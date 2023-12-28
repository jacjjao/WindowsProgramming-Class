using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.IO;
using System.Threading;

namespace PowerPointUITests
{
    [TestClass]
    public class SaveAndLoadUITest
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
        public void SaveAndLoadButtonTest()
        {
            _robot.ClickButton("ShapeSelector");
            _robot.ClickButton("圓");
            _robot.ClickButton("新增");
            _robot.KeyInputString("_topLeftX", "100");
            _robot.KeyInputString("_topLeftY", "100");
            _robot.KeyInputString("_bottomRightX", "400");
            _robot.KeyInputString("_bottomRightY", "400");
            _robot.ClickButton("OK");

            _robot.ClickButton("ToolStripFileSaveButton");
            _robot.ClickButton("Yes");
            _robot.AssertEnable("ToolStripFileSaveButton", false);
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _robot.ClickButton("OK");
            _robot.AssertEnable("ToolStripFileSaveButton", true);

            var circle = new Circle(new System.Drawing.Point(100, 100), new System.Drawing.Point(400, 400));
            _robot.ClickDataGridViewCellBy(0, "刪除 Row");
            
            _robot.ClickButton("ToolStripFileLoadButton");
            _robot.ClickButton("Yes");
            Thread.Sleep(TimeSpan.FromSeconds(12));
            _robot.ClickButton("OK");
            _robot.AssertEnable("ToolStripFileLoadButton", true);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            _robot.AssertDataGridViewShapeCells("_dataGridView", 0, circle.Name);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);
        }
    }
}
