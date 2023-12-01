using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class CommandManager
    {
        readonly Stack<ICommand> _commandBuffer = new Stack<ICommand>();
        readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

        Shapes _list = null;

        public CommandManager(Shapes list)
        {
            _list = list;
        }

        public void Execute(ICommand command)
        {
            command.Execute(_list);
            _commandHistory.Push(command);
            _commandBuffer.Clear();
        }

        public bool CanUndo()
        {
            return _commandHistory.Count > 0;
        }

        public void Undo()
        {
            if (CanUndo())
            {
                var command = _commandHistory.Pop();
                command.Unexecute(_list);
                _commandBuffer.Push(command);
            }
        }

        public bool CanRedo()
        {
            return _commandBuffer.Count > 0;
        }

        public void Redo()
        {
            if (CanRedo())
            {
                var redoCommand = _commandBuffer.Pop();
                redoCommand.Execute(_list);
                _commandHistory.Push(redoCommand);
            }
        }
    }
}
