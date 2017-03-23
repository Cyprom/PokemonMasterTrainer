using System.Collections.Generic;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data.Properties;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class CardLoader
    {
        private static int id = 1;

        public static void ResetIds()
        {
            id = 1;
        }

        public static List<Card> LoadItems()
        {
            return new List<Card>
            {
                new Card(id++, "Attack Bonus +1", Resources.AttackBonus1, DeckType.Item, CardType.AttackBonus1),
                new Card(id++, "Attack Bonus +1", Resources.AttackBonus1, DeckType.Item, CardType.AttackBonus1),
                new Card(id++, "Attack Bonus +1", Resources.AttackBonus1, DeckType.Item, CardType.AttackBonus1),
                new Card(id++, "Attack Bonus +1", Resources.AttackBonus1, DeckType.Item, CardType.AttackBonus1),
                new Card(id++, "Attack Bonus +1", Resources.AttackBonus1, DeckType.Item, CardType.AttackBonus1),
                new Card(id++, "Attack Bonus +1", Resources.AttackBonus1, DeckType.Item, CardType.AttackBonus1),
                new Card(id++, "Attack Bonus +1", Resources.AttackBonus1, DeckType.Item, CardType.AttackBonus1),
                new Card(id++, "Attack Bonus +2", Resources.AttackBonus2, DeckType.Item, CardType.AttackBonus2),
                new Card(id++, "Attack Bonus +2", Resources.AttackBonus2, DeckType.Item, CardType.AttackBonus2),
                new Card(id++, "Attack Bonus +2", Resources.AttackBonus2, DeckType.Item, CardType.AttackBonus2),
                new Card(id++, "Attack Bonus +2", Resources.AttackBonus2, DeckType.Item, CardType.AttackBonus2),
                new Card(id++, "Attack Bonus +2", Resources.AttackBonus2, DeckType.Item, CardType.AttackBonus2),
                new Card(id++, "Attack Bonus +2", Resources.AttackBonus2, DeckType.Item, CardType.AttackBonus2),
                new Card(id++, "Attack Bonus +3", Resources.AttackBonus3, DeckType.Item, CardType.AttackBonus3),
                new Card(id++, "Attack Bonus +3", Resources.AttackBonus3, DeckType.Item, CardType.AttackBonus3),
                new Card(id++, "Attack Bonus +3", Resources.AttackBonus3, DeckType.Item, CardType.AttackBonus3),
                new Card(id++, "Attack Bonus +3", Resources.AttackBonus3, DeckType.Item, CardType.AttackBonus3),
                new Card(id++, "Attack Bonus +3", Resources.AttackBonus3, DeckType.Item, CardType.AttackBonus3),
                new Card(id++, "Attack Bonus +4", Resources.AttackBonus4, DeckType.Item, CardType.AttackBonus4),
                new Card(id++, "Attack Bonus +4", Resources.AttackBonus4, DeckType.Item, CardType.AttackBonus4),
                new Card(id++, "Attack Bonus +4", Resources.AttackBonus4, DeckType.Item, CardType.AttackBonus4),
                new Card(id++, "Attack Bonus +4", Resources.AttackBonus4, DeckType.Item, CardType.AttackBonus4),
                new Card(id++, "Attack Bonus +5", Resources.AttackBonus5, DeckType.Item, CardType.AttackBonus5),
                new Card(id++, "Attack Bonus +5", Resources.AttackBonus5, DeckType.Item, CardType.AttackBonus5),
                new Card(id++, "Attack Bonus +5", Resources.AttackBonus5, DeckType.Item, CardType.AttackBonus5),
                new Card(id++, "Fly", Resources.Fly, DeckType.Item, CardType.Fly),
                new Card(id++, "Fly", Resources.Fly, DeckType.Item, CardType.Fly),
                new Card(id++, "Fly", Resources.Fly, DeckType.Item, CardType.Fly),
                new Card(id++, "Fly", Resources.Fly, DeckType.Item, CardType.Fly),
                new Card(id++, "Fly", Resources.Fly, DeckType.Item, CardType.Fly),
                new Card(id++, "Great Ball", Resources.GreatBall, DeckType.Item, CardType.GreatBall),
                new Card(id++, "Great Ball", Resources.GreatBall, DeckType.Item, CardType.GreatBall),
                new Card(id++, "Great Ball", Resources.GreatBall, DeckType.Item, CardType.GreatBall),
                new Card(id++, "Great Ball", Resources.GreatBall, DeckType.Item, CardType.GreatBall),
                new Card(id++, "Great Ball", Resources.GreatBall, DeckType.Item, CardType.GreatBall),
                new Card(id++, "Great Ball", Resources.GreatBall, DeckType.Item, CardType.GreatBall),
                new Card(id++, "Great Ball", Resources.GreatBall, DeckType.Item, CardType.GreatBall),
                new Card(id++, "Ultra Ball", Resources.UltraBall, DeckType.Item, CardType.UltraBall),
                new Card(id++, "Ultra Ball", Resources.UltraBall, DeckType.Item, CardType.UltraBall),
                new Card(id++, "Ultra Ball", Resources.UltraBall, DeckType.Item, CardType.UltraBall),
                new Card(id++, "Master Ball", Resources.MasterBall, DeckType.Item, CardType.MasterBall),
                new Card(id++, "Potion", Resources.Potion, DeckType.Item, CardType.Potion),
                new Card(id++, "Potion", Resources.Potion, DeckType.Item, CardType.Potion),
                new Card(id++, "Potion", Resources.Potion, DeckType.Item, CardType.Potion),
                new Card(id++, "Potion", Resources.Potion, DeckType.Item, CardType.Potion),
                new Card(id++, "Potion", Resources.Potion, DeckType.Item, CardType.Potion),
                new Card(id++, "Poké Doll", Resources.PokeDoll, DeckType.Item, CardType.PokeDoll),
                new Card(id++, "Poké Doll", Resources.PokeDoll, DeckType.Item, CardType.PokeDoll),
                new Card(id++, "Poké Doll", Resources.PokeDoll, DeckType.Item, CardType.PokeDoll),
                new Card(id++, "Poké Doll", Resources.PokeDoll, DeckType.Item, CardType.PokeDoll),
                new Card(id++, "Poké Doll", Resources.PokeDoll, DeckType.Item, CardType.PokeDoll)
            };
        }

        public static List<Card> LoadEvents()
        {

            return new List<Card>
            {
                new Card(id++, "Item Finder +1", Resources.ItemFinder1, DeckType.Event, CardType.ItemFinder1),
                new Card(id++, "Item Finder +1", Resources.ItemFinder1, DeckType.Event, CardType.ItemFinder1),
                new Card(id++, "Item Finder +1", Resources.ItemFinder1, DeckType.Event, CardType.ItemFinder1),
                new Card(id++, "Item Finder +1", Resources.ItemFinder1, DeckType.Event, CardType.ItemFinder1),
                new Card(id++, "Item Finder +1", Resources.ItemFinder1, DeckType.Event, CardType.ItemFinder1),
                new Card(id++, "Item Finder +1", Resources.ItemFinder1, DeckType.Event, CardType.ItemFinder1),
                new Card(id++, "Item Finder +1", Resources.ItemFinder1, DeckType.Event, CardType.ItemFinder1),
                new Card(id++, "Item Finder +2", Resources.ItemFinder2, DeckType.Event, CardType.ItemFinder2),
                new Card(id++, "Item Finder +2", Resources.ItemFinder2, DeckType.Event, CardType.ItemFinder2),
                new Card(id++, "Item Finder +2", Resources.ItemFinder2, DeckType.Event, CardType.ItemFinder2),
                new Card(id++, "Item Finder +2", Resources.ItemFinder2, DeckType.Event, CardType.ItemFinder2),
                new Card(id++, "Item Finder +2", Resources.ItemFinder2, DeckType.Event, CardType.ItemFinder2),
                new Card(id++, "Item Finder +3", Resources.ItemFinder3, DeckType.Event, CardType.ItemFinder3),
                new Card(id++, "Item Finder +3", Resources.ItemFinder3, DeckType.Event, CardType.ItemFinder3),
                new Card(id++, "Item Finder +3", Resources.ItemFinder3, DeckType.Event, CardType.ItemFinder3),
                new Card(id++, "Challenge", Resources.Challenge, DeckType.Event, CardType.Challenge),
                new Card(id++, "Challenge", Resources.Challenge, DeckType.Event, CardType.Challenge),
                new Card(id++, "Challenge", Resources.Challenge, DeckType.Event, CardType.Challenge),
                new Card(id++, "Challenge", Resources.Challenge, DeckType.Event, CardType.Challenge),
                new Card(id++, "Challenge", Resources.Challenge, DeckType.Event, CardType.Challenge),
                new Card(id++, "Challenge", Resources.Challenge, DeckType.Event, CardType.Challenge),
                new Card(id++, "Trade", Resources.Trade, DeckType.Event, CardType.Trade),
                new Card(id++, "Trade", Resources.Trade, DeckType.Event, CardType.Trade),
                new Card(id++, "Trade", Resources.Trade, DeckType.Event, CardType.Trade),
                new Card(id++, "Trade", Resources.Trade, DeckType.Event, CardType.Trade),
                new Card(id++, "Trade", Resources.Trade, DeckType.Event, CardType.Trade),
                new Card(id++, "Trade", Resources.Trade, DeckType.Event, CardType.Trade),
                new Card(id++, "Investigation", Resources.Investigation, DeckType.Event, CardType.Investigation),
                new Card(id++, "Investigation", Resources.Investigation, DeckType.Event, CardType.Investigation),
                new Card(id++, "Investigation", Resources.Investigation, DeckType.Event, CardType.Investigation),
                new Card(id++, "Investigation", Resources.Investigation, DeckType.Event, CardType.Investigation),
                new Card(id++, "Investigation", Resources.Investigation, DeckType.Event, CardType.Investigation),
                new Card(id++, "Team Rocket", Resources.TeamRocket, DeckType.Event, CardType.TeamRocket),
                new Card(id++, "Team Rocket", Resources.TeamRocket, DeckType.Event, CardType.TeamRocket),
                new Card(id++, "Team Rocket", Resources.TeamRocket, DeckType.Event, CardType.TeamRocket),
                new Card(id++, "Pokemon Center", Resources.PokemonCenter, DeckType.Event, CardType.PokemonCenter),
                new Card(id++, "Pokemon Center", Resources.PokemonCenter, DeckType.Event, CardType.PokemonCenter),
                new Card(id++, "Pokemon Center", Resources.PokemonCenter, DeckType.Event, CardType.PokemonCenter),
                new Card(id++, "Pokemon Center", Resources.PokemonCenter, DeckType.Event, CardType.PokemonCenter),
                new Card(id++, "Pokemon Center", Resources.PokemonCenter, DeckType.Event, CardType.PokemonCenter),
                new Card(id++, "Pokemon Center", Resources.PokemonCenter, DeckType.Event, CardType.PokemonCenter),
                new Card(id++, "Dungeon Of Legends", Resources.DungeonOfLegends, DeckType.Event, CardType.DungeonOfLegends),
                new Card(id++, "Dungeon Of Legends", Resources.DungeonOfLegends, DeckType.Event, CardType.DungeonOfLegends),
                new Card(id++, "Dungeon Of Legends", Resources.DungeonOfLegends, DeckType.Event, CardType.DungeonOfLegends),
                new Card(id++, "Dungeon Of Legends", Resources.DungeonOfLegends, DeckType.Event, CardType.DungeonOfLegends),
                new Card(id++, "Dungeon Of Legends", Resources.DungeonOfLegends, DeckType.Event, CardType.DungeonOfLegends)
            };
        }
    }
}
