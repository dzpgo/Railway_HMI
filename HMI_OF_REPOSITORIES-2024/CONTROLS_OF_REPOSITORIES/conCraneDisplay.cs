using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class conCraneDisplay : UserControl
    {
        public conCraneDisplay()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                return parms;
            }
        }    
        //private long craneWith = 0;
        Label lbl = new Label();
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
        private long cranesDistain = 0;

        public long CranesDistain   //行车间距
        {
            get { return cranesDistain; }
            set { cranesDistain = value; }
        }
        private long craneXAct = 0;  //行车当前位置

        public long CraneXAct
        {
            get { return craneXAct; }
            set { craneXAct = value; }
        }
        //step3
        public delegate void RefreshControlInvoke(CraneStatusBase cranePLCStatusBase, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, long craneWith, Panel panel);

        public void RefreshControl(CraneStatusBase cranePLCStatusBase, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown,long craneWith,Panel panel)
        {
            try
            {
                craneXAct = cranePLCStatusBase.XAct;
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
                this.Height = panelHeight - 20;//大车的高度直接等于panel的高度

                //定位大车的坐标
                this.Location = new Point(Convert.ToInt32(location_Crane_X), Convert.ToInt32(location_Crane_Y));


                //修改小车的宽度
                panelCrab.Width = this.Width;

                //定位小车的坐标
                panelCrab.Location = new Point(Convert.ToInt32(location_Crab_X), Convert.ToInt32(location_Crab_Y));
                panelCrab.BringToFront();

                //无卷显示无卷标记
                if (cranePLCStatusBase.HasCoil == 0)
                {
                    this.panelCrab.BackgroundImage = global::CONTROLS_OF_REPOSITORIES.Resources.imgCarNoCoil;
                }
                //有卷显示有卷标记
                else if (cranePLCStatusBase.HasCoil == 1)
                {
                    this.panelCrab.BackgroundImage = global::CONTROLS_OF_REPOSITORIES.Resources.imgCarCoil;
                }

                Control sk = GetPbControl(cranePLCStatusBase.CraneNO);
                if (sk == null)
                {
                    lbl.Name = cranePLCStatusBase.CraneNO;
                    
                    lbl.BackColor = Color.Transparent;
                    //lbl.Size =
                    lbl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    panel.Controls.Add(lbl);
                }
                lbl.Text = cranePLCStatusBase.CraneNO + "# " + CranesDistain.ToString("0,000");//
                if (CranesDistain<40000)
                {
                    lbl.ForeColor = Color.Red;
                }
                else
                {
                    lbl.ForeColor = Color.White;
                }
                lbl.Location = new Point(Convert.ToInt32(location_Crane_X), Convert.ToInt32(location_Crane_Y + this.Height));
                lbl.BringToFront();
                

                this.BringToFront();

            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 通过控件名获取控件
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        private Control GetPbControl(string strName)
        {
            string pbName = strName;
            return GetControl(this, pbName);
        }

        /// <summary>
        /// 通过控件名获取控件
        /// </summary>
        /// <param name="ct">控件所在的容器或者窗体</param>
        /// <param name="name">需要查找的控件名</param>
        /// <returns></returns>
        public static Control GetControl(Control ct, string name)
        {
            Control[] ctls = ct.Controls.Find(name, false);
            if (ctls.Length > 0)
            {
                return ctls[0];
            }
            else
            {
                return null;
            }
        }

        public long calculateCraneDistain(long  craneNeighborDist)
        {
            
            cranesDistain = Math.Abs(craneXAct - craneNeighborDist);
            return cranesDistain;
        }
    }
}
