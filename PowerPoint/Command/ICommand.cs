namespace PowerPoint
{
    public interface ICommand
    {
        /* execute */
        void Execute(Page list);

        /* undo */
        void Undo(Page list);
    }
}
