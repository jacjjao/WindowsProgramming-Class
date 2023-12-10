using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Tests
{
    [TestClass]
    public class DeleteCommandTests
    {
        Shapes _list = null;

        // test
        [TestInitialize]
        public void Initialize()
        {
            _list = new Shapes();
        }

        // test
        [TestMethod]
        public void ExecuteTest()
        {
            _list.AddRandomShape(ShapeType.Line, 800, 600);
            var cmd = new DeleteCommand
            {
                DeleteIndex = 0
            };
            cmd.Execute(_list);
            Assert.AreEqual(0, _list.Count);
        }

        // test
        [TestMethod]
        public void UnexecuteTest()
        {
            _list.AddRandomShape(ShapeType.Line, 800, 600);
            var shape = _list[0];
            var cmd = new DeleteCommand
            {
                DeleteIndex = 0
            };
            cmd.Undo(_list);
            Assert.AreEqual(1, _list.Count);
            cmd.Execute(_list);
            cmd.Undo(_list);
            Assert.AreEqual(1, _list.Count);
            Assert.AreEqual(shape, _list[0]);
        }
    }
}