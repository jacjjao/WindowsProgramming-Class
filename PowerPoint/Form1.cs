using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private List<ToolStripButton> _toolStripButtons;
        private readonly PresentationModel _presentModel;
        private DoubleBufferedPanel _drawPanel;

        public Form1(PresentationModel model)
        {
            InitializeComponent();
            _presentModel = model;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            CreateAndInitializeComponents();
        }

        /* 有形狀變動時需要更新data grid */
        private void UpdateDataGrid(int index, Shape shape)
        {
            const int SHAPE_COLUMN = 1;
            const int INFO_COLUMN = 2;
            var row = _dataGridView.Rows[index];
            row.Cells[SHAPE_COLUMN].Value = shape.GetShapeName();
            row.Cells[INFO_COLUMN].Value = shape.GetInfo();
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
            _presentModel.AddShape((ShapeType)_shapeComboBox.SelectedIndex);
        }

        /* 處理DataGridView上的"刪除"按鈕被按的event */
        private void DoDataGridViewButtonCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _presentModel.RemoveShape(e.RowIndex);
                _dataGridView.Rows.RemoveAt(e.RowIndex);
                _drawPanel.Invalidate();
            }
        }

        /* 處理有新的形狀加入時的event */
        private void DoNewShapeAdd(object sender, Shape shape)
        {
            const int DELETE_COLUMN = 0;
            int rowIndex = _dataGridView.Rows.Add();
            var row = _dataGridView.Rows[rowIndex];
            row.Cells[DELETE_COLUMN].Value = new DataGridViewButtonCell();
            UpdateDataGrid(rowIndex, shape);
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

        /* '/' button被點擊時的event */
        private void DoToolStripButtonLineClick(object sender, EventArgs e)
        {
            _presentModel.DoToolStripButtonClick(sender, _toolStripButtons, ShapeType.Line);
            ChangeCursor();
        }

        /* '[]' button被點擊時的event */
        private void DoToolStripButtonRectangleClick(object sender, EventArgs e)
        {
            _presentModel.DoToolStripButtonClick(sender, _toolStripButtons, ShapeType.Rectangle);
            ChangeCursor();
        }

        /* 'O' button被點擊時的event */
        private void DoToolStripButtonCircleClick(object sender, EventArgs e)
        {
            _presentModel.DoToolStripButtonClick(sender, _toolStripButtons, ShapeType.Circle);
            ChangeCursor();
        }
    }
}
