using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public sealed class Elite : TransparentControl
    {
        public string Trainer { get; set; }
        public Dictionary<int, Tuple<string, int>> Team { get; set; }
        public bool Flipped { get; set; }
        public Image FrontSide { get; set; }
        public Image BackSide { get; set; }
        public Tuple<string, int> ActivePokemon { get; set; }

        public Elite(string trainer, Dictionary<int, Tuple<string, int>> team, Image frontSide, Image backSide)
        {
            Trainer = trainer;
            Team = team;
            FrontSide = frontSide;
            BackSide = backSide;
            Cursor = Cursors.Hand;
            Location = new Point(0, 0);
            Size = new Size(TechnicalConstants.ELITE_WIDTH, TechnicalConstants.ELITE_HEIGHT);
            Flipped = false;
            Enabled = false;
            Click += Rival_Click;
        }

        private void Rival_Click(object sender, EventArgs eventArgs)
        {
            if (!Flipped)
            {
                Flipped = true;
                Invalidate();
            }
        }

        protected override Image ImageToDraw()
        {
            return Flipped ? FrontSide : BackSide;
        }

        // Trainer is the unique identifier for an elite
        public override string ToString()
        {
            return Trainer;
        }

    }
}
