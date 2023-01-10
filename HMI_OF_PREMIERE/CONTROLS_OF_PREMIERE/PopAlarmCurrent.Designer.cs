namespace CONTROLS_OF_PREMIERE
{
    partial class PopAlarmCurrent
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
            this.lblCraneNo = new System.Windows.Forms.Label();
            this.btnGetTag = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView_ALARM = new System.Windows.Forms.DataGridView();
            this.ALARM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALARM_INFO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALARM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_ALARM2 = new System.Windows.Forms.DataGridView();
            this.ALARM_CODE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALARM_INFO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALARM_CLASS2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ALARM)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ALARM2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblCraneNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGetTag, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.09466F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.90535F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 565);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCraneNo
            // 
            this.lblCraneNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCraneNo.AutoSize = true;
            this.lblCraneNo.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCraneNo.Location = new System.Drawing.Point(174, 19);
            this.lblCraneNo.Name = "lblCraneNo";
            this.lblCraneNo.Size = new System.Drawing.Size(135, 28);
            this.lblCraneNo.TabIndex = 0;
            this.lblCraneNo.Text = "行车号--报警";
            // 
            // btnGetTag
            // 
            this.btnGetTag.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetTag.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetTag.Location = new System.Drawing.Point(364, 559);
            this.btnGetTag.Name = "btnGetTag";
            this.btnGetTag.Size = new System.Drawing.Size(117, 3);
            this.btnGetTag.TabIndex = 2;
            this.btnGetTag.Text = "查询";
            this.btnGetTag.UseVisualStyleBackColor = true;
            this.btnGetTag.Visible = false;
            this.btnGetTag.Click += new System.EventHandler(this.btnGetTag_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 483);
            this.panel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(478, 483);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_ALARM);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(470, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "防摇报警";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ALARM
            // 
            this.dataGridView_ALARM.AllowUserToAddRows = false;
            this.dataGridView_ALARM.AllowUserToResizeRows = false;
            this.dataGridView_ALARM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_ALARM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ALARM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ALARM_CODE,
            this.ALARM_INFO,
            this.ALARM_CLASS});
            this.dataGridView_ALARM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ALARM.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_ALARM.Name = "dataGridView_ALARM";
            this.dataGridView_ALARM.ReadOnly = true;
            this.dataGridView_ALARM.RowHeadersVisible = false;
            this.dataGridView_ALARM.RowTemplate.Height = 23;
            this.dataGridView_ALARM.Size = new System.Drawing.Size(464, 444);
            this.dataGridView_ALARM.TabIndex = 1;
            // 
            // ALARM_CODE
            // 
            this.ALARM_CODE.DataPropertyName = "ALARM_CODE";
            this.ALARM_CODE.HeaderText = "故障编号";
            this.ALARM_CODE.Name = "ALARM_CODE";
            this.ALARM_CODE.ReadOnly = true;
            this.ALARM_CODE.Width = 90;
            // 
            // ALARM_INFO
            // 
            this.ALARM_INFO.DataPropertyName = "ALARM_INFO";
            this.ALARM_INFO.HeaderText = "报警备注";
            this.ALARM_INFO.Name = "ALARM_INFO";
            this.ALARM_INFO.ReadOnly = true;
            this.ALARM_INFO.Width = 90;
            // 
            // ALARM_CLASS
            // 
            this.ALARM_CLASS.DataPropertyName = "ALARM_CLASS";
            this.ALARM_CLASS.HeaderText = "报警级别";
            this.ALARM_CLASS.Name = "ALARM_CLASS";
            this.ALARM_CLASS.ReadOnly = true;
            this.ALARM_CLASS.Width = 90;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_ALARM2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(470, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "行车报警";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ALARM2
            // 
            this.dataGridView_ALARM2.AllowUserToAddRows = false;
            this.dataGridView_ALARM2.AllowUserToResizeRows = false;
            this.dataGridView_ALARM2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ALARM2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ALARM_CODE2,
            this.ALARM_INFO2,
            this.ALARM_CLASS2});
            this.dataGridView_ALARM2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ALARM2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_ALARM2.Name = "dataGridView_ALARM2";
            this.dataGridView_ALARM2.ReadOnly = true;
            this.dataGridView_ALARM2.RowHeadersVisible = false;
            this.dataGridView_ALARM2.RowTemplate.Height = 23;
            this.dataGridView_ALARM2.Size = new System.Drawing.Size(464, 444);
            this.dataGridView_ALARM2.TabIndex = 0;
            // 
            // ALARM_CODE2
            // 
            this.ALARM_CODE2.DataPropertyName = "ALARM_CODE";
            this.ALARM_CODE2.HeaderText = "报警编号";
            this.ALARM_CODE2.Name = "ALARM_CODE2";
            this.ALARM_CODE2.ReadOnly = true;
            // 
            // ALARM_INFO2
            // 
            this.ALARM_INFO2.DataPropertyName = "ALARM_INFO";
            this.ALARM_INFO2.HeaderText = "报警信息";
            this.ALARM_INFO2.Name = "ALARM_INFO2";
            this.ALARM_INFO2.ReadOnly = true;
            this.ALARM_INFO2.Width = 260;
            // 
            // ALARM_CLASS2
            // 
            this.ALARM_CLASS2.DataPropertyName = "ALARM_CLASS";
            this.ALARM_CLASS2.HeaderText = "报警级别";
            this.ALARM_CLASS2.Name = "ALARM_CLASS2";
            this.ALARM_CLASS2.ReadOnly = true;
            // 
            // PopAlarmCurrent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 565);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PopAlarmCurrent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "行车报警";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ALARM)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ALARM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCraneNo;
        private System.Windows.Forms.Button btnGetTag;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView_ALARM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_INFO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_CLASS;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_ALARM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_CODE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_INFO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_CLASS2;
    }
}