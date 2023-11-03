using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class Shapes
    {
        private readonly ShapesFactory _factory = new ShapesFactory();
        private BindingList<Shape> _list;

        public Shapes()
        {
            _list = new BindingList<Shape>
            {
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true,
                AllowEdit = true,
            };
        }

        public Shape this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public BindingList<Shape> Content
        {
            get
            {
                return _list;
            }
        }

        /* add shape */
        public void AddRandomShape(ShapeType type)
        {
            _list.Add(_factory.CreateRandomShape(type));
        }

        /* add shape */
        public void AddShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            _list.Add(_factory.CreateShape(type, pointFirst, pointSecond));
        }

        public void Remove(Shape shape)
        {
            _list.Remove(shape);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        /* draw all */
        public void DrawAll(IGraphics graphics)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].DrawShape(graphics);
            }
        }
    }
}
