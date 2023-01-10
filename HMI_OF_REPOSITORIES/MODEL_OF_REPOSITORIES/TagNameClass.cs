using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    public class TagNameClass
    {
        #region 通道门
        /// <summary>
        /// 4_1门(靠近Z33跨的门) 
        /// </summary>
        public const string tag_4_1_Door = "Z33_ULTRAHEIGHT_G_4_1";
        /// <summary>
        /// 4_2门(靠近Z32跨到成品库的门T2)
        /// </summary>
        public const string tag_4_2_Door = "Z33_ULTRAHEIGHT_G_4_2";
        /// <summary>
        /// 4_3门(Z32跨T2进来门)
        /// </summary>
        public const string tag_4_3_Door = "Z33_ULTRAHEIGHT_G_4_3";
        /// <summary>
        /// 4_4门(Z32跨T1进来门)
        /// </summary>
        public const string tag_4_4_Door = "Z33_ULTRAHEIGHT_G_4_4";
        /// <summary>
        /// 4_5门(Z32跨靠近D202机组的门)
        /// </summary>
        public const string tag_4_5_Door = "Z33_ULTRAHEIGHT_G_4_5";

        /// <summary>
        /// Z32与Z33相连通道的门
        /// </summary>
        public const string tag_Z32_Z33_Door = "Z32_Z33_ULTRAHEIGHT_MID";
        /// <summary>
        /// 铁路库A跨道闸
        /// </summary>
        public const string tag_DAOZHA_A_NORTH_CLOSE = "DAOZHA_A_NORTH_CLOSE";
        /// <summary>
        /// 铁路库A跨道闸
        /// </summary>
        public const string tag_DAOZHA_A_NORTH_OPEN = "DAOZHA_A_NORTH_OPEN";
        /// <summary>
        /// 铁路库A跨道闸
        /// </summary>
        public const string tag_DAOZHA_A_SOUTH_CLOSE = "DAOZHA_A_SOUTH_CLOSE";
        /// <summary>
        /// 铁路库A跨道闸
        /// </summary>
        public const string tag_DAOZHA_A_SOUTH_OPEN = "DAOZHA_A_SOUTH_OPEN";
        //C跨
        /// <summary>
        /// 铁路库C跨道闸
        /// </summary>
        public const string tag_DAOZHA_C_NORTH_CLOSE = "DAOZHA_C_NORTH_CLOSE";
        /// <summary>
        /// 铁路库C跨道闸
        /// </summary>
        public const string tag_DAOZHA_C_NORTH_OPEN = "DAOZHA_C_NORTH_OPEN";
        /// <summary>
        /// 铁路库C跨道闸
        /// </summary>
        public const string tag_DAOZHA_C_SOUTH_CLOSE = "DAOZHA_C_SOUTH_CLOSE";
        /// <summary>
        /// 铁路库C跨道闸
        /// </summary>
        public const string tag_DAOZHA_C_SOUTH_OPEN = "DAOZHA_C_SOUTH_OPEN"; 
        #endregion


        #region 安全门
        /// <summary>
        /// Z32跨A区预定
        /// </summary>
        public const string tag_Area_Reserve_Z32_A = "AREA_RESERVE_Z32_A";

        /// <summary>
        /// Z32跨B区预定
        /// </summary>
        public const string tag_Area_Reserve_Z32_B = "AREA_RESERVE_Z32_B";

        /// <summary>
        /// Z32跨C区预定
        /// </summary>
        public const string tag_Area_Reserve_Z32_C = "AREA_RESERVE_Z32_C";

        /// <summary>
        /// Z32跨D区预定
        /// </summary>
        public const string tag_Area_Reserve_Z32_D = "AREA_RESERVE_Z32_D";

        /// <summary>
        /// Z32跨E区预定
        /// </summary>
        public const string tag_Area_Reserve_Z32_E = "AREA_RESERVE_Z32_E";

        /// <summary>
        /// Z32跨F区预定
        /// </summary>
        public const string tag_Area_Reserve_Z32_F = "AREA_RESERVE_Z32_F";

        /// <summary>
        /// Z32跨G区预定
        /// </summary>
        public const string tag_Area_Reserve_Z32_G = "AREA_RESERVE_Z32_G";

        /// <summary>
        /// Z33跨I区预定
        /// </summary>
        public const string tag_Area_Reserve_Z33_I = "AREA_RESERVE_Z33_I";

        /// <summary>
        /// Z33跨J区预定
        /// </summary>
        public const string tag_Area_Reserve_Z33_J = "AREA_RESERVE_Z33_J";

        /// <summary>
        /// Z33跨K区预定
        /// </summary>
        public const string tag_Area_Reserve_Z33_K = "AREA_RESERVE_Z33_K";

        /// <summary>
        /// Z33跨L区预定
        /// </summary>
        public const string tag_Area_Reserve_Z33_L = "AREA_RESERVE_Z33_L";

        /// <summary>
        /// Z33跨M区预定
        /// </summary>
        public const string tag_Area_Reserve_Z33_M = "AREA_RESERVE_Z33_M";

        /// <summary>
        /// Z32跨A区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z32_A = "AREA_SAFE_Z32_A";
        /// <summary>
        /// Z32跨B区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z32_B = "AREA_SAFE_Z32_B";
        /// <summary>
        /// Z32跨C区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z32_C = "AREA_SAFE_Z32_C";
        /// <summary>
        /// Z32跨D区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z32_D = "AREA_SAFE_Z32_D";
        /// <summary>
        /// Z32跨E区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z32_E = "AREA_SAFE_Z32_E";
        /// <summary>
        /// Z32跨F区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z32_F = "AREA_SAFE_Z32_F";
        /// <summary>
        /// Z32跨G区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z32_G = "AREA_SAFE_Z32_G";
        /// <summary>
        /// Z33跨I区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z33_I = "AREA_SAFE_Z33_I";
        /// <summary>
        /// Z33跨J区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z33_J = "AREA_SAFE_Z33_J";
        /// <summary>
        /// Z33跨K区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z33_K = "AREA_SAFE_Z33_K";
        /// <summary>
        /// Z33跨L区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z33_L = "AREA_SAFE_Z33_L";
        /// <summary>
        /// Z33跨M区是否安全
        /// </summary>
        public const string tag_Area_Safe_Z33_M = "AREA_SAFE_Z33_M";
        /// <summary>
        /// 铁路库安全门
        /// </summary>
        public const string tag_AREA_SAFE_A_A = "AREA_SAFE_A_A";
        /// <summary>
        /// 铁路库安全门
        /// </summary>
        public const string tag_AREA_SAFE_A_B = "AREA_SAFE_A_B";
        /// <summary>
        /// 铁路库安全门
        /// </summary>
        public const string tag_AREA_SAFE_A_C = "AREA_SAFE_A_C";
        /// <summary>
        /// 铁路库安全门
        /// </summary>
        public const string tag_AREA_SAFE_A_D = "AREA_SAFE_A_D";
        /// <summary>
        /// 铁路库安全门
        /// </summary>
        public const string tag_AREA_SAFE_A_E = "AREA_SAFE_A_E";
        /// <summary>
        /// 铁路库安全门
        /// </summary>
        public const string tag_AREA_SAFE_A_F = "AREA_SAFE_A_F";
        /// <summary>
        /// 铁路库安全门
        /// </summary>
        public const string tag_AREA_SAFE_A_G = "AREA_SAFE_A_G";

        //C跨
        /// <summary>
        /// 铁路库安全门
        /// </summary>
        public const string tag_AREA_SAFE_C_A = "AREA_SAFE_C_A";
        public const string tag_AREA_SAFE_C_B = "AREA_SAFE_C_B";
        public const string tag_AREA_SAFE_C_C = "AREA_SAFE_C_C";
        public const string tag_AREA_SAFE_C_D = "AREA_SAFE_C_D";
        public const string tag_AREA_SAFE_C_E = "AREA_SAFE_C_E";
        public const string tag_AREA_SAFE_C_F = "AREA_SAFE_C_F";
        public const string tag_AREA_SAFE_C_G = "AREA_SAFE_C_G";



        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_1_waterLevel_Flag = "1_waterLevel_Flag";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_2_waterLevel_Flag = "2_waterLevel_Flag";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_3_waterLevel_Flag = "3_waterLevel_Flag";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_7_waterLevel_Flag = "7_waterLevel_Flag";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_8_waterLevel_Flag = "8_waterLevel_Flag";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_1_DownLoadWater = "1_DownLoadWater";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_2_DownLoadWater = "2_DownLoadWater";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_3_DownLoadWater = "3_DownLoadWater";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_7_DownLoadWater = "7_DownLoadWater";
        /// <summary>
        /// 铁路库行车水位
        /// </summary>
        public const string tag_8_DownLoadWater = "8_DownLoadWater";
        /// <summary>
        /// 行车吊具类型
        /// </summary>
        public const string tag_1_clamp_sucker_switch = "1_clamp_sucker_switch";
        /// <summary>
        /// 行车吊具类型
        /// </summary>
        public const string tag_2_clamp_sucker_switch = "2_clamp_sucker_switch";
        /// <summary>
        /// 行车吊具类型
        /// </summary>
        public const string tag_7_clamp_sucker_switch = "7_clamp_sucker_switch";
        /// <summary>
        /// 行车吊具类型
        /// </summary>
        public const string tag_8_clamp_sucker_switch = "8_clamp_sucker_switch";
        /// <summary>
        /// 行车吊具类型
        /// </summary>
        public const string tag_1_DownLoadClampSucker = "1_DownLoadClampSucker";
        /// <summary>
        /// 行车吊具类型
        /// </summary>
        public const string tag_2_DownLoadClampSucker = "2_DownLoadClampSucker";
        /// <summary>
        /// 行车吊具类型
        /// </summary>
        public const string tag_7_DownLoadClampSucker = "7_DownLoadClampSucker";
        /// <summary>
        /// 行车吊具类型
        /// </summary>
        public const string tag_8_DownLoadClampSucker = "8_DownLoadClampSucker";
        /// <summary>
        /// 光电门
        /// </summary>
        public const string tag_AREA_SAFE_A_AB = "AREA_SAFE_A_AB";
        /// <summary>
        /// 光电门
        /// </summary>
        public const string tag_AREA_SAFE_A_CD = "AREA_SAFE_A_CD";
        /// <summary>
        /// 光电门
        /// </summary>
        public const string tag_AREA_SAFE_C_AB = "AREA_SAFE_C_AB";
        /// <summary>
        /// 光电门
        /// </summary>
        public const string tag_AREA_SAFE_C_CD = "AREA_SAFE_C_CD";
        /// <summary>
        /// 道闸
        /// </summary>
        public const string tag_DAOZHA_SOUTH_UPPER_LIMIT = "DAOZHA_SOUTH_UPPER_LIMIT";
        /// <summary>
        /// 道闸
        /// </summary>
        public const string tag_DAOZHA_SOUTH_LOWER_LIMIT = "DAOZHA_SOUTH_LOWER_LIMIT";
        /// <summary>
        /// 道闸
        /// </summary>
        public const string tag_DAOZHA_NORTH_UPPER_LIMIT = "DAOZHA_NORTH_UPPER_LIMIT";
        /// <summary>
        /// 道闸
        /// </summary>
        public const string tag_DAOZHA_NORTH_LOWER_LIMIT = "DAOZHA_NORTH_LOWER_LIMIT";
        //C跨
        /// <summary>
        /// 道闸
        /// </summary>
        public const string tag_C_DAOZHA_SOUTH_UPPER_LIMIT = "C_DAOZHA_SOUTH_UPPER_LIMIT";
        /// <summary>
        /// 道闸
        /// </summary>
        public const string tag_C_DAOZHA_SOUTH_LOWER_LIMIT = "C_DAOZHA_SOUTH_LOWER_LIMIT";
        /// <summary>
        /// 道闸
        /// </summary>
        public const string tag_C_DAOZHA_NORTH_UPPER_LIMIT = "C_DAOZHA_NORTH_UPPER_LIMIT";
        /// <summary>
        /// 道闸
        /// </summary>
        public const string tag_C_DAOZHA_NORTH_LOWER_LIMIT = "C_DAOZHA_NORTH_LOWER_LIMIT";

        #endregion


        #region 起落卷动作
        /// <summary>
        /// Z33跨落卷动作
        /// </summary>
        public const string tag_Z33_Coil_Down = "Z33_COIL_DOWN";
        /// <summary>
        /// Z33跨起卷动作
        /// </summary>
        public const string tag_Z33_Coil_Up = "Z33_COIL_UP";
        /// <summary>
        /// Z32跨落卷动作
        /// </summary>
        public const string tag_Z32_Coil_Down = "Z32_COIL_DOWN";
        /// <summary>
        /// Z32跨起卷动作
        /// </summary>
        public const string tag_Z32_Coil_Up = "Z32_COIL_UP";
        /// <summary>
        /// 行车模式切换
        /// </summary>
        public const string tag_CraneMode = "DownLoadShortCommand"; 
        #endregion
    }
}
