using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using MODEL_OF_REPOSITORIES;
using CONTROLS_OF_REPOSITORIES;
using System.Threading;
using HMI_OF_REPOSITORIES;
using System.Runtime.InteropServices;
namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmRailwayABayMonitor : FormBase
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        //Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new Baosight.iSuperframe.TagService.DataCollection<object>();
        private CraneStatusInBay craneStatusInBay = new CraneStatusInBay();
        private List<conCraneDisplay> listConCraneDisplay = new List<conCraneDisplay>();
        private List<conCraneStatus> lstConCraneStatusPanel = new List<conCraneStatus>();
        private List<string> CraneNoList = new List<string>();
        private conAreaInStockMessage AreaInStock;
        private conParkingSpaceInMessage ParkingSpace;
        private const string craneNO_1 = "1";
        private const string craneNO_2 = "2";
        private const string craneNO_3 = "3";
        private bool isCranteArea = false;
        private bool isNDoorStatus = false;
        private bool isBDoorStatus = false;
        private bool isRefesh = false;
        public FrmRailwayABayMonitor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.Load += RailwayABayMonitor_Load;

            btnCrane_1_WaterStatus.Name = craneNO_1;
            btnCrane_2_WaterStatus.Name = craneNO_2;
            btnCrane_3_WaterStatus.Name = craneNO_3;

            btnLoaderChange1.Name = craneNO_1;
            btnLoaderChange2.Name = craneNO_2;
        }

        #region 事件方法
        //空调水排放
        void btnCrane_1_WaterStatus_Click(object sender, EventArgs e)
        {
            //检查
            Button btn = (Button)sender;
            if (!AreaInStock.updataCraneWaterLevel(btn.Name))
            {
                MessageBoxButtons btn1 = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show(btn.Name + "#行车水位没有到达报警值，不能进行放水!", "提示", btn1, MessageBoxIcon.Asterisk);
                return;
            }
            SubFrmLetOutWater frm = new SubFrmLetOutWater(btn.Name);
            frm.ShowDialog();
            //if (frm.CraneDrainWater)
            //{ ((Button)sender).BackColor = Color.Green; }
        }
        //吊具切换
        void btnLoaderChange1_Click(object sender, EventArgs e)
        {
            //用户信息确认
            SubFrmUserLogin form = new SubFrmUserLogin();
            form.ShowDialog();
            if (form.DialogResultLogin == DialogResult.Cancel)
            {
                return;
            }
            if (!form.AllowLogin)
            { 
                MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string tagNmae = "";
            //string tagValue = "";
            switch (((Button)sender).Name)
            {
                case craneNO_1:
                    tagNmae=TagNameClass.tag_1_DownLoadClampSucker;
                    break;
                case craneNO_2:
                    tagNmae=TagNameClass.tag_2_DownLoadClampSucker;
                    break;
                default:
                    break;
            }
            if (AreaInStock.getCarneLoderType(((Button)sender).Name))   //吸盘
            {
                MessageBoxButtons btn1 = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show(((Button)sender).Name+ "#行车吊具切换为夹钳？", "提示", btn1, MessageBoxIcon.Asterisk);
                if (dr==DialogResult.OK)
                {
                    tagDP.SetData(tagNmae, ((Button)sender).Name+"|"+"0");
                    UACSUtility.HMILogger.WriteLog(btnLoaderChange1.Text, "行车吊具切换为夹钳,用户：" + form.UserName, UACSUtility.LogLevel.Info, this.Text);
                }
            }
            else
            {
                MessageBoxButtons btn1 = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show(((Button)sender).Name + "#行车吊具切换为吸盘？", "提示", btn1, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.OK)
                {
                    tagDP.SetData(tagNmae, ((Button)sender).Name + "|" + "1");
                    UACSUtility.HMILogger.WriteLog(btnLoaderChange1.Text, "行车吊具切换为吸盘,用户：" + form.UserName, UACSUtility.LogLevel.Info, this.Text);
                }
            }
        } 
        #endregion

        //解决窗体加载闪烁问题
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }


        void RailwayABayMonitor_Load(object sender, EventArgs e)
        {
            AreaInStock = new conAreaInStockMessage(SaddleBase.BayNo_RailwayA);
            ParkingSpace = new conParkingSpaceInMessage("A");
            // -------------------事件--------------------------------------
            btnCrane_1_WaterStatus.Click += btnCrane_1_WaterStatus_Click;
            btnCrane_2_WaterStatus.Click += btnCrane_1_WaterStatus_Click;
            btnCrane_3_WaterStatus.Click += btnCrane_1_WaterStatus_Click;
            btnLoaderChange1.Click += btnLoaderChange1_Click;
            btnLoaderChange2.Click += btnLoaderChange1_Click;
            //--------------------跨别行车配置-------------------------------
            CraneNoList.Add(craneNO_1);
            CraneNoList.Add(craneNO_2);
            CraneNoList.Add(craneNO_3);

            //-------------------行车显示配置--------------------------------
            conRailwayCrane_1.InitTagDataProvide(SaddleBase.tagServiceName);
            conRailwayCrane_1.CraneNO = craneNO_1;
            listConCraneDisplay.Add(conRailwayCrane_1);

            conRailwayCrane_2.InitTagDataProvide(SaddleBase.tagServiceName);
            conRailwayCrane_2.CraneNO = craneNO_2;
            listConCraneDisplay.Add(conRailwayCrane_2);

            conRailwayCrane_3.InitTagDataProvide(SaddleBase.tagServiceName);
            conRailwayCrane_3.CraneNO = craneNO_3;
            listConCraneDisplay.Add(conRailwayCrane_3);

            //---------------------行车状态配置-------------------------------
            conCraneStatus1.InitTagDataProvide(SaddleBase.tagServiceName);
            conCraneStatus1.CraneNO = craneNO_1;
            lstConCraneStatusPanel.Add(conCraneStatus1);

            conCraneStatus2.InitTagDataProvide(SaddleBase.tagServiceName);
            conCraneStatus2.CraneNO = craneNO_2;
            lstConCraneStatusPanel.Add(conCraneStatus2);

            conCraneStatus3.InitTagDataProvide(SaddleBase.tagServiceName);
            conCraneStatus3.CraneNO = craneNO_3;
            lstConCraneStatusPanel.Add(conCraneStatus3);

            //---------------------行车tag配置--------------------------------
            craneStatusInBay.InitTagDataProvide(SaddleBase.tagServiceName);
            craneStatusInBay.AddCraneNO(craneNO_1);
            craneStatusInBay.AddCraneNO(craneNO_2);
            craneStatusInBay.AddCraneNO(craneNO_3);
            craneStatusInBay.SetReady();
            //用于道闸Tag
            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            //TagValues.Clear();
            //
            //TagValues.Add("EV_SAFEDOOR", null);
            //tagDP.Attach(TagValues);

            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer2.Enabled = true;
            
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (tabActived == false)
            {
                return;
            }

            //--------------------------显示小区-------------------------------------------
            AreaInStock.conInit(plRailwayABay, 
                SaddleBase.BayNo_RailwayA,
                SaddleBase.tagServiceName, 
                SaddleBase.RailwayAbaySpaceX, 
                SaddleBase.RailwayAbaySpaceY, 
                plRailwayABay.Width, 
                plRailwayABay.Height, 
                SaddleBase.xAxisRight, 
                SaddleBase.yAxisDown, 
                isNDoorStatus, 
                isBDoorStatus, 
                isRefesh);

            //--------------------------显示停车位-------------------------------------------
            ParkingSpace.conInit(plRailwayABay, 
                SaddleBase.tagServiceName,
                SaddleBase.RailwayAbaySpaceX, 
                SaddleBase.RailwayAbaySpaceY,
                SaddleBase.xAxisRight, 
                SaddleBase.yAxisDown);
            //-------------------------行车水位报警------------------------------------------
            btnCrane_1_WaterStatus.BackColor = AreaInStock.updataCraneWaterLevel(craneNO_1) ? Color.Red : Color.AliceBlue;
            btnCrane_2_WaterStatus.BackColor = AreaInStock.updataCraneWaterLevel(craneNO_2) ? Color.Red : Color.AliceBlue;
            btnCrane_3_WaterStatus.BackColor = AreaInStock.updataCraneWaterLevel(craneNO_3) ? Color.Red : Color.AliceBlue;
            //-------------------------吊具类型------------------------------------------
            btnLoaderChange1.Text = AreaInStock.getCarneLoderType(craneNO_1) ? "1#吊具：吸盘" : "1#吊具：夹钳";
            btnLoaderChange1.BackColor = AreaInStock.getCarneLoderType(craneNO_1) ? SystemColors.Control : Color.AliceBlue;
            btnLoaderChange2.Text = AreaInStock.getCarneLoderType(craneNO_2) ? "2#吊具：吸盘" : "2#吊具：夹钳";
            btnLoaderChange2.BackColor = AreaInStock.getCarneLoderType(craneNO_2) ? SystemColors.Control : Color.AliceBlue;
            //-------------------------光电门------------------------------------------------
            btnPhotogate_AB.Text = AreaInStock.getPhotogateStatus("AB") ? "AB区光电门：关" : "AB区光电门：开";
            btnPhotogate_AB.BackColor = AreaInStock.getPhotogateStatus("AB") ? Color.AliceBlue : Color.Red;
            btnPhotogate_CD.Text = AreaInStock.getPhotogateStatus("CD") ? "CD区光电门：关" : "CD区光电门：开";
            btnPhotogate_CD.BackColor = AreaInStock.getPhotogateStatus("CD") ? Color.AliceBlue : Color.Red;
            //-------------------------道闸--------------------------------------------------
            if (AreaInStock.getDaoZhaUpperStatus("N"))
            { button3.Text = "北道闸：开"; button3.BackColor = SystemColors.Control; SetGatStatus("N", true); }
            else if (AreaInStock.getDaoZhaLowerStatus("N"))
            { button3.Text = "北道闸：关"; button3.BackColor = Color.AliceBlue; SetGatStatus("N", false); }
            else
                button3.Text = "北道闸：...";
            if (AreaInStock.getDaoZhaUpperStatus("S"))
            { button1.Text = "南道闸：开"; button1.BackColor = SystemColors.Control; SetGatStatus("S", true); }
            else if (AreaInStock.getDaoZhaLowerStatus("S"))
            { button1.Text = "南道闸：关"; button1.BackColor = Color.AliceBlue; SetGatStatus("S", false); }
            else
                button1.Text = "南道闸：...";

            isRefesh = true;

            timer1.Interval = 3000;

            ClearMemory();
            //foreach (Control c in plRailwayABay.Controls)
            //{
            //    if (c is conArea)
            //    {
            //        LogManager.WriteProgramLog(c.Name);
            //        LogManager.WriteProgramLog(c.Width.ToString());
            //        LogManager.WriteProgramLog(c.Height.ToString());
            //    }
            //}  

          // timer1.Enabled = false;
            
        }
        //TODO:1、显示小区
        //TODO:2、划分区域
        //TODO:3、停车位显示
        int index = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {


            if (tabActived == false)
            {
                return;
            }

            try
            {

                craneStatusInBay.getAllPLCStatusInBay(CraneNoList);

                //--------------------------行车指令控件刷新------------------------------------------
                foreach (conCraneStatus conCraneStatusPanel in lstConCraneStatusPanel)
                {
                    conCraneStatus.RefreshControlInvoke ConCraneStatusPanel_Invoke = new conCraneStatus.RefreshControlInvoke(conCraneStatusPanel.RefreshControl);
                    conCraneStatusPanel.BeginInvoke(ConCraneStatusPanel_Invoke, new Object[] { craneStatusInBay.DicCranePLCStatusBase[conCraneStatusPanel.CraneNO].Clone() });
                }

                //if (!isCranteArea)
                //{
                //    //--------------------------显示小区-------------------------------------------
                //    AreaInStock.conInit(plRailwayABay, SaddleBase.BayNo_RailwayA, SaddleBase.tagServiceName, SaddleBase.RailwayAbaySpaceX, SaddleBase.RailwayAbaySpaceY, plRailwayABay.Width, plRailwayABay.Height, SaddleBase.xAxisRight, SaddleBase.yAxisDown, false);

                //    //--------------------------显示停车位-------------------------------------------
                //    ParkingSpace.conInit(plRailwayABay, SaddleBase.tagServiceName, SaddleBase.RailwayAbaySpaceX, SaddleBase.RailwayAbaySpaceY, SaddleBase.xAxisRight, SaddleBase.yAxisDown);

                //    isCranteArea = true;
                //    //index = 0;
                //}

            
                //--------------------------行车显示控件刷新-------------------------------------------
                foreach (conCraneDisplay conCraneVisual in listConCraneDisplay)
                {
                    conCraneDisplay.RefreshControlInvoke ConCraneVisual_Invoke = new conCraneDisplay.RefreshControlInvoke(conCraneVisual.RefreshControl);
                    conCraneVisual.BeginInvoke(ConCraneVisual_Invoke, new Object[] { craneStatusInBay.DicCranePLCStatusBase[conCraneVisual.CraneNO].Clone(), SaddleBase.RailwayAbaySpaceX, SaddleBase.RailwayAbaySpaceY, plRailwayABay.Width, plRailwayABay.Height, SaddleBase.xAxisRight, SaddleBase.yAxisDown, 12000, plRailwayABay });
                    
                }
               
                //index++;
                //计算两车距离

                conRailwayCrane_1.calculateCraneDistain(conRailwayCrane_2.CraneXAct);
                conRailwayCrane_3.calculateCraneDistain(conRailwayCrane_2.CraneXAct);
                if (conRailwayCrane_2.calculateCraneDistain(conRailwayCrane_1.CraneXAct) < conRailwayCrane_2.calculateCraneDistain(conRailwayCrane_3.CraneXAct))
                    conRailwayCrane_2.calculateCraneDistain(conRailwayCrane_1.CraneXAct);
                else
                    conRailwayCrane_2.calculateCraneDistain(conRailwayCrane_3.CraneXAct);
            }
            catch (Exception er)
            {
                MessageBox.Show("警告！出现"+ er.Message);
                timer2.Enabled = false;

            }
        }



        #region -----------------------------画面切换--------------------------------
        private bool tabActived = true;
        void MyTabActivated(object sender, EventArgs e)
        {
            tabActived = true;
        }
        void MyTabDeactivated(object sender, EventArgs e)
        {
            tabActived = false;
        }
        #endregion


        //窗体缩小后
        private void FrmRailwayABayMonitor_Resize(object sender, EventArgs e)
        {
            if (this.Height == 0)
                tabActived = false;
            else
                tabActived = true;
        }

        private void btnCraneIsShow_Click(object sender, EventArgs e)
        {
            if (btnCraneIsShow.Text == "行车隐藏")
            {
                conRailwayCrane_1.Visible = false;
                conRailwayCrane_2.Visible = false;
                conRailwayCrane_3.Visible = false;
                btnCraneIsShow.Text = "行车显示";
            }
            else
            {
                conRailwayCrane_1.Visible = true;
                conRailwayCrane_2.Visible = true;
                conRailwayCrane_3.Visible = true;
                btnCraneIsShow.Text = "行车隐藏";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Contains("开"))
            {
                DialogResult dr1 = MessageBox.Show("是否关闭南道闸？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (dr1 == DialogResult.Cancel)
                    return;
                isRefesh = false;
                tagDP.SetData("DAOZHA_A_SOUTH_CLOSE", "1");
                Thread.Sleep(1000);
                tagDP.SetData("DAOZHA_A_SOUTH_CLOSE", "0");
                SetGatStatus("S", false);
                UACSUtility.HMILogger.WriteLog(button1.Text, "关闭南道闸", UACSUtility.LogLevel.Info, this.Text);
            }
            else if (((Button)sender).Text.Contains("关"))
            {
                DialogResult dr = MessageBox.Show("是否打开南道闸？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Cancel)
                    return;
                isRefesh = false;
                tagDP.SetData("DAOZHA_A_SOUTH_OPEN", "1");
                Thread.Sleep(1000);
                tagDP.SetData("DAOZHA_A_SOUTH_OPEN", "0");
                SetGatStatus("S", true);
                UACSUtility.HMILogger.WriteLog(button1.Text, "打开南道闸", UACSUtility.LogLevel.Info, this.Text);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭南道闸？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Cancel)
                return;
            isRefesh = false;
            tagDP.SetData("DAOZHA_A_SOUTH_CLOSE", "1");
            Thread.Sleep(1000);
            tagDP.SetData("DAOZHA_A_SOUTH_CLOSE", "0");
            SetGatStatus("S", false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Contains("开"))
            {
                DialogResult dr = MessageBox.Show("是否关闭北道闸？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Cancel)
                    return;
                isRefesh = false;
                tagDP.SetData("DAOZHA_A_NORTH_CLOSE", "1");
                Thread.Sleep(1000);
                tagDP.SetData("DAOZHA_A_NORTH_CLOSE", "0");
                SetGatStatus("N", false);
                UACSUtility.HMILogger.WriteLog(button3.Text, "关闭北道闸", UACSUtility.LogLevel.Info, this.Text);
            }
            else if (((Button)sender).Text.Contains("关"))
            {
                DialogResult dr = MessageBox.Show("是否打开北道闸？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Cancel)
                    return;
                isRefesh = false;
                tagDP.SetData("DAOZHA_A_NORTH_OPEN", "1");
                Thread.Sleep(1000);
                tagDP.SetData("DAOZHA_A_NORTH_OPEN", "0");
                SetGatStatus("N", true);
                UACSUtility.HMILogger.WriteLog(button3.Text, "开北道闸", UACSUtility.LogLevel.Info, this.Text);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭北道闸？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Cancel)
                return;
            isRefesh = false;
            tagDP.SetData("DAOZHA_A_NORTH_CLOSE", "1");
            Thread.Sleep(1000);
            tagDP.SetData("DAOZHA_A_NORTH_CLOSE", "0");
            SetGatStatus("N", false);
        }

        private void btnPhotogate_AB_Click(object sender, EventArgs e)
        {
            
            if (((Button)sender).Text.Contains("关") )
            {
                MessageBox.Show("光电门已经处于关闭状态", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                 return;
            }
            DialogResult dr = MessageBox.Show("是否关闭AB区光电门？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                tagDP.SetData(TagNameClass.tag_AREA_SAFE_A_AB, "1");
                UACSUtility.HMILogger.WriteLog(btnPhotogate_AB.Text, "关闭AB区光电门", UACSUtility.LogLevel.Info, this.Text);
            }

        }

        private void btnPhotogate_CD_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Contains("关"))
            {
                MessageBox.Show("光电门已经处于关闭状态", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult dr = MessageBox.Show("是否关闭CD区光电门？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                tagDP.SetData(TagNameClass.tag_AREA_SAFE_A_CD, "1");
                UACSUtility.HMILogger.WriteLog(btnPhotogate_CD.Text, "关闭CD区光电门", UACSUtility.LogLevel.Info, this.Text);

            }
        }
        private void btnUpSaddle_Click(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
            timer2_Tick(null, null);
            //UACSUtility.HMILogger.WriteLog(btnUpSaddle.Text, "按钮刷新", UACSUtility.LogLevel.Info ,this.Text);
        }
        private void SetGatStatus(string gateName, bool status)
        {
            foreach (Control item in plRailwayABay.Controls)
            {
                if (item is conArea)
                {
                    conArea area = (conArea)item;
                    area.SetGateStatus(gateName, status);
                }
            }  
        }

        #region  -----------------------------内存回收--------------------------------
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                FrmRailwayABayMonitor.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion




    
    }
}
