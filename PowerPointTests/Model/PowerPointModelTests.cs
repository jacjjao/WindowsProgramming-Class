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
    public class PowerPointModelTests
    {
        PowerPointModel _model;
        PrivateObject _modelPrivate;

        [TestInitialize()]
        public void Initialize()
        {
            _model = new PowerPointModel();
            _modelPrivate = new PrivateObject(_model);
        }

        [TestMethod()]
        public void DrawAllTest()
        {
            var list = (Shapes)_modelPrivate.GetFieldOrProperty("_list");
            int screenWidth = 800;
            int screenHeight = 600;
            list.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            list.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            list.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            list.AddRandomShape(ShapeType.Rectangle, screenWidth, screenHeight);
            int count = 0;
            var graphics = new PowerPointTests.MockGraphicsAdapter
            {
                drawRectangle = delegate (Point p1, Point p2)
                {
                    count++;
                }
            };
            _model.DrawAll(graphics);
            Assert.AreEqual(list.Count, count);
        }

        [TestMethod()]
        public void DoMouseDownTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DoMouseMoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DoMouseUpTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddRandomShapeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DoKeyDownTest()
        {
            Assert.Fail();
        }
    }
}