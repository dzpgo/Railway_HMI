namespace _1550PDA
{
    partial class ShemeOutAssemble
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
            this.btnManual = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnACK = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCarIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.dataGrid1.Location = new System.Drawing.Point(2, 4);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(234, 182);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(118, 191);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(60, 40);
            this.btnManual.TabIndex = 1;
            this.btnManual.Text = "手动";
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(-2, 230);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(80, 40);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(178, 191);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(78, 230);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 40);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(69, 271);
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(166, 23);
            this.txtresult.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.Text = "操作结果";
            // 
            // btnACK
            // 
            this.btnACK.Location = new System.Drawing.Point(158, 230);
            this.btnACK.Name = "btnACK";
            this.btnACK.Size = new System.Drawing.Size(80, 40);
            this.btnACK.TabIndex = 46;
            this.btnACK.Text = "应答";
            this.btnACK.Click += new System.EventHandler(this.btnACK_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(58, 191);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 40);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCarIn
            // 
            this.btnCarIn.Location = new System.Drawing.Point(-2, 191);
            this.btnCarIn.Name = "btnCarIn";
            this.btnCarIn.Size = new System.Drawing.Size(60, 40);
            this.btnCarIn.TabIndex = 50;
            this.btnCarIn.Text = "入位";
            this.btnCarIn.Click += new System.EventHandler(this.btnCarIn_Click);
            // 
            // ShemeOutAssemble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnCarIn);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnACK);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnManual);
            this.Name = "ShemeOutAssemble";
            this.Text = "拼车装车";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnACK;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCarIn;
    }
}