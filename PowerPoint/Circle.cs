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
                NotifyPropertyChanged();
            }
        }

        public Point Center
        {
            get
            {
                const int TWO = 2;
                return new Point(HitBox.X + HitBox.Width / TWO, HitBox.Y + HitBox.Height / TWO);
            }
            set
            {
                _hitBox.X = value.X;
                _hitBox.Y = value.Y;
                NotifyPropertyChanged();
            }
        }

        public Circle(Point pointFirst, Point pointSecond)
        {
            _hitBox.X = Math.Min(pointFirst.X, pointSecond.X);
            _hitBox.Y = Math.Min(pointFirst.Y, pointSecond.Y);
            _hitBox.Width = Math.Abs(pointSecond.X - pointFirst.X);
            _hitBox.Height = Math.Abs(pointSecond.Y - pointFirst.Y);
        }

        const string SHAPE_NAME = "圓形";

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0},{1})";
            return string.Format(FORMAT, Center.X, Center.Y);
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw circle */
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(Center, Diameter);
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

            if (mouseToOrigin == 0.0)
            {
                return true;
            }

            const double TWO = 2.0;
            double angle = Math.Atan(differenceY / differenceX);
            double radiusX = Diameter.X / TWO;
            double radiusY = Diameter.Y / TWO;
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
    }
}
