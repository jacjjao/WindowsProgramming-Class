﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Point = System.Drawing.Point;

namespace PowerPoint.Tests
{
    [TestClass]
    public class PageTests
    {
        Page _list;

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _list = new Page();
        }

        /* constructor */
        [TestMethod]
        public void ShapesTest()
        {
            Assert.IsTrue(_list.Content.AllowNew);
            Assert.IsTrue(_list.Content.AllowRemove);
            Assert.IsTrue(_list.Content.RaiseListChangedEvents);
            Assert.IsTrue(_list.Content.AllowEdit);
        }

        /* add random shape */
        [TestMethod]
        public void AddRandomShapeTest()
        {
            int screenWidth = 800;
            int screenHeight = 600;
            _list.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            Assert.AreEqual(1, _list.Count);
            Assert.IsTrue(_list[0] is Rectangle);
        }

        /* operator [] */
        [TestMethod]
        public void IndexerTest()
        {
            int screenWidth = 800;
            int screenHeight = 600;
            _list.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            var shape = new Rectangle(new Point(0, 0), new Point(10, 10));
            _list[0] = shape;
            Assert.AreEqual(shape, _list[0]);
        }

        /* add shape */
        [TestMethod]
        public void AddShapeTest()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(100, 100);
            _list.AddShape(ShapeType.Line, p1, p2);
            Assert.AreEqual(1, _list.Count);
            Assert.IsTrue(_list[0] is Line);
            var line = (Line)_list[0];
            Assert.AreEqual(p1, line.PointLeft);
            Assert.AreEqual(p2, line.PointRight);
        }

        /* remove */
        [TestMethod]
        public void RemoveTest()
        {
            _list.AddRandomShape(ShapeType.Circle, 100, 100);
            _list.AddRandomShape(ShapeType.Rectangle, 100, 100);
            var s2 = _list[1];
            _list.Remove(_list[0]);
            Assert.AreEqual(1, _list.Count);
            Assert.AreEqual(s2, _list[0]);
        }

        /* remove at */
        [TestMethod]
        public void RemoveAtTest()
        {
            _list.AddRandomShape(ShapeType.Circle, 100, 100);
            _list.AddRandomShape(ShapeType.Rectangle, 100, 100);
            var s2 = _list[1];
            _list.RemoveAt(0);
            Assert.AreEqual(1, _list.Count);
            Assert.AreEqual(s2, _list[0]);
        }

        /* find contain */
        [TestMethod]
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

        /* draw all */
        [TestMethod]
        public void DrawAllTest()
        {
            int idx = 0;
            int circleIdx = 0;
            int rectIdx = 0;
            int lineIdx = 0;
            var graphics = new PowerPointTests.MockGraphicsAdapter
            {
                drawEllipse = delegate (System.Drawing.Rectangle rect)
                {
                    circleIdx = ++idx;
                },
                drawRectangle = delegate (System.Drawing.Rectangle rect)
                {
                    rectIdx = ++idx;
                },
                drawLine = delegate (Point p1, Point p2)
                {
                    lineIdx = ++idx;
                }
            };
            const int screenWidth = 800;
            const int screenHeight = 600;
            _list.AddRandomShape(ShapeType.Circle, screenWidth, screenHeight);
            _list.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            _list.AddRandomShape(ShapeType.Line, screenWidth, screenHeight);
            _list.DrawAll(new Pen(Color.Red), graphics);
            Assert.AreEqual(1, circleIdx);
            Assert.AreEqual(2, rectIdx);
            Assert.AreEqual(3, lineIdx);
        }
    }
}