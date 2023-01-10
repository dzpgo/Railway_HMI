namespace CONTROLS_OF_REPOSITORIES
{
    partial class conCraneDisplay
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
            this.panelCrane.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCrane
            // 
            this.panelCrane.BackColor = System.Drawing.Color.White;
            this.panelCrane.BackgroundImage = global::CONTROLS_OF_REPOSITORIES.Resources.行车_Avoid;
            this.panelCrane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCrane.Controls.Add(this.panelCrab);
            this.panelCrane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCrane.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelCrane.Location = new System.Drawing.Point(0, 0);
            this.panelCrane.Name = "panelCrane";
            this.panelCrane.Size = new System.Drawing.Size(47, 408);
            this.panelCrane.TabIndex = 3;
            // 
            // panelCrab
            // 
            this.panelCrab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCrab.BackColor = System.Drawing.Color.White;
            this.panelCrab.BackgroundImage = global::CONTROLS_OF_REPOSITORIES.Resources.imgCarNoCoil;
            this.panelCrab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCrab.Location = new System.Drawing.Point(0, 194);
            this.panelCrab.Name = "panelCrab";
            this.panelCrab.Size = new System.Drawing.Size(47, 27);
            this.panelCrab.TabIndex = 3;
            // 
            // conCraneDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelCrane);
            this.Name = "conCraneDisplay";
            this.Size = new System.Drawing.Size(47, 408);
            this.panelCrane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCrane;
        private System.Windows.Forms.Panel panelCrab;


    }
}
