using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        /* create toolstrip button list */
        private void CreateToolStripButtonListLine()
        {
            const string SLASH = "/";
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            var lineButton = new BindToolStripButton();
            lineButton.Text = SLASH;
            lineButton.DataBindings.Add(CHECKED, _presentModel.CheckList[LINE_BUTTON_INDEX], VALUE);
            lineButton.Click += DoToolStripButtonLineClick;
            lineButton.AccessibleName = LINE_BUTTON_NAME;
            _toolStrip1.Items.Add(lineButton);
            _toolStripButtons.Add(lineButton, LINE_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListRectangle()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            var rectangleButton = new BindToolStripButton();
            rectangleButton.Image = Properties.Resources.Rectangle;
            rectangleButton.DataBindings.Add(CHECKED, _presentModel.CheckList[RECTANGLE_BUTTON_INDEX], VALUE);
            rectangleButton.Click += DoToolStripButtonRectangleClick;
            rectangleButton.AccessibleName = RECTANGLE_BUTTON_NAME;
            _toolStrip1.Items.Add(rectangleButton);
            _toolStripButtons.Add(rectangleButton, RECTANGLE_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListCircle()
        {
            const string CIRCLE = "O";
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            var circleButton = new BindToolStripButton();
            circleButton.Text = CIRCLE;
            circleButton.DataBindings.Add(CHECKED, _presentModel.CheckList[CIRCLE_BUTTON_INDEX], VALUE);
            circleButton.Click += DoToolStripButtonCircleClick;
            circleButton.AccessibleName = CIRCLE_BUTTON_NAME;
            _toolStrip1.Items.Add(circleButton);
            _toolStripButtons.Add(circleButton, CIRCLE_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListPointer()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            var pointerButton = new BindToolStripButton();
            pointerButton.Image = Properties.Resources.Pointer;
            pointerButton.DataBindings.Add(CHECKED, _presentModel.CheckList[POINTER_BUTTON_INDEX], VALUE);
            pointerButton.Click += DoToolStripButtonPointerClick;
            pointerButton.Checked = true;
            pointerButton.AccessibleName = POINTER_BUTTON_NAME;
            _toolStrip1.Items.Add(pointerButton);
            _toolStripButtons.Add(pointerButton, POINTER_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListUndo()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            const string TEXT = "<-";
            var undoButton = new BindToolStripButton();
            undoButton.Text = TEXT;
            undoButton.DataBindings.Add(CHECKED, _presentModel.CheckList[UNDO_BUTTON_INDEX], VALUE);
            undoButton.Click += DoToolStripButtonUndoClick;
            undoButton.AccessibleName = UNDO_BUTTON_NAME;
            _toolStrip1.Items.Add(undoButton);
            _toolStripButtons.Add(undoButton, UNDO_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListRedo()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            const string TEXT = "->";
            var redoButton = new BindToolStripButton();
            redoButton.Text = TEXT;
            redoButton.DataBindings.Add(CHECKED, _presentModel.CheckList[REDO_BUTTON_INDEX], VALUE);
            redoButton.Click += DoToolStripButtonRedoClick;
            redoButton.AccessibleName = REDO_BUTTON_NAME;
            _toolStrip1.Items.Add(redoButton);
            _toolStripButtons.Add(redoButton, REDO_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonNewPage()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            var newPageButton = new BindToolStripButton();
            newPageButton.Image = Properties.Resources.NewPage;
            newPageButton.DataBindings.Add(CHECKED, _presentModel.CheckList[NEW_PAGE_BUTTON_INDEX], VALUE);
            newPageButton.Click += DoToolStripButtonNewPageClick;
            newPageButton.AccessibleName = NEW_PAGE_BUTTON_NAME;
            _toolStrip1.Items.Add(newPageButton);
            _toolStripButtons.Add(newPageButton, NEW_PAGE_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonDeletePage()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            var newPageButton = new BindToolStripButton();
            newPageButton.Image = Properties.Resources.DeletePage;
            newPageButton.DataBindings.Add(CHECKED, _presentModel.CheckList[DELETE_PAGE_BUTTON_INDEX], VALUE);
            newPageButton.Click += RemoveCheckedSlide;
            newPageButton.AccessibleName = DELETE_PAGE_BUTTON_NAME;
            _toolStrip1.Items.Add(newPageButton);
            _toolStripButtons.Add(newPageButton, DELETE_PAGE_BUTTON_INDEX);
        }

        /* create draw panel */
        private void CreateDrawPanel()
        {
            const string NAME = "DrawPanel";
            _drawPanel = new DoubleBufferedPanel
            {
                Dock = DockStyle.None,
                BackColor = Color.White,
                AccessibleName = NAME
            };
            _splitContainer4.Panel1.Controls.Add(_drawPanel);
            _drawPanel.MouseUp += DoDrawPanelMouseUp;
            _drawPanel.MouseMove += DoDrawPanelMouseMove;
            _drawPanel.MouseDown += DoDrawPanelMouseDown;
            _drawPanel.Paint += DrawPanelOnDraw;
        }
    }
}
