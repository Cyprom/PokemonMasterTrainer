using System.Drawing;
using System.Linq;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public class CityTown : Space
    {
        private readonly Point trainerLocation1;
        private readonly Point trainerLocation2;
        private readonly Point trainerLocation3;

        public string CityName { get; set; }

        public CityTown(int id, string name, Image picture, SpaceType spaceType, Rarity color, int horizontalPosition, int verticalPosition,
            int horizontalPosition1, int verticalPosition1, int horizontalPosition2, int verticalPosition2, int horizontalPosition3, int verticalPosition3)
            : base(id, picture, spaceType, color, horizontalPosition, verticalPosition)
        {
            CityName = name;
            trainerLocation1 = new Point(horizontalPosition1, verticalPosition1);
            trainerLocation2 = new Point(horizontalPosition2, verticalPosition2);
            trainerLocation3 = new Point(horizontalPosition3, verticalPosition3);
        }

        public override void AddPlayer(Player player)
        {
            player.Trainer.Location = TrainerLocation;
            players.Add(player);
            player.Trainer.Refresh();
        }

        public override void RemovePlayer(Player player)
        {
            players.Remove(player);
            var others = players.ToList();
            players.Clear();
            foreach (var other in others)
            {
                AddPlayer(other);
            }
        }

        private Point TrainerLocation
        {
            get
            {
                switch (Population)
                {
                    case 1: return trainerLocation2;
                    case 2: return trainerLocation3;
                    default: return trainerLocation1;
                }
            }
        }
    }
}
