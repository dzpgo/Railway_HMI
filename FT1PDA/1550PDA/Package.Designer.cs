namespace _1550PDA
{
    partial class Package
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
            this.chbUp = new System.Windows.Forms.CheckBox();
            this.chbDown = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.cbxPackageType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtMatno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesUnit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "材料号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "生产标签";
            // 
            // chbUp
            // 
            this.chbUp.Location = new System.Drawing.Point(80, 153);
            this.chbUp.Name = "chbUp";
            this.chbUp.Size = new System.Drawing.Size(79, 20);
            this.chbUp.TabIndex = 2;
            this.chbUp.Text = "上开卷";
            // 
            // chbDown
            // 
            this.chbDown.Location = new System.Drawing.Point(156, 153);
            this.chbDown.Name = "chbDown";
            this.chbDown.Size = new System.Drawing.Size(76, 20);
            this.chbDown.TabIndex = 3;
            this.chbDown.Text = "下开卷";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(9, 218);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 49);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "确认";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(139, 218);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 49);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "返回";
            // 
            // cbxPackageType
            // 
            this.cbxPackageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbxPackageType.Items.Add("简易包装");
            this.cbxPackageType.Items.Add("成品包装");
            this.cbxPackageType.Location = new System.Drawing.Point(103, 110);
            this.cbxPackageType.Name = "cbxPackageType";
            this.cbxPackageType.Size = new System.Drawing.Size(116, 23);
            this.cbxPackageType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "包装类型";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.Text = "开卷方向";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(103, 67);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(116, 23);
            this.txtProduct.TabIndex = 11;
            // 
            // txtMatno
            // 
            this.txtMatno.Location = new System.Drawing.Point(103, 23);
            this.txtMatno.Name = "txtMatno";
            this.txtMatno.Size = new System.Drawing.Size(116, 23);
            this.txtMatno.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "操作结果:";
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(80, 270);
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(156, 23);
            this.txtresult.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.Text = "目标位置";
            // 
            // txtDesUnit
            // 
            this.txtDesUnit.Location = new System.Drawing.Point(103, 184);
            this.txtDesUnit.Name = "txtDesUnit";
            this.txtDesUnit.Size = new System.Drawing.Size(116, 23);
            this.txtDesUnit.TabIndex = 34;
            // 
            // Package
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.txtDesUnit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chbUp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.txtMatno);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxPackageType);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.chbDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Package";
            this.Text = "离线包装";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbUp;
        private System.Windows.Forms.CheckBox chbDown;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cbxPackageType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtMatno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesUnit;
    }
}