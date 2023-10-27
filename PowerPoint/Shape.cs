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
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
