using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface ICommandManager
    {
        void Execute(ICommand command);

        bool CanUndo();
        void Undo();

        bool CanRedo();
        void Redo();
    }
}
