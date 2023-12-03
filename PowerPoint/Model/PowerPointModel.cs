using System.Windows.Forms;
using Pen = System.Drawing.Pen;
using Point = System.Drawing.Point;

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

        IState _state;
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

        CommandManager _manager = null;
        public CommandManager Manager
        {
            get
            {
                return _manager;
            }
        }

        public PowerPointModel()
        {
            _manager = new CommandManager(_list);
            State = new PointState
            {
                Manager = _manager
            };
        }

        /* draw all */
        public void DrawAll(IGraphics graphics)
        {
            Manager.Execute(new DrawCommand { DrawPen = DrawPen, Graphics = graphics });
        }

        /* mouse down */
        public Cursor DoMouseDown(Point position)
        {
            return State.MouseDown(ShapeList, position);
        }

        /* mouse move */
        public Cursor DoMouseMove(Point position)
        {
            return State.MouseMove(ShapeList, position);
        }

        /* mouse up */
        public Cursor DoMouseUp(Point position)
        {
            SelectedShape = ShapeType.None;
            return State.MouseUp(ShapeList, position);
        }

        /* add shape */
        public void AddRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            AddCommand command = new AddCommand
            {
                AddRandom = true,
                Type = type,
                ScreenWidth = screenWidth,
                ScreenHeight = screenHeight
            };
            _manager.Execute(command);
        }

        /* remove at */
        public void RemoveAt(int index)
        {
            DeleteCommand command = new DeleteCommand
            {
                DeleteIndex = index
            };
            _manager.Execute(command);
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
