using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    /// <summary>
    /// 鞍座基类
    /// </summary>
    public class SaddleBase : ICloneable
    {

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public SaddleBase Clone()
        {
            return (SaddleBase)this.MemberwiseClone();
        }

        private string saddleNo;
        /// <summary>
        /// 鞍座号
        /// </summary>
        public string SaddleNo
        {
            get { return saddleNo; }
            set { saddleNo = value; }
        }

        private string saddleName;
        /// <summary>
        /// 鞍座名称
        /// </summary>
        public string SaddleName
        {
            get { return saddleName; }
            set { saddleName = value; }
        }

        private int saddle_Seq;
        /// <summary>
        /// 鞍座序号
        /// </summary>
        public int Saddle_Seq
        {
            get { return saddle_Seq; }
            set { saddle_Seq = value; }
        }

        private int row_No;
        /// <summary>
        /// 行号
        /// </summary>
        public int Row_No
        {
            get { return row_No; }
            set { row_No = value; }
        }

        private int col_No;
        /// <summary>
        /// 列号
        /// </summary>
        public int Col_No
        {
            get { return col_No; }
            set { col_No = value; }
        }

        private long saddleWidth;
        /// <summary>
        /// 鞍座宽度
        /// </summary>
        public long SaddleWidth
        {
            get { return saddleWidth; }
            set { saddleWidth = value; }
        }

        private long saddleLength;
        /// <summary>
        /// 鞍座长度
        /// </summary>
        public long SaddleLength
        {
            get { return saddleLength; }
            set { saddleLength = value; }
        }


        private long x_Center;
        /// <summary>
        /// X中心点
        /// </summary>
        public long X_Center
        {
            get { return x_Center; }
            set { x_Center = value; }
        }

        private long y_Center;
        /// <summary>
        /// Y中心点
        /// </summary>
        public long Y_Center
        {
            get { return y_Center; }
            set { y_Center = value; }
        }

        private long z_Center;
        /// <summary>
        /// Z中心点
        /// </summary>
        public long Z_Center
        {
            get { return z_Center; }
            set { z_Center = value; }
        }

        private int stock_Status;
        /// <summary>
        /// 库位状态
        /// </summary>
        public int Stock_Status
        {
            get { return stock_Status; }
            set { stock_Status = value; }
        }

        private int lock_Flag;
        /// <summary>
        /// 封锁标记
        /// </summary>
        public int Lock_Flag
        {
            get { return lock_Flag; }
            set { lock_Flag = value; }
        }


        private string mat_No;
        /// <summary>
        /// 材料号
        /// </summary>
        public string Mat_No
        {
            get { return mat_No; }
            set
            {
                mat_No = value;
            }
        }

        private string next_Unit_No;
        /// <summary>
        /// 下道机组
        /// </summary>
        public string Next_Unit_No
        {
            get { return next_Unit_No; }
            set
            {
                next_Unit_No = value;
            }
        }

        private string tagAdd_IsOccupied;
        /// <summary>
        /// 鞍座占位信号点地址
        /// </summary>
        public string TagAdd_IsOccupied
        {
            get
            {
                return tagAdd_IsOccupied;
            }
            set
            {
                tagAdd_IsOccupied = value;
            }
        }

        private long tagVal_IsOccupied;
        /// <summary>
        /// 鞍座占位信号点值
        /// </summary>
        public long TagVal_IsOccupied
        {
            get
            {
                return tagVal_IsOccupied;
            }
            set
            {
                tagVal_IsOccupied = value;
            }
        }

        private string coilNO;
        /// <summary>
        /// 钢卷号
        /// </summary>
        public string CoilNO
        {
            get
            {
                return coilNO;
            }
            set
            {
                coilNO = value;
            }
        }
        /// <summary>
        /// 物流流向标记位
        /// </summary>
        private int logisticsFlag;

        public int LogisticsFlag
        {
            get { return logisticsFlag; }
            set { logisticsFlag = value; }
        }  
        public const long Z32baySpaceX = 210000;
        public const long Z32baySpaceY = 34000;

        public const long Z33baySpaceX = 120000;
        public const long Z33baySpaceY = 37000;

        public const long Z51baySpaceX = 500000;
        public const long Z51baySpaceY = 45000;

        public const long Z52baySpaceX = 500000;
        public const long Z52baySpaceY = 42000;

        public const long Z53baySpaceX = 410000;
        public const long Z53baySpaceY = 42000;


        public const long RailwayAbaySpaceX = 330000;
        public const long RailwayAbaySpaceY = 45000;





        public const bool xAxisRight = true;
        public const bool yAxisDown = true;

        public const string bayNo_Z32 = "Z32-1";
        public const string bayNo_Z33 = "Z33-1";
        public const string bayNo_Z51 = "Z51-1";
        public const string bayNo_Z52 = "Z52-1";
        public const string bayNo_Z53 = "Z53-1";

        public const string BayNo_RailwayA = "A-1";

        /// <summary>
        /// 平台tag名称
        /// </summary>
        public const string tagServiceName = "iplature";
    }
}
