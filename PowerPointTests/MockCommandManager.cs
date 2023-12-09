using PowerPoint;
using System;

namespace PowerPointTests
{
    public class MockCommandManager : ICommandManager
    {
        public Func<bool> canRedo = null;
        public Func<bool> canUndo = null;
        public Action<ICommand> execute = null;
        public Action redo = null;
        public Action undo = null;

        public bool CanRedo()
        {
            return canRedo.Invoke();
        }

        public bool CanUndo()
        {
            return canUndo.Invoke();
        }

        public void Execute(ICommand command)
        {
            execute.Invoke(command);
        }

        public void Redo()
        {
            redo.Invoke();
        }

        public void Undo()
        {
            undo.Invoke();
        }
    }
}
