namespace _1550PDA
{
    partial class PreSendForm
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtPresendno = new System.Windows.Forms.TextBox();
            this.txtMatno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(19, 191);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 50);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(125, 191);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 50);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtPresendno
            // 
            this.txtPresendno.Location = new System.Drawing.Point(82, 141);
            this.txtPresendno.Name = "txtPresendno";
            this.txtPresendno.Size = new System.Drawing.Size(137, 23);
            this.txtPresendno.TabIndex = 3;
            this.txtPresendno.TextChanged += new System.EventHandler(this.txtPresendno_TextChanged);
            // 
            // txtMatno
            // 
            this.txtMatno.Location = new System.Drawing.Point(82, 84);
            this.txtMatno.Name = "txtMatno";
            this.txtMatno.Size = new System.Drawing.Size(137, 23);
            this.txtMatno.TabIndex = 2;
            this.txtMatno.TextChanged += new System.EventHandler(this.txtMatno_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.Text = "钢卷号:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.Text = "准发号:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.Text = "操作结果:";
            // 
            // txtresult
            // 
            this.txtresult.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtresult.Location = new System.Drawing.Point(75, 244);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.Size = new System.Drawing.Size(157, 49);
            this.txtresult.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.Text = "唛头号:";
            // 
            // txtMT
            // 
            this.txtMT.Location = new System.Drawing.Point(84, 31);
            this.txtMT.Name = "txtMT";
            this.txtMT.Size = new System.Drawing.Size(137, 23);
            this.txtMT.TabIndex = 12;
            this.txtMT.Tag = "1";
            this.txtMT.TextChanged += new System.EventHandler(this.txtMT_TextChanged);
            // 
            // PreSendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.txtMT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMatno);
            this.Controls.Add(this.txtPresendno);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Name = "PreSendForm";
            this.Text = "准发扫描";
            this.Load += new System.EventHandler(this.PreSendForm_Load);
            this.Activated += new System.EventHandler(this.PreSendForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtPresendno;
        private System.Windows.Forms.TextBox txtMatno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMT;
    }
}