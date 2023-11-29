using System.Windows.Forms;
using Pen = System.Drawing.Pen;

namespace PowerPoint
{
    public class PowerPointModel
    {
        readonly Shapes _list = new Shapes();
        public Shapes ShapeList
        {
            get
            {
                return _list;
            }
        }

        const float DEFAULT_WIDTH = 1.0f;
        Pen _pen = new Pen(System.Drawing.Color.Red, DEFAULT_WIDTH);
        public Pen DrawPen
        {
            get
            {
                return _pen;
            }
            set
            {
                _pen = value;
            }
        }

        IState _state = new DrawingState();
        public IState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        ShapeType _selectType = ShapeType.None;
        public ShapeType SelectedShape
        {
            get
            {
                return _selectType;
            }
            set
            {
                _selectType = value;
                if (State is DrawingState)
                {
                    ((DrawingState)State).SetShapeType(_selectType);
                }
            }
        }

        /* draw all */
        public void DrawAll(IGraphics graphics)
        {
            ShapeList.DrawAll(DrawPen, graphics);
        }

        /* mouse down */
        public Cursor DoMouseDown(MouseEventArgs e)
        {
            return State.MouseDown(ShapeList, e.Location);
        }

        /* mouse move */
        public Cursor DoMouseMove(MouseEventArgs e)
        {
            return State.MouseMove(ShapeList, e.Location);
        }

        /* mouse up */
        public Cursor DoMouseUp(MouseEventArgs e)
        {
            SelectedShape = ShapeType.None;
            return State.MouseUp(ShapeList, e.Location);
        }

        /* add shape */
        public void AddRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            _list.AddRandomShape(type, screenWidth, screenHeight);
        }

        /* remove at */
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
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
