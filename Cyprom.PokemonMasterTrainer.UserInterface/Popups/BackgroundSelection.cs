using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class BackgroundSelection : Form
    {
        private readonly Options parent;
        private readonly SoundPlayer soundPlayer;
        private readonly bool soundsEnabled;

        public BackgroundSelection(Options parent, BoardBackground background, bool soundsEnabled)
        {
            InitializeComponent();
            this.parent = parent;
            soundPlayer = SoundPlayer.Instance();
            this.soundsEnabled = soundsEnabled;
            AddSoundEvents();
            switch (background)
            {
                case BoardBackground.Kanto: KantoLabel.ForeColor = Color.OrangeRed;
                    break;
                case BoardBackground.GreenCloth: GreenClothLabel.ForeColor = Color.OrangeRed;
                    break;
                case BoardBackground.BrownDirt: BrownDirtLabel.ForeColor = Color.OrangeRed;
                    break;
                case BoardBackground.BlueBubble: BlueBubbleLabel.ForeColor = Color.OrangeRed;
                    break;
                case BoardBackground.RedRug: RedRugLabel.ForeColor = Color.OrangeRed;
                    break;
            }
            KantoPicture.Tag = (int)BoardBackground.Kanto;
            GreenClothPicture.Tag = (int)BoardBackground.GreenCloth;
            BrownDirtPicture.Tag = (int)BoardBackground.BrownDirt;
            BlueBubblePicture.Tag = (int)BoardBackground.BlueBubble;
            RedRugPicture.Tag = (int)BoardBackground.RedRug;
        }

        private void AddSoundEvents()
        {
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                pictureBox.MouseEnter += EnterSoundEvent;
                pictureBox.Click += ClickSoundEvent;
            }
        }

        private void Picture_Click(object sender, EventArgs eventArgs)
        {
            parent.SetBoardBackground((BoardBackground)((PictureBox)sender).Tag);
            Close();
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            if (soundsEnabled)
            {
                soundPlayer.HardPlay(LoadFacade.BuildUri("Hover", false));
            }
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            if (soundsEnabled)
            {
                soundPlayer.HardPlay(LoadFacade.BuildUri("Click", false));
            }
        }

        private void BackgroundSelection_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            parent.Enabled = true;
            parent.Show();
        }
    }
}
