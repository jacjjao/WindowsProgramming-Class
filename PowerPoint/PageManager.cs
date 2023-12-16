using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pen = System.Drawing.Pen;

namespace PowerPoint
{
    public class PageManager
    {
        public delegate void NewPageAddedHandler();
        public event NewPageAddedHandler NewPageAdded;

        public delegate void PageRemovedHandler(int index);
        public event PageRemovedHandler PageRemoved;

        public delegate void CurrentPageChangedHandler();
        public event CurrentPageChangedHandler CurrentPageChanged;

        readonly List<Page> _pages = new List<Page>();

        Page _currentPage = null;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            private set
            {
                _currentPage = value;
                OnCurrentPageChanged();
            }
        }

        // get current page index
        public int GetCurrentPageIndex()
        {
            return _pages.FindIndex((page) => page.Equals(CurrentPage));
        }

        // set current page
        public void SetCurrentPage(int index)
        {
            Debug.Assert(0 <= index && index < _pages.Count);
            CurrentPage = _pages[index];
        }

        // add blank page
        public void AddBlankPage()
        {
            _pages.Add(new Page());
            CurrentPage = _pages.Last();
            OnPageAdd();
        }

        // add page
        public void AddPage(Page page, int index)
        {
            _pages.Insert(index, page);
            CurrentPage = page;
            OnPageAdd();
        }

        // remove
        public void Remove(Page page)
        {
            if (_pages.Count <= 1)
                return;
            Debug.Assert(page != null && _pages.Contains(page));
            int removeIndex = _pages.FindIndex((p) => p.Equals(page));
            if (page.Equals(CurrentPage))
            {
                int index = GetCurrentPageIndex();
                if (index > 0)
                    index--;
                _pages.Remove(page);
                CurrentPage = _pages[index];
            }
            else 
                _pages.Remove(page);
            OnPageRemove(removeIndex);
        }

        // remove at
        public void RemoveAt(int removeIndex)
        {
            if (_pages.Count <= 1)
                return;
            Debug.Assert(0 <= removeIndex && removeIndex < _pages.Count);
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
            OnPageRemove(removeIndex);
        }

        // remove last page
        public void RemoveLastPage()
        {
            Debug.Assert(_pages.Count > 0);
            if (_pages.Count > 1)
            {
                if (CurrentPage == _pages.Last())
                {
                    CurrentPage = _pages[_pages.Count - 2];
                }
                _pages.Remove(_pages.Last());
                OnPageRemove(_pages.Count);
            }
        }

        // select current page
        public void SelectCurrentPage(Page page)
        {
            Debug.Assert(page != null && _pages.Contains(page));
            _currentPage = page;
        }

        // draw current page
        public void DrawCurrentPage(Pen pen, IGraphics graphics)
        {
            Debug.Assert(_currentPage != null && _pages.Contains(_currentPage));
            _currentPage.DrawAll(pen, graphics);
        }

        // draw page
        public void DrawPage(int index, Pen pen, IGraphics graphics)
        {
            Debug.Assert(0 <= index && index < _pages.Count);
            _pages[index].DrawAll(pen, graphics);
        }

        // page add
        private void OnPageAdd()
        {
            if (NewPageAdded != null)
            {
                NewPageAdded();
            }
        }

        // page remove
        private void OnPageRemove(int index)
        {
            if (PageRemoved != null)
            {
                PageRemoved(index);
            }
        }

        // current page change
        private void OnCurrentPageChanged()
        {
            if (CurrentPageChanged != null)
            {
                CurrentPageChanged();
            }
        }
    }
}
