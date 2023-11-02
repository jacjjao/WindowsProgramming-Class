using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class Shapes : BindingList<Shape>
    {
        private readonly ShapesFactory _factory = new ShapesFactory();

        public Shapes()
        {
            AllowNew = true;
            AllowRemove = true;
            RaiseListChangedEvents = true;
            AllowEdit = true;
        }

        /* add shape */
        public void AddRandomShape(ShapeType type)
        {
            Add(_factory.CreateRandomShape(type));
        }

        /* add shape */
        public void AddShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            Add(_factory.CreateShape(type, pointFirst, pointSecond));
        }

        /* draw all */
        public void DrawAll(IGraphics graphics)
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].DrawShape(graphics);
            }
        }
    }
}
