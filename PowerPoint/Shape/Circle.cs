using System;
using System.Drawing;

namespace PowerPoint
{
    public class Circle : Shape
    {
        public Point Diameter
        {
            get
            {
                return new Point(HitBox.Width, HitBox.Height);
            }
            set
            {
                _hitBox.Width = value.X;
                _hitBox.Height = value.Y;
            }
        }

        public Point Radius
        {
            get
            {
                const int TWO = 2;
                return new Point(HitBox.Width / TWO, HitBox.Height / TWO);
            }
            set
            {
                const int TWO = 2;
                _hitBox.Width = value.X * TWO;
                _hitBox.Height = value.Y * TWO;
            }
        }

        public Point Center
        {
            get
            {
                return new Point(HitBox.X + Radius.X, HitBox.Y + Radius.Y);
            }
            set
            {
                _hitBox.X = value.X - Radius.X;
                _hitBox.Y = value.Y - Radius.Y;
            }
        }

        public Circle(Point pointFirst, Point pointSecond)
        {
            Resize(pointFirst, pointSecond);
        }

        public const string SHAPE_NAME = "圓形";

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0},{1})";
            var center = TransformPoint(Center);
            return string.Format(FORMAT, center.X, center.Y);
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw circle */
        public override void Draw(Pen pen, IGraphics graphics)
        {
            graphics.DrawEllipse(pen, _hitBox);
        }

        /* contain */
        public override bool Contains(Point mousePosition)
        {
            var difference = new Point();
            difference.X = mousePosition.X - Center.X;
            difference.Y = mousePosition.Y - Center.Y;
            double differenceX = difference.X;
            double differenceY = difference.Y;
            double mouseToOrigin = Math.Sqrt(differenceX * differenceX + differenceY * differenceY);
            const double ZERO = 0.0;
            if (mouseToOrigin == ZERO)
                return true;
            double angle = Math.Atan(differenceY / differenceX);
            double radiusX = Radius.X;
            double radiusY = Radius.Y;
            double lengthX = radiusX * Math.Cos(angle);
            double lengthY = radiusY * Math.Sin(angle);
            double distance = Math.Sqrt(lengthX * lengthX + lengthY * lengthY);
            return mouseToOrigin <= distance;
        }

        /* move */
        public override void Move(int differenceX, int differenceY)
        {
            _hitBox.X += differenceX;
            _hitBox.Y += differenceY;
        }

        /* resize */
        public override void Resize(Point pointFirst, Point pointSecond)
        {
            _hitBox.X = Math.Min(pointFirst.X, pointSecond.X);
            _hitBox.Y = Math.Min(pointFirst.Y, pointSecond.Y);
            _hitBox.Width = Math.Abs(pointSecond.X - pointFirst.X);
            _hitBox.Height = Math.Abs(pointSecond.Y - pointFirst.Y);
        }
    }
}
