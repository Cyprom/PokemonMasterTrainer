using Cyprom.PokemonMasterTrainer.Business.Managers;
using System;
using System.Windows.Media;

namespace Cyprom.PokemonMasterTrainer.Business.Sound
{
    public abstract class AudioPlayer
    {
        protected MediaPlayer mediaPlayer;
        protected ConfigurationManager configurationManager;

        protected AudioPlayer()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaEnded += AudioEnded;
            configurationManager = ConfigurationManager.Instance();
        }

        public int Volume
        {
            get
            {
                return (int)(mediaPlayer.Volume * 100);
            }
            set
            {
                mediaPlayer.Volume = ((double)value) / 100;
            }
        }

        protected abstract void AudioEnded(object sender, EventArgs eventArgs);

        public void HardPlay(Uri audioFile)
        {
            mediaPlayer.Stop();
            mediaPlayer.Open(audioFile);
            mediaPlayer.Play();
        }

    }
}
