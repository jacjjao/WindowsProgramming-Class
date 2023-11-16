using System.ComponentModel;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        private readonly ShapesFactory _factory = new ShapesFactory();
        private Point _drawStartPos = new Point();
        private Point _drawEndPos = new Point();
        private bool _mousePressed = false;
        private ShapeType _type = ShapeType.None;

        /* mouse down */
        public void MouseDown(Shapes list, Point pos, ShapeType type)
        {
            if (type == ShapeType.None)
            {
                return;
            }
            _type = type;
            _mousePressed = true;
            _drawStartPos = _drawEndPos = pos;
            list.AddShape(_type, pos, pos);
        }

        /* mouse move */
        public void MouseMove(Shapes list, Point pos)
        {
            if (!_mousePressed)
            {
                return;
            }
            _drawEndPos = pos;
            list[list.Count - 1] = _factory.CreateShape(_type, _drawStartPos, _drawEndPos);
        }

        /* mouse up */
        public void MouseUp(Shapes list, Point pos)
        {
            if (!_mousePressed)
                return;
            _mousePressed = false;
            _drawEndPos = pos;
            list[list.Count - 1] = _factory.CreateShape(_type, _drawStartPos, _drawEndPos);
        }
    }
}
