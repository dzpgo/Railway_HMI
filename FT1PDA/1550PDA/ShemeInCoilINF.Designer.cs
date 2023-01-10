namespace _1550PDA
{
    partial class ShemeInCoilINF
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbxIsUnload = new System.Windows.Forms.ComboBox();
            this.cbxPackage = new System.Windows.Forms.ComboBox();
            this.txtCoilNo = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtGroove = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtLeft = new System.Windows.Forms.RadioButton();
            this.rbtRight = new System.Windows.Forms.RadioButton();
            this.checkBox_FlagRotate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.Text = "钢卷号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.Text = "是否卸下";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.Text = "包装状态";
            // 
            // cbxIsUnload
            // 
            this.cbxIsUnload.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbxIsUnload.Items.Add("是");
            this.cbxIsUnload.Items.Add("否");
            this.cbxIsUnload.Location = new System.Drawing.Point(110, 106);
            this.cbxIsUnload.Name = "cbxIsUnload";
            this.cbxIsUnload.Size = new System.Drawing.Size(100, 22);
            this.cbxIsUnload.TabIndex = 5;
            this.cbxIsUnload.SelectedIndexChanged += new System.EventHandler(this.cbxIsUnload_SelectedIndexChanged);
            // 
            // cbxPackage
            // 
            this.cbxPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbxPackage.Items.Add("已包装");
            this.cbxPackage.Items.Add("未包装");
            this.cbxPackage.Location = new System.Drawing.Point(110, 168);
            this.cbxPackage.Name = "cbxPackage";
            this.cbxPackage.Size = new System.Drawing.Size(100, 22);
            this.cbxPackage.TabIndex = 7;
            this.cbxPackage.SelectedIndexChanged += new System.EventHandler(this.cbxPackage_SelectedIndexChanged);
            // 
            // txtCoilNo
            // 
            this.txtCoilNo.Location = new System.Drawing.Point(110, 16);
            this.txtCoilNo.Name = "txtCoilNo";
            this.txtCoilNo.Size = new System.Drawing.Size(100, 21);
            this.txtCoilNo.TabIndex = 8;
            this.txtCoilNo.TextChanged += new System.EventHandler(this.txtCoilNo_TextChanged);
            this.txtCoilNo.GotFocus += new System.EventHandler(this.txtCoilNo_GotFocus);
            this.txtCoilNo.LostFocus += new System.EventHandler(this.txtCoilNo_LostFocus);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(37, 253);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 37);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(140, 253);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 37);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtGroove
            // 
            this.txtGroove.Location = new System.Drawing.Point(69, 55);
            this.txtGroove.Name = "txtGroove";
            this.txtGroove.Size = new System.Drawing.Size(44, 21);
            this.txtGroove.TabIndex = 30;
            this.txtGroove.TextChanged += new System.EventHandler(this.txtGroove_TextChanged);
            this.txtGroove.GotFocus += new System.EventHandler(this.txtGroove_GotFocus);
            this.txtGroove.LostFocus += new System.EventHandler(this.txtGroove_LostFocus);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.Text = "槽号";
            // 
            // rbtLeft
            // 
            this.rbtLeft.Location = new System.Drawing.Point(119, 55);
            this.rbtLeft.Name = "rbtLeft";
            this.rbtLeft.Size = new System.Drawing.Size(50, 20);
            this.rbtLeft.TabIndex = 44;
            this.rbtLeft.Text = "左";
            this.rbtLeft.CheckedChanged += new System.EventHandler(this.rbtLeft_CheckedChanged);
            // 
            // rbtRight
            // 
            this.rbtRight.Location = new System.Drawing.Point(170, 57);
            this.rbtRight.Name = "rbtRight";
            this.rbtRight.Size = new System.Drawing.Size(50, 20);
            this.rbtRight.TabIndex = 45;
            this.rbtRight.Text = "右";
            this.rbtRight.CheckedChanged += new System.EventHandler(this.rbtRight_CheckedChanged);
            // 
            // checkBox_FlagRotate
            // 
            this.checkBox_FlagRotate.Location = new System.Drawing.Point(24, 213);
            this.checkBox_FlagRotate.Name = "checkBox_FlagRotate";
            this.checkBox_FlagRotate.Size = new System.Drawing.Size(147, 20);
            this.checkBox_FlagRotate.TabIndex = 57;
            this.checkBox_FlagRotate.Text = "是否旋转带头";
            this.checkBox_FlagRotate.CheckStateChanged += new System.EventHandler(this.checkBox_FlagRotate_CheckStateChanged);
            // 
            // ShemeInCoilINF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.checkBox_FlagRotate);
            this.Controls.Add(this.rbtRight);
            this.Controls.Add(this.rbtLeft);
            this.Controls.Add(this.txtGroove);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCoilNo);
            this.Controls.Add(this.cbxPackage);
            this.Controls.Add(this.cbxIsUnload);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShemeInCoilINF";
            this.Text = "钢卷信息";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxIsUnload;
        private System.Windows.Forms.ComboBox cbxPackage;
        private System.Windows.Forms.TextBox txtCoilNo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtGroove;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbtLeft;
        private System.Windows.Forms.RadioButton rbtRight;
        private System.Windows.Forms.CheckBox checkBox_FlagRotate;
    }
}