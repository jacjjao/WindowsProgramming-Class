using System;
using System.Drawing;

namespace PowerPoint
{
    class ShapesFactory
    {
        /* create random shape */
        public Shape CreateRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            const int SIZE_LOW = 10;
            const int SIZE_HIGH = 200;
            const int POS_LOW = 0;
            var random = new Random();
            var size = new Point(random.Next(SIZE_LOW, SIZE_HIGH), random.Next(SIZE_LOW, SIZE_HIGH));
            var startPoint = new Point(random.Next(POS_LOW, screenWidth - size.X), random.Next(POS_LOW, screenHeight - size.Y));
            var endPoint = new Point(startPoint.X + size.X, startPoint.Y + size.Y);
            return CreateShape(type, startPoint, endPoint);
        }

        /* create shape */
        public Shape CreateShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            Shape shape = null;
            switch (type)
            {
                case ShapeType.Rectangle:
                    shape = new Rectangle(pointFirst, pointSecond);
                    break;
                case ShapeType.Line:
                    shape = new Line(pointFirst, pointSecond);
                    break;
                case ShapeType.Circle:
                    shape = new Circle(pointFirst, pointSecond);
                    break;
            }
            return shape;
        }
    }
}
