using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class RoundedPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath gp = new GraphicsPath())
            {
                if (Image != null)
                {
                    gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                    g.SetClip(gp);
                    g.DrawImage(this.Image, new Rectangle(0, 0, this.Width, this.Height));
                    g.DrawEllipse(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
                }
            }
        }
    }
}
