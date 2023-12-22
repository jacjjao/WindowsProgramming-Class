using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Tests
{
    [TestClass]
    public class PageManagerTests
    {
        PageManager _manager;
        PrivateObject _managerPrivate;
        bool _pageAdded = false;

        // test
        [TestInitialize]
        public void Initlaize()
        {
            _manager = new PageManager();
            _managerPrivate = new PrivateObject(_manager);
        }

        // test
        [TestMethod]
        public void GetPageTest()
        {
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            var page = new Page();
            pages.Add(page);
            Assert.AreEqual(page, _manager[0]);
        }

        // test
        [TestMethod]
        public void GetCurrentPageIndexTest()
        {
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            var page = new Page();
            pages.Add(page);
            _managerPrivate.SetFieldOrProperty("CurrentPage", page);
            Assert.AreEqual(0, _manager.GetCurrentPageIndex());
        }

        // test
        [TestMethod]
        public void SetCurrentPageTest()
        {
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            var page = new Page();
            pages.Add(page);
            _manager.SetCurrentPage(0);
            Assert.AreEqual(page, _manager.CurrentPage);
        }

        // test
        [TestMethod]
        public void AddBlankPageTest()
        {
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            _manager.AddBlankPage();
            Assert.AreEqual(1, pages.Count);
            Assert.AreEqual(pages[0], _manager.CurrentPage);
        }

        // test
        [TestMethod]
        public void AddBlankPageAtTest()
        {
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            _manager.AddBlankPage();
            var page = pages[0];
            _manager.AddBlankPageAt(0);
            Assert.AreEqual(2, pages.Count);
            Assert.AreEqual(page, pages[1]);
        }

        // test
        [TestMethod]
        public void AddPageTest()
        {
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            var page = new Page();
            _manager.AddPage(page, 0);
            Assert.AreEqual(1, pages.Count);
            Assert.AreEqual(page, pages[0]);
        }

        // test
        [TestMethod]
        public void RemoveAtTest()
        {
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            _manager.AddBlankPage();
            _manager.Remove(_manager.CurrentPage);
            Assert.AreEqual(1, pages.Count);
            _manager.AddBlankPage();
            _manager.Remove(_manager.CurrentPage);
            Assert.AreEqual(1, pages.Count);
            _manager.AddBlankPage();
            _managerPrivate.SetFieldOrProperty("CurrentPage", pages[0]);
            _manager.Remove(pages[0]);
            Assert.AreEqual(1, pages.Count);
        }

        // test
        public void PageAdd()
        {
            _pageAdded = true;
        }

        // test
        public void PageRemove(int index)
        {
            Assert.AreEqual(0, index);
        }

        // test
        [TestMethod]
        public void EventTest()
        {
            _manager._newPageAdded += PageAdd;
            _manager._pageRemoved += PageRemove;
            _manager.AddBlankPage();
            Assert.IsTrue(_pageAdded);
            _manager.AddBlankPage();
            _manager.RemoveAt(0);
        }
    }
}