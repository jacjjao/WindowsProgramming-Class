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

        /* 檢查游標有沒有在shape裡 */
        public virtual bool Contains(Point mousePosition)
        {
            return mousePosition.X >= _hitBox.X && mousePosition.X <= _hitBox.X + _hitBox.Width && mousePosition.Y >= _hitBox.Y && mousePosition.Y <= _hitBox.Y + _hitBox.Height;
        }

        /* move */
        public abstract void Move(int differenceX, int differenceY);

        /* get info */
        public abstract string GetInfo();

        /* get shape name */
        public abstract string GetShapeName();

        /* draw */
        public abstract void Draw(IGraphics graphics);

        /* draw shape */
        public void DrawShape(IGraphics graphics)
        {
            const float RADIUS = 10.0f;
            if (Selected)
            {
                graphics.DrawHitBox(HitBox, RADIUS);
            }
            Draw(graphics);
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
