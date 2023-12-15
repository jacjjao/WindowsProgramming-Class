using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using PowerPoint;
using System.Threading;
using System.Collections.Generic;

namespace PowerPointUITests
{
    [TestClass]
    public class UndoAndRedoUITest
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
        public void UndoAndRedoTest()
        {
            int shapeCount = 0;
            int offset = 50;
            var shape = new List<Shape>();
            for (int i = 0; i < 5; i++)
            {
                _robot.ClickButton(Form1.TOOLSTRIP_BUTTON_NAME[Form1.RECTANGLE_BUTTON_INDEX]);
                int x = offset * (i + 1), y = offset * (i + 1), width = offset, height = offset;
                _robot.DrawShape(x, y, width, height);
                shape.Add(new Rectangle(new System.Drawing.Point(x, y), new System.Drawing.Point(x + width, y + height)));
                shapeCount++;
            }
            int n = 3;

            for (int i = 0; i < n; i++)
                _robot.ClickButton(Form1.TOOLSTRIP_BUTTON_NAME[Form1.UNDO_BUTTON_INDEX]);
            _robot.AssertDataGridViewRowCountBy("_dataGridView", shapeCount - n);

            for (int i = 0; i < n; i++)
                _robot.ClickButton(Form1.TOOLSTRIP_BUTTON_NAME[Form1.REDO_BUTTON_INDEX]);
            _robot.AssertDataGridViewRowCountBy("_dataGridView", shapeCount);

            for (int i = 0; i < shapeCount; i++)
            {
                _robot.AssertDataGridViewShapeCells("_dataGridView", i, shape[i].Name);
                _robot.AssertDataGridViewInfoCells("_dataGridView", i, shape[i].Info);
            }
        }
    }
}
