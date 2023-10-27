using System;
using System.Drawing;

namespace PowerPoint
{
    class Line : Shape
    {
        private Point _startPoint = new Point();
        private Point _endPoint = new Point();

        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
                UpdateHitBox();
                NotifyPropertyChanged();
            }
        }
        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
                UpdateHitBox();
                NotifyPropertyChanged();
            }
        }

        private const string SHAPE_NAME = "線";

        public Line(Point pointFirst, Point pointSecond)
        {
            if (pointFirst.X <= pointSecond.X)
            {
                StartPoint = pointFirst;
                EndPoint = pointSecond;
            }
            else
            {
                StartPoint = pointSecond;
                EndPoint = pointFirst;
            }
            UpdateHitBox();
        }

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0},{1})({2},{3})";
            return string.Format(FORMAT, StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw line */
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(StartPoint, EndPoint);
        }

        public override bool Contains(Point mousePosition)
        {
            return mousePosition.X >= _hitBox.X && mousePosition.X <= _hitBox.X + _hitBox.Width && mousePosition.Y >= _hitBox.Y && mousePosition.Y <= _hitBox.Y + _hitBox.Height;
        }

        private void UpdateHitBox()
        {
            _hitBox.X = Math.Min(EndPoint.X, StartPoint.X);
            _hitBox.Y = Math.Min(StartPoint.Y, EndPoint.Y);
            _hitBox.Width = Math.Max(EndPoint.X, StartPoint.X) - Math.Min(EndPoint.X, StartPoint.X);
            _hitBox.Height = Math.Max(StartPoint.Y, EndPoint.Y) - Math.Min(StartPoint.Y, EndPoint.Y);
        }

        public override void Move(int dx, int dy)
        {
            _startPoint.X += dx;
            _startPoint.Y += dy;
            _endPoint.X += dx;
            _endPoint.Y += dy;
            UpdateHitBox();
        }
    }
}
