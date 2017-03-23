using System.Collections.Generic;
using System.Linq;
using Cyprom.PokemonMasterTrainer.Business.Helpers;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data;
using Cyprom.PokemonMasterTrainer.Data.Interfaces;
using Cyprom.PokemonMasterTrainer.Domain;

namespace Cyprom.PokemonMasterTrainer.Business.Managers
{
    public class GameManager
    {
        private static GameManager instance;

        private readonly IRepository gameRepository;
        private readonly List<EvolutionTree> evolutions;

        public static GameManager Instance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }

        private GameManager()
        {
            gameRepository = GameRepository.Instance();
            evolutions = LoadFacade.LoadEvolutions();
        }

        public EvolutionTree EvolutionTree(Chip pokemon)
        {
            return evolutions.SingleOrDefault(tree => tree.PlaceInTree(pokemon.Number) > 0);
        }

        public int CalculateEvolutionBonus(Chip pokemon, List<Chip> team)
        {
            var evolutionTree = evolutions.SingleOrDefault(tree => tree.PlaceInTree(pokemon.Number) > 1);
            if (evolutionTree == null)
            {
                return 0;
            }
            if (evolutionTree.Size == 2)
            {
                if (team.Any(chip => chip.Number == evolutionTree.First))
                {
                    return TechnicalConstants.EVOLUTION_BONUS_TWO_DOUBLE;
                }
            }
            if (evolutionTree.PlaceInTree(pokemon.Number) == 3)
            {
                if (team.Any(chip => chip.Number == evolutionTree.Second))
                {
                    return team.Any(chip => chip.Number == evolutionTree.First)
                        ? TechnicalConstants.EVOLUTION_BONUS_THREE_TRIPLE
                        : TechnicalConstants.EVOLUTION_BONUS_THREE_DOUBLE;
                }
            }
            else
            {
                if (team.Any(chip => chip.Number == evolutionTree.First))
                {
                    return TechnicalConstants.EVOLUTION_BONUS_THREE_DOUBLE;
                }
            }
            return 0;
        }

        public bool SaveGameAvailable()
        {
            return gameRepository.SaveGameAvailable();
        }

        public void SaveGame(BoardState state)
        {
            gameRepository.Save(state);
        }

        public BoardState NewGame()
        {
            var boardState = gameRepository.Load(false);
            boardState.PinkChips = Randomizer.Shuffle(boardState.PinkChips);
            boardState.GreenChips = Randomizer.Shuffle(boardState.GreenChips);
            boardState.BlueChips = Randomizer.Shuffle(boardState.BlueChips);
            boardState.RedChips = Randomizer.Shuffle(boardState.RedChips);
            boardState.YellowChips = Randomizer.Shuffle(boardState.YellowChips);
            boardState.ItemCards = Randomizer.Shuffle(boardState.ItemCards);
            boardState.EventCards = Randomizer.Shuffle(boardState.EventCards);
            boardState.EliteTrainers = Randomizer.Shuffle(boardState.EliteTrainers);
            return boardState;
        }

        public BoardState LoadGame()
        {
            return gameRepository.Load(true);
        }

        public void DeleteSavedGame()
        {
            gameRepository.ClearAll();
        }
    }
}
