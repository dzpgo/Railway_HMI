namespace _1550PDA
{
    partial class Inventory_Diff
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.txtMatNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaddle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnRet = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.dataGrid1.Location = new System.Drawing.Point(1, 56);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(237, 178);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // txtMatNo
            // 
            this.txtMatNo.Location = new System.Drawing.Point(60, 29);
            this.txtMatNo.Name = "txtMatNo";
            this.txtMatNo.Size = new System.Drawing.Size(114, 23);
            this.txtMatNo.TabIndex = 89;
            this.txtMatNo.TextChanged += new System.EventHandler(this.txtMatNo_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.Text = "材料号";
            // 
            // txtSaddle
            // 
            this.txtSaddle.Location = new System.Drawing.Point(60, 4);
            this.txtSaddle.Name = "txtSaddle";
            this.txtSaddle.Size = new System.Drawing.Size(114, 23);
            this.txtSaddle.TabIndex = 88;
            this.txtSaddle.TextChanged += new System.EventHandler(this.txtSaddle_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.Text = "垛位";
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(87, 272);
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(147, 23);
            this.txtresult.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.Text = "操作结果";
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(119, 240);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(60, 30);
            this.btnRedo.TabIndex = 98;
            this.btnRedo.Text = "重置";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(175, 28);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(60, 26);
            this.btnSubmit.TabIndex = 97;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnRet
            // 
            this.btnRet.Location = new System.Drawing.Point(178, 240);
            this.btnRet.Name = "btnRet";
            this.btnRet.Size = new System.Drawing.Size(60, 30);
            this.btnRet.TabIndex = 95;
            this.btnRet.Text = "返回";
            this.btnRet.Click += new System.EventHandler(this.btnRet_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(176, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 26);
            this.btnSearch.TabIndex = 99;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 30);
            this.btnAdd.TabIndex = 103;
            this.btnAdd.Text = "手动";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(60, 240);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(60, 30);
            this.btnDel.TabIndex = 107;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // Inventory_Diff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnRet);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMatNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaddle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Inventory_Diff";
            this.Text = "盘库差异";
            this.Load += new System.EventHandler(this.Inventory_Diff_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox txtMatNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaddle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnRet;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
    }
}