using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointTests;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace PowerPoint.Tests
{
    [TestClass]
    public class PointStateTests
    {
        PointState _state;
        PrivateObject _statePrivate;
        Point _p1;
        Point _p2;
        Page _list;

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _state = new PointState();
            _statePrivate = new PrivateObject(_state);
            _p1 = new Point(0, 0);
            _p2 = new Point(200, 300);
            _list = new Page();
            _list.AddShape(ShapeType.Rectangle, new Point(50, 50), _p2);
            _list.AddShape(ShapeType.Rectangle, _p1, _p2);
        }

        /* get cursor */
        [TestMethod]
        public void GetCursorTest()
        {
            Assert.AreEqual(Cursors.SizeNS, _statePrivate.Invoke("GetCursor", ResizeDirection.TopMiddle));
            Assert.AreEqual(Cursors.SizeNS, _statePrivate.Invoke("GetCursor", ResizeDirection.BottomMiddle));

            Assert.AreEqual(Cursors.SizeNWSE, _statePrivate.Invoke("GetCursor", ResizeDirection.TopLeft));
            Assert.AreEqual(Cursors.SizeNWSE, _statePrivate.Invoke("GetCursor", ResizeDirection.BottomRight));

            Assert.AreEqual(Cursors.SizeNESW, _statePrivate.Invoke("GetCursor", ResizeDirection.TopRight));
            Assert.AreEqual(Cursors.SizeNESW, _statePrivate.Invoke("GetCursor", ResizeDirection.BottomLeft));

            Assert.AreEqual(Cursors.SizeWE, _statePrivate.Invoke("GetCursor", ResizeDirection.MiddleLeft));
            Assert.AreEqual(Cursors.SizeWE, _statePrivate.Invoke("GetCursor", ResizeDirection.MiddleRight));

            Assert.AreEqual(Cursors.SizeAll, _statePrivate.Invoke("GetCursor", ResizeDirection.None));
        }

        /* mouse down */
        [TestMethod]
        public void MouseDownTest()
        {
            var cursor = _state.MouseDown(_list, _p1);
            Assert.AreEqual(Cursors.SizeAll, cursor);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p1, _statePrivate.GetFieldOrProperty("_previousMousePosition"));
            Assert.AreEqual(_list[1], _statePrivate.GetFieldOrProperty("_selectedShape"));

            _state.MouseDown(_list, new Point(20, 20));
            cursor = _state.MouseDown(_list, new Point(20, 20));
            Assert.AreEqual(Cursors.SizeAll, cursor);
            Assert.AreEqual(ResizeDirection.None, _statePrivate.GetFieldOrProperty("_direction"));
            cursor = _state.MouseDown(_list, new Point(1, 1));
            Assert.AreEqual(Cursors.SizeNWSE, cursor);
            Assert.AreEqual(ResizeDirection.TopLeft, _statePrivate.GetFieldOrProperty("_direction"));

            var p = new Point(-100, -100);
            cursor = _state.MouseDown(_list, p);
            Assert.AreEqual(Cursors.Default, cursor);
        }

        /* mouse move */
        [TestMethod]
        public void MouseMoveTest()
        {
            _state.MouseMove(_list, _p2);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreNotEqual(_p2, _statePrivate.GetFieldOrProperty("_previousMousePosition"));
            Assert.IsNull(_statePrivate.GetFieldOrProperty("_selectedShape"));

            _state.MouseDown(_list, _p1);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mouseMoved"));
            _state.MouseMove(_list, _p2);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mouseMoved"));
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p2, _statePrivate.GetFieldOrProperty("_previousMousePosition"));
            Assert.AreEqual(_list[1], _statePrivate.GetFieldOrProperty("_selectedShape"));

            bool executed = false;
            var p = new Point(50, 50);
            _state.Manager = new MockCommandManager
            {
                _execute = (ICommand command) =>
                {
                    var moveCommand = (MoveCommand)command;
                    executed = true;
                    Assert.AreEqual(moveCommand.MoveX, _p2.X - p.X);
                    Assert.AreEqual(moveCommand.MoveY, _p2.Y - p.Y);
                }
            };
            _state.MouseDown(_list, p);
            _state.MouseMove(_list, _p2);
            Assert.IsTrue(executed);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p2, _statePrivate.GetFieldOrProperty("_previousMousePosition"));
            Assert.IsNotNull(_statePrivate.GetFieldOrProperty("_selectedShape"));
        }

        /* mouse up */
        [TestMethod]
        public void MouseUpTest()
        {
            var cursor = _state.MouseUp(_list, new Point(-10, -10));
            Assert.AreEqual(Cursors.Default, cursor);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));

            _state.MouseDown(_list, _p1);
            _state.MouseMove(_list, _p2);
            cursor = _state.MouseUp(_list, _p2);
            Assert.AreEqual(Cursors.SizeAll, cursor);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));

            cursor = _state.MouseUp(_list, new Point(-10, -10));
            Assert.AreEqual(Cursors.Default, cursor);
        }

        /* mouse move */
        [TestMethod]
        public void MouseMoveTest2()
        {
            _state.MouseDown(_list, _p1);
            _state.MouseUp(_list, _p1);
            var cursor = _state.MouseMove(_list, _p2);
            Assert.AreEqual(Cursors.SizeNWSE, cursor);
            cursor = _state.MouseMove(_list, new Point(100, 100));
            Assert.AreEqual(Cursors.SizeAll, cursor);
            cursor = _state.MouseMove(_list, new Point(-100, -100));
            Assert.AreEqual(Cursors.Default, cursor);
        }

        /* remove selected */
        [TestMethod]
        public void RemoveSelectedShapeTest()
        {
            int nShape = _list.Count;
            _state.MouseDown(_list, new Point(-10, -10));
            _state.RemoveSelectedShape(_list);
            Assert.AreEqual(nShape, _list.Count);
            Assert.IsNull(_statePrivate.GetFieldOrProperty("_selectedShape"));

            var manager = new MockCommandManager();
            manager._execute = (ICommand command) =>
            {
                command.Execute(_list);
            };
            _state.Manager = manager;
            Assert.AreEqual(manager, _state.Manager);

            var shouldRemain = _list[0];
            _state.MouseDown(_list, new Point(10, 10));
            _state.RemoveSelectedShape(_list);
            Assert.AreEqual(nShape - 1, _list.Count);
            Assert.AreEqual(shouldRemain, _list[0]);
            Assert.IsNull(_statePrivate.GetFieldOrProperty("_selectedShape"));
        }
    }
}