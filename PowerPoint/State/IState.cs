using Cursor = System.Windows.Forms.Cursor;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public interface IState
    {
        /* mouse down */
        Cursor MouseDown(Page list, Point pos);

        /* mouse move */
        Cursor MouseMove(Page list, Point pos);

        /* mouse up */
        Cursor MouseUp(Page list, Point pos);

        /* set shape type */
        void SetShapeType(ShapeType type);
    }
}
