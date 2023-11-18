using System.Drawing;

namespace PowerPoint
{
    public interface IGraphics
    {
        /* clear all */
        void ClearAll(Color color);

        /* draw circle */
        void DrawEllipse(Pen pen, System.Drawing.Rectangle rectangle);

        /* draw line */
        void DrawLine(Pen pen, Point firstPoint, Point secondPoint);

        /* draw rectangle */
        void DrawRectangle(Pen pen, System.Drawing.Rectangle rectangle);
    }
}
