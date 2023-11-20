﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.Tests
{
    [TestClass]
    public class DrawingStateTests
    {
        DrawingState _state;
        PrivateObject _statePrivate;
        Shapes _list;
        Point _p1;
        Point _p2;

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _state = new DrawingState();
            _statePrivate = new PrivateObject(_state);
            _list = new Shapes();
            _p1 = new Point(100, 100);
            _p2 = new Point(200, 200);
        }

        /* mouse down */
        [TestMethod]
        public void MouseDownTest()
        {
            _state.MouseDown(_list, _p1);
            Assert.AreEqual(0, _list.Count);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreNotEqual(_p1, _statePrivate.GetFieldOrProperty("_drawStartPos"));
            Assert.AreNotEqual(_p1, _statePrivate.GetFieldOrProperty("_drawEndPos"));
            Assert.AreEqual(ShapeType.None, _statePrivate.GetFieldOrProperty("_type"));

            _state.SetShapeType(ShapeType.Circle);
            _state.MouseDown(_list, _p1);
            Assert.AreEqual(1, _list.Count);
            Assert.IsTrue(_list[0] is Circle);
            var circle = (Circle)_list[0];
            Assert.AreEqual(_p1, circle.Center);
            Assert.AreEqual(new Point(0, 0), circle.Diameter);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p1, _statePrivate.GetFieldOrProperty("_drawStartPos"));
            Assert.AreEqual(_p1, _statePrivate.GetFieldOrProperty("_drawEndPos"));
            Assert.AreEqual(ShapeType.Circle, _statePrivate.GetFieldOrProperty("_type"));
        }

        /* mouse move */
        [TestMethod]
        public void MouseMoveTest()
        {
            var cursor = _state.MouseMove(_list, _p2);
            Assert.AreEqual(0, _list.Count);
            Assert.AreEqual(Cursors.Default, cursor);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreNotEqual(_p1, _statePrivate.GetFieldOrProperty("_drawStartPos"));
            Assert.AreNotEqual(_p2, _statePrivate.GetFieldOrProperty("_drawEndPos"));
            Assert.AreEqual(ShapeType.None, _statePrivate.GetFieldOrProperty("_type"));

            _state.SetShapeType(ShapeType.Circle);
            cursor = _state.MouseMove(_list, _p2);
            Assert.AreEqual(Cursors.Cross, cursor);

            _state.SetShapeType(ShapeType.Circle);
            _state.MouseDown(_list, _p1);
            cursor = _state.MouseMove(_list, _p2);
            Assert.AreEqual(Cursors.Cross, cursor);
            Assert.AreEqual(1, _list.Count);
            Assert.IsTrue(_list[0] is Circle);
            var circle = (Circle)_list[0];
            var center = new Point();
            center.X = (_p1.X + _p2.X) / 2;
            center.Y = (_p1.Y + _p2.Y) / 2;
            Assert.AreEqual(center, circle.Center);
            Assert.AreEqual(new Point(_p2.X - _p1.X, _p2.Y - _p1.Y), circle.Diameter);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p1, _statePrivate.GetFieldOrProperty("_drawStartPos"));
            Assert.AreEqual(_p2, _statePrivate.GetFieldOrProperty("_drawEndPos"));
            Assert.AreEqual(ShapeType.Circle, _statePrivate.GetFieldOrProperty("_type"));
        }

        /* mouse up */
        [TestMethod]
        public void MouseUpTest()
        {
            _state.MouseUp(_list, _p2);
            Assert.AreEqual(0, _list.Count);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreNotEqual(_p1, _statePrivate.GetFieldOrProperty("_drawStartPos"));
            Assert.AreNotEqual(_p2, _statePrivate.GetFieldOrProperty("_drawEndPos"));
            Assert.AreEqual(ShapeType.None, _statePrivate.GetFieldOrProperty("_type"));

            _state.SetShapeType(ShapeType.Circle);
            _state.MouseDown(_list, _p1);
            _state.MouseUp(_list, _p2);
            Assert.IsTrue(_list.Count == 1);
            Assert.IsTrue(_list[0] is Circle);
            var circle = (Circle)_list[0];
            var center = new Point();
            center.X = (_p1.X + _p2.X) / 2;
            center.Y = (_p1.Y + _p2.Y) / 2;
            Assert.AreEqual(circle.Center, center);
            Assert.AreEqual(circle.Diameter, new Point(_p2.X - _p1.X, _p2.Y - _p1.Y));
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p1, _statePrivate.GetFieldOrProperty("_drawStartPos"));
            Assert.AreEqual(_p2, _statePrivate.GetFieldOrProperty("_drawEndPos"));
            Assert.AreEqual(ShapeType.Circle, _statePrivate.GetFieldOrProperty("_type"));
        }
    }
}