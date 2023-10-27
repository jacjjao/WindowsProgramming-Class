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

        public void DrawHitBox(System.Drawing.Rectangle rect, float radius)
        {
            var pen = new Pen(Color.Gray, 1.0f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            _graphics.DrawRectangle(pen, rect);
            int stepX = rect.Width / 2;
            int stepY = rect.Height / 2;
            pen.Color = Color.Green;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            _graphics.DrawEllipse(pen, rect.X - radius,               rect.Y - radius,             radius * 2, radius * 2);
            _graphics.DrawEllipse(pen, rect.X + stepX - radius,       rect.Y - radius,             radius * 2, radius * 2);
            _graphics.DrawEllipse(pen, rect.X + (2 * stepX) - radius, rect.Y - radius,             radius * 2, radius * 2);
            _graphics.DrawEllipse(pen, rect.X - radius,               rect.Y + stepY - radius,     radius * 2, radius * 2);
            _graphics.DrawEllipse(pen, rect.X + (2 * stepX) - radius, rect.Y + stepY - radius,     radius * 2, radius * 2);
            _graphics.DrawEllipse(pen, rect.X - radius,               rect.Y + 2 * stepY - radius, radius * 2, radius * 2);
            _graphics.DrawEllipse(pen, rect.X + stepX - radius,       rect.Y + 2 * stepY - radius, radius * 2, radius * 2);
            _graphics.DrawEllipse(pen, rect.X + (2 * stepX) - radius, rect.Y + 2 * stepY - radius, radius * 2, radius * 2);
        }
    }
}
