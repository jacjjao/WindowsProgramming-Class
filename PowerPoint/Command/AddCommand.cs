﻿using System;
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

        public Shape AddShape
        {
            get;
            set;
        }

        public void Execute(Shapes list)
        {
            if (AddShape != null)
            {
                AddShape.Selected = false;
                list.Content.Add(AddShape);
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
            AddShape = list.Content.Last();
        }

        public void Unexecute(Shapes list)
        {
            if (AddShape != null)
            {
                list.Remove(AddShape);
            }
        }
    }
}
