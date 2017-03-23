using System.Drawing;

namespace Cyprom.PokemonMasterTrainer.Data.DataObjects
{
    public class TrainerData
    {
        public string DefaultName { get; set; }
        public Point Location { get; set; }

        public TrainerData(object defaultName, object x, object y)
        {
            DefaultName = (string)defaultName;
            Location = new Point((int)x, (int)y);
        }
    }
}
