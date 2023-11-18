using Color = System.Drawing.Color;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public interface IGraphics
    {
        /* clear all */
        void ClearAll(Color color);

        /* draw line */
        void DrawLine(Point firstPoint, Point secondPoint);

        /* draw rectangle */
        void DrawRectangle(Point position, Point size);

        /* draw circle */
        void DrawCircle(Point center, Point radius);

        /* draw hitbox */
        void DrawHitBox(System.Drawing.Rectangle rectangle, int radius);
    }
}
