namespace FORMS_OF_REPOSITORIES
{
    partial class FrmRailwayCBayMonitor
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
            this.components = new System.ComponentModel.Container();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.plRailwayABay = new System.Windows.Forms.Panel();
            this.conRailwayCrane_8 = new CONTROLS_OF_REPOSITORIES.conCraneDisplay();
            this.conRailwayCrane_7 = new CONTROLS_OF_REPOSITORIES.conCraneDisplay();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.conCraneStatus8 = new CONTROLS_OF_REPOSITORIES.conCraneStatus();
            this.conCraneStatus7 = new CONTROLS_OF_REPOSITORIES.conCraneStatus();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPhotogate_CD = new System.Windows.Forms.Button();
            this.btnPhotogate_AB = new System.Windows.Forms.Button();
            this.btnLoaderChange2 = new System.Windows.Forms.Button();
            this.btnLoaderChange1 = new System.Windows.Forms.Button();
            this.btnCrane_2_WaterStatus = new System.Windows.Forms.Button();
            this.btnCrane_1_WaterStatus = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCraneIsShow = new System.Windows.Forms.Button();
            this.btnUpSaddle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.plRailwayABay.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(489, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 42);
            this.label1.TabIndex = 12;
            this.label1.Text = "产成品库C跨行车监控画面";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 626);
            this.panel1.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.plRailwayABay, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1364, 626);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // plRailwayABay
            // 
            this.plRailwayABay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plRailwayABay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.plRailwayABay.Controls.Add(this.conRailwayCrane_8);
            this.plRailwayABay.Controls.Add(this.conRailwayCrane_7);
            this.plRailwayABay.Location = new System.Drawing.Point(3, 3);
            this.plRailwayABay.Name = "plRailwayABay";
            this.plRailwayABay.Size = new System.Drawing.Size(1358, 373);
            this.plRailwayABay.TabIndex = 0;
            // 
            // conRailwayCrane_8
            // 
            this.conRailwayCrane_8.BackColor = System.Drawing.SystemColors.Control;
            this.conRailwayCrane_8.CraneNO = "";
            this.conRailwayCrane_8.CranesDistain = ((long)(0));
            this.conRailwayCrane_8.CraneXAct = ((long)(0));
            this.conRailwayCrane_8.Location = new System.Drawing.Point(673, 0);
            this.conRailwayCrane_8.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.conRailwayCrane_8.Name = "conRailwayCrane_8";
            this.conRailwayCrane_8.Size = new System.Drawing.Size(45, 439);
            this.conRailwayCrane_8.TabIndex = 4;
            // 
            // conRailwayCrane_7
            // 
            this.conRailwayCrane_7.BackColor = System.Drawing.SystemColors.Control;
            this.conRailwayCrane_7.CraneNO = "";
            this.conRailwayCrane_7.CranesDistain = ((long)(0));
            this.conRailwayCrane_7.CraneXAct = ((long)(0));
            this.conRailwayCrane_7.Location = new System.Drawing.Point(489, 2);
            this.conRailwayCrane_7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.conRailwayCrane_7.Name = "conRailwayCrane_7";
            this.conRailwayCrane_7.Size = new System.Drawing.Size(45, 437);
            this.conRailwayCrane_7.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Location = new System.Drawing.Point(3, 382);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1358, 241);
            this.panel6.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus7, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1358, 241);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // conCraneStatus8
            // 
            this.conCraneStatus8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus8.CraneNO = "";
            this.conCraneStatus8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus8.Location = new System.Drawing.Point(456, 5);
            this.conCraneStatus8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.conCraneStatus8.Name = "conCraneStatus8";
            this.conCraneStatus8.Size = new System.Drawing.Size(444, 231);
            this.conCraneStatus8.TabIndex = 8;
            // 
            // conCraneStatus7
            // 
            this.conCraneStatus7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus7.CraneNO = "";
            this.conCraneStatus7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus7.Location = new System.Drawing.Point(4, 5);
            this.conCraneStatus7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.conCraneStatus7.Name = "conCraneStatus7";
            this.conCraneStatus7.Size = new System.Drawing.Size(444, 231);
            this.conCraneStatus7.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPhotogate_CD);
            this.panel2.Controls.Add(this.btnPhotogate_AB);
            this.panel2.Controls.Add(this.btnLoaderChange2);
            this.panel2.Controls.Add(this.btnLoaderChange1);
            this.panel2.Controls.Add(this.btnCrane_2_WaterStatus);
            this.panel2.Controls.Add(this.btnCrane_1_WaterStatus);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnCraneIsShow);
            this.panel2.Controls.Add(this.btnUpSaddle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 697);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1364, 41);
            this.panel2.TabIndex = 14;
            // 
            // btnPhotogate_CD
            // 
            this.btnPhotogate_CD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPhotogate_CD.BackColor = System.Drawing.Color.AliceBlue;
            this.btnPhotogate_CD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPhotogate_CD.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPhotogate_CD.Location = new System.Drawing.Point(356, 3);
            this.btnPhotogate_CD.Name = "btnPhotogate_CD";
            this.btnPhotogate_CD.Size = new System.Drawing.Size(126, 35);
            this.btnPhotogate_CD.TabIndex = 38;
            this.btnPhotogate_CD.Text = "CD区光电门:开";
            this.btnPhotogate_CD.UseVisualStyleBackColor = false;
            this.btnPhotogate_CD.Click += new System.EventHandler(this.btnPhotogate_CD_Click);
            // 
            // btnPhotogate_AB
            // 
            this.btnPhotogate_AB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPhotogate_AB.BackColor = System.Drawing.Color.AliceBlue;
            this.btnPhotogate_AB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPhotogate_AB.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPhotogate_AB.Location = new System.Drawing.Point(224, 3);
            this.btnPhotogate_AB.Name = "btnPhotogate_AB";
            this.btnPhotogate_AB.Size = new System.Drawing.Size(126, 35);
            this.btnPhotogate_AB.TabIndex = 37;
            this.btnPhotogate_AB.Text = "AB区光电门:开";
            this.btnPhotogate_AB.UseVisualStyleBackColor = false;
            this.btnPhotogate_AB.Click += new System.EventHandler(this.btnPhotogate_AB_Click);
            // 
            // btnLoaderChange2
            // 
            this.btnLoaderChange2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoaderChange2.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLoaderChange2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoaderChange2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoaderChange2.Location = new System.Drawing.Point(967, 3);
            this.btnLoaderChange2.Name = "btnLoaderChange2";
            this.btnLoaderChange2.Size = new System.Drawing.Size(114, 35);
            this.btnLoaderChange2.TabIndex = 36;
            this.btnLoaderChange2.Text = "8#吊具：吸盘";
            this.btnLoaderChange2.UseVisualStyleBackColor = false;
            // 
            // btnLoaderChange1
            // 
            this.btnLoaderChange1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoaderChange1.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLoaderChange1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoaderChange1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoaderChange1.Location = new System.Drawing.Point(847, 3);
            this.btnLoaderChange1.Name = "btnLoaderChange1";
            this.btnLoaderChange1.Size = new System.Drawing.Size(114, 35);
            this.btnLoaderChange1.TabIndex = 35;
            this.btnLoaderChange1.Text = "7#吊具：夹钳";
            this.btnLoaderChange1.UseVisualStyleBackColor = false;
            // 
            // btnCrane_2_WaterStatus
            // 
            this.btnCrane_2_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_2_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_2_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_2_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_2_WaterStatus.Location = new System.Drawing.Point(607, 3);
            this.btnCrane_2_WaterStatus.Name = "btnCrane_2_WaterStatus";
            this.btnCrane_2_WaterStatus.Size = new System.Drawing.Size(114, 35);
            this.btnCrane_2_WaterStatus.TabIndex = 33;
            this.btnCrane_2_WaterStatus.Text = "8#空调水排放";
            this.btnCrane_2_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // btnCrane_1_WaterStatus
            // 
            this.btnCrane_1_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_1_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_1_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_1_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_1_WaterStatus.Location = new System.Drawing.Point(487, 3);
            this.btnCrane_1_WaterStatus.Name = "btnCrane_1_WaterStatus";
            this.btnCrane_1_WaterStatus.Size = new System.Drawing.Size(114, 35);
            this.btnCrane_1_WaterStatus.TabIndex = 32;
            this.btnCrane_1_WaterStatus.Text = "7#空调水排放";
            this.btnCrane_1_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button3.BackColor = System.Drawing.Color.AliceBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(114, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 35);
            this.button3.TabIndex = 30;
            this.button3.Text = "开北道闸";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 35);
            this.button1.TabIndex = 28;
            this.button1.Text = "开南道闸";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCraneIsShow
            // 
            this.btnCraneIsShow.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCraneIsShow.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCraneIsShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCraneIsShow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCraneIsShow.Location = new System.Drawing.Point(1253, 3);
            this.btnCraneIsShow.Name = "btnCraneIsShow";
            this.btnCraneIsShow.Size = new System.Drawing.Size(104, 35);
            this.btnCraneIsShow.TabIndex = 27;
            this.btnCraneIsShow.Text = "行车隐藏";
            this.btnCraneIsShow.UseVisualStyleBackColor = false;
            this.btnCraneIsShow.Click += new System.EventHandler(this.btnCraneIsShow_Click);
            // 
            // btnUpSaddle
            // 
            this.btnUpSaddle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUpSaddle.BackColor = System.Drawing.Color.AliceBlue;
            this.btnUpSaddle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpSaddle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpSaddle.Location = new System.Drawing.Point(1143, 3);
            this.btnUpSaddle.Name = "btnUpSaddle";
            this.btnUpSaddle.Size = new System.Drawing.Size(104, 35);
            this.btnUpSaddle.TabIndex = 14;
            this.btnUpSaddle.Text = "刷新";
            this.btnUpSaddle.UseVisualStyleBackColor = false;
            this.btnUpSaddle.Click += new System.EventHandler(this.btnUpSaddle_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.02965F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.97035F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 741);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // FrmRailwayCBayMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmRailwayCBayMonitor";
            this.Text = "铁路库监控主画面";
            this.TabActivated += new System.EventHandler(this.MyTabActivated);
            this.TabDeactivated += new System.EventHandler(this.MyTabDeactivated);
            this.Resize += new System.EventHandler(this.FrmRailwayABayMonitor_Resize);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.plRailwayABay.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plRailwayABay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCraneIsShow;
        private System.Windows.Forms.Button btnUpSaddle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private CONTROLS_OF_REPOSITORIES.conCraneDisplay conRailwayCrane_8;
        private CONTROLS_OF_REPOSITORIES.conCraneDisplay conRailwayCrane_7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CONTROLS_OF_REPOSITORIES.conCraneStatus conCraneStatus8;
        private CONTROLS_OF_REPOSITORIES.conCraneStatus conCraneStatus7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCrane_2_WaterStatus;
        private System.Windows.Forms.Button btnCrane_1_WaterStatus;
        private System.Windows.Forms.Button btnLoaderChange2;
        private System.Windows.Forms.Button btnLoaderChange1;
        private System.Windows.Forms.Button btnPhotogate_CD;
        private System.Windows.Forms.Button btnPhotogate_AB;
    }
}