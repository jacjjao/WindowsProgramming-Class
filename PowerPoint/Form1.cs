using System;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private readonly PresentationModel _presentModel;
        private TransparentPanel _drawPanel;

        public Form1(PresentationModel model)
        {
            InitializeComponent();
            _presentModel = model;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            CreateDrawPanel();
        }

        /* create draw panel */
        private void CreateDrawPanel()
        {
            _drawPanel = new TransparentPanel
            {
                Dock = DockStyle.Fill
            };
            _drawPanel.MouseEnter += new EventHandler(this.OnMouseEnter);
            _drawPanel.MouseLeave += new EventHandler(this.OnMouseLeave);
            _drawPanel.Paint += new PaintEventHandler(this.OnDrawPanelPaint);
            _drawPanel.MouseUp += new MouseEventHandler(this.OnMouseUp);
            _drawPanel.MouseDown += new MouseEventHandler(this.OnMouseDown);
            _tableLayoutPanel1.Controls.Add(_drawPanel);
        }

        /* 處理"新增"按鈕被按的event */
        private void AddButtonClick(object sender, EventArgs e)
        {
            const int DELETE_COLUMN = 0;
            const int SHAPE_COLUMN = 1;
            const int INFO_COLUMN = 2;
            if (_shapeComboBox.SelectedIndex < 0)
                return;
            var shape = _presentModel.TheModel.AddShapes(_shapeComboBox.SelectedIndex);
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
                _presentModel.TheModel.ShapesList.RemoveAt(e.RowIndex);
            }
        }

        private void UncheckedAllToolStripButton()
        {
            _toolStripLineButton.Checked = false;
            _toolStripRectangleButton.Checked = false;
            _toolStripCircleButton.Checked = false;
        }

        private void _toolStripLineButton_Click(object sender, EventArgs e)
        {
            UncheckedAllToolStripButton();
            _toolStripLineButton.Checked = true;
            _presentModel.SelectedShapeType = PresentationModel.ShapeType.Line;
        }

        private void _toolStripRectangleButton_Click(object sender, EventArgs e)
        {
            UncheckedAllToolStripButton();
            _toolStripRectangleButton.Checked = true;
            _presentModel.SelectedShapeType = PresentationModel.ShapeType.Rectangle;
        }

        private void _toolStripCircleButton_Click(object sender, EventArgs e)
        {
            UncheckedAllToolStripButton();
            _toolStripCircleButton.Checked = true;
            _presentModel.SelectedShapeType = PresentationModel.ShapeType.Circle;
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (_presentModel.SelectedShapeType != PresentationModel.ShapeType.None)
            {
                Cursor = Cursors.Cross;
            }
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void OnDrawPanelPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.FillRectangle(Brushes.Black, 0, 0, 1000, 1000);
        }
    }
}
