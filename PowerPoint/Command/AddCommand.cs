using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class AddCommand : ICommand
    {
        Shape _shape = null;

        public void Execute(Shapes list, Shape shape)
        {
            list.Content.Add(shape);
            _shape = shape;
        }

        public void Unexecute(Shapes list)
        {
            if (_shape != null)
            {
                list.Remove(_shape);
                _shape = null;
            }
        }
    }
}
