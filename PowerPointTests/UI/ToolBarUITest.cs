﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.IO;

namespace PowerPointUITests
{
    [TestClass]
    public class ToolBarUITest
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
        private void ToolStripLineButtonTest()
        {
            _robot.ClickButton(Form1.LINE_BUTTON_NAME);
            _robot.AssertToolStripButtonChecked(Form1.LINE_BUTTON_NAME);

            _robot.AssertToolStripButtonUnchecked(Form1.RECTANGLE_BUTTON_NAME);
            _robot.AssertToolStripButtonUnchecked(Form1.CIRCLE_BUTTON_NAME);
            _robot.AssertToolStripButtonUnchecked(Form1.POINTER_BUTTON_NAME);

            int x = 10, y = 10, width = 100, height = 50;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, width, height);
            var line = new Line(new System.Drawing.Point(x, y), new System.Drawing.Point(x + width, y + height));
            _robot.AssertDataGridViewShapeCells("_dataGridView", 0, line.GetShapeName());
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.GetInfo());
        }

        // test
        private void ToolStripRectangleButtonTest()
        {
            _robot.ClickButton(Form1.RECTANGLE_BUTTON_NAME);
            _robot.AssertToolStripButtonChecked(Form1.RECTANGLE_BUTTON_NAME);

            _robot.AssertToolStripButtonUnchecked(Form1.LINE_BUTTON_NAME);
            _robot.AssertToolStripButtonUnchecked(Form1.CIRCLE_BUTTON_NAME);
            _robot.AssertToolStripButtonUnchecked(Form1.POINTER_BUTTON_NAME);

            int x = 200, y = 200, width = 200, height = 250;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, width, height);
            var rect = new Rectangle(new System.Drawing.Point(x, y), new System.Drawing.Point(x + width, y + height));
            _robot.AssertDataGridViewShapeCells("_dataGridView", 1, rect.GetShapeName());
            _robot.AssertDataGridViewInfoCells("_dataGridView", 1, rect.GetInfo());
        }

        // test
        private void ToolStripCircleButtonTest()
        {
            _robot.ClickButton(Form1.CIRCLE_BUTTON_NAME);
            _robot.AssertToolStripButtonChecked(Form1.CIRCLE_BUTTON_NAME);

            _robot.AssertToolStripButtonUnchecked(Form1.LINE_BUTTON_NAME);
            _robot.AssertToolStripButtonUnchecked(Form1.RECTANGLE_BUTTON_NAME);
            _robot.AssertToolStripButtonUnchecked(Form1.POINTER_BUTTON_NAME);

            int x = 300, y = 300, width = 100, height = 100;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, width, height);
            var circle = new Circle(new System.Drawing.Point(x, y), new System.Drawing.Point(x + width, y + height));
            _robot.AssertDataGridViewShapeCells("_dataGridView", 2, circle.GetShapeName());
            _robot.AssertDataGridViewInfoCells("_dataGridView", 2, circle.GetInfo());
        }
        // test
        [TestMethod]
        public void ToolStripButtonsTest()
        {
            ToolStripLineButtonTest();
            ToolStripRectangleButtonTest();
            ToolStripCircleButtonTest();
        }
    }
}
