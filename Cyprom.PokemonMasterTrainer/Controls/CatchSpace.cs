using System.Drawing;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public class CatchSpace : Space
    {
        private readonly Point chipLocation;
        private Chip chip;

        public CatchSpace(int id, Image picture, SpaceType spaceType, Rarity color, int horizontalPosition, int verticalPosition, int chipHorizontalPosition, int chipVerticalPosition)
            : base(id, picture, spaceType, color, horizontalPosition, verticalPosition)
        {
            chipLocation = new Point(chipHorizontalPosition, chipVerticalPosition);
        }

        public Chip AdjacentChip
        {
            get
            {
                return chip;
            }
            set
            {
                if (chip != null)
                {
                    chip.AdjacentSpace = null;
                }
                chip = value;
                chip.Location = chipLocation;
                chip.AdjacentSpace = this;
            }
        }
    }
}
