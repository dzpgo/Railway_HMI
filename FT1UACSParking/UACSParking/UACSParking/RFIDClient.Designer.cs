namespace UACSParking
{
    partial class RFIDClien
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFIDClien));
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnChangCarStatus = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnNOppen = new System.Windows.Forms.Button();
            this.btnNClose = new System.Windows.Forms.Button();
            this.btnSOpen = new System.Windows.Forms.Button();
            this.btnSClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCarStatusSet0 = new System.Windows.Forms.Button();
            this.txtCarNO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Enabled = false;
            this.txtIP.Location = new System.Drawing.Point(108, 10);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192.168.10.105";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(269, 10);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "3005";
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Location = new System.Drawing.Point(405, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(97, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接服务器";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 39);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(1049, 261);
            this.txtInfo.TabIndex = 3;
            this.txtInfo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "RFID Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "端口";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 335);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(307, 96);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "RFID Tag";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "通过道闸车辆";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(325, 335);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(220, 96);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(325, 450);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(109, 20);
            this.comboBox1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "手工设置状态";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1：在库区内",
            "0：在库区外",
            "-1：其他状态"});
            this.comboBox2.Location = new System.Drawing.Point(582, 374);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(133, 24);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.Text = "1：在库区内";
            // 
            // btnChangCarStatus
            // 
            this.btnChangCarStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangCarStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangCarStatus.Location = new System.Drawing.Point(582, 410);
            this.btnChangCarStatus.Name = "btnChangCarStatus";
            this.btnChangCarStatus.Size = new System.Drawing.Size(133, 38);
            this.btnChangCarStatus.TabIndex = 14;
            this.btnChangCarStatus.Text = "修改";
            this.btnChangCarStatus.UseVisualStyleBackColor = true;
            this.btnChangCarStatus.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnNOppen
            // 
            this.btnNOppen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNOppen.BackgroundImage")));
            this.btnNOppen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNOppen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNOppen.ForeColor = System.Drawing.Color.White;
            this.btnNOppen.Location = new System.Drawing.Point(1137, 48);
            this.btnNOppen.Name = "btnNOppen";
            this.btnNOppen.Size = new System.Drawing.Size(133, 38);
            this.btnNOppen.TabIndex = 34;
            this.btnNOppen.Text = "北道闸开";
            this.btnNOppen.UseVisualStyleBackColor = true;
            this.btnNOppen.Click += new System.EventHandler(this.btnNOppen_Click);
            // 
            // btnNClose
            // 
            this.btnNClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNClose.BackgroundImage")));
            this.btnNClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNClose.ForeColor = System.Drawing.Color.White;
            this.btnNClose.Location = new System.Drawing.Point(1137, 101);
            this.btnNClose.Name = "btnNClose";
            this.btnNClose.Size = new System.Drawing.Size(133, 38);
            this.btnNClose.TabIndex = 35;
            this.btnNClose.Text = "北道闸关";
            this.btnNClose.UseVisualStyleBackColor = true;
            this.btnNClose.Click += new System.EventHandler(this.btnNClose_Click);
            // 
            // btnSOpen
            // 
            this.btnSOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSOpen.BackgroundImage")));
            this.btnSOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSOpen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSOpen.ForeColor = System.Drawing.Color.White;
            this.btnSOpen.Location = new System.Drawing.Point(1137, 158);
            this.btnSOpen.Name = "btnSOpen";
            this.btnSOpen.Size = new System.Drawing.Size(133, 38);
            this.btnSOpen.TabIndex = 36;
            this.btnSOpen.Text = "南道闸开";
            this.btnSOpen.UseVisualStyleBackColor = true;
            this.btnSOpen.Click += new System.EventHandler(this.btnSOpen_Click);
            // 
            // btnSClose
            // 
            this.btnSClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSClose.BackgroundImage")));
            this.btnSClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSClose.ForeColor = System.Drawing.Color.White;
            this.btnSClose.Location = new System.Drawing.Point(1137, 216);
            this.btnSClose.Name = "btnSClose";
            this.btnSClose.Size = new System.Drawing.Size(133, 38);
            this.btnSClose.TabIndex = 37;
            this.btnSClose.Text = "南道闸关";
            this.btnSClose.UseVisualStyleBackColor = true;
            this.btnSClose.Click += new System.EventHandler(this.btnSClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(663, 580);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(545, 46);
            this.label6.TabIndex = 38;
            this.label6.Text = "此画面关闭后道闸将不会自动运行";
            // 
            // btnCarStatusSet0
            // 
            this.btnCarStatusSet0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCarStatusSet0.BackgroundImage")));
            this.btnCarStatusSet0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCarStatusSet0.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarStatusSet0.ForeColor = System.Drawing.Color.White;
            this.btnCarStatusSet0.Location = new System.Drawing.Point(1137, 283);
            this.btnCarStatusSet0.Name = "btnCarStatusSet0";
            this.btnCarStatusSet0.Size = new System.Drawing.Size(133, 38);
            this.btnCarStatusSet0.TabIndex = 39;
            this.btnCarStatusSet0.Text = "车辆状态置0";
            this.btnCarStatusSet0.UseVisualStyleBackColor = true;
            this.btnCarStatusSet0.Click += new System.EventHandler(this.btnCarStatusSet0_Click);
            // 
            // txtCarNO
            // 
            this.txtCarNO.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCarNO.Location = new System.Drawing.Point(582, 335);
            this.txtCarNO.Name = "txtCarNO";
            this.txtCarNO.Size = new System.Drawing.Size(133, 26);
            this.txtCarNO.TabIndex = 40;
            this.txtCarNO.Text = "输入车头号";
            // 
            // RFIDClien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 662);
            this.Controls.Add(this.txtCarNO);
            this.Controls.Add(this.btnCarStatusSet0);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSClose);
            this.Controls.Add(this.btnSOpen);
            this.Controls.Add(this.btnNClose);
            this.Controls.Add(this.btnNOppen);
            this.Controls.Add(this.btnChangCarStatus);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Name = "RFIDClien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "道闸数据接收画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RFIDClien_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnChangCarStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnNOppen;
        private System.Windows.Forms.Button btnNClose;
        private System.Windows.Forms.Button btnSOpen;
        private System.Windows.Forms.Button btnSClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCarStatusSet0;
        private System.Windows.Forms.TextBox txtCarNO;
    }
}

