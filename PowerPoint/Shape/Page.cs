using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class Page
    {
        readonly ShapesFactory _factory = new ShapesFactory(new RandomGenerator());
        readonly BindingList<Shape> _list = new BindingList<Shape>();

        public Page()
        {
            _list.AllowEdit = true;
            _list.AllowNew = true;
            _list.RaiseListChangedEvents = true;
            _list.AllowRemove = true;
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
        public void AddRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            _list.Add(_factory.CreateRandomShape(type, screenWidth, screenHeight));
        }

        /* add shape */
        public void AddShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            _list.Add(_factory.CreateShape(type, pointFirst, pointSecond));
        }

        /* remove */
        public void Remove(Shape shape)
        {
            _list.Remove(shape);
        }

        /* remove at */
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        /* find contain */
        public Shape FindContain(Point point)
        {
            Shape result = null;
            bool found = false;
            foreach (var shape in _list.Reverse())
            {
                if (!found && shape.Contains(point))
                {
                    shape.Selected = true;
                    result = shape;
                    found = true;
                }
                else
                {
                    shape.Selected = false;
                }
            }
            return result;
        }

        /* draw all */
        public void DrawAll(Pen pen, IGraphics graphics)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].DrawShape(pen, graphics);
            }
        }
    }
}
