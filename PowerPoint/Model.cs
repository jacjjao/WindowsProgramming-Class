using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace PowerPoint
{
    class Model
    {
        public List<Shape> ShapesList 
        { 
            get; 
        }

        public Model()
        {
            ShapesList = new List<Shape>();
        }

        /* 新增新的shape */
        public void AddShape(Shape shape)
        {
            if (shape != null)
            {
                ShapesList.Add(shape);
            }
        }
    }
}
