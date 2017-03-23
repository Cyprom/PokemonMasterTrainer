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
    public partial class Bag : Form
    {
        private readonly Board parent;
        private readonly SoundPlayer soundPlayer;
        private readonly BackgroundWorker aiThread;

        private readonly Player player;
        private IButtonControl botChoice;
        private CancelFunction cancelFunction;
        public delegate void CancelFunction(Bag bag);

        public Bag(Board parent, Player player, CancelFunction cancelFunction, params CardType[] enabledTypes)
        {
            InitializeComponent();
            soundPlayer = SoundPlayer.Instance();
            aiThread = new BackgroundWorker();
            aiThread.DoWork += Sleep;
            aiThread.RunWorkerCompleted += BotClick;
            this.parent = parent;
            this.player = player;
            this.cancelFunction = cancelFunction;
            ItemsCountedLabel.Text = player.Items.Count.ToString();
            LoadCollection(enabledTypes.ToList());
            var discard = enabledTypes.Count() == 0;
            AddClickEvents(discard);
            AddSoundEvents();
            soundPlayer.Play(LoadFacade.BuildUri("Bag", false), false);
        }

        private void AddSoundEvents()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.MouseEnter += EnterSoundEvent;
                button.Click += ClickSoundEvent;
            }
        }

        private void AddClickEvents(bool discard)
        {
            if (discard)
            {
                foreach (var item in player.Items)
                {
                    item.Click += Discard;
                }
            }
            else
            {
                foreach (var item in player.Items)
                {
                    switch (item.CardType)
                    {
                        case CardType.AttackBonus1:
                        case CardType.AttackBonus2:
                        case CardType.AttackBonus3:
                        case CardType.AttackBonus4:
                        case CardType.AttackBonus5:
                            item.Click += AddAttackBonus;
                            break;
                        case CardType.PokeDoll:
                            item.Click += EndChallengeOrTrade;
                            break;
                        case CardType.Fly:
                            item.Click += Fly;
                            break;
                        case CardType.Potion:
                            item.Click += SingleRevival;
                            break;
                        case CardType.GreatBall:
                        case CardType.UltraBall:
                        case CardType.MasterBall:
                            item.Click += UseSpecialBall;
                            break;
                    }
                }
            }
        }

        private void Discard(object sender, EventArgs eventArgs)
        {
            var result = MessageHelper.ShowMessage("Are you sure you want to discard this item?", TechnicalConstants.DISCARD, player.IsBot, MessageBoxButtons.YesNo);
            if (player.IsBot)
            {
                result = ArtificialIntelligence.ConfirmUsage() ? DialogResult.Yes : DialogResult.No;
            }
            if (result == DialogResult.Yes)
            {
                PutBackInDeck((Card)sender);
                LoadCollection(new List<CardType>());
                ItemsCountedLabel.Text = player.Items.Count.ToString();
                if (player.Items.Count <= 7)
                {
                    MessageHelper.ShowMessage("You have discarded enough items. This bag is no longer overloaded.", TechnicalConstants.DISCARD, player.IsBot);
                    cancelFunction = null;
                    parent.Discarded(this);
                }
                else if (player.IsBot)
                {
                    botChoice = ArtificialIntelligence.SelectDiscard(player);
                    aiThread.RunWorkerAsync();
                }
            }
        }

        private void AddAttackBonus(object sender, EventArgs eventArgs)
        {
            var result = MessageHelper.ShowMessage("Are you sure you want to use this Attack Bonus now?", TechnicalConstants.BATTLE, player.IsBot, MessageBoxButtons.YesNo);
            if (player.IsBot)
            {
                result = ArtificialIntelligence.ConfirmUsage() ? DialogResult.Yes : DialogResult.No;
            }
            if (result == DialogResult.Yes)
            {
                PutBackInDeck((Card)sender);
                cancelFunction = null;
                parent.AttackBonusUsed(this, player, (Card)sender);
            }
        }

        private void EndChallengeOrTrade(object sender, EventArgs eventArgs)
        {
            var result = MessageHelper.ShowMessage("Are you sure you want to use a Poké Doll now?", TechnicalConstants.POKEDOLL, player.IsBot, MessageBoxButtons.YesNo);
            if (player.IsBot)
            {
                result = ArtificialIntelligence.ConfirmUsage() ? DialogResult.Yes : DialogResult.No;
            }
            if (result == DialogResult.Yes)
            {
                PutBackInDeck((Card)sender);
                cancelFunction = null;
                parent.PokeDollUsed(this);
            }
        }

        private void Fly(object sender, EventArgs eventArgs)
        {
            var result = MessageHelper.ShowMessage("Are you sure you want to use Fly now?", TechnicalConstants.FLY, player.IsBot, MessageBoxButtons.YesNo);
            if (player.IsBot)
            {
                result = ArtificialIntelligence.ConfirmUsage() ? DialogResult.Yes : DialogResult.No;
            }
            if (result == DialogResult.Yes)
            {
                PutBackInDeck((Card)sender);
                cancelFunction = null;
                parent.Fly(this);
            }
        }

        private void SingleRevival(object sender, EventArgs eventArgs)
        {
            if (!player.HasKnockedOutPokemon)
            {
                MessageHelper.ShowMessage(string.Format(TechnicalConstants.NO_USE, "All your Pokémon are healthy."), TechnicalConstants.REVIVAL, player.IsBot);
            }
            else
            {
                var result = MessageHelper.ShowMessage("Are you sure you want to use a Potion now?", TechnicalConstants.REVIVAL, player.IsBot, MessageBoxButtons.YesNo);
                if (player.IsBot)
                {
                    result = ArtificialIntelligence.ConfirmUsage() ? DialogResult.Yes : DialogResult.No;
                }
                if (result == DialogResult.Yes)
                {
                    PutBackInDeck((Card)sender);
                    cancelFunction = null;
                    parent.UsePotion(this);
                }
            }
        }

        private void UseSpecialBall(object sender, EventArgs eventArgs)
        {
            var result = MessageHelper.ShowMessage("Are you sure you want to use this Poké Ball now?", TechnicalConstants.CATCH, player.IsBot, MessageBoxButtons.YesNo);
            if (player.IsBot)
            {
                result = ArtificialIntelligence.ConfirmUsage() ? DialogResult.Yes : DialogResult.No;
            }
            if (result == DialogResult.Yes)
            {
                PutBackInDeck((Card)sender);
                cancelFunction = null;
                parent.CatchWithBall(this, (Card)sender);
            }
        }

        public void HandleBotChoice(Card choice)
        {
            CloseButton.Enabled = false;
            foreach (var item in player.Items)
            {
                item.Enabled = false;
            }
            botChoice = choice;
            aiThread.RunWorkerAsync();
        }

        private void LoadCollection(ICollection<CardType> enabledTypes)
        {
            CollectionPanel.Controls.Clear();
            var collection = player.Items.OrderBy(item => item.CardType).ToList();
            for (var i = 0; i < collection.Count; i++)
            {
                var horizontalPosition = (TechnicalConstants.COLLECTION_START * ((i % 3) + 1)) + (TechnicalConstants.CARD_WIDTH * (i % 3));
                var verticalPosition = (int)((TechnicalConstants.COLLECTION_START * (Math.Floor(i / 3d) + 1)) + (TechnicalConstants.CARD_HEIGHT * Math.Floor(i / 3d)));
                collection[i].Location = new Point(horizontalPosition, verticalPosition);
                CollectionPanel.Controls.Add(collection[i]);

                if (enabledTypes.Count == 0 || enabledTypes.Contains(collection[i].CardType))
                {
                    collection[i].Enabled = true;
                }
            }
            var amount = ((collection.Count - 1) / 3);
            var width = CollectionPanel.Size.Width;
            var height = TechnicalConstants.COLLECTION_START * (amount + 2) + TechnicalConstants.CARD_HEIGHT * (amount + 1);
            if (collection.Count > 2)
            {
                width = TechnicalConstants.COLLECTION_START * 4 + TechnicalConstants.CARD_WIDTH * 3;
            }
            CollectionPanel.AutoScrollMinSize = new Size(width, height);
        }

        private void Bag_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if (cancelFunction == null)
            {
                CollectionPanel.Controls.Clear();
                foreach (var item in player.Items)
                {
                    item.Enabled = false;
                    item.Click -= AddAttackBonus;
                    item.Click -= EndChallengeOrTrade;
                    item.Click -= Fly;
                    item.Click -= SingleRevival;
                    item.Click -= UseSpecialBall;
                    item.Click -= Discard;
                }
                parent.PopUps.Remove(this);
                parent.Show();
            }
            else
            {
                eventArgs.Cancel = true;
                var function = cancelFunction;
                cancelFunction = null;
                function(this);
            }
        }

        private void PutBackInDeck(Card card)
        {
            player.Items.Remove(card);
            if (card.CardType != CardType.MasterBall)
            {
                parent.PutCardBackInDeck(card);
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
