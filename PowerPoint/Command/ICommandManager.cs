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
