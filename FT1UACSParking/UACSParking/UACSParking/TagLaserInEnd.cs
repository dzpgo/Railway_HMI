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
    public partial class TagLaserInEnd : Form
    {
        public string TAG_PARKING_NO = "";
        public string TAG_CAR_NO = "";
        public string TAG_TREATMENT_NO = "";
        public string TAG_LASER_ACTION_COUNT = "";
        public bool CANCEL_FLAG = false;

        public TagLaserInEnd()
        {
            InitializeComponent();
        }

        public TagLaserInEnd(string ParkingNo, string CarNO, string TreatmentNO, string LastLaserAccount)
        {
            InitializeComponent();
            comb_ParkingNO.Text = ParkingNo;
            txt_CarNO.Text = CarNO;
            txt_TREATMENT_NO.Text = TreatmentNO;
            txt_LASER_ACTION_COUNT.Text = LastLaserAccount;
        }

        #region 页面加载
        private void TagLaserInEnd_Load(object sender, EventArgs e)
        {
            try
            {
                //设置背景色
                this.panel1.BackColor = Color.FromArgb(242, 246, 252);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 确定
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                TAG_PARKING_NO = comb_ParkingNO.Text.ToString().Trim();
                TAG_CAR_NO = txt_CarNO.Text.ToString().Trim();
                TAG_TREATMENT_NO = txt_TREATMENT_NO.Text.ToString().Trim();
                TAG_LASER_ACTION_COUNT = txt_LASER_ACTION_COUNT.Text.ToString().Trim();
                CANCEL_FLAG = false;

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
                CANCEL_FLAG = true;
                this.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }
        #endregion
    }
}
