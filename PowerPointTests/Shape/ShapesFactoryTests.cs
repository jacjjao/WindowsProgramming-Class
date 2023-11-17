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
    public class ShapesFactoryTests
    {
        PowerPointTests.MockRandom _random;
        ShapesFactory _factory;

        [TestInitialize()]
        public void Initialize()
        {
            _random = new PowerPointTests.MockRandom();
            _factory = new ShapesFactory(_random);
        }

        [TestMethod()]
        public void CreateRandomShapeTest()
        {
            int screenWidth = 800, screenHeight = 600;
            var shape = _factory.CreateRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            Assert.IsTrue(shape is Rectangle);
            var rect = (Rectangle)shape;
            Assert.AreEqual(_random.value[0], rect.Size.X);
            Assert.AreEqual(_random.value[1], rect.Size.Y);
            Assert.AreEqual(_random.value[2], rect.Position.X);
            Assert.AreEqual(_random.value[3], rect.Position.Y);
        }

        [TestMethod()]
        public void CreateShapeTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(200, 100);
            var shape = _factory.CreateShape(ShapeType.None, p1, p2);
            Assert.IsNull(shape);

            shape = _factory.CreateShape(ShapeType.Circle, p1, p2);
            Assert.IsTrue(shape is Circle);
            var circle = (Circle)shape;
            Assert.AreEqual(new Point(100, 50), circle.Center);

            shape = _factory.CreateShape(ShapeType.Rectangle, p1, p2);
            Assert.IsTrue(shape is Rectangle);
            var rect = (Rectangle)shape;
            Assert.AreEqual(new Point(0, 0), rect.Position);
            Assert.AreEqual(p2, rect.Size);

            shape = _factory.CreateShape(ShapeType.Line, p1, p2);
            Assert.IsTrue(shape is Line);
            var line = (Line)shape;
            Assert.AreEqual(p1, line.StartPoint);
            Assert.AreEqual(p2, line.EndPoint);
        }
    }
}