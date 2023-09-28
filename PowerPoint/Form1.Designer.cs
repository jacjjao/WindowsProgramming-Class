
namespace PowerPoint
{
    partial class Form1
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
            this._dataGroup = new System.Windows.Forms.GroupBox();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._addButton = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._button2 = new System.Windows.Forms.Button();
            this._button3 = new System.Windows.Forms.Button();
            this._tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tableLayoutPanel1.SuspendLayout();
            this._dataGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._flowLayoutPanel1.SuspendLayout();
            this._tableLayoutPanel2.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel1
            // 
            this._tableLayoutPanel1.AutoSize = true;
            this._tableLayoutPanel1.ColumnCount = 3;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.87554F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.12447F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this._tableLayoutPanel1.Controls.Add(this._dataGroup, 2, 0);
            this._tableLayoutPanel1.Controls.Add(this._flowLayoutPanel1, 0, 0);
            this._tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel1.Location = new System.Drawing.Point(2, 23);
            this._tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this._tableLayoutPanel1.Name = "_tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 1;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(795, 400);
            this._tableLayoutPanel1.TabIndex = 0;
            // 
            // _dataGroup
            // 
            this._dataGroup.Controls.Add(this._splitContainer1);
            this._dataGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGroup.Location = new System.Drawing.Point(595, 2);
            this._dataGroup.Margin = new System.Windows.Forms.Padding(2);
            this._dataGroup.Name = "_dataGroup";
            this._dataGroup.Padding = new System.Windows.Forms.Padding(2);
            this._dataGroup.Size = new System.Drawing.Size(198, 396);
            this._dataGroup.TabIndex = 0;
            this._dataGroup.TabStop = false;
            this._dataGroup.Text = "資料顯示";
            // 
            // _splitContainer1
            // 
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.Location = new System.Drawing.Point(2, 17);
            this._splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this._splitContainer1.Name = "_splitContainer1";
            this._splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._shapeComboBox);
            this._splitContainer1.Panel1.Controls.Add(this._addButton);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._dataGridView);
            this._splitContainer1.Size = new System.Drawing.Size(194, 377);
            this._splitContainer1.SplitterDistance = 26;
            this._splitContainer1.SplitterWidth = 2;
            this._splitContainer1.TabIndex = 0;
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "矩形",
            "線"});
            this._shapeComboBox.Location = new System.Drawing.Point(69, 4);
            this._shapeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(82, 20);
            this._shapeComboBox.TabIndex = 1;
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(2, 2);
            this._addButton.Margin = new System.Windows.Forms.Padding(2);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(53, 22);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "新增";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._infoColumn});
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(0, 0);
            this._dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this._dataGridView.RowTemplate.Height = 28;
            this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridView.Size = new System.Drawing.Size(194, 349);
            this._dataGridView.TabIndex = 0;
            this._dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoDataGridViewButtonCellClick);
            // 
            // 刪除
            // 
            this._deleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._deleteColumn.HeaderText = "刪除";
            this._deleteColumn.MinimumWidth = 8;
            this._deleteColumn.Name = "刪除";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteColumn.Text = "刪除";
            this._deleteColumn.UseColumnTextForButtonValue = true;
            this._deleteColumn.Width = 54;
            // 
            // 形狀
            // 
            this._shapeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._shapeColumn.HeaderText = "形狀";
            this._shapeColumn.MinimumWidth = 8;
            this._shapeColumn.Name = "形狀";
            this._shapeColumn.ReadOnly = true;
            this._shapeColumn.Width = 54;
            // 
            // 資訊
            // 
            this._infoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._infoColumn.HeaderText = "資訊";
            this._infoColumn.MinimumWidth = 8;
            this._infoColumn.Name = "資訊";
            this._infoColumn.ReadOnly = true;
            this._infoColumn.Width = 54;
            // 
            // _flowLayoutPanel1
            // 
            this._flowLayoutPanel1.Controls.Add(this._button2);
            this._flowLayoutPanel1.Controls.Add(this._button3);
            this._flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this._flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this._flowLayoutPanel1.Name = "_flowLayoutPanel1";
            this._flowLayoutPanel1.Size = new System.Drawing.Size(72, 396);
            this._flowLayoutPanel1.TabIndex = 1;
            // 
            // _button2
            // 
            this._button2.Location = new System.Drawing.Point(2, 2);
            this._button2.Margin = new System.Windows.Forms.Padding(2);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(71, 48);
            this._button2.TabIndex = 0;
            this._button2.UseVisualStyleBackColor = true;
            // 
            // _button3
            // 
            this._button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._button3.AutoSize = true;
            this._button3.Location = new System.Drawing.Point(2, 54);
            this._button3.Margin = new System.Windows.Forms.Padding(2);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(71, 48);
            this._button3.TabIndex = 1;
            this._button3.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel2
            // 
            this._tableLayoutPanel2.ColumnCount = 1;
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.Controls.Add(this._tableLayoutPanel1, 0, 1);
            this._tableLayoutPanel2.Controls.Add(this._menuStrip, 0, 0);
            this._tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this._tableLayoutPanel2.Name = "_tableLayoutPanel2";
            this._tableLayoutPanel2.RowCount = 2;
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.082212F));
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.91779F));
            this._tableLayoutPanel2.Size = new System.Drawing.Size(799, 425);
            this._tableLayoutPanel2.TabIndex = 1;
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._infoToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this._menuStrip.Size = new System.Drawing.Size(799, 21);
            this._menuStrip.TabIndex = 1;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _infoToolStripMenuItem
            // 
            this._infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._infoToolStripMenuItem.Name = "_infoToolStripMenuItem";
            this._infoToolStripMenuItem.Size = new System.Drawing.Size(45, 19);
            this._infoToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 425);
            this.Controls.Add(this._tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "PowerPoint";
            this._tableLayoutPanel1.ResumeLayout(false);
            this._dataGroup.ResumeLayout(false);
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._flowLayoutPanel1.ResumeLayout(false);
            this._flowLayoutPanel1.PerformLayout();
            this._tableLayoutPanel2.ResumeLayout(false);
            this._tableLayoutPanel2.PerformLayout();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
        private System.Windows.Forms.GroupBox _dataGroup;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel2;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanel1;
        private System.Windows.Forms.Button _button2;
        private System.Windows.Forms.Button _button3;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoColumn;
    }
}

