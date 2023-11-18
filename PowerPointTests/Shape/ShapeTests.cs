using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PowerPoint.Tests
{
    class MockShape : Shape
    {
        /* contains */
        public override bool Contains(Point mousePosition)
        {
            throw new NotImplementedException();
        }

        /* draw */
        public override void Draw(Pen pen, IGraphics graphics)
        {
            graphics.DrawRectangle(pen, 0, 0, 0, 0);
        }

        /* get info */
        public override string GetInfo()
        {
            return "GetInfo";
        }

        /* get shape name */
        public override string GetShapeName()
        {
            return "GetShapeName";
        }

        /* move */
        public override void Move(int differenceX, int differenceY)
        {
            throw new NotImplementedException();
        }

        /* resize */
        public override void Resize(Point pointFirst, Point pointSecond)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass()]
    public class ShapeTests
    {
        MockShape _shape;

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _shape = new MockShape();
        }

        /* Info property */
        [TestMethod]
        public void InfoTest()
        {
            Assert.AreEqual("GetInfo", _shape.Info);
        }

        /* Name property */
        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual("GetShapeName", _shape.Name);
        }

        /* Selected property */
        [TestMethod]
        public void SelectedTest()
        {
            Assert.IsFalse(_shape.Selected);
            _shape.Selected = true;
            Assert.IsTrue(_shape.Selected);
        }

        /* draw shape */
        [TestMethod]
        public void DrawShapeTest()
        {
            var graphics = new PowerPointTests.MockGraphicsAdapter();
            bool rectDraw = false;
            graphics.drawRectangle = delegate (int x, int y, int width, int height)
            {
                rectDraw = true;
            };
            _shape.DrawShape(new Pen(Color.Red), graphics);
            Assert.IsTrue(rectDraw);
            rectDraw = false;
            bool hitboxDraw = false;
            graphics.drawEllipse = delegate (int x, int y, int width, int height)
            {
                hitboxDraw = true;
            };
            _shape.Selected = true;
            _shape.DrawShape(new Pen(Color.Red), graphics);
            Assert.IsTrue(rectDraw);
            Assert.IsTrue(hitboxDraw);
        }

        /* notify property changed */
        [TestMethod]
        public void NotifyPropertyChangedTest()
        {
            object obj = null;
            _shape.NotifyPropertyChanged();
            Assert.IsNull(obj);
            _shape.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(delegate (object sender, System.ComponentModel.PropertyChangedEventArgs args)
            {
                obj = sender;
            });
            _shape.NotifyPropertyChanged();
            Assert.AreEqual(_shape, obj);
        }
    }
}