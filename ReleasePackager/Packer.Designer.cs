namespace ReleasePackager
{
    partial class Packer
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
            this.tbSource = new System.Windows.Forms.TextBox();
            this.btnSourcePath = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.tbGamePath = new System.Windows.Forms.TextBox();
            this.btnGamePath = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnOutputPath = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.tbProgress = new System.Windows.Forms.TextBox();
            this.lblMainEspName = new System.Windows.Forms.Label();
            this.lbPreset = new System.Windows.Forms.Label();
            this.cbPresets = new System.Windows.Forms.ComboBox();
            this.lblZipName = new System.Windows.Forms.Label();
            this.tbZipName = new System.Windows.Forms.TextBox();
            this.cbMainEspName = new System.Windows.Forms.ComboBox();
            this.lblArchiver = new System.Windows.Forms.Label();
            this.tbArchiverPath = new System.Windows.Forms.TextBox();
            this.btnArchiverPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSource
            // 
            this.tbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSource.Location = new System.Drawing.Point(83, 105);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(396, 20);
            this.tbSource.TabIndex = 2;
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourcePath.Location = new System.Drawing.Point(485, 103);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(75, 23);
            this.btnSourcePath.TabIndex = 3;
            this.btnSourcePath.Text = "button1";
            this.btnSourcePath.UseVisualStyleBackColor = true;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(12, 108);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(65, 13);
            this.lblSource.TabIndex = 2;
            this.lblSource.Text = "Source path";
            // 
            // tbGamePath
            // 
            this.tbGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGamePath.Location = new System.Drawing.Point(83, 160);
            this.tbGamePath.Name = "tbGamePath";
            this.tbGamePath.Size = new System.Drawing.Size(396, 20);
            this.tbGamePath.TabIndex = 6;
            this.tbGamePath.Text = "G:\\Steam\\SteamApps\\common\\Skyrim";
            // 
            // btnGamePath
            // 
            this.btnGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGamePath.Location = new System.Drawing.Point(485, 158);
            this.btnGamePath.Name = "btnGamePath";
            this.btnGamePath.Size = new System.Drawing.Size(75, 23);
            this.btnGamePath.TabIndex = 7;
            this.btnGamePath.Text = "button1";
            this.btnGamePath.UseVisualStyleBackColor = true;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(12, 163);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(59, 13);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Game path";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 134);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(63, 13);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "Output path";
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(83, 131);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(396, 20);
            this.tbOutput.TabIndex = 4;
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputPath.Location = new System.Drawing.Point(485, 129);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Size = new System.Drawing.Size(75, 23);
            this.btnOutputPath.TabIndex = 5;
            this.btnOutputPath.Text = "button1";
            this.btnOutputPath.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(452, 212);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(108, 43);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tbProgress
            // 
            this.tbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProgress.Location = new System.Drawing.Point(15, 261);
            this.tbProgress.Multiline = true;
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbProgress.Size = new System.Drawing.Size(545, 375);
            this.tbProgress.TabIndex = 9;
            this.tbProgress.WordWrap = false;
            // 
            // lblMainEspName
            // 
            this.lblMainEspName.AutoSize = true;
            this.lblMainEspName.Location = new System.Drawing.Point(12, 80);
            this.lblMainEspName.Name = "lblMainEspName";
            this.lblMainEspName.Size = new System.Drawing.Size(54, 13);
            this.lblMainEspName.TabIndex = 2;
            this.lblMainEspName.Text = "Main ESP";
            // 
            // lbPreset
            // 
            this.lbPreset.AutoSize = true;
            this.lbPreset.Location = new System.Drawing.Point(12, 24);
            this.lbPreset.Name = "lbPreset";
            this.lbPreset.Size = new System.Drawing.Size(37, 13);
            this.lbPreset.TabIndex = 4;
            this.lbPreset.Text = "Preset";
            // 
            // cbPresets
            // 
            this.cbPresets.FormattingEnabled = true;
            this.cbPresets.Location = new System.Drawing.Point(83, 21);
            this.cbPresets.Name = "cbPresets";
            this.cbPresets.Size = new System.Drawing.Size(396, 21);
            this.cbPresets.TabIndex = 0;
            // 
            // lblZipName
            // 
            this.lblZipName.AutoSize = true;
            this.lblZipName.Location = new System.Drawing.Point(265, 80);
            this.lblZipName.Name = "lblZipName";
            this.lblZipName.Size = new System.Drawing.Size(57, 13);
            this.lblZipName.TabIndex = 2;
            this.lblZipName.Text = "Output Zip";
            // 
            // tbZipName
            // 
            this.tbZipName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbZipName.Location = new System.Drawing.Point(328, 77);
            this.tbZipName.Name = "tbZipName";
            this.tbZipName.Size = new System.Drawing.Size(151, 20);
            this.tbZipName.TabIndex = 1;
            // 
            // cbMainEspName
            // 
            this.cbMainEspName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMainEspName.DisplayMember = "Value";
            this.cbMainEspName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMainEspName.FormattingEnabled = true;
            this.cbMainEspName.Location = new System.Drawing.Point(83, 76);
            this.cbMainEspName.Name = "cbMainEspName";
            this.cbMainEspName.Size = new System.Drawing.Size(158, 21);
            this.cbMainEspName.TabIndex = 10;
            this.cbMainEspName.ValueMember = "Key";
            // 
            // lblArchiver
            // 
            this.lblArchiver.AutoSize = true;
            this.lblArchiver.Location = new System.Drawing.Point(12, 189);
            this.lblArchiver.Name = "lblArchiver";
            this.lblArchiver.Size = new System.Drawing.Size(70, 13);
            this.lblArchiver.TabIndex = 2;
            this.lblArchiver.Text = "Archiver path";
            // 
            // tbArchiverPath
            // 
            this.tbArchiverPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbArchiverPath.Location = new System.Drawing.Point(83, 186);
            this.tbArchiverPath.Name = "tbArchiverPath";
            this.tbArchiverPath.Size = new System.Drawing.Size(396, 20);
            this.tbArchiverPath.TabIndex = 6;
            this.tbArchiverPath.Text = "G:\\Steam\\SteamApps\\common\\Skyrim\r\n";
            // 
            // btnArchiverPath
            // 
            this.btnArchiverPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchiverPath.Location = new System.Drawing.Point(485, 184);
            this.btnArchiverPath.Name = "btnArchiverPath";
            this.btnArchiverPath.Size = new System.Drawing.Size(75, 23);
            this.btnArchiverPath.TabIndex = 7;
            this.btnArchiverPath.Text = "button1";
            this.btnArchiverPath.UseVisualStyleBackColor = true;
            // 
            // Packer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 648);
            this.Controls.Add(this.cbMainEspName);
            this.Controls.Add(this.cbPresets);
            this.Controls.Add(this.lbPreset);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnOutputPath);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbProgress);
            this.Controls.Add(this.lblArchiver);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnArchiverPath);
            this.Controls.Add(this.btnGamePath);
            this.Controls.Add(this.lblZipName);
            this.Controls.Add(this.lblMainEspName);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.tbArchiverPath);
            this.Controls.Add(this.tbGamePath);
            this.Controls.Add(this.btnSourcePath);
            this.Controls.Add(this.tbZipName);
            this.Controls.Add(this.tbSource);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "Packer";
            this.Text = "Mod Release Packer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Button btnSourcePath;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.TextBox tbGamePath;
        private System.Windows.Forms.Button btnGamePath;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnOutputPath;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox tbProgress;
        private System.Windows.Forms.Label lblMainEspName;
        private System.Windows.Forms.Label lbPreset;
        private System.Windows.Forms.ComboBox cbPresets;
        private System.Windows.Forms.Label lblZipName;
        private System.Windows.Forms.TextBox tbZipName;
        private System.Windows.Forms.ComboBox cbMainEspName;
        private System.Windows.Forms.Label lblArchiver;
        private System.Windows.Forms.TextBox tbArchiverPath;
        private System.Windows.Forms.Button btnArchiverPath;
    }
}

