namespace UACSParking
{
    partial class SubFrmTrainCaseTypeSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubFrmTrainCaseTypeSelect));
            this.button2 = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtRailwayLineNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrainCaseIndex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbbStowageType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrainCaseNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(180, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 13;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(49, 283);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 33);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtRailwayLineNO
            // 
            this.txtRailwayLineNO.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRailwayLineNO.Location = new System.Drawing.Point(130, 54);
            this.txtRailwayLineNO.Name = "txtRailwayLineNO";
            this.txtRailwayLineNO.Size = new System.Drawing.Size(150, 26);
            this.txtRailwayLineNO.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(50, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "轨道号：";
            // 
            // txtTrainCaseIndex
            // 
            this.txtTrainCaseIndex.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTrainCaseIndex.Location = new System.Drawing.Point(130, 104);
            this.txtTrainCaseIndex.Name = "txtTrainCaseIndex";
            this.txtTrainCaseIndex.Size = new System.Drawing.Size(150, 26);
            this.txtTrainCaseIndex.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(36, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "车皮索引：";
            // 
            // cmbbStowageType
            // 
            this.cmbbStowageType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbbStowageType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbbStowageType.FormattingEnabled = true;
            this.cmbbStowageType.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbbStowageType.Location = new System.Drawing.Point(130, 191);
            this.cmbbStowageType.Name = "cmbbStowageType";
            this.cmbbStowageType.Size = new System.Drawing.Size(150, 28);
            this.cmbbStowageType.TabIndex = 23;
            this.cmbbStowageType.Text = "空";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(45, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "车皮类：";
            // 
            // txtTrainCaseNO
            // 
            this.txtTrainCaseNO.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTrainCaseNO.Location = new System.Drawing.Point(130, 147);
            this.txtTrainCaseNO.Name = "txtTrainCaseNO";
            this.txtTrainCaseNO.Size = new System.Drawing.Size(150, 26);
            this.txtTrainCaseNO.TabIndex = 25;
            this.txtTrainCaseNO.TextChanged += new System.EventHandler(this.txtTrainCaseNO_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(46, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "车皮号：";
            // 
            // SubFrmTrainCaseTypeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(313, 371);
            this.Controls.Add(this.txtTrainCaseNO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbbStowageType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTrainCaseIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRailwayLineNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConfirm);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFrmTrainCaseTypeSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "火车皮类型选择";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtRailwayLineNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrainCaseIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbbStowageType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrainCaseNO;
        private System.Windows.Forms.Label label4;
    }
}