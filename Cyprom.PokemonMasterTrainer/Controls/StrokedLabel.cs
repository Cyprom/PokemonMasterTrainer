using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cyprom.PokemonMasterTrainer.Controls
{
    public class StrokedLabel : Label
    {
        public Color OutlineForeColor { get; set; }
        public float OutlineWidth { get; set; }

        public StrokedLabel()
        {
            OutlineForeColor = Color.White;
            OutlineWidth = 0;
        }

        protected override void OnPaint(PaintEventArgs eventArgs)
        {
            eventArgs.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
            using (var graphicsPath = new GraphicsPath())
            {
                using (var pen = new Pen(OutlineForeColor, OutlineWidth) { LineJoin = LineJoin.Round })
                {
                    using (var stringFormat = new StringFormat())
                    {
                        using (var brush = new SolidBrush(ForeColor))
                        {
                            graphicsPath.AddString(Text, Font.FontFamily, (int)Font.Style, Font.Size, ClientRectangle, stringFormat);
                            eventArgs.Graphics.ScaleTransform(1.3f, 1.35f);
                            eventArgs.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                            eventArgs.Graphics.DrawPath(pen, graphicsPath);
                            eventArgs.Graphics.FillPath(brush, graphicsPath);
                        }
                    }
                }
            }
        }
    }
}
