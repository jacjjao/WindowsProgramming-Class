using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(new Point(), new Point());
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
    }

    [TestClass()]
    public class ShapeTests
    {
        MockShape _shape;

        [TestInitialize()]
        public void Initialize()
        {
            _shape = new MockShape();
        }

        [TestMethod()]
        public void InfoTest()
        {
            Assert.AreEqual("GetInfo", _shape.Info);
        }

        [TestMethod()]
        public void NameTest()
        {
            Assert.AreEqual("GetShapeName", _shape.Name);
        }

        [TestMethod()]
        public void SelectedTest()
        {
            Assert.IsFalse(_shape.Selected);
            _shape.Selected = true;
            Assert.IsTrue(_shape.Selected);
        }

        [TestMethod()]
        public void DrawShapeTest()
        {
            var graphics = new PowerPointTests.MockGraphicsAdapter();
            bool rectDraw = false;
            graphics.drawRectangle = delegate (Point p1, Point p2)
            {
                rectDraw = true;
            };
            _shape.DrawShape(graphics);
            Assert.IsTrue(rectDraw);
            rectDraw = false;
            bool hitboxDraw = false;
            graphics.drawHitBox = delegate (System.Drawing.Rectangle rectangle, float radius)
            {
                hitboxDraw = true;
            };
            _shape.Selected = true;
            _shape.DrawShape(graphics);
            Assert.IsTrue(rectDraw);
            Assert.IsTrue(hitboxDraw);
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            object obj = null;
            _shape.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(delegate (object sender, System.ComponentModel.PropertyChangedEventArgs args)
            {
                obj = sender;
            });
            _shape.NotifyPropertyChanged();
            Assert.AreEqual(_shape, obj);
        }
    }
}