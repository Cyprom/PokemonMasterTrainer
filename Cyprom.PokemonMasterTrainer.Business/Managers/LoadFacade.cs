using System;
using System.Collections.Generic;
using System.Drawing;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data.Loaders;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Business.Managers
{
    public static class LoadFacade
    {
        public static List<Uri> LoadSongs()
        {
            return AudioLoader.LoadSongs();
        }

        public static Uri BuildUri(string fileName, bool music)
        {
            return AudioLoader.BuildUri(fileName, music);
        }

        public static Tuple<Image, Color> LoadBackground(BoardBackground type)
        {
            return BackgroundLoader.LoadBackground(type);
        }

        public static List<Card> LoadItems()
        {
            return CardLoader.LoadItems();
        }

        public static List<Card> LoadEvents()
        {
            return CardLoader.LoadEvents();
        }

        public static List<Chip> LoadChips(Rarity rarity)
        {
            return ChipLoader.LoadChips(rarity);
        }

        public static List<Elite> LoadElites()
        {
            return EliteLoader.LoadElites();
        }

        public static List<EvolutionTree> LoadEvolutions()
        {
            return EvolutionLoader.LoadEvolutions();
        }

        public static List<Point> LoadLegendaryLocations()
        {
            return LocationLoader.LoadLegendaryLocations();
        }

        public static Point LoadEliteLocation()
        {
            return LocationLoader.LoadEliteLocation();
        }

        public static OptionImage LoadMusicOptionImage(bool isOn)
        {
            return OptionImageLoader.LoadMusicOptionImage(isOn);
        }

        public static OptionImage LoadSoundOptionImage(bool isOn)
        {
            return OptionImageLoader.LoadSoundOptionImage(isOn);
        }

        public static OptionImage LoadScreenLockOptionImage(bool isOn)
        {
            return OptionImageLoader.LoadScreenLockOptionImage(isOn);
        }

        public static OptionImage LoadAutoSaveOptionImage(bool isOn)
        {
            return OptionImageLoader.LoadAutoSaveOptionImage(isOn);
        }

        public static OptionImage LoadLogOptionImage(bool isOn)
        {
            return OptionImageLoader.LoadLogOptionImage(isOn);
        }

        public static Tuple<List<Space>, Space, Space, Space> LoadSpaces()
        {
            return SpaceLoader.LoadSpaces();
        }

        public static Trainer LoadAsh()
        {
            return TrainerLoader.LoadAsh();
        }

        public static Trainer LoadMisty()
        {
            return TrainerLoader.LoadMisty();
        }

        public static Trainer LoadBrock()
        {
            return TrainerLoader.LoadBrock();
        }
    }
}
