﻿
namespace HomeWork1
{
    partial class AppForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._textBox = new System.Windows.Forms.TextBox();
            this._buttonClear = new System.Windows.Forms.Button();
            this._buttonPlus = new System.Windows.Forms.Button();
            this._buttonSubtract = new System.Windows.Forms.Button();
            this._buttonMultiply = new System.Windows.Forms.Button();
            this._buttonDivide = new System.Windows.Forms.Button();
            this._buttonEqual = new System.Windows.Forms.Button();
            this._button3 = new System.Windows.Forms.Button();
            this._button6 = new System.Windows.Forms.Button();
            this._button9 = new System.Windows.Forms.Button();
            this._buttonClearExpression = new System.Windows.Forms.Button();
            this._buttonDot = new System.Windows.Forms.Button();
            this._button2 = new System.Windows.Forms.Button();
            this._button5 = new System.Windows.Forms.Button();
            this._button8 = new System.Windows.Forms.Button();
            this._button0 = new System.Windows.Forms.Button();
            this._button1 = new System.Windows.Forms.Button();
            this._button4 = new System.Windows.Forms.Button();
            this._button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this._textBox.Font = new System.Drawing.Font("PMingLiU", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._textBox.Location = new System.Drawing.Point(36, 46);
            this._textBox.Margin = new System.Windows.Forms.Padding(4);
            this._textBox.Name = "textBox";
            this._textBox.ReadOnly = true;
            this._textBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._textBox.Size = new System.Drawing.Size(580, 74);
            this._textBox.TabIndex = 0;
            this._textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonC
            // 
            this._buttonClear.Location = new System.Drawing.Point(479, 142);
            this._buttonClear.Margin = new System.Windows.Forms.Padding(6);
            this._buttonClear.Name = "buttonC";
            this._buttonClear.Size = new System.Drawing.Size(136, 88);
            this._buttonClear.TabIndex = 1;
            this._buttonClear.Text = "C";
            this._buttonClear.UseVisualStyleBackColor = true;
            this._buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // buttonPlus
            // 
            this._buttonPlus.Location = new System.Drawing.Point(479, 242);
            this._buttonPlus.Margin = new System.Windows.Forms.Padding(6);
            this._buttonPlus.Name = "buttonPlus";
            this._buttonPlus.Size = new System.Drawing.Size(136, 88);
            this._buttonPlus.TabIndex = 2;
            this._buttonPlus.Text = "+";
            this._buttonPlus.UseVisualStyleBackColor = true;
            this._buttonPlus.Click += new System.EventHandler(this.ButtonPlusClick);
            // 
            // buttonMinus
            // 
            this._buttonSubtract.Location = new System.Drawing.Point(479, 342);
            this._buttonSubtract.Margin = new System.Windows.Forms.Padding(6);
            this._buttonSubtract.Name = "buttonMinus";
            this._buttonSubtract.Size = new System.Drawing.Size(136, 88);
            this._buttonSubtract.TabIndex = 3;
            this._buttonSubtract.Text = "-";
            this._buttonSubtract.UseVisualStyleBackColor = true;
            this._buttonSubtract.Click += new System.EventHandler(this.ButtonSubtractClick);
            // 
            // buttonMul
            // 
            this._buttonMultiply.Location = new System.Drawing.Point(479, 442);
            this._buttonMultiply.Margin = new System.Windows.Forms.Padding(6);
            this._buttonMultiply.Name = "buttonMul";
            this._buttonMultiply.Size = new System.Drawing.Size(136, 88);
            this._buttonMultiply.TabIndex = 4;
            this._buttonMultiply.Text = "x";
            this._buttonMultiply.UseVisualStyleBackColor = true;
            this._buttonMultiply.Click += new System.EventHandler(this.ButtonMultiplyClick);
            // 
            // buttonDiv
            // 
            this._buttonDivide.Location = new System.Drawing.Point(479, 542);
            this._buttonDivide.Margin = new System.Windows.Forms.Padding(6);
            this._buttonDivide.Name = "buttonDiv";
            this._buttonDivide.Size = new System.Drawing.Size(136, 88);
            this._buttonDivide.TabIndex = 5;
            this._buttonDivide.Text = "/";
            this._buttonDivide.UseVisualStyleBackColor = true;
            this._buttonDivide.Click += new System.EventHandler(this.ButtonDivideClick);
            // 
            // buttonEqual
            // 
            this._buttonEqual.Location = new System.Drawing.Point(331, 542);
            this._buttonEqual.Margin = new System.Windows.Forms.Padding(6);
            this._buttonEqual.Name = "buttonEqual";
            this._buttonEqual.Size = new System.Drawing.Size(136, 88);
            this._buttonEqual.TabIndex = 10;
            this._buttonEqual.Text = "=";
            this._buttonEqual.UseVisualStyleBackColor = true;
            this._buttonEqual.Click += new System.EventHandler(this.ButtonEqualClick);
            // 
            // button3
            // 
            this._button3.Location = new System.Drawing.Point(331, 442);
            this._button3.Margin = new System.Windows.Forms.Padding(6);
            this._button3.Name = "button3";
            this._button3.Size = new System.Drawing.Size(136, 88);
            this._button3.TabIndex = 9;
            this._button3.Text = "3";
            this._button3.UseVisualStyleBackColor = true;
            this._button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // button6
            // 
            this._button6.Location = new System.Drawing.Point(331, 342);
            this._button6.Margin = new System.Windows.Forms.Padding(6);
            this._button6.Name = "button6";
            this._button6.Size = new System.Drawing.Size(136, 88);
            this._button6.TabIndex = 8;
            this._button6.Text = "6";
            this._button6.UseVisualStyleBackColor = true;
            this._button6.Click += new System.EventHandler(this.Button6Click);
            // 
            // button9
            // 
            this._button9.Location = new System.Drawing.Point(331, 242);
            this._button9.Margin = new System.Windows.Forms.Padding(6);
            this._button9.Name = "button9";
            this._button9.Size = new System.Drawing.Size(136, 88);
            this._button9.TabIndex = 7;
            this._button9.Text = "9";
            this._button9.UseVisualStyleBackColor = true;
            this._button9.Click += new System.EventHandler(this.Button9Click);
            // 
            // buttonCE
            // 
            this._buttonClearExpression.Location = new System.Drawing.Point(331, 142);
            this._buttonClearExpression.Margin = new System.Windows.Forms.Padding(6);
            this._buttonClearExpression.Name = "buttonCE";
            this._buttonClearExpression.Size = new System.Drawing.Size(136, 88);
            this._buttonClearExpression.TabIndex = 6;
            this._buttonClearExpression.Text = "CE";
            this._buttonClearExpression.UseVisualStyleBackColor = true;
            this._buttonClearExpression.Click += new System.EventHandler(this.ButtonClearExpressionClick);
            // 
            // buttonDot
            // 
            this._buttonDot.Location = new System.Drawing.Point(184, 542);
            this._buttonDot.Margin = new System.Windows.Forms.Padding(6);
            this._buttonDot.Name = "buttonDot";
            this._buttonDot.Size = new System.Drawing.Size(136, 88);
            this._buttonDot.TabIndex = 15;
            this._buttonDot.Text = ".";
            this._buttonDot.UseVisualStyleBackColor = true;
            this._buttonDot.Click += new System.EventHandler(this.ButtonDotClick);
            // 
            // button2
            // 
            this._button2.Location = new System.Drawing.Point(184, 442);
            this._button2.Margin = new System.Windows.Forms.Padding(6);
            this._button2.Name = "button2";
            this._button2.Size = new System.Drawing.Size(136, 88);
            this._button2.TabIndex = 14;
            this._button2.Text = "2";
            this._button2.UseVisualStyleBackColor = true;
            this._button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // button5
            // 
            this._button5.Location = new System.Drawing.Point(184, 342);
            this._button5.Margin = new System.Windows.Forms.Padding(6);
            this._button5.Name = "button5";
            this._button5.Size = new System.Drawing.Size(136, 88);
            this._button5.TabIndex = 13;
            this._button5.Text = "5";
            this._button5.UseVisualStyleBackColor = true;
            this._button5.Click += new System.EventHandler(this.Button5Click);
            // 
            // button8
            // 
            this._button8.Location = new System.Drawing.Point(184, 242);
            this._button8.Margin = new System.Windows.Forms.Padding(6);
            this._button8.Name = "button8";
            this._button8.Size = new System.Drawing.Size(136, 88);
            this._button8.TabIndex = 12;
            this._button8.Text = "8";
            this._button8.UseVisualStyleBackColor = true;
            this._button8.Click += new System.EventHandler(this.Button8Click);
            // 
            // button0
            // 
            this._button0.Location = new System.Drawing.Point(36, 542);
            this._button0.Margin = new System.Windows.Forms.Padding(6);
            this._button0.Name = "button0";
            this._button0.Size = new System.Drawing.Size(136, 88);
            this._button0.TabIndex = 20;
            this._button0.Text = "0";
            this._button0.UseVisualStyleBackColor = true;
            this._button0.Click += new System.EventHandler(this.Button0Click);
            // 
            // button1
            // 
            this._button1.Location = new System.Drawing.Point(36, 442);
            this._button1.Margin = new System.Windows.Forms.Padding(6);
            this._button1.Name = "button1";
            this._button1.Size = new System.Drawing.Size(136, 88);
            this._button1.TabIndex = 19;
            this._button1.Text = "1";
            this._button1.UseVisualStyleBackColor = true;
            this._button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // button4
            // 
            this._button4.Location = new System.Drawing.Point(36, 342);
            this._button4.Margin = new System.Windows.Forms.Padding(6);
            this._button4.Name = "button4";
            this._button4.Size = new System.Drawing.Size(136, 88);
            this._button4.TabIndex = 18;
            this._button4.Text = "4";
            this._button4.UseVisualStyleBackColor = true;
            this._button4.Click += new System.EventHandler(this.Button4Click);
            // 
            // button7
            // 
            this._button7.Location = new System.Drawing.Point(36, 242);
            this._button7.Margin = new System.Windows.Forms.Padding(6);
            this._button7.Name = "button7";
            this._button7.Size = new System.Drawing.Size(136, 88);
            this._button7.TabIndex = 17;
            this._button7.Text = "7";
            this._button7.UseVisualStyleBackColor = true;
            this._button7.Click += new System.EventHandler(this.Button7Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 663);
            this.Controls.Add(this._button0);
            this.Controls.Add(this._button1);
            this.Controls.Add(this._button4);
            this.Controls.Add(this._button7);
            this.Controls.Add(this._buttonDot);
            this.Controls.Add(this._button2);
            this.Controls.Add(this._button5);
            this.Controls.Add(this._button8);
            this.Controls.Add(this._buttonEqual);
            this.Controls.Add(this._button3);
            this.Controls.Add(this._button6);
            this.Controls.Add(this._button9);
            this.Controls.Add(this._buttonClearExpression);
            this.Controls.Add(this._buttonDivide);
            this.Controls.Add(this._buttonMultiply);
            this.Controls.Add(this._buttonSubtract);
            this.Controls.Add(this._buttonPlus);
            this.Controls.Add(this._buttonClear);
            this.Controls.Add(this._textBox);
            this.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AppForm";
            this.Text = "HW1 Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBox;
        private System.Windows.Forms.Button _buttonClear;
        private System.Windows.Forms.Button _buttonPlus;
        private System.Windows.Forms.Button _buttonSubtract;
        private System.Windows.Forms.Button _buttonMultiply;
        private System.Windows.Forms.Button _buttonDivide;
        private System.Windows.Forms.Button _buttonEqual;
        private System.Windows.Forms.Button _button3;
        private System.Windows.Forms.Button _button6;
        private System.Windows.Forms.Button _button9;
        private System.Windows.Forms.Button _buttonClearExpression;
        private System.Windows.Forms.Button _buttonDot;
        private System.Windows.Forms.Button _button2;
        private System.Windows.Forms.Button _button5;
        private System.Windows.Forms.Button _button8;
        private System.Windows.Forms.Button _button0;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.Button _button4;
        private System.Windows.Forms.Button _button7;
    }
}

