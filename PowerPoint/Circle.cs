using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    class Circle : Shape
    {
        private int _radius;
        private Point _position = new Point();

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
                NotifyPropertyChanged();
            }
        }

        public Point Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                NotifyPropertyChanged();
            }
        }

        public Circle(Point pointFirst, Point pointSecond)
        {
            Position = pointFirst;
            var radius = new Point();
            radius.X = pointSecond.X - pointFirst.X;
            radius.Y = pointSecond.Y - pointFirst.Y;
            Radius = (int)Math.Sqrt(radius.X * radius.X + radius.Y * radius.Y);
        }

        const string SHAPE_NAME = "圓形";

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0},{1})";
            return string.Format(FORMAT, Position.X, Position.Y);
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw circle */
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, Radius + Radius, Radius + Radius);
        }
    }
}
