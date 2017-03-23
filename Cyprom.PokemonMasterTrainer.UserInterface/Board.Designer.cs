namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    partial class Board
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.BoardPicture = new System.Windows.Forms.PictureBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.QuitButton = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.GroupBox();
            this.LogView = new System.Windows.Forms.TextBox();
            this.OptionsBox = new System.Windows.Forms.GroupBox();
            this.ScreenLockQuick = new System.Windows.Forms.PictureBox();
            this.SoundQuick = new System.Windows.Forms.PictureBox();
            this.MusicQuick = new System.Windows.Forms.PictureBox();
            this.PlayerBox = new System.Windows.Forms.GroupBox();
            this.DiceCup = new System.Windows.Forms.PictureBox();
            this.ItemBag = new System.Windows.Forms.PictureBox();
            this.Pokedex = new System.Windows.Forms.PictureBox();
            this.StatusBox = new System.Windows.Forms.GroupBox();
            this.CurrentPlayerPicture = new System.Windows.Forms.PictureBox();
            this.CurrentPlayerLabel = new System.Windows.Forms.Label();
            this.PlayerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.BoardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardPicture)).BeginInit();
            this.InfoPanel.SuspendLayout();
            this.LogBox.SuspendLayout();
            this.OptionsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenLockQuick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundQuick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicQuick)).BeginInit();
            this.PlayerBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiceCup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokedex)).BeginInit();
            this.StatusBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPlayerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.AutoScroll = true;
            this.BoardPanel.Controls.Add(this.BoardPicture);
            this.BoardPanel.Location = new System.Drawing.Point(200, 0);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(1035, 560);
            this.BoardPanel.TabIndex = 1;
            // 
            // BoardPicture
            // 
            this.BoardPicture.BackColor = System.Drawing.SystemColors.Control;
            this.BoardPicture.InitialImage = null;
            this.BoardPicture.Location = new System.Drawing.Point(0, 0);
            this.BoardPicture.Margin = new System.Windows.Forms.Padding(0);
            this.BoardPicture.Name = "BoardPicture";
            this.BoardPicture.Size = new System.Drawing.Size(2000, 1474);
            this.BoardPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BoardPicture.TabIndex = 0;
            this.BoardPicture.TabStop = false;
            this.BoardPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BoardPicture_MouseDown);
            this.BoardPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BoardPicture_MouseMove);
            this.BoardPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BoardPicture_MouseUp);
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.Black;
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoPanel.Controls.Add(this.QuitButton);
            this.InfoPanel.Controls.Add(this.LogBox);
            this.InfoPanel.Controls.Add(this.OptionsBox);
            this.InfoPanel.Controls.Add(this.PlayerBox);
            this.InfoPanel.Controls.Add(this.StatusBox);
            this.InfoPanel.Location = new System.Drawing.Point(0, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(200, 560);
            this.InfoPanel.TabIndex = 2;
            this.InfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InfoPanel_Paint);
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.SystemColors.Control;
            this.QuitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.QuitButton.ForeColor = System.Drawing.Color.White;
            this.QuitButton.Location = new System.Drawing.Point(30, 5);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(140, 60);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.TabStop = false;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // LogBox
            // 
            this.LogBox.Controls.Add(this.LogView);
            this.LogBox.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold);
            this.LogBox.ForeColor = System.Drawing.SystemColors.Control;
            this.LogBox.Location = new System.Drawing.Point(3, 370);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(190, 230);
            this.LogBox.TabIndex = 3;
            this.LogBox.TabStop = false;
            this.LogBox.Text = "Log";
            // 
            // LogView
            // 
            this.LogView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.LogView.BackColor = System.Drawing.Color.Black;
            this.LogView.CausesValidation = false;
            this.LogView.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogView.ForeColor = System.Drawing.Color.White;
            this.LogView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.LogView.Location = new System.Drawing.Point(10, 26);
            this.LogView.MaxLength = 2147483647;
            this.LogView.Multiline = true;
            this.LogView.Name = "LogView";
            this.LogView.ReadOnly = true;
            this.LogView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogView.Size = new System.Drawing.Size(170, 195);
            this.LogView.TabIndex = 0;
            this.LogView.TabStop = false;
            // 
            // OptionsBox
            // 
            this.OptionsBox.Controls.Add(this.ScreenLockQuick);
            this.OptionsBox.Controls.Add(this.SoundQuick);
            this.OptionsBox.Controls.Add(this.MusicQuick);
            this.OptionsBox.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold);
            this.OptionsBox.ForeColor = System.Drawing.SystemColors.Control;
            this.OptionsBox.Location = new System.Drawing.Point(3, 270);
            this.OptionsBox.Name = "OptionsBox";
            this.OptionsBox.Size = new System.Drawing.Size(190, 100);
            this.OptionsBox.TabIndex = 2;
            this.OptionsBox.TabStop = false;
            this.OptionsBox.Text = "Quick Options";
            // 
            // ScreenLockQuick
            // 
            this.ScreenLockQuick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ScreenLockQuick.Location = new System.Drawing.Point(130, 35);
            this.ScreenLockQuick.Name = "ScreenLockQuick";
            this.ScreenLockQuick.Size = new System.Drawing.Size(50, 50);
            this.ScreenLockQuick.TabIndex = 5;
            this.ScreenLockQuick.TabStop = false;
            this.PlayerToolTip.SetToolTip(this.ScreenLockQuick, "Switch screen lock on/off");
            this.ScreenLockQuick.Click += new System.EventHandler(this.ScreenLockQuick_Click);
            // 
            // SoundQuick
            // 
            this.SoundQuick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SoundQuick.Location = new System.Drawing.Point(70, 35);
            this.SoundQuick.Name = "SoundQuick";
            this.SoundQuick.Size = new System.Drawing.Size(50, 50);
            this.SoundQuick.TabIndex = 4;
            this.SoundQuick.TabStop = false;
            this.PlayerToolTip.SetToolTip(this.SoundQuick, "Switch sounds on/off");
            this.SoundQuick.Click += new System.EventHandler(this.SoundQuick_Click);
            // 
            // MusicQuick
            // 
            this.MusicQuick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MusicQuick.Location = new System.Drawing.Point(10, 35);
            this.MusicQuick.Name = "MusicQuick";
            this.MusicQuick.Size = new System.Drawing.Size(50, 50);
            this.MusicQuick.TabIndex = 3;
            this.MusicQuick.TabStop = false;
            this.PlayerToolTip.SetToolTip(this.MusicQuick, "Switch music on/off");
            this.MusicQuick.Click += new System.EventHandler(this.MusicQuick_Click);
            // 
            // PlayerBox
            // 
            this.PlayerBox.Controls.Add(this.DiceCup);
            this.PlayerBox.Controls.Add(this.ItemBag);
            this.PlayerBox.Controls.Add(this.Pokedex);
            this.PlayerBox.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold);
            this.PlayerBox.ForeColor = System.Drawing.SystemColors.Control;
            this.PlayerBox.Location = new System.Drawing.Point(3, 170);
            this.PlayerBox.Name = "PlayerBox";
            this.PlayerBox.Size = new System.Drawing.Size(190, 100);
            this.PlayerBox.TabIndex = 1;
            this.PlayerBox.TabStop = false;
            this.PlayerBox.Text = "Player Box";
            // 
            // DiceCup
            // 
            this.DiceCup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DiceCup.Image = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.DiceCup_Small;
            this.DiceCup.Location = new System.Drawing.Point(130, 35);
            this.DiceCup.Name = "DiceCup";
            this.DiceCup.Size = new System.Drawing.Size(50, 50);
            this.DiceCup.TabIndex = 2;
            this.DiceCup.TabStop = false;
            this.PlayerToolTip.SetToolTip(this.DiceCup, "Roll the dice");
            this.DiceCup.Click += new System.EventHandler(this.DiceCup_Click);
            // 
            // ItemBag
            // 
            this.ItemBag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ItemBag.Image = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.ItemBag_Small;
            this.ItemBag.Location = new System.Drawing.Point(70, 35);
            this.ItemBag.Name = "ItemBag";
            this.ItemBag.Size = new System.Drawing.Size(50, 50);
            this.ItemBag.TabIndex = 1;
            this.ItemBag.TabStop = false;
            this.PlayerToolTip.SetToolTip(this.ItemBag, "Open your Item Bag");
            this.ItemBag.Click += new System.EventHandler(this.ItemBag_Click);
            // 
            // Pokedex
            // 
            this.Pokedex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pokedex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pokedex.Image = global::Cyprom.PokemonMasterTrainer.UserInterface.Properties.Resources.Pokedex_Small;
            this.Pokedex.Location = new System.Drawing.Point(10, 35);
            this.Pokedex.Name = "Pokedex";
            this.Pokedex.Size = new System.Drawing.Size(50, 50);
            this.Pokedex.TabIndex = 0;
            this.Pokedex.TabStop = false;
            this.PlayerToolTip.SetToolTip(this.Pokedex, "View your Pokédex");
            this.Pokedex.Click += new System.EventHandler(this.Pokedex_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.Controls.Add(this.CurrentPlayerPicture);
            this.StatusBox.Controls.Add(this.CurrentPlayerLabel);
            this.StatusBox.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Control;
            this.StatusBox.Location = new System.Drawing.Point(3, 70);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(190, 100);
            this.StatusBox.TabIndex = 0;
            this.StatusBox.TabStop = false;
            this.StatusBox.Text = "Currently Playing";
            // 
            // CurrentPlayerPicture
            // 
            this.CurrentPlayerPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CurrentPlayerPicture.Location = new System.Drawing.Point(10, 35);
            this.CurrentPlayerPicture.Name = "CurrentPlayerPicture";
            this.CurrentPlayerPicture.Size = new System.Drawing.Size(50, 50);
            this.CurrentPlayerPicture.TabIndex = 1;
            this.CurrentPlayerPicture.TabStop = false;
            // 
            // CurrentPlayerLabel
            // 
            this.CurrentPlayerLabel.AutoSize = true;
            this.CurrentPlayerLabel.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPlayerLabel.Location = new System.Drawing.Point(65, 50);
            this.CurrentPlayerLabel.Name = "CurrentPlayerLabel";
            this.CurrentPlayerLabel.Size = new System.Drawing.Size(0, 22);
            this.CurrentPlayerLabel.TabIndex = 0;
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.BoardPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1050, 600);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "Board";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Board_FormClosing);
            this.Load += new System.EventHandler(this.Board_Load);
            this.BoardPanel.ResumeLayout(false);
            this.BoardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardPicture)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            this.LogBox.ResumeLayout(false);
            this.LogBox.PerformLayout();
            this.OptionsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenLockQuick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundQuick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicQuick)).EndInit();
            this.PlayerBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DiceCup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokedex)).EndInit();
            this.StatusBox.ResumeLayout(false);
            this.StatusBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPlayerPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BoardPicture;
        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.GroupBox OptionsBox;
        private System.Windows.Forms.PictureBox ScreenLockQuick;
        private System.Windows.Forms.PictureBox SoundQuick;
        private System.Windows.Forms.PictureBox MusicQuick;
        private System.Windows.Forms.GroupBox PlayerBox;
        private System.Windows.Forms.PictureBox ItemBag;
        private System.Windows.Forms.PictureBox Pokedex;
        private System.Windows.Forms.GroupBox StatusBox;
        private System.Windows.Forms.PictureBox CurrentPlayerPicture;
        private System.Windows.Forms.Label CurrentPlayerLabel;
        private System.Windows.Forms.PictureBox DiceCup;
        private System.Windows.Forms.ToolTip PlayerToolTip;
        private System.Windows.Forms.GroupBox LogBox;
        private System.Windows.Forms.TextBox LogView;
        private System.Windows.Forms.Button QuitButton;

    }
}

