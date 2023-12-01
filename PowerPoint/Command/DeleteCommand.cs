using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DeleteCommand : ICommand
    {
        Shape _shape = null;

        public int DeleteIndex
        {
            get;
            set;
        }

        public void Execute(Shapes list)
        {
            _shape = list[DeleteIndex];
            list.RemoveAt(DeleteIndex);
        }

        public void Unexecute(Shapes list)
        {
            if (_shape != null)
            {
                list.Content.Insert(DeleteIndex, _shape);
                _shape = null;
            }  
        }
    }
}
