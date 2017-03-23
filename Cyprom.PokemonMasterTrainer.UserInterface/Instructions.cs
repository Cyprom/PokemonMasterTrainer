using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cyprom.PokemonMasterTrainer.UserInterface
{
    public partial class Instructions : Form
    {
        private readonly Home parent;
        private readonly SoundPlayer soundPlayer;

        public Instructions(Home parent)
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

        private void Instructions_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            parent.Enabled = true;
            parent.Show();
        }

        private void Instructions_Load(object sender, EventArgs eventArgs)
        {
            Browser.Url = new Uri(string.Format("file:///{0}/Resources/Html/Instructions.html", Directory.GetCurrentDirectory()));
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
