using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        public const int LINE_BUTTON_INDEX = 0;
        public const int RECTANGLE_BUTTON_INDEX = 1;
        public const int CIRCLE_BUTTON_INDEX = 2;
        public const int POINTER_BUTTON_INDEX = 3;
        public const int UNDO_BUTTON_INDEX = 4;
        public const int REDO_BUTTON_INDEX = 5;
        public const int NEW_PAGE_BUTTON_INDEX = 6;
        readonly Dictionary<ToolStripButton, int> _toolStripButtons = new Dictionary<ToolStripButton, int>();
        readonly PresentationModel _presentModel;
        DoubleBufferedPanel _drawPanel;
        readonly BindingSource _bindingSource = new BindingSource();
        FormGraphicsAdapter _graphics;
        List<Button> _slideButtons = new List<Button>();
        MyFlowLayoutPanel _flowLayoutPanel = new MyFlowLayoutPanel();

        public static readonly string[] TOOLSTRIP_BUTTON_NAME =
        {
            "ToolStripLineButton",
            "ToolStripRectangleButton",
            "ToolStripCircleButton",
            "ToolStripPointerButton",
            "ToolStripUndoButton",
            "ToolStripRedoButton",
            "ToolStripNewPageButton",
        };

        public Form1(PresentationModel presentationModel)
        {
            InitializeComponent();
            _presentModel = presentationModel;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            CreateToolStripButtonListLine();
            CreateToolStripButtonListRectangle();
            CreateToolStripButtonListCircle();
            CreateToolStripButtonListPointer();
            CreateToolStripButtonListUndo();
            CreateToolStripButtonListRedo();
            CreateToolStripButtonNewPage();

            _presentModel.Model.PageManager.NewPageAdded += AddNewSlideButton;
            _presentModel.Model.AddBlankPage();

            CreateDrawPanel();
            KeyPreview = true;

            _flowLayoutPanel.Dock = DockStyle.Fill;
            _splitContainer1.Panel1.Controls.Add(_flowLayoutPanel);
        }

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
            lineButton.AccessibleName = TOOLSTRIP_BUTTON_NAME[LINE_BUTTON_INDEX];
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
            rectangleButton.AccessibleName = TOOLSTRIP_BUTTON_NAME[RECTANGLE_BUTTON_INDEX];
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
            circleButton.AccessibleName = TOOLSTRIP_BUTTON_NAME[CIRCLE_BUTTON_INDEX];
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
            pointerButton.AccessibleName = TOOLSTRIP_BUTTON_NAME[POINTER_BUTTON_INDEX];
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
            undoButton.AccessibleName = TOOLSTRIP_BUTTON_NAME[UNDO_BUTTON_INDEX];
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
            redoButton.AccessibleName = TOOLSTRIP_BUTTON_NAME[REDO_BUTTON_INDEX];
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
            newPageButton.AccessibleName = TOOLSTRIP_BUTTON_NAME[NEW_PAGE_BUTTON_INDEX];
            _toolStrip1.Items.Add(newPageButton);
            _toolStripButtons.Add(newPageButton, NEW_PAGE_BUTTON_INDEX);
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

        /* redraw panel and slide button */
        private void Draw()
        {
            _drawPanel.Invalidate();
            for (int i = 0; i < _slideButtons.Count; i++)
                _slideButtons[i].Invalidate();
        }

        /* 有形狀變動時重畫 */
        private void DoListChanged(object sender, ListChangedEventArgs e)
        {
            Draw();
        }

        /* 在畫布上點擊滑鼠時的event */
        private void DoDrawPanelMouseDown(object sender, MouseEventArgs e)
        {
            Cursor = _presentModel.DoMouseDown(e.Location);
            Draw();
        }

        /* 在畫布上移動滑鼠時的event */
        private void DoDrawPanelMouseMove(object sender, MouseEventArgs e)
        {
            Cursor = _presentModel.DoMouseMove(e.Location);
            Draw();
        }

        /* 在畫布上鬆開滑鼠按鍵時的event */
        private void DoDrawPanelMouseUp(object sender, MouseEventArgs e)
        {
            Cursor = _presentModel.DoMouseUp(e.Location);
            Draw();
            if (!(_presentModel.Model.State is PointState))
            {
                _toolStrip1.Items[POINTER_BUTTON_INDEX].PerformClick();
            }
        }

        /* 畫出所有的形狀 */
        private void DrawPanelOnDraw(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(_presentModel.DrawPanelScaleX, _presentModel.DrawPanelScaleY);
            _graphics = new FormGraphicsAdapter(e.Graphics);
            _presentModel.DrawAll(_graphics);
        }

        /* 處理"新增"按鈕被按的event */
        private void AddButtonClick(object sender, EventArgs e)
        {
            if (_shapeComboBox.SelectedIndex < 0)
                return;
            _presentModel.AddRandomShape((ShapeType)_shapeComboBox.SelectedIndex, _drawPanel.Width, _drawPanel.Height);
        }

        /* 處理DataGridView上的"刪除"按鈕被按的event */
        private void DoDataGridViewButtonCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _presentModel.RemoveAt(e.RowIndex);
                Draw();
            }
        }

        /* change cursor */
        private void ChangeCursor(ShapeType type)
        {
            Cursor = type == ShapeType.None ? Cursors.Default : Cursors.Cross;
        }

        /* '/' button被點擊時的event */
        private void DoToolStripButtonLineClick(object sender, EventArgs e)
        {
            var state = new DrawingState();
            state.Manager = _presentModel.Model.CommandManager;
            _presentModel.SetState(state);
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.Line);
            ChangeCursor(type);
        }

        /* '[]' button被點擊時的event */
        private void DoToolStripButtonRectangleClick(object sender, EventArgs e)
        {
            var state = new DrawingState();
            state.Manager = _presentModel.Model.CommandManager;
            _presentModel.SetState(state);
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.Rectangle);
            ChangeCursor(type);
        }

        /* 'O' button被點擊時的event */
        private void DoToolStripButtonCircleClick(object sender, EventArgs e)
        {
            var state = new DrawingState();
            state.Manager = _presentModel.Model.CommandManager;
            _presentModel.SetState(state);
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.Circle);
            ChangeCursor(type);
        }

        /* button pointer click */
        private void DoToolStripButtonPointerClick(object sender, EventArgs e)
        {
            var pointerButton = (ToolStripButton)sender;
            _presentModel.DoToolStripButtonClick(_toolStripButtons[pointerButton], ShapeType.None);
            if (pointerButton.Checked)
            {
                var state = new PointState();
                state.Manager = _presentModel.Model.CommandManager;
                _presentModel.SetState(state);
            }
            else
            {
                var state = new DrawingState();
                state.Manager = _presentModel.Model.CommandManager;
                _presentModel.SetState(state);
            }
        }

        /* button undo click */
        private void DoToolStripButtonUndoClick(object sender, EventArgs e)
        {
            _presentModel.Model.CommandManager.Undo();
            Draw();
        }

        /* button undo click */
        private void DoToolStripButtonRedoClick(object sender, EventArgs e)
        {
            _presentModel.Model.CommandManager.Redo();
            Draw();
        }
        
        /* new page click */
        private void DoToolStripButtonNewPageClick(object sender, EventArgs e)
        {
            _presentModel.Model.AddBlankPage();
            Draw();
        }

        /* add new slide button */
        private void AddNewSlideButton()
        {
            var slideButton = new Button();
            slideButton.Paint += DoSlideButtonPaint;
            _flowLayoutPanel.Controls.Add(slideButton);
            _slideButtons.Add(slideButton);

            _presentModel.Model.CurrentPage.Content.ListChanged += DoListChanged;
            _bindingSource.DataSource = _presentModel.Model.CurrentPage.Content;
            _dataGridView.DataSource = _bindingSource;

            _presentModel.Model.CommandManager.Page = _presentModel.Model.PageManager.CurrentPage;

            _flowLayoutPanel.OnResize();
        }

        /* slide button click */
        private void OnSlideButtonClick(object sender, EventArgs e)
        {

        }

        /* keydown */
        private void Form1KeyDown(object sender, KeyEventArgs e)
        {
            _presentModel.DoKeyDown(e);
        }

        /* slide button paint */
        private void DoSlideButtonPaint(object sender, PaintEventArgs e)
        {
            var button = (Button)sender;
            var adapter = new FormGraphicsAdapter(e.Graphics);
            float scaleX = (float)button.Width / (float)_drawPanel.Width;
            float scaleY = (float)button.Height / (float)_drawPanel.Height;
            scaleX *= _presentModel.DrawPanelScaleX;
            scaleY *= _presentModel.DrawPanelScaleY;
            e.Graphics.ScaleTransform(scaleX, scaleY);
            _presentModel.DrawAll(adapter);
        }

        /* resize */
        private void SplitContainer2Panel1Resize(object sender, EventArgs e)
        {
            if (_drawPanel == null)
                return;
            int layoutWidth = _splitContainer4.Panel1.Width;
            int layoutHeight = _splitContainer4.Panel1.Height;
            _presentModel.UpdateDrawPanelSizeAndPosition(_drawPanel, layoutWidth, layoutHeight);
        }

        /* resize */
        private void SplitContainer1Panel1Resize(object sender, EventArgs e)
        {
            const float TARGET_ASPECT_RATIO = 16.0f / 9.0f;
            for (int i = 0; i < _slideButtons.Count; i++)
            {
                _slideButtons[i].Width = _splitContainer1.Panel1.Width - _slideButtons[i].Margin.Horizontal;
                _slideButtons[i].Height = (int)((float)_slideButtons[i].Width / TARGET_ASPECT_RATIO);
            }
        }
    }
}
