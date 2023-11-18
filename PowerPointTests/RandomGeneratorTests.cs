using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Tests
{
    [TestClass]
    public class RandomGeneratorTests
    {
        /* constructor */
        [TestMethod]
        public void RandomGeneratorTest()
        {
            var random = new RandomGenerator();
            Assert.IsNotNull(random);
        }

        /* GetNext */
        [TestMethod]
        public void GetNextTest()
        {
            var generator = new RandomGenerator();
            int low = 10;
            int high = 11;
            int value = generator.GetNext(low, high);
            Assert.AreEqual(low, value);
        }
    }
}