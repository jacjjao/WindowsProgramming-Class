using System;
using System.Drawing;

namespace PowerPoint
{
    class ShapesFactory
    {
        /* create shape */
        public Shape CreateShape(ShapeType type)
        {
            const int POS_LOW = 100;
            const int POS_HIGH = 300;
            const int SIZE_LOW = 20;
            const int SIZE_HIGH = 100;
            var random = new Random();
            var startPoint = new Point(random.Next(POS_LOW, POS_HIGH), random.Next(POS_LOW, POS_HIGH));
            var endPoint = new Point(random.Next(SIZE_LOW, SIZE_HIGH), random.Next(SIZE_LOW, SIZE_HIGH));
            return CreateShape(type, startPoint, endPoint);
        }

        public Shape CreateShape(ShapeType type, Point p1, Point p2)
        {
            Shape shape = null;
            switch (type)
            {
                case ShapeType.Rectangle:
                    shape = new Rectangle(p1, p2);
                    break;
                case ShapeType.Line:
                    shape = new Line
                    {
                        StartPoint = p1,
                        EndPoint = p2
                    };
                    break;
                case ShapeType.Circle:
                    shape = new Circle(p1, p2);
                    break;
            }
            return shape;
        }
    }
}
