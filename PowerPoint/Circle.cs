using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PowerPoint
{
    class Circle : Shape
    {
        public float Radius
        {
            get;
            set;
        }

        public Vector Position
        {
            get;
            set;
        }

        public Circle()
        {

        }

        const string SHAPE_NAME = "圓形";

        /* get info */
        public string GetInfo()
        {
            const string FORMAT = "({0})";
            return string.Format(FORMAT, Position);
        }

        /* get shape name */
        public string GetShapeName()
        {
            return SHAPE_NAME;
        }
    }
}
