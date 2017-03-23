using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Enums;
using Cyprom.PokemonMasterTrainer.UserInterface.Popups;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    public partial class Options : Form
    {
        private readonly Home parent;
        private readonly ConfigurationManager configurationManager;
        private readonly MusicPlayer musicPlayer;
        private readonly SoundPlayer soundPlayer;

        private readonly OptionImage musicOption;
        private readonly OptionImage soundOption;
        private readonly OptionImage screenLockOption;
        private readonly OptionImage autoSaveOption;
        private readonly OptionImage logOption;
        private readonly int musicVolume;
        private readonly int soundVolume;
        private WindowSize windowSize;
        private Speed speed;
        private BoardBackground background;

        public Options(Home parent)
        {
            InitializeComponent();
            this.parent = parent;
            configurationManager = ConfigurationManager.Instance();
            musicPlayer = MusicPlayer.Instance();
            soundPlayer = SoundPlayer.Instance();
            musicOption = LoadFacade.LoadMusicOptionImage(configurationManager.Music);
            soundOption = LoadFacade.LoadSoundOptionImage(configurationManager.Sound);
            screenLockOption = LoadFacade.LoadScreenLockOptionImage(configurationManager.ScreenLock);
            autoSaveOption = LoadFacade.LoadAutoSaveOptionImage(configurationManager.AutoSave);
            logOption = LoadFacade.LoadLogOptionImage(configurationManager.Log);
            musicVolume = musicPlayer.Volume;
            soundVolume = soundPlayer.Volume;
            windowSize = configurationManager.WindowSize;
            speed = configurationManager.Speed;
            background = configurationManager.BoardBackground;
        }

        private void AddSoundEvents()
        {
            foreach (var control in Controls)
            {
                var button = control as Button;
                if (button != null)
                {
                    button.MouseEnter += EnterSoundEvent;
                    button.Click += ClickSoundEvent;
                }
                var optionImage = control as OptionImage;
                if (optionImage != null)
                {
                    optionImage.MouseEnter += EnterSoundEvent;
                    optionImage.Click += ClickSoundEvent;
                }
            }
        }

        private void Options_Load(object sender, EventArgs eventArgs)
        {
            musicOption.Location = new Point(TechnicalConstants.OPTION_IMAGE_OFFSET, 5);
            musicOption.Click += MusicOption_Click;
            soundOption.Location = new Point(TechnicalConstants.OPTION_IMAGE_OFFSET, 70);
            screenLockOption.Location = new Point(TechnicalConstants.OPTION_IMAGE_OFFSET, 135);
            autoSaveOption.Location = new Point(TechnicalConstants.OPTION_IMAGE_OFFSET, 200);
            logOption.Location = new Point(TechnicalConstants.OPTION_IMAGE_OFFSET, 265);
            Controls.Add(musicOption);
            Controls.Add(soundOption);
            Controls.Add(screenLockOption);
            Controls.Add(autoSaveOption);
            Controls.Add(logOption);
            SetResolutionLabel(windowSize);
            SetSpeedLabel(speed);
            SetBackgroundPicture(background);
            MusicVolumeSlider.Value = configurationManager.MusicVolume;
            MusicVolumeLabel.Text = configurationManager.MusicVolume.ToString();
            SoundVolumeSlider.Value = configurationManager.SoundVolume;
            SoundVolumeLabel.Text = configurationManager.SoundVolume.ToString();
            AddSoundEvents();
        }

        private void MusicOption_Click(object sender, EventArgs eventArgs)
        {
            musicPlayer.Stop();
        }

        private void ResolutionSelectionLabel_Click(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
            var popup = new ResolutionSelection(this, windowSize, soundOption.IsOn);
            popup.Show();
            Enabled = false;
        }

        private void SpeedSelectionLabel_Click(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
            var popup = new SpeedSelection(this, speed, soundOption.IsOn);
            popup.Show();
            Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
            configurationManager.Music = musicOption.IsOn;
            configurationManager.Sound = soundOption.IsOn;
            configurationManager.MusicVolume = MusicVolumeSlider.Value;
            configurationManager.SoundVolume = SoundVolumeSlider.Value;
            configurationManager.ScreenLock = screenLockOption.IsOn;
            configurationManager.AutoSave = autoSaveOption.IsOn;
            configurationManager.Log = logOption.IsOn;
            configurationManager.WindowSize = windowSize;
            configurationManager.Speed = speed;
            configurationManager.BoardBackground = background;
            configurationManager.SaveConfiguration();
            Close();
        }

        private void ReturnButton_Click(object sender, EventArgs eventArgs)
        {
            musicPlayer.Volume = musicVolume;
            soundPlayer.Volume = soundVolume;
            configurationManager.MusicVolume = musicVolume;
            configurationManager.SoundVolume = soundVolume;
            Close();
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            parent.Enabled = true;
            parent.Show();
        }

        public void SetResolution(WindowSize windowSize)
        {
            this.windowSize = windowSize;
            SetResolutionLabel(windowSize);
        }

        public void SetSpeed(Speed speed)
        {
            this.speed = speed;
            SetSpeedLabel(speed);
        }

        public void SetBoardBackground(BoardBackground background)
        {
            this.background = background;
            SetBackgroundPicture(background);
        }

        private void SetResolutionLabel(WindowSize windowSize)
        {
            switch (windowSize)
            {
                case WindowSize.Tiny: ResolutionSelectionLabel.Text = TechnicalConstants.TINY_RESOLUTION;
                    break;
                case WindowSize.Small: ResolutionSelectionLabel.Text = TechnicalConstants.SMALL_RESOLUTION;
                    break;
                case WindowSize.Normal: ResolutionSelectionLabel.Text = TechnicalConstants.NORMAL_RESOLUTION;
                    break;
                case WindowSize.Large: ResolutionSelectionLabel.Text = TechnicalConstants.LARGE_RESOLUTION;
                    break;
                case WindowSize.Huge: ResolutionSelectionLabel.Text = TechnicalConstants.HUGE_RESOLUTION;
                    break;
                case WindowSize.FullScreen: ResolutionSelectionLabel.Text = TechnicalConstants.FULL_SCREEN_RESOLUTION;
                    break;
            }
        }

        private void SetSpeedLabel(Speed speed)
        {
            switch (speed)
            {
                case Speed.Slow: SpeedSelectionLabel.Text = TechnicalConstants.SPEED_SLOW;
                    break;
                case Speed.Normal: SpeedSelectionLabel.Text = TechnicalConstants.SPEED_NORMAL;
                    break;
                case Speed.Fast: SpeedSelectionLabel.Text = TechnicalConstants.SPEED_FAST;
                    break;
            }
        }

        private void SetBackgroundPicture(BoardBackground background)
        {
            switch (background)
            {
                case BoardBackground.Kanto: BackgroundPicture.BackgroundImage = Properties.Resources.Kanto;
                    break;
                case BoardBackground.GreenCloth: BackgroundPicture.BackgroundImage = Properties.Resources.GreenCloth;
                    break;
                case BoardBackground.BrownDirt: BackgroundPicture.BackgroundImage = Properties.Resources.BrownDirt;
                    break;
                case BoardBackground.BlueBubble: BackgroundPicture.BackgroundImage = Properties.Resources.BlueBubble;
                    break;
                case BoardBackground.RedRug: BackgroundPicture.BackgroundImage = Properties.Resources.RedRug;
                    break;
            }
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            if (soundOption.IsOn)
            {
                soundPlayer.HardPlay(LoadFacade.BuildUri("Hover", false));
            }
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            if (soundOption.IsOn)
            {
                soundPlayer.HardPlay(LoadFacade.BuildUri("Click", false));
            }
        }

        private void MusicVolumeSlider_Scroll(object sender, EventArgs eventArgs)
        {
            musicPlayer.Volume = MusicVolumeSlider.Value;
            MusicVolumeLabel.Text = MusicVolumeSlider.Value.ToString();
        }

        private void SoundVolumeSlider_Scroll(object sender, EventArgs eventArgs)
        {
            soundPlayer.Volume = SoundVolumeSlider.Value;
            SoundVolumeLabel.Text = SoundVolumeSlider.Value.ToString();
        }

        private void BackgroundPicture_Click(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
            var popup = new BackgroundSelection(this, background, soundOption.IsOn);
            popup.Show();
            Enabled = false;
        }
    }
}
