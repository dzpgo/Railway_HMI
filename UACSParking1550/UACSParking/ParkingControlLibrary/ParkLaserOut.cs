using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ParkingControlLibrary
{
    public delegate void LabClick(string matNO);
    public partial class ParkLaserOut : UserControl
    {

        //获取 控件大小 
        //Panel pan0 = new Panel();  //地面
        Panel pan1 = new Panel(); //车位
        Panel pan2 = new Panel(); //车
        Panel panelVirtualCar = new Panel();  //虚拟车形状

        Bitmap bitM;  //实例化一个新画布
        Graphics g;   //创建Graphics对象
        Pen myPen;    //创建Pen对象

        //ToolTip toolTip1 = new ToolTip();

        //获取 控件大小        
        int labWidth, labHeight;
        decimal XRatio, YRatio;
        //X、Y偏移量,相对左上角的坐标
        int XOffset, YOffset, XOffset1, YOffset1;
        bool hasCarSize = true;

        public bool HasCarSize
        {
            get { return hasCarSize; }
            set { hasCarSize = value; }
        }

        //
        public event LabClick LabClick;


        public ParkLaserOut()
        {
            InitializeComponent();
            //初始化画布
            bitM = new Bitmap(this.labPark.Width, this.labPark.Height);
            g = Graphics.FromImage(bitM);
            myPen = new Pen(Color.Blue, 2.0f);

            XOffset = YOffset = XOffset1 = YOffset1=0;



        }
        /// <summary>
        /// 画车位边框
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xLength"></param>
        /// <param name="yLength"></param>
        public void DrawParksize(int x, int y, int xLength, int yLength)
        {
            try
            {
                //bitM.Dispose();
                //g.Dispose();
                bitM = new Bitmap(this.pan1.Width, this.pan1.Height);
                g = Graphics.FromImage(bitM);
                g.Clear(Color.LightSteelBlue);
                //ClearbitM();
                //x-传给->Y y-->x   换过来
                int n1 = Convert.ToInt32(Math.Abs(y * YRatio + YOffset));
                int n2 = Convert.ToInt32(Math.Abs(x * XRatio + XOffset));
                int n3 = Convert.ToInt32(xLength * XRatio);
                int n4 = Convert.ToInt32(yLength * YRatio);

                g.DrawRectangle(myPen, n1 + YOffset1, n2 + XOffset1, n4, n3);       //调用Graphics对象的DrawRectangle方法
                this.pan1.BackgroundImage = bitM;                //将画布设为panel1控件的背景图
            }
            catch (Exception)
            {                
                return;
            }
        }

        /// <summary>
        /// 画车位边框和车头方向
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xLength"></param>
        /// <param name="yLength"></param>
        public void DrawParksize(int x, int y, int xLength, int yLength,string carHearDrection)
        {
            try
            {
                //bitM.Dispose();
                //g.Dispose();
                bitM = new Bitmap(this.pan1.Width, this.pan1.Height);
                g = Graphics.FromImage(bitM);
                g.Clear(Color.LightSteelBlue);
                //ClearbitM();
                //x-传给->Y y-->x   换过来
                int n1 = Convert.ToInt32(Math.Abs(y * YRatio + YOffset));
                int n2 = Convert.ToInt32(Math.Abs(x * XRatio + XOffset));
                int n3 = Convert.ToInt32(xLength * XRatio);
                int n4 = Convert.ToInt32(yLength * YRatio);

                g.DrawRectangle(myPen, n1 + YOffset1, n2 + XOffset1, n4, n3);       //调用Graphics对象的DrawRectangle方法
                if (carHearDrection == "E" || carHearDrection=="S")
                {
                    g.DrawString("车头", new Font("宋本", 10, FontStyle.Regular), new SolidBrush(Color.Black), pan1.Size.Width - 20, pan1.Size.Height / 3, new StringFormat(StringFormatFlags.DirectionVertical));               //绘制说明文字
                }
                else if ((carHearDrection == "W" || carHearDrection=="N"))
                {
                    g.DrawString("车头", new Font("宋本", 10, FontStyle.Regular), new SolidBrush(Color.Black),0, pan1.Size.Height / 3, new StringFormat(StringFormatFlags.DirectionVertical));               //绘制说明文字
                }
                //else
                //{
                //    g.Clear(Color.LightSteelBlue);
                //    g.DrawRectangle(myPen, n1 + YOffset1, n2 + XOffset1, n4, n3);       //调用Graphics对象的DrawRectangle方法
                //}
                this.pan1.BackgroundImage = bitM;                //将画布设为panel1控件的背景图
            }
            catch (Exception)
            {
                return;
            }
        }

        public void DrawSelectLoction(int x1, int y1, int x2, int y2)
        {
            g.DrawLine(myPen, this.pan1.Width / 2, 0, this.pan1.Height / 2, this.pan1.Width / 2);
            this.pan1.BackgroundImage = bitM;                //将画布设为panel1控件的背景图
        }

        /// <summary>
        /// 生成车道区域
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xLength"></param>
        /// <param name="yLength"></param>
        public void CreatePassageWayArea(int x, int y, int xLength, int yLength)
        {
            try
            {
                //x-传给->Y y-->x   换过来
                XRatio = GetRatio(labHeight, xLength);
                YRatio = GetRatio(labWidth, yLength);
                InitializeOffsetXY(x, y);
                pan1.Location = new Point(5, 5);
                pan1.Size = new Size(labWidth, labHeight);
                pan1.BackColor = Color.White;

                this.labPark.Controls.Add(pan1);
            }

            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            } 
        }

        /// <summary>
        /// 生成停车位
        /// </summary>
        /// <param name="x">坐标x</param>
        /// <param name="y">坐标y</param>
        /// <param name="xLength">x方向长度</param>
        /// <param name="yLength">y方向长度</param>
        public void CreatePark(int x, int y, int xLength, int yLength)
        {
            try
            {
                //x-传给->Y y-->x   换过来
                XRatio = GetRatio(labHeight, xLength);
                YRatio = GetRatio(labWidth, yLength);
                InitializeOffsetXY(x, y);
                pan1.Location = new Point(5, 5);
                pan1.Size = new Size( labWidth,labHeight);
                pan1.BackColor = Color.Green;

                this.labPark.Controls.Add(pan1);
            }

            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }

        }
        /// <summary>
        /// 生成车辆镜像
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xLength"></param>
        /// <param name="yLength"></param>
        public void CreateCarSize(int x, int y, int xLength, int yLength, int carType, string carDiretion)
        {
            try
            {
                //x-传给->Y y-->x   换过来
                int n1 = Convert.ToInt32(Math.Abs(y * YRatio + YOffset));
                int n2 = Convert.ToInt32(Math.Abs(x * XRatio + XOffset));
                int n3 = Convert.ToInt32(xLength * XRatio);
                int n4 = Convert.ToInt32(yLength * YRatio);
                if (carType == 0 || x==0 || y== 0)
                {
                    //pan2.Location = new Point(32, 18);  //20
                    //pan2.Size = new Size(pan1.Width - 80, pan1.Height - 36);
                    //pan2.BackColor = Color.White;
                    //不需要生成
                    HasCarSize = false;
                }
                else
                {
                    HasCarSize = true;
                    pan2.Location = new Point(n1 + YOffset1, n2 + XOffset1);
                    pan2.Size = new Size(n4, n3);
                    pan2.BackColor = Color.Gold;
                    this.pan1.Controls.Add(pan2);
                }
                //pan2.Location = new Point(n1 + YOffset1, n2 + XOffset1);
                //pan2.Size = new Size(n4, n3);
                //pan2.BackColor = Color.Gold;



                //车头
                if (carDiretion == "W")
                {
                    Label lab1 = new Label();
                    lab1.Location = new Point(0, 0);
                    if (carType == 0)
                    {
                        lab1.Size = new Size(pan1.Size.Height / 6, pan1.Size.Height);
                        lab1.BackColor = Color.White;
                        lab1.Text = "车头";
                        lab1.TextAlign = ContentAlignment.MiddleCenter;
                        pan1.Controls.Add(lab1);
                    }
                    //else if (carType == 2)
                    //{
                    //    lab1.Size = new Size(pan2.Size.Height, pan2.Size.Height);
                    //    lab1.BackColor = Color.Red;
                    //    pan2.Controls.Add(lab1);
                    //}
                    //else if (carType == 2)
                    //{
                    //    lab1.Size = new Size(pan2.Size.Height, pan2.Size.Height);
                    //    lab1.BackColor = Color.Red;
                    //    pan2.Controls.Add(lab1);
                    //}
                }
                else if (carDiretion == "E")
                {
                    Label lab1 = new Label();
                    lab1.Location = new Point(pan1.Size.Width - pan1.Size.Height / 6, 0);
                    if (carType == 0)
                    {
                        lab1.Size = new Size(pan1.Size.Height / 5, pan1.Size.Height);
                        lab1.BackColor = Color.White;
                        lab1.Text = "车头";
                        lab1.TextAlign = ContentAlignment.MiddleCenter;
                        pan1.Controls.Add(lab1);
                    }
                    //else if (carType == 2)
                    //{
                    //    lab1.Size = new Size(pan2.Size.Height, pan2.Size.Height);
                    //    lab1.BackColor = Color.Red;
                    //    pan2.Controls.Add(lab1);
                    //}
                    //else if (carType == 2)
                    //{
                    //    lab1.Size = new Size(pan2.Size.Height, pan2.Size.Height);
                    //    lab1.BackColor = Color.Red;
                    //    pan2.Controls.Add(lab1);
                    //}
                }
            }

            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        /// <summary>
        /// 虚拟车XXX
        /// </summary>
        /// <param name="dictLaserData"></param>
        //public void CreatVirtualCarSize(Dictionary<string, LASER_DATA> dictLaserData)
        //{
        //    if (dictLaserData.Count != 0)
        //    {
        //        Bitmap bitM1;  //实例化一个新画布
        //        Graphics g1;   //创建Graphics对象
        //        //初始化画布

        //        //  c车位（10，10）
        //        panelVirtualCar.Location = new Point(labPark.Location.X + 10, labPark.Location.Y + 10);
        //        panelVirtualCar.Size = new Size(labPark.Size.Width - 20, labPark.Size.Height - 20);

        //        bitM1 = new Bitmap(this.panelVirtualCar.Width, this.panelVirtualCar.Height);
        //        g1 = Graphics.FromImage(bitM1);
        //       // panelVirtualCar.Size = new Size(n4, n3);
        //        foreach (string key in dictLaserData.Keys)
        //        {
        //            int grooveX = Convert.ToInt32(dictLaserData[key].GROOVE_ACT_X);
        //            int grooveY = Convert.ToInt32(dictLaserData[key].GROOVE_ACT_Y);
        //            int n5 = Convert.ToInt32(Math.Abs(grooveY * YRatio + YOffset));
        //            int n6 = Convert.ToInt32(Math.Abs(grooveX * XRatio + XOffset));
        //            //线： X 不变，Y固定
        //            g1.DrawLine(myPen, n5, panelVirtualCar.Location.Y, n5, panelVirtualCar.Location.Y);
        //        }
        //        this.panelVirtualCar.BackgroundImage = bitM1;                //将画布设为panel1控件的背景图
        //        pan1.Controls.Add(panelVirtualCar);
        //    }
        //}


        /// <summary>
        /// 生成钢卷图像
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xLength"></param>
        /// <param name="yLength"></param>
        public void CreateCoilSize(int x, int y, int coilWidth, int coilOutSide, string GrooveNO,bool hasCoil)
        {
            Label lab1 = new Label();
            int n3 = Convert.ToInt32(coilWidth * XRatio);
            int n4 = Convert.ToInt32(coilOutSide * YRatio);
            //中心坐标-高度/2=位置Y,中心坐标-宽度/2=位置X
            int n1 = Convert.ToInt32(Math.Abs(y * YRatio + YOffset));
            int n2 = Convert.ToInt32(Math.Abs(x * XRatio + XOffset));
            //X：画面坐标=|转换坐标（负的）|-车位置偏移   Y： 画面坐标=转换坐标-车位位置偏移
            lab1.Location = new Point(n1 + YOffset1 - pan2.Location.X - n4 / 2 , n2 + XOffset1 - pan2.Location.Y - n3 / 2);
            lab1.Size = new Size(n4, n3);
            //lab1.Size = new Size(10, 10);
            //字体,生成槽号
            lab1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lab1.TextAlign = ContentAlignment.MiddleCenter;
            lab1.Text = GrooveNO;
            //
            if (hasCoil)
            {
               lab1.BackColor = Color.Gray;
            }
            else
            {
                lab1.BackColor = Color.Red;
            }
            if (!HasCarSize)
            {
                lab1.Location = new Point(n1 + YOffset1   - n4 / 2 , n2 + XOffset1  - n3 / 2);
                this.pan1.Controls.Add(lab1);
                return;
            }
            this.pan2.Controls.Add(lab1);
        }

        public void CreateCoilSize(int x, int y, int coilWidth, int coilOutSide, string GrooveNO, bool hasCoil, string coilMatNO, ToolTip toolTip)
        {
            Label lab1 = new Label();
            int n3 = Convert.ToInt32(coilWidth * XRatio);
            int n4 = Convert.ToInt32(coilOutSide * YRatio);
            //中心坐标-高度/2=位置Y,中心坐标-宽度/2=位置X
            int n1 = Convert.ToInt32(Math.Abs(y * YRatio + YOffset));
            int n2 = Convert.ToInt32(Math.Abs(x * XRatio + XOffset));
            //X：画面坐标=|转换坐标（负的）|-车位置偏移   Y： 画面坐标=转换坐标-车位位置偏移
            lab1.Location = new Point(n1 + YOffset1 - pan2.Location.X - n4 / 2, n2 + XOffset1 - pan2.Location.Y - n3 / 2);
            lab1.Size = new Size(n4, n3);
            //lab1.Size = new Size(10, 10);
            //字体,生成槽号
            lab1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lab1.TextAlign = ContentAlignment.MiddleCenter;
            lab1.Name = coilMatNO;
            lab1.Text = GrooveNO;

            string ToolTipShow = String.Format("槽索引： {0} \n钢卷号: {1} \n槽坐标X： {2}\n槽坐标Y： {3}", lab1.Text, lab1.Name, x, y);
            toolTip.SetToolTip(lab1, ToolTipShow);
            lab1.Click += lab1_Click;
            lab1.BringToFront();
            //
            if (hasCoil)
            {
                lab1.BackColor = Color.LightGray;
            }
            else
            {
                lab1.BackColor = Color.Red;
            }
            if (!HasCarSize)
            {
                //lab1.Location = new Point(n1 + YOffset1 - n4 / 2, n2 + XOffset1 - n3 / 2);
                //string ToolTipShow = String.Format("槽号： {0} \n钢卷号: {1} \nX坐标： {2}\nY坐标： {3}", GrooveNO, coilMatNO, x, y);
                //toolTip.SetToolTip(lab1, ToolTipShow);
                //lab1.Click += lab1_Click;
                //lab1.BringToFront();
                this.pan1.Controls.Add(lab1);
                return;
            }

            this.pan2.Controls.Add(lab1);

        }

        public void CreateCoilSize(int x, int y, int coilWidth, int coilOutSide, string GrooveNO, bool hasCoil, string coilMatNO, ToolTip toolTip,int coilStaus)
        {
            Label lab1 = new Label();
            int n3 = Convert.ToInt32(coilWidth * XRatio);
            int n4 = Convert.ToInt32(coilOutSide * YRatio);
            //中心坐标-高度/2=位置Y,中心坐标-宽度/2=位置X
            int n1 = Convert.ToInt32(Math.Abs(y * YRatio + YOffset));
            int n2 = Convert.ToInt32(Math.Abs(x * XRatio + XOffset));
            //X：画面坐标=|转换坐标（负的）|-车位置偏移   Y： 画面坐标=转换坐标-车位位置偏移
            lab1.Location = new Point(n1 + YOffset1 - pan2.Location.X - n4 / 2, n2 + XOffset1 - pan2.Location.Y - n3 / 2);
            lab1.Size = new Size(n4, n3);
            //lab1.Size = new Size(10, 10);
            //字体,生成槽号
            lab1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lab1.TextAlign = ContentAlignment.MiddleCenter;
            lab1.Name = coilMatNO;
            lab1.Text = GrooveNO;

            string ToolTipShow = String.Format("槽号： {0} \n钢卷号: {1} \n槽坐标X： {2}\n槽坐标Y： {3}", GrooveNO, lab1.Name, x, y);
            toolTip.SetToolTip(lab1, ToolTipShow);
            lab1.Click += lab1_Click;
            lab1.BringToFront();
            //
            if (hasCoil)
            {
                //封锁标记(0:可用 1:待判 2:封锁)
                //if (coilStaus==0)
                //{
                //    lab1.BackColor = Color.Gray;
                //}
                //else if (coilStaus == 1)
                //{
                //    lab1.BackColor = Color.Red;
                //}
                //else
                //{
                //    lab1.BackColor = Color.Red;
                //}
                lab1.BackColor = Color.Gray;
            }
            else
            {
                lab1.BackColor = Color.White;
            }
            if (!HasCarSize)
            {
                //lab1.Location = new Point(n1 + YOffset1 - n4 / 2, n2 + XOffset1 - n3 / 2);
                //string ToolTipShow = String.Format("槽号： {0} \n钢卷号: {1} \nX坐标： {2}\nY坐标： {3}", GrooveNO, coilMatNO, x, y);
                //toolTip.SetToolTip(lab1, ToolTipShow);
                //lab1.Click += lab1_Click;
                //lab1.BringToFront();
                this.pan1.Controls.Add(lab1);
                return;
            }

            this.pan2.Controls.Add(lab1);

        }
        /// <summary>
        /// 改变已上车卷颜色
        /// </summary>
        /// <param name="matNO"></param>
        /// <param name="coilState"></param>
        /// <param name="carType"></param>
        public void ChangeCoilState(string matNO, string  coilState, string carType)
        {
            if (carType=="0")  //社会车
            {
                foreach (var item in pan1.Controls)
                {
                    if (item is Label)
                    {
                        Label labItem = (Label)item;
                        if (labItem.Name == matNO && coilState == "100")
                        {
                            labItem.BackColor = Color.Gray;
                        }
                        else if (true)
                        {
                            
                        }
                    }

                    else
                    { 
                    
                    }
                }
            }
            else if (carType=="1")  //框架车
            {
                foreach (Label item in pan2.Controls)
                {
                    if (item is Label)
                    {
                        Label labItem = (Label)item;
                        if (labItem.Name == matNO && coilState == "100")
                        {
                            labItem.BackColor = Color.Gray;
                        }
                    }
                    else
                    { 
                    
                    }
                } 
            }

        }

        /// <summary>
        /// 改变已上车卷颜色
        /// </summary>
        /// <param name="matNO"></param>
        /// <param name="coilState"></param>
        /// <param name="hascarSize"></param>
        /// <param name="hasCoil"></param>
        public void ChangeCoilState(string matNO, string coilState, bool hascarSize,bool hasCoil)
        {
            if (coilState!="100")
            {
                return;
            }
            if (!hascarSize)  //无边框
            {
                foreach (var item in pan1.Controls)
                {
                    if (item is Label)
                    {
                        Label labItem = (Label)item;
                        if (labItem.Name == matNO && coilState == "100" && hasCoil)
                        {
                            labItem.BackColor = Color.Gray;
                        }
                        else if (labItem.Name == matNO && coilState == "100" && !hasCoil)
                        {
                            labItem.BackColor = Color.White;
                        }
                    }

                    else
                    {

                    }
                }
            }
            else if (hascarSize)  //有边框
            {
                foreach (Label item in pan2.Controls)
                {
                    if (item is Label)
                    {
                        Label labItem = (Label)item;
                        if (labItem.Name == matNO && coilState == "100" && hasCoil)
                        {
                            labItem.BackColor = Color.Gray;
                        }
                        else if (labItem.Name == matNO && coilState == "100" && !hasCoil)
                        {
                            labItem.BackColor = Color.White;
                        }
                    }
                    else
                    {

                    }
                }
            }

        }
        public void lab1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("6666");
            //LabClick(coilMatNO);           
            Label lab = (Label) sender;
            if (LabClick != null)
            {
                LabClick(lab.Name);
            }
        }
        /// <summary>
        /// 设置车上卷材料号
        /// </summary>
        /// <param name="matNO"></param>
        /// <param name="coilState"></param>
        /// <param name="carType"></param>
        public void SetCoilsNmae(string GrooveID, string matNO, ToolTip toolTip)
        {
 
                foreach (var item in pan1.Controls)
                {
                    if (item is Label)
                    {
                        Label labItem = (Label)item;
                        if (labItem.Name == GrooveID)
                        {
                            labItem.Name = matNO;
                            labItem.BackColor = Color.Gray;
                            string ToolTipShow = String.Format("槽索引： {0} \n钢卷号: {1}", labItem.Text, labItem.Name);
                            toolTip.SetToolTip(labItem, ToolTipShow);
                        }
                    }
                    else
                    {

                    }
                }


        }
        public void SetCoilsNmae(string index, string GrooveID, string matNO, ToolTip toolTip)
        {

            foreach (var item in pan1.Controls)
            {
                if (item is Label)
                {
                    Label labItem = (Label)item;
                    if (labItem.Name == index)
                    {
                        labItem.Name = matNO;
                        labItem.Text = GrooveID;
                        labItem.BackColor = Color.Gray;
                        string ToolTipShow = String.Format("槽号： {0} \n钢卷号: {1}", labItem.Text, labItem.Name);
                        toolTip.SetToolTip(labItem, ToolTipShow);
                    }
                }
                else
                {

                }
            }
        }
        public void CreateLaserLocation(int x, int y, int coilWidth, int coilOutSide)
        {
            Label lab1 = new Label();
            int n3 = Convert.ToInt32(coilWidth * XRatio);
            int n4 = Convert.ToInt32(coilOutSide * YRatio);
            //中心坐标-高度/2=位置Y,中心坐标-宽度/2=位置X
            int n1 = Convert.ToInt32(Math.Abs(y * YRatio + YOffset));
            int n2 = Convert.ToInt32(Math.Abs(x * XRatio + XOffset));
            //X：画面坐标=|转换坐标（负的）|-车位置偏移   Y： 画面坐标=转换坐标-车位位置偏移
            lab1.Location = new Point(n1 + YOffset1 - pan2.Location.X, n2 + XOffset1 - pan2.Location.Y - n3 / 2);
            lab1.Size = new Size(n4, n3);
            //lab1.Size = new Size(10, 10);
            //字体,生成槽号
            lab1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lab1.TextAlign = ContentAlignment.MiddleCenter;

            //
            lab1.BackColor = Color.Red;
            if (!HasCarSize)
            {
                lab1.Location = new Point(n1 + YOffset1 - pan2.Location.X, n2 + XOffset1 - pan2.Location.Y - n3 / 2);
                this.pan1.Controls.Add(lab1);
                return;
            }
            this.pan2.Controls.Add(lab1);
        }

        /// <summary>
        /// 获取控件大小
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        public void InitializeXY(int Width, int Height)
        {
            ClearbitM();
            labWidth = Width;  //X
            labHeight = Height;  //Y
        }
        /// <summary>
        /// 坐标比率
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        private decimal GetRatio(int n1, int n2)
        {
            decimal ret = 1;
            ret = Math.Round((decimal)n1 / n2, 5); ;
            return ret;
        }
        /// <summary>
        /// 初始化坐标偏移量
        /// </summary>
        /// <param name="X1">实际X</param>
        /// <param name="Y1">实际Y</param>
        /// <returns></returns>
        private bool InitializeOffsetXY(int XNIM, int YMAX)
        {
            bool ret = false;
            try
            {
                //实际*比率+偏移量 = 画面参数
                //坐标转换  (YMAX,XNIM) --> (5,5)
                XOffset = Convert.ToInt32(5 - XNIM * XRatio);
                YOffset = Convert.ToInt32(5 - YMAX * YRatio);
                XOffset1 = -5;
                YOffset1 = -5;
                return ret;
            }

            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                return ret;
            }

        }

        public void ClearbitM()
        {
            //bitM.Dispose();
            pan2.Controls.Clear();
            pan1.Controls.Clear();
            g.Dispose();
        }
    }
}
