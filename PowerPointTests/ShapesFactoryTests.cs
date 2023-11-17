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
        ShapesFactory _factory;

        [TestInitialize()]
        public void Initialize()
        {
            _factory = new ShapesFactory();
        }

        [TestMethod()]
        public void CreateRandomShapeTest()
        {
            int screenWidth = 800, screenHeight = 600;
            var shape = _factory.CreateRandomShape(ShapeType.Circle, screenWidth, screenHeight);
            Assert.IsTrue(shape is Circle);
            var circle = (Circle)shape;
            Assert.IsTrue(0 < circle.Diameter.X && circle.Diameter.X < screenWidth);
            Assert.IsTrue(0 < circle.Center.X - circle.Radius.X && circle.Center.X + circle.Radius.X < screenWidth);
            Assert.IsTrue(0 < circle.Diameter.Y && circle.Diameter.Y < screenHeight);
            Assert.IsTrue(0 < circle.Center.Y - circle.Radius.Y && circle.Center.Y + circle.Radius.Y < screenHeight);
        }

        [TestMethod()]
        public void CreateShapeTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(200, 100);
            var shape = _factory.CreateShape(ShapeType.None, p1, p2);
            Assert.AreEqual(null, shape);

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