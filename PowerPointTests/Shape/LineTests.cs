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
        Line _line;

        [TestInitialize()]
        public void Initialize()
        {
            _p1 = new Point(0, 0);
            _p2 = new Point(100, 100);
            _line = new Line(_p1, _p2);
        }

        [TestMethod()]
        public void LineTest()
        {
            Assert.AreEqual(_p1, _line.StartPoint);
            Assert.AreEqual(_p2, _line.EndPoint);

            var p3 = new Point(_p2.X, _p2.Y);
            var p4 = new Point(_p1.X, _p1.Y);
            _line = new Line(p3, p4);
            Assert.AreEqual(p4, _line.StartPoint);
            Assert.AreEqual(p3, _line.EndPoint);
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            var str = string.Format("({0},{1})({2},{3})", _p1.X, _p1.Y, _p2.X, _p2.Y);
            Assert.AreEqual(str, _line.GetInfo());
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual("線", _line.GetShapeName());
        }

        [TestMethod()]
        public void DrawTest()
        {
            bool executed = false;
            var graphics = new PowerPointTests.MockGraphicsAdapter
            {
                drawLine = delegate (Point start, Point end)
                {
                    executed = true;
                    Assert.AreEqual(_line.StartPoint, start);
                    Assert.AreEqual(_line.EndPoint, end);
                }
            };
            _line.Draw(graphics);
            Assert.IsTrue(executed);
        }

        [TestMethod()]
        public void MoveTest()
        {
            int dx = 100, dy = 50;
            var p3 = new Point(_p1.X + dx, _p1.Y + dy);
            var p4 = new Point(_p2.X + dx, _p2.Y + dy);
            _line.Move(dx, dy);
            Assert.AreEqual(p3, _line.StartPoint);
            Assert.AreEqual(p4, _line.EndPoint);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Assert.IsTrue(_line.Contains(new Point(50, 50)));
            Assert.IsFalse(_line.Contains(new Point(-1, 50)));
            Assert.IsFalse(_line.Contains(new Point(1000, 50)));
            Assert.IsFalse(_line.Contains(new Point(50, -1)));
            Assert.IsFalse(_line.Contains(new Point(50, 1000)));
        }
    }
}