namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    partial class SpeedSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeedSelection));
            this.SlowLabel = new System.Windows.Forms.Label();
            this.NormalLabel = new System.Windows.Forms.Label();
            this.FastLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SlowLabel
            // 
            this.SlowLabel.AutoSize = true;
            this.SlowLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SlowLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SlowLabel.Location = new System.Drawing.Point(0, 0);
            this.SlowLabel.MinimumSize = new System.Drawing.Size(380, 0);
            this.SlowLabel.Name = "SlowLabel";
            this.SlowLabel.Size = new System.Drawing.Size(380, 57);
            this.SlowLabel.TabIndex = 0;
            this.SlowLabel.Text = "Slow";
            this.SlowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SlowLabel.Click += new System.EventHandler(this.Label_Click);
            this.SlowLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.SlowLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // NormalLabel
            // 
            this.NormalLabel.AutoSize = true;
            this.NormalLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NormalLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.NormalLabel.Location = new System.Drawing.Point(0, 60);
            this.NormalLabel.MinimumSize = new System.Drawing.Size(380, 0);
            this.NormalLabel.Name = "NormalLabel";
            this.NormalLabel.Size = new System.Drawing.Size(380, 57);
            this.NormalLabel.TabIndex = 1;
            this.NormalLabel.Text = "Normal";
            this.NormalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NormalLabel.Click += new System.EventHandler(this.Label_Click);
            this.NormalLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.NormalLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // FastLabel
            // 
            this.FastLabel.AutoSize = true;
            this.FastLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FastLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FastLabel.Location = new System.Drawing.Point(0, 120);
            this.FastLabel.MinimumSize = new System.Drawing.Size(380, 0);
            this.FastLabel.Name = "FastLabel";
            this.FastLabel.Size = new System.Drawing.Size(380, 57);
            this.FastLabel.TabIndex = 2;
            this.FastLabel.Text = "Fast";
            this.FastLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FastLabel.Click += new System.EventHandler(this.Label_Click);
            this.FastLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.FastLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // SpeedSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(198)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(384, 181);
            this.Controls.Add(this.FastLabel);
            this.Controls.Add(this.NormalLabel);
            this.Controls.Add(this.SlowLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 220);
            this.MinimumSize = new System.Drawing.Size(400, 220);
            this.Name = "SpeedSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpeedSelection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpeedSelection_FormClosing);
            this.Load += new System.EventHandler(this.SpeedSelection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SlowLabel;
        private System.Windows.Forms.Label NormalLabel;
        private System.Windows.Forms.Label FastLabel;
    }
}