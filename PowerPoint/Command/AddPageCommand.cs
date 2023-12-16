using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class AddPageCommand : ICommand
    {
        Page _page = null;
        int _index = -1;

        public PageManager Manager
        {
            get;
            set;
        }

        // execute
        public void Execute(Page list)
        {
            if (_page == null)
            {
                Manager.AddBlankPage();
                _page = Manager.CurrentPage;
                _index = Manager.GetCurrentPageIndex();
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
