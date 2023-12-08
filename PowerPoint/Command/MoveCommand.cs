﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class MoveCommand : ICommand
    {
        public Shape SelectShape
        {
            get;
            set;
        }
        
        public int MoveX
        {
            get;
            set;
        }

        public int MoveY
        {
            get;
            set;
        }

        public ResizeDirection ScaleDirect
        {
            get;
            set;
        }

        public bool CombinePreviousCommand
        {
            get;
            set;
        }

        public void Execute(Shapes list)
        {
            const int ZERO = 0;
            if (SelectShape != null)
            {
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, MoveX, ZERO);
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, ZERO, MoveY);
            }
        }

        public void Unexecute(Shapes list)
        {
            const int ZERO = 0;
            if (SelectShape != null)
            {
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, -MoveX, ZERO);
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, ZERO, -MoveY);
            }
        }

        public void Combine(MoveCommand other)
        {
            if (!Equals(SelectShape, other.SelectShape))
            {
                throw new ArgumentException();
            }
            MoveX += other.MoveX;
            MoveY += other.MoveY;
        }
    }
}
