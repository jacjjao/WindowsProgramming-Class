using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DeleteCommand : ICommand
    {
        Shape _shape;
        int _index;

        public void Execute(Shapes list, Shape shape)
        {
            _index = list.Content.IndexOf(shape);
            if (_index >= 0)
            {
                list.RemoveAt(_index);
                _shape = shape;
            }
        }

        public void Unexecute(Shapes list)
        {
            if (_shape != null)
            {
                list.Content.Insert(_index, _shape);
                _shape = null;
            }  
        }
    }
}
