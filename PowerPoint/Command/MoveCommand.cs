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

        public void Execute(Shapes list)
        {
            SelectShape.Move(MoveX, MoveY);
        }

        public void Unexecute(Shapes list)
        {
            SelectShape.Move(-MoveX, -MoveY);
        }
    }
}
