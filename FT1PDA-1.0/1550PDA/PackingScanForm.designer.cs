namespace _1550PDA
{
    partial class PackingScanForm
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
            this.button_subMit = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.label_MatNo = new System.Windows.Forms.Label();
            this.label_StockNo = new System.Windows.Forms.Label();
            this.textBox_StockNo = new System.Windows.Forms.TextBox();
            this.textBox_MatNo = new System.Windows.Forms.TextBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.label_SubmitResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_subMit
            // 
            this.button_subMit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.button_subMit.Location = new System.Drawing.Point(3, 207);
            this.button_subMit.Name = "button_subMit";
            this.button_subMit.Size = new System.Drawing.Size(112, 93);
            this.button_subMit.TabIndex = 0;
            this.button_subMit.Text = "重新提交";
            this.button_subMit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // button_Close
            // 
            this.button_Close.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(121, 207);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(116, 93);
            this.button_Close.TabIndex = 1;
            this.button_Close.Text = "返回";
            this.button_Close.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label_MatNo
            // 
            this.label_MatNo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.label_MatNo.Location = new System.Drawing.Point(3, 126);
            this.label_MatNo.Name = "label_MatNo";
            this.label_MatNo.Size = new System.Drawing.Size(70, 32);
            this.label_MatNo.Text = "材料号";
            this.label_MatNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_StockNo
            // 
            this.label_StockNo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.label_StockNo.Location = new System.Drawing.Point(0, 70);
            this.label_StockNo.Name = "label_StockNo";
            this.label_StockNo.Size = new System.Drawing.Size(70, 32);
            this.label_StockNo.Text = "库位号";
            this.label_StockNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_StockNo
            // 
            this.textBox_StockNo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.textBox_StockNo.Location = new System.Drawing.Point(66, 68);
            this.textBox_StockNo.Name = "textBox_StockNo";
            this.textBox_StockNo.Size = new System.Drawing.Size(171, 31);
            this.textBox_StockNo.TabIndex = 2;
            // 
            // textBox_MatNo
            // 
            this.textBox_MatNo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.textBox_MatNo.Location = new System.Drawing.Point(66, 124);
            this.textBox_MatNo.Name = "textBox_MatNo";
            this.textBox_MatNo.Size = new System.Drawing.Size(171, 31);
            this.textBox_MatNo.TabIndex = 3;
            // 
            // label_Title
            // 
            this.label_Title.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label_Title.Location = new System.Drawing.Point(14, 12);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(212, 32);
            this.label_Title.Text = "离线包装场地扫描";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_SubmitResult
            // 
            this.label_SubmitResult.Location = new System.Drawing.Point(3, 158);
            this.label_SubmitResult.Name = "label_SubmitResult";
            this.label_SubmitResult.Size = new System.Drawing.Size(234, 46);
            this.label_SubmitResult.Text = "15:00 提交成功";
            // 
            // PackingScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.label_SubmitResult);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.textBox_MatNo);
            this.Controls.Add(this.textBox_StockNo);
            this.Controls.Add(this.label_StockNo);
            this.Controls.Add(this.label_MatNo);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_subMit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "PackingScanForm";
            this.Text = "离线包装场地扫描";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PackingScanForm_Load);
            this.Closed += new System.EventHandler(this.PackingScanForm_Closed);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button_subMit;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_MatNo;
        private System.Windows.Forms.Label label_StockNo;
        private System.Windows.Forms.TextBox textBox_StockNo;
        private System.Windows.Forms.TextBox textBox_MatNo;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_SubmitResult;
    }
}