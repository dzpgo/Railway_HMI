namespace FORMS_OF_REPOSITORIES
{
    partial class FrmCranePlanManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCranePlanManage));
            this.dateTimePicker2_recTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1_recTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.combox_craneInstCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_matNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CHECK_COLUMN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SEQ1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIRST_JOB = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PLAN_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_GROUP_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRANE_NO = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BAY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_PRIORITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FROM_STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TO_STOCK_NO = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CMD_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG_DISPAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REC_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPD_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEL_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG_DEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISPAT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISPAT_ACK_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uACS_PLAN_CRANPLANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_query = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.button_createorder = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ckBoxAutoReflesh = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBoxBayNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBoxCmdStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBoxCraneNo = new System.Windows.Forms.ComboBox();
            this.lbArea = new System.Windows.Forms.Label();
            this.cbBoxArea = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_Z51 = new System.Windows.Forms.CheckBox();
            this.checkBox_Z53 = new System.Windows.Forms.CheckBox();
            this.checkBox_Z52 = new System.Windows.Forms.CheckBox();
            this.checkBox_Z33 = new System.Windows.Forms.CheckBox();
            this.checkBox_Z32 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uACS_PLAN_CRANPLANBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker2_recTime
            // 
            this.dateTimePicker2_recTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker2_recTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2_recTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2_recTime.Location = new System.Drawing.Point(327, 43);
            this.dateTimePicker2_recTime.Name = "dateTimePicker2_recTime";
            this.dateTimePicker2_recTime.Size = new System.Drawing.Size(190, 29);
            this.dateTimePicker2_recTime.TabIndex = 8;
            this.dateTimePicker2_recTime.ValueChanged += new System.EventHandler(this.dateTimePicker2_recTime_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(299, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "~";
            // 
            // dateTimePicker1_recTime
            // 
            this.dateTimePicker1_recTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker1_recTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1_recTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1_recTime.Location = new System.Drawing.Point(102, 43);
            this.dateTimePicker1_recTime.Name = "dateTimePicker1_recTime";
            this.dateTimePicker1_recTime.Size = new System.Drawing.Size(191, 29);
            this.dateTimePicker1_recTime.TabIndex = 6;
            this.dateTimePicker1_recTime.ValueChanged += new System.EventHandler(this.dateTimePicker1_recTime_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "创建时间:";
            // 
            // combox_craneInstCode
            // 
            this.combox_craneInstCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combox_craneInstCode.FormattingEnabled = true;
            this.combox_craneInstCode.Location = new System.Drawing.Point(333, 8);
            this.combox_craneInstCode.Name = "combox_craneInstCode";
            this.combox_craneInstCode.Size = new System.Drawing.Size(121, 29);
            this.combox_craneInstCode.TabIndex = 4;
            this.combox_craneInstCode.SelectedIndexChanged += new System.EventHandler(this.combox_craneInstCode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(253, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "指令类型:";
            // 
            // textbox_matNo
            // 
            this.textbox_matNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textbox_matNo.Location = new System.Drawing.Point(778, 8);
            this.textbox_matNo.Name = "textbox_matNo";
            this.textbox_matNo.Size = new System.Drawing.Size(100, 29);
            this.textbox_matNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(708, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "材料号:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECK_COLUMN,
            this.SEQ1,
            this.SEQ2,
            this.SEQ3,
            this.SEQ4,
            this.SEQ5,
            this.FIRST_JOB,
            this.PLAN_NO,
            this.ORDER_NO,
            this.ORDER_GROUP_NO,
            this.CRANE_NO,
            this.BAY_NO,
            this.MAT_NO,
            this.ORDER_TYPE,
            this.ORDER_PRIORITY,
            this.SEQ,
            this.FROM_STOCK_NO,
            this.TO_STOCK_NO,
            this.CMD_STATUS,
            this.FLAG_DISPAT,
            this.REC_TIME,
            this.UPD_TIME,
            this.DEL_TIME,
            this.FLAG_DEL,
            this.DISPAT_TIME,
            this.DISPAT_ACK_TIME});
            this.dataGridView1.DataSource = this.uACS_PLAN_CRANPLANBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 83);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1146, 395);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // CHECK_COLUMN
            // 
            this.CHECK_COLUMN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CHECK_COLUMN.DataPropertyName = "CHECK_COLUMN";
            this.CHECK_COLUMN.FalseValue = "0";
            this.CHECK_COLUMN.HeaderText = "选择";
            this.CHECK_COLUMN.Name = "CHECK_COLUMN";
            this.CHECK_COLUMN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHECK_COLUMN.TrueValue = "1";
            this.CHECK_COLUMN.Width = 55;
            // 
            // SEQ1
            // 
            this.SEQ1.HeaderText = "SEQ1";
            this.SEQ1.Name = "SEQ1";
            this.SEQ1.Visible = false;
            this.SEQ1.Width = 65;
            // 
            // SEQ2
            // 
            this.SEQ2.HeaderText = "SEQ2";
            this.SEQ2.Name = "SEQ2";
            this.SEQ2.Visible = false;
            this.SEQ2.Width = 65;
            // 
            // SEQ3
            // 
            this.SEQ3.HeaderText = "SEQ3";
            this.SEQ3.Name = "SEQ3";
            this.SEQ3.Visible = false;
            this.SEQ3.Width = 65;
            // 
            // SEQ4
            // 
            this.SEQ4.HeaderText = "SEQ4";
            this.SEQ4.Name = "SEQ4";
            this.SEQ4.Visible = false;
            this.SEQ4.Width = 65;
            // 
            // SEQ5
            // 
            this.SEQ5.HeaderText = "SEQ5";
            this.SEQ5.Name = "SEQ5";
            this.SEQ5.Visible = false;
            this.SEQ5.Width = 65;
            // 
            // FIRST_JOB
            // 
            this.FIRST_JOB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FIRST_JOB.DataPropertyName = "FIRST_JOB";
            this.FIRST_JOB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FIRST_JOB.HeaderText = "FIRST JOB";
            this.FIRST_JOB.Name = "FIRST_JOB";
            this.FIRST_JOB.ReadOnly = true;
            this.FIRST_JOB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FIRST_JOB.Text = "FIRST JOB";
            this.FIRST_JOB.Width = 92;
            // 
            // PLAN_NO
            // 
            this.PLAN_NO.DataPropertyName = "PLAN_NO";
            this.PLAN_NO.HeaderText = "L3吊运指令号";
            this.PLAN_NO.Name = "PLAN_NO";
            this.PLAN_NO.ReadOnly = true;
            this.PLAN_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PLAN_NO.Width = 113;
            // 
            // ORDER_NO
            // 
            this.ORDER_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ORDER_NO.DataPropertyName = "ORDER_NO";
            this.ORDER_NO.HeaderText = "指令号";
            this.ORDER_NO.Name = "ORDER_NO";
            this.ORDER_NO.ReadOnly = true;
            this.ORDER_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_NO.Width = 64;
            // 
            // ORDER_GROUP_NO
            // 
            this.ORDER_GROUP_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ORDER_GROUP_NO.DataPropertyName = "ORDER_GROUP_NO";
            this.ORDER_GROUP_NO.HeaderText = "处理组";
            this.ORDER_GROUP_NO.Name = "ORDER_GROUP_NO";
            this.ORDER_GROUP_NO.ReadOnly = true;
            this.ORDER_GROUP_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_GROUP_NO.Width = 64;
            // 
            // CRANE_NO
            // 
            this.CRANE_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CRANE_NO.DataPropertyName = "CRANE_NO";
            this.CRANE_NO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CRANE_NO.HeaderText = "行车号";
            this.CRANE_NO.Name = "CRANE_NO";
            this.CRANE_NO.ReadOnly = true;
            this.CRANE_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CRANE_NO.Width = 64;
            // 
            // BAY_NO
            // 
            this.BAY_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BAY_NO.DataPropertyName = "BAY_NO";
            this.BAY_NO.HeaderText = "跨别";
            this.BAY_NO.Name = "BAY_NO";
            this.BAY_NO.ReadOnly = true;
            this.BAY_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BAY_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BAY_NO.Width = 48;
            // 
            // MAT_NO
            // 
            this.MAT_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MAT_NO.DataPropertyName = "MAT_NO";
            this.MAT_NO.HeaderText = "材料号";
            this.MAT_NO.Name = "MAT_NO";
            this.MAT_NO.ReadOnly = true;
            this.MAT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MAT_NO.Width = 64;
            // 
            // ORDER_TYPE
            // 
            this.ORDER_TYPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ORDER_TYPE.DataPropertyName = "ORDER_TYPE";
            this.ORDER_TYPE.HeaderText = "指令类型";
            this.ORDER_TYPE.Name = "ORDER_TYPE";
            this.ORDER_TYPE.ReadOnly = true;
            this.ORDER_TYPE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ORDER_TYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_TYPE.Width = 80;
            // 
            // ORDER_PRIORITY
            // 
            this.ORDER_PRIORITY.DataPropertyName = "ORDER_PRIORITY";
            this.ORDER_PRIORITY.HeaderText = "优先级";
            this.ORDER_PRIORITY.Name = "ORDER_PRIORITY";
            this.ORDER_PRIORITY.ReadOnly = true;
            this.ORDER_PRIORITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_PRIORITY.Width = 64;
            // 
            // SEQ
            // 
            this.SEQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SEQ.DataPropertyName = "SEQ";
            this.SEQ.HeaderText = "行车指令顺";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            this.SEQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SEQ.Width = 96;
            // 
            // FROM_STOCK_NO
            // 
            this.FROM_STOCK_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FROM_STOCK_NO.DataPropertyName = "FROM_STOCK_NO";
            this.FROM_STOCK_NO.HeaderText = "起吊库位";
            this.FROM_STOCK_NO.Name = "FROM_STOCK_NO";
            this.FROM_STOCK_NO.ReadOnly = true;
            this.FROM_STOCK_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FROM_STOCK_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FROM_STOCK_NO.Width = 80;
            // 
            // TO_STOCK_NO
            // 
            this.TO_STOCK_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TO_STOCK_NO.DataPropertyName = "TO_STOCK_NO";
            this.TO_STOCK_NO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TO_STOCK_NO.HeaderText = "卸下库位";
            this.TO_STOCK_NO.Name = "TO_STOCK_NO";
            this.TO_STOCK_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TO_STOCK_NO.Width = 80;
            // 
            // CMD_STATUS
            // 
            this.CMD_STATUS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CMD_STATUS.DataPropertyName = "CMD_STATUS";
            this.CMD_STATUS.HeaderText = "作业状态";
            this.CMD_STATUS.Name = "CMD_STATUS";
            this.CMD_STATUS.ReadOnly = true;
            this.CMD_STATUS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CMD_STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CMD_STATUS.Width = 80;
            // 
            // FLAG_DISPAT
            // 
            this.FLAG_DISPAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FLAG_DISPAT.DataPropertyName = "FLAG_DISPAT";
            this.FLAG_DISPAT.HeaderText = "指令确认标记";
            this.FLAG_DISPAT.Name = "FLAG_DISPAT";
            this.FLAG_DISPAT.ReadOnly = true;
            this.FLAG_DISPAT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLAG_DISPAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FLAG_DISPAT.Width = 112;
            // 
            // REC_TIME
            // 
            this.REC_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.REC_TIME.DataPropertyName = "REC_TIME";
            this.REC_TIME.HeaderText = "创建时间";
            this.REC_TIME.Name = "REC_TIME";
            this.REC_TIME.ReadOnly = true;
            this.REC_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.REC_TIME.Width = 80;
            // 
            // UPD_TIME
            // 
            this.UPD_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UPD_TIME.DataPropertyName = "UPD_TIME";
            this.UPD_TIME.HeaderText = "更新时间";
            this.UPD_TIME.Name = "UPD_TIME";
            this.UPD_TIME.ReadOnly = true;
            this.UPD_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UPD_TIME.Width = 80;
            // 
            // DEL_TIME
            // 
            this.DEL_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DEL_TIME.DataPropertyName = "DEL_TIME";
            this.DEL_TIME.HeaderText = "删除时间";
            this.DEL_TIME.Name = "DEL_TIME";
            this.DEL_TIME.ReadOnly = true;
            this.DEL_TIME.Width = 99;
            // 
            // FLAG_DEL
            // 
            this.FLAG_DEL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FLAG_DEL.DataPropertyName = "FLAG_DEL";
            this.FLAG_DEL.HeaderText = "删除标识";
            this.FLAG_DEL.Name = "FLAG_DEL";
            this.FLAG_DEL.ReadOnly = true;
            this.FLAG_DEL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLAG_DEL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FLAG_DEL.Width = 80;
            // 
            // DISPAT_TIME
            // 
            this.DISPAT_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DISPAT_TIME.DataPropertyName = "DISPAT_TIME";
            this.DISPAT_TIME.HeaderText = "下发时间";
            this.DISPAT_TIME.Name = "DISPAT_TIME";
            this.DISPAT_TIME.ReadOnly = true;
            this.DISPAT_TIME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DISPAT_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DISPAT_TIME.Width = 80;
            // 
            // DISPAT_ACK_TIME
            // 
            this.DISPAT_ACK_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DISPAT_ACK_TIME.DataPropertyName = "DISPAT_ACK_TIME";
            this.DISPAT_ACK_TIME.HeaderText = "模型应答时间";
            this.DISPAT_ACK_TIME.Name = "DISPAT_ACK_TIME";
            this.DISPAT_ACK_TIME.ReadOnly = true;
            this.DISPAT_ACK_TIME.Width = 131;
            // 
            // uACS_PLAN_CRANPLANBindingSource
            // 
            this.uACS_PLAN_CRANPLANBindingSource.DataMember = "UACS_PLAN_CRANPLAN";
            // 
            // button_query
            // 
            this.button_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_query.BackColor = System.Drawing.Color.White;
            this.button_query.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_query.BackgroundImage")));
            this.button_query.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_query.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_query.ForeColor = System.Drawing.Color.White;
            this.button_query.Image = ((System.Drawing.Image)(resources.GetObject("button_query.Image")));
            this.button_query.Location = new System.Drawing.Point(1040, 29);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(97, 38);
            this.button_query.TabIndex = 14;
            this.button_query.Text = "查询";
            this.button_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_query.UseVisualStyleBackColor = false;
            this.button_query.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.BackColor = System.Drawing.Color.White;
            this.btnMerge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMerge.BackgroundImage")));
            this.btnMerge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMerge.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMerge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerge.ForeColor = System.Drawing.Color.White;
            this.btnMerge.Location = new System.Drawing.Point(804, 0);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(114, 44);
            this.btnMerge.TabIndex = 15;
            this.btnMerge.Text = "下发";
            this.btnMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMerge.UseVisualStyleBackColor = false;
            this.btnMerge.Visible = false;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // button_createorder
            // 
            this.button_createorder.BackColor = System.Drawing.Color.White;
            this.button_createorder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_createorder.BackgroundImage")));
            this.button_createorder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_createorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_createorder.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_createorder.ForeColor = System.Drawing.Color.White;
            this.button_createorder.Location = new System.Drawing.Point(1032, 0);
            this.button_createorder.Name = "button_createorder";
            this.button_createorder.Size = new System.Drawing.Size(114, 44);
            this.button_createorder.TabIndex = 16;
            this.button_createorder.Text = "生成指令";
            this.button_createorder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_createorder.UseVisualStyleBackColor = false;
            this.button_createorder.Visible = false;
            this.button_createorder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(918, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 44);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ckBoxAutoReflesh
            // 
            this.ckBoxAutoReflesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckBoxAutoReflesh.AutoSize = true;
            this.ckBoxAutoReflesh.BackColor = System.Drawing.Color.Transparent;
            this.ckBoxAutoReflesh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckBoxAutoReflesh.Location = new System.Drawing.Point(939, 42);
            this.ckBoxAutoReflesh.Name = "ckBoxAutoReflesh";
            this.ckBoxAutoReflesh.Size = new System.Drawing.Size(93, 25);
            this.ckBoxAutoReflesh.TabIndex = 33;
            this.ckBoxAutoReflesh.Text = "自动刷新";
            this.ckBoxAutoReflesh.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(48, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 34;
            this.label6.Text = "跨别:";
            this.label6.Visible = false;
            // 
            // cbBoxBayNo
            // 
            this.cbBoxBayNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxBayNo.FormattingEnabled = true;
            this.cbBoxBayNo.Location = new System.Drawing.Point(102, 11);
            this.cbBoxBayNo.Name = "cbBoxBayNo";
            this.cbBoxBayNo.Size = new System.Drawing.Size(121, 29);
            this.cbBoxBayNo.TabIndex = 35;
            this.cbBoxBayNo.Visible = false;
            this.cbBoxBayNo.SelectedValueChanged += new System.EventHandler(this.cbBoxBayNo_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(234, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 21);
            this.label7.TabIndex = 40;
            this.label7.Text = "作业状态:";
            this.label7.Visible = false;
            // 
            // cbBoxCmdStatus
            // 
            this.cbBoxCmdStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxCmdStatus.FormattingEnabled = true;
            this.cbBoxCmdStatus.Location = new System.Drawing.Point(320, 8);
            this.cbBoxCmdStatus.Name = "cbBoxCmdStatus";
            this.cbBoxCmdStatus.Size = new System.Drawing.Size(121, 29);
            this.cbBoxCmdStatus.TabIndex = 41;
            this.cbBoxCmdStatus.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 42;
            this.label1.Text = "行车号:";
            // 
            // cbBoxCraneNo
            // 
            this.cbBoxCraneNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxCraneNo.FormattingEnabled = true;
            this.cbBoxCraneNo.Location = new System.Drawing.Point(103, 8);
            this.cbBoxCraneNo.Name = "cbBoxCraneNo";
            this.cbBoxCraneNo.Size = new System.Drawing.Size(121, 29);
            this.cbBoxCraneNo.TabIndex = 43;
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.BackColor = System.Drawing.Color.Transparent;
            this.lbArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbArea.Location = new System.Drawing.Point(501, 11);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(46, 21);
            this.lbArea.TabIndex = 44;
            this.lbArea.Text = "区域:";
            // 
            // cbBoxArea
            // 
            this.cbBoxArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxArea.FormattingEnabled = true;
            this.cbBoxArea.Location = new System.Drawing.Point(555, 8);
            this.cbBoxArea.Name = "cbBoxArea";
            this.cbBoxArea.Size = new System.Drawing.Size(121, 29);
            this.cbBoxArea.TabIndex = 45;
            this.cbBoxArea.SelectedValueChanged += new System.EventHandler(this.cbBoxArea_SelectedValueChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_Z51);
            this.panel1.Controls.Add(this.checkBox_Z53);
            this.panel1.Controls.Add(this.checkBox_Z52);
            this.panel1.Controls.Add(this.checkBox_Z33);
            this.panel1.Controls.Add(this.checkBox_Z32);
            this.panel1.Controls.Add(this.lbArea);
            this.panel1.Controls.Add(this.cbBoxArea);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.combox_craneInstCode);
            this.panel1.Controls.Add(this.cbBoxCraneNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textbox_matNo);
            this.panel1.Controls.Add(this.dateTimePicker2_recTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ckBoxAutoReflesh);
            this.panel1.Controls.Add(this.dateTimePicker1_recTime);
            this.panel1.Controls.Add(this.button_query);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 74);
            this.panel1.TabIndex = 16;
            // 
            // checkBox_Z51
            // 
            this.checkBox_Z51.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Z51.AutoSize = true;
            this.checkBox_Z51.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Z51.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Z51.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox_Z51.Location = new System.Drawing.Point(562, 42);
            this.checkBox_Z51.Name = "checkBox_Z51";
            this.checkBox_Z51.Size = new System.Drawing.Size(73, 25);
            this.checkBox_Z51.TabIndex = 50;
            this.checkBox_Z51.Text = "Z51库";
            this.checkBox_Z51.UseVisualStyleBackColor = false;
            // 
            // checkBox_Z53
            // 
            this.checkBox_Z53.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Z53.AutoSize = true;
            this.checkBox_Z53.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Z53.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Z53.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox_Z53.Location = new System.Drawing.Point(712, 42);
            this.checkBox_Z53.Name = "checkBox_Z53";
            this.checkBox_Z53.Size = new System.Drawing.Size(73, 25);
            this.checkBox_Z53.TabIndex = 49;
            this.checkBox_Z53.Text = "Z53库";
            this.checkBox_Z53.UseVisualStyleBackColor = false;
            // 
            // checkBox_Z52
            // 
            this.checkBox_Z52.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Z52.AutoSize = true;
            this.checkBox_Z52.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Z52.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Z52.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox_Z52.Location = new System.Drawing.Point(638, 42);
            this.checkBox_Z52.Name = "checkBox_Z52";
            this.checkBox_Z52.Size = new System.Drawing.Size(73, 25);
            this.checkBox_Z52.TabIndex = 48;
            this.checkBox_Z52.Text = "Z52库";
            this.checkBox_Z52.UseVisualStyleBackColor = false;
            // 
            // checkBox_Z33
            // 
            this.checkBox_Z33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Z33.AutoSize = true;
            this.checkBox_Z33.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Z33.Checked = true;
            this.checkBox_Z33.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Z33.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Z33.Location = new System.Drawing.Point(860, 42);
            this.checkBox_Z33.Name = "checkBox_Z33";
            this.checkBox_Z33.Size = new System.Drawing.Size(73, 25);
            this.checkBox_Z33.TabIndex = 47;
            this.checkBox_Z33.Text = "Z33库";
            this.checkBox_Z33.UseVisualStyleBackColor = false;
            // 
            // checkBox_Z32
            // 
            this.checkBox_Z32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Z32.AutoSize = true;
            this.checkBox_Z32.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Z32.Checked = true;
            this.checkBox_Z32.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Z32.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Z32.Location = new System.Drawing.Point(791, 42);
            this.checkBox_Z32.Name = "checkBox_Z32";
            this.checkBox_Z32.Size = new System.Drawing.Size(73, 25);
            this.checkBox_Z32.TabIndex = 46;
            this.checkBox_Z32.Text = "Z32库";
            this.checkBox_Z32.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMerge);
            this.panel2.Controls.Add(this.cbBoxCmdStatus);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.button_createorder);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbBoxBayNo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1146, 44);
            this.panel2.TabIndex = 46;
            // 
            // tagDP
            // 
            this.tagDP.AutoRegist = true;
            this.tagDP.IsCacheEnable = true;
            this.tagDP.ServiceName = "iplature";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1152, 531);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // FrmCranePlanManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 531);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCranePlanManage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "吊运计划信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CranePlanManage_FormClosing);
            this.Load += new System.EventHandler(this.CranePlanManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uACS_PLAN_CRANPLANBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1_recTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combox_craneInstCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_matNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2_recTime;
        private System.Windows.Forms.Label label5;
       // private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource uACS_PLAN_CRANPLANBindingSource;
        //private DataSet1TableAdapters.UACS_PLAN_CRANPLANTableAdapter uACS_PLAN_CRANPLANTableAdapter;
        //private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRANENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRANEINSTCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRANESEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hGNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fROMYARDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOYARDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMDSTATUSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dELFLAGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dELTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button_createorder;
        private System.Windows.Forms.CheckBox ckBoxAutoReflesh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBoxBayNo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBoxCmdStatus;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.ComboBox cbBoxArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBoxCraneNo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISPAT_ACK_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISPAT_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG_DEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEL_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPD_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REC_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG_DISPAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMD_STATUS;
        private System.Windows.Forms.DataGridViewButtonColumn TO_STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FROM_STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_PRIORITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAY_NO;
        private System.Windows.Forms.DataGridViewButtonColumn CRANE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_GROUP_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_NO;
        private System.Windows.Forms.DataGridViewButtonColumn FIRST_JOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ5;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ4;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK_COLUMN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_Z51;
        private System.Windows.Forms.CheckBox checkBox_Z53;
        private System.Windows.Forms.CheckBox checkBox_Z52;
        private System.Windows.Forms.CheckBox checkBox_Z33;
        private System.Windows.Forms.CheckBox checkBox_Z32;
        // private DataSet1TableAdapters.DataTable3TableAdapter dataTable3TableAdapter;

    }
}

