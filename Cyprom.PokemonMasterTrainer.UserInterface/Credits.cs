using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    public partial class Credits : Form
    {
        private readonly Home parent;
        private readonly SoundPlayer soundPlayer;

        public Credits(Home parent)
        {
            InitializeComponent();
            this.parent = parent;
            soundPlayer = SoundPlayer.Instance();
            AddSoundEvents();
        }

        private void AddSoundEvents()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.MouseEnter += EnterSoundEvent;
                button.Click += ClickSoundEvent;
            }
        }

        private void Credits_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            parent.Enabled = true;
            parent.Show();
        }

        private void BackButton_Click(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Hover", false), false);
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Click", false), false);
        }
    }
}
