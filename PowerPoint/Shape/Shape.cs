using System;
using System.ComponentModel;
using System.Drawing;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public abstract partial class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Info
        {
            get
            {
                return GetInfo();
            }
        }

        public string Name
        {
            get
            {
                return GetShapeName();
            }
        }

        public bool Selected
        {
            get;
            set;
        }

        /* 檢查游標有沒有在shape裡 */
        public abstract bool Contains(Point mousePosition);

        /* move */
        public abstract void Move(int differenceX, int differenceY);

        /* resize */
        public abstract void Resize(Point pointFirst, Point pointSecond);

        /* get info */
        public abstract string GetInfo();

        /* get shape name */
        public abstract string GetShapeName();

        /* draw */
        public abstract void Draw(Pen pen, IGraphics graphics);

        /* is in hitbox */
        public bool IsInHitBox(Point point)
        {
            return point.X >= HitBox.X && point.X <= HitBox.X + HitBox.Width && point.Y >= HitBox.Y && point.Y <= HitBox.Y + HitBox.Height;
        }

        /* resize top left */
        private ResizeDirection OffsetTopLeft(ref Point pointFirst, ref Point pointSecond, int differenceX, int differenceY)
        {
            pointFirst.X += differenceX;
            pointFirst.Y += differenceY;
            if (pointFirst.X > pointSecond.X)
                return ResizeDirection.TopRight;
            if (pointFirst.Y > pointSecond.Y)
                return ResizeDirection.BottomLeft;
            return ResizeDirection.TopLeft;
        }

        /* resize top middle */
        private ResizeDirection OffsetTopMiddle(ref Point pointFirst, ref Point pointSecond, int differenceY)
        {
            pointFirst.Y += differenceY;
            if (pointFirst.Y > pointSecond.Y)
                return ResizeDirection.BottomMiddle;
            return ResizeDirection.TopMiddle;
        }

        /* resize top right */
        private ResizeDirection OffsetTopRight(ref Point pointFirst, ref Point pointSecond, int differenceX, int differenceY)
        {
            pointSecond.X += differenceX;
            pointFirst.Y += differenceY;
            if (pointFirst.X > pointSecond.X)
                return ResizeDirection.TopLeft;
            if (pointFirst.Y > pointSecond.Y)
                return ResizeDirection.BottomRight;
            return ResizeDirection.TopRight;
        }

        /* resize middle left */
        private ResizeDirection OffsetMiddleLeft(ref Point pointFirst, ref Point pointSecond, int differenceX)
        {
            pointFirst.X += differenceX;
            if (pointFirst.X > pointSecond.X)
                return ResizeDirection.MiddleRight;
            return ResizeDirection.MiddleLeft;
        }

        /* resize middle right */
        private ResizeDirection OffsetMiddleRight(ref Point pointFirst, ref Point pointSecond, int differenceX)
        {
            pointSecond.X += differenceX;
            if (pointFirst.X > pointSecond.X)
                return ResizeDirection.MiddleLeft;
            return ResizeDirection.MiddleRight;
        }

        /* resize bottom left */
        private ResizeDirection OffsetBottomLeft(ref Point pointFirst, ref Point pointSecond, int differenceX, int differenceY)
        {
            pointFirst.X += differenceX;
            pointSecond.Y += differenceY;
            if (pointFirst.X > pointSecond.X)
                return ResizeDirection.BottomRight;
            if (pointFirst.Y > pointSecond.Y)
                return ResizeDirection.TopLeft;
            return ResizeDirection.BottomLeft;
        }

        /* resize bottom middle */
        private ResizeDirection OffsetBottomMiddle(ref Point pointFirst, ref Point pointSecond, int differenceY)
        {
            pointSecond.Y += differenceY;
            if (pointFirst.Y > pointSecond.Y)
                return ResizeDirection.TopMiddle;
            return ResizeDirection.BottomMiddle;
        }

        /* resize bottom right */
        private ResizeDirection OffsetBottomRight(ref Point pointFirst, ref Point pointSecond, int differenceX, int differenceY)
        {
            pointSecond.X += differenceX;
            pointSecond.Y += differenceY;
            if (pointFirst.X > pointSecond.X)
                return ResizeDirection.BottomLeft;
            if (pointFirst.Y > pointSecond.Y)
                return ResizeDirection.TopRight;
            return ResizeDirection.BottomRight;
        }

        /* directional resize */
        public ResizeDirection ResizeBasedOnDirection(ResizeDirection direction, int differenceX, int differenceY)
        {
            var pointFirst = new Point(HitBox.X, HitBox.Y);
            var pointSecond = new Point(pointFirst.X + HitBox.Width, pointFirst.Y + HitBox.Height);
            switch (direction)
            {
                case ResizeDirection.None:
                    Move(differenceX, differenceY);
                    return ResizeDirection.None;
                case ResizeDirection.TopLeft:
                    direction = OffsetTopLeft(ref pointFirst, ref pointSecond, differenceX, differenceY);
                    break;
                case ResizeDirection.TopMiddle:
                    direction = OffsetTopMiddle(ref pointFirst, ref pointSecond, differenceY);
                    break;
                case ResizeDirection.TopRight:
                    direction = OffsetTopRight(ref pointFirst, ref pointSecond, differenceX, differenceY);
                    break;
                case ResizeDirection.MiddleLeft:
                    direction = OffsetMiddleLeft(ref pointFirst, ref pointSecond, differenceX);
                    break;
                case ResizeDirection.MiddleRight:
                    direction = OffsetMiddleRight(ref pointFirst, ref pointSecond, differenceX);
                    break;
                case ResizeDirection.BottomLeft:
                    direction = OffsetBottomLeft(ref pointFirst, ref pointSecond, differenceX, differenceY);
                    break;
                case ResizeDirection.BottomMiddle:
                    direction = OffsetBottomMiddle(ref pointFirst, ref pointSecond, differenceY);
                    break;
                case ResizeDirection.BottomRight:
                    direction = OffsetBottomRight(ref pointFirst, ref pointSecond, differenceX, differenceY);
                    break;
                default:
                    throw new ArgumentException();
            }
            Resize(pointFirst, pointSecond);
            return direction;
        }

        /* draw shape */
        public void DrawShape(Pen pen, IGraphics graphics)
        {
            if (Selected)
            {
                DrawHitBox(graphics);
            }
            Draw(pen, graphics);
        }

        /* notify */
        public void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
