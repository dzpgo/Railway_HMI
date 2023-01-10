namespace UACSParking
{
    partial class FrmCarEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarEntry));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPacking = new System.Windows.Forms.TextBox();
            this.txtCarNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtFlag = new System.Windows.Forms.ComboBox();
            this.txtDirection = new System.Windows.Forms.ComboBox();
            this.labTips = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCarType = new System.Windows.Forms.ComboBox();
            this.cbbScanCrane = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(49, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "停车位：";
            // 
            // txtPacking
            // 
            this.txtPacking.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPacking.Location = new System.Drawing.Point(120, 28);
            this.txtPacking.Name = "txtPacking";
            this.txtPacking.Size = new System.Drawing.Size(150, 26);
            this.txtPacking.TabIndex = 1;
            // 
            // txtCarNo
            // 
            this.txtCarNo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCarNo.Location = new System.Drawing.Point(120, 69);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(150, 26);
            this.txtCarNo.TabIndex = 3;
            this.txtCarNo.TextChanged += new System.EventHandler(this.txtCarNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(63, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "车号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(35, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "空满标记：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(35, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "车头方向：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(39, 311);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 33);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(170, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtFlag
            // 
            this.txtFlag.Enabled = false;
            this.txtFlag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtFlag.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFlag.FormattingEnabled = true;
            this.txtFlag.Items.AddRange(new object[] {
            "1",
            "2"});
            this.txtFlag.Location = new System.Drawing.Point(120, 110);
            this.txtFlag.Name = "txtFlag";
            this.txtFlag.Size = new System.Drawing.Size(150, 28);
            this.txtFlag.TabIndex = 10;
            this.txtFlag.Text = "空";
            // 
            // txtDirection
            // 
            this.txtDirection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtDirection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDirection.FormattingEnabled = true;
            this.txtDirection.Location = new System.Drawing.Point(120, 158);
            this.txtDirection.Name = "txtDirection";
            this.txtDirection.Size = new System.Drawing.Size(150, 28);
            this.txtDirection.TabIndex = 11;
            // 
            // labTips
            // 
            this.labTips.AutoSize = true;
            this.labTips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTips.Location = new System.Drawing.Point(12, 192);
            this.labTips.Name = "labTips";
            this.labTips.Size = new System.Drawing.Size(307, 17);
            this.labTips.TabIndex = 12;
            this.labTips.Text = "朝A跨南门为南，朝A跨北门为北。（框架以1号槽为准）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(35, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "车辆类型：";
            // 
            // cmbCarType
            // 
            this.cmbCarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCarType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCarType.FormattingEnabled = true;
            this.cmbCarType.Items.AddRange(new object[] {
            "框架车",
            "社会车"});
            this.cmbCarType.Location = new System.Drawing.Point(122, 219);
            this.cmbCarType.Name = "cmbCarType";
            this.cmbCarType.Size = new System.Drawing.Size(150, 28);
            this.cmbCarType.TabIndex = 14;
            // 
            // cbbScanCrane
            // 
            this.cbbScanCrane.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbbScanCrane.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbScanCrane.FormattingEnabled = true;
            this.cbbScanCrane.Items.AddRange(new object[] {
            "1#车",
            "2#车",
            "3#车"});
            this.cbbScanCrane.Location = new System.Drawing.Point(121, 261);
            this.cbbScanCrane.Name = "cbbScanCrane";
            this.cbbScanCrane.Size = new System.Drawing.Size(150, 28);
            this.cbbScanCrane.TabIndex = 16;
            this.cbbScanCrane.SelectedIndexChanged += new System.EventHandler(this.cbbScanCrane_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(32, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "扫描行车：";
            // 
            // FrmCarEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(313, 371);
            this.Controls.Add(this.cbbScanCrane);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCarType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labTips);
            this.Controls.Add(this.txtDirection);
            this.Controls.Add(this.txtFlag);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCarNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPacking);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmCarEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车入位";
            this.Activated += new System.EventHandler(this.FrmCarEntry_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPacking;
        private System.Windows.Forms.TextBox txtCarNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox txtFlag;
        private System.Windows.Forms.ComboBox txtDirection;
        private System.Windows.Forms.Label labTips;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCarType;
        private System.Windows.Forms.ComboBox cbbScanCrane;
        private System.Windows.Forms.Label label5;
    }
}