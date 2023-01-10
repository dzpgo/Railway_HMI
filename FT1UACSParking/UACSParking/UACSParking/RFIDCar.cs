using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baosight.ZJWS
{
    /// <summary>
    /// 车辆信息类，基本数据来自于数据库
    /// </summary>
    public class CarInfo
    {
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
        private string door;

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
    }

    /// <summary>
    /// 处理RFID有关信息
    /// </summary>
    public class RFIDCar
    {
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
                allcars.Add(item, carinfo);
                alltags.Add(item);
            }
      
        }

        /// <summary>
        /// 应该来自于数据库
        /// </summary>
        public void InitData()
        {
            string[] tagIDs_01 = { "34708968", "34710263" };
            CarInfo car1 = new CarInfo("A1201", "湛钢J0111", tagIDs_01);
            AddCarDictionary(car1);

            string[] tagIDs_02 = { "34708784", "34709454" };
            CarInfo car2 = new CarInfo("A1202", "湛钢J0112", tagIDs_02);
            AddCarDictionary(car2);

            //不存在
            string[] tagIDs_03 = { "34709740", "34710280" };
            CarInfo car3 = new CarInfo("A1252", "湛钢J0152", tagIDs_03);
            AddCarDictionary(car3);

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
                sss += item.Key + ":" + item.Value.CarStatus.ToString() + "  "+ item.Value.ReadTime.ToLongTimeString()+"\r\n";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rfidInfo"></param>
        /// <returns></returns>
        public string AddTag(string rfidInfo,out string curtagID)
        {

            string tagID = GetSubString(rfidInfo, "<TagBlink><TagID><![CDATA[", "]]></TagID><Time>");
            curtagID = tagID;

            if (tagID != "") //重复的不会加入
                alltags.Add(tagID);

            //看看有无RFID出入库区：，查找关键字<WherePortID>
            string str = "<WherePortID>";
            int index = rfidInfo.IndexOf(str);

            if (index!=-1) //有RFID靠近出入道闸
            {
                //获得从哪个方向进出的
                string portID = GetSubString(rfidInfo, "<WherePortID><![CDATA[", "]]></WherePortID>");

                //先查找该tagID有没有在？
                if ( allcars.ContainsKey(tagID) )
                {
                    //有该tag ID 存在，证明是在库区里面，再判断信号时间
                    TimeSpan span = DateTime.Now.Subtract(allcars[tagID].ReadTime);

                    //小于60秒，应该是重复信号不处理
                    if(span.TotalSeconds >= 60 )
                    {
                        CarInfo car = allcars[tagID];

                        if (portID == "5011" || portID == "5012" || portID == "5013" || portID == "5014")
                            car.Door = "北通道门口";
                        else
                            car.Door = "南通道门口";

                        if (car.CarStatus == 1)  //从库区内要出去
                        {
                            car.CarStatus = 0; //出库则删除
                            return "【" + tagID + "】要出库，已经更新状态，通道口："+car.Door;
                        }else if(car.CarStatus == 0)  //从库区内要出去
                        {
                            car.CarStatus = 1; //出库则删除
                            return "【" + tagID + "】要入库，已经更新状态，通道口：" + car.Door;
                        }
                    }
                }
            }//ends if
            return "";
        }
    }
}
