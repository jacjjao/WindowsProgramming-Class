using System;
using System.Drawing;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        private Point _topLeftPoint = new Point();
        private Point _size = new Point();

        public Point TopLeftPoint
        {
            get
            {
                return _topLeftPoint;
            }
            set
            {
                _topLeftPoint = value;
                updateHitBox();
                NotifyPropertyChanged();
            }
        }
        public Point Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                updateHitBox();
                NotifyPropertyChanged();
            }
        }

        private const string SHAPE_NAME = "矩形";

        public Rectangle()
        {
            TopLeftPoint = new Point();
            Size = new Point();
        }

        public Rectangle(Point pointFirst, Point pointSecond)
        {
            TopLeftPoint = new Point(Math.Min(pointFirst.X, pointSecond.X), Math.Min(pointFirst.Y, pointSecond.Y));
            Size = new Point
            {
                X = Math.Max(pointFirst.X, pointSecond.X) - Math.Min(pointFirst.X, pointSecond.X),
                Y = Math.Max(pointFirst.Y, pointSecond.Y) - Math.Min(pointFirst.Y, pointSecond.Y)
            };
            updateHitBox();
        }

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0},{1})({2},{3})";
            return string.Format(FORMAT, TopLeftPoint.X, TopLeftPoint.Y, TopLeftPoint.X + Size.X, TopLeftPoint.Y + Size.Y);
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw rectangle */
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(TopLeftPoint, Size);
        }

        public override bool Contains(Point mousePosition)
        {
            return mousePosition.X >= TopLeftPoint.X && mousePosition.X <= TopLeftPoint.X + Size.X && mousePosition.Y >= TopLeftPoint.Y && mousePosition.Y <= TopLeftPoint.Y + Size.Y;
        }

        private void updateHitBox()
        {
            _hitBox.X = TopLeftPoint.X;
            _hitBox.Y = TopLeftPoint.Y;
            _hitBox.Width = Size.X;
            _hitBox.Height = Size.Y;
        }

        public override void Move(int dx, int dy)
        {
            _topLeftPoint.X += dx;
            _topLeftPoint.Y += dy;
            updateHitBox();
        }
    }
}
