using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PowerPoint.Tests
{
    [TestClass]
    public class MoveCommandTests
    {
        Shapes _list;

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
            _list.AddRandomShape(ShapeType.Circle, 800, 600);
            var loc = _list[0].HitBox.Location;
            int dx = 10;
            int dy = -20;
            var cmd = new MoveCommand
            {
                MoveX = dx,
                MoveY = dy,
                SelectShape = _list[0]
            };
            cmd.Execute(_list);
            Assert.AreEqual(loc.X + dx, _list[0].HitBox.X);
            Assert.AreEqual(loc.Y + dy, _list[0].HitBox.Y);
        }

        // test
        [TestMethod]
        public void UnexecuteTest()
        {
            _list.AddRandomShape(ShapeType.Circle, 800, 600);
            var loc = _list[0].HitBox.Location;
            int dx = 10;
            int dy = -20;
            var cmd = new MoveCommand
            {
                MoveX = dx,
                MoveY = dy,
                SelectShape = _list[0]
            };
            cmd.Undo(_list);
            Assert.AreEqual(loc.X - dx, _list[0].HitBox.X);
            Assert.AreEqual(loc.Y - dy, _list[0].HitBox.Y);

            cmd.SelectShape = null;
            cmd.Undo(_list);
        }

        // test
        [TestMethod]
        public void CombineTest()
        {
            _list.AddRandomShape(ShapeType.Circle, 800, 600);
            int dx1 = 10;
            int dy1 = 5;
            int dx2 = -10;
            int dy2 = -5;
            var shape = _list[0];

            var cmd1 = new MoveCommand
            {
                MoveX = dx1,
                MoveY = dy1,
                SelectShape = shape
            };
            var cmd2 = new MoveCommand
            {
                MoveX = dx2,
                MoveY = dy2,
                SelectShape = shape
            };

            cmd1.Combine(cmd2);
            Assert.AreEqual(dx1 + dx2, cmd1.MoveX);
            Assert.AreEqual(dy1 + dy2, cmd1.MoveY);

            cmd1.SelectShape = null;
            bool exception = false;
            try
            {
                cmd1.Combine(cmd2);
            }
            catch (ArgumentException)
            {
                exception = true;
            }
            Assert.IsTrue(exception);
        }
    }
}