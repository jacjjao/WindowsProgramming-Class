
namespace PowerPoint
{
    partial class AddShapeMessageBox
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
            this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this._bottomRightY = new System.Windows.Forms.TextBox();
            this._bottomRightYLabel = new System.Windows.Forms.Label();
            this._tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this._bottomRightX = new System.Windows.Forms.TextBox();
            this._bottomRightXLabel = new System.Windows.Forms.Label();
            this._tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._topLeftY = new System.Windows.Forms.TextBox();
            this._topLeftYLabel = new System.Windows.Forms.Label();
            this._tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._topLeftXLabel = new System.Windows.Forms.Label();
            this._topLeftX = new System.Windows.Forms.TextBox();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._tableLayoutPanel1.SuspendLayout();
            this._tableLayoutPanel5.SuspendLayout();
            this._tableLayoutPanel4.SuspendLayout();
            this._tableLayoutPanel3.SuspendLayout();
            this._tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel1
            // 
            this._tableLayoutPanel1.ColumnCount = 2;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.Controls.Add(this._tableLayoutPanel5, 1, 1);
            this._tableLayoutPanel1.Controls.Add(this._tableLayoutPanel4, 0, 1);
            this._tableLayoutPanel1.Controls.Add(this._tableLayoutPanel3, 1, 0);
            this._tableLayoutPanel1.Controls.Add(this._tableLayoutPanel2, 0, 0);
            this._tableLayoutPanel1.Controls.Add(this._cancelButton, 1, 2);
            this._tableLayoutPanel1.Controls.Add(this._okButton, 0, 2);
            this._tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this._tableLayoutPanel1.Name = "_tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 3;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(434, 277);
            this._tableLayoutPanel1.TabIndex = 0;
            // 
            // _tableLayoutPanel5
            // 
            this._tableLayoutPanel5.ColumnCount = 1;
            this._tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel5.Controls.Add(this._bottomRightY, 0, 1);
            this._tableLayoutPanel5.Controls.Add(this._bottomRightYLabel, 0, 0);
            this._tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel5.Location = new System.Drawing.Point(224, 103);
            this._tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this._tableLayoutPanel5.Name = "_tableLayoutPanel5";
            this._tableLayoutPanel5.RowCount = 2;
            this._tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel5.Size = new System.Drawing.Size(203, 85);
            this._tableLayoutPanel5.TabIndex = 3;
            // 
            // _bottomRightY
            // 
            this._bottomRightY.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bottomRightY.Location = new System.Drawing.Point(3, 45);
            this._bottomRightY.Name = "_bottomRightY";
            this._bottomRightY.Size = new System.Drawing.Size(197, 36);
            this._bottomRightY.TabIndex = 2;
            this._bottomRightY.TextChanged += new System.EventHandler(this.DoBottomRightLabelTextChanged);
            // 
            // _bottomRightYLabel
            // 
            this._bottomRightYLabel.AutoSize = true;
            this._bottomRightYLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bottomRightYLabel.Location = new System.Drawing.Point(3, 0);
            this._bottomRightYLabel.Name = "_bottomRightYLabel";
            this._bottomRightYLabel.Size = new System.Drawing.Size(197, 42);
            this._bottomRightYLabel.TabIndex = 1;
            this._bottomRightYLabel.Text = "右下角座標Y";
            this._bottomRightYLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // _tableLayoutPanel4
            // 
            this._tableLayoutPanel4.ColumnCount = 1;
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel4.Controls.Add(this._bottomRightX, 0, 1);
            this._tableLayoutPanel4.Controls.Add(this._bottomRightXLabel, 0, 0);
            this._tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel4.Location = new System.Drawing.Point(7, 103);
            this._tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this._tableLayoutPanel4.Name = "_tableLayoutPanel4";
            this._tableLayoutPanel4.RowCount = 2;
            this._tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel4.Size = new System.Drawing.Size(203, 85);
            this._tableLayoutPanel4.TabIndex = 2;
            // 
            // _bottomRightX
            // 
            this._bottomRightX.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bottomRightX.Location = new System.Drawing.Point(3, 45);
            this._bottomRightX.Name = "_bottomRightX";
            this._bottomRightX.Size = new System.Drawing.Size(197, 36);
            this._bottomRightX.TabIndex = 2;
            this._bottomRightX.TextChanged += new System.EventHandler(this.DoBottomLeftLabelTextChanged);
            // 
            // _bottomRightXLabel
            // 
            this._bottomRightXLabel.AutoSize = true;
            this._bottomRightXLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bottomRightXLabel.Location = new System.Drawing.Point(3, 0);
            this._bottomRightXLabel.Name = "_bottomRightXLabel";
            this._bottomRightXLabel.Size = new System.Drawing.Size(197, 42);
            this._bottomRightXLabel.TabIndex = 1;
            this._bottomRightXLabel.Text = "右下角座標X";
            this._bottomRightXLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // _tableLayoutPanel3
            // 
            this._tableLayoutPanel3.ColumnCount = 1;
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel3.Controls.Add(this._topLeftY, 0, 1);
            this._tableLayoutPanel3.Controls.Add(this._topLeftYLabel, 0, 0);
            this._tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel3.Location = new System.Drawing.Point(224, 6);
            this._tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this._tableLayoutPanel3.Name = "_tableLayoutPanel3";
            this._tableLayoutPanel3.RowCount = 2;
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel3.Size = new System.Drawing.Size(203, 85);
            this._tableLayoutPanel3.TabIndex = 1;
            // 
            // _topLeftY
            // 
            this._topLeftY.Dock = System.Windows.Forms.DockStyle.Fill;
            this._topLeftY.Location = new System.Drawing.Point(3, 45);
            this._topLeftY.Name = "_topLeftY";
            this._topLeftY.Size = new System.Drawing.Size(197, 36);
            this._topLeftY.TabIndex = 2;
            this._topLeftY.TextChanged += new System.EventHandler(this.DoTopRightLabelTextChanged);
            // 
            // _topLeftYLabel
            // 
            this._topLeftYLabel.AutoSize = true;
            this._topLeftYLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._topLeftYLabel.Location = new System.Drawing.Point(3, 0);
            this._topLeftYLabel.Name = "_topLeftYLabel";
            this._topLeftYLabel.Size = new System.Drawing.Size(197, 42);
            this._topLeftYLabel.TabIndex = 1;
            this._topLeftYLabel.Text = "左上角座標Y";
            this._topLeftYLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // _tableLayoutPanel2
            // 
            this._tableLayoutPanel2.ColumnCount = 1;
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.Controls.Add(this._topLeftXLabel, 0, 0);
            this._tableLayoutPanel2.Controls.Add(this._topLeftX, 0, 1);
            this._tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel2.Location = new System.Drawing.Point(7, 6);
            this._tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this._tableLayoutPanel2.Name = "_tableLayoutPanel2";
            this._tableLayoutPanel2.RowCount = 2;
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.Size = new System.Drawing.Size(203, 85);
            this._tableLayoutPanel2.TabIndex = 0;
            // 
            // _topLeftXLabel
            // 
            this._topLeftXLabel.AutoSize = true;
            this._topLeftXLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._topLeftXLabel.Location = new System.Drawing.Point(3, 0);
            this._topLeftXLabel.Name = "_topLeftXLabel";
            this._topLeftXLabel.Size = new System.Drawing.Size(197, 42);
            this._topLeftXLabel.TabIndex = 0;
            this._topLeftXLabel.Text = "左上角座標X";
            this._topLeftXLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // _topLeftX
            // 
            this._topLeftX.Dock = System.Windows.Forms.DockStyle.Fill;
            this._topLeftX.Location = new System.Drawing.Point(3, 45);
            this._topLeftX.Name = "_topLeftX";
            this._topLeftX.Size = new System.Drawing.Size(197, 36);
            this._topLeftX.TabIndex = 1;
            this._topLeftX.TextChanged += new System.EventHandler(this.DoTopLeftLabelTextChanged);
            // 
            // _cancelButton
            // 
            this._cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cancelButton.Location = new System.Drawing.Point(224, 200);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(203, 71);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.DoCancelButtonClick);
            // 
            // _okButton
            // 
            this._okButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(3, 197);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(211, 77);
            this._okButton.TabIndex = 6;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.DoOkButtonClick);
            // 
            // AddShapeMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 277);
            this.Controls.Add(this._tableLayoutPanel1);
            this.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "AddShapeMessageBox";
            this._tableLayoutPanel1.ResumeLayout(false);
            this._tableLayoutPanel5.ResumeLayout(false);
            this._tableLayoutPanel5.PerformLayout();
            this._tableLayoutPanel4.ResumeLayout(false);
            this._tableLayoutPanel4.PerformLayout();
            this._tableLayoutPanel3.ResumeLayout(false);
            this._tableLayoutPanel3.PerformLayout();
            this._tableLayoutPanel2.ResumeLayout(false);
            this._tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel2;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _topLeftXLabel;
        private System.Windows.Forms.TextBox _bottomRightY;
        private System.Windows.Forms.Label _bottomRightYLabel;
        private System.Windows.Forms.TextBox _bottomRightX;
        private System.Windows.Forms.Label _bottomRightXLabel;
        private System.Windows.Forms.TextBox _topLeftY;
        private System.Windows.Forms.Label _topLeftYLabel;
        private System.Windows.Forms.TextBox _topLeftX;
        private System.Windows.Forms.Button _okButton;
    }
}