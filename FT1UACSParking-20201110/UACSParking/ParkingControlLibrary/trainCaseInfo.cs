using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkClassLibrary;

namespace UACSParking
{
    public partial class trainCaseInfo : UserControl
    {
        private ClsTrainCase clsTrainInfo = new ClsTrainCase();

        public ClsTrainCase ClsTrainInfo
        {
            get { return clsTrainInfo; }
            //set { clsTrainInfo = (ClsTrainCase)value.Clone(); }
        }
        public void setClsTrainInfo(ClsTrainCase valueClsTrainCase)
        {
            clsTrainInfo = (ClsTrainCase)valueClsTrainCase.Clone();
        }
        public trainCaseInfo()
        {
            InitializeComponent();
        }

        public void updataTrainInfo()
        {
            txtTainNum.Text = clsTrainInfo.TrainCaseNO + "-" + clsTrainInfo.TrainCaseName;
            txtTrainCaseType.Text = clsTrainInfo.Specification;
            txtStowageName.Text = clsTrainInfo.StowageName;
            txtStowageID.Text = clsTrainInfo.StowageID;
            
            txtLaserCaseWidth.Text = clsTrainInfo.TrainCaseSize.Height.ToString();
            txtLaserCaseLength.Text = clsTrainInfo.TrainCaseSize.Width.ToString();
            txtLaserFloorZ.Text =  clsTrainInfo.LaserFloorZ.ToString();

            txtLaserCaseLength.Text = clsTrainInfo.LaserTrainCaseSize.Width.ToString();
            txtLaserCaseWidth.Text = clsTrainInfo.LaserTrainCaseSize.Height.ToString();
            txtLaserFloorZ.Text = clsTrainInfo.LaserFloorZ.ToString();
            txtLaserCount.Text = clsTrainInfo.LaserCount.ToString();

            txtLength.Text = clsTrainInfo.TrainCaseSize.Width.ToString();
            txtWidth.Text = clsTrainInfo.TrainCaseSize.Height.ToString();
            txtFloorZ.Text = clsTrainInfo.TrainHeight.ToString();
            txtLaserCount.Text = clsTrainInfo.LaserCount.ToString();
            string temp = "";
            switch (clsTrainInfo.RailwayStatus)
            {          
                case 0:
                    temp = "无车皮";break;
                case 10:
                    temp = "车皮确认中"; break;
                case 20:
                    temp = "配载方案确认中"; break;
                case 30:
                    temp = "配载方案确认完"; break;
                case 40:
                    temp = "激光扫描完成"; break;
                default:
                    temp = "";
                    break;
            }
            txtStatus.Text = temp;
            temp = "";
            switch (clsTrainInfo.TrainCaseStatus)
            {

                case -10:
                    temp = "空"; break;
                case 0:
                    temp = "准备中"; break;
                case 10:
                    temp = "准备完成"; break;
                case 20:
                    temp = "钢卷选择完"; break;
                case 30:
                    temp = "作业开始"; break;
                case 40:
                    temp = "作业暂停"; break;
                case 50:
                    temp = "作业完成"; break;
                default:
                    temp = "";
                    break;
            }
            txtTrainCaseStatus.Text = temp;
        }

    }
}
