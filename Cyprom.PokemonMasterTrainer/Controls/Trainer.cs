using System.Drawing;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public class Trainer : TransparentControl
    {
        public string DefaultName { get; set; }
        public Image Face { get; set; }

        public Trainer(string defaultName, Image face)
        {
            DefaultName = defaultName;
            Face = face;
            Location = new Point(0, 0);
            Size = new Size(TechnicalConstants.SPACE_SIZE, TechnicalConstants.SPACE_SIZE);
        }

        protected override Image ImageToDraw()
        {
            return Face;
        }

        // DefaultName is the unique identifier for a trainer
        public override string ToString()
        {
            return DefaultName;
        }

        public Trainer Clone()
        {
            return new Trainer(DefaultName, Face);
        }
    }
}
