using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.UserInterface.Popups;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.UserInterface.Helpers;

namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    public partial class Home : Form
    {
        private readonly SoundPlayer soundPlayer;

        public Home()
        {
            InitializeComponent();
            soundPlayer = SoundPlayer.Instance();
            if (ConfigurationManager.Instance().Music)
            {
                MusicPlayer.Instance().Play(LoadFacade.BuildUri("Theme", true));
            }
            AddSoundEvents();
            Show();
        }

        private void AddSoundEvents()
        {
            foreach (var label in Controls.OfType<Label>())
            {
                label.MouseEnter += EnterSoundEvent;
                label.Click += ClickSoundEvent;
            }
        }

        private void Label_MouseEnter(object sender, EventArgs eventArgs)
        {
            var label = (Label)sender;
            if (label.Enabled)
            {
                label.ForeColor = Color.OrangeRed;
            }
        }

        private void Label_MouseLeave(object sender, EventArgs eventArgs)
        {
            var label = (Label)sender;
            if (label.Enabled)
            {
                label.ForeColor = Color.Black;
            }
        }

        private void NewGameLabel_Click(object sender, EventArgs eventArgs)
        {
            if (GameManager.Instance().SaveGameAvailable())
            {
                var result = MessageHelper.ShowMessage("Are you sure you want to start a new game? Your saved game will be lost...", TechnicalConstants.NEW_GAME, false, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    GameManager.Instance().DeleteSavedGame();
                    var playerSelection = new PlayerSelection(this);
                    playerSelection.Show();
                    Enabled = false;
                }
            }
            else
            {
                var playerSelection = new PlayerSelection(this);
                playerSelection.Show();
                Enabled = false;
            }
        }

        public void StartGame(Form caller, List<Player> players)
        {
            caller.Dispose();
            var board = new Board(this);
            board.Show();
            Visible = false;
            Enabled = true;
            board.StartGame(players);
        }

        private void LoadGameLabel_Click(object sender, EventArgs eventArgs)
        {
            var board = new Board(this);
            board.Show();
            Visible = false;
            Enabled = true;
            board.StartGame();
        }

        private void InstructionsLabel_Click(object sender, EventArgs eventArgs)
        {
            var popup = new Instructions(this);
            popup.Show();
            Enabled = false;
        }

        private void OptionLabel_Click(object sender, EventArgs eventArgs)
        {
            var popup = new Options(this);
            popup.Show();
            Enabled = false;
        }

        private void CreditsLabel_Click(object sender, EventArgs eventArgs)
        {
            var popup = new Credits(this);
            popup.Show();
            Enabled = false;
        }

        private void ExitLabel_Click(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void Home_VisibleChanged(object sender, EventArgs eventArgs)
        {
            if (Visible)
            {
                NewGameLabel.ForeColor = Color.Black;
                LoadGameLabel.ForeColor = Color.Black;
                InstructionsLabel.ForeColor = Color.Black;
                OptionLabel.ForeColor = Color.Black;
                CreditsLabel.ForeColor = Color.Black;
                ExitLabel.ForeColor = Color.Black;
                LoadGameLabel.Enabled = GameManager.Instance().SaveGameAvailable();
            }
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Hover", false), false);
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            Environment.Exit(0);
        }
    }
}
