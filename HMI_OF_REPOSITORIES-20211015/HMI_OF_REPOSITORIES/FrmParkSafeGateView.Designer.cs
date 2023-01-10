namespace FORMS_OF_REPOSITORIES
{
    partial class FrmParkSafeGateView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnToSafe = new System.Windows.Forms.Button();
            this.btnToStat = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDaozha = new System.Windows.Forms.Button();
            this.btnToStock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnToSafe
            // 
            this.btnToSafe.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToSafe.Location = new System.Drawing.Point(342, 643);
            this.btnToSafe.Name = "btnToSafe";
            this.btnToSafe.Size = new System.Drawing.Size(103, 46);
            this.btnToSafe.TabIndex = 54;
            this.btnToSafe.Text = "安全区履历";
            this.btnToSafe.UseVisualStyleBackColor = true;
            // 
            // btnToStat
            // 
            this.btnToStat.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToStat.Location = new System.Drawing.Point(608, 643);
            this.btnToStat.Name = "btnToStat";
            this.btnToStat.Size = new System.Drawing.Size(103, 46);
            this.btnToStat.TabIndex = 53;
            this.btnToStat.Text = "转统计";
            this.btnToStat.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(209, 643);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 46);
            this.button2.TabIndex = 52;
            this.button2.Text = "车位";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnDaozha
            // 
            this.btnDaozha.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDaozha.Location = new System.Drawing.Point(76, 643);
            this.btnDaozha.Name = "btnDaozha";
            this.btnDaozha.Size = new System.Drawing.Size(103, 46);
            this.btnDaozha.TabIndex = 51;
            this.btnDaozha.Text = "道闸";
            this.btnDaozha.UseVisualStyleBackColor = true;
            // 
            // btnToStock
            // 
            this.btnToStock.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToStock.Location = new System.Drawing.Point(475, 643);
            this.btnToStock.Name = "btnToStock";
            this.btnToStock.Size = new System.Drawing.Size(103, 46);
            this.btnToStock.TabIndex = 50;
            this.btnToStock.Text = "转库位";
            this.btnToStock.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(240, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 42);
            this.label1.TabIndex = 55;
            this.label1.Text = "产成品A跨道闸、停车位画面";
            // 
            // FrmParkSafeGateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnToSafe);
            this.Controls.Add(this.btnToStat);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDaozha);
            this.Controls.Add(this.btnToStock);
            this.Name = "FrmParkSafeGateView";
            this.Text = "库区及车位信息";
            this.Load += new System.EventHandler(this.ParkSafeGateView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToSafe;
        private System.Windows.Forms.Button btnToStat;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDaozha;
        private System.Windows.Forms.Button btnToStock;
        private System.Windows.Forms.Label label1;
    }
}