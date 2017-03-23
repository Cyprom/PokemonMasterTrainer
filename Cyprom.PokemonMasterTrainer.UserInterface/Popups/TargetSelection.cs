using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.UserInterface.Helpers;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class TargetSelection : Form
    {
        private readonly SoundPlayer soundPlayer;
        private readonly BackgroundWorker aiThread;

        public ReturnResult ReturnFunction { get; set; }
        public delegate void ReturnResult(Player challenger, Player target);

        private readonly int activePlayerIndex;
        private readonly List<Player> players;
        private readonly bool battle;
        private readonly List<Trainer> trainers;
        private IButtonControl botChoice;

        public TargetSelection(List<Player> players, int activePlayerIndex, bool battle)
        {
            InitializeComponent();
            soundPlayer = SoundPlayer.Instance();
            aiThread = new BackgroundWorker();
            aiThread.DoWork += Sleep;
            aiThread.RunWorkerCompleted += BotClick;
            this.activePlayerIndex = activePlayerIndex;
            this.players = players;
            this.battle = battle;
            trainers = new List<Trainer>();
        }

        private void TargetSelection_Load(object sender, EventArgs eventArgs)
        {
            SelectionLabel.Text = string.Format("Select the player you wish to {0} with.", battle ? "battle" : "trade");
            var first = true;
            foreach (var player in players.Where(player => players.IndexOf(player) != activePlayerIndex))
            {
                var trainer = player.Trainer.Clone();
                trainer.MouseEnter += EnterSoundEvent;
                trainer.Click += ClickSoundEvent;
                trainer.Click += SelectPlayer;
                trainer.Tag = players.IndexOf(player);
                trainer.Cursor = Cursors.Hand;
                trainer.Location = new Point(first ? 80 : 210, 50);
                trainers.Add(trainer);
                Controls.Add(trainer);
                first = false;
            }
        }

        private void SelectPlayer(object sender, EventArgs eventArgs)
        {
            var active = players[activePlayerIndex];
            var selected = players[(int)((Trainer)sender).Tag];
            if (!battle && !active.CanTrade(selected).Any())
            {
                MessageHelper.ShowMessage(string.Format("There are no possible trade with {0}. Select a different target.", selected.Name), TechnicalConstants.TRADE, active.IsBot);
            }
            else if (battle && !selected.CanBattle)
            {
                MessageHelper.ShowMessage(string.Format("{0} is not able to battle. Select a different target.", selected.Name), TechnicalConstants.BATTLE, active.IsBot);
            }
            else
            {
                Visible = false;
                var function = ReturnFunction;
                ReturnFunction = null;
                function(active, selected);
            }
        }

        private void TargetSelection_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            MessageHelper.ShowMessage("You must select a trainer now.", TechnicalConstants.TARGET_SELECTION, players[activePlayerIndex].IsBot);
            eventArgs.Cancel = true;
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Hover", false), false);
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
        }

        public void HandleBotChoice(Player choice)
        {
            foreach (var trainer in trainers)
            {
                trainer.Enabled = false;
            }
            botChoice = trainers.Single(trainer => (int)trainer.Tag == players.IndexOf(choice));
            aiThread.RunWorkerAsync();
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
