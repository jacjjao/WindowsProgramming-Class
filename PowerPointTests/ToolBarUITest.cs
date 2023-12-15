using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace PowerPointUITests
{
    [TestClass]
    public class ToolBarUITest
    {
        Robot _robot;
        const string projectName = "PowerPoint";

        [TestInitialize]
        public void Initialize()
        {
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            string targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "PowerPoint.exe");
            _robot = new Robot(targetAppPath, projectName);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _robot.ClickButton("ToolStripLineButton");
            _robot.AssertToolStripButtonChecked("ToolStripLineButton");
            _robot.ClickButton("ToolStripRectangleButton");
            _robot.AssertToolStripButtonChecked("ToolStripRectangleButton");
        }
    }
}
