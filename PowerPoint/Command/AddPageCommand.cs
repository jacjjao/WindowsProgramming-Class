﻿namespace PowerPoint
{
    public class AddPageCommand : ICommand
    {
        Page _page = null;

        public PageManager Manager
        {
            get;
            set;
        }

        int _index = -1;
        public int AddIndex
        {
            set
            {
                _index = value;
            }
        }

        // execute
        public void Execute(Page list)
        {
            if (_page == null)
            {
                Manager.AddBlankPageAt(_index);
                _page = Manager.CurrentPage;
            }
            else
            {
                Manager.AddPage(_page, _index);
            }
        }

        // undo
        public void Undo(Page list)
        {
            Manager.Remove(_page);
        }
    }
}
