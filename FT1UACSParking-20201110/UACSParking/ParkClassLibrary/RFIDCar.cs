using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Windows.Forms;

namespace ParkClassLibrary
{

    /// <summary>
    /// 车辆信息类，基本数据来自于数据库
    /// </summary>
    public class CarInfo
    {
        public const string A_GATE_S = "A_S";
        public const string A_GATE_N = "A_N";

        public const string C_GATE_S = "C_S";
        public const string C_GATE_N = "C_N";
        //一个车的ID（车号）可能有多个，如：A1201
        private string carID;

        //车辆车牌号，如：湛钢J0111
        private string carLicence;

        //tagID，2-4个
        private List<string> tagIDs = new List<string>();

       
        //汽车状态：1在库区内，0在库区外，-1未投运
        private int carStatus = 0;

        //所在停车位位置，空代表未占用停车位
        private string pos = "";

        //经过道闸的时间
        private DateTime readtime;

        //南通道还是北通道
        private string door="";
        //进入时刻
        private DateTime carInTime;

        public DateTime CarInTime
        {
            get { return carInTime; }
            set { carInTime = value; }
        }
        //出去时刻
        private DateTime carOutTime;

        public DateTime CarOutTime
        {
            get { return carOutTime; }
            set { carOutTime = value; }
        }
        public string CarID
        {
            get
            {
                return carID;
            }

            set
            {
                carID = value;
            }
        }

        public int CarStatus
        {
            get
            {
                return carStatus;
            }

            set
            {
                carStatus = value;
            }
        }

        public string Pos
        {
            get
            {
                return pos;
            }

            set
            {
                pos = value;
            }
        }

        public List<string> TagID
        {
            get
            {
                return tagIDs;
            }
        }

        public DateTime ReadTime
        {
            get
            {
                return readtime;
            }

            set
            {
                readtime = value;
            }
        }

        public string CarLicence
        {
            get
            {
                return carLicence;
            }

            set
            {
                carLicence = value;
            }
        }

        public int TagCount
        {
            get
            {
                return tagIDs.Count;
            }
        }

        public string Door
        {
            get
            {
                return door;
            }

            set
            {
                door = value;
            }
        }

        public CarInfo(string carID,string carLicence, string[] tagIds)
        {
            this.carID = carID;
            this.carLicence = carLicence;

            if (tagIds != null)
                tagIDs.AddRange(tagIDs.AsEnumerable());
        }
        public CarInfo(string carID, string carLicence, string tagIdstr)
        {
            this.carID = carID;
            this.carLicence = carLicence;
            carStatus = 0;
            door = "";
            carInTime = DateTime.MinValue;
            carOutTime = DateTime.MinValue;

            if (tagIdstr != null)
            {
                string[] tagIdarr = tagIdstr.Split(',');
                tagIDs.AddRange(tagIdarr.AsEnumerable());
            }

        }

        public void AddTagIDs( string[] tagIds)
        {
            //避免重复，要先查找
            if (tagIds != null)
            {
                foreach (string item in tagIDs)
                {
                    AddTagID(item);
                }
            }
        }

        public void AddTagID(string tagId)
        {
            //避免重复，要先查找
            if (tagId != null)
            {
                foreach(string item in tagIDs)
                {
                    if (item == tagId)
                        return;
                }
                tagIDs.Add(tagId);
            }
        }
        public override string ToString()
        {
            return "车号： " + CarID + "车牌号: " + carLicence + "  道闸： " + door + "  状态:  " + carStatus + "  进来时刻： " + carInTime.ToString("yyyyMMddHHmmss") + "  出去时刻： " + carOutTime.ToString("yyyyMMddHHmmss");
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        } 
    }

    /// <summary>
    /// 处理RFID有关信息
    /// </summary>
    public class RFIDCar
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
                        //MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion
        /// <summary>
        /// 登记的车辆信息，所有的车信息都在这里头
        /// </summary>
        private Dictionary<string, CarInfo> allcars;

        //在库内的所有tag
        private HashSet<string> alltags;

        
        public RFIDCar()
        {
            allcars = new Dictionary<string, CarInfo>();
            alltags = new HashSet<string>();

            InitData();
        }

        /// <summary>
        /// 增加索引，tagID为key
        /// </summary>
        /// <param name="carinfo"></param>
        public void AddCarDictionary(CarInfo carinfo)
        {
            List<string> tagIDs = carinfo.TagID;
            foreach(string item in tagIDs)
            {
                if (allcars.ContainsKey(item))
                {
                     //(item + "已经存在");
                    
                }
                else
                    allcars.Add(item, carinfo);
                
                alltags.Add(item);
            }
      
        }

        /// <summary>
        /// 初始化车辆信息集合
        /// </summary>
        public void InitData()
        {
            string carNO="";
            string carNumber="";
            string tagIDs = "";
            string sqlTextF = "SELECT CARNO,CAR_NUMBER,CAR_TAG_NUM FROM UACS_CAR_HEAD_DEFINE";
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlTextF))
            {
                while (rdr.Read())
                {
                    if (rdr["CARNO"] != DBNull.Value)
                    {
                        carNO = Convert.ToString(rdr["CARNO"]);
                    }
                    if (rdr["CAR_NUMBER"] != DBNull.Value)
                    {
                        carNumber = Convert.ToString(rdr["CAR_NUMBER"]);
                    }
                    if (rdr["CAR_TAG_NUM"] != DBNull.Value)
                    {
                        tagIDs = Convert.ToString(rdr["CAR_TAG_NUM"]);
                    }
                    CarInfo car1 = new CarInfo(carNO, carNumber, tagIDs);
                    AddCarDictionary(car1);
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CarToString()
        {
            string sss = "";
            int index = 1;
            foreach (KeyValuePair<string,CarInfo>item in allcars)
            {
                ///sss += item.Key + ":" + item.Value.CarStatus.ToString() + "  "+ item.Value.ReadTime.ToLongTimeString()+"\r\n";
                sss += item.Key + ":" + item.Value.CarID+","+item.Value.CarLicence+"\r\n";

                index++;
            }
            return sss;
        }

        public string TagToString()
        {
            string sss = "";
            int index = 1;
            foreach(string tag in alltags)
            {
                sss += index.ToString() + ":" + tag + "\r\n";
                index++;
            }
            return sss;
        }

        /// <summary>
        /// 返回str内,substr1最后一个位置与substr2第一个位置之间的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="substr1"></param>
        /// <param name="substr2"></param>
        /// <returns></returns>
        private string GetSubString(string str, string substr1, string substr2)
        {
            if (str == "")
                return "";

            int index1 = str.IndexOf(substr1);
            int index2 = str.IndexOf(substr2);

            if (index1 != -1 && index2 != -1)
            {
                int length = index2 - index1 - substr1.Length;
                string rfidtag = str.Substring(index1 + substr1.Length, length);
                return rfidtag;
            }

            return "";
        }

        /// <summary>
        /// 更新某个tag的ID，如果Tag不存在，就加入
        /// </summary>
        /// <param name="tagID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int ModifyTagStatus(string tagID, int status)
        {
            if (allcars.ContainsKey(tagID))
            {
                CarInfo car = allcars[tagID];
                car.CarStatus = status;
            }
                return 0;
        }


        public bool getTagInfo(string rfidInfo, out string curtagID, out string portID, out string currCarNO,out string gate)
        {
            bool ret = false;
            curtagID = "";
            portID = "";
            currCarNO = "";
            gate = "";
            try
            {
                string tagID = GetSubString(rfidInfo, "<TagBlink><TagID><![CDATA[", "]]></TagID><Time>");
                curtagID = tagID;

                //看看有无RFID出入库区：，查找关键字<WherePortID>
                string str = "<WherePortID>";
                int index = rfidInfo.IndexOf(str);

                if (index == -1)
                {
                    return ret;
                }
                portID = GetSubString(rfidInfo, "<WherePortID><![CDATA[", "]]></WherePortID>");
                string tempGate = portID.Trim();

                if (allcars.ContainsKey(tagID))
                {
                    currCarNO = allcars[tagID].CarLicence;
                    ret = true;
                }
                else
                {
                    CarInfo newCarInfo = new CarInfo("NULL", "未知", tagID);
                    allcars.Add(tagID, newCarInfo);
                    ret = true;
                }
                if (tempGate == "5011" || tempGate == "5012")
                {
                    gate = "A_N";
                }
                else if (tempGate == "5014" || tempGate == "5013")
                {
                    gate = "A_S";
                }
                else if (tempGate == "5031" || tempGate == "5032")
                {
                    gate = "C_N";
                }
                else if (tempGate == "5034" || tempGate == "5033")
                {
                    gate = "C_S";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

            

            return ret;
        }

    
        /// <summary>
        /// 更新车辆信息
        /// </summary>
        /// <param name="rfidInfo"></param>
        /// <returns></returns>
        public string UpdataCars(string tagID, string portID, string curDoor, out CarInfo currCar)
        {
            currCar = null;
            if (tagID == "" || curDoor == "")
            {
                return string.Format("-------tagID== ||curDoor== ,返回--------\r\n");
            }
            //状态
            if (allcars[tagID].CarStatus != 1)  //进来
            {
                //allcars[tagID].CarStatus = 1;
                allcars[tagID].CarInTime = DateTime.Now;
            }
            else                              //出去
            {
                //allcars[tagID].CarStatus = 0;
                allcars[tagID].CarOutTime = DateTime.Now;
            }
            switch(portID)
            {
                case "5011":
                    allcars[tagID].CarStatus = 0;
                    break;
                case "5012":
                    allcars[tagID].CarStatus = 1;
                    break;
                case "5013":
                    allcars[tagID].CarStatus = 1;
                    break;
                case "5014":
                    allcars[tagID].CarStatus = 0;
                    break;
                case "5031":
                    allcars[tagID].CarStatus = 1;
                    break;
                case "5032":
                    allcars[tagID].CarStatus = 0;
                    break;
                case "5033":
                    allcars[tagID].CarStatus = 0;
                    break;
                case "5034":
                    allcars[tagID].CarStatus = 1;
                    break;

                default :
                    allcars[tagID].CarStatus = 1;
                    break;
            }
 
            allcars[tagID].Door = curDoor;

            //相同TagID处理
            currCar = allcars[tagID];
            string str = ChangSameTagCarState(tagID);
            return str + "\r\n" + allcars[tagID].ToString();
        }
        /// <summary>
        /// 改变车号相同的状态
        /// </summary>
        /// <param name="tagID"></param>
        private string  ChangSameTagCarState(string tagID)
        {
            string ret = "改变相同车的Tag状态：\r\n";
            foreach (KeyValuePair<string, CarInfo> item in allcars)
            {
                if (item.Value.CarLicence == allcars[tagID].CarLicence)
                {
                    item.Value.CarInTime = allcars[tagID].CarInTime;
                    item.Value.CarStatus = allcars[tagID].CarStatus;
                    item.Value.Door = allcars[tagID].Door;
                    item.Value.CarOutTime = allcars[tagID].CarOutTime;
                    item.Value.Pos = allcars[tagID].Pos;
                    ret += "Tag: " + item.ToString() + "\r\n";
                }
            }
            return ret;
        }
        /// <summary>
        /// 改变车号相同的状态
        /// </summary>
        /// <param name="tagID"></param>
        public string CarStateClear()
        {
            string ret = "车状态清空：\r\n";
            foreach (KeyValuePair<string, CarInfo> item in allcars)
            {
                item.Value.CarStatus = 0;
                ret += "Tag: " + item.ToString() + "\r\n";
            }
            return ret;
        }
        /// <summary>
        /// 改变指定车的状态
        /// </summary>
        /// <returns></returns>
        public string ChangeCarStatus(string carNO ,int status)
        {
            string ret = "改变指定车的状态：\r\n";
            foreach (KeyValuePair<string, CarInfo> item in allcars)
            {
                if (item.Value.CarID == carNO)
                {
                    item.Value.CarStatus = status;
                    ret += "Tag: " + item.ToString() + "\r\n";
                    break;
                }
               
            }
            return ret;
        }
        /// <summary>
        /// 经过道闸时，60s内返回true
        /// </summary>
        /// <param name="tagID"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public bool PassGateLess60s(string tagID,out double sec)
        {
            bool ret=false;
            sec = 60;
            DateTime datetimePass = new DateTime();
            if (allcars[tagID].CarInTime==DateTime.MinValue)
            {
                return ret;
            }
            if (allcars[tagID].CarStatus==1)
            {
                datetimePass= allcars[tagID].CarInTime;
            }
            else
            {
                datetimePass = allcars[tagID].CarOutTime;
            }
            TimeSpan span = DateTime.Now.Subtract(datetimePass);
            sec = span.TotalSeconds;
            if (span.TotalSeconds<100)   //100秒内不接收
            {
                ret = true;
            }
            return ret;
        }
        public bool PassGateLess60s(string tagID, string currGate,out double sec)
        {
            bool ret = false; 
            sec = 60;
            try
            {
                DateTime datetimePass = new DateTime();

                if (allcars[tagID].CarInTime == DateTime.MinValue || allcars[tagID].Door != currGate) // && currGate!="NS")
                {
                    return ret;
                }
                if (allcars[tagID].CarStatus == 1)
                {
                    datetimePass = allcars[tagID].CarInTime;
                }
                else
                {
                    datetimePass = allcars[tagID].CarOutTime;
                }
                TimeSpan span = DateTime.Now.Subtract(datetimePass);
                sec = span.TotalSeconds;
                if (span.TotalSeconds < 100)   //100秒内不接收
                {
                    ret = true;
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);

            }
            return ret;
        }
        public bool checkTagIDIsInDictionary(string tagID)
        {
            bool ret = false;
            try
            {
                if (!allcars.Keys.Contains(tagID))
                {
                    CarInfo newCarInfo = new CarInfo("NULL", "未知", tagID);
                    allcars.Add(tagID, newCarInfo);
                    ret = true;
                }
            }
            catch (Exception)
            {
                
            }
            return ret;
        }
    }
}
