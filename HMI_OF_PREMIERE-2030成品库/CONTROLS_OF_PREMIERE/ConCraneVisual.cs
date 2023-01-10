using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MODULES_OF_PREMIERE;


namespace CONTROLS_OF_PREMIERE
{
    public partial class ConCraneVisual : UserControl
    {
        public ConCraneVisual()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }



        private long craneWith = 4500;



        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        //step1
        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {
            }
        }


        private string craneNO = string.Empty;
        //step2
        public string CraneNO
        {
            get { return craneNO; }
            set { craneNO = value; }
        }

        //step3
        public delegate void RefreshControlInvoke(CranePLCStatusBase cranePLCStatusBase, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown);

        public void RefreshControl(CranePLCStatusBase cranePLCStatusBase, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown)
        {
            try
            {


                //0----------------------------------------------------------->X
                //       X_Start    X_End
                //       location.x
                //
                //X<----------------------------------------------------------0
                //       X_End      X_Start
                //       location.x

                //计算X方向上的比例关系
                double xScale = Convert.ToDouble(panelWidth) / Convert.ToDouble(baySpaceX);

                //计算控件行车中心X，区分为X坐标轴向左或者向右
                double X = 0;
                double location_Crane_X = 0;
                double location_Crab_X = 0;
                if (xAxisRight == true)
                {
                    X = Convert.ToDouble(cranePLCStatusBase.XAct) * xScale;
                    location_Crane_X = Convert.ToDouble(cranePLCStatusBase.XAct - craneWith / 2) * xScale;
                    location_Crab_X = 0;//在行车panel内，所以永远为0
                }
                else
                {
                    X = (Convert.ToDouble(baySpaceX) - Convert.ToDouble(cranePLCStatusBase.XAct)) * xScale;
                    location_Crane_X = Convert.ToDouble(cranePLCStatusBase.XAct + craneWith / 2) * xScale;
                    location_Crab_X = 0;//在行车panel内，所以永远为0
                }




                //      |
                //      |  Y_Start   location.Y
                //      | 
                //      |  Y_End
                //      |
                //      V


                //      A
                //      |  Y_End   location.Y
                //      | 
                //      |  Y_Start
                //      |

                //计算Y方向的比例关系
                double yScale = Convert.ToDouble(panelHeight) / Convert.ToDouble(baySpaceY);

                //计算行车中心Y 区分Y坐标轴向上或者向下
                double Y = 0;
                double location_Crane_Y = 0;
                double location_Crab_Y = 0;
                if (yAxisDown == true)
                {
                    Y = Convert.ToDouble(cranePLCStatusBase.YAct) * yScale;
                    location_Crane_Y = 0;
                    location_Crab_Y = Y - panelCrab.Height / 2;
                }
                else
                {
                    Y = (Convert.ToDouble(baySpaceY) - Convert.ToDouble(cranePLCStatusBase.YAct)) * yScale;
                    location_Crane_Y = 0;
                    location_Crab_Y = Y - panelCrab.Height / 2;
                }




                //修改行车大车控件的宽度和高度
                this.Width = Convert.ToInt32(craneWith * xScale);
                this.Height = panelHeight;//大车的高度直接等于panel的高度

                //定位大车的坐标
                this.Location = new Point(Convert.ToInt32(location_Crane_X), Convert.ToInt32(location_Crane_Y));


                //修改小车的宽度
                panelCrab.Width = this.Width;
                //定位小车的坐标
                panelCrab.Location = new Point(Convert.ToInt32(location_Crab_X), Convert.ToInt32(location_Crab_Y));
                panelCrab.BringToFront();
                //显示行车号
                //txt_CraneNO.Text = cranePLCStatusBase.CraneNO.Substring(cranePLCStatusBase.CraneNO.Length - 1, 1);
                txt_CraneNO.Text = cranePLCStatusBase.CraneNO;

                //无卷显示无卷标记
                if (cranePLCStatusBase.HasCoil == 0)
                {
                    panelCrab.BackColor = Color.DarkBlue;
                }
                //有卷显示有卷标记
                else if (cranePLCStatusBase.HasCoil== 1)
                {
                    panelCrab.BackColor = Color.Brown;
                }

                this.BringToFront();
                //this.SendToBack();


            }
            catch (Exception ex)
            {
            }
        }




    }
}
