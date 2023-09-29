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
            set;
        }

        public Model()
        {
            ShapesList = new List<Shape>();
        }
    }
}
