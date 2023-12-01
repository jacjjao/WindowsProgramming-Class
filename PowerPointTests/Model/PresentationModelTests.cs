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

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _m = new PowerPointModel();
            _model = new PresentationModel(_m);
        }

        /* constructor */
        [TestMethod]
        public void PresentationModelTest()
        {
            const int LEN = 6;
            Assert.AreEqual(LEN, _model.CheckList.Count);
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
            _model.AddRandomShape(ShapeType.Circle, 800, 600);
            Assert.AreEqual(1, _m.ShapeList.Count);
        }

        /* remove at */
        [TestMethod]
        public void RemoveAtTest()
        {
            _model.AddRandomShape(ShapeType.Circle, 800, 600);
            _model.AddRandomShape(ShapeType.Circle, 800, 600);
            var remain = _m.ShapeList[1];
            _model.RemoveAt(0);
            Assert.AreEqual(1, _m.ShapeList.Count);
            Assert.AreEqual(remain, _m.ShapeList[0]);
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
            _model.AddRandomShape(ShapeType.Rectangle, 800, 600);
            _model.DrawAll(g);
            Assert.IsTrue(draw);
        }

        /* do mouse down */
        [TestMethod]
        public void DoMouseDownTest()
        {
            var executed = false;
            var state = new MockState
            {
                mouseDown = delegate (Shapes shape, Point p)
                {
                    executed = true;
                }
            };
            _m.State = state;
            _model.DoMouseDown(new System.Windows.Forms.MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0));
            Assert.IsTrue(executed);
        }

        /* do mouse move */
        [TestMethod]
        public void DoMouseMoveTest()
        {
            var executed = false;
            var state = new MockState
            {
                mouseMove = delegate (Shapes shape, Point p)
                {
                    executed = true;
                }
            };
            _m.State = state;
            _model.DoMouseMove(new System.Windows.Forms.MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0));
            Assert.IsTrue(executed);
        }

        /* do mouse up */
        [TestMethod]
        public void DoMouseUpTest()
        {
            var executed = false;
            var state = new MockState
            {
                mouseUp = delegate (Shapes shape, Point p)
                {
                    executed = true;
                }
            };
            _m.State = state;
            _model.DoMouseUp(new System.Windows.Forms.MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0));
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
            _model.AddRandomShape(ShapeType.Rectangle, 800, 600);
            _model.SetState(new PointState());
            int x = _m.ShapeList[0].HitBox.X + _m.ShapeList[0].HitBox.Width / 2;
            int y = _m.ShapeList[0].HitBox.Y + _m.ShapeList[0].HitBox.Height / 2;
            _model.DoMouseDown(new System.Windows.Forms.MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, x, y, 0));
            _model.DoKeyDown(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Delete));
            Assert.AreEqual(0, _m.ShapeList.Count);
        }

        /* set state */
        [TestMethod]
        public void SetStateTest()
        {
            var state = new PointState();
            _model.SetState(state);
            Assert.AreEqual(state, _m.State);
            Assert.IsTrue(_m.ShapeList.Content.All((shape) => shape.Selected == false));
        }
    }
}