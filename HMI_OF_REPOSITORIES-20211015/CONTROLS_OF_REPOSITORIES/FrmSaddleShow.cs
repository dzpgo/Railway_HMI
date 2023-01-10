using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class FrmSaddleShow : Form
    {
        public FrmSaddleShow()
        {
            InitializeComponent();
            this.SetStyle(
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.AllPaintingInWmPaint, true);
            this.Load += FrmSaddleShow_Load;
        }
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键

        private AreaBase areaBase = new AreaBase();
        public AreaBase AreaBase
        {
            get { return areaBase; }
            set { areaBase = value; }
        }

        private conSaddleInStockMessage conSaddle = new conSaddleInStockMessage();
        private SaddleStrategyData saddleData = new SaddleStrategyData();

        void FrmSaddleShow_Load(object sender, EventArgs e)
        {


            //panel6.BackColor = Color.LightGreen;
            //panel7.BackColor = Color.Pink;
            //panel8.BackColor = Color.Orange;

            lblArea.Text = areaBase.AreaNo + "库位详细信息";
            conSaddle = new conSaddleInStockMessage();

            refreshSaddle();
            //timer1.Enabled = true;
            //timer1.Interval = 2000;
        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            this.Hide();         
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdata_Click(object sender, EventArgs e)
        {
            refreshSaddle();
        }

        private void FrmSaddleShow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void refreshSaddle()  //库位
        {
            conSaddle.conInit(panel2, areaBase, SaddleBase.tagServiceName,
               panel2.Width, panel2.Height, SaddleBase.xAxisRight, SaddleBase.yAxisDown, 900);
        }

        #region 无边框拖动
        private void FrmSaddleShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void FrmSaddleShow_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void FrmSaddleShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        } 
        #endregion

        private bool flag = false;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //timer1.Enabled = true;

            Graphics gp = panel2.CreateGraphics();
            
            double X_Width = areaBase.X_End - areaBase.X_Start;
            double Y_Height = areaBase.Y_End - areaBase.Y_Start;
            //计算X方向上的比例关系
            double xScale = Convert.ToDouble(panel2.Width - 40) / Convert.ToDouble(X_Width);
            double yScale = Convert.ToDouble(panel2.Height - 60) / Convert.ToDouble(Y_Height);

            saddleData.BayNo = areaBase.BayNo;
            saddleData.GetSaddleStrategMessage();


            foreach (SaddleStrategyType item in saddleData.ListSaddleType)
            {

                if (item.Id < 130000 || item.Id > 310000)
                {
                    Brush bColor;
                    //区分南北颜色
                    if (item.Desc.Contains("外贸"))
                    {
                        bColor = Brushes.LightGreen;
                    }
                    else if (item.Desc.Contains("内贸"))
                    {                       
                        bColor = Brushes.Pink;
                    }
                    else if (item.Desc.Contains("铁路北"))
                    {
                        bColor = Brushes.Orange;
                    }
                    else if(item.Desc.Contains("铁路南"))
                    {
                        bColor = Brushes.Peru;
                    }
                    else
                    {
                        bColor = Brushes.White;
                    }

                    //1、在本小区内(在小区范围)--区域的X小 大于等于 小区的X起,并且区域的X大 小于等于 小区的X终 92468 185818
                    if (item.XMin >= areaBase.X_Start && item.XMax <= areaBase.X_End)
                    {
                        Rectangle rec = new Rectangle(new Point(
                            Convert.ToInt32(Convert.ToDouble(item.XMin - (areaBase.X_Start - 1500)) * xScale),  //-1000
                            Convert.ToInt32(Convert.ToDouble(item.YMin - areaBase.Y_Start + 400) * yScale)),     //-450
                            new Size(Convert.ToInt32(Convert.ToDouble(item.XMax - item.XMin) * xScale),
                                Convert.ToInt32(Convert.ToDouble(item.YMax - item.YMin + 400) * yScale)  //+1200
                                ));
                        //填充颜色       获取系统颜色     给定要填充的矩形  
                        //gp.FillRectangle(bColor, rec);
                        gp.DrawRectangle(new Pen(bColor, 5), rec);
                    }

                    //2、区域范围X小 小于等于 小区X最小,并且区域范围X大 小于等于 小区X最大,并且区域X最大 大于 小区的X起
                    else if (item.XMin <= areaBase.X_Start && item.XMax <= areaBase.X_End && item.XMax > areaBase.X_Start)
                    {
                         Rectangle rec = new Rectangle(new Point(
                            Convert.ToInt32(Convert.ToDouble(1000) * xScale),
                            Convert.ToInt32(Convert.ToDouble(item.YMin - areaBase.Y_Start + 400) * yScale)),
                            new Size(Convert.ToInt32(Convert.ToDouble(item.XMax - item.XMin) * xScale),
                                Convert.ToInt32(Convert.ToDouble(item.YMax - item.YMin + 400) * yScale)
                                ));
                        //填充颜色       获取系统颜色     给定要填充的矩形  
                        //gp.FillRectangle(bColor, rec);
                        gp.DrawRectangle(new Pen(bColor, 5), rec);
                    }

                    //3、区域范围X最小 小于等于 小区X最小,并且区域范围X大 大于等于 小区X最大
                    else if (item.XMin <= areaBase.X_Start && item.XMax >= areaBase.X_End)
                    {
                        Rectangle rec = new Rectangle(new Point(
                           Convert.ToInt32(Convert.ToDouble(1000) * xScale),
                           Convert.ToInt32(Convert.ToDouble(item.YMin - areaBase.Y_Start + 400) * yScale)),
                           new Size(Convert.ToInt32(Convert.ToDouble(areaBase.X_End) * xScale),
                               Convert.ToInt32(Convert.ToDouble(item.YMax - item.YMin + 400) * yScale)
                               ));
                        //填充颜色       获取系统颜色     给定要填充的矩形  
                        //gp.FillRectangle(bColor, rec);
                        gp.DrawRectangle(new Pen(bColor, 5), rec);
                    }

                    //4、在本小区内部分区域(超过小区最大X) ---区域X小  大于 小区的X最小 并且 区域X大 大于 小区的X终
                    else if (item.XMin > areaBase.X_Start && item.XMax > areaBase.X_End)
                    {
                        Rectangle rec = new Rectangle(new Point(
                            Convert.ToInt32(Convert.ToDouble(item.XMin - (areaBase.X_Start - 1500)) * xScale), //-1000
                           Convert.ToInt32(Convert.ToDouble(item.YMin - areaBase.Y_Start + 400) * yScale)),
                           new Size(Convert.ToInt32(Convert.ToDouble(areaBase.X_End - item.XMin) * xScale),
                               Convert.ToInt32(Convert.ToDouble(item.YMax - item.YMin + 400) * yScale)
                               ));
                        //填充颜色       获取系统颜色     给定要填充的矩形  
                        //gp.FillRectangle(bColor, rec);
                        gp.DrawRectangle(new Pen(bColor, 5), rec);
                    }
                }      
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshSaddle();
        }

    }
}
