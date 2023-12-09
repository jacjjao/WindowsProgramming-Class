namespace PowerPoint
{
    public interface ICommand
    {
        void Execute(Shapes list);

        void Undo(Shapes list);
    }
}
