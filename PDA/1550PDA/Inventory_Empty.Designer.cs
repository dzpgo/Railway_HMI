namespace _1550PDA
{
    partial class Inventory_Empty
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaddle = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSummit = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label_RowCnt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.Text = "库位号";
            // 
            // txtSaddle
            // 
            this.txtSaddle.Location = new System.Drawing.Point(67, 2);
            this.txtSaddle.Name = "txtSaddle";
            this.txtSaddle.Size = new System.Drawing.Size(123, 23);
            this.txtSaddle.TabIndex = 1;
            this.txtSaddle.TextChanged += new System.EventHandler(this.txtSaddle_TextChanged);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 31);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(232, 141);
            this.dataGrid1.TabIndex = 2;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(81, 178);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(160, 178);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(72, 30);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSummit
            // 
            this.btnSummit.Location = new System.Drawing.Point(3, 210);
            this.btnSummit.Name = "btnSummit";
            this.btnSummit.Size = new System.Drawing.Size(72, 30);
            this.btnSummit.TabIndex = 5;
            this.btnSummit.Text = "提交";
            this.btnSummit.Click += new System.EventHandler(this.btnSummit_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(81, 210);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(72, 30);
            this.btnRedo.TabIndex = 7;
            this.btnRedo.Text = "重置";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(67, 246);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(166, 47);
            this.txtresult.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(2, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.Text = "操作结果";
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(159, 210);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(72, 30);
            this.btnCheck.TabIndex = 98;
            this.btnCheck.Text = "复核";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 178);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 30);
            this.btnStart.TabIndex = 99;
            this.btnStart.Text = "开始";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label_RowCnt
            // 
            this.label_RowCnt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.label_RowCnt.Location = new System.Drawing.Point(192, 4);
            this.label_RowCnt.Name = "label_RowCnt";
            this.label_RowCnt.Size = new System.Drawing.Size(43, 20);
            this.label_RowCnt.Text = "0 件";
            // 
            // Inventory_Empty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label_RowCnt);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnSummit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.txtSaddle);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.Name = "Inventory_Empty";
            this.Text = "空库位确认";
            this.Load += new System.EventHandler(this.Inventory_Empty_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaddle;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSummit;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label_RowCnt;
    }
}