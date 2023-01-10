using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.MsgService.Interface;

using MODULES_OF_PREMIERE;

namespace CONTROLS_OF_PREMIERE
{
    public partial class ConCraneStatusPanel : UserControl
    {
        bool isAllowPLCOrder = false;
        bool isAntiSway = false;
        int mouseBtnCount = 0;
        public ConCraneStatusPanel()
        {
            InitializeComponent();
            this.Load += ConCraneStatusPanel_Load;
            
        }

        void ConCraneStatusPanel_Load(object sender, EventArgs e)
        {
            this.Text = "行车监控-调试";
            panel25.MouseClick += cmdDownLoadPlan_MouseClick;
            mouseBtnCount = 0;
        }

        public const long SHORT_CMD_NORMAL_STOP = 100;
        public const long SHORT_CMD_EMG_STOP = 200;
        public const long SHORT_CMD_RESET = 300;
        public const long SHORT_CMD_ASK_COMPUTER_AUTO = 400;
        public const long SHORT_CMD_CANCEL_COMPUTER_AUTO = 500;

        private const string Crane7 = "7";
        private const string Crane4 = "4";
        private const string Crane_7_4 = "7_4";

        public const string MESSAGE_NO_SHORT_CMD = "HMICRANE01";

        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        private string tagServiceName = string.Empty;
        //step1
        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                this.tagServiceName = tagServiceName;
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {
            }
        }


        private string craneNO = string.Empty;
        //step2
        public string CraneNO
        {
            get { return craneNO; }
            set { craneNO = value; }
        }


        private CranePLCStatusBase cranePLCStatusBase = new CranePLCStatusBase();
        public delegate void RefreshControlInvoke(CranePLCStatusBase theCranePLCStatusBase);
        //step3
        public void RefreshControl(CranePLCStatusBase theCranePLCStatusBase)
        {
            try
            {

                cranePLCStatusBase = theCranePLCStatusBase;

                //1 CRANE_NO
                text_CraneNO.Text =  "行车 "+cranePLCStatusBase.CraneNO.ToString() ;

                //2 READY 
                refresh_Textbox_Light(light_READY, cranePLCStatusBase.Ready);

                //3 CONTROL_MODE  字2
                if (cranePLCStatusBase.ControlMode == 4)
                {
                    refresh_Textbox_Light(light_CONTROL_MODE, 1);
                }
                else
                {
                    refresh_Textbox_Light(light_CONTROL_MODE, 0);
                }
                txt_CONTROL_MODE.Text = cranePLCStatusBase.ControlMode.ToString();

                //4 ASK_PLAN
                refresh_Textbox_Light(light_ASK_PLAN, cranePLCStatusBase.AskPlan);

                //5 TASK_EXCUTING 
                refresh_Textbox_Light(light_TASK_EXCUTING, cranePLCStatusBase.TaskExcuting);

                //6 XACT
                txt_XACT.Text = cranePLCStatusBase.XAct.ToString("0,000");

                //7 YACT
                txt_YACT.Text = cranePLCStatusBase.YAct.ToString("0,000");

                //8 ZACT
                txt_ZACT.Text = cranePLCStatusBase.ZAct.ToString("0,000");

                //9 XSPEED
                txt_XSPEED.Text = cranePLCStatusBase.XSpeed.ToString();

                //10 YSPEED
                txt_YSPEED.Text = cranePLCStatusBase.YSpeed.ToString();

                //11 ZSPEED
                txt_ZSPEED.Text = cranePLCStatusBase.ZSpeed.ToString();

                //12 XDIR_P
                refresh_Textbox_Light(light_XDIR_P, cranePLCStatusBase.XDirPositive);

                //13 XDIR_N
                refresh_Textbox_Light(light_XDIR_N, cranePLCStatusBase.XDirectNegative);

                //14 YDIR_P
                refresh_Textbox_Light(light_YDIR_P, cranePLCStatusBase.YDirectPositive);

                //15 YDIR_N
                refresh_Textbox_Light(light_YDIR_N, cranePLCStatusBase.YDirectNegative);

                //16 ZDIR_P
                refresh_Textbox_Light(light_ZDIR_P, cranePLCStatusBase.ZDirectPositive);

                //17 ZDIR_N
                refresh_Textbox_Light(light_ZDIR_N, cranePLCStatusBase.ZDirectNegative);

                //18 HAS_COIL
                refresh_Textbox_Light(light_HAS_COIL, cranePLCStatusBase.HasCoil);

                //19 HAS_COIL
                refresh_Textbox_Light(light_HAS_COIL, cranePLCStatusBase.HasCoil);

                //2018-02-05 add
                txt_WEIGHT_LOADED.Text = cranePLCStatusBase.WeightLoaded.ToString();

                //20 ROTATE_ANGLE_ACT
                txt_ROTATE_ANGLE_ACT.Text = cranePLCStatusBase.RotateAngleAct.ToString();

                //21 CLAMP_WIDTH_ACT
                txt_CLAMP_WIDTH_ACT.Text = cranePLCStatusBase.ClampWidthAct.ToString();

                //22 EMG_STOP
                refresh_Textbox_Light(light_EMG_STOP, cranePLCStatusBase.EmgStop);

                //23 ORDER_ID
                txt_ORDER_ID.Text = cranePLCStatusBase.OrderID.ToString();

                //24 PLAN_UP_X
                txt_PLAN_UP_X.Text = cranePLCStatusBase.PlanUpX.ToString();

                //25 PLAN_UP_Y
                txt_PLAN_UP_Y.Text = cranePLCStatusBase.PlanUpY.ToString();

                //26 PLAN_UP_Z
                txt_PLAN_UP_Z.Text = cranePLCStatusBase.PlanUpZ.ToString();

                //27 PLAN_DOWN_X
                txt_PLAN_DOWN_X.Text = cranePLCStatusBase.PlanDownX.ToString();

                //28 PLAN_DOWN_Y
                txt_PLAN_DOWN_Y.Text = cranePLCStatusBase.PlanDownY.ToString();

                //29 PLAN_DOWN_Z
                txt_PLAN_DOWN_Z.Text = cranePLCStatusBase.PlanDownZ.ToString();

                //30 CRANE_STATUS
                txt_CRANE_STATUS.Text = cranePLCStatusBase.CraneStatus.ToString();

                //31 HeartBeat
                if (txt_HeartBeat.Text == cranePLCStatusBase.ReceiveTime.ToString() && communicate_PLC_OK==true)
                {
                    heatBeatCounter++;
                }
                if (txt_HeartBeat.Text != cranePLCStatusBase.ReceiveTime.ToString() && communicate_PLC_OK == true)
                {
                    heatBeatCounter=0;
                }
                else if (txt_HeartBeat.Text != cranePLCStatusBase.ReceiveTime.ToString() && communicate_PLC_OK == false)
                {
                    heatBeatCounter=0;
                    communicate_PLC_OK = true;
                }

                if (heatBeatCounter >= 20 && communicate_PLC_OK == true)
                {
                       communicate_PLC_OK = false;
                }

                if (communicate_PLC_OK)
                {
                    txt_HeartBeat.BackColor = Color.LightGreen;
                }
                else
                {
                    txt_HeartBeat.BackColor = Color.Red;
                }

                txt_HeartBeat.Text = cranePLCStatusBase.ReceiveTime.ToString();

                txt_CRANE_STATUS_DESC.Text = cranePLCStatusBase.CraneStatusDesc().ToString();
            }
            catch (Exception ex)
            {
            }
        }

        long heatBeatCounter=0;
        bool communicate_PLC_OK = true;

        private static void refresh_Textbox_Light(TextBox theTextBox, long theValue)
        {
            try
            {

                if (theValue == 1)
                {
                    theTextBox.BackColor = Color.LightGreen;
                }
                else 
                {
                    theTextBox.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SendShortCmd(string theMessageNO,string theCraneNO, long cmdFlag)
        {
            try
            {
                string messageBuffer = string.Empty;

                messageBuffer = theCraneNO + "," + cmdFlag.ToString();

                // if you need to use InvokeP99  release these code
                //string objectName = theCraneNO;

                //XComMessage0 xComMessage0 = new XComMessage0();
                //xComMessage0.Lineno = 0;
                //xComMessage0.TextLenth = 0;
                //xComMessage0.MessageNO = theMessageNO;
                //xComMessage0.TextBuf = messageBuffer;



               //InvokeP99(objectName, xComMessage0.Code2Bytes());

                Baosight.iSuperframe.TagService.DataCollection<object> wirteDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                wirteDatas[theCraneNO + "_DownLoadShortCommand"] = messageBuffer;
                tagDataProvider.SetData(theCraneNO + "_DownLoadShortCommand", messageBuffer);

            }
            catch (Exception ex)
            {
            }
        }
        //切手动
        private void cmd_Manu_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CraneNO.IndexOf(Crane7) > -1)
                //{
                //    if (CraneNO != Crane_7_4)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法切手动");
                //        return;
                //    }

                //}
                //else
                //{
                //    if (CraneNO.IndexOf(Crane4) > -1)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法切手动");
                //        return;
                //    }
                //}
                SendShortCmd(MESSAGE_NO_SHORT_CMD, craneNO, SHORT_CMD_CANCEL_COMPUTER_AUTO);
                UACSUtility.HMILogger.WriteLog(cmd_Manu.Text, "行车切手动 ， 行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);

            }
            catch (Exception ex)
            {
            }
        }

        //切自动
        private void cmd_Auto_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CraneNO.IndexOf(Crane7) > -1)
                //{
                //    if (CraneNO != Crane_7_4)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法切自动");
                //        return;
                //    }

                //}
                //else
                //{
                //    if (CraneNO.IndexOf(Crane4) > -1)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法切自动");
                //        return;
                //    }

                //}


                if (DialogResult.OK == MessageBox.Show("注意,行车切自动", "Warning", MessageBoxButtons.OK))
                {
                    SendShortCmd(MESSAGE_NO_SHORT_CMD, craneNO, SHORT_CMD_ASK_COMPUTER_AUTO);
                    UACSUtility.HMILogger.WriteLog(cmd_Auto.Text, "行车切自动 ， 行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);

                }
                

                //timer_AutoReset.Stop();

                //timer_AutoReset.Start();
                
                
            }
            catch (Exception ex)
            {
            }
        }

        //紧急停止
        private void cmd_EmergencyStop_Click(object sender, EventArgs e)
        {
            try
            {

                //if (CraneNO.IndexOf(Crane7) > -1)
                //{
                //    if (CraneNO != Crane_7_4)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法紧急停止");
                //        return;
                //    }

                //}
                //else
                //{
                //    if (CraneNO.IndexOf(Crane4) > -1)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法紧急停止");
                //        return;
                //    }

                //}
                SendShortCmd(MESSAGE_NO_SHORT_CMD, craneNO, SHORT_CMD_EMG_STOP);
                UACSUtility.HMILogger.WriteLog(cmd_EmergencyStop.Text, "行车切紧急 ， 行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);

            }
            catch (Exception ex)
            {
            }
        }

        //复位
        private void cmd_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CraneNO.IndexOf(Crane7) > -1)
                //{
                //    if (CraneNO != Crane_7_4)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法复位");
                //        return;
                //    }

                //}
                //else
                //{
                //    if (CraneNO.IndexOf(Crane4) > -1)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法复位");
                //        return;
                //    }
                //}

                SendShortCmd(MESSAGE_NO_SHORT_CMD, craneNO, SHORT_CMD_RESET);
                UACSUtility.HMILogger.WriteLog(cmd_Reset.Text, "行车切复位 ， 行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);

            }
            catch (Exception ex)
            {
            }
        }

        //要求停车
        private void cmdStopMoving_Click(object sender, EventArgs e)
        {
            try
            {

                //if (CraneNO.IndexOf(Crane7) > -1)
                //{
                //    if (CraneNO != Crane_7_4)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法停车");
                //        return;
                //    }

                //}
                //else
                //{
                //    if (CraneNO.IndexOf(Crane4) > -1)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法停车");
                //        return;
                //    }
                //}
                //SendShortCmd(MESSAGE_NO_SHORT_CMD, craneNO, SHORT_CMD_NORMAL_STOP);
                PopStartLaserDevice popfrm = new PopStartLaserDevice();
                popfrm.InitTagDataProvide(tagServiceName);
                popfrm.CraneNO = craneNO;

                popfrm.Show();

            }
            catch (Exception ex)
            {
            }
        }

        PopCranePLCOrderSetting popCranePLCOrderSetting =new PopCranePLCOrderSetting ();

        //行车指令输入按钮按下，指令参数对话框弹出
        private void cmdDownLoadPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isAntiSway)
                {
                    FrmPassword frm = new FrmPassword();
                    frm.ShowDialog();
                    if (frm.isAllow)
                    {
                        isAllowPLCOrder = true;
                        mouseBtnCount = 0;
                    }
                    if (!isAllowPLCOrder)
                    {
                        return;
                    }
                }

                if (popCranePLCOrderSetting != null)
                {
                    popCranePLCOrderSetting.Close();
                    popCranePLCOrderSetting = null;
                }
                popCranePLCOrderSetting = new PopCranePLCOrderSetting();
                popCranePLCOrderSetting.InitTagDataProvide(tagServiceName);
                popCranePLCOrderSetting.CraneNO = craneNO;
                popCranePLCOrderSetting.Show();
                if (!isAntiSway)
                {
                    isAllowPLCOrder = false;
                }
 
            }
            catch (Exception ex)
            {
            }
        }


        private void InvokeP99(string objname, byte[] bytes)
        {
            IServiceMonitor svrMntor = FrameContext.Instance.GetPlugin<IMsgServicePlugin>() as IServiceMonitor;
            if (svrMntor == null)
            {
                MessageBox.Show(this, "MsgServicePlugin not find", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IMsgService msgsvr = svrMntor.ServiceContainer.Get(objname) as IMsgService;
            if (msgsvr == null)
            {
                MessageBox.Show(this, "MsgService " + objname + " not find", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            try
            {
                msgsvr.SendMSG(bytes);
                MessageBox.Show(this, "Send OK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, "Send Failed " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        PopCraneComputerOrderSetting popCraneComputerOrderSetting = new PopCraneComputerOrderSetting();
        private void cmdComputerOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CraneNO.IndexOf(Crane7) > -1)
                //{
                //    MessageBox.Show(CraneNO + "暂时无法下达计算机指令");
                //    return;
                //}
                //else
                //{
                //    if (CraneNO.IndexOf(Crane4) > -1)
                //    {
                //        MessageBox.Show(CraneNO + "暂时无法下达计算机指令");
                //        return;
                //    }
                //}
                        //string[] arrTagAdress;
                        //List<string> lstAdress = new List<string>();

                        //lstAdress.Add(craneNO + "_ROUTE_POINTS");
                        //arrTagAdress = lstAdress.ToArray<string>();

                        //Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                        //tagDataProvider.GetData(arrTagAdress, out inDatas);


                        //string theValue = string.Empty;
                        //object valueObject = null;
                        //try
                        //{
                        //    valueObject = inDatas[craneNO + "_ROUTE_POINTS"];
                        //    theValue = Convert.ToString((valueObject));
                        //}
                        //catch
                        //{
                           
                        //}

                        //string[] strResult = theValue.Split('|');

                        //string messageBoxResult = string.Empty;
                        //foreach (string temp in strResult)
                        //{
                        //    messageBoxResult += temp + "\n";
                        //}
                        //MessageBox.Show(messageBoxResult);


                        if (popCraneComputerOrderSetting != null)
                        {
                                popCraneComputerOrderSetting.Close();
                                popCraneComputerOrderSetting = null;
                         }
                        popCraneComputerOrderSetting = new PopCraneComputerOrderSetting();
                        popCraneComputerOrderSetting.InitTagDataProvide(tagServiceName);
                        popCraneComputerOrderSetting.CraneNO = craneNO;
                        popCraneComputerOrderSetting.Show();
                    

            }
            catch (Exception ex)
            {
            }
        }

        private void timer_AutoReset_Tick(object sender, EventArgs e)
        {
            
            SendShortCmd(MESSAGE_NO_SHORT_CMD, craneNO, SHORT_CMD_RESET);
            timer_AutoReset.Stop();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopAlarmCurrent popAlarm = new PopAlarmCurrent();
            popAlarm.Crane_No = craneNO;
            popAlarm.ShowDialog();
        }

        private void btnEvade_Click(object sender, EventArgs e)
        {
            PopCraneEvade craneEvade = new PopCraneEvade();
            craneEvade.Crane_NO = craneNO;
            craneEvade.Show( this );
        }

        private void btnStockToStock_Click(object sender, EventArgs e)
        {
            PopStockToStock form = new PopStockToStock();
            form.CraneNO = CraneNO;
            form.Show();
        }

        private void cmdDownLoadPlan_MouseClick(object sender, MouseEventArgs e)
        {
 
            if (e.Button== System.Windows.Forms.MouseButtons.Left && mouseBtnCount>10)
            {
                isAllowPLCOrder = true;
                isAntiSway = true;
                MessageBox.Show("防摇调试模式开启！");
            }
            else if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                mouseBtnCount += 2;
            }

        }


    }
}
