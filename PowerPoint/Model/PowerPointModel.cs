using System.Windows.Forms;
using Pen = System.Drawing.Pen;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PowerPointModel
    {
        readonly PageManager _pageManager = new PageManager();
        public PageManager PageManager
        {
            get
            {
                return _pageManager;
            }
        }
        public Page CurrentPage
        {
            get
            {
                return _pageManager.CurrentPage;
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
                _state.SetShapeType(_selectType);
            }
        }

        CommandManager _commandManager = null;
        public CommandManager CommandManager
        {
            get
            {
                return _commandManager;
            }
        }

        public PowerPointModel()
        {
            _commandManager = new CommandManager(_pageManager.CurrentPage);
            State = new PointState
            {
                Manager = _commandManager
            };
            PageManager._currentPageChanged += DoCurrentPageChange;
        }

        // current page change
        private void DoCurrentPageChange()
        {
            CommandManager.CurrentPage = PageManager.CurrentPage;
        }

        // add blank page
        public void AddBlankPage()
        {
            _pageManager.AddBlankPage();
        }

        // set current page
        public void SetCurrentPage(int index)
        {
            _pageManager.SetCurrentPage(index);
        }

        // draw page
        public void DrawPage(int index, IGraphics graphics)
        {
            _pageManager.DrawPage(index, DrawPen, graphics);
        }

        /* draw all */
        public void DrawCurrentPage(IGraphics graphics)
        {
            _pageManager.CurrentPage.DrawAll(DrawPen, graphics);
        }

        /* mouse down */
        public Cursor DoMouseDown(Point position)
        {
            return State.MouseDown(CurrentPage, position);
        }

        /* mouse move */
        public Cursor DoMouseMove(Point position)
        {
            return State.MouseMove(CurrentPage, position);
        }

        /* mouse up */
        public Cursor DoMouseUp(Point position)
        {
            SelectedShape = ShapeType.None;
            return State.MouseUp(CurrentPage, position);
        }

        /* add shape */
        public void AddRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            AddCommand command = new AddCommand();
            command.AddRandom = true;
            command.Type = type;
            command.ScreenWidth = screenWidth;
            command.ScreenHeight = screenHeight;
            _commandManager.Execute(command);
        }

        /* remove at */
        public void RemoveAt(int index)
        {
            DeleteCommand command = new DeleteCommand();
            command.DeleteIndex = index;
            _commandManager.Execute(command);
        }

        /* keydown */
        public void DoKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && State is PointState)
            {
                var state = (PointState)State;
                state.RemoveSelectedShape(CurrentPage);
            }
        }
    }
}
