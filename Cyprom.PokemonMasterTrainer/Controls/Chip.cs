using System;
using System.Drawing;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Domain;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public sealed class Chip : TransparentControl
    {
        public int Number { get; set; }
        public string Pokemon { get; set; }
        public string Attack { get; set; }
        public int PowerPoints { get; set; }
        public int Damage { get; set; }
        public int[] CatchRate { get; set; }
        public Rarity Rarity { get; set; }
        public bool Flipped { get; set; }
        public Image FrontSide { get; set; }
        public Image BackSide { get; set; }
        public bool KnockedOut { get; set; }
        public int BonusDamage { get; set; }
        public CatchSpace AdjacentSpace { get; set; }

        private bool clickable;
        public bool Clickable
        {
            get
            {
                return clickable;
            }
            set
            {
                Cursor = value ? Cursors.Hand : Cursors.Default;
                clickable = value;
            }
        }

        private readonly PictureToolTip toolTip;

        public Chip(int number, string pokemon, string attack, int powerPoints, int damage, int[] catchRate, Rarity rarity, Image frontSide, Image backSide)
        {
            Number = number;
            Pokemon = pokemon;
            Attack = attack;
            PowerPoints = powerPoints;
            Damage = damage;
            CatchRate = catchRate;
            Rarity = rarity;
            FrontSide = frontSide;
            BackSide = backSide;
            KnockedOut = false;
            BonusDamage = 0;
            Cursor = Cursors.Hand;
            Location = new Point(0, 0);
            Size = new Size(TechnicalConstants.CHIP_SIZE, TechnicalConstants.CHIP_SIZE);
            Flipped = false;
            toolTip = new PictureToolTip(this, backSide, GetColor());
            Clickable = false;
            Click += Chip_Click;
        }

        private Color GetColor()
        {
            switch (Rarity)
            {
                case Rarity.Pink: return Color.HotPink;
                case Rarity.Green: return Color.Green;
                case Rarity.Blue: return Color.Navy;
                case Rarity.Red: return Color.Red;
                case Rarity.Yellow: return Color.Gold;
                case Rarity.Starter: return Color.Purple;
                default: return Color.White;
            }
        }

        private void Chip_Click(object sender, EventArgs eventArgs)
        {
            if (!Flipped)
            {
                toolTip.Image = FrontSide;
            }
        }

        protected override Image ImageToDraw()
        {
            return !Flipped || KnockedOut ? BackSide : FrontSide;
        }

        public int TotalDamage
        {
            get
            {
                return Damage + BonusDamage;
            }
        }

        protected override void OnClick(EventArgs eventArgs)
        {
            var botEventArgs = eventArgs as BotEventArgs;
            if (Clickable || (botEventArgs != null && (bool)botEventArgs.Argument))
            {
                base.OnClick(eventArgs);
            }
        }

        // Number is the unique identifier for a chip
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
