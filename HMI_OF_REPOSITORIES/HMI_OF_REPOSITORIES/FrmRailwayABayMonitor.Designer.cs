﻿namespace FORMS_OF_REPOSITORIES
{
    partial class FrmRailwayABayMonitor
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPhotogate_CD = new System.Windows.Forms.Button();
            this.btnPhotogate_AB = new System.Windows.Forms.Button();
            this.btnLoaderChange2 = new System.Windows.Forms.Button();
            this.btnLoaderChange1 = new System.Windows.Forms.Button();
            this.btnCrane_3_WaterStatus = new System.Windows.Forms.Button();
            this.btnCrane_2_WaterStatus = new System.Windows.Forms.Button();
            this.btnCrane_1_WaterStatus = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCraneIsShow = new System.Windows.Forms.Button();
            this.btnUpSaddle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.conRailwayCrane_3 = new CONTROLS_OF_REPOSITORIES.conCraneDisplay();
            this.conRailwayCrane_2 = new CONTROLS_OF_REPOSITORIES.conCraneDisplay();
            this.conRailwayCrane_1 = new CONTROLS_OF_REPOSITORIES.conCraneDisplay();
            this.conCraneStatus3 = new CONTROLS_OF_REPOSITORIES.conCraneStatus();
            this.conCraneStatus2 = new CONTROLS_OF_REPOSITORIES.conCraneStatus();
            this.conCraneStatus1 = new CONTROLS_OF_REPOSITORIES.conCraneStatus();
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
            this.label1.Location = new System.Drawing.Point(732, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 64);
            this.label1.TabIndex = 12;
            this.label1.Text = "产成品库A跨行车监控画面";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 98);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2047, 940);
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
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(2047, 940);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // plRailwayABay
            // 
            this.plRailwayABay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plRailwayABay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.plRailwayABay.Controls.Add(this.conRailwayCrane_3);
            this.plRailwayABay.Controls.Add(this.conRailwayCrane_2);
            this.plRailwayABay.Controls.Add(this.conRailwayCrane_1);
            this.plRailwayABay.Location = new System.Drawing.Point(4, 4);
            this.plRailwayABay.Margin = new System.Windows.Forms.Padding(4);
            this.plRailwayABay.Name = "plRailwayABay";
            this.plRailwayABay.Size = new System.Drawing.Size(2039, 562);
            this.plRailwayABay.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Location = new System.Drawing.Point(4, 574);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2039, 362);
            this.panel6.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(2039, 362);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPhotogate_CD);
            this.panel2.Controls.Add(this.btnPhotogate_AB);
            this.panel2.Controls.Add(this.btnLoaderChange2);
            this.panel2.Controls.Add(this.btnLoaderChange1);
            this.panel2.Controls.Add(this.btnCrane_3_WaterStatus);
            this.panel2.Controls.Add(this.btnCrane_2_WaterStatus);
            this.panel2.Controls.Add(this.btnCrane_1_WaterStatus);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnCraneIsShow);
            this.panel2.Controls.Add(this.btnUpSaddle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 1046);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2047, 62);
            this.panel2.TabIndex = 14;
            // 
            // btnPhotogate_CD
            // 
            this.btnPhotogate_CD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPhotogate_CD.BackColor = System.Drawing.Color.AliceBlue;
            this.btnPhotogate_CD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPhotogate_CD.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPhotogate_CD.Location = new System.Drawing.Point(534, 4);
            this.btnPhotogate_CD.Margin = new System.Windows.Forms.Padding(4);
            this.btnPhotogate_CD.Name = "btnPhotogate_CD";
            this.btnPhotogate_CD.Size = new System.Drawing.Size(189, 52);
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
            this.btnPhotogate_AB.Location = new System.Drawing.Point(336, 4);
            this.btnPhotogate_AB.Margin = new System.Windows.Forms.Padding(4);
            this.btnPhotogate_AB.Name = "btnPhotogate_AB";
            this.btnPhotogate_AB.Size = new System.Drawing.Size(189, 52);
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
            this.btnLoaderChange2.Location = new System.Drawing.Point(1450, 4);
            this.btnLoaderChange2.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoaderChange2.Name = "btnLoaderChange2";
            this.btnLoaderChange2.Size = new System.Drawing.Size(171, 52);
            this.btnLoaderChange2.TabIndex = 36;
            this.btnLoaderChange2.Text = "2#吊具：吸盘";
            this.btnLoaderChange2.UseVisualStyleBackColor = false;
            // 
            // btnLoaderChange1
            // 
            this.btnLoaderChange1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoaderChange1.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLoaderChange1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoaderChange1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoaderChange1.Location = new System.Drawing.Point(1270, 4);
            this.btnLoaderChange1.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoaderChange1.Name = "btnLoaderChange1";
            this.btnLoaderChange1.Size = new System.Drawing.Size(171, 52);
            this.btnLoaderChange1.TabIndex = 35;
            this.btnLoaderChange1.Text = "1#吊具：夹钳";
            this.btnLoaderChange1.UseVisualStyleBackColor = false;
            // 
            // btnCrane_3_WaterStatus
            // 
            this.btnCrane_3_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_3_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_3_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_3_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_3_WaterStatus.Location = new System.Drawing.Point(1090, 4);
            this.btnCrane_3_WaterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrane_3_WaterStatus.Name = "btnCrane_3_WaterStatus";
            this.btnCrane_3_WaterStatus.Size = new System.Drawing.Size(171, 52);
            this.btnCrane_3_WaterStatus.TabIndex = 34;
            this.btnCrane_3_WaterStatus.Text = "3#空调水排放";
            this.btnCrane_3_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // btnCrane_2_WaterStatus
            // 
            this.btnCrane_2_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_2_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_2_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_2_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_2_WaterStatus.Location = new System.Drawing.Point(910, 4);
            this.btnCrane_2_WaterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrane_2_WaterStatus.Name = "btnCrane_2_WaterStatus";
            this.btnCrane_2_WaterStatus.Size = new System.Drawing.Size(171, 52);
            this.btnCrane_2_WaterStatus.TabIndex = 33;
            this.btnCrane_2_WaterStatus.Text = "2#空调水排放";
            this.btnCrane_2_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // btnCrane_1_WaterStatus
            // 
            this.btnCrane_1_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_1_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_1_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_1_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_1_WaterStatus.Location = new System.Drawing.Point(730, 4);
            this.btnCrane_1_WaterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrane_1_WaterStatus.Name = "btnCrane_1_WaterStatus";
            this.btnCrane_1_WaterStatus.Size = new System.Drawing.Size(171, 52);
            this.btnCrane_1_WaterStatus.TabIndex = 32;
            this.btnCrane_1_WaterStatus.Text = "1#空调水排放";
            this.btnCrane_1_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button3.BackColor = System.Drawing.Color.AliceBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(171, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 52);
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
            this.button1.Location = new System.Drawing.Point(6, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 52);
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
            this.btnCraneIsShow.Location = new System.Drawing.Point(1881, 4);
            this.btnCraneIsShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnCraneIsShow.Name = "btnCraneIsShow";
            this.btnCraneIsShow.Size = new System.Drawing.Size(156, 52);
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
            this.btnUpSaddle.Location = new System.Drawing.Point(1715, 4);
            this.btnUpSaddle.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpSaddle.Name = "btnUpSaddle";
            this.btnUpSaddle.Size = new System.Drawing.Size(156, 52);
            this.btnUpSaddle.TabIndex = 14;
            this.btnUpSaddle.Text = "检修";
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.02965F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.97035F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2055, 1112);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // conRailwayCrane_3
            // 
            this.conRailwayCrane_3.BackColor = System.Drawing.SystemColors.Control;
            this.conRailwayCrane_3.CraneNO = "";
            this.conRailwayCrane_3.CranesDistain = ((long)(0));
            this.conRailwayCrane_3.CraneXAct = ((long)(0));
            this.conRailwayCrane_3.Location = new System.Drawing.Point(1244, -4);
            this.conRailwayCrane_3.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.conRailwayCrane_3.Name = "conRailwayCrane_3";
            this.conRailwayCrane_3.Size = new System.Drawing.Size(70, 658);
            this.conRailwayCrane_3.TabIndex = 5;
            // 
            // conRailwayCrane_2
            // 
            this.conRailwayCrane_2.BackColor = System.Drawing.SystemColors.Control;
            this.conRailwayCrane_2.CraneNO = "";
            this.conRailwayCrane_2.CranesDistain = ((long)(0));
            this.conRailwayCrane_2.CraneXAct = ((long)(0));
            this.conRailwayCrane_2.Location = new System.Drawing.Point(1010, 0);
            this.conRailwayCrane_2.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.conRailwayCrane_2.Name = "conRailwayCrane_2";
            this.conRailwayCrane_2.Size = new System.Drawing.Size(68, 658);
            this.conRailwayCrane_2.TabIndex = 4;
            // 
            // conRailwayCrane_1
            // 
            this.conRailwayCrane_1.BackColor = System.Drawing.SystemColors.Control;
            this.conRailwayCrane_1.CraneNO = "";
            this.conRailwayCrane_1.CranesDistain = ((long)(0));
            this.conRailwayCrane_1.CraneXAct = ((long)(0));
            this.conRailwayCrane_1.Location = new System.Drawing.Point(734, 3);
            this.conRailwayCrane_1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.conRailwayCrane_1.Name = "conRailwayCrane_1";
            this.conRailwayCrane_1.Size = new System.Drawing.Size(68, 656);
            this.conRailwayCrane_1.TabIndex = 3;
            // 
            // conCraneStatus3
            // 
            this.conCraneStatus3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus3.CraneNO = "";
            this.conCraneStatus3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus3.Location = new System.Drawing.Point(1364, 8);
            this.conCraneStatus3.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.conCraneStatus3.Name = "conCraneStatus3";
            this.conCraneStatus3.Size = new System.Drawing.Size(669, 346);
            this.conCraneStatus3.TabIndex = 9;
            // 
            // conCraneStatus2
            // 
            this.conCraneStatus2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus2.CraneNO = "";
            this.conCraneStatus2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus2.Location = new System.Drawing.Point(685, 8);
            this.conCraneStatus2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.conCraneStatus2.Name = "conCraneStatus2";
            this.conCraneStatus2.Size = new System.Drawing.Size(667, 346);
            this.conCraneStatus2.TabIndex = 8;
            // 
            // conCraneStatus1
            // 
            this.conCraneStatus1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1.CraneNO = "";
            this.conCraneStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1.Location = new System.Drawing.Point(6, 8);
            this.conCraneStatus1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.conCraneStatus1.Name = "conCraneStatus1";
            this.conCraneStatus1.Size = new System.Drawing.Size(667, 346);
            this.conCraneStatus1.TabIndex = 7;
            // 
            // FrmRailwayABayMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2055, 1112);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmRailwayABayMonitor";
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
        private CONTROLS_OF_REPOSITORIES.conCraneDisplay conRailwayCrane_3;
        private CONTROLS_OF_REPOSITORIES.conCraneDisplay conRailwayCrane_2;
        private CONTROLS_OF_REPOSITORIES.conCraneDisplay conRailwayCrane_1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CONTROLS_OF_REPOSITORIES.conCraneStatus conCraneStatus3;
        private CONTROLS_OF_REPOSITORIES.conCraneStatus conCraneStatus2;
        private CONTROLS_OF_REPOSITORIES.conCraneStatus conCraneStatus1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCrane_3_WaterStatus;
        private System.Windows.Forms.Button btnCrane_2_WaterStatus;
        private System.Windows.Forms.Button btnCrane_1_WaterStatus;
        private System.Windows.Forms.Button btnLoaderChange2;
        private System.Windows.Forms.Button btnLoaderChange1;
        private System.Windows.Forms.Button btnPhotogate_CD;
        private System.Windows.Forms.Button btnPhotogate_AB;
    }
}