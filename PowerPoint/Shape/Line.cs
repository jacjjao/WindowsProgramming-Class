using System;
using System.Drawing;

namespace PowerPoint
{
    public class Line : Shape
    {
        private Point _startPoint = new Point();
        private Point _endPoint = new Point();

        public Point PointLeft
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
        public Point PointRight
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

        enum Type
        {
            ForwardSlash,
            BackwardSlash
        }

        Type _type = Type.ForwardSlash;

        private const string SHAPE_NAME = "線";

        public Line(Point pointFirst, Point pointSecond)
        {
            CreationResize(pointFirst, pointSecond);
        }

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0},{1})({2},{3})";
            return string.Format(FORMAT, PointLeft.X, PointLeft.Y, PointRight.X, PointRight.Y);
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw line */
        public override void Draw(Pen pen, IGraphics graphics)
        {
            graphics.DrawLine(pen, PointLeft, PointRight);
        }

        /* update hit box */
        private void UpdateHitBox()
        {
            _hitBox.X = Math.Min(PointRight.X, PointLeft.X);
            _hitBox.Y = Math.Min(PointLeft.Y, PointRight.Y);
            _hitBox.Width = Math.Max(PointRight.X, PointLeft.X) - Math.Min(PointRight.X, PointLeft.X);
            _hitBox.Height = Math.Max(PointLeft.Y, PointRight.Y) - Math.Min(PointLeft.Y, PointRight.Y);
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
                PointLeft = pointFirst;
                PointRight = pointSecond;
            }
            else
            {
                PointLeft = pointSecond;
                PointRight = pointFirst;
            }
            _type = PointLeft.Y <= PointRight.Y ? Type.BackwardSlash : Type.ForwardSlash;
        }

        /* resize */
        public override void Resize(Point pointFirst, Point pointSecond)
        {
            if (_type == Type.BackwardSlash)
            {
                _startPoint.X = Math.Min(pointFirst.X, pointSecond.X);
                _startPoint.Y = Math.Min(pointFirst.Y, pointSecond.Y);
                _endPoint.X = Math.Max(pointFirst.X, pointSecond.X);
                _endPoint.Y = Math.Max(pointFirst.Y, pointSecond.Y);
            }
            else
            {
                _startPoint.X = Math.Min(pointFirst.X, pointSecond.X);
                _startPoint.Y = Math.Max(pointFirst.Y, pointSecond.Y);
                _endPoint.X = Math.Max(pointFirst.X, pointSecond.X);
                _endPoint.Y = Math.Min(pointFirst.Y, pointSecond.Y);
            }
            UpdateHitBox();
        }

        /* contains */
        public override bool Contains(Point mousePosition)
        {
            var size = new Point(PointRight.X - PointLeft.X, Math.Abs(PointRight.Y - PointLeft.Y));
            var position = new Point(PointLeft.X, Math.Min(PointLeft.Y, PointRight.Y));
            return mousePosition.X >= position.X && mousePosition.X <= position.X + size.X && mousePosition.Y >= position.Y && mousePosition.Y <= position.Y + size.Y;
        }
    }
}
