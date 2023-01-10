using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    public class SaddleStrategyType
    {

        private int id;
        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string desc;
        /// <summary>
        /// 区域描述
        /// </summary>
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
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

        private int xMin;
        /// <summary>
        /// X最小
        /// </summary>
        public int XMin
        {
            get { return xMin; }
            set { xMin = value; }
        }

        private int xMax;
        /// <summary>
        /// X最大
        /// </summary>
        public int XMax
        {
            get { return xMax; }
            set { xMax = value; }
        }


        private int yMin;
        /// <summary>
        /// Y最小
        /// </summary>
        public int YMin
        {
            get { return yMin; }
            set { yMin = value; }
        }


        private int yMax;
        /// <summary>
        /// Y最大
        /// </summary>
        public int YMax
        {
            get { return yMax; }
            set { yMax = value; }
        }

        private string xDir;
        /// <summary>
        /// X寻找方向
        /// </summary>
        public string XDir
        {
            get { return xDir; }
            set { xDir = value; }
        }

        private int yCenter;
        /// <summary>
        /// 参考中心Y
        /// </summary>
        public int YCenter
        {
            get { return yCenter; }
            set { yCenter = value; }
        }

        private int minEmptySaddle;
        /// <summary>
        /// 最少鞍座数
        /// </summary>
        public int MinEmptySaddle
        {
            get { return minEmptySaddle; }
            set { minEmptySaddle = value; }
        }
        
    }
}
