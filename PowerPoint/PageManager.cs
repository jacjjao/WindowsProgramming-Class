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

        public delegate void PageRemovedHandler();
        public event PageRemovedHandler PageRemoved;

        List<Shapes> _pages = new List<Shapes>();

        Shapes _currentPage = null;
        public Shapes CurrentPage
        {
            get
            {
                return _currentPage;
            }
        }

        // add blank page
        public void AddBlankPage()
        {
            _pages.Add(new Shapes());
            _currentPage = _pages.Last();
            OnPageAdd();
        }

        // remove
        public void Remove(Shapes page)
        {
            Debug.Assert(page != null && _pages.Contains(page));
            _pages.Remove(page);
            OnPageRemove();
        }

        // remove last page
        public void RemoveLastPage()
        {
            Debug.Assert(_pages.Count > 0);
            if (_pages.Count > 1)
            {
                if (_currentPage == _pages.Last())
                {
                    _currentPage = _pages[_pages.Count - 2];
                }
                _pages.Remove(_pages.Last());
                OnPageRemove();
            }
        }

        // select current page
        public void SelectCurrentPage(Shapes page)
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
        private void OnPageRemove()
        {
            if (PageRemoved != null)
            {
                PageRemoved();
            }
        }
    }
}
