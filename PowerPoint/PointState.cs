using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    class PointState : IState
    {
        // Shape _selectedShape = null;

        /* mouse down */
        public void MouseDown(BindingList<Shape> list, Point pos)
        {
        }

        /* mouse move */
        public void MouseMove(BindingList<Shape> list, Point pos)
        {
        }

        /* mouse up */
        public void MouseUp(BindingList<Shape> list, Point pos)
        {
        }

        /* select shape type */
        public void SetShapeType(ShapeType type)
        {
        }
    }
}
