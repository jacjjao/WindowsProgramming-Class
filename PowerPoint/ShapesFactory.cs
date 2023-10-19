using System;
using System.Drawing;

namespace PowerPoint
{
    class ShapesFactory
    {
        /* create random shape */
        public IShape CreateRandomShape(ShapeType type)
        {
            const int POS_LOW = 150;
            const int POS_HIGH = 350;
            const int SIZE_LOW = 20;
            const int SIZE_HIGH = 50;
            var random = new Random();
            var startPoint = new Point(random.Next(POS_LOW, POS_HIGH), random.Next(POS_LOW, POS_HIGH));
            var endPoint = new Point(random.Next(SIZE_LOW, SIZE_HIGH), random.Next(SIZE_LOW, SIZE_HIGH));
            return CreateShape(type, startPoint, endPoint);
        }

        /* create shape */
        public IShape CreateShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            IShape shape = null;
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
