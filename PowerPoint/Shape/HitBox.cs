using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    public class HitBox
    {
        const int RADIUS = 10;

        System.Drawing.Rectangle _rectangle = new System.Drawing.Rectangle();

        public System.Drawing.Rectangle Rect
        {
            get
            {
                return _rectangle;
            }
        }

        public int X
        {
            get
            {
                return _rectangle.X;
            }
            set
            {
                _rectangle.X = value;
            }
        }

        public int Y
        {
            get
            {
                return _rectangle.Y;
            }
            set
            {
                _rectangle.Y = value;
            }
        }

        public int Width
        {
            get
            {
                return _rectangle.Width;
            }
            set
            {
                _rectangle.Width = value;
            }
        }

        public int Height
        {
            get
            {
                return _rectangle.Height;
            }
            set
            {
                _rectangle.Height = value;
            }
        }

        /* draw upper hitbox */
        private void DrawUpperHitBox(IGraphics graphics, Pen pen, ref System.Drawing.Rectangle rectangle)
        {
            const int TWO = 2;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = X + Width / TWO - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = X + Width - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
        }

        /* draw middle hitbox */
        private void DrawMiddleHitBox(IGraphics graphics, Pen pen, ref System.Drawing.Rectangle rectangle)
        {
            const int TWO = 2;
            rectangle.X = X - RADIUS;
            rectangle.Y = Y + Height / TWO - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = X + Width - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
        }

        /* draw bottom hitbox */
        private void DrawBottomHitBox(IGraphics graphics, Pen pen, ref System.Drawing.Rectangle rectangle)
        {
            const int TWO = 2;
            rectangle.X = X - RADIUS;
            rectangle.Y = Y + Height - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = X + Width / TWO - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = X + Width - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
        }

        /* draw */
        public void Draw(IGraphics graphics)
        {
            const float WIDTH = 1.0f;
            const int TWO = 2;
            var pen = new Pen(Color.Gray, WIDTH);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawRectangle(pen, _rectangle);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            var rectangle = new System.Drawing.Rectangle(X - RADIUS, Y - RADIUS, RADIUS * TWO, RADIUS * TWO);
            DrawUpperHitBox(graphics, pen, ref rectangle);
            DrawMiddleHitBox(graphics, pen, ref rectangle);
            DrawBottomHitBox(graphics, pen, ref rectangle);
        }

        /* is in circle */
        public bool IsInCircle(ResizeDirection direction, Point point)
        {
            const int TWO = 2;
            switch (direction)
            {
                case ResizeDirection.TopLeft:
                    return IsInCircle(new Point(X, Y), point);
                case ResizeDirection.TopMiddle:
                    return IsInCircle(new Point(X + Width / TWO, Y), point);
                case ResizeDirection.TopRight:
                    return IsInCircle(new Point(X + Width, Y), point);
                case ResizeDirection.MiddleLeft:
                    return IsInCircle(new Point(X, Y + Height / TWO), point);
                case ResizeDirection.MiddleRight:
                    return IsInCircle(new Point(X + Width, Y + Height / TWO), point);
                case ResizeDirection.BottomLeft:
                    return IsInCircle(new Point(X, Y + Height), point);
                case ResizeDirection.BottomMiddle:
                    return IsInCircle(new Point(X + Width / TWO, Y + Height), point);
                case ResizeDirection.BottomRight:
                    return IsInCircle(new Point(X + Width, Y + Height), point);
            }
            return false;
        }

        /* in circle */
        private bool IsInCircle(Point center, Point point)
        {
            int lengthX = point.X - center.X;
            int lengthY = point.Y - center.Y;
            return Math.Sqrt(lengthX * lengthX + lengthY * lengthY) <= RADIUS;
        }

        /* test upper hitbox */
        private ResizeDirection TestUpperHitBox(Point mousePosition, ref Point pos)
        {
            const int TWO = 2;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.TopLeft;
            pos.X = X + Width / TWO;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.TopMiddle;
            pos.X = X + Width;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.TopRight;
            return ResizeDirection.None;
        }

        /* test middle hitbox */
        private ResizeDirection TestMiddleHitBox(Point mousePosition, ref Point pos)
        {
            const int TWO = 2;
            pos.X = X;
            pos.Y = Y + Height / TWO;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.MiddleLeft;
            pos.X = X + Width;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.MiddleRight;
            return ResizeDirection.None;
        }

        /* test bottom hitbox */
        private ResizeDirection TestBottomHitBox(Point mousePosition, ref Point pos)
        {
            const int TWO = 2;
            pos.X = X;
            pos.Y = Y + Height;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.BottomLeft;
            pos.X = X + Width / TWO;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.BottomMiddle;
            pos.X = X + Width;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.BottomRight;
            return ResizeDirection.None;
        }

        /* get resize direction */
        public ResizeDirection GetResizeDirection(Point mousePosition)
        {
            var pos = new Point(X, Y);
            var direction = TestUpperHitBox(mousePosition, ref pos);
            if (direction != ResizeDirection.None)
                return direction;
            direction = TestMiddleHitBox(mousePosition, ref pos);
            if (direction != ResizeDirection.None)
                return direction;
            direction = TestBottomHitBox(mousePosition, ref pos);
            return direction;
        }
    }
}
