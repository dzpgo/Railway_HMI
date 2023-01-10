namespace CONTROLS_OF_PREMIERE
{
    partial class PopStartLaserDevice
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
            this.cmdStartSendingXPos = new System.Windows.Forms.Button();
            this.cmdStopSendingXPos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSendMsgStartLaser = new System.Windows.Forms.Button();
            this.txtParkingNO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdStartSendingXPos
            // 
            this.cmdStartSendingXPos.Location = new System.Drawing.Point(30, 72);
            this.cmdStartSendingXPos.Name = "cmdStartSendingXPos";
            this.cmdStartSendingXPos.Size = new System.Drawing.Size(154, 36);
            this.cmdStartSendingXPos.TabIndex = 0;
            this.cmdStartSendingXPos.Text = "发送";
            this.cmdStartSendingXPos.UseVisualStyleBackColor = true;
            this.cmdStartSendingXPos.Click += new System.EventHandler(this.cmdStartSendingXPos_Click);
            // 
            // cmdStopSendingXPos
            // 
            this.cmdStopSendingXPos.Location = new System.Drawing.Point(209, 72);
            this.cmdStopSendingXPos.Name = "cmdStopSendingXPos";
            this.cmdStopSendingXPos.Size = new System.Drawing.Size(154, 36);
            this.cmdStopSendingXPos.TabIndex = 1;
            this.cmdStopSendingXPos.Text = "停止";
            this.cmdStopSendingXPos.UseVisualStyleBackColor = true;
            this.cmdStopSendingXPos.Click += new System.EventHandler(this.cmdStopSendingXPos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "大车位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(36, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "入库框架扫描开始";
            // 
            // cmdSendMsgStartLaser
            // 
            this.cmdSendMsgStartLaser.Location = new System.Drawing.Point(209, 237);
            this.cmdSendMsgStartLaser.Name = "cmdSendMsgStartLaser";
            this.cmdSendMsgStartLaser.Size = new System.Drawing.Size(154, 36);
            this.cmdSendMsgStartLaser.TabIndex = 4;
            this.cmdSendMsgStartLaser.Text = "发送";
            this.cmdSendMsgStartLaser.UseVisualStyleBackColor = true;
            this.cmdSendMsgStartLaser.Click += new System.EventHandler(this.cmdSendMsgStartLaser_Click);
            // 
            // txtParkingNO
            // 
            this.txtParkingNO.Location = new System.Drawing.Point(40, 237);
            this.txtParkingNO.Name = "txtParkingNO";
            this.txtParkingNO.Size = new System.Drawing.Size(100, 21);
            this.txtParkingNO.TabIndex = 5;
            // 
            // PopStartLaserDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 446);
            this.Controls.Add(this.txtParkingNO);
            this.Controls.Add(this.cmdSendMsgStartLaser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdStopSendingXPos);
            this.Controls.Add(this.cmdStartSendingXPos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopStartLaserDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopStartLaserDevice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStartSendingXPos;
        private System.Windows.Forms.Button cmdStopSendingXPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSendMsgStartLaser;
        private System.Windows.Forms.TextBox txtParkingNO;
    }
}