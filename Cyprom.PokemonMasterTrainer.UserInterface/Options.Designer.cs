namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    partial class Options
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.MusicLabel = new System.Windows.Forms.Label();
            this.SoundLabel = new System.Windows.Forms.Label();
            this.AutoSaveLabel = new System.Windows.Forms.Label();
            this.ResolutionSelectionLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.MusicVolumeSlider = new System.Windows.Forms.TrackBar();
            this.SoundVolumeSlider = new System.Windows.Forms.TrackBar();
            this.BackgroundLabel = new System.Windows.Forms.Label();
            this.BackgroundPicture = new System.Windows.Forms.PictureBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.MusicVolumeLabel = new System.Windows.Forms.Label();
            this.SoundVolumeLabel = new System.Windows.Forms.Label();
            this.OptionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ScreenLockLabel = new System.Windows.Forms.Label();
            this.SpeedSelectionLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new Cyprom.PokemonMasterTrainer.Controls.StrokedLabel();
            this.ResolutionLabel = new Cyprom.PokemonMasterTrainer.Controls.StrokedLabel();
            ((System.ComponentModel.ISupportInitialize)(this.MusicVolumeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundVolumeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MusicLabel
            // 
            this.MusicLabel.AutoSize = true;
            this.MusicLabel.BackColor = System.Drawing.Color.Transparent;
            this.MusicLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicLabel.ForeColor = System.Drawing.Color.Black;
            this.MusicLabel.Location = new System.Drawing.Point(93, 0);
            this.MusicLabel.Name = "MusicLabel";
            this.MusicLabel.Size = new System.Drawing.Size(148, 57);
            this.MusicLabel.TabIndex = 0;
            this.MusicLabel.Text = "Music:";
            this.OptionToolTip.SetToolTip(this.MusicLabel, "Enable or disable the background music. There is a quick option for this on the g" +
        "ame board.");
            // 
            // SoundLabel
            // 
            this.SoundLabel.AutoSize = true;
            this.SoundLabel.BackColor = System.Drawing.Color.Transparent;
            this.SoundLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SoundLabel.ForeColor = System.Drawing.Color.Black;
            this.SoundLabel.Location = new System.Drawing.Point(76, 65);
            this.SoundLabel.Name = "SoundLabel";
            this.SoundLabel.Size = new System.Drawing.Size(165, 57);
            this.SoundLabel.TabIndex = 1;
            this.SoundLabel.Text = "Sounds:";
            this.OptionToolTip.SetToolTip(this.SoundLabel, "Enable or disable the sounds. There is a quick option for this on the game board." +
        "");
            // 
            // AutoSaveLabel
            // 
            this.AutoSaveLabel.AutoSize = true;
            this.AutoSaveLabel.BackColor = System.Drawing.Color.Transparent;
            this.AutoSaveLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.AutoSaveLabel.ForeColor = System.Drawing.Color.Black;
            this.AutoSaveLabel.Location = new System.Drawing.Point(23, 195);
            this.AutoSaveLabel.Name = "AutoSaveLabel";
            this.AutoSaveLabel.Size = new System.Drawing.Size(218, 57);
            this.AutoSaveLabel.TabIndex = 3;
            this.AutoSaveLabel.Text = "Auto-save:";
            this.OptionToolTip.SetToolTip(this.AutoSaveLabel, "Enable or disable saving the game after every turn.");
            // 
            // ResolutionSelectionLabel
            // 
            this.ResolutionSelectionLabel.AutoSize = true;
            this.ResolutionSelectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.ResolutionSelectionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResolutionSelectionLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ResolutionSelectionLabel.Location = new System.Drawing.Point(260, 325);
            this.ResolutionSelectionLabel.Name = "ResolutionSelectionLabel";
            this.ResolutionSelectionLabel.Size = new System.Drawing.Size(0, 57);
            this.ResolutionSelectionLabel.TabIndex = 7;
            this.ResolutionSelectionLabel.Click += new System.EventHandler(this.ResolutionSelectionLabel_Click);
            this.ResolutionSelectionLabel.MouseEnter += new System.EventHandler(this.EnterSoundEvent);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(450, 420);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(140, 60);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.BackColor = System.Drawing.Color.Transparent;
            this.ReturnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnButton.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnButton.Location = new System.Drawing.Point(620, 420);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(140, 60);
            this.ReturnButton.TabIndex = 9;
            this.ReturnButton.Text = "Cancel";
            this.ReturnButton.UseVisualStyleBackColor = false;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // MusicVolumeSlider
            // 
            this.MusicVolumeSlider.LargeChange = 20;
            this.MusicVolumeSlider.Location = new System.Drawing.Point(310, 20);
            this.MusicVolumeSlider.Maximum = 100;
            this.MusicVolumeSlider.Minimum = 1;
            this.MusicVolumeSlider.Name = "MusicVolumeSlider";
            this.MusicVolumeSlider.Size = new System.Drawing.Size(200, 45);
            this.MusicVolumeSlider.SmallChange = 5;
            this.MusicVolumeSlider.TabIndex = 10;
            this.MusicVolumeSlider.TickFrequency = 5;
            this.MusicVolumeSlider.Value = 50;
            this.MusicVolumeSlider.Scroll += new System.EventHandler(this.MusicVolumeSlider_Scroll);
            // 
            // SoundVolumeSlider
            // 
            this.SoundVolumeSlider.LargeChange = 20;
            this.SoundVolumeSlider.Location = new System.Drawing.Point(310, 85);
            this.SoundVolumeSlider.Maximum = 100;
            this.SoundVolumeSlider.Minimum = 1;
            this.SoundVolumeSlider.Name = "SoundVolumeSlider";
            this.SoundVolumeSlider.Size = new System.Drawing.Size(200, 45);
            this.SoundVolumeSlider.SmallChange = 5;
            this.SoundVolumeSlider.TabIndex = 11;
            this.SoundVolumeSlider.TickFrequency = 5;
            this.SoundVolumeSlider.Value = 50;
            this.SoundVolumeSlider.Scroll += new System.EventHandler(this.SoundVolumeSlider_Scroll);
            // 
            // BackgroundLabel
            // 
            this.BackgroundLabel.AutoSize = true;
            this.BackgroundLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.BackgroundLabel.ForeColor = System.Drawing.Color.Black;
            this.BackgroundLabel.Location = new System.Drawing.Point(625, 240);
            this.BackgroundLabel.Name = "BackgroundLabel";
            this.BackgroundLabel.Size = new System.Drawing.Size(146, 57);
            this.BackgroundLabel.TabIndex = 12;
            this.BackgroundLabel.Text = "Board:";
            this.OptionToolTip.SetToolTip(this.BackgroundLabel, "Select a background for the game board.");
            // 
            // BackgroundPicture
            // 
            this.BackgroundPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackgroundPicture.Location = new System.Drawing.Point(648, 300);
            this.BackgroundPicture.Name = "BackgroundPicture";
            this.BackgroundPicture.Size = new System.Drawing.Size(100, 100);
            this.BackgroundPicture.TabIndex = 13;
            this.BackgroundPicture.TabStop = false;
            this.BackgroundPicture.Click += new System.EventHandler(this.BackgroundPicture_Click);
            this.BackgroundPicture.MouseEnter += new System.EventHandler(this.EnterSoundEvent);
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LogLabel.ForeColor = System.Drawing.Color.Black;
            this.LogLabel.Location = new System.Drawing.Point(134, 260);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(107, 57);
            this.LogLabel.TabIndex = 18;
            this.LogLabel.Text = "Log:";
            this.OptionToolTip.SetToolTip(this.LogLabel, "Enable or disable action logging.");
            // 
            // MusicVolumeLabel
            // 
            this.MusicVolumeLabel.AutoSize = true;
            this.MusicVolumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.MusicVolumeLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.MusicVolumeLabel.Location = new System.Drawing.Point(500, 0);
            this.MusicVolumeLabel.Name = "MusicVolumeLabel";
            this.MusicVolumeLabel.Size = new System.Drawing.Size(0, 57);
            this.MusicVolumeLabel.TabIndex = 19;
            // 
            // SoundVolumeLabel
            // 
            this.SoundVolumeLabel.AutoSize = true;
            this.SoundVolumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.SoundVolumeLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SoundVolumeLabel.Location = new System.Drawing.Point(500, 65);
            this.SoundVolumeLabel.Name = "SoundVolumeLabel";
            this.SoundVolumeLabel.Size = new System.Drawing.Size(0, 57);
            this.SoundVolumeLabel.TabIndex = 20;
            // 
            // ScreenLockLabel
            // 
            this.ScreenLockLabel.AutoSize = true;
            this.ScreenLockLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScreenLockLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ScreenLockLabel.ForeColor = System.Drawing.Color.Black;
            this.ScreenLockLabel.Location = new System.Drawing.Point(-9, 135);
            this.ScreenLockLabel.Name = "ScreenLockLabel";
            this.ScreenLockLabel.Size = new System.Drawing.Size(250, 57);
            this.ScreenLockLabel.TabIndex = 22;
            this.ScreenLockLabel.Text = "Screen Lock:";
            this.OptionToolTip.SetToolTip(this.ScreenLockLabel, "Enable or disable the screen lock (if on, this prevents the screen from following" +
        " players). There is a quick option for this on the board.");
            // 
            // SpeedSelectionLabel
            // 
            this.SpeedSelectionLabel.AutoSize = true;
            this.SpeedSelectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.SpeedSelectionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpeedSelectionLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SpeedSelectionLabel.Location = new System.Drawing.Point(260, 390);
            this.SpeedSelectionLabel.Name = "SpeedSelectionLabel";
            this.SpeedSelectionLabel.Size = new System.Drawing.Size(0, 57);
            this.SpeedSelectionLabel.TabIndex = 23;
            this.SpeedSelectionLabel.Click += new System.EventHandler(this.SpeedSelectionLabel_Click);
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.BackColor = System.Drawing.Color.Transparent;
            this.SpeedLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SpeedLabel.Location = new System.Drawing.Point(40, 390);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.OutlineForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(198)))), ((int)(((byte)(226)))));
            this.SpeedLabel.OutlineWidth = 3F;
            this.SpeedLabel.Size = new System.Drawing.Size(201, 57);
            this.SpeedLabel.TabIndex = 24;
            this.SpeedLabel.Text = "AI Speed:";
            this.OptionToolTip.SetToolTip(this.SpeedLabel, "Determine how long bots need to execute their actions.");
            // 
            // ResolutionLabel
            // 
            this.ResolutionLabel.AutoSize = true;
            this.ResolutionLabel.BackColor = System.Drawing.Color.Transparent;
            this.ResolutionLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ResolutionLabel.Location = new System.Drawing.Point(12, 325);
            this.ResolutionLabel.Name = "ResolutionLabel";
            this.ResolutionLabel.OutlineForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(198)))), ((int)(((byte)(226)))));
            this.ResolutionLabel.OutlineWidth = 3F;
            this.ResolutionLabel.Size = new System.Drawing.Size(229, 57);
            this.ResolutionLabel.TabIndex = 25;
            this.ResolutionLabel.Text = "Resolution:";
            this.OptionToolTip.SetToolTip(this.ResolutionLabel, "Pick the size of the game board.");
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(198)))), ((int)(((byte)(226)))));
            this.BackgroundImage = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.Options;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(784, 499);
            this.Controls.Add(this.ResolutionLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.SpeedSelectionLabel);
            this.Controls.Add(this.ScreenLockLabel);
            this.Controls.Add(this.SoundVolumeLabel);
            this.Controls.Add(this.MusicVolumeLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.BackgroundPicture);
            this.Controls.Add(this.BackgroundLabel);
            this.Controls.Add(this.SoundVolumeSlider);
            this.Controls.Add(this.MusicVolumeSlider);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ResolutionSelectionLabel);
            this.Controls.Add(this.AutoSaveLabel);
            this.Controls.Add(this.SoundLabel);
            this.Controls.Add(this.MusicLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 538);
            this.MinimumSize = new System.Drawing.Size(800, 538);
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MusicVolumeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundVolumeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MusicLabel;
        private System.Windows.Forms.Label SoundLabel;
        private System.Windows.Forms.Label AutoSaveLabel;
        private System.Windows.Forms.Label ResolutionSelectionLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.TrackBar MusicVolumeSlider;
        private System.Windows.Forms.TrackBar SoundVolumeSlider;
        private System.Windows.Forms.Label BackgroundLabel;
        private System.Windows.Forms.PictureBox BackgroundPicture;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Label MusicVolumeLabel;
        private System.Windows.Forms.Label SoundVolumeLabel;
        private System.Windows.Forms.ToolTip OptionToolTip;
        private System.Windows.Forms.Label ScreenLockLabel;
        private System.Windows.Forms.Label SpeedSelectionLabel;
        private Controls.StrokedLabel SpeedLabel;
        private Controls.StrokedLabel ResolutionLabel;
    }
}