using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.IO;

namespace PowerPointUITests
{
    [TestClass]
    public class AddShapeUITest
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
        public void AddShapeTest()
        {
            _robot.ClickButton("新增");
            _robot.KeyInputString("_topLeftX", "100");
            _robot.KeyInputString("_topLeftY", "100");
            _robot.KeyInputString("_bottomRightX", "400");
            _robot.KeyInputString("_bottomRightY", "400");
            _robot.ClickButton("OK");

            _robot.ClickButton("ShapeSelector");
            _robot.ClickButton("圓");
            _robot.ClickButton("新增");
            _robot.KeyInputString("_topLeftX", "100");
            _robot.KeyInputString("_topLeftY", "100");
            _robot.KeyInputString("_bottomRightX", "400");
            _robot.KeyInputString("_bottomRightY", "400");
            _robot.ClickButton("OK");

            _robot.ClickButton("ShapeSelector");
            _robot.ClickButton("線");
            _robot.ClickButton("新增");
            _robot.KeyInputString("_topLeftX", "100");
            _robot.KeyInputString("_topLeftY", "100");
            _robot.KeyInputString("_bottomRightX", "400");
            _robot.KeyInputString("_bottomRightY", "400");
            _robot.ClickButton("OK");


            var p1 = new System.Drawing.Point(100, 100);
            var p2 = new System.Drawing.Point(400, 400);
            var rect = new Rectangle(p1, p2);
            var circle = new Circle(p1, p2);
            var line = new Line(p1, p2);
            _robot.AssertDataGridViewShapeCells("_dataGridView", 0, rect.Name);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);
            _robot.AssertDataGridViewShapeCells("_dataGridView", 1, circle.Name);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 1, circle.Info);
            _robot.AssertDataGridViewShapeCells("_dataGridView", 2, line.Name);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 2, line.Info);


            _robot.AssertDataGridViewRowCountBy("_dataGridView", 3);

            _robot.ClickDataGridViewCellBy(2, "刪除 Row");
            _robot.AssertDataGridViewRowCountBy("_dataGridView", 2);

            _robot.ClickDataGridViewCellBy(1, "刪除 Row");
            _robot.AssertDataGridViewRowCountBy("_dataGridView", 1);

            _robot.ClickDataGridViewCellBy(0, "刪除 Row");
            _robot.AssertDataGridViewRowCountBy("_dataGridView", 0);
        }
    }
}
