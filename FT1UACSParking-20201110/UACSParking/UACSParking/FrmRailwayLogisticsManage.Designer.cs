namespace UACSParking
{
    partial class FrmRailwayLogisticsManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HAVEN_CNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSPORTTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dsCmbb = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.TypeName = new System.Data.DataColumn();
            this.TypeValue = new System.Data.DataColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCarEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCmbb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.HAVEN_CNAME,
            this.TRANSPORTTYPE,
            this.Column3});
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.Location = new System.Drawing.Point(3, 111);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.Size = new System.Drawing.Size(949, 334);
            this.dgvInfo.TabIndex = 0;
            this.dgvInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellClick);
            this.dgvInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellContentClick);
            this.dgvInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInfo_CellFormatting);
            this.dgvInfo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvInfo_EditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ROW_NUMBER";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            // 
            // HAVEN_CNAME
            // 
            this.HAVEN_CNAME.DataPropertyName = "HAVEN_CNAME";
            this.HAVEN_CNAME.HeaderText = "港口名称";
            this.HAVEN_CNAME.Name = "HAVEN_CNAME";
            this.HAVEN_CNAME.Width = 500;
            // 
            // TRANSPORTTYPE
            // 
            this.TRANSPORTTYPE.DataPropertyName = "TRANSPORTTYPE";
            this.TRANSPORTTYPE.HeaderText = "当前物流方向";
            this.TRANSPORTTYPE.Name = "TRANSPORTTYPE";
            this.TRANSPORTTYPE.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataSource = this.dsCmbb;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.DisplayMember = "dataTable1.TypeName";
            this.Column3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column3.HeaderText = "修改物流方向";
            this.Column3.Name = "Column3";
            this.Column3.ValueMember = "dataTable1.TypeValue";
            this.Column3.Width = 150;
            // 
            // dsCmbb
            // 
            this.dsCmbb.DataSetName = "NewDataSet";
            this.dsCmbb.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.TypeName,
            this.TypeValue});
            this.dataTable1.TableName = "dataTable1";
            // 
            // TypeName
            // 
            this.TypeName.ColumnName = "TypeName";
            // 
            // TypeValue
            // 
            this.TypeValue.ColumnName = "TypeValue";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(955, 448);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnCarEnter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 102);
            this.panel1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnRefresh.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(703, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 38);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCarEnter
            // 
            this.btnCarEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnCarEnter.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnCarEnter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCarEnter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarEnter.ForeColor = System.Drawing.Color.White;
            this.btnCarEnter.Location = new System.Drawing.Point(832, 53);
            this.btnCarEnter.Name = "btnCarEnter";
            this.btnCarEnter.Size = new System.Drawing.Size(98, 38);
            this.btnCarEnter.TabIndex = 70;
            this.btnCarEnter.Text = "提交";
            this.btnCarEnter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCarEnter.UseVisualStyleBackColor = false;
            this.btnCarEnter.Click += new System.EventHandler(this.btnCarEnter_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(949, 50);
            this.label1.TabIndex = 72;
            this.label1.Text = "产成品库物流流向管理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmRailwayLogisticsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 448);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmRailwayLogisticsManage";
            this.Text = "铁路物流管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCmbb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Data.DataSet dsCmbb;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn TypeName;
        private System.Data.DataColumn TypeValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCarEnter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAVEN_CNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSPORTTYPE;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.Label label1;
    }
}