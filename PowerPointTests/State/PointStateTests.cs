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
    public class PointStateTests
    {
        PointState _state;
        PrivateObject _statePrivate;
        Point _p1;
        Point _p2;
        Shapes _list;

        [TestInitialize()]
        public void Initialize()
        {
            _state = new PointState();
            _statePrivate = new PrivateObject(_state);
            _p1 = new Point(100, 100);
            _p2 = new Point(200, 300);
            _list = new Shapes();
            _list.AddShape(ShapeType.Rectangle, new Point(50, 50), _p2);
            _list.AddShape(ShapeType.Rectangle, new Point(0, 0), _p2);
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            _state.MouseDown(_list, _p1, ShapeType.None);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p1, _statePrivate.GetFieldOrProperty("_previousMousePosition"));
            Assert.AreEqual(_list[1], _statePrivate.GetFieldOrProperty("_selectedShape"));
        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            _state.MouseMove(_list, _p2);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreNotEqual(_p2, _statePrivate.GetFieldOrProperty("_previousMousePosition"));
            Assert.IsNull(_statePrivate.GetFieldOrProperty("_selectedShape"));

            _state.MouseDown(_list, _p1, ShapeType.None);
            _state.MouseMove(_list, _p2);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p2, _statePrivate.GetFieldOrProperty("_previousMousePosition"));
            Assert.AreEqual(_list[1], _statePrivate.GetFieldOrProperty("_selectedShape"));

            var p = new Point(-10, -10);
            _state.MouseDown(_list, p, ShapeType.None);
            _state.MouseMove(_list, _p2);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p2, _statePrivate.GetFieldOrProperty("_previousMousePosition"));
            Assert.IsNull(_statePrivate.GetFieldOrProperty("_selectedShape"));
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            _state.MouseUp(_list, _p2);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));

            _state.MouseDown(_list, _p1, ShapeType.None);
            _state.MouseMove(_list, _p2);
            _state.MouseUp(_list, _p2);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
        }

        [TestMethod()]
        public void RemoveSelectedShapeTest()
        {
            var shouldRemain = _list[0];
            _state.MouseDown(_list, new Point(10, 10), ShapeType.None);
            _state.RemoveSelectedShape(_list);
            Assert.AreEqual(1, _list.Count);
            Assert.AreEqual(shouldRemain, _list[0]);
            Assert.IsNull(_statePrivate.GetFieldOrProperty("_selectedShape"));
        }
    }
}