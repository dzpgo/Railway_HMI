using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UACSParking
{

    public partial class FrmLaserDataInput : Form
    {

        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
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

        /// <summary>
        /// 停车位
        /// </summary>
        public string ParkingNo { get; set; }

        //存放画面添加的数据
        List<LaserDataBase> lstLaserDataBase = new List<LaserDataBase>();

        public FrmLaserDataInput()
        {
            InitializeComponent();
            this.Load += FrmLaserDataInput_Load;
        }

        void FrmLaserDataInput_Load(object sender, EventArgs e)
        {
            txtParkingNo.Text = ParkingNo;
            GetLaserdata();
        }



        #region -------------------方法--------------------
        /// <summary>
        /// 获取停车位状态表车号和扫描次数
        /// </summary>
        private void GetLaserdata()
        {
            try
            {
                txtCarNo.Text = "";
                txtLaserCount.Text = "";
                string sql = string.Format("select CAR_NO,LASER_ACTION_COUNT,TREATMENT_NO from UACS_PARKING_STATUS where PARKING_NO = '{0}'", ParkingNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["CAR_NO"] != DBNull.Value)
                            txtCarNo.Text = rdr["CAR_NO"].ToString();
                        if (rdr["LASER_ACTION_COUNT"] != DBNull.Value)
                            txtLaserCount.Text = rdr["LASER_ACTION_COUNT"].ToString();
                        if (rdr["TREATMENT_NO"] != DBNull.Value)
                            txt_TREATMENT_NO.Text = rdr["TREATMENT_NO"].ToString();
                    }
                }
            }
            catch (Exception er)
            {
            }
        }

        private void getLaterData(string _XCenter, string _YCenter, string _ZCenter, string _SteelWidth, string _SteelDia)
        {
            LaserDataBase theLaterData = null;
            try
            {
                if (_XCenter != null && _XCenter.Trim() != string.Empty && _YCenter != null && _YCenter.Trim() != string.Empty && _ZCenter != null && _ZCenter.Trim() != string.Empty && _SteelWidth != null && _SteelWidth.Trim() != string.Empty && _SteelDia != null && _SteelDia.Trim() != string.Empty)
                {
                    theLaterData = new LaserDataBase(_XCenter, _YCenter, _ZCenter, _SteelWidth, _SteelDia);
                    lstLaserDataBase.Add(theLaterData);
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void SaveALaterData(string _ParkingNo,string _Treatment, string _CarNo, int _LaterCount, int _XCenter, int _YCenter, int _ZCenter, int _SteelWidth, int _SteelDia)
        {
            try
            {
                string sql = @"insert into UACS_LASER_IN(
                             PARKING_NO,TREATMENT_NO,CAR_NO,LASER_ACTION_COUNT,X_ACT_CENTER,Y_ACT_CENTER,Z_ACT_CENTER,STEELWIDE,STEELDIAMETER)
                             values ( ";
                sql += "'" + _ParkingNo + "', ";
                sql += "'" + _Treatment + "', ";
                sql += "'" + _CarNo + "', ";
                sql += " " + _LaterCount + ", ";
                sql += " " + _XCenter + ", ";
                sql += " " + _YCenter + ", ";
                sql += " " + _ZCenter + ", ";
                sql += " " + _SteelWidth + " , ";
                sql += " " + _SteelDia + "";
                sql += " )";
                DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }


        private bool SaveData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtCarNo.Text.Trim().ToString()))
                {
                    MessageBox.Show("车号不为空");
                    return false;
                }

                if (string.IsNullOrEmpty(txtLaserCount.Text.Trim().ToString()))
                {
                    MessageBox.Show("激光扫描次数不为空");
                    return false;
                }

                lstLaserDataBase.Clear();
                getLaterData(txt_XCenter1.Text, txt_YCenter1.Text, txt_ZCenter1.Text, txt_Width1.Text, txt_Dia1.Text);
                getLaterData(txt_XCenter2.Text, txt_YCenter2.Text, txt_ZCenter2.Text, txt_Width2.Text, txt_Dia2.Text);
                getLaterData(txt_XCenter3.Text, txt_YCenter3.Text, txt_ZCenter3.Text, txt_Width3.Text, txt_Dia3.Text);
                getLaterData(txt_XCenter4.Text, txt_YCenter4.Text, txt_ZCenter4.Text, txt_Width4.Text, txt_Dia4.Text);
                getLaterData(txt_XCenter5.Text, txt_YCenter5.Text, txt_ZCenter5.Text, txt_Width5.Text, txt_Dia5.Text);
                getLaterData(txt_XCenter6.Text, txt_YCenter6.Text, txt_ZCenter6.Text, txt_Width6.Text, txt_Dia6.Text);
                getLaterData(txt_XCenter7.Text, txt_YCenter7.Text, txt_ZCenter7.Text, txt_Width7.Text, txt_Dia7.Text);
                getLaterData(txt_XCenter8.Text, txt_YCenter8.Text, txt_ZCenter8.Text, txt_Width8.Text, txt_Dia8.Text);

                if (lstLaserDataBase.Count == 0)
                {
                    return false;
                }

                foreach (LaserDataBase ptData in lstLaserDataBase)
                {
                    SaveALaterData(txtParkingNo.Text.Trim().ToString(),txt_TREATMENT_NO.Text.Trim().ToString(), txtCarNo.Text.Trim().ToString(), Convert.ToInt32(txtLaserCount.Text.Trim()), Convert.ToInt32(ptData.XCenter), Convert.ToInt32(ptData.YCenter), Convert.ToInt32(ptData.ZCenter), Convert.ToInt32(ptData.SteelWidth), Convert.ToInt32(ptData.SteelDia));
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion



        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (SaveData())
                {
                    MessageBox.Show("激光数据添加成功");
                    Thread.Sleep(1000);
                    this.Close();
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

    }

    public class LaserDataBase
    {
        private string xCenter;
        public string XCenter
        {
            get { return xCenter; }
            set { xCenter = value; }
        }

        private string yCenter;
        public string YCenter
        {
            get { return yCenter; }
            set { yCenter = value; }
        }

        private string zCenter;
        public string ZCenter
        {
            get { return zCenter; }
            set { zCenter = value; }
        }

        private string steelWidth;
        public string SteelWidth
        {
            get { return steelWidth; }
            set { steelWidth = value; }
        }

        private string steelDia;
        public string SteelDia
        {
            get { return steelDia; }
            set { steelDia = value; }
        }

        public LaserDataBase(string theXCenter, string theYCenter, string theZCenter, string theSteelWidth, string theSteelDia)
        {
            xCenter = theXCenter;
            yCenter = theYCenter;
            zCenter = theZCenter;
            steelWidth = theSteelWidth;
            steelDia = theSteelDia;
        }

    }

}
