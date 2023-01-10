using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONTROLS_OF_PREMIERE
{
    public partial class PopStockToStock : Form
    {
        public PopStockToStock()
        {
            InitializeComponent();
            this.Load += PopStockToStock_Load;
        }

        public PopStockToStock(string _bay_no)
        {
            InitializeComponent();
            this.Load += PopStockToStock_Load;
            bayNO = _bay_no;
        }

        void PopStockToStock_Load(object sender, EventArgs e)
        {
            lstBoxInfo.Text += "当前跨别："+ bayNO + "，倒垛行车：" + CraneNO+ "\r\n";
        }
        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        public static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
                    }
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion

        #region iPlature配置
        private static Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = null;
        public static Baosight.iSuperframe.TagService.Controls.TagDataProvider TagDP
        {
            get
            {
                if (tagDP == null)
                {
                    try
                    {
                        tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
                        tagDP.ServiceName = "iplature";
                        tagDP.AutoRegist = true;
                    }
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return tagDP;
            }
            //set { tagDP = value; }
        }
        #endregion
        private string craneNO = string.Empty;
        public string CraneNO
        {
            get { return craneNO; }
            set { craneNO = value; }
        }

        private string bayNO = string.Empty;

        public string BayNO
        {
            get { return bayNO; }
            set { bayNO = value; }
        }
        const string PLC_INT_NULL = "999999";
        //const string BAY_NO = "A-1";
        long orderID = 100;
        bool isCheckFromStock =false;
        bool isCheckToStock = false;
        private void txt_FromStock_TextChanged(object sender, EventArgs e)
        {
            isCheckFromStock = false;
            string stockFrom;
            stockFrom = txt_FromStock.Text.ToUpper().ToString().Trim();
            txt_FromStock.Text = stockFrom;
            txt_FromStock.SelectionStart = txt_FromStock.Text.Length;
            txt_FromStock.SelectionLength = 0;

            //获取库位信息
            //if ((stockFrom.Contains('-') && stockFrom.Length == 5) || (stockFrom.Contains("FT") && stockFrom.Length == 8))
            if (stockFrom.Contains("Z0") && stockFrom.Length == 8)
            {
                //string str1;
                //string str2;
                string stockNO;
                int stockStatus;
                int stockFlag;
                //if (stockFrom.Contains('-'))
                //{
                //    int index1 = stockFrom.IndexOf('-');
                //    str1 = stockFrom.Substring(0, index1);
                //    str2 = stockFrom.Substring(index1 + 1);
                //    if (BayNO == "C-1")
                //    {
                //        stockNO = "FT33" + str1 + str2;
                //    }
                //    else
                //    {
                //        stockNO = "FT11" + str1 + str2;
                //    }
                //}
                //else 
                //{
                    stockNO = stockFrom;
                //}
                //获取库位状态
                getStockStatus(stockNO, out stockStatus, out stockFlag);
                if (stockStatus != 2 || stockFlag != 0)  //2占用，
                {
                    lstBoxInfo.Text += "库位当前状态不满足stockStatus（2）： " + stockStatus + "  stockFlag（0）：" + stockFlag + "\r\n";
                    lstBoxInfo.Text += "倒垛目标库位选择失败： " + stockNO + "\r\n";
                    lstBoxInfo.Text += "请重新选择另一个有卷库位！ " + "\r\n";
                    txt_PLAN_UP_X.Text = PLC_INT_NULL;
                    txt_PLAN_UP_Y.Text = PLC_INT_NULL;
                    txt_COIL_WEIGHT.Text = PLC_INT_NULL;
                    txt_COIL_WIDTH.Text = PLC_INT_NULL;
                    txt_COIL_OUT_DIA.Text = PLC_INT_NULL;
                    txt_COIL_IN_DIA.Text = PLC_INT_NULL;
                    txt_MatNO.Text = PLC_INT_NULL;
                    return;
                }
                if (cmdCalFrmXY(stockNO))
                {
                    lstBoxInfo.Text += "倒垛开始库位选择成功： " + stockNO + "\r\n";
                    txt_FromStock.Text = stockNO;
                    txt_FromStock.SelectionStart = txt_FromStock.Text.Length;
                    txt_FromStock.SelectionLength = 0;
                    //
                    txt_ToStock.Focus();
                    txt_ToStock.Text = "";
                }
                else
                {
                    lstBoxInfo.Text += "倒垛开始库位选择失败： " + stockNO + "\r\n";
                    txt_PLAN_UP_X.Text = PLC_INT_NULL;
                    txt_PLAN_UP_Y.Text = PLC_INT_NULL;
                }
                Int32 weight, width,inDIA,outDIA;
                string matNO = string.Empty;                
                //获取钢卷信息
                if (getCoilInfo(stockNO,out matNO, out weight, out width, out inDIA, out outDIA))
                {
                    lstBoxInfo.Text += "钢卷信息获取成功： " + matNO + "\r\n";
                    txt_MatNO.Text = matNO;
                    if (weight != 0) { txt_COIL_WEIGHT.Text = weight.ToString(); }
                    if (width != 0) { txt_COIL_WIDTH.Text = width.ToString(); }
                    if (inDIA != 0) { txt_COIL_IN_DIA.Text = inDIA.ToString(); }
                    if (outDIA != 0) { txt_COIL_OUT_DIA.Text = outDIA.ToString(); }
                }
                else
                {
                    lstBoxInfo.Text += "钢卷信息获取失败： " + matNO + "\r\n";
                    txt_COIL_WEIGHT.Text = PLC_INT_NULL;
                    txt_COIL_WIDTH.Text = PLC_INT_NULL;
                    txt_COIL_OUT_DIA.Text = PLC_INT_NULL;
                    txt_COIL_IN_DIA.Text = PLC_INT_NULL;
                    return;
                }
                //设置起卷Z
                if (weight != 0 && width != 0 && inDIA != 0 && outDIA != 0)
                {
                    cmdCalUpClampWidthSet();
                    cmdCalUpZDownZ();
                    isCheckFromStock = true;
                }

            }
            else
            {
                return;
            }
        }

        private void txt_ToStock_TextChanged(object sender, EventArgs e)
        {
            isCheckToStock = false;
            string stockTo;
            stockTo = txt_ToStock.Text.ToUpper().ToString().Trim();
            txt_ToStock.Text = stockTo;
            txt_ToStock.SelectionStart = txt_ToStock.Text.Length;
            txt_ToStock.SelectionLength = 0;
            //if ((stockTo.Contains('-') && stockTo.Length == 5) || (stockTo.Contains("FT") && stockTo.Length == 8))
            if (stockTo.Contains("Z0") && stockTo.Length == 8)
            {
                //string str1;
                //string str2;
                string stockNO;
                int stockStatus;
                int stockFlag;
                //if (stockTo.Contains('-') )
                //{
                //    int index1 = stockTo.IndexOf('-');
                //    str1 = stockTo.Substring(0, index1);
                //    str2 = stockTo.Substring(index1 + 1);
                //    stockNO = "FT11" + str1 + str2;
                //}
                //if (stockTo.Contains('-'))
                //{
                //    int index1 = stockTo.IndexOf('-');
                //    str1 = stockTo.Substring(0, index1);
                //    str2 = stockTo.Substring(index1 + 1);
                //    if (BayNO == "C-1")
                //    {
                //        stockNO = "FT33" + str1 + str2;
                //    }
                //    else
                //    {
                //        stockNO = "FT11" + str1 + str2;
                //    }
                //}
                //else
                //{
                    stockNO = stockTo;
                //}
                getStockStatus(stockNO, out stockStatus, out stockFlag);
                if (stockStatus!=0 ||stockFlag!=0)
                {
                    lstBoxInfo.Text += "库位当前状态不满足stockStatus（0）： " + stockStatus + "  stockFlag：（0）" + stockFlag + "\r\n";
                    lstBoxInfo.Text += "倒垛目标库位选择失败： " + stockNO + "\r\n";
                    lstBoxInfo.Text += "请重新选择另一个空库位！ " + "\r\n";
                    txt_PLAN_DOWN_X.Text = PLC_INT_NULL;
                    txt_PLAN_DOWN_Y.Text = PLC_INT_NULL;
                    return;
                }
                if (cmdCalDownXY(stockNO))
                {
                    lstBoxInfo.Text += "倒垛目标库位选择成功： " + stockNO + "\r\n";
                    txt_ToStock.Text = stockNO;
                    txt_ToStock.SelectionStart = txt_ToStock.Text.Length;
                    txt_ToStock.SelectionLength = 0;
                    isCheckToStock = true;
                }
                else
                {
                    lstBoxInfo.Text += "倒垛目标库位选择失败： " + stockNO + "\r\n";
                    txt_PLAN_DOWN_X.Text = PLC_INT_NULL;
                    txt_PLAN_DOWN_Y.Text = PLC_INT_NULL;

                }

            }

        }

        #region 方法
        //from
        private bool cmdCalFrmXY(string stock)
        {

            bool ret = false;
            try
            {
                long upX=Convert.ToInt32(PLC_INT_NULL);
                long upY=Convert.ToInt32(PLC_INT_NULL);
                string fromStockNO = stock;
                if(fromStockNO==string.Empty)
                {
                    MessageBox.Show("起吊Stock为空", "起吊Stock为空", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return ret;
                }
                ret= getStockXY(fromStockNO, ref upX, ref upY);
                txt_PLAN_UP_X.Text = upX.ToString();
                txt_PLAN_UP_Y.Text = upY.ToString();

            }
            catch (Exception ex)
            {
            }
            return ret;
        }

        public bool getStockXY(string stockNO, ref long stockX, ref long stockY)
        {
            bool ret = false;
            try
            {
                // string sqlText = "SELECT * FROM UACS_YARDMAP_SADDLE_DEFINE WHERE SADDLE_NO=" + "'" + stockNO + "'";
                string sqlText = string.Format("SELECT * FROM  UACS_YARDMAP_SADDLE_DEFINE  JOIN  UACS_YARDMAP_SADDLE_STOCK ON   UACS_YARDMAP_SADDLE_DEFINE.SADDLE_NO=UACS_YARDMAP_SADDLE_STOCK.SADDLE_NO  where   UACS_YARDMAP_SADDLE_STOCK.STOCK_NO = '{0}' ", stockNO);
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

        //to
        private bool cmdCalDownXY(string stockNO)
        {
            bool ret = false;
            try
            {
                long downX = Convert.ToInt32(PLC_INT_NULL);
                long downY = Convert.ToInt32(PLC_INT_NULL);
                string toStockNO = stockNO;
                if (toStockNO == string.Empty)
                {
                    MessageBox.Show("落关Stock为空", "StockStock为空", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return ret;
                }
                getSaddleXY(toStockNO, ref downX, ref downY);
                txt_PLAN_DOWN_X.Text = downX.ToString();
                txt_PLAN_DOWN_Y.Text = downY.ToString();
                ret = true;
            }
            catch (Exception ex)
            {
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
            catch (Exception )
            {
                //MessageBox.Show("Refresh_CranePlan"+ex.Message);
            }

            return ret;

        }
        private void getStockStatus(string stockNO, out int stockStatus, out int stockFlag)
        {
            stockStatus = 2;
            stockFlag = 2;
            try
            {
                string sqlText = "SELECT STOCK_STATUS, LOCK_FLAG FROM UACSAPP.UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NO  = " + "'" + stockNO + "'";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        if (rdr["STOCK_STATUS"] != System.DBNull.Value) { stockStatus = Convert.ToInt32(rdr["STOCK_STATUS"]); }
                        if (rdr["LOCK_FLAG"] != System.DBNull.Value) { stockFlag = Convert.ToInt32(rdr["LOCK_FLAG"]); }
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Refresh_CranePlan"+ex.Message);
            }
        }
        private bool  getCoilInfo(string stockNO,out string matNO, out Int32 weight, out int width, out int inDIA, out int outDIA)
        {
            bool ret = false;
            weight = 0;
            width = 0;
            inDIA = 0;
            outDIA = 0;
            matNO = "";
            try
            {
                string sqlText = "SELECT B.MAT_NO ,A.WEIGHT,A.WIDTH,A.INDIA,A.OUTDIA FROM  UACS_YARDMAP_COIL A ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE B ON A.COIL_NO = B.MAT_NO ";
                sqlText += " WHERE B.STOCK_NO = " + "'" + stockNO + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        if (rdr["MAT_NO"] != System.DBNull.Value) { matNO = Convert.ToString(rdr["MAT_NO"]); }
                        if (rdr["WEIGHT"] != System.DBNull.Value) { weight = Convert.ToInt32(rdr["WEIGHT"]); }
                        if (rdr["WIDTH"] != System.DBNull.Value) { width = Convert.ToInt32(rdr["WIDTH"]); }
                        if (rdr["INDIA"] != System.DBNull.Value) { inDIA = Convert.ToInt32(rdr["INDIA"]); }
                        if (rdr["OUTDIA"] != System.DBNull.Value) { outDIA = Convert.ToInt32(rdr["OUTDIA"]); }
                        ret = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            return ret;
        }
        private void cmdCalUpZDownZ( )
        {
            try
            {
                long outDia = Convert.ToInt64(txt_COIL_OUT_DIA.Text);
                if (outDia >= 2200)
                {
                    MessageBox.Show("直径大于2200上限", "直径大于2200上限", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (outDia <= 500)
                {
                    MessageBox.Show("直径小于于500下限", "直径小于于500下限", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmdCalUpClampWidthSet()
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

        private void cmdCreateComputerOrder()
        {
            try
            {
                //2 orderID
                long orderID =  this.orderID++;
                //3 planUpX
                long planUpX = Convert.ToInt64(txt_PLAN_UP_X.Text);
                //4 planUpY
                long planUpY = Convert.ToInt64(txt_PLAN_UP_Y.Text);
                //5 planUpZ
                long planUpZ = Convert.ToInt64(txt_PLAN_UP_Z.Text);
                //6 UP_ROTATE_ANGLE_SET
                long upRotateAngleSet = Convert.ToInt64(PLC_INT_NULL); //
                //7 CLAMP_WIDTH_SET
                long clampWidthSet = Convert.ToInt64(txt_CLAMP_WIDTH_SET.Text);
                //8 planDownX
                long planDownX = Convert.ToInt64(txt_PLAN_DOWN_X.Text);
                //9 planDownY
                long planDownY = Convert.ToInt64(txt_PLAN_DOWN_Y.Text);
                //10 planDownZ
                long planDownZ = Convert.ToInt64(txt_PLAN_DOWN_Z.Text);
                //11 DOWN_ROTATE_ANGLE_SET
                long downRotateAngleSet = Convert.ToInt64(PLC_INT_NULL); //
                //12 coilWidth
                long coilWidth = Convert.ToInt64(txt_COIL_WIDTH.Text);
                //13 COIL_WEIGHT
                long coilWeight = Convert.ToInt64(txt_COIL_WEIGHT.Text);
                //14 coilOutDia
                long coilOutDia = Convert.ToInt64(txt_COIL_OUT_DIA.Text);

                //15 coilInDia
                long coilInDia = Convert.ToInt64(txt_COIL_IN_DIA.Text);

                //16 floorUpZ
                long floorUpZ = Convert.ToInt64(PLC_INT_NULL); //

                //17 flagSmallCoil
                long flagSmallCoil = 0; //

                //18 floorDownZ
                long floorDownZ = 0 ;  ///

                string bayNO = BayNO;

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

              //DialogResult dr =  MessageBox.Show("指令已经写入系统", "指令已经写入系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
              //if (dr == System.Windows.Forms.DialogResult.OK)
              //{
              //    //this.Close();
              //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("指令写入系统失败" + ex.Message, "指令写入系统失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cmdExcuteComputerOrder()
        {
            try
            {
                //DialogResult ret = MessageBox.Show("确认放开指令并启动行车", "确认放开指令并启动行车", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                //if (ret == DialogResult.Cancel)
                //{
                //    return;
                //}
                string strSql = " Update UACS_CRANE_ORDER_CURRENT set ";

                strSql += " CMD_STATUS=" + "'" + "COIL_UP_PROCESS" + "'";

                strSql += " where CRANE_NO=" + "'" + craneNO + "'";

                DBHelper.ExecuteNonQuery(strSql);
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        private void btnCommit_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("确认提交该倒垛指令？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ret == DialogResult.Cancel)
            {
                return;
            }
            if (isCheckToStock && isCheckFromStock)
            {
                cmdCreateComputerOrder();
                cmdExcuteComputerOrder();
                UACSUtility.HMILogger.WriteLog(btnCommit.Text, "提交该倒垛指令 ， 行车号：" + craneNO, UACSUtility.LogLevel.Info, this.Text);
            }
            else
            {
                lstBoxInfo.Text += "请检查起卷、目标库位：" + "isCheckFromStock：" + isCheckFromStock.ToString() + "isCheckToStock：" + isCheckToStock.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
