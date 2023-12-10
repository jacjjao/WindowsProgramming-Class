namespace PowerPoint
{
    public interface ICommandManager
    {
        /* execute */
        void Execute(ICommand command);

        /* execute */
        void Execute(ICommand command, ExecuteOption option);

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
