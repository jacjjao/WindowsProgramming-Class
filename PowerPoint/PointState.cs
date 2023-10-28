using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    class PointState : IState
    {
        Shape _selectedShape = null;
        private Point _previousMousePosition = new Point();
        private bool _mousePressed = false;

        /* mouse down */
        public void MouseDown(BindingList<Shape> list, Point pos)
        {
            _mousePressed = true;
            _previousMousePosition = pos;
            _selectedShape = null;
            bool found = false;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (!found && list[i].Contains(pos))
                {
                    list[i].Selected = true;
                    _selectedShape = list[i];
                    found = true;
                }
                else
                {
                    list[i].Selected = false;
                }
            }
        }

        /* mouse move */
        public void MouseMove(BindingList<Shape> list, Point pos)
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
        public void MouseUp(BindingList<Shape> list, Point pos)
        {
            _mousePressed = false;
            if (_selectedShape != null)
            {
                _selectedShape.NotifyPropertyChanged();
            }
        }

        /* remove selected shape */
        public void RemoveSelectedShape(BindingList<Shape> list)
        {
            list.Remove(_selectedShape);
            _selectedShape = null;
        }

        /* select shape type */
        public void SetShapeType(ShapeType type)
        {
        }
    }
}
