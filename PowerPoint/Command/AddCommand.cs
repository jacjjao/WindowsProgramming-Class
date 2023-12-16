using System.Linq;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class AddCommand : ICommand
    {
        public ShapeType Type
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
            list.AddShape(Type, PointFirst, PointSecond);
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
