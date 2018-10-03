using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace ReleasePackager
{
    public partial class Config : Form
    {
        public string ConfigFilePath;

        public ConfigCollection ConfigCollection;

        public Config()
        {
            InitializeComponent();

            ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

            cbGame.DisplayMember = "GameName";
            cbGame.ValueMember = "Id";
            cbGame.SelectedIndexChanged += CbGame_SelectedIndexChanged;

            cbMod.DisplayMember = "ModName";
            cbMod.ValueMember = "Id";
            cbMod.SelectedIndexChanged += CbMod_SelectedIndexChanged;

            cbModGames.DisplayMember = "GameName";
            cbModGames.ValueMember = "Id";
            cbModGames.SelectedIndexChanged += CbModGames_SelectedIndexChanged;
        }

        public void LoadConfig()
        {
            var configCollection = new ConfigCollection();

            using (var fileStream = File.OpenRead(ConfigFilePath))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ConfigCollection));

                using (var stream = new MemoryStream())
                {
                    fileStream.CopyTo(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    configCollection = (ConfigCollection)ser.ReadObject(stream);
                }
            }

            ConfigCollection = configCollection;
            cbGame.DataSource = ConfigCollection.GameSetups;
            cbMod.DataSource = ConfigCollection.ModSetups;
        }

        public void WriteConfig()
        {
            using (var stream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ConfigCollection));
                ser.WriteObject(stream, ConfigCollection);

                using (var fileStream = File.Create(ConfigFilePath))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
            }
        }


        public ConfigCollection CreatePresets()
        {
            var modSetupCollection = new ConfigCollection
            {
                GameSetups = new List<GameSetup>
                {
                    new GameSetup()
                }
            };
            modSetupCollection.ModSetups = new List<ModSetup>
            {
                new ModSetup()
            };

            return modSetupCollection;
        }

        public List<KeyValuePair<int, string>> PopulateEsps(string sourceDirName)
        {
            var items = new List<KeyValuePair<int, string>>();
            if (string.IsNullOrWhiteSpace(sourceDirName))
            {
                return items;
            }

            string[] files;
            try
            {
                files = Directory.GetFiles(sourceDirName, "*.esp");
            }
            catch (Exception ex)
            {
                return items;
            }

            for (int i = 0; i < files.Length; i++)
            {
                var filename = Path.GetFileNameWithoutExtension(files[i]);
                items.Add(new KeyValuePair<int, string>(i, filename));
            }

            return items;
        }


        private void Config_Load(object sender, EventArgs e)
        {
        }

        private void btnGamePath_Click(object sender, EventArgs e) => pathSelect(tbGamePath);
        private void btnArchiverPath_Click(object sender, EventArgs e) => pathSelect(tbArchiverPath);
        private void btnSourcePath_Click(object sender, EventArgs e) => pathSelect(tbSource);
        private void btnOutputPath_Click(object sender, EventArgs e) => pathSelect(tbOutput);

        private void pathSelect(TextBox tb)
        {
            fbConfigPaths.SelectedPath = tb.Text;
            var dr = fbConfigPaths.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb.Text = fbConfigPaths.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var game = cbGame.SelectedItem as GameSetup;
            var configGame = ConfigCollection.GameSetups.SingleOrDefault(x => x.Id == game.Id);
            if (configGame == null)
            {
                configGame = new GameSetup();
                ConfigCollection.GameSetups.Add(configGame);
            }
            configGame.GameName = tbGameName.Text;
            configGame.GamePath = tbGamePath.Text;
            configGame.ArchiverPath = tbArchiverPath.Text;

            var mod = cbMod.SelectedItem as ModSetup;
            var configMod = ConfigCollection.ModSetups.SingleOrDefault(x => x.Id == mod.Id);
            if (configMod == null)
            {
                configMod = new ModSetup();
                ConfigCollection.ModSetups.Add(configMod);
            }
            configMod.ModName = tbModName.Text;
            configMod.GameId = (cbModGames.SelectedItem as GameSetup).Id;
            configMod.SourcePath = tbSource.Text;
            configMod.MainEspIndex = cbMainEspName.SelectedIndex;
            configMod.ZipName = tbZipName.Text;
            configMod.OutputPath = tbOutput.Text;

            WriteConfig();
            Close();
        }

        private void CbGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cbGame.SelectedItem as GameSetup;
            tbGameName.Text = item?.GameName;
            tbGamePath.Text = item?.GamePath;
            tbArchiverPath.Text = item?.ArchiverPath;
        }

        private void CbMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cbMod.SelectedItem as ModSetup;
            tbModName.Text = item?.ModName;
            cbModGames.DataSource = ConfigCollection.GameSetups;
            cbModGames.SelectedItem = ConfigCollection.GameSetups.SingleOrDefault(x => x.Id == item?.GameId);
            tbSource.Text = item?.SourcePath;
            cbMainEspName.DataSource = PopulateEsps(tbSource.Text);
            cbMainEspName.SelectedIndex = item.MainEspIndex <= (cbMainEspName.Items.Count - 1) ? item.MainEspIndex : -1;
            tbZipName.Text = item?.ZipName;
            tbOutput.Text = item?.OutputPath;
        }

        private void CbModGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cbMod.SelectedItem as ModSetup;
            item.GameId = (cbModGames.SelectedItem as GameSetup).Id;
        }

    }
}
