namespace UACSParking
{
    partial class FrmSelectCoilUpCar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackingNo = new System.Windows.Forms.TextBox();
            this.txtCarNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStowageId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddlist = new System.Windows.Forms.Button();
            this.btnRemoveCoil = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbAreaNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCoil = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.CHECK_COLUMN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStowageId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCarNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPackingNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "停车位信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "停车位：";
            // 
            // txtPackingNo
            // 
            this.txtPackingNo.Location = new System.Drawing.Point(68, 32);
            this.txtPackingNo.Name = "txtPackingNo";
            this.txtPackingNo.ReadOnly = true;
            this.txtPackingNo.Size = new System.Drawing.Size(111, 21);
            this.txtPackingNo.TabIndex = 1;
            // 
            // txtCarNo
            // 
            this.txtCarNo.Location = new System.Drawing.Point(266, 32);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.ReadOnly = true;
            this.txtCarNo.Size = new System.Drawing.Size(111, 21);
            this.txtCarNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "框架：";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(457, 32);
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            this.txtNum.Size = new System.Drawing.Size(111, 21);
            this.txtNum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "处理号：";
            // 
            // txtStowageId
            // 
            this.txtStowageId.Location = new System.Drawing.Point(665, 32);
            this.txtStowageId.Name = "txtStowageId";
            this.txtStowageId.ReadOnly = true;
            this.txtStowageId.Size = new System.Drawing.Size(111, 21);
            this.txtStowageId.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(594, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "配载图id：";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(511, 105);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(265, 328);
            this.listBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(511, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "上车的材料";
            // 
            // btnAddlist
            // 
            this.btnAddlist.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddlist.Location = new System.Drawing.Point(410, 208);
            this.btnAddlist.Name = "btnAddlist";
            this.btnAddlist.Size = new System.Drawing.Size(95, 29);
            this.btnAddlist.TabIndex = 3;
            this.btnAddlist.Text = "添加 》》》";
            this.btnAddlist.UseVisualStyleBackColor = true;
            this.btnAddlist.Click += new System.EventHandler(this.btnAddlist_Click);
            // 
            // btnRemoveCoil
            // 
            this.btnRemoveCoil.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveCoil.Location = new System.Drawing.Point(681, 73);
            this.btnRemoveCoil.Name = "btnRemoveCoil";
            this.btnRemoveCoil.Size = new System.Drawing.Size(95, 29);
            this.btnRemoveCoil.TabIndex = 4;
            this.btnRemoveCoil.Text = "移除选中材料";
            this.btnRemoveCoil.UseVisualStyleBackColor = true;
            this.btnRemoveCoil.Click += new System.EventHandler(this.btnRemoveCoil_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECK_COLUMN,
            this.STOCK_NO,
            this.MAT_NO});
            this.dataGridView1.Location = new System.Drawing.Point(0, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(404, 328);
            this.dataGridView1.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(554, 450);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 29);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "提交材料";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(681, 450);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "取消选卷";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "区：";
            // 
            // cbbAreaNo
            // 
            this.cbbAreaNo.FormattingEnabled = true;
            this.cbbAreaNo.Items.AddRange(new object[] {
            "全部",
            "A",
            "B",
            "C",
            "D"});
            this.cbbAreaNo.Location = new System.Drawing.Point(37, 79);
            this.cbbAreaNo.Name = "cbbAreaNo";
            this.cbbAreaNo.Size = new System.Drawing.Size(66, 20);
            this.cbbAreaNo.TabIndex = 9;
            this.cbbAreaNo.Text = "全部";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "材料：";
            // 
            // txtCoil
            // 
            this.txtCoil.Location = new System.Drawing.Point(167, 79);
            this.txtCoil.Name = "txtCoil";
            this.txtCoil.Size = new System.Drawing.Size(109, 21);
            this.txtCoil.TabIndex = 11;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Location = new System.Drawing.Point(309, 73);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 29);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "查找";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // CHECK_COLUMN
            // 
            this.CHECK_COLUMN.DataPropertyName = "CHECK_COLUMN";
            this.CHECK_COLUMN.HeaderText = "选中";
            this.CHECK_COLUMN.Name = "CHECK_COLUMN";
            this.CHECK_COLUMN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHECK_COLUMN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CHECK_COLUMN.Width = 60;
            // 
            // STOCK_NO
            // 
            this.STOCK_NO.DataPropertyName = "STOCK_NO";
            this.STOCK_NO.HeaderText = "库位";
            this.STOCK_NO.Name = "STOCK_NO";
            this.STOCK_NO.Width = 140;
            // 
            // MAT_NO
            // 
            this.MAT_NO.DataPropertyName = "MAT_NO";
            this.MAT_NO.HeaderText = "材料";
            this.MAT_NO.Name = "MAT_NO";
            this.MAT_NO.Width = 140;
            // 
            // FrmSelectCoilUpCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 491);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtCoil);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbAreaNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRemoveCoil);
            this.Controls.Add(this.btnAddlist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmSelectCoilUpCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "框架车选卷上车";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackingNo;
        private System.Windows.Forms.TextBox txtStowageId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCarNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddlist;
        private System.Windows.Forms.Button btnRemoveCoil;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbAreaNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCoil;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK_COLUMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAT_NO;
    }
}