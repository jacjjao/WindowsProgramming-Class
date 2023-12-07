using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint.Tests
{
    [TestClass]
    public class AddCommandTests
    {
        Shapes _list;
        [TestInitialize]
        public void Initialize()
        {
            _list = new Shapes();
        }

        [TestMethod]
        public void AddRandomShapeTest()
        {
            var addRandom = new AddCommand
            {
                AddRandom = true,
                ScreenWidth = 800,
                ScreenHeight = 600
            };
            for (int i = 0; i < 500; i++)
            {
                addRandom.Execute(_list);
                Assert.IsTrue(_list[0].HitBox.X <= 800 && _list[0].HitBox.Y <= 600);
                _list.Content.Clear();
            }
        }

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

        [TestMethod]
        public void UnexecuteTest()
        {
            var addRandom = new AddCommand
            {
                AddRandom = true,
                ScreenWidth = 800,
                ScreenHeight = 600
            };
            addRandom.Unexecute(_list);
            Assert.AreEqual(0, _list.Count);

            addRandom.Execute(_list);
            addRandom.Unexecute(_list);
            Assert.AreEqual(0, _list.Count);
        }
    }
}