using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Cyprom.PokemonMasterTrainer.Domain;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public class TransparentControl : Panel, IButtonControl
    {
        private DialogResult dialogResult;

        public bool IsDefault { get; set; }

        public DialogResult DialogResult
        {
            get
            {
                return dialogResult;
            }
            set
            {
                if (Enum.IsDefined(typeof (DialogResult), value))
                {
                    dialogResult = value;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs eventArgs)
        {
            var graphics = eventArgs.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(ImageToDraw(), new Rectangle(0, 0, Size.Width, Size.Height));
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                // Set WS_EX_TRANSPARENT
                createParams.ExStyle |= 0x00000020;
                return createParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs eventArgs)
        {
            // Do nothing to make the background transparent
        }

        protected virtual Image ImageToDraw() 
        {
            return null;
        }

        public override void Refresh()
        {
            var parent = Parent;
            if (parent != null)
            {
                parent.Controls.Remove(this);
                base.Refresh();
                parent.Controls.Add(this);
            }
        }

        public void NotifyDefault(bool value)
        {
            if (IsDefault != value)
            {
                IsDefault = value;
            }
        }

        public void PerformClick()
        {
            OnClick(new BotEventArgs { Argument = true });
        }

    }
}
