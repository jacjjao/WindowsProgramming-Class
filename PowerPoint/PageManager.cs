using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace PowerPoint
{
    public class PageManager
    {
        public delegate void NewPageAddedEventHandler();
        public event NewPageAddedEventHandler _newPageAdded;

        public delegate void PageRemovedEventHandler(int index);
        public event PageRemovedEventHandler _pageRemoved;

        public delegate void CurrentPageChangedEventHandler();
        public event CurrentPageChangedEventHandler _currentPageChanged;

        readonly List<Page> _pages = new List<Page>();
        public int Count
        {
            get
            {
                return _pages.Count;
            }
        }
        public Page this[int index]
        {
            get
            {
                return _pages[index];
            }
        }


        Page _currentPage = null;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            private set
            {
                Debug.Assert(_pages.Contains(value));
                _currentPage = value;
                DoCurrentPageChanged();
            }
        }

        // upload files
        public Task UploadAllPageAsync(IPageSaver saver)
        {
            System.TimeSpan SLEEP_TIME = System.TimeSpan.FromSeconds(10);
            var uploadBuffer = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                var fileContent = new StringBuilder();
                for (int j = 0; j < _pages[i].Count; j++)
                    fileContent.AppendLine(_pages[i][j].GetSaveInfo());
                uploadBuffer.Add(fileContent.ToString());
            }
            return Task.Run(() =>
            {
                foreach (var fileContent in uploadBuffer)
                {
                    saver.Upload(fileContent);
                }
                Thread.Sleep(SLEEP_TIME);
            });
        }

        // get current page index
        public int GetCurrentPageIndex()
        {
            return _pages.FindIndex((page) => page.Equals(CurrentPage));
        }

        // set current page
        public void SetCurrentPage(int index)
        {
            CurrentPage = _pages[index];
        }

        // add blank page
        public void AddBlankPage()
        {
            _pages.Add(new Page());
            CurrentPage = _pages.Last();
            DoPageAdd();
        }

        // add blank page at
        public void AddBlankPageAt(int index)
        {
            _pages.Insert(index, new Page());
            CurrentPage = _pages[index];
            DoPageAdd();
        }

        // add page
        public void AddPage(Page page, int index)
        {
            _pages.Insert(index, page);
            CurrentPage = page;
            DoPageAdd();
        }

        // remove
        public void Remove(Page page)
        {
            RemoveAt(_pages.FindIndex(p => p.Equals(page)));
        }

        // remove at
        public void RemoveAt(int removeIndex)
        {
            if (_pages.Count <= 1)
                return;
            if (GetCurrentPageIndex() == removeIndex)
            {
                int index = removeIndex;
                if (index > 0)
                    index--;
                _pages.RemoveAt(removeIndex);
                CurrentPage = _pages[index];
            }
            else
                _pages.RemoveAt(removeIndex);
            DoPageRemove(removeIndex);
        }

        // page add
        private void DoPageAdd()
        {
            if (_newPageAdded != null)
            {
                _newPageAdded();
            }
        }

        // page remove
        private void DoPageRemove(int index)
        {
            if (_pageRemoved != null)
            {
                _pageRemoved(index);
            }
        }

        // current page change
        private void DoCurrentPageChanged()
        {
            if (_currentPageChanged != null)
            {
                _currentPageChanged();
            }
        }
    }
}
