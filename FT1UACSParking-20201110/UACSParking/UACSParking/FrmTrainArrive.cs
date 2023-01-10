using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkClassLibrary;

namespace UACSParking
{
   public delegate void sendTrainsCount(string railwayLineNO ,int count );
    public partial class FrmTrainArrive : Form
    {
        public event sendTrainsCount sendTrainsCount;
        //ClsParkingManager parkingManager = new ClsParkingManager();
        string railWayLineNO;

        public string RailWayLineNO
        {
            get { return railWayLineNO; }
            //set { railWayLineNO = value; }
        }
        int trainCaseCount = 0 ;

        public int TrainCaseCount
        {
            get { return trainCaseCount; }
            set { trainCaseCount = value; }
        }
        public FrmTrainArrive()
        {
            InitializeComponent();
            this.Load += FrmTrainArrive_Load;
        }

        public FrmTrainArrive(string _trainNO)
        {
            InitializeComponent();
            this.Load += FrmTrainArrive_Load;
            railWayLineNO = _trainNO;
        }
        void FrmTrainArrive_Load(object sender, EventArgs e)
        {
            BindRailwayLineNO(railWayLineNO);
            BindScanCrane(railWayLineNO);
            //添加默认指定行车
            //cbbScanCrane.SelectedIndex = cbbScanCrane.FindString("8#行车"); 
            txtTrainSection.KeyPress += txtTrainSection_KeyPress;
            txtStartPoint_X.KeyPress += txtStartPoint_X_KeyPress;
            txtEndPoint_X.KeyPress += txtStartPoint_X_KeyPress;
        }

        void txtStartPoint_X_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txtSender = (TextBox)sender;
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtSender.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtSender.Text, out oldf);
                    b2 = float.TryParse(txtSender.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        void txtTrainSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 || (int)e.KeyChar == 46)
                e.Handled = true;
            if ((int)e.KeyChar == 48 ) // 两位 可输入0/1
            {
                if (txtTrainSection.Text.Length <= 0 || txtTrainSection.Text.Length >= 2 || Convert.ToInt32(txtTrainSection.Text.Trim()) != 1)
                    e.Handled = true;
            }
            else if (txtTrainSection.Text.Trim() == "1" && (int)e.KeyChar == 49)
            {
                e.Handled = false;
            }
            else
            {
                if (txtTrainSection.Text.Length >= 1 &&  (int)e.KeyChar != 8)
                    e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            TrainCaseCount = 0;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                int tmp;
                if (!int.TryParse(txtTrainSection.Text.Trim(), out tmp) || tmp>11)
                {
                    MessageBox.Show("输入数据不合法！", "提示");
                    return;
                }
                int xStart, xEnd;
                if (!int.TryParse(txtStartPoint_X.Text.Trim(),out xStart) || xStart<0)
                {
                    MessageBox.Show("输入数据不合法！", "提示");
                    return;
                }
                if (!int.TryParse(txtEndPoint_X.Text.Trim(),out xEnd)|| xStart>xEnd)
                {
                    MessageBox.Show("输入数据不合法！", "提示");
                    return;
                }
                int scanCrane;
                if (cbbScanCrane.Text =="")
                {
                    MessageBox.Show("请指定扫描行车！");
                    cbbScanCrane.Focus();
                    return;
                }
                scanCrane = Convert.ToInt32(cbbScanCrane.SelectedValue);
                setScanCrane(scanCrane);
                railWayLineNO = cmbbLineName.SelectedValue.ToString();
                TrainCaseCount = tmp;
                string tagValue = "";

                int temp = Convert.ToInt32(txtEndPoint_X.Text) + 6000;
                      
                tagValue = railWayLineNO + "|" + txtTrainSection.Text.Trim() + "|" + txtStartPoint_X.Text + "|" + temp ;
                //DialogResult dr = MessageBox.Show("是否发送tagVaule： " + tagValue, "调试", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                //if (dr == DialogResult.OK)
                //{
                //    ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_ARRIVE, tagValue); //PT55|2
                //    UACSUtility.HMILogger.WriteLog(btnConfirm.Text, "火车到位：" + tagValue, UACSUtility.LogLevel.Info, this.Text);

                //    //return;
                //}

                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_ARRIVE, tagValue); //PT55|2
                UACSUtility.HMILogger.WriteLog(btnConfirm.Text, "火车到位：" + tagValue, UACSUtility.LogLevel.Info, this.Text);

                if (sendTrainsCount != null)
                {
                    sendTrainsCount(railWayLineNO ,Convert.ToInt32(txtTrainSection.Text.Trim()));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void BindRailwayLineNO(string _trainLine)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr = dt.NewRow();

            dr = dt.NewRow();
            dr["TypeValue"] = _trainLine;
            dr["TypeName"] =string.Format("{0}{1}",  _trainLine.Contains("PT55")?"A跨 ":_trainLine.Contains("PT57")?"C跨 ": "" , _trainLine);
            dt.Rows.Add(dr);

            //绑定列表下拉框数据
            this.cmbbLineName.DataSource = dt;
            this.cmbbLineName.DisplayMember = "TypeName";
            this.cmbbLineName.ValueMember = "TypeValue";
        }

        private void BindScanCrane(string _trainLine)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr = dt.NewRow();
            if (_trainLine.Contains("PT55"))
            {

                dr = dt.NewRow();
                dr["TypeValue"] = 1;
                dr["TypeName"] = "1#行车";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = 2;
                dr["TypeName"] = "2#行车";
                dt.Rows.Add(dr);

            }

            else  if (_trainLine.Contains("PT57"))
            {
                if (_trainLine.Contains("PT57A"))
                {
                    dr = dt.NewRow();
                    dr["TypeValue"] = 8;
                    dr["TypeName"] = "8#行车";
                    dt.Rows.Add(dr);
                }

                else if (_trainLine.Contains("PT57B"))
                {
                    dr = dt.NewRow();
                    dr["TypeValue"] = 7;
                    dr["TypeName"] = "7#行车";
                    dt.Rows.Add(dr);
                }
                else
                {
                    return;
                }
                
            }

            //绑定列表下拉框数据
            this.cbbScanCrane.DataSource = dt;
            this.cbbScanCrane.DisplayMember = "TypeName";
            this.cbbScanCrane.ValueMember = "TypeValue";
        }

        private void FrmTrainArrive_Activated(object sender, EventArgs e)
        {
            txtTrainSection.Focus();
        }
        private void setScanCrane(int craneNO)
        {
            try
            {
                string sql = "UPDATE UACS_CRANE_SCAN_MOVE_REQUEST SET CRANE_NO = '" + craneNO + "'";
                sql += " WHERE PARKING_NO = '"+ railWayLineNO+ "'";
                ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteNonQuery(sql);  //.ExecuteReader(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
    }
}
