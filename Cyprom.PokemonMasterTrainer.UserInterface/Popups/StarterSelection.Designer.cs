namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    partial class StarterSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StarterSelection));
            this.ClickLabel = new System.Windows.Forms.Label();
            this.OakPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OakPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ClickLabel
            // 
            this.ClickLabel.AutoSize = true;
            this.ClickLabel.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ClickLabel.Location = new System.Drawing.Point(0, 0);
            this.ClickLabel.MinimumSize = new System.Drawing.Size(700, 0);
            this.ClickLabel.Name = "ClickLabel";
            this.ClickLabel.Size = new System.Drawing.Size(700, 43);
            this.ClickLabel.TabIndex = 0;
            this.ClickLabel.Text = "Click on a Starter Chip to get your first Pokémon!";
            this.ClickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OakPicture
            // 
            this.OakPicture.Image = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.Oak;
            this.OakPicture.Location = new System.Drawing.Point(505, 50);
            this.OakPicture.Name = "OakPicture";
            this.OakPicture.Size = new System.Drawing.Size(180, 193);
            this.OakPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.OakPicture.TabIndex = 4;
            this.OakPicture.TabStop = false;
            // 
            // StarterSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(704, 241);
            this.Controls.Add(this.OakPicture);
            this.Controls.Add(this.ClickLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(720, 280);
            this.MinimumSize = new System.Drawing.Size(720, 280);
            this.Name = "StarterSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starter Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StarterSelection_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.OakPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ClickLabel;
        private System.Windows.Forms.PictureBox OakPicture;
    }
}