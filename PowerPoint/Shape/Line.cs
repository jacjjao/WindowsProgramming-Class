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
            }
        }

        private const string SHAPE_NAME = "線";

        public Line(Point pointFirst, Point pointSecond)
        {
            CreationResize(pointFirst, pointSecond);
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
        public override void Draw(Pen pen, IGraphics graphics)
        {
            graphics.DrawLine(pen, StartPoint, EndPoint);
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

        /* creation resize */
        public override void CreationResize(Point pointFirst, Point pointSecond)
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
        }

        /* resize */
        public override void Resize(Point pointFirst, Point pointSecond)
        {
            if (pointFirst.X > pointSecond.X)
            {
                (pointFirst, pointSecond) = (pointSecond, pointFirst);
            }
            if (_startPoint.Y < _endPoint.Y)
            {
                _startPoint = pointFirst;
                _endPoint = pointSecond;
            }
            else
            {
                _startPoint.X = pointFirst.X;
                _startPoint.Y = pointSecond.Y;
                _endPoint.X = pointSecond.X;
                _endPoint.Y = pointFirst.Y;
            }
            UpdateHitBox();
        }

        /* contains */
        public override bool Contains(Point mousePosition)
        {
            var size = new Point(EndPoint.X - StartPoint.X, Math.Abs(EndPoint.Y - StartPoint.Y));
            var position = new Point(StartPoint.X, Math.Min(StartPoint.Y, EndPoint.Y));
            return mousePosition.X >= position.X && mousePosition.X <= position.X + size.X && mousePosition.Y >= position.Y && mousePosition.Y <= position.Y + size.Y;
        }
    }
}
