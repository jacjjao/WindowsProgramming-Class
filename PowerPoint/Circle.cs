using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    class Circle : Shape
    {
        public int Radius
        {
            get;
            set;
        }

        public Point Position
        {
            get;
            set;
        }

        public Circle()
        {
            Position = new Point();
        }

        public Circle(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            Position = p1;
            Radius = (int)Math.Sqrt(dx * dx + dy * dy);
        }

        const string SHAPE_NAME = "圓形";

        /* get info */
        public string GetInfo()
        {
            const string FORMAT = "({0},{1})";
            return string.Format(FORMAT, Position.X, Position.Y);
        }

        /* get shape name */
        public string GetShapeName()
        {
            return SHAPE_NAME;
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, Radius + Radius, Radius + Radius);
        }
    }
}
