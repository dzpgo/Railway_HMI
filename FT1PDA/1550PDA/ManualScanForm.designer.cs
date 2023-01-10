namespace _1550PDA
{
    partial class ManualScanForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label_MatNo = new System.Windows.Forms.Label();
            this.label_StockNo = new System.Windows.Forms.Label();
            this.textBox_StockNo = new System.Windows.Forms.TextBox();
            this.textBox_MatNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "确认";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(140, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_MatNo
            // 
            this.label_MatNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label_MatNo.Location = new System.Drawing.Point(25, 81);
            this.label_MatNo.Name = "label_MatNo";
            this.label_MatNo.Size = new System.Drawing.Size(60, 21);
            this.label_MatNo.Text = "材料号";
            this.label_MatNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_StockNo
            // 
            this.label_StockNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label_StockNo.Location = new System.Drawing.Point(14, 39);
            this.label_StockNo.Name = "label_StockNo";
            this.label_StockNo.Size = new System.Drawing.Size(84, 21);
            this.label_StockNo.Text = "库位号";
            this.label_StockNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_StockNo
            // 
            this.textBox_StockNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_StockNo.Location = new System.Drawing.Point(83, 35);
            this.textBox_StockNo.Name = "textBox_StockNo";
            this.textBox_StockNo.Size = new System.Drawing.Size(141, 28);
            this.textBox_StockNo.TabIndex = 2;
            this.textBox_StockNo.TextChanged += new System.EventHandler(this.textBox_StockNo_TextChanged);
            // 
            // textBox_MatNo
            // 
            this.textBox_MatNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_MatNo.Location = new System.Drawing.Point(83, 76);
            this.textBox_MatNo.Name = "textBox_MatNo";
            this.textBox_MatNo.Size = new System.Drawing.Size(141, 28);
            this.textBox_MatNo.TabIndex = 3;
            // 
            // ManualScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 240);
            this.Controls.Add(this.textBox_MatNo);
            this.Controls.Add(this.textBox_StockNo);
            this.Controls.Add(this.label_StockNo);
            this.Controls.Add(this.label_MatNo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "ManualScanForm";
            this.Text = "确认";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_MatNo;
        private System.Windows.Forms.Label label_StockNo;
        private System.Windows.Forms.TextBox textBox_StockNo;
        private System.Windows.Forms.TextBox textBox_MatNo;
    }
}