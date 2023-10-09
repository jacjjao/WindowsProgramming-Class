using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

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

        /* add shape */
        public Shape AddShapes(int index)
        {
            ShapesList.Add(_factory.CreateShape(index));
            return ShapesList.Last();
        }
    }
}
