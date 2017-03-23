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
using Cyprom.PokemonMasterTrainer.UserInterface.Properties;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class Deck : Form
    {
        private static readonly Dictionary<Board, Deck> instances = new Dictionary<Board, Deck>();

        private readonly Board parent;
        private readonly SoundPlayer soundPlayer;
        private readonly BackgroundWorker aiThread;

        private DeckType activeDeck;
        private int cardsToDraw;
        private Player player;

        public List<Card> ItemCards { get; set; }
        public List<Card> EventCards { get; set; }

        public List<Card> Drawn { get; set; }

        public static Deck Instance(Board board, List<Card> itemCards, List<Card> eventCards)
        {
            if (!instances.Keys.Contains(board))
            {
                instances.Add(board, new Deck(board, itemCards, eventCards));
            }
            return instances[board];
        }

        private Deck(Board parent, List<Card> itemCards, List<Card> eventCards)
        {
            InitializeComponent();
            this.parent = parent;
            soundPlayer = SoundPlayer.Instance();
            aiThread = new BackgroundWorker();
            aiThread.DoWork += Sleep;
            aiThread.RunWorkerCompleted += BotClick;
            ItemCards = itemCards;
            EventCards = eventCards;
            DeckPicture.MouseEnter += EnterSoundEvent;
            DeckPicture.Enabled = false;
            DoneButton.MouseEnter += EnterSoundEvent;
            DoneButton.Click += ClickSoundEvent;
            DoneButton.Enabled = false;
            cardsToDraw = 0;
            AmountLabel.Text = "0";
            activeDeck = DeckType.Item;
            Drawn = new List<Card>();
        }

        public void ShowDeck(DeckType type, int cardsToDraw, Player player)
        {
            this.cardsToDraw = cardsToDraw;
            this.player = player;
            AmountLabel.Text = cardsToDraw.ToString();
            activeDeck = type;
            switch (type)
            {
                case DeckType.Item: LoadItemDeck();
                    break;
                case DeckType.Event: LoadEventDeck();
                    break;
            }
            Visible = true;
            if (player.IsBot)
            {
                aiThread.RunWorkerAsync();
            }
            else
            {
                DeckPicture.Enabled = true;
            }
        }

        private void LoadItemDeck()
        {
            BackColor = Color.Firebrick;
            DeckPicture.Image = Resources.Item;
        }

        private void LoadEventDeck()
        {
            BackColor = Color.ForestGreen;
            DeckPicture.Image = Resources.Event;
        }

        private void DeckPicture_Click(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Draw", false), false);
            cardsToDraw--;
            AmountLabel.Text = cardsToDraw.ToString();
            switch (activeDeck)
            {
                case (DeckType.Item): DrawCard(ItemCards);
                    break;
                case (DeckType.Event): DrawCard(EventCards);
                    break;
            }
            if (player.IsBot)
            {
                aiThread.RunWorkerAsync();
            }
            else
            {
                if (cardsToDraw <= 0)
                {
                    DeckPicture.Enabled = false;
                    DoneButton.Enabled = true;
                }
            }
        }

        private void DrawCard(IList<Card> cards)
        {
            var card = cards[0];
            cards.RemoveAt(0);
            Drawn.Add(card);
            PickedCardPicture.Image = card.Picture;
            MessageHelper.ShowMessage(string.Format("You drew \"{0}\".", card.Title), TechnicalConstants.DRAW, player.IsBot);
        }

        private void DoneButton_Click(object sender, EventArgs eventArgs)
        {
            DoneButton.Enabled = false;
            Visible = false;
            PickedCardPicture.Image = null;
            var playerOnBoard = player;
            player = null;
            parent.CardsDrawn(playerOnBoard, activeDeck);
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Hover", false), false);
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
        }

        private void Deck_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            eventArgs.Cancel = true;
            MessageHelper.ShowMessage("Draw a card from the deck.", TechnicalConstants.DRAW, player.IsBot);
        }

        private static void Sleep(object sender, DoWorkEventArgs eventArgs)
        {
            ArtificialIntelligence.Sleep();
        }

        private void BotClick(object sender, RunWorkerCompletedEventArgs eventArgs)
        {
            if (cardsToDraw > 0)
            {
                DeckPicture_Click(DeckPicture, null);
            }
            else
            {
                DoneButton_Click(DoneButton, null);
            }
        }

        public static void Destroy(Board board)
        {
            if (instances.Keys.Contains(board))
            {
                var toDestroy = instances[board];
                instances.Remove(board);
                toDestroy.Dispose();
            }
        }
    }
}
