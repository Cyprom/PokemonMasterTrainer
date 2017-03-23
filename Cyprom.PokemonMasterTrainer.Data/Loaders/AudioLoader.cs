using System;
using System.Collections.Generic;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class AudioLoader
    {
        public static List<Uri> LoadSongs()
        {
            return new List<Uri>
            {
                BuildUri("Bicycle", true),
                BuildUri("Caves", true),
                BuildUri("Celadon", true),
                BuildUri("Cerulean_Bridge", true),
                BuildUri("Cerulean_Fuchsia", true),
                BuildUri("Cinnabar", true),
                BuildUri("Final_Road", true),
                BuildUri("Following", true),
                BuildUri("Forest", true),
                BuildUri("Game_Corner", true),
                BuildUri("Ghost_Tower", true),
                BuildUri("Lavender", true),
                BuildUri("Mansion", true),
                BuildUri("Oak_Laboratory", true),
                BuildUri("Pallet_Town", true),
                BuildUri("Poke_Flute", true),
                BuildUri("Pokemon_Center", true),
                BuildUri("Rocket_Hideout", true),
                BuildUri("Routes", true),
                BuildUri("Silph_Co", true),
                BuildUri("SS_Anne", true),
                BuildUri("Surfing", true),
                BuildUri("Vermilion_To_Lavender", true),
                BuildUri("Viridian_Pewter_Saffron", true)
            };
        }

        public static Uri BuildUri(string fileName, bool music)
        {
            var subDirectory = music ? TechnicalConstants.SUBDIRECTORY_MUSIC : TechnicalConstants.SUBDIRECTORY_SOUND;
            return new Uri(string.Format(TechnicalConstants.AUDIO_URI, subDirectory, fileName), UriKind.Relative);
        }
    }
}
