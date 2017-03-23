using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Controls;

namespace Cyprom.PokemonMasterTrainer.Domain
{
    public class BoardState
    {
        public List<Chip> PinkChips { get; set; }
        public List<Chip> GreenChips { get; set; }
        public List<Chip> BlueChips { get; set; }
        public List<Chip> RedChips { get; set; }
        public List<Chip> YellowChips { get; set; }

        public List<Card> ItemCards { get; set; }
        public List<Card> EventCards { get; set; }

        public List<Player> Players { get; set; }
        public List<Space> Spaces { get; set; }
        public List<Elite> EliteTrainers { get; set; }

        public Space PalletTown { get; set; }
        public Space CinnabarIsland { get; set; }
        public Space IndigoArrival { get; set; }

        public List<Tuple<Player, int>> OrderOfPlay { get; set; }
        public Chip InCatchProcess { get; set; }
        public Card BallToCatchWith { get; set; }
        public Player Challenger { get; set; }
        public Player Target { get; set; }
        public Elite EliteTrainer { get; set; }
        public Tuple<Chip, Chip> InBattle { get; set; }
        public IButtonControl BotChoice { get; set; }

        public int ActivePlayerIndex { get; set; }
        public bool TeamRocket { get; set; }
        public bool FirstBonusUsed { get; set; }
        public bool GameStarted { get; set; }
        public bool GameOver { get; set; }

        public string OnLoadMethod { get; set; }
        public List<object> OnLoadMethodParameters { get; set; } 
        public string OnLoadMessage { get; set; }

        public Player ActivePlayer
        {
            get
            {
                return Players[ActivePlayerIndex];
            }
        }

        public BoardState()
        {
            TeamRocket = false;
            FirstBonusUsed = false;
            GameStarted = false;
            GameOver = false;
            PinkChips = new List<Chip>();
            GreenChips = new List<Chip>();
            BlueChips = new List<Chip>();
            RedChips = new List<Chip>();
            YellowChips = new List<Chip>();
            Players = new List<Player>();
            Spaces = new List<Space>();
            EliteTrainers = new List<Elite>();
            OrderOfPlay = new List<Tuple<Player, int>>();
            OnLoadMethodParameters = new List<object>();
            OnLoadMessage = string.Empty;
        }

        public void ActivateNextPlayer()
        {
            ActivePlayerIndex++;
            if (ActivePlayerIndex >= Players.Count)
            {
                ActivePlayerIndex = 0;
            }
        }
    }
}
