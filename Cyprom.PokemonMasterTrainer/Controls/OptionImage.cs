using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public sealed class OptionImage : TransparentControl
    {
        private readonly Image on;
        private readonly Image off;

        public bool IsOn { get; set; }

        public OptionImage(int size, Image on, Image off, bool isOn)
        {
            this.on = on;
            this.off = off;
            IsOn = isOn;
            Location = new Point(0, 0);
            Size = new Size(size, size);
            Cursor = Cursors.Hand;
            Click += OptionImage_Click;
        }

        private void OptionImage_Click(object sender, EventArgs eventArgs)
        {
            IsOn = !IsOn;
            base.Refresh();
        }

        protected override Image ImageToDraw()
        {
            return IsOn ? on : off;
        }
    }
}
