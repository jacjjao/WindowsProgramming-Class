using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    public abstract partial class Shape
    {
        const int RADIUS = 6;

        protected System.Drawing.Rectangle _hitBox = new System.Drawing.Rectangle();
        public System.Drawing.Rectangle HitBox
        {
            get
            {
                return _hitBox;
            }
        }

        /* draw upper hitbox */
        private void DrawUpperHitBox(IGraphics graphics, Pen pen, ref System.Drawing.Rectangle rectangle)
        {
            const int TWO = 2;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = HitBox.X + HitBox.Width / TWO - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = HitBox.X + HitBox.Width - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
        }

        /* draw middle hitbox */
        private void DrawMiddleHitBox(IGraphics graphics, Pen pen, ref System.Drawing.Rectangle rectangle)
        {
            const int TWO = 2;
            rectangle.X = HitBox.X - RADIUS;
            rectangle.Y = HitBox.Y + HitBox.Height / TWO - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = HitBox.X + HitBox.Width - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
        }

        /* draw bottom hitbox */
        private void DrawBottomHitBox(IGraphics graphics, Pen pen, ref System.Drawing.Rectangle rectangle)
        {
            const int TWO = 2;
            rectangle.X = HitBox.X - RADIUS;
            rectangle.Y = HitBox.Y + HitBox.Height - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = HitBox.X + HitBox.Width / TWO - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
            rectangle.X = HitBox.X + HitBox.Width - RADIUS;
            graphics.DrawEllipse(pen, rectangle);
        }

        /* draw */
        private void DrawHitBox(IGraphics graphics)
        {
            const float WIDTH = 1.0f;
            const int TWO = 2;
            var pen = new Pen(Color.Gray, WIDTH);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawRectangle(pen, HitBox);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            var rectangle = new System.Drawing.Rectangle(HitBox.X - RADIUS, HitBox.Y - RADIUS, RADIUS * TWO, RADIUS * TWO);
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
                    return IsInCircle(new Point(HitBox.X, HitBox.Y), point);
                case ResizeDirection.TopMiddle:
                    return IsInCircle(new Point(HitBox.X + HitBox.Width / TWO, HitBox.Y), point);
                case ResizeDirection.TopRight:
                    return IsInCircle(new Point(HitBox.X + HitBox.Width, HitBox.Y), point);
                case ResizeDirection.MiddleLeft:
                    return IsInCircle(new Point(HitBox.X, HitBox.Y + HitBox.Height / TWO), point);
                case ResizeDirection.MiddleRight:
                    return IsInCircle(new Point(HitBox.X + HitBox.Width, HitBox.Y + HitBox.Height / TWO), point);
                case ResizeDirection.BottomLeft:
                    return IsInCircle(new Point(HitBox.X, HitBox.Y + HitBox.Height), point);
                case ResizeDirection.BottomMiddle:
                    return IsInCircle(new Point(HitBox.X + HitBox.Width / TWO, HitBox.Y + HitBox.Height), point);
                case ResizeDirection.BottomRight:
                    return IsInCircle(new Point(HitBox.X + HitBox.Width, HitBox.Y + HitBox.Height), point);
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
            pos.X = HitBox.X + HitBox.Width / TWO;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.TopMiddle;
            pos.X = HitBox.X + HitBox.Width;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.TopRight;
            return ResizeDirection.None;
        }

        /* test middle hitbox */
        private ResizeDirection TestMiddleHitBox(Point mousePosition, ref Point pos)
        {
            const int TWO = 2;
            pos.X = HitBox.X;
            pos.Y = HitBox.Y + HitBox.Height / TWO;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.MiddleLeft;
            pos.X = HitBox.X + HitBox.Width;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.MiddleRight;
            return ResizeDirection.None;
        }

        /* test bottom hitbox */
        private ResizeDirection TestBottomHitBox(Point mousePosition, ref Point pos)
        {
            const int TWO = 2;
            pos.X = HitBox.X;
            pos.Y = HitBox.Y + HitBox.Height;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.BottomLeft;
            pos.X = HitBox.X + HitBox.Width / TWO;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.BottomMiddle;
            pos.X = HitBox.X + HitBox.Width;
            if (IsInCircle(pos, mousePosition))
                return ResizeDirection.BottomRight;
            return ResizeDirection.None;
        }

        /* get resize direction */
        public ResizeDirection GetResizeDirection(Point mousePosition)
        {
            var pos = new Point(HitBox.X, HitBox.Y);
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
