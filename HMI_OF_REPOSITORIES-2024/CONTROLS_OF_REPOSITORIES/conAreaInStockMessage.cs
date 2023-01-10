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
    public partial class conAreaInStockMessage : UserControl
    {
        public conAreaInStockMessage()
        {
            InitializeComponent();
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
        private int panelWidth = 0;  
        private int panelHeight = 0;
        private bool xAxisRight = false;
        private bool yAxisDown = false;
        private AreaInBay theAreaInfoInBay = new AreaInBay();
        private bool flag = false;
        private string tagServiceName = string.Empty;
        private LimitUltrahighTagValue TagValue = new LimitUltrahighTagValue();
        private bool isNDoorStatus = false;
        private bool isBDoorStatus = false;
        private bool isRefesh = false;

        /// <summary>
        /// 显示小区需要的详细信息
        /// </summary>
        /// <param name="theBayPanel">显示Panel</param>
        /// <param name="theBayNO">跨别</param>
        /// <param name="theTagServiceName">平台ServiceName</param>
        /// <param name="_baySpaceX">跨别X</param>
        /// <param name="_baySpaceY">跨别Y</param>
        /// <param name="_panelWidth">Panel宽</param>
        /// <param name="_panelHeight">Panel高</param>
        /// <param name="_xAxisRight">X显示方向</param>
        /// <param name="_yAxisDown">Y显示方向</param>
        /// <param name="flag">需要显示的小区(true = 不包括库区内库区;false = 所有小区)</param>
        /// <param name="tagValue"></param>
        public void conInit(Panel theBayPanel, string theBayNO, string theTagServiceName, long _baySpaceX, long _baySpaceY, int _panelWidth, int _panelHeight, bool _xAxisRight, bool _yAxisDown,bool _isNDoorStatus,bool _isBDoorStatus,bool _isRefesh)
        {
            try
            {
                bayPanel = theBayPanel;
                bayNO = theBayNO;
                tagServiceName = theTagServiceName;
                baySpaceX = _baySpaceX;
                baySpaceY = _baySpaceY;
                panelWidth = _panelWidth;
                panelHeight = _panelHeight;
                xAxisRight = _xAxisRight;
                yAxisDown = _yAxisDown;
                isNDoorStatus = _isNDoorStatus;
                isBDoorStatus = _isBDoorStatus;
                isRefesh = _isRefesh;
                theAreaInfoInBay.conInit(theBayNO, theTagServiceName, flag);
                refreshControl();
            }
            catch (Exception ex)
            {
            }
        }



        private Dictionary<string, conArea> dicSaddleVisual = new Dictionary<string, conArea>();

        public void refreshControl()
        {
            try
            {

                theAreaInfoInBay.getPortionAreaData();
                foreach (AreaBase theSaddleInfo in theAreaInfoInBay.DicSaddles.Values)
                {
                    conArea theSaddleVisual = new conArea();
                    if (dicSaddleVisual.ContainsKey(theSaddleInfo.AreaNo))
                    {
                        theSaddleVisual = dicSaddleVisual[theSaddleInfo.AreaNo];
                    }
                    else
                    {
                        theSaddleVisual = new conArea();
                        theSaddleVisual.conInit();

                        //theSaddleVisual.SetAreaBackColor(theAreaInfoInBay.GetSafeDoorState(theSaddleInfo.AreaNo), Color.Red);
                        bayPanel.Controls.Add(theSaddleVisual);
                        if (theSaddleInfo.AreaNo.Contains("G"))
                        {
                            theSaddleVisual.BringToFront();
                        }
                    }
                    //添加安全门 1 开 0 关
                    isNDoorStatus = !theAreaInfoInBay.GetSafeDoorState(theSaddleInfo.AreaNo);
                    conArea.areaRefreshInvoke theInvoke = new conArea.areaRefreshInvoke(theSaddleVisual.refreshControl);
                    theSaddleVisual.BeginInvoke(theInvoke, new Object[] { theSaddleInfo, baySpaceX, baySpaceY, panelWidth, panelHeight, xAxisRight, yAxisDown, bayPanel, theSaddleVisual, isNDoorStatus,isBDoorStatus,isRefesh });
                    theSaddleVisual.Saddle_Selected -= new conArea.EventHandler_Saddle_Selected(theSaddleVisual_Saddle_Selected);
                    theSaddleVisual.Saddle_Selected += new conArea.EventHandler_Saddle_Selected(theSaddleVisual_Saddle_Selected);
                    dicSaddleVisual[theSaddleInfo.AreaNo] = theSaddleVisual;
                    //theSaddleVisual.gdi();

                    
                }

            }
            catch (Exception ex)
            {
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

        public bool updataCraneWaterLevel(string craneNO)
        {
            bool ret = false;
            ret=theAreaInfoInBay.getCraneWaterLevelStatus(craneNO);
            return ret;

        }
        public bool getCarneLoderType(string craneNO)
        {
            bool ret = false;
            ret = theAreaInfoInBay.getCraneLoderType(craneNO);
            return ret;
        }
        public bool getPhotogateStatus(string area)
        {
            bool ret = false;
            ret = theAreaInfoInBay.getPhotogateStatus(area);
            return ret;
        }
        public bool getDaoZhaLowerStatus(string name)
        {
            bool ret = false;
            ret = theAreaInfoInBay.getDaoZhaLowerStatus(name);
            return ret;
        }
        public bool getDaoZhaUpperStatus(string name)
        {
            bool ret = false;
            ret = theAreaInfoInBay.getDaoZhaUpperStatus(name);
            return ret;
        }
    }
}
