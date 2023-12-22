using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Tests
{
    [TestClass]
    public class SlideButtonTests
    {
        // test
        [TestMethod]
        public void SlideButtonTest()
        {
            var button = new SlideButton();
            var obj = new PrivateObject(button);
            Assert.IsFalse((bool)obj.GetFieldOrProperty("ShowFocusCues"));
        }
    }
}