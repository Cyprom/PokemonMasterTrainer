using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;
using Cyprom.PokemonMasterTrainer.UserInterface.Helpers;
using Cyprom.PokemonMasterTrainer.UserInterface.Properties;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class PlayerSelection : Form
    {
        private readonly Home parent;
        private readonly SoundPlayer soundPlayer;

        private Trainer ash;
        private Trainer misty;
        private Trainer brock;

        public PlayerSelection(Home parent)
        {
            InitializeComponent();
            this.parent = parent;
            soundPlayer = SoundPlayer.Instance();
            AddTrainers();
            AshType.Image = Resources.Human;
            MistyType.Image = Resources.Human;
            BrockType.Image = Resources.Human;
            AshType.Tag = PlayerType.Human;
            MistyType.Tag = PlayerType.Human;
            BrockType.Tag = PlayerType.Human;
            AddSoundEvents();
        }

        private void AddSoundEvents()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.MouseEnter += EnterSoundEvent;
                button.Click += ClickSoundEvent;
            }
            foreach (var pictureBox in AshPanel.Controls.OfType<PictureBox>())
            {
                pictureBox.MouseEnter += EnterSoundEvent;
                pictureBox.Click += ClickSoundEvent;
            }
            foreach (var pictureBox in MistyPanel.Controls.OfType<PictureBox>())
            {
                pictureBox.MouseEnter += EnterSoundEvent;
                pictureBox.Click += ClickSoundEvent;
            }
            foreach (var pictureBox in BrockPanel.Controls.OfType<PictureBox>())
            {
                pictureBox.MouseEnter += EnterSoundEvent;
                pictureBox.Click += ClickSoundEvent;
            }
        }

        private void AddTrainers()
        {
            ash = LoadFacade.LoadAsh();
            ash.Location = new Point(40, 20);
            AshPanel.Controls.Add(ash);
            misty = LoadFacade.LoadMisty();
            misty.Location = new Point(40, 20);
            MistyPanel.Controls.Add(misty);
            brock = LoadFacade.LoadBrock();
            brock.Location = new Point(40, 20);
            BrockPanel.Controls.Add(brock);
        }

        private void StartButton_Click(object sender, EventArgs eventArgs)
        {
            var types = new List<PlayerType> { (PlayerType)AshType.Tag, (PlayerType)MistyType.Tag, (PlayerType)BrockType.Tag };
            if (types.Count(type => type == PlayerType.Disabled) > 1)
            {
                MessageHelper.ShowMessage("At least 2 players are needed to start the game!", TechnicalConstants.FAILED_TO_START, false);
            }
            else if (types.Count(type => type == PlayerType.Human) < 1)
            {
                MessageHelper.ShowMessage("At least 1 human player is needed to start the game!", TechnicalConstants.FAILED_TO_START, false);
            }
            else
            {
                if (ValidateNames())
                {
                    var players = CreatePlayers();
                    parent.StartGame(this, players);
                }
            }
        }

        private List<Player> CreatePlayers()
        {
            var players = new List<Player>();
            var ashType = (PlayerType)AshType.Tag;
            if (ashType != PlayerType.Disabled)
            {
                players.Add(new Player(AshName.Text, ashType, LoadFacade.LoadAsh()));
            }
            var mistyType = (PlayerType)MistyType.Tag;
            if (mistyType != PlayerType.Disabled)
            {
                players.Add(new Player(MistyName.Text, mistyType, LoadFacade.LoadMisty()));
            }
            var brockType = (PlayerType)BrockType.Tag;
            if (brockType != PlayerType.Disabled)
            {
                players.Add(new Player(BrockName.Text, brockType, LoadFacade.LoadBrock()));
            }
            return players;
        }

        private bool ValidateNames()
        {
            if (AshName.Text.Length == 0)
            {
                MessageHelper.ShowMessage("The player using Ash does not have a name!", TechnicalConstants.FAILED_TO_START, false);
                return false;
            }
            if (MistyName.Text.Length == 0)
            {
                MessageHelper.ShowMessage("The player using Misty does not have a name!", TechnicalConstants.FAILED_TO_START, false);
                return false;
            }
            if (BrockName.Text.Length == 0)
            {
                MessageHelper.ShowMessage("The player using Brock does not have a name!", TechnicalConstants.FAILED_TO_START, false);
                return false;
            }
            if (AshName.Text == MistyName.Text || MistyName.Text == BrockName.Text || AshName.Text == BrockName.Text)
            {
                MessageHelper.ShowMessage("There are players with identical names! Please use unique names.", TechnicalConstants.FAILED_TO_START, false);
                return false;
            }
            return true;
        }

        private void ReturnButton_Click(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void AshType_Click(object sender, EventArgs eventArgs)
        {
            switch ((PlayerType)AshType.Tag)
            {
                case PlayerType.Human:
                    AshType.Tag = PlayerType.Bot;
                    AshType.Image = Resources.Bot;
                    AshName.Enabled = false;
                    AshName.Text = "Ash (Bot)";
                    break;
                case PlayerType.Bot:
                    AshType.Tag = PlayerType.Disabled;
                    AshType.Image = Resources.Disabled;
                    AshName.Enabled = false;
                    AshName.Text = "/";
                    break;
                case PlayerType.Disabled:
                    AshType.Tag = PlayerType.Human;
                    AshType.Image = Resources.Human;
                    AshName.Enabled = true;
                    AshName.Text = string.Empty;
                    break;
            }
        }

        private void MistyType_Click(object sender, EventArgs eventArgs)
        {
            switch ((PlayerType)MistyType.Tag)
            {
                case PlayerType.Human:
                    MistyType.Tag = PlayerType.Bot;
                    MistyType.Image = Resources.Bot;
                    MistyName.Enabled = false;
                    MistyName.Text = "Misty (Bot)";
                    break;
                case PlayerType.Bot:
                    MistyType.Tag = PlayerType.Disabled;
                    MistyType.Image = Resources.Disabled;
                    MistyName.Enabled = false;
                    MistyName.Text = "/";
                    break;
                case PlayerType.Disabled:
                    MistyType.Tag = PlayerType.Human;
                    MistyType.Image = Resources.Human;
                    MistyName.Enabled = true;
                    MistyName.Text = string.Empty;
                    break;
            }
        }

        private void BrockType_Click(object sender, EventArgs eventArgs)
        {
            switch ((PlayerType)BrockType.Tag)
            {
                case PlayerType.Human:
                    BrockType.Tag = PlayerType.Bot;
                    BrockType.Image = Resources.Bot;
                    BrockName.Enabled = false;
                    BrockName.Text = "Brock (Bot)";
                    break;
                case PlayerType.Bot:
                    BrockType.Tag = PlayerType.Disabled;
                    BrockType.Image = Resources.Disabled;
                    BrockName.Enabled = false;
                    BrockName.Text = "/";
                    break;
                case PlayerType.Disabled:
                    BrockType.Tag = PlayerType.Human;
                    BrockType.Image = Resources.Human;
                    BrockName.Enabled = true;
                    BrockName.Text = string.Empty;
                    break;
            }
        }

        private void PlayerSelection_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            parent.Enabled = true;
            parent.Show();
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Hover", false), false);
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
        }
    }
}
