using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class Model
    {
        private readonly ShapesFactory _factory = new ShapesFactory();

        public BindingList<IShape> ShapesList
        {
            get;
        }

        public Model()
        {
            ShapesList = new BindingList<IShape>
            {
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true,
                AllowEdit = true
            };
        }

        /* create shape */
        public IShape CreateShape(ShapeType type, Point pointFirst, Point pointSecond)
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
