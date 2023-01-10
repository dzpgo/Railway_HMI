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
    public partial class TagCarArrive : Form
    {
        public string TAG_PARKING_NO = "";
        public string TAG_CAR_NO = "";
        public string TAG_HEAD_POSTION = "";
        public string TAG_ISLOADED = "";
        public string TAG_CAR_TYPE = "";
        public string TAG_PARKING_TYPE = "";
        public bool CANCEL_FLAG = false;
        string CHEPAI = "";
        string CAR_NO = "";

        public TagCarArrive()
        {
            InitializeComponent();
        }

        public TagCarArrive(string ParkingNO, string CarNO, string HeadPosition, string IsLoaded)
        {
            InitializeComponent();
            comb_ParkingNO.Text = ParkingNO;
            txt_CarNO.Text = CarNO;
            comb_HeadPosition.Text = HeadPosition;
            comb_IsLoaded.Text = IsLoaded;
        }
        public TagCarArrive(string ParkingNO)
        {
            InitializeComponent();
            comb_ParkingNO.Text = ParkingNO;
            comb_ParkingNO.Enabled = false;
            comb_HeadPosition.Text = "";
            comb_IsLoaded.Text = "重车";
            //comb_IsLoaded.Enabled = false;
            comCarType.Text = "";
            com_parkingType.Text = "一般大车位";
            com_parkingType.Enabled = false;

        }

        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
                    }
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion

        #region 页面加载
        private void TagCarArrive_Load(object sender, EventArgs e)
        {
            try
            {
                //设置背景色
                this.panel1.BackColor = Color.FromArgb(242, 246, 252);

                //下拉停车位数据绑定
                //BindParkingNo();

                //绑定方向
                BindCarDrection();

                //下拉空满标记数据绑定
                BindIsLoaded();

                //下拉车辆类型数据绑定
                BindCarType();

                //下拉停车位类型数据绑定
                BindParkingType();

                comb_HeadPosition.Text = "";
                comb_IsLoaded.Text = "重车";
                comCarType.Text = "";
                com_parkingType.Text = "一般大车位";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #region 绑定下拉框方法
        private void BindParkingNo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            //准备数据（停车位信息表）
            string sqlText = @"SELECT DISTINCT PARKING_NO AS TypeValue FROM UACS_PARKING_STATUS ";
            sqlText = string.Format(sqlText);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeValue"] = rdr["TypeValue"];
                    dt.Rows.Add(dr);
                }
            }

            //多加一个空值
            DataRow dr1 = dt.NewRow();
            //dr1["TypeValue"] = "";
            //dt.Rows.Add(dr1);

            //绑定列表下拉框数据
            this.comb_ParkingNO.DataSource = dt;
            this.comb_ParkingNO.DisplayMember = "TypeValue";
            this.comb_ParkingNO.ValueMember = "TypeValue";
        }

        private void BindIsLoaded()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            //多加一个空值
            DataRow dr = dt.NewRow();
            //dr["TypeValue"] = "";
            //dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "1";
            dr["TypeName"] = "空车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "2";
            dr["TypeName"] = "重车";
            dt.Rows.Add(dr);

            //绑定列表下拉框数据
            this.comb_IsLoaded.DataSource = dt;
            this.comb_IsLoaded.DisplayMember = "TypeName";
            this.comb_IsLoaded.ValueMember = "TypeValue";
        }

        private void BindCarDrection()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr = dt.NewRow();

            dr = dt.NewRow();
            dr["TypeValue"] = "E";
            dr["TypeName"] = "东";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "W";
            dr["TypeName"] = "西";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "S";
            dr["TypeName"] = "南";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "N";
            dr["TypeName"] = "北";
            dt.Rows.Add(dr);

            //绑定列表下拉框数据
            this.comb_HeadPosition.DataSource = dt;
            this.comb_HeadPosition.DisplayMember = "TypeName";
            this.comb_HeadPosition.ValueMember = "TypeValue";
        }

        private void BindCarType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            //多加一个空值
            DataRow dr ;
            //dr["TypeValue"] = "";
            //dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "100";
            dr["TypeName"] = "普通框架";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "101";
            dr["TypeName"] = "一般社会车辆";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "102";
            dr["TypeName"] = "大头娃娃车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "103";
            dr["TypeName"] = "17m社会车辆";
            dt.Rows.Add(dr);

            //绑定列表下拉框数据
            this.comCarType.DataSource = dt;
            this.comCarType.DisplayMember = "TypeName";
            this.comCarType.ValueMember = "TypeValue";
        }

        private void BindParkingType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            //多加一个空值
            DataRow dr = dt.NewRow();
            //dr["TypeValue"] = "";
            //dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "0";
            dr["TypeName"] = "一般大车位";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "1";
            dr["TypeName"] = "大头娃娃车小车位";
            dt.Rows.Add(dr);

            //绑定列表下拉框数据
            this.com_parkingType.DataSource = dt;
            this.com_parkingType.DisplayMember = "TypeName";
            this.com_parkingType.ValueMember = "TypeValue";
        }
        #endregion
        #endregion

        #region 确定
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CHEPAI = btnArea.Text.Trim();                                  //车牌前汉字
                TAG_PARKING_NO = comb_ParkingNO.Text.ToString().Trim();
                TAG_CAR_NO = txt_CarNO.Text.ToString().Trim();
                if (btnArea.Text.Trim() != "空")
                {
                    TAG_CAR_NO = CHEPAI + TAG_CAR_NO;
                }
                if (checkBox_gua.Checked == true)
                {
                    TAG_CAR_NO = TAG_CAR_NO + "挂";
                }
                TAG_HEAD_POSTION = comb_HeadPosition.SelectedValue.ToString().Trim();
                TAG_ISLOADED = comb_IsLoaded.SelectedValue.ToString().Trim();
                TAG_CAR_TYPE = comCarType.SelectedValue.ToString().Trim();
                TAG_PARKING_TYPE = com_parkingType.SelectedValue.ToString().Trim();
                CANCEL_FLAG = true;

                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //CANCEL_FLAG = true;
                this.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 社会车辆车号前汉字
        private void btnArea_Click(object sender, EventArgs e)
        {
            try
            {
                CarNo form = new CarNo();
                form.ShowDialog();
                form.StartPosition = FormStartPosition.CenterScreen;
                this.btnArea.Text = form.Area;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 车号大写锁定事件
        private void txt_CarNO_TextChanged(object sender, EventArgs e)
        {
            CAR_NO = txt_CarNO.Text.ToUpper().ToString().Trim();
            txt_CarNO.Text = CAR_NO;
            txt_CarNO.SelectionStart = txt_CarNO.Text.Length;
            txt_CarNO.SelectionLength = 0;
        }
        #endregion
    }
}
