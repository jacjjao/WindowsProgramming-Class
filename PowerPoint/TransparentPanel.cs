using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PowerPoint
{
    class TransparentPanel : Panel
    {
        /* on paint */
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;
            graphics.FillRectangle(Brushes.Black, 0, 0, 1000, 1000);
        }
    }
}
