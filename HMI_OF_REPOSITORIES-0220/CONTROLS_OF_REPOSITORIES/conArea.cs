using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class conArea : UserControl
    {
        //private Baosight.iSuperframe.Authorization.Interface.IAuthorization auth;
        public conArea()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
        
        //显示小区名
        private Label lblAreaNO = new Label();

        //显示打包区
        private Label lblPackage = new Label();
        //要显示到的panel
        private Panel panel = new Panel();
        //分界线的高度
        private int gHeight;
        //存放小区数据
        private AreaBase areaBase = new AreaBase();

        private AreaInBay areaInBay = new AreaInBay();
        //是否创建小区
        private bool isCranteLblArea = false;
        //是否画分界线
        //private bool isBorder = false;
        //是否创建打包区
        //private bool isPackage = false;
        //安全门状态
        private bool isNDoorStatus = false;
        private bool isBDoorStatus = false;
        //道闸状态
        private bool GateStatus_N = false;
        private bool GateStatus_S = false;



        //是否弹出窗体
        private bool isShowFrom = false;


        private bool isClick = false;

        FrmSaddleShow FrmSaddleDetail = new FrmSaddleShow();

        //private Graphics gr;

        //private int yHeight;
        //private int xWidth;

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                return parms;
            }
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
                    if (Saddle_Selected != null)
                    {
                        Saddle_Selected(areaBase.Clone());
                    }
                }
                else
                {
                    if (!isShowFrom)
                    {
                        FrmSaddleDetail.AreaBase = areaBase;
                        FrmSaddleDetail.FormBorderStyle = FormBorderStyle.None;
                       // FrmSaddleDetail.Hide();
                        isShowFrom = true;
                    }
                    FrmSaddleDetail.Show();           
                }
            }
            catch (Exception ex)
            {
            }
        }


        public delegate void areaRefreshInvoke(AreaBase theSaddle, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel panel, conArea _conArea, bool _isNDoorStatus, bool _isBDoorStatus, bool _isRefesh);

        public void refreshControl_(AreaBase theSaddle, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel _panel, conArea _conArea,bool _isNDoorStatus,bool _isBDoorStatus,bool _isRefesh)
        {
            if (isClick)
                return;
            try
            {
                areaBase = theSaddle;
                isNDoorStatus = _isNDoorStatus;
                isBDoorStatus = _isBDoorStatus;
                panel = _panel;

                //计算X方向上的比例关系
                double xScale = Convert.ToDouble(panelWidth) / Convert.ToDouble(baySpaceX);

                //计算控件中心X，区分为X坐标轴向左或者向右
                double location_X = 0;
                if (xAxisRight == true)
                {
                    location_X = Convert.ToDouble(theSaddle.X_Start) * xScale;
                }
                else
                {
                    location_X = Convert.ToDouble(baySpaceX - (theSaddle.X_End)) * xScale;
                }


                //计算Y方向的比例关系
                double yScale = Convert.ToDouble(panelHeight) / Convert.ToDouble(baySpaceY);

                //计算行车中心Y 区分Y坐标轴向上或者向下
                double location_Y = 0;
                if (yAxisDown == true)
                {
                    location_Y = Convert.ToDouble(theSaddle.Y_Start) * yScale;
                }
                else
                {
                    location_Y = Convert.ToDouble(baySpaceY - (theSaddle.Y_End)) * yScale;
                }

                if (location_Y < 0)
                {
                    location_Y = 0;
                }

                //定位库位鞍座的坐标
                this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y));
                //修改鞍座控件的宽度和高度

                this.Width = Convert.ToInt32((theSaddle.X_End - theSaddle.X_Start) * xScale);

                this.Height = Convert.ToInt32((theSaddle.Y_End - theSaddle.Y_Start) * yScale);

                if (theSaddle.AreaNo.ToString() == "FT1-1-T")
                {
                    this.Visible = false;
                }



                //如果是A区 根据他的y最大值加一米  画一条分界线

                if (theSaddle.AreaNo.IndexOf("A") > -1)
                {
                    if (!_isRefesh)
                    {
                        gHeight = Convert.ToInt32(Convert.ToDouble(theSaddle.Y_End + 1000) * yScale);
                        panel.Paint += panel_Paint;
                    }
                    
                   // this.Paint += conArea_Paint;
                    //if (isBorder == false || flag == true)
                    //{
                        
                       
                        //panel.Paint += panel_Paint;
                       // isBorder = true;
                        
                    //}
                }

                if (theSaddle.AreaNo.IndexOf("FT") > -1)
                {
                    int saddleNum = areaInBay.getAreaSaddleNum(areaBase.AreaNo);
                    int saddleNoCoilNum = areaInBay.getAreaSaddleNoCoilNum(areaBase.AreaNo);
                    int saddleCoilNum = areaInBay.getAreaSaddleCoilNum(areaBase.AreaNo);
                   
                    if (!isCranteLblArea)
                    {
                        lblAreaNO.Name = theSaddle.AreaNo;
                       // lblAreaNO.BackColor = Color.LightGray;
                        lblAreaNO.BackColor = (isNDoorStatus == true ? Color.OrangeRed : Color.Beige);
                        lblAreaNO.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        lblAreaNO.Width = 130;
                        lblAreaNO.Height = 130;
                       // lblAreaNO.ForeColor = Color.Black;
                        lblAreaNO.ForeColor = (isNDoorStatus == true ? Color.Red : Color.Black);
                        _conArea.Controls.Add(lblAreaNO);
                        isCranteLblArea = true;
                    }
                    lblAreaNO.Text = theSaddle.AreaNo.Substring(6, theSaddle.AreaNo.Count() - 6) + "区" + "\n"
                               + "鞍座总数：" + saddleNum + "\n"
                               + "白库位：" + saddleNoCoilNum + "\n"
                               + "黑库位：" + saddleCoilNum + "\n"
                               + "红库位：" + (saddleNum - saddleNoCoilNum - saddleCoilNum)+"\n"
                               + "安全门： " + (isNDoorStatus==true?"开":"关");
                    lblAreaNO.Location = new Point(this.Width / 2 + 5, this.Height / 2 + 5);
                }

               // this.BackColor = Color.Beige;

                this.BackColor = (isNDoorStatus == true ? Color.OrangeRed : Color.Beige);

               
            }
            catch (Exception ex)
            {
                //LogManager.WriteProgramLog("refreshControl:" + ex.Message);
            }
        }
        public void refreshControl(AreaBase theSaddle, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel _panel, conArea _conArea, bool _isNDoorStatus, bool _isBDoorStatus, bool _isRefesh)
        {
            if (isClick)
                return;
            try
            {
                areaBase = theSaddle;
                isNDoorStatus = _isNDoorStatus;
                //isBDoorStatus = _isBDoorStatus;
                panel = _panel;

                //计算X方向上的比例关系
                decimal xScale = Convert.ToDecimal(panelWidth) / Convert.ToDecimal(baySpaceX);

                //计算控件中心X，区分为X坐标轴向左或者向右
                decimal location_X = 0;
                if (xAxisRight == true)
                {
                    location_X = Convert.ToDecimal(theSaddle.X_Start) * xScale;
                }
                else
                {
                    location_X = Convert.ToDecimal(baySpaceX - (theSaddle.X_End)) * xScale;
                }


                //计算Y方向的比例关系
                decimal yScale = Convert.ToDecimal(panelHeight) / Convert.ToDecimal(baySpaceY);

                //计算行车中心Y 区分Y坐标轴向上或者向下
                decimal location_Y = 0;
                if (yAxisDown == true)
                {
                    location_Y = Convert.ToDecimal(theSaddle.Y_Start) * yScale;
                }
                else
                {
                    location_Y = Convert.ToDecimal(baySpaceY - (theSaddle.Y_End)) * yScale;
                }

                if (location_Y < 0)
                {
                    location_Y = 0;
                }

                //定位库位鞍座的坐标
                this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y));
                //修改鞍座控件的宽度和高度

                this.Width = (int)(Math.Abs(theSaddle.X_End - theSaddle.X_Start) * xScale);

                this.Height = (int)(Math.Abs(theSaddle.Y_End - theSaddle.Y_Start) * yScale);

                if (theSaddle.AreaNo.ToString() == "FT1-1-T")
                {
                    this.Visible = false;
                }



                //如果是A区 根据他的y最大值加一米  画一条分界线

                if (theSaddle.AreaNo.IndexOf("A") > -1)
                {
                    if (!_isRefesh)
                    {
                        if (theSaddle.AreaNo.Contains("RAILWAY"))
                        {
                            gHeight = Convert.ToInt32(Convert.ToDecimal(27800 + 1000) * yScale);
                            //_conArea.Paint += _conArea_Paint;
                            Panel pnlRailway = new Panel();
                            pnlRailway.Paint += pnlRailway_Paint;
                            pnlRailway.Size = _conArea.Size;
                            //pnlRailway.BackColor = Color.Beige;
                            _conArea.Controls.Add(pnlRailway);
                            _conArea.paintRailwayPathWay(pnlRailway);
                        }
                        else 
                             gHeight = Convert.ToInt32(Convert.ToDecimal(theSaddle.Y_End + 1000) * yScale);
                        panel.Paint += panel_Paint;
                    }

                    // this.Paint += conArea_Paint;
                    //if (isBorder == false || flag == true)
                    //{


                    //panel.Paint += panel_Paint;
                    // isBorder = true;

                    //}
                }

                if (theSaddle.AreaNo.IndexOf("FT") > -1)
                {
                    int saddleNum = areaInBay.getAreaSaddleNum(areaBase.AreaNo);
                    int saddleNoCoilNum = areaInBay.getAreaSaddleNoCoilNum(areaBase.AreaNo);
                    int saddleCoilNum = areaInBay.getAreaSaddleCoilNum(areaBase.AreaNo);

                    if (!isCranteLblArea)
                    {
                        lblAreaNO.Name = theSaddle.AreaNo;
                        //lblAreaNO.BackColor = Color.Beige;
                        //lblAreaNO.BackColor = (isNDoorStatus == true ? Color.OrangeRed : Color.Beige);
                        lblAreaNO.Font = new System.Drawing.Font("微软雅黑", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        lblAreaNO.Width = (this.Width - 130) > 0 ? 120 : 0;
                        lblAreaNO.Height = (this.Height - 130) > 0 ? 120 : 0;
                        lblAreaNO.ForeColor = Color.Black;
                        lblAreaNO.MouseDown += conSaddle_visual_MouseUp;
                        _conArea.Controls.Add(lblAreaNO);
                        isCranteLblArea = true;
                    }
                    lblAreaNO.Text = theSaddle.AreaNo.Substring(6, theSaddle.AreaNo.Count() - 6) + "区" + "\n"
                               + "鞍座总数：" + saddleNum + "\n"
                               + "空库位：" + saddleNoCoilNum + "\n"
                               + "占用库位：" + saddleCoilNum + "\n"
                               + "红库位：" + (saddleNum - saddleNoCoilNum - saddleCoilNum) + "\n"
                               + "安全门： " + (isNDoorStatus == true ? "开" : "关");
                    lblAreaNO.Location = new Point(this.Width -150 , this.Height / 2 + 5-70);
                }

                // this.BackColor = Color.Beige;

                this.BackColor = (isNDoorStatus == true ? Color.OrangeRed : Color.Beige);
               

            }
            catch (Exception ex)
            {
                //LogManager.WriteProgramLog("refreshControl:" + ex.Message);
            }
        }

        void pnlRailway_Paint(object sender, PaintEventArgs e)
        {
            paintRailwayPathWay((Panel)sender);
        }

        void _conArea_Paint(object sender, PaintEventArgs e)
        {
            paintRailwayPathWay(this);
        }
        public void paintRailwayPathWay(Control pnlControl)
        {
            int wayWidth = pnlControl.Height;
            int wayLength = pnlControl.Width;
            int way_X1 = 0;
            int way_Y1 = 5;
            int way_X2 = 0;
            int way_Y2 = wayWidth - 5;
            //画图对象
            Graphics gr;
            //清空所有绘制的线条
            using (Graphics g = pnlControl.CreateGraphics())
            {
                g.Clear(pnlControl.BackColor);
            }
            gr = pnlControl.CreateGraphics();
            Pen pen1 = new Pen(Color.DimGray, 2);
            gr.DrawLine(pen1, way_X1, way_Y1, wayLength, way_Y1);  //铁轨1
            gr.DrawLine(pen1, way_X2, way_Y2, wayLength, way_Y2);  //铁轨2

            //铁轨横线
            for (int i = 5; i < wayLength; i += 25)
            {
                Point linePoinSrat = new Point();
                Point linePoinEnd = new Point();
                linePoinSrat.X = i;
                linePoinSrat.Y = way_Y1;
                linePoinEnd.X = i;
                linePoinEnd.Y = way_Y2;
                gr.DrawLine(pen1, linePoinSrat, linePoinEnd);
            }

        }
        void panel_Paint(object sender, PaintEventArgs e)
        {
            //画图对象
            Graphics gr;
            //清空所有绘制的线条
            using (Graphics g = panel.CreateGraphics())
            {
                g.Clear(panel.BackColor);
            }

            gr = panel.CreateGraphics();

            //gHeight = 352;
            //gHeight = 365;
            Pen p = new Pen(Color.Gold, 2);
            Pen p1 = new Pen(Color.White, 2);
            Pen p2 = new Pen(Color.Blue, 10);
            Pen p3 = new Pen(Color.FromArgb(176, 224, 230), 11);
            Pen p4 = new Pen(Color.Gold, 2);
            Pen p5 = new Pen(Color.White, 10);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;//虚线的样式
            p.DashPattern = new float[] { 5, 1 };//设置虚线中实点和空白区域之间的间隔
            p4.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;//虚线的样式
            p4.DashPattern = new float[] { 2, 2 };//设置虚线中实点和空白区域之间的间隔
            //分界线
            gr.DrawLine(p3, 0, gHeight-5, panel.Width, gHeight-5);


            //给定要填充的矩形对象  
            Rectangle rec = new Rectangle(new Point(0, gHeight + 5), new Size(panel.Width, panel.Height - gHeight - 25));
            //填充颜色       获取系统颜色     给定要填充的矩形  
            gr.FillRectangle(Brushes.DarkSlateGray, rec);
            int nWidth = 0;

            do
            {
                nWidth = nWidth + 150;
                gr.DrawLine(p5, nWidth, (gHeight - 5) + (panel.Height - gHeight - 5) / 2, nWidth + 50, (gHeight - 5) + (panel.Height - gHeight - 5) / 2);

            } while (nWidth < panel.Width - 250);


            //gr.DrawLine(p1, 0, gHeight-5, panel.Width, gHeight-5);
           // gr.DrawLine(p, 0, gHeight, panel.Width, gHeight);
            //方向
            //gr.DrawString("←南", new Font("微软雅黑", 15, FontStyle.Bold), Brushes.Red, new Point(80, panel.Height -50));
            //gr.DrawString("北→", new Font("微软雅黑", 15, FontStyle.Bold), Brushes.Red, new Point(panel.Width - 130, panel.Height - 50)); 
            //大门
            //gr.DrawLine(p2, 0, gHeight, 0, gHeight + 20);
           // gr.DrawLine(p2, 0, panel.Height, 0, panel.Height - 20);
           // gr.DrawLine(p2, panel.Width, gHeight, panel.Width, gHeight + 20);
            //gr.DrawLine(p2, panel.Width, panel.Height, panel.Width, panel.Height - 20);
            gr.DrawString("南", new Font("微软雅黑", 10, FontStyle.Bold), Brushes.White, new Point(1, (panel.Height - gHeight) / 2 + gHeight-10));
            gr.DrawString("门", new Font("微软雅黑", 10, FontStyle.Bold), Brushes.White, new Point(1, (panel.Height - gHeight) / 2 + gHeight+4));
            gr.DrawString("北", new Font("微软雅黑", 10, FontStyle.Bold), Brushes.White, new Point(panel.Width - 15, (panel.Height - gHeight) / 2 + gHeight-10));
            gr.DrawString("门", new Font("微软雅黑", 10, FontStyle.Bold), Brushes.White, new Point(panel.Width - 15, (panel.Height - gHeight) / 2 + gHeight+4));

            //道闸南
            Rectangle NrecS = new Rectangle(new Point(20, gHeight + 20 - 4), new Size(15, 10));
            gr.FillRectangle(Brushes.GhostWhite, NrecS);
            Rectangle NrecX = new Rectangle(new Point(20, panel.Height - 30 - 4), new Size(15, 10));
            gr.FillRectangle(Brushes.GhostWhite, NrecX);
            if (GateStatus_S)
            {
                gr.DrawLine(p1, 35, gHeight + 25 - 4, 55, gHeight + 25 -4);
                gr.DrawLine(p1, 35, panel.Height - 25 - 4, 55, panel.Height - 25 - 4);
                gr.DrawLine(p4, 35, gHeight + 25 - 4, 55, gHeight + 25 - 4);
                gr.DrawLine(p4, 35, panel.Height - 25 - 4, 55, panel.Height - 25- 4);
               // flag = false;
            }
            else
            {
                gr.DrawLine(p1, 27, gHeight + 30 - 4, 27, gHeight + 90 - 4);
                gr.DrawLine(p1, 27, panel.Height - 30 - 4, 27, panel.Height - 90 - 4);
                gr.DrawLine(p4, 27, gHeight + 30 - 4, 27, gHeight + 90 - 4);
                gr.DrawLine(p4, 27, panel.Height - 30 - 4, 27, panel.Height - 90 - 4);
                //flag = true;
            }
           

            //道闸北
            Rectangle BrecS = new Rectangle(new Point(panel.Width -35, gHeight + 20 -4), new Size(15, 10));
            gr.FillRectangle(Brushes.GhostWhite, BrecS);
            Rectangle BrecX = new Rectangle(new Point(panel.Width - 35, panel.Height - 30 -4), new Size(15, 10));
            gr.FillRectangle(Brushes.GhostWhite, BrecX);
            if (GateStatus_N)
            {
                gr.DrawLine(p1, panel.Width - 35, gHeight + 25 - 4, panel.Width - 55, gHeight + 25 - 4);
                gr.DrawLine(p1, panel.Width - 35, panel.Height - 25 - 4, panel.Width - 55, panel.Height - 25 - 4);
                gr.DrawLine(p4, panel.Width - 35, gHeight + 25 - 4, panel.Width - 55, gHeight + 25 - 4);
                gr.DrawLine(p4, panel.Width - 35, panel.Height - 25 - 4, panel.Width - 55, panel.Height - 25 - 4);
            }
            else
            {
                gr.DrawLine(p1, panel.Width - 27, gHeight + 30 - 4, panel.Width - 27, gHeight + 90 - 4);
                gr.DrawLine(p1, panel.Width - 27, panel.Height - 30 - 4, panel.Width - 27, panel.Height - 90 - 4);
                gr.DrawLine(p4, panel.Width - 27, gHeight + 30 - 4, panel.Width - 27, gHeight + 90 - 4);
                gr.DrawLine(p4, panel.Width - 27, panel.Height - 30 - 4, panel.Width - 27, panel.Height - 90 - 4);
            }
           


            
            //isBorder = true;
        }


        public delegate void EventHandler_Saddle_Selected(AreaBase theAreaInfo);
        public event EventHandler_Saddle_Selected Saddle_Selected;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            try
            {
                if (areaBase.AreaNo != null)
                {
                    #region D区  添加打包区  不要了
                    //如果是D区  
                    //if (areaBase.AreaNo.IndexOf("D") > -1)
                    //{
                    //    yHeight = this.Height / 2;
                    //    xWidth = this.Width / 2;

                    //    Pen p = new Pen(Color.Orange, 2);
                    //    Pen p3 = new Pen(Color.Green, 2);
                    //    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;//虚线的样式
                    //    p.DashPattern = new float[] { 3, 1 };//设置虚线中实点和空白区域之间的间隔
                    //    //画横坐标线
                    //    gr.DrawLine(p3, xWidth, 0, xWidth, yHeight);
                    //    gr.DrawLine(p3, 0, yHeight, xWidth, yHeight);

                    //    gr.DrawLine(p, xWidth, 0, xWidth, yHeight);
                    //    gr.DrawLine(p, 0,  yHeight, xWidth, yHeight);

                    //    //给定要填充的矩形对象  
                    //    Rectangle rec = new Rectangle(new Point(1, 1), new Size(xWidth - 2, yHeight - 2));
                    //    //填充颜色       获取系统颜色     给定要填充的矩形  
                    //    gr.FillRectangle(Brushes.FloralWhite, rec);

                    //    gr.DrawString("打包区", new Font("微软雅黑", 17, FontStyle.Bold), Brushes.Red, new Point(xWidth / 2 - 25, yHeight / 2 - 22));



                    //}


                    #endregion
                    Pen p1 = new Pen(Color.Green, 2);
                    Pen p2 = new Pen(Color.Orange, 2);
                    p2.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;//虚线的样式
                    p2.DashPattern = new float[] { 5, 1 };//设置虚线中实点和空白区域之间的间隔
                    gr.DrawLine(p1, 1, 1, this.Width, 1);
                    gr.DrawLine(p1, 1, this.Height - 1, this.Width, this.Height - 1);
                    gr.DrawLine(p1, 1, 1, 1, this.Height);
                    gr.DrawLine(p1, this.Width - 1, 1, this.Width - 1, this.Height);
                    gr.DrawLine(p2, 1, 1, this.Width, 1);
                    gr.DrawLine(p2, 1, this.Height - 1, this.Width, this.Height - 1);
                    gr.DrawLine(p2, 1, 1, 1, this.Height);
                    gr.DrawLine(p2, this.Width - 1, 1, this.Width - 1, this.Height);

                    //gr.DrawString(areaBase.AreaNo.Substring(6, areaBase.AreaNo.Count() - 6) + "区", new Font("微软雅黑", 9.0F, FontStyle.Bold), Brushes.White, new Point(this.Width / 2 + 5, this.Height / 2 + 5));   
                    if (areaBase.AreaNo.Contains("G"))
                    {
                        gr.DrawString("打包区", new Font("微软雅黑", 17, FontStyle.Bold), Brushes.Black, new Point(this.Width / 3, this.Height / 3));
                    }
                   
                   
                }

            }
            catch (Exception er)
            {
                //LogManager.WriteProgramLog("gdi:" + er.Message);
            }
        }

        private void conArea_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.SkyBlue;
        }

        private void conArea_MouseLeave(object sender, EventArgs e)
        {
            //this.BackColor = Color.Beige;
            //lblAreaNO.BackColor = Color.Beige;
            foreach (var item in this.Controls)
            {
                if (item is Label)
                {
                    Label labItem = (Label)item;
                    labItem.Font = new System.Drawing.Font("微软雅黑", 9.0F,
                        System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
            }
            isClick = false;
        }

        private void conArea_MouseMove(object sender, MouseEventArgs e)
        {
            //this.BackColor = Color.SkyBlue;
            //lblAreaNO.BackColor = Color.SkyBlue;
            foreach (var item in this.Controls)
            {
                if (item is Label)
                {
                    Label labItem = (Label)item;
                    labItem.Font = new System.Drawing.Font("微软雅黑", 10.0F, 
                        System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
            }
            isClick = true;
        }

        public void SetAreaBackColor(bool status, Color mcolor)
        {
            if (status)
            {
                this.BackColor = mcolor;
            }
            else
            {
                this.BackColor = Color.Beige;
            }
        }
        public void SetGateStatus(string gate, bool status)
        {
            if (gate=="N")
            {
                GateStatus_N = status;
            }
            else
            {
                GateStatus_S = status;
            }
        }

    }
}
