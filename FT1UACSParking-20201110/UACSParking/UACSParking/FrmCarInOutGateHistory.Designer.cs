namespace UACSParking
{
    partial class FrmCarInOutGateHistory
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
            this.cmbGate = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtCarNO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFine = new System.Windows.Forms.Button();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.ROW_INDEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GATE_FLAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAR_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IN_OUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IN_OUT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1354, 733);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbGate);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.txtCarNO);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnFine);
            this.panel1.Controls.Add(this.dateTimeEnd);
            this.panel1.Controls.Add(this.dateTimeStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1348, 102);
            this.panel1.TabIndex = 0;
            // 
            // cmbGate
            // 
            this.cmbGate.FormattingEnabled = true;
            this.cmbGate.Items.AddRange(new object[] {
            "全部",
            "南",
            "北"});
            this.cmbGate.Location = new System.Drawing.Point(431, 36);
            this.cmbGate.Name = "cmbGate";
            this.cmbGate.Size = new System.Drawing.Size(96, 33);
            this.cmbGate.TabIndex = 88;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "全部",
            "出库",
            "入库"});
            this.cmbType.Location = new System.Drawing.Point(249, 36);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(96, 33);
            this.cmbType.TabIndex = 86;
            // 
            // txtCarNO
            // 
            this.txtCarNO.Location = new System.Drawing.Point(64, 34);
            this.txtCarNO.Name = "txtCarNO";
            this.txtCarNO.Size = new System.Drawing.Size(100, 33);
            this.txtCarNO.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 25);
            this.label5.TabIndex = 89;
            this.label5.Text = "道闸：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 87;
            this.label2.Text = "出入库：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 85;
            this.label1.Text = "车号：";
            // 
            // btnFine
            // 
            this.btnFine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(137)))), ((int)(((byte)(241)))));
            this.btnFine.BackgroundImage = global::UACSParking.Resource1.bg_btn;
            this.btnFine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFine.ForeColor = System.Drawing.Color.White;
            this.btnFine.Location = new System.Drawing.Point(1215, 34);
            this.btnFine.Name = "btnFine";
            this.btnFine.Size = new System.Drawing.Size(101, 38);
            this.btnFine.TabIndex = 83;
            this.btnFine.Text = "查询";
            this.btnFine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFine.UseVisualStyleBackColor = false;
            this.btnFine.Click += new System.EventHandler(this.btnFine_Click);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeEnd.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(971, 37);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(226, 33);
            this.dateTimeEnd.TabIndex = 23;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeStart.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(641, 38);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(224, 33);
            this.dateTimeStart.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(871, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "结束时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(545, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "开始时间：";
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROW_INDEX,
            this.GATE_FLAGE,
            this.CARNO,
            this.CAR_NUMBER,
            this.IN_OUT,
            this.IN_OUT_TIME});
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 111);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 30;
            this.dgv1.Size = new System.Drawing.Size(1348, 619);
            this.dgv1.TabIndex = 1;
            this.dgv1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv1_CellFormatting);
            // 
            // ROW_INDEX
            // 
            this.ROW_INDEX.DataPropertyName = "ROW_INDEX";
            this.ROW_INDEX.HeaderText = "序号";
            this.ROW_INDEX.Name = "ROW_INDEX";
            // 
            // GATE_FLAGE
            // 
            this.GATE_FLAGE.DataPropertyName = "GATE_FLAGE";
            this.GATE_FLAGE.HeaderText = "道闸";
            this.GATE_FLAGE.Name = "GATE_FLAGE";
            // 
            // CARNO
            // 
            this.CARNO.DataPropertyName = "CARNO";
            this.CARNO.HeaderText = "车号";
            this.CARNO.Name = "CARNO";
            // 
            // CAR_NUMBER
            // 
            this.CAR_NUMBER.DataPropertyName = "CAR_NUMBER";
            this.CAR_NUMBER.HeaderText = "车牌号";
            this.CAR_NUMBER.Name = "CAR_NUMBER";
            this.CAR_NUMBER.Width = 120;
            // 
            // IN_OUT
            // 
            this.IN_OUT.DataPropertyName = "IN_OUT";
            this.IN_OUT.HeaderText = "出入类型";
            this.IN_OUT.Name = "IN_OUT";
            this.IN_OUT.Width = 120;
            // 
            // IN_OUT_TIME
            // 
            this.IN_OUT_TIME.DataPropertyName = "IN_OUT_TIME";
            this.IN_OUT_TIME.HeaderText = "动作时间";
            this.IN_OUT_TIME.Name = "IN_OUT_TIME";
            this.IN_OUT_TIME.Width = 200;
            // 
            // FrmCarInOutGateHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCarInOutGateHistory";
            this.Text = "车辆出入库历史";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCarNO;
        private System.Windows.Forms.Button btnFine;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ComboBox cmbGate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROW_INDEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn GATE_FLAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAR_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn IN_OUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn IN_OUT_TIME;
    }
}