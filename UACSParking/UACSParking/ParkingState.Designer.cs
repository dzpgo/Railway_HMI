namespace UACS.Park
{
    partial class ParkingState
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtparkNo = new System.Windows.Forms.Label();
            this.txtCarNo = new System.Windows.Forms.Label();
            this.txtCarState = new System.Windows.Forms.Label();
            this.txtParkState = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtparkNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCarNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCarState, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtParkState, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 84);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtparkNo
            // 
            this.txtparkNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtparkNo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtparkNo.Location = new System.Drawing.Point(4, 1);
            this.txtparkNo.Name = "txtparkNo";
            this.txtparkNo.Size = new System.Drawing.Size(89, 40);
            this.txtparkNo.TabIndex = 2;
            this.txtparkNo.Text = "999999";
            this.txtparkNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCarNo
            // 
            this.txtCarNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCarNo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtCarNo.Location = new System.Drawing.Point(100, 1);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(89, 40);
            this.txtCarNo.TabIndex = 5;
            this.txtCarNo.Text = "999999";
            this.txtCarNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtCarNo.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCarState
            // 
            this.txtCarState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCarState.Font = new System.Drawing.Font("宋体", 14.25F);
            this.txtCarState.Location = new System.Drawing.Point(100, 42);
            this.txtCarState.Name = "txtCarState";
            this.txtCarState.Size = new System.Drawing.Size(89, 41);
            this.txtCarState.TabIndex = 3;
            this.txtCarState.Text = "999999";
            this.txtCarState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtParkState
            // 
            this.txtParkState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtParkState.Font = new System.Drawing.Font("宋体", 14.25F);
            this.txtParkState.Location = new System.Drawing.Point(4, 42);
            this.txtParkState.Name = "txtParkState";
            this.txtParkState.Size = new System.Drawing.Size(89, 41);
            this.txtParkState.TabIndex = 6;
            this.txtParkState.Text = "999999";
            this.txtParkState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParkingState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ParkingState";
            this.Size = new System.Drawing.Size(193, 84);
            this.Load += new System.EventHandler(this.ParkingState_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txtCarState;
        private System.Windows.Forms.Label txtparkNo;
        private System.Windows.Forms.Label txtCarNo;
        private System.Windows.Forms.Label txtParkState;
    }
}
