using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class MoveCommand : ICommand
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

        public int ScaleX
        {
            get;
            set;
        }

        public int ScaleY
        {
            get;
            set;
        }

        public ResizeDirection ScaleDirect
        {
            get;
            set;
        }

        public void Execute(Shapes list)
        {
            SelectShape.Move(MoveX, MoveY);
            if (ScaleDirect != ResizeDirection.None)
            {
                const int ZERO = 0;
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, ScaleX, ZERO);
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, ZERO, ScaleY);
            }
        }

        public void Unexecute(Shapes list)
        {
            SelectShape.Move(-MoveX, -MoveY);
            if (ScaleDirect != ResizeDirection.None)
            {
                const int ZERO = 0;
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, -ScaleX, ZERO);
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, ZERO, -ScaleY);
            }
        }
    }
}
