namespace _1550PDA
{
    partial class FrmXZhang
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
            this.dg = new System.Windows.Forms.DataGrid();
            this.txtMatNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.btnRet = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.dg.Location = new System.Drawing.Point(0, 46);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(240, 169);
            this.dg.TabIndex = 0;
            this.dg.Click += new System.EventHandler(this.dg_Click);
            // 
            // txtMatNo
            // 
            this.txtMatNo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.txtMatNo.Location = new System.Drawing.Point(55, 15);
            this.txtMatNo.Name = "txtMatNo";
            this.txtMatNo.Size = new System.Drawing.Size(114, 24);
            this.txtMatNo.TabIndex = 88;
            this.txtMatNo.TextChanged += new System.EventHandler(this.txtMatNo_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(-2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.Text = "材料号";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Location = new System.Drawing.Point(173, 10);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(60, 30);
            this.btnSubmit.TabIndex = 87;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(3, 257);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(237, 34);
            this.txtresult.TabIndex = 91;
            // 
            // btnRet
            // 
            this.btnRet.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnRet.Location = new System.Drawing.Point(3, 221);
            this.btnRet.Name = "btnRet";
            this.btnRet.Size = new System.Drawing.Size(71, 30);
            this.btnRet.TabIndex = 94;
            this.btnRet.Text = "开始";
            this.btnRet.Click += new System.EventHandler(this.btnRet_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnDel.Location = new System.Drawing.Point(165, 221);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(71, 30);
            this.btnDel.TabIndex = 97;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click_1);
            // 
            // btnRedo
            // 
            this.btnRedo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnRedo.Location = new System.Drawing.Point(84, 221);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(71, 30);
            this.btnRedo.TabIndex = 99;
            this.btnRedo.Text = "重置";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // FrmXZhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRet);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.txtMatNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dg);
            this.Name = "FrmXZhang";
            this.Text = "装车销账";
            this.Activated += new System.EventHandler(this.FrmXZhang_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dg;
        private System.Windows.Forms.TextBox txtMatNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Button btnRet;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnRedo;
    }
}