using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class EventHandler
    {
        private Calculator _calculator = new Calculator();
        private string _result = "";
        private bool _dot = false;

        /* 處理button CE被點擊時的event */
        private void ButtonClearExpressionClick(object sender, EventArgs e)
        {
            _textBox.Text = _result;
            _dot = !double.TryParse(_result, out _);
        }

        /* 處理button C被點擊時的event */
        private void ButtonClearClick(object sender, EventArgs e)
        {
            _textBox.Text = _result = "";
            _dot = false;
        }

        /* 處理button 9被點擊時的event */
        private void Button9Click(object sender, EventArgs e)
        {
            _textBox.Text += _button9.Text;
        }

        /* 處理button 8被點擊時的event */
        private void Button8Click(object sender, EventArgs e)
        {
            _textBox.Text += _button8.Text;
        }

        /* 處理button 7被點擊時的event */
        private void Button7Click(object sender, EventArgs e)
        {
            _textBox.Text += _button7.Text;
        }

        /* 處理button 6被點擊時的event */
        private void Button6Click(object sender, EventArgs e)
        {
            _textBox.Text += _button6.Text;
        }

        /* 處理button 5被點擊時的event */
        private void Button5Click(object sender, EventArgs e)
        {
            _textBox.Text += _button5.Text;
        }

        /* 處理button 4被點擊時的event */
        private void Button4Click(object sender, EventArgs e)
        {
            _textBox.Text += _button4.Text;
        }

        /* 處理button 3被點擊時的event */
        private void Button3Click(object sender, EventArgs e)
        {
            _textBox.Text += _button3.Text;
        }

        /* 處理button 2被點擊時的event */
        private void Button2Click(object sender, EventArgs e)
        {
            _textBox.Text += _button2.Text;
        }

        /* 處理button 1被點擊時的event */
        private void Button1Click(object sender, EventArgs e)
        {
            _textBox.Text += _button1.Text;
        }

        /* 處理button 0被點擊時的event */
        private void Button0Click(object sender, EventArgs e)
        {
            _textBox.Text += _button0.Text;
        }

        /* 處理button plus被點擊時的event */
        private void ButtonPlusClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_textBox.Text) &&
                Char.IsNumber(_textBox.Text[_textBox.Text.Length - 1]))
            {
                _textBox.Text += _buttonPlus.Text;
                _dot = false;
            }
        }

        /* 處理button subtract被點擊時的event */
        private void ButtonSubtractClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_textBox.Text) ||
                Char.IsNumber(_textBox.Text[_textBox.Text.Length - 1]))
            {
                _textBox.Text += _buttonSubtract.Text;
                _dot = false;
            }
        }

        /* 處理button multiply被點擊時的event */
        private void ButtonMultiplyClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_textBox.Text) &&
                Char.IsNumber(_textBox.Text[_textBox.Text.Length - 1]))
            {
                _textBox.Text += _buttonMultiply.Text;
                _dot = false;
            }
        }

        /* 處理button divide被點擊時的event */
        private void ButtonDivideClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_textBox.Text) &&
                Char.IsNumber(_textBox.Text[_textBox.Text.Length - 1]))
            {
                _textBox.Text += _buttonDivide.Text;
                _dot = false;
            }
        }

        /* 處理button dot被點擊時的event */
        private void ButtonDotClick(object sender, EventArgs e)
        {
            bool canInsert =
                !_dot &&
                !String.IsNullOrEmpty(_textBox.Text) &&
                Char.IsNumber(_textBox.Text[_textBox.Text.Length - 1]);
            if (canInsert)
            {
                _textBox.Text += _buttonDot.Text;
                _dot = true;
            }
        }

        /* 處理button equal被點擊時的event */
        private void ButtonEqualClick(object sender, EventArgs e)
        {
            try
            {
                string result = _calculator.Calculate(_textBox.Text);
                if (!String.IsNullOrEmpty(result))
                {
                    _result = _textBox.Text = result;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something bad happened");
                Reset();
            }
        }

        /* reset */
        private void Reset()
        {
            _result = _textBox.Text = "";
            _dot = false;
            _calculator.Reset();
        }
    }
}
