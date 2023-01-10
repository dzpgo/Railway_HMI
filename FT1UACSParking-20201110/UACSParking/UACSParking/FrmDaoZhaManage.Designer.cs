namespace UACSParking
{
    partial class FrmDaoZhaManage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvHMIInfo = new System.Windows.Forms.DataGridView();
            this.RECOMMEND_MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODE_LOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECOMMEND_PARKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SET_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FRAME_HEAD_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FRAME_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtParksSequence = new System.Windows.Forms.TextBox();
            this.labCurrMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labCurrHMISequence = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnCloseHMIMode = new System.Windows.Forms.Button();
            this.btnChangeMode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvParkToAreaInfo = new System.Windows.Forms.DataGridView();
            this.ROW_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARKING_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbbRecommendPark = new System.Windows.Forms.ComboBox();
            this.cmbbModeLock = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbbFrameName = new System.Windows.Forms.ComboBox();
            this.cmbbModeType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnFine = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbNO = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHMIInfo)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkToAreaInfo)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1354, 733);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(700, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 659);
            this.panel1.TabIndex = 72;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dgvHMIInfo, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel8, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(651, 659);
            this.tableLayoutPanel3.TabIndex = 80;
            // 
            // dgvHMIInfo
            // 
            this.dgvHMIInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHMIInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RECOMMEND_MODE,
            this.MODE_TYPE,
            this.MODE_LOCK,
            this.RECOMMEND_PARKS,
            this.SET_TIME,
            this.FRAME_HEAD_NO,
            this.FRAME_NO});
            this.dgvHMIInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHMIInfo.Location = new System.Drawing.Point(4, 216);
            this.dgvHMIInfo.Name = "dgvHMIInfo";
            this.dgvHMIInfo.RowTemplate.Height = 23;
            this.dgvHMIInfo.Size = new System.Drawing.Size(643, 350);
            this.dgvHMIInfo.TabIndex = 79;
            this.dgvHMIInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHMIInfo_CellMouseClick);
            // 
            // RECOMMEND_MODE
            // 
            this.RECOMMEND_MODE.DataPropertyName = "RECOMMEND_MODE";
            this.RECOMMEND_MODE.HeaderText = "模式";
            this.RECOMMEND_MODE.Name = "RECOMMEND_MODE";
            // 
            // MODE_TYPE
            // 
            this.MODE_TYPE.DataPropertyName = "MODE_TYPE";
            this.MODE_TYPE.HeaderText = "模式名称";
            this.MODE_TYPE.Name = "MODE_TYPE";
            this.MODE_TYPE.Width = 140;
            // 
            // MODE_LOCK
            // 
            this.MODE_LOCK.DataPropertyName = "MODE_LOCK";
            this.MODE_LOCK.HeaderText = "模式状态";
            this.MODE_LOCK.Name = "MODE_LOCK";
            this.MODE_LOCK.Width = 140;
            // 
            // RECOMMEND_PARKS
            // 
            this.RECOMMEND_PARKS.DataPropertyName = "RECOMMEND_PARKS";
            this.RECOMMEND_PARKS.HeaderText = "推荐车位";
            this.RECOMMEND_PARKS.Name = "RECOMMEND_PARKS";
            this.RECOMMEND_PARKS.Width = 140;
            // 
            // SET_TIME
            // 
            this.SET_TIME.DataPropertyName = "SET_TIME";
            this.SET_TIME.HeaderText = "设定时间";
            this.SET_TIME.Name = "SET_TIME";
            this.SET_TIME.Width = 140;
            // 
            // FRAME_HEAD_NO
            // 
            this.FRAME_HEAD_NO.DataPropertyName = "FRAME_HEAD_NO";
            this.FRAME_HEAD_NO.HeaderText = "车头号";
            this.FRAME_HEAD_NO.Name = "FRAME_HEAD_NO";
            // 
            // FRAME_NO
            // 
            this.FRAME_NO.DataPropertyName = "FRAME_NO";
            this.FRAME_NO.HeaderText = "框架号";
            this.FRAME_NO.Name = "FRAME_NO";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtParksSequence);
            this.panel7.Controls.Add(this.labCurrMode);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.labCurrHMISequence);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(643, 205);
            this.panel7.TabIndex = 80;
            // 
            // txtParksSequence
            // 
            this.txtParksSequence.Location = new System.Drawing.Point(166, 102);
            this.txtParksSequence.Name = "txtParksSequence";
            this.txtParksSequence.Size = new System.Drawing.Size(400, 34);
            this.txtParksSequence.TabIndex = 72;
            this.txtParksSequence.TextChanged += new System.EventHandler(this.txtParksSequence_TextChanged);
            // 
            // labCurrMode
            // 
            this.labCurrMode.AutoSize = true;
            this.labCurrMode.Location = new System.Drawing.Point(54, 14);
            this.labCurrMode.Name = "labCurrMode";
            this.labCurrMode.Size = new System.Drawing.Size(112, 27);
            this.labCurrMode.TabIndex = 78;
            this.labCurrMode.Text = "当前模式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 27);
            this.label1.TabIndex = 73;
            this.label1.Text = "设置优先顺序：";
            // 
            // labCurrHMISequence
            // 
            this.labCurrHMISequence.AutoSize = true;
            this.labCurrHMISequence.Location = new System.Drawing.Point(14, 58);
            this.labCurrHMISequence.Name = "labCurrHMISequence";
            this.labCurrHMISequence.Size = new System.Drawing.Size(152, 27);
            this.labCurrHMISequence.TabIndex = 77;
            this.labCurrHMISequence.Text = "当前优先顺序：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(552, 21);
            this.label3.TabIndex = 76;
            this.label3.Text = "说明：按推荐顺序输入车位号，每个车位用’#‘隔开，例如：FT101#FT102\r\n";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnRefresh);
            this.panel8.Controls.Add(this.btnCommit);
            this.panel8.Controls.Add(this.btnCloseHMIMode);
            this.panel8.Controls.Add(this.btnChangeMode);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(4, 573);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(643, 82);
            this.panel8.TabIndex = 81;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnRefresh.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(480, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(122, 38);
            this.btnRefresh.TabIndex = 76;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnCommit.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCommit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommit.ForeColor = System.Drawing.Color.White;
            this.btnCommit.Location = new System.Drawing.Point(33, 23);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(122, 38);
            this.btnCommit.TabIndex = 71;
            this.btnCommit.Text = "重新设定";
            this.btnCommit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCommit.UseVisualStyleBackColor = false;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnCloseHMIMode
            // 
            this.btnCloseHMIMode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCloseHMIMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnCloseHMIMode.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnCloseHMIMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseHMIMode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseHMIMode.ForeColor = System.Drawing.Color.White;
            this.btnCloseHMIMode.Location = new System.Drawing.Point(325, 23);
            this.btnCloseHMIMode.Name = "btnCloseHMIMode";
            this.btnCloseHMIMode.Size = new System.Drawing.Size(122, 38);
            this.btnCloseHMIMode.TabIndex = 75;
            this.btnCloseHMIMode.Text = "关闭";
            this.btnCloseHMIMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCloseHMIMode.UseVisualStyleBackColor = false;
            this.btnCloseHMIMode.Click += new System.EventHandler(this.btnCloseHMIMode_Click);
            // 
            // btnChangeMode
            // 
            this.btnChangeMode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnChangeMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnChangeMode.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnChangeMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeMode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeMode.ForeColor = System.Drawing.Color.White;
            this.btnChangeMode.Location = new System.Drawing.Point(180, 23);
            this.btnChangeMode.Name = "btnChangeMode";
            this.btnChangeMode.Size = new System.Drawing.Size(122, 38);
            this.btnChangeMode.TabIndex = 74;
            this.btnChangeMode.Text = "启用";
            this.btnChangeMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeMode.UseVisualStyleBackColor = false;
            this.btnChangeMode.Click += new System.EventHandler(this.btnChangeMode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(700, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(651, 63);
            this.label2.TabIndex = 74;
            this.label2.Text = "人工车位推荐自定义";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(651, 63);
            this.label6.TabIndex = 77;
            this.label6.Text = "自动推荐车位查询";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 659);
            this.panel2.TabIndex = 78;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvParkToAreaInfo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(651, 659);
            this.tableLayoutPanel2.TabIndex = 91;
            // 
            // dgvParkToAreaInfo
            // 
            this.dgvParkToAreaInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParkToAreaInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROW_NO,
            this.Column1,
            this.NAME,
            this.Column2,
            this.PARKING_STATUS,
            this.Column3});
            this.dgvParkToAreaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParkToAreaInfo.Location = new System.Drawing.Point(4, 216);
            this.dgvParkToAreaInfo.Name = "dgvParkToAreaInfo";
            this.dgvParkToAreaInfo.RowTemplate.Height = 23;
            this.dgvParkToAreaInfo.Size = new System.Drawing.Size(643, 350);
            this.dgvParkToAreaInfo.TabIndex = 83;
            this.dgvParkToAreaInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvParkToAreaInfo_CellFormatting);
            // 
            // ROW_NO
            // 
            this.ROW_NO.DataPropertyName = "ROW_NO";
            this.ROW_NO.HeaderText = "序号";
            this.ROW_NO.Name = "ROW_NO";
            this.ROW_NO.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DESC";
            this.Column1.HeaderText = "区域";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "停车位";
            this.NAME.Name = "NAME";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "X_SUB";
            this.Column2.HeaderText = "距离(MM)";
            this.Column2.Name = "Column2";
            this.Column2.Width = 140;
            // 
            // PARKING_STATUS
            // 
            this.PARKING_STATUS.DataPropertyName = "PARKING_STATUS";
            this.PARKING_STATUS.HeaderText = "当前状态";
            this.PARKING_STATUS.Name = "PARKING_STATUS";
            this.PARKING_STATUS.Width = 140;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "HAVEN_CNAME";
            this.Column3.HeaderText = "码头名称";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmbbRecommendPark);
            this.panel5.Controls.Add(this.cmbbModeLock);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.cmbbFrameName);
            this.panel5.Controls.Add(this.cmbbModeType);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(643, 205);
            this.panel5.TabIndex = 84;
            // 
            // cmbbRecommendPark
            // 
            this.cmbbRecommendPark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbbRecommendPark.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbbRecommendPark.FormattingEnabled = true;
            this.cmbbRecommendPark.Location = new System.Drawing.Point(431, 29);
            this.cmbbRecommendPark.Name = "cmbbRecommendPark";
            this.cmbbRecommendPark.Size = new System.Drawing.Size(150, 33);
            this.cmbbRecommendPark.TabIndex = 85;
            // 
            // cmbbModeLock
            // 
            this.cmbbModeLock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbbModeLock.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbbModeLock.FormattingEnabled = true;
            this.cmbbModeLock.Location = new System.Drawing.Point(431, 84);
            this.cmbbModeLock.Name = "cmbbModeLock";
            this.cmbbModeLock.Size = new System.Drawing.Size(150, 33);
            this.cmbbModeLock.TabIndex = 90;
            this.cmbbModeLock.SelectedIndexChanged += new System.EventHandler(this.cmbbModeLock_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "车头号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(315, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 25);
            this.label8.TabIndex = 89;
            this.label8.Text = "模式状态：";
            // 
            // cmbbFrameName
            // 
            this.cmbbFrameName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbbFrameName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbbFrameName.FormattingEnabled = true;
            this.cmbbFrameName.Location = new System.Drawing.Point(127, 26);
            this.cmbbFrameName.Name = "cmbbFrameName";
            this.cmbbFrameName.Size = new System.Drawing.Size(150, 33);
            this.cmbbFrameName.TabIndex = 17;
            this.cmbbFrameName.SelectedIndexChanged += new System.EventHandler(this.cmbbFrameName_SelectedIndexChanged);
            // 
            // cmbbModeType
            // 
            this.cmbbModeType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbbModeType.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbbModeType.FormattingEnabled = true;
            this.cmbbModeType.Location = new System.Drawing.Point(127, 84);
            this.cmbbModeType.Name = "cmbbModeType";
            this.cmbbModeType.Size = new System.Drawing.Size(150, 33);
            this.cmbbModeType.TabIndex = 88;
            this.cmbbModeType.SelectedIndexChanged += new System.EventHandler(this.cmbbModeType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(315, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 84;
            this.label5.Text = "推荐车位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(9, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 87;
            this.label7.Text = "模式名称：";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnDelete);
            this.panel6.Controls.Add(this.btnModify);
            this.panel6.Controls.Add(this.btnFine);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 573);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(643, 82);
            this.panel6.TabIndex = 85;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnDelete.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(478, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 38);
            this.btnDelete.TabIndex = 89;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnModify.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModify.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Location = new System.Drawing.Point(264, 20);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(101, 38);
            this.btnModify.TabIndex = 86;
            this.btnModify.Text = "修改";
            this.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnFine
            // 
            this.btnFine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnFine.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnFine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFine.ForeColor = System.Drawing.Color.White;
            this.btnFine.Location = new System.Drawing.Point(50, 20);
            this.btnFine.Name = "btnFine";
            this.btnFine.Size = new System.Drawing.Size(101, 38);
            this.btnFine.TabIndex = 82;
            this.btnFine.Text = "查询";
            this.btnFine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFine.UseVisualStyleBackColor = false;
            this.btnFine.Click += new System.EventHandler(this.btnFine_Click);
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(3, 731);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1348, 1);
            this.tabControl1.TabIndex = 79;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbStatus);
            this.tabPage1.Controls.Add(this.btnClearAll);
            this.tabPage1.Controls.Add(this.btnChange);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbNO);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1340, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "车辆当前状态修改";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(315, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 25);
            this.label10.TabIndex = 90;
            this.label10.Text = "状态：";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "1：在库区内",
            "0：在库区外",
            "-1：其他状态"});
            this.cmbStatus.Location = new System.Drawing.Point(396, 38);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(155, 33);
            this.cmbStatus.TabIndex = 89;
            this.cmbStatus.Text = "1：在库区内";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnClearAll.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.ForeColor = System.Drawing.Color.White;
            this.btnClearAll.Location = new System.Drawing.Point(1210, 38);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(101, 38);
            this.btnClearAll.TabIndex = 88;
            this.btnClearAll.Text = "全部置0";
            this.btnClearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnChange.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChange.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Location = new System.Drawing.Point(1043, 38);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(101, 38);
            this.btnChange.TabIndex = 87;
            this.btnChange.Text = "修改状态";
            this.btnChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(47, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "车号：";
            // 
            // cmbNO
            // 
            this.cmbNO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbNO.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbNO.FormattingEnabled = true;
            this.cmbNO.Location = new System.Drawing.Point(127, 38);
            this.cmbNO.Name = "cmbNO";
            this.cmbNO.Size = new System.Drawing.Size(150, 33);
            this.cmbNO.TabIndex = 19;
            // 
            // FrmDaoZhaManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDaoZhaManage";
            this.Text = "道闸车位管理";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHMIInfo)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkToAreaInfo)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParksSequence;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labCurrHMISequence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseHMIMode;
        private System.Windows.Forms.Button btnChangeMode;
        private System.Windows.Forms.Label labCurrMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbbFrameName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFine;
        private System.Windows.Forms.DataGridView dgvParkToAreaInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ComboBox cmbbRecommendPark;
        private System.Windows.Forms.DataGridView dgvHMIInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECOMMEND_MODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODE_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODE_LOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECOMMEND_PARKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SET_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FRAME_HEAD_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FRAME_NO;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbbModeType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbbModeLock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbNO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROW_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARKING_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}