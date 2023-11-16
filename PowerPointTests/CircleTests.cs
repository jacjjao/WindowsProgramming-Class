using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.AreEqual(circle.Diameter, p2);
            Assert.AreEqual(circle.Center, new Point(p2.X / 2, p2.Y / 2));
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 50);
            var circle = new Circle(p1, p2);
            Assert.AreEqual(circle.GetInfo(), "(50,25)");
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 50);
            var circle = new Circle(p1, p2);
            Assert.AreEqual(circle.GetShapeName(), "圓形");
        }

        [TestMethod()]
        public void DrawTest()
        {

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
            Assert.AreEqual(circle.Center, p2);
            circle.Move(-100, -50);
            Assert.AreEqual(circle.Center, p1);
        }
    }
}