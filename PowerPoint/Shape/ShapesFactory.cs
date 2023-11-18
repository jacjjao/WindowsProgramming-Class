using System;
using System.Drawing;

namespace PowerPoint
{
    public class ShapesFactory
    {
        readonly IRandom _random;

        public ShapesFactory(IRandom random)
        {
            _random = random;
        }

        /* create random shape */
        public Shape CreateRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            const int SIZE_LOW = 10;
            int sizeHigh = Math.Min(screenWidth, screenHeight);
            const int POS_LOW = 0;
            var size = new Point(_random.GetNext(SIZE_LOW, sizeHigh), _random.GetNext(SIZE_LOW, sizeHigh));
            var startPoint = new Point(_random.GetNext(POS_LOW, screenWidth - size.X), _random.GetNext(POS_LOW, screenHeight - size.Y));
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
