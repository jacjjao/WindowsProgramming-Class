using System.ComponentModel;
using Point = System.Drawing.Point;
using Pen = System.Drawing.Pen;

namespace PowerPoint
{
    public class PowerPointModel
    {
        private readonly ShapesFactory _factory = new ShapesFactory();

        public BindingList<Shape> ShapesList
        {
            get;
        }

        public Pen DrawPen
        {
            get;
            set;
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
            const float WIDTH = 1.0f;
            DrawPen = new Pen(System.Drawing.Color.Red, WIDTH);
        }

        /* draw all */
        public void DrawAll(IGraphics graphics)
        {
            for (int i = 0; i < ShapesList.Count; i++)
            {
                ShapesList[i].Draw(graphics);
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

        /* remove at */
        public void RemoveAt(int index)
        {
            ShapesList.RemoveAt(index);
        }
    }
}
