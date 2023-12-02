using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class CommandManager
    {
        readonly Stack<ICommand> _redo = new Stack<ICommand>();
        readonly Stack<ICommand> _undo = new Stack<ICommand>();

        readonly Shapes _list = null;

        public CommandManager(Shapes list)
        {
            _list = list;
        }

        public void Execute(ICommand command)
        {
            command.Execute(_list);
            if (command is MoveCommand && ((MoveCommand)command).CombinePreviousCommand && _undo.Count > 0 && _undo.Last() is MoveCommand)
            {
                ((MoveCommand)_undo.Last()).Combine((MoveCommand)command);
            }
            else if (!(command is DrawCommand))
            {
                AddCommand(command);
            }
        }

        public void AddCommand(ICommand command)
        {
            _undo.Push(command);
            _redo.Clear();
        }

        public bool CanUndo()
        {
            return _undo.Count > 0;
        }

        public void Undo()
        {
            if (CanUndo())
            {
                var command = _undo.Pop();
                command.Unexecute(_list);
                _redo.Push(command);
            }
        }

        public bool CanRedo()
        {
            return _redo.Count > 0;
        }

        public void Redo()
        {
            if (CanRedo())
            {
                var redoCommand = _redo.Pop();
                redoCommand.Execute(_list);
                _undo.Push(redoCommand);
            }
        }
    }
}
