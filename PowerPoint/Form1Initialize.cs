using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        /* create components */
        private void CreateComponents()
        {
            HandlePresentationModelEvent();
            CreateToolButtons();
            AssignDrawPanelEvent();
        }

        /* Handle presentation model 的 event */
        private void HandlePresentationModelEvent()
        {
            _presentModel._onNewShapeAdd += DoNewShapeAdd;
            _presentModel._shouldUpdateDataGrid += UpdateDataGrid;
        }

        /* 把button放到toolstrip上 */
        private void CreateToolButtons()
        {
            const string LINE = "/";
            const string RECTANGLE = "[]";
            const string CIRCLE = "O";
            var lineButton = new ToolStripButton();
            lineButton.Text = LINE;
            var rectangleButton = new ToolStripButton();
            rectangleButton.Text = RECTANGLE;
            var circleButton = new ToolStripButton();
            circleButton.Text = CIRCLE;
            _toolButtonList = new List<Tuple<ToolStripButton, ShapeType>>();
            _toolButtonList.Add(Tuple.Create(lineButton, ShapeType.Line));
            _toolButtonList.Add(Tuple.Create(rectangleButton, ShapeType.Rectangle));
            _toolButtonList.Add(Tuple.Create(circleButton, ShapeType.Circle));
            _toolButtonList.ForEach((tuple) => _toolStrip1.Items.Add(tuple.Item1));
        }

        /* Handl draw panel 的 event */
        private void AssignDrawPanelEvent()
        {
            _drawPanel.MouseUp += DoDrawPanelMouseUp;
            _drawPanel.MouseMove += DoDrawPanelMouseMove;
            _drawPanel.MouseDown += DoDrawPanelMouseDown;
            _drawPanel.Paint += DrawPanelOnDraw;
        }
    }
}