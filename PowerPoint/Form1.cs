using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private Dictionary<ToolStripButton, int> _toolStripButtons = new Dictionary<ToolStripButton, int>();
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
            CreateToolStripButtonListFirst();
            CreateToolStripButtonListSecond(); 
            CreateToolStripButtonListThird();
            CreateToolStripButtonListFourth();
            CreateDrawPanel();
            this.KeyPreview = true;
        }

        /* create toolstrip button list */
        private void CreateToolStripButtonListFirst()
        {
            const string SLASH = "/";
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            const int ZERO = 0;
            var lineButton = new BindableToolStripButton();
            lineButton.Text = SLASH;
            lineButton.DataBindings.Add(CHECKED, _presentModel.CheckList[ZERO], VALUE);
            lineButton.Click += DoToolStripButtonLineClick;
            _toolStrip1.Items.Add(lineButton);
            _toolStripButtons.Add(lineButton, ZERO);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListSecond()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            const string RECTANGLE = "[]";
            const int ONE = 1;
            var rectangleButton = new BindableToolStripButton();
            rectangleButton.Text = RECTANGLE;
            rectangleButton.DataBindings.Add(CHECKED, _presentModel.CheckList[ONE], VALUE);
            rectangleButton.Click += DoToolStripButtonRectangleClick;
            _toolStrip1.Items.Add(rectangleButton);
            _toolStripButtons.Add(rectangleButton, ONE);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListThird()
        {
            const string CIRCLE = "O";
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            const int TWO = 2;
            var circleButton = new BindableToolStripButton();
            // circleButton.Text = CIRCLE;
            circleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            circleButton.Image = (Image)Properties.Resources.ResourceManager.GetObject("Bitmap1");
            circleButton.DataBindings.Add(CHECKED, _presentModel.CheckList[TWO], VALUE);
            circleButton.Click += DoToolStripButtonCircleClick;
            _toolStrip1.Items.Add(circleButton);
            _toolStripButtons.Add(circleButton, TWO);
        }

        /* 分割出來的不然會太長 */
        private void CreateToolStripButtonListFourth()
        {
            const string CHECKED = "Checked";
            const string VALUE = ".Value";
            const string POINTER = "->";
            const int THREE = 3;
            var pointerButton = new BindableToolStripButton();
            pointerButton.Text = POINTER;
            pointerButton.DataBindings.Add(CHECKED, _presentModel.CheckList[THREE], VALUE);
            pointerButton.Click += DoToolStripButtonPointerClick;
            _toolStrip1.Items.Add(pointerButton);
            _toolStripButtons.Add(pointerButton, THREE);
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

        private void Redraw()
        {
            _drawPanel.Invalidate();
            _slideButton1.Invalidate();
        }

        /* 有形狀變動時重畫 */
        private void DoListChanged(object sender, ListChangedEventArgs e)
        {
            Redraw();
        }

        /* 在畫布上鬆開滑鼠按鍵時的event */
        private void DoDrawPanelMouseUp(object sender, MouseEventArgs e)
        {
            _presentModel.DoMouseUp(e);
            Redraw();
            Cursor = Cursors.Default;
        }

        /* 在畫布上移動滑鼠時的event */
        private void DoDrawPanelMouseMove(object sender, MouseEventArgs e)
        {
            _presentModel.DoMouseMove(e);
            Redraw();
        }

        /* 在畫布上點擊滑鼠時的event */
        private void DoDrawPanelMouseDown(object sender, MouseEventArgs e)
        {
            _presentModel.DoMouseDown(e);
            Redraw();
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
                Redraw();
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
            _presentModel.SetState(new DrawingState());
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.Line);
            ChangeCursor(type);
        }

        /* '[]' button被點擊時的event */
        private void DoToolStripButtonRectangleClick(object sender, EventArgs e)
        {
            _presentModel.SetState(new DrawingState());
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.Rectangle);
            ChangeCursor(type);
        }

        /* 'O' button被點擊時的event */
        private void DoToolStripButtonCircleClick(object sender, EventArgs e)
        {
            _presentModel.SetState(new DrawingState());
            ShapeType type = _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.Circle);
            ChangeCursor(type);
        }

        /* button pointer click */
        private void DoToolStripButtonPointerClick(object sender, EventArgs e)
        {
            _presentModel.SetState(new PointState());
            _presentModel.DoToolStripButtonClick(_toolStripButtons[(ToolStripButton)sender], ShapeType.None);
        }

        /* slide button1 paint */
        private void DoSlideButton1Paint(object sender, PaintEventArgs e)
        {
            float scaleX = (float)_slideButton1.Width / (float)_drawPanel.Width;
            float scaleY = (float)_slideButton1.Height / (float)_drawPanel.Height;
            e.Graphics.ScaleTransform(scaleX, scaleY);
            _graphics = new FormGraphicsAdapter(e.Graphics);
            _graphics.DrawPen = _presentModel.GetDrawPen();
            _presentModel.DrawAll(_graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _presentModel.DoKeyDown(e);
        }
    }
}
