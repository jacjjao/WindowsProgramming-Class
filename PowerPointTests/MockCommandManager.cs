using PowerPoint;
using System;

namespace PowerPointTests
{
    public class MockCommandManager : ICommandManager
    {
        public Func<bool> _canRedo = null;
        public Func<bool> _canUndo = null;
        public Action<ICommand> _execute = null;
        public Action _redo = null;
        public Action _undo = null;

        /* can redo */
        public bool IsCanRedo()
        {
            return _canRedo.Invoke();
        }

        /* can undo */
        public bool IsCanUndo()
        {
            return _canUndo.Invoke();
        }

        /* execute */
        public void Execute(ICommand command)
        {
            _execute.Invoke(command);
        }

        /* execute */
        public void Execute(ICommand command, ExecuteOption option)
        {
            _execute.Invoke(command);
        }

        /* redo */
        public void Redo()
        {
            _redo.Invoke();
        }

        /* undo */
        public void Undo()
        {
            _undo.Invoke();
        }
    }
}
