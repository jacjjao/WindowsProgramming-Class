using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointTests
{
    public class MockGraphicsAdapter : PowerPoint.IGraphics
    {
        public Action<Color> clear = null;
        public Action<Point, Point> drawCircle = null;
        public Action<Rectangle, float> drawHitBox = null;
        public Action<Point, Point> drawLine = null;
        public Action<Point, Point> drawRectangle = null;

        /* clear all */
        public void ClearAll(Color color)
        {
            clear?.Invoke(color);
        }

        /* draw circle */
        public void DrawCircle(Point center, Point radius)
        {
            drawCircle?.Invoke(center, radius);
        }

        /* draw hit box */
        public void DrawHitBox(Rectangle rectangle, float radius)
        {
            drawHitBox?.Invoke(rectangle, radius);
        }

        /* draw line */
        public void DrawLine(Point firstPoint, Point secondPoint)
        {
            drawLine?.Invoke(firstPoint, secondPoint);
        }

        /* draw rectangle */
        public void DrawRectangle(Point position, Point size)
        {
            drawRectangle?.Invoke(position, size);
        }
    }
}
