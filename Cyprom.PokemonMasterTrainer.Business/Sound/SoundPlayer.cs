using System;

namespace Cyprom.PokemonMasterTrainer.Business.Sound
{
    public class SoundPlayer : AudioPlayer
    {
        private readonly MusicPlayer musicPlayer;

        private static SoundPlayer instance;

        public static SoundPlayer Instance()
        {
            if (instance == null)
            {
                instance = new SoundPlayer();
            }
            return instance;
        }

        private SoundPlayer()
        {
            musicPlayer = MusicPlayer.Instance();
            Volume = configurationManager.SoundVolume;
        }

        public void Play(Uri audioFile, bool pauseMusic)
        {
            if (configurationManager.Sound)
            {
                if (pauseMusic)
                {
                    musicPlayer.Pause();
                }
                HardPlay(audioFile);
            }
        }

        public void Stop()
        {
            mediaPlayer.Stop();
            musicPlayer.Continue();
        }

        protected override void AudioEnded(object sender, EventArgs eventArgs)
        {
            musicPlayer.Continue();
        }
    }
}
