using System.Collections.Generic;
using System.Drawing;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class LocationLoader
    {
        public static List<Point> LoadLegendaryLocations()
        {
            return new List<Point>
            {
                new Point(1660, 1205),
                new Point(1820, 1205),
                new Point(1660, 1335),
                new Point(1820, 1335),
                new Point(1740, 1271),
            };
        }

        public static Point LoadEliteLocation()
        {
            return new Point(804, 737);
        }
    }
}
