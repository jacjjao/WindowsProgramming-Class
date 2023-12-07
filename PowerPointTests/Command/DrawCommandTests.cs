using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using PowerPointTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;

namespace PowerPoint.Tests
{
    [TestClass]
    public class DrawCommandTests
    {
        [TestMethod]
        public void PropertyTest()
        {
            var pen = new Pen(Color.Black);
            var g = new MockGraphicsAdapter();
            var clearColor = Color.Red;
            var cmd = new DrawCommand
            {
                Graphics = g,
                DrawPen = pen,
                ClearColor = clearColor
            };
            Assert.AreEqual(g, cmd.Graphics);
            Assert.AreEqual(pen, cmd.DrawPen);
            Assert.AreEqual(clearColor, cmd.ClearColor);
        }

        [TestMethod]
        public void UnexecuteTest()
        {
            Color clearColor = Color.Red;
            bool executed = false;
            var g = new MockGraphicsAdapter
            {
                clearAll = (Color color) =>
                {
                    executed = true;
                    Assert.AreEqual(clearColor, color);
                }
            };
            var cmd = new DrawCommand
            {
                Graphics = g,
                ClearColor = clearColor
            };
            cmd.Unexecute(null);
            Assert.IsTrue(executed);
        }
    }
}