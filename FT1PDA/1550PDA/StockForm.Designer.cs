namespace _1550PDA
{
    partial class StockForm
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
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dg = new System.Windows.Forms.DataGrid();
            this.txtSaddle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRet = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatNum = new System.Windows.Forms.TextBox();
            this.txtMatNo = new System.Windows.Forms.TextBox();
            this.btnRedo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.btncheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(89, 246);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(147, 47);
            this.txtresult.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.Text = "操作结果";
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular);
            this.dg.Location = new System.Drawing.Point(4, 60);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(232, 147);
            this.dg.TabIndex = 67;
            this.dg.Click += new System.EventHandler(this.dg_Click);
            // 
            // txtSaddle
            // 
            this.txtSaddle.Location = new System.Drawing.Point(57, 5);
            this.txtSaddle.Name = "txtSaddle";
            this.txtSaddle.Size = new System.Drawing.Size(114, 21);
            this.txtSaddle.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.Text = "垛位";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(95, 210);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(47, 30);
            this.btnDel.TabIndex = 77;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRet
            // 
            this.btnRet.Location = new System.Drawing.Point(1, 210);
            this.btnRet.Name = "btnRet";
            this.btnRet.Size = new System.Drawing.Size(47, 30);
            this.btnRet.TabIndex = 77;
            this.btnRet.Text = "开始";
            this.btnRet.Click += new System.EventHandler(this.btnRet_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(175, 28);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(60, 30);
            this.btnSubmit.TabIndex = 77;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.Text = "材料号";
            // 
            // txtMatNum
            // 
            this.txtMatNum.Location = new System.Drawing.Point(201, 4);
            this.txtMatNum.Name = "txtMatNum";
            this.txtMatNum.Size = new System.Drawing.Size(34, 21);
            this.txtMatNum.TabIndex = 66;
            // 
            // txtMatNo
            // 
            this.txtMatNo.Location = new System.Drawing.Point(57, 33);
            this.txtMatNo.Name = "txtMatNo";
            this.txtMatNo.Size = new System.Drawing.Size(114, 21);
            this.txtMatNo.TabIndex = 85;
            this.txtMatNo.TextChanged += new System.EventHandler(this.txtMatNo_TextChanged);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(48, 210);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(47, 30);
            this.btnRedo.TabIndex = 91;
            this.btnRedo.Text = "重置";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(177, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.Text = "件";
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(142, 210);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(47, 30);
            this.btnEmpty.TabIndex = 96;
            this.btnEmpty.Text = "空";
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btncheck
            // 
            this.btncheck.Location = new System.Drawing.Point(189, 210);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(47, 30);
            this.btncheck.TabIndex = 101;
            this.btncheck.Text = "复核";
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btncheck);
            this.Controls.Add(this.btnEmpty);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.txtMatNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnRet);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.txtMatNum);
            this.Controls.Add(this.txtSaddle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "StockForm";
            this.Text = "库位信息";
            this.Load += new System.EventHandler(this.StockForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGrid dg;
        private System.Windows.Forms.TextBox txtSaddle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnRet;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatNum;
        private System.Windows.Forms.TextBox txtMatNo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEmpty;
        private System.Windows.Forms.Button btncheck;
    }
}