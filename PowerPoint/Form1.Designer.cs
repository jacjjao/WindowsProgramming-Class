﻿
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._toolStripLineButton = new PowerPoint.BindToolStripButton();
            this._toolStripRectangleButton = new PowerPoint.BindToolStripButton();
            this._toolStripCircleButton = new PowerPoint.BindToolStripButton();
            this._toolStripPointerButton = new PowerPoint.BindToolStripButton();
            this._toolStripUndoButton = new PowerPoint.BindToolStripButton();
            this._toolStripRedoButton = new PowerPoint.BindToolStripButton();
            this._toolStripNewPageButton = new PowerPoint.BindToolStripButton();
            this._toolStripDeletePageButton = new PowerPoint.BindToolStripButton();
            this._toolStripFileSaveButton = new PowerPoint.BindToolStripButton();
            this._toolStripFileLoadButton = new PowerPoint.BindToolStripButton();
            this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._splitContainer4 = new System.Windows.Forms.SplitContainer();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._splitContainer3 = new System.Windows.Forms.SplitContainer();
            this._flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this._addButton = new System.Windows.Forms.Button();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._tableLayoutPanel3.SuspendLayout();
            this._menuStrip1.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            this._tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer4)).BeginInit();
            this._splitContainer4.Panel2.SuspendLayout();
            this._splitContainer4.SuspendLayout();
            this._groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer3)).BeginInit();
            this._splitContainer3.Panel1.SuspendLayout();
            this._splitContainer3.Panel2.SuspendLayout();
            this._splitContainer3.SuspendLayout();
            this._flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._shapeBindingSource)).BeginInit();
            this._tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel3
            // 
            this._tableLayoutPanel3.ColumnCount = 1;
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel3.Controls.Add(this._menuStrip1, 0, 0);
            this._tableLayoutPanel3.Controls.Add(this._toolStrip1, 0, 1);
            this._tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel3.Name = "_tableLayoutPanel3";
            this._tableLayoutPanel3.RowCount = 2;
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this._tableLayoutPanel3.Size = new System.Drawing.Size(1268, 64);
            this._tableLayoutPanel3.TabIndex = 1;
            // 
            // _menuStrip1
            // 
            this._menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._infoToolStripMenuItem});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(1268, 28);
            this._menuStrip1.TabIndex = 1;
            this._menuStrip1.Text = "menuStrip1";
            // 
            // _infoToolStripMenuItem
            // 
            this._infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._infoToolStripMenuItem.Name = "_infoToolStripMenuItem";
            this._infoToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this._infoToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _toolStrip1
            // 
            this._toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripLineButton,
            this._toolStripRectangleButton,
            this._toolStripCircleButton,
            this._toolStripPointerButton,
            this._toolStripUndoButton,
            this._toolStripRedoButton,
            this._toolStripNewPageButton,
            this._toolStripDeletePageButton,
            this._toolStripFileSaveButton,
            this._toolStripFileLoadButton});
            this._toolStrip1.Location = new System.Drawing.Point(0, 28);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1268, 36);
            this._toolStrip1.TabIndex = 0;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // _toolStripLineButton
            // 
            this._toolStripLineButton.AccessibleName = "ToolStripLineButton";
            this._toolStripLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripLineButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripLineButton.Image")));
            this._toolStripLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripLineButton.Name = "_toolStripLineButton";
            this._toolStripLineButton.Size = new System.Drawing.Size(23, 33);
            this._toolStripLineButton.Text = "/";
            this._toolStripLineButton.Click += new System.EventHandler(this.DoToolStripButtonLineClick);
            // 
            // _toolStripRectangleButton
            // 
            this._toolStripRectangleButton.AccessibleName = "ToolStripRectangleButton";
            this._toolStripRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripRectangleButton.Image")));
            this._toolStripRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripRectangleButton.Name = "_toolStripRectangleButton";
            this._toolStripRectangleButton.Size = new System.Drawing.Size(23, 33);
            this._toolStripRectangleButton.Click += new System.EventHandler(this.DoToolStripButtonRectangleClick);
            // 
            // _toolStripCircleButton
            // 
            this._toolStripCircleButton.AccessibleName = "ToolStripCircleButton";
            this._toolStripCircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripCircleButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripCircleButton.Image")));
            this._toolStripCircleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripCircleButton.Name = "_toolStripCircleButton";
            this._toolStripCircleButton.Size = new System.Drawing.Size(23, 33);
            this._toolStripCircleButton.Text = "O";
            this._toolStripCircleButton.Click += new System.EventHandler(this.DoToolStripButtonCircleClick);
            // 
            // _toolStripPointerButton
            // 
            this._toolStripPointerButton.AccessibleName = "ToolStripPointerButton";
            this._toolStripPointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripPointerButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripPointerButton.Image")));
            this._toolStripPointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripPointerButton.Name = "_toolStripPointerButton";
            this._toolStripPointerButton.Size = new System.Drawing.Size(23, 33);
            this._toolStripPointerButton.Click += new System.EventHandler(this.DoToolStripButtonPointerClick);
            // 
            // _toolStripUndoButton
            // 
            this._toolStripUndoButton.AccessibleName = "ToolStripUndoButton";
            this._toolStripUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripUndoButton.Enabled = false;
            this._toolStripUndoButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripUndoButton.Image")));
            this._toolStripUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripUndoButton.Name = "_toolStripUndoButton";
            this._toolStripUndoButton.Size = new System.Drawing.Size(24, 33);
            this._toolStripUndoButton.Text = "<-";
            this._toolStripUndoButton.Click += new System.EventHandler(this.DoToolStripButtonUndoClick);
            // 
            // _toolStripRedoButton
            // 
            this._toolStripRedoButton.AccessibleName = "ToolStripRedoButton";
            this._toolStripRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripRedoButton.Enabled = false;
            this._toolStripRedoButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripRedoButton.Image")));
            this._toolStripRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripRedoButton.Name = "_toolStripRedoButton";
            this._toolStripRedoButton.Size = new System.Drawing.Size(24, 33);
            this._toolStripRedoButton.Text = "->";
            this._toolStripRedoButton.Click += new System.EventHandler(this.DoToolStripButtonRedoClick);
            // 
            // _toolStripNewPageButton
            // 
            this._toolStripNewPageButton.AccessibleName = "ToolStripNewPageButton";
            this._toolStripNewPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripNewPageButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripNewPageButton.Image")));
            this._toolStripNewPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripNewPageButton.Name = "_toolStripNewPageButton";
            this._toolStripNewPageButton.Size = new System.Drawing.Size(23, 33);
            this._toolStripNewPageButton.Click += new System.EventHandler(this.DoToolStripButtonNewPageClick);
            // 
            // _toolStripDeletePageButton
            // 
            this._toolStripDeletePageButton.AccessibleName = "ToolStripDeletePageButton";
            this._toolStripDeletePageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripDeletePageButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripDeletePageButton.Image")));
            this._toolStripDeletePageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripDeletePageButton.Name = "_toolStripDeletePageButton";
            this._toolStripDeletePageButton.Size = new System.Drawing.Size(23, 33);
            this._toolStripDeletePageButton.Click += new System.EventHandler(this.RemoveCheckedSlide);
            // 
            // _toolStripFileSaveButton
            // 
            this._toolStripFileSaveButton.AccessibleName = "ToolStripFileSaveButton";
            this._toolStripFileSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripFileSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripFileSaveButton.Image")));
            this._toolStripFileSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripFileSaveButton.Name = "_toolStripFileSaveButton";
            this._toolStripFileSaveButton.Size = new System.Drawing.Size(23, 33);
            this._toolStripFileSaveButton.Click += new System.EventHandler(this.UploadPages);
            // 
            // _toolStripFileLoadButton
            // 
            this._toolStripFileLoadButton.AccessibleName = "ToolStripFileLoadButton";
            this._toolStripFileLoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripFileLoadButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripFileLoadButton.Image")));
            this._toolStripFileLoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripFileLoadButton.Name = "_toolStripFileLoadButton";
            this._toolStripFileLoadButton.Size = new System.Drawing.Size(23, 33);
            this._toolStripFileLoadButton.Click += new System.EventHandler(this.DownloadFile);
            // 
            // _tableLayoutPanel1
            // 
            this._tableLayoutPanel1.AutoSize = true;
            this._tableLayoutPanel1.ColumnCount = 1;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.3139F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.6861F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 271F));
            this._tableLayoutPanel1.Controls.Add(this._splitContainer1, 1, 0);
            this._tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel1.Location = new System.Drawing.Point(2, 72);
            this._tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this._tableLayoutPanel1.Name = "_tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 1;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(1270, 667);
            this._tableLayoutPanel1.TabIndex = 0;
            // 
            // _splitContainer1
            // 
            this._splitContainer1.AccessibleName = "_splitContainer1";
            this._splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer1.Location = new System.Drawing.Point(3, 3);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._flowLayoutPanel);
            this._splitContainer1.Panel1.Resize += new System.EventHandler(this.ResizeSlideButtons);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer4);
            this._splitContainer1.Size = new System.Drawing.Size(1264, 661);
            this._splitContainer1.SplitterDistance = 139;
            this._splitContainer1.TabIndex = 2;
            // 
            // _flowLayoutPanel
            // 
            this._flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._flowLayoutPanel.Name = "_flowLayoutPanel";
            this._flowLayoutPanel.Size = new System.Drawing.Size(135, 657);
            this._flowLayoutPanel.TabIndex = 0;
            this._flowLayoutPanel.SizeChanged += new System.EventHandler(this.ResizeSlideButtons);
            // 
            // _splitContainer4
            // 
            this._splitContainer4.AccessibleName = "_splitContainer4";
            this._splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer4.Location = new System.Drawing.Point(0, 0);
            this._splitContainer4.Name = "_splitContainer4";
            // 
            // _splitContainer4.Panel1
            // 
            this._splitContainer4.Panel1.Resize += new System.EventHandler(this.SplitContainer2Panel1Resize);
            // 
            // _splitContainer4.Panel2
            // 
            this._splitContainer4.Panel2.Controls.Add(this._groupBox1);
            this._splitContainer4.Size = new System.Drawing.Size(1121, 661);
            this._splitContainer4.SplitterDistance = 867;
            this._splitContainer4.TabIndex = 0;
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._splitContainer3);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox1.Location = new System.Drawing.Point(0, 0);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(246, 657);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "資料顯示";
            // 
            // _splitContainer3
            // 
            this._splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer3.IsSplitterFixed = true;
            this._splitContainer3.Location = new System.Drawing.Point(3, 18);
            this._splitContainer3.Name = "_splitContainer3";
            this._splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainer3.Panel1
            // 
            this._splitContainer3.Panel1.Controls.Add(this._flowLayoutPanel2);
            // 
            // _splitContainer3.Panel2
            // 
            this._splitContainer3.Panel2.Controls.Add(this._dataGridView);
            this._splitContainer3.Size = new System.Drawing.Size(240, 636);
            this._splitContainer3.SplitterDistance = 52;
            this._splitContainer3.TabIndex = 0;
            // 
            // _flowLayoutPanel2
            // 
            this._flowLayoutPanel2.Controls.Add(this._addButton);
            this._flowLayoutPanel2.Controls.Add(this._shapeComboBox);
            this._flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this._flowLayoutPanel2.Name = "_flowLayoutPanel2";
            this._flowLayoutPanel2.Size = new System.Drawing.Size(240, 52);
            this._flowLayoutPanel2.TabIndex = 0;
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(2, 2);
            this._addButton.Margin = new System.Windows.Forms.Padding(2);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(63, 40);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "新增";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.AccessibleName = "ShapeSelector";
            this._shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "矩形",
            "線",
            "圓"});
            this._shapeComboBox.Location = new System.Drawing.Point(69, 2);
            this._shapeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(141, 20);
            this._shapeComboBox.TabIndex = 1;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AutoGenerateColumns = false;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._shapeColumn,
            this._infoColumn,
            this._infoDataGridViewTextBoxColumn,
            this._nameDataGridViewTextBoxColumn,
            this._deleteColumn});
            this._dataGridView.DataSource = this._shapeBindingSource;
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(0, 0);
            this._dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this._dataGridView.RowTemplate.Height = 28;
            this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridView.Size = new System.Drawing.Size(240, 580);
            this._dataGridView.TabIndex = 0;
            this._dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoDataGridViewButtonCellClick);
            // 
            // _shapeColumn
            // 
            this._shapeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._shapeColumn.DataPropertyName = "Name";
            this._shapeColumn.HeaderText = "形狀";
            this._shapeColumn.MinimumWidth = 8;
            this._shapeColumn.Name = "_shapeColumn";
            this._shapeColumn.ReadOnly = true;
            this._shapeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._shapeColumn.Width = 54;
            // 
            // _infoColumn
            // 
            this._infoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._infoColumn.DataPropertyName = "Info";
            this._infoColumn.HeaderText = "資訊";
            this._infoColumn.MinimumWidth = 8;
            this._infoColumn.Name = "_infoColumn";
            this._infoColumn.ReadOnly = true;
            this._infoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _infoDataGridViewTextBoxColumn
            // 
            this._infoDataGridViewTextBoxColumn.DataPropertyName = "Info";
            this._infoDataGridViewTextBoxColumn.HeaderText = "Info";
            this._infoDataGridViewTextBoxColumn.Name = "_infoDataGridViewTextBoxColumn";
            this._infoDataGridViewTextBoxColumn.ReadOnly = true;
            this._infoDataGridViewTextBoxColumn.Visible = false;
            // 
            // _nameDataGridViewTextBoxColumn
            // 
            this._nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this._nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this._nameDataGridViewTextBoxColumn.Name = "_nameDataGridViewTextBoxColumn";
            this._nameDataGridViewTextBoxColumn.ReadOnly = true;
            this._nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // _deleteColumn
            // 
            this._deleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._deleteColumn.HeaderText = "刪除";
            this._deleteColumn.MinimumWidth = 8;
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._deleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteColumn.Text = "刪除";
            this._deleteColumn.UseColumnTextForButtonValue = true;
            this._deleteColumn.Width = 54;
            // 
            // _shapeBindingSource
            // 
            this._shapeBindingSource.DataSource = typeof(PowerPoint.Shape);
            // 
            // _tableLayoutPanel2
            // 
            this._tableLayoutPanel2.AutoSize = true;
            this._tableLayoutPanel2.ColumnCount = 1;
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel2.Controls.Add(this._tableLayoutPanel1, 0, 1);
            this._tableLayoutPanel2.Controls.Add(this._tableLayoutPanel3, 0, 0);
            this._tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this._tableLayoutPanel2.Name = "_tableLayoutPanel2";
            this._tableLayoutPanel2.RowCount = 2;
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel2.Size = new System.Drawing.Size(1274, 741);
            this._tableLayoutPanel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 741);
            this.Controls.Add(this._tableLayoutPanel2);
            this.MainMenuStrip = this._menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "PowerPoint";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1KeyDown);
            this._tableLayoutPanel3.ResumeLayout(false);
            this._tableLayoutPanel3.PerformLayout();
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this._tableLayoutPanel1.ResumeLayout(false);
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer4)).EndInit();
            this._splitContainer4.ResumeLayout(false);
            this._groupBox1.ResumeLayout(false);
            this._splitContainer3.Panel1.ResumeLayout(false);
            this._splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer3)).EndInit();
            this._splitContainer3.ResumeLayout(false);
            this._flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._shapeBindingSource)).EndInit();
            this._tableLayoutPanel2.ResumeLayout(false);
            this._tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource _shapeBindingSource;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel3;
        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip _toolStrip1;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.SplitContainer _splitContainer4;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.SplitContainer _splitContainer3;
        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanel2;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel2;
        private BindToolStripButton _toolStripLineButton;
        private BindToolStripButton _toolStripRectangleButton;
        private BindToolStripButton _toolStripCircleButton;
        private BindToolStripButton _toolStripPointerButton;
        private BindToolStripButton _toolStripUndoButton;
        private BindToolStripButton _toolStripRedoButton;
        private BindToolStripButton _toolStripNewPageButton;
        private BindToolStripButton _toolStripDeletePageButton;
        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanel;
        private BindToolStripButton _toolStripFileSaveButton;
        private BindToolStripButton _toolStripFileLoadButton;
    }
}

