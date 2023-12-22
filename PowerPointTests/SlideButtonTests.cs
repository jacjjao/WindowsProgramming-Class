using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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