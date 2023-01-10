using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    public class CarMessageBase
    {
        /// <summary>
        /// 车宽
        /// </summary>
        public int CarWidth { get; set; }

        /// <summary>
        /// 车长
        /// </summary>
        public int CarLength { get; set; }


        public int X_Center { get; set; }


        public int Y_Center { get; set; }
    }
}
