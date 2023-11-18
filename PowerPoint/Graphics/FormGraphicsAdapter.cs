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
        public void DrawEllipse(Pen pen, int x, int y, int width, int height)
        {
            _graphics.DrawEllipse(pen, x, y, width, height);
        }

        /* draw line */
        public void DrawLine(Pen pen, Point firstPoint, Point secondPoint)
        {
            _graphics.DrawLine(pen, firstPoint, secondPoint);
        }

        /* draw rectangle */
        public void DrawRectangle(Pen pen, int x, int y, int width, int height)
        {
            _graphics.DrawRectangle(pen, x, y, width, height);
        }
    }
}
