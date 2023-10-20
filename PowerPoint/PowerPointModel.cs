using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PowerPointModel
    {
        private readonly ShapesFactory _factory = new ShapesFactory();

        public BindingList<Shape> ShapesList
        {
            get;
        }

        public PowerPointModel()
        {
            ShapesList = new BindingList<Shape>
            {
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true,
                AllowEdit = true
            };
        }

        /* draw all */
        public void DrawAll(System.Drawing.Graphics graphics, System.Drawing.Pen pen)
        {
            for (int i = 0; i < ShapesList.Count; i++)
            {
                ShapesList[i].Draw(graphics, pen);
            }
        }

        /* create shape */
        public Shape CreateShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            return _factory.CreateShape(type, pointFirst, pointSecond);
        }

        /* add shape */
        public void AddShape(ShapeType type)
        {
            ShapesList.Add(_factory.CreateRandomShape(type));
        }

        /* add shape */
        public void AddShape(ShapeType type, Point pointFirst, Point pointSecond)
        {
            ShapesList.Add(_factory.CreateShape(type, pointFirst, pointSecond));
        }
    }
}
