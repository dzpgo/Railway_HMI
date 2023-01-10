using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;
using System.Media;

namespace CONTROLS_OF_REPOSITORIES
{
   
    public partial class conCraneStatus : UserControl
    {
        public const long SHORT_CMD_NORMAL_STOP = 100;
        public const long SHORT_CMD_EMG_STOP = 200;
        public const long SHORT_CMD_RESET = 300;
        public const long SHORT_CMD_ASK_COMPUTER_AUTO = 400;
        public const long SHORT_CMD_CANCEL_COMPUTER_AUTO = 500;
        private const string numberIsNull = "999999";
        private FrmModeSwitchover frmModeSwitchover = null;
        private PlaySoundHandler playSound = null;

        private bool flag = false;

        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();


        System.Object locker = new System.Object();
        public conCraneStatus()
        {
            InitializeComponent();
            this.Load += conCraneStatus_Load;

        }

        void conCraneStatus_Load(object sender, EventArgs e)
        {
          
        }


        private string TagServiceName = string.Empty;
        //step1
        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                this.TagServiceName = tagServiceName;
                tagDataProvider.ServiceName = TagServiceName;

                AuthorityManagement auth = new AuthorityManagement();

                playSound += new PlaySoundHandler(PlaySoundEvt);

                if (auth.isUserJudgeEqual("D308", "D202", "scal", "D212"))
                {
                    btnMode.Enabled = false;
                    btnStop.Enabled = false;
                }
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

        long heatBeatCounter = 0;
        bool communicate_PLC_OK = true;

        private CraneStatusBase craneStatusBase = new CraneStatusBase();
        public delegate void RefreshControlInvoke(CraneStatusBase theCraneStatusBase);
        //step3
        public void RefreshControl(CraneStatusBase theCraneStatusBase)
        {
            try
            {

                craneStatusBase = theCraneStatusBase;

                //行车号
                lbl_CraneNo.Text = "行车 " + craneStatusBase.CraneNO.ToString();
                //准备好信号灯
                refresh_Textbox_Light(light_READY, craneStatusBase.Ready);
                //自动信号灯
                if (craneStatusBase.ControlMode == 4)
                {
                    refresh_Textbox_Light(light_CONTROL_MODE, 1);
                }
                else
                {
                    refresh_Textbox_Light(light_CONTROL_MODE, 0);
                }
                //控制模式
                txt_CONTROL_MODE.Text = craneStatusBase.CraneModeDesc();
                //请求指令信号灯
                refresh_Textbox_Light(light_ASK_PLAN, craneStatusBase.AskPlan);
                //x
                txt_XACT.Text = craneStatusBase.XAct.ToString("0,000");
                //y
                txt_YACT.Text = craneStatusBase.YAct.ToString("0,000");
                //z
                txt_ZACT.Text = craneStatusBase.ZAct.ToString("0,000");
                //有卷信号灯
                refresh_Textbox_Light(light_HAS_COIL, craneStatusBase.HasCoil);
                //行车状态
                txt_CRANE_STATUS.Text = craneStatusBase.CraneStatusDesc();
                //与行车通讯状态
                if (lbl_HeartBeat.Text == craneStatusBase.ReceiveTime.ToString() && communicate_PLC_OK == true)
                {
                    heatBeatCounter++;
                }
                if (lbl_HeartBeat.Text != craneStatusBase.ReceiveTime.ToString() && communicate_PLC_OK == true)
                {
                    heatBeatCounter = 0;
                }
                else if (lbl_HeartBeat.Text != craneStatusBase.ReceiveTime.ToString() && communicate_PLC_OK == false)
                {
                    heatBeatCounter = 0;
                    communicate_PLC_OK = true;
                }

                if (heatBeatCounter >= 20 && communicate_PLC_OK == true)
                {
                    communicate_PLC_OK = false;
                }

                if (communicate_PLC_OK)
                {
                    lbl_HeartBeat.BackColor = Color.LightGreen;
                }
                else
                {
                    lbl_HeartBeat.BackColor = Color.Red;
                }
                //时间心跳
                lbl_HeartBeat.Text = craneStatusBase.ReceiveTime.ToString();
                //行车指令
                lblTextByCraneNo(craneStatusBase.CraneNO.ToString());

                if (txt_CONTROL_MODE.Text == "等待" && txt_CRANE_STATUS.Text == "999")
                {
                    btnShow.Visible = true;
                    if (!flag)
                    {
                        btnShow.BackColor = Color.Red;
                        flag = true;
                    }
                    else
                    {
                        btnShow.BackColor = System.Drawing.SystemColors.Control;
                        flag = false;
                    }
                    timer1.Enabled = true;
                   
                }
                else
                {
                    timer1.Enabled = false;
                    btnShow.Visible = false;
                }
               
      
                
            }
            catch (Exception ex)
            {
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            PlaySoundDelegate dge = new PlaySoundDelegate(PlaySoundFuntion);
            dge.BeginInvoke("行车故障.wav", null, null);
        }

        private void PlaySoundFuntion(string fileName)
        {
            if (btnShow.Visible == true)
            {
                SoundEvtAgs e = new SoundEvtAgs();
                e.FileName = fileName;
                playSound(this, e);
            }
        }
        private void PlaySoundEvt(object sender, SoundEvtAgs e)
        {
            playesounder(e.FileName);
        }
        private void playesounder(String strWaveName)
        {
            try
            {
                System.Media.SoundPlayer player = new SoundPlayer();
                player.SoundLocation = System.Windows.Forms.Application.StartupPath + "\\" + strWaveName;
                player.Load();
                player.PlaySync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


       
        /// <summary>
        /// 当前状态
        /// </summary>
        /// <param name="theTextBox"></param>
        /// <param name="theValue"></param>
        private static void refresh_Textbox_Light(Panel panel, long theValue)
        {
            try
            {

                if (theValue == 1)
                {
                    panel.BackColor = Color.LightGreen;
                }
                else
                {
                    panel.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 紧停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            //MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            //DialogResult dr = MessageBox.Show(craneNO + " 确定要紧停吗？", "操作提示", btn);
            //if (dr == DialogResult.OK)
            //{
               
            //}        
            SendShortCmd(craneNO, CraneStatusBase.SHORT_CMD_EMG_STOP);
            UACSUtility.HMILogger.WriteLog(btnStop.Text, "紧停,行车：" + craneNO, UACSUtility.LogLevel.Warn, this.Text);
        }


        /// <summary>
        /// 行车指令显示
        /// </summary>
        /// <param name="craneNo"></param>
        private void lblTextByCraneNo(string craneNo)
        {
            bool isValue = false;
            try
            {

                string sql = string.Format("SELECT * FROM UACS_CRANE_ORDER_CURRENT WHERE CRANE_NO = '{0}' ", craneNO);

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {

                        //指令号
                        if (rdr["ORDER_NO"] != System.DBNull.Value)
                        {

                            txt_CraneOrder.Text = rdr["ORDER_NO"].ToString();
                        }
                        else
                            txt_CraneOrder.Text = "";


                        //材料号
                        if (rdr["MAT_NO"] != System.DBNull.Value)
                        {

                            txt_CoilNo.Text = rdr["MAT_NO"].ToString();
                        }
                        else
                            txt_CoilNo.Text = numberIsNull;

                        //起卷库位
                        if (rdr["FROM_STOCK_NO"] != System.DBNull.Value)
                        {
                            txt_FromStock.Text = rdr["FROM_STOCK_NO"].ToString();
                        }
                        else
                            txt_FromStock.Text = numberIsNull;

                        //落下库位
                        if (rdr["TO_STOCK_NO"] != System.DBNull.Value)
                        {
                            txt_ToStock.Text = rdr["TO_STOCK_NO"].ToString();
                        }
                        else
                            txt_ToStock.Text = numberIsNull;

                        isValue = true;
                    }
                }
            }
            catch (Exception er)
            {

                //throw;
            }
            finally
            {
                if (!isValue)
                {
                     txt_CraneOrder.Text = "";
                     txt_CoilNo.Text = numberIsNull;
                     txt_FromStock.Text = numberIsNull;
                     txt_ToStock.Text = numberIsNull;
                }
            }
        }

        private int getMatLFlag(string matNO)
        {
            int ret = 0;
            try
            {

                string sql = string.Format(@"SELECT A.LOGISTICS_FLAG FROM UACS_LOGISTICS_CONFIG A 
                LEFT JOIN UACS_PLAN_IN_DETAIL B ON A.HAVEN_CNAME = B.HAVEN_CNAME
                WHERE B.MAT_NO = '{0}'", matNO);

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["LOGISTICS_FLAG"] != System.DBNull.Value)
                        {
                            ret = Convert.ToInt32(rdr["LOGISTICS_FLAG"]);
                        }
                        else
                            ret = 0;
                         
                    }
                }
            }
            catch (Exception er)
            {

            }
            finally
            {

            }
            return ret;
        }

        /// <summary>
        /// 模式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMode_Click(object sender, EventArgs e)
        {
            if (frmModeSwitchover == null || frmModeSwitchover.IsDisposed)
            {
                frmModeSwitchover = new FrmModeSwitchover();
                frmModeSwitchover.Crane_No = craneNO;
                frmModeSwitchover.TagServiceName = TagServiceName;
                frmModeSwitchover.Show();
            }
            else
            {
                frmModeSwitchover.WindowState = FormWindowState.Normal;
                frmModeSwitchover.Activate();
            }

           
        }


        /// <summary>
        /// 模式切换
        /// </summary>
        /// <param name="theCraneNO">行车号</param>
        /// <param name="cmdFlag">对应模式切换数值</param>
        private void SendShortCmd(string theCraneNO, long cmdFlag)
        {
            try
            {
                string messageBuffer = string.Empty;

                messageBuffer = theCraneNO + "," + cmdFlag.ToString();

                Baosight.iSuperframe.TagService.DataCollection<object> wirteDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                wirteDatas[theCraneNO + "_DownLoadShortCommand"] = messageBuffer;
                tagDataProvider.SetData(theCraneNO + "_DownLoadShortCommand", messageBuffer);

            }
            catch (Exception ex)
            {
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            PopAlarmCurrent popAlarm = new PopAlarmCurrent();
            popAlarm.Crane_No = craneNO;
            popAlarm.ShowDialog();
        }

        private void txt_CoilNo_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string matNO = txt.Text.Trim();
            int temp = getMatLFlag(matNO);

            //2019-03-06 加流向显示

            switch(temp)
            {
                case 1:
                    label2.ForeColor = Color.LightGreen;
                    break;
                case 2:
                    label2.ForeColor = Color.Pink;
                    break;
                case 3:
                    label2.ForeColor = Color.Orange;
                    break;
                case 4:
                    label2.ForeColor = Color.Peru;
                    break;
                default:
                    label2.ForeColor = Color.Black;
                    break;

            }


        }

       

    }

    public delegate void PlaySoundHandler(object sender, SoundEvtAgs e);
    public delegate void PlaySoundDelegate(string fileName);
    public class SoundEvtAgs : System.EventArgs
    {
        private string fileName;
        public string FileName
        {
            set { fileName = value; }
            get { return fileName; }
        }
    }
}
