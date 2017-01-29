namespace ReleasePackager
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class Packer : Form
    {
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

        public Packer()
        {
            InitializeComponent();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            archiveName = tbArchiveName.Text + ".bsa";
            zipName = tbArchiveName.Text + ".zip";
            modSourcePath = tbSource.Text;

            compilerPath = Path.Combine(tbGamePath.Text, "Papyrus Compiler", "PapyrusCompiler.exe");
            compilerFlagsPath = Path.Combine(tbGamePath.Text, "Papyrus Compiler", "TESV_Papyrus_Flags.flg");
            coreScriptsSourcePath = Path.Combine(tbGamePath.Text, "Data", "Scripts", "Source");
            archiverPath = Path.Combine(tbGamePath.Text, ArchiverFilename);

            outputDirRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "packTest");
            tempDirRoot = GetTemporaryDirectory();
            tempDirData = Path.Combine(tempDirRoot, "Data");
            manifestPath = Path.Combine(tempDirRoot, ArchiveManifestFilename);
            zipSourceDir = Path.Combine(tempDirRoot, "ToZip");

            await DoWorkNotOnUIThread();
        }

        private async Task DoWorkNotOnUIThread()
        {
            await Task.Run(() =>
            {
                CopyEsps();
                CopySkse();

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

        private void CopyEsps()
        {
            AddProgress("Copy ESP files");

            CopyFiles(modSourcePath, zipSourceDir, "*.esp");

            AddProgress("All ESPs copied");
        }

        private void CopySkse()
        {
            AddProgress("Copy SKSE folder");

            var skseSource = Path.Combine(modSourcePath, "SKSE");
            var skseDest = Path.Combine(zipSourceDir, "SKSE");
            CopyDirectory(skseSource, skseDest, true);
            
            AddProgress("SKSE copied");
        }

        private void CopyScripts()
        {
            AddProgress("Copy Scripts source");

            var sourcePath = Path.Combine(modSourcePath, "Scripts", "Source");
            var destPath = Path.Combine(tempDirData, "Scripts", "Source");
            CopyFiles(sourcePath, destPath, "*.psc");

            AddProgress("All Scripts source copied");
        }

        private void CompileScripts()
        {
            AddProgress("Compile Scripts");

            var exePath = $"\"{compilerPath}\"";
            var scriptSourcePath = Path.Combine(tempDirData, "Scripts", "Source");
            var compiledOutputPath = Path.Combine(tempDirData, "Scripts");
            string args = $"\"{scriptSourcePath}\" -a -f=\"{compilerFlagsPath}\" -i=\"{scriptSourcePath};{coreScriptsSourcePath}\" -o=\"{compiledOutputPath}\"";

            System.Diagnostics.Process papCompiler;
            try
            {
                papCompiler = System.Diagnostics.Process.Start(exePath, args);
                papCompiler.WaitForExit();
            }
            catch(Exception ex)
            {
                AddProgress("Script error! " + ex.Message);
                throw;
            }

            AddProgress("All Scripts compiled");
        }

        private void CopyOtherAssets()
        {
            AddProgress("Copy Interface folder");
            CopyDirectory(Path.Combine(modSourcePath, "Interface"), Path.Combine(tempDirData, "Interface"), true);
            AddProgress("Interface folder copied");

            AddProgress("Copy Seq folder");
            CopyDirectory(Path.Combine(modSourcePath, "Seq"), Path.Combine(tempDirData, "Seq"), true);
            AddProgress("Seq folder copied");

            AddProgress("Copy Sound folder");
            CopyDirectory(Path.Combine(modSourcePath, "Sound"), Path.Combine(tempDirData, "Sound"), true);
            AddProgress("Sound folder copied");
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
            AddToManifest(tempDirData, "Interface", true);
            AddToManifest(tempDirData, "Seq", true);
            AddToManifest(tempDirData, "Sound", true);
            AddToManifest(tempDirData, "Scripts", true);
        }

        private void CreateArchive()
        {
            var archiverPath = Path.Combine(tempDirRoot, ArchiverFilename);
            var archiver = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = tempDirRoot,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
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
            var archivePath = Path.Combine(tempDirRoot, archiveName);
            File.Copy(archivePath, Path.Combine(zipSourceDir, archiveName), true);
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

        private void CopyFiles(string sourceDirName, string destDirName, string filePattern)
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
                AddProgress($"Copied {filename}");
            }
        }

        private void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                AddProgress("No directory to copy");
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
                    CopyDirectory(subdir.FullName, temppath, copySubDirs);
                }
            }

            AddProgress($"Copied {sourceDirName}");
        }

        private void AddToManifest(string rootName, string usedPath, bool recurse)
        {
            var sourceDirName = Path.Combine(rootName, usedPath);
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                AddProgress("No directory to copy");
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
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (recurse)
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(usedPath, subdir.Name);
                    AddToManifest(rootName, temppath, recurse);
                }
            }

        }

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

        delegate void SetTextCallback(string text);
    }
}
