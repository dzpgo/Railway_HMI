namespace _1550PDA
{
    partial class LoginForm
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxStoreID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(24, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.Text = "用户名";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.txtUsername.Location = new System.Drawing.Point(118, 55);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 28);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.LostFocus += new System.EventHandler(this.txtUsername_LostFocus);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.txtPassword.Location = new System.Drawing.Point(118, 144);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 28);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.GotFocus += new System.EventHandler(this.txtPassword_GotFocus);
            this.txtPassword.LostFocus += new System.EventHandler(this.txtPassword_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(24, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.Text = "密码";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnLogin.Location = new System.Drawing.Point(24, 201);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(66, 51);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnQuit.Location = new System.Drawing.Point(152, 201);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(66, 51);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "退出";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(24, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.Text = "库区";
            // 
            // cbxStoreID
            // 
            this.cbxStoreID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.cbxStoreID.Items.Add("FT1");
            this.cbxStoreID.Location = new System.Drawing.Point(118, 103);
            this.cbxStoreID.Name = "cbxStoreID";
            this.cbxStoreID.Size = new System.Drawing.Size(100, 29);
            this.cbxStoreID.TabIndex = 11;
            this.cbxStoreID.SelectedIndexChanged += new System.EventHandler(this.cbxStoreID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(3, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "操作结果";
            // 
            // txtresult
            // 
            this.txtresult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.txtresult.Location = new System.Drawing.Point(70, 263);
            this.txtresult.Name = "txtresult";
            this.txtresult.Size = new System.Drawing.Size(165, 28);
            this.txtresult.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(5, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.Text = "版本号：20180104-1";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxStoreID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxStoreID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label5;
    }
}

