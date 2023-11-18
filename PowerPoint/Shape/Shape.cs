using System;
using System.ComponentModel;
using System.Drawing;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        const int RADIUS = 10;

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

        protected System.Drawing.Rectangle _hitBox = new System.Drawing.Rectangle();
        public System.Drawing.Rectangle HitBox
        {
            get
            {
                return _hitBox;
            }
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

        /* draw hit box */
        private void DrawHitBox(IGraphics graphics)
        {
            const float WIDTH = 1.0f;
            const int TWO = 2;
            var pen = new Pen(Color.Gray, WIDTH);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawRectangle(pen, HitBox.X, HitBox.Y, HitBox.Width, HitBox.Height);
            int stepX = HitBox.Width / TWO;
            int stepY = HitBox.Height / TWO;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            int diameter = RADIUS * TWO;
            graphics.DrawEllipse(pen, HitBox.X - RADIUS, HitBox.Y - RADIUS, diameter, diameter);
            graphics.DrawEllipse(pen, HitBox.X + stepX - RADIUS, HitBox.Y - RADIUS, diameter, diameter);
            graphics.DrawEllipse(pen, HitBox.X + (TWO * stepX) - RADIUS, HitBox.Y - RADIUS, diameter, diameter);
            graphics.DrawEllipse(pen, HitBox.X - RADIUS, HitBox.Y + stepY - RADIUS, diameter, diameter);
            graphics.DrawEllipse(pen, HitBox.X + (TWO * stepX) - RADIUS, HitBox.Y + stepY - RADIUS, diameter, diameter);
            graphics.DrawEllipse(pen, HitBox.X - RADIUS, HitBox.Y + TWO * stepY - RADIUS, diameter, diameter);
            graphics.DrawEllipse(pen, HitBox.X + stepX - RADIUS, HitBox.Y + TWO * stepY - RADIUS, diameter, diameter);
            graphics.DrawEllipse(pen, HitBox.X + (TWO * stepX) - RADIUS, HitBox.Y + TWO * stepY - RADIUS, diameter, diameter);
        }

        /* in circle */
        private bool InCircle(Point center, Point point)
        {
            int x = point.X - center.X;
            int y = point.Y - center.Y;
            return Math.Sqrt(x * x + y * y) <= RADIUS;
        }

        /* get resize direction */
        public ResizeDirection GetResizeDirection(Point mousePosition)
        {
            const int TWO = 2;
            var pos = new Point(HitBox.X, HitBox.Y);
            if (InCircle(pos, mousePosition))
                return ResizeDirection.TopLeft;
            pos.X = HitBox.X + HitBox.Width / TWO;
            if (InCircle(pos, mousePosition))
                return ResizeDirection.TopMiddle;
            pos.X = HitBox.X + HitBox.Width;
            if (InCircle(pos, mousePosition))
                return ResizeDirection.TopRight;

            pos.X = HitBox.X;
            pos.Y = HitBox.Y + HitBox.Height / TWO;
            if (InCircle(pos, mousePosition))
                return ResizeDirection.MiddleLeft;
            pos.X = HitBox.X + HitBox.Width;
            if (InCircle(pos, mousePosition))
                return ResizeDirection.MiddleRight;

            pos.X = HitBox.X;
            pos.Y = HitBox.Y + HitBox.Height;
            if (InCircle(pos, mousePosition))
                return ResizeDirection.BottomLeft;
            pos.X = HitBox.X + HitBox.Width / TWO;
            if (InCircle(pos, mousePosition))
                return ResizeDirection.BottomMiddle;
            pos.X = HitBox.X + HitBox.Width;
            if (InCircle(pos, mousePosition))
                return ResizeDirection.BottomRight;

            return ResizeDirection.None;
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
