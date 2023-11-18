using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class Shapes
    {
        private readonly ShapesFactory _factory = new ShapesFactory(new RandomGenerator());

        public Shapes()
        {
            Content = new BindingList<Shape>
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
                return Content[index];
            }
            set
            {
                Content[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return Content.Count;
            }
        }

        public BindingList<Shape> Content 
        { 
            get; 
        }

        /* add shape */
        public void AddRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            Content.Add(_factory.CreateRandomShape(type, screenWidth, screenHeight));
        }

        /* add shape */
        public void AddShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            Content.Add(_factory.CreateShape(type, pointFirst, pointSecond));
        }

        /* remove */
        public void Remove(Shape shape)
        {
            Content.Remove(shape);
        }

        /* remove at */
        public void RemoveAt(int index)
        {
            Content.RemoveAt(index);
        }

        /* find contain */
        public Shape FindContain(Point point)
        {
            Shape result = null;
            bool found = false;
            foreach (var shape in Content.Reverse())
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
            for (int i = 0; i < Content.Count; i++)
            {
                Content[i].DrawShape(pen, graphics);
            }
        }
    }
}
