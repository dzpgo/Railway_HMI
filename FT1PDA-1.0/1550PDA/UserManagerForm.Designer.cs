namespace _1550PDA
{
    partial class UserManagerForm
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
            this.btnCreatUser = new System.Windows.Forms.Button();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreatUser
            // 
            this.btnCreatUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnCreatUser.Location = new System.Drawing.Point(62, 32);
            this.btnCreatUser.Name = "btnCreatUser";
            this.btnCreatUser.Size = new System.Drawing.Size(114, 53);
            this.btnCreatUser.TabIndex = 7;
            this.btnCreatUser.Text = "创建用户";
            this.btnCreatUser.Click += new System.EventHandler(this.btnCreatUser_Click);
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnModifyUser.Location = new System.Drawing.Point(62, 107);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(114, 53);
            this.btnModifyUser.TabIndex = 8;
            this.btnModifyUser.Text = "修改密码";
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnDeleteUser.Location = new System.Drawing.Point(62, 186);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(114, 53);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "删除用户";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // UserManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnModifyUser);
            this.Controls.Add(this.btnCreatUser);
            this.Name = "UserManagerForm";
            this.Text = "用户管理画面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreatUser;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Button btnDeleteUser;
    }
}