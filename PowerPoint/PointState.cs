using System.ComponentModel;
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
            _selectedShape?.Move(pos.X - _position.X, pos.Y - _position.Y);
            _position = pos;
        }

        /* mouse up */
        public void MouseUp(BindingList<Shape> list, Point pos)
        {
            _mousePressed = false;
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
