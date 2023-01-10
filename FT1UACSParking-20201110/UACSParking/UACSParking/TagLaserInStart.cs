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
    public partial class TagLaserInStart : Form
    {
        public string TAG_PARKING_NO = "";
        public bool CANCEL_FLAG = false;
        public TagLaserInStart()
        {
            InitializeComponent();
        }

        public TagLaserInStart(string ParkingNO)
        {
            InitializeComponent();
            comb_ParkingNO.Text = ParkingNO;
        }

        private void TagLaserInStart_Load(object sender, EventArgs e)
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                TAG_PARKING_NO = comb_ParkingNO.Text.ToString().Trim();
                CANCEL_FLAG = false;

                this.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }

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
    }
}
