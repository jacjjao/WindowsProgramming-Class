﻿using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        Point _drawStartPos = new Point();
        Point _drawEndPos = new Point();
        bool _mousePressed = false;
        ShapeType _type = ShapeType.None;

        public CommandManager Manager
        {
            get;
            set;
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
            _drawStartPos = _drawEndPos = pos;
            list.AddShape(_type, pos, pos);
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
            list[list.Count - 1].Resize(_drawStartPos, _drawEndPos);
            return Cursors.Cross;
        }

        /* mouse up */
        public Cursor MouseUp(Shapes list, Point pos)
        {
            if (!_mousePressed)
                return Cursors.Default;
            _mousePressed = false;
            _drawEndPos = pos;
            list[list.Count - 1].Resize(_drawStartPos, _drawEndPos);
            list[list.Count - 1].NotifyPropertyChanged();
            if (Manager != null)
            {
                Manager.AddCommand(new AddCommand
                {
                    AddRandom = false,
                    PointFirst = _drawStartPos,
                    PointSecond = _drawEndPos,
                    Type = _type,
                    AddShape = list[list.Count - 1]
                });
            }
            return Cursors.Default;
        }
    }
}
