using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public class PictureToolTip : ToolTip
    {
        public Image Image { get; set; }

        public PictureToolTip(Control control, Image image, Color color)
        {
            BackColor = color;
            OwnerDraw = true;
            Image = image;
            Draw += PictureToolTip_Draw;
            Popup += PictureToolTip_Popup;
            // A caption is required, though ignored in the display
            SetToolTip(control, "caption");
        }

        private void PictureToolTip_Draw(object sender, DrawToolTipEventArgs eventArgs)
        {
            eventArgs.Graphics.FillRectangle(new SolidBrush(BackColor), eventArgs.Bounds);
            eventArgs.Graphics.DrawRectangle(new Pen(Color.Black, 2), eventArgs.Bounds);
            eventArgs.Graphics.DrawImage(Image, eventArgs.Bounds);
        }

        private void PictureToolTip_Popup(object sender, PopupEventArgs eventArgs)
        {
            eventArgs.ToolTipSize = Image.Size;
        }
    }
}
