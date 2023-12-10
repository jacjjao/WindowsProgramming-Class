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
            Execute(command, new ExecuteOption());
        }

        /* execute */
        public void Execute(ICommand command, ExecuteOption option)
        {
            command.Execute(_list);
            if (option.CombindWithPreviousCommand)
            {
                var moveCommandOne = (MoveCommand)_undo.Pop();
                var moveCommandTwo = (MoveCommand)command;
                moveCommandTwo.Combine(moveCommandOne);
            }
            if (option.SaveCommand)
            {
                _undo.Push(command);
                _redo.Clear();
            }
            if (option.ResetDataBindings)
            {
                _list.Content.ResetBindings();
            }
        }

        /* can undo */
        public bool IsCanUndo()
        {
            return _undo.Count > 0;
        }

        /* undo */
        public void Undo()
        {
            if (IsCanUndo())
            {
                var command = _undo.Pop();
                command.Undo(_list);
                _redo.Push(command);
                _list.Content.ResetBindings();
            }
        }

        /* can redo */
        public bool IsCanRedo()
        {
            return _redo.Count > 0;
        }

        /* redo */
        public void Redo()
        {
            if (IsCanRedo())
            {
                var redoCommand = _redo.Pop();
                redoCommand.Execute(_list);
                _undo.Push(redoCommand);
                _list.Content.ResetBindings();
            }
        }
    }
}
