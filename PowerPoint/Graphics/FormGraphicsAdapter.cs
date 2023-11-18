using System.Drawing;

namespace PowerPoint
{
    public class FormGraphicsAdapter : IGraphics
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
        public void DrawCircle(Point center, Point diameter)
        {
            const int TWO = 2;
            _graphics.DrawEllipse(DrawPen, center.X - diameter.X / TWO, center.Y - diameter.Y / TWO, diameter.X, diameter.Y);
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

        /* draw hitbox */
        public void DrawHitBox(System.Drawing.Rectangle rectangle, int radius)
        {
            const float WIDTH = 1.0f;
            const int TWO = 2;
            var pen = new Pen(Color.Gray, WIDTH);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            _graphics.DrawRectangle(pen, rectangle);
            int stepX = rectangle.Width / TWO;
            int stepY = rectangle.Height / TWO;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            int diameter = radius * TWO;
            _graphics.DrawEllipse(pen, rectangle.X - radius, rectangle.Y - radius, diameter, diameter);
            _graphics.DrawEllipse(pen, rectangle.X + stepX - radius, rectangle.Y - radius, diameter, diameter);
            _graphics.DrawEllipse(pen, rectangle.X + (TWO * stepX) - radius, rectangle.Y - radius, diameter, diameter);
            _graphics.DrawEllipse(pen, rectangle.X - radius, rectangle.Y + stepY - radius, diameter, diameter);
            _graphics.DrawEllipse(pen, rectangle.X + (TWO * stepX) - radius, rectangle.Y + stepY - radius, diameter, diameter);
            _graphics.DrawEllipse(pen, rectangle.X - radius, rectangle.Y + TWO * stepY - radius, diameter, diameter);
            _graphics.DrawEllipse(pen, rectangle.X + stepX - radius, rectangle.Y + TWO * stepY - radius, diameter, diameter);
            _graphics.DrawEllipse(pen, rectangle.X + (TWO * stepX) - radius, rectangle.Y + TWO * stepY - radius, diameter, diameter);
        }
    }
}
