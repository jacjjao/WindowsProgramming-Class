﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        const int LINE_BUTTON_INDEX = 0;
        const int RECTANGLE_BUTTON_INDEX = 1;
        const int CIRCLE_BUTTON_INDEX = 2;
        const int POINTER_BUTTON_INDEX = 3;
        const int UNDO_BUTTON_INDEX = 4;
        const int REDO_BUTTON_INDEX = 5;
        readonly Dictionary<ToolStripButton, int> _toolStripButtons = new Dictionary<ToolStripButton, int>();
        readonly PresentationModel _presentModel;
        DoubleBufferedPanel _drawPanel;
        readonly BindingSource _bindingSource = new BindingSource();
        FormGraphicsAdapter _graphics;

        bool _sizeAssign = false;

        public Form1(PresentationModel presentationModel)
        {
            InitializeComponent();
            _presentModel = presentationModel;
            _presentModel.Model.ShapeList.Content.ListChanged += DoListChanged;
            _bindingSource.DataSource = _presentModel.Model.ShapeList.Content;
            _dataGridView.DataSource = _bindingSource;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            CreateToolStripButtonListLine();
            CreateToolStripButtonListRectangle();
            CreateToolStripButtonListCircle();
            CreateToolStripButtonListPointer();
            CreateToolStripButtonListUndo();
            CreateToolStripButtonListRedo();
            CreateDrawPanel();
            KeyPreview = true;
            OnResize(EventArgs.Empty);
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
            _toolStrip1.Items.Add(pointerButton);
            _toolStripButtons.Add(pointerButton, POINTER_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListUndo()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            var undoButton = new BindToolStripButton();
            undoButton.Text = "<-";
            undoButton.DataBindings.Add(CHECKED, _presentModel.CheckList[UNDO_BUTTON_INDEX], VALUE);
            undoButton.Click += DoToolStripButtonUndoClick;
            _toolStrip1.Items.Add(undoButton);
            _toolStripButtons.Add(undoButton, UNDO_BUTTON_INDEX);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListRedo()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            var redoButton = new BindToolStripButton();
            redoButton.Text = "->";
            redoButton.DataBindings.Add(CHECKED, _presentModel.CheckList[REDO_BUTTON_INDEX], VALUE);
            redoButton.Click += DoToolStripButtonRedoClick;
            _toolStrip1.Items.Add(redoButton);
            _toolStripButtons.Add(redoButton, REDO_BUTTON_INDEX);
        }

        /* create draw panel */
        private void CreateDrawPanel()
        {
            _drawPanel = new DoubleBufferedPanel
            {
                Dock = DockStyle.None,
                BackColor = Color.White
            };
            splitContainer2.Panel1.Controls.Add(_drawPanel);
            _drawPanel.MouseUp += DoDrawPanelMouseUp;
            _drawPanel.MouseMove += DoDrawPanelMouseMove;
            _drawPanel.MouseDown += DoDrawPanelMouseDown;
            _drawPanel.Paint += DrawPanelOnDraw;
        }

        /* redraw panel and slide button */
        private void Draw()
        {
            _drawPanel.Invalidate();
            _slideButton1.Invalidate();
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
            _presentModel.AddRandomShape((ShapeType)_shapeComboBox.SelectedIndex, (int)(_drawPanel.Width / _presentModel.DrawPanelScaleX), (int)(_drawPanel.Height / _presentModel.DrawPanelScaleY));
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
            _presentModel.SetState(new DrawingState { Manager = _presentModel.Model.Manager });
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.Line);
            ChangeCursor(type);
        }

        /* '[]' button被點擊時的event */
        private void DoToolStripButtonRectangleClick(object sender, EventArgs e)
        {
            _presentModel.SetState(new DrawingState { Manager = _presentModel.Model.Manager });
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.Rectangle);
            ChangeCursor(type);
        }

        /* 'O' button被點擊時的event */
        private void DoToolStripButtonCircleClick(object sender, EventArgs e)
        {
            _presentModel.SetState(new DrawingState { Manager = _presentModel.Model.Manager });
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
                _presentModel.SetState(new PointState { Manager = _presentModel.Model.Manager });
            }
            else
            {
                _presentModel.SetState(new DrawingState { Manager = _presentModel.Model.Manager });
            }
        }

        /* button undo click */
        private void DoToolStripButtonUndoClick(object sender, EventArgs e)
        {
            _presentModel.Model.Manager.Undo();
            Draw();
        }

        /* button undo click */
        private void DoToolStripButtonRedoClick(object sender, EventArgs e)
        {
            _presentModel.Model.Manager.Redo();
            Draw();
        }

        /* keydown */
        private void Form1KeyDown(object sender, KeyEventArgs e)
        {
            _presentModel.DoKeyDown(e);
        }

        /* slide button paint */
        private void DoSlideButtonPaint(object sender, PaintEventArgs e)
        {
            var adapter = new FormGraphicsAdapter(e.Graphics);
            float scaleX = (float)_slideButton1.Width / (float)_drawPanel.Width;
            float scaleY = (float)_slideButton1.Height / (float)_drawPanel.Height;
            scaleX *= _presentModel.DrawPanelScaleX;
            scaleY *= _presentModel.DrawPanelScaleY;
            e.Graphics.ScaleTransform(scaleX, scaleY);
            _presentModel.DrawAll(adapter);
        }

        private void SlideButtonResize(object sender, EventArgs e)
        {
            const float TARGET_ASPECT_RATIO = 16.0f / 9.0f;
            _slideButton1.Height = (int)((float)_slideButton1.Width / TARGET_ASPECT_RATIO);
        }

        private void SplitContainer2Panel1Resize(object sender, EventArgs e)
        {
            if (_drawPanel == null)
                return;

            Point size = _presentModel.UpdateDrawPanelSize(splitContainer2.Panel1.Width, splitContainer2.Panel1.Height);
            _drawPanel.Width = size.X;
            _drawPanel.Height = size.Y;

            _drawPanel.Location = _presentModel.UpdateDrawPanelLocation(splitContainer2.Panel1.Width, splitContainer2.Panel1.Height, size.X, size.Y);

            if (!_sizeAssign)
            {
                _presentModel.InitDrawPanelWidth = _drawPanel.Width;
                _presentModel.InitDrawPanelHeight = _drawPanel.Height;
                _sizeAssign = true;
            }
            else
            {
                _presentModel.CurrentDrawPanelWidth = _drawPanel.Width;
                _presentModel.CurrentDrawPanelHeight = _drawPanel.Height;
            }

            Shape.ScaleX = _presentModel.DrawPanelScaleX;
            Shape.ScaleY = _presentModel.DrawPanelScaleY;
        }
    }
}
