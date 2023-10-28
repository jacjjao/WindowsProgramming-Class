using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    class PointState : IState
    {
        Shape _selectedShape = null;
        private Point _prevPosition = new Point();
        private bool _mousePressed = false;
        private int _scaleCircle = -1;

        /* mouse down */
        public void MouseDown(BindingList<Shape> list, Point pos)
        {
            _mousePressed = true;
            _prevPosition = pos;
            if (_selectedShape != null)
            {
                _scaleCircle = _selectedShape.ScaleCircleClick(pos.X, pos.Y);
                if (_scaleCircle >= 0)
                {
                    return;
                }
            }
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
            int dx = pos.X - _prevPosition.X;
            int dy = pos.Y - _prevPosition.Y;
            if (_scaleCircle >= 0)
            {
                switch (_scaleCircle)
                {
                    case 0:
                        _selectedShape.Move(dx, dy);
                        _selectedShape.Resize(-dx, -dy);
                        break;
                    case 1:
                        _selectedShape.Move(0, dy);
                        _selectedShape.Resize(0, -dy);
                        break;
                    case 2:
                        _selectedShape.Move(0, dy);
                        _selectedShape.Resize(dx, -dy);
                        break;
                    case 3:
                        _selectedShape.Move(dx, 0);
                        _selectedShape.Resize(-dx, 0);
                        break;
                    case 4:
                        _selectedShape.Resize(dx, 0);
                        break;
                    case 5:
                        _selectedShape.Move(dx, 0);
                        _selectedShape.Resize(-dx, dy);
                        break;
                    case 6:
                        _selectedShape.Resize(0, dy);
                        break;
                    case 7:
                        _selectedShape.Resize(dx, dy);
                        break;
                }
            }
            else
            {
                _selectedShape?.Move(dx, dy);
            }
            _prevPosition = pos;
        }

        /* mouse up */
        public void MouseUp(BindingList<Shape> list, Point pos)
        {
            _mousePressed = false;
            _selectedShape?.NotifyPropertyChanged();
        }

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
