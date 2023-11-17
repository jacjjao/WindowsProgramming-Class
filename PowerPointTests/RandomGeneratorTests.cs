using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class RandomGeneratorTests
    {
        [TestMethod()]
        public void RandomGeneratorTest()
        {
            var random = new RandomGenerator();
            Assert.IsNotNull(random);
        }

        [TestMethod()]
        public void NextTest()
        {
            var generator = new RandomGenerator();
            int low = 10;
            int high = 11;
            int value = generator.Next(low, high);
            Assert.AreEqual(low, value);
        }
    }
}