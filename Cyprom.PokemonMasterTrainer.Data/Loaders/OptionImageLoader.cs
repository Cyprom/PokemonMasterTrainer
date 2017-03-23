using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data.Properties;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class OptionImageLoader
    {
        public static OptionImage LoadMusicOptionImage(bool isOn)
        {
            return new OptionImage(TechnicalConstants.OPTION_SIZE, Resources.Music_On, Resources.Music_Off, isOn);
        }

        public static OptionImage LoadSoundOptionImage(bool isOn)
        {
            return new OptionImage(TechnicalConstants.OPTION_SIZE, Resources.Sound_On, Resources.Sound_Off, isOn);
        }

        public static OptionImage LoadScreenLockOptionImage(bool isOn)
        {
            return new OptionImage(TechnicalConstants.OPTION_SIZE, Resources.ScreenLock_On, Resources.ScreenLock_Off, isOn);
        }

        public static OptionImage LoadAutoSaveOptionImage(bool isOn)
        {
            return new OptionImage(TechnicalConstants.OPTION_SIZE, Resources.AutoSave_On, Resources.AutoSave_Off, isOn);
        }

        public static OptionImage LoadLogOptionImage(bool isOn)
        {
            return new OptionImage(TechnicalConstants.OPTION_SIZE, Resources.Log_On, Resources.Log_Off, isOn);
        }
    }
}
