using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UACSUtility
{
    public class ColorSln
    {
        static public Color BlueBlack = Color.FromArgb(40, 79, 80);          //蓝黑
        static public Color LightGray = Color.FromArgb(230, 230, 230);       //亮灰
        static public Color SkyBlue = Color.FromArgb(96, 173, 174);       //天蓝
        static public Color WhiteGray = Color.FromArgb(235, 235, 215);      //白灰
        static public Color PurpleRed = Color.FromArgb(205, 0, 103);        //紫红
        static public Color SeaBlue = Color.FromArgb(51, 102, 153);       //海蓝
        static public Color LightCoffee = Color.FromArgb(140, 140, 70);       //淡咖啡
        static public Color LightRed = Color.FromArgb(255, 135, 195);     //淡红
        static public Color LightBlue = Color.FromArgb(165, 195, 225);     //淡蓝
        static public Color PaleWaterGreen = Color.FromArgb(0xd4, 0xef, 0xff);     //淡水绿
        static public Color LightGreen = Color.FromArgb(0xff, 0xfa, 0xcd);  //亮绿
        static public Color LightOrange  = Color.FromArgb(0xD8,0X46,0X00);  //亮橙
        static public Color GradualGreen = Color.FromArgb(209, 215, 170);      //渐绿
        static public Color KingPurple = Color.FromArgb(0x8d, 0x7f, 0xff);     //气质紫

        static public Color FormBgColor = Color.FromArgb(242, 246, 252);                    //窗体背景色
        static public Color ControlContainerBgColor = Color.FromArgb(249,249,249);          //控件容器背景色
        static public Color ControlContainerBorderColor = Color.FromArgb(182,198,221);     //控件容器边框色

        public static Color BtnBgColor = Color.FromArgb(66, 101, 175);                      //扁平按钮背景色

        static public Color GridBorderColor = Color.FromArgb(182,198,221);                  //表格边框色
        static public Color GridInnerBorderColor = Color.FromArgb(204, 204, 204);           //表格内边框色
        static public Color GridNormalColor = Color.FromArgb(245,245,245);                  //表格正常背景色
        static public Color GridAltColor = Color.FromArgb(255,255,255);                     //表格交替背景色
        static public Color GridHeaderColor = Color.FromArgb(217,225,237);                  //表格标题背景色
        static public Color GridColHeaderNormalColor = Color.FromArgb(230, 235, 244);       //表格列标题正常背景色
        static public Color GridColHeaderAltColor = Color.FromArgb(217, 225, 237);          //表格列标题交替背景色
        static public Color FontTextColor = Color.FromArgb(51,51,51);                       //表格交替背景色

        public static Color c1AreaZoneBgColor = Color.FromArgb(239,241,244);                    //机组背景
        public static Color c1AreaZoneFontColor_Unlock = Color.FromArgb(142, 165, 188);         //机组边框

        public static Color c1ArealblBorderColor_Unlock = Color.FromArgb(142, 165, 188);        //区域边框
        public static Color c1ArealblBgColor = Color.FromArgb(239, 241, 244);                   //区域背景

        public static Color c1ChannelZoneBgColor = Color.DarkGray;
        public static Color c1ChannelZoneFontColor = Color.FromArgb(142,165,188);

        public static Color SaddleOccupy = Color.SteelBlue;
        public static Color SaddleReserve = Color.DarkKhaki;
        public static Color SaddleEmpty = Color.Gainsboro;


        static public Color c1ParkingBgColor = Color.DarkSeaGreen;                     //停车位背景色
        static public Color c1ParkingFontColor = Color.White;                          //停车位前景色


        static public Color c1CraneCarBorderColor = Color.CornflowerBlue;              //行车小车边界色

        public static Color Lock = Color.FromArgb(255,106,106);
        public static Color Unlock = Color.FromArgb(242, 246, 252);
        public static Color WaitJudge = Color.DarkOrange;


        public static Color DatafridviewBack = System.Drawing.SystemColors.Info;      //Datagridview背景颜色

    }
}
