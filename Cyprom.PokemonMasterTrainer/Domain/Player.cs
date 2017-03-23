using System.Collections.Generic;
using System.Linq;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public Trainer Trainer { get; set; }
        public List<Chip> Pokemon { get; set; }
        public List<Card> Items { get; set; }
        public SortType SortType { get; set; }
        public SortKey SortKey { get; set; }
        public bool OnCinnabarIsland { get; set; }
        public bool UnderInvestigation { get; set; }
        public bool Flying { get; set; }
        public Chip ActivePokemon { get; set; }
        public List<CityTown> VisitedPlaces { get; set; }
        public PlayerType PlayerType { get; set; }

        private Space space;

        public int PowerPoints
        {
            get
            {
                return Pokemon.Where(chip => !chip.KnockedOut).Sum(chip => chip.PowerPoints);
            }
        }

        public bool HasSpecialBalls
        {
            get
            {
                return Items.Select(item => item.CardType).Contains(CardType.GreatBall)
                    || Items.Select(item => item.CardType).Contains(CardType.UltraBall)
                    || Items.Select(item => item.CardType).Contains(CardType.MasterBall);
            }
        }

        public bool HasAttackBonus
        {
            get
            {
                return Items.Select(item => item.CardType).Contains(CardType.AttackBonus1)
                    || Items.Select(item => item.CardType).Contains(CardType.AttackBonus2)
                    || Items.Select(item => item.CardType).Contains(CardType.AttackBonus3)
                    || Items.Select(item => item.CardType).Contains(CardType.AttackBonus4)
                    || Items.Select(item => item.CardType).Contains(CardType.AttackBonus5);
            }
        }

        public bool HasKnockedOutPokemon
        {
            get
            {
                return Pokemon.Any(chip => chip.KnockedOut);
            }
        }

        public bool IsBot
        {
            get
            {
                return PlayerType == PlayerType.Bot;
            }
        }

        public bool CanBattle
        {
            get
            {
                return Pokemon.Any(chip => !chip.KnockedOut);
            }
        }

        public Space Space
        {
            get
            {
                return space;
            }
            set
            {
                if (value != null)
                {
                    if (space != null)
                    {
                        space.RemovePlayer(this);
                    }
                    space = value;
                    space.AddPlayer(this);
                    var cityTown = space as CityTown;
                    if (cityTown != null && !VisitedPlaces.Contains(cityTown))
                    {
                        VisitedPlaces.Add(cityTown);
                    }
                }
            }
        }
        
        public Player(string name, PlayerType playerType, Trainer trainer)
        {
            Name = name;
            PlayerType = playerType;
            Trainer = trainer;
            Pokemon = new List<Chip>();
            Items = new List<Card>();
            SortKey = SortKey.Name;
            SortType = SortType.Ascending;
            OnCinnabarIsland = false;
            UnderInvestigation = false;
            Flying = false;
            VisitedPlaces = new List<CityTown>();
        }
        
        public List<Rarity> CanTrade(Player target)
        {
            var rarities = new List<Rarity>();
            var grouped = Pokemon.GroupBy(chip => chip.Rarity);
            foreach (var group in grouped.Where(rarity => rarity.Key != Rarity.Starter))
            {
                if (target.Pokemon.Any(chip => chip.Rarity == group.Key))
                {
                    rarities.Add(group.Key);
                }
            }
            return rarities;
        }

        // Name is the unique identifier for a player
        public override string ToString()
        {
            return Name;
        }
    }
}
