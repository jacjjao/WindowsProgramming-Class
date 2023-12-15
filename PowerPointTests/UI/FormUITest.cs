using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using PowerPoint;
using System.Threading;
using System.Collections.Generic;

namespace PowerPointUITests
{
    [TestClass]
    public class FormUITest
    {
        Robot _robot;
        const string projectName = "PowerPoint";

        // test
        [TestInitialize]
        public void Initialize()
        {
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            string targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "PowerPoint.exe");
            _robot = new Robot(targetAppPath, projectName);
        }

        // test
        [TestCleanup]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // test
        [TestMethod]
        public void FormResizing()
        {
            Action<int, int> AssertAspectRatio = (int width, int height) =>
            {
                const float ASPECT_RATIO = 16.0f / 9.0f;
                float ratio = (float)width / (float)height;
                const float EPSILON = 0.05f;
                Assert.IsTrue(Math.Abs(ASPECT_RATIO - ratio) <= EPSILON);
            };

            _robot.MouseDownAndMoveThenUp("PowerPoint", 1, 1, 100, 100);
            _robot.Sleep(3);
            var size = _robot.GetElementSize("DrawPanel");
            AssertAspectRatio(size.Width, size.Height);

            size = _robot.GetElementSize("_slideButton1");
            AssertAspectRatio(size.Width, size.Height);
        }
    }
}
