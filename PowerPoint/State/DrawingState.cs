﻿using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        Point _drawStartPos = new Point();
        Point _drawEndPos = new Point();
        bool _mousePressed = false;
        ShapeType _type = ShapeType.None;

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
            list[list.Count - 1].Resize(_drawStartPos, _drawEndPos);
        }

        /* mouse up */
        public void MouseUp(Shapes list, Point pos)
        {
            if (!_mousePressed)
                return;
            _mousePressed = false;
            _drawEndPos = pos;
            list[list.Count - 1].Resize(_drawStartPos, _drawEndPos);
            list[list.Count - 1].NotifyPropertyChanged();
        }
    }
}
