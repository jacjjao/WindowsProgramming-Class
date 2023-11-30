using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class MoveCommand : ICommand
    {
        Shape _shape = null;
        
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

        public void Execute(Shapes list, Shape shape)
        {
            _shape = shape;
            shape.Move(MoveX, MoveY);
        }

        public void Unexecute(Shapes list)
        {
            _shape.Move(-MoveX, -MoveY);
        }
    }
}
