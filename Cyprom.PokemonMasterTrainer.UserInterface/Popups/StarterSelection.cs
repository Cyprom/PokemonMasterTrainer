using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Business.Helpers;
using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Enums;
using Cyprom.PokemonMasterTrainer.UserInterface.Helpers;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class StarterSelection : Form
    {
        private readonly SoundPlayer soundPlayer;
        private readonly BackgroundWorker aiThread;

        private readonly List<Chip> starters;
        private IButtonControl botChoice;

        public bool Bot { get; set; }
        public ReturnResult ReturnFunction { get; set; }
        public delegate void ReturnResult(Chip starter, StarterSelection origin);

        public StarterSelection()
        {
            InitializeComponent();
            soundPlayer = SoundPlayer.Instance();
            aiThread = new BackgroundWorker();
            aiThread.DoWork += Sleep;
            aiThread.RunWorkerCompleted += BotClick;
            starters = Randomizer.Shuffle(LoadFacade.LoadChips(Rarity.Starter));
            foreach (var starter in starters)
            {
                starter.Clickable = true;
                starter.MouseEnter += Starter_Hover;
                starter.Click += Starter_Click;
            }
            starters[0].Location = new Point(55, 85);
            starters[1].Location = new Point(205, 85);
            starters[2].Location = new Point(355, 85);
            Controls.AddRange(starters.ToArray());
        }

        private void Starter_Hover(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Hover", false), false);
        }

        private void Starter_Click(object sender, EventArgs eventArgs)
        {
            var starter = (Chip)sender;
            starter.Flipped = true;
            starter.Refresh();
            soundPlayer.Play(LoadFacade.BuildUri("Flip", false), false);
            MessageHelper.ShowMessage(string.Format("Congratulations, you got {0}!", starter.Pokemon), TechnicalConstants.STARTER_SELECTION, Bot);
            starter.Click -= Starter_Click;
            Controls.Remove(starter);
            starters.Remove(starter);
            ReturnFunction(starter, this);
        }

        private void StarterSelection_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            MessageHelper.ShowMessage("It's a dangerous world out there, you should choose a Pokémon!", TechnicalConstants.STARTER_SELECTION, Bot);
            eventArgs.Cancel = true;
        }

        public void Reactivate()
        {
            foreach (var starter in starters)
            {
                starter.Clickable = true;
            }
            if (Bot)
            {
                foreach (var starter in starters)
                {
                    starter.Clickable = false;
                }
                botChoice = ArtificialIntelligence.SelectStarter(starters);
                aiThread.RunWorkerAsync();
            }
        }

        private static void Sleep(object sender, DoWorkEventArgs eventArgs)
        {
            ArtificialIntelligence.Sleep();
        }

        private void BotClick(object sender, RunWorkerCompletedEventArgs eventArgs)
        {
            if (botChoice != null)
            {
                botChoice.PerformClick();
            }
        }

    }
}
