﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private List<ToolStripButton> _toolStripButtons;
        private readonly PresentationModel _presentModel;
        private DoubleBufferedPanel _drawPanel;
        private readonly BindingSource _bindingSource = new BindingSource();

        public Form1(PresentationModel presentationModel)
        {
            InitializeComponent();
            _presentModel = presentationModel;
            _presentModel._checkListChanged += DoCheckListChanged;
            _presentModel.Model.ShapesList.ListChanged += UpdateDrawPanel;
            _bindingSource.DataSource = _presentModel.Model.ShapesList;
            _dataGridView.DataSource = _bindingSource;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            CreateAndInitializeComponents();
        }

        /* on check list changed */
        private void DoCheckListChanged()
        {
            for (int i = 0; i < _toolStripButtons.Count; i++)
            {
                _toolStripButtons[i].Checked = _presentModel.CheckList[i];
            }
        }

        /* 有形狀變動時重畫 */
        private void UpdateDrawPanel(object sender, ListChangedEventArgs e)
        {
            _drawPanel.Invalidate();
        }

        /* 在畫布上鬆開滑鼠按鍵時的event */
        private void DoDrawPanelMouseUp(object sender, MouseEventArgs e)
        {
            _presentModel.DoMouseUp(e);
            Cursor = Cursors.Default;
        }

        /* 在畫布上移動滑鼠時的event */
        private void DoDrawPanelMouseMove(object sender, MouseEventArgs e)
        {
            _presentModel.DoMouseMove(e);
        }

        /* 在畫布上點擊滑鼠時的event */
        private void DoDrawPanelMouseDown(object sender, MouseEventArgs e)
        {
            _presentModel.DoMouseDown(e);
        }

        /* 畫出所有的形狀 */
        private void DrawPanelOnDraw(object sender, PaintEventArgs e)
        {
            _presentModel.DrawAll(e.Graphics);
        }

        /* 處理"新增"按鈕被按的event */
        private void AddButtonClick(object sender, EventArgs e)
        {
            if (_shapeComboBox.SelectedIndex < 0)
                return;
            _presentModel.Model.AddShape((ShapeType)_shapeComboBox.SelectedIndex);
        }

        /* 處理DataGridView上的"刪除"按鈕被按的event */
        private void DoDataGridViewButtonCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _presentModel.Model.RemoveAt(e.RowIndex);
                _drawPanel.Invalidate();
            }
        }

        /* change cursor */
        private void ChangeCursor()
        {
            if (_presentModel.SelectedShapeType != ShapeType.None)
            {
                Cursor = Cursors.Cross;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        /* 更新toolstrip button的Check屬性 */
        private void RefreshModelCheckList()
        {
            for (int i = 0; i < _toolStripButtons.Count; i++)
            {
                _toolStripButtons[i].Checked = _presentModel.CheckList[i];
            }
        }

        /* '/' button被點擊時的event */
        private void DoToolStripButtonLineClick(object sender, EventArgs e)
        {
            _presentModel.DoToolStripButtonClick(_toolStripButtons.FindIndex((button) => button.Equals(sender)), ShapeType.Line);
            RefreshModelCheckList();
            ChangeCursor();
        }

        /* '[]' button被點擊時的event */
        private void DoToolStripButtonRectangleClick(object sender, EventArgs e)
        {
            _presentModel.DoToolStripButtonClick(_toolStripButtons.FindIndex((button) => button.Equals(sender)), ShapeType.Rectangle);
            RefreshModelCheckList();
            ChangeCursor();
        }

        /* 'O' button被點擊時的event */
        private void DoToolStripButtonCircleClick(object sender, EventArgs e)
        {
            _presentModel.DoToolStripButtonClick(_toolStripButtons.FindIndex((button) => button.Equals(sender)), ShapeType.Circle);
            RefreshModelCheckList();
            ChangeCursor();
        }
    }
}
