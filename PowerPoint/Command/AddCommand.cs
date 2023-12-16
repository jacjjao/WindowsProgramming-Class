using System.Linq;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class AddCommand : ICommand
    {
        public bool AddRandom
        {
            get;
            set;
        }

        public ShapeType Type
        {
            get;
            set;
        }

        public int ScreenWidth
        {
            get;
            set;
        }

        public int ScreenHeight
        {
            get;
            set;
        }

        public Point PointFirst
        {
            get;
            set;
        }

        public Point PointSecond
        {
            get;
            set;
        }

        public Shape AddShape
        {
            get;
            set;
        }

        /* execute */
        public void Execute(Page list)
        {
            if (AddShape != null)
            {
                AddShape.Selected = false;
                list.Content.Add(AddShape);
                return;
            }
            if (AddRandom)
            {
                list.AddRandomShape(Type, ScreenWidth, ScreenHeight);
            }
            else
            {
                list.AddShape(Type, PointFirst, PointSecond);
            }
            AddShape = list.Content.Last();
        }

        /* undo(Unexecute會報名不符實) */
        public void Undo(Page list)
        {
            if (AddShape != null)
            {
                list.Remove(AddShape);
            }
        }
    }
}
