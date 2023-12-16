using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.IO;

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
        public void UndoAndRedoDataGridViewTest()
        {
            int shapeCount = 0;
            int offset = 50;
            var shape = new List<Shape>();
            for (int i = 0; i < 5; i++)
            {
                _robot.ClickButton(Form1.RECTANGLE_BUTTON_NAME);
                int x = offset * (i + 1), y = offset * (i + 1), width = offset, height = offset;
                _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, width, height);
                shape.Add(new Rectangle(new System.Drawing.Point(x, y), new System.Drawing.Point(x + width, y + height)));
                shapeCount++;
            }
            int n = 3;

            for (int i = 0; i < n; i++)
                _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            _robot.AssertDataGridViewRowCountBy("_dataGridView", shapeCount - n);
            for (int i = 0; i < shapeCount - n; i++)
            {
                _robot.AssertDataGridViewShapeCells("_dataGridView", i, shape[i].Name);
                _robot.AssertDataGridViewInfoCells("_dataGridView", i, shape[i].Info);
            }

            for (int i = 0; i < n; i++)
                _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            _robot.AssertDataGridViewRowCountBy("_dataGridView", shapeCount);
            for (int i = 0; i < shapeCount; i++)
            {
                _robot.AssertDataGridViewShapeCells("_dataGridView", i, shape[i].Name);
                _robot.AssertDataGridViewInfoCells("_dataGridView", i, shape[i].Info);
            }
        }

        // test
        [TestMethod]
        public void ResizingAndMovingRectangleTest()
        {
            int x = 100, y = 100, width = 200, height = 100;
            var rect = new Rectangle(new System.Drawing.Point(x, y), new System.Drawing.Point(x + width, y + height));
            _robot.ClickButton(Form1.RECTANGLE_BUTTON_NAME);
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, width, height);
            _robot.Click(x + width / 2, y + height / 2);
            int dx = 50, dy = 50;


            // move
            _robot.MouseDownAndMoveThenUp("DrawPanel", x + width / 2, y + height / 2, dx, dy);
            rect.Move(dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.Move(-dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.Move(dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.Move(-dx, -dy);


            // top left
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            rect.ResizeBasedOnDirection(ResizeDirection.TopLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopLeft, -dx, -dy);


            // top middle
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            rect.ResizeBasedOnDirection(ResizeDirection.TopMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopMiddle, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopMiddle, -dx, -dy);


            // top right
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            rect.ResizeBasedOnDirection(ResizeDirection.TopRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.TopRight, -dx, -dy);


            // middle left
            x -= width;
            y += height / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            rect.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, -dx, -dy);


            // middle right
            x += width;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            rect.ResizeBasedOnDirection(ResizeDirection.MiddleRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.MiddleRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.MiddleRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.MiddleRight, -dx, -dy);


            // bottom left
            x -= width;
            y += height / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomLeft, -dx, -dy);


            // bottom middle
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, -dx, -dy);


            // bottom right
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, rect.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            rect.ResizeBasedOnDirection(ResizeDirection.BottomRight, -dx, -dy);
        }

        // test
        [TestMethod]
        public void ResizingAndMovingLineTest()
        {
            int x = 100, y = 100, width = 200, height = 100;
            var line = new Line(new System.Drawing.Point(x, y), new System.Drawing.Point(x + width, y + height));
            _robot.ClickButton(Form1.LINE_BUTTON_NAME);
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, width, height);
            _robot.Click(x + width / 2, y + height / 2);
            int dx = 50, dy = 50;


            // move
            _robot.MouseDownAndMoveThenUp("DrawPanel", x + width / 2, y + height / 2, dx, dy);
            line.Move(dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.Move(-dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.Move(dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.Move(-dx, -dy);


            // top left
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            line.ResizeBasedOnDirection(ResizeDirection.TopLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopLeft, -dx, -dy);


            // top middle
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            line.ResizeBasedOnDirection(ResizeDirection.TopMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopMiddle, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopMiddle, -dx, -dy);


            // top right
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            line.ResizeBasedOnDirection(ResizeDirection.TopRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.TopRight, -dx, -dy);


            // middle left
            x -= width;
            y += height / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            line.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, -dx, -dy);


            // middle right
            x += width;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            line.ResizeBasedOnDirection(ResizeDirection.MiddleRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.MiddleRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.MiddleRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.MiddleRight, -dx, -dy);


            // bottom left
            x -= width;
            y += height / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            line.ResizeBasedOnDirection(ResizeDirection.BottomLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomLeft, -dx, -dy);


            // bottom middle
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            line.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, -dx, -dy);


            // bottom right
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            line.ResizeBasedOnDirection(ResizeDirection.BottomRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, line.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            line.ResizeBasedOnDirection(ResizeDirection.BottomRight, -dx, -dy);
        }

        // test
        [TestMethod]
        public void ResizingAndMovingCircleTest()
        {
            int x = 100, y = 100, width = 200, height = 100;
            var circle = new Circle(new System.Drawing.Point(x, y), new System.Drawing.Point(x + width, y + height));
            _robot.ClickButton(Form1.CIRCLE_BUTTON_NAME);
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, width, height);
            _robot.Click(x + width / 2, y + height / 2);
            int dx = 50, dy = 50;


            // move
            _robot.MouseDownAndMoveThenUp("DrawPanel", x + width / 2, y + height / 2, dx, dy);
            circle.Move(dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.Move(-dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.Move(dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.Move(-dx, -dy);


            // top left
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            circle.ResizeBasedOnDirection(ResizeDirection.TopLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopLeft, -dx, -dy);


            // top middle
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            circle.ResizeBasedOnDirection(ResizeDirection.TopMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopMiddle, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopMiddle, -dx, -dy);


            // top right
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            circle.ResizeBasedOnDirection(ResizeDirection.TopRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.TopRight, -dx, -dy);


            // middle left
            x -= width;
            y += height / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            circle.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.MiddleLeft, -dx, -dy);


            // middle right
            x += width;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            circle.ResizeBasedOnDirection(ResizeDirection.MiddleRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.MiddleRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.MiddleRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.MiddleRight, -dx, -dy);


            // bottom left
            x -= width;
            y += height / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomLeft, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomLeft, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomLeft, -dx, -dy);


            // bottom middle
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomMiddle, -dx, -dy);


            // bottom right
            x += width / 2;
            _robot.MouseDownAndMoveThenUp("DrawPanel", x, y, dx, dy);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomRight, -dx, -dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.REDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomRight, dx, dy);
            _robot.AssertDataGridViewInfoCells("_dataGridView", 0, circle.Info);

            _robot.ClickButton(Form1.UNDO_BUTTON_NAME);
            circle.ResizeBasedOnDirection(ResizeDirection.BottomRight, -dx, -dy);
        }
    }
}
