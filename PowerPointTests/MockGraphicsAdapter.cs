using System;
using System.Drawing;

namespace PowerPointTests
{
    public class MockGraphicsAdapter : PowerPoint.IGraphics
    {
        public Action<Color> clearAll = null;
        public Action<Rectangle> drawEllipse = null;
        public Action<Point, Point> drawLine = null;
        public Action<Rectangle> drawRectangle = null;

        /* clear all */
        public void ClearAll(Color color)
        {
            clearAll(color);
        }

        /* draw circle */
        public void DrawEllipse(Pen pen, Rectangle rect)
        {
            drawEllipse.Invoke(rect);
        }

        /* draw line */
        public void DrawLine(Pen pen, Point firstPoint, Point secondPoint)
        {
            drawLine.Invoke(firstPoint, secondPoint);
        }

        /* draw rectangle */
        public void DrawRectangle(Pen pen, Rectangle rect)
        {
            drawRectangle.Invoke(rect);
        }
    }
}
