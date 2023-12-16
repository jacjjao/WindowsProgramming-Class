namespace PowerPoint
{
    public class DeleteCommand : ICommand
    {
        Shape _shape = null;

        public int DeleteIndex
        {
            get;
            set;
        }

        /* execute */
        public void Execute(Page list)
        {
            _shape = list[DeleteIndex];
            list.RemoveAt(DeleteIndex);
        }

        /* undo */
        public void Undo(Page list)
        {
            if (_shape != null)
            {
                list.Content.Insert(DeleteIndex, _shape);
                _shape = null;
            }
        }
    }
}
