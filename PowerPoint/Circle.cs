using System;
using System.Drawing;

namespace PowerPoint
{
    class Circle : Shape
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
                return new Point(HitBox.X + HitBox.Width / 2, HitBox.Y + HitBox.Height / 2);
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
            if (Selected)
            {
                graphics.DrawHitBox(HitBox, ScaleCircleRadius);
            }
            graphics.DrawCircle(Center, Diameter);
        }

        public override bool Contains(Point mousePosition)
        {
            var difference = new Point
            {
                X = mousePosition.X - Center.X,
                Y = mousePosition.Y - Center.Y
            };
            double dx = difference.X;
            double dy = difference.Y;
            double mouseToOrigin = Math.Sqrt(dx * dx + dy * dy);

            double theta = Math.Atan(dy / dx);
            double rx = Diameter.X / 2.0;
            double ry = Diameter.Y / 2.0;
            double x = rx * Math.Cos(theta);
            double y = ry * Math.Sin(theta);
            double distance = Math.Sqrt(x * x + y * y);

            return mouseToOrigin <= distance;
        }

        public override void Move(int dx, int dy)
        {
            _hitBox.X += dx;
            _hitBox.Y += dy;
        }

        public override void Resize(int dx, int dy)
        {
            _hitBox.Width += dx;
            _hitBox.Height += dy;
            _hitBox.Width = Math.Max(_hitBox.Width, 50);
            _hitBox.Height = Math.Max(_hitBox.Height, 50);
        }
    }
}
