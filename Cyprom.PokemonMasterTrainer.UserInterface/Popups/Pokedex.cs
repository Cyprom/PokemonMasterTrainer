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
using Cyprom.PokemonMasterTrainer.Enums;
using Cyprom.PokemonMasterTrainer.UserInterface.Helpers;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class Pokedex : Form
    {
        private readonly Board parent;
        private readonly SoundPlayer soundPlayer;
        private readonly BackgroundWorker aiThread;
        
        private readonly Player player;
        private bool canClose;
        private Chip alreadySelected;
        private IButtonControl botChoice;

        public bool PotionUsed { get; set; }

        public Pokedex(Board parent, Player player, bool canClose, bool battle, bool revival, bool trade, List<Rarity> rarities, Chip alreadySelected)
        {
            InitializeComponent();
            soundPlayer = SoundPlayer.Instance();
            aiThread = new BackgroundWorker();
            aiThread.DoWork += Sleep;
            aiThread.RunWorkerCompleted += BotClick;
            this.parent = parent;
            this.player = player;
            this.canClose = canClose;
            this.alreadySelected = alreadySelected;
            if (rarities == null)
            {
                rarities = Enum.GetValues(typeof(Rarity)).Cast<Rarity>().ToList();
            }
            PowerPointsCalculatedLabel.Text = player.PowerPoints.ToString();
            CheckRadioButtons(player.SortKey, player.SortType);
            LoadCollection();
            AddClickEvents(battle, trade, revival, rarities);
            AddSoundEvents();
            soundPlayer.Play(LoadFacade.BuildUri("Pokedex", false), false);
            PotionUsed = false;
        }

        private void CheckRadioButtons(SortKey sortKey, SortType sortType)
        {
            RadioName.Tag = (int)SortKey.Name;
            RadioPowerPoints.Tag = (int)SortKey.PowerPoints;
            RadioAttackDamage.Tag = (int)SortKey.AttackDamage;
            RadioAscending.Tag = (int)SortType.Ascending;
            RadioDescending.Tag = (int)SortType.Descending;
            switch (sortKey)
            {
                case SortKey.Name: RadioName.Checked = true;
                    break;
                case SortKey.PowerPoints: RadioPowerPoints.Checked = true;
                    break;
                case SortKey.AttackDamage: RadioAttackDamage.Checked = true;
                    break;
            }
            switch (sortType)
            {
                case SortType.Ascending: RadioAscending.Checked = true;
                    break;
                case SortType.Descending: RadioDescending.Checked = true;
                    break;
            }
        }

        private void AddSoundEvents()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.MouseEnter += EnterSoundEvent;
                button.Click += ClickSoundEvent;
            }
        }

        private void LoadCollection()
        {
            CollectionPanel.Controls.Clear();
            var horizontalPosition = TechnicalConstants.COLLECTION_START;
            LoadColumn(player.Pokemon.Where(chip => chip.Rarity == Rarity.Pink).ToList(), player.Pokemon.SingleOrDefault(chip => chip.Rarity == Rarity.Starter), horizontalPosition);
            horizontalPosition += TechnicalConstants.COLLECTION_MARGIN;
            LoadColumn(player.Pokemon.Where(chip => chip.Rarity == Rarity.Green).ToList(), null, horizontalPosition);
            horizontalPosition += TechnicalConstants.COLLECTION_MARGIN;
            LoadColumn(player.Pokemon.Where(chip => chip.Rarity == Rarity.Blue).ToList(), null, horizontalPosition);
            horizontalPosition += TechnicalConstants.COLLECTION_MARGIN;
            LoadColumn(player.Pokemon.Where(chip => chip.Rarity == Rarity.Red).ToList(), null, horizontalPosition);
            horizontalPosition += TechnicalConstants.COLLECTION_MARGIN;
            LoadColumn(player.Pokemon.Where(chip => chip.Rarity == Rarity.Yellow).ToList(), null, horizontalPosition);
        }

        private void AddClickEvents(bool battle, bool trade, bool revival, ICollection<Rarity> rarities)
        {
            foreach (var chip in player.Pokemon.Where(pokemon => rarities.Contains(pokemon.Rarity)))
            {
                if (!chip.KnockedOut && battle)
                {
                    chip.Clickable = true;
                    chip.Click += ChooseForBattle;
                }
                else if (trade && chip.Rarity != Rarity.Starter)
                {
                    chip.Clickable = true;
                    chip.Click += Trade;
                }
                else if (chip.KnockedOut && revival)
                {
                    chip.Clickable = true;
                    chip.Click += Revive;
                }
            }
        }

        private void ChooseForBattle(object sender, EventArgs eventArgs)
        {
            canClose = true;
            player.ActivePokemon = (Chip)sender;
            if (alreadySelected == null)
            {
                parent.BattleSelected(this, (Chip)sender, null);
            }
            else
            {
                var firstParty = alreadySelected;
                alreadySelected = null;
                parent.BattleSelected(this, firstParty, (Chip)sender);
            }
        }

        private void Trade(object sender, EventArgs eventArgs)
        {
            canClose = true;
            if (alreadySelected == null)
            {
                parent.TradeSelected(this, (Chip)sender, null);
            }
            else
            {
                var firstParty = alreadySelected;
                alreadySelected = null;
                parent.TradeSelected(this, firstParty, (Chip)sender);
            }
        }

        private void Revive(object sender, EventArgs eventArgs)
        {
            var pokemon = (Chip)sender;
            pokemon.KnockedOut = false;
            pokemon.Refresh();
            PowerPointsCalculatedLabel.Text = player.PowerPoints.ToString();
            Enabled = false;
            MessageHelper.ShowMessage(string.Format("You revived {0}.", pokemon.Pokemon), TechnicalConstants.REVIVAL, player.IsBot);
            canClose = true;
            parent.RevivalEnded(this, pokemon);
        }

        public void HandleBotChoice(Chip choice)
        {
            CloseButton.Enabled = false;
            foreach (var chip in player.Pokemon)
            {
                chip.Clickable = false;
            }
            botChoice = choice;
            aiThread.RunWorkerAsync();
        }

        private void LoadColumn(IEnumerable<Chip> subCollection, Chip starter, int horizontalPosition)
        {
            var verticalPosition = TechnicalConstants.COLLECTION_START;
            if (starter != null)
            {
                starter.Location = new Point(horizontalPosition, verticalPosition);
                CollectionPanel.Controls.Add(starter);
                verticalPosition += TechnicalConstants.COLLECTION_MARGIN;
            }
            var sortedCollection = SortCollection(subCollection);
            foreach (var chip in sortedCollection)
            {
                chip.Location = new Point(horizontalPosition, verticalPosition);
                CollectionPanel.Controls.Add(chip);
                verticalPosition += TechnicalConstants.COLLECTION_MARGIN;
            }
            if (verticalPosition > CollectionPanel.AutoScrollMinSize.Height)
            {
                CollectionPanel.AutoScrollMinSize = new Size(CollectionPanel.AutoScrollMinSize.Width, verticalPosition);
            }
        }

        private IEnumerable<Chip> SortCollection(IEnumerable<Chip> subCollection)
        {
            switch (player.SortKey)
            {
                case SortKey.PowerPoints:
                    return player.SortType == SortType.Ascending
                        ? subCollection.OrderBy(chip => chip.PowerPoints).ToList()
                        : subCollection.OrderByDescending(chip => chip.PowerPoints).ToList();
                case SortKey.AttackDamage:
                    return player.SortType == SortType.Ascending
                        ? subCollection.OrderBy(chip => chip.Damage).ToList()
                        : subCollection.OrderByDescending(chip => chip.Damage).ToList();
                default:
                    return player.SortType == SortType.Ascending
                        ? subCollection.OrderBy(chip => chip.Pokemon).ToList()
                        : subCollection.OrderByDescending(chip => chip.Pokemon).ToList();
            }
        }

        private void Pokedex_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if (canClose)
            {
                CollectionPanel.Controls.Clear();
                foreach (var chip in player.Pokemon)
                {
                    chip.Clickable = false;
                    chip.Click -= Revive;
                    chip.Click -= ChooseForBattle;
                    chip.Click -= Trade;
                }
                parent.PopUps.Remove(this);
                parent.Show();
            }
            else
            {
                MessageHelper.ShowMessage("You must select a Pokémon now.", TechnicalConstants.POKEDEX, player.IsBot);
                eventArgs.Cancel = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Hover", false), false);
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
        }

        private void RadioSortKey_Changed(object sender, EventArgs eventArgs)
        {
            var radio = (RadioButton)sender;
            if (radio.Checked)
            {
                player.SortKey = (SortKey)radio.Tag;
            }
            LoadCollection();
        }

        private void RadioSortType_Changed(object sender, EventArgs eventArgs)
        {
            var radio = (RadioButton)sender;
            if (radio.Checked)
            {
                player.SortType = (SortType)radio.Tag;
            }
            LoadCollection();
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
