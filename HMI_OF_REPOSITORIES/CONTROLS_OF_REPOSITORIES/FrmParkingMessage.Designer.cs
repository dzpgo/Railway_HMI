namespace CONTROLS_OF_REPOSITORIES
{
    partial class FrmParkingMessage
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
            this.plParkingMessage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // plParkingMessage
            // 
            this.plParkingMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.plParkingMessage.Location = new System.Drawing.Point(0, 0);
            this.plParkingMessage.Name = "plParkingMessage";
            this.plParkingMessage.Size = new System.Drawing.Size(1010, 377);
            this.plParkingMessage.TabIndex = 0;
            // 
            // FrmParkingMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 568);
            this.Controls.Add(this.plParkingMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmParkingMessage";
            this.Text = "停车位信息";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plParkingMessage;
    }
}