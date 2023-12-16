using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace PowerPoint.Tests
{
    [TestClass]
    public class AddCommandTests
    {
        Page _list;

        // test
        [TestInitialize]
        public void Initialize()
        {
            _list = new Page();
        }

        // test
        [TestMethod]
        public void ExecuteTest()
        {
            var p1 = new Point(100, 100);
            var p2 = new Point(200, 200);
            var addRandom = new AddCommand
            {
                Type = ShapeType.Circle,
                PointFirst = p1,
                PointSecond = p2
            };
            addRandom.Execute(_list);
        }

        // test
        [TestMethod]
        public void UnexecuteTest()
        {
            var p1 = new Point(100, 100);
            var p2 = new Point(200, 200);
            var addRandom = new AddCommand
            {
                Type = ShapeType.Circle,
                PointFirst = p1,
                PointSecond = p2
            };
            addRandom.Undo(_list);
            Assert.AreEqual(0, _list.Count);

            addRandom.Execute(_list);
            addRandom.Undo(_list);
            Assert.AreEqual(0, _list.Count);
        }
    }
}