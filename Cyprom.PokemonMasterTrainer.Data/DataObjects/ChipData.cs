using System.Drawing;

namespace Cyprom.PokemonMasterTrainer.Data.DataObjects
{
    public class ChipData
    {
        public int Number { get; set; }
        public Point Location { get; set; }
        public bool Flipped { get; set; }
        public bool KnockedOut { get; set; }
        public int BonusDamage { get; set; }
        public bool Clickable { get; set; }

        public ChipData(object number, object x, object y, object flipped, object knockedOut, object bonusDamage, object clickable)
        {
            Number = (int)number;
            Location = new Point((int)x, (int)y);
            Flipped = (bool)flipped;
            KnockedOut = (bool)knockedOut;
            BonusDamage = (int)bonusDamage;
            Clickable = (bool)clickable;
        }
    }
}
