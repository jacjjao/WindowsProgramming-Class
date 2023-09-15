using System;
using System.Windows.Forms;

namespace HW1 {
    public partial class AppForm : Form {
        public AppForm() {
            InitializeComponent();
            _result = "";
            _calculator = new Calculator();
            _dot = false;
        }

        private Calculator _calculator;
        private string _result;
        private bool _dot;

        /* 處理button CE被點擊時的event */
        private void ButtonCEClick(object sender, EventArgs e) {
            textBox.Text = _result;
            _dot = !double.TryParse(_result, out _);
        }

        /* 處理button C被點擊時的event */
        private void ButtonCClick(object sender, EventArgs e) {
            textBox.Text = _result = "";
            _dot = false;
        }

        /* 處理button 9被點擊時的event */
        private void Button9Click(object sender, EventArgs e) {
            textBox.Text += button9.Text;
        }

        /* 處理button 8被點擊時的event */
        private void Button8Click(object sender, EventArgs e) {
            textBox.Text += button8.Text;
        }

        /* 處理button 7被點擊時的event */
        private void Button7Click(object sender, EventArgs e) {
            textBox.Text += button7.Text;
        }

        /* 處理button 6被點擊時的event */
        private void Button6Click(object sender, EventArgs e) {
            textBox.Text += button6.Text;
        }

        /* 處理button 5被點擊時的event */
        private void Button5Click(object sender, EventArgs e) {
            textBox.Text += button5.Text;
        }

        /* 處理button 4被點擊時的event */
        private void Button4Click(object sender, EventArgs e) {
            textBox.Text += button4.Text;
        }

        /* 處理button 3被點擊時的event */
        private void Button3Click(object sender, EventArgs e) {
            textBox.Text += button3.Text;
        }

        /* 處理button 2被點擊時的event */
        private void Button2Click(object sender, EventArgs e) {
            textBox.Text += button2.Text;
        }

        /* 處理button 1被點擊時的event */
        private void Button1Click(object sender, EventArgs e) {
            textBox.Text += button1.Text;
        }

        /* 處理button 0被點擊時的event */
        private void Button0Click(object sender, EventArgs e) {
            textBox.Text += button0.Text;
        }

        /* 處理button plus被點擊時的event */
        private void ButtonPlusClick(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1])) {
                textBox.Text += buttonPlus.Text;
                _dot = false;
            }
        }

        /* 處理button minus被點擊時的event */
        private void ButtonSubClick(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1])) {
                textBox.Text += buttonSub.Text;
                _dot = false;
            }
        }

        /* 處理button multiply被點擊時的event */
        private void ButtonMulClick(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1])) {
                textBox.Text += buttonMul.Text;
                _dot = false;
            }
        }

        /* 處理button divide被點擊時的event */
        private void ButtonDivClick(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1])) {
                textBox.Text += buttonDiv.Text;
                _dot = false;
            }
        }

        /* 處理button dot被點擊時的event */
        private void ButtonDotClick(object sender, EventArgs e) {
            bool canInsert =
                !_dot &&
                !String.IsNullOrEmpty(textBox.Text) &&
                 Char.IsNumber(textBox.Text[textBox.Text.Length - 1]);
            if (canInsert) {
                textBox.Text += buttonDot.Text;
                _dot = true;
            }
        }

        /* 處理button equal被點擊時的event */
        private void ButtonEqualClick(object sender, EventArgs e) {
            string result = _calculator.Calculate(textBox.Text);
            if (!String.IsNullOrEmpty(result)) {
                _result = textBox.Text = result;
            }
        }
    }
}
