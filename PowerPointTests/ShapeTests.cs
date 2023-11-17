using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    class MockShape : Shape
    {
        /* draw */
        public override void Draw(IGraphics graphics)
        {
            throw new NotImplementedException();
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

        [TestProperty("MockShape", "Info")]
        public void InfoTest()
        {
            Assert.AreEqual("GetInfo", _shape.Info);
        }

        [TestProperty("MockShape", "Name")]
        public void NameTest()
        {
            Assert.AreEqual("GetShapeName", _shape.Info);
        }

        [TestProperty("MockShape", "Selected")]
        public void SelectedTest()
        {
            Assert.IsFalse(_shape.Selected);
            _shape.Selected = true;
            Assert.IsTrue(_shape.Selected);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DrawTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DrawShapeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            Assert.Fail();
        }
    }
}