using System;
using System.Drawing;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        public Point Position
        {
            get
            {
                return new Point(HitBox.X, HitBox.Y);
            }
            set
            {
                _hitBox.X = value.X;
                _hitBox.Y = value.Y;
                NotifyPropertyChanged();
            }
        }
        public Point Size
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

        private const string SHAPE_NAME = "矩形";

        public Rectangle()
        {
            Position = new Point();
            Size = new Point();
        }

        public Rectangle(Point pointFirst, Point pointSecond)
        {
            Position = new Point(Math.Min(pointFirst.X, pointSecond.X), Math.Min(pointFirst.Y, pointSecond.Y));
            Size = new Point
            {
                X = Math.Max(pointFirst.X, pointSecond.X) - Math.Min(pointFirst.X, pointSecond.X),
                Y = Math.Max(pointFirst.Y, pointSecond.Y) - Math.Min(pointFirst.Y, pointSecond.Y)
            };
        }

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0},{1})({2},{3})";
            return string.Format(FORMAT, Position.X, Position.Y, Position.X + Size.X, Position.Y + Size.Y);
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw rectangle */
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(Position, Size);
        }

        public override bool Contains(Point mousePosition)
        {
            return mousePosition.X >= Position.X && mousePosition.X <= Position.X + Size.X && mousePosition.Y >= Position.Y && mousePosition.Y <= Position.Y + Size.Y;
        }

        public override void Move(int dx, int dy)
        {
            _hitBox.X += dx;
            _hitBox.Y += dy;
        }

        public override void Resize(int dx, int dy)
        {
            _hitBox.Width = Math.Max(_hitBox.Width + dx, 50);
            _hitBox.Height = Math.Max(_hitBox.Height + dy, 50);
        }
    }
}
