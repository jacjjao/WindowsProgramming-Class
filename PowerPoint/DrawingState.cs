using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    class DrawingState : IState
    {
        private readonly ShapesFactory _factory = new ShapesFactory();
        private Point _drawStartPos = new Point();
        private Point _drawEndPos = new Point();
        private bool _mousePressed = false;
        private ShapeType _type = ShapeType.None;

        public void MouseDown(BindingList<Shape> list, Point pos)
        {
            if (_type == ShapeType.None)
            {
                return;
            }
            _mousePressed = true;
            _drawStartPos = _drawEndPos = pos;
            list.Add(_factory.CreateShape(_type, _drawStartPos, _drawEndPos));
        }

        public void MouseMove(BindingList<Shape> list, Point pos)
        {
            if (!_mousePressed)
            {
                return;
            }
            _drawEndPos = pos;
            list[list.Count - 1] = _factory.CreateShape(_type, _drawStartPos, _drawEndPos);
        }

        public void MouseUp(BindingList<Shape> list, Point pos)
        {
            if (!_mousePressed)
                return;
            _mousePressed = false;
            _drawEndPos = pos;
            list[list.Count - 1] = _factory.CreateShape(_type, _drawStartPos, _drawEndPos);
            _type = ShapeType.None;
        }

        public void SelectShapeType(ShapeType type)
        {
            _type = type;
        }
    }
}
