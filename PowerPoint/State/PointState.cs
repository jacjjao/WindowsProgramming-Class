using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PointState : IState
    {
        Shape _selectedShape = null;
        Point _previousMousePosition = new Point();
        bool _mousePressed = false;
        ResizeDirection _direction = ResizeDirection.None;

        /* mouse down */
        public void MouseDown(Shapes list, Point pos, ShapeType type)
        {
            _mousePressed = true;
            _previousMousePosition = pos;
            if (_selectedShape != null)
            {
                _direction = _selectedShape.GetResizeDirection(pos);
                if (_direction != ResizeDirection.None)
                    return;
            }
            _selectedShape = list.FindContain(pos);
            _direction = ResizeDirection.None;
        }

        /* mouse move */
        public void MouseMove(Shapes list, Point pos)
        {
            if (!_mousePressed)
                return;
            int differenceX = pos.X - _previousMousePosition.X;
            int differenceY = pos.Y - _previousMousePosition.Y;
            _previousMousePosition = pos;
            if (_selectedShape == null)
                return;
            _direction = _selectedShape.ResizeBasedOnDirection(_direction, differenceX, differenceY);
        }

        /* mouse up */
        public void MouseUp(Shapes list, Point pos)
        {
            _mousePressed = false;
            if (_selectedShape != null)
            {
                _selectedShape.NotifyPropertyChanged();
            }
        }

        /* remove selected shape */
        public void RemoveSelectedShape(Shapes list)
        {
            list.Remove(_selectedShape);
            _selectedShape = null;
        }
    }
}
