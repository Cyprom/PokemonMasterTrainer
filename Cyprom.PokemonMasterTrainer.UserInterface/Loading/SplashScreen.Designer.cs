namespace Cyprom.PokemonMasterTrainer.UserInterface.Loading
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.SplashPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SplashPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashPicture
            // 
            this.SplashPicture.Image = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.Splash;
            this.SplashPicture.Location = new System.Drawing.Point(0, 0);
            this.SplashPicture.Name = "SplashPicture";
            this.SplashPicture.Size = new System.Drawing.Size(800, 413);
            this.SplashPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SplashPicture.TabIndex = 0;
            this.SplashPicture.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 413);
            this.Controls.Add(this.SplashPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokemon Master Trainer - Digital";
            ((System.ComponentModel.ISupportInitialize)(this.SplashPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SplashPicture;
    }
}