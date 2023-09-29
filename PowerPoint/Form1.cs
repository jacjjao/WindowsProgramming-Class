using System;
using System.Windows.Forms;
using System.Linq;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private readonly Model _model;
        private readonly ShapesFactory _factory;

        public Form1()
        {
            InitializeComponent();
            _model = new Model();
            _factory = new ShapesFactory();
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
        }

        /* 處理"新增"按鈕被按的event */
        private void AddButtonClick(object sender, EventArgs e)
        {
            const int DELETE_COLUMN = 0;
            const int SHAPE_COLUMN = 1;
            const int INFO_COLUMN = 2;
            _model.AddShape(_factory.CreateShape(_shapeComboBox.SelectedIndex));
            var shape = _model.ShapesList.Last();
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
                _dataGridView.Rows.Remove(_dataGridView.Rows[e.RowIndex]);
            }
        }
    }
}
