using System;
using System.Drawing;

namespace PowerPoint
{
    public class Line : Shape
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

        /* update hit box */
        private void UpdateHitBox()
        {
            _hitBox.X = Math.Min(EndPoint.X, StartPoint.X);
            _hitBox.Y = Math.Min(StartPoint.Y, EndPoint.Y);
            _hitBox.Width = Math.Max(EndPoint.X, StartPoint.X) - Math.Min(EndPoint.X, StartPoint.X);
            _hitBox.Height = Math.Max(StartPoint.Y, EndPoint.Y) - Math.Min(StartPoint.Y, EndPoint.Y);
        }

        /* move */
        public override void Move(int differenceX, int differenceY)
        {
            _startPoint.X += differenceX;
            _startPoint.Y += differenceY;
            _endPoint.X += differenceX;
            _endPoint.Y += differenceY;
            UpdateHitBox();
        }
    }
}
