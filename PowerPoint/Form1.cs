using System;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private List<Tuple<ToolStripButton, ShapeType>> _toolButtonList;
        private readonly PresentationModel _presentModel;
        private Graphics _graphics;

        public Form1(PresentationModel model)
        {
            InitializeComponent();
            ResizeRedraw = true;
            DoubleBuffered = true;
            _presentModel = model;
            _presentModel.OnNewShapeAdd += OnNewShapeAdd;
            _presentModel.OnShapeRemove += OnShapeRemove;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            CreateToolButtons();
            AssignDrawPanelEvent();
        }

        private void CreateToolButtons()
        {
            _toolButtonList = new List<Tuple<ToolStripButton, ShapeType>>();
            _toolButtonList.Add(Tuple.Create(new ToolStripButton { Text = "/" }, ShapeType.Line));
            _toolButtonList.Add(Tuple.Create(new ToolStripButton { Text = "[]" }, ShapeType.Rectangle));
            _toolButtonList.Add(Tuple.Create(new ToolStripButton { Text = "O" }, ShapeType.Circle));
            _toolButtonList.ForEach((tuple) => toolStrip1.Items.Add(tuple.Item1));
        }

        /* create draw panel */
        private void AssignDrawPanelEvent()
        {
            _drawPanel.MouseUp += OnMouseUp;
            _drawPanel.MouseMove += OnMouseMove;
            _drawPanel.MouseDown += OnMouseDown;
            _graphics = _drawPanel.CreateGraphics();
        }

        /* 處理"新增"按鈕被按的event */
        private void AddButtonClick(object sender, EventArgs e)
        {
            if (_shapeComboBox.SelectedIndex < 0)
                return;
            var shape = _presentModel.AddShape((ShapeType)_shapeComboBox.SelectedIndex);
        }

        private void AddShapeToDataGrid(Shape shape)
        {
            const int DELETE_COLUMN = 0;
            const int SHAPE_COLUMN = 1;
            const int INFO_COLUMN = 2;
            int rowIndex = _dataGridView.Rows.Add();
            var row = _dataGridView.Rows[rowIndex];
            row.Cells[DELETE_COLUMN].Value = new DataGridViewButtonCell();
            row.Cells[SHAPE_COLUMN].Value = shape.GetShapeName();
            row.Cells[INFO_COLUMN].Value = shape.GetInfo();
        }

        /* 處理DataGridView上的"刪除"按鈕被按的event */
        private void OnDataGridViewButtonCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _presentModel.RemoveShape(e.RowIndex);
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _presentModel.OnMouseUp(e.Location);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            _presentModel.OnMouseMove(e.Location);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            _presentModel.OnMouseDown(e.Location);
        }

        private void OnNewShapeAdd(object sender, Shape shape)
        {
            AddShapeToDataGrid(shape);
            shape.Draw(_graphics, _presentModel.DrawPen);
        }

        private void OnShapeRemove(object sender, int index)
        {
            _dataGridView.Rows.RemoveAt(index);
            _graphics.Clear(_drawPanel.BackColor);
            _presentModel.DrawAll(_graphics);
        }

        private void OnToolButtonClick(object sender, ToolStripItemClickedEventArgs e)
        {
            _presentModel.OnToolStripButtonClick(e.ClickedItem, _toolButtonList);
            if (_presentModel.SelectedShapeType != ShapeType.None)
            {
                Cursor = Cursors.Cross;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
