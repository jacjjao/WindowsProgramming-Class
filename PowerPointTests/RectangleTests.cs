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
    public class RectangleTests
    {
        Point _p1;
        Point _p2;
        Rectangle _rect;

        [TestInitialize()]
        public void Initialize()
        {
            _p1 = new Point(0, 0);
            _p2 = new Point(100, 200);
            _rect = new Rectangle(_p1, _p2);
        }

        [TestMethod()]
        public void RectangleTest()
        {
            Assert.AreEqual(_p1, _rect.Position);
            Assert.AreEqual(_p2, _rect.Size);
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            var str = string.Format("({0},{1})({2},{3})", _p1.X, _p1.Y, _p2.X, _p2.Y);
            Assert.AreEqual(str, _rect.GetInfo());
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual("矩形", _rect.GetShapeName());
        }

        [TestMethod()]
        public void DrawTest()
        {
            bool executed = false;
            var graphics = new PowerPointTests.MockGraphicsAdapter
            {
                drawRectangle = delegate (Point position, Point size)
                {
                    executed = true;
                    Assert.AreEqual(position, _rect.Position);
                    Assert.AreEqual(size, _rect.Size);
                }
            };
            _rect.Draw(graphics);
            Assert.IsTrue(executed);
        }

        [TestMethod()]
        public void MoveTest()
        {
            _rect.Move(_p2.X, _p2.Y);
            Assert.AreEqual(_p2, _rect.Position);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Assert.IsTrue(_rect.Contains(new Point(50, 100)));
            Assert.IsFalse(_rect.Contains(new Point(-1, -1)));
            Assert.IsFalse(_rect.Contains(new Point(50, -1)));
            Assert.IsFalse(_rect.Contains(new Point(50, 1000)));
            Assert.IsFalse(_rect.Contains(new Point(-1, 50)));
            Assert.IsFalse(_rect.Contains(new Point(10000, 50)));
        }
    }
}