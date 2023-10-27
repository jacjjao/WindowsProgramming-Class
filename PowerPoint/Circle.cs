using System;
using System.Drawing;

namespace PowerPoint
{
    class Circle : Shape
    {
        private Point _diameter = new Point();
        private Point _position = new Point();

        public Point Diameter
        {
            get
            {
                return _diameter;
            }
            set
            {
                _diameter = value;
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
            _diameter.X = Math.Abs(pointSecond.X - pointFirst.X);
            _diameter.Y = Math.Abs(pointSecond.Y - pointFirst.Y);
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
            graphics.DrawCircle(Position, Diameter);
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
            double rx = Diameter.X / 2.0;
            double ry = Diameter.Y / 2.0;
            double x = rx * Math.Cos(theta);
            double y = ry * Math.Sin(theta);
            double distance = Math.Sqrt(x * x + y * y);

            return mouseToOrigin <= distance;
        }

        private void UpdateHitBox()
        {
            _hitBox.Width = Diameter.X;
            _hitBox.Height = Diameter.Y;
            _hitBox.X = Position.X - Diameter.X / 2;
            _hitBox.Y = Position.Y - Diameter.Y / 2;
        }

        public override void Move(int dx, int dy)
        {
            _position.X += dx;
            _position.Y += dy;
            UpdateHitBox();
        }

        public override void Resize(int dx, int dy)
        {
            _diameter.X = Math.Max(_diameter.X + dx, 10);
            _diameter.Y = Math.Max(_diameter.Y + dy, 10);
            // _position.X -= dx;
            // _position.Y -= dy;
            UpdateHitBox();
        }
    }
}
