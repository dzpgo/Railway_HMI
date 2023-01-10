using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class conStockArea : UserControl
    {
        decimal XRatio, YRatio;
        //X、Y偏移量,相对左上角的坐标
        int XOffset, YOffset;
        //区域
        Panel pnlArea =new Panel();

        Bitmap bitM;  //实例化一个新画布
        Graphics g;   //创建Graphics对象
        Pen myPen;    //创建Pen对象
        public conStockArea()
        {
            InitializeComponent();
            XRatio = YRatio = 1;
            XOffset = YOffset = 5;
            myPen = new Pen(Color.Blue, 2.0f);
        }
        private string areaName;

        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; labConText.Text = "库区： " + areaName; }
        }


        private void createArea( Point actualPoint,Size actualSize)
        {
            try
            {
                int s_x = converToHMISize_X(actualSize.Width);
                int s_y = converToHMISize_X(actualSize.Height);
                int p_x = converToHMISize_X(actualPoint.X);
                int p_y = converToHMISize_X(actualPoint.Y);
                pnlArea.Location = new Point(p_x, p_y);
                pnlArea.Size = new Size(s_x, s_y);
                this.Controls.Add(pnlArea);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        public void createAreaSize(int x, int y, int xLength, int yLength)
        {
            clearStockArea();
            pnlArea.Location = new Point(5, 5);
            pnlArea.Size = new Size(this.Width - 10, this.Height - 10 - labConText.Size.Height);
            //pnlArea.BackColor = Color.Red;
            this.Controls.Add(pnlArea);
            //labConText.Location = new Point(0, pnlArea.Size.Height + 1);
            initializeRatio(x, y, xLength, yLength);  //必须先初始化pnlArea初始化
            //
            bitM = new Bitmap(this.pnlArea.Width, this.pnlArea.Height);
            g = Graphics.FromImage(bitM);
            g.Clear(Color.Moccasin);
            //int n1 = Convert.ToInt32(Math.Abs(y * YRatio + YOffset));
            //int n2 = Convert.ToInt32(Math.Abs(x * XRatio + XOffset));
            //int n3 = Convert.ToInt32(xLength * XRatio);
            //int n4 = Convert.ToInt32(yLength * YRatio);
            int l_x = converToHMILocation_X(x);
            int l_y = converToHMILocation_Y(y);
            int s_x = converToHMISize_X(xLength);
            int s_y = converToHMISize_Y(yLength);

            //g.DrawRectangle(myPen, n2, n1, n3, n4);       //调用Graphics对象的DrawRectangle方法
            g.DrawRectangle(myPen, l_x, l_y, s_x, s_y);    
            //if (carHearDrection == "E" || carHearDrection == "N")
            //{
            //    g.DrawString("车头", new Font("宋本", 10, FontStyle.Regular), new SolidBrush(Color.Black), pan1.Size.Width - 20, pan1.Size.Height / 3, new StringFormat(StringFormatFlags.DirectionVertical));               //绘制说明文字
            //}
            //else if ((carHearDrection == "W" || carHearDrection == "S"))
            //{
            //    g.DrawString("车头", new Font("宋本", 10, FontStyle.Regular), new SolidBrush(Color.Black), 0, pan1.Size.Height / 3, new StringFormat(StringFormatFlags.DirectionVertical));               //绘制说明文字
            //}

            this.pnlArea.BackgroundImage = bitM;                //将画布设为panel1控件的背景图
        }

        #region 坐标转换
        private decimal getRatio(int HMIValue, int actualValue)
        {
            decimal ret = 1;
            ret = Math.Round((decimal)HMIValue / actualValue, 5); ;
            return ret;
        }
        public void initializeRatio(int location_X,int location_Y,int size_X, int size_Y )
        {
            try
            {
                int X_bloeUp, Y_blowUp;
                X_bloeUp = 2500;
                Y_blowUp = 2500;//放大偏移量
                //XRatio = getRatio(this.Size.Width-10, size_X + X_bloeUp); //
                //YRatio = getRatio(this.Size.Height-10, size_Y + Y_blowUp);
                XRatio = getRatio(this.pnlArea.Size.Width , size_X + X_bloeUp); //
                YRatio = getRatio(this.pnlArea.Size.Height, size_Y + Y_blowUp);
                InitializeOffsetXY(location_X, location_Y);
                //默认放大区域:X+500,Y+500
                //createArea(new Size(size_X + X_bloeUp * 2, size_Y + Y_blowUp * 2), new Point(location_X, location_Y));
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        private int converToHMISize_X(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(XRatio * actualValue) ;
            return HMIValue;
        }
        private int converToHMISize_Y(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(YRatio * actualValue) ;
            return HMIValue;
        }
        private int converToHMILocation_X(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = (int)Math.Abs(XRatio * actualValue + XOffset);
            return HMIValue;
        }
        private int converToHMILocation_Y(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = (int)Math.Abs(YRatio * actualValue + YOffset);
            return HMIValue;
        }
        private void InitializeOffsetXY(int actualLocation_X, int actualLocation_Y)
        {
            //实际*比率+偏移量 = 画面参数
            //坐标转换  (x,y) --> (5,5)
            XOffset = Convert.ToInt32(5 - actualLocation_X * XRatio);
            YOffset = Convert.ToInt32(5 - actualLocation_Y * YRatio);              

        }
        #endregion

        public void addSmallArae(ClsSmallArea smallArea)
        {
            pnlArea.Controls.Clear();
            Panel pnl = new Panel();
            if (smallArea.point!=null)
            {
                pnl.Location = new Point(converToHMILocation_X(smallArea.point.X), converToHMILocation_Y(smallArea.point.Y));
            }
            pnl.Size = new Size(converToHMISize_X(smallArea.size.Width), converToHMISize_Y(smallArea.size.Height));
            
            Color bColor;
            //区分南北颜色
            if (smallArea.logisticsFlag =="1")
            {
                bColor = Color.LightGreen;
            }
            else if (smallArea.logisticsFlag == "2")
            {
                bColor = Color.Pink;
            }
            else if (smallArea.logisticsFlag == "3")
            {
                bColor = Color.Orange;
            }
            else
            {
                bColor = Color.Gray;
            }
            pnl.BackColor = bColor;
            pnl.Name = smallArea.areaID;
            pnlArea.Controls.Add(pnl);
            Label lab = new Label();
            lab.Text = smallArea.areaName;
            if (lab.Size.Width >pnl.Size.Width)
            {
                lab.Text = UACSUtility.ViewHelper.changTextDrection(lab.Text);
            }
            lab.AutoSize = true;
            lab.BackColor = smallArea.enable ? Color.Green : Color.Gray;
            pnl.BringToFront();	
            pnl.Controls.Add(lab);
            
        }

        public void clearStockArea()
        {
            pnlArea.Controls.Clear();
            //pnlArea.Location = new Point(0, 0);
            //pnlArea.Size = new Size(0, 0);
            //this.Controls.Clear();
        }
         
    }
}
