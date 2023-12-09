using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointTests;
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
            _state.Manager = null;
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
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p1, _statePrivate.GetFieldOrProperty("_drawStartPos"));
            Assert.AreEqual(_p2, _statePrivate.GetFieldOrProperty("_drawEndPos"));
            Assert.AreEqual(ShapeType.Circle, _statePrivate.GetFieldOrProperty("_type"));

            _list.AddRandomShape(ShapeType.Circle, 800, 600);
            _state.MouseDown(_list, _p1);
            bool executed = false;
            var manager = new MockCommandManager
            {
                execute = (ICommand command) =>
                {
                    executed = true;
                    var addCommand = (AddCommand)command;
                    Assert.IsFalse(addCommand.AddRandom);
                }
            };
            _state.Manager = manager;
            Assert.AreEqual(manager, _state.Manager);
            _state.MouseMove(_list, _p2);
            Assert.IsTrue(executed);
            Assert.AreEqual(Cursors.Cross, cursor);
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(_p1, _statePrivate.GetFieldOrProperty("_drawStartPos"));
            Assert.AreEqual(_p2, _statePrivate.GetFieldOrProperty("_drawEndPos"));
            Assert.AreEqual(ShapeType.Circle, _statePrivate.GetFieldOrProperty("_type"));

            _state = new DrawingState();
            _state.SetShapeType(ShapeType.Circle);
            _state.MouseDown(_list, new Point(0, 0));
            _state.MouseMove(_list, new Point(20, 20));
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
            Assert.IsTrue((bool)_statePrivate.GetFieldOrProperty("_mouseMoved"));
            cursor = _state.MouseMove(_list, new Point(50, 50));
            Assert.AreEqual(Cursors.Cross, cursor);

            _state = new DrawingState();
            _statePrivate.SetFieldOrProperty("_mousePressed", true);
            _statePrivate.SetFieldOrProperty("_mouseMoved", true);
            _state.MouseMove(_list, _p2);
            Assert.IsNull(_statePrivate.GetFieldOrProperty("_shape"));
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

            _list.AddRandomShape(ShapeType.Circle, 800, 600);
            _statePrivate.SetFieldOrProperty("_mousePressed", true);
            _state.MouseUp(_list, _p2);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));

            _list.Content.Clear();
            _statePrivate.SetFieldOrProperty("_mousePressed", true);
            _state.MouseUp(_list, _p2);
            Assert.IsFalse((bool)_statePrivate.GetFieldOrProperty("_mousePressed"));
        }
    }
}