namespace UACSParking
{
    partial class railwayCarriage
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
            this.labCount = new System.Windows.Forms.Label();
            this.labScheme = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labTrainCaseType = new System.Windows.Forms.Label();
            this.labStowage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labCount
            // 
            this.labCount.AutoSize = true;
            this.labCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCount.Location = new System.Drawing.Point(43, 0);
            this.labCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(37, 20);
            this.labCount.TabIndex = 0;
            this.labCount.Text = "节数";
            this.labCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labScheme
            // 
            this.labScheme.AutoSize = true;
            this.labScheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labScheme.Location = new System.Drawing.Point(2, 50);
            this.labScheme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labScheme.Name = "labScheme";
            this.labScheme.Size = new System.Drawing.Size(37, 19);
            this.labScheme.TabIndex = 1;
            this.labScheme.Text = "方案";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labStowage, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labScheme, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labTrainCaseType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labCount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(163, 112);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "车号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "类型";
            // 
            // labTrainCaseType
            // 
            this.labTrainCaseType.AutoSize = true;
            this.labTrainCaseType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTrainCaseType.ForeColor = System.Drawing.Color.White;
            this.labTrainCaseType.Location = new System.Drawing.Point(43, 25);
            this.labTrainCaseType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTrainCaseType.Name = "labTrainCaseType";
            this.labTrainCaseType.Size = new System.Drawing.Size(65, 19);
            this.labTrainCaseType.TabIndex = 4;
            this.labTrainCaseType.Text = "车皮类型";
            this.labTrainCaseType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labStowage
            // 
            this.labStowage.AutoSize = true;
            this.labStowage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStowage.ForeColor = System.Drawing.Color.White;
            this.labStowage.Location = new System.Drawing.Point(43, 50);
            this.labStowage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labStowage.Name = "labStowage";
            this.labStowage.Size = new System.Drawing.Size(46, 19);
            this.labStowage.TabIndex = 2;
            this.labStowage.Text = "方案1";
            this.labStowage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railwayCarriage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(4F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "railwayCarriage";
            this.Size = new System.Drawing.Size(163, 112);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labScheme;
        private System.Windows.Forms.Label labCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labStowage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labTrainCaseType;
        private System.Windows.Forms.Label label2;
    }
}
