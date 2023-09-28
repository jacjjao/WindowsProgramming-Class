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

        private readonly ShapesFactory _factory;

        public Model()
        {
            ShapesList = new List<Shape>();
            _factory = new ShapesFactory();
        }

        /* 新增新的shape */
        public void AddShape(int index)
        {
            var shape = _factory.CreateShape(index); // 我只有呼叫一次factory的method但Dr.Smell說我呼叫兩次?
            if (shape != null)
            {
                ShapesList.Add(shape);
            }
        }
    }
}
