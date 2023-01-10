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
    public partial class conParkingSpace : UserControl
    {
        public delegate void EventHandler_Parking_Selected(AreaBase theAreaInfo);
        public event EventHandler_Parking_Selected Parking_Selected;
        private AreaBase myParkingInfo = new AreaBase();
        public conParkingSpace()
        {
            InitializeComponent();
            this.SetStyle(
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.AllPaintingInWmPaint, true);
        }
        public void conInit()
        {
            try
            {
                this.MouseDown += new MouseEventHandler(conSaddle_visual_MouseUp);
            }
            catch (Exception ex)
            {
            }
        }

        void conSaddle_visual_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (Parking_Selected != null)
                    {
                        Parking_Selected(myParkingInfo.Clone());
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
            }
        }

        public delegate void ParkingSpaceRefreshInvoke(AreaBase _theParking, Panel _panel, long baySpaceX, long baySpaceY, bool _xAxisRight, bool _yAxisDown);

         public void refreshControl(AreaBase _theParking, Panel _panel,long baySpaceX, long baySpaceY ,bool _xAxisRight, bool _yAxisDown)
         {
             try
             {
                 myParkingInfo = _theParking;



                 //计算X方向上的比例关系
                 double xScale = Convert.ToDouble(_panel.Width) / Convert.ToDouble(baySpaceX);

                 //计算中心X，区分为X坐标轴向左或者向右
                 double location_X = 0;
                 if (_xAxisRight == true)
                     location_X = Convert.ToDouble(_theParking.X_Start) * xScale;
                 //else
                 //    location_X = Convert.ToDouble(baySpaceX - (_theSaddle.X_Center + _theSaddle.SaddleLength / 2)) * xScale;

                 //计算Y方向的比例关系
                 double yScale = Convert.ToDouble(_panel.Height) / Convert.ToDouble(baySpaceY);

                 //计算中心Y 区分Y坐标轴向上或者向下
                 double location_Y = 0;
                 if (_yAxisDown == true)
                     location_Y = (_theParking.Y_Start) * yScale;
                 //else
                 //    location_Y = (baySpaceY - (_theSaddle.Y_Center + _theSaddle.SaddleWidth / 2)) * yScale;

                 //修改控件的宽度和高度
                 this.Width = Convert.ToInt32(_theParking.AreaLength * xScale);
                 this.Height = Convert.ToInt32(_theParking.AreaWidth* yScale);

                 //停车位有车
                 if (_theParking.ParkingStatus)
                     this.pictureBox1.Image = global::CONTROLS_OF_REPOSITORIES.Resources.greenBall_small;                  
                 else
                 {
                     this.pictureBox1.Image = global::CONTROLS_OF_REPOSITORIES.Resources.redBall_small;
                     conParkingSpace_MouseMove(null, null);
                 }

                 this.Paint += conParkingSpace_Paint;
                 //定位坐标
                 this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y));
                 this.BackColor = Color.LightSteelBlue;


             }
             catch (Exception er)
             {
             }

         }

         void conParkingSpace_Paint(object sender, PaintEventArgs e)
         {
             string carNo = string.Empty;
             Graphics gr = e.Graphics;
             StringFormat sf = new StringFormat();
             sf.LineAlignment = StringAlignment.Center;
             sf.Alignment = StringAlignment.Center;

             if (myParkingInfo.ParkingStatus)
             {
                 if (myParkingInfo.IsLoaded == 0)
                 {
                     carNo = myParkingInfo.CarNo + "(出库)";
                 }
                 else
                 {
                     carNo = myParkingInfo.CarNo + "(入库)";
                 }
                 gr.DrawString(carNo, new Font("微软雅黑", 10, FontStyle.Bold), 
                     Brushes.Blue, this.ClientRectangle, sf);
             }                   
         }


         protected override void OnPaint(PaintEventArgs e)
         {
             base.OnPaint(e);
             Graphics gr = e.Graphics;
             StringFormat sf = new StringFormat();
             sf.LineAlignment = StringAlignment.Far;
             sf.Alignment = StringAlignment.Center;
             //gr.DrawString(myParkingInfo.AreaNo.ToString(), new Font("微软雅黑", 10, FontStyle.Bold), Brushes.Red, this.ClientRectangle, sf);
             gr.DrawString(myParkingInfo.AreaNo.ToString(), new Font("微软雅黑", 10, FontStyle.Bold), Brushes.White, new Point(0,this.Height - 18));
             Pen p1 = new Pen(Color.Orange, 1);
             gr.DrawLine(p1, 0, 0, this.Width, 0);
             gr.DrawLine(p1, 1, this.Height-1, this.Width, this.Height-1);
             gr.DrawLine(p1, 0, 0, 0, this.Height);
             gr.DrawLine(p1, this.Width-1, 1, this.Width-1, this.Height);

         }

         private void conParkingSpace_MouseLeave(object sender, EventArgs e)
         {
             this.BackColor = Color.LightSteelBlue;
         }

         private void conParkingSpace_MouseMove(object sender, MouseEventArgs e)
         {
             this.BackColor = Color.Beige;
         } 

    }
}
