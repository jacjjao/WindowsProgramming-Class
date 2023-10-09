using System;
using System.Windows.Forms;
using System.Linq;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private readonly Model _model;

        public Form1(Model model)
        {
            InitializeComponent();
            _model = model;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
        }

        /* 處理"新增"按鈕被按的event */
        private void AddButtonClick(object sender, EventArgs e)
        {
            const int DELETE_COLUMN = 0;
            const int SHAPE_COLUMN = 1;
            const int INFO_COLUMN = 2;
            if (_shapeComboBox.SelectedIndex < 0)
                return;
            var shape = _model.AddShapes(_shapeComboBox.SelectedIndex);
            int rowIndex = _dataGridView.Rows.Add();
            var row = _dataGridView.Rows[rowIndex];
            row.Cells[DELETE_COLUMN].Value = new DataGridViewButtonCell();
            row.Cells[SHAPE_COLUMN].Value = shape.GetShapeName();
            row.Cells[INFO_COLUMN].Value = shape.GetInfo();
        }

        /* 處理DataGridView上的"刪除"按鈕被按的event */
        private void DoDataGridViewButtonCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _dataGridView.Rows.RemoveAt(e.RowIndex);
                _model.ShapesList.RemoveAt(e.RowIndex);
            }
        }
    }
}
