using System;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    class Rectangle : IShape
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Point _topLeftPoint = new Point();
        private Point _size = new Point();

        public Point TopLeftPoint
        {
            get
            {
                return _topLeftPoint;
            }
            set
            {
                _topLeftPoint = value;
                NotifyPropertyChanged();
            }
        }
        public Point Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                NotifyPropertyChanged();
            }
        }

        private const string SHAPE_NAME = "矩形";

        public Rectangle()
        {
            TopLeftPoint = new Point();
            Size = new Point();
        }

        public Rectangle(Point pointFirst, Point pointSecond)
        {
            TopLeftPoint = new Point(Math.Min(pointFirst.X, pointSecond.X), Math.Min(pointFirst.Y, pointSecond.Y));
            Size = new Point
            {
                X = Math.Max(pointFirst.X, pointSecond.X) - Math.Min(pointFirst.X, pointSecond.X),
                Y = Math.Max(pointFirst.Y, pointSecond.Y) - Math.Min(pointFirst.Y, pointSecond.Y)
            };
        }

        /* get info */
        public string GetInfo()
        {
            const string FORMAT = "({0},{1})({2},{3})";
            return string.Format(FORMAT, TopLeftPoint.X, TopLeftPoint.Y, TopLeftPoint.X + Size.X, TopLeftPoint.Y + Size.Y);
        }

        /* get shape name */
        public string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw rectangle */
        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawRectangle(pen, TopLeftPoint.X, TopLeftPoint.Y, Size.X, Size.Y);
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
