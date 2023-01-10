namespace HMI_OF_REPOSITORIES
{
    partial class FrmCarHearInf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarHearInf));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCarHead = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLicenceNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarNum = new System.Windows.Forms.TextBox();
            this.btnSerch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CARNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarHead)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1207, 662);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(3, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1178, 586);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvCarHead);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1170, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "车辆信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvCarHead
            // 
            this.dgvCarHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CARNO,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvCarHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarHead.Location = new System.Drawing.Point(3, 3);
            this.dgvCarHead.Name = "dgvCarHead";
            this.dgvCarHead.Size = new System.Drawing.Size(1164, 550);
            this.dgvCarHead.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtLicenceNO);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCarNum);
            this.panel1.Controls.Add(this.btnSerch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 64);
            this.panel1.TabIndex = 1;
            // 
            // txtLicenceNO
            // 
            this.txtLicenceNO.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicenceNO.Location = new System.Drawing.Point(319, 24);
            this.txtLicenceNO.Name = "txtLicenceNO";
            this.txtLicenceNO.Size = new System.Drawing.Size(100, 26);
            this.txtLicenceNO.TabIndex = 65;
            this.txtLicenceNO.TextChanged += new System.EventHandler(this.txtLicenceNO_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(231, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 64;
            this.label2.Text = "牌 照 号：";
            // 
            // txtCarNum
            // 
            this.txtCarNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCarNum.Location = new System.Drawing.Point(100, 24);
            this.txtCarNum.Name = "txtCarNum";
            this.txtCarNum.Size = new System.Drawing.Size(100, 26);
            this.txtCarNum.TabIndex = 63;
            this.txtCarNum.TextChanged += new System.EventHandler(this.txtCarNum_TextChanged);
            // 
            // btnSerch
            // 
            this.btnSerch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerch.BackColor = System.Drawing.Color.White;
            this.btnSerch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSerch.BackgroundImage")));
            this.btnSerch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSerch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerch.ForeColor = System.Drawing.Color.White;
            this.btnSerch.Image = ((System.Drawing.Image)(resources.GetObject("btnSerch.Image")));
            this.btnSerch.Location = new System.Drawing.Point(1076, 16);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(95, 38);
            this.btnSerch.TabIndex = 42;
            this.btnSerch.Text = "查询";
            this.btnSerch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSerch.UseVisualStyleBackColor = false;
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "车 号：";
            // 
            // CARNO
            // 
            this.CARNO.DataPropertyName = "CARNO";
            this.CARNO.Frozen = true;
            this.CARNO.HeaderText = "车号";
            this.CARNO.Name = "CARNO";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CAR_NUMBER";
            this.Column2.HeaderText = "牌照号";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CARNO_TYPE";
            this.Column3.HeaderText = "牌照类型";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CAR_TYPE";
            this.Column4.HeaderText = "车种名称";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CAR_OIL_TYPE";
            this.Column5.HeaderText = "燃油类别";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "RATED_OIL";
            this.Column6.HeaderText = "额定燃油";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DESIGN_LOAD";
            this.Column7.HeaderText = "设计载重";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "RATED_LOAD";
            this.Column8.HeaderText = "额定载重";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "CAR_STATE_FLAG";
            this.Column9.HeaderText = "车辆状态标记";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "CAR_TAG_NUM";
            this.Column10.HeaderText = "标签号\t";
            this.Column10.Name = "Column10";
            this.Column10.Width = 400;
            // 
            // FrmCarHearInf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 662);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCarHearInf";
            this.Text = "车头信息画面";
            this.Load += new System.EventHandler(this.FrmCarHear_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarHead)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvCarHead;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSerch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCarNum;
        private System.Windows.Forms.TextBox txtLicenceNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}