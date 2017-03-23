using System;
using System.Drawing;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class ResolutionSelection : Form
    {
        private readonly Options parent;
        private SoundPlayer soundPlayer;
        private readonly bool soundsEnabled;

        public ResolutionSelection(Options parent, WindowSize currentResolution, bool soundsEnabled)
        {
            InitializeComponent();
            this.parent = parent;
            this.soundsEnabled = soundsEnabled;
            switch (currentResolution)
            {
                case WindowSize.Tiny: TinyLabel.ForeColor = Color.OrangeRed;
                    break;
                case WindowSize.Small: SmallLabel.ForeColor = Color.OrangeRed;
                    break;
                case WindowSize.Normal: NormalLabel.ForeColor = Color.OrangeRed;
                    break;
                case WindowSize.Large: LargeLabel.ForeColor = Color.OrangeRed;
                    break;
                case WindowSize.Huge: HugeLabel.ForeColor = Color.OrangeRed;
                    break;
                case WindowSize.FullScreen: FullScreenLabel.ForeColor = Color.OrangeRed;
                    break;
            }
        }

        private void ResolutionSelection_Load(object sender, EventArgs eventArgs)
        {
            soundPlayer = SoundPlayer.Instance();
            TinyLabel.Text = TechnicalConstants.TINY_RESOLUTION;
            SmallLabel.Text = TechnicalConstants.SMALL_RESOLUTION;
            NormalLabel.Text = TechnicalConstants.NORMAL_RESOLUTION;
            LargeLabel.Text = TechnicalConstants.LARGE_RESOLUTION;
            HugeLabel.Text = TechnicalConstants.HUGE_RESOLUTION;
            FullScreenLabel.Text = TechnicalConstants.FULL_SCREEN_RESOLUTION;
            TinyLabel.Tag = WindowSize.Tiny;
            SmallLabel.Tag = WindowSize.Small;
            NormalLabel.Tag = WindowSize.Normal;
            LargeLabel.Tag = WindowSize.Large;
            HugeLabel.Tag = WindowSize.Huge;
            FullScreenLabel.Tag = WindowSize.FullScreen;
        }

        private void Label_Click(object sender, EventArgs eventArgs)
        {
            if (soundsEnabled)
            {
                soundPlayer.HardPlay(LoadFacade.BuildUri("Click", false));
            }
            parent.SetResolution((WindowSize)((Label)sender).Tag);
            Close();
        }

        private void Label_MouseEnter(object sender, EventArgs eventArgs)
        {
            if (soundsEnabled)
            {
                soundPlayer.HardPlay(LoadFacade.BuildUri("Hover", false));
            }
            var label = (Label)sender;
            if (label.ForeColor != Color.OrangeRed)
            {
                label.ForeColor = Color.BlueViolet;
            }
        }

        private void Label_MouseLeave(object sender, EventArgs eventArgs)
        {
            var label = (Label)sender;
            if (label.ForeColor != Color.OrangeRed)
            {
                label.ForeColor = Color.Black;
            }
        }

        private void ResolutionSelection_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            parent.Enabled = true;
            parent.Show();
        }
    }
}
