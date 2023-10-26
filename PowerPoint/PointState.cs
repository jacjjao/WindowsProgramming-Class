using System.ComponentModel;
using System.Linq;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    class PointState : IState
    {
        Shape _selectedShape = null;
        private Point _position = new Point();
        private bool _mousePressed = false;

        /* mouse down */
        public void MouseDown(BindingList<Shape> list, Point pos)
        {
            _mousePressed = true;
            _position = pos;
            _selectedShape = null;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].Contains(pos))
                {
                    _selectedShape = list[i];
                    break;
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
            _selectedShape?.Move(pos.X - _position.X, pos.Y - _position.Y);
            _position = pos;
        }

        /* mouse up */
        public void MouseUp(BindingList<Shape> list, Point pos)
        {
            _mousePressed = false;
        }

        /* select shape type */
        public void SetShapeType(ShapeType type)
        {
        }
    }
}
