using System;
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

        public Circle(Point pointFirst, Point pointSecond)
        {
            Point point = new Point();
            point.X = pointSecond.X - pointFirst.X;
            point.Y = pointSecond.Y - pointFirst.Y;
            Position = pointFirst;
            Radius = (int)Math.Sqrt(point.X * point.X + point.Y * point.Y);
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

        /* draw circle */
        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, Radius + Radius, Radius + Radius);
        }
    }
}
