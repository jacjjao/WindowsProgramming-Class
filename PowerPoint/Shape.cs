using System.ComponentModel;
using Point = System.Drawing.Point;
using System.Windows;

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

        public abstract bool DoMouseDown(Point mousePosition);

        public abstract void DoMouseMove(Point mousePosition);

        public abstract void DoMouseUp(Point mousePosition);

        public abstract Rect GetHitBox(Point mousePosition);

        public void DrawHitBox()
        {

        }

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
