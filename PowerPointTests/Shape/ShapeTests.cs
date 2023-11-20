using PowerPoint;
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
            graphics.DrawRectangle(pen, new System.Drawing.Rectangle());
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
            _hitBox.X += differenceX;
            _hitBox.Y += differenceY;
        }

        /* resize */
        public override void Resize(Point pointFirst, Point pointSecond)
        {
            _hitBox.X = Math.Min(pointFirst.X, pointSecond.X);
            _hitBox.Y = Math.Min(pointFirst.Y, pointSecond.Y);
            _hitBox.Width = Math.Max(pointFirst.X, pointSecond.X) - _hitBox.X;
            _hitBox.Height = Math.Max(pointFirst.Y, pointSecond.Y) - _hitBox.Y;
        }
    }

    [TestClass()]
    public class ShapeTests
    {
        MockShape _shape;
        PrivateObject _shapePrivate;

        /* initialize */
        [TestInitialize]
        public void Initialize()
        {
            _shape = new MockShape();
            _shapePrivate = new PrivateObject(_shape);
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
            graphics.drawRectangle = delegate (System.Drawing.Rectangle rect)
            {
                rectDraw = true;
            };
            _shape.DrawShape(new Pen(Color.Red), graphics);
            Assert.IsTrue(rectDraw);
            rectDraw = false;
            bool hitboxDraw = false;
            graphics.drawEllipse = delegate (System.Drawing.Rectangle rect)
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

        /* is in hitbox */
        [TestMethod]
        public void IsInHitBoxTest()
        {
            var hitbox = new System.Drawing.Rectangle
            {
                X = 0,
                Y = 0,
                Width = 100,
                Height = 100
            };
            _shapePrivate.SetFieldOrProperty("_hitBox", hitbox);
            Assert.IsFalse(_shape.IsInHitBox(new Point(-1, 0)));
            Assert.IsFalse(_shape.IsInHitBox(new Point(100000, 0)));
            Assert.IsFalse(_shape.IsInHitBox(new Point(0, -1)));
            Assert.IsFalse(_shape.IsInHitBox(new Point(0, 100000)));
            Assert.IsTrue(_shape.IsInHitBox(new Point(50, 50)));
        }

        /* is in circle */
        [TestMethod]
        public void IsInCircleTest()
        {
            var hitbox = new System.Drawing.Rectangle
            {
                X = 0,
                Y = 0,
                Width = 100,
                Height = 100
            };
            _shapePrivate.SetFieldOrProperty("_hitBox", hitbox);
            Assert.IsTrue(_shape.IsInCircle(ResizeDirection.TopLeft, new Point(0, 0)));
            Assert.IsTrue(_shape.IsInCircle(ResizeDirection.TopMiddle, new Point(50, 0)));
            Assert.IsTrue(_shape.IsInCircle(ResizeDirection.TopRight, new Point(100, 0)));
            Assert.IsTrue(_shape.IsInCircle(ResizeDirection.MiddleLeft, new Point(0, 50)));
            Assert.IsTrue(_shape.IsInCircle(ResizeDirection.MiddleRight, new Point(100, 50)));
            Assert.IsTrue(_shape.IsInCircle(ResizeDirection.BottomLeft, new Point(0, 100)));
            Assert.IsTrue(_shape.IsInCircle(ResizeDirection.BottomMiddle, new Point(50, 100)));
            Assert.IsTrue(_shape.IsInCircle(ResizeDirection.BottomRight, new Point(100, 100)));

            Assert.IsFalse(_shape.IsInCircle(ResizeDirection.TopLeft, new Point(-100, -100)));
            Assert.IsFalse(_shape.IsInCircle(ResizeDirection.None, new Point(0, 0)));
        }

        /* get resize direction */
        [TestMethod]
        public void GetResizeDirectionTest()
        {
            var hitbox = new System.Drawing.Rectangle
            {
                X = 0,
                Y = 0,
                Width = 100,
                Height = 100
            };
            _shapePrivate.SetFieldOrProperty("_hitBox", hitbox);
            Assert.AreEqual(ResizeDirection.TopLeft, _shape.GetResizeDirection(new Point(0, 0)));
            Assert.AreEqual(ResizeDirection.TopMiddle, _shape.GetResizeDirection(new Point(50, 0)));
            Assert.AreEqual(ResizeDirection.TopRight,_shape.GetResizeDirection( new Point(100, 0)));
            Assert.AreEqual(ResizeDirection.MiddleLeft, _shape.GetResizeDirection(new Point(0, 50)));
            Assert.AreEqual(ResizeDirection.MiddleRight, _shape.GetResizeDirection(new Point(100, 50)));
            Assert.AreEqual(ResizeDirection.BottomLeft, _shape.GetResizeDirection(new Point(0, 100)));
            Assert.AreEqual(ResizeDirection.BottomMiddle, _shape.GetResizeDirection(new Point(50, 100)));
            Assert.AreEqual(ResizeDirection.BottomRight, _shape.GetResizeDirection(new Point(100, 100)));
            Assert.AreEqual(ResizeDirection.None, _shape.GetResizeDirection(new Point(-100, -100)));
        }

        /* resize based on direction */
        [TestMethod]
        public void ResizeBasedOnDirectionTest()
        {
            var hitbox = new System.Drawing.Rectangle
            {
                X = 0,
                Y = 0,
                Width = 100,
                Height = 100
            };
            var resetShape = new Action(() => _shapePrivate.SetFieldOrProperty("_hitBox", hitbox)); 
            int dx = 10, dy = -10;
            int bigdx = 10000, bigdy = 10000;
            
            // None
            resetShape.Invoke();
            var dir = _shape.ResizeBasedOnDirection(ResizeDirection.None, dx, dy);
            Assert.AreEqual(ResizeDirection.None, dir);
            Assert.AreEqual(hitbox.X + dx, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y + dy, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height, _shape.HitBox.Height);


            // TopLeft
            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.TopLeft, dx, dy);
            Assert.AreEqual(ResizeDirection.TopLeft, dir);
            Assert.AreEqual(hitbox.X + dx, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y + dy, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width - dx, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height - dy, _shape.HitBox.Height);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.TopLeft, bigdx, 0);
            Assert.AreEqual(ResizeDirection.TopRight, dir);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.TopLeft, 0, bigdy);
            Assert.AreEqual(ResizeDirection.BottomLeft, dir);

            

            // TopMiddle
            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.TopMiddle, dx, dy);
            Assert.AreEqual(ResizeDirection.TopMiddle, dir);
            Assert.AreEqual(hitbox.X, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y + dy, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height - dy, _shape.HitBox.Height);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.TopMiddle, 0, bigdy);
            Assert.AreEqual(ResizeDirection.BottomMiddle, dir);



            // TopRight
            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.TopRight, dx, dy);
            Assert.AreEqual(ResizeDirection.TopRight, dir);
            Assert.AreEqual(hitbox.X, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y + dy, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width + dx, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height - dy, _shape.HitBox.Height);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.TopRight, -bigdx, 0);
            Assert.AreEqual(ResizeDirection.TopLeft, dir);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.TopRight, 0, bigdy);
            Assert.AreEqual(ResizeDirection.BottomRight, dir);



            // MiddleLeft
            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, dx, dy);
            Assert.AreEqual(ResizeDirection.MiddleLeft, dir);
            Assert.AreEqual(hitbox.X + dx, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width - dx, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height, _shape.HitBox.Height);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, bigdx, 0);
            Assert.AreEqual(ResizeDirection.MiddleRight, dir);



            // MiddleRight
            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.MiddleRight, dx, dy);
            Assert.AreEqual(ResizeDirection.MiddleRight, dir);
            Assert.AreEqual(hitbox.X, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width + dx, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height, _shape.HitBox.Height);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.MiddleRight, -bigdx, 0);
            Assert.AreEqual(ResizeDirection.MiddleLeft, dir);



            // BottomLeft
            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.BottomLeft, dx, dy);
            Assert.AreEqual(ResizeDirection.BottomLeft, dir);
            Assert.AreEqual(hitbox.X + dx, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width - dx, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height + dy, _shape.HitBox.Height);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.BottomLeft, bigdx, 0);
            Assert.AreEqual(ResizeDirection.BottomRight, dir);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.BottomLeft, 0, -bigdy);
            Assert.AreEqual(ResizeDirection.TopLeft, dir);



            // BottomMiddle
            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, dx, dy);
            Assert.AreEqual(ResizeDirection.BottomMiddle, dir);
            Assert.AreEqual(hitbox.X, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height + dy, _shape.HitBox.Height);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, 0, -bigdy);
            Assert.AreEqual(ResizeDirection.TopMiddle, dir);



            // BottomRight
            resetShape.Invoke();
            _shape.ResizeBasedOnDirection(ResizeDirection.BottomRight, dx, dy);
            Assert.AreEqual(hitbox.X, _shape.HitBox.X);
            Assert.AreEqual(hitbox.Y, _shape.HitBox.Y);
            Assert.AreEqual(hitbox.Width + dx, _shape.HitBox.Width);
            Assert.AreEqual(hitbox.Height + dy, _shape.HitBox.Height);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.BottomRight, -bigdx, 0);
            Assert.AreEqual(ResizeDirection.BottomLeft, dir);

            resetShape.Invoke();
            dir = _shape.ResizeBasedOnDirection(ResizeDirection.BottomRight, 0, -bigdy);
            Assert.AreEqual(ResizeDirection.TopRight, dir);



            // invalid argument
            int invalid = -1;
            object thrown = null;
            try
            {
                _shape.ResizeBasedOnDirection((ResizeDirection)invalid, 0, 0);
            }  
            catch(Exception e)
            {
                thrown = e;
            }
            Assert.IsTrue(thrown is ArgumentException);
        }
    }
}