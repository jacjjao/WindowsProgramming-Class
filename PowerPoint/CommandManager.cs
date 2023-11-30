using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class CommandManager
    {
        ICommand _currentCommand;
        Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void Execute(ICommand command, Shapes list, Shape shape)
        {
            _currentCommand = command;
            _currentCommand.Execute(list, shape);
            _commandHistory.Push(_currentCommand);
        }

        public void Unexecute(Shapes list)
        {
            _commandHistory.Pop().Unexecute(list);
        }
    }
}
