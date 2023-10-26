using System.ComponentModel;
using Rect = System.Windows.Rect;
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

        protected Rect _hitBox = new Rect();
        public Rect HitBox
        {
            get
            {
                return _hitBox;
            }
        }

        public abstract bool Contains(Point mousePosition);

        public abstract void Move(int dx, int dy);

        /* get info */
        public abstract string GetInfo();

        /* get shape name */
        public abstract string GetShapeName();

        /* draw */
        public abstract void Draw(IGraphics graphics);

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
