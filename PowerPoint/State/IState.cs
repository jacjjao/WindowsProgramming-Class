using Point = System.Drawing.Point;

namespace PowerPoint
{
    public interface IState
    {
        /* mouse down */
        void MouseDown(Shapes list, Point pos, ShapeType type);

        /* mouse move */
        void MouseMove(Shapes list, Point pos);

        /* mouse up */
        void MouseUp(Shapes list, Point pos);
    }
}
