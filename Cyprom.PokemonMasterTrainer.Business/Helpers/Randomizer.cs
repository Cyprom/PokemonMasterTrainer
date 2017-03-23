using System;
using System.Collections.Generic;

namespace Cyprom.PokemonMasterTrainer.Business.Helpers
{
    public static class Randomizer
    {
        private static readonly Random random = new Random();

        public static int Randomize(int maximum)
        {
            return Randomize(0, maximum);
        }

        public static int Randomize(int minimum, int maximum)
        {
            return random.Next(minimum, maximum);
        }

        public static List<T> Shuffle<T>(List<T> list)
        {
            var shuffled = new List<T>();
            while (list.Count > 0)
            {
                var index = Randomize(list.Count);
                shuffled.Add(list[index]);
                list.RemoveAt(index);
            }
            return shuffled;
        }
    }
}
