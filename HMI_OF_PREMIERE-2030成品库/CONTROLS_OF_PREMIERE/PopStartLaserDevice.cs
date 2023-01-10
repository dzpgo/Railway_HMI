using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONTROLS_OF_PREMIERE
{
    public partial class PopStartLaserDevice : Form
    {
        public PopStartLaserDevice()
        {
            InitializeComponent();
        }

        private string craneNO = string.Empty;

        public string CraneNO
        {
            get { return craneNO; }
            set { craneNO = value; }
        }

        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();

        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdStartSendingXPos_Click(object sender, EventArgs e)
        {
            try
            {
                string tagName = craneNO + "_" + "SEND_X_TO_LASER";
                string tagValue = "1";
                Write2Tag(tagName, tagValue);
            }
            catch(Exception ex)
            {
            }
        }

        private void cmdStopSendingXPos_Click(object sender, EventArgs e)
        {
            try
            {
                string tagName = craneNO + "_" + "SEND_X_TO_LASER";
                string tagValue = "0";
                Write2Tag(tagName, tagValue);
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdSendMsgStartLaser_Click(object sender, EventArgs e)
        {
            try
            {
                string tagName = "EV_NEW_PARKING_LASERSTART";
                if(txtParkingNO.Text.Trim()==String.Empty)
                {
                    MessageBox.Show("停车位号不能为空");
                    return;
                }
                string tagValue = txtParkingNO.Text.Trim()+ "|"+ craneNO;
                Write2Tag(tagName, tagValue);
            }
            catch (Exception ex)
            {
            }
        }

        private void Write2Tag(string tagName, string tagValue)
        {
            try
            {

                tagDataProvider.SetData(tagName, tagValue);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WRITE2TAG");
            }
        }


    }
}
