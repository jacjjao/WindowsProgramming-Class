using System.ComponentModel;
using System.Windows.Forms;
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

        public IState State
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
            State = new DrawingState();
            const float WIDTH = 1.0f;
            DrawPen = new Pen(System.Drawing.Color.Red, WIDTH);
        }

        /* draw all */
        public void DrawAll(IGraphics graphics)
        {
            for (int i = 0; i < ShapesList.Count; i++)
            {
                ShapesList[i].DrawShape(graphics);
            }
        }

        /* mouse down */
        public void DoMouseDown(MouseEventArgs e)
        {
            State.MouseDown(ShapesList, e.Location);
        }

        /* mouse move */
        public void DoMouseMove(MouseEventArgs e)
        {
            State.MouseMove(ShapesList, e.Location);
        }

        /* mouse up */
        public void DoMouseUp(MouseEventArgs e)
        {
            State.MouseUp(ShapesList, e.Location);
        }

        /* add shape */
        public void AddShape(ShapeType type)
        {
            ShapesList.Add(_factory.CreateRandomShape(type));
        }

        /* remove at */
        public void RemoveAt(int index)
        {
            ShapesList.RemoveAt(index);
        }

        /* keydown */
        public void DoKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                State.RemoveSelectedShape(ShapesList);
            }
        }
    }
}
