using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        Point _drawStartPos = new Point();
        Point _drawEndPos = new Point();
        bool _mousePressed = false;
        bool _mouseMoved = false;
        ShapeType _type = ShapeType.None;
        Shape _shape = null;

        ICommandManager _manager;
        public ICommandManager Manager
        {
            get
            {
                return _manager;
            }
            set
            {
                _manager = value;
            }
        }

        /* set type */
        public void SetShapeType(ShapeType type)
        {
            _type = type;
        }

        /* mouse down */
        public Cursor MouseDown(Shapes list, Point pos)
        {
            if (_type == ShapeType.None)
            {
                return Cursors.Default;
            }
            _mousePressed = true;
            _mouseMoved = false;
            _drawStartPos = _drawEndPos = pos;
            return Cursors.Cross;
        }

        /* mouse move */
        public Cursor MouseMove(Shapes list, Point pos)
        {
            if (!_mousePressed)
            {
                return _type == ShapeType.None ? Cursors.Default : Cursors.Cross;
            }
            _drawEndPos = pos;
            if (!_mouseMoved)
            {
                var command = new AddCommand
                {
                    AddRandom = false,
                    PointFirst = _drawStartPos,
                    PointSecond = _drawEndPos,
                    Type = _type,
                };
                if (_manager == null)
                    command.Execute(list);
                else
                    _manager.Execute(command);
                _shape = command.AddShape;
                _mouseMoved = true;
            }
            else
            {
                _shape.CreationResize(_drawStartPos, _drawEndPos);
            }
            return Cursors.Cross;
        }

        /* mouse up */
        public Cursor MouseUp(Shapes list, Point pos)
        {
            if (!_mousePressed)
                return Cursors.Default;
            _mousePressed = false;
            if (list.Count > 0)
                list[list.Count - 1].NotifyPropertyChanged();
            return Cursors.Default;
        }
    }
}
