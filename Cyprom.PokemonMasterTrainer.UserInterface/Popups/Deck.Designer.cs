namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    partial class Deck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deck));
            this.DeckPicture = new System.Windows.Forms.PictureBox();
            this.ClickLabel = new System.Windows.Forms.Label();
            this.PickedCardPicture = new System.Windows.Forms.PictureBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.AmountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DeckPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickedCardPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // DeckPicture
            // 
            this.DeckPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeckPicture.Location = new System.Drawing.Point(15, 50);
            this.DeckPicture.Name = "DeckPicture";
            this.DeckPicture.Size = new System.Drawing.Size(219, 300);
            this.DeckPicture.TabIndex = 0;
            this.DeckPicture.TabStop = false;
            this.DeckPicture.Click += new System.EventHandler(this.DeckPicture_Click);
            // 
            // ClickLabel
            // 
            this.ClickLabel.AutoSize = true;
            this.ClickLabel.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ClickLabel.Location = new System.Drawing.Point(0, 0);
            this.ClickLabel.MinimumSize = new System.Drawing.Size(485, 0);
            this.ClickLabel.Name = "ClickLabel";
            this.ClickLabel.Size = new System.Drawing.Size(485, 43);
            this.ClickLabel.TabIndex = 1;
            this.ClickLabel.Text = "Click on the deck to draw a card.";
            this.ClickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PickedCardPicture
            // 
            this.PickedCardPicture.BackColor = System.Drawing.Color.Transparent;
            this.PickedCardPicture.Location = new System.Drawing.Point(250, 50);
            this.PickedCardPicture.Name = "PickedCardPicture";
            this.PickedCardPicture.Size = new System.Drawing.Size(219, 300);
            this.PickedCardPicture.TabIndex = 2;
            this.PickedCardPicture.TabStop = false;
            // 
            // DoneButton
            // 
            this.DoneButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoneButton.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.DoneButton.Location = new System.Drawing.Point(170, 360);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(140, 60);
            this.DoneButton.TabIndex = 3;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Font = new System.Drawing.Font("High Tower Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountLabel.Location = new System.Drawing.Point(15, 360);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(0, 28);
            this.AmountLabel.TabIndex = 4;
            // 
            // Deck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(489, 431);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.PickedCardPicture);
            this.Controls.Add(this.ClickLabel);
            this.Controls.Add(this.DeckPicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(505, 470);
            this.MinimumSize = new System.Drawing.Size(505, 470);
            this.Name = "Deck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deck";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Deck_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DeckPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickedCardPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DeckPicture;
        private System.Windows.Forms.Label ClickLabel;
        private System.Windows.Forms.PictureBox PickedCardPicture;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label AmountLabel;
    }
}