namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    partial class Bag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bag));
            this.CloseButton = new System.Windows.Forms.Button();
            this.CollectionPanel = new System.Windows.Forms.Panel();
            this.BagPicture = new System.Windows.Forms.PictureBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.ItemsCountedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BagPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.CloseButton.Location = new System.Drawing.Point(640, 425);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(140, 60);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CollectionPanel
            // 
            this.CollectionPanel.AutoScroll = true;
            this.CollectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CollectionPanel.Location = new System.Drawing.Point(0, 0);
            this.CollectionPanel.Name = "CollectionPanel";
            this.CollectionPanel.Size = new System.Drawing.Size(635, 500);
            this.CollectionPanel.TabIndex = 1;
            // 
            // BagPicture
            // 
            this.BagPicture.Image = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.ItemBag;
            this.BagPicture.Location = new System.Drawing.Point(635, 0);
            this.BagPicture.Name = "BagPicture";
            this.BagPicture.Size = new System.Drawing.Size(150, 150);
            this.BagPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BagPicture.TabIndex = 2;
            this.BagPicture.TabStop = false;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Bold);
            this.AmountLabel.Location = new System.Drawing.Point(635, 150);
            this.AmountLabel.MinimumSize = new System.Drawing.Size(150, 0);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(150, 25);
            this.AmountLabel.TabIndex = 3;
            this.AmountLabel.Text = "Amount:";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemsCountedLabel
            // 
            this.ItemsCountedLabel.AutoSize = true;
            this.ItemsCountedLabel.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Bold);
            this.ItemsCountedLabel.Location = new System.Drawing.Point(635, 175);
            this.ItemsCountedLabel.MinimumSize = new System.Drawing.Size(150, 0);
            this.ItemsCountedLabel.Name = "ItemsCountedLabel";
            this.ItemsCountedLabel.Size = new System.Drawing.Size(150, 25);
            this.ItemsCountedLabel.TabIndex = 4;
            this.ItemsCountedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(784, 499);
            this.Controls.Add(this.ItemsCountedLabel);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.BagPicture);
            this.Controls.Add(this.CollectionPanel);
            this.Controls.Add(this.CloseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 538);
            this.MinimumSize = new System.Drawing.Size(800, 538);
            this.Name = "Bag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Bag";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bag_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.BagPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel CollectionPanel;
        private System.Windows.Forms.PictureBox BagPicture;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label ItemsCountedLabel;
    }
}