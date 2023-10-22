using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;
using Color = System.Drawing.Color;

namespace PowerPoint
{
    public interface IGraphics
    {
        /* clear all */
        void ClearAll(Color color);

        /* draw line */
        void DrawLine(Point firstPoint, Point secondPoint);
        
        /* draw rectangle */
        void DrawRectangle(Point position, Point size);

        /* draw circle */
        void DrawCircle(Point center, Point radius);
    }
}
