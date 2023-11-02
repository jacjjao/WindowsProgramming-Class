using System.ComponentModel;
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
            _selectedShape = null;
            bool found = false;
            for (int i = list.Content.Count - 1; i >= 0; i--)
            {
                if (!found && list.Content[i].Contains(pos))
                {
                    list.Content[i].Selected = true;
                    _selectedShape = list.Content[i];
                    found = true;
                }
                else
                {
                    list.Content[i].Selected = false;
                }
            }
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
            list.Content.Remove(_selectedShape);
            _selectedShape = null;
        }
    }
}
