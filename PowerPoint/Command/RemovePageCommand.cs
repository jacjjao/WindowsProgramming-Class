namespace PowerPoint
{
    public class RemovePageCommand : ICommand
    {
        Page _page = null;

        public PageManager Manager
        {
            get;
            set;
        }

        int _index = -1;
        public int RemoveIndex
        {
            set
            {
                _index = value;
            }
        }

        // execute
        public void Execute(Page list)
        {
            _page = Manager.GetPage(_index);
            Manager.RemoveAt(_index);
        }

        // undo
        public void Undo(Page list)
        {
            Manager.AddPage(_page, _index);
        }
    }
}