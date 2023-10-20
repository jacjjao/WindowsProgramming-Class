using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    class Circle : Shape
    {
        private Point _radius = new Point();
        private Point _position = new Point();

        public Point Radius
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
            const int TWO = 2;
            _position.X = Math.Abs(pointFirst.X + pointSecond.X) / TWO;
            _position.Y = Math.Abs(pointFirst.Y + pointSecond.Y) / TWO;
            _radius.X = Math.Abs(pointSecond.X - pointFirst.X) / TWO;
            _radius.Y = Math.Abs(pointSecond.Y - pointFirst.Y) / TWO;
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
            const int TWO = 2;
            graphics.DrawEllipse(pen, Position.X - Radius.X, Position.Y - Radius.Y, Radius.X * TWO, Radius.Y * TWO);
        }
    }
}
