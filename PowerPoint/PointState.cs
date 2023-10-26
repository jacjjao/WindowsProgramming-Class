using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    class PointState : IState
    {
        Shape _selectedShape = null;

        public void MouseDown(BindingList<Shape> list, Point pos)
        {
            _selectedShape = null;
            foreach (var shape in list)
            {
                if (shape.DoMouseDown(pos))
                {
                    shape.Selected = true;
                    _selectedShape = shape;
                }
                else
                {
                    shape.Selected = false;
                }
            }
        }

        public void MouseMove(BindingList<Shape> list, Point pos)
        {
            if (_selectedShape == null)
            {
                return;
            }
            _selectedShape.DoMouseMove(pos);
        }

        public void MouseUp(BindingList<Shape> list, Point pos)
        {
            _selectedShape.DoMouseUp(pos);
        }

        public void SelectShapeType(ShapeType type)
        {
            
        }
    }
}
