using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Drawing;
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

        /* add shape */
        public Shape AddShape(ShapeType type)
        {
            ShapesList.Add(_factory.CreateShape(type));
            return ShapesList.Last();
        }

        public Shape AddShape(ShapeType type, Point p1, Point p2)
        {
            ShapesList.Add(_factory.CreateShape(type, p1, p2));
            return ShapesList.Last();
        }

        public void DrawAll(Graphics graphics, Pen pen)
        {
            ShapesList.ForEach((shape) => shape.Draw(graphics, pen));
        }
    }
}
