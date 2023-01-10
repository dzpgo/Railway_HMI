using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkClassLibrary;
using System.Drawing.Drawing2D;

namespace UACSParking
{
    public delegate void SendParam(string mode, string kind, string num);
    public delegate void SendTrainCls(ClsTrainCase clsTrain);
    public partial class railwayCarriage : UserControl
    {
        
        public event SendParam SendParam;
        public event SendTrainCls SendTrainCls;
        private ClsTrainCase clsTrainCase= new ClsTrainCase();

        public ClsTrainCase ClsTrainCase 
        {
            get { return clsTrainCase; }
           // set { clsTrainCase = (ClsTrainCase )value.Clone(); updataTrain(); }
        }

        public void setClsTrainCase(ClsTrainCase valueClsTrainCase)
       {
           clsTrainCase = (ClsTrainCase)valueClsTrainCase.Clone(); updataTrain(); 
       }


        public railwayCarriage()
        {
            InitializeComponent();
        }
        public railwayCarriage(Size ControlSize)
        {
            InitializeComponent();
            this.Size = ControlSize;
            //long ratio_X = ControlSize.Width / this.Size.Width;
            //long ratio_Y = ControlSize.Height / this.Size.Width;
            this.Load += railwayCarriage_Load;
            tableLayoutPanel1.Click += tableLayoutPanel1_Click;
            foreach (Control item in tableLayoutPanel1.Controls)
            {
                //initControlProperty(ratio_X, ratio_Y, item);
                item.Click += tableLayoutPanel1_Click;
            }
        }

        void railwayCarriage_Load(object sender, EventArgs e)
        {

        }


        void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            try
            {
                //if (SendParam != null)
                //SendParam(Mode, Kind, TrainNum);
                if (SendTrainCls!=null)
                {
                    SendTrainCls(clsTrainCase);
                }
            }
            catch (Exception meg)
            {
                MessageBox.Show(string.Format("railwayCarriage : UserControl调用函数SendParam出错：{0} \r\n{1}", meg.Message,meg.StackTrace));
            }
        }
        private void initControlProperty(long raito_x, long raito_y, Control control)
        {
            control.Location = new System.Drawing.Point((int)raito_x * control.Location.X, (int)raito_y * control.Location.Y);
            control.Size = new System.Drawing.Size((int)raito_x * control.Size.Width, (int)raito_y * control.Size.Height);
        }

        public void setBackColor(Color color)
        {
            foreach (Control item in tableLayoutPanel1.Controls)
            {
                item.BackColor = color;
            }
            tableLayoutPanel1.BackColor = color;
        }
        public void updataTrain()
        {
            labCount.Text = clsTrainCase.TrainCaseNO + "-" + clsTrainCase.TrainCaseName;
            switch (clsTrainCase.Specification)
            {
                case ClsParkingManager.TRAIN_SPECIFICATION_C60:
                    labTrainCaseType.Text = "60吨";
                    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C61:
                    labTrainCaseType.Text = "61吨";
                    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C70:
                    labTrainCaseType.Text = "70吨";
                    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C71:
                    labTrainCaseType.Text = "71吨";
                    break;

                case ClsParkingManager.TRAIN_SPECIFICATION_C60_1:
                    labTrainCaseType.Text = "睿力60吨";
                    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C61_1:
                    labTrainCaseType.Text = "睿力61吨";
                    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C70_1:
                    labTrainCaseType.Text = "睿力70吨";
                    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C71_1:
                    labTrainCaseType.Text = "睿力71吨";
                    break;
                default:
                    labTrainCaseType.Text = "没定义";
                    break;
            }
            labTrainCaseType.ForeColor = ClsTrainCase.IsConfirmTrainCaseType ? Color.Black : Color.White;
            labStowage.ForeColor = ClsTrainCase.IsConfirmStowageType ? Color.Black : Color.White;
            labStowage.Text = clsTrainCase.StowageType;
        }

        private void label1_Paint(Control c)
        {
            using (Graphics formGraphics = c.CreateGraphics())
            {
                List<Point> lstPioit1 = new List<Point>();
                List<Point> lstPioit2 = new List<Point>();
                lstPioit1.Add(new Point(5, 7));
                lstPioit1.Add(new Point(10, 10));
                lstPioit1.Add(new Point(10, 15));
                lstPioit2.Add(new Point(10, 10));
                lstPioit2.Add(new Point(10, 15));
                lstPioit2.Add(new Point(20, 0));
                using (var path = new GraphicsPath())
                {
                    path.AddLines(lstPioit1.ToArray());
                    formGraphics.FillPath(Brushes.Green, path);
                    path.Reset();
                    path.AddLines(lstPioit2.ToArray());
                    formGraphics.FillPath(Brushes.Green, path);
                }
            }
        }


    }
}
