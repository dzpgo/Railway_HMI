using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class FrmSeekCoil : Form
    {
        
        public conSaddleInStockMessage saddleInStock_Z32 { get; set; }
        public conSaddleInStockMessage saddleInStock_Z33 { get; set; }
        public int Z32_Width { get; set; }
        public int Z32_Height { get; set; }
        public int Z33_Width { get; set; }
        public int Z33_Height { get; set; }
        public Panel Z32Panel { get; set; }
        public Panel Z33Panel { get; set; }
        public string BayNo { get; set; }



        private CoilMessage coilMessageClass = new CoilMessage();
        public FrmSeekCoil()
        {
            InitializeComponent();
            this.Load += FrmSeekCoil_Load;
        }

        void FrmSeekCoil_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Text = BayNo + "找卷";
        }

        private void btnGetCoil_Click(object sender, EventArgs e)
        {
            string coil = this.txtCoilNo.Text.Trim();

            if (BayNo == SaddleBase.bayNo_Z32)
            {
                //saddleInStock_Z32.conInit(Z32Panel, SaddleBase.bayNo_Z32, SaddleBase.tagServiceName, SaddleBase.Z32baySpaceX, SaddleBase.Z32baySpaceY, Z32_Width, Z32_Height, SaddleBase.xAxisRight, SaddleBase.yAxisDown, coil);
            }
            else if (BayNo == SaddleBase.bayNo_Z33)
            {
                //saddleInStock_Z33.conInit(Z33Panel, SaddleBase.bayNo_Z33, SaddleBase.tagServiceName, SaddleBase.Z33baySpaceX, SaddleBase.Z33baySpaceY, Z33_Width, Z33_Height, SaddleBase.xAxisRight, SaddleBase.yAxisDown, coil);
            }
     
            coilMessageClass.GetLabeTxtByCoil(lblMessage,coil);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //if (BayNo == SaddleBase.bayNo_Z32)
            //{
            //    saddleInStock_Z32.conInit(Z32Panel, SaddleBase.bayNo_Z32, SaddleBase.tagServiceName, SaddleBase.Z32baySpaceX, SaddleBase.Z32baySpaceY, Z32_Width, Z32_Height, SaddleBase.xAxisRight, SaddleBase.yAxisDown);
            //}
            //else if (BayNo == SaddleBase.bayNo_Z33)
            //{
            //    saddleInStock_Z33.conInit(Z33Panel, SaddleBase.bayNo_Z33, SaddleBase.tagServiceName, SaddleBase.Z33baySpaceX, SaddleBase.Z33baySpaceY, Z33_Width, Z33_Height, SaddleBase.xAxisRight, SaddleBase.yAxisDown);
            //}
            
            this.Close();
        }
       



    }
}
