﻿using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    class Line : Shape
    {
        private Point _startPoint = new Point();
        private Point _endPoint = new Point();

        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
                NotifyPropertyChanged();
            }
        }
        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
                NotifyPropertyChanged();
            }
        }

        private const string SHAPE_NAME = "線";

        public Line(Point pointFirst, Point pointSecond)
        {
            if (pointFirst.X <= pointSecond.X)
            {
                StartPoint = pointFirst;
                EndPoint = pointSecond;
            }
            else
            {
                StartPoint = pointSecond;
                EndPoint = pointFirst;
            }
        }

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0},{1})({2},{3})";
            return string.Format(FORMAT, StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }

        /* draw line */
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, StartPoint, EndPoint);
        }
    }
}
