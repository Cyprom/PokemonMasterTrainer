using System;
using System.Drawing;
using Cyprom.PokemonMasterTrainer.Data.Properties;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class BackgroundLoader
    {
        public static Tuple<Image, Color> LoadBackground(BoardBackground type)
        {
            switch (type)
            {
                case BoardBackground.GreenCloth: return new Tuple<Image, Color>(Resources.Board_GreenCloth, Color.DarkGreen);
                case BoardBackground.BrownDirt: return new Tuple<Image, Color>(Resources.Board_BrownDirt, Color.Peru);
                case BoardBackground.BlueBubble: return new Tuple<Image, Color>(Resources.Board_BlueBubble, Color.MidnightBlue);
                case BoardBackground.RedRug: return new Tuple<Image, Color>(Resources.Board_RedRug, Color.Maroon);
                default: return new Tuple<Image, Color>(Resources.Board, Color.DarkGoldenrod);
            }
        }
    }
}
