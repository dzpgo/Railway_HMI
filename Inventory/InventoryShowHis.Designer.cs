namespace Inventory
{
    partial class InventoryShowHis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checBox_All_Details = new System.Windows.Forms.CheckBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.CheckedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.INVENT_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DROP_MAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVENT_RESULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCAN_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REC_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONFIRMER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SURE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_NO_IMPLICATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACTION_IMPLICATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESULT_IMPLICATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtStockNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnSeachMat = new System.Windows.Forms.Button();
            this.txtMatNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAreaNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.refreshDgvTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 733);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.24795F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1210, 615);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checBox_All_Details);
            this.groupBox1.Controls.Add(this.dgvDetail);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1204, 609);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checBox_All_Details
            // 
            this.checBox_All_Details.AutoSize = true;
            this.checBox_All_Details.Location = new System.Drawing.Point(9, 22);
            this.checBox_All_Details.Name = "checBox_All_Details";
            this.checBox_All_Details.Size = new System.Drawing.Size(51, 21);
            this.checBox_All_Details.TabIndex = 7;
            this.checBox_All_Details.Text = "全选";
            this.checBox_All_Details.UseVisualStyleBackColor = true;
            this.checBox_All_Details.CheckedChanged += new System.EventHandler(this.checBox_All_Details_CheckedChanged);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeight = 28;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckedColumn,
            this.INVENT_TYPE,
            this.STOCK_NO,
            this.MAT_NO,
            this.DROP_MAT,
            this.INVENT_RESULT,
            this.ACTION,
            this.RESULT,
            this.REMARK,
            this.USER,
            this.SCAN_TIME,
            this.PTID,
            this.REC_TIME,
            this.CONFIRMER,
            this.SURE_TIME,
            this.STOCK_NO_IMPLICATE,
            this.ACTION_IMPLICATE,
            this.RESULT_IMPLICATE});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 19);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(1198, 587);
            this.dgvDetail.TabIndex = 6;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            this.dgvDetail.Sorted += new System.EventHandler(this.dgvDetail_Sorted);
            // 
            // CheckedColumn
            // 
            this.CheckedColumn.FillWeight = 487.3096F;
            this.CheckedColumn.Frozen = true;
            this.CheckedColumn.HeaderText = "              ";
            this.CheckedColumn.Name = "CheckedColumn";
            this.CheckedColumn.ReadOnly = true;
            this.CheckedColumn.Width = 70;
            // 
            // INVENT_TYPE
            // 
            this.INVENT_TYPE.DataPropertyName = "INVENT_TYPE";
            this.INVENT_TYPE.Frozen = true;
            this.INVENT_TYPE.HeaderText = "盘库类型";
            this.INVENT_TYPE.Name = "INVENT_TYPE";
            this.INVENT_TYPE.ReadOnly = true;
            // 
            // STOCK_NO
            // 
            this.STOCK_NO.DataPropertyName = "STOCK_NO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STOCK_NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.STOCK_NO.FillWeight = 64.79003F;
            this.STOCK_NO.Frozen = true;
            this.STOCK_NO.HeaderText = "库 位";
            this.STOCK_NO.Name = "STOCK_NO";
            this.STOCK_NO.ReadOnly = true;
            this.STOCK_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STOCK_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STOCK_NO.Width = 82;
            // 
            // MAT_NO
            // 
            this.MAT_NO.DataPropertyName = "MAT_NO";
            this.MAT_NO.FillWeight = 64.79003F;
            this.MAT_NO.Frozen = true;
            this.MAT_NO.HeaderText = "实 物";
            this.MAT_NO.Name = "MAT_NO";
            this.MAT_NO.ReadOnly = true;
            this.MAT_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MAT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MAT_NO.Width = 102;
            // 
            // DROP_MAT
            // 
            this.DROP_MAT.DataPropertyName = "DROP_MAT";
            this.DROP_MAT.FillWeight = 64.79003F;
            this.DROP_MAT.Frozen = true;
            this.DROP_MAT.HeaderText = "信 息";
            this.DROP_MAT.Name = "DROP_MAT";
            this.DROP_MAT.ReadOnly = true;
            this.DROP_MAT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DROP_MAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DROP_MAT.Width = 102;
            // 
            // INVENT_RESULT
            // 
            this.INVENT_RESULT.DataPropertyName = "INVENT_RESULT";
            this.INVENT_RESULT.HeaderText = "盘库结果";
            this.INVENT_RESULT.Name = "INVENT_RESULT";
            this.INVENT_RESULT.ReadOnly = true;
            this.INVENT_RESULT.Width = 65;
            // 
            // ACTION
            // 
            this.ACTION.DataPropertyName = "ACTION";
            this.ACTION.FillWeight = 64.79003F;
            this.ACTION.HeaderText = "库位动作";
            this.ACTION.Name = "ACTION";
            this.ACTION.ReadOnly = true;
            this.ACTION.Visible = false;
            this.ACTION.Width = 82;
            // 
            // RESULT
            // 
            this.RESULT.DataPropertyName = "RESULT";
            this.RESULT.FillWeight = 64.79003F;
            this.RESULT.HeaderText = "动作结果";
            this.RESULT.Name = "RESULT";
            this.RESULT.ReadOnly = true;
            this.RESULT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RESULT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RESULT.Width = 102;
            // 
            // REMARK
            // 
            this.REMARK.DataPropertyName = "REMARK";
            this.REMARK.FillWeight = 64.79003F;
            this.REMARK.HeaderText = "是否需要复核";
            this.REMARK.Name = "REMARK";
            this.REMARK.ReadOnly = true;
            this.REMARK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.REMARK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.REMARK.Width = 150;
            // 
            // USER
            // 
            this.USER.DataPropertyName = "USER";
            this.USER.FillWeight = 64.79003F;
            this.USER.HeaderText = "扫描工号";
            this.USER.Name = "USER";
            this.USER.ReadOnly = true;
            this.USER.Width = 82;
            // 
            // SCAN_TIME
            // 
            this.SCAN_TIME.DataPropertyName = "SCAN_TIME";
            this.SCAN_TIME.HeaderText = "扫描时间";
            this.SCAN_TIME.Name = "SCAN_TIME";
            this.SCAN_TIME.ReadOnly = true;
            this.SCAN_TIME.Width = 160;
            // 
            // PTID
            // 
            this.PTID.DataPropertyName = "PTID";
            this.PTID.HeaderText = "扫描IP";
            this.PTID.Name = "PTID";
            this.PTID.ReadOnly = true;
            this.PTID.Width = 60;
            // 
            // REC_TIME
            // 
            this.REC_TIME.DataPropertyName = "REC_TIME";
            this.REC_TIME.HeaderText = "提交时间";
            this.REC_TIME.Name = "REC_TIME";
            this.REC_TIME.ReadOnly = true;
            this.REC_TIME.Width = 160;
            // 
            // CONFIRMER
            // 
            this.CONFIRMER.DataPropertyName = "CONFIRMER";
            this.CONFIRMER.HeaderText = "确认工号";
            this.CONFIRMER.Name = "CONFIRMER";
            this.CONFIRMER.ReadOnly = true;
            // 
            // SURE_TIME
            // 
            this.SURE_TIME.DataPropertyName = "SURE_TIME";
            this.SURE_TIME.HeaderText = "确认时间";
            this.SURE_TIME.Name = "SURE_TIME";
            this.SURE_TIME.ReadOnly = true;
            this.SURE_TIME.Width = 160;
            // 
            // STOCK_NO_IMPLICATE
            // 
            this.STOCK_NO_IMPLICATE.DataPropertyName = "STOCK_NO_IMPLICATE";
            this.STOCK_NO_IMPLICATE.FillWeight = 64.79003F;
            this.STOCK_NO_IMPLICATE.HeaderText = "牵连库位";
            this.STOCK_NO_IMPLICATE.Name = "STOCK_NO_IMPLICATE";
            this.STOCK_NO_IMPLICATE.ReadOnly = true;
            this.STOCK_NO_IMPLICATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STOCK_NO_IMPLICATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STOCK_NO_IMPLICATE.Width = 102;
            // 
            // ACTION_IMPLICATE
            // 
            this.ACTION_IMPLICATE.DataPropertyName = "ACTION_IMPLICATE";
            this.ACTION_IMPLICATE.FillWeight = 64.79003F;
            this.ACTION_IMPLICATE.HeaderText = "牵连库位动作";
            this.ACTION_IMPLICATE.Name = "ACTION_IMPLICATE";
            this.ACTION_IMPLICATE.ReadOnly = true;
            this.ACTION_IMPLICATE.Width = 105;
            // 
            // RESULT_IMPLICATE
            // 
            this.RESULT_IMPLICATE.DataPropertyName = "RESULT_IMPLICATE";
            this.RESULT_IMPLICATE.FillWeight = 64.79003F;
            this.RESULT_IMPLICATE.HeaderText = "牵连库位结果";
            this.RESULT_IMPLICATE.Name = "RESULT_IMPLICATE";
            this.RESULT_IMPLICATE.ReadOnly = true;
            this.RESULT_IMPLICATE.Width = 105;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 688);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1210, 45);
            this.panel3.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(83, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 24);
            this.label11.TabIndex = 50;
            this.label11.Text = "实物信息不一致的库位";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Yellow;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(423, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 24);
            this.label10.TabIndex = 49;
            this.label10.Text = "强制复核的库位";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Red;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(261, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 24);
            this.label9.TabIndex = 48;
            this.label9.Text = "有实物无信息的库位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 22);
            this.label6.TabIndex = 47;
            this.label6.Text = "颜色说明：";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(101)))), ((int)(((byte)(175)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(982, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 45);
            this.button1.TabIndex = 46;
            this.button1.TabStop = false;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(101)))), ((int)(((byte)(175)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1096, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 45);
            this.button3.TabIndex = 39;
            this.button3.Text = "导出";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.txtStockNo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.btnSeachMat);
            this.panel2.Controls.Add(this.txtMatNo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbxAreaNo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbbId);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1210, 73);
            this.panel2.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(931, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 21);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.Text = "一致";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtStockNo
            // 
            this.txtStockNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStockNo.Location = new System.Drawing.Point(293, 45);
            this.txtStockNo.Name = "txtStockNo";
            this.txtStockNo.Size = new System.Drawing.Size(122, 23);
            this.txtStockNo.TabIndex = 52;
            this.txtStockNo.TabStop = false;
            this.txtStockNo.TextChanged += new System.EventHandler(this.txtStockNo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(221, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 51;
            this.label8.Text = "指定库位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(434, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "~";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(812, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "实物与信息比对：";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox2.Location = new System.Drawing.Point(988, 13);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(63, 21);
            this.checkBox2.TabIndex = 48;
            this.checkBox2.Text = "不一致";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(293, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 23);
            this.dateTimePicker1.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(221, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "盘库时间：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(454, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(140, 23);
            this.dateTimePicker2.TabIndex = 45;
            // 
            // btnSeachMat
            // 
            this.btnSeachMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeachMat.BackColor = System.Drawing.Color.White;
            this.btnSeachMat.BackgroundImage = global::Inventory.Properties.Resources.bg_btn;
            this.btnSeachMat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSeachMat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeachMat.ForeColor = System.Drawing.Color.White;
            this.btnSeachMat.Location = new System.Drawing.Point(1084, 3);
            this.btnSeachMat.Name = "btnSeachMat";
            this.btnSeachMat.Size = new System.Drawing.Size(123, 64);
            this.btnSeachMat.TabIndex = 43;
            this.btnSeachMat.Text = "查询盘库履历";
            this.btnSeachMat.UseVisualStyleBackColor = false;
            this.btnSeachMat.Click += new System.EventHandler(this.btnSeachMat_Click);
            // 
            // txtMatNo
            // 
            this.txtMatNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMatNo.Location = new System.Drawing.Point(83, 44);
            this.txtMatNo.Name = "txtMatNo";
            this.txtMatNo.Size = new System.Drawing.Size(122, 23);
            this.txtMatNo.TabIndex = 40;
            this.txtMatNo.TabStop = false;
            this.txtMatNo.TextChanged += new System.EventHandler(this.txtMatNo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(10, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "指定材料：";
            // 
            // cbxAreaNo
            // 
            this.cbxAreaNo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbxAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxAreaNo.FormattingEnabled = true;
            this.cbxAreaNo.Location = new System.Drawing.Point(678, 9);
            this.cbxAreaNo.Name = "cbxAreaNo";
            this.cbxAreaNo.Size = new System.Drawing.Size(122, 25);
            this.cbxAreaNo.TabIndex = 39;
            this.cbxAreaNo.TabStop = false;
            this.cbxAreaNo.SelectedIndexChanged += new System.EventHandler(this.cbxAreaNo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(607, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "盘库区域：";
            // 
            // cbbId
            // 
            this.cbbId.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbbId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbId.FormattingEnabled = true;
            this.cbbId.Location = new System.Drawing.Point(83, 9);
            this.cbbId.Name = "cbbId";
            this.cbbId.Size = new System.Drawing.Size(122, 25);
            this.cbbId.TabIndex = 37;
            this.cbbId.TabStop = false;
            this.cbbId.SelectedIndexChanged += new System.EventHandler(this.cbbId_SelectedIndexChanged);
            this.cbbId.Click += new System.EventHandler(this.cbbId_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "盘 库 跨：";
            // 
            // refreshDgvTimer
            // 
            this.refreshDgvTimer.Interval = 3000;
            this.refreshDgvTimer.Tick += new System.EventHandler(this.refreshDgvTimer_Tick);
            // 
            // InventoryShowHis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 733);
            this.Controls.Add(this.panel1);
            this.Name = "InventoryShowHis";
            this.Text = "盘库";
            this.Load += new System.EventHandler(this.InventoryShow_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbbId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checBox_All_Details;
        private System.Windows.Forms.Button btnSeachMat;
        private System.Windows.Forms.TextBox txtMatNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxAreaNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Timer refreshDgvTimer;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStockNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESULT_IMPLICATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTION_IMPLICATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_NO_IMPLICATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SURE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONFIRMER;
        private System.Windows.Forms.DataGridViewTextBoxColumn REC_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCAN_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESULT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVENT_RESULT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DROP_MAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVENT_TYPE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckedColumn;
    }
}

