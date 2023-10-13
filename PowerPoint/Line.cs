using System.Drawing;

namespace PowerPoint
{
    class Line : Shape
    {
        public Point StartPoint
        {
            get;
            set;
        }
        public Point EndPoint
        {
            get;
            set;
        }

        private const string SHAPE_NAME = "線";

        public Line()
        {
            StartPoint = new Point();
            EndPoint = new Point();
        }

        public Line(Point pointFirst, Point pointSecond)
        {
            StartPoint = pointFirst;
            EndPoint = pointSecond;
        }

        /* get info */
        public string GetInfo()
        {
            const string FORMAT = "({0},{1})({2},{3})";
            return string.Format(FORMAT, StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
        }

        /* get shape name */
        public string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw line */
        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, StartPoint, EndPoint);
        }
    }
}
