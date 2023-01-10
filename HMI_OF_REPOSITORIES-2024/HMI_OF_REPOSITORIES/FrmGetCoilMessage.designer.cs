namespace FORMS_OF_REPOSITORIES
{
    partial class FrmGetCoilMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGetCoilMessage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPlantype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCoilNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCoilMessage = new System.Windows.Forms.DataGridView();
            this.PLAN_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_TYPE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REC_TIME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_TYPE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REC_TIME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGISTICS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoilMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPlantype);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtCoilNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cmbPlantype
            // 
            this.cmbPlantype.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbPlantype.FormattingEnabled = true;
            this.cmbPlantype.Items.AddRange(new object[] {
            "全部",
            "入库",
            "出库"});
            this.cmbPlantype.Location = new System.Drawing.Point(108, 32);
            this.cmbPlantype.Name = "cmbPlantype";
            this.cmbPlantype.Size = new System.Drawing.Size(100, 29);
            this.cmbPlantype.TabIndex = 4;
            this.cmbPlantype.Text = "全部";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "计划类型：";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(905, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // txtCoilNo
            // 
            this.txtCoilNo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtCoilNo.Location = new System.Drawing.Point(311, 32);
            this.txtCoilNo.Name = "txtCoilNo";
            this.txtCoilNo.Size = new System.Drawing.Size(167, 29);
            this.txtCoilNo.TabIndex = 1;
            this.txtCoilNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCoilNo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(231, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "钢卷号：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCoilMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 602);
            this.panel1.TabIndex = 1;
            // 
            // dgvCoilMessage
            // 
            this.dgvCoilMessage.AllowUserToAddRows = false;
            this.dgvCoilMessage.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoilMessage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCoilMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoilMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PLAN_NO,
            this.Column1,
            this.STOCK_NO,
            this.PLAN_TYPE1,
            this.REC_TIME1,
            this.PLAN_TYPE2,
            this.REC_TIME2,
            this.LOGISTICS_FLAG,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCoilMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCoilMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCoilMessage.EnableHeadersVisualStyles = false;
            this.dgvCoilMessage.Location = new System.Drawing.Point(0, 0);
            this.dgvCoilMessage.Name = "dgvCoilMessage";
            this.dgvCoilMessage.ReadOnly = true;
            this.dgvCoilMessage.RowTemplate.Height = 23;
            this.dgvCoilMessage.Size = new System.Drawing.Size(1040, 602);
            this.dgvCoilMessage.TabIndex = 0;
            this.dgvCoilMessage.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCoilMessage_CellFormatting);
            // 
            // PLAN_NO
            // 
            this.PLAN_NO.DataPropertyName = "PLAN_NO";
            this.PLAN_NO.HeaderText = "计划号";
            this.PLAN_NO.Name = "PLAN_NO";
            this.PLAN_NO.ReadOnly = true;
            this.PLAN_NO.Width = 150;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "COIL_NO";
            this.Column1.HeaderText = "钢卷号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // STOCK_NO
            // 
            this.STOCK_NO.DataPropertyName = "STOCK_NO";
            this.STOCK_NO.HeaderText = "库位号";
            this.STOCK_NO.Name = "STOCK_NO";
            this.STOCK_NO.ReadOnly = true;
            this.STOCK_NO.Width = 120;
            // 
            // PLAN_TYPE1
            // 
            this.PLAN_TYPE1.DataPropertyName = "PLAN_TYPE1";
            this.PLAN_TYPE1.HeaderText = "入库";
            this.PLAN_TYPE1.Name = "PLAN_TYPE1";
            this.PLAN_TYPE1.ReadOnly = true;
            this.PLAN_TYPE1.Width = 75;
            // 
            // REC_TIME1
            // 
            this.REC_TIME1.DataPropertyName = "REC_TIME1";
            this.REC_TIME1.HeaderText = "入库计划时间";
            this.REC_TIME1.Name = "REC_TIME1";
            this.REC_TIME1.ReadOnly = true;
            this.REC_TIME1.Width = 200;
            // 
            // PLAN_TYPE2
            // 
            this.PLAN_TYPE2.DataPropertyName = "PLAN_TYPE2";
            this.PLAN_TYPE2.HeaderText = "出库";
            this.PLAN_TYPE2.Name = "PLAN_TYPE2";
            this.PLAN_TYPE2.ReadOnly = true;
            this.PLAN_TYPE2.Width = 75;
            // 
            // REC_TIME2
            // 
            this.REC_TIME2.DataPropertyName = "REC_TIME2";
            this.REC_TIME2.HeaderText = "出库计划时间";
            this.REC_TIME2.Name = "REC_TIME2";
            this.REC_TIME2.ReadOnly = true;
            this.REC_TIME2.Width = 200;
            // 
            // LOGISTICS_FLAG
            // 
            this.LOGISTICS_FLAG.DataPropertyName = "LOGISTICS_FLAG";
            this.LOGISTICS_FLAG.HeaderText = "流向";
            this.LOGISTICS_FLAG.Name = "LOGISTICS_FLAG";
            this.LOGISTICS_FLAG.ReadOnly = true;
            this.LOGISTICS_FLAG.Width = 80;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "WEIGHT";
            this.Column2.HeaderText = "重量";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 67;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "WIDTH";
            this.Column3.HeaderText = "宽度";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 67;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "INDIA";
            this.Column4.HeaderText = "内径";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 67;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "OUTDIA";
            this.Column5.HeaderText = "外径";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 67;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.DataPropertyName = "PACK_FLAG";
            this.Column6.HeaderText = "是否包装";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 99;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.DataPropertyName = "SLEEVE_WIDTH";
            this.Column7.HeaderText = "套筒宽度";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 99;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.DataPropertyName = "COIL_OPEN_DIRECTION";
            this.Column8.HeaderText = "取卷方向";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 99;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.DataPropertyName = "NEXT_UNIT_NO";
            this.Column9.HeaderText = "下道机组";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 99;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.DataPropertyName = "STEEL_GRANDID";
            this.Column10.HeaderText = "钢种";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 67;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column11.DataPropertyName = "ACT_WEIGHT";
            this.Column11.HeaderText = "实际重量";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 99;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column12.DataPropertyName = "ACT_WIDTH";
            this.Column12.HeaderText = "实际宽度";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 99;
            // 
            // FrmGetCoilMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 685);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGetCoilMessage";
            this.Text = "钢卷信息查询";
            this.Load += new System.EventHandler(this.FrmGetCoilMessage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoilMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCoilNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvCoilMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPlantype;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_TYPE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn REC_TIME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_TYPE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn REC_TIME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGISTICS_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}