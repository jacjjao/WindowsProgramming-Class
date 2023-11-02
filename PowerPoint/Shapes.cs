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
        public BindingList<Shape> Content
        {
            get
            {
                return _list;
            }
        }

        public Shapes()
        {
            _list = new BindingList<Shape>()
            {
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true,
                AllowEdit = true
            };
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

        /* remove at */
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
