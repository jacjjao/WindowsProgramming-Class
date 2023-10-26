using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public interface IState
    {
        void MouseDown(BindingList<Shape> list, Point pos);

        void MouseMove(BindingList<Shape> list, Point pos);

        void MouseUp(BindingList<Shape> list, Point pos);

        void SelectShapeType(ShapeType type);
    }
}
