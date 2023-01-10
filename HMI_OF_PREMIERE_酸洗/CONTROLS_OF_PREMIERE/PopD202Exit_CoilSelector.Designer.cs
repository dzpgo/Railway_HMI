namespace CONTROLS_OF_PREMIERE
{
    partial class PopD202Exit_CoilSelector
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridLineExitInfo = new System.Windows.Forms.DataGridView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SADDLE_L2NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HAS_COIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COIL_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlagSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WIDTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IN_DIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUT_DIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLEEVE_WIDTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdCanel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLineExitInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridLineExitInfo
            // 
            this.dataGridLineExitInfo.AllowUserToAddRows = false;
            this.dataGridLineExitInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridLineExitInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridLineExitInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridLineExitInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridLineExitInfo.ColumnHeadersHeight = 60;
            this.dataGridLineExitInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridLineExitInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SADDLE_L2NAME,
            this.HAS_COIL,
            this.COIL_NO,
            this.FlagSelected,
            this.WEIGHT,
            this.WIDTH,
            this.IN_DIA,
            this.OUT_DIA,
            this.SLEEVE_WIDTH});
            this.dataGridLineExitInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLineExitInfo.Location = new System.Drawing.Point(13, 25);
            this.dataGridLineExitInfo.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridLineExitInfo.Name = "dataGridLineExitInfo";
            this.dataGridLineExitInfo.ReadOnly = true;
            this.dataGridLineExitInfo.RowHeadersVisible = false;
            this.dataGridLineExitInfo.RowTemplate.Height = 45;
            this.dataGridLineExitInfo.Size = new System.Drawing.Size(1071, 466);
            this.dataGridLineExitInfo.TabIndex = 18;
            this.dataGridLineExitInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridLineExitInfo_CellClick);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightGray;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(1084, 25);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(13, 466);
            this.panel10.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(13, 466);
            this.panel3.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1097, 25);
            this.panel2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.cmdCanel);
            this.panel1.Controls.Add(this.cmdSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 491);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 84);
            this.panel1.TabIndex = 14;
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            // 
            // SADDLE_L2NAME
            // 
            this.SADDLE_L2NAME.FillWeight = 95.36802F;
            this.SADDLE_L2NAME.HeaderText = "SADDLE_L2NAME";
            this.SADDLE_L2NAME.Name = "SADDLE_L2NAME";
            this.SADDLE_L2NAME.ReadOnly = true;
            // 
            // HAS_COIL
            // 
            this.HAS_COIL.FillWeight = 95.36802F;
            this.HAS_COIL.HeaderText = "HAS_COIL";
            this.HAS_COIL.Name = "HAS_COIL";
            this.HAS_COIL.ReadOnly = true;
            // 
            // COIL_NO
            // 
            this.COIL_NO.FillWeight = 95.36802F;
            this.COIL_NO.HeaderText = "COIL_NO";
            this.COIL_NO.Name = "COIL_NO";
            this.COIL_NO.ReadOnly = true;
            // 
            // FlagSelected
            // 
            this.FlagSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FlagSelected.FillWeight = 137.0558F;
            this.FlagSelected.HeaderText = "";
            this.FlagSelected.Name = "FlagSelected";
            this.FlagSelected.ReadOnly = true;
            this.FlagSelected.Width = 30;
            // 
            // WEIGHT
            // 
            this.WEIGHT.FillWeight = 95.36802F;
            this.WEIGHT.HeaderText = "WEIGHT";
            this.WEIGHT.Name = "WEIGHT";
            this.WEIGHT.ReadOnly = true;
            // 
            // WIDTH
            // 
            this.WIDTH.FillWeight = 95.36802F;
            this.WIDTH.HeaderText = "WIDTH";
            this.WIDTH.Name = "WIDTH";
            this.WIDTH.ReadOnly = true;
            // 
            // IN_DIA
            // 
            this.IN_DIA.FillWeight = 95.36802F;
            this.IN_DIA.HeaderText = "IN_DIA";
            this.IN_DIA.Name = "IN_DIA";
            this.IN_DIA.ReadOnly = true;
            // 
            // OUT_DIA
            // 
            this.OUT_DIA.FillWeight = 95.36802F;
            this.OUT_DIA.HeaderText = "OUT_DIA";
            this.OUT_DIA.Name = "OUT_DIA";
            this.OUT_DIA.ReadOnly = true;
            // 
            // SLEEVE_WIDTH
            // 
            this.SLEEVE_WIDTH.FillWeight = 95.36802F;
            this.SLEEVE_WIDTH.HeaderText = "SLEEVE_WIDTH";
            this.SLEEVE_WIDTH.Name = "SLEEVE_WIDTH";
            this.SLEEVE_WIDTH.ReadOnly = true;
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdSelect.Location = new System.Drawing.Point(450, 14);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(176, 58);
            this.cmdSelect.TabIndex = 0;
            this.cmdSelect.Text = "选  择";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdCanel
            // 
            this.cmdCanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cmdCanel.Location = new System.Drawing.Point(717, 14);
            this.cmdCanel.Name = "cmdCanel";
            this.cmdCanel.Size = new System.Drawing.Size(176, 58);
            this.cmdCanel.TabIndex = 1;
            this.cmdCanel.Text = "取  消";
            this.cmdCanel.UseVisualStyleBackColor = true;
            this.cmdCanel.Click += new System.EventHandler(this.cmdCanel_Click);
            // 
            // PopD202Exit_CoilSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 575);
            this.Controls.Add(this.dataGridLineExitInfo);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PopD202Exit_CoilSelector";
            this.Text = "机组出口鞍座";
            this.Load += new System.EventHandler(this.PopD202Exit_CoilSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLineExitInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridLineExitInfo;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridViewTextBoxColumn SADDLE_L2NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAS_COIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn COIL_NO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FlagSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn WEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn WIDTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn IN_DIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn OUT_DIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLEEVE_WIDTH;
        private System.Windows.Forms.Button cmdCanel;
        private System.Windows.Forms.Button cmdSelect;
    }
}