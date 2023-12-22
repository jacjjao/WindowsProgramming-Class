using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class AddShapeMessageBox : Form
    {
        readonly DoubleBufferedPanel _panel = null;

        public AddShapeMessageBox(Form parent, DoubleBufferedPanel panel)
        {
            InitializeComponent();
            _panel = panel;
            ShowDialog(parent);
        }

        Point _pointFirst = new Point();
        public Point PointFirst
        {
            get
            {
                return _pointFirst;
            }
            set
            {
                _pointFirst = value;
            }
        }

        Point _pointSecond = new Point();
        public Point PointSecond
        {
            get
            {
                return _pointSecond;
            }
            set
            {
                _pointSecond = value;
            }
        }

        // get input
        private bool GetInput()
        {
            int leftY = 0;
            int rightX = 0;
            int rightY = 0;
            bool succeed =
                int.TryParse(_topLeftX.Text, out int leftX) &&
                int.TryParse(_topLeftY.Text, out leftY) &&
                int.TryParse(_bottomRightX.Text, out rightX) &&
                int.TryParse(_bottomRightY.Text, out rightY);
            if (!succeed)
                return false;
            _pointFirst.X = leftX;
            _pointFirst.Y = leftY;
            _pointSecond.X = rightX;
            _pointSecond.Y = rightY;
            return true;
        }

        // verify input
        private bool CheckInput()
        {
            Func<Point, bool> isOutOfBounds = (Point point) =>
            {
                return point.X < 0 || point.X > _panel.Width || point.Y < 0 || point.Y > _panel.Height;
            };
            return GetInput() && _pointFirst.X < _pointSecond.X && _pointFirst.Y < _pointSecond.Y && !isOutOfBounds(_pointFirst) && !isOutOfBounds(_pointSecond);
        }

        // ok button click
        private void DoOkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        // cancel button click
        private void DoCancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // text changed
        private void DoTopLeftLabelTextChanged(object sender, EventArgs e)
        {
            _okButton.Enabled = CheckInput();
        }

        // text changed
        private void DoTopRightLabelTextChanged(object sender, EventArgs e)
        {
            _okButton.Enabled = CheckInput();
        }

        // text changed
        private void DoBottomLeftLabelTextChanged(object sender, EventArgs e)
        {
            _okButton.Enabled = CheckInput();
        }

        // text changed
        private void DoBottomRightLabelTextChanged(object sender, EventArgs e)
        {
            _okButton.Enabled = CheckInput();
        }
    }
}
