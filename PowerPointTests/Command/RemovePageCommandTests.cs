using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PowerPoint.Tests
{
    [TestClass]
    public class RemovePageCommandTests
    {
        PageManager _manager;
        PrivateObject _managerPrivate;

        // test
        [TestInitialize]
        public void Initialze()
        {
            _manager = new PageManager();
            _managerPrivate = new PrivateObject(_manager);
            for (int i = 0; i < 3; i++)
                _manager.AddBlankPage();
        }

        // test
        [TestMethod]
        public void ExecuteTest()
        {
            var cmd = new RemovePageCommand
            {
                Manager = _manager,
                RemoveIndex = 1
            };
            cmd.Execute(null);

            var list = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            Assert.IsFalse(list.Contains(new PrivateObject(cmd).GetFieldOrProperty("_page")));
        }

        // test
        [TestMethod]
        public void UndoTest()
        {
            var cmd = new RemovePageCommand
            {
                Manager = _manager,
                RemoveIndex = 1
            };
            cmd.Execute(null);
            var list = (List<Page>)_managerPrivate.GetFieldOrProperty("_pages");
            cmd.Undo(null);
            Assert.AreEqual(3, list.Count);
        }
    }
}