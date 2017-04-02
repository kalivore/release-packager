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
            this.button1 = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.tbGamePath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.tbProgress = new System.Windows.Forms.TextBox();
            this.tbArchiveName = new System.Windows.Forms.TextBox();
            this.lblArchiveName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSource
            // 
            this.tbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSource.Location = new System.Drawing.Point(83, 40);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(396, 20);
            this.tbSource.TabIndex = 0;
            this.tbSource.Text = "F:\\Games Work\\Skyrim\\Arrow Sheaves\\mod";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(485, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(12, 43);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(65, 13);
            this.lblSource.TabIndex = 2;
            this.lblSource.Text = "Source path";
            // 
            // tbGamePath
            // 
            this.tbGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGamePath.Location = new System.Drawing.Point(83, 69);
            this.tbGamePath.Name = "tbGamePath";
            this.tbGamePath.Size = new System.Drawing.Size(396, 20);
            this.tbGamePath.TabIndex = 0;
            this.tbGamePath.Text = "G:\\Steam\\SteamApps\\common\\Skyrim";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(485, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(12, 72);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(59, 13);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Game path";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 101);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(63, 13);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "Output path";
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(83, 98);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(396, 20);
            this.tbOutput.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(485, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(452, 125);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(108, 43);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tbProgress
            // 
            this.tbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProgress.Location = new System.Drawing.Point(15, 174);
            this.tbProgress.Multiline = true;
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbProgress.Size = new System.Drawing.Size(545, 417);
            this.tbProgress.TabIndex = 3;
            this.tbProgress.WordWrap = false;
            // 
            // tbArchiveName
            // 
            this.tbArchiveName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbArchiveName.Location = new System.Drawing.Point(83, 12);
            this.tbArchiveName.Name = "tbArchiveName";
            this.tbArchiveName.Size = new System.Drawing.Size(396, 20);
            this.tbArchiveName.TabIndex = 0;
            this.tbArchiveName.Text = "Arrow Sheaves";
            // 
            // lblArchiveName
            // 
            this.lblArchiveName.AutoSize = true;
            this.lblArchiveName.Location = new System.Drawing.Point(12, 15);
            this.lblArchiveName.Name = "lblArchiveName";
            this.lblArchiveName.Size = new System.Drawing.Size(43, 13);
            this.lblArchiveName.TabIndex = 2;
            this.lblArchiveName.Text = "Archive";
            // 
            // Packer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 603);
            this.Controls.Add(this.tbProgress);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblArchiveName);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.tbGamePath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbArchiveName);
            this.Controls.Add(this.tbSource);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "Packer";
            this.Text = "Mod Release Packer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.TextBox tbGamePath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox tbProgress;
        private System.Windows.Forms.TextBox tbArchiveName;
        private System.Windows.Forms.Label lblArchiveName;
    }
}

