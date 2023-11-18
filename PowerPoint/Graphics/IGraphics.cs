using System.Drawing;

namespace PowerPoint
{
    public interface IGraphics
    {
        /* clear all */
        void ClearAll(Color color);

        /* draw line */
        void DrawLine(Pen pen, Point firstPoint, Point secondPoint);

        /* draw rectangle */
        void DrawRectangle(Pen pen, int x, int y, int width, int height);

        /* draw circle */
        void DrawEllipse(Pen pen, int x, int y, int width, int height);
    }
}
