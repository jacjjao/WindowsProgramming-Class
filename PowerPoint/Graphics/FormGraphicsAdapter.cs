using System.Drawing;

namespace PowerPoint
{
    public class FormGraphicsAdapter : IGraphics
    {
        private Graphics _graphics;

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        /* clear all */
        public void ClearAll(Color color)
        {
            _graphics.Clear(color);
        }

        /* draw circle */
        public void DrawEllipse(Pen pen, System.Drawing.Rectangle rectangle)
        {
            _graphics.DrawEllipse(pen, rectangle);
        }

        /* draw line */
        public void DrawLine(Pen pen, Point firstPoint, Point secondPoint)
        {
            _graphics.DrawLine(pen, firstPoint, secondPoint);
        }

        /* draw rectangle */
        public void DrawRectangle(Pen pen, System.Drawing.Rectangle rectangle)
        {
            _graphics.DrawRectangle(pen, rectangle);
        }
    }
}
