namespace FORMS_OF_REPOSITORIES
{
    partial class FrmCranePlanOper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCranePlanOper));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_OperStatistic = new System.Windows.Forms.RichTextBox();
            this.txt_L3TelAck = new System.Windows.Forms.RichTextBox();
            this.btnResend = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnL3OrderTransfer = new System.Windows.Forms.Button();
            this.btnOrderTransfer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBox_SlctAll = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CHECK_COLUMN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UNIQUE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_GROUP_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRANE_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRANE_MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HG_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRANE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMD_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEL_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPER_USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REC_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPER_EQUIPIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEND_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_ByUniqueID = new System.Windows.Forms.CheckBox();
            this.checkBox_ByRecTime = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1_recTime = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.textBox_stockNo = new System.Windows.Forms.TextBox();
            this.dateTimePicker2_recTime = new System.Windows.Forms.DateTimePicker();
            this.comboBox_craneNo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_matNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.uACS_PLAN_CRANEPLAN_OPERACKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uACS_PLAN_CRANEPLAN_OPERACKBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1362, 733);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1356, 727);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_OperStatistic);
            this.groupBox3.Controls.Add(this.txt_L3TelAck);
            this.groupBox3.Controls.Add(this.btnResend);
            this.groupBox3.Controls.Add(this.btnExport);
            this.groupBox3.Controls.Add(this.btnL3OrderTransfer);
            this.groupBox3.Controls.Add(this.btnOrderTransfer);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 670);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1356, 57);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txt_OperStatistic
            // 
            this.txt_OperStatistic.BackColor = System.Drawing.SystemColors.Control;
            this.txt_OperStatistic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_OperStatistic.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_OperStatistic.Location = new System.Drawing.Point(447, 17);
            this.txt_OperStatistic.Name = "txt_OperStatistic";
            this.txt_OperStatistic.Size = new System.Drawing.Size(421, 37);
            this.txt_OperStatistic.TabIndex = 35;
            this.txt_OperStatistic.Text = "";
            // 
            // txt_L3TelAck
            // 
            this.txt_L3TelAck.BackColor = System.Drawing.SystemColors.Control;
            this.txt_L3TelAck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_L3TelAck.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_L3TelAck.Location = new System.Drawing.Point(3, 17);
            this.txt_L3TelAck.Name = "txt_L3TelAck";
            this.txt_L3TelAck.Size = new System.Drawing.Size(444, 37);
            this.txt_L3TelAck.TabIndex = 34;
            this.txt_L3TelAck.Text = "";
            // 
            // btnResend
            // 
            this.btnResend.BackColor = System.Drawing.Color.White;
            this.btnResend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResend.BackgroundImage")));
            this.btnResend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResend.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResend.ForeColor = System.Drawing.Color.White;
            this.btnResend.Location = new System.Drawing.Point(1049, 17);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(103, 37);
            this.btnResend.TabIndex = 33;
            this.btnResend.Text = "实绩补发";
            this.btnResend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResend.UseVisualStyleBackColor = false;
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1048, 17);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 37);
            this.btnExport.TabIndex = 33;
            this.btnExport.Text = "导出";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnL3OrderTransfer
            // 
            this.btnL3OrderTransfer.BackColor = System.Drawing.Color.White;
            this.btnL3OrderTransfer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnL3OrderTransfer.BackgroundImage")));
            this.btnL3OrderTransfer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnL3OrderTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnL3OrderTransfer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnL3OrderTransfer.ForeColor = System.Drawing.Color.White;
            this.btnL3OrderTransfer.Location = new System.Drawing.Point(1152, 17);
            this.btnL3OrderTransfer.Name = "btnL3OrderTransfer";
            this.btnL3OrderTransfer.Size = new System.Drawing.Size(98, 37);
            this.btnL3OrderTransfer.TabIndex = 33;
            this.btnL3OrderTransfer.Text = "转L3指令";
            this.btnL3OrderTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnL3OrderTransfer.UseVisualStyleBackColor = false;
            this.btnL3OrderTransfer.Visible = false;
            this.btnL3OrderTransfer.Click += new System.EventHandler(this.btnL3OrderTransfer_Click);
            // 
            // btnOrderTransfer
            // 
            this.btnOrderTransfer.BackColor = System.Drawing.Color.White;
            this.btnOrderTransfer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOrderTransfer.BackgroundImage")));
            this.btnOrderTransfer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOrderTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrderTransfer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderTransfer.ForeColor = System.Drawing.Color.White;
            this.btnOrderTransfer.Location = new System.Drawing.Point(1250, 17);
            this.btnOrderTransfer.Name = "btnOrderTransfer";
            this.btnOrderTransfer.Size = new System.Drawing.Size(103, 37);
            this.btnOrderTransfer.TabIndex = 33;
            this.btnOrderTransfer.Text = "转吊运指令";
            this.btnOrderTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrderTransfer.UseVisualStyleBackColor = false;
            this.btnOrderTransfer.Visible = false;
            this.btnOrderTransfer.Click += new System.EventHandler(this.btnOrderTransfer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkBox_SlctAll);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1353, 603);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // chkBox_SlctAll
            // 
            this.chkBox_SlctAll.AutoSize = true;
            this.chkBox_SlctAll.Location = new System.Drawing.Point(20, 35);
            this.chkBox_SlctAll.Name = "chkBox_SlctAll";
            this.chkBox_SlctAll.Size = new System.Drawing.Size(15, 14);
            this.chkBox_SlctAll.TabIndex = 3;
            this.chkBox_SlctAll.UseVisualStyleBackColor = true;
            this.chkBox_SlctAll.CheckedChanged += new System.EventHandler(this.chkBox_SlctAll_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 26;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECK_COLUMN,
            this.UNIQUE_ID,
            this.ORDER_NO,
            this.ORDER_GROUP_NO,
            this.CRANE_SEQ,
            this.CRANE_MODE,
            this.HG_NO,
            this.ORDER_TYPE,
            this.CRANE_NO,
            this.MAT_NO,
            this.STOCK_NO,
            this.X,
            this.Y,
            this.CMD_STATUS,
            this.DEL_FLAG,
            this.OPER_USERNAME,
            this.REC_TIME,
            this.OPER_EQUIPIP,
            this.SEND_FLAG});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1347, 575);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // CHECK_COLUMN
            // 
            this.CHECK_COLUMN.DataPropertyName = "CHECK_COLUMN";
            this.CHECK_COLUMN.FalseValue = "0";
            this.CHECK_COLUMN.HeaderText = "";
            this.CHECK_COLUMN.IndeterminateValue = "0";
            this.CHECK_COLUMN.MinimumWidth = 12;
            this.CHECK_COLUMN.Name = "CHECK_COLUMN";
            this.CHECK_COLUMN.TrueValue = "1";
            this.CHECK_COLUMN.Width = 48;
            // 
            // UNIQUE_ID
            // 
            this.UNIQUE_ID.DataPropertyName = "UNIQUE_ID";
            this.UNIQUE_ID.HeaderText = "实绩流水号";
            this.UNIQUE_ID.Name = "UNIQUE_ID";
            this.UNIQUE_ID.ReadOnly = true;
            this.UNIQUE_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIQUE_ID.Width = 86;
            // 
            // ORDER_NO
            // 
            this.ORDER_NO.DataPropertyName = "ORDER_NO";
            this.ORDER_NO.HeaderText = "吊运指令号";
            this.ORDER_NO.Name = "ORDER_NO";
            this.ORDER_NO.ReadOnly = true;
            this.ORDER_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_NO.Width = 86;
            // 
            // ORDER_GROUP_NO
            // 
            this.ORDER_GROUP_NO.DataPropertyName = "ORDER_GROUP_NO";
            this.ORDER_GROUP_NO.HeaderText = "指令分组号";
            this.ORDER_GROUP_NO.Name = "ORDER_GROUP_NO";
            this.ORDER_GROUP_NO.ReadOnly = true;
            this.ORDER_GROUP_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_GROUP_NO.Width = 86;
            // 
            // CRANE_SEQ
            // 
            this.CRANE_SEQ.DataPropertyName = "CRANE_SEQ";
            this.CRANE_SEQ.HeaderText = "命令顺序号(L3)";
            this.CRANE_SEQ.Name = "CRANE_SEQ";
            this.CRANE_SEQ.ReadOnly = true;
            this.CRANE_SEQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CRANE_SEQ.Width = 120;
            // 
            // CRANE_MODE
            // 
            this.CRANE_MODE.DataPropertyName = "CRANE_MODE";
            this.CRANE_MODE.HeaderText = "吊运模式";
            this.CRANE_MODE.Name = "CRANE_MODE";
            this.CRANE_MODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CRANE_MODE.Width = 86;
            // 
            // HG_NO
            // 
            this.HG_NO.DataPropertyName = "HG_NO";
            this.HG_NO.HeaderText = "处理组(L3)";
            this.HG_NO.Name = "HG_NO";
            this.HG_NO.ReadOnly = true;
            this.HG_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HG_NO.Width = 92;
            // 
            // ORDER_TYPE
            // 
            this.ORDER_TYPE.DataPropertyName = "ORDER_TYPE";
            this.ORDER_TYPE.HeaderText = "吊运事件";
            this.ORDER_TYPE.Name = "ORDER_TYPE";
            this.ORDER_TYPE.ReadOnly = true;
            this.ORDER_TYPE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ORDER_TYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_TYPE.Width = 86;
            // 
            // CRANE_NO
            // 
            this.CRANE_NO.DataPropertyName = "CRANE_NO";
            this.CRANE_NO.HeaderText = "行车号";
            this.CRANE_NO.Name = "CRANE_NO";
            this.CRANE_NO.ReadOnly = true;
            this.CRANE_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CRANE_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CRANE_NO.Width = 78;
            // 
            // MAT_NO
            // 
            this.MAT_NO.DataPropertyName = "MAT_NO";
            this.MAT_NO.HeaderText = "材料号";
            this.MAT_NO.Name = "MAT_NO";
            this.MAT_NO.ReadOnly = true;
            this.MAT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MAT_NO.Width = 120;
            // 
            // STOCK_NO
            // 
            this.STOCK_NO.DataPropertyName = "STOCK_NO";
            this.STOCK_NO.HeaderText = "库位号";
            this.STOCK_NO.Name = "STOCK_NO";
            this.STOCK_NO.ReadOnly = true;
            this.STOCK_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STOCK_NO.Width = 90;
            // 
            // X
            // 
            this.X.DataPropertyName = "X";
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.X.Width = 78;
            // 
            // Y
            // 
            this.Y.DataPropertyName = "Y";
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Y.Width = 78;
            // 
            // CMD_STATUS
            // 
            this.CMD_STATUS.DataPropertyName = "CMD_STATUS";
            this.CMD_STATUS.HeaderText = "状态";
            this.CMD_STATUS.Name = "CMD_STATUS";
            this.CMD_STATUS.ReadOnly = true;
            this.CMD_STATUS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CMD_STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CMD_STATUS.Width = 78;
            // 
            // DEL_FLAG
            // 
            this.DEL_FLAG.DataPropertyName = "DEL_FLAG";
            this.DEL_FLAG.HeaderText = "执行类型";
            this.DEL_FLAG.Name = "DEL_FLAG";
            this.DEL_FLAG.ReadOnly = true;
            this.DEL_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DEL_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DEL_FLAG.Width = 86;
            // 
            // OPER_USERNAME
            // 
            this.OPER_USERNAME.DataPropertyName = "OPER_USERNAME";
            this.OPER_USERNAME.HeaderText = "操作者";
            this.OPER_USERNAME.Name = "OPER_USERNAME";
            this.OPER_USERNAME.ReadOnly = true;
            this.OPER_USERNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OPER_USERNAME.Width = 78;
            // 
            // REC_TIME
            // 
            this.REC_TIME.DataPropertyName = "REC_TIME";
            this.REC_TIME.HeaderText = "操作时间";
            this.REC_TIME.Name = "REC_TIME";
            this.REC_TIME.ReadOnly = true;
            this.REC_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.REC_TIME.Width = 140;
            // 
            // OPER_EQUIPIP
            // 
            this.OPER_EQUIPIP.DataPropertyName = "OPER_EQUIPIP";
            this.OPER_EQUIPIP.HeaderText = "操作终端IP";
            this.OPER_EQUIPIP.Name = "OPER_EQUIPIP";
            this.OPER_EQUIPIP.ReadOnly = true;
            this.OPER_EQUIPIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OPER_EQUIPIP.Width = 120;
            // 
            // SEND_FLAG
            // 
            this.SEND_FLAG.DataPropertyName = "SEND_FLAG";
            this.SEND_FLAG.FalseValue = "0";
            this.SEND_FLAG.HeaderText = "发送标记";
            this.SEND_FLAG.Name = "SEND_FLAG";
            this.SEND_FLAG.ReadOnly = true;
            this.SEND_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SEND_FLAG.TrueValue = "1";
            this.SEND_FLAG.Width = 86;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1356, 61);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox_ByUniqueID);
            this.panel2.Controls.Add(this.checkBox_ByRecTime);
            this.panel2.Controls.Add(this.dateTimePicker1_recTime);
            this.panel2.Controls.Add(this.btnQuery);
            this.panel2.Controls.Add(this.textBox_stockNo);
            this.panel2.Controls.Add(this.dateTimePicker2_recTime);
            this.panel2.Controls.Add(this.comboBox_craneNo);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBox_matNo);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1350, 41);
            this.panel2.TabIndex = 2;
            // 
            // checkBox_ByUniqueID
            // 
            this.checkBox_ByUniqueID.AutoSize = true;
            this.checkBox_ByUniqueID.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_ByUniqueID.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_ByUniqueID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ByUniqueID.Location = new System.Drawing.Point(1001, 8);
            this.checkBox_ByUniqueID.Name = "checkBox_ByUniqueID";
            this.checkBox_ByUniqueID.Size = new System.Drawing.Size(106, 24);
            this.checkBox_ByUniqueID.TabIndex = 39;
            this.checkBox_ByUniqueID.Text = "查询最近8吊";
            this.checkBox_ByUniqueID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_ByUniqueID.UseVisualStyleBackColor = false;
            this.checkBox_ByUniqueID.CheckedChanged += new System.EventHandler(this.checkBox_ByUniqueID_CheckedChanged);
            // 
            // checkBox_ByRecTime
            // 
            this.checkBox_ByRecTime.AutoSize = true;
            this.checkBox_ByRecTime.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_ByRecTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_ByRecTime.Checked = true;
            this.checkBox_ByRecTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ByRecTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ByRecTime.Location = new System.Drawing.Point(520, 8);
            this.checkBox_ByRecTime.Name = "checkBox_ByRecTime";
            this.checkBox_ByRecTime.Size = new System.Drawing.Size(98, 24);
            this.checkBox_ByRecTime.TabIndex = 38;
            this.checkBox_ByRecTime.Text = "按周期查询";
            this.checkBox_ByRecTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_ByRecTime.UseVisualStyleBackColor = false;
            this.checkBox_ByRecTime.CheckedChanged += new System.EventHandler(this.checkBox_ByRecTime_CheckedChanged);
            // 
            // dateTimePicker1_recTime
            // 
            this.dateTimePicker1_recTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1_recTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1_recTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1_recTime.Location = new System.Drawing.Point(623, 7);
            this.dateTimePicker1_recTime.Name = "dateTimePicker1_recTime";
            this.dateTimePicker1_recTime.Size = new System.Drawing.Size(178, 26);
            this.dateTimePicker1_recTime.TabIndex = 30;
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.White;
            this.btnQuery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuery.BackgroundImage")));
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(1258, 0);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(92, 41);
            this.btnQuery.TabIndex = 29;
            this.btnQuery.Text = "查询";
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // textBox_stockNo
            // 
            this.textBox_stockNo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_stockNo.Location = new System.Drawing.Point(418, 8);
            this.textBox_stockNo.Name = "textBox_stockNo";
            this.textBox_stockNo.Size = new System.Drawing.Size(100, 26);
            this.textBox_stockNo.TabIndex = 28;
            // 
            // dateTimePicker2_recTime
            // 
            this.dateTimePicker2_recTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2_recTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2_recTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2_recTime.Location = new System.Drawing.Point(816, 7);
            this.dateTimePicker2_recTime.Name = "dateTimePicker2_recTime";
            this.dateTimePicker2_recTime.Size = new System.Drawing.Size(182, 26);
            this.dateTimePicker2_recTime.TabIndex = 26;
            // 
            // comboBox_craneNo
            // 
            this.comboBox_craneNo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_craneNo.FormattingEnabled = true;
            this.comboBox_craneNo.Location = new System.Drawing.Point(66, 7);
            this.comboBox_craneNo.Name = "comboBox_craneNo";
            this.comboBox_craneNo.Size = new System.Drawing.Size(121, 28);
            this.comboBox_craneNo.TabIndex = 22;
            this.comboBox_craneNo.SelectedIndexChanged += new System.EventHandler(this.comboBox_craneNo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(801, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "~";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_matNo
            // 
            this.textBox_matNo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_matNo.Location = new System.Drawing.Point(254, 8);
            this.textBox_matNo.Name = "textBox_matNo";
            this.textBox_matNo.Size = new System.Drawing.Size(100, 26);
            this.textBox_matNo.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(4, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 21);
            this.label15.TabIndex = 17;
            this.label15.Text = "行车号:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(193, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 21);
            this.label14.TabIndex = 18;
            this.label14.Text = "材料号:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(357, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 21);
            this.label13.TabIndex = 19;
            this.label13.Text = "库位号:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "*.xls";
            this.saveFileDialog1.Filter = "(*.xls)|*.xls";
            // 
            // uACS_PLAN_CRANEPLAN_OPERACKBindingSource
            // 
            this.uACS_PLAN_CRANEPLAN_OPERACKBindingSource.AllowNew = false;
            this.uACS_PLAN_CRANEPLAN_OPERACKBindingSource.DataMember = "UACS_PLAN_CRANEPLAN_OPERACK";
            // 
            // FrmCranePlanOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCranePlanOper";
            this.Text = "吊运实绩信息";
            this.Load += new System.EventHandler(this.CranePlanOper_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uACS_PLAN_CRANEPLAN_OPERACKBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn mATNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRANEINSTCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRANESEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hGNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRANENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMDSTATUSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dELFLAGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPERUSERNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPEREQUIPIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_recTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox textBox_stockNo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2_recTime;
        private System.Windows.Forms.ComboBox comboBox_craneNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_matNo;
        private System.Windows.Forms.BindingSource uACS_PLAN_CRANEPLAN_OPERACKBindingSource;
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagRefresh;
        private System.Windows.Forms.Button btnResend;
        private System.Windows.Forms.Button btnOrderTransfer;
        private System.Windows.Forms.Button btnL3OrderTransfer;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_ByRecTime;
        private System.Windows.Forms.RichTextBox txt_L3TelAck;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkBox_SlctAll;
        private System.Windows.Forms.RichTextBox txt_OperStatistic;
        private System.Windows.Forms.CheckBox checkBox_ByUniqueID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK_COLUMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIQUE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_GROUP_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRANE_SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRANE_MODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HG_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRANE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMD_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEL_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPER_USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REC_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPER_EQUIPIP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SEND_FLAG;
        // private DataSet1TableAdapters.DataTable4TableAdapter dataTable4TableAdapter;
    }
}