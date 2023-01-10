namespace CONTROLS_OF_PREMIERE
{
    partial class ConCraneVisual
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
            this.panelCrane = new System.Windows.Forms.Panel();
            this.panelCrab = new System.Windows.Forms.Panel();
            this.txt_CraneNO = new System.Windows.Forms.TextBox();
            this.panelCrane.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCrane
            // 
            this.panelCrane.BackColor = System.Drawing.Color.SteelBlue;
            this.panelCrane.Controls.Add(this.panelCrab);
            this.panelCrane.Controls.Add(this.txt_CraneNO);
            this.panelCrane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCrane.Location = new System.Drawing.Point(0, 0);
            this.panelCrane.Name = "panelCrane";
            this.panelCrane.Size = new System.Drawing.Size(34, 385);
            this.panelCrane.TabIndex = 1;
            // 
            // panelCrab
            // 
            this.panelCrab.BackColor = System.Drawing.Color.DarkRed;
            this.panelCrab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCrab.Location = new System.Drawing.Point(0, 197);
            this.panelCrab.Name = "panelCrab";
            this.panelCrab.Size = new System.Drawing.Size(36, 40);
            this.panelCrab.TabIndex = 2;
            // 
            // txt_CraneNO
            // 
            this.txt_CraneNO.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txt_CraneNO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_CraneNO.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_CraneNO.Font = new System.Drawing.Font("宋体", 7F);
            this.txt_CraneNO.Location = new System.Drawing.Point(0, 0);
            this.txt_CraneNO.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CraneNO.Name = "txt_CraneNO";
            this.txt_CraneNO.ReadOnly = true;
            this.txt_CraneNO.Size = new System.Drawing.Size(34, 11);
            this.txt_CraneNO.TabIndex = 1;
            this.txt_CraneNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConCraneVisual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCrane);
            this.Name = "ConCraneVisual";
            this.Size = new System.Drawing.Size(34, 385);
            this.panelCrane.ResumeLayout(false);
            this.panelCrane.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCrane;
        private System.Windows.Forms.Panel panelCrab;
        private System.Windows.Forms.TextBox txt_CraneNO;
    }
}
