using System.Collections.Generic;

namespace PowerPoint
{
    public class CommandManager : ICommandManager
    {
        readonly Stack<ICommand> _redo = new Stack<ICommand>();
        readonly Stack<ICommand> _undo = new Stack<ICommand>();

        readonly Shapes _list = null;

        public CommandManager(Shapes list)
        {
            _list = list;
        }

        /* execute */
        public void Execute(ICommand command)
        {
            command.Execute(_list);
            if (command is MoveCommand && ((MoveCommand)command).CombinePreviousCommand)
            {
                var moveCommandOne = (MoveCommand)_undo.Pop();
                var moveCommandTwo = (MoveCommand)command;
                moveCommandTwo.Combine(moveCommandOne);
            }
            if (!(command is DrawCommand))
            {
                _undo.Push(command);
                _redo.Clear();
            }
        }

        /* can undo */
        public bool CanUndo()
        {
            return _undo.Count > 0;
        }

        /* undo */
        public void Undo()
        {
            if (CanUndo())
            {
                var command = _undo.Pop();
                command.Undo(_list);
                _redo.Push(command);
            }
        }

        /* can redo */
        public bool CanRedo()
        {
            return _redo.Count > 0;
        }

        /* redo */
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
