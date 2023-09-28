using System;
using System.Windows;

namespace PowerPoint
{
    class ShapesFactory
    {
        /* create shape */
        public Shape CreateShape(int index)
        {
            const int LOW = 10;
            const int HIGH = 100;
            var random = new Random();
            var startPoint = new Vector(random.Next(LOW, HIGH), random.Next(LOW, HIGH));
            var endPoint = new Vector(random.Next(LOW, HIGH), random.Next(LOW, HIGH));
            Shape shape = null;
            switch (index)
            {
                case 0:
                    shape = new Rectangle (startPoint, endPoint);
                    break;
                case 1:
                    shape = new Line(startPoint, endPoint);
                    break;
            }
            return shape;
        }
    }
}
