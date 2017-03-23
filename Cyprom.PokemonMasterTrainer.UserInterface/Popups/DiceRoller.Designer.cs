namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    partial class DiceRoller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiceRoller));
            this.DicePicture = new System.Windows.Forms.PictureBox();
            this.RollLabel = new System.Windows.Forms.Label();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DicePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // DicePicture
            // 
            this.DicePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DicePicture.Image = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.One;
            this.DicePicture.Location = new System.Drawing.Point(75, 50);
            this.DicePicture.Name = "DicePicture";
            this.DicePicture.Size = new System.Drawing.Size(50, 50);
            this.DicePicture.TabIndex = 1;
            this.DicePicture.TabStop = false;
            this.DicePicture.Tag = "1";
            this.DicePicture.Click += new System.EventHandler(this.DicePicture_Click);
            // 
            // RollLabel
            // 
            this.RollLabel.AutoSize = true;
            this.RollLabel.Font = new System.Drawing.Font("High Tower Text", 15.75F);
            this.RollLabel.Location = new System.Drawing.Point(0, 0);
            this.RollLabel.MinimumSize = new System.Drawing.Size(200, 0);
            this.RollLabel.Name = "RollLabel";
            this.RollLabel.Size = new System.Drawing.Size(200, 25);
            this.RollLabel.TabIndex = 2;
            this.RollLabel.Text = "Click the die to roll:";
            this.RollLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Interval = 25;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // DiceRoller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 131);
            this.Controls.Add(this.RollLabel);
            this.Controls.Add(this.DicePicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(220, 170);
            this.MinimumSize = new System.Drawing.Size(220, 170);
            this.Name = "DiceRoller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dice Roller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiceRoller_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.DiceRoller_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DicePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DicePicture;
        private System.Windows.Forms.Label RollLabel;
        private System.Windows.Forms.Timer AnimationTimer;

    }
}