using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.MsgService.Interface;

using MODULES_OF_PREMIERE;

namespace CONTROLS_OF_PREMIERE
{
    public partial class PopCranePLCOrderSetting : Form
    {
        public PopCranePLCOrderSetting()
        {
            InitializeComponent();
        }



        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;

        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }

                }
                return dbHelper;
            }
        }




        public const string MESSAGE_NO_PLC_ORDER = "HMICRANE02";


        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        //step 1
        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {
            }
        }

        private string craneNO = string.Empty;
        //setp 2
        public string CraneNO
        {
            get { return craneNO; }
            set { craneNO = value; }
        }



        private void PopCranePLCOrderSetting_Shown(object sender, EventArgs e)
        {
            try
            {
                txt_CRANE_NO.Text = craneNO;
                radiobtn3.Checked = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdDownLoadPlan_Click(object sender, EventArgs e)
        {
            try
            {
                //FrmPassword frm = new FrmPassword();
                //frm.ShowDialog();
                //if (!frm.isAllow)
                //{
                //    return;
                //}
                DialogResult ret = MessageBox.Show("确认下达指令", "确认下达指令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ret == DialogResult.OK)
                {
                    bool retSendPLCOrder = SendPLCOrder( MESSAGE_NO_PLC_ORDER,craneNO);
                    if (retSendPLCOrder == true)
                    {
                        //MessageBox.Show("指令下达成功", "指令下达成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("指令下达失败", "指令下达失败", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }




        private bool SendPLCOrder(string theMessageNO, string theCraneNO)
        {
            bool ret = true;
            try
            {



                    //2 orderID
                    long orderID = Convert.ToInt64(txt_ORDER_Id.Text);
                    //3 planUpX
                    long planUpX = Convert.ToInt64(txt_PLAN_UP_X.Text);
                    //4 planUpY
                    long planUpY = Convert.ToInt64(txt_PLAN_UP_Y.Text);
                    //5 planUpZ
                    long planUpZ = Convert.ToInt64(txt_PLAN_UP_Z.Text);
                    //6 UP_ROTATE_ANGLE_SET
                    long upRotateAngleSet = Convert.ToInt64(txt_UP_ROTATE_ANGLE_SET.Text);
                    //7 CLAMP_WIDTH_SET
                    long clampWidthSet = Convert.ToInt64(txt_CLAMP_WIDTH_SET.Text);
                    //8 planDownX
                    long planDownX = Convert.ToInt64(txt_PLAN_DOWN_X.Text);
                    //9 planDownY
                    long planDownY = Convert.ToInt64(txt_PLAN_DOWN_Y.Text);
                    //10 planDownZ
                    long planDownZ = Convert.ToInt64(txt_PLAN_DOWN_Z.Text);
                    //11 DOWN_ROTATE_ANGLE_SET
                    long downRotateAngleSet = Convert.ToInt64(txt_DOWN_ROTATE_ANGLE_SET.Text);
                    //12 coilWidth
                    long coilWidth = Convert.ToInt64(txt_COIL_WIDTH.Text);
                    //13 COIL_WEIGHT
                    long coilWeight = Convert.ToInt64(txt_COIL_WEIGHT.Text);
                    //14 coilOutDia
                    long coilOutDia = Convert.ToInt64(txt_COIL_OUT_DIA.Text);
                    //15 coilInDIa
                    long coilInDia = Convert.ToInt64(txt_COIL_IN_DIA.Text);
                    //16 FloorUpZ
                    long floorUpZ = Convert.ToInt64(txtFloorUpZ.Text);
                    //17 FlagSmallCoil
                    long flagSmallCoil = Convert.ToInt64(txtFlagSmallCoil.Text);
                    //18 FloorDownZ
                    long flagDownZ = Convert.ToInt64(txtFloorDownZ.Text);
                    if (floorUpZ >= 0 && floorUpZ <= 3000)
                    {
                    }
                    else
                    {
                        MessageBox.Show("floorUpZ 数据不合法");
                        return false;
                    }
                    if (flagSmallCoil == 0 || flagSmallCoil == 1)
                    {
                    }
                    else
                    {
                        MessageBox.Show("flagSmallCoil 数据不合法");
                        return false;
                    }
                    if (flagDownZ >= 0 && flagDownZ <= 3000)
                    {
                    }
                    else
                    {
                        MessageBox.Show("flagDownZ 数据不合法");
                        return false;
                    }

                    string messageBuffer = string.Empty;
                    //1
                    messageBuffer = theCraneNO.ToString() + ",";
                    //2
                    messageBuffer += orderID.ToString() + ",";
                    //3
                    messageBuffer += planUpX.ToString() + ",";
                    //4
                    messageBuffer += planUpY.ToString() + ",";
                    //5
                    messageBuffer += planUpZ.ToString() + ",";
                    //6
                    messageBuffer += upRotateAngleSet.ToString() + ",";
                    //7
                    messageBuffer += clampWidthSet.ToString() + ",";
                    //8
                    messageBuffer += planDownX.ToString() + ",";
                    //9
                    messageBuffer += planDownY.ToString() + ",";
                    //10
                    messageBuffer += planDownZ.ToString() + ",";
                    //11
                    messageBuffer += downRotateAngleSet.ToString() + ",";
                    //12
                    messageBuffer += coilWidth.ToString() + ",";
                    //13
                    messageBuffer += coilWeight.ToString() + ",";
                    //14
                    messageBuffer += coilOutDia.ToString() + ","; ;
                    //15
                    messageBuffer += coilInDia.ToString() + ",";
                    //16
                    messageBuffer += floorUpZ.ToString() + ",";
                    //17
                    messageBuffer += flagSmallCoil.ToString() + ",";
                    //18
                    messageBuffer += flagDownZ.ToString();

                    //if you will need use InvokeP99 release these codes
                    //string objectName = theCraneNO;


                    //XComMessage0 xComMessage0 = new XComMessage0();
                    //xComMessage0.Lineno = 0;
                    //xComMessage0.TextLenth = 0;
                    //xComMessage0.MessageNO = theMessageNO;
                    //xComMessage0.TextBuf = messageBuffer;

                    //InvokeP99(objectName, xComMessage0.Code2Bytes());

                    Baosight.iSuperframe.TagService.DataCollection<object> wirteDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                    wirteDatas[theCraneNO + "_DownLoadOrder"] = messageBuffer;
                    tagDataProvider.SetData(theCraneNO + "_DownLoadOrder", messageBuffer);
                    UACSUtility.HMILogger.WriteLog(cmdDownLoadPlan.Text, "下载PLC指令 ， 行车号：" + craneNO + "，内容：" + messageBuffer, UACSUtility.LogLevel.Info, this.Text);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
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

        private void radiobtn1_CheckedChanged(object sender, EventArgs e)
        {
            if(radiobtn1.Checked == true)
            {
                txt_PLAN_UP_X.Text = "999999";
                txt_PLAN_UP_X.Enabled = false;
                txt_PLAN_DOWN_X.Text = "999999";
                txt_PLAN_DOWN_X.Enabled = false;
            }
            else
            {
                txt_PLAN_UP_X.Enabled = true;
                txt_PLAN_DOWN_X.Enabled = true;
            }
        }

        private void radiobtn2_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtn2.Checked == true)
            {
                txt_PLAN_UP_Y.Text = "999999";
                txt_PLAN_UP_Y.Enabled = false;
                txt_PLAN_DOWN_Y.Text = "999999";
                txt_PLAN_DOWN_Y.Enabled = false;
            }
            else
            {
                txt_PLAN_UP_Y.Enabled = true;
                txt_PLAN_DOWN_Y.Enabled = true;
            }

        }

        private void radiobtn3_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtn2.Checked == true)
            {
                txt_PLAN_UP_X.Enabled = true;
                txt_PLAN_DOWN_X.Enabled = true;
                txt_PLAN_UP_Y.Enabled = true;
                txt_PLAN_DOWN_Y.Enabled = true;
            }

        }
    }
}
