namespace _1550PDA
{
    partial class subFrmXZ
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
            this.cmbTrainLine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTrainCase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbTrainLine
            // 
            this.cmbTrainLine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.cmbTrainLine.Items.Add("PT55");
            this.cmbTrainLine.Location = new System.Drawing.Point(89, 56);
            this.cmbTrainLine.Name = "cmbTrainLine";
            this.cmbTrainLine.Size = new System.Drawing.Size(117, 29);
            this.cmbTrainLine.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(19, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.Text = "轨道号";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(19, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "车皮号";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(19, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "取消";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(129, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 39);
            this.button2.TabIndex = 6;
            this.button2.Text = "确认";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTrainCase
            // 
            this.txtTrainCase.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.txtTrainCase.Location = new System.Drawing.Point(89, 116);
            this.txtTrainCase.Name = "txtTrainCase";
            this.txtTrainCase.Size = new System.Drawing.Size(117, 28);
            this.txtTrainCase.TabIndex = 9;
            this.txtTrainCase.TextChanged += new System.EventHandler(this.txtTrainCase_TextChanged);
            // 
            // subFrmXZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.txtTrainCase);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTrainLine);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.Name = "subFrmXZ";
            this.Text = "火车信息确认";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTrainLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTrainCase;
    }
}