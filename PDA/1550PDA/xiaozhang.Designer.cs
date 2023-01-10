namespace _1550PDA
{
    partial class xiaozhang
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMAT = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.rbtnIn = new System.Windows.Forms.RadioButton();
            this.rbtnOut = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.rbtnSmall = new System.Windows.Forms.RadioButton();
            this.timer_RefreshL3Ack = new System.Windows.Forms.Timer();
            this.rbtnInvent = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.Text = "材料号:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.Text = "设备号:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.Text = "用户名:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.Text = "库区号:";
            // 
            // txtMAT
            // 
            this.txtMAT.Location = new System.Drawing.Point(97, 13);
            this.txtMAT.Name = "txtMAT";
            this.txtMAT.Size = new System.Drawing.Size(117, 21);
            this.txtMAT.TabIndex = 4;
            this.txtMAT.TextChanged += new System.EventHandler(this.txtMAT_TextChanged);
            this.txtMAT.Validated += new System.EventHandler(this.txtMAT_Validated);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(97, 88);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(117, 21);
            this.txtID.TabIndex = 5;
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(97, 129);
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(117, 21);
            this.txtSite.TabIndex = 5;
            this.txtSite.TextChanged += new System.EventHandler(this.txtSite_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(50, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "操作结果:";
            this.label5.Visible = false;
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(3, 234);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(232, 57);
            this.txtresult.TabIndex = 27;
            this.txtresult.TabStop = false;
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(97, 50);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.ReadOnly = true;
            this.txtDevice.Size = new System.Drawing.Size(117, 21);
            this.txtDevice.TabIndex = 5;
            // 
            // rbtnIn
            // 
            this.rbtnIn.Location = new System.Drawing.Point(12, 160);
            this.rbtnIn.Name = "rbtnIn";
            this.rbtnIn.Size = new System.Drawing.Size(100, 20);
            this.rbtnIn.TabIndex = 28;
            this.rbtnIn.TabStop = false;
            this.rbtnIn.Text = "入库销帐";
            this.rbtnIn.CheckedChanged += new System.EventHandler(this.rbtnIn_CheckedChanged);
            // 
            // rbtnOut
            // 
            this.rbtnOut.Checked = true;
            this.rbtnOut.Location = new System.Drawing.Point(12, 186);
            this.rbtnOut.Name = "rbtnOut";
            this.rbtnOut.Size = new System.Drawing.Size(100, 20);
            this.rbtnOut.TabIndex = 28;
            this.rbtnOut.Text = "出库销帐";
            this.rbtnOut.CheckedChanged += new System.EventHandler(this.rbtnOut_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(118, 182);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 46);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "退 出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rbtnSmall
            // 
            this.rbtnSmall.Location = new System.Drawing.Point(12, 212);
            this.rbtnSmall.Name = "rbtnSmall";
            this.rbtnSmall.Size = new System.Drawing.Size(100, 20);
            this.rbtnSmall.TabIndex = 28;
            this.rbtnSmall.TabStop = false;
            this.rbtnSmall.Text = "在制品出库";
            this.rbtnSmall.CheckedChanged += new System.EventHandler(this.rbtnSmall_CheckedChanged);
            // 
            // timer_RefreshL3Ack
            // 
            this.timer_RefreshL3Ack.Interval = 2000;
            this.timer_RefreshL3Ack.Tick += new System.EventHandler(this.timer_RefreshL3Ack_Tick);
            // 
            // rbtnInvent
            // 
            this.rbtnInvent.Location = new System.Drawing.Point(126, 158);
            this.rbtnInvent.Name = "rbtnInvent";
            this.rbtnInvent.Size = new System.Drawing.Size(100, 20);
            this.rbtnInvent.TabIndex = 35;
            this.rbtnInvent.Text = "盘库扫描";
            this.rbtnInvent.CheckedChanged += new System.EventHandler(this.radioInvent_CheckedChanged);
            // 
            // xiaozhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.rbtnInvent);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rbtnSmall);
            this.Controls.Add(this.rbtnOut);
            this.Controls.Add(this.rbtnIn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.txtDevice);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtMAT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "xiaozhang";
            this.Text = "手动销帐";
            this.Closed += new System.EventHandler(this.xiaozhang_Closed);
            this.Activated += new System.EventHandler(this.xiaozhang_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMAT;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.RadioButton rbtnIn;
        private System.Windows.Forms.RadioButton rbtnOut;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rbtnSmall;
        private System.Windows.Forms.Timer timer_RefreshL3Ack;
        private System.Windows.Forms.RadioButton rbtnInvent;
    }
}