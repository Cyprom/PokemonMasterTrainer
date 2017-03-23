using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Data.Helpers
{
    public static class ObjectSerializer
    {
        public static string Serialize(List<object> deserialized)
        {
            if (deserialized.Count <= 0)
            {
                return string.Empty;
            }
            var serialized = new StringBuilder();
            foreach (var obj in deserialized)
            {
                if (obj == null)
                {
                    serialized.Append(TechnicalConstants.NULL);
                    serialized.Append(TechnicalConstants.TYPE_OBJECT_DISTINGUISHER);
                    serialized.Append(string.Empty);
                    serialized.Append(TechnicalConstants.LIST_DELIMITER);
                }
                else
                {
                    serialized.Append(obj.GetType());
                    serialized.Append(TechnicalConstants.TYPE_OBJECT_DISTINGUISHER);
                    serialized.Append(obj);
                    serialized.Append(TechnicalConstants.LIST_DELIMITER);
                }
            }
            return serialized.ToString().Substring(0, serialized.Length - 1);
        }

        public static List<object> Deserialize(string serialized, List<Player> players, List<Chip> chips, List<Card> cards, List<Elite> elites)
        {
            if (string.IsNullOrEmpty(serialized))
            {
                return new List<object>();
            }
            return serialized.Split(TechnicalConstants.LIST_DELIMITER)
                .Select(str => str.Split(TechnicalConstants.TYPE_OBJECT_DISTINGUISHER))
                .Select(split => FetchObject(split.First(), split.Last(), players, chips, cards, elites)).ToList();
        }

        private static object FetchObject(string type, string identifier, IEnumerable<Player> players, IEnumerable<Chip> chips, IEnumerable<Card> cards, IEnumerable<Elite> elites)
        {
            // Only the types that are used to load the game are added here. If new parameters are required, add the objects here.
            switch (type)
            {
                case "Cyprom.PokemonMasterTrainer.Domain.Player":
                    return players.Single(player => player.Name == identifier);
                case "Cyprom.PokemonMasterTrainer.Controls.Chip":
                    return chips.Single(chip => chip.Number == int.Parse(identifier));
                case "Cyprom.PokemonMasterTrainer.Controls.Card":
                    return cards.Single(card => card.Id == int.Parse(identifier));
                case "Cyprom.PokemonMasterTrainer.Controls.Elite":
                    return elites.Single(elite => elite.Trainer == identifier);
                case "Cyprom.PokemonMasterTrainer.Enums.DeckType":
                    return Enum.Parse(typeof(DeckType), identifier);
                case TechnicalConstants.NULL:
                    return null;
                default:
                    return Convert.ChangeType(identifier, Type.GetType(type));
            }
        } 
    }
}
