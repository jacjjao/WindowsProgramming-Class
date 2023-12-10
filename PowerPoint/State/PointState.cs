using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PointState : IState
    {
        Shape _selectedShape = null;
        Point _previousMousePosition = new Point();
        bool _mousePressed = false;
        bool _mouseMoved = false;
        ResizeDirection _direction = ResizeDirection.None;

        ICommandManager _manager = null;
        public ICommandManager Manager
        {
            get
            {
                return _manager;
            }
            set
            {
                _manager = value;
            }
        }

        /* get cursor */
        private Cursor GetCursor(ResizeDirection direction)
        {
            switch (direction)
            {
                case ResizeDirection.BottomMiddle:
                case ResizeDirection.TopMiddle:
                    return Cursors.SizeNS;
                case ResizeDirection.TopLeft:
                case ResizeDirection.BottomRight:
                    return Cursors.SizeNWSE;
                case ResizeDirection.TopRight:
                case ResizeDirection.BottomLeft:
                    return Cursors.SizeNESW;
                case ResizeDirection.MiddleLeft:
                case ResizeDirection.MiddleRight:
                    return Cursors.SizeWE;
                default:
                    return Cursors.SizeAll;
            }
        }

        /* mouse down */
        public Cursor MouseDown(Shapes list, Point pos)
        {
            _mousePressed = true;
            _mouseMoved = false;
            _previousMousePosition = pos;
            if (_selectedShape != null)
            {
                _direction = _selectedShape.GetResizeDirection(pos);
                if (_direction != ResizeDirection.None)
                {
                    return GetCursor(_direction);
                }
            }
            _selectedShape = list.FindContain(pos);
            _direction = ResizeDirection.None;
            return _selectedShape == null ? Cursors.Default : Cursors.SizeAll;
        }

        /* do shape resize */
        private Cursor DoShapeResize(Point pos)
        {
            const int DIRECTION_NUMBER = 8;
            const int ONE = 1;
            ResizeDirection direction = ResizeDirection.TopLeft;
            for (int i = 0; i < DIRECTION_NUMBER; i++)
            {
                if (_selectedShape.IsInCircle(direction, pos))
                    return GetCursor(direction);
                direction = (ResizeDirection)((int)direction + ONE);
            }
            return _selectedShape.IsInHitBox(pos) ? Cursors.SizeAll : Cursors.Default;
        }

        /* create move command */
        private MoveCommand CreateMoveCommand(Point pos)
        {
            var command = new MoveCommand();
            command.SelectShape = _selectedShape;
            command.ScaleDirect = _direction;
            command.MoveX = pos.X - _previousMousePosition.X;
            command.MoveY = pos.Y - _previousMousePosition.Y;
            return command;
        }

        /* mouse move */
        public Cursor MouseMove(Shapes list, Point pos)
        {
            if (_selectedShape == null)
                return Cursors.Default;
            if (!_mousePressed)
                return DoShapeResize(pos);
            var command = CreateMoveCommand(pos);
            if (_manager == null)
                command.Execute(list);
            else
            {
                var option = new ExecuteOption();
                option.CombindWithPreviousCommand = _mouseMoved;
                option.ResetDataBindings = false;
                _manager.Execute(command, option);
            }
            _previousMousePosition = pos;
            _mouseMoved = true;
            _direction = command.ScaleDirect;
            return GetCursor(_direction);
        }

        /* mouse up */
        public Cursor MouseUp(Shapes list, Point pos)
        {
            _mousePressed = false;
            if (_selectedShape != null)
            {
                _selectedShape.NotifyPropertyChanged();
                return _selectedShape.Contains(pos) ? Cursors.SizeAll : Cursors.Default;
            }
            return Cursors.Default;
        }

        /* set shape type */
        public void SetShapeType(ShapeType type)
        {
            /* nothing */
        }

        /* remove selected shape */
        public void RemoveSelectedShape(Shapes list)
        {
            if (_selectedShape == null)
                return;
            var command = new DeleteCommand();
            command.DeleteIndex = list.Content.IndexOf(_selectedShape);
            if (_manager == null)
                command.Execute(list);
            else
                _manager.Execute(command);
            _selectedShape = null;
        }
    }
}
