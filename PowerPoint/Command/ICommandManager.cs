namespace PowerPoint
{
    public interface ICommandManager
    {
        /* execute */
        void Execute(ICommand command);

        /* can undo */
        bool IsCanUndo();

        /* undo */
        void Undo();

        /* can redo */
        bool IsCanRedo();

        /* redo */
        void Redo();
    }
}
