namespace UACSParking
{
    partial class FrmTrainArrive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrainArrive));
            this.button2 = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cmbbLineName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTrainSection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartPoint_X = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndPoint_X = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbScanCrane = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(172, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 11;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(41, 305);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 33);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cmbbLineName
            // 
            this.cmbbLineName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbbLineName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbbLineName.FormattingEnabled = true;
            this.cmbbLineName.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbbLineName.Location = new System.Drawing.Point(122, 32);
            this.cmbbLineName.Name = "cmbbLineName";
            this.cmbbLineName.Size = new System.Drawing.Size(150, 28);
            this.cmbbLineName.TabIndex = 15;
            this.cmbbLineName.Text = "空";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(46, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "轨道号：";
            // 
            // txtTrainSection
            // 
            this.txtTrainSection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTrainSection.Location = new System.Drawing.Point(124, 88);
            this.txtTrainSection.Name = "txtTrainSection";
            this.txtTrainSection.Size = new System.Drawing.Size(150, 26);
            this.txtTrainSection.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(39, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "火车节数：";
            // 
            // txtStartPoint_X
            // 
            this.txtStartPoint_X.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStartPoint_X.Location = new System.Drawing.Point(124, 141);
            this.txtStartPoint_X.Name = "txtStartPoint_X";
            this.txtStartPoint_X.Size = new System.Drawing.Size(150, 26);
            this.txtStartPoint_X.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(2, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 40);
            this.label3.TabIndex = 18;
            this.label3.Text = "扫描X开始坐标：\r\n        (毫米)";
            // 
            // txtEndPoint_X
            // 
            this.txtEndPoint_X.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEndPoint_X.Location = new System.Drawing.Point(124, 193);
            this.txtEndPoint_X.Name = "txtEndPoint_X";
            this.txtEndPoint_X.Size = new System.Drawing.Size(150, 26);
            this.txtEndPoint_X.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(2, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 40);
            this.label4.TabIndex = 20;
            this.label4.Text = "扫描X结束坐标：\r\n         (毫米)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(37, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "扫描行车：";
            // 
            // cbbScanCrane
            // 
            this.cbbScanCrane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbScanCrane.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbbScanCrane.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbScanCrane.FormattingEnabled = true;
            this.cbbScanCrane.Items.AddRange(new object[] {
            "1#车",
            "2#车"});
            this.cbbScanCrane.Location = new System.Drawing.Point(122, 247);
            this.cbbScanCrane.Name = "cbbScanCrane";
            this.cbbScanCrane.Size = new System.Drawing.Size(150, 28);
            this.cbbScanCrane.TabIndex = 23;
            // 
            // FrmTrainArrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(313, 371);
            this.Controls.Add(this.cbbScanCrane);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEndPoint_X);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStartPoint_X);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTrainSection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbbLineName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConfirm);
            this.Name = "FrmTrainArrive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "火车到达";
            this.Activated += new System.EventHandler(this.FrmTrainArrive_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cmbbLineName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTrainSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartPoint_X;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndPoint_X;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbScanCrane;
    }
}