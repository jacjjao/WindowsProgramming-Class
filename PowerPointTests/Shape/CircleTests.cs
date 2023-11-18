using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace PowerPoint.Tests
{
    [TestClass]
    public class CircleTests
    {
        Point _p1;
        Point _p2;
        Circle _circle;
        
        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _p1 = new Point(0, 0);
            _p2 = new Point(100, 50);
            _circle = new Circle(_p1, _p2);
        }

        /* constructor */
        [TestMethod]
        public void CircleTest()
        {
            Assert.AreEqual(_p2, _circle.Diameter);
            Assert.AreEqual(new Point(_p2.X / 2, _p2.Y / 2), _circle.Center);
        }

        /* property */
        [TestMethod]
        public void PropertySet()
        {
            var pos = new Point(500, 500);
            _circle.Center = pos;
            Assert.AreEqual(pos, _circle.Center);
            var diameter = new Point(200, 200);
            _circle.Diameter = diameter;
            Assert.AreEqual(diameter, _circle.Diameter);
            var radius = new Point(100, 100);
            _circle.Radius = radius;
            Assert.AreEqual(radius, _circle.Radius);
        }

        /* GetInfo */
        [TestMethod]
        public void GetInfoTest()
        {
            Assert.AreEqual("(50,25)", _circle.GetInfo());
        }

        /* GetShapeName */
        [TestMethod]
        public void GetShapeNameTest()
        {
            Assert.AreEqual("圓形", _circle.GetShapeName());
        }

        /* draw */
        [TestMethod]
        public void DrawTest()
        {
            bool executed = false;
            var graphics = new PowerPointTests.MockGraphicsAdapter
            {
                drawCircle = delegate (Point center, Point diameter)
                {
                    executed = true;
                    Assert.AreEqual(center, _circle.Center);
                    Assert.AreEqual(diameter, _circle.Diameter);
                }
            };
            _circle.Draw(graphics);
            Assert.IsTrue(executed);
        }

        /* contains */
        [TestMethod]
        public void ContainsTest()
        {
            Assert.IsTrue(_circle.Contains(_circle.Center));
            Assert.IsTrue(_circle.Contains(new Point(_circle.Center.X + 1, _circle.Center.Y + 1)));

            Assert.IsFalse(_circle.Contains(_p1));
            Assert.IsFalse(_circle.Contains(_p2));
        }

        /* move */
        [TestMethod]
        public void MoveTest()
        {
            _circle.Move(50, 25);
            Assert.AreEqual(_p2, _circle.Center);
            _circle.Move(-100, -50);
            Assert.AreEqual(_p1, _circle.Center);
        }
    }
}