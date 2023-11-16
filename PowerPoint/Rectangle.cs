using System;
using System.Drawing;

namespace PowerPoint
{
    public class Rectangle : Shape
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

        /* move */
        public override void Move(int differenceX, int differenceY)
        {
            _hitBox.X += differenceX;
            _hitBox.Y += differenceY;
        }
    }
}
