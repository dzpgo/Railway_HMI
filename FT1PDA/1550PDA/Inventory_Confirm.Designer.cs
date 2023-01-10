namespace _1550PDA
{
    partial class Inventory_Confirm
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
            this.dataGrid_notScan = new System.Windows.Forms.DataGrid();
            this.btnDelScan = new System.Windows.Forms.Button();
            this.btnSumbit = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.cbxRowNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_AddScan = new System.Windows.Forms.Button();
            this.dataGrid_Scanned = new System.Windows.Forms.DataGrid();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid_notScan
            // 
            this.dataGrid_notScan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid_notScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_notScan.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular);
            this.dataGrid_notScan.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_notScan.Name = "dataGrid_notScan";
            this.dataGrid_notScan.Size = new System.Drawing.Size(232, 174);
            this.dataGrid_notScan.TabIndex = 0;
            this.dataGrid_notScan.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            this.dataGrid_notScan.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // btnDelScan
            // 
            this.btnDelScan.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnDelScan.Location = new System.Drawing.Point(61, 235);
            this.btnDelScan.Name = "btnDelScan";
            this.btnDelScan.Size = new System.Drawing.Size(58, 34);
            this.btnDelScan.TabIndex = 1;
            this.btnDelScan.Text = "删除";
            this.btnDelScan.Click += new System.EventHandler(this.btnManu_Click);
            // 
            // btnSumbit
            // 
            this.btnSumbit.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnSumbit.Location = new System.Drawing.Point(120, 235);
            this.btnSumbit.Name = "btnSumbit";
            this.btnSumbit.Size = new System.Drawing.Size(58, 34);
            this.btnSumbit.TabIndex = 2;
            this.btnSumbit.Text = "提交";
            this.btnSumbit.Click += new System.EventHandler(this.btnSumbit_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnRedo.Location = new System.Drawing.Point(179, 235);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(58, 34);
            this.btnRedo.TabIndex = 4;
            this.btnRedo.Text = "重置";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(1, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.Text = "操作结果:";
            // 
            // txtresult
            // 
            this.txtresult.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.txtresult.Location = new System.Drawing.Point(64, 272);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(173, 23);
            this.txtresult.TabIndex = 54;
            // 
            // cbxRowNo
            // 
            this.cbxRowNo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.cbxRowNo.Location = new System.Drawing.Point(84, 3);
            this.cbxRowNo.Name = "cbxRowNo";
            this.cbxRowNo.Size = new System.Drawing.Size(97, 25);
            this.cbxRowNo.TabIndex = 59;
            this.cbxRowNo.SelectedIndexChanged += new System.EventHandler(this.cbxRowNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.Text = "待盘排清单";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.btnSearch.Location = new System.Drawing.Point(187, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(3, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(232, 197);
            this.tabControl1.TabIndex = 66;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGrid_notScan);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(232, 174);
            this.tabPage1.Text = "待盘清单";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGrid_Scanned);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 106);
            this.tabPage2.Text = "已盘清单";
            // 
            // button_AddScan
            // 
            this.button_AddScan.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular);
            this.button_AddScan.Location = new System.Drawing.Point(2, 235);
            this.button_AddScan.Name = "button_AddScan";
            this.button_AddScan.Size = new System.Drawing.Size(58, 34);
            this.button_AddScan.TabIndex = 69;
            this.button_AddScan.Text = "添加";
            // 
            // dataGrid_Scanned
            // 
            this.dataGrid_Scanned.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid_Scanned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_Scanned.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular);
            this.dataGrid_Scanned.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_Scanned.Name = "dataGrid_Scanned";
            this.dataGrid_Scanned.Size = new System.Drawing.Size(232, 106);
            this.dataGrid_Scanned.TabIndex = 1;
            // 
            // Inventory_Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.cbxRowNo);
            this.Controls.Add(this.button_AddScan);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSumbit);
            this.Controls.Add(this.btnDelScan);
            this.Name = "Inventory_Confirm";
            this.Text = "特定盘库(红库位)";
            this.Load += new System.EventHandler(this.Inventory_Check_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid_notScan;
        private System.Windows.Forms.Button btnDelScan;
        private System.Windows.Forms.Button btnSumbit;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.ComboBox cbxRowNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_AddScan;
        private System.Windows.Forms.DataGrid dataGrid_Scanned;
    }
}