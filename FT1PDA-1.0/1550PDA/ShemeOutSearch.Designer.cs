namespace _1550PDA
{
    partial class ShemeOutSearch
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
            this.tctdg = new System.Windows.Forms.TabControl();
            this.tg_pick = new System.Windows.Forms.TabPage();
            this.dg_pick = new System.Windows.Forms.DataGrid();
            this.tg_tran = new System.Windows.Forms.TabPage();
            this.dg_tran = new System.Windows.Forms.DataGrid();
            this.tg_l3pro = new System.Windows.Forms.TabPage();
            this.dgL3Pro = new System.Windows.Forms.DataGrid();
            this.tg_l2pro = new System.Windows.Forms.TabPage();
            this.dg_l2pro = new System.Windows.Forms.DataGrid();
            this.btnBack = new System.Windows.Forms.Button();
            this.cbxPlanNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.tctdg.SuspendLayout();
            this.tg_pick.SuspendLayout();
            this.tg_tran.SuspendLayout();
            this.tg_l3pro.SuspendLayout();
            this.tg_l2pro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tctdg
            // 
            this.tctdg.Controls.Add(this.tg_pick);
            this.tctdg.Controls.Add(this.tg_tran);
            this.tctdg.Controls.Add(this.tg_l3pro);
            this.tctdg.Controls.Add(this.tg_l2pro);
            this.tctdg.Location = new System.Drawing.Point(0, 0);
            this.tctdg.Name = "tctdg";
            this.tctdg.SelectedIndex = 0;
            this.tctdg.Size = new System.Drawing.Size(238, 246);
            this.tctdg.TabIndex = 0;
            this.tctdg.SelectedIndexChanged += new System.EventHandler(this.tctdg_SelectedIndexChanged);
            // 
            // tg_pick
            // 
            this.tg_pick.Controls.Add(this.dg_pick);
            this.tg_pick.Location = new System.Drawing.Point(0, 0);
            this.tg_pick.Name = "tg_pick";
            this.tg_pick.Size = new System.Drawing.Size(238, 223);
            this.tg_pick.Text = "发货";
            // 
            // dg_pick
            // 
            this.dg_pick.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_pick.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.dg_pick.Location = new System.Drawing.Point(3, 3);
            this.dg_pick.Name = "dg_pick";
            this.dg_pick.Size = new System.Drawing.Size(218, 211);
            this.dg_pick.TabIndex = 1;
            // 
            // tg_tran
            // 
            this.tg_tran.Controls.Add(this.dg_tran);
            this.tg_tran.Location = new System.Drawing.Point(0, 0);
            this.tg_tran.Name = "tg_tran";
            this.tg_tran.Size = new System.Drawing.Size(224, 220);
            this.tg_tran.Text = "转库";
            // 
            // dg_tran
            // 
            this.dg_tran.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_tran.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.dg_tran.Location = new System.Drawing.Point(3, 3);
            this.dg_tran.Name = "dg_tran";
            this.dg_tran.Size = new System.Drawing.Size(218, 211);
            this.dg_tran.TabIndex = 0;
            // 
            // tg_l3pro
            // 
            this.tg_l3pro.Controls.Add(this.dgL3Pro);
            this.tg_l3pro.Location = new System.Drawing.Point(0, 0);
            this.tg_l3pro.Name = "tg_l3pro";
            this.tg_l3pro.Size = new System.Drawing.Size(224, 220);
            this.tg_l3pro.Text = "L3生产";
            // 
            // dgL3Pro
            // 
            this.dgL3Pro.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgL3Pro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.dgL3Pro.Location = new System.Drawing.Point(4, 4);
            this.dgL3Pro.Name = "dgL3Pro";
            this.dgL3Pro.Size = new System.Drawing.Size(216, 210);
            this.dgL3Pro.TabIndex = 0;
            // 
            // tg_l2pro
            // 
            this.tg_l2pro.Controls.Add(this.dg_l2pro);
            this.tg_l2pro.Location = new System.Drawing.Point(0, 0);
            this.tg_l2pro.Name = "tg_l2pro";
            this.tg_l2pro.Size = new System.Drawing.Size(224, 220);
            this.tg_l2pro.Text = "L2生产";
            // 
            // dg_l2pro
            // 
            this.dg_l2pro.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_l2pro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.dg_l2pro.Location = new System.Drawing.Point(3, 3);
            this.dg_l2pro.Name = "dg_l2pro";
            this.dg_l2pro.RowHeadersVisible = false;
            this.dg_l2pro.Size = new System.Drawing.Size(218, 211);
            this.dg_l2pro.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(183, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(52, 37);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cbxPlanNo
            // 
            this.cbxPlanNo.Location = new System.Drawing.Point(60, 0);
            this.cbxPlanNo.Name = "cbxPlanNo";
            this.cbxPlanNo.Size = new System.Drawing.Size(117, 22);
            this.cbxPlanNo.TabIndex = 3;
            this.cbxPlanNo.SelectedIndexChanged += new System.EventHandler(this.cbxPlanNo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.Text = "提单号";
            // 
            // txtPlan
            // 
            this.txtPlan.Location = new System.Drawing.Point(60, 25);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.Size = new System.Drawing.Size(117, 21);
            this.txtPlan.TabIndex = 5;
            this.txtPlan.TextChanged += new System.EventHandler(this.txtPlan_TextChanged);
            // 
            // ShemeOutSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.txtPlan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxPlanNo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tctdg);
            this.Name = "ShemeOutSearch";
            this.Text = "出库计划查询";
            this.Load += new System.EventHandler(this.ShemeOutSearch_Load);
            this.tctdg.ResumeLayout(false);
            this.tg_pick.ResumeLayout(false);
            this.tg_tran.ResumeLayout(false);
            this.tg_l3pro.ResumeLayout(false);
            this.tg_l2pro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tctdg;
        private System.Windows.Forms.TabPage tg_l3pro;
        private System.Windows.Forms.DataGrid dgL3Pro;
        private System.Windows.Forms.TabPage tg_tran;
        private System.Windows.Forms.DataGrid dg_tran;
        private System.Windows.Forms.TabPage tg_pick;
        private System.Windows.Forms.TabPage tg_l2pro;
        private System.Windows.Forms.DataGrid dg_pick;
        private System.Windows.Forms.DataGrid dg_l2pro;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cbxPlanNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlan;
    }
}