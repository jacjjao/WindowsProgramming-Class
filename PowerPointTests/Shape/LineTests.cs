using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Point = System.Drawing.Point;

namespace PowerPoint.Tests
{
    [TestClass]
    public class LineTests
    {
        Point _p1;
        Point _p2;
        Line _line;

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _p1 = new Point(0, 0);
            _p2 = new Point(100, 100);
            _line = new Line(_p1, _p2);
        }

        /* constructor */
        [TestMethod]
        public void LineTest()
        {
            Assert.AreEqual(_p1, _line.PointLeft);
            Assert.AreEqual(_p2, _line.PointRight);

            var p3 = _p2;
            var p4 = _p1;
            _line = new Line(p3, p4);
            Assert.AreEqual(p4, _line.PointLeft);
            Assert.AreEqual(p3, _line.PointRight);

            var p5 = new Point(0, 500);
            _line = new Line(p5, _p2);
            Assert.AreEqual(p5, _line.PointLeft);
            Assert.AreEqual(_p2, _line.PointRight);
        }

        /* GetInfo */
        [TestMethod]
        public void GetInfoTest()
        {
            var str = string.Format("({0},{1})({2},{3})", _p1.X, _p1.Y, _p2.X, _p2.Y);
            Assert.AreEqual(str, _line.GetInfo());
        }

        /* GetShapeName */
        [TestMethod]
        public void GetShapeNameTest()
        {
            Assert.AreEqual("線", _line.GetShapeName());
        }

        /* draw */
        [TestMethod]
        public void DrawTest()
        {
            bool executed = false;
            var graphics = new PowerPointTests.MockGraphicsAdapter
            {
                drawLine = delegate (Point start, Point end)
                {
                    executed = true;
                    Assert.AreEqual(_line.PointLeft, start);
                    Assert.AreEqual(_line.PointRight, end);
                }
            };
            _line.Draw(new Pen(Color.Red), graphics);
            Assert.IsTrue(executed);
        }

        /* move */
        [TestMethod]
        public void MoveTest()
        {
            int dx = 100, dy = 50;
            var p3 = new Point(_p1.X + dx, _p1.Y + dy);
            var p4 = new Point(_p2.X + dx, _p2.Y + dy);
            _line.Move(dx, dy);
            Assert.AreEqual(p3, _line.PointLeft);
            Assert.AreEqual(p4, _line.PointRight);
        }

        [TestMethod]
        public void ResizeTest()
        {
            var p3 = new Point(50, 50);
            _line.Resize(p3, _p2);
            Assert.AreEqual(p3, _line.PointLeft);
            Assert.AreEqual(_p2, _line.PointRight);

            var p4 = new Point(200, 0);
            _line.Resize(p4, _p2);
            Assert.AreEqual(_p2, _line.PointLeft);
            Assert.AreEqual(p4, _line.PointRight);

            var p5 = new Point(0, 500);
            _line = new Line(p5, _p2);
            _line.Resize(p5, _p2);
        }

        /* contains */
        [TestMethod]
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