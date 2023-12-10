using System;

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

        /* execute */
        public void Execute(Shapes list)
        {
            if (SelectShape != null)
            {
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, MoveX, MoveY);
            }
        }

        /* undo */
        public void Undo(Shapes list)
        {
            if (SelectShape != null)
            {
                ScaleDirect = SelectShape.ResizeBasedOnDirection(ScaleDirect, -MoveX, -MoveY);
            }
        }

        /* combine */
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
