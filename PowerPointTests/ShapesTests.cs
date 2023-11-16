using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes _list;

        [TestInitialize()]
        public void Initialize()
        {
            _list = new Shapes();
        }

        [TestMethod()]
        public void ShapesTest()
        {
            Assert.IsTrue(_list.Content.AllowNew);
            Assert.IsTrue(_list.Content.AllowRemove);
            Assert.IsTrue(_list.Content.RaiseListChangedEvents);
            Assert.IsTrue(_list.Content.AllowEdit);
        }

        [TestMethod()]
        public void AddRandomShapeTest()
        {
            int screenWidth = 800;
            int screenHeight = 600;
            _list.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            Assert.AreEqual(1, _list.Count);
            Assert.IsTrue(_list[0] is Rectangle);
            var rect = (Rectangle)_list[0];
            Assert.IsTrue(0 <= rect.Position.X && rect.Position.X < screenWidth);
            Assert.IsTrue(0 <= rect.Position.Y && rect.Position.Y < screenHeight);
            Assert.IsTrue(rect.Position.X + rect.Size.X <= screenWidth);
            Assert.IsTrue(rect.Position.Y + rect.Size.Y <= screenHeight);
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 100);
            _list.AddShape(ShapeType.Line, p1, p2);
            Assert.AreEqual(1, _list.Count);
            Assert.IsTrue(_list[0] is Line);
            var line = (Line)_list[0];
            Assert.AreEqual(p1, line.StartPoint);
            Assert.AreEqual(p2, line.EndPoint);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            _list.AddRandomShape(ShapeType.Circle, 100, 100);
            _list.AddRandomShape(ShapeType.Rectangle, 100, 100);
            var s2 = _list[1];
            _list.Remove(_list[0]);
            Assert.AreEqual(1, _list.Count);
            Assert.AreEqual(s2, _list[0]);
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            _list.AddRandomShape(ShapeType.Circle, 100, 100);
            _list.AddRandomShape(ShapeType.Rectangle, 100, 100);
            var s2 = _list[1];
            _list.RemoveAt(0);
            Assert.AreEqual(1, _list.Count);
            Assert.AreEqual(s2, _list[0]);
        }

        [TestMethod()]
        public void FindContainTest()
        {
            Assert.AreEqual(null, _list.FindContain(new Point()));
            _list.AddShape(ShapeType.Rectangle, new Point(), new Point(100, 100));
            _list.AddShape(ShapeType.Rectangle, new Point(300, 300), new Point(400, 400));

            Assert.AreEqual(_list[0], _list.FindContain(new Point(50, 50)));
            Assert.AreEqual(_list[1], _list.FindContain(new Point(350, 350)));

            _list.AddShape(ShapeType.Rectangle, new Point(), new Point(200, 200));
            Assert.AreEqual(_list[2], _list.FindContain(new Point(50, 50)));

            Assert.AreEqual(null, _list.FindContain(new Point(-100, -100)));
        }

        [TestMethod()]
        public void DrawAllTest()
        {
            Assert.Fail();
        }
    }
}