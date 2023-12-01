using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Command
{
    class DrawCommand : ICommand
    {
        public void Execute(Shapes list)
        {
            throw new NotImplementedException();
        }

        public void Unexecute(Shapes list)
        {
            throw new NotImplementedException();
        }
    }
}
