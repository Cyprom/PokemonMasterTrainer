using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;
using Cyprom.PokemonMasterTrainer.UserInterface.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.UserInterface.Helpers;

namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    public partial class Board : Form
    {
        #region Variables

        private readonly Home parent;
        private readonly GameManager gameManager;
        private readonly ConfigurationManager configurationManager;
        private readonly MusicPlayer musicPlayer;
        private readonly SoundPlayer soundPlayer;
        private readonly DiceRoller diceRoller;
        private readonly BackgroundWorker aiThread;
        private Point dragLocation;

        private BoardState state;

        public List<Form> PopUps { get; set; }

        #endregion

        #region Properties

        public Point MaximumScrollPosition
        {
            get
            {
                return new Point(
                    BoardPanel.HorizontalScroll.Maximum - BoardPanel.HorizontalScroll.LargeChange + 1,
                    BoardPanel.VerticalScroll.Maximum - BoardPanel.VerticalScroll.LargeChange + 1);
            }
        }

        #endregion

        #region Constructor and Default Loading

        public Board(Home parent)
        {
            InitializeComponent();
            PopUps = new List<Form>();
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            DiceCup.Enabled = false;
            this.parent = parent;
            gameManager = GameManager.Instance();
            configurationManager = ConfigurationManager.Instance();
            musicPlayer = MusicPlayer.Instance();
            soundPlayer = SoundPlayer.Instance();
            diceRoller = DiceRoller.Instance();
            aiThread = new BackgroundWorker();
            SetSize(configurationManager.WindowSize);
            AddSoundEvents();
        }

        private void Board_Load(object sender, EventArgs eventArgs)
        {
            LoadBackground();
            musicPlayer.ContinuousPlay = true;
            if (configurationManager.Music)
            {
                musicPlayer.Play();
            }
            if (!configurationManager.Log)
            {
                LogBox.Visible = false;
            }
            LoadQuickOptions();
            dragLocation = Point.Empty;
            BoardPanel.VerticalScroll.Value = MaximumScrollPosition.Y;
            aiThread.DoWork += Sleep;
            aiThread.RunWorkerCompleted += BotClick;
        }

        private void LoadQuickOptions()
        {
            MusicQuick.Image = configurationManager.Music ? Properties.Resources.Music_On : Properties.Resources.Music_Off;
            SoundQuick.Image = configurationManager.Sound ? Properties.Resources.Sound_On : Properties.Resources.Sound_Off;
            ScreenLockQuick.Image = configurationManager.ScreenLock ? Properties.Resources.ScreenLock_On : Properties.Resources.ScreenLock_Off;
        }

        private void LoadBackground()
        {
            var backgroundInfo = LoadFacade.LoadBackground(configurationManager.BoardBackground);
            BoardPicture.Image = backgroundInfo.Item1;
            InfoPanel.BackColor = backgroundInfo.Item2;
            QuitButton.BackColor = backgroundInfo.Item2;
        }

        private void SetSize(WindowSize windowSize)
        {
            switch (windowSize)
            {
                case WindowSize.Tiny: SetSize(800, 450);
                    break;
                case WindowSize.Small: SetSize(960, 600);
                    break;
                case WindowSize.Large: SetSize(1600, 900);
                    break;
                case WindowSize.Huge: SetSize(1920, 1200);
                    break;
                case WindowSize.FullScreen:
                    FormBorderStyle = FormBorderStyle.None;
                    SetSize(Screen.FromControl(this).WorkingArea.Width + TechnicalConstants.HORIZONTAL_WINDOW_OFFSET, Screen.FromControl(this).WorkingArea.Height + TechnicalConstants.VERTICAL_WINDOW_OFFSET);
                    Location = new Point(0, 0);
                    break;
                default: SetSize(1280, 720);
                    break;
            }
        }

        private void SetSize(int width, int height)
        {
            var boardSize = new Size(width, height);
            Size = boardSize;
            MaximumSize = boardSize;
            MinimumSize = boardSize;
            var panelHeight = height - TechnicalConstants.VERTICAL_WINDOW_OFFSET;
            BoardPanel.Size = new Size(width - TechnicalConstants.STATUS_PANEL_WIDTH - TechnicalConstants.HORIZONTAL_WINDOW_OFFSET, panelHeight);
            InfoPanel.Size = new Size(TechnicalConstants.STATUS_PANEL_WIDTH, panelHeight);
            if (height > 450)
            {
                LogBox.Height = height - 420;
                LogView.Height = LogBox.Height - 35;
            }
            else
            {
                LogBox.Visible = false;
            }
        }

        public void StartGame(List<Player> players = null)
        {
            var newGame = players != null;
            state = newGame ? gameManager.NewGame() : gameManager.LoadGame();
            ActivateChips();
            ActivateSpaces();
            ActivateElites(newGame);
            PopulateCatchSpaces(newGame);

            if (newGame)
            {
                state.Players = players;
                ScatterLegendaries();
                DetermineOrderOfPlay();
            }
            else
            {
                if (state.Players.All(player => player.Space != null))
                {
                    ActivatePlayers();
                }
                if (!string.IsNullOrEmpty(state.OnLoadMessage))
                {
                    MessageHelper.ShowMessage(state.OnLoadMessage, TechnicalConstants.GAME_LOADED, false);
                }
                if (!string.IsNullOrEmpty(state.OnLoadMethod))
                {
                    var type = GetType();
                    var method = type.GetMethod(state.OnLoadMethod);
                    method.Invoke(this, state.OnLoadMethodParameters.ToArray());
                }
            }
        }

        #endregion

        #region Activate controls

        private void ActivatePlayers()
        {
            foreach (var player in state.Players)
            {
                BoardPicture.Controls.Add(player.Trainer);
            }
        }

        private void ActivateChips()
        {
            AddCatchEvent(state.PinkChips);
            AddCatchEvent(state.GreenChips);
            AddCatchEvent(state.BlueChips);
            AddCatchEvent(state.RedChips);
            AddCatchEvent(state.YellowChips);
            foreach (var chip in state.YellowChips)
            {
                BoardPicture.Controls.Add(chip);
            }
        }

        private void ActivateSpaces()
        {
            foreach (var space in state.Spaces)
            {
                space.Click += MovePlayer;
                switch (space.SpaceType)
                {
                    case (SpaceType.Catch): space.Click += Catch;
                        break;
                    case (SpaceType.Item1): space.Click += TakeOneItem;
                        break;
                    case (SpaceType.Item2): space.Click += TakeTwoItems;
                        break;
                    case (SpaceType.Item3): space.Click += TakeThreeItems;
                        break;
                    case (SpaceType.Event): space.Click += TakeEvent;
                        break;
                    case (SpaceType.Revive): space.Click += Revive;
                        break;
                    case (SpaceType.PowerPoint): space.Click += CinnabarIslandArrival;
                        break;
                    case (SpaceType.Return): space.Click += BackToCinnabarIsland;
                        break;
                    case (SpaceType.FinalBattle): space.Click += FinalBattle;
                        break;
                    default: space.Click += NothingHappens;
                        break;
                }
            }
            BoardPicture.Controls.AddRange(state.Spaces.ToArray());
        }

        private void ActivateElites(bool newGame)
        {
            var eliteLocation = LoadFacade.LoadEliteLocation();
            foreach (var trainer in state.EliteTrainers)
            {
                trainer.Click += StartFinalBattle;
                trainer.Location = eliteLocation;
            }
            if (newGame)
            {
                ReplaceElite();
            }
            else
            {
                BoardPicture.Controls.Add(state.EliteTrainers[0]);
                if (state.EliteTrainer != null)
                {
                    state.EliteTrainers[0].Flipped = true;
                }
            }
        }

        private void PopulateCatchSpaces(bool newGame)
        {
            var catchSpaces = state.Spaces.OfType<CatchSpace>().ToList();
            if (newGame)
            {
                foreach (var space in catchSpaces)
                {
                    ReplaceCatchSpaceChip(space);
                }
            }
            else
            {
                foreach (var space in catchSpaces.Where(space => space.AdjacentChip != null))
                {
                    BoardPicture.Controls.Add(space.AdjacentChip);
                }
                AddCatchEvent(catchSpaces.Where(space => space.AdjacentChip != null).Select(space => space.AdjacentChip));
            }
        }

        private Chip TakeFirst(IList<Chip> chips)
        {
            if (chips.Count > 0)
            {
                var first = chips[0];
                chips.RemoveAt(0);
                BoardPicture.Controls.Add(first);
                return first;
            }
            else
            {
                return null;
            }
        }

        private void ScatterLegendaries()
        {
            var legendaryLocations = LoadFacade.LoadLegendaryLocations();
            for (var i = 0; i < state.YellowChips.Count; i++)
            {
                var chip = state.YellowChips[i];
                chip.Location = legendaryLocations[i];
                chip.Refresh();
            }
        }

        #endregion

        #region Start of New Game

        private void DetermineOrderOfPlay()
        {
            state.OrderOfPlay = new List<Tuple<Player, int>>();
            MessageHelper.ShowMessage(string.Format("{0}, roll the die to determine the order of play.", state.Players[0].Name), TechnicalConstants.ORDER_OF_PLAY, state.Players[0].IsBot);
            diceRoller.Bot = state.Players[0].IsBot;
            diceRoller.ReturnFunction = FirstPlayerRolled;
            diceRoller.Show();
        }

        private void FirstPlayerRolled(int result)
        {
            Log("{0} rolled {1}", state.Players[0].Name, result);
            state.OrderOfPlay.Add(new Tuple<Player, int>(state.Players[0], result));
            MessageHelper.ShowMessage(string.Format("{0}, roll the die to determine the order of play.", state.Players[1].Name), TechnicalConstants.ORDER_OF_PLAY, state.Players[1].IsBot);
            diceRoller.Bot = state.Players[1].IsBot;
            diceRoller.ReturnFunction = SecondPlayerRolled;
            diceRoller.Show();
        }

        private void SecondPlayerRolled(int result)
        {
            Log("{0} rolled {1}", state.Players[1].Name, result);
            state.OrderOfPlay.Add(new Tuple<Player, int>(state.Players[1], result));
            if (state.Players.Count > 2)
            {
                if (state.OrderOfPlay.GroupBy(tuple => tuple.Item2).Count() < state.OrderOfPlay.Count())
                {
                    Log("Rolling again");
                    MessageHelper.ShowMessage("Players rolled the same amount, roll again...", TechnicalConstants.ORDER_OF_PLAY, state.Players[0].IsBot && state.Players[1].IsBot);
                    DetermineOrderOfPlay();
                }
                else
                {
                    MessageHelper.ShowMessage(string.Format("{0}, roll the die to determine the order of play.", state.Players[2].Name), TechnicalConstants.ORDER_OF_PLAY, state.Players[2].IsBot);
                    diceRoller.Bot = state.Players[2].IsBot;
                    diceRoller.IgnoredRolls.Add(state.OrderOfPlay[0].Item2);
                    diceRoller.IgnoredRolls.Add(state.OrderOfPlay[1].Item2);
                    diceRoller.ReturnFunction = ThirdPlayerRolled;
                    diceRoller.Show();
                }
            }
            else
            {
                CheckOrderOfPlay();
            }
        }

        private void ThirdPlayerRolled(int result)
        {
            Log("{0} rolled {1}", state.Players[2].Name, result);
            state.OrderOfPlay.Add(new Tuple<Player, int>(state.Players[2], result));
            CheckOrderOfPlay();
        }

        private void CheckOrderOfPlay()
        {
            if (state.OrderOfPlay.GroupBy(tuple => tuple.Item2).Count() < state.OrderOfPlay.Count())
            {
                Log("Rolling again");
                MessageHelper.ShowMessage("Players rolled the same amount, roll again...", TechnicalConstants.ORDER_OF_PLAY, false);
                DetermineOrderOfPlay();
            }
            else
            {
                state.Players = state.OrderOfPlay.OrderByDescending(tuple => tuple.Item2).Select(tuple => tuple.Item1).ToList();
                Log("Order of play determined");
                SelectFirstStarter();
            }
        }

        private void SelectFirstStarter()
        {
            var starterSelection = new StarterSelection { ReturnFunction = FirstStarterSelected, Bot = state.Players[0].IsBot };
            PopUps.Add(starterSelection);
            starterSelection.Show();
            MessageHelper.ShowMessage(string.Format("{0}, it is your turn to pick a starter Pokémon.", state.Players[0].Name), TechnicalConstants.STARTER_SELECTION, state.Players[0].IsBot);
            starterSelection.Reactivate();
        }

        private void FirstStarterSelected(Chip starter, StarterSelection origin)
        {
            state.Players[0].Pokemon.Add(starter);
            Log("{0} got {1} as starter Pokémon", state.Players[0].Name, starter.Pokemon);
            origin.ReturnFunction = SecondStarterSelected;
            origin.Bot = state.Players[1].IsBot;
            MessageHelper.ShowMessage(string.Format("{0}, it is your turn to pick a starter Pokémon.", state.Players[1].Name), TechnicalConstants.STARTER_SELECTION, state.Players[1].IsBot);
            origin.Reactivate();
        }

        private void SecondStarterSelected(Chip starter, StarterSelection origin)
        {
            state.Players[1].Pokemon.Add(starter);
            Log("{0} got {1} as starter Pokémon", state.Players[1].Name, starter.Pokemon);
            if (state.Players.Count > 2)
            {
                origin.ReturnFunction = ThirdStarterSelected;
                origin.Bot = state.Players[2].IsBot;
                MessageHelper.ShowMessage(string.Format("{0}, it is your turn to pick a starter Pokémon.", state.Players[2].Name), TechnicalConstants.STARTER_SELECTION, state.Players[2].IsBot);
                origin.Reactivate();
            }
            else
            {
                PopUps.Remove(origin);
                origin.Dispose();
                StarterSelectionCompleted();
            }
        }

        private void ThirdStarterSelected(Chip starter, StarterSelection origin)
        {
            state.Players[2].Pokemon.Add(starter);
            Log("{0} got {1} as starter Pokémon", state.Players[2].Name, starter.Pokemon);
            PopUps.Remove(origin);
            origin.Dispose();
            StarterSelectionCompleted();
        }

        private void StarterSelectionCompleted()
        {
            foreach (var player in state.Players)
            {
                player.Space = state.PalletTown;
            }
            ActivatePlayers();
            state.ActivePlayerIndex = 0;
            state.GameStarted = true;
            StartNewTurn();
        }

        #endregion

        #region Gameplay

        public void StartNewTurn()
        {
            state.OnLoadMethod = "StartNewTurn";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to start a new turn.", state.ActivePlayer.Name);
            var player = state.ActivePlayer;
            Log("{0} started a new turn", player.Name);
            ScrollBoard(player.Trainer);
            Activate();
            UpdateStatusBox();
            soundPlayer.Play(LoadFacade.BuildUri("NewTurn", false), false);
            MessageHelper.ShowMessage(string.Format("{0}, it's your turn to play.", player.Name), TechnicalConstants.NEW_TURN, player.IsBot);
            if (player.UnderInvestigation)
            {
                Log("{0} skipped a turn", player.Name);
                MessageHelper.ShowMessage("Unfortunately, you are still being interrogated by Officer Jenny. You must skip this turn.", TechnicalConstants.INVESTIGATION, player.IsBot);
                player.UnderInvestigation = false;
                EndTurn();
            }
            else if (player.OnCinnabarIsland)
            {
                player.OnCinnabarIsland = false;
                if (player.PowerPoints >= TechnicalConstants.POWER_POINT_REQUIREMENT)
                {
                    var result = MessageHelper.ShowMessage("You have enough Power Points to travel to Indigo Plateau. Do you want to go there now?", TechnicalConstants.INDIGO_PLATEAU, player.IsBot, MessageBoxButtons.YesNo);
                    if (player.IsBot)
                    {
                        result = ArtificialIntelligence.GoToIndigoPlateau(player) ? DialogResult.Yes : DialogResult.No;
                    }
                    if (result == DialogResult.Yes)
                    {
                        player.Space = state.IndigoArrival;
                        Log("{0} arrived on Indigo Plateau", player.Name);
                        soundPlayer.Play(LoadFacade.BuildUri("Ferry", false), false);
                        MessageHelper.ShowMessage("Congratulations! You have arrived on Indigo Plateau!", TechnicalConstants.INDIGO_PLATEAU, player.IsBot);
                    }
                    PlayTurn();
                }
                else
                {
                    MessageHelper.ShowMessage("You do not have enough Power Points to travel to Indigo Plateau. You will have to turn around.", TechnicalConstants.INDIGO_PLATEAU, player.IsBot);
                    PlayTurn();
                }
            }
            else
            {
                PlayTurn();
            }
        }

        public void PlayTurn()
        {
            if (state.ActivePlayer.IsBot)
            {
                if (ArtificialIntelligence.UsePotion(state.ActivePlayer))
                {
                    ItemBag_Click(ItemBag, new BotEventArgs {Argument = CardType.Potion});
                }
                else
                {
                    BotMoveOrFly();
                }
            }
            else
            {
                Pokedex.Enabled = true;
                ItemBag.Enabled = true;
                DiceCup.Enabled = true;
            }
        }

        private void BotMoveOrFly()
        {
            if (ArtificialIntelligence.UseFly(state.ActivePlayer))
            {
                ItemBag_Click(ItemBag, new BotEventArgs { Argument = CardType.Fly });
            }
            else
            {
                DiceCup_Click(DiceCup, null);
            }
        }

        public void EndTurn()
        {
            state.OnLoadMethod = "EndTurn";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to end a turn.", state.ActivePlayer.Name);
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            var player = state.ActivePlayer;
            if (player.Items.Count > 7)
            {
                MessageHelper.ShowMessage("You are carrying too many items. The bag is overloaded. Please discard some...", TechnicalConstants.DISCARD, player.IsBot);
                var bag = new Bag(this, player, DiscardCanceled);
                PopUps.Add(bag);
                bag.Show();
                if (player.IsBot)
                {
                    bag.HandleBotChoice(ArtificialIntelligence.SelectDiscard(player));
                }
            }
            else
            {
                Log("{0} ended a turn", player.Name);
                if (configurationManager.AutoSave)
                {
                    gameManager.SaveGame(state);
                }
                state.ActivateNextPlayer();
                StartNewTurn();
            }
        }

        private void DiscardCanceled(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            MessageHelper.ShowMessage("You must select an item now.", TechnicalConstants.DISCARD, state.ActivePlayer.IsBot);
            bag = new Bag(this, state.ActivePlayer, DiscardCanceled);
            PopUps.Add(bag);
            bag.Show();
        }

        public void Discarded(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            Log("{0} discarded items", state.ActivePlayer.Name);
            EndTurn();
        }

        private void UpdateStatusBox()
        {
            CurrentPlayerLabel.Text = state.ActivePlayer.Name;
            CurrentPlayerPicture.BackgroundImage = state.ActivePlayer.Trainer.Face;
        }

        public void DrawCards(DeckType type, int amount, Player player)
        {
            state.OnLoadMethod = "DrawCards";
            state.OnLoadMethodParameters = new List<object> { type, amount, player };
            state.OnLoadMessage = string.Format("{0} was about to draw {1} cards.", player.Name, type);
            var deck = Deck.Instance(this, state.ItemCards, state.EventCards);
            PopUps.Add(deck);
            deck.ShowDeck(type, amount, player);
        }

        public void CardsDrawn(Player player, DeckType type)
        {
            var end = false;
            var deck = Deck.Instance(this, state.ItemCards, state.EventCards);
            Log("{0} drew {1} {2} card{3}", player.Name, deck.Drawn.Count, type, deck.Drawn.Count > 1 ? "s" : string.Empty);
            switch (type)
            {
                case DeckType.Item:
                    foreach (var card in deck.Drawn)
                    {
                        player.Items.Add(card);
                    }
                    deck.Drawn.Clear();
                    end = true;
                    break;
                case DeckType.Event:
                    var eventCard = deck.Drawn.First();
                    PutCardBackInDeck(eventCard);
                    deck.Drawn.Clear();
                    StartEvent(eventCard.CardType); 
                    break;
            }
            if (end)
            {
                EndTurn();
            }
        }

        public void PutCardBackInDeck(Card card)
        {
            var deck = Deck.Instance(this, state.ItemCards, state.EventCards);
            switch (card.DeckType)
            {
                case DeckType.Item: deck.ItemCards.Add(card);
                    break;
                case DeckType.Event: deck.EventCards.Add(card);
                    break;
            }
        }

        #endregion

        #region Moving

        public void PlayerMovement(int result)
        {
            state.OnLoadMethod = "PlayerMovement";
            state.OnLoadMethodParameters = new List<object>{ result };
            state.OnLoadMessage = string.Format("{0} was about to move.", state.ActivePlayer.Name);
            Log("{0} rolled {1}", state.ActivePlayer.Name, result);
            var player = state.ActivePlayer;
            var availableSpaces = player.Space.CalculateAvailableSpaces(result);
            if (player.IsBot)
            {
                state.BotChoice = ArtificialIntelligence.Move(player, availableSpaces);
                aiThread.RunWorkerAsync();
            }
            else
            {
                foreach (var space in availableSpaces)
                {
                    space.Visible = true;
                }
            }
        }

        private void MovePlayer(object sender, EventArgs eventArgs)
        {
            foreach (var space in state.Spaces)
            {
                space.Visible = false;
            }
            ScrollBoard((Control)sender);
            var player = state.ActivePlayer;
            player.Space = (Space)sender;
            if (player.Flying)
            {
                var cityTown = (CityTown)player.Space;
                player.Flying = false;
                Log("{0} flew to {1}", state.ActivePlayer.Name, cityTown.CityName);
                soundPlayer.Play(LoadFacade.BuildUri("Fly", false), false);
                MessageHelper.ShowMessage(string.Format("You flew to {0}.", cityTown.CityName), TechnicalConstants.FLY, player.IsBot);
            }
            else
            {
                soundPlayer.Play(LoadFacade.BuildUri("Move", false), false);
                Log("{0} moved", state.ActivePlayer.Name);
            }
        }

        private void TakeOneItem(object sender, EventArgs eventArgs)
        {
            DrawCards(DeckType.Item, 1, state.ActivePlayer);
        }

        private void TakeTwoItems(object sender, EventArgs eventArgs)
        {
            DrawCards(DeckType.Item, 2, state.ActivePlayer);
        }

        private void TakeThreeItems(object sender, EventArgs eventArgs)
        {
            DrawCards(DeckType.Item, 3, state.ActivePlayer);
        }

        private void TakeEvent(object sender, EventArgs eventArgs)
        {
            DrawCards(DeckType.Event, 1, state.ActivePlayer);
        }

        private void Revive(object sender, EventArgs eventArgs)
        {
            Revival();
        }

        private void CinnabarIslandArrival(object sender, EventArgs eventArgs)
        {
            var player = state.ActivePlayer;
            player.OnCinnabarIsland = true;
            EndTurn();
        }

        private void BackToCinnabarIsland(object sender, EventArgs eventArgs)
        {
            var player = state.ActivePlayer;
            player.Space = state.CinnabarIsland;
            Log("{0} returned to Cinnabar Island", player.Name);
            player.OnCinnabarIsland = true;
            soundPlayer.Play(LoadFacade.BuildUri("Ferry", false), false);
            MessageHelper.ShowMessage("You have returned to Cinnabar Island.", TechnicalConstants.INDIGO_PLATEAU, player.IsBot);
            EndTurn();
        }

        private void NothingHappens(object sender, EventArgs eventArgs)
        {
            EndTurn();
        }

        #endregion

        #region Catching

        private void AddCatchEvent(IEnumerable<Chip> chips)
        {
            foreach (var chip in chips)
            {
                chip.Click += CatchPokemon;
            }
        }

        private void Catch(object sender, EventArgs eventArgs)
        {
            state.OnLoadMethod = string.Empty;
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to catch a Pokémon.", state.ActivePlayer.Name);
            var catchSpace = sender as CatchSpace;
            if (catchSpace != null)
            {
                if (state.ActivePlayer.IsBot)
                {
                    catchSpace.AdjacentChip.Clickable = false;
                    state.BotChoice = catchSpace.AdjacentChip;
                    aiThread.RunWorkerAsync();
                }
                else
                {
                    catchSpace.AdjacentChip.Clickable = true;
                }
            }
            else
            {
                var indigoSpace = (Space)sender;
                CatchFromIndigoPlateau(indigoSpace.Color);
            }
        }

        private void CatchFromIndigoPlateau(Rarity color)
        {
            state.OnLoadMessage = string.Format("{0} was about to catch a {1} Pokémon.", state.ActivePlayer.Name, color);
            Log("{0} may catch any {1} Pokémon", state.ActivePlayer.Name, color);
            MessageHelper.ShowMessage(string.Format("Catch any {0} Pokémon on the field.", color), TechnicalConstants.CATCH, state.ActivePlayer.IsBot);
            var possibilities = state.Spaces.Where(space => space.Color == color).OfType<CatchSpace>().Where(catchSpace => catchSpace.AdjacentChip != null).ToList();
            if (possibilities.Any())
            {
                if (state.ActivePlayer.IsBot)
                {
                    state.BotChoice = ArtificialIntelligence.Catch(state.ActivePlayer, possibilities.Select(space => space.AdjacentChip).ToList(), color);
                    aiThread.RunWorkerAsync();
                }
                else
                {
                    foreach (var possibility in possibilities)
                    {
                        possibility.AdjacentChip.Clickable = true;
                    }
                }
            }
            else
            {
                Log("Nothing left to catch");
                MessageHelper.ShowMessage("It seems there are no {0} Pokémon left. Too bad...", TechnicalConstants.CATCH, state.ActivePlayer.IsBot);
                EndTurn();
            }
        }

        public void CatchPokemon(object sender, EventArgs eventArgs)
        {
            state.OnLoadMethod = "CatchPokemon";
            state.OnLoadMethodParameters = new List<object> { sender, null };
            state.OnLoadMessage = string.Format("{0} was about to try and catch {1}.", state.ActivePlayer.Name, ((Chip)sender).Pokemon);
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            DisableChips();
            var chip = (Chip)sender;
            if (!chip.Flipped)
            {
                chip.Flipped = true;
                soundPlayer.Play(LoadFacade.BuildUri("Flip", false), false);
            }
            chip.Refresh();
            if (state.TeamRocket)
            {
                state.TeamRocket = false;
                NewCompanion(chip);
            }
            else
            {
                state.InCatchProcess = chip;
                var player = state.ActivePlayer;
                MessageHelper.ShowMessage(string.Format("You are trying to catch {0}, roll the dice to throw a Poké Ball. Good luck!", state.InCatchProcess.Pokemon), TechnicalConstants.CATCH, player.IsBot);
                if (state.InCatchProcess.Pokemon != TechnicalConstants.MEW && player.HasSpecialBalls)
                {
                    var result = MessageHelper.ShowMessage("Do you want to use a special Poké Ball?", TechnicalConstants.POKEBALL, player.IsBot, MessageBoxButtons.YesNo);
                    if (player.IsBot)
                    {
                        result = ArtificialIntelligence.UseSpecialBall(player, chip) ? DialogResult.Yes : DialogResult.No;
                    }
                    if (result == DialogResult.Yes)
                    {
                        var bag = new Bag(this, player, PokeBallUsageCanceled, CardType.GreatBall, CardType.UltraBall, CardType.MasterBall);
                        PopUps.Add(bag);
                        bag.Show();
                        if (player.IsBot)
                        {
                            bag.HandleBotChoice(ArtificialIntelligence.SelectSpecialBall(player, chip));
                        }
                    }
                    else
                    {
                        RollForCatch();
                    }
                }
                else
                {
                    RollForCatch();
                }
            }
        }

        private void PokeBallUsageCanceled(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            RollForCatch();
        }

        private void DisableChips()
        {
            foreach (var catchSpace in state.Spaces.OfType<CatchSpace>())
            {
                catchSpace.AdjacentChip.Clickable = false;
            }
            foreach (var chip in state.YellowChips)
            {
                chip.Clickable = false;
            }
        }

        public void CatchWithBall(Bag bag, Card ball)
        {
            bag.Close();
            PopUps.Remove(bag);
            Log("{0} used a {1}", state.ActivePlayer.Name,
                ball.CardType == CardType.GreatBall ? "Great Ball" : ball.CardType == CardType.UltraBall ? "Ultra Ball" : "Master Ball");
            state.BallToCatchWith = ball;
            RollForCatch();
        }

        private void RollForCatch()
        {
            diceRoller.ReturnFunction = PokemonCaught;
            diceRoller.Bot = state.ActivePlayer.IsBot;
            diceRoller.Show();
        }
        
        private void PokemonCaught(int result)
        {
            var player = state.ActivePlayer;
            Log("{0} rolled {1}", player.Name, result);
            if (IsCaught(state.InCatchProcess, result, state.BallToCatchWith))
            {
                Log("{0} caught {1}", player.Name, state.InCatchProcess.Pokemon);
                soundPlayer.Play(LoadFacade.BuildUri("Catch", false), false);
                MessageHelper.ShowMessage(string.Format("Congratulations, you successfully caught {0}!", state.InCatchProcess.Pokemon), TechnicalConstants.CATCH, player.IsBot);
                state.InCatchProcess.Click -= CatchPokemon;
                BoardPicture.Controls.Remove(state.InCatchProcess);
                player.Pokemon.Add(state.InCatchProcess);
                if (state.InCatchProcess.Rarity != Rarity.Yellow)
                {
                    ReplaceCatchSpaceChip(state.InCatchProcess.AdjacentSpace);
                }
                else
                {
                    state.YellowChips.Remove(state.InCatchProcess);
                }
            }
            else
            {
                Log("{0} failed to catch {1}", player.Name, state.InCatchProcess.Pokemon);
                soundPlayer.Play(LoadFacade.BuildUri("Failure", false), false);
                MessageHelper.ShowMessage("Darn, it got away... Better luck next time.", TechnicalConstants.CATCH, player.IsBot);
            }
            state.InCatchProcess = null;
            state.BallToCatchWith = null;
            EndTurn();
        }

        private static bool IsCaught(Chip pokemon, int roll, Card ball)
        {
            if (ball != null)
            {
                switch (ball.CardType)
                {
                    case CardType.MasterBall:
                        return true;
                    case CardType.UltraBall:
                        return pokemon.CatchRate.Contains(roll) || pokemon.CatchRate.Contains(roll + 1) || pokemon.CatchRate.Contains(roll - 1);
                    case CardType.GreatBall:
                        return pokemon.CatchRate.Contains(roll) || pokemon.CatchRate.Contains(roll + 1);
                }
            }
            return pokemon.CatchRate.Contains(roll);
        }

        private void ReplaceCatchSpaceChip(CatchSpace space)
        {
            switch (space.Color)
            {
                case Rarity.Pink: space.AdjacentChip = TakeFirst(state.PinkChips);
                    break;
                case Rarity.Green: space.AdjacentChip = TakeFirst(state.GreenChips);
                    break;
                case Rarity.Blue: space.AdjacentChip = TakeFirst(state.BlueChips);
                    break;
                case Rarity.Red: space.AdjacentChip = TakeFirst(state.RedChips);
                    break;
            }
        }

        #endregion

        #region Item Cards

        public void Fly(Bag bag)
        {
            state.OnLoadMethod = string.Empty;
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to fly somewhere.", state.ActivePlayer.Name);
            if (bag != null)
            {
                bag.Close();
                PopUps.Remove(bag);
            }
            var player = state.ActivePlayer;
            player.Flying = true;
            foreach (var space in player.VisitedPlaces)
            {
                space.Visible = true;
            }
            DiceCup.Enabled = false;
            MessageHelper.ShowMessage("Choose the City or Town where you want to fly to. Only places you have already visited are available.", TechnicalConstants.FLY, player.IsBot);
            if (player.IsBot)
            {
                state.BotChoice = ArtificialIntelligence.FlyTo(state.ActivePlayer);
                aiThread.RunWorkerAsync();
            }
        }

        public void UsePotion(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            Log("{0} used a Potion", state.ActivePlayer.Name);
            ReviveSingle(true);
        }

        #endregion

        #region Event Cards

        private void StartEvent(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.ItemFinder1: ItemFinder(1);
                    break;
                case CardType.ItemFinder2: ItemFinder(2);
                    break;
                case CardType.ItemFinder3: ItemFinder(3);
                    break;
                case CardType.Challenge: Challenge();
                    break;
                case CardType.Trade: Trade();
                    break;
                case CardType.Investigation: Investigation();
                    break;
                case CardType.TeamRocket: TeamRocket();
                    break;
                case CardType.PokemonCenter: Revival();
                    break;
                case CardType.DungeonOfLegends: DungeonOfLegends();
                    break;
            }
        }

        private void ItemFinder(int amount)
        {
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            soundPlayer.Play(LoadFacade.BuildUri("ItemFound", false), false);
            MessageHelper.ShowMessage(string.Format("The Item Finder is responding. You found {0} items.", amount), TechnicalConstants.DRAW, state.ActivePlayer.IsBot);
            DrawCards(DeckType.Item, amount, state.ActivePlayer);
        }

        public void Challenge()
        {
            state.OnLoadMethod = "Challenge";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to challenge someone.", state.ActivePlayer.Name);
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            Log("Challenge started");
            if (state.Players.Count > 2)
            {
                if (!state.ActivePlayer.CanBattle || state.Players.Count(player => player.CanBattle) < 2)
                {
                    Log("Challenge ended: no possible battles");
                    MessageHelper.ShowMessage("There are players without Pokémon able to fight, there will be no battle.", TechnicalConstants.BATTLE, state.ActivePlayer.IsBot);
                }
                else
                {
                    soundPlayer.Play(LoadFacade.BuildUri("Challenge", false), false);
                    var targetSelection = new TargetSelection(state.Players, state.ActivePlayerIndex, true)
                    {
                        ReturnFunction = ChallengeStarted
                    };
                    PopUps.Add(targetSelection);
                    targetSelection.Show();
                    if (state.ActivePlayer.IsBot)
                    {
                        targetSelection.HandleBotChoice(ArtificialIntelligence.SelectTarget(state.ActivePlayer, state.Players.Where(player => player != state.ActivePlayer).ToList(), true));
                    }
                }
            }
            else
            {
                var active = state.ActivePlayer;
                var other = state.Players[Math.Abs(state.ActivePlayerIndex - 1)];
                if (!active.CanBattle || !other.CanBattle)
                {
                    Log("Challenge ended: no possible battles");
                    MessageHelper.ShowMessage("There are players without Pokémon able to fight, there will be no battle.", TechnicalConstants.BATTLE, active.IsBot);
                    EndTurn();
                }
                else
                {
                    soundPlayer.Play(LoadFacade.BuildUri("Challenge", false), false);
                    ChallengeStarted(active, other);
                }
            }
        }

        public void Trade()
        {
            state.OnLoadMethod = "TradeStarted";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to trade with someone.", state.ActivePlayer.Name);
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            Log("Trade initiated");
            var active = state.ActivePlayer;
            if (state.Players.Where(player => player != active).All(player => !player.CanTrade(active).Any()))
            {
                Log("Trade ended: no possible trades");
                MessageHelper.ShowMessage("There are no possible trades... This trade will be canceled.", TechnicalConstants.TRADE, active.IsBot);
                EndTurn();
            }
            else
            {
                soundPlayer.Play(LoadFacade.BuildUri("Coin", false), false);
                if (state.Players.Count > 2)
                {
                    var targetSelection = new TargetSelection(state.Players, state.ActivePlayerIndex, false)
                    {
                        ReturnFunction = TradeStarted
                    };
                    PopUps.Add(targetSelection);
                    targetSelection.Show();
                    if (state.ActivePlayer.IsBot)
                    {
                        targetSelection.HandleBotChoice(ArtificialIntelligence.SelectTarget(state.ActivePlayer, state.Players.Where(player => player != state.ActivePlayer).ToList(), false));
                    }
                }
                else
                {
                    TradeStarted(active, state.Players[Math.Abs(state.ActivePlayerIndex - 1)]);
                }
            }
        }

        private void TeamRocket()
        {
            state.OnLoadMethod = string.Empty;
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to select a new companion after defeating Team Rocket.", state.ActivePlayer.Name);
            state.TeamRocket = true;
            var color = state.ActivePlayer.Space.Color;
            var possibilities = state.Spaces.Where(space => space.Color == color).OfType<CatchSpace>().Where(catchSpace => catchSpace.AdjacentChip != null).ToList();
            if (!possibilities.Any())
            {
                Log("Team Rocket got away from {0}", state.ActivePlayer.Name);
                MessageHelper.ShowMessage(string.Format("You encountered Team Rocket, but they got away with all the {0} Pokémon. There are none left for you...", color), TechnicalConstants.TEAM_ROCKET, state.ActivePlayer.IsBot);
                EndTurn();
            }
            else
            {
                Log("Team Rocket was defeated by {0}", state.ActivePlayer.Name);
                MessageHelper.ShowMessage(string.Format("You encountered and defeated Team Rocket! Select any {0} Pokémon as your new companion.", color), TechnicalConstants.TEAM_ROCKET, state.ActivePlayer.IsBot);
                if (state.ActivePlayer.IsBot)
                {
                    state.BotChoice = ArtificialIntelligence.Catch(state.ActivePlayer, possibilities.Select(space => space.AdjacentChip).ToList(), color);
                    aiThread.RunWorkerAsync();
                }
                else
                {
                    foreach (var possibility in possibilities)
                    {
                        possibility.AdjacentChip.Clickable = true;
                    }
                }
            }
        }

        private void DungeonOfLegends()
        {
            state.OnLoadMethod = string.Empty;
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to catch a Legendary Pokémon in the Dungeon of Legends.", state.ActivePlayer.Name);
            Log("{0} entered the Dungeon of Legends", state.ActivePlayer.Name);
            if (!configurationManager.ScreenLock)
            {
                BoardPanel.HorizontalScroll.Value = MaximumScrollPosition.X;
                BoardPanel.VerticalScroll.Value = MaximumScrollPosition.Y;
            }
            if (!state.YellowChips.Any())
            {
                Log("The dungeon was empty");
                MessageHelper.ShowMessage("It seems all legendary Pokémon have been caught already... There's nothing to do in the dungeon.", TechnicalConstants.DUNGEON_OF_LEGENDS, state.ActivePlayer.IsBot);
                EndTurn();
            }
            else
            {
                soundPlayer.Play(LoadFacade.BuildUri("Dungeon", false), false);
                MessageHelper.ShowMessage("You have entered the Dungeon of Legends. Click on any of the yellow chips to try and catch a legendary Pokémon!", TechnicalConstants.DUNGEON_OF_LEGENDS, state.ActivePlayer.IsBot);
                if (state.ActivePlayer.IsBot)
                {
                    state.BotChoice = ArtificialIntelligence.Catch(state.ActivePlayer, state.YellowChips);
                    aiThread.RunWorkerAsync();
                }
                else
                {
                    foreach (var chip in state.YellowChips)
                    {
                        chip.Clickable = true;
                    }
                }
            }
        }

        private void Investigation()
        {
            var player = state.ActivePlayer;
            player.UnderInvestigation = true;
            Log("Investigation started. Interrogating: {0}", player.Name);
            soundPlayer.Play(LoadFacade.BuildUri("Whistle", false), false);
            MessageHelper.ShowMessage(string.Format("{0}, Officer Jenny will soon start her interrogation. You will not be able to play on your next turn.", player.Name), TechnicalConstants.INVESTIGATION, player.IsBot);
            EndTurn();
        }

        public void PokeDollUsed(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            Log("A Poké Doll was used");
            MessageHelper.ShowMessage("A Poké Doll was used to stop the current event.", TechnicalConstants.POKEDOLL, state.ActivePlayer.IsBot);
            EndTurn();
        }

        private void NewCompanion(Chip chip)
        {
            var player = state.ActivePlayer;
            Log("{0} got {1} as a new companion", player.Name, chip.Pokemon);
            soundPlayer.Play(LoadFacade.BuildUri("Catch", false), false);
            MessageHelper.ShowMessage(string.Format("{0} joined your team!", chip.Pokemon), TechnicalConstants.TEAM_ROCKET, player.IsBot);
            chip.Click -= CatchPokemon;
            BoardPicture.Controls.Remove(chip);
            player.Pokemon.Add(chip);
            ReplaceCatchSpaceChip(chip.AdjacentSpace);
            EndTurn();
        }

        #endregion

        #region Battle

        public void ChallengeStarted(Player challenger, Player target)
        {
            state.OnLoadMethod = "ChallengeStarted";
            state.OnLoadMethodParameters = new List<object> { challenger, target };
            state.OnLoadMessage = string.Format("{0} was in a challenge with {1}.", challenger.Name, target.Name);
            state.Challenger = challenger;
            state.Target = target;
            if (target.Items.Any(item => item.CardType == CardType.PokeDoll))
            {
                var result = MessageHelper.ShowMessage(string.Format("{0}, do you want to cancel this challenge by using a Poké Doll?", target.Name), TechnicalConstants.POKEDOLL, target.IsBot, MessageBoxButtons.YesNo);
                if (target.IsBot)
                {
                    result = ArtificialIntelligence.UsePokeDoll(target, true) ? DialogResult.Yes : DialogResult.No;
                }
                if (result == DialogResult.Yes)
                {
                    var bag = new Bag(this, target, ChallengePokeDollCanceled, CardType.PokeDoll);
                    PopUps.Add(bag);
                    bag.Show();
                    if (target.IsBot)
                    {
                        bag.HandleBotChoice(ArtificialIntelligence.SelectCard(target, CardType.PokeDoll));
                    }
                }
                else
                {
                    StartChallengeSelection();
                }
            }
            else
            {
                StartChallengeSelection();
            }
        }

        private void ChallengePokeDollCanceled(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            StartChallengeSelection();
        }

        public void StartChallengeSelection()
        {
            state.OnLoadMethod = "StartChallengeSelection";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to select a Pokémon to battle with.", state.Challenger.Name);
            MessageHelper.ShowMessage(string.Format("{0}, select one of your Pokémon to battle with.", state.Challenger.Name), TechnicalConstants.BATTLE, state.Challenger.IsBot);
            var pokedex = new Pokedex(this, state.Challenger, false, true, false, false, null, null);
            PopUps.Add(pokedex);
            pokedex.Show();
            if (state.Challenger.IsBot)
            {
                pokedex.HandleBotChoice(ArtificialIntelligence.SelectBattleChip(state.Challenger));
            }
        }

        public void BattleSelected(Pokedex toClose, Chip left, Chip right)
        {
            state.OnLoadMethod = "BattleSelected";
            state.OnLoadMethodParameters = new List<object> { null, left, right };
            state.OnLoadMessage = string.Format("{0} was about to battle{1}.", left.Pokemon, right == null ? string.Empty : " " + right.Pokemon);
            if (toClose != null)
            {
                toClose.Close();
                PopUps.Remove(toClose);
            }
            if (state.EliteTrainer != null)
            {
                ChallengerSelected(left);
            }
            else
            {
                if (right == null)
                {
                    Log("{0} chose {1} to battle", state.Challenger.Name, left.Pokemon);
                    MessageHelper.ShowMessage(string.Format("{0}, select one of your Pokémon to battle with.", state.Target.Name), TechnicalConstants.BATTLE, state.Target.IsBot);
                    var pokedex = new Pokedex(this, state.Target, false, true, false, false, null, left);
                    PopUps.Add(pokedex);
                    pokedex.Show();
                    if (state.Target.IsBot)
                    {
                        pokedex.HandleBotChoice(ArtificialIntelligence.SelectBattleChip(state.Target));
                    }
                }
                else
                {
                    Log("{0} chose {1} to battle", state.Target.Name, right.Pokemon);
                    state.InBattle = new Tuple<Chip, Chip>(left, right);
                    state.Challenger.ActivePokemon.BonusDamage += CalculateEvolutionBonus(state.Challenger);
                    state.Target.ActivePokemon.BonusDamage += CalculateEvolutionBonus(state.Target);
                    if (state.Challenger.HasAttackBonus)
                    {
                        var result = MessageHelper.ShowMessage(string.Format("{0}, do you want to increase your Pokémon's attack with a bonus item?", state.Challenger.Name), TechnicalConstants.BATTLE, state.Challenger.IsBot, MessageBoxButtons.YesNo);
                        if (state.Challenger.IsBot)
                        {
                            result = ArtificialIntelligence.UseAttackBonus(state.Challenger, state.Target) ? DialogResult.Yes : DialogResult.No;
                        }
                        if (result == DialogResult.Yes)
                        {
                            var bag = new Bag(this, state.Challenger, ChallengerAttackBonusCanceled, CardType.AttackBonus1, CardType.AttackBonus2, CardType.AttackBonus3, CardType.AttackBonus4, CardType.AttackBonus5);
                            PopUps.Add(bag);
                            bag.Show();
                            if (state.Challenger.IsBot)
                            {
                                bag.HandleBotChoice(ArtificialIntelligence.SelectAttackBonus(state.Challenger, state.Target));
                            }
                        }
                        else
                        {
                            AttackBonusUsed(null, state.Challenger, null);
                        }
                    }
                    else
                    {
                        AttackBonusUsed(null, state.Challenger, null);
                    }
                }
            }
        }

        private void ChallengerAttackBonusCanceled(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            AttackBonusUsed(null, state.Challenger, null);
        }

        private int CalculateEvolutionBonus(Player player)
        {
            var bonus = gameManager.CalculateEvolutionBonus(player.ActivePokemon, player.Pokemon);
            if (bonus > 0)
            {
                Log("{0} got an evolution bonus of {1}", player.ActivePokemon.Pokemon, bonus);
                MessageHelper.ShowMessage(string.Format("{0}'s {1} got an evolution bonus of {2}.", player.Name, player.ActivePokemon.Pokemon, bonus), TechnicalConstants.BATTLE, player.IsBot);
            }
            return bonus;
        }

        public void AttackBonusUsed(Bag bag, Player player, Card bonus)
        {
            state.OnLoadMethod = "AttackBonusUsed";
            state.OnLoadMethodParameters = new List<object> { null, player, bonus };
            state.OnLoadMessage = string.Format("{0} was thinking of using an attack bonus.", player.Name);
            if (bag != null)
            {
                bag.Close();
                PopUps.Remove(bag);
            }
            if (state.EliteTrainer != null)
            {
                if (state.FirstBonusUsed)
                {
                    SecondAttackBonusUsed(bonus);
                }
                else
                {
                    FirstAttackBonusUsed(bonus);
                }
            }
            else
            {
                if (bonus != null)
                {
                    var bonusDamage = Int32.Parse(bonus.CardType.ToString().Replace(TechnicalConstants.ATTACK_BONUS, string.Empty));
                    Log("{0} used an attack bonus of +{1}", player.Name, bonusDamage);
                    player.ActivePokemon.BonusDamage += bonusDamage;
                }
                if (player == state.Challenger && state.Target.HasAttackBonus)
                {
                    var result = MessageHelper.ShowMessage(string.Format("{0}, do you want to increase your Pokémon's attack with a bonus item?", state.Target.Name), TechnicalConstants.BATTLE, state.Target.IsBot, MessageBoxButtons.YesNo);
                    if (state.Target.IsBot)
                    {
                        result = ArtificialIntelligence.UseAttackBonus(state.Target, state.Challenger) ? DialogResult.Yes : DialogResult.No;
                    }
                    if (result == DialogResult.Yes)
                    {
                        bag = new Bag(this, state.Target, TargetAttackBonusCanceled, CardType.AttackBonus1, CardType.AttackBonus2, CardType.AttackBonus3, CardType.AttackBonus4, CardType.AttackBonus5);
                        PopUps.Add(bag);
                        bag.Show();
                        if (state.Challenger.IsBot)
                        {
                            bag.HandleBotChoice(ArtificialIntelligence.SelectAttackBonus(state.Target, state.Challenger));
                        }
                    }
                    else
                    {
                        InitiateFirstAttack();
                    }
                }
                else
                {
                    InitiateFirstAttack();
                }
            }
        }

        private void TargetAttackBonusCanceled(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            InitiateFirstAttack();
        }

        public void InitiateFirstAttack()
        {
            state.OnLoadMethod = "InitiateFirstAttack";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to attack.", state.Challenger.Name);
            MessageHelper.ShowMessage(string.Format("{0}, roll the dice to determine your attack damage.", state.Challenger.Name), TechnicalConstants.BATTLE, state.Challenger.IsBot);
            diceRoller.ReturnFunction = FirstAttack;
            diceRoller.Bot = state.Challenger.IsBot;
            diceRoller.Show();
        }

        public void FirstAttack(int result)
        {
            state.OnLoadMethod = "FirstAttack";
            state.OnLoadMethodParameters = new List<object> { result };
            state.OnLoadMessage = string.Format("{0} was about to attack.", state.Target.Name);
            Log("{0} rolled {1}", state.Challenger.Name, result);
            state.Challenger.ActivePokemon.BonusDamage += result;
            MessageHelper.ShowMessage(string.Format("{0}, roll the dice to determine your attack damage.", state.Target.Name), TechnicalConstants.BATTLE, state.Target.IsBot);
            diceRoller.ReturnFunction = SecondAttack;
            diceRoller.Bot = state.Target.IsBot;
            diceRoller.Show();
        }

        private void SecondAttack(int result)
        {
            Log("{0} rolled {1}", state.Target.Name, result);
            state.Target.ActivePokemon.BonusDamage += result;
            var challengerDamage = state.Challenger.ActivePokemon.TotalDamage;
            var targetDamage = state.Target.ActivePokemon.TotalDamage;
            MessageHelper.ShowMessage(string.Format("{0}'s {1} used {2} and dealt {3} damage. {4}'s {5} used {6} and dealt {7} damage.", state.Challenger.Name, state.InBattle.Item1.Pokemon, state.InBattle.Item1.Attack, challengerDamage,
                state.Target.Name, state.InBattle.Item2.Pokemon, state.InBattle.Item2.Attack, targetDamage), TechnicalConstants.BATTLE, state.Challenger.IsBot && state.Target.IsBot);
            if (challengerDamage > targetDamage)
            {
                state.InBattle.Item2.KnockedOut = true;
                BattleWon(state.Challenger, state.Target, state.InBattle.Item2);
            }
            else if (targetDamage > challengerDamage)
            {
                state.InBattle.Item1.KnockedOut = true;
                BattleWon(state.Target, state.Challenger, state.InBattle.Item1);
            }
            else
            {
                MessageHelper.ShowMessage("We have a tie. Players will roll again to perform a new attack.", TechnicalConstants.BATTLE, state.Challenger.IsBot && state.Target.IsBot);
                InitiateFirstAttack();
            }
        }

        private void BattleWon(Player winner, Player loser, Chip knockedOut)
        {
            state.InBattle = null;
            state.Challenger = null;
            state.Target = null;
            winner.ActivePokemon.BonusDamage = 0;
            winner.ActivePokemon = null;
            loser.ActivePokemon.BonusDamage = 0;
            loser.ActivePokemon = null;
            knockedOut.KnockedOut = true;
            Log("{0}'s {1} was knocked out", loser.Name, knockedOut.Pokemon);
            soundPlayer.Play(LoadFacade.BuildUri("Battle", false), false);
            MessageHelper.ShowMessage(string.Format("Too bad {0}, you lost. Your {1} is knocked out.", loser.Name, knockedOut.Pokemon), TechnicalConstants.BATTLE, loser.IsBot);
            Log("{0} won the battle", winner.Name);
            MessageHelper.ShowMessage(string.Format("Congratulations {0}, you won the battle! As a reward, you get an item card.", winner.Name), TechnicalConstants.BATTLE, winner.IsBot);
            DrawCards(DeckType.Item, 1, winner);
        }

        #endregion

        #region Trade

        public void TradeStarted(Player challenger, Player target)
        {
            state.OnLoadMethod = "TradeStarted";
            state.OnLoadMethodParameters = new List<object> { challenger, target };
            state.OnLoadMessage = string.Format("{0} was thinking of using a Poké Doll to cancel a trade with {1}.", target.Name, challenger.Name);
            state.Challenger = challenger;
            state.Target = target;
            if (target.Items.Any(item => item.CardType == CardType.PokeDoll))
            {
                var result = MessageHelper.ShowMessage(string.Format("{0}, do you want to cancel this trade by using a Poké Doll?", target.Name), TechnicalConstants.POKEDOLL, target.IsBot, MessageBoxButtons.YesNo);
                if (target.IsBot)
                {
                    result = ArtificialIntelligence.UsePokeDoll(target, false) ? DialogResult.Yes : DialogResult.No;
                }
                if (result == DialogResult.Yes)
                {
                    var bag = new Bag(this, target, TradePokeDollCanceled, CardType.PokeDoll);
                    PopUps.Add(bag);
                    bag.Show();
                    if (target.IsBot)
                    {
                        bag.HandleBotChoice(ArtificialIntelligence.SelectCard(target, CardType.PokeDoll));
                    }
                }
                else
                {
                    StartTradeSelection();
                }
            }
            else
            {
                StartTradeSelection();
            }
        }

        private void TradePokeDollCanceled(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            StartTradeSelection();
        }

        public void StartTradeSelection()
        {
            state.OnLoadMethod = "StartTradeSelection";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was selecting one of his/her Pokémon to trade.", state.Challenger.Name);
            MessageHelper.ShowMessage(string.Format("{0}, select one of your own Pokémon you wish to trade.", state.Challenger.Name), TechnicalConstants.TRADE, state.Challenger.IsBot);
            var pokedex = new Pokedex(this, state.Challenger, false, false, false, true, state.Challenger.CanTrade(state.Target), null);
            PopUps.Add(pokedex);
            pokedex.Show();
            if (state.Challenger.IsBot)
            {
                pokedex.HandleBotChoice(ArtificialIntelligence.SelectTradeChip(state.Challenger, state.Target, true));
            }
        }

        public void TradeSelected(Pokedex toClose, Chip left, Chip right)
        {
            state.OnLoadMethod = "TradeSelected";
            state.OnLoadMethodParameters = new List<object> { null, left, right };
            state.OnLoadMessage = string.Format("{0} was about to select one of {1}'s Pokémon to trade.", state.Challenger.Name, state.Target.Name);
            if (toClose != null)
            {
                toClose.Close();
                PopUps.Remove(toClose);
            }
            if (right == null)
            {
                Log("{0} was chosen as the first Pokémon to trade", left.Pokemon);
                MessageHelper.ShowMessage(string.Format("{0}, select one of {1}'s Pokémon of the same color you wish to get in return.", state.Challenger.Name, state.Target.Name), TechnicalConstants.TRADE, state.Challenger.IsBot);
                var pokedex = new Pokedex(this, state.Target, false, false, false, true, new List<Rarity> { left.Rarity }, left);
                PopUps.Add(pokedex);
                pokedex.Show();
                if (state.Challenger.IsBot)
                {
                    pokedex.HandleBotChoice(ArtificialIntelligence.SelectTradeChip(state.Challenger, state.Target, false));
                }
            }
            else
            {
                Log("{0} was chosen as the second Pokémon to trade", right.Pokemon);
                state.Challenger.Pokemon.Remove(left);
                state.Target.Pokemon.Remove(right);
                state.Challenger.Pokemon.Add(right);
                state.Target.Pokemon.Add(left);
                Log("Traded {0} for {1}", left.Pokemon, right.Pokemon);
                MessageHelper.ShowMessage(string.Format("Traded {0}'s {1} for {2}'s {3}. Enjoy your new partners!", state.Challenger.Name, left.Pokemon, state.Target.Name, right.Pokemon), TechnicalConstants.TRADE, state.Challenger.IsBot && state.Target.IsBot);
                state.Challenger = null;
                state.Target = null;
                EndTurn();
            }
        }

        #endregion

        #region Revival

        public void Revival()
        {
            state.OnLoadMethod = "Revival";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was thinking of taking the revival challenge", state.ActivePlayer.Name);
            var player = state.ActivePlayer;
            if (!player.HasKnockedOutPokemon)
            {
                Log("{0} did not have any knocked out Pokémon", player.Name);
                MessageHelper.ShowMessage("All your Pokémon are fit for battle.", TechnicalConstants.REVIVAL, player.IsBot);
                EndTurn();
            }
            else
            {
                var result = MessageHelper.ShowMessage(string.Format("{0}, do you want to take the Revival Challenge (throw higher than 4 to revive all your Pokémon)? If not, you can revive a single Pokémon.", player.Name), TechnicalConstants.REVIVAL, player.IsBot, MessageBoxButtons.YesNo);
                if (player.IsBot)
                {
                    result = ArtificialIntelligence.TakeRevivalChallenge(player) ? DialogResult.Yes : DialogResult.No;
                }
                if (result == DialogResult.Yes)
                {
                    Log("{0} took the Revival Challenge", player.Name);
                    diceRoller.ReturnFunction = RevivalChallengeEnded;
                    diceRoller.Bot = player.IsBot;
                    diceRoller.Show();
                }
                else
                {
                    ReviveSingle(false);
                }
            }
        }

        public void ReviveSingle(bool potionUsed)
        {
            state.OnLoadMethod = "ReviveSingle";
            state.OnLoadMethodParameters = new List<object> { potionUsed };
            state.OnLoadMessage = string.Format("{0} was about to select a Pokémon to revive.", state.ActivePlayer.Name);
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            MessageHelper.ShowMessage("Select the knocked out Pokémon you wish to revive.", TechnicalConstants.REVIVAL, state.ActivePlayer.IsBot);
            var pokedex = new Pokedex(this, state.ActivePlayer, false, false, true, false, null, null)
            {
                PotionUsed = potionUsed
            };
            PopUps.Add(pokedex);
            pokedex.Show();
            if (state.ActivePlayer.IsBot)
            {
                pokedex.HandleBotChoice(ArtificialIntelligence.SelectRevivalChip(state.ActivePlayer));
            }
        }

        public void RevivalEnded(Pokedex pokedex, Chip chip)
        {
            state.OnLoadMethod = string.Empty;
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} had just revived {1}.", state.ActivePlayer.Name, chip.Pokemon);
            DiceCup.Enabled = true;
            Log("{0} was revived", chip.Pokemon);
            soundPlayer.Play(LoadFacade.BuildUri("Revival", false), false);
            var end = !pokedex.PotionUsed;
            pokedex.Close();
            PopUps.Remove(pokedex);
            if (end)
            {
                EndTurn();
            }
            else
            {
                if (state.ActivePlayer.IsBot)
                {
                    BotMoveOrFly();
                }
                else
                {
                    Pokedex.Enabled = true;
                    ItemBag.Enabled = true;
                }
            }
        }

        private void RevivalChallengeEnded(int result)
        {
            if (result > 4)
            {
                foreach (var pokemon in state.ActivePlayer.Pokemon.Where(chip => chip.KnockedOut))
                {
                    pokemon.KnockedOut = false;
                }
                Log("All Pokémon were revived");
                soundPlayer.Play(LoadFacade.BuildUri("Revival", false), false);
                MessageHelper.ShowMessage("Success! All your Pokémon have been revived!", TechnicalConstants.REVIVAL, state.ActivePlayer.IsBot);
            }
            else
            {
                Log("Revival challenge failed");
                soundPlayer.Play(LoadFacade.BuildUri("Failure", false), false);
                MessageHelper.ShowMessage("You failed to revive your Pokémon...", TechnicalConstants.REVIVAL, state.ActivePlayer.IsBot);
            }
            EndTurn();
        }

        #endregion

        #region Final Battle

        private void FinalBattle(object sender, EventArgs eventArgs)
        {
            state.OnLoadMethod = string.Empty;
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to find out who his/her elite opponent is.", state.ActivePlayer.Name);
            MessageHelper.ShowMessage("Draw an elite card to see who your opponent is.", TechnicalConstants.FINAL_BATTLE, state.ActivePlayer.IsBot);
            if (state.ActivePlayer.IsBot)
            {
                state.BotChoice = state.EliteTrainers[0];
                aiThread.RunWorkerAsync();
            }
            else
            {
                state.EliteTrainers[0].Enabled = true;
            }
        }

        public void StartFinalBattle(object sender, EventArgs eventArgs)
        {
            state.OnLoadMethod = "StartFinalBattle";
            state.OnLoadMethodParameters = new List<object> { sender, null };
            state.OnLoadMessage = string.Format("{0} was about to start a battle against an elite trainer.", state.ActivePlayer.Name);
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            var elite = (Elite)sender;
            Log("Elite trainer {0} was challenged to a battle", elite.Trainer);
            elite.Enabled = false;
            state.EliteTrainer = elite;
            MessageHelper.ShowMessage(string.Format("Your Elite opponent is {0}. Good luck!", elite.Trainer), TechnicalConstants.FINAL_BATTLE, state.ActivePlayer.IsBot);
            state.Challenger = state.ActivePlayer;
            MessageHelper.ShowMessage(string.Format("{0}, select one of your Pokémon to battle with.", state.Challenger.Name), TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot);
            var pokedex = new Pokedex(this, state.Challenger, false, true, false, false, null, null);
            PopUps.Add(pokedex);
            pokedex.Show();
            if (state.Challenger.IsBot)
            {
                pokedex.HandleBotChoice(ArtificialIntelligence.SelectBattleChip(state.Challenger));
            }
        }

        public void ChallengerSelected(Chip pokemon)
        {
            state.OnLoadMethod = "ChallengerSelected";
            state.OnLoadMethodParameters = new List<object> { pokemon };
            state.OnLoadMessage = string.Format("{0} had just selected {1} to battle against an elite trainer.", state.Challenger.Name, pokemon.Pokemon);
            Log("{0} chose {1} to battle", state.Challenger.Name, pokemon.Pokemon);
            state.Challenger.ActivePokemon = pokemon;
            state.Challenger.ActivePokemon.BonusDamage += CalculateEvolutionBonus(state.Challenger);
            if (state.Challenger.HasAttackBonus)
            {
                var result = MessageHelper.ShowMessage(string.Format("{0}, do you want to increase your Pokémon's attack with a bonus item?", state.Challenger.Name), TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot, MessageBoxButtons.YesNo);
                if (state.Challenger.IsBot)
                {
                    result = ArtificialIntelligence.UseAttackBonus(state.Challenger, null) ? DialogResult.Yes : DialogResult.No;
                }
                if (result == DialogResult.Yes)
                {
                    var bag = new Bag(this, state.Challenger, EliteAttackBonusCanceled, CardType.AttackBonus1, CardType.AttackBonus2, CardType.AttackBonus3, CardType.AttackBonus4, CardType.AttackBonus5);
                    PopUps.Add(bag);
                    bag.Show();
                    if (state.Challenger.IsBot)
                    {
                        bag.HandleBotChoice(ArtificialIntelligence.SelectAttackBonus(state.Challenger, null));
                    }
                }
                else
                {
                    EliteChoice();
                }
            }
            else
            {
                EliteChoice();
            }
        }

        public void FirstAttackBonusUsed(Card bonus)
        {
            state.OnLoadMethod = "FirstAttackBonusUsed";
            state.OnLoadMethodParameters = new List<object> { bonus };
            state.OnLoadMessage = string.Format("{0} had just used an attack bonus in a battle with an elite trainer.", state.Challenger.Name);
            var bonusDamage = Int32.Parse(bonus.CardType.ToString().Replace(TechnicalConstants.ATTACK_BONUS, string.Empty));
            Log("{0} used an attack bonus of +{1}", state.Challenger.Name, bonusDamage);
            state.Challenger.ActivePokemon.BonusDamage += bonusDamage;
            state.FirstBonusUsed = true;
            if (state.Challenger.HasAttackBonus)
            {
                var result = MessageHelper.ShowMessage(string.Format("{0}, do you want to increase your Pokémon's attack again with another bonus item?", state.Challenger.Name), TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot, MessageBoxButtons.YesNo);
                if (state.Challenger.IsBot)
                {
                    result = ArtificialIntelligence.UseAttackBonus(state.Challenger, null) ? DialogResult.Yes : DialogResult.No;
                }
                if (result == DialogResult.Yes)
                {
                    var bag = new Bag(this, state.Challenger, EliteAttackBonusCanceled, CardType.AttackBonus1, CardType.AttackBonus2, CardType.AttackBonus3, CardType.AttackBonus4, CardType.AttackBonus5);
                    PopUps.Add(bag);
                    bag.Show();
                    if (state.Challenger.IsBot)
                    {
                        bag.HandleBotChoice(ArtificialIntelligence.SelectAttackBonus(state.Challenger, null));
                    }
                }
                else
                {
                    EliteChoice();
                }
            }
            else
            {
                EliteChoice();
            }
        }

        private void EliteAttackBonusCanceled(Bag bag)
        {
            bag.Close();
            PopUps.Remove(bag);
            EliteChoice();
        }

        private void SecondAttackBonusUsed(Card bonus)
        {
            var bonusDamage = Int32.Parse(bonus.CardType.ToString().Replace(TechnicalConstants.ATTACK_BONUS, string.Empty));
            Log("{0} used another attack bonus of +{1}", state.Challenger.Name, bonusDamage);
            state.Challenger.ActivePokemon.BonusDamage += bonusDamage;
            EliteChoice();
        }

        public void EliteChoice()
        {
            state.FirstBonusUsed = false;
            state.OnLoadMethod = "EliteChoice";
            state.OnLoadMethodParameters = new List<object>();
            state.OnLoadMessage = string.Format("{0} was about to find out which Pokémon the elite trainer is going to use.", state.Challenger.Name);
            MessageHelper.ShowMessage("Roll the dice to see what Pokémon the Elite Trainer is going to use.", TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot);
            diceRoller.ReturnFunction = EliteChosen;
            diceRoller.Bot = state.Challenger.IsBot;
            diceRoller.Show();
        }

        public void EliteChosen(int result)
        {
            state.OnLoadMethod = "EliteChosen";
            state.OnLoadMethodParameters = new List<object> { result };
            state.OnLoadMessage = string.Format("{0} was about to attack an elite trainer.", state.Challenger.Name);
            var pokemon = state.EliteTrainer.Team[result];
            state.EliteTrainer.ActivePokemon = pokemon;
            Log("{0} sent out {1}", state.EliteTrainer.Trainer, pokemon.Item1);
            MessageHelper.ShowMessage(string.Format("{0} sent out {1} to battle.", state.EliteTrainer.Trainer, pokemon.Item1), TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot);
            MessageHelper.ShowMessage("Roll the dice to determine your attack damage.", TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot);
            diceRoller.ReturnFunction = FinalBattleAttack;
            diceRoller.Bot = state.Challenger.IsBot;
            diceRoller.Show();
        }

        private void FinalBattleAttack(int result)
        {
            var challengerDamage = state.Challenger.ActivePokemon.TotalDamage + result;
            var eliteDamage = state.EliteTrainer.ActivePokemon.Item2;
            MessageHelper.ShowMessage(string.Format("{0}'s {1} used {2} and dealt {3} damage. {4}'s {5} attacked and dealt {6} damage.", state.Challenger.Name,
                state.Challenger.ActivePokemon.Pokemon, state.Challenger.ActivePokemon.Attack, challengerDamage, state.EliteTrainer.Trainer,
                state.EliteTrainer.ActivePokemon.Item1, state.EliteTrainer.ActivePokemon.Item2), TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot);
            if (challengerDamage > eliteDamage)
            {
                Log("{0} beat {1} and won the game", state.Challenger.Name, state.EliteTrainer.Trainer);
                musicPlayer.Stop();
                musicPlayer.HardPlay(LoadFacade.BuildUri("Victory", true));
                MessageHelper.ShowMessage(string.Format("Congratulations {0}! You beat an Elite Trainer and you are now a true Pokémon Master! YOU HAVE WON THE GAME!!!", state.Challenger.Name), TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot);
                state.GameOver = true;
                DiceCup.Enabled = false;
                Pokedex.Enabled = true;
                ItemBag.Enabled = true;
            }
            else if (eliteDamage > challengerDamage)
            {
                Log("{0} was defeated by {1}", state.Challenger.Name, state.EliteTrainer.Trainer);
                soundPlayer.Play(LoadFacade.BuildUri("Failure", false), false);
                MessageHelper.ShowMessage("Too bad, you lost. But there's no shame in losing to an Elite Trainer. If you train harder, maybe you can beat one later.", TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot);
                state.EliteTrainer.ActivePokemon = null;
                state.EliteTrainer.Flipped = !state.EliteTrainer.Flipped;
                state.EliteTrainer = null;
                ReplaceElite();
                state.Challenger.ActivePokemon.BonusDamage = 0;
                state.Challenger.ActivePokemon.KnockedOut = true;
                state.Challenger.ActivePokemon = null;
                state.Challenger.Space = state.CinnabarIsland;
                state.Challenger = null;
                EndTurn();
            }
            else
            {
                Log("Battle was a tie");
                MessageHelper.ShowMessage("We have a tie. New rolls will determine a new elite Pokémon and new attack damage for the challenger.", TechnicalConstants.FINAL_BATTLE, state.Challenger.IsBot);
                EliteChoice();
            }
        }

        private void ReplaceElite()
        {
            var elite = state.EliteTrainers[0];
            if (BoardPicture.Controls.Contains(elite))
            {
                BoardPicture.Controls.Remove(elite);
                state.EliteTrainers.Remove(elite);
                state.EliteTrainers.Add(elite);
            }
            elite = state.EliteTrainers[0];
            BoardPicture.Controls.Add(elite);
        }

        #endregion

        #region Player Box

        private void Pokedex_Click(object sender, EventArgs eventArgs)
        {
            var pokedex = new Pokedex(this, state.ActivePlayer, true, false, false, false, null, null);
            PopUps.Add(pokedex);
            pokedex.Show();
        }

        private void ItemBag_Click(object sender, EventArgs eventArgs)
        {
            var bag = new Bag(this, state.ActivePlayer, null, CardType.Fly, CardType.Potion);
            PopUps.Add(bag);
            bag.Show();
            if (state.ActivePlayer.IsBot)
            {
                bag.HandleBotChoice(ArtificialIntelligence.SelectCard(state.ActivePlayer, (CardType)((BotEventArgs)eventArgs).Argument));
            }
        }

        private void DiceCup_Click(object sender, EventArgs eventArgs)
        {
            Pokedex.Enabled = false;
            ItemBag.Enabled = false;
            DiceCup.Enabled = false;
            diceRoller.ReturnFunction = PlayerMovement;
            diceRoller.Bot = state.ActivePlayer.IsBot;
            diceRoller.Show();
        }

        #endregion

        #region Options Box

        private void MusicQuick_Click(object sender, EventArgs eventArgs)
        {
            if (configurationManager.Music)
            {
                configurationManager.Music = false;
                musicPlayer.Stop();
                MusicQuick.Image = Properties.Resources.Music_Off;
            }
            else
            {
                configurationManager.Music = true;
                musicPlayer.Play();
                MusicQuick.Image = Properties.Resources.Music_On;
            }
        }

        private void SoundQuick_Click(object sender, EventArgs eventArgs)
        {
            if (configurationManager.Sound)
            {
                configurationManager.Sound = false;
                SoundQuick.Image = Properties.Resources.Sound_Off;
            }
            else
            {
                configurationManager.Sound = true;
                SoundQuick.Image = Properties.Resources.Sound_On;
            }
        }

        private void ScreenLockQuick_Click(object sender, EventArgs eventArgs)
        {
            if (configurationManager.ScreenLock)
            {
                configurationManager.ScreenLock = false;
                ScreenLockQuick.Image = Properties.Resources.ScreenLock_Off;
            }
            else
            {
                configurationManager.ScreenLock = true;
                ScreenLockQuick.Image = Properties.Resources.ScreenLock_On;
            }
        }

        #endregion

        #region Default Events

        private void AddSoundEvents()
        {
            DiceCup.MouseEnter += EnterSoundEvent;
            DiceCup.Click += ClickSoundEvent;
            foreach (var pictureBox in OptionsBox.Controls.OfType<PictureBox>())
            {
                pictureBox.MouseEnter += EnterSoundEvent;
                pictureBox.Click += ClickSoundEvent;
            }
        }

        private void Log(string message, params object[] parameters)
        {
            if (configurationManager.Log)
            {
                if (parameters.Any())
                {
                    message = string.Format(message, parameters);
                }
                LogView.Text = message + Environment.NewLine + LogView.Text;
            }
        }

        private void QuitButton_Click(object sender, EventArgs eventArgs)
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
            if (state.BotChoice != null)
            {
                state.BotChoice.PerformClick();
            }
        }

        private void InfoPanel_Paint(object sender, PaintEventArgs eventArgs)
        {
            using (var pen = new Pen(Color.Black, 3))
            {
                eventArgs.Graphics.DrawRectangle(pen, new Rectangle(0, 0, InfoPanel.ClientSize.Width - 1, InfoPanel.ClientSize.Height - 1));
            }
        }

        private void Board_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if (state.GameStarted && !state.GameOver)
            {
                if (configurationManager.AutoSave
                    || (MessageHelper.ShowMessage("Do you want to save your current game?", TechnicalConstants.SAVE_GAME, false, MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    gameManager.SaveGame(state);
                }
            }
            else
            {
                gameManager.DeleteSavedGame();
            }
            musicPlayer.ContinuousPlay = false;
            musicPlayer.Stop();
            foreach (var form in PopUps)
            {
                form.Dispose();
            }
            diceRoller.ReturnFunction = null;
            diceRoller.Hide();
            Deck.Destroy(this);
            parent.Enabled = true;
            parent.Show();
        }

        #endregion

        #region Scrolling

        private void ScrollBoard(Control scrollTo)
        {
            if (!configurationManager.ScreenLock)
            {
                var horizontalScroll = (int)((scrollTo.Location.X + (double)scrollTo.Width / 2) - ((double)(BoardPanel.HorizontalScroll.Maximum - MaximumScrollPosition.X)) / 2);
                var verticalScroll = (int)((scrollTo.Location.Y + (double)scrollTo.Height / 2) - ((double)(BoardPanel.VerticalScroll.Maximum - MaximumScrollPosition.Y)) / 2);
                if (horizontalScroll < 0)
                {
                    horizontalScroll = 0;
                }
                if (verticalScroll < 0)
                {
                    verticalScroll = 0;
                }
                if (horizontalScroll > MaximumScrollPosition.X)
                {
                    horizontalScroll = MaximumScrollPosition.X;
                }
                if (verticalScroll > MaximumScrollPosition.Y)
                {
                    verticalScroll = MaximumScrollPosition.Y;
                }
                BoardPanel.HorizontalScroll.Value = horizontalScroll;
                BoardPanel.VerticalScroll.Value = verticalScroll;
            }
        }

        private void BoardPicture_MouseDown(object sender, MouseEventArgs eventArgs)
        {
            Cursor = Cursors.NoMove2D;
            dragLocation = eventArgs.Location;
        }

        private void BoardPicture_MouseUp(object sender, MouseEventArgs eventArgs)
        {
            Cursor = Cursors.Default;
            dragLocation = Point.Empty;
        }

        private void BoardPicture_MouseMove(object sender, MouseEventArgs eventArgs)
        {
            if (dragLocation != Point.Empty)
            {
                BoardPanel.AutoScrollPosition = new Point(dragLocation.X - eventArgs.X - BoardPanel.AutoScrollPosition.X, dragLocation.Y - eventArgs.Y - BoardPanel.AutoScrollPosition.Y);
            }
        }

        #endregion

    }
}
