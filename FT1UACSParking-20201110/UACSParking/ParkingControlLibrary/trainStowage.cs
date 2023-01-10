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
    enum braketType
    {
        L = 0,
        M = 1,
        R = 2
    };
    enum RowIndex
    {
        L = 0,
        M = 1,
        R = 2

    };
    public delegate void SendSowageTrainCls(ClsTrainCase clsTrain);
    public delegate void SendLabName(string labNane);

    public partial class trainStowage : UserControl
    {
        
        public event SendSowageTrainCls SendSowageTrainCls;
        public event SendLabName SendLabName;
        private ClsTrainCase clsTrainStowage = new ClsTrainCase();
        string currClickLabelName;
        int coilsCountLeft ,coilsCountMiddle ,coilsCountRight;
        ToolTip toolTip1 = new ToolTip();
        //坐标转换
        decimal XRatio, YRatio;
        int XOffset, YOffset;
        public ClsTrainCase ClsTrainStowage
        {
            get { return clsTrainStowage; }
            //set { clsTrainStowage = (ClsTrainCase)value.Clone(); }
        }

        public void setClsTrainCase(ClsTrainCase valueClsTrainCase)
        {
            clsTrainStowage = (ClsTrainCase)valueClsTrainCase.Clone();
        }
        public trainStowage()
        {
            InitializeComponent();
            XRatio = YRatio = 1;
            XOffset = YOffset = 0;
            this.Load += trainStowage_Load;
        }

        void trainStowage_Load(object sender, EventArgs e)
        {
            pnlTrainCase.Paint += panel1_Paint;
            #region  tooltipshow
            // Create the ToolTip and associate with the Form container.
            
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            #endregion
        }

        void panel1_Paint(object sender, PaintEventArgs e)
        {
            int lineHeght, lineWidth; //坐标点（5，5）
            lineHeght = this.Height - 5;
            lineWidth = this.Width / 3 -5 ;
            int offSet = 3;
            base.OnPaint(e);
            Pen myPen = new Pen(Color.Blue, 2.0f);
            Rectangle rtg1 = new Rectangle(new Point(1 + offSet, 1), new Size(lineWidth, lineHeght));
            Rectangle rtg2 = new Rectangle(new Point(pnlTrainCase.Width / 3 + offSet, 1), new Size(lineWidth, lineHeght));
            Rectangle rtg3 = new Rectangle(new Point(pnlTrainCase.Width / 3 * 2 + offSet, 1), new Size(lineWidth, lineHeght));
            e.Graphics.DrawRectangle(myPen, rtg1);
            e.Graphics.DrawRectangle(myPen, rtg2);
            e.Graphics.DrawRectangle(myPen, rtg3);
        }
        //根据配载类型生成钢支架
        private void craetStowage_Old(string stowageType)
        {
            pnlTrainCase.Controls.Clear();
            if (stowageType == null)
            {
                return;
            } 
            string bracketLeft = stowageType.Substring(0, stowageType.IndexOf("--"));
            string bracketMiddle = stowageType.Substring(stowageType.IndexOf("--") + 2, stowageType.LastIndexOf("--") - 2 - bracketLeft.Length);
            string brackRight = stowageType.Substring(stowageType.LastIndexOf("--") +2);
            string[] braketsLeft = bracketLeft.Split('-');
            string[] braketsMiddle = bracketMiddle.Split('-');
            string[] braketsRight = brackRight.Split('-');

            coilsCountLeft = braketsLeft.Contains("0") && braketsLeft.Length == 1 ? 0 : braketsLeft.Length;
            coilsCountMiddle = braketsMiddle.Contains("0") && braketsMiddle.Length == 1 ? 0 : braketsMiddle.Length;
            coilsCountRight = braketsRight.Contains("0") && braketsRight.Length == 1 ? 0 : braketsRight.Length;

            for (int i = 0; i < braketsRight.Count<string>(); i++)
            {
                creatCoil(Convert.ToInt32(braketsRight[i]), (int)braketType.R, i);
            }
            for (int i = 0; i < braketsMiddle.Count<string>(); i++)
            {
                creatCoil(Convert.ToInt32(braketsMiddle[i]), (int)braketType.M, i);
            }
            for (int i = 0; i < braketsLeft.Count<string>(); i++)
            {
                creatCoil(Convert.ToInt32(braketsLeft[i]), (int)braketType.L, i);
            }
        }
        private void craetStowage(string stowageType)
        {
            pnlTrainCase.Controls.Clear();
            if (stowageType == null || !stowageType.Contains("--"))
            {
                return;
            }
            string bracketLeft = stowageType.Substring(0, stowageType.IndexOf("--"));
            string bracketMiddle = stowageType.Substring(stowageType.IndexOf("--") + 2, stowageType.LastIndexOf("--") - 2 - bracketLeft.Length);
            string brackRight = stowageType.Substring(stowageType.LastIndexOf("--") + 2);
            string[] braketsLeft = bracketLeft.Split('-');
            string[] braketsMiddle = bracketMiddle.Split('-');
            string[] braketsRight = brackRight.Split('-');

            coilsCountLeft = braketsLeft.Contains("0") && braketsLeft.Length == 1 ? 0 : braketsLeft.Length;
            coilsCountMiddle = braketsMiddle.Contains("0") && braketsMiddle.Length == 1 ? 0 : braketsMiddle.Length;
            coilsCountRight = braketsRight.Contains("0") && braketsRight.Length == 1 ? 0 : braketsRight.Length;

            for (int i = 0; i < braketsRight.Count<string>(); i++)
            {
                creatCoilNew(Convert.ToInt32(braketsRight[i]), (int)braketType.R, i, coilsCountRight - i);
            }
            for (int i = 0; i < braketsMiddle.Count<string>(); i++)
            {
                creatCoilNew(Convert.ToInt32(braketsMiddle[i]), (int)braketType.M, i, (coilsCountRight + coilsCountMiddle) - i);
            }
            for (int i = 0; i < braketsLeft.Count<string>(); i++)
            {
                creatCoilNew(Convert.ToInt32(braketsLeft[i]), (int)braketType.L, i, (coilsCountLeft + coilsCountMiddle + coilsCountRight) - i);
            }
        }
        /// <summary>
        /// 生成火车支架位置
        /// </summary>
        /// <param name="number">每列支架数量</param>
        /// <param name="bracketIndex">支架位置</param>
        /// <param name="rowIndex">第几列</param>
        private void creatCoil(int number, int bracketIndex, int rowIndex)
        {
            const int WIDTH = 60;
            const int HEIGHT = 40;
            int row_X = 0;
            //int offset = this.Width /3 * bracketIndex + 10;  //200
            int offset = (pnlTrainCase.Width / 3) * bracketIndex + 0;//200
            int offset_X = 10;
            int[] index = { 1, 3, 5 };

            switch (rowIndex)
            {
                case 0:
                    row_X = pnlTrainCase.Width / 9 * rowIndex + offset + offset_X;
                    break;
                case 1:
                    row_X = pnlTrainCase.Width / 9 * rowIndex + offset + offset_X;
                    break;
                case 2:
                    row_X = pnlTrainCase.Width / 9 * rowIndex + offset + offset_X;
                    break;
                default:
                    break;
            }
            switch (number)
            {
                case 1 :
                    Label lab = new Label();
                    lab.Size = new Size(WIDTH, HEIGHT);
                    lab.Location = new Point(row_X, pnlTrainCase.Size.Height / 2  - HEIGHT/2);
                    lab.BackColor = Color.White;
                    lab.Text = string.Format("{0}{1}-{2}", (braketType)bracketIndex,(RowIndex)rowIndex, 0);
                    lab.Name = lab.Text;
                    lab.Click += lab_Click;
                    pnlTrainCase.Controls.Add(lab);
                    if (!clsTrainStowage.TrainCaseCoils.ContainsKey(lab.Text))
                       clsTrainStowage.TrainCaseCoils[lab.Text] = new clsTrainCoils(); 
                    break;
                case 2:
                    for (int i = 0; i < number; i++)
                    {
                        Label lab2 = new Label();
                        lab2.Size = new Size(WIDTH, HEIGHT);
                        lab2.Location = new Point(row_X, pnlTrainCase.Size.Height / 4 * index [i]- HEIGHT / 2);
                        lab2.BackColor = Color.White;
                        lab2.Text = string.Format("{0}{1}-{2}", (braketType)bracketIndex, (RowIndex)rowIndex, i);
                        lab2.Name = lab2.Text;
                        lab2.Click += lab_Click;
                        pnlTrainCase.Controls.Add(lab2);
                        if (!clsTrainStowage.TrainCaseCoils.ContainsKey(lab2.Text))
                             clsTrainStowage.TrainCaseCoils[lab2.Text] = new clsTrainCoils();
                    }

                    //Label lab2_1 = new Label();
                    //lab2_1.Size = new Size(WIDTH, HEIGHT);
                    //lab2_1.Location = new Point(row_X, panel1.Size.Height / 4  - HEIGHT / 2);
                    //lab2_1.BackColor = Color.White;
                    //lab2_1.Text = string.Format("{0}-{1}", number, number-1);
                    //panel1.Controls.Add(lab2_1);
                    break;
                case 3:
                    for (int i = 0; i < number; i++)
                    {
                        Label lab3 = new Label();
                        lab3.Size = new Size(WIDTH, HEIGHT);
                        lab3.Location = new Point(row_X, pnlTrainCase.Size.Height / 6 * index[i] - HEIGHT / 2);
                        lab3.BackColor = Color.White;
                        lab3.Text = string.Format("{0}{1}-{2}", (braketType)bracketIndex, (RowIndex)rowIndex, i);
                        lab3.Name = lab3.Text;
                        lab3.Click += lab_Click;
                        pnlTrainCase.Controls.Add(lab3);
                        if (!clsTrainStowage.TrainCaseCoils.ContainsKey(lab3.Text))
                            clsTrainStowage.TrainCaseCoils[lab3.Text] = new clsTrainCoils();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 生成火车支架位置
        /// </summary>
        /// <param name="number">每列支架数量</param>
        /// <param name="bracketIndex">支架位置</param>
        /// <param name="rowIndex">第几列</param>
        private void creatCoilNew(int number, int bracketIndex, int rowIndex, int columnIndex)
        {
            const int WIDTH = 60;
            const int HEIGHT = 40;
            int row_X = 0;
            //int offset = this.Width /3 * bracketIndex + 10;  //200
            int offset = (pnlTrainCase.Width / 3) * bracketIndex + 0;//200
            int offset_X = 10;
            int[] index = { 1, 3, 5 };

            switch (rowIndex)
            {
                case 0:
                    row_X = pnlTrainCase.Width / 9 * rowIndex + offset + offset_X;
                    break;
                case 1:
                    row_X = pnlTrainCase.Width / 9 * rowIndex + offset + offset_X;
                    break;
                case 2:
                    row_X = pnlTrainCase.Width / 9 * rowIndex + offset + offset_X;
                    break;
                default:
                    break;
            }
            switch (number)
            {
                case 1:
                    Label lab = new Label();
                    lab.Size = new Size(WIDTH, HEIGHT);
                    lab.Location = new Point(row_X, pnlTrainCase.Size.Height / 2 - HEIGHT / 2);
                    lab.BackColor = Color.White;
                    //lab.Text = string.Format("{0}{1}-{2}", (braketType)bracketIndex, (RowIndex)rowIndex, 0);
                    lab.Text = string.Format("{0}-M", columnIndex);
                    lab.Name = lab.Text;
                    lab.TextAlign = ContentAlignment.MiddleCenter;
                    lab.Click += lab_Click;

                    pnlTrainCase.Controls.Add(lab);

                    if (clsTrainStowage.TrainCaseCoils.ContainsKey(lab.Text) && clsTrainStowage.TrainCaseStatus > 10) //配卷完成
                    {
                        lab.Size = new Size(converToHMISize_X(clsTrainStowage.TrainCaseCoils[lab.Text].coilSize.Width),
                            converToHMISize_Y(clsTrainStowage.TrainCaseCoils[lab.Text].coilSize.Height));

                        lab.Location = new Point(converToHMILocation_X(clsTrainStowage.TrainCaseCoils[lab.Text].coilPoint.X - lab.Width/2),
                            converToHMILocation_Y(clsTrainStowage.TrainCaseCoils[lab.Text].coilPoint.Y) -lab.Height/2);

                        if (true)
                        {
                            lab.Location = new Point(this.Size.Width - lab.Location.X, lab.Location.Y);
                        }

                        lab.Name = clsTrainStowage.TrainCaseCoils[lab.Text].MAT_NO;

                    }
                    else
                    {
                        clsTrainStowage.TrainCaseCoils[lab.Text] = new clsTrainCoils();
                        clsTrainStowage.TrainCaseCoils[lab.Text].coilSize = lab.Size;
                        clsTrainStowage.TrainCaseCoils[lab.Text].coilPoint = lab.Location;
                        if (true)
                        {
                            clsTrainStowage.TrainCaseCoils[lab.Text].coilPoint = new Point(this.Size.Width - lab.Location.X , lab.Location.Y);
                        }
                    }

                    

                     string ToolTipShow = string.Format("槽号：{0} \n卷号：{1} \nX坐标：{2}\nY坐标：{3}",
                         lab.Text, clsTrainStowage.TrainCaseCoils[lab.Text].MAT_NO,
                         clsTrainStowage.TrainCaseCoils[lab.Text].coilPoint.X,
                         clsTrainStowage.TrainCaseCoils[lab.Text].coilPoint.Y);
                    toolTip1.SetToolTip(lab, ToolTipShow);
                    break;
                case 2:
                    for (int i = 0; i < number; i++)
                    {
                        Label lab2 = new Label();
                        lab2.Size = new Size(WIDTH, HEIGHT);
                        lab2.Location = new Point(row_X, pnlTrainCase.Size.Height / 4 * index[i] - HEIGHT / 2);
                        lab2.BackColor = Color.White;
                        string rowIndex_ = i == 0 ? "L" : "R";
                        lab2.Text = string.Format("{0}-{1}",  columnIndex,rowIndex_);
                        lab2.Name = lab2.Text;
                        lab2.TextAlign = ContentAlignment.MiddleCenter;
                        lab2.Click += lab_Click;
                        pnlTrainCase.Controls.Add(lab2);
                        if (clsTrainStowage.TrainCaseCoils.ContainsKey(lab2.Text) && clsTrainStowage.TrainCaseStatus > 10)
                        {
                            lab2.Size = new Size(converToHMISize_X(clsTrainStowage.TrainCaseCoils[lab2.Text].coilSize.Width),
                                converToHMISize_Y(clsTrainStowage.TrainCaseCoils[lab2.Text].coilSize.Height));
                            lab2.Location = new Point(converToHMILocation_X(clsTrainStowage.TrainCaseCoils[lab2.Text].coilPoint.X - lab2.Size.Width /2),
                                converToHMILocation_Y(clsTrainStowage.TrainCaseCoils[lab2.Text].coilPoint.Y) - lab2.Size.Height / 2);

                            if (true)
                            {
                                lab2.Location = new Point(this.Size.Width - lab2.Location.X, lab2.Location.Y);
                            }

                            lab2.Name = clsTrainStowage.TrainCaseCoils[lab2.Text].MAT_NO;
                        }
                        else
                        {
                            clsTrainStowage.TrainCaseCoils[lab2.Text] = new clsTrainCoils();
                            clsTrainStowage.TrainCaseCoils[lab2.Text].coilSize = lab2.Size;
                            clsTrainStowage.TrainCaseCoils[lab2.Text].coilPoint = lab2.Location;
                            if (true)
                            {
                                clsTrainStowage.TrainCaseCoils[lab2.Text].coilPoint = new Point(this.Size.Width - lab2.Location.X , lab2.Location.Y);
                            }
                        }

                        

                        string ToolTipShow2 = string.Format("槽号：{0} \n卷号：{1} \nX坐标：{2}\nY坐标：{3}",
                            lab2.Text, clsTrainStowage.TrainCaseCoils[lab2.Text].MAT_NO,
                              clsTrainStowage.TrainCaseCoils[lab2.Text].coilPoint.X,
                             clsTrainStowage.TrainCaseCoils[lab2.Text].coilPoint.Y);
                        toolTip1.SetToolTip(lab2, ToolTipShow2);
                    }

                    break;
                case 3:
                    for (int i = 0; i < number; i++)
                    {
                        Label lab3 = new Label();
                        lab3.Size = new Size(WIDTH, HEIGHT);
                        lab3.Location = new Point(row_X, pnlTrainCase.Size.Height / 6 * index[i] - HEIGHT / 2);
                        lab3.BackColor = Color.White;
                        string rowIndex_ = string.Format("{0}", (RowIndex)number, columnIndex);//
                        lab3.Text = string.Format("{0}-{1}",  (RowIndex)rowIndex,rowIndex_);
                        lab3.Name = lab3.Text;
                        lab3.TextAlign = ContentAlignment.MiddleCenter;
                        lab3.Click += lab_Click;
                        pnlTrainCase.Controls.Add(lab3);
                        if (clsTrainStowage.TrainCaseCoils.ContainsKey(lab3.Text) && clsTrainStowage.TrainCaseStatus > 10 )
                        {
                            lab3.Size = new Size(converToHMISize_X(clsTrainStowage.TrainCaseCoils[lab3.Text].coilSize.Width),
                                 converToHMISize_Y(clsTrainStowage.TrainCaseCoils[lab3.Text].coilSize.Height));

                            lab3.Location = new Point(converToHMILocation_X(clsTrainStowage.TrainCaseCoils[lab3.Text].coilPoint.X - lab3.Width / 2),
                                converToHMILocation_Y(clsTrainStowage.TrainCaseCoils[lab3.Text].coilPoint.Y) - lab3.Height / 2);

                            if (true)
                            {
                                lab3.Location = new Point(this.Size.Width - lab3.Location.X, lab3.Location.Y);
                            }

                            lab3.Name = clsTrainStowage.TrainCaseCoils[lab3.Text].MAT_NO;
                        }
                        else
                        {
                            clsTrainStowage.TrainCaseCoils[lab3.Text] = new clsTrainCoils();
                            clsTrainStowage.TrainCaseCoils[lab3.Text].coilSize = lab3.Size;
                            clsTrainStowage.TrainCaseCoils[lab3.Text].coilPoint= lab3.Location;
                            if (true)
                            {
                                clsTrainStowage.TrainCaseCoils[lab3.Text].coilPoint = new Point(this.Size.Width - lab3.Location.X , lab3.Location.Y);
                            }
                        }

                        


                        string ToolTipShow3 = string.Format("槽号：{0} \n卷号：{1} \nX坐标：{2}\nY坐标：{3}",
                            lab3.Text, clsTrainStowage.TrainCaseCoils[lab3.Text].MAT_NO,
                              clsTrainStowage.TrainCaseCoils[lab3.Text].coilPoint.X,
                             clsTrainStowage.TrainCaseCoils[lab3.Text].coilPoint.Y);
                        toolTip1.SetToolTip(lab3, ToolTipShow3);
                    }
                    break;
                default:
                    break;
            }
        }

        void lab_Click(object sender, EventArgs e)
        {
            if (SendSowageTrainCls != null)
            {
                SendSowageTrainCls(clsTrainStowage);
            }
            if (SendLabName!=null)
            {
                Label lab = (Label)sender;
                SendLabName(lab.Name);
            }
        }
        public void updataStowage()
        {
            craetStowage(clsTrainStowage.StowageType);
            refreshTrainStowage();
        }
        //单击选中颜色改变
        public void setLabBackColor(string labName, Color color) //labName:LL0
        {
            try
            {
                currClickLabelName = labName;
                refreshTrainStowage();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+"\r\n"+ex.StackTrace);
            } 
        }
        //刷新控件显示
        public void refreshTrainStowage()
        {
            if (clsTrainStowage.TrainCaseCoils==null)
            {
                pnlTrainCase.Controls.Clear();
                return;
            }
            foreach (Label item in pnlTrainCase.Controls)
            {
                if (item.Text == currClickLabelName)
                {
                    item.BackColor = Color.LightSkyBlue;
                }
                else if (clsTrainStowage.TrainCaseCoils.ContainsKey(item.Text) &&
                    clsTrainStowage.TrainCaseCoils[item.Text].MAT_NO != "" && 
                    (clsTrainStowage.TrainCaseCoils[item.Text].status == 100 || clsTrainStowage.TrainCaseCoils[item.Text].status == 101))
                {
                    item.BackColor = Color.Gray;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }

        }
        /// <summary>
        /// 重置钢卷数据
        /// </summary>
        public void resetStowage()
        {
            if (clsTrainStowage.StowageType !=null)
            {
                clsTrainStowage.setTrainCaseCoils(new Dictionary<string, clsTrainCoils>());
                craetStowage(clsTrainStowage.StowageType);
                refreshTrainStowage();
            }
        }
        #region 坐标转换
        public void initializeControlToActual(int location_X, int location_Y, int size_X, int size_Y)
        {
            //int X_bloeUp, Y_blowUp;
            //X_bloeUp = 500;
            //Y_blowUp = 500;//放大偏移量
            //XRatio = getRatio(this.pnlTrainCase.Size.Width, size_X + X_bloeUp); 
            //YRatio = getRatio(this.pnlTrainCase.Size.Height, size_Y + Y_blowUp);
            initializeRatio(size_X, size_Y);
            InitializeOffsetXY(location_X, location_Y);
        }
        private void InitializeOffsetXY(int actualLocation_X, int actualLocation_Y)
        {
            //实际*比率+偏移量 = 画面参数
            //坐标转换  (x,y) --> (5,5)
            XOffset = Convert.ToInt32(5 - actualLocation_X * XRatio);
            YOffset = Convert.ToInt32(5 - actualLocation_Y * YRatio);

        }
        private decimal getRatio(int HMIValue, int actualValue)
        {
            decimal ret = 1;
            ret = Math.Round((decimal)HMIValue / actualValue, 5); ;
            return ret;
        }
        public void initializeRatio(int size_X, int size_Y)
        {
            int X_bloeUp, Y_blowUp;
            X_bloeUp = 500;
            Y_blowUp = 500;//放大偏移量
            XRatio = getRatio(this.pnlTrainCase.Size.Width-5, size_X + X_bloeUp);
            YRatio = getRatio(this.pnlTrainCase.Size.Height-5, size_Y + Y_blowUp);
        }
        private int converToHMISize_X(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(XRatio * actualValue);
            return HMIValue;
        }
        private int converToHMISize_Y(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(YRatio * actualValue);
            return HMIValue;
        }
        private Size converToHMISize(Size actualSize)
        {
            Size hmiSize = new Size();
            hmiSize.Width = converToHMISize_X(actualSize.Width);
            hmiSize.Height = converToHMISize_Y(actualSize.Height);
            return hmiSize;
        }
        private int converToHMILocation_X(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(Math.Abs(XRatio * actualValue + XOffset));
            return HMIValue;
        }
        private int converToHMILocation_Y(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(Math.Abs(YRatio * actualValue + YOffset));
            return HMIValue;
        }
        private Point converHMIPoint(Point actualPoint)
        {
            Point hmiPoint = new Point();
            hmiPoint.X = converToHMILocation_X(actualPoint.X);
            hmiPoint.Y = converToHMILocation_X(actualPoint.Y);
            return hmiPoint;
        }
        #endregion
    }
}
