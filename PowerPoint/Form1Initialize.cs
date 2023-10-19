using System.Collections.Generic;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        /* create components */
        private void CreateAndInitializeComponents()
        {
            CreateToolStripButtonList();
            CreateDrawPanel();
            HandleDrawPanelEvent();
        }

        /* create toolstrip button list */
        private void CreateToolStripButtonList()
        {
            _toolStripButtons = new List<ToolStripButton>();
            foreach (var item in _toolStrip1.Items)
            {
                if (item is ToolStripButton)
                {
                    var button = (ToolStripButton)item;
                    _toolStripButtons.Add(button);
                }
            }
        }

        /* create draw panel */
        private void CreateDrawPanel()
        {
            _drawPanel = new DoubleBufferedPanel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.White
            };
            _tableLayoutPanel1.Controls.Add(_drawPanel);
        }

        /* Handl draw panel 的 event */
        private void HandleDrawPanelEvent()
        {
            _drawPanel.MouseUp += DoDrawPanelMouseUp;
            _drawPanel.MouseMove += DoDrawPanelMouseMove;
            _drawPanel.MouseDown += DoDrawPanelMouseDown;
            _drawPanel.Paint += DrawPanelOnDraw;
        }
    }
}