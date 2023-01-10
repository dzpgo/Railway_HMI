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
    public partial class PopCraneComputerOrderSetting : Form
    {
        public PopCraneComputerOrderSetting()
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
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ2030");
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }

                }
                return dbHelper;
            }
        }



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

        private void PopCraneComputerOrderSetting_Shown(object sender, EventArgs e)
        {
            try
            {
                txt_CRANE_NO.Text = craneNO;

                prepareActionControlList();

                prepareTagAddressList();

                timer.Interval = 1500;
                timer.Enabled = true;

                try
                {
                    cmdD202Exit_Z33.Visible = false;
                    cmdD202Exit_Z32.Visible = false;
                    //if (craneNO == "4_4")
                    //{
                    //    cmdD202Exit_Z33.Visible = true;
                    //}
                    //if (craneNO == "4_1")
                    //{
                    //    cmdD202Exit_Z32.Visible = true;
                    //}

                    cmdReadOrderCurrent_Click(null, null);
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }



        private void cmdCreateComputerOrder_Click(object sender, EventArgs e)
        {
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

                //15 coilInDia
                long coilInDia = Convert.ToInt64(txt_COIL_IN_DIA.Text);

                //16 floorUpZ
                long floorUpZ = Convert.ToInt64(txtFloorUpZ.Text);

                //17 flagSmallCoil
                long flagSmallCoil = Convert.ToInt64(txtFlagSmallCoil.Text);

                //18 floorDownZ
                long floorDownZ = Convert.ToInt64(txtFloorDownZ.Text);

                string bayNO = txt_BayNO.Text.ToString().Trim();

                string matNO = txt_MatNO.Text.ToString().Trim();

                string fromStockNO = txt_FromStock.Text.ToString().Trim();

                string toStockNO = txt_ToStock.Text.ToString().Trim();


                string strSql = " Update UACS_CRANE_ORDER_CURRENT set ";

                strSql += " ORDER_NO=" + orderID + ",";

                strSql += " BAY_NO=" + "'" + bayNO + "'" + ",";

                strSql += " MAT_NO=" + "'" + matNO + "'" + ",";

                strSql += " FROM_STOCK_NO=" + "'" + fromStockNO + "'" + ",";

                strSql += " TO_STOCK_NO=" + "'" + toStockNO + "'" + ",";

                strSql += " PLAN_UP_X=" + planUpX + ",";

                strSql += " PLAN_UP_Y=" + planUpY + ",";

                strSql += " PLAN_UP_Z=" + planUpZ + ",";

                strSql += " UP_ROTATE_ANGLE_SET=" + upRotateAngleSet + ",";

                strSql += " CLAMP_WIDTH_SET=" + clampWidthSet + ",";

                strSql += " PLAN_DOWN_X=" + planDownX + ",";

                strSql += " PLAN_DOWN_Y=" + planDownY + ",";

                strSql += " PLAN_DOWN_Z=" + planDownZ + ",";

                strSql += " DOWN_ROTATE_ANGLESET=" + downRotateAngleSet + ",";

                strSql += " COIL_WIDTH=" + coilWidth + ",";

                strSql += " COIL_WEIGHT=" + coilWeight + ",";

                strSql += " COIL_OUT_DIA=" + coilOutDia + ",";

                strSql += " COIL_IN_DIA=" + coilInDia + ",";

                strSql += " FLOOR_UP_Z=" + floorUpZ + ",";

                strSql += " FLAG_SMALL_COIL=" + flagSmallCoil + ",";

                strSql += " FLOOR_DOWN_Z=" + floorDownZ + ",";


                strSql += " CMD_STATUS=" + "'" + "ORDER_INIT" + "'";

                strSql += " where CRANE_NO=" + "'" + craneNO + "'";

                DBHelper.ExecuteNonQuery(strSql);

                MessageBox.Show("指令已经写入系统", "指令已经写入系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //UACSUtility.HMILogger.WriteLog(cmdCreateComputerOrder.Text, "指令写入系统，行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("指令写入系统失败"+ex.Message , "指令写入系统失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdExcuteComputerOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //Baosight.iSuperframe.TagService.DataCollection<object> wirteDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                //wirteDatas[craneNO + "_TestRunCraneOrder"] = "1";
                //tagDataProvider.SetData(craneNO + "_TestRunCraneOrder", "1");

                //MessageBox.Show("行车计算机点动开关已经打开", "行车计算机点动开关已经打开", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult ret = MessageBox.Show("确认放开指令并启动行车", "确认放开指令并启动行车", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (ret == DialogResult.Cancel)
                {
                    return;
                }

                string strSql = " Update UACS_CRANE_ORDER_CURRENT set ";

                strSql += " CMD_STATUS=" + "'" + "COIL_UP_PROCESS" + "'";

                strSql += " where CRANE_NO=" + "'" + craneNO + "'";

                DBHelper.ExecuteNonQuery(strSql);

                //UACSUtility.HMILogger.WriteLog(cmdExcuteComputerOrder.Text, "确认放开指令并启动行车 ， 行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);

            }
            catch (Exception ex)
            {
            }
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCalUpZDownZ_Click(object sender, EventArgs e)
        {
            try
            {
                long outDia = Convert.ToInt64(txt_COIL_OUT_DIA.Text);
                if (outDia >= 2200)
                {
                    MessageBox.Show("直径大于2000上限", "直径大于2000上限",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (outDia <= 500)
                {
                    MessageBox.Show("直径小于于500下限", "直径小于于500下限",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                long upZ = outDia / 2 - 63;
                txt_PLAN_UP_Z.Text = upZ.ToString();

                long downZ = outDia / 2 + 100;
                txt_PLAN_DOWN_Z.Text = downZ.ToString();

            }
            catch (Exception ex)
            {
            }
        }

        private void cmdCalUpClampWidthSet_Click(object sender, EventArgs e)
        {
            try
            {
                long coilWidth = Convert.ToInt64(txt_COIL_WIDTH.Text);
                //if (coilWidth >= 1400)
                //{
                //    MessageBox.Show("钢卷宽度大于1400上限", "钢卷宽度大于1400上限", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (coilWidth >= 1900)
                {
                    MessageBox.Show("钢卷宽度大于1900上限", "钢卷宽度大于1900上限", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (coilWidth <= 500)
                {
                    MessageBox.Show("钢卷宽度小于于500下限", "钢卷宽度小于于500下限", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                long upClampWidthSet = coilWidth + 400;
                txt_CLAMP_WIDTH_SET.Text = upClampWidthSet.ToString();

               
            }
            catch (Exception ex)
            {
            }
        }
        string PLC_INT_NULL = "999999";

        private void cmdClearDataItems_Click(object sender, EventArgs e)
        {
            try
            {
                txt_ORDER_Id.Text = PLC_INT_NULL;
                txt_PLAN_UP_X.Text = PLC_INT_NULL;
                txt_PLAN_UP_Y.Text = PLC_INT_NULL;
                txt_PLAN_UP_Z.Text = PLC_INT_NULL;
                txt_UP_ROTATE_ANGLE_SET.Text = PLC_INT_NULL;
                txt_CLAMP_WIDTH_SET.Text = PLC_INT_NULL;
                txt_PLAN_DOWN_X.Text = PLC_INT_NULL;
                txt_PLAN_DOWN_Y.Text = PLC_INT_NULL;
                txt_PLAN_DOWN_Z.Text = PLC_INT_NULL;
                txt_DOWN_ROTATE_ANGLE_SET.Text = PLC_INT_NULL;
                txt_COIL_WIDTH.Text = PLC_INT_NULL;
                txt_COIL_WEIGHT.Text = PLC_INT_NULL;
                txt_COIL_OUT_DIA.Text = PLC_INT_NULL;
                txt_BayNO.Text = PLC_INT_NULL;
                txt_MatNO.Text = PLC_INT_NULL;
                txt_FromStock.Text = PLC_INT_NULL;
                txt_ToStock.Text = PLC_INT_NULL;
                txt_COIL_IN_DIA.Text = PLC_INT_NULL;
                txtFloorUpZ.Text = Convert.ToString(0);
                txtFlagSmallCoil.Text = Convert.ToString(0);
                txtFloorDownZ.Text = Convert.ToString(0);



                string strSql = " Update UACS_CRANE_ORDER_CURRENT set ";

                strSql += " ORDER_NO=NULL"  + ",";

                strSql += " BAY_NO=NULL" + ",";

                strSql += " MAT_NO=NULL"  + ",";

                strSql += " FROM_STOCK_NO=NULL"  + ",";

                strSql += " TO_STOCK_NO=NULL"  + ",";

                strSql += " PLAN_UP_X=NULL"  + ",";

                strSql += " PLAN_UP_Y=NULL"  + ",";

                strSql += " PLAN_UP_Z=NULL"  + ",";

                strSql += " UP_ROTATE_ANGLE_SET=NULL"  + ",";

                strSql += " CLAMP_WIDTH_SET=NULL"  + ",";

                strSql += " PLAN_DOWN_X=NULL"  + ",";

                strSql += " PLAN_DOWN_Y=NULL"  + ",";

                strSql += " PLAN_DOWN_Z=NULL"  + ",";

                strSql += " DOWN_ROTATE_ANGLESET=NULL"  + ",";

                strSql += " COIL_WIDTH=NULL"  + ",";

                strSql += " COIL_WEIGHT=NULL"  + ",";

                strSql += " COIL_OUT_DIA=NULL"  + ",";

                strSql += " COIL_IN_DIA=NULL"  + ",";

                strSql += " FLOOR_UP_Z=NULL" + ",";

                strSql += " FLAG_SMALL_COIL=NULL" + ",";

                strSql += " FLOOR_DOWN_Z=NULL" + ",";

                strSql += " CMD_STATUS=" + "'" + "EMPTY" + "'";

                strSql += " where CRANE_NO=" + "'" + craneNO + "'";

                DBHelper.ExecuteNonQuery(strSql);

                MessageBox.Show("行车指令已经清空", "行车指令已经清空", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //UACSUtility.HMILogger.WriteLog(cmdClearDataItems.Text, "行车指令已经清空 ， 行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);






            }
            catch (Exception ex)
            {
            }
        }



        public bool getStockXY(string stockNO, ref long stockX, ref long stockY)
        {
            bool ret = false;
            try
            {
                // string sqlText = "SELECT * FROM UACS_YARDMAP_SADDLE_DEFINE WHERE SADDLE_NO=" + "'" + stockNO + "'";
                string sqlText =string.Format("SELECT * FROM  UACS_YARDMAP_SADDLE_DEFINE  JOIN  UACS_YARDMAP_SADDLE_STOCK ON   UACS_YARDMAP_SADDLE_DEFINE.SADDLE_NO=UACS_YARDMAP_SADDLE_STOCK.SADDLE_NO  where   UACS_YARDMAP_SADDLE_STOCK.STOCK_NO = '{0}' ", stockNO);
                stockX = Convert.ToInt32(PLC_INT_NULL);
                stockY = Convert.ToInt32(PLC_INT_NULL);

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {

                        if (rdr["X_CENTER"] != System.DBNull.Value) { stockX = Convert.ToInt32(rdr["X_CENTER"]); }
                        if (rdr["Y_CENTER"] != System.DBNull.Value) { stockY = Convert.ToInt32(rdr["Y_CENTER"]); }
                        ret = true;

                    }

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Refresh_CranePlan"+ex.Message);
            }

            return ret;

        }

        public bool getSaddleXY(string stockNO, ref long saddleX, ref long saddleY)
        {
            bool ret = false;
            try
            {
                string sqlText = "select c.X_CENTER X_CENTER ,c.Y_CENTER Y_CENTER from UACS_YARDMAP_STOCK_DEFINE a, UACS_YARDMAP_SADDLE_STOCK b, UACS_YARDMAP_SADDLE_DEFINE c where a.STOCK_NO = b.STOCK_NO and b.SADDLE_NO = c.SADDLE_NO and  a.STOCK_NO=" + "'" + stockNO + "'";
                saddleX = Convert.ToInt32(PLC_INT_NULL);
                saddleY = Convert.ToInt32(PLC_INT_NULL);

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {

                        if (rdr["X_CENTER"] != System.DBNull.Value) { saddleX = Convert.ToInt32(rdr["X_CENTER"]); }
                        if (rdr["Y_CENTER"] != System.DBNull.Value) { saddleY = Convert.ToInt32(rdr["Y_CENTER"]); }
                        ret = true;

                    }

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Refresh_CranePlan"+ex.Message);
            }

            return ret;

        }

        private void cmdCalFrmXY_Click(object sender, EventArgs e)
        {
            try
            {
                long upX=Convert.ToInt32(PLC_INT_NULL);
                long upY=Convert.ToInt32(PLC_INT_NULL);
                string fromStockNO=txt_FromStock.Text .ToString().Trim();
                if(fromStockNO==string.Empty)
                {
                    MessageBox.Show("起吊Stock为空", "起吊Stock为空", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                getStockXY(fromStockNO, ref upX, ref upY);
                txt_PLAN_UP_X.Text = upX.ToString();
                txt_PLAN_UP_Y.Text = upY.ToString();

            }
            catch (Exception ex)
            {
            }
        }

        private void cmdCalDownXY_Click(object sender, EventArgs e)
        {
            try
            {
                long downX = Convert.ToInt32(PLC_INT_NULL);
                long downY = Convert.ToInt32(PLC_INT_NULL);
                string toStockNO = txt_ToStock.Text.ToString().Trim();
                if (toStockNO == string.Empty)
                {
                    MessageBox.Show("落关Stock为空", "StockStock为空", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                getSaddleXY(toStockNO, ref downX, ref downY);
                txt_PLAN_DOWN_X.Text = downX.ToString();
                txt_PLAN_DOWN_Y.Text = downY.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdReadOrderCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlText = "SELECT * FROM UACS_CRANE_ORDER_CURRENT WHERE CRANE_NO=" + "'" + craneNO + "'";
 
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {

                        if (rdr["ORDER_NO"] != System.DBNull.Value)
                        {
                            txt_ORDER_Id.Text = Convert.ToString(rdr["ORDER_NO"]);
                        }
                        else
                        {
                            txt_ORDER_Id.Text = PLC_INT_NULL;
                        }

                        if (rdr["BAY_NO"] != System.DBNull.Value)
                        {
                            txt_BayNO.Text = Convert.ToString(rdr["BAY_NO"]);
                        }
                        else
                        {
                            txt_BayNO.Text = PLC_INT_NULL;
                        }

                        if (rdr["MAT_NO"] != System.DBNull.Value)
                        {
                            txt_MatNO.Text = Convert.ToString(rdr["MAT_NO"]);
                        }
                        else
                        {
                            txt_MatNO.Text = PLC_INT_NULL;
                        }

                        if (rdr["FROM_STOCK_NO"] != System.DBNull.Value)
                        {
                            txt_FromStock.Text = Convert.ToString(rdr["FROM_STOCK_NO"]);
                        }
                        else
                        {
                            txt_FromStock.Text = PLC_INT_NULL;
                        }

                        if (rdr["TO_STOCK_NO"] != System.DBNull.Value)
                        {
                            txt_ToStock.Text = Convert.ToString(rdr["TO_STOCK_NO"]);
                        }
                        else
                        {
                            txt_ToStock.Text = PLC_INT_NULL;
                        }

                        if (rdr["PLAN_UP_X"] != System.DBNull.Value)
                        {
                            txt_PLAN_UP_X.Text = Convert.ToString(rdr["PLAN_UP_X"]);
                        }
                        else
                        {
                            txt_PLAN_UP_X.Text = PLC_INT_NULL;
                        }

                        if (rdr["PLAN_UP_Y"] != System.DBNull.Value)
                        {
                            txt_PLAN_UP_Y.Text = Convert.ToString(rdr["PLAN_UP_Y"]);
                        }
                        else
                        {
                            txt_PLAN_UP_Y.Text = PLC_INT_NULL;
                        }

                        if (rdr["PLAN_UP_Z"] != System.DBNull.Value)
                        {
                            txt_PLAN_UP_Z.Text = Convert.ToString(rdr["PLAN_UP_Z"]);
                        }
                        else
                        {
                            txt_PLAN_UP_Z.Text = PLC_INT_NULL;
                        }

                        if (rdr["UP_ROTATE_ANGLE_SET"] != System.DBNull.Value)
                        {
                            txt_UP_ROTATE_ANGLE_SET.Text = Convert.ToString(rdr["UP_ROTATE_ANGLE_SET"]);
                        }
                        else
                        {
                            txt_UP_ROTATE_ANGLE_SET.Text = PLC_INT_NULL;
                        }

                        if (rdr["CLAMP_WIDTH_SET"] != System.DBNull.Value)
                        {
                            txt_CLAMP_WIDTH_SET.Text = Convert.ToString(rdr["CLAMP_WIDTH_SET"]);
                        }
                        else
                        {
                            txt_CLAMP_WIDTH_SET.Text = PLC_INT_NULL;
                        }

                        if (rdr["PLAN_DOWN_X"] != System.DBNull.Value)
                        {
                            txt_PLAN_DOWN_X.Text = Convert.ToString(rdr["PLAN_DOWN_X"]);
                        }
                        else
                        {
                            txt_PLAN_DOWN_X.Text = PLC_INT_NULL;
                        }

                        if (rdr["PLAN_DOWN_Y"] != System.DBNull.Value)
                        {
                            txt_PLAN_DOWN_Y.Text = Convert.ToString(rdr["PLAN_DOWN_Y"]);
                        }
                        else
                        {
                            txt_PLAN_DOWN_Y.Text = PLC_INT_NULL;
                        }

                        if (rdr["PLAN_DOWN_Z"] != System.DBNull.Value)
                        {
                            txt_PLAN_DOWN_Z.Text = Convert.ToString(rdr["PLAN_DOWN_Z"]);
                        }
                        else
                        {
                            txt_PLAN_DOWN_Z.Text = PLC_INT_NULL;
                        }

                        if (rdr["DOWN_ROTATE_ANGLESET"] != System.DBNull.Value)
                        {
                            txt_DOWN_ROTATE_ANGLE_SET.Text = Convert.ToString(rdr["DOWN_ROTATE_ANGLESET"]);
                        }
                        else
                        {
                            txt_DOWN_ROTATE_ANGLE_SET.Text = PLC_INT_NULL;
                        }

                        if (rdr["COIL_WIDTH"] != System.DBNull.Value)
                        {
                            txt_COIL_WIDTH.Text = Convert.ToString(rdr["COIL_WIDTH"]);
                        }
                        else
                        {
                            txt_COIL_WIDTH.Text = PLC_INT_NULL;
                        }

                        if (rdr["COIL_WEIGHT"] != System.DBNull.Value)
                        {
                            txt_COIL_WEIGHT.Text = Convert.ToString(rdr["COIL_WEIGHT"]);
                        }
                        else
                        {
                            txt_COIL_WEIGHT.Text = PLC_INT_NULL;
                        }

                        if (rdr["COIL_OUT_DIA"] != System.DBNull.Value)
                        {
                            txt_COIL_OUT_DIA.Text = Convert.ToString(rdr["COIL_OUT_DIA"]);
                        }
                        else
                        {
                            txt_COIL_OUT_DIA.Text = PLC_INT_NULL;
                        }

                        if (rdr["COIL_IN_DIA"] != System.DBNull.Value)
                        {
                            txt_COIL_IN_DIA.Text = Convert.ToString(rdr["COIL_IN_DIA"]);
                        }
                        else
                        {
                            txt_COIL_IN_DIA.Text = PLC_INT_NULL;
                        }

                        if (rdr["CMD_STATUS"] != System.DBNull.Value)
                        {
                            txt_cmdStatus.Text = Convert.ToString(rdr["CMD_STATUS"]);
                        }
                        else
                        {
                            txt_cmdStatus.Text = PLC_INT_NULL;
                        }


                        if (rdr["FLOOR_UP_Z"] != System.DBNull.Value)
                        {
                            txtFloorUpZ.Text = Convert.ToString(rdr["FLOOR_UP_Z"]);
                        }
                        else
                        {
                            txtFloorUpZ.Text = "0";
                        }

                        if (rdr["FLAG_SMALL_COIL"] != System.DBNull.Value)
                        {
                            txtFlagSmallCoil.Text = Convert.ToString(rdr["FLAG_SMALL_COIL"]);
                        }
                        else
                        {
                            txtFlagSmallCoil.Text = "0";
                        }

                        if (rdr["FLOOR_DOWN_Z"] != System.DBNull.Value)
                        {
                            txtFloorDownZ.Text = Convert.ToString(rdr["FLOOR_DOWN_Z"]);
                        }
                        else
                        {
                            txtFloorDownZ.Text = "0";
                        }


                    }

                }
               // UACSUtility.HMILogger.WriteLog(cmdReadOrderCurrent.Text, "刷新指令，行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);
            }
            catch (Exception ex)
            {
            }
        }


/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>

        List<TextBox> lstActionName = new List<TextBox>();
        List<TextBox> lstActionLight = new List<TextBox>();


        // call it in the formLoad
        private void prepareActionControlList()
        {
            try
            {
                lstActionName.Clear();
                lstActionLight.Clear();

                lstActionName.Add(txt_Action_0);
                lstActionName.Add(txt_Action_1);
                lstActionName.Add(txt_Action_2);
                lstActionName.Add(txt_Action_3);
                lstActionName.Add(txt_Action_4);
                lstActionName.Add(txt_Action_5);
                lstActionName.Add(txt_Action_6);
                lstActionName.Add(txt_Action_7);
                lstActionName.Add(txt_Action_8);
                lstActionName.Add(txt_Action_9);
                lstActionName.Add(txt_Action_10);
                lstActionName.Add(txt_Action_11);

                lstActionLight.Add(light__Action_0);
                lstActionLight.Add(light__Action_1);
                lstActionLight.Add(light__Action_2);
                lstActionLight.Add(light__Action_3);
                lstActionLight.Add(light__Action_4);
                lstActionLight.Add(light__Action_5);
                lstActionLight.Add(light__Action_6);
                lstActionLight.Add(light__Action_7);
                lstActionLight.Add(light__Action_8);
                lstActionLight.Add(light__Action_9);
                lstActionLight.Add(light__Action_10);
                lstActionLight.Add(light__Action_11);

            }
            catch (Exception ex)
            {
            }
        }



        private List<string> lstTagAdressList = new List<string>();

        // call it in the formLoad
        private void prepareTagAddressList()
        {
            try
            {
                lstTagAdressList.Clear();
                lstTagAdressList.Add(craneNO + "_ACTIONS_LIST");
                lstTagAdressList.Add( craneNO+"_ACTIONS_SUCCESSED" );
                lstTagAdressList.Add(craneNO+"_ACTIONS_STOP_RESULT" );
            }
            catch (Exception ex)
            {
            }
        }


        //private function
        private void readTag(ref string valueActions, ref string valueActionsSucced, ref string valueActionStopReslut)
        {
            try
            {
                string[] arrTagAdress = lstTagAdressList.ToArray();

                Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();

                tagDataProvider.GetData(arrTagAdress, out inDatas);

                valueActions = get_value(craneNO + "_ACTIONS_LIST", inDatas);

                valueActionsSucced = get_value(craneNO + "_ACTIONS_SUCCESSED", inDatas);

                valueActionStopReslut = get_value(craneNO + "_ACTIONS_STOP_RESULT", inDatas);
            }
            catch (Exception ex)
            {
            }
        }

        //private function
        private string get_value(string tagName, Baosight.iSuperframe.TagService.DataCollection<object> inDatas)
        {
            string theValue = string.Empty;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToString(valueObject);
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }


        //private function
        private void deCode_ActionsLit(string valueActions)
        {
            try
            {
                string[] temp= valueActions.Split(',');
                lstActions_AfterDecode = temp.ToList();
            }
            catch (Exception ex)
            {
            }
        }

        //private function
        private void deCode_ActionsSuccessedList(string valueActionsSuccessed)
        {
            try
            {
                string[] temp = valueActionsSuccessed.Split(',');
                lstActionsSuccessed_AfterDecode=temp.ToList(); 
            }
            catch (Exception ex)
            {
            }
        }


        string valueActions = string.Empty;
        string valueActionsSucced = string.Empty;
        string valueActionStopReslut = string.Empty;

        List<string> lstActions_AfterDecode = new List<string>();
        List<string> lstActionsSuccessed_AfterDecode = new List<string>();

        private void refreshActionInfo()
        {
            try
            {
                foreach (TextBox textBox in lstActionName)
                {
                    textBox.Text = string.Empty;
                }
                foreach (TextBox textBox in lstActionLight)
                {
                    textBox.BackColor = Color.White;
                }

                readTag(ref valueActions, ref valueActionsSucced, ref valueActionStopReslut);

                deCode_ActionsLit(valueActions);

                deCode_ActionsSuccessedList(valueActionsSucced);

                for (int i = 0; i < lstActions_AfterDecode.Count; i++)
                {
                    if(i<12){lstActionName[i].Text = lstActions_AfterDecode[i];}
                }

                for(int i=0; i<lstActionsSuccessed_AfterDecode.Count ; i++)
                {
                    if(i<12)
                    {
                        if(lstActions_AfterDecode[i]==lstActionsSuccessed_AfterDecode[i])
                        {
                            lstActionLight[i].BackColor=Color.LightGreen;
                        }
                        else
                        {
                            lstActionLight[i].BackColor=Color.White;
                        }
                    }
                }

                txt_StopReason.Text = valueActionStopReslut;

            }
            catch (Exception ex)
            {
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                refreshActionInfo();
            }
            catch (Exception ex)
            {
            }
        }

        //select coil from D202 Exit in Bay Z33-1
        private void cmdD202Exit_Z33_Click(object sender, EventArgs e)
        {
            try
            {
                PopD202Exit_CoilSelector popD202Exit_CoilSelector = new PopD202Exit_CoilSelector();
                popD202Exit_CoilSelector.UnitNO = "D202";
                popD202Exit_CoilSelector.BayNO = "Z33-1";
                DialogResult ret = popD202Exit_CoilSelector.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    txt_MatNO.Text = popD202Exit_CoilSelector.CoilNO;
                    if (popD202Exit_CoilSelector.CoilWidth != 0) { txt_COIL_WIDTH.Text = popD202Exit_CoilSelector.CoilWidth.ToString(); }
                    if (popD202Exit_CoilSelector.Weight != 0) { txt_COIL_WEIGHT.Text = popD202Exit_CoilSelector.Weight.ToString(); }
                    if (popD202Exit_CoilSelector.OutDia != 0) { txt_COIL_OUT_DIA.Text = popD202Exit_CoilSelector.OutDia.ToString(); }
                    if( popD202Exit_CoilSelector.InDia!=0) {txt_COIL_IN_DIA.Text = popD202Exit_CoilSelector.InDia.ToString(); }
                    if (popD202Exit_CoilSelector.StockNO != string.Empty) { txt_FromStock.Text = popD202Exit_CoilSelector.StockNO; }
                }
            }
            catch (Exception ex)
            {
            }
        }
        //select coil from D202 Exit in Bay Z32-1
        private void cmdD202Exit_Z32_Click(object sender, EventArgs e)
        {
            try
            {
                PopD202Exit_CoilSelector popD202Exit_CoilSelector = new PopD202Exit_CoilSelector();
                popD202Exit_CoilSelector.UnitNO = "D202";
                popD202Exit_CoilSelector.BayNO = "Z32-1";
                DialogResult ret = popD202Exit_CoilSelector.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    txt_MatNO.Text = popD202Exit_CoilSelector.CoilNO;
                    if (popD202Exit_CoilSelector.CoilWidth != 0) { txt_COIL_WIDTH.Text = popD202Exit_CoilSelector.CoilWidth.ToString(); }
                    if (popD202Exit_CoilSelector.Weight != 0) { txt_COIL_WEIGHT.Text = popD202Exit_CoilSelector.Weight.ToString(); }
                    if (popD202Exit_CoilSelector.OutDia != 0) { txt_COIL_OUT_DIA.Text = popD202Exit_CoilSelector.OutDia.ToString(); }
                    if (popD202Exit_CoilSelector.InDia != 0) { txt_COIL_IN_DIA.Text = popD202Exit_CoilSelector.InDia.ToString(); }
                    if (popD202Exit_CoilSelector.StockNO != string.Empty) { txt_FromStock.Text = popD202Exit_CoilSelector.StockNO; }
                }
            }
            catch (Exception ex)
            {
            }
        }


        //select coil in yard
        private void cmdCoilInYardSelector_Click(object sender, EventArgs e)
        {
            try
            {
                PopCoilSelector_InYard popCoilSelector_InYard = new PopCoilSelector_InYard();
                popCoilSelector_InYard.InitTagDataProvide(tagDataProvider.ServiceName);
                DialogResult ret = popCoilSelector_InYard.ShowDialog();

                if (ret == DialogResult.OK)
                {
                    txt_MatNO.Text = popCoilSelector_InYard.CoilNO;
                    if (popCoilSelector_InYard.CoilWidth != 0) { txt_COIL_WIDTH.Text = popCoilSelector_InYard.CoilWidth.ToString(); }
                    if (popCoilSelector_InYard.Weight != 0) { txt_COIL_WEIGHT.Text = popCoilSelector_InYard.Weight.ToString(); }
                    if (popCoilSelector_InYard.OutDia != 0) { txt_COIL_OUT_DIA.Text = popCoilSelector_InYard.OutDia.ToString(); }
                    if (popCoilSelector_InYard.InDia != 0) { txt_COIL_IN_DIA.Text = popCoilSelector_InYard.InDia.ToString(); }
                    if (popCoilSelector_InYard.StockNO != string.Empty) { txt_FromStock.Text = popCoilSelector_InYard.StockNO; }
                }


            }
            catch (Exception ex)
            {
            }
        }


































    }
}
