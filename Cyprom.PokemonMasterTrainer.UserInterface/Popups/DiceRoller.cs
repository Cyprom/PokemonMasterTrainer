using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Business.Helpers;
using Cyprom.PokemonMasterTrainer.Business.Managers;
using Cyprom.PokemonMasterTrainer.Business.Sound;
using Cyprom.PokemonMasterTrainer.UserInterface.Helpers;
using Cyprom.PokemonMasterTrainer.UserInterface.Properties;

namespace Cyprom.PokemonMasterTrainer.UserInterface.Popups
{
    public partial class DiceRoller : Form
    {
        private static DiceRoller instance;

        private readonly SoundPlayer soundPlayer;

        private Dictionary<int, Image> dice;

        public bool Bot { get; set; }
        public List<int> IgnoredRolls { get; set; }
        public ReturnResult ReturnFunction { get; set; }
        public delegate void ReturnResult(int result);

        public static DiceRoller Instance()
        {
            if (instance == null)
            {
                instance = new DiceRoller();
            }
            return instance;
        }

        private DiceRoller()
        {
            InitializeComponent();
            Visible = false;
            soundPlayer = SoundPlayer.Instance();
            Bot = false;
            IgnoredRolls = new List<int>();
            LoadDice();
            DicePicture.MouseEnter += EnterSoundEvent;
            DicePicture.Click += ClickSoundEvent;
        }

        private void DicePicture_Click(object sender, EventArgs eventArgs)
        {
            DicePicture.Enabled = false;
            AnimationTimer.Enabled = true;
        }

        private void LoadDice()
        {
            dice = new Dictionary<int, Image>
            {
                { 1, Resources.One },
                { 2, Resources.Two },
                { 3, Resources.Three },
                { 4, Resources.Four },
                { 5, Resources.Five },
                { 6, Resources.Six }
            };
        }

        private void AnimationTimer_Tick(object sender, EventArgs eventArgs)
        {
            if (AnimationTimer.Interval <= TechnicalConstants.ANIMATION_TIMER_END_INTERVAL)
            {
                var roll = Randomizer.Randomize(6) + 1;
                while (roll == Int32.Parse(DicePicture.Tag.ToString()))
                {
                    roll = Randomizer.Randomize(6) + 1;
                }
                DicePicture.Image = dice[roll];
                DicePicture.Tag = roll;
                AnimationTimer.Interval += TechnicalConstants.ANIMATION_TIMER_INCREASE;
                AnimationTimer.Enabled = true;
            }
            else
            {
                AnimationTimer.Enabled = false;
                FinalRoll();
            }
        }

        private void FinalRoll()
        {
            AnimationTimer.Interval = TechnicalConstants.ANIMATION_TIMER_START_INTERVAL;
            var roll = Randomizer.Randomize(6) + 1;
            while (IgnoredRolls.Contains(roll))
            {
                roll = Randomizer.Randomize(6) + 1;
            }
            DicePicture.Image = dice[roll];
            DicePicture.Tag = roll;
            MessageHelper.ShowMessage(string.Format("You have rolled a {0}.", roll), TechnicalConstants.DICE_ROLL, Bot);
            Visible = false;
            DicePicture.Enabled = true;
            var function = ReturnFunction;
            ReturnFunction = null;
            IgnoredRolls.Clear();
            function(roll);
        }

        private void EnterSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Hover", false), false);
        }

        private void ClickSoundEvent(object sender, EventArgs eventArgs)
        {
            soundPlayer.Play(LoadFacade.BuildUri("Roll", false), false);
        }

        private void DiceRoller_FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            eventArgs.Cancel = true;
            MessageHelper.ShowMessage("You have to roll the dice now!", TechnicalConstants.DICE_ROLL, Bot);
        }

        private void DiceRoller_VisibleChanged(object sender, EventArgs eventArgs)
        {
            if (Visible && Bot)
            {
                DicePicture_Click(DicePicture, null);
                soundPlayer.Play(LoadFacade.BuildUri("Roll", false), false);
            }
        }
    }
}
