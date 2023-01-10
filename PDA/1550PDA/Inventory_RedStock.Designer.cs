namespace _1550PDA
{
    partial class Inventory_RedStock
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnManu = new System.Windows.Forms.Button();
            this.btnSumbit = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatNo = new System.Windows.Forms.TextBox();
            this.cbxRowNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label_RowDetail = new System.Windows.Forms.Label();
            this.btnManual = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular);
            this.dataGrid1.Location = new System.Drawing.Point(1, 58);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(234, 165);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // btnManu
            // 
            this.btnManu.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnManu.Location = new System.Drawing.Point(59, 224);
            this.btnManu.Name = "btnManu";
            this.btnManu.Size = new System.Drawing.Size(60, 34);
            this.btnManu.TabIndex = 1;
            this.btnManu.Text = "空";
            this.btnManu.Click += new System.EventHandler(this.btnManu_Click);
            // 
            // btnSumbit
            // 
            this.btnSumbit.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnSumbit.Location = new System.Drawing.Point(119, 224);
            this.btnSumbit.Name = "btnSumbit";
            this.btnSumbit.Size = new System.Drawing.Size(60, 34);
            this.btnSumbit.TabIndex = 2;
            this.btnSumbit.Text = "提交";
            this.btnSumbit.Click += new System.EventHandler(this.btnSumbit_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnRedo.Location = new System.Drawing.Point(179, 224);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(57, 34);
            this.btnRedo.TabIndex = 4;
            this.btnRedo.Text = "重置";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(1, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.Text = "操作结果:";
            // 
            // txtresult
            // 
            this.txtresult.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.txtresult.Location = new System.Drawing.Point(63, 259);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(173, 36);
            this.txtresult.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.Text = "扫描库位";
            // 
            // txtMatNo
            // 
            this.txtMatNo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.txtMatNo.Location = new System.Drawing.Point(68, 31);
            this.txtMatNo.Name = "txtMatNo";
            this.txtMatNo.ReadOnly = true;
            this.txtMatNo.Size = new System.Drawing.Size(111, 24);
            this.txtMatNo.TabIndex = 56;
            // 
            // cbxRowNo
            // 
            this.cbxRowNo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.cbxRowNo.Location = new System.Drawing.Point(68, 3);
            this.cbxRowNo.Name = "cbxRowNo";
            this.cbxRowNo.Size = new System.Drawing.Size(68, 25);
            this.cbxRowNo.TabIndex = 59;
            this.cbxRowNo.SelectedIndexChanged += new System.EventHandler(this.cbxRowNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.Text = "红库位排";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnSearch.Location = new System.Drawing.Point(2, 224);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 34);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label_RowDetail
            // 
            this.label_RowDetail.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.label_RowDetail.Location = new System.Drawing.Point(134, 5);
            this.label_RowDetail.Name = "label_RowDetail";
            this.label_RowDetail.Size = new System.Drawing.Size(102, 20);
            this.label_RowDetail.Text = "已核xx/共nn件";
            this.label_RowDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnManual
            // 
            this.btnManual.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnManual.Location = new System.Drawing.Point(184, 31);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(51, 24);
            this.btnManual.TabIndex = 64;
            this.btnManual.Text = "手输";
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // Inventory_RedStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.cbxRowNo);
            this.Controls.Add(this.label_RowDetail);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.txtMatNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSumbit);
            this.Controls.Add(this.btnManu);
            this.Controls.Add(this.dataGrid1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.Name = "Inventory_RedStock";
            this.Text = "红库位清单";
            this.Load += new System.EventHandler(this.Inventory_Check_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnManu;
        private System.Windows.Forms.Button btnSumbit;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatNo;
        private System.Windows.Forms.ComboBox cbxRowNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label_RowDetail;
        private System.Windows.Forms.Button btnManual;
    }
}