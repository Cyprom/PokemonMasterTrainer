using System;
using System.Drawing;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class SpeedSelection : Form
    {
        private readonly Options parent;
        private SoundPlayer soundPlayer;
        private readonly bool soundsEnabled;

        public SpeedSelection(Options parent, Speed currentSpeed, bool soundsEnabled)
        {
            InitializeComponent();
            this.parent = parent;
            this.soundsEnabled = soundsEnabled;
            switch (currentSpeed)
            {
                case Speed.Slow: SlowLabel.ForeColor = Color.OrangeRed;
                    break;
                case Speed.Normal: NormalLabel.ForeColor = Color.OrangeRed;
                    break;
                case Speed.Fast: FastLabel.ForeColor = Color.OrangeRed;
                    break;
            }
        }

        private void SpeedSelection_Load(object sender, EventArgs eventArgs)
        {
            soundPlayer = SoundPlayer.Instance();
            SlowLabel.Text = TechnicalConstants.SPEED_SLOW;
            NormalLabel.Text = TechnicalConstants.SPEED_NORMAL;
            FastLabel.Text = TechnicalConstants.SPEED_FAST;
            SlowLabel.Tag = Speed.Slow;
            NormalLabel.Tag = Speed.Normal;
            FastLabel.Tag = Speed.Fast;
        }

        private void Label_Click(object sender, EventArgs eventArgs)
        {
            if (soundsEnabled)
            {
                soundPlayer.HardPlay(LoadFacade.BuildUri("Click", false));
            }
            parent.SetSpeed((Speed)((Label)sender).Tag);
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

        private void SpeedSelection_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            parent.Enabled = true;
            parent.Show();
        }
    }
}
