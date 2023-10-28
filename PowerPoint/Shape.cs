using System;
using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public abstract class Shape : INotifyPropertyChanged
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

        private float _scaleCircleRadius = 10.0f;
        public float ScaleCircleRadius
        {
            get
            {
                return _scaleCircleRadius;
            }
            set
            {
                _scaleCircleRadius = value;
            }
        }

        protected System.Drawing.Rectangle _hitBox = new System.Drawing.Rectangle();
        public System.Drawing.Rectangle HitBox
        {
            get
            {
                return _hitBox;
            }
        }

        public int ResizeCircleRadius
        {
            get;
            set;
        }

        public abstract bool Contains(Point mousePosition);

        public abstract void Move(int dx, int dy);

        public abstract void Resize(int dx, int dy);

        private bool CircleHitDetection(int x, int y, int cx, int cy)
        {
            int dx = x - cx;
            int dy = y - cy;
            return Math.Sqrt(dx * dx + dy * dy) <= ScaleCircleRadius;
        }

        public int ScaleCircleClick(int mx, int my)
        {
            int x = HitBox.X;
            int y = HitBox.Y;
            int stepX = HitBox.Width / 2;
            int stepY = HitBox.Height / 2;
            int cnt = 0;
            for (int i = 0; i < 8; i++)
            {
                if (i == 4)
                {
                    x += stepX;
                    cnt++;
                }

                if (CircleHitDetection(mx, my, x, y))
                {
                    return i;
                }

                x += stepX;
                if (cnt++ >= 2)
                {
                    x = HitBox.X;
                    y += stepY;
                    cnt = 0;
                }
            }
            return -1;
        }

        /* get info */
        public abstract string GetInfo();

        /* get shape name */
        public abstract string GetShapeName();

        /* draw */
        public abstract void Draw(IGraphics graphics);

        public void DrawHitBox(IGraphics graphics)
        {
            graphics.DrawHitBox(HitBox, 10.0f);
        }

        public void DrawShape(IGraphics graphics)
        {
            Draw(graphics);
            if (Selected)
            {
                DrawHitBox(graphics);
            }
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
