using System.ComponentModel;
using System.Windows.Forms;
using Pen = System.Drawing.Pen;

namespace PowerPoint
{
    public class PowerPointModel
    {
        private Shapes _list = new Shapes();
        public Shapes ShapeList
        {
            get
            {
                return _list;
            }
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

        public ShapeType SelectedShape
        {
            get;
            set;
        }

        public PowerPointModel()
        {
            State = new DrawingState();
            const float WIDTH = 1.0f;
            DrawPen = new Pen(System.Drawing.Color.Red, WIDTH);
        }

        /* draw all */
        public void DrawAll(IGraphics graphics)
        {
            ShapeList.DrawAll(graphics);
        }

        /* mouse down */
        public void DoMouseDown(MouseEventArgs e)
        {
            State.MouseDown(ShapeList, e.Location, SelectedShape);
        }

        /* mouse move */
        public void DoMouseMove(MouseEventArgs e)
        {
            State.MouseMove(ShapeList, e.Location);
        }

        /* mouse up */
        public void DoMouseUp(MouseEventArgs e)
        {
            State.MouseUp(ShapeList, e.Location);
        }

        /* add shape */
        public void AddRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            ShapeList.AddRandomShape(type, screenWidth, screenHeight);
            SelectedShape = type;
        }

        /* remove at */
        public void RemoveAt(int index)
        {
            ShapeList.RemoveAt(index);
        }

        /* keydown */
        public void DoKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && State is PointState)
            {
                var state = (PointState)State;
                state.RemoveSelectedShape(ShapeList);
            }
        }
    }
}
