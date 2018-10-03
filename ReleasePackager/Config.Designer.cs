namespace ReleasePackager
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbMainEspName = new System.Windows.Forms.ComboBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnOutputPath = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lblArchiver = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.btnArchiverPath = new System.Windows.Forms.Button();
            this.btnGamePath = new System.Windows.Forms.Button();
            this.lblZipName = new System.Windows.Forms.Label();
            this.lblMainEspName = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.tbArchiverPath = new System.Windows.Forms.TextBox();
            this.tbGamePath = new System.Windows.Forms.TextBox();
            this.btnSourcePath = new System.Windows.Forms.Button();
            this.tbZipName = new System.Windows.Forms.TextBox();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.lblMod = new System.Windows.Forms.Label();
            this.cbMod = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbModName = new System.Windows.Forms.TextBox();
            this.lblModName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGames = new System.Windows.Forms.TabPage();
            this.lblGameName = new System.Windows.Forms.Label();
            this.tbGameName = new System.Windows.Forms.TextBox();
            this.lblGame = new System.Windows.Forms.Label();
            this.cbGame = new System.Windows.Forms.ComboBox();
            this.tpMods = new System.Windows.Forms.TabPage();
            this.cbModGames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fbConfigPaths = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tpGames.SuspendLayout();
            this.tpMods.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMainEspName
            // 
            this.cbMainEspName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMainEspName.DisplayMember = "Value";
            this.cbMainEspName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMainEspName.FormattingEnabled = true;
            this.cbMainEspName.Location = new System.Drawing.Point(79, 125);
            this.cbMainEspName.Name = "cbMainEspName";
            this.cbMainEspName.Size = new System.Drawing.Size(587, 21);
            this.cbMainEspName.TabIndex = 26;
            this.cbMainEspName.ValueMember = "Key";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(8, 155);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(63, 13);
            this.lblOutput.TabIndex = 12;
            this.lblOutput.Text = "Output path";
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputPath.Location = new System.Drawing.Point(642, 150);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Size = new System.Drawing.Size(24, 23);
            this.btnOutputPath.TabIndex = 21;
            this.btnOutputPath.Text = "...";
            this.btnOutputPath.UseVisualStyleBackColor = true;
            this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(79, 152);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(557, 20);
            this.tbOutput.TabIndex = 20;
            // 
            // lblArchiver
            // 
            this.lblArchiver.AutoSize = true;
            this.lblArchiver.Location = new System.Drawing.Point(6, 113);
            this.lblArchiver.Name = "lblArchiver";
            this.lblArchiver.Size = new System.Drawing.Size(70, 13);
            this.lblArchiver.TabIndex = 13;
            this.lblArchiver.Text = "Archiver path";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(6, 85);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(59, 13);
            this.lblData.TabIndex = 14;
            this.lblData.Text = "Game path";
            // 
            // btnArchiverPath
            // 
            this.btnArchiverPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchiverPath.Location = new System.Drawing.Point(640, 107);
            this.btnArchiverPath.Name = "btnArchiverPath";
            this.btnArchiverPath.Size = new System.Drawing.Size(24, 23);
            this.btnArchiverPath.TabIndex = 24;
            this.btnArchiverPath.Text = "...";
            this.btnArchiverPath.UseVisualStyleBackColor = true;
            this.btnArchiverPath.Click += new System.EventHandler(this.btnArchiverPath_Click);
            // 
            // btnGamePath
            // 
            this.btnGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGamePath.Location = new System.Drawing.Point(640, 79);
            this.btnGamePath.Name = "btnGamePath";
            this.btnGamePath.Size = new System.Drawing.Size(24, 23);
            this.btnGamePath.TabIndex = 25;
            this.btnGamePath.Text = "...";
            this.btnGamePath.UseVisualStyleBackColor = true;
            this.btnGamePath.Click += new System.EventHandler(this.btnGamePath_Click);
            // 
            // lblZipName
            // 
            this.lblZipName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZipName.AutoSize = true;
            this.lblZipName.Location = new System.Drawing.Point(8, 181);
            this.lblZipName.Name = "lblZipName";
            this.lblZipName.Size = new System.Drawing.Size(57, 13);
            this.lblZipName.TabIndex = 15;
            this.lblZipName.Text = "Output Zip";
            // 
            // lblMainEspName
            // 
            this.lblMainEspName.AutoSize = true;
            this.lblMainEspName.Location = new System.Drawing.Point(8, 129);
            this.lblMainEspName.Name = "lblMainEspName";
            this.lblMainEspName.Size = new System.Drawing.Size(54, 13);
            this.lblMainEspName.TabIndex = 16;
            this.lblMainEspName.Text = "Main ESP";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(8, 102);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(65, 13);
            this.lblSource.TabIndex = 17;
            this.lblSource.Text = "Source path";
            // 
            // tbArchiverPath
            // 
            this.tbArchiverPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbArchiverPath.Location = new System.Drawing.Point(77, 110);
            this.tbArchiverPath.Name = "tbArchiverPath";
            this.tbArchiverPath.Size = new System.Drawing.Size(557, 20);
            this.tbArchiverPath.TabIndex = 22;
            // 
            // tbGamePath
            // 
            this.tbGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGamePath.Location = new System.Drawing.Point(77, 82);
            this.tbGamePath.Name = "tbGamePath";
            this.tbGamePath.Size = new System.Drawing.Size(557, 20);
            this.tbGamePath.TabIndex = 23;
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourcePath.Location = new System.Drawing.Point(642, 97);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(24, 23);
            this.btnSourcePath.TabIndex = 19;
            this.btnSourcePath.Text = "...";
            this.btnSourcePath.UseVisualStyleBackColor = true;
            this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
            // 
            // tbZipName
            // 
            this.tbZipName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbZipName.Location = new System.Drawing.Point(79, 178);
            this.tbZipName.Name = "tbZipName";
            this.tbZipName.Size = new System.Drawing.Size(587, 20);
            this.tbZipName.TabIndex = 11;
            // 
            // tbSource
            // 
            this.tbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSource.Location = new System.Drawing.Point(79, 99);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(557, 20);
            this.tbSource.TabIndex = 18;
            // 
            // lblMod
            // 
            this.lblMod.AutoSize = true;
            this.lblMod.Location = new System.Drawing.Point(8, 18);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(28, 13);
            this.lblMod.TabIndex = 16;
            this.lblMod.Text = "Mod";
            // 
            // cbMod
            // 
            this.cbMod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMod.DisplayMember = "Value";
            this.cbMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMod.FormattingEnabled = true;
            this.cbMod.Location = new System.Drawing.Point(79, 15);
            this.cbMod.Name = "cbMod";
            this.cbMod.Size = new System.Drawing.Size(587, 21);
            this.cbMod.TabIndex = 26;
            this.cbMod.ValueMember = "Key";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(617, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbModName
            // 
            this.tbModName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbModName.Location = new System.Drawing.Point(79, 73);
            this.tbModName.Name = "tbModName";
            this.tbModName.Size = new System.Drawing.Size(587, 20);
            this.tbModName.TabIndex = 18;
            // 
            // lblModName
            // 
            this.lblModName.AutoSize = true;
            this.lblModName.Location = new System.Drawing.Point(8, 76);
            this.lblModName.Name = "lblModName";
            this.lblModName.Size = new System.Drawing.Size(35, 13);
            this.lblModName.TabIndex = 17;
            this.lblModName.Text = "Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpGames);
            this.tabControl1.Controls.Add(this.tpMods);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 236);
            this.tabControl1.TabIndex = 28;
            // 
            // tpGames
            // 
            this.tpGames.Controls.Add(this.lblGameName);
            this.tpGames.Controls.Add(this.tbGameName);
            this.tpGames.Controls.Add(this.lblGame);
            this.tpGames.Controls.Add(this.cbGame);
            this.tpGames.Controls.Add(this.tbArchiverPath);
            this.tpGames.Controls.Add(this.tbGamePath);
            this.tpGames.Controls.Add(this.lblArchiver);
            this.tpGames.Controls.Add(this.btnGamePath);
            this.tpGames.Controls.Add(this.lblData);
            this.tpGames.Controls.Add(this.btnArchiverPath);
            this.tpGames.Location = new System.Drawing.Point(4, 22);
            this.tpGames.Name = "tpGames";
            this.tpGames.Padding = new System.Windows.Forms.Padding(3);
            this.tpGames.Size = new System.Drawing.Size(672, 210);
            this.tpGames.TabIndex = 0;
            this.tpGames.Text = "Games";
            this.tpGames.UseVisualStyleBackColor = true;
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(6, 55);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(35, 13);
            this.lblGameName.TabIndex = 29;
            this.lblGameName.Text = "Name";
            // 
            // tbGameName
            // 
            this.tbGameName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGameName.Location = new System.Drawing.Point(77, 52);
            this.tbGameName.Name = "tbGameName";
            this.tbGameName.Size = new System.Drawing.Size(557, 20);
            this.tbGameName.TabIndex = 30;
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Location = new System.Drawing.Point(6, 16);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(35, 13);
            this.lblGame.TabIndex = 27;
            this.lblGame.Text = "Game";
            // 
            // cbGame
            // 
            this.cbGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGame.DisplayMember = "Value";
            this.cbGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGame.FormattingEnabled = true;
            this.cbGame.Location = new System.Drawing.Point(77, 13);
            this.cbGame.Name = "cbGame";
            this.cbGame.Size = new System.Drawing.Size(589, 21);
            this.cbGame.TabIndex = 28;
            this.cbGame.ValueMember = "Key";
            // 
            // tpMods
            // 
            this.tpMods.Controls.Add(this.lblMod);
            this.tpMods.Controls.Add(this.cbMod);
            this.tpMods.Controls.Add(this.cbModGames);
            this.tpMods.Controls.Add(this.cbMainEspName);
            this.tpMods.Controls.Add(this.lblModName);
            this.tpMods.Controls.Add(this.lblOutput);
            this.tpMods.Controls.Add(this.tbSource);
            this.tpMods.Controls.Add(this.btnOutputPath);
            this.tpMods.Controls.Add(this.tbZipName);
            this.tpMods.Controls.Add(this.tbOutput);
            this.tpMods.Controls.Add(this.tbModName);
            this.tpMods.Controls.Add(this.btnSourcePath);
            this.tpMods.Controls.Add(this.label1);
            this.tpMods.Controls.Add(this.lblSource);
            this.tpMods.Controls.Add(this.lblMainEspName);
            this.tpMods.Controls.Add(this.lblZipName);
            this.tpMods.Location = new System.Drawing.Point(4, 22);
            this.tpMods.Name = "tpMods";
            this.tpMods.Padding = new System.Windows.Forms.Padding(3);
            this.tpMods.Size = new System.Drawing.Size(672, 210);
            this.tpMods.TabIndex = 1;
            this.tpMods.Text = "Mods";
            this.tpMods.UseVisualStyleBackColor = true;
            // 
            // cbModGames
            // 
            this.cbModGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModGames.DisplayMember = "Value";
            this.cbModGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModGames.FormattingEnabled = true;
            this.cbModGames.Location = new System.Drawing.Point(79, 42);
            this.cbModGames.Name = "cbModGames";
            this.cbModGames.Size = new System.Drawing.Size(587, 21);
            this.cbModGames.TabIndex = 26;
            this.cbModGames.ValueMember = "Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Game";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 289);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.MinimumSize = new System.Drawing.Size(720, 300);
            this.Name = "Config";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpGames.ResumeLayout(false);
            this.tpGames.PerformLayout();
            this.tpMods.ResumeLayout(false);
            this.tpMods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMainEspName;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnOutputPath;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label lblArchiver;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button btnArchiverPath;
        private System.Windows.Forms.Button btnGamePath;
        private System.Windows.Forms.Label lblZipName;
        private System.Windows.Forms.Label lblMainEspName;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.TextBox tbArchiverPath;
        private System.Windows.Forms.TextBox tbGamePath;
        private System.Windows.Forms.Button btnSourcePath;
        private System.Windows.Forms.TextBox tbZipName;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Label lblMod;
        private System.Windows.Forms.ComboBox cbMod;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbModName;
        private System.Windows.Forms.Label lblModName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpGames;
        private System.Windows.Forms.TabPage tpMods;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.ComboBox cbGame;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.TextBox tbGameName;
        private System.Windows.Forms.ComboBox cbModGames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbConfigPaths;
    }
}