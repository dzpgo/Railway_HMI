using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class conParkingSpaceInMessage : UserControl
    {
        public conParkingSpaceInMessage()
        {
            InitializeComponent();
        }

        public conParkingSpaceInMessage(string _bayno)
        {
            InitializeComponent();
            bayNO = _bayno;

        }

        private string bayNO = string.Empty;
        public string BayNO
        {
            get { return bayNO; }
            set { bayNO = value; }
        }
        private Panel bayPanel = new Panel();
        private long baySpaceX = 0;
        private long baySpaceY = 0;
        private bool xAxisRight = false;
        private bool yAxisDown = false;
        private AreaInBay theAreaInfoInBay = new AreaInBay();
        private string tagServiceName = string.Empty;
        public void conInit(Panel _theBayPanel, string _theTagServiceName, long _baySpaceX, long _baySpaceY, bool _xAxisRight, bool _yAxisDown)
        {
            try
            {
                bayPanel = _theBayPanel;
                tagServiceName = _theTagServiceName;
                baySpaceX = _baySpaceX;
                baySpaceY = _baySpaceY;
                xAxisRight = _xAxisRight;
                yAxisDown = _yAxisDown;
                //theAreaInfoInBay.conInit("A", _theTagServiceName, false);
                refreshControl();
            }
            catch (Exception ex)
            {
            }
        }

        private Dictionary<string, conParkingSpace> dicParkingVisual = new Dictionary<string, conParkingSpace>();


        public void refreshControl()
        {
            try
            {
                //theAreaInfoInBay.getParkingData();
                theAreaInfoInBay.getParkingData(BayNO);
                foreach (AreaBase theSaddleInfo in theAreaInfoInBay.DicSaddles.Values)
                {
                    conParkingSpace theSaddleVisual = new conParkingSpace();
                    if (dicParkingVisual.ContainsKey(theSaddleInfo.AreaNo))
                    {
                        theSaddleVisual = dicParkingVisual[theSaddleInfo.AreaNo];

                    }
                    else
                    {
                        theSaddleVisual = new conParkingSpace();
                        theSaddleVisual.conInit();
                        bayPanel.Controls.Add(theSaddleVisual);
                    }
                    conParkingSpace.ParkingSpaceRefreshInvoke theInvoke = new conParkingSpace.ParkingSpaceRefreshInvoke(theSaddleVisual.refreshControl);
                    theSaddleVisual.BeginInvoke(theInvoke, new Object[] { theSaddleInfo,bayPanel, baySpaceX, baySpaceY, xAxisRight, yAxisDown });
                    theSaddleVisual.Parking_Selected -= new conParkingSpace.EventHandler_Parking_Selected(theSaddleVisual_Saddle_Selected);
                    theSaddleVisual.Parking_Selected += new conParkingSpace.EventHandler_Parking_Selected(theSaddleVisual_Saddle_Selected);
                    dicParkingVisual[theSaddleInfo.AreaNo] = theSaddleVisual;

                }
            }
            catch (Exception er)
            {
                
                throw;
            }
        }

        void theSaddleVisual_Saddle_Selected(AreaBase theSaddleInfo)
        {
            try
            {
                if (Saddle_Selected != null)
                {
                    Saddle_Selected(theSaddleInfo.Clone());
                }
            }
            catch (Exception ex)
            {
            }
        }

        public delegate void EventHandler_Saddle_Selected(AreaBase theSaddleInfo);
        public event EventHandler_Saddle_Selected Saddle_Selected;
    }
}
