using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Point = System.Drawing.Point;

namespace PowerPoint.Tests
{
    [TestClass]
    public class PresentationModelTests
    {
        PowerPointModel _m;
        PresentationModel _model;
        PrivateObject _modelPrivate;

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _m = new PowerPointModel();
            _m.AddBlankPage();
            _model = new PresentationModel(_m);
            _modelPrivate = new PrivateObject(_model);
        }

        /* constructor */
        [TestMethod]
        public void PresentationModelTest()
        {
            Assert.AreEqual(_m, _model.Model);
        }

        /* DoToolStripButtonClick */
        [TestMethod]
        public void DoToolStripButtonClickTest()
        {
            var type = _model.DoToolStripButtonClick(1, ShapeType.Circle);
            Assert.IsTrue(_model.CheckList[1].Value);
            Assert.AreEqual(ShapeType.Circle, type);

            type = _model.DoToolStripButtonClick(1, ShapeType.Circle);
            Assert.IsFalse(_model.CheckList[1].Value);
            Assert.AreEqual(ShapeType.None, type);
        }

        /* AddRandomShape */
        [TestMethod]
        public void AddRandomShapeTest()
        {
            _model.Model.AddShape(ShapeType.Circle, 800, 600);
            Assert.AreEqual(1, _m.CurrentPage.Count);
        }

        /* remove at */
        [TestMethod]
        public void RemoveAtTest()
        {
            _model.Model.AddShape(ShapeType.Circle, 800, 600);
            _model.Model.AddShape(ShapeType.Circle, 800, 600);
            var remain = _m.CurrentPage[1];
            _model.Model.RemoveAt(0);
            Assert.AreEqual(1, _m.CurrentPage.Count);
            Assert.AreEqual(remain, _m.CurrentPage[0]);
        }

        /* get draw pen */
        [TestMethod]
        public void GetDrawPenTest()
        {
            Assert.AreEqual(_model.GetDrawPen(), _m.DrawPen);
        }

        /* draw all */
        [TestMethod]
        public void DrawAllTest()
        {
            var g = new PowerPointTests.MockGraphicsAdapter();
            bool draw = false;
            g.drawRectangle = delegate (System.Drawing.Rectangle rect)
            {
                draw = true;
            };
            _model.Model.AddShape(ShapeType.Rectangle, 800, 600);
            _model.Model.DrawCurrentPage(g);
            Assert.IsTrue(draw);
        }

        /* do mouse down */
        [TestMethod]
        public void DoMouseDownTest()
        {
            var executed = false;
            var state = new MockState
            {
                mouseDown = delegate (Page shape, Point p)
                {
                    executed = true;
                }
            };
            _m.State = state;
            _model.DoMouseDown(new Point(0, 0));
            Assert.IsTrue(executed);
        }

        /* do mouse move */
        [TestMethod]
        public void DoMouseMoveTest()
        {
            var executed = false;
            var state = new MockState
            {
                mouseMove = delegate (Page shape, Point p)
                {
                    executed = true;
                }
            };
            _m.State = state;
            _model.DoMouseMove(new Point(0, 0));
            Assert.IsTrue(executed);
        }

        /* do mouse up */
        [TestMethod]
        public void DoMouseUpTest()
        {
            var executed = false;
            var state = new MockState
            {
                mouseUp = delegate (Page shape, Point p)
                {
                    executed = true;
                }
            };
            _m.State = state;
            _model.DoMouseUp(new Point(0, 0));
            Assert.IsTrue(executed);
            for (int i = 0; i < 3; i++)
            {
                Assert.IsFalse(_model.CheckList[i].Value);
            }
        }

        /* do key down */
        [TestMethod]
        public void DoKeyDownTest()
        {
            _model.Model.AddShape(ShapeType.Rectangle, 800, 600);
            _model.SetState(new PointState());
            int x = _m.CurrentPage[0].HitBox.X + _m.CurrentPage[0].HitBox.Width / 2;
            int y = _m.CurrentPage[0].HitBox.Y + _m.CurrentPage[0].HitBox.Height / 2;
            _model.DoMouseDown(new Point(x, y));
            _model.DoKeyDown(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Delete));
            Assert.AreEqual(0, _m.CurrentPage.Count);
        }

        /* set state */
        [TestMethod]
        public void SetStateTest()
        {
            var state = new PointState();
            _model.SetState(state);
            Assert.AreEqual(state, _m.State);
            Assert.IsTrue(_m.CurrentPage.Content.All((shape) => shape.Selected == false));
        }

        /* test */
        [TestMethod]
        public void UpdateDrawPanelSizeTest()
        {
            var size = (Point)_modelPrivate.Invoke("UpdateDrawPanelSize", 800, 600);
            Assert.AreEqual(800, size.X);
            Assert.AreEqual(450, size.Y);
            size = (Point)_modelPrivate.Invoke("UpdateDrawPanelSize", 1600, 90);
            Assert.AreEqual(160, size.X);
            Assert.AreEqual(90, size.Y);
        }

        /* test */
        [TestMethod]
        public void UpdateDrawPanelLocationTest()
        {
            int containerWidth = 800;
            int containerHeight = 600;
            var size = (Point)_modelPrivate.Invoke("UpdateDrawPanelSize", containerWidth, containerHeight);
            var pos = (Point)_modelPrivate.Invoke("UpdateDrawPanelLocation", containerWidth, containerHeight, size.X, size.Y);
            Assert.AreEqual(0, pos.X);
            Assert.AreEqual((600 - 450) / 2, pos.Y);
        }

        /* test */
        [TestMethod]
        public void ScaleFactorTest()
        {
            _modelPrivate.SetFieldOrProperty("_initialWidth", 800);
            _modelPrivate.SetFieldOrProperty("_initialHeight", 600);
            _model.CurrentDrawPanelWidth = 1600;
            _model.CurrentDrawPanelHeight = 300;
            Assert.AreEqual(2.0f, _model.DrawPanelScaleX);
            Assert.AreEqual(0.5f, _model.DrawPanelScaleY);
        }

        /* test */
        [TestMethod]
        public void UpdateDrawPanelSizeAndPositionTest()
        {
            _m.AddShape(ShapeType.Circle, 800, 600);

            var panel = new DoubleBufferedPanel();
            _model.UpdateDrawPanelSizeAndPosition(panel, 800, 600);
            Assert.AreEqual(800, panel.Width);
            Assert.AreEqual(450, panel.Height);

            _model.UpdateDrawPanelSizeAndPosition(panel, 1600, 1000);
            Assert.AreEqual(1600, panel.Width);
            Assert.AreEqual(900, panel.Height);
        }
    }
}