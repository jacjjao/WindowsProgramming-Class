using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Tests
{
    [TestClass]
    public class DoubleBufferedPanelTest
    {
        /* property and constructor */
        [TestMethod]
        public void BasicTest()
        {
            var panel = new DoubleBufferedPanel();
            var panelPrivate = new PrivateObject(panel);
            Assert.IsTrue((bool)panelPrivate.GetFieldOrProperty("ResizeRedraw"));
            Assert.IsTrue((bool)panelPrivate.GetFieldOrProperty("DoubleBuffered"));
        }
    }
}
