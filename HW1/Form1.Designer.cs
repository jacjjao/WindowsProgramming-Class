
namespace HW1
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
            this._buttonC = new System.Windows.Forms.Button();
            this._buttonPlus = new System.Windows.Forms.Button();
            this._buttonSub = new System.Windows.Forms.Button();
            this._buttonMul = new System.Windows.Forms.Button();
            this._buttonDiv = new System.Windows.Forms.Button();
            this._buttonEqual = new System.Windows.Forms.Button();
            this._button3 = new System.Windows.Forms.Button();
            this._button6 = new System.Windows.Forms.Button();
            this._button9 = new System.Windows.Forms.Button();
            this._buttonCE = new System.Windows.Forms.Button();
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
            this._buttonC.Location = new System.Drawing.Point(479, 142);
            this._buttonC.Margin = new System.Windows.Forms.Padding(6);
            this._buttonC.Name = "buttonC";
            this._buttonC.Size = new System.Drawing.Size(136, 88);
            this._buttonC.TabIndex = 1;
            this._buttonC.Text = "C";
            this._buttonC.UseVisualStyleBackColor = true;
            this._buttonC.Click += new System.EventHandler(this.DoButtonCClick);
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
            this._buttonSub.Location = new System.Drawing.Point(479, 342);
            this._buttonSub.Margin = new System.Windows.Forms.Padding(6);
            this._buttonSub.Name = "buttonMinus";
            this._buttonSub.Size = new System.Drawing.Size(136, 88);
            this._buttonSub.TabIndex = 3;
            this._buttonSub.Text = "-";
            this._buttonSub.UseVisualStyleBackColor = true;
            this._buttonSub.Click += new System.EventHandler(this.ButtonSubClick);
            // 
            // buttonMul
            // 
            this._buttonMul.Location = new System.Drawing.Point(479, 442);
            this._buttonMul.Margin = new System.Windows.Forms.Padding(6);
            this._buttonMul.Name = "buttonMul";
            this._buttonMul.Size = new System.Drawing.Size(136, 88);
            this._buttonMul.TabIndex = 4;
            this._buttonMul.Text = "x";
            this._buttonMul.UseVisualStyleBackColor = true;
            this._buttonMul.Click += new System.EventHandler(this.ButtonMulClick);
            // 
            // buttonDiv
            // 
            this._buttonDiv.Location = new System.Drawing.Point(479, 542);
            this._buttonDiv.Margin = new System.Windows.Forms.Padding(6);
            this._buttonDiv.Name = "buttonDiv";
            this._buttonDiv.Size = new System.Drawing.Size(136, 88);
            this._buttonDiv.TabIndex = 5;
            this._buttonDiv.Text = "/";
            this._buttonDiv.UseVisualStyleBackColor = true;
            this._buttonDiv.Click += new System.EventHandler(this.ButtonDivClick);
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
            this._buttonCE.Location = new System.Drawing.Point(331, 142);
            this._buttonCE.Margin = new System.Windows.Forms.Padding(6);
            this._buttonCE.Name = "buttonCE";
            this._buttonCE.Size = new System.Drawing.Size(136, 88);
            this._buttonCE.TabIndex = 6;
            this._buttonCE.Text = "CE";
            this._buttonCE.UseVisualStyleBackColor = true;
            this._buttonCE.Click += new System.EventHandler(this.DoButtonCEClick);
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
            this.Controls.Add(this._buttonCE);
            this.Controls.Add(this._buttonDiv);
            this.Controls.Add(this._buttonMul);
            this.Controls.Add(this._buttonSub);
            this.Controls.Add(this._buttonPlus);
            this.Controls.Add(this._buttonC);
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
        private System.Windows.Forms.Button _buttonC;
        private System.Windows.Forms.Button _buttonPlus;
        private System.Windows.Forms.Button _buttonSub;
        private System.Windows.Forms.Button _buttonMul;
        private System.Windows.Forms.Button _buttonDiv;
        private System.Windows.Forms.Button _buttonEqual;
        private System.Windows.Forms.Button _button3;
        private System.Windows.Forms.Button _button6;
        private System.Windows.Forms.Button _button9;
        private System.Windows.Forms.Button _buttonCE;
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

