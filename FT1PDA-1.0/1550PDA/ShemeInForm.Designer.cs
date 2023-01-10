namespace _1550PDA
{
    partial class ShemeInForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSummit = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.dataGrid1.Location = new System.Drawing.Point(2, 3);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(234, 183);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(-2, 188);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(78, 188);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSummit
            // 
            this.btnSummit.Location = new System.Drawing.Point(-2, 228);
            this.btnSummit.Name = "btnSummit";
            this.btnSummit.Size = new System.Drawing.Size(80, 40);
            this.btnSummit.TabIndex = 4;
            this.btnSummit.Text = "提交";
            this.btnSummit.Click += new System.EventHandler(this.btnSummit_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(158, 228);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 40);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "返回";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(158, 188);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(80, 40);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(88, 270);
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(147, 23);
            this.txtresult.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.Text = "操作结果";
            // 
            // ShemeInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSummit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGrid1);
            this.Name = "ShemeInForm";
            this.Text = "入库信息";
            this.Load += new System.EventHandler(this.ShemeInForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSummit;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label5;
    }
}