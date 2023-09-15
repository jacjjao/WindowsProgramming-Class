using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW1
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
            _result = "";
            _calculator = new Calculator();
            _dot = false;
        }

        private Calculator _calculator;
        private string _result;
        private bool _dot;

        private void ButtonCEClick(object sender, EventArgs e)
        {
            textBox.Text = _result;
            _dot = !double.TryParse(_result, out _);
        }

        private void ButtonCClick(object sender, EventArgs e)
        {
            textBox.Text = _result = "";
            _dot = false;
        }

        private void Button9Click(object sender, EventArgs e)
        {
            textBox.Text += button9.Text;
        }

        private void Button8Click(object sender, EventArgs e)
        {
            textBox.Text += button8.Text;
        }

        private void Button7Click(object sender, EventArgs e)
        {
            textBox.Text += button7.Text;
        }

        private void Button6Click(object sender, EventArgs e)
        {
            textBox.Text += button6.Text;
        }

        private void Button5Click(object sender, EventArgs e)
        {
            textBox.Text += button5.Text;
        }

        private void Button4Click(object sender, EventArgs e)
        {
            textBox.Text += button4.Text;
        }

        private void Button3Click(object sender, EventArgs e)
        {
            textBox.Text += button3.Text;
        }

        private void Button2Click(object sender, EventArgs e)
        {
            textBox.Text += button2.Text;
        }

        private void Button1Click(object sender, EventArgs e)
        {
            textBox.Text += button1.Text;
        }

        private void Button0Click(object sender, EventArgs e)
        {
            textBox.Text += button0.Text;
        }

        private void ButtonPlusClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1]))
            {
                textBox.Text += buttonPlus.Text;
                _dot = false;
            }
        }

        private void ButtonMinusClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1]))
            {
                textBox.Text += buttonMinus.Text;
                _dot = false;
            }
        }

        private void ButtonMulClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1]))
            {
                textBox.Text += buttonMul.Text;
                _dot = false;
            }
        }

        private void ButtonDivClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1]))
            {
                textBox.Text += buttonDiv.Text;
                _dot = false;
            }
        }

        private void ButtonDotClick(object sender, EventArgs e)
        {
            bool canInsert =
                !_dot &&
                !String.IsNullOrEmpty(textBox.Text) &&
                 Char.IsNumber(textBox.Text[textBox.Text.Length - 1]);
            if (canInsert)
            {
                textBox.Text += buttonDot.Text;
                _dot = true;
            }
        }

        private void ButtonEqualClick(object sender, EventArgs e)
        {
            const char mulOperator = '*';
            string result = _calculator.Calculate(textBox.Text.Replace(buttonMul.Text[0], mulOperator));
            if (!String.IsNullOrEmpty(result))
            {
                _result = textBox.Text = result;
            }
        }
    }
}
