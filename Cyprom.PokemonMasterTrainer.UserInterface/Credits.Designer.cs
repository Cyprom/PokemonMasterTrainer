namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    partial class Credits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credits));
            this.OriginalLabel = new System.Windows.Forms.Label();
            this.PokemonCompanyLabel = new System.Windows.Forms.Label();
            this.WallpaperLabel = new System.Windows.Forms.Label();
            this.SimonLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OriginalLabel
            // 
            this.OriginalLabel.BackColor = System.Drawing.Color.Transparent;
            this.OriginalLabel.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.OriginalLabel.Location = new System.Drawing.Point(20, 20);
            this.OriginalLabel.Name = "OriginalLabel";
            this.OriginalLabel.Size = new System.Drawing.Size(420, 80);
            this.OriginalLabel.TabIndex = 1;
            this.OriginalLabel.Text = "The original Pokémon Master Trainer game on which this digital version was based," +
    " was created by Hasbro and Milton Bradley in 1999.";
            // 
            // PokemonCompanyLabel
            // 
            this.PokemonCompanyLabel.BackColor = System.Drawing.Color.Transparent;
            this.PokemonCompanyLabel.Font = new System.Drawing.Font("High Tower Text", 15.75F);
            this.PokemonCompanyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.PokemonCompanyLabel.Location = new System.Drawing.Point(20, 120);
            this.PokemonCompanyLabel.Name = "PokemonCompanyLabel";
            this.PokemonCompanyLabel.Size = new System.Drawing.Size(340, 60);
            this.PokemonCompanyLabel.TabIndex = 2;
            this.PokemonCompanyLabel.Text = "All other Pokémon related content is owned by the Pokémon Company.";
            // 
            // WallpaperLabel
            // 
            this.WallpaperLabel.BackColor = System.Drawing.Color.Transparent;
            this.WallpaperLabel.Font = new System.Drawing.Font("High Tower Text", 15.75F);
            this.WallpaperLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.WallpaperLabel.Location = new System.Drawing.Point(20, 200);
            this.WallpaperLabel.Name = "WallpaperLabel";
            this.WallpaperLabel.Size = new System.Drawing.Size(390, 60);
            this.WallpaperLabel.TabIndex = 3;
            this.WallpaperLabel.Text = "All wallpapers used as backgrounds belong to their respective creators/owners.";
            // 
            // SimonLabel
            // 
            this.SimonLabel.BackColor = System.Drawing.Color.Transparent;
            this.SimonLabel.Font = new System.Drawing.Font("High Tower Text", 15.75F);
            this.SimonLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.SimonLabel.Location = new System.Drawing.Point(20, 280);
            this.SimonLabel.Name = "SimonLabel";
            this.SimonLabel.Size = new System.Drawing.Size(410, 110);
            this.SimonLabel.TabIndex = 4;
            this.SimonLabel.Text = "Coding and artwork exclusive to this digital version of the game (board, chips, i" +
    "tems, etc.) are created and owned by the developer, Simon Van Leuven, codename C" +
    "yprom.";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("High Tower Text", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.label1.Location = new System.Drawing.Point(20, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "All rights reserved © Cyprom 2014";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.Control;
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.BackButton.Location = new System.Drawing.Point(630, 425);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(140, 60);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.Credits;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 499);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SimonLabel);
            this.Controls.Add(this.WallpaperLabel);
            this.Controls.Add(this.PokemonCompanyLabel);
            this.Controls.Add(this.OriginalLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 538);
            this.MinimumSize = new System.Drawing.Size(800, 538);
            this.Name = "Credits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Credits_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label OriginalLabel;
        private System.Windows.Forms.Label PokemonCompanyLabel;
        private System.Windows.Forms.Label WallpaperLabel;
        private System.Windows.Forms.Label SimonLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
    }
}