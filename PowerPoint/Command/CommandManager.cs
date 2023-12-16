using System;
using System.Collections.Generic;

namespace PowerPoint
{
    public class CommandManager : ICommandManager
    {
        readonly Stack<Tuple<Page, ICommand>> _redo = new Stack<Tuple<Page, ICommand>>();
        readonly Stack<Tuple<Page, ICommand>> _undo = new Stack<Tuple<Page, ICommand>>();

        Page _page = null;
        public Page CurrentPage
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
            }
        }

        public CommandManager(Page page)
        {
            CurrentPage = page;
        }

        /* execute */
        public void Execute(ICommand command)
        {
            Execute(command, new ExecuteOption());
        }

        /* execute */
        public void Execute(ICommand command, ExecuteOption option)
        {
            command.Execute(_page);
            if (option.CombineWithPreviousCommand)
            {
                var (_, cmd) = _undo.Pop();
                var moveCommandOne = (MoveCommand)cmd;
                var moveCommandTwo = (MoveCommand)command;
                moveCommandTwo.Combine(moveCommandOne);
            }
            if (option.SaveCommand)
            {
                _undo.Push(Tuple.Create(CurrentPage, command));
                _redo.Clear();
            }
            if (option.ResetDataBindings)
            {
                _page.Content.ResetBindings();
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
                var (page, command) = _undo.Pop();
                command.Undo(page);
                _redo.Push(Tuple.Create(page, command));
                _page.Content.ResetBindings();
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
                var (page, redoCommand) = _redo.Pop();
                redoCommand.Execute(page);
                _undo.Push(Tuple.Create(page, redoCommand));
                _page.Content.ResetBindings();
            }
        }
    }
}
