using Baosight.iSuperframe.TagService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSParking
{
    public partial class FrmCarEntry : Form
    {
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        public FrmCarEntry()
        {
            InitializeComponent();
            this.Load += FrmCarEntry_Load;
        }
        /// <summary>
        /// 停车位
        /// </summary>
        public string PackingNo { get; set; }
        private string carType = "";
        //public string carType = "";
        string carFlag="1";
        string carDirection="";
        bool changeScaneCrane = false;

        public string CarType
        {
            get { return carType; }
            set { carType = value; }
        }
        void FrmCarEntry_Load(object sender, EventArgs e)
        {


            txtPacking.Text = PackingNo;

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add("EV_NEW_PARKING_CARARRIVE", null);
            tagDP.Attach(TagValues);
            BindCarType(cmbCarType);
            this.Text = string.Format("{0}到位", carType);
            //if (carType== "框架车")
            //{
            //    txtDirection.Enabled = true;
            //    //txtDirection.Text = "东";
            //    txtDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            //    cmbCarType.Enabled = true;
                 cmbCarType.SelectedText = "普通框架";
            //    cmbCarType.Text = "普通框架";
            //    cmbCarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //}
            //else if (carType == "社会车")
            //{
            //    cmbCarType.Enabled = true;
            //    txtDirection.Text = "";
            //    //cmbCarType.SelectedText = "一般社会车辆";
            //    cmbCarType.Text = "一般社会车辆";
            //    cmbCarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //}
            BindCarDrection();//绑定方向
            txtDirection.Text = "";
            if (PackingNo.Contains("Z3"))
            {
                labTips.Text = "朝4-1门为南，朝4-4门为北";
            }
            else if (PackingNo.Contains("Z5"))
            {
                labTips.Text = "朝7-1门为东，朝7-9门为西"; 
            }
            else if (PackingNo.Contains("FT"))
            {
                txtDirection.Text = "北";
                labTips.Text = "朝A跨南门为南，朝A跨北门为北。（框架以1号槽准）";
            }
            this.Shown += FrmCarEntry_Shown;
            this.MouseDoubleClick += cbbScanCrane_MouseDoubleClick;
        }

        void cbbScanCrane_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }
            cbbScanCrane.Enabled = true;
            changeScaneCrane = true;
        }


        void FrmCarEntry_Shown(object sender, EventArgs e)
        {
           BindScanCrane(cbbScanCrane);         
           cbbScanCrane.Text = getScanCrane(PackingNo);
           cbbScanCrane.Enabled = false;
        }
        private void BindCarDrection()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr = dt.NewRow();
            if (PackingNo.Contains("Z3") || PackingNo.Contains("FT"))
            {
                dr = dt.NewRow();
                dr["TypeValue"] = "S";
                dr["TypeName"] = "南";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "N";
                dr["TypeName"] = "北";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr["TypeValue"] = "E";
                dr["TypeName"] = "东";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "W";
                dr["TypeName"] = "西";
                dt.Rows.Add(dr);
            }

            //绑定列表下拉框数据
            this.txtDirection.DataSource = dt;
            this.txtDirection.DisplayMember = "TypeName";
            this.txtDirection.ValueMember = "TypeValue";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carType = cmbCarType.Text.Trim();
            if (!txtPacking.Text.ToString().Contains('F') || txtPacking.Text.ToString().Trim()=="请选择")
            {
                MessageBox.Show("请先选择停车位！！", "提示");
                this.Close();
                return;
            }
            //设置扫描行车 
            int temp;
            if ( changeScaneCrane && int.TryParse(cbbScanCrane.SelectedValue.ToString(),out temp))
            {
                setScanCrane(PackingNo, temp);
            }
            //else 
            //{
            //    MessageBox.Show("指定行车有误？");
            //}
            //框架车
            if (carType == "普通框架")
            {
                if (txtCarNo.Text.Length<4)
                {
                    MessageBox.Show("请输入四位以上的车牌号！", "提示");
                    return;
                }
                if (txtCarNo.Text.Trim() != "" || txtDirection.Text.Trim() != "" || txtFlag.Text.Trim() != "" || txtPacking.Text.Trim() != "")
                {
                    //操作人|日期|班次|班组|停车位|车号|空满标记|车头方向|载重能力|设备号
                    //车头位置(东：E 西：W 南：S 北：N)
                    StringBuilder sb = new StringBuilder("HMI");
                    sb.Append("|");
                    sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append(txtPacking.Text.Trim());
                    sb.Append("|");
                    sb.Append(txtCarNo.Text.ToUpper().Trim());
                    sb.Append("|");
                    sb.Append(carFlag.Trim());
                    sb.Append("|");
                   // sb.Append(carDirection.Trim());
                    sb.Append(txtDirection.SelectedValue.ToString().Trim());
                    sb.Append("|");
                    sb.Append("90");
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    string carTypeValue = cmbCarType.SelectedValue.ToString().Trim();
                    sb.Append(carTypeValue); //100
                    sb.Append("|");
                    sb.Append("0");

                    //DialogResult dResult = MessageBox.Show(sb.ToString(), "调试", MessageBoxButtons.YesNo);
                    //if (dResult == DialogResult.No)
                    //{
                    //    return;
                    //}
                    UACSUtility.HMILogger.WriteLog(btnConfirm.Text, "车到位：" + sb.ToString(), UACSUtility.LogLevel.Info, this.Text);
                    tagDP.SetData("EV_NEW_PARKING_CARARRIVE", sb.ToString());
                    DialogResult dr = MessageBox.Show("框架车车到位成功，激光扫描开始，请保证车位上方没有行车经过。", "提示", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("请填写完整");
            }
            else if (carType == "一般社会车辆" || carType == "较低社会车辆")
            {
                if (txtDirection.Text.Trim() == "东")
                {
                    carDirection = "E";
                }
                else if (txtDirection.Text.Trim() == "西")
                {
                    carDirection = "W";
                }
                else if (txtDirection.Text.Trim() == "南")
                {
                    carDirection = "S";
                }
                else if (txtDirection.Text.Trim() == "北")
                {
                    carDirection = "N";
                }
                else
                {
                    MessageBox.Show("请输入车头方向！","提示");
                    return;
                }
                if (txtCarNo.Text.Length < 4)
                {
                    MessageBox.Show("请输入四位以上的车牌号！", "提示");
                    return;
                }
                if (txtCarNo.Text.Trim() != "" || txtDirection.Text.Trim() != "" || txtFlag.Text.Trim() != "" || txtPacking.Text.Trim() != "")
                {
                    //操作人|日期|班次|班组|停车位|车号|空满标记|车头方向|载重能力|设备号|车辆类型
                    //车头位置(东：E 西：W 南：S 北：N)
                    StringBuilder sb = new StringBuilder("HMI");
                    sb.Append("|");
                    sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append(txtPacking.Text.Trim());
                    sb.Append("|");
                    sb.Append(txtCarNo.Text.ToUpper().Trim());
                    sb.Append("|");
                    sb.Append(carFlag.Trim());
                    sb.Append("|");
                    //sb.Append(carDirection.Trim());
                    sb.Append(txtDirection.SelectedValue.ToString().Trim());
                    sb.Append("|");
                    sb.Append("90");
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    string carTypeValue = cmbCarType.SelectedValue.ToString().Trim();
                    sb.Append(carTypeValue); 
                    //sb.Append("101");
                    sb.Append("|");
                    if (carTypeValue=="102")
                    {
                        sb.Append("1");
                    }
                    else
                    {
                        sb.Append("0");
                    }
                    //DialogResult dResult = MessageBox.Show(sb.ToString(), "调试", MessageBoxButtons.YesNo);
                    //if (dResult == DialogResult.No)
                    //{
                    //    return;
                    //}
                    UACSUtility.HMILogger.WriteLog(btnConfirm.Text, "车到位：" + sb.ToString(), UACSUtility.LogLevel.Info, this.Text);
                    tagDP.SetData("EV_NEW_PARKING_CARARRIVE", sb.ToString());
                    DialogResult dr = MessageBox.Show("社会车车到位成功，激光扫描开始，请保证车位上方没有行车经过。", "提示", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("请填写完整");
            }

            else
                MessageBox.Show("不存在该出库类型！");
        }

        private void FrmCarEntry_Activated(object sender, EventArgs e)
        {
            txtCarNo.Focus();
        }

        private void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            string UpTem = txtCarNo.Text;
            txtCarNo.Text = UpTem.ToUpper().Trim();
            txtCarNo.SelectionStart = txtCarNo.Text.Length;
            txtCarNo.SelectionLength = 0;
        }
        private void BindCarType(ComboBox cmbBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr;

            dr = dt.NewRow();
            dr["TypeValue"] = "100";
            dr["TypeName"] = "普通框架";
            dt.Rows.Add(dr); 
            //if (carType == "社会车")
            //{
                dr = dt.NewRow();
                dr["TypeValue"] = "101";
                dr["TypeName"] = "一般社会车辆";
                dt.Rows.Add(dr);

                //dr = dt.NewRow();
                //dr["TypeValue"] = "102";
                //dr["TypeName"] = "大头娃娃车";
                //dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "103";
                //dr["TypeName"] = "17m社会车辆";
                dr["TypeName"] = "较低社会车辆";
                dt.Rows.Add(dr);
            //}
            //if (carType == "框架车")
            //{
                
            //}

            //绑定列表下拉框数据
            cmbBox.DataSource = dt;
            cmbBox.DisplayMember = "TypeName";
            cmbBox.ValueMember = "TypeValue";
        }

        #region 指定行车扫描
        private string getScanCrane(string parkNO)
        {
            string crane = "无";
            try
            {
                string sql = "SELECT CRANE_NO FROM UACS_CRANE_SCAN_MOVE_REQUEST WHERE PARKING_NO ='" + parkNO + "'";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        crane = ParkClassLibrary.ManagerHelper.JudgeStrNull(rdr["CRANE_NO"]);
                        crane += "#行车";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return crane;
        }

        private void setScanCrane(string parkNO, int craneNO)
        {
            try
            {
                string sql = "UPDATE UACS_CRANE_SCAN_MOVE_REQUEST SET CRANE_NO = '" + craneNO + "'";
                sql += " WHERE PARKING_NO = '" + parkNO + "'";
                ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteNonQuery(sql);
                UACSUtility.HMILogger.WriteLog(btnConfirm.Text, "库位扫描行车修改，停车位：" + parkNO + "行车：" + craneNO, UACSUtility.LogLevel.Warn, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void BindScanCrane(ComboBox cmbBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr;

            if (txtPacking.Text.Contains("FT1"))
            {
                dr = dt.NewRow();
                dr["TypeValue"] = "1";
                dr["TypeName"] = "1#车";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "2";
                dr["TypeName"] = "2#车";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "3";
                dr["TypeName"] = "3#车";
                dt.Rows.Add(dr);
            }
            else if (txtPacking.Text.Contains("FT3"))
            {
                dr = dt.NewRow();
                dr["TypeValue"] = "7";
                dr["TypeName"] = "7#车";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "8";
                dr["TypeName"] = "8#车";
                dt.Rows.Add(dr);
            }

            //绑定列表下拉框数据
            cmbBox.DisplayMember = "TypeName";
            cmbBox.ValueMember = "TypeValue";
            cmbBox.DataSource = dt;
        }

        private void cbbScanCrane_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } 
        #endregion
}
