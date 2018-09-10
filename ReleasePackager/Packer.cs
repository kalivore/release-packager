using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReleasePackager
{
    public partial class Packer : Form
    {
        private string mainEspName;
        private string archiveName;
        private string zipName;
        private string modSourcePath;
        private string tempDirRoot;
        private string tempDirData;
        private string manifestPath;
        private string archiverPath;
        private string compilerPath;
        private string compilerFlagsPath;
        private string coreScriptsSourcePath;
        private string outputDirRoot;
        private string zipSourceDir;

        private const string ArchiverFilename = "Archive.exe";
        private const string ArchiveBuilderFilename = "ArchiveBuilder.txt";
        private const string ArchiveManifestFilename = "ArchiveManifest.txt";

        private string configFilePath;
        private ConfigCollection config;
        private List<FolderCopyConfig> otherFolders;

        private int manifestFilesTotal;

        private int scriptsTotal;
        private int scriptsDone;

        public Packer()
        {
            InitializeComponent();

            configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            //SavePresets();
            LoadPresets();

            otherFolders = new List<FolderCopyConfig> {
                new FolderCopyConfig { FolderName = "Interface", IncludeInBsa = true },
                new FolderCopyConfig { FolderName = "Meshes", IncludeInBsa = true },
                new FolderCopyConfig { FolderName = "Seq", IncludeInBsa = true },
                new FolderCopyConfig { FolderName = "Sound", IncludeInBsa = true },
                new FolderCopyConfig { FolderName = "SkyProc Patchers", IncludeInBsa = false },
                new FolderCopyConfig { FolderName = "SKSE", IncludeInBsa = false },
                new FolderCopyConfig { FolderName = "Textures", IncludeInBsa = true },
            };

            cbPresets.DisplayMember = "ModName";
            cbPresets.ValueMember = "ModName";
            cbPresets.DataSource = config.ModSetups;
            cbPresets.SelectedIndexChanged += CbPresets_SelectedIndexChanged;
            tbOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "packTest");
        }

        private void CbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((ComboBox)sender).SelectedItem as ModSetup;
            tbZipName.Text = item?.ZipName;
            tbSource.Text = item?.SourcePath;
            if (item?.GameName != null)
            {
                GameSetup gameSetup = null;
                foreach (var setup in config.GameSetups)
                {
                    if (setup.GameName == item?.GameName)
                    {
                        gameSetup = setup;
                        break;
                    }
                }
                if (gameSetup?.GamePath != null)
                {
                    tbGamePath.Text = gameSetup?.GamePath;
                }
                if (gameSetup?.ArchiverPath != null)
                {
                    tbArchiverPath.Text = gameSetup?.ArchiverPath;
                }
                if (gameSetup?.OutputPath != null)
                {
                    tbOutput.Text = gameSetup?.OutputPath;
                }
            }
            cbMainEspName.DataSource = PopulateEsps(tbSource.Text);
            cbMainEspName.SelectedIndex = item.MainEspIndex <= (cbMainEspName.Items.Count - 1) ? item.MainEspIndex : -1;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            var config = new Config();
            var dr = config.ShowDialog();
            config.Dispose();
        }

        private void btnSourcePath_Click(object sender, EventArgs e) => pathSelect(tbSource);
        private void btnOutputPath_Click(object sender, EventArgs e) => pathSelect(tbOutput);
        private void btnGamePath_Click(object sender, EventArgs e) => pathSelect(tbGamePath);
        private void btnArchiverPath_Click(object sender, EventArgs e) => pathSelect(tbArchiverPath);

        private void pathSelect(TextBox tb)
        {
            fbPath.SelectedPath = tb.Text;
            var dr = fbPath.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb.Text = fbPath.SelectedPath;
            }
        }
        

        private async void btnGo_Click(object sender, EventArgs e)
        {
            mainEspName = cbMainEspName.Text;
            archiveName = mainEspName + ".bsa";
            zipName = tbZipName.Text + ".zip";
            modSourcePath = tbSource.Text;

            compilerPath = Path.Combine(tbGamePath.Text, "Papyrus Compiler", "PapyrusCompiler.exe");
            compilerFlagsPath = Path.Combine(tbGamePath.Text, "Papyrus Compiler", "TESV_Papyrus_Flags.flg");
            coreScriptsSourcePath = Path.Combine(tbGamePath.Text, "Data", "Scripts", "Source");
            archiverPath = Path.Combine(tbArchiverPath.Text, ArchiverFilename);

            outputDirRoot = tbOutput.Text;
            tempDirRoot = GetTemporaryDirectory();
            tempDirData = Path.Combine(tempDirRoot, "Data");
            manifestPath = Path.Combine(tempDirRoot, ArchiveManifestFilename);
            zipSourceDir = Path.Combine(tempDirRoot, "ToZip");

            tbProgress.Text = string.Empty;

            scriptsDone = 0;
            scriptsTotal = 0;
            lblProgressScripts.Text = string.Empty;
            pbScripts.Value = 0;

            await DoWorkNotOnUIThread();
        }


        private async Task DoWorkNotOnUIThread()
        {
            try
            {
                await Task.Run(() =>
                {
                    CopyEsps();

                    CopyScripts();
                    CompileScripts();

                    CopyOtherAssets();

                    CopyArchiver();
                    CreateArchiveBuilder();
                    CreateArchiveManifest();
                    BuildArchiveManifest();

                    CreateArchive();

                    CopyArchive();

                    CreateZip();

                    DeleteTemporaryDirectory();
                });

                AddProgress("ALL DONE! :D");
            }
            catch (Exception ex)
            {
                AddProgress("OH NOES! Problem while processing.. ");
                AddProgress(ex.Message);
            }
        }

        private List<KeyValuePair<int, string>> PopulateEsps(string sourceDirName)
        {
            var items = new List<KeyValuePair<int, string>>();
            string[] files;
            try
            {
                files = Directory.GetFiles(sourceDirName, "*.esp");
            }
            catch (Exception ex)
            {
                AddProgress("Error getting esp files: " + ex.Message);
                return items;
            }

            for (int i = 0; i < files.Length; i++)
            {
                var filename = Path.GetFileNameWithoutExtension(files[i]);
                items.Add(new KeyValuePair<int, string>(i, filename));
            }

            return items;
        }

        private void CopyEsps()
        {
            AddProgress("Copy ESP files");

            CopyFiles(modSourcePath, zipSourceDir, "*.esp");

            AddProgress("All ESPs copied");
        }

        private void CopyScripts()
        {
            AddProgress("Copy Scripts source");

            var sourcePath = Path.Combine(modSourcePath, "Scripts", "Source");
            var destPath = Path.Combine(tempDirData, "Scripts", "Source");
            CopyFiles(sourcePath, destPath, "*.psc", () => { return scriptsTotal++; });

            AddProgress("All Scripts source copied");
        }

        private void CompileScripts()
        {
            if (scriptsTotal == 0)
            {
                AddProgress("No Scripts to Compile!");
                return;
            }

            AddProgress("Compile Scripts");
            UpdateScriptProgress($"{scriptsDone}/{scriptsTotal}");
            UpdateScriptBar(scriptsDone, scriptsTotal);

            var exePath = $"\"{compilerPath}\"";
            var scriptSourcePath = Path.Combine(tempDirData, "Scripts", "Source");
            var compiledOutputPath = Path.Combine(tempDirData, "Scripts");
            string args = $"\"{scriptSourcePath}\" -a -f=\"{compilerFlagsPath}\" -i=\"{scriptSourcePath};{coreScriptsSourcePath}\" -o=\"{compiledOutputPath}\"";

            var papCompiler = new Process();
            papCompiler.StartInfo.FileName = exePath;
            papCompiler.StartInfo.Arguments = args;
            papCompiler.StartInfo.UseShellExecute = false;
            papCompiler.StartInfo.CreateNoWindow = true;
            papCompiler.StartInfo.RedirectStandardOutput = true;
            papCompiler.OutputDataReceived += new DataReceivedEventHandler(CompilerOutputHandler);
            papCompiler.StartInfo.RedirectStandardError = true;

            string capturedError = string.Empty;
            try
            {
                AddProgress("------------ BEGIN PAPYRUS OUTPUT ------------");
                papCompiler.Start();
                papCompiler.BeginOutputReadLine();

                papCompiler.WaitForExit();

                var srErr = papCompiler.StandardError;
                capturedError = srErr.ReadToEnd();

                if (papCompiler.ExitCode < 0)
                {
                    throw new Exception("Non-specific compile error");
                }

            }
            catch (Exception ex)
            {
                AddProgress("Script error! " + ex.Message);
                capturedError = capturedError.Replace("\n", Environment.NewLine);
                AddProgress(capturedError);
                throw;
            }
            finally
            {
                AddProgress("------------ END PAPYRUS OUTPUT ------------");
                papCompiler.Dispose();
            }

            AddProgress("Scripts compile complete");
        }

        private void CompilerOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            var text = outLine.Data?.Replace("\n", Environment.NewLine);
            AddProgress(text);
            if (text?.Trim() == "Assembly succeeded")
            {
                scriptsDone++;
                UpdateScriptProgress($"{scriptsDone}/{scriptsTotal}");
                UpdateScriptBar(scriptsDone, scriptsTotal);
            }
        }

        private void CopyOtherAssets()
        {
            foreach (var item in otherFolders)
            {
                CopyDirectoryStructure(item.FolderName, item.IncludeInBsa);
            }
        }

        private void CopyArchiver()
        {
            File.Copy(archiverPath, Path.Combine(tempDirRoot, ArchiverFilename), true);
        }

        private void CreateArchiveBuilder()
        {
            var builderPath = Path.Combine(tempDirRoot, ArchiveBuilderFilename);
            using (StreamWriter sw = File.CreateText(builderPath))
            {
                sw.WriteLine("Log: " + "ArchiveLog.txt");
                sw.WriteLine("New Archive");
                //sw.WriteLine("Check: Meshes");
                //sw.WriteLine("Check: Textures");
                sw.WriteLine("Check: Menus");
                sw.WriteLine("Check: Sounds");
                sw.WriteLine("Check: Voices");
                //sw.WriteLine("Check: Shaders");
                //sw.WriteLine("Check: Trees");
                //sw.WriteLine("Check: Fonts");
                sw.WriteLine("Check: Misc");
                sw.WriteLine("Check: Retain Directory Names");
                sw.WriteLine("Check: Retain File Names");
                //sw.WriteLine("Check: Compress Archive");
                sw.WriteLine("Set File Group Root: " + "Data\\");
                sw.WriteLine("Add File Group: " + ArchiveManifestFilename);
                sw.WriteLine("Save Archive: " + archiveName);
            }

        }

        private void CreateArchiveManifest()
        {
            var fs = File.Create(manifestPath);
            fs.Close();
        }

        private void BuildArchiveManifest()
        {
            AddProgress("Build Archive Manifest");
            AddToManifest("Interface", tempDirData, "Interface", true);
            AddToManifest("Seq", tempDirData, "Seq", true);
            AddToManifest("Sound", tempDirData, "Sound", true);
            AddToManifest("Scripts", tempDirData, "Scripts", true);
            AddProgress("Archive Manifest Complete");
        }

        private void CreateArchive()
        {
            if (manifestFilesTotal == 0)
            {
                AddProgress("No files to put in BSA!");
                return;
            }

            var archiverPath = Path.Combine(tempDirRoot, ArchiverFilename);
            var archiver = new Process();
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = tempDirRoot,
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = archiverPath,
                Arguments = ArchiveBuilderFilename,
                UseShellExecute = false
            };
            try
            {
                archiver.StartInfo = startInfo;
                archiver.Start();
                archiver.WaitForExit();
            }
            catch (Exception ex)
            {
                AddProgress("Archiver error! " + ex.Message);
                throw;
            }

            AddProgress("Archive created");
        }

        private void CopyArchive()
        {
            try
            {

                var archivePath = Path.Combine(tempDirRoot, archiveName);
                File.Copy(archivePath, Path.Combine(zipSourceDir, archiveName), true);
            }
            catch (Exception ex)
            {
                AddProgress("Error copying BSA! " + ex.Message);
                throw;
            }
        }

        private void CreateZip()
        {
            var zipPath = Path.Combine(outputDirRoot, zipName);
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            try
            {
                ZipFile.CreateFromDirectory(zipSourceDir, zipPath);
            }
            catch (Exception ex)
            {
                AddProgress("Zipping error! " + ex.Message);
                throw;
            }

            AddProgress("Zip created");
        }

        private void DeleteTemporaryDirectory()
        {
            Directory.Delete(tempDirRoot, true);

            AddProgress("Temp directory removed");
        }


        private string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        private void CopyFiles(string sourceDirName, string destDirName, string filePattern, Func<int> copyCompleteCallback = null)
        {
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            string[] files;
            try
            {
                files = Directory.GetFiles(sourceDirName, filePattern);
            }
            catch (Exception ex)
            {
                AddProgress("Error copying files: " + ex.Message);
                return;
            }

            for (int i = 0; i < files.Length; i++)
            {
                var filename = Path.GetFileName(files[i]);
                File.Copy(Path.Combine(sourceDirName, filename), Path.Combine(destDirName, filename), true);
                copyCompleteCallback?.Invoke();
                AddProgress($"Copied {filename}");
            }
        }

        private void CopyDirectoryStructure(string dirDisplayName, bool includeInBsa)
        {
            var sourceDirName = Path.Combine(modSourcePath, dirDisplayName);
            var destDirName = Path.Combine(includeInBsa ? tempDirData : zipSourceDir, dirDisplayName);

            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (dir.Exists)
            {
                AddProgress($"Copy {dirDisplayName} folder structure");
                CopyDirectory(dirDisplayName, sourceDirName, destDirName, true);
                AddProgress($"{dirDisplayName} folder structure copied");
            }
            else
            {
                AddProgress($"No {dirDisplayName} directory to copy");
            }
        }

        private void CopyDirectory(string dirDisplayName, string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                AddProgress($"No {dirDisplayName} directory to copy");
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    CopyDirectory(subdir.Name, subdir.FullName, temppath, copySubDirs);
                }
            }

            AddProgress($"Copied {sourceDirName}");
        }

        private void AddToManifest(string displayName, string rootName, string usedPath, bool recurse)
        {
            var sourceDirName = Path.Combine(rootName, usedPath);
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                AddProgress($"No {displayName} directory for manifest");
                return;
            }

            using (StreamWriter sw = File.AppendText(manifestPath))
            {
                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string filepath = Path.Combine(usedPath, file.Name);
                    sw.WriteLine(filepath);
                    AddProgress($"Added {filepath} to manifest");
                    manifestFilesTotal++;
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (recurse)
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(usedPath, subdir.Name);
                    AddToManifest(subdir.Name, rootName, temppath, recurse);
                }
            }

        }

        private void LoadPresets()
        {
            var configCollection = new ConfigCollection();

            using (var fileStream = File.OpenRead(configFilePath))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ConfigCollection));

                using (var stream = new MemoryStream())
                {
                    fileStream.CopyTo(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    configCollection = (ConfigCollection)ser.ReadObject(stream);
                }
            }

            config = configCollection;
        }

        private void SavePresets()
        {
            var modSetupCollection = new ConfigCollection
            {
                GameSetups = new List<GameSetup>
                {
                    new GameSetup
                    {
                        GameName = "Skyrim",
                        GamePath = @"G:\Steam\SteamApps\common\Skyrim",
                        ArchiverPath = @"G:\Steam\SteamApps\common\Skyrim",
                        OutputPath = @"C:\Users\Ben\Desktop\packTest"
                    },
                    new GameSetup
                    {
                        GameName = "Skyrim SE",
                        GamePath = @"H:\Steam\steamapps\common\Skyrim Special Edition",
                        ArchiverPath = @"H:\Steam\steamapps\common\Skyrim Special Edition\Tools\Archive",
                        OutputPath = @"C:\Users\Ben\Desktop\packTest"
                    }
                },
                ModSetups = new List<ModSetup>
                {
                    new ModSetup(),
                    new ModSetup
                    {
                        GameName = "Skyrim",
                        ModName = "Arrow Sheaves",
                        MainEspIndex = 0,
                        ZipName = "Arrow Sheaves",
                        SourcePath = @"F:\Games Work\Skyrim\Arrow Sheaves\mod"
                    },
                    new ModSetup
                    {
                        GameName = "Skyrim",
                        ModName = "Poisoning Extended",
                        MainEspIndex = 0,
                        ZipName = "Poisoning Extended",
                        SourcePath = @"F:\Games Work\Skyrim\Poisoning Extended\mod"
                    },
                    new ModSetup
                    {
                        GameName = "Skyrim",
                        ModName = "Follower Potions",
                        MainEspIndex = 0,
                        ZipName = "Follower Potions",
                        SourcePath = @"F:\Games Work\Skyrim\Follower Potions\mod"
                    },
                    new ModSetup
                    {
                        GameName = "Skyrim SE",
                        ModName = "Poisoning Extended SE",
                        MainEspIndex = 0,
                        ZipName = "Poisoning Extended",
                        SourcePath = @"F:\Games Work\Skyrim\Poisoning Extended SE\mod"
                    }
                }
            };

            using (var stream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ConfigCollection));
                ser.WriteObject(stream, config);

                using (var fileStream = File.Create(configFilePath))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
            }
        }


        delegate void SetTextCallback(string text);

        private void AddProgress(string progress)
        {
            if (this.tbProgress.InvokeRequired)
            {
                var d = new SetTextCallback(AddProgress);
                this.Invoke(d, new object[] { progress });
            }
            else
            {
                tbProgress.AppendText(Environment.NewLine + progress);
            }
        }

        private void UpdateScriptProgress(string progress)
        {
            if (this.lblProgressScripts.InvokeRequired)
            {
                var d = new SetTextCallback(UpdateScriptProgress);
                this.Invoke(d, new object[] { progress });
            }
            else
            {
                lblProgressScripts.Text = progress;
            }
        }

        delegate void SetProgressBarCallback(int val, int max);

        private void UpdateScriptBar(int val, int max)
        {
            if (this.pbScripts.InvokeRequired)
            {
                var d = new SetProgressBarCallback(UpdateScriptBar);
                this.Invoke(d, new object[] { val, max });
            }
            else
            {
                pbScripts.Maximum = max;
                if (val == max)
                {
                    pbScripts.Maximum = max + 1;
                    pbScripts.Value = val + 1;
                    pbScripts.Maximum = max;
                }
                else
                { 
                    pbScripts.Value = val + 1;
                }
                pbScripts.Value = val;
            }
        }

    }

    public struct FolderCopyConfig
    {
        public string FolderName { get; set; }
        public bool IncludeInBsa { get; set; }
    }
}
