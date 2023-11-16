using Point = System.Drawing.Point;

namespace PowerPoint
{
    class PointState : IState
    {
        private Shape _selectedShape = null;
        private Point _previousMousePosition = new Point();
        private bool _mousePressed = false;

        /* mouse down */
        public void MouseDown(Shapes list, Point pos, ShapeType type)
        {
            _mousePressed = true;
            _previousMousePosition = pos;
            _selectedShape = list.FindContain(pos);
        }

        /* mouse move */
        public void MouseMove(Shapes list, Point pos)
        {
            if (!_mousePressed)
            {
                return;
            }
            int differenceX = pos.X - _previousMousePosition.X;
            int differenceY = pos.Y - _previousMousePosition.Y;
            if (_selectedShape != null)
            {
                _selectedShape.Move(differenceX, differenceY);
            }
            _previousMousePosition = pos;
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
