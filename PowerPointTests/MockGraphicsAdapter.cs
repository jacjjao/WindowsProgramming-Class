using System;
using System.Drawing;

namespace PowerPointTests
{
    public class MockGraphicsAdapter : PowerPoint.IGraphics
    {
        public Action<Color> clearAll = null;
        public Action<Point, Point> drawCircle = null;
        public Action<Rectangle, float> drawHitBox = null;
        public Action<Point, Point> drawLine = null;
        public Action<Point, Point> drawRectangle = null;

        /* clear all */
        public void ClearAll(Color color)
        {
            clearAll.Invoke(color);
        }

        /* draw circle */
        public void DrawCircle(Point center, Point radius)
        {
            drawCircle.Invoke(center, radius);
        }

        /* draw hit box */
        public void DrawHitBox(Rectangle rectangle, float radius)
        {
            drawHitBox.Invoke(rectangle, radius);
        }

        /* draw line */
        public void DrawLine(Point firstPoint, Point secondPoint)
        {
            drawLine.Invoke(firstPoint, secondPoint);
        }

        /* draw rectangle */
        public void DrawRectangle(Point position, Point size)
        {
            drawRectangle.Invoke(position, size);
        }
    }
}
