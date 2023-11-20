﻿using Cursor = System.Windows.Forms.Cursor;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public interface IState
    {
        /* mouse down */
        Cursor MouseDown(Shapes list, Point pos);

        /* mouse move */
        Cursor MouseMove(Shapes list, Point pos);

        /* mouse up */
        Cursor MouseUp(Shapes list, Point pos);
    }
}
