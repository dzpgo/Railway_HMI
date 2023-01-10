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
    public partial class conSaddleInStockMessage : UserControl
    {
        public conSaddleInStockMessage()
        {
            InitializeComponent();
        }

        private Panel bayPanel = new Panel();
        private bool xAxisRight = false;
        private bool yAxisDown = false;
        private int panelWidth = 0;
        private int panelHeight = 0;
        private SaddleInBay theSaddlsInfoInBay = new SaddleInBay();
        private AreaBase theAreaBase = new AreaBase();
        private string tagServiceName = string.Empty;
        private List<int> list = new List<int>();


        public void conInit(Panel theBayPanel, AreaBase areaBase, string theTagServiceName, int _panelWidth, int _panelHeight, bool _xAxisRight, bool _yAxisDown, int _index)
        {
            try
            {
                theAreaBase = areaBase;
                bayPanel = theBayPanel;
                tagServiceName = theTagServiceName;
                xAxisRight = _xAxisRight;
                yAxisDown = _yAxisDown;
                panelWidth = _panelWidth;
                panelHeight = _panelHeight;

                if (_index == 888)
                {
                    list = null;
                }
                else
                {
                    list.Add(_index);
                }

                theSaddlsInfoInBay.conInit(areaBase.AreaNo, theTagServiceName);

                refreshControl();
            }
            catch (Exception ex)
            {
            }

        }

        private Dictionary<string, conSaddle> dicSaddleVisual = new Dictionary<string, conSaddle>();

        public void refreshControl()
        {

            //取这块小区的大小
            double X_Width = theAreaBase.X_End - theAreaBase.X_Start;

            double Y_Height = theAreaBase.Y_End - theAreaBase.Y_Start;
            theSaddlsInfoInBay.get_Z32_Z33_SaddleData();
            foreach (SaddleBase theSaddleInfo in theSaddlsInfoInBay.DicSaddles.Values)
            {
                conSaddle theSaddleVisual = new conSaddle();

                if (dicSaddleVisual.ContainsKey(theSaddleInfo.SaddleNo))
                {
                    theSaddleVisual = dicSaddleVisual[theSaddleInfo.SaddleNo];

                }
                else
                {
                    theSaddleVisual = new conSaddle();
                    theSaddleVisual.conInit();
                    bayPanel.Controls.Add(theSaddleVisual);
                }
                conSaddle.saddlesRefreshInvoke theInvoke = new conSaddle.saddlesRefreshInvoke(theSaddleVisual.refreshControl);
                theSaddleVisual.BeginInvoke(theInvoke, new Object[] { theSaddleInfo, X_Width, Y_Height, theAreaBase, panelWidth, panelHeight, xAxisRight, yAxisDown, bayPanel, list });
                theSaddleVisual.Saddle_Selected -= new conSaddle.EventHandler_Saddle_Selected(theSaddleVisual_Saddle_Selected);
                theSaddleVisual.Saddle_Selected += new conSaddle.EventHandler_Saddle_Selected(theSaddleVisual_Saddle_Selected);
                dicSaddleVisual[theSaddleInfo.SaddleNo] = theSaddleVisual;

            }
        }
        void theSaddleVisual_Saddle_Selected(SaddleBase theSaddleInfo)
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

        public delegate void EventHandler_Saddle_Selected(SaddleBase theSaddleInfo);
        public event EventHandler_Saddle_Selected Saddle_Selected;

    }
}
