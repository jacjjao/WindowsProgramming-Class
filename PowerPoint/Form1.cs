using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        public const int TOOL_STRIP_BUTTON_COUNT = 3;
        private List<ToolStripButton> _toolStripButtons;
        private readonly PresentationModel _presentModel;
        private DoubleBufferedPanel _drawPanel;

        public Form1(PresentationModel presentationModel)
        {
            InitializeComponent();
            _presentModel = presentationModel;
            _presentModel.Model.ShapesList.ListChanged += new ListChangedEventHandler(UpdateDataGrid);
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            CreateAndInitializeComponents();
        }

        /* 有形狀變動時需要更新data grid */
        private void UpdateDataGrid(object sender, ListChangedEventArgs e)
        {
            if (_presentModel.Model.ShapesList.Count < _dataGridView.Rows.Count)
            {
                _dataGridView.Rows.RemoveAt(e.NewIndex);
                return;
            }
            const int DELETE_COLUMN = 0;
            const int SHAPE_COLUMN = 1;
            const int INFO_COLUMN = 2;
            if (_presentModel.Model.ShapesList.Count > _dataGridView.Rows.Count)
            {
                int rowIndex = _dataGridView.Rows.Add();
                _dataGridView.Rows[rowIndex].Cells[DELETE_COLUMN].Value = new DataGridViewButtonCell();
            }
            var row = _dataGridView.Rows[e.NewIndex];
            row.Cells[SHAPE_COLUMN].Value = _presentModel.Model.ShapesList[e.NewIndex].GetShapeName();
            row.Cells[INFO_COLUMN].Value = _presentModel.Model.ShapesList[e.NewIndex].GetInfo();
            _drawPanel.Invalidate();
        }

        /* 在畫布上鬆開滑鼠按鍵時的event */
        private void DoDrawPanelMouseUp(object sender, MouseEventArgs e)
        {
            _presentModel.DoMouseUp(e, _toolStripButtons);
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
                _presentModel.Model.ShapesList.RemoveAt(e.RowIndex);
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
