namespace _1550PDA
{
    partial class ShemeInFrom_Tai
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
            this.txtCoilNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLenth = new System.Windows.Forms.TextBox();
            this.cbxDirection = new System.Windows.Forms.ComboBox();
            this.cbxIsPackage = new System.Windows.Forms.ComboBox();
            this.btnSummit = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.Text = "钢卷号";
            // 
            // txtCoilNo
            // 
            this.txtCoilNo.Location = new System.Drawing.Point(107, 30);
            this.txtCoilNo.Name = "txtCoilNo";
            this.txtCoilNo.Size = new System.Drawing.Size(117, 23);
            this.txtCoilNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.Text = "开卷方向";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.Text = "是否包装";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.Text = "套筒长度";
            // 
            // txtLenth
            // 
            this.txtLenth.Location = new System.Drawing.Point(107, 181);
            this.txtLenth.Name = "txtLenth";
            this.txtLenth.Size = new System.Drawing.Size(117, 23);
            this.txtLenth.TabIndex = 8;
            // 
            // cbxDirection
            // 
            this.cbxDirection.Location = new System.Drawing.Point(107, 80);
            this.cbxDirection.Name = "cbxDirection";
            this.cbxDirection.Size = new System.Drawing.Size(117, 23);
            this.cbxDirection.TabIndex = 9;
            // 
            // cbxIsPackage
            // 
            this.cbxIsPackage.Location = new System.Drawing.Point(107, 130);
            this.cbxIsPackage.Name = "cbxIsPackage";
            this.cbxIsPackage.Size = new System.Drawing.Size(117, 23);
            this.cbxIsPackage.TabIndex = 10;
            // 
            // btnSummit
            // 
            this.btnSummit.Location = new System.Drawing.Point(23, 229);
            this.btnSummit.Name = "btnSummit";
            this.btnSummit.Size = new System.Drawing.Size(86, 44);
            this.btnSummit.TabIndex = 11;
            this.btnSummit.Text = "提交";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(134, 229);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(86, 44);
            this.btnQuit.TabIndex = 12;
            this.btnQuit.Text = "返回";
            // 
            // ShemeInFrom_Tai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSummit);
            this.Controls.Add(this.cbxIsPackage);
            this.Controls.Add(this.cbxDirection);
            this.Controls.Add(this.txtLenth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCoilNo);
            this.Controls.Add(this.label1);
            this.Name = "ShemeInFrom_Tai";
            this.Text = "台车入库";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCoilNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLenth;
        private System.Windows.Forms.ComboBox cbxDirection;
        private System.Windows.Forms.ComboBox cbxIsPackage;
        private System.Windows.Forms.Button btnSummit;
        private System.Windows.Forms.Button btnQuit;
    }
}