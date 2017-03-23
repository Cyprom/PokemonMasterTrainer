using System;
using System.Collections.Generic;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data.Properties;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class EliteLoader
    {
        public static List<Elite> LoadElites()
        {
            return new List<Elite>
            {
                new Elite("Agatha", CreateTeamAgatha(), Resources.Agatha, Resources.Elite),
                new Elite("Bruno", CreateTeamBruno(), Resources.Bruno, Resources.Elite),
                new Elite("Gary", CreateTeamGary(), Resources.Gary, Resources.Elite),
                new Elite("Lance", CreateTeamLance(), Resources.Lance, Resources.Elite),
                new Elite("Lorelei", CreateTeamLorelei(), Resources.Lorelei, Resources.Elite)
            };
        }

        private static Dictionary<int, Tuple<string, int>> CreateTeamAgatha()
        {
            return new Dictionary<int, Tuple<string, int>>
            {
                { 1, new Tuple<string, int>("Golbat", 21) },
                { 2, new Tuple<string, int>("Arbok", 22) },
                { 3, new Tuple<string, int>("Haunter", 23) },
                { 4, new Tuple<string, int>("Vileplume", 24) },
                { 5, new Tuple<string, int>("Gengar", 26) },
                { 6, new Tuple<string, int>("Gengar", 26) }
            };
        }

        private static Dictionary<int, Tuple<string, int>> CreateTeamBruno()
        {
            return new Dictionary<int, Tuple<string, int>>
            {
                { 1, new Tuple<string, int>("Onix", 20) },
                { 2, new Tuple<string, int>("Machoke", 21) },
                { 3, new Tuple<string, int>("Hitmonchan", 22) },
                { 4, new Tuple<string, int>("Hitmonlee", 23) },
                { 5, new Tuple<string, int>("Machamp", 25) },
                { 6, new Tuple<string, int>("Machamp", 25) }
            };
        }

        private static Dictionary<int, Tuple<string, int>> CreateTeamGary()
        {
            return new Dictionary<int, Tuple<string, int>>
            {
                { 1, new Tuple<string, int>("Pidgeot", 23) },
                { 2, new Tuple<string, int>("Exeggutor", 24) },
                { 3, new Tuple<string, int>("Rhydon", 25) },
                { 4, new Tuple<string, int>("Alakazam", 26) },
                { 5, new Tuple<string, int>("Arcanine", 28) },
                { 6, new Tuple<string, int>("Arcanine", 28) }
            };
        }

        private static Dictionary<int, Tuple<string, int>> CreateTeamLance()
        {
            return new Dictionary<int, Tuple<string, int>>
            {
                { 1, new Tuple<string, int>("Gyarados", 22) },
                { 2, new Tuple<string, int>("Dragonair", 23) },
                { 3, new Tuple<string, int>("Aerodactyl", 24) },
                { 4, new Tuple<string, int>("Charizard", 25) },
                { 5, new Tuple<string, int>("Dragonite", 27) },
                { 6, new Tuple<string, int>("Dragonite", 27) }
            };
        }

        private static Dictionary<int, Tuple<string, int>> CreateTeamLorelei()
        {
            return new Dictionary<int, Tuple<string, int>>
            {
                { 1, new Tuple<string, int>("Cloyster", 19) },
                { 2, new Tuple<string, int>("Jynx", 20) },
                { 3, new Tuple<string, int>("Dewgong", 21) },
                { 4, new Tuple<string, int>("Slowbro", 22) },
                { 5, new Tuple<string, int>("Lapras", 24) },
                { 6, new Tuple<string, int>("Lapras", 24) }
            };
        }
    }
}
