namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    partial class Pokedex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pokedex));
            this.CloseButton = new System.Windows.Forms.Button();
            this.CollectionPanel = new System.Windows.Forms.Panel();
            this.PokedexPicture = new System.Windows.Forms.PictureBox();
            this.SortKeyGroup = new System.Windows.Forms.GroupBox();
            this.RadioAttackDamage = new System.Windows.Forms.RadioButton();
            this.RadioPowerPoints = new System.Windows.Forms.RadioButton();
            this.RadioName = new System.Windows.Forms.RadioButton();
            this.SortTypeGroup = new System.Windows.Forms.GroupBox();
            this.RadioDescending = new System.Windows.Forms.RadioButton();
            this.RadioAscending = new System.Windows.Forms.RadioButton();
            this.PowerPointsLabel = new System.Windows.Forms.Label();
            this.PowerPointsCalculatedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PokedexPicture)).BeginInit();
            this.SortKeyGroup.SuspendLayout();
            this.SortTypeGroup.SuspendLayout();
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
            // PokedexPicture
            // 
            this.PokedexPicture.Image = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.Pokedex;
            this.PokedexPicture.Location = new System.Drawing.Point(635, 0);
            this.PokedexPicture.Name = "PokedexPicture";
            this.PokedexPicture.Size = new System.Drawing.Size(150, 150);
            this.PokedexPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PokedexPicture.TabIndex = 2;
            this.PokedexPicture.TabStop = false;
            // 
            // SortKeyGroup
            // 
            this.SortKeyGroup.Controls.Add(this.RadioAttackDamage);
            this.SortKeyGroup.Controls.Add(this.RadioPowerPoints);
            this.SortKeyGroup.Controls.Add(this.RadioName);
            this.SortKeyGroup.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold);
            this.SortKeyGroup.ForeColor = System.Drawing.SystemColors.Control;
            this.SortKeyGroup.Location = new System.Drawing.Point(640, 155);
            this.SortKeyGroup.Name = "SortKeyGroup";
            this.SortKeyGroup.Size = new System.Drawing.Size(135, 100);
            this.SortKeyGroup.TabIndex = 3;
            this.SortKeyGroup.TabStop = false;
            this.SortKeyGroup.Text = "Sort Key";
            // 
            // RadioAttackDamage
            // 
            this.RadioAttackDamage.AutoSize = true;
            this.RadioAttackDamage.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAttackDamage.Location = new System.Drawing.Point(5, 70);
            this.RadioAttackDamage.Name = "RadioAttackDamage";
            this.RadioAttackDamage.Size = new System.Drawing.Size(129, 23);
            this.RadioAttackDamage.TabIndex = 2;
            this.RadioAttackDamage.TabStop = true;
            this.RadioAttackDamage.Text = "Attack Damage";
            this.RadioAttackDamage.UseVisualStyleBackColor = true;
            this.RadioAttackDamage.CheckedChanged += new System.EventHandler(this.RadioSortKey_Changed);
            // 
            // RadioPowerPoints
            // 
            this.RadioPowerPoints.AutoSize = true;
            this.RadioPowerPoints.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPowerPoints.Location = new System.Drawing.Point(5, 45);
            this.RadioPowerPoints.Name = "RadioPowerPoints";
            this.RadioPowerPoints.Size = new System.Drawing.Size(116, 23);
            this.RadioPowerPoints.TabIndex = 1;
            this.RadioPowerPoints.TabStop = true;
            this.RadioPowerPoints.Text = "Power Points";
            this.RadioPowerPoints.UseVisualStyleBackColor = true;
            this.RadioPowerPoints.CheckedChanged += new System.EventHandler(this.RadioSortKey_Changed);
            // 
            // RadioName
            // 
            this.RadioName.AutoSize = true;
            this.RadioName.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioName.Location = new System.Drawing.Point(5, 20);
            this.RadioName.Name = "RadioName";
            this.RadioName.Size = new System.Drawing.Size(66, 23);
            this.RadioName.TabIndex = 0;
            this.RadioName.TabStop = true;
            this.RadioName.Text = "Name";
            this.RadioName.UseVisualStyleBackColor = true;
            this.RadioName.CheckedChanged += new System.EventHandler(this.RadioSortKey_Changed);
            // 
            // SortTypeGroup
            // 
            this.SortTypeGroup.Controls.Add(this.RadioDescending);
            this.SortTypeGroup.Controls.Add(this.RadioAscending);
            this.SortTypeGroup.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold);
            this.SortTypeGroup.ForeColor = System.Drawing.SystemColors.Control;
            this.SortTypeGroup.Location = new System.Drawing.Point(640, 264);
            this.SortTypeGroup.Name = "SortTypeGroup";
            this.SortTypeGroup.Size = new System.Drawing.Size(135, 75);
            this.SortTypeGroup.TabIndex = 4;
            this.SortTypeGroup.TabStop = false;
            this.SortTypeGroup.Text = "Sort Type";
            // 
            // RadioDescending
            // 
            this.RadioDescending.AutoSize = true;
            this.RadioDescending.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioDescending.Location = new System.Drawing.Point(5, 45);
            this.RadioDescending.Name = "RadioDescending";
            this.RadioDescending.Size = new System.Drawing.Size(102, 23);
            this.RadioDescending.TabIndex = 1;
            this.RadioDescending.TabStop = true;
            this.RadioDescending.Text = "Descending";
            this.RadioDescending.UseVisualStyleBackColor = true;
            this.RadioDescending.CheckedChanged += new System.EventHandler(this.RadioSortType_Changed);
            // 
            // RadioAscending
            // 
            this.RadioAscending.AutoSize = true;
            this.RadioAscending.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAscending.Location = new System.Drawing.Point(5, 20);
            this.RadioAscending.Name = "RadioAscending";
            this.RadioAscending.Size = new System.Drawing.Size(95, 23);
            this.RadioAscending.TabIndex = 0;
            this.RadioAscending.TabStop = true;
            this.RadioAscending.Text = "Ascending";
            this.RadioAscending.UseVisualStyleBackColor = true;
            this.RadioAscending.CheckedChanged += new System.EventHandler(this.RadioSortType_Changed);
            // 
            // PowerPointsLabel
            // 
            this.PowerPointsLabel.AutoSize = true;
            this.PowerPointsLabel.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerPointsLabel.ForeColor = System.Drawing.Color.Yellow;
            this.PowerPointsLabel.Location = new System.Drawing.Point(635, 345);
            this.PowerPointsLabel.Name = "PowerPointsLabel";
            this.PowerPointsLabel.Size = new System.Drawing.Size(147, 25);
            this.PowerPointsLabel.TabIndex = 5;
            this.PowerPointsLabel.Text = "Power Points:";
            // 
            // PowerPointsCalculatedLabel
            // 
            this.PowerPointsCalculatedLabel.AutoSize = true;
            this.PowerPointsCalculatedLabel.Font = new System.Drawing.Font("High Tower Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerPointsCalculatedLabel.ForeColor = System.Drawing.Color.Yellow;
            this.PowerPointsCalculatedLabel.Location = new System.Drawing.Point(635, 370);
            this.PowerPointsCalculatedLabel.MinimumSize = new System.Drawing.Size(150, 0);
            this.PowerPointsCalculatedLabel.Name = "PowerPointsCalculatedLabel";
            this.PowerPointsCalculatedLabel.Size = new System.Drawing.Size(150, 37);
            this.PowerPointsCalculatedLabel.TabIndex = 6;
            this.PowerPointsCalculatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pokedex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(784, 499);
            this.Controls.Add(this.PowerPointsCalculatedLabel);
            this.Controls.Add(this.PowerPointsLabel);
            this.Controls.Add(this.SortTypeGroup);
            this.Controls.Add(this.SortKeyGroup);
            this.Controls.Add(this.PokedexPicture);
            this.Controls.Add(this.CollectionPanel);
            this.Controls.Add(this.CloseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 538);
            this.MinimumSize = new System.Drawing.Size(800, 538);
            this.Name = "Pokedex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokédex";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pokedex_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PokedexPicture)).EndInit();
            this.SortKeyGroup.ResumeLayout(false);
            this.SortKeyGroup.PerformLayout();
            this.SortTypeGroup.ResumeLayout(false);
            this.SortTypeGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel CollectionPanel;
        private System.Windows.Forms.PictureBox PokedexPicture;
        private System.Windows.Forms.GroupBox SortKeyGroup;
        private System.Windows.Forms.RadioButton RadioAttackDamage;
        private System.Windows.Forms.RadioButton RadioPowerPoints;
        private System.Windows.Forms.RadioButton RadioName;
        private System.Windows.Forms.GroupBox SortTypeGroup;
        private System.Windows.Forms.RadioButton RadioDescending;
        private System.Windows.Forms.RadioButton RadioAscending;
        private System.Windows.Forms.Label PowerPointsLabel;
        private System.Windows.Forms.Label PowerPointsCalculatedLabel;
    }
}