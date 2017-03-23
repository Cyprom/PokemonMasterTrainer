using Cyprom.PokemonMasterTrainer.Business.Properties;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Business.Managers
{
    public class ConfigurationManager
    {
        private static ConfigurationManager instance;

        public bool Music { get; set; }
        public bool Sound { get; set; }
        public int MusicVolume { get; set; }
        public int SoundVolume { get; set; }
        public Speed Speed { get; set; }
        public bool ScreenLock { get; set; }
        public bool AutoSave { get; set; }
        public bool Log { get; set; }
        public WindowSize WindowSize { get; set; }
        public BoardBackground BoardBackground { get; set; }

        public int AISpeed
        {
            get
            {
                switch (Speed)
                {
                    case Speed.Slow: return TechnicalConstants.AI_SLOW;
                    case Speed.Fast: return TechnicalConstants.AI_FAST;
                    default: return TechnicalConstants.AI_NORMAL;
                }
            }
        }

        public static ConfigurationManager Instance()
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }

        private ConfigurationManager()
        {
            Music = Settings.Default.Music;
            Sound = Settings.Default.Sound;
            MusicVolume = Settings.Default.MusicVolume;
            SoundVolume = Settings.Default.SoundVolume;
            Speed = (Speed)Settings.Default.Speed;
            ScreenLock = Settings.Default.ScreenLock;
            AutoSave = Settings.Default.AutoSave;
            Log = Settings.Default.Log;
            WindowSize = (WindowSize)Settings.Default.Resolution;
            BoardBackground = (BoardBackground)Settings.Default.BoardBackground;
        }

        public void SaveConfiguration()
        {
            Settings.Default.Music = Music;
            Settings.Default.Sound = Sound;
            Settings.Default.MusicVolume = MusicVolume;
            Settings.Default.SoundVolume = SoundVolume;
            Settings.Default.Speed = (int)Speed;
            Settings.Default.ScreenLock = ScreenLock;
            Settings.Default.AutoSave = AutoSave;
            Settings.Default.Log = Log;
            Settings.Default.Resolution = (int)WindowSize;
            Settings.Default.BoardBackground = (int)BoardBackground;
            Settings.Default.Save();
        }
    }
}
