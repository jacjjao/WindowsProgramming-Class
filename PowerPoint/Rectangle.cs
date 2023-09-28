using System.Windows;
using System;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        public Vector Position 
        { 
            get; 
            set; 
        }
        public Vector Size 
        { 
            get; 
            set; 
        }

        private const string SHAPE_NAME = "矩形";

        public Rectangle()
        {
            Position = new Vector();
            Size = new Vector();
        }

        public Rectangle(Vector position, Vector size)
        {
            Position = position;
            Size = size;
        }

        /* get info */
        public override string GetInfo()
        {
            const string FORMAT = "({0})({1})";
            return String.Format(FORMAT, Position.ToString(), Size.ToString());
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return SHAPE_NAME;
        }
    }
}
