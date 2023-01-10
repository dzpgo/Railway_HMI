using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{

    /// <summary>
    /// 小区基类
    /// </summary>
    public class AreaBase : ICloneable
    {
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public AreaBase Clone()
        {
            return (AreaBase)this.MemberwiseClone();
        }
        private string areaNo;
        /// <summary>
        /// 小区
        /// </summary>
        public string AreaNo
        {
            get { return areaNo; }
            set { areaNo = value; }
        }

        private string bayNo;
        /// <summary>
        /// 跨别
        /// </summary>
        public string BayNo
        {
            get { return bayNo; }
            set { bayNo = value; }
        }


        private long x_Start;
        /// <summary>
        /// X起
        /// </summary>
        public long X_Start
        {
            get { return x_Start; }
            set { x_Start = value; }
        }

        private long x_End;
        /// <summary>
        /// X终
        /// </summary>
        public long X_End
        {
            get { return x_End; }
            set { x_End = value; }
        }

        private long y_Start;
        /// <summary>
        /// Y起
        /// </summary>
        public long Y_Start
        {
            get { return y_Start; }
            set { y_Start = value; }
        }

        private long y_End;
        /// <summary>
        /// Y终
        /// </summary>
        public long Y_End
        {
            get { return y_End; }
            set { y_End = value; }
        }


        private long areaWidth;
        /// <summary>
        /// 小区宽度
        /// </summary>
        public long AreaWidth
        {
            get { return areaWidth; }
            set 
            {
                areaWidth = value;
            }
        }

        private long areaLength;
        /// <summary>
        /// 小区长度
        /// </summary>
        public long AreaLength
        {
            get { return areaLength; }
            set
            {
                areaLength = value;
            }
        }



        private long areaHeight;
        /// <summary>
        /// 小区高度
        /// </summary>
        public long AreaHeight
        {
            get { return areaHeight; }
            set
            {
                areaHeight = value;
            }
        }

        private bool parkingStatus;
        /// <summary>
        /// 停车位状态
        /// </summary>
        public bool ParkingStatus
        {
            get { return parkingStatus; }
            set
            {
                parkingStatus = value;
            }
        }


        private string carNo;
        /// <summary>
        /// 框架车号
        /// </summary>
        public string CarNo
        {
            get { return carNo; }
            set { carNo = value; }
        }

        private int isLoaded;
        /// <summary>
        /// 框架空满标记
        /// </summary>
        public int IsLoaded
        {
            get { return isLoaded; }
            set { isLoaded = value; }
        }
        


        


        public string LblText { get; set; }


        /// <summary>
        /// Z32跨连退(D212)入口小区编号
        /// </summary>
        public const string Z32_D212VR = "D212VR-Z32";
        /// <summary>
        /// Z32跨热镀锌(D308)入口小区编号
        /// </summary>
        public const string Z32_D308VR = "D308WR-Z32";
        /// <summary>
        /// Z32跨T1停车位
        /// </summary>
        public const string Z32_1_T1 = "Z32-1-T1";
        /// <summary>
        /// Z32跨T2停车位
        /// </summary>
        public const string Z32_1_T2 = "Z32-1-T2";
        /// <summary>
        /// Z32跨D202出口
        /// </summary>
        public const string Z32_D202VC = "D202WC-Z32";
        /// <summary>
        /// Z33跨D118入口
        /// </summary>
        public const string Z33_D118VR = "D118VR-Z33";
        /// <summary>
        /// Z33跨D218入口
        /// </summary>
        public const string Z33_D218VR = "D218VR-Z33";
        /// <summary>
        /// Z33跨D202出口
        /// </summary>
        public const string Z33_D202WC = "D202WC-Z33";
        /// <summary>
        /// Z33跨T1停车位
        /// </summary>
        public const string Z33_1_T1 = "Z33-1-T1";
    }
}
