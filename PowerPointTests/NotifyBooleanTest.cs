using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Tests
{
    [TestClass]
    public class NotifyBooleanTest
    {
        /* property and constructor */
        [TestMethod]
        public void BasicTest()
        {
            int count = 0;
            var b = new NotifyBoolean();
            b.Value = true;
            Assert.IsTrue(b.Value);
            Assert.AreEqual(0, count);

            b.PropertyChanged += delegate (object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                count++;
            };
            b.Value = false;
            Assert.IsFalse(b.Value);
            Assert.AreEqual(1, count);
        }
    }
}
