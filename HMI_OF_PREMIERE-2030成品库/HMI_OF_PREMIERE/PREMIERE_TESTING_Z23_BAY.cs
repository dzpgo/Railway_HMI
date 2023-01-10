using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CONTROLS_OF_PREMIERE;
using MODULES_OF_PREMIERE;

using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService.Controls;
using Baosight.iSuperframe.TagService;

namespace HMI_OF_PREMIERE
{
    public partial class PREMIERE_TESTING_Z23_BAY : FormBase
    {
        public PREMIERE_TESTING_Z23_BAY()
        {
            InitializeComponent();
        }


        private string tagServiceName = "iplature";

        //private long baySpaceX = 300000;
        private long baySpaceX = 432000;
        private long baySpaceY = 45000;
        private int panelWidth;
        private int panelHeight;
        private bool xAxisRight = true;
        private bool yAxisDown = true;
        private string bayNO = "Z23";

        private string craneNO_1 = "6_9";
        private string craneNO_2 = "6_8";
        private string craneNO_3 = "6_7";
        private string craneNO_4 = "6_10";

        private CranePLCStatusInBay cranePLCStatusInBay = new CranePLCStatusInBay();

        private List<ConCraneStatusPanel> lstConCraneStatusPanel = new List<ConCraneStatusPanel>();
        private List<ConCraneVisual>lstConCraneVisual=new List<ConCraneVisual> ();

        private void PREMIERE_TESTING_6_7_TO_6_10_Load(object sender, EventArgs e)
        {
            try
            {
                //this.TabActivated += new EventHandler(PREMIERE_TESTING_4_1_TO_4_3_TabActivated);
                //this.TabDeactivated += new EventHandler(PREMIERE_TESTING_4_1_TO_4_3_TabDeactivated);
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                conCraneVisual_1.InitTagDataProvide( tagServiceName );
                conCraneVisual_1.CraneNO = craneNO_1;
                lstConCraneVisual.Add(conCraneVisual_1);

                conCraneVisual_2.InitTagDataProvide(tagServiceName);
                conCraneVisual_2.CraneNO = craneNO_2;
                lstConCraneVisual.Add(conCraneVisual_2);

                conCraneVisual_3.InitTagDataProvide(tagServiceName);
                conCraneVisual_3.CraneNO = craneNO_3;
                lstConCraneVisual.Add(conCraneVisual_3);

                conCraneVisual_4.InitTagDataProvide(tagServiceName);
                conCraneVisual_4.CraneNO = craneNO_4;
                lstConCraneVisual.Add(conCraneVisual_4);

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                conCraneStatusPanel_1.InitTagDataProvide(tagServiceName);
                conCraneStatusPanel_1.CraneNO = craneNO_1;
                lstConCraneStatusPanel.Add(conCraneStatusPanel_1);

                conCraneStatusPanel_2.InitTagDataProvide(tagServiceName);
                conCraneStatusPanel_2.CraneNO = craneNO_2;
                lstConCraneStatusPanel.Add(conCraneStatusPanel_2);

                conCraneStatusPanel_3.InitTagDataProvide(tagServiceName);
                conCraneStatusPanel_3.CraneNO = craneNO_3;
                lstConCraneStatusPanel.Add(conCraneStatusPanel_3);

                conCraneStatusPanel_4.InitTagDataProvide(tagServiceName);
                conCraneStatusPanel_4.CraneNO = craneNO_4;
                lstConCraneStatusPanel.Add(conCraneStatusPanel_4);


                ////////////////////////////////////////////////////////////////////////////////////////////////////
                cranePLCStatusInBay.InitTagDataProvide(tagServiceName);

                cranePLCStatusInBay.AddCraneNO(craneNO_1);
                cranePLCStatusInBay.AddCraneNO(craneNO_2);
                cranePLCStatusInBay.AddCraneNO(craneNO_3);
                cranePLCStatusInBay.AddCraneNO(craneNO_4);

                cranePLCStatusInBay.SetReady();

                timer.Interval = 250;
                timer.Enabled = true;


            }
            catch (Exception ex)
            {
            }
        }

        bool tabActived = true;
        void MyTabActivated(object sender, EventArgs e)
        {
            tabActived = true;
        }
        void MyTabDeactivated(object sender, EventArgs e)
        {
            tabActived = false;
        }


        //时钟函数
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tabActived == false)
                {
                    return;
                }

                cranePLCStatusInBay.getAllPLCStatusInBay();

                foreach(ConCraneVisual  conCraneVisual in lstConCraneVisual)
                {
                    ConCraneVisual.RefreshControlInvoke ConCraneVisual_Invoke = new ConCraneVisual.RefreshControlInvoke(conCraneVisual.RefreshControl);
                    conCraneVisual.BeginInvoke(ConCraneVisual_Invoke, new Object[] { cranePLCStatusInBay.DicCranePLCStatusBase[conCraneVisual.CraneNO].Clone(), baySpaceX, baySpaceY, panelBay.Width, panelBay.Height, xAxisRight, yAxisDown });

                }
                
                foreach(ConCraneStatusPanel conCraneStatusPanel in lstConCraneStatusPanel)
                {
                        ConCraneStatusPanel.RefreshControlInvoke ConCraneStatusPanel_Invoke = new ConCraneStatusPanel.RefreshControlInvoke(conCraneStatusPanel.RefreshControl);
                        conCraneStatusPanel.BeginInvoke(ConCraneStatusPanel_Invoke, new Object[] { cranePLCStatusInBay.DicCranePLCStatusBase[conCraneStatusPanel.CraneNO].Clone() });
                }

            }
            catch (Exception ex)
            {
            }
        }








    }
}
