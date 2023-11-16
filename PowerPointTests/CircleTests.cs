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
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void CircleTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 50);
            var circle = new Circle(p1, p2);
            Assert.AreEqual(p2, circle.Diameter);
            Assert.AreEqual(new Point(p2.X / 2, p2.Y / 2), circle.Center);
        }

        [TestMethod()]
        public void PropertySet()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 50);
            var circle = new Circle(p1, p2);
            var pos = new Point(500, 500);
            circle.Center = pos;
            Assert.AreEqual(pos, circle.Center);
            var diameter = new Point(200, 200);
            circle.Diameter = diameter;
            Assert.AreEqual(diameter, circle.Diameter);
            var radius = new Point(100, 100);
            circle.Radius = radius;
            Assert.AreEqual(radius, circle.Radius);
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 50);
            var circle = new Circle(p1, p2);
            Assert.AreEqual("(50,25)", circle.GetInfo());
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 50);
            var circle = new Circle(p1, p2);
            Assert.AreEqual("圓形", circle.GetShapeName());
        }

        [TestMethod()]
        public void DrawTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContainsTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 50);
            var circle = new Circle(p1, p2);

            Assert.IsTrue(circle.Contains(circle.Center));
            Assert.IsTrue(circle.Contains(new Point(circle.Center.X + 1, circle.Center.Y + 1)));

            Assert.IsFalse(circle.Contains(p1));
            Assert.IsFalse(circle.Contains(p2));
        }

        [TestMethod()]
        public void MoveTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 50);
            var circle = new Circle(p1, p2);

            circle.Move(50, 25);
            Assert.AreEqual(p2, circle.Center);
            circle.Move(-100, -50);
            Assert.AreEqual(p1, circle.Center);
        }
    }
}