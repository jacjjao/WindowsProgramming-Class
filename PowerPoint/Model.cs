using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class Model
    {
        private readonly ShapesFactory _factory;

        public List<Shape> ShapesList
        {
            get;
        }

        public Model()
        {
            ShapesList = new List<Shape>();
            _factory = new ShapesFactory();
        }

        /* create shape */
        public Shape CreateShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            return _factory.CreateShape(type, pointFirst, pointSecond);
        }

        /* add shape */
        public Shape AddShape(ShapeType type)
        {
            ShapesList.Add(_factory.CreateShape(type));
            return ShapesList.Last();
        }

        /* add shape */
        public Shape AddShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            ShapesList.Add(_factory.CreateShape(type, pointFirst, pointSecond));
            return ShapesList.Last();
        }
    }
}
