using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cyprom.PokemonMasterTrainer.Business.Helpers;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Business.Managers
{
    public static class ArtificialIntelligence
    {

        #region Message replies

        public static bool UsePotion(Player player)
        {
            var potion = player.Items.FirstOrDefault(item => item.CardType == CardType.Potion);
            return potion != null && player.HasKnockedOutPokemon;
        }

        public static bool UseFly(Player player)
        {
            if (player.Space.Id >= 76 && !TakeRevivalChallenge(player))
            {
                return false;
            }
            var fly = player.Items.FirstOrDefault(item => item.CardType == CardType.Fly);
            if (fly != null)
            {
                if (player.Items.Count >= 7 && player.VisitedPlaces.Any())
                {
                    return true;
                }
                if (player.PowerPoints >= 20 && player.VisitedPlaces.Any(place => place.CityName == "Cinnabar Island"))
                {
                    return true;
                }
                if (TakeRevivalChallenge(player) && (player.VisitedPlaces.Any(place => place.CityName == "Vermilion City") || player.VisitedPlaces.Any(place => place.CityName == "Cerulean City")))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool UseAttackBonus(Player player, Player other)
        {
            if (other == null || player.Items.Count >= 7)
            {
                return true;
            }
            return other.ActivePokemon.Damage - player.ActivePokemon.Damage >= 3
                && player.Items.Any(item =>
                    item.CardType == CardType.AttackBonus1
                    || item.CardType == CardType.AttackBonus2
                    || item.CardType == CardType.AttackBonus3
                    || item.CardType == CardType.AttackBonus4);
        }

        public static bool UseSpecialBall(Player player, Chip pokemon)
        {
            if (player.Items.Count >= 7
                && (player.Items.Any(item => item.CardType == CardType.GreatBall) || player.Items.Any(item => item.CardType == CardType.UltraBall))
                && !pokemon.CatchRate.Contains(1))
            {
                return true;
            }
            if (player.Items.Any(item => item.CardType == CardType.MasterBall) && pokemon.Rarity == Rarity.Yellow)
            {
                return true;
            }
            var completers = EvolutionLineCompleters(player.Pokemon);
            if (player.Items.Any(item => item.CardType == CardType.UltraBall) && (pokemon.Rarity == Rarity.Red || completers.Contains(pokemon.Number)))
            {
                return true;
            }
            return (player.Items.Any(item => item.CardType == CardType.GreatBall)
                    && (pokemon.Rarity == Rarity.Yellow || pokemon.Rarity == Rarity.Red || pokemon.Rarity == Rarity.Blue || completers.Contains(pokemon.Number)));
        }

        public static bool UsePokeDoll(Player player, bool battle)
        {
            if (player.Items.Count >= 7)
            {
                return true;
            }
            if (battle)
            {
                return player.PowerPoints >= 20 && player.PowerPoints - StrongestWithEvolutionBonus(player.Pokemon, false).PowerPoints < 20;
            }
            return player.Pokemon.Any(chip => chip.Pokemon == TechnicalConstants.MEW);
        }

        public static bool TakeRevivalChallenge(Player player)
        {
            if (player.Pokemon.Count > 6)
            {
                return player.Pokemon.Count(chip => chip.KnockedOut) > 3;
            }
            return player.Pokemon.Count(chip => chip.KnockedOut) >= 3;
        }

        public static bool GoToIndigoPlateau(Player player)
        {
            return StrongestWithEvolutionBonus(player.Pokemon, false).Damage > 8 && player.HasAttackBonus;
        }

        public static bool ConfirmUsage()
        {
            return true;
        }

        #endregion

        #region Selections

        public static Chip SelectStarter(List<Chip> starters)
        {
            return starters[Randomizer.Randomize(starters.Count)];
        }

        public static Player SelectTarget(Player player, List<Player> others, bool battle)
        {
            if (battle)
            {
                return StrongestWithEvolutionBonus(others.First().Pokemon, false).Damage > StrongestWithEvolutionBonus(others.Last().Pokemon, false).Damage
                       ? others.First()
                       : others.Last();
            }
            var firstLeft = SelectTradeChip(player, others.First(), true);
            var firstRight = SelectTradeChip(player, others.First(), false);
            var lastLeft = SelectTradeChip(player, others.Last(), true);
            var lastRight = SelectTradeChip(player, others.Last(), false);
            if (firstRight.Damage - firstLeft.Damage > lastRight.Damage - lastLeft.Damage)
            {
                return others.First();
            }
            if (firstRight.Damage - firstLeft.Damage < lastRight.Damage - lastLeft.Damage)
            {
                return others.Last();
            }
            if (firstRight.PowerPoints - firstLeft.PowerPoints > lastRight.PowerPoints - lastLeft.PowerPoints)
            {
                return others.First();
            }
            if (firstRight.PowerPoints - firstLeft.PowerPoints < lastRight.PowerPoints - lastLeft.PowerPoints)
            {
                return others.Last();
            }
            return others[Randomizer.Randomize(others.Count(other => other.PlayerType == PlayerType.Human))];
        }

        public static Chip SelectBattleChip(Player player)
        {
            return StrongestWithEvolutionBonus(player.Pokemon, false);
        }

        public static Chip SelectTradeChip(Player challenger, Player target, bool first)
        {
            if (first)
            {
                var rarity = SelectTradeChip(challenger, target, false).Rarity;
                var ordered = challenger.Pokemon.Where(chip => chip.Rarity == rarity).OrderBy(chip => chip.Damage).ThenBy(chip => chip.PowerPoints).ToList();
                foreach (var loss in ordered.Where(loss => !EvolutionLineCompleters(ordered.Where(chip => chip != loss).ToList()).Contains(loss.Number)))
                {
                    return loss;
                }
                return ordered.First();
            }
            var rarities = challenger.Pokemon.Select(chip => chip.Rarity).Distinct().Intersect(target.Pokemon.Select(chip => chip.Rarity).Distinct()).ToList();
            rarities.Remove(Rarity.Starter);
            var completers = EvolutionLineCompleters(challenger.Pokemon);
            var evolutionChips = target.Pokemon.Where(chip => completers.Contains(chip.Number)).ToList();
            return evolutionChips.Any() ? evolutionChips.OrderByDescending(chip => chip.Damage).ThenByDescending(chip => chip.PowerPoints).First() : target.Pokemon.Where(chip => rarities.Contains(chip.Rarity)).OrderByDescending(chip => chip.Damage).First();
        }

        public static Chip SelectRevivalChip(Player player)
        {
            return StrongestWithEvolutionBonus(player.Pokemon, true);
        }

        public static Card SelectAttackBonus(Player player, Player other)
        {
            Card bonus;
            if (other == null)
            {
                bonus = player.Items.FirstOrDefault(item => item.CardType == CardType.AttackBonus5);
                if (bonus != null)
                {
                    return bonus;
                }
                bonus = player.Items.FirstOrDefault(item => item.CardType == CardType.AttackBonus4);
                if (bonus != null)
                {
                    return bonus;
                }
                bonus = player.Items.FirstOrDefault(item => item.CardType == CardType.AttackBonus3);
                if (bonus != null)
                {
                    return bonus;
                }
                bonus = player.Items.FirstOrDefault(item => item.CardType == CardType.AttackBonus2);
                return bonus ?? player.Items.First(item => item.CardType == CardType.AttackBonus1);
            }
            bonus = player.Items.FirstOrDefault(item => item.CardType == CardType.AttackBonus1);
            if (bonus != null)
            {
                return bonus;
            }
            bonus = player.Items.FirstOrDefault(item => item.CardType == CardType.AttackBonus2);
            if (bonus != null)
            {
                return bonus;
            }
            bonus = player.Items.FirstOrDefault(item => item.CardType == CardType.AttackBonus3);
            if (bonus != null)
            {
                return bonus;
            }
            bonus = player.Items.FirstOrDefault(item => item.CardType == CardType.AttackBonus4);
            return bonus ?? player.Items.First(item => item.CardType == CardType.AttackBonus5);
        }

        public static Card SelectSpecialBall(Player player, Chip pokemon)
        {
            var ball = player.Items.FirstOrDefault(item => item.CardType == CardType.MasterBall);
            if (ball != null && pokemon.Rarity == Rarity.Yellow)
            {
                return ball;
            }
            ball = player.Items.FirstOrDefault(item => item.CardType == CardType.UltraBall);
            if (ball != null && pokemon.Rarity == Rarity.Red)
            {
                return ball;
            }
            ball = player.Items.FirstOrDefault(item => item.CardType == CardType.GreatBall);
            return ball ?? player.Items.FirstOrDefault(item => item.CardType == CardType.UltraBall);
        }

        public static Card SelectCard(Player player, CardType cardType)
        {
            return player.Items.FirstOrDefault(card => card.CardType == cardType);
        }

        public static Card SelectDiscard(Player player)
        {
            var grouped = player.Items.GroupBy(item => item.CardType);
            var type = grouped.OrderByDescending(group => group.Count()).ThenBy(group => ItemImportance(group.Key)).First().Key;
            return player.Items.First(item => item.CardType == type);
        }

        public static Chip Catch(Player player, List<Chip> legendaries)
        {
            var flippedMew = legendaries.SingleOrDefault(legendary => legendary.Flipped && legendary.Number == 151);
            return flippedMew ?? legendaries[Randomizer.Randomize(legendaries.Count)];
        }

        public static Chip Catch(Player player, List<Chip> chips, Rarity color)
        {
            var flipped = chips.Where(chip => chip.Flipped).ToList();
            var unflipped = chips.Where(chip => !chip.Flipped).ToList();
            if (flipped.Any())
            {
                var completers = EvolutionLineCompleters(player.Pokemon);
                var evolutionSpaces = flipped.Where(chip => completers.Contains(chip.Number)).ToList();
                if (evolutionSpaces.Any())
                {
                    return evolutionSpaces.OrderByDescending(chip => chip.Damage).First();
                }
                if (!unflipped.Any())
                {
                    return flipped.OrderByDescending(chip => chip.Damage).First();
                }
                int max;
                switch (color)
                {
                    case Rarity.Green: max = 5;
                        break;
                    case Rarity.Blue: max = 7;
                        break;
                    case Rarity.Red: max = 8;
                        break;
                    default: max = 3;
                        break;
                }
                var withMaxDamage = flipped.Where(chip => chip.Damage >= max).ToList();
                if (withMaxDamage.Any())
                {
                    return withMaxDamage[Randomizer.Randomize(withMaxDamage.Count)];
                }
            }
            return unflipped[Randomizer.Randomize(unflipped.Count)];
        }

        public static CityTown FlyTo(Player player)
        {
            var cinnabarIsland = player.VisitedPlaces.SingleOrDefault(place => place.CityName == "Cinnabar Island");
            if (player.PowerPoints >= 20 && cinnabarIsland != null && GoToIndigoPlateau(player))
            {
                var current = player.Space as CityTown;
                if (current != null && current.CityName != "Cinnabar Island")
                {
                    return cinnabarIsland;
                }
            }
            var pokemonCenter = player.VisitedPlaces.SingleOrDefault(place => place.CityName == "Vermilion City");
            if (pokemonCenter != null)
            {
                return pokemonCenter;
            }
            pokemonCenter = player.VisitedPlaces.SingleOrDefault(place => place.CityName == "Cerulean City");
            return pokemonCenter ?? player.VisitedPlaces.Where(place => place.CityName != "Cinnabar Island").OrderByDescending(place => place.Id).First();
        }

        public static Space Move(Player player, List<Space> availableSpaces)
        {
            if (availableSpaces.Count == 1)
            {
                return availableSpaces.First();
            }
            var cinnabarIsland = availableSpaces.SingleOrDefault(space => space is CityTown && ((CityTown)space).CityName == "Cinnabar Island");
            if (player.PowerPoints >= 20 && cinnabarIsland != null && GoToIndigoPlateau(player))
            {
                return cinnabarIsland;
            }
            var cityTowns = availableSpaces.Where(space => space is CityTown && ((CityTown)space).CityName != "Cinnabar Island" && ((CityTown)space).CityName != "Pallet Town").ToList();
            if (cityTowns.Any())
            {
                if (cityTowns.Any(space => space.SpaceType == SpaceType.Revive) && TakeRevivalChallenge(player))
                {
                    return cityTowns.OrderByDescending(space => space.Id).First(space => space.SpaceType == SpaceType.Revive);
                }
                if (cityTowns.Any(space => space.SpaceType != SpaceType.Revive) && player.Items.Count < 5)
                {
                    return cityTowns.OrderByDescending(space => space.Id).First(space => space.SpaceType != SpaceType.Revive);
                }
            }
            if (player.PowerPoints < 20)
            {
                var catchSpaces = availableSpaces.Where(space => space is CatchSpace && ((CatchSpace)space).AdjacentChip != null).ToList();
                if (catchSpaces.Any())
                {
                    var completers = EvolutionLineCompleters(player.Pokemon);
                    var evolutionSpaces = catchSpaces.Where(space => completers.Contains(((CatchSpace)space).AdjacentChip.Number)).ToList();
                    return evolutionSpaces.Any() ? evolutionSpaces.OrderByDescending(space => space.Id).First() : catchSpaces.OrderByDescending(space => space.Id).First();
                }
            }
            return availableSpaces.Where(space => !(space is CityTown)).OrderByDescending(space => space.Id).First();
        }

        #endregion

        #region Helpers

        private static List<int> EvolutionLineCompleters(List<Chip> pokemon)
        {
            var completers = new List<int>();
            var evolutions = pokemon.Select(chip => GameManager.Instance().EvolutionTree(chip)).Where(tree => tree != null);
            var singleMissing = evolutions.Where(tree => tree.Size > 2).GroupBy(tree => tree.Id).Where(group => group.Count() == 2);
            foreach (var group in singleMissing)
            {
                var tree = group.First();
                var missing = pokemon.SingleOrDefault(chip => chip.Number == tree.First);
                if (missing == null)
                {
                    completers.Add(tree.First);
                }
                else
                {
                    missing = pokemon.SingleOrDefault(chip => chip.Number == tree.Second);
                    if (missing == null)
                    {
                        completers.Add(tree.Second);
                    }
                    else if (tree.Third.HasValue)
                    {
                        completers.Add(tree.Third.Value);
                    }
                }
            }
            return completers;
        }

        private static Chip StrongestWithEvolutionBonus(List<Chip> pokemon, bool knockedOut)
        {
            return pokemon.Where(chip => chip.KnockedOut == knockedOut)
                .Select(chip => new Tuple<Chip, int>(chip, GameManager.Instance().CalculateEvolutionBonus(chip, pokemon) + chip.Damage))
                .OrderByDescending(tuple => tuple.Item2).First().Item1;
        }

        private static int ItemImportance(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.AttackBonus2: return 1;
                case CardType.Fly: return 2;
                case CardType.PokeDoll: return 3;
                case CardType.AttackBonus3: return 4;
                case CardType.GreatBall: return 5;
                case CardType.Potion: return 6;
                case CardType.UltraBall: return 7;
                case CardType.AttackBonus4: return 8;
                case CardType.MasterBall: return 9;
                case CardType.AttackBonus5: return 10;
                default: return 0;
            }
        }

        public static void Sleep()
        {
            Thread.Sleep(ConfigurationManager.Instance().AISpeed);
        }

        #endregion

    }
}
