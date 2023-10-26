using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private List<ToolStripButton> _toolStripButtons = new List<ToolStripButton>();
        private readonly PresentationModel _presentModel;
        private DoubleBufferedPanel _drawPanel;
        private readonly BindingSource _bindingSource = new BindingSource();
        private FormGraphicsAdapter _graphics;

        public Form1(PresentationModel presentationModel)
        {
            InitializeComponent();
            _presentModel = presentationModel;
            _presentModel.Model.ShapesList.ListChanged += DoListChanged;
            _bindingSource.DataSource = _presentModel.Model.ShapesList;
            _dataGridView.DataSource = _bindingSource;
            _shapeComboBox.SelectedItem = _shapeComboBox.Items[0];
            CreateToolStripButtonList();
            CreateDrawPanel();
        }

        /* create toolstrip button list */
        private void CreateToolStripButtonList()
        {
            var lineButton = new ToolStripBindableButton
            {
                Text = "/"
            };
            lineButton.DataBindings.Add(new Binding("Checked", _presentModel.LineCheck, ".Value"));
            lineButton.Click += DoToolStripButtonLineClick;
            _toolStrip1.Items.Add(lineButton);
            _toolStripButtons.Add(lineButton);

            var RectangleButton = new ToolStripBindableButton
            { 
                Text = "[]"
            };
            RectangleButton.DataBindings.Add(new Binding("Checked", _presentModel.RectangleCheck, ".Value"));
            RectangleButton.Click += DoToolStripButtonRectangleClick;
            _toolStrip1.Items.Add(RectangleButton);
            _toolStripButtons.Add(RectangleButton);

            var CircleButton = new ToolStripBindableButton
            {
                Text = "O"
            };
            CircleButton.DataBindings.Add(new Binding("Checked", _presentModel.CircleCheck, ".Value"));
            CircleButton.Click += DoToolStripButtonCircleClick;
            _toolStrip1.Items.Add(CircleButton);
            _toolStripButtons.Add(CircleButton);

            var PointerButton = new ToolStripBindableButton
            {
                Text = "->"
            };
            PointerButton.DataBindings.Add(new Binding("Checked", _presentModel.PointerCheck, ".Value"));
            PointerButton.Click += DoToolStripButtonPointerClick;
            _toolStrip1.Items.Add(PointerButton);
            _toolStripButtons.Add(PointerButton);
        }

        /* create draw panel */
        private void CreateDrawPanel()
        {
            _drawPanel = new DoubleBufferedPanel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.White
            };
            _tableLayoutPanel1.Controls.Add(_drawPanel);
            _drawPanel.MouseUp += DoDrawPanelMouseUp;
            _drawPanel.MouseMove += DoDrawPanelMouseMove;
            _drawPanel.MouseDown += DoDrawPanelMouseDown;
            _drawPanel.Paint += DrawPanelOnDraw;
        }

        /* 有形狀變動時重畫 */
        private void DoListChanged(object sender, ListChangedEventArgs e)
        {
            _drawPanel.Invalidate();
            _slideButton1.Invalidate();
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
            _graphics = new FormGraphicsAdapter(e.Graphics);
            _graphics.DrawPen = _presentModel.GetDrawPen();
            _presentModel.DrawAll(_graphics);
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
                _presentModel.RemoveAt(e.RowIndex);
                _drawPanel.Invalidate();
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
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons.FindIndex((button) => button.Equals(sender)), ShapeType.Line);
            ChangeCursor(type);
        }

        /* '[]' button被點擊時的event */
        private void DoToolStripButtonRectangleClick(object sender, EventArgs e)
        {
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons.FindIndex((button) => button.Equals(sender)), ShapeType.Rectangle);
            ChangeCursor(type);
        }

        /* 'O' button被點擊時的event */
        private void DoToolStripButtonCircleClick(object sender, EventArgs e)
        {
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons.FindIndex((button) => button.Equals(sender)), ShapeType.Circle);
            ChangeCursor(type);
        }

        private void DoToolStripButtonPointerClick(object sender, EventArgs e)
        {
            _presentModel.DoToolStripButtonClick(_toolStripButtons.FindIndex((button) => button.Equals(sender)), ShapeType.None);
        }

        private void _slideButton1_Paint(object sender, PaintEventArgs e)
        {
            float scaleX = (float)_slideButton1.Width / (float)_drawPanel.Width;
            float scaleY = (float)_slideButton1.Height / (float)_drawPanel.Height;
            e.Graphics.ScaleTransform(scaleX, scaleY);
            _graphics = new FormGraphicsAdapter(e.Graphics);
            _graphics.DrawPen = _presentModel.GetDrawPen();
            _presentModel.DrawAll(_graphics);
        }
    }
}
