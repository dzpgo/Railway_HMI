using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    /// <summary>
    /// 配载图
    /// </summary>
    public class TruckStowageClass
    {
        /// <summary>
        /// 钢卷号
        /// </summary>
        public string  CoilNo { get; set; }
        /// <summary>
        /// 配载图ID
        /// </summary>
        public int StowageId { get; set; }
        /// <summary>
        /// X
        /// </summary>
        public int XCenter { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        public int YCenter { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int ZCenter { get; set; }
        /// <summary>
        /// 槽号
        /// </summary>
        public int GrooveId{ get; set; }

        public static List<string> listClickCoilNo = new List<string>();
    }
}
