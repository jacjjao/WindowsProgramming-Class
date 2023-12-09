namespace PowerPoint
{
    public interface ICommand
    {
        /* execute */
        void Execute(Shapes list);

        /* undo */
        void Undo(Shapes list);
    }
}
