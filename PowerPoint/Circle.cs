using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    class Circle : IShape, INotifyPropertyChanged
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
            var radius = new Point()
            {
                X = pointSecond.X - pointFirst.X,
                Y = pointSecond.Y - pointFirst.Y
            };
            Radius = (int)Math.Sqrt(radius.X * radius.X + radius.Y * radius.Y);
        }

        const string SHAPE_NAME = "圓形";

        public event PropertyChangedEventHandler PropertyChanged;

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

        /* notify */
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
