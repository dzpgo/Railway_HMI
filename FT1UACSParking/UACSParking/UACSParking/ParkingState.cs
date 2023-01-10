using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACS.Park
{
    public delegate void RefParkInfo(string carNo, string carState);
    public partial class ParkingState : UserControl
    {
        public ParkingState(string parkNo,string carState)
        {
            InitializeComponent();
            txtparkNo.Text = parkNo;
            txtCarState.Text = carState;
        }
        public ParkingState()
        {
            InitializeComponent();
        }

        public event RefParkInfo RefParkInfo;

        public void SetPark(string parkNo,string  carState,string  parkState,string carNo)
        {
            try
            {
                 txtparkNo.Text = parkNo;
                //
                 txtCarNo.Text = carNo;
                //
                 if (carState == "0")
                 {
                     txtCarState.Text = "出库";
                 }
                 else if (carState == "1")
                 {
                     txtCarState.Text = "入库";
                 }
                 else
                 {
                     txtCarState.Text = "999999";
                 }
                 //
                 if (parkState == "5")
                 {
                     txtParkState.Text = "车位无车";
                 }
                 else if (parkState == "10")
                 {
                     txtParkState.Text = "车位有车";
                 }
                 else if (parkState == "110")
                 {
                     txtParkState.Text = "扫描开始";
                 }
                 else if (parkState == "120")
                 {
                     txtParkState.Text = "扫描完成";
                 }
                 else if (parkState == "130")
                 {
                     txtParkState.Text = "手持机扫描完";
                 }
                 else if (parkState == "140")
                 {
                     txtParkState.Text = "计划生成";
                 }
                 else if (parkState == "160")
                 {
                     txtParkState.Text = "作业开始";
                 }
                 else if (parkState == "170")
                 {
                     txtParkState.Text = "作业暂停";
                 }
                 else if (parkState == "180")
                 {
                     txtParkState.Text = "作业结束";
                 }
                 else if (parkState == "210")
                 {
                     txtParkState.Text = "扫描开始";
                 }
                 else if (parkState == "220")
                 {
                     txtParkState.Text = "扫描完成";
                 }
                 else if (parkState == "240")
                 {
                     txtParkState.Text = "计划生成";
                 }
                 else if (parkState == "260")
                 {
                     txtParkState.Text = "作业开始";
                 }
                 else if (parkState == "270")
                 {
                     txtParkState.Text = "作业暂停";
                 }
                 else if (parkState == "280")
                 {
                     txtParkState.Text = "作业结束";
                 }
                 else if (parkState == "290")
                 {
                     txtParkState.Text = "手持机确认";
                 }

                 else
                 {
                     txtParkState.Text = "999999";
                 }
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }

        private void ParkingState_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




    }
}
