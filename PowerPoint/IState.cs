using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public interface IState
    {
        void MouseDown(BindingList<Shape> list, Point pos);

        void MouseMove(BindingList<Shape> list, Point pos);

        void MouseUp(BindingList<Shape> list, Point pos);

        void SelectShapeType(ShapeType type);
    }
}
