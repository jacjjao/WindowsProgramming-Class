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
    public class LineTests
    {
        Point _p1;
        Point _p2;

        [TestInitialize()]
        public void Initialize()
        {
            _p1 = new Point(0, 0);
            _p2 = new Point(100, 100);
        }

        [TestMethod()]
        public void LineTest()
        {
            var line = new Line(_p1, _p2);
            Assert.AreEqual(_p1, line.StartPoint);
            Assert.AreEqual(_p2, line.EndPoint);

            var p3 = new Point(_p2.X, _p2.Y);
            var p4 = new Point(_p1.X, _p1.Y);
            line = new Line(p3, p4);
            Assert.AreEqual(p4, line.StartPoint);
            Assert.AreEqual(p3, line.EndPoint);
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            var line = new Line(_p1, _p2);
            var str = string.Format("({0},{1})({2},{3})", _p1.X, _p1.Y, _p2.X, _p2.Y);
            Assert.AreEqual(str, line.GetInfo());
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            var line = new Line(_p1, _p2);
            Assert.AreEqual("線", line.GetShapeName());
        }

        [TestMethod()]
        public void DrawTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MoveTest()
        {
            var line = new Line(_p1, _p2);
            int dx = 100, dy = 50;
            var p3 = new Point(_p1.X + dx, _p1.Y + dy);
            var p4 = new Point(_p2.X + dx, _p2.Y + dy);
            line.Move(dx, dy);
            Assert.AreEqual(p3, line.StartPoint);
            Assert.AreEqual(p4, line.EndPoint);
        }
    }
}