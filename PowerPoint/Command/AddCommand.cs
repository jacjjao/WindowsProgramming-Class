using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    class AddCommand : ICommand
    {
        public bool AddRandom
        {
            get;
            set;
        }

        public ShapeType Type
        {
            get;
            set;
        }

        public int ScreenWidth
        {
            get;
            set;
        }

        public int ScreenHeight
        {
            get;
            set;
        }

        public Point PointFirst
        {
            get;
            set;
        }

        public Point PointSecond
        {
            get;
            set;
        }

        private Shape _shape = null;

        public void Execute(Shapes list)
        {
            if (_shape != null)
            {
                list.Content.Add(_shape);
                return;
            }
            if (AddRandom)
            {
                list.AddRandomShape(Type, ScreenWidth, ScreenHeight);
            }
            else
            {
                list.AddShape(Type, PointFirst, PointSecond);
            }
            _shape = list.Content.Last();
        }

        public void Unexecute(Shapes list)
        {
            if (_shape != null)
            {
                list.Remove(_shape);
            }
        }
    }
}
