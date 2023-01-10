namespace _1550PDA
{
    partial class Inventory_Single
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
            this.btnExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtMAT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(142, 187);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 46);
            this.btnExit.TabIndex = 42;
            this.btnExit.Text = "退 出";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "操作结果:";
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(80, 255);
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(149, 23);
            this.txtresult.TabIndex = 39;
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(97, 144);
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(117, 23);
            this.txtSite.TabIndex = 36;
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(97, 65);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.ReadOnly = true;
            this.txtDevice.Size = new System.Drawing.Size(117, 23);
            this.txtDevice.TabIndex = 38;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(97, 103);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(117, 23);
            this.txtID.TabIndex = 37;
            // 
            // txtMAT
            // 
            this.txtMAT.Location = new System.Drawing.Point(97, 28);
            this.txtMAT.Name = "txtMAT";
            this.txtMAT.Size = new System.Drawing.Size(117, 23);
            this.txtMAT.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.Text = "库区号:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.Text = "设备号:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.Text = "材料号:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(38, 187);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(72, 46);
            this.btnSubmit.TabIndex = 42;
            this.btnSubmit.Text = "提 交";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Inventory_Single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.txtDevice);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtMAT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Inventory_Single";
            this.Text = "单个盘库";
            this.Closed += new System.EventHandler(this.Inventory_Single_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtMAT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
    }
}