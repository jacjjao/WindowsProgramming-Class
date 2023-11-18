using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace PowerPoint.Tests
{
    [TestClass]
    public class BindableToolStripButtonTest
    {
        /* constructor and property */
        [TestMethod]
        public void BasicTest()
        {
            var button = new BindableToolStripButton();
            Assert.IsNotNull(button.DataBindings);
            var context = new BindingContext();
            button.BindingContext = context;
            Assert.AreEqual(context, button.BindingContext);
        }
    }
}
