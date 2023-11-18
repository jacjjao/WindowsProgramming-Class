using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PointState : IState
    {
        Shape _selectedShape = null;
        Point _previousMousePosition = new Point();
        bool _mousePressed = false;
        ResizeDirection _direction = ResizeDirection.None;

        /* mouse down */
        public void MouseDown(Shapes list, Point pos, ShapeType type)
        {
            _mousePressed = true;
            _previousMousePosition = pos;
            if (_selectedShape != null)
            {
                _direction = _selectedShape.GetResizeDirection(pos);
                if (_direction != ResizeDirection.None)
                    return;
            }
            _selectedShape = list.FindContain(pos);
            _direction = ResizeDirection.None;
        }

        /* mouse move */
        public void MouseMove(Shapes list, Point pos)
        {
            if (!_mousePressed)
                return;
            int differenceX = pos.X - _previousMousePosition.X;
            int differenceY = pos.Y - _previousMousePosition.Y;
            _previousMousePosition = pos;
            if (_selectedShape == null)
                return;
            var pointFirst = new Point(_selectedShape.HitBox.X, _selectedShape.HitBox.Y);
            var pointSecond = new Point(pointFirst.X + _selectedShape.HitBox.Width, pointFirst.Y + _selectedShape.HitBox.Height);
            if (_direction == ResizeDirection.None)
            {
                _selectedShape.Move(differenceX, differenceY);
                return;
            }
            switch (_direction)
            {
                case ResizeDirection.TopLeft:
                    pointFirst.X += differenceX;
                    pointFirst.Y += differenceY;
                    if (pointFirst.X > pointSecond.X && pointFirst.Y < pointSecond.Y)
                    {
                        _direction = ResizeDirection.TopRight;
                    }
                    else if (pointFirst.X < pointSecond.X && pointFirst.Y > pointSecond.Y)
                    {
                        _direction = ResizeDirection.BottomLeft;
                    }
                    break;

                case ResizeDirection.TopMiddle:
                    pointFirst.Y += differenceY;
                    if (pointFirst.Y > pointSecond.Y)
                    {
                        _direction = ResizeDirection.BottomMiddle;
                    }
                    break;

                case ResizeDirection.TopRight:
                    pointSecond.X += differenceX;
                    pointFirst.Y += differenceY;
                    if (pointFirst.X > pointSecond.X && pointFirst.Y < pointSecond.Y)
                    {
                        _direction = ResizeDirection.TopLeft;
                    }
                    else if (pointFirst.X < pointSecond.X && pointFirst.Y > pointSecond.Y)
                    {
                        _direction = ResizeDirection.BottomRight;
                    }
                    break;

                case ResizeDirection.MiddleLeft:
                    pointFirst.X += differenceX;
                    if (pointFirst.X > pointSecond.X)
                    {
                        _direction = ResizeDirection.MiddleRight;
                    }
                    break;

                case ResizeDirection.MiddleRight:
                    pointSecond.X += differenceX;
                    if (pointFirst.X > pointSecond.X)
                    {
                        _direction = ResizeDirection.MiddleLeft;
                    }
                    break;

                case ResizeDirection.BottomLeft:
                    pointFirst.X += differenceX;
                    pointSecond.Y += differenceY;
                    if (pointFirst.X > pointSecond.X && pointFirst.Y < pointSecond.Y)
                    {
                        _direction = ResizeDirection.BottomRight;
                    }
                    else if (pointFirst.X < pointSecond.X && pointFirst.Y > pointSecond.Y)
                    {
                        _direction = ResizeDirection.TopLeft;
                    }
                    break;

                case ResizeDirection.BottomMiddle:
                    pointSecond.Y += differenceY;
                    if (pointFirst.Y > pointSecond.Y)
                    {
                        _direction = ResizeDirection.TopMiddle;
                    }
                    break;

                case ResizeDirection.BottomRight:
                    pointSecond.X += differenceX;
                    pointSecond.Y += differenceY;
                    if (pointFirst.X > pointSecond.X && pointFirst.Y < pointSecond.Y)
                    {
                        _direction = ResizeDirection.BottomLeft;
                    }
                    else if (pointFirst.X < pointSecond.X && pointFirst.Y > pointSecond.Y)
                    {
                        _direction = ResizeDirection.TopRight;
                    }
                    break;
            }
            _selectedShape.Resize(pointFirst, pointSecond);
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
            list.Remove(_selectedShape);
            _selectedShape = null;
        }
    }
}
