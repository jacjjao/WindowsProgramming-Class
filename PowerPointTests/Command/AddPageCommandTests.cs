using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Tests
{
    [TestClass]
    public class AddPageCommandTests
    {
        PageManager _manager;
        PrivateObject _managerPrivate;

        // test
        [TestInitialize]
        public void Initialize()
        {
            _manager = new PageManager();
            _managerPrivate = new PrivateObject(_manager);
        }

        // test
        [TestMethod]
        public void ExecuteTest()
        {
            var cmd = new AddPageCommand
            {
                AddIndex = 0,
                Manager = _manager
            };
            cmd.Execute(null);
            Assert.IsNotNull(new PrivateObject(cmd).GetFieldOrProperty("_page"));
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            Assert.AreEqual(1, pages.Count);
            cmd.Execute(null);
            Assert.AreEqual(2, pages.Count);
        }

        // test
        [TestMethod]
        public void UndoTest()
        {
            var pages = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            var cmd = new AddPageCommand
            {
                AddIndex = 0,
                Manager = _manager
            };
            var cmd2 = new AddPageCommand
            {
                AddIndex = 0,
                Manager = _manager
            };
            cmd.Execute(null);
            cmd2.Execute(null);
            cmd.Undo(null);
            Assert.AreEqual(1, pages.Count);
        }
    }
}