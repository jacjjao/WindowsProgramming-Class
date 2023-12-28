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

        const int SLEEP_SECONDS = 10;

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
                NotifyCurrentPageChanged();
            }
        }

        // upload files
        public Task UploadAllPageAsync(IPageSaver saver)
        {
            var uploadBuffer = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                if (_pages[i].Count <= 0)
                    continue;
                var fileContent = new StringBuilder();
                for (int j = 0; j < _pages[i].Count; j++)
                    fileContent.AppendLine(_pages[i][j].GetSaveInfo());
                uploadBuffer.Add(fileContent.ToString());
            }
            return Task.Run(() =>
            {
                foreach (var fileContent in uploadBuffer)
                    saver.Save(fileContent);
                Thread.Sleep(System.TimeSpan.FromSeconds(SLEEP_SECONDS));
            });
        }

        // download
        public void DownloadPages(IPageSaver saver)
        {
            int length = _pages.Count;
            var pages = saver.Load();
            Thread.Sleep(System.TimeSpan.FromSeconds(SLEEP_SECONDS));
            if (pages.Count == 0)
                return;
            foreach (var page in pages)
                AddPage(page, 0);
            for (int i = 0; i < length; i++)
                Remove(_pages.Last());
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
            PageAdd();
        }

        // add blank page at
        public void AddBlankPageAt(int index)
        {
            _pages.Insert(index, new Page());
            CurrentPage = _pages[index];
            PageAdd();
        }

        // add page
        public void AddPage(Page page, int index)
        {
            _pages.Insert(index, page);
            CurrentPage = page;
            PageAdd();
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
            PageRemove(removeIndex);
        }

        // page add
        private void PageAdd()
        {
            if (_newPageAdded != null)
            {
                _newPageAdded();
            }
        }

        // page remove
        private void PageRemove(int index)
        {
            if (_pageRemoved != null)
            {
                _pageRemoved(index);
            }
        }

        // current page change
        private void NotifyCurrentPageChanged()
        {
            if (_currentPageChanged != null)
            {
                _currentPageChanged();
            }
        }
    }
}
