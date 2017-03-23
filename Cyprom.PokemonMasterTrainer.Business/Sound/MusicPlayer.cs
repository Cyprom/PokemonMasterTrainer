using System;
using System.Collections.Generic;
using Cyprom.PokemonMasterTrainer.Business.Helpers;
using Cyprom.PokemonMasterTrainer.Business.Managers;

namespace Cyprom.PokemonMasterTrainer.Business.Sound
{
    public class MusicPlayer : AudioPlayer
    {
        public bool ContinuousPlay { get; set; }
        
        private bool paused;
        private readonly List<Uri> songs;

        private static MusicPlayer instance;

        public static MusicPlayer Instance()
        {
            if (instance == null)
            {
                instance = new MusicPlayer();
            }
            return instance;
        }

        private MusicPlayer()
        {
            ContinuousPlay = false;
            paused = false;
            songs = LoadFacade.LoadSongs();
            Volume = configurationManager.MusicVolume;
        }

        protected override void AudioEnded(object sender, EventArgs eventArgs)
        {
            if (configurationManager.Music && ContinuousPlay)
            {
                Play();
            }
        }

        public void Play()
        {
            if (configurationManager.Music)
            {
                HardPlay(GetRandomSong());
            }
        }

        public void Play(Uri audioFile)
        {
            if (configurationManager.Music)
            {
                HardPlay(audioFile);
            }
        }

        public void Pause()
        {
            paused = true;
            mediaPlayer.Pause();
        }

        public void Continue()
        {
            if (paused)
            {
                paused = false;
                if (configurationManager.Music)
                {
                    mediaPlayer.Play();
                }
            }
        }

        public void Stop()
        {
            mediaPlayer.Stop();
        }

        private Uri GetRandomSong()
        {
            return songs[Randomizer.Randomize(songs.Count)];
        }
    }
}
