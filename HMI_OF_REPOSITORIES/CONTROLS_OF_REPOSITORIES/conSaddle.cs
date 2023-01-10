using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;
using System.Drawing.Drawing2D;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class conSaddle : UserControl
    {
        public conSaddle()
        {
            InitializeComponent();
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, true);
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

        private SaddleBase mySaddleInfo = new SaddleBase();
        private Label lblRowNo = new Label();
        private Label lblColNo = new Label();
        private bool isCranteLblRowNo = false;
        private bool isCranteLblColNo = false;
        private double location_x;
        private double location_y;
        private Graphics gr;
        public delegate void EventHandler_Saddle_Selected(SaddleBase theSaddleInfo);
        public event EventHandler_Saddle_Selected Saddle_Selected;
        //20200509注释yezhiwei
        //private bool   double_deck = false ;
        //public bool  Double_deck
        //{
        //    get { return double_deck; }
        //    set { double_deck = value; }
        //}
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
                    if (Saddle_Selected != null)
                    {
                        Saddle_Selected(mySaddleInfo.Clone());
                    }
                }
                else
                {
                    FrmSaddleMetail FrmSaddleDetail = new FrmSaddleMetail();
                    FrmSaddleDetail.SaddleInfo = this.mySaddleInfo;
                    FrmSaddleDetail.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public delegate void saddlesRefreshInvoke(SaddleBase theSaddle, double X_Width, double Y_Height, AreaBase theArea, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel panel, List<int> list = null);

        public void refreshControl(SaddleBase theSaddle, double X_Width, double Y_Height, AreaBase theArea, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel panel, List<int> list = null)
        {
            try
            {



                //
                //附对象
                mySaddleInfo = theSaddle;


                //计算X方向上的比例关系
                double xScale = Convert.ToDouble(panelWidth - 40) / Convert.ToDouble(X_Width);

                //计算控件行车中心X，区分为X坐标轴向左或者向右
                double location_X = 0;
                if (xAxisRight == true)
                {
                    //SaddleWidth
                    location_X = Convert.ToDouble((theSaddle.X_Center - theSaddle.SaddleLength / 2) - (theArea.X_Start - 1000)) * xScale;
                }
                else
                {
                    //location_X = Convert.ToDouble(X_Width - (theSaddle.X_Center + theSaddle.SaddleLength / 2)) * xScale;
                }


                //计算Y方向的比例关系
                double yScale = Convert.ToDouble(panelHeight - 40) / Convert.ToDouble(Y_Height);

                //计算行车中心Y 区分Y坐标轴向上或者向下
                double location_Y = 0;
                if (yAxisDown == true)
                {
                    location_Y = ((theSaddle.Y_Center - theSaddle.SaddleWidth / 2) - theArea.Y_Start) * yScale;
                }
                else
                {
                    // location_Y = (Y_Height - (theSaddle.Y_Center + theSaddle.SaddleWidth / 2)) * yScale;
                }


                if (theSaddle.Stock_Status == 0 && theSaddle.Lock_Flag == 0 ) //无卷可用
                    this.BackColor = Color.White;
                else if (theSaddle.Stock_Status == 2 && theSaddle.Lock_Flag == 0)
                {
                    if (theSaddle.LogisticsFlag==1)
                    {
                        this.BackColor = Color.LightGreen;
                    }
                    else if (theSaddle.LogisticsFlag==2)
                    {
                         this.BackColor = Color.Pink;
                    }
                    else if (theSaddle.LogisticsFlag == 3)
                    {
                        this.BackColor = Color.Orange;
                    }
                    else if (theSaddle.LogisticsFlag == 4)
                    {
                        this.BackColor = Color.Peru;
                    }
                    else
                    {
                        this.BackColor = Color.Black;
                    }

                }//有卷可用
                    
                else
                    this.BackColor = Color.Red;

                //修改鞍座控件的宽度和高度
                this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale);
                this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale);

                //定位库位鞍座的坐标
                //20200508修改-----yezhiwei
                if ((theSaddle.SaddleNo.Substring(0, 4) == "FT36" || theSaddle.SaddleNo.Substring(0, 4) == "FT14"))
                { 
                    this.Location = new Point(Convert.ToInt32(location_X), (Convert.ToInt32(location_Y )- 14));
                }
                else
                { this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y)); }
                //this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y));

                this.BringToFront();

               // if (!isCranteLblRowNo)
                //{
                    //lblRowNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //lblRowNo.Width = 130;
                    //lblRowNo.Height = 130;
                    //lblRowNo.ForeColor = Color.Blue;
                    //lblRowNo.BorderStyle = BorderStyle.FixedSingle;
                    //panel.Controls.Add(lblRowNo);
                    //isCranteLblRowNo = true;
               // }
                //lblRowNo.Text = theSaddle.Row_No.ToString();
                //lblRowNo.Location = new Point(1, Convert.ToInt32(location_Y));

                //创建GDI+对象  
               // Graphics g = this.CreateGraphics();
                //绘制文本   文本         字体样式： 字体    字号 样式粗？斜？...  获取系统颜色       绘制到的座标点  
                //g.DrawString("aaa", new Font("微软雅黑", 9, FontStyle.Bold), Brushes.Blue, new Point(1,2);

                gr = panel.CreateGraphics();  
            //绘制文本   文本         字体样式： 字体    字号 样式粗？斜？...  获取系统颜色       绘制到的座标点  
                location_x = location_X;
                location_y = location_Y;
                panel.Paint += panel_Paint;

                toolTip1.IsBalloon = true;
                toolTip1.ReshowDelay = 0;
                //toolTip1.SetToolTip(this, "材料号：" + theSaddle.Mat_No + "\r"
                //                    + "库位：    " + theSaddle.SaddleNo.ToString()
                //                    + "\r" + theSaddle.Row_No.ToString() + "行" + "-" +stockRowFormat( theSaddle.Col_No) + "列，" + "\r"
                //                    + "坐标：" + "\r"
                //                    + "X = " + theSaddle.X_Center + "\r"
                //                    + "Y = " + theSaddle.Y_Center 
                //                   );
                //前面注释换种方法，进针对贴离开当前-----20200508叶志伟
                toolTip1.SetToolTip(this, "材料号：" + theSaddle.Mat_No + "\r"
                                    + "库位：    " + theSaddle.SaddleNo.ToString()
                                    + "\r" + theSaddle.SaddleNo.Substring(5, 1) + "行" + "-" + theSaddle.SaddleNo.Substring(6, 2) + "列，" + "\r"
                                    + "坐标：" + "\r"
                                    + "X = " + theSaddle.X_Center + "\r"
                                    + "Y = " + theSaddle.Y_Center
                                   );

            }
            catch (Exception er)
            {

                throw;
            }
        }

        void panel_Paint(object sender, PaintEventArgs e)
        {
            if (mySaddleInfo.Col_No == 1)
            {
                gr.DrawString(mySaddleInfo.Row_No.ToString("X"), new Font("微软雅黑", 10, FontStyle.Bold), Brushes.Blue, new Point(1, Convert.ToInt32(location_y)));
            }
            //20200508修改-----yezhiwei
            if (mySaddleInfo.SaddleNo.Substring(0, 4) == "FT36" || mySaddleInfo.SaddleNo.Substring(0, 4) == "FT14")
            { gr.DrawString(stockRowFormat(mySaddleInfo.Col_No), new Font("微软雅黑", 6, FontStyle.Bold), Brushes.Blue, new Point(Convert.ToInt32(location_x), Convert.ToInt32(location_y) - 14)); }
            else
            { gr.DrawString(stockRowFormat(mySaddleInfo.Col_No), new Font("微软雅黑", 7, FontStyle.Bold), Brushes.Blue, new Point(Convert.ToInt32(location_x), Convert.ToInt32(location_y) + 15)); }
            //gr.DrawString(stockRowFormat(mySaddleInfo.Col_No), new Font("微软雅黑", 7, FontStyle.Bold), Brushes.Blue, new Point(Convert.ToInt32(location_x), Convert.ToInt32(location_y) + 15));

        }
        string stockRowFormat(object rowNO)
        {
            string retStr = "";
            int temp = Convert.ToInt32(rowNO);
            if (temp < 99)
            {
                retStr = temp.ToString("00");
            }
            else
            {
                int temp1 = temp / 10;
                int temp2 = temp % 10;
                retStr = temp1.ToString("X") + temp2.ToString("0");
            }
            return retStr;
        }

    }
}
