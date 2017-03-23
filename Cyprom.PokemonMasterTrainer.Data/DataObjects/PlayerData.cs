using System;
using System.Collections.Generic;
using System.Linq;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Data.DataObjects
{
    public class PlayerData
    {
        public string Name { get; set; }
        public string Trainer { get; set; }
        public List<int> Pokemon { get; set; }
        public List<int> Cards { get; set; }
        public SortType SortType { get; set; }
        public SortKey SortKey { get; set; }
        public bool OnCinnabarIsland { get; set; }
        public bool UnderInvestigation { get; set; }
        public bool Flying { get; set; }
        public int ActivePokemon { get; set; }
        public List<int> VisitedPlaces { get; set; }
        public PlayerType PlayerType { get; set; }
        public int Space { get; set; }

        public PlayerData(object name, object trainer, object pokemon, object cards, object sortType,
            object sortKey, object onCinnabarIsland, object underInvestigation, object flying, object activePokemon,
            object visitedPlaces, object playerType, object space)
        {
            Name = (string)name;
            Trainer = (string)trainer;
            Pokemon = string.IsNullOrWhiteSpace((string)pokemon) ? new List<int>() : ((string)pokemon).Split(TechnicalConstants.LIST_DELIMITER).Select(int.Parse).ToList();
            Cards = string.IsNullOrWhiteSpace((string)cards) ? new List<int>() : ((string)cards).Split(TechnicalConstants.LIST_DELIMITER).Select(int.Parse).ToList();
            SortType = (SortType)sortType;
            SortKey = (SortKey)sortKey;
            OnCinnabarIsland = (bool)onCinnabarIsland;
            UnderInvestigation = (bool)underInvestigation;
            Flying = (bool)flying;
            ActivePokemon = activePokemon.GetType() != typeof(DBNull) ? (int)activePokemon : -1;
            VisitedPlaces = string.IsNullOrWhiteSpace((string)visitedPlaces) ? new List<int>() : ((string)visitedPlaces).Split(TechnicalConstants.LIST_DELIMITER).Select(int.Parse).ToList();
            PlayerType = (PlayerType)playerType;
            Space = space.GetType() != typeof(DBNull) ? (int)space : -1;
        }
    }
}
