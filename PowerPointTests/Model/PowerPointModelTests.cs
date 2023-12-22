using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace PowerPoint.Tests
{
    class MockState : IState
    {
        public Action<Page, Point> mouseDown = null;
        public Action<Page, Point> mouseMove = null;
        public Action<Page, Point> mouseUp = null;

        /* mouse down */
        public Cursor MouseDown(Page list, Point pos)
        {
            mouseDown.Invoke(list, pos);
            return Cursors.Default;
        }

        /* mouse move */
        public Cursor MouseMove(Page list, Point pos)
        {
            mouseMove.Invoke(list, pos);
            return Cursors.Default;
        }

        /* mouse up */
        public Cursor MouseUp(Page list, Point pos)
        {
            mouseUp.Invoke(list, pos);
            return Cursors.Default;
        }

        // test
        public void SetShapeType(ShapeType type)
        {

        }
    }

    [TestClass]
    public class PowerPointModelTests
    {
        PowerPointModel _model;
        PrivateObject _modelPrivate;

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _model = new PowerPointModel();
            _model.AddBlankPage();
            _modelPrivate = new PrivateObject(_model);
        }

        /* property */
        [TestMethod]
        public void PropertyTest()
        {
            Assert.IsNotNull(_model.CurrentPage);

            Assert.IsNotNull(_model.DrawPen);
            const float width = 10.0f;
            var color = System.Drawing.Color.Black;
            var pen = new System.Drawing.Pen(color, width);
            _model.DrawPen = pen;
            Assert.AreEqual(color, _model.DrawPen.Color);
            Assert.AreEqual(width, _model.DrawPen.Width);

            var state = new PointState();
            _model.State = state;
            Assert.AreEqual(state, _model.State);

            _model.SelectedShape = ShapeType.Line;
            Assert.AreEqual(ShapeType.Line, _model.SelectedShape);

            _model.State = new DrawingState();
            _model.SelectedShape = ShapeType.Circle;
        }

        /* draw all */
        [TestMethod]
        public void DrawAllTest()
        {
            var page = _model.CurrentPage;
            int screenWidth = 800;
            int screenHeight = 600;
            page.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            page.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            page.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            page.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            int count = 0;
            var graphics = new PowerPointTests.MockGraphicsAdapter
            {
                drawRectangle = delegate (System.Drawing.Rectangle rect)
                {
                    count++;
                }
            };
            _model.DrawCurrentPage(graphics);
            Assert.AreEqual(page.Count, count);
        }

        /* do mouse down */
        [TestMethod]
        public void DoMouseDownTest()
        {
            bool executed = false;
            var location = new Point(50, 100);
            _model.SelectedShape = ShapeType.Rectangle;
            var state = new MockState
            {
                mouseDown = delegate (Page list, Point loc)
                {
                    executed = true;
                    Assert.AreEqual(location, loc);
                    Assert.AreEqual(_model.CurrentPage, list);
                }
            };
            _model.State = state;
            _model.DoMouseDown(location);
            Assert.IsTrue(executed);
        }

        /* do mouse move */
        [TestMethod]
        public void DoMouseMoveTest()
        {
            bool executed = false;
            var location = new Point(50, 100);
            var state = new MockState
            {
                mouseMove = delegate (Page list, Point loc)
                {
                    executed = true;
                    Assert.AreEqual(location, loc);
                    Assert.AreEqual(_model.CurrentPage, list);
                }
            };
            _model.State = state;
            _model.DoMouseMove(location);
            Assert.IsTrue(executed);
        }

        /* do mouse up */
        [TestMethod]
        public void DoMouseUpTest()
        {
            bool executed = false;
            var location = new Point(50, 100);
            var state = new MockState
            {
                mouseUp = delegate (Page list, Point loc)
                {
                    executed = true;
                    Assert.AreEqual(location, loc);
                    Assert.AreEqual(_model.CurrentPage, list);
                }
            };
            _model.State = state;
            _model.SelectedShape = ShapeType.Rectangle;
            _model.DoMouseUp(location);
            Assert.IsTrue(executed);
            Assert.AreEqual(ShapeType.None, _model.SelectedShape);
        }

        /* add random shape */
        [TestMethod]
        public void AddRandomShapeTest()
        {
            _model.AddRandomShape(ShapeType.Rectangle, 800, 600);
            Assert.AreEqual(1, _model.CurrentPage.Count);
            Assert.IsTrue(_model.CurrentPage[0] is Rectangle);
        }

        /* remove at */
        [TestMethod]
        public void RemoveAtTest()
        {
            const int screenWidth = 800;
            const int screenHeight = 600;
            _model.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            _model.AddRandomShape(ShapeType.Circle, screenWidth, screenHeight);
            var remain = _model.CurrentPage[1];
            _model.RemoveAt(0);
            Assert.AreEqual(1, _model.CurrentPage.Count);
            Assert.AreEqual(remain, _model.CurrentPage[0]);
        }

        /* do key down */
        [TestMethod]
        public void DoKeyDownTest()
        {
            const int screenWidth = 800;
            const int screenHeight = 600;
            _model.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            _model.AddRandomShape(ShapeType.Circle, screenWidth, screenHeight);

            var keyArgs = new KeyEventArgs(Keys.Escape);
            _model.State = new DrawingState();
            _model.DoKeyDown(keyArgs);
            Assert.AreEqual(2, _model.CurrentPage.Count);

            keyArgs = new KeyEventArgs(Keys.Delete);
            _model.DoKeyDown(keyArgs);
            Assert.AreEqual(2, _model.CurrentPage.Count);

            _model.State = new PointState();
            int x = _model.CurrentPage[0].HitBox.X + _model.CurrentPage[0].HitBox.Width / 2;
            int y = _model.CurrentPage[0].HitBox.Y + _model.CurrentPage[0].HitBox.Height / 2;
            _model.DoMouseDown(new Point(x, y));
            _model.DoKeyDown(keyArgs);
            Assert.AreEqual(1, _model.CurrentPage.Count);
        }
    }
}