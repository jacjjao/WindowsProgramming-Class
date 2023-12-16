using System.Collections.Generic;

namespace PowerPoint
{
    public class CommandManager : ICommandManager
    {
        readonly Dictionary<Page, Stack<ICommand>> _redo = new Dictionary<Page, Stack<ICommand>>();
        readonly Dictionary<Page, Stack<ICommand>> _undo = new Dictionary<Page, Stack<ICommand>>();

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
                if (_page != null)
                {
                    if (!_undo.ContainsKey(_page))
                        _undo.Add(_page, new Stack<ICommand>());
                    if (!_redo.ContainsKey(_page))
                        _redo.Add(_page, new Stack<ICommand>());
                }
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
                var moveCommandOne = (MoveCommand)_undo[_page].Pop();
                var moveCommandTwo = (MoveCommand)command;
                moveCommandTwo.Combine(moveCommandOne);
            }
            if (option.SaveCommand)
            {
                _undo[_page].Push(command);
                _redo[_page].Clear();
            }
            if (option.ResetDataBindings)
            {
                _page.Content.ResetBindings();
            }
        }

        /* can undo */
        public bool IsCanUndo()
        {
            return _undo[_page].Count > 0;
        }

        /* undo */
        public void Undo()
        {
            if (IsCanUndo())
            {
                var command = _undo[_page].Pop();
                command.Undo(_page);
                _redo[_page].Push(command);
                _page.Content.ResetBindings();
            }
        }

        /* can redo */
        public bool IsCanRedo()
        {
            return _redo[_page].Count > 0;
        }

        /* redo */
        public void Redo()
        {
            if (IsCanRedo())
            {
                var redoCommand = _redo[_page].Pop();
                redoCommand.Execute(_page);
                _undo[_page].Push(redoCommand);
                _page.Content.ResetBindings();
            }
        }
    }
}
