namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    partial class PlayerSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerSelection));
            this.AshPanel = new System.Windows.Forms.Panel();
            this.AshType = new System.Windows.Forms.PictureBox();
            this.AshName = new System.Windows.Forms.TextBox();
            this.AshLabel = new System.Windows.Forms.Label();
            this.MistyPanel = new System.Windows.Forms.Panel();
            this.MistyType = new System.Windows.Forms.PictureBox();
            this.MistyName = new System.Windows.Forms.TextBox();
            this.MistyLabel = new System.Windows.Forms.Label();
            this.BrockPanel = new System.Windows.Forms.Panel();
            this.BrockType = new System.Windows.Forms.PictureBox();
            this.BrockName = new System.Windows.Forms.TextBox();
            this.BrockLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.AshPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AshType)).BeginInit();
            this.MistyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MistyType)).BeginInit();
            this.BrockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrockType)).BeginInit();
            this.SuspendLayout();
            // 
            // AshPanel
            // 
            this.AshPanel.Controls.Add(this.AshType);
            this.AshPanel.Controls.Add(this.AshName);
            this.AshPanel.Controls.Add(this.AshLabel);
            this.AshPanel.Location = new System.Drawing.Point(20, 20);
            this.AshPanel.Name = "AshPanel";
            this.AshPanel.Size = new System.Drawing.Size(150, 310);
            this.AshPanel.TabIndex = 0;
            // 
            // AshType
            // 
            this.AshType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AshType.Location = new System.Drawing.Point(25, 190);
            this.AshType.Name = "AshType";
            this.AshType.Size = new System.Drawing.Size(100, 100);
            this.AshType.TabIndex = 2;
            this.AshType.TabStop = false;
            this.AshType.Tag = "";
            this.AshType.Click += new System.EventHandler(this.AshType_Click);
            // 
            // AshName
            // 
            this.AshName.Font = new System.Drawing.Font("High Tower Text", 15.75F);
            this.AshName.Location = new System.Drawing.Point(10, 140);
            this.AshName.MaxLength = 15;
            this.AshName.Name = "AshName";
            this.AshName.Size = new System.Drawing.Size(130, 32);
            this.AshName.TabIndex = 1;
            this.AshName.Text = "Ash";
            this.AshName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AshLabel
            // 
            this.AshLabel.AutoSize = true;
            this.AshLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AshLabel.Location = new System.Drawing.Point(0, 110);
            this.AshLabel.MinimumSize = new System.Drawing.Size(150, 0);
            this.AshLabel.Name = "AshLabel";
            this.AshLabel.Size = new System.Drawing.Size(150, 25);
            this.AshLabel.TabIndex = 0;
            this.AshLabel.Text = "Name:";
            this.AshLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MistyPanel
            // 
            this.MistyPanel.Controls.Add(this.MistyType);
            this.MistyPanel.Controls.Add(this.MistyName);
            this.MistyPanel.Controls.Add(this.MistyLabel);
            this.MistyPanel.Location = new System.Drawing.Point(190, 20);
            this.MistyPanel.Name = "MistyPanel";
            this.MistyPanel.Size = new System.Drawing.Size(150, 310);
            this.MistyPanel.TabIndex = 1;
            // 
            // MistyType
            // 
            this.MistyType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MistyType.Location = new System.Drawing.Point(25, 190);
            this.MistyType.Name = "MistyType";
            this.MistyType.Size = new System.Drawing.Size(100, 100);
            this.MistyType.TabIndex = 2;
            this.MistyType.TabStop = false;
            this.MistyType.Tag = "";
            this.MistyType.Click += new System.EventHandler(this.MistyType_Click);
            // 
            // MistyName
            // 
            this.MistyName.Font = new System.Drawing.Font("High Tower Text", 15.75F);
            this.MistyName.Location = new System.Drawing.Point(10, 140);
            this.MistyName.MaxLength = 15;
            this.MistyName.Name = "MistyName";
            this.MistyName.Size = new System.Drawing.Size(130, 32);
            this.MistyName.TabIndex = 1;
            this.MistyName.Text = "Misty";
            this.MistyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MistyLabel
            // 
            this.MistyLabel.AutoSize = true;
            this.MistyLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.MistyLabel.Location = new System.Drawing.Point(0, 110);
            this.MistyLabel.MinimumSize = new System.Drawing.Size(150, 0);
            this.MistyLabel.Name = "MistyLabel";
            this.MistyLabel.Size = new System.Drawing.Size(150, 25);
            this.MistyLabel.TabIndex = 0;
            this.MistyLabel.Text = "Name:";
            this.MistyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrockPanel
            // 
            this.BrockPanel.Controls.Add(this.BrockType);
            this.BrockPanel.Controls.Add(this.BrockName);
            this.BrockPanel.Controls.Add(this.BrockLabel);
            this.BrockPanel.Location = new System.Drawing.Point(360, 20);
            this.BrockPanel.Name = "BrockPanel";
            this.BrockPanel.Size = new System.Drawing.Size(150, 310);
            this.BrockPanel.TabIndex = 2;
            // 
            // BrockType
            // 
            this.BrockType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrockType.Location = new System.Drawing.Point(25, 190);
            this.BrockType.Name = "BrockType";
            this.BrockType.Size = new System.Drawing.Size(100, 100);
            this.BrockType.TabIndex = 2;
            this.BrockType.TabStop = false;
            this.BrockType.Tag = "";
            this.BrockType.Click += new System.EventHandler(this.BrockType_Click);
            // 
            // BrockName
            // 
            this.BrockName.Font = new System.Drawing.Font("High Tower Text", 15.75F);
            this.BrockName.Location = new System.Drawing.Point(10, 140);
            this.BrockName.MaxLength = 15;
            this.BrockName.Name = "BrockName";
            this.BrockName.Size = new System.Drawing.Size(130, 32);
            this.BrockName.TabIndex = 1;
            this.BrockName.Text = "Brock";
            this.BrockName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BrockLabel
            // 
            this.BrockLabel.AutoSize = true;
            this.BrockLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.BrockLabel.Location = new System.Drawing.Point(0, 110);
            this.BrockLabel.MinimumSize = new System.Drawing.Size(150, 0);
            this.BrockLabel.Name = "BrockLabel";
            this.BrockLabel.Size = new System.Drawing.Size(150, 25);
            this.BrockLabel.TabIndex = 0;
            this.BrockLabel.Text = "Name:";
            this.BrockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartButton
            // 
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.StartButton.Location = new System.Drawing.Point(110, 350);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(140, 60);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnButton.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ReturnButton.Location = new System.Drawing.Point(280, 350);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(140, 60);
            this.ReturnButton.TabIndex = 4;
            this.ReturnButton.Text = "Cancel";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // PlayerSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(127)))));
            this.ClientSize = new System.Drawing.Size(534, 431);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.BrockPanel);
            this.Controls.Add(this.MistyPanel);
            this.Controls.Add(this.AshPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(550, 470);
            this.MinimumSize = new System.Drawing.Size(550, 470);
            this.Name = "PlayerSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Players";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerSelection_FormClosing);
            this.AshPanel.ResumeLayout(false);
            this.AshPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AshType)).EndInit();
            this.MistyPanel.ResumeLayout(false);
            this.MistyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MistyType)).EndInit();
            this.BrockPanel.ResumeLayout(false);
            this.BrockPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrockType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AshPanel;
        private System.Windows.Forms.PictureBox AshType;
        private System.Windows.Forms.TextBox AshName;
        private System.Windows.Forms.Label AshLabel;
        private System.Windows.Forms.Panel MistyPanel;
        private System.Windows.Forms.PictureBox MistyType;
        private System.Windows.Forms.TextBox MistyName;
        private System.Windows.Forms.Label MistyLabel;
        private System.Windows.Forms.Panel BrockPanel;
        private System.Windows.Forms.PictureBox BrockType;
        private System.Windows.Forms.TextBox BrockName;
        private System.Windows.Forms.Label BrockLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ReturnButton;
    }
}