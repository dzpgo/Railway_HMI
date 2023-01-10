using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace MODEL_OF_REPOSITORIES
{
    /// <summary>
    /// 小区处理数据类
    /// </summary>
    public class AreaInBay
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();

        private string areaNo = string.Empty;
        private string[] arrTagAdress;
        private string carNo = string.Empty;
        private int isLoaded = 999999;
        /// <summary>
        /// 跨别
        /// </summary>
        public string AreaNo
        {
            get { return areaNo; }
        }

        private bool Flag = false;
        public void conInit(string theAreaNo, string tagServiceName,bool flag)
        {
            try
            {
                areaNo = theAreaNo;
                Flag = flag;
                //初始化Tag
                tagDP.ServiceName = tagServiceName;
                //tagDP.AutoRegist = true;
                InitArrTagAdress();
            }
            catch (Exception ex)
            {
            }
        }
        private void InitArrTagAdress()
        {
            List<string> lstAdress = new List<string>();
            //安全区
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_A);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_B);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_C);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_D);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_E);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_F);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_G);
            //道闸
            //lstAdress.Add(TagNameClass.tag_DAOZHA_A_NORTH_CLOSE);
            //lstAdress.Add(TagNameClass.tag_DAOZHA_A_NORTH_OPEN);
            //lstAdress.Add(TagNameClass.tag_DAOZHA_A_SOUTH_CLOSE);
            //lstAdress.Add(TagNameClass.tag_DAOZHA_A_SOUTH_OPEN);
            //行车水位
            lstAdress.Add(TagNameClass.tag_1_DownLoadWater);
            lstAdress.Add(TagNameClass.tag_2_DownLoadWater);
            lstAdress.Add(TagNameClass.tag_3_DownLoadWater);
            lstAdress.Add(TagNameClass.tag_1_waterLevel_Flag);
            lstAdress.Add(TagNameClass.tag_2_waterLevel_Flag);
            lstAdress.Add(TagNameClass.tag_3_waterLevel_Flag);
            //行车吊具类型
            lstAdress.Add(TagNameClass.tag_1_clamp_sucker_switch);
            lstAdress.Add(TagNameClass.tag_2_clamp_sucker_switch);
            //光电门
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_AB);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_A_CD);
            //道闸限位
            lstAdress.Add(TagNameClass.tag_DAOZHA_SOUTH_UPPER_LIMIT);
            lstAdress.Add(TagNameClass.tag_DAOZHA_SOUTH_LOWER_LIMIT);
            lstAdress.Add(TagNameClass.tag_DAOZHA_NORTH_UPPER_LIMIT);
            lstAdress.Add(TagNameClass.tag_DAOZHA_NORTH_LOWER_LIMIT);

            //C跨
            //安全PLC
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_A);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_B);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_C);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_D);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_E);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_F);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_G);

            //光电门
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_AB);
            lstAdress.Add(TagNameClass.tag_AREA_SAFE_C_CD);
            //行车吊具类型
            lstAdress.Add(TagNameClass.tag_7_clamp_sucker_switch);
            lstAdress.Add(TagNameClass.tag_8_clamp_sucker_switch);
            //行车水位
            lstAdress.Add(TagNameClass.tag_7_DownLoadWater);
            lstAdress.Add(TagNameClass.tag_8_DownLoadWater);
            lstAdress.Add(TagNameClass.tag_7_waterLevel_Flag);
            lstAdress.Add(TagNameClass.tag_8_waterLevel_Flag);

            //道闸限位
            lstAdress.Add(TagNameClass.tag_C_DAOZHA_SOUTH_UPPER_LIMIT);
            lstAdress.Add(TagNameClass.tag_C_DAOZHA_SOUTH_LOWER_LIMIT);
            lstAdress.Add(TagNameClass.tag_C_DAOZHA_NORTH_UPPER_LIMIT);
            lstAdress.Add(TagNameClass.tag_C_DAOZHA_NORTH_LOWER_LIMIT);

            arrTagAdress = lstAdress.ToArray<string>();
            readTags();
        }
        /// <summary>
        /// 存储每个鞍座对应的数据（字典）
        /// </summary>
        private Dictionary<string, AreaBase> dicSaddles = new Dictionary<string, AreaBase>();
        public Dictionary<string, AreaBase> DicSaddles
        {
            get { return dicSaddles; }
            set { dicSaddles = value; }
        }

        /// <summary>
        /// 查找部分对应数据(不包括小区)
        /// </summary>
        public void getPortionAreaData()
        {

            string sql = null;

            try
            {
                if (Flag)
                     sql = string.Format("SELECT * FROM UACS_YARDMAP_AREA_DEFINE WHERE BAY_NO LIKE '{0}%'  and AREA_TYPE != 0", areaNo);
                else
                     sql = string.Format("SELECT * FROM UACS_YARDMAP_AREA_DEFINE WHERE BAY_NO LIKE '{0}%'  and AREA_TYPE = 0 ", areaNo);

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        AreaBase theArea = new AreaBase();
                        if (rdr["AREA_NO"] != System.DBNull.Value)
                        {
                            theArea.AreaNo = Convert.ToString(rdr["AREA_NO"]);
                        }
                        if (rdr["X_START"] != System.DBNull.Value)
                        {
                            theArea.X_Start = Convert.ToInt32(rdr["X_START"]);
                        }
                        if (rdr["X_END"] != System.DBNull.Value)
                        {
                            theArea.X_End = Convert.ToInt32(rdr["X_END"]);
                        }
                        if (rdr["Y_START"] != System.DBNull.Value)
                        {
                            theArea.Y_Start = Convert.ToInt32(rdr["Y_START"]);
                        }
                        if (rdr["Y_END"] != System.DBNull.Value)
                        {
                            theArea.Y_End = Convert.ToInt32(rdr["Y_END"]);
                        }
                        if (rdr["BAY_NO"] != DBNull.Value)
                        {
                            theArea.BayNo = rdr["BAY_NO"].ToString();
                        }
                        
                        dicSaddles[theArea.AreaNo] = theArea;
                    }
                }
            }
            catch (Exception er)
            {
                
                throw;
            } 
            
        }

        /// <summary>
        /// 查找部分对应数据(不包括小区)
        /// </summary>
        public void getPortionAreaData(string _bayno)
        {

            string sql = string.Empty;

            try
            {
                //if (Flag)
                //    sql = string.Format("SELECT * FROM UACS_YARDMAP_AREA_DEFINE WHERE BAY_NO LIKE '{0}%'  and AREA_TYPE != 0", areaNo);
                //else
                //    sql = string.Format("SELECT * FROM UACS_YARDMAP_AREA_DEFINE WHERE BAY_NO LIKE '{0}%'  and AREA_TYPE = 0 ", areaNo);

                sql = string.Format("SELECT * FROM UACS_YARDMAP_AREA_DEFINE WHERE BAY_NO = '{0}'  and AREA_TYPE = 0 ", _bayno);

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        AreaBase theArea = new AreaBase();
                        if (rdr["AREA_NO"] != System.DBNull.Value)
                        {
                            theArea.AreaNo = Convert.ToString(rdr["AREA_NO"]);
                        }
                        if (rdr["X_START"] != System.DBNull.Value)
                        {
                            theArea.X_Start = Convert.ToInt32(rdr["X_START"]);
                        }
                        if (rdr["X_END"] != System.DBNull.Value)
                        {
                            theArea.X_End = Convert.ToInt32(rdr["X_END"]);
                        }
                        if (rdr["Y_START"] != System.DBNull.Value)
                        {
                            theArea.Y_Start = Convert.ToInt32(rdr["Y_START"]);
                        }
                        if (rdr["Y_END"] != System.DBNull.Value)
                        {
                            theArea.Y_End = Convert.ToInt32(rdr["Y_END"]);
                        }
                        if (rdr["BAY_NO"] != DBNull.Value)
                        {
                            theArea.BayNo = rdr["BAY_NO"].ToString();
                        }

                        dicSaddles[theArea.AreaNo] = theArea;
                    }
                }
            }
            catch (Exception er)
            {

                throw;
            }

        }
        /// <summary>
        /// 查询停车位信息
        /// </summary>
        public void getParkingData()
        {
            try
            {
                string sql = @"select ID,X_START,X_END,Y_START,Y_END from UACS_YARDMAP_PARKINGSITE where YARD_NO = 'A' and ID like 'FT%' ";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        AreaBase theArea = new AreaBase();
                        if (rdr["ID"] != DBNull.Value)
                            theArea.AreaNo = rdr["ID"].ToString();
                        if (rdr["X_START"] != DBNull.Value)
                            theArea.X_Start =Convert.ToInt32( rdr["X_START"]);
                        if (rdr["X_END"] != DBNull.Value)
                            theArea.X_End = Convert.ToInt32( rdr["X_END"]);
                        if (rdr["Y_START"] != DBNull.Value)
                            theArea.Y_Start = Convert.ToInt32(rdr["Y_START"]);
                        if (rdr["Y_END"] != DBNull.Value)
                            theArea.Y_End =  Convert.ToInt32(rdr["Y_END"]);
                        theArea.ParkingStatus = getParkingStatus(theArea.AreaNo, out carNo,out isLoaded);
                        theArea.CarNo = carNo;
                        theArea.IsLoaded = isLoaded;
                        theArea.AreaWidth = theArea.Y_End - theArea.Y_Start;
                        theArea.AreaLength = theArea.X_End - theArea.X_Start;
                        dicSaddles[theArea.AreaNo] = theArea;

                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 查询停车位信息
        /// </summary>
        public void getParkingData(string BayNO)
        {
            try
            {
                string sql = @"select ID,X_START,X_END,Y_START,Y_END from UACS_YARDMAP_PARKINGSITE where YARD_NO = '"+ BayNO+ "' and ID like 'FT%' ";

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        AreaBase theArea = new AreaBase();
                        if (rdr["ID"] != DBNull.Value)
                            theArea.AreaNo = rdr["ID"].ToString();
                        if (rdr["X_START"] != DBNull.Value)
                            theArea.X_Start = Convert.ToInt32(rdr["X_START"]);
                        if (rdr["X_END"] != DBNull.Value)
                            theArea.X_End = Convert.ToInt32(rdr["X_END"]);
                        if (rdr["Y_START"] != DBNull.Value)
                            theArea.Y_Start = Convert.ToInt32(rdr["Y_START"]);
                        if (rdr["Y_END"] != DBNull.Value)
                            theArea.Y_End = Convert.ToInt32(rdr["Y_END"]);
                        theArea.ParkingStatus = getParkingStatus(theArea.AreaNo, out carNo, out isLoaded);
                        theArea.CarNo = carNo;
                        theArea.IsLoaded = isLoaded;
                        theArea.AreaWidth = theArea.Y_End - theArea.Y_Start;
                        theArea.AreaLength = theArea.X_End - theArea.X_Start;
                        dicSaddles[theArea.AreaNo] = theArea;

                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }



        /// <summary>
        /// 读小区全部鞍座
        /// </summary>
        /// <param name="_AreaNo"></param>
        /// <returns></returns>
        public int getAreaSaddleNum(string _AreaNo)
        {
            int saddlenum = 0;
            try
            {
                string sql = @"SELECT COUNT(*) as num FROM UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NAME like '" + _AreaNo + "%'";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                            saddlenum = Convert.ToInt32(rdr["num"]);
                    }
                }
            }
            catch (Exception er)
            {
                return 0;
            }
            return saddlenum;
        }

        /// <summary>
        /// 读小区白库位
        /// </summary>
        /// <param name="_AreaNo"></param>
        /// <returns></returns>
        public int getAreaSaddleNoCoilNum(string _AreaNo)
        {
            int saddleNoCoil = 0;
            try
            {
                string sql = @"SELECT COUNT(*) as num FROM UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NAME like '" + _AreaNo + "%' AND STOCK_STATUS = 0 AND LOCK_FLAG = 0";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                            saddleNoCoil = Convert.ToInt32(rdr["num"]);
                    }
                }
            }
            catch (Exception er)
            {
                return 0;
            }
            return saddleNoCoil;
        }

        /// <summary>
        /// 读小区黑库位
        /// </summary>
        /// <param name="_AreaNo"></param>
        /// <returns></returns>
        public int getAreaSaddleCoilNum(string _AreaNo)
        {
            int saddleCoil = 0;
            try
            {
                string sql = @"SELECT COUNT(*) as num FROM UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NAME like '" + _AreaNo + "%' AND STOCK_STATUS = 2 AND LOCK_FLAG = 0";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                            saddleCoil = Convert.ToInt32(rdr["num"]);
                    }
                }
            }
            catch (Exception er)
            {
                return 0;
            }
            return saddleCoil;
        }

        /// <summary>
        /// 读取停车位状态
        /// </summary>
        /// <param name="_PackingNo"></param>
        /// <returns></returns>
        private bool getParkingStatus(string _PackingNo,out string _CarNo,out int _isLoaded)
        {
            bool flag = false;
            _CarNo = null;
            _isLoaded = 999999;
            try
            {
                string sql = @"SELECT * FROM UACS_PARKING_STATUS WHERE PARKING_NO = '"+_PackingNo+"' and PARKING_STATUS != 5";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        flag = true;
                        if (rdr["CAR_NO"] != DBNull.Value)
                        {
                            _CarNo = rdr["CAR_NO"].ToString();
                        }
                        if (rdr["ISLOADED"] != DBNull.Value)
                        {
                            _isLoaded = Convert.ToInt32(rdr["ISLOADED"]);
                        }

                    }
                }
            }
            catch (Exception er)
            {
                return false;
                //throw;
            }
            return flag;
        }
        /// <summary>
        /// 获取安全门状态
        /// </summary>
        /// <param name="areaNum"></param>
        /// <returns></returns>
        public bool GetSafeDoorState(string areaNum)
        {
            bool ret = false;
            string tagName = "";
            if (areaNum.Contains("1-A"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_A_A;
            }
            else if (areaNum.Contains("1-B"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_A_B;
            }
            else if (areaNum.Contains("1-C"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_A_C;
            }

            else if (areaNum.Contains("1-D"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_A_D;
            }
            else if (areaNum.Contains("1-E"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_A_E;
            }
            else if (areaNum.Contains("1-F"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_A_F;
            }
            else if (areaNum.Contains("1-G"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_A_G;
            }
            else if (areaNum.Contains("RAILWAY"))
            {
                return ret = true; //火车轨道的，暂时这个没有状态，
            }
            //
            else if (areaNum.Contains("3-A"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_C_A;
            }
            else if (areaNum.Contains("3-B"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_C_B;
            }
            else if (areaNum.Contains("3-C"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_C_C;
            }

            else if (areaNum.Contains("3-D"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_C_D;
            }
            else if (areaNum.Contains("3-E"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_C_E;
            }
            else if (areaNum.Contains("3-F"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_C_F;
            }
            else if (areaNum.Contains("3-G"))
            {
                tagName = TagNameClass.tag_AREA_SAFE_C_G;
            }
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                if (valueObject != null && valueObject.ToString()=="1")
                {
                    ret = true; 
                }
                
            }
            catch
            {
                valueObject = null;
            }
            return ret;
        }
        /// <summary>
        /// 行车水位状态
        /// </summary>
        /// <param name="crane"></param>
        /// <returns></returns>
        public bool getCraneWaterLevelStatus(string crane)
        {
            bool ret = false;
            switch (crane)
            {
                case "1":
                  ret = GetDaoZhaState(TagNameClass.tag_1_waterLevel_Flag);
                    break;
                case "2":
                    ret = GetDaoZhaState(TagNameClass.tag_2_waterLevel_Flag);
                    break;
                case "3":
                    ret = GetDaoZhaState(TagNameClass.tag_3_waterLevel_Flag);
                    break;
                case "7":
                    ret = GetDaoZhaState(TagNameClass.tag_7_waterLevel_Flag);
                    break;
                case "8":
                    ret = GetDaoZhaState(TagNameClass.tag_8_waterLevel_Flag);
                    break;
                default:
                    break;
            }
            return ret;
        }
        //获取行车吊具类型
        /// <summary>
        /// tagValue=1为true
        /// </summary>
        /// <param name="crane"></param>
        /// <returns></returns>
        public bool getCraneLoderType(string crane)
        {
            bool ret = false;
            switch (crane)
            {
                case "1":
                    ret = GetDaoZhaState(TagNameClass.tag_1_clamp_sucker_switch);
                    break;
                case "2":
                    ret = GetDaoZhaState(TagNameClass.tag_2_clamp_sucker_switch);
                    break;
                case "7":
                    ret = GetDaoZhaState(TagNameClass.tag_7_clamp_sucker_switch);
                    break;
                case "8":
                    ret = GetDaoZhaState(TagNameClass.tag_8_clamp_sucker_switch);
                    break;
                //case "3":
                //    ret = GetDaoZhaState(TagNameClass.tag_3_waterLevel_Flag);
                //    break;
                default:
                    break;
            }
            return ret;
        }
        /// <summary>
        /// 获取光电门状态 0：开，1：关
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool getPhotogateStatus(string area)
        {
            bool ret = false;
            switch (area)
            {
                case "AB":
                    ret = GetDaoZhaState(TagNameClass.tag_AREA_SAFE_A_AB);
                    break;
                case "CD":
                    ret = GetDaoZhaState(TagNameClass.tag_AREA_SAFE_A_CD);
                    break;
                case "C-AB":
                    ret = GetDaoZhaState(TagNameClass.tag_AREA_SAFE_C_AB);
                    break;
                case "C-CD":
                    ret = GetDaoZhaState(TagNameClass.tag_AREA_SAFE_C_CD);
                    break;
                //case "3":
                //    ret = GetDaoZhaState(TagNameClass.tag_3_waterLevel_Flag);
                //    break;
                default:
                    break;
            }
            return ret;
        }
        /// <summary>
        /// 获取道闸下限位状态 0：开，1：关
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool getDaoZhaLowerStatus(string name)
        {
            bool ret = false;
            switch (name)
            {
                case "N":
                    ret = GetDaoZhaState(TagNameClass.tag_DAOZHA_NORTH_LOWER_LIMIT);
                    break;
                case "S":
                    ret = GetDaoZhaState(TagNameClass.tag_DAOZHA_SOUTH_LOWER_LIMIT);
                    break;
                case "C_N":
                    ret = GetDaoZhaState(TagNameClass.tag_C_DAOZHA_NORTH_LOWER_LIMIT);
                    break;
                case "C_S":
                    ret = GetDaoZhaState(TagNameClass.tag_C_DAOZHA_SOUTH_LOWER_LIMIT);
                    break;
                //case "3":
                //    ret = GetDaoZhaState(TagNameClass.tag_3_waterLevel_Flag);
                //    break;
                default:
                    break;
            }
            return ret;
        }
        /// <summary>
        /// 获取道闸上限位状态 0：开，1：关
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool getDaoZhaUpperStatus(string name)
        {
            bool ret = false;
            switch (name)
            {
                case "N":
                    ret = GetDaoZhaState(TagNameClass.tag_DAOZHA_NORTH_UPPER_LIMIT);
                    break;
                case "S":
                    ret = GetDaoZhaState(TagNameClass.tag_DAOZHA_SOUTH_UPPER_LIMIT);
                    break;
                case "C_N":
                    ret = GetDaoZhaState(TagNameClass.tag_C_DAOZHA_NORTH_UPPER_LIMIT);
                    break;
                case "C_S":
                    ret = GetDaoZhaState(TagNameClass.tag_C_DAOZHA_SOUTH_UPPER_LIMIT);
                    break;
                //case "3":
                //    ret = GetDaoZhaState(TagNameClass.tag_3_waterLevel_Flag);
                //    break;
                default:
                    break;
            }
            return ret;
        }
        /// <summary>
        /// tag点value为1是为true
        /// </summary>
        /// <param name="gate"></param>
        /// <returns></returns>
        public bool GetDaoZhaState(string gate)
        {
            bool ret = false;
            string tagName = gate;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                if (valueObject != null && valueObject.ToString() == "1")
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }
        private void readTags()
        {
            try
            {
                inDatas.Clear();
                tagDP.GetData(arrTagAdress, out inDatas);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
