namespace _1550PDA
{
    partial class ShemeInTruck
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
            this.cbxTruckPostion = new System.Windows.Forms.ComboBox();
            this.txtTruckNo = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.cbxHeadDirection = new System.Windows.Forms.ComboBox();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbnIn = new System.Windows.Forms.RadioButton();
            this.rbnOut = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbxCarType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxParkingType = new System.Windows.Forms.ComboBox();
            this.chbChooseCN = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "车位号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.Text = "车号";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "车头方向";
            // 
            // cbxTruckPostion
            // 
            this.cbxTruckPostion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbxTruckPostion.Items.Add("FT101");
            this.cbxTruckPostion.Items.Add("FT102");
            this.cbxTruckPostion.Items.Add("FT103");
            this.cbxTruckPostion.Items.Add("FT104");
            this.cbxTruckPostion.Items.Add("FT105");
            this.cbxTruckPostion.Items.Add("FT106");
            this.cbxTruckPostion.Items.Add("FT107");
            this.cbxTruckPostion.Items.Add("FT108");
            this.cbxTruckPostion.Items.Add("FT109");
            this.cbxTruckPostion.Location = new System.Drawing.Point(118, 50);
            this.cbxTruckPostion.Name = "cbxTruckPostion";
            this.cbxTruckPostion.Size = new System.Drawing.Size(101, 22);
            this.cbxTruckPostion.TabIndex = 3;
            this.cbxTruckPostion.SelectedIndexChanged += new System.EventHandler(this.cbxTruckPostion_SelectedIndexChanged);
            // 
            // txtTruckNo
            // 
            this.txtTruckNo.Location = new System.Drawing.Point(116, 149);
            this.txtTruckNo.Name = "txtTruckNo";
            this.txtTruckNo.Size = new System.Drawing.Size(70, 21);
            this.txtTruckNo.TabIndex = 4;
            this.txtTruckNo.TextChanged += new System.EventHandler(this.txtTruckNo_TextChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(32, 210);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(77, 51);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(128, 210);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(77, 51);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Text = "返回";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // cbxHeadDirection
            // 
            this.cbxHeadDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbxHeadDirection.Items.Add("W");
            this.cbxHeadDirection.Items.Add("S");
            this.cbxHeadDirection.Items.Add("N");
            this.cbxHeadDirection.Items.Add("E");
            this.cbxHeadDirection.Location = new System.Drawing.Point(116, 183);
            this.cbxHeadDirection.Name = "cbxHeadDirection";
            this.cbxHeadDirection.Size = new System.Drawing.Size(102, 22);
            this.cbxHeadDirection.TabIndex = 15;
            this.cbxHeadDirection.SelectedIndexChanged += new System.EventHandler(this.cbxHeadDirection_SelectedIndexChanged);
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(70, 270);
            this.txtresult.Name = "txtresult";
            this.txtresult.Size = new System.Drawing.Size(165, 21);
            this.txtresult.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "操作结果";
            // 
            // rbnIn
            // 
            this.rbnIn.Checked = true;
            this.rbnIn.Location = new System.Drawing.Point(19, 11);
            this.rbnIn.Name = "rbnIn";
            this.rbnIn.Size = new System.Drawing.Size(100, 20);
            this.rbnIn.TabIndex = 32;
            this.rbnIn.TabStop = false;
            this.rbnIn.Text = "入库";
            this.rbnIn.CheckedChanged += new System.EventHandler(this.rbnIn_CheckedChanged);
            // 
            // rbnOut
            // 
            this.rbnOut.Location = new System.Drawing.Point(122, 12);
            this.rbnOut.Name = "rbnOut";
            this.rbnOut.Size = new System.Drawing.Size(100, 20);
            this.rbnOut.TabIndex = 33;
            this.rbnOut.TabStop = false;
            this.rbnOut.Text = "出库";
            this.rbnOut.CheckedChanged += new System.EventHandler(this.rbnOut_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.Silver;
            this.linkLabel1.Location = new System.Drawing.Point(70, 151);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(38, 20);
            this.linkLabel1.TabIndex = 46;
            this.linkLabel1.Text = "空";
            this.linkLabel1.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // cbxCarType
            // 
            this.cbxCarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbxCarType.Items.Add("标准框架");
            this.cbxCarType.Items.Add("标准社会车辆");
            this.cbxCarType.Items.Add("大头娃娃车");
            this.cbxCarType.Items.Add("17m社会车辆");
            this.cbxCarType.Location = new System.Drawing.Point(118, 85);
            this.cbxCarType.Name = "cbxCarType";
            this.cbxCarType.Size = new System.Drawing.Size(101, 22);
            this.cbxCarType.TabIndex = 54;
            this.cbxCarType.SelectedIndexChanged += new System.EventHandler(this.cbxCarType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(22, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "车辆类型";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(21, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "车位类型";
            // 
            // cbxParkingType
            // 
            this.cbxParkingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbxParkingType.Items.Add("大框");
            this.cbxParkingType.Items.Add("小框");
            this.cbxParkingType.Location = new System.Drawing.Point(116, 120);
            this.cbxParkingType.Name = "cbxParkingType";
            this.cbxParkingType.Size = new System.Drawing.Size(101, 22);
            this.cbxParkingType.TabIndex = 62;
            this.cbxParkingType.SelectedIndexChanged += new System.EventHandler(this.cbxParkingType_SelectedIndexChanged);
            // 
            // chbChooseCN
            // 
            this.chbChooseCN.Location = new System.Drawing.Point(190, 151);
            this.chbChooseCN.Name = "chbChooseCN";
            this.chbChooseCN.Size = new System.Drawing.Size(45, 20);
            this.chbChooseCN.TabIndex = 69;
            this.chbChooseCN.Text = "挂";
            this.chbChooseCN.CheckStateChanged += new System.EventHandler(this.chbChooseCN_CheckStateChanged);
            // 
            // ShemeInTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.chbChooseCN);
            this.Controls.Add(this.cbxParkingType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxCarType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.rbnOut);
            this.Controls.Add(this.rbnIn);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxHeadDirection);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtTruckNo);
            this.Controls.Add(this.cbxTruckPostion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShemeInTruck";
            this.Text = "卡车入位";
            this.Closed += new System.EventHandler(this.ShemeInTruck_Closed);
            this.Activated += new System.EventHandler(this.ShemeInTruck_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxTruckPostion;
        private System.Windows.Forms.TextBox txtTruckNo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ComboBox cbxHeadDirection;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbnIn;
        private System.Windows.Forms.RadioButton rbnOut;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cbxCarType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxParkingType;
        private System.Windows.Forms.CheckBox chbChooseCN;
    }
}