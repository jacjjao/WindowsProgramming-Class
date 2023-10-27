using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public interface IState
    {
        /* mouse down */
        void MouseDown(BindingList<Shape> list, Point pos);

        /* mouse move */
        void MouseMove(BindingList<Shape> list, Point pos);

        /* mouse up */
        void MouseUp(BindingList<Shape> list, Point pos);

        /* select shape type */
        void SetShapeType(ShapeType type);

        void RemoveSelectedShape(BindingList<Shape> list);
    }
}
