using System.Windows;
using System;

namespace PowerPoint
{
    class Line : Shape
    {
        public Vector StartPoint 
        { 
            get; 
            set; 
        }
        public Vector EndPoint 
        { 
            get; 
            set; 
        }

        private const string SHAPE_NAME = "線";

        public Line()
        {
            StartPoint = new Vector();
            EndPoint = new Vector();
        }

        public Line(Vector startPoint, Vector endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0})({1})";
            return String.Format(FORMAT, StartPoint.ToString(), EndPoint.ToString());
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }
    }
}
