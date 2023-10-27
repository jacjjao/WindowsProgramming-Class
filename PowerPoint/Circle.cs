using System;
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
                UpdateHitBox();
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
                UpdateHitBox();
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
            UpdateHitBox();
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
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(Position, Radius);
        }

        public override bool Contains(Point mousePosition)
        {
            var difference = new Point
            {
                X = mousePosition.X - Position.X,
                Y = mousePosition.Y - Position.Y
            };
            double dx = difference.X;
            double dy = difference.Y;
            double mouseToOrigin = Math.Sqrt(dx * dx + dy * dy);

            double theta = Math.Atan(dy / dx);
            double rx = Radius.X;
            double ry = Radius.Y;
            double x = rx * Math.Cos(theta);
            double y = ry * Math.Sin(theta);
            double distance = Math.Sqrt(x * x + y * y);

            return mouseToOrigin <= distance;
        }

        private void UpdateHitBox()
        {
            const int TWO = 2;
            _hitBox.Width = Radius.X * TWO;
            _hitBox.Height = Radius.Y * TWO;
            _hitBox.X = Position.X - Radius.X;
            _hitBox.Y = Position.Y - Radius.Y;
        }

        public override void Move(int dx, int dy)
        {
            _position.X += dx;
            _position.Y += dy;
            UpdateHitBox();
        }
    }
}
