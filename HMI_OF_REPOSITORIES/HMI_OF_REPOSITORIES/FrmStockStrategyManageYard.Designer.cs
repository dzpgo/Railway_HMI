namespace HMI_OF_REPOSITORIES
{
    partial class FrmStockStrategyManageYard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockStrategyManageYard));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cmbbCarNO = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.conStockArea_D = new CONTROLS_OF_REPOSITORIES.conStockArea();
            this.conStockArea_A = new CONTROLS_OF_REPOSITORIES.conStockArea();
            this.conStockArea_C = new CONTROLS_OF_REPOSITORIES.conStockArea();
            this.conStockArea_B = new CONTROLS_OF_REPOSITORIES.conStockArea();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSaddleDetail = new System.Windows.Forms.DataGridView();
            this.ID3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAY_NO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MAX3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MIN3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MAX3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MIN3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_DIR3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_CENTER3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIN_EMPTY_SADDLES3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStrategyDetail = new System.Windows.Forms.DataGridView();
            this.ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIST_UNIT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAY_NO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MAX2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MIN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MAX2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MIN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_DIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_CENTER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIN_EMPTY_SADDLES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvStrategy = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRANE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COIL_STRATEGY_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SADDLE_STRATEGY_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG_ENABLED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaddleDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategyDetail)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategy)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 739);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbArea);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.cmbbCarNO);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 82);
            this.panel1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnQuery.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnQuery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuery.BackgroundImage")));
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(1224, 36);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 39);
            this.btnQuery.TabIndex = 40;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cmbbCarNO
            // 
            this.cmbbCarNO.FormattingEnabled = true;
            this.cmbbCarNO.Location = new System.Drawing.Point(311, 46);
            this.cmbbCarNO.Name = "cmbbCarNO";
            this.cmbbCarNO.Size = new System.Drawing.Size(122, 29);
            this.cmbbCarNO.TabIndex = 39;
            this.cmbbCarNO.SelectedIndexChanged += new System.EventHandler(this.cmbbCarNO_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(226, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 38;
            this.label9.Text = "行车号：";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1364, 40);
            this.label1.TabIndex = 42;
            this.label1.Text = "倒垛策略配置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 528);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1364, 208);
            this.panel2.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.conStockArea_D, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conStockArea_A, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.conStockArea_C, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.conStockArea_B, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1364, 208);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // conStockArea_D
            // 
            this.conStockArea_D.AreaName = null;
            this.conStockArea_D.BackColor = System.Drawing.Color.White;
            this.conStockArea_D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conStockArea_D.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conStockArea_D.Location = new System.Drawing.Point(5, 5);
            this.conStockArea_D.Margin = new System.Windows.Forms.Padding(5);
            this.conStockArea_D.Name = "conStockArea_D";
            this.conStockArea_D.Size = new System.Drawing.Size(311, 198);
            this.conStockArea_D.TabIndex = 1;
            // 
            // conStockArea_A
            // 
            this.conStockArea_A.AreaName = null;
            this.conStockArea_A.BackColor = System.Drawing.Color.White;
            this.conStockArea_A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conStockArea_A.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conStockArea_A.Location = new System.Drawing.Point(1028, 5);
            this.conStockArea_A.Margin = new System.Windows.Forms.Padding(5);
            this.conStockArea_A.Name = "conStockArea_A";
            this.conStockArea_A.Size = new System.Drawing.Size(311, 198);
            this.conStockArea_A.TabIndex = 0;
            // 
            // conStockArea_C
            // 
            this.conStockArea_C.AreaName = null;
            this.conStockArea_C.BackColor = System.Drawing.Color.White;
            this.conStockArea_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conStockArea_C.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conStockArea_C.Location = new System.Drawing.Point(346, 5);
            this.conStockArea_C.Margin = new System.Windows.Forms.Padding(5);
            this.conStockArea_C.Name = "conStockArea_C";
            this.conStockArea_C.Size = new System.Drawing.Size(311, 198);
            this.conStockArea_C.TabIndex = 2;
            // 
            // conStockArea_B
            // 
            this.conStockArea_B.AreaName = null;
            this.conStockArea_B.BackColor = System.Drawing.Color.White;
            this.conStockArea_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conStockArea_B.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conStockArea_B.Location = new System.Drawing.Point(687, 5);
            this.conStockArea_B.Margin = new System.Windows.Forms.Padding(5);
            this.conStockArea_B.Name = "conStockArea_B";
            this.conStockArea_B.Size = new System.Drawing.Size(311, 198);
            this.conStockArea_B.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 266);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1364, 256);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSaddleDetail);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(685, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(676, 250);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "找空鞍座位置";
            // 
            // dgvSaddleDetail
            // 
            this.dgvSaddleDetail.AllowUserToAddRows = false;
            this.dgvSaddleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaddleDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID3,
            this.DESC3,
            this.BAY_NO3,
            this.X_MAX3,
            this.X_MIN3,
            this.Y_MAX3,
            this.Y_MIN3,
            this.X_DIR3,
            this.Y_CENTER3,
            this.MIN_EMPTY_SADDLES3});
            this.dgvSaddleDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSaddleDetail.Location = new System.Drawing.Point(3, 25);
            this.dgvSaddleDetail.Name = "dgvSaddleDetail";
            this.dgvSaddleDetail.RowTemplate.Height = 23;
            this.dgvSaddleDetail.Size = new System.Drawing.Size(670, 222);
            this.dgvSaddleDetail.TabIndex = 5;
            // 
            // ID3
            // 
            this.ID3.DataPropertyName = "ID";
            this.ID3.HeaderText = "ID";
            this.ID3.Name = "ID3";
            this.ID3.Width = 70;
            // 
            // DESC3
            // 
            this.DESC3.DataPropertyName = "DESC";
            this.DESC3.HeaderText = "描述";
            this.DESC3.Name = "DESC3";
            this.DESC3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DESC3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DESC3.Width = 150;
            // 
            // BAY_NO3
            // 
            this.BAY_NO3.DataPropertyName = "BAY_NO";
            this.BAY_NO3.HeaderText = "跨别";
            this.BAY_NO3.Name = "BAY_NO3";
            // 
            // X_MAX3
            // 
            this.X_MAX3.DataPropertyName = "X_MAX";
            this.X_MAX3.HeaderText = "X最大坐标";
            this.X_MAX3.Name = "X_MAX3";
            this.X_MAX3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.X_MAX3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.X_MAX3.Width = 120;
            // 
            // X_MIN3
            // 
            this.X_MIN3.DataPropertyName = "X_MIN";
            this.X_MIN3.HeaderText = "X最小坐标";
            this.X_MIN3.Name = "X_MIN3";
            this.X_MIN3.Width = 120;
            // 
            // Y_MAX3
            // 
            this.Y_MAX3.DataPropertyName = "Y_MAX";
            this.Y_MAX3.HeaderText = "Y最大坐标";
            this.Y_MAX3.Name = "Y_MAX3";
            this.Y_MAX3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Y_MAX3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Y_MAX3.Width = 120;
            // 
            // Y_MIN3
            // 
            this.Y_MIN3.DataPropertyName = "Y_MIN";
            this.Y_MIN3.HeaderText = "Y最小坐标";
            this.Y_MIN3.Name = "Y_MIN3";
            this.Y_MIN3.Width = 120;
            // 
            // X_DIR3
            // 
            this.X_DIR3.DataPropertyName = "X_DIR";
            this.X_DIR3.HeaderText = "X方向";
            this.X_DIR3.Name = "X_DIR3";
            this.X_DIR3.Width = 85;
            // 
            // Y_CENTER3
            // 
            this.Y_CENTER3.DataPropertyName = "Y_CENTER";
            this.Y_CENTER3.HeaderText = "Y中心线";
            this.Y_CENTER3.Name = "Y_CENTER3";
            // 
            // MIN_EMPTY_SADDLES3
            // 
            this.MIN_EMPTY_SADDLES3.DataPropertyName = "MIN_EMPTY_SADDLES";
            this.MIN_EMPTY_SADDLES3.HeaderText = "最少鞍座数量";
            this.MIN_EMPTY_SADDLES3.Name = "MIN_EMPTY_SADDLES3";
            this.MIN_EMPTY_SADDLES3.Width = 140;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStrategyDetail);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "找卷位置配置";
            // 
            // dgvStrategyDetail
            // 
            this.dgvStrategyDetail.AllowUserToAddRows = false;
            this.dgvStrategyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrategyDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID2,
            this.DESC2,
            this.LIST_UNIT_NO,
            this.BAY_NO2,
            this.X_MAX2,
            this.X_MIN2,
            this.Y_MAX2,
            this.Y_MIN2,
            this.X_DIR,
            this.Y_CENTER,
            this.MIN_EMPTY_SADDLES});
            this.dgvStrategyDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStrategyDetail.Location = new System.Drawing.Point(3, 25);
            this.dgvStrategyDetail.Name = "dgvStrategyDetail";
            this.dgvStrategyDetail.RowTemplate.Height = 23;
            this.dgvStrategyDetail.Size = new System.Drawing.Size(670, 222);
            this.dgvStrategyDetail.TabIndex = 5;
            // 
            // ID2
            // 
            this.ID2.DataPropertyName = "ID";
            this.ID2.HeaderText = "ID";
            this.ID2.Name = "ID2";
            this.ID2.Width = 70;
            // 
            // DESC2
            // 
            this.DESC2.DataPropertyName = "DESC";
            this.DESC2.HeaderText = "描述";
            this.DESC2.Name = "DESC2";
            this.DESC2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DESC2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DESC2.Width = 150;
            // 
            // LIST_UNIT_NO
            // 
            this.LIST_UNIT_NO.DataPropertyName = "LIST_UNIT_NO";
            this.LIST_UNIT_NO.HeaderText = "流向";
            this.LIST_UNIT_NO.Name = "LIST_UNIT_NO";
            // 
            // BAY_NO2
            // 
            this.BAY_NO2.DataPropertyName = "BAY_NO";
            this.BAY_NO2.HeaderText = "跨别";
            this.BAY_NO2.Name = "BAY_NO2";
            // 
            // X_MAX2
            // 
            this.X_MAX2.DataPropertyName = "X_MAX";
            this.X_MAX2.HeaderText = "X最大坐标";
            this.X_MAX2.Name = "X_MAX2";
            this.X_MAX2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.X_MAX2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.X_MAX2.Width = 120;
            // 
            // X_MIN2
            // 
            this.X_MIN2.DataPropertyName = "X_MIN";
            this.X_MIN2.HeaderText = "X最小坐标";
            this.X_MIN2.Name = "X_MIN2";
            this.X_MIN2.Width = 120;
            // 
            // Y_MAX2
            // 
            this.Y_MAX2.DataPropertyName = "Y_MAX";
            this.Y_MAX2.HeaderText = "Y最大坐标";
            this.Y_MAX2.Name = "Y_MAX2";
            this.Y_MAX2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Y_MAX2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Y_MAX2.Width = 120;
            // 
            // Y_MIN2
            // 
            this.Y_MIN2.DataPropertyName = "Y_MIN";
            this.Y_MIN2.HeaderText = "Y最小坐标";
            this.Y_MIN2.Name = "Y_MIN2";
            this.Y_MIN2.Width = 120;
            // 
            // X_DIR
            // 
            this.X_DIR.DataPropertyName = "X_DIR";
            this.X_DIR.HeaderText = "X方向";
            this.X_DIR.Name = "X_DIR";
            this.X_DIR.Width = 85;
            // 
            // Y_CENTER
            // 
            this.Y_CENTER.DataPropertyName = "Y_CENTER";
            this.Y_CENTER.HeaderText = "Y中心线";
            this.Y_CENTER.Name = "Y_CENTER";
            // 
            // MIN_EMPTY_SADDLES
            // 
            this.MIN_EMPTY_SADDLES.DataPropertyName = "MIN_EMPTY_SADDLES";
            this.MIN_EMPTY_SADDLES.HeaderText = "最少鞍座数量";
            this.MIN_EMPTY_SADDLES.Name = "MIN_EMPTY_SADDLES";
            this.MIN_EMPTY_SADDLES.Width = 140;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvStrategy);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1364, 169);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "行车作业区域配置";
            // 
            // dgvStrategy
            // 
            this.dgvStrategy.AllowUserToAddRows = false;
            this.dgvStrategy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrategy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CRANE_NO,
            this.COIL_STRATEGY_ID,
            this.SADDLE_STRATEGY_ID,
            this.SEQ,
            this.FLAG_ENABLED,
            this.Column12,
            this.Column13});
            this.dgvStrategy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStrategy.Location = new System.Drawing.Point(3, 25);
            this.dgvStrategy.Name = "dgvStrategy";
            this.dgvStrategy.RowTemplate.Height = 23;
            this.dgvStrategy.Size = new System.Drawing.Size(1358, 141);
            this.dgvStrategy.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // CRANE_NO
            // 
            this.CRANE_NO.DataPropertyName = "CRANE_NO";
            this.CRANE_NO.HeaderText = "行车号";
            this.CRANE_NO.Name = "CRANE_NO";
            // 
            // COIL_STRATEGY_ID
            // 
            this.COIL_STRATEGY_ID.DataPropertyName = "COIL_STRATEGY_ID";
            this.COIL_STRATEGY_ID.HeaderText = "找卷策略号";
            this.COIL_STRATEGY_ID.Name = "COIL_STRATEGY_ID";
            this.COIL_STRATEGY_ID.Width = 150;
            // 
            // SADDLE_STRATEGY_ID
            // 
            this.SADDLE_STRATEGY_ID.DataPropertyName = "SADDLE_STRATEGY_ID";
            this.SADDLE_STRATEGY_ID.HeaderText = "找鞍座策略号";
            this.SADDLE_STRATEGY_ID.Name = "SADDLE_STRATEGY_ID";
            this.SADDLE_STRATEGY_ID.Width = 150;
            // 
            // SEQ
            // 
            this.SEQ.DataPropertyName = "SEQ";
            this.SEQ.HeaderText = "执行顺序";
            this.SEQ.Name = "SEQ";
            // 
            // FLAG_ENABLED
            // 
            this.FLAG_ENABLED.DataPropertyName = "FLAG_ENABLED";
            this.FLAG_ENABLED.HeaderText = "启用标记";
            this.FLAG_ENABLED.Name = "FLAG_ENABLED";
            // 
            // Column12
            // 
            this.Column12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column12.HeaderText = "启用";
            this.Column12.Name = "Column12";
            this.Column12.Text = "启用";
            this.Column12.UseColumnTextForButtonValue = true;
            // 
            // Column13
            // 
            this.Column13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column13.HeaderText = "关闭";
            this.Column13.Name = "Column13";
            this.Column13.Text = "关闭";
            this.Column13.UseColumnTextForButtonValue = true;
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Items.AddRange(new object[] {
            "产成品A-1",
            "产成品C-1"});
            this.cmbArea.Location = new System.Drawing.Point(88, 46);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(122, 29);
            this.cmbArea.TabIndex = 44;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 43;
            this.label2.Text = "作业区域：";
            // 
            // FrmStockStrategyManageYard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 739);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmStockStrategyManageYard";
            this.Text = "库内倒垛策略";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaddleDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategyDetail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cmbbCarNO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStrategy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CONTROLS_OF_REPOSITORIES.conStockArea conStockArea_D;
        private CONTROLS_OF_REPOSITORIES.conStockArea conStockArea_A;
        private CONTROLS_OF_REPOSITORIES.conStockArea conStockArea_C;
        private CONTROLS_OF_REPOSITORIES.conStockArea conStockArea_B;
        private System.Windows.Forms.DataGridView dgvStrategyDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSaddleDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRANE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COIL_STRATEGY_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SADDLE_STRATEGY_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG_ENABLED;
        private System.Windows.Forms.DataGridViewButtonColumn Column12;
        private System.Windows.Forms.DataGridViewButtonColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIST_UNIT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAY_NO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MAX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MIN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MAX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MIN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_DIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_CENTER;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIN_EMPTY_SADDLES;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAY_NO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MAX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MIN3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MAX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MIN3;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_DIR3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_CENTER3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIN_EMPTY_SADDLES3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label2;
    }
}