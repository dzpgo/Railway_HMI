namespace HMI_OF_REPOSITORIES
{
    partial class FrmStockStrategyManageOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockStrategyManageOut));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStrategyDetail = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AREA_ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COIL_STRATEGY_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG_ENABLED2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FLOW_TO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MAX2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MIN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MAX2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MIN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvStrategy = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRANE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AREA_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG_MY_DYUTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG_ENABLED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategyDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategy)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.90047F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.09953F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 213F));
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
            this.panel1.Size = new System.Drawing.Size(1364, 79);
            this.panel1.TabIndex = 0;
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Items.AddRange(new object[] {
            "产成品A-1",
            "产成品C-1"});
            this.cmbArea.Location = new System.Drawing.Point(94, 41);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(122, 29);
            this.cmbArea.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 42;
            this.label2.Text = "作业区域：";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnQuery.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnQuery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuery.BackgroundImage")));
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(1224, 31);
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
            this.cmbbCarNO.Items.AddRange(new object[] {
            "1#行车",
            "2#行车",
            "3#行车"});
            this.cmbbCarNO.Location = new System.Drawing.Point(306, 40);
            this.cmbbCarNO.Name = "cmbbCarNO";
            this.cmbbCarNO.Size = new System.Drawing.Size(122, 29);
            this.cmbbCarNO.TabIndex = 39;
            this.cmbbCarNO.SelectedIndexChanged += new System.EventHandler(this.cmbbCarNO_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(226, 43);
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
            this.label1.TabIndex = 41;
            this.label1.Text = "出库策略配置";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStrategyDetail);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 356);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1364, 166);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "找卷位置配置";
            // 
            // dgvStrategyDetail
            // 
            this.dgvStrategyDetail.AllowUserToAddRows = false;
            this.dgvStrategyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrategyDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ID2,
            this.AREA_ID2,
            this.COIL_STRATEGY_ID,
            this.Column5,
            this.FLAG_ENABLED2,
            this.Column7,
            this.Column8,
            this.FLOW_TO2,
            this.DESC2,
            this.Column11,
            this.X_MAX2,
            this.X_MIN2,
            this.Y_MAX2,
            this.Y_MIN2,
            this.Column18,
            this.Column19,
            this.Column20});
            this.dgvStrategyDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStrategyDetail.Location = new System.Drawing.Point(3, 25);
            this.dgvStrategyDetail.Name = "dgvStrategyDetail";
            this.dgvStrategyDetail.RowTemplate.Height = 23;
            this.dgvStrategyDetail.Size = new System.Drawing.Size(1358, 138);
            this.dgvStrategyDetail.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CRANE_NO";
            this.Column1.HeaderText = "行车号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 85;
            // 
            // ID2
            // 
            this.ID2.DataPropertyName = "ID";
            this.ID2.HeaderText = "ID";
            this.ID2.Name = "ID2";
            this.ID2.Width = 70;
            // 
            // AREA_ID2
            // 
            this.AREA_ID2.DataPropertyName = "AREA_ID";
            this.AREA_ID2.HeaderText = "区域号";
            this.AREA_ID2.Name = "AREA_ID2";
            this.AREA_ID2.Width = 85;
            // 
            // COIL_STRATEGY_ID
            // 
            this.COIL_STRATEGY_ID.DataPropertyName = "COIL_STRATEGY_ID";
            this.COIL_STRATEGY_ID.HeaderText = "找卷策略号";
            this.COIL_STRATEGY_ID.Name = "COIL_STRATEGY_ID";
            this.COIL_STRATEGY_ID.Width = 130;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SEQ";
            this.Column5.HeaderText = "执行顺序";
            this.Column5.Name = "Column5";
            // 
            // FLAG_ENABLED2
            // 
            this.FLAG_ENABLED2.DataPropertyName = "FLAG_ENABLED";
            this.FLAG_ENABLED2.HeaderText = "启用标记";
            this.FLAG_ENABLED2.Name = "FLAG_ENABLED2";
            // 
            // Column7
            // 
            this.Column7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column7.HeaderText = "启用";
            this.Column7.Name = "Column7";
            this.Column7.Text = "启用";
            this.Column7.UseColumnTextForButtonValue = true;
            this.Column7.Width = 85;
            // 
            // Column8
            // 
            this.Column8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column8.HeaderText = "关闭";
            this.Column8.Name = "Column8";
            this.Column8.Text = "关闭";
            this.Column8.UseColumnTextForButtonValue = true;
            this.Column8.Width = 85;
            // 
            // FLOW_TO2
            // 
            this.FLOW_TO2.DataPropertyName = "FLOW_TO";
            this.FLOW_TO2.HeaderText = "流向";
            this.FLOW_TO2.Name = "FLOW_TO2";
            this.FLOW_TO2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLOW_TO2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FLOW_TO2.Visible = false;
            this.FLOW_TO2.Width = 70;
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
            // Column11
            // 
            this.Column11.DataPropertyName = "BAY_NO";
            this.Column11.HeaderText = "跨别";
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Width = 70;
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
            // Column18
            // 
            this.Column18.DataPropertyName = "X_DIR";
            this.Column18.HeaderText = "X方向";
            this.Column18.Name = "Column18";
            this.Column18.Width = 85;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "Y_CENTER";
            this.Column19.HeaderText = "Y中心线";
            this.Column19.Name = "Column19";
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "MIN_EMPTY_SADDLES";
            this.Column20.HeaderText = "最少鞍座数量";
            this.Column20.Name = "Column20";
            this.Column20.Width = 140;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvStrategy);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1364, 262);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "行车作业区域配置";
            // 
            // dgvStrategy
            // 
            this.dgvStrategy.AllowUserToAddRows = false;
            this.dgvStrategy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrategy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CRANE_NO,
            this.AREA_ID,
            this.BAY_NO,
            this.X_MAX,
            this.DESC,
            this.X_MIN,
            this.Y_MAX,
            this.Y_MIN,
            this.FLAG_MY_DYUTY,
            this.SEQ,
            this.FLAG_ENABLED,
            this.Column12,
            this.Column13});
            this.dgvStrategy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStrategy.Location = new System.Drawing.Point(3, 25);
            this.dgvStrategy.Name = "dgvStrategy";
            this.dgvStrategy.RowTemplate.Height = 23;
            this.dgvStrategy.Size = new System.Drawing.Size(1358, 234);
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
            // AREA_ID
            // 
            this.AREA_ID.DataPropertyName = "AREA_ID";
            this.AREA_ID.HeaderText = "区域号";
            this.AREA_ID.Name = "AREA_ID";
            // 
            // BAY_NO
            // 
            this.BAY_NO.DataPropertyName = "BAY_NO";
            this.BAY_NO.HeaderText = "跨别";
            this.BAY_NO.Name = "BAY_NO";
            // 
            // X_MAX
            // 
            this.X_MAX.DataPropertyName = "X_MAX";
            this.X_MAX.HeaderText = "X最大坐标";
            this.X_MAX.Name = "X_MAX";
            this.X_MAX.Width = 140;
            // 
            // DESC
            // 
            this.DESC.DataPropertyName = "DESC";
            this.DESC.HeaderText = "描述";
            this.DESC.Name = "DESC";
            this.DESC.Width = 150;
            // 
            // X_MIN
            // 
            this.X_MIN.DataPropertyName = "X_MIN";
            this.X_MIN.HeaderText = "X最小坐标";
            this.X_MIN.Name = "X_MIN";
            this.X_MIN.Width = 140;
            // 
            // Y_MAX
            // 
            this.Y_MAX.DataPropertyName = "Y_MAX";
            this.Y_MAX.HeaderText = "Y最大坐标";
            this.Y_MAX.Name = "Y_MAX";
            this.Y_MAX.Width = 140;
            // 
            // Y_MIN
            // 
            this.Y_MIN.DataPropertyName = "Y_MIN";
            this.Y_MIN.HeaderText = "Y最小坐标";
            this.Y_MIN.Name = "Y_MIN";
            this.Y_MIN.Width = 140;
            // 
            // FLAG_MY_DYUTY
            // 
            this.FLAG_MY_DYUTY.DataPropertyName = "FLAG_MY_DYUTY";
            this.FLAG_MY_DYUTY.HeaderText = "本职工作";
            this.FLAG_MY_DYUTY.Name = "FLAG_MY_DYUTY";
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
            // FrmStockStrategyManageOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 739);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmStockStrategyManageOut";
            this.Text = "出库流向配置";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategyDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cmbbCarNO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvStrategy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRANE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn AREA_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAY_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG_MY_DYUTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG_ENABLED;
        private System.Windows.Forms.DataGridViewButtonColumn Column12;
        private System.Windows.Forms.DataGridViewButtonColumn Column13;
        private System.Windows.Forms.DataGridView dgvStrategyDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CONTROLS_OF_REPOSITORIES.conStockArea conStockArea_D;
        private CONTROLS_OF_REPOSITORIES.conStockArea conStockArea_A;
        private CONTROLS_OF_REPOSITORIES.conStockArea conStockArea_C;
        private CONTROLS_OF_REPOSITORIES.conStockArea conStockArea_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AREA_ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn COIL_STRATEGY_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG_ENABLED2;
        private System.Windows.Forms.DataGridViewButtonColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLOW_TO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MAX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MIN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MAX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MIN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label2;
    }
}