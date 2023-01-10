namespace _1550PDA
{
    partial class Inventory_Lock
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
            this.txtSaddle = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSummit = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_EmptyMatNo = new System.Windows.Forms.Button();
            this.label_RowCnt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.Text = "库位号";
            // 
            // txtSaddle
            // 
            this.txtSaddle.Location = new System.Drawing.Point(67, 2);
            this.txtSaddle.Name = "txtSaddle";
            this.txtSaddle.Size = new System.Drawing.Size(123, 21);
            this.txtSaddle.TabIndex = 1;
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 51);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(232, 169);
            this.dataGrid1.TabIndex = 2;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(80, 226);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(48, 30);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSummit
            // 
            this.btnSummit.Location = new System.Drawing.Point(3, 226);
            this.btnSummit.Name = "btnSummit";
            this.btnSummit.Size = new System.Drawing.Size(71, 30);
            this.btnSummit.TabIndex = 5;
            this.btnSummit.Text = "提交";
            this.btnSummit.Click += new System.EventHandler(this.btnSummit_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(131, 226);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(53, 30);
            this.btnRedo.TabIndex = 7;
            this.btnRedo.Text = "重置";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(67, 259);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(169, 34);
            this.txtresult.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.Text = "操作结果";
            // 
            // btn_EmptyMatNo
            // 
            this.btn_EmptyMatNo.Enabled = false;
            this.btn_EmptyMatNo.Location = new System.Drawing.Point(192, 27);
            this.btn_EmptyMatNo.Name = "btn_EmptyMatNo";
            this.btn_EmptyMatNo.Size = new System.Drawing.Size(44, 21);
            this.btn_EmptyMatNo.TabIndex = 99;
            this.btn_EmptyMatNo.Text = "空";
            this.btn_EmptyMatNo.Click += new System.EventHandler(this.btn_EmptyMatNo_Click);
            // 
            // label_RowCnt
            // 
            this.label_RowCnt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular);
            this.label_RowCnt.Location = new System.Drawing.Point(192, 0);
            this.label_RowCnt.Name = "label_RowCnt";
            this.label_RowCnt.Size = new System.Drawing.Size(43, 20);
            this.label_RowCnt.Text = "0 件";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.Text = "材料号";
            // 
            // txtMatNo
            // 
            this.txtMatNo.Location = new System.Drawing.Point(67, 27);
            this.txtMatNo.Name = "txtMatNo";
            this.txtMatNo.Size = new System.Drawing.Size(123, 21);
            this.txtMatNo.TabIndex = 104;
            this.txtMatNo.TextChanged += new System.EventHandler(this.txtMatNo_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(187, 226);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 30);
            this.btnClose.TabIndex = 109;
            this.btnClose.Text = "返回";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Inventory_Lock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtMatNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_RowCnt);
            this.Controls.Add(this.btn_EmptyMatNo);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnSummit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.txtSaddle);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "Inventory_Lock";
            this.Text = "库位封锁";
            this.Load += new System.EventHandler(this.Inventory_Check_Lock);
            this.Closed += new System.EventHandler(this.Inventory_Lock_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaddle;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSummit;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_EmptyMatNo;
        private System.Windows.Forms.Label label_RowCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatNo;
        private System.Windows.Forms.Button btnClose;
    }
}