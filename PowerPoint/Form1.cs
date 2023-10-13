using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private List<Tuple<ToolStripButton, ShapeType>> _toolButtonList;
        private readonly PresentationModel _presentModel;

        public Form1(PresentationModel model)
        {
            InitializeComponent();
            ResizeRedraw = true;
            DoubleBuffered = true;
            _presentModel = model;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            HandlePresentationModelEvent();
            CreateToolButtons();
            AssignDrawPanelEvent();
        }

        /* Handle presentation model 的 event */
        private void HandlePresentationModelEvent()
        {
            _presentModel._onNewShapeAdd += DoNewShapeAdd;
            _presentModel._shouldUpdateDataGrid += UpdateDataGrid;
        }

        /* 把button放到toolstrip上 */
        private void CreateToolButtons()
        {
            const string LINE = "/";
            const string RECTANGLE = "[]";
            const string CIRCLE = "O";
            var lineButton = new ToolStripButton();
            lineButton.Text = LINE;
            var rectangleButton = new ToolStripButton();
            rectangleButton.Text = RECTANGLE;
            var circleButton = new ToolStripButton();
            circleButton.Text = CIRCLE;
            _toolButtonList = new List<Tuple<ToolStripButton, ShapeType>>();
            _toolButtonList.Add(Tuple.Create(lineButton, ShapeType.Line));
            _toolButtonList.Add(Tuple.Create(rectangleButton, ShapeType.Rectangle));
            _toolButtonList.Add(Tuple.Create(circleButton, ShapeType.Circle));
            _toolButtonList.ForEach((tuple) => _toolStrip1.Items.Add(tuple.Item1));
        }

        /* Handl draw panel 的 event */
        private void AssignDrawPanelEvent()
        {
            _drawPanel.MouseUp += DoDrawPanelMouseUp;
            _drawPanel.MouseMove += DoDrawPanelMouseMove;
            _drawPanel.MouseDown += DoDrawPanelMouseDown;
            _drawPanel.Paint += DrawPanelOnDraw;
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
            _presentModel.DoMouseUp(e, _toolButtonList);
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
                DoShapeRemove(e.RowIndex);
            }
        }

        /* 刪掉shape所對應的row */
        private void DoShapeRemove(int index)
        {
            _dataGridView.Rows.RemoveAt(index);
            _drawPanel.Invalidate();
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

        /* toolstrip按鈕上的button被按到時的event */
        private void DoToolButtonClick(object sender, ToolStripItemClickedEventArgs e)
        {
            _presentModel.DoToolStripButtonClick(e.ClickedItem, _toolButtonList);
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
