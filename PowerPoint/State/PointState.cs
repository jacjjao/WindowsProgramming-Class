using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PointState : IState
    {
        Shape _selectedShape = null;
        Point _previousMousePosition = new Point();
        bool _mousePressed = false;
        ResizeDirection _direction = ResizeDirection.None;
        MoveCommand _commandBuffer = null;

        public CommandManager Manager
        {
            get;
            set;
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
            _previousMousePosition = pos;
            if (_selectedShape != null)
            {
                _direction = _selectedShape.GetResizeDirection(pos);
                if (_direction != ResizeDirection.None)
                {
                    _commandBuffer = new MoveCommand
                    {
                        ScaleDirect = _direction,
                        SelectShape = _selectedShape
                    };
                    return GetCursor(_direction);
                }
            }
            _selectedShape = list.FindContain(pos);
            if (_selectedShape != null)
            {
                _commandBuffer = new MoveCommand
                {
                    ScaleDirect = ResizeDirection.None,
                    SelectShape = _selectedShape
                };
            }
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

        /* mouse move */
        public Cursor MouseMove(Shapes list, Point pos)
        {
            if (_selectedShape == null)
                return Cursors.Default;
            if (!_mousePressed)
            {
                return DoShapeResize(pos);
            }
            int differenceX = pos.X - _previousMousePosition.X;
            int differenceY = pos.Y - _previousMousePosition.Y;
            _previousMousePosition = pos;
            _direction = _selectedShape.ResizeBasedOnDirection(_direction, differenceX, differenceY);
            if (_direction == ResizeDirection.None)
            {
                _commandBuffer.MoveX += differenceX;
                _commandBuffer.MoveY += differenceY;
            }
            else
            {
                _commandBuffer.ScaleDirect = _direction;
                _commandBuffer.ScaleX += differenceX;
                _commandBuffer.ScaleY += differenceY;
            }
            return GetCursor(_direction);
        }

        /* mouse up */
        public Cursor MouseUp(Shapes list, Point pos)
        {
            _mousePressed = false;
            if (_selectedShape != null)
            {
                _selectedShape.NotifyPropertyChanged();
                if (Manager != null && (_commandBuffer.MoveX != 0 || _commandBuffer.MoveY != 0 || _commandBuffer.ScaleX != 0 || _commandBuffer.ScaleY != 0))
                    Manager.AddCommand(_commandBuffer);
                return _selectedShape.Contains(pos) ? Cursors.SizeAll : Cursors.Default;
            }
            return Cursors.Default;
        }

        /* remove selected shape */
        public void RemoveSelectedShape(Shapes list)
        {
            list.Remove(_selectedShape);
            _selectedShape = null;
        }
    }
}
