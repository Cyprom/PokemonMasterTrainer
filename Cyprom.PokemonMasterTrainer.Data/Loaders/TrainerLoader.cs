using System.Collections.Generic;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data.Properties;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class TrainerLoader
    {
        public static List<Trainer> LoadTrainers()
        {
            return new List<Trainer>
            {
                LoadAsh(),
                LoadMisty(),
                LoadBrock()
            };
        }

        public static Trainer LoadAsh()
        {
            return new Trainer(TechnicalConstants.ASH, Resources.Ash);
        }

        public static Trainer LoadMisty()
        {
            return new Trainer(TechnicalConstants.MISTY, Resources.Misty);
        }

        public static Trainer LoadBrock()
        {
            return new Trainer(TechnicalConstants.BROCK, Resources.Brock);
        }
    }
}
