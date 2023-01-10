namespace _1550PDA
{
    partial class MainForm
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
            this.btnShemeIn = new System.Windows.Forms.Button();
            this.btnPreSearch = new System.Windows.Forms.Button();
            this.btnCoilINFSearch = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.button_PackingScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShemeIn
            // 
            this.btnShemeIn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnShemeIn.Location = new System.Drawing.Point(3, 3);
            this.btnShemeIn.Name = "btnShemeIn";
            this.btnShemeIn.Size = new System.Drawing.Size(111, 80);
            this.btnShemeIn.TabIndex = 0;
            this.btnShemeIn.Text = "卡车出入库";
            this.btnShemeIn.Click += new System.EventHandler(this.btnShemeIn_Click);
            // 
            // btnPreSearch
            // 
            this.btnPreSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnPreSearch.Location = new System.Drawing.Point(119, 3);
            this.btnPreSearch.Name = "btnPreSearch";
            this.btnPreSearch.Size = new System.Drawing.Size(115, 80);
            this.btnPreSearch.TabIndex = 2;
            this.btnPreSearch.Text = "装车销账";
            this.btnPreSearch.Click += new System.EventHandler(this.btnPreSearch_Click);
            // 
            // btnCoilINFSearch
            // 
            this.btnCoilINFSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnCoilINFSearch.Location = new System.Drawing.Point(119, 169);
            this.btnCoilINFSearch.Name = "btnCoilINFSearch";
            this.btnCoilINFSearch.Size = new System.Drawing.Size(115, 80);
            this.btnCoilINFSearch.TabIndex = 4;
            this.btnCoilINFSearch.Text = "信息查询";
            this.btnCoilINFSearch.Click += new System.EventHandler(this.btnCoilINFSearch_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnQuit.Location = new System.Drawing.Point(62, 255);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(106, 37);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "切换用户";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnInventory.Location = new System.Drawing.Point(3, 86);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(111, 80);
            this.btnInventory.TabIndex = 9;
            this.btnInventory.Text = "盘库";
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnManual
            // 
            this.btnManual.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.btnManual.Location = new System.Drawing.Point(3, 169);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(111, 80);
            this.btnManual.TabIndex = 10;
            this.btnManual.Text = "手动销帐";
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // button_PackingScan
            // 
            this.button_PackingScan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.button_PackingScan.Location = new System.Drawing.Point(119, 86);
            this.button_PackingScan.Name = "button_PackingScan";
            this.button_PackingScan.Size = new System.Drawing.Size(115, 80);
            this.button_PackingScan.TabIndex = 11;
            this.button_PackingScan.Text = "离线包装";
            this.button_PackingScan.Click += new System.EventHandler(this.button_PackingScan_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.button_PackingScan);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnCoilINFSearch);
            this.Controls.Add(this.btnPreSearch);
            this.Controls.Add(this.btnShemeIn);
            this.Name = "MainForm";
            this.Text = "主画面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShemeIn;
        private System.Windows.Forms.Button btnPreSearch;
        private System.Windows.Forms.Button btnCoilINFSearch;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button button_PackingScan;
    }
}