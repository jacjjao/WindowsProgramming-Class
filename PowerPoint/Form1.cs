﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
        const int NEW_PAGE_BUTTON_INDEX = 6;
        const int DELETE_PAGE_BUTTON_INDEX = 7;
        readonly Dictionary<ToolStripButton, int> _toolStripButtons = new Dictionary<ToolStripButton, int>();
        readonly PresentationModel _presentModel;
        DoubleBufferedPanel _drawPanel;
        readonly BindingSource _bindingSource = new BindingSource();
        FormGraphicsAdapter _graphics;
        List<CheckBox> _slideButtons = new List<CheckBox>();
        MyFlowLayoutPanel _flowLayoutPanel = new MyFlowLayoutPanel();

        public const string LINE_BUTTON_NAME = "ToolStripLineButton";
        public const string RECTANGLE_BUTTON_NAME = "ToolStripRectangleButton";
        public const string CIRCLE_BUTTON_NAME = "ToolStripCircleButton";
        public const string POINTER_BUTTON_NAME = "ToolStripPointerButton";
        public const string UNDO_BUTTON_NAME = "ToolStripUndoButton";
        public const string REDO_BUTTON_NAME = "ToolStripRedoButton";
        public const string NEW_PAGE_BUTTON_NAME = "ToolStripNewPageButton";
        public const string DELETE_PAGE_BUTTON_NAME = "ToolStripDeletePageButton";

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
            CreateToolStripButtonDeletePage();
            _presentModel.Model.PageManager._newPageAdded += AddNewSlideButton;
            _presentModel.Model.PageManager._pageRemoved += RemoveSlideButton;
            _presentModel.Model.PageManager._currentPageChanged += BindDataGridViewToCurrentPage;
            _presentModel.Model.AddBlankPage();
            CreateDrawPanel();
            KeyPreview = true;
            _flowLayoutPanel.Dock = DockStyle.Fill;
            _flowLayoutPanel.SizeChanged += ResizeSlideButtons;
            _splitContainer1.Panel1.Controls.Add(_flowLayoutPanel);
        }

        // draw all
        private void DrawAll()
        {
            _drawPanel.Invalidate();
            for (int i = 0; i < _slideButtons.Count; i++)
                _slideButtons[i].Invalidate();
        }

        /* redraw panel and slide button */
        private void DrawPartial()
        {
            _drawPanel.Invalidate();
            int index = _presentModel.Model.PageManager.GetCurrentPageIndex();
            _slideButtons[index].Invalidate();
        }

        /* 有形狀變動時重畫 */
        private void DoListChanged(object sender, ListChangedEventArgs e)
        {
            DrawPartial();
        }

        /* 在畫布上點擊滑鼠時的event */
        private void DoDrawPanelMouseDown(object sender, MouseEventArgs e)
        {
            Cursor = _presentModel.DoMouseDown(e.Location);
            DrawPartial();
        }

        /* 在畫布上移動滑鼠時的event */
        private void DoDrawPanelMouseMove(object sender, MouseEventArgs e)
        {
            Cursor = _presentModel.DoMouseMove(e.Location);
            DrawPartial();
        }

        /* 在畫布上鬆開滑鼠按鍵時的event */
        private void DoDrawPanelMouseUp(object sender, MouseEventArgs e)
        {
            Cursor = _presentModel.DoMouseUp(e.Location);
            DrawPartial();
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
            _presentModel.Model.DrawCurrentPage(_graphics);
        }

        /* 處理"新增"按鈕被按的event */
        private void AddButtonClick(object sender, EventArgs e)
        {
            var box = new AddShapeMessageBox(this, _drawPanel);
            if (_shapeComboBox.SelectedIndex < 0 || box.DialogResult != DialogResult.OK)
                return;
            _presentModel.Model.AddShape((ShapeType)_shapeComboBox.SelectedIndex, box.PointFirst, box.PointSecond);
        }

        /* 處理DataGridView上的"刪除"按鈕被按的event */
        private void DoDataGridViewButtonCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _presentModel.RemoveAt(e.RowIndex);
                DrawPartial();
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
            DrawAll();
            UpdateSlideButtonCheckedAndName();
        }

        /* button undo click */
        private void DoToolStripButtonRedoClick(object sender, EventArgs e)
        {
            _presentModel.Model.CommandManager.Redo();
            DrawAll();
            UpdateSlideButtonCheckedAndName();
        }

        /* new page click */
        private void DoToolStripButtonNewPageClick(object sender, EventArgs e)
        {
            var command = new AddPageCommand();
            command.AddIndex = _slideButtons.FindIndex((button) => button.Checked) + 1;
            command.Manager = _presentModel.Model.PageManager;
            _presentModel.Model.CommandManager.Execute(command);
            DrawAll();
        }

        // rebind databinding
        private void BindDataGridViewToCurrentPage()
        {
            _presentModel.Model.CurrentPage.Content.ListChanged += DoListChanged;
            _bindingSource.DataSource = _presentModel.Model.CurrentPage.Content;
            _dataGridView.DataSource = _bindingSource;
        }

        // check button
        private void UpdateSlideButtonCheckedAndName()
        {
            for (int i = 0; i < _slideButtons.Count; i++)
                _slideButtons[i].Checked = false;
            _slideButtons[_presentModel.Model.PageManager.GetCurrentPageIndex()].Checked = true;
            const string NAME = "SlideButton{0}";
            for (int i = 0; i < _slideButtons.Count; i++)
                _slideButtons[i].AccessibleName = string.Format(NAME, i);
        }

        /* add new slide button */
        private void AddNewSlideButton()
        {
            var slideButton = new SlideButton();
            slideButton.Paint += DoSlideButtonPaint;
            slideButton.Click += DoSlideButtonClick;
            _flowLayoutPanel.Controls.Add(slideButton);
            _slideButtons.Add(slideButton);
            UpdateSlideButtonCheckedAndName();
            _flowLayoutPanel.DoSizeChanged();
        }

        // remove slide
        private void RemoveCheckedSlide(object sender, EventArgs e)
        {
            int index = _slideButtons.FindIndex((button) => button.Checked);
            var command = new RemovePageCommand();
            command.Manager = _presentModel.Model.PageManager;
            command.RemoveIndex = index;
            _presentModel.Model.CommandManager.Execute(command);
            if (index > 0)
                index--;
            UpdateSlideButtonCheckedAndName();
            DrawAll();
        }

        // remove Index
        private void RemoveSlideButton(int index)
        {
            _slideButtons.Remove(_slideButtons.Last());
            _flowLayoutPanel.Controls.RemoveAt(_flowLayoutPanel.Controls.Count - 1);
        }

        /* slide button click */
        private void DoSlideButtonClick(object sender, EventArgs e)
        {
            int index = _slideButtons.FindIndex((button) => button.Equals(sender));
            _presentModel.Model.SetCurrentPage(index);
            UpdateSlideButtonCheckedAndName();
            DrawPartial();
        }

        /* keydown */
        private void Form1KeyDown(object sender, KeyEventArgs e)
        {
            _presentModel.DoKeyDown(e);
        }

        /* slide button paint */
        private void DoSlideButtonPaint(object sender, PaintEventArgs e)
        {
            var button = (CheckBox)sender;
            var adapter = new FormGraphicsAdapter(e.Graphics);
            float scaleX = (float)button.Width / (float)_drawPanel.Width;
            float scaleY = (float)button.Height / (float)_drawPanel.Height;
            scaleX *= _presentModel.DrawPanelScaleX;
            scaleY *= _presentModel.DrawPanelScaleY;
            e.Graphics.ScaleTransform(scaleX, scaleY);
            _presentModel.Model.DrawPage(_slideButtons.FindIndex((slideButton) => slideButton.Equals(button)), adapter);
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
        private void ResizeSlideButtons(object sender, EventArgs e)
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
