using Point = System.Drawing.Point;
using System.Windows.Forms;

namespace PowerPoint
{
    public class PointState : IState
    {
        Shape _selectedShape = null;
        Point _previousMousePosition = new Point();
        bool _mousePressed = false;
        ResizeDirection _direction = ResizeDirection.None;

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
                    return GetCursor(_direction);
                }
            }
            _selectedShape = list.FindContain(pos);
            _direction = ResizeDirection.None;
            return Cursors.SizeAll;
        }

        /* mouse move */
        public Cursor MouseMove(Shapes list, Point pos)
        {
            if (_selectedShape == null)
            {
                return Cursors.Default;
            }
            if (!_mousePressed)
            {
                const int DIRECTION_NUMBER = 8;
                const int ONE = 1;
                ResizeDirection direction = ResizeDirection.TopLeft;
                for (int i = 0; i < DIRECTION_NUMBER; i++)
                {
                    if (_selectedShape.IsInCircle(direction, pos))
                    {
                        return GetCursor(direction);
                    }
                    direction = (ResizeDirection)((int)direction + ONE);
                }   
                return _selectedShape.IsInHitBox(pos) ? Cursors.SizeAll : Cursors.Default;
            }
            int differenceX = pos.X - _previousMousePosition.X;
            int differenceY = pos.Y - _previousMousePosition.Y;
            _previousMousePosition = pos;
            _direction = _selectedShape.ResizeBasedOnDirection(_direction, differenceX, differenceY);
            return GetCursor(_direction);
        }

        /* mouse up */
        public Cursor MouseUp(Shapes list, Point pos)
        {
            _mousePressed = false;
            if (_selectedShape != null)
            {
                _selectedShape.NotifyPropertyChanged();
                return _selectedShape.Contains(pos) ? Cursors.Default : Cursors.SizeAll;
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
