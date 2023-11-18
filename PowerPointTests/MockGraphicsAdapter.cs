using System;
using System.Drawing;

namespace PowerPointTests
{
    public class MockGraphicsAdapter : PowerPoint.IGraphics
    {
        public Action<Color> clearAll = null;
        public Action<int, int, int, int> drawEllipse = null;
        public Action<Point, Point> drawLine = null;
        public Action<int, int, int, int> drawRectangle = null;

        /* clear all */
        public void ClearAll(Color color)
        {
            clearAll.Invoke(color);
        }

        /* draw circle */
        public void DrawEllipse(Pen pen, int x, int y, int width, int height)
        {
            drawEllipse.Invoke(x, y, width, height);
        }

        /* draw line */
        public void DrawLine(Pen pen, Point firstPoint, Point secondPoint)
        {
            drawLine.Invoke(firstPoint, secondPoint);
        }

        /* draw rectangle */
        public void DrawRectangle(Pen pen, int x, int y, int width, int height)
        {
            drawRectangle.Invoke(x, y, width, height);
        }
    }
}
