using System.Drawing;

namespace PowerPoint
{
    class FormGraphicsAdapter : IGraphics
    {
        private Graphics _graphics;

        public Pen DrawPen
        {
            get;
            set;
        }

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
            const float WIDTH = 1.0f;
            DrawPen = new Pen(Color.Red)
            {
                Width = WIDTH
            };
        }

        /* clear all */
        public void ClearAll(Color color)
        {
            _graphics.Clear(color);
        }

        /* draw circle */
        public void DrawCircle(Point center, Point radius)
        {
            const int TWO = 2;
            _graphics.DrawEllipse(DrawPen, center.X - radius.X, center.Y - radius.Y, radius.X * TWO, radius.Y * TWO);
        }

        /* draw line */
        public void DrawLine(Point firstPoint, Point secondPoint)
        {
            _graphics.DrawLine(DrawPen, firstPoint, secondPoint);
        }

        /* draw rectangle */
        public void DrawRectangle(Point position, Point size)
        {
            _graphics.DrawRectangle(DrawPen, position.X, position.Y, size.X, size.Y);
        }
    }
}
