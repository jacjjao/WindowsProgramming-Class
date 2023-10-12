using System;
using System.Drawing;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        public Point TopLeftPoint 
        { 
            get; 
            set; 
        }
        public Point Size 
        { 
            get; 
            set; 
        }

        private const string SHAPE_NAME = "矩形";

        public Rectangle()
        {
            TopLeftPoint = new Point();
            Size = new Point();
        }

        public Rectangle(Point p1, Point p2)
        {
            TopLeftPoint = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            Size = new Point
            {
                X = Math.Max(p1.X, p2.X) - Math.Min(p1.X, p2.X),
                Y = Math.Max(p1.Y, p2.Y) - Math.Min(p1.Y, p2.Y)
            };
        }

        /* get info */
        public string GetInfo()
        {
            const string FORMAT = "({0},{1})({2},{3})";
            return string.Format(FORMAT, TopLeftPoint.X, TopLeftPoint.Y, Size.X, Size.Y);
        }

        /* get shape name */
        public string GetShapeName()
        {
            return SHAPE_NAME;
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawRectangle(pen, TopLeftPoint.X, TopLeftPoint.Y, Size.X, Size.Y);
        }
    }
}
