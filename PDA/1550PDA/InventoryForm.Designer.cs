namespace _1550PDA
{
    partial class InventoryForm
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
            this.btnInit = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCommon = new System.Windows.Forms.Button();
            this.button_StockLock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular);
            this.btnInit.Location = new System.Drawing.Point(36, 6);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(174, 70);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "库位投用";
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular);
            this.btnCheck.Location = new System.Drawing.Point(36, 219);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(174, 70);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "复核盘库";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCommon
            // 
            this.btnCommon.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular);
            this.btnCommon.Location = new System.Drawing.Point(36, 148);
            this.btnCommon.Name = "btnCommon";
            this.btnCommon.Size = new System.Drawing.Size(174, 70);
            this.btnCommon.TabIndex = 2;
            this.btnCommon.Text = "普通盘库";
            this.btnCommon.Click += new System.EventHandler(this.btnCommon_Click);
            // 
            // button_StockLock
            // 
            this.button_StockLock.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular);
            this.button_StockLock.Location = new System.Drawing.Point(36, 77);
            this.button_StockLock.Name = "button_StockLock";
            this.button_StockLock.Size = new System.Drawing.Size(174, 70);
            this.button_StockLock.TabIndex = 3;
            this.button_StockLock.Text = "库位封锁";
            this.button_StockLock.Click += new System.EventHandler(this.button_StockLock_Click);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.button_StockLock);
            this.Controls.Add(this.btnCommon);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnInit);
            this.Name = "InventoryForm";
            this.Text = "盘库";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCommon;
        private System.Windows.Forms.Button button_StockLock;
    }
}