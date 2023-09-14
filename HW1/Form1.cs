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
            result_ = "";
            calculator_ = new Calculator();
            dot_ = false;
        }

        private Calculator calculator_;
        private string result_;
        private bool dot_;

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBox.Text = result_;
            dot_ = !double.TryParse(result_, out _);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox.Text = result_ = "";
            dot_ = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox.Text += '9';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox.Text += '8';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox.Text += '7';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox.Text += '6';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox.Text += '5';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox.Text += '4';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox.Text += '3';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox.Text += '2';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox.Text += '1';
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox.Text += '0';
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1]))
            {
                textBox.Text += '+';
                dot_ = false;
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1]))
            {
                textBox.Text += '-';
                dot_ = false;
            }
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1]))
            {
                textBox.Text += 'x';
                dot_ = false;
            }
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text) && Char.IsNumber(textBox.Text[textBox.Text.Length - 1]))
            {
                textBox.Text += '/';
                dot_ = false;
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            bool can_insert =
                !dot_ &&
                !String.IsNullOrEmpty(textBox.Text) &&
                 Char.IsNumber(textBox.Text[textBox.Text.Length - 1]);
            if (can_insert)
            {
                textBox.Text += '.';
                dot_ = true;
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            string result = calculator_.calculate(textBox.Text.Replace('x', '*'));
            if (!String.IsNullOrEmpty(result))
            {
                result_ = textBox.Text = result;
            }
        }
    }
}
