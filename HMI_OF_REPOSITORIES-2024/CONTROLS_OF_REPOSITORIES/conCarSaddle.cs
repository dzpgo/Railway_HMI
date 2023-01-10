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
    public partial class conCarSaddle : UserControl
    {
        public conCarSaddle()
        {
            InitializeComponent();
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, true);
        }



        private TruckStowageClass myVar;

        public TruckStowageClass MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public delegate void carRefreshInvoke(int _PointX, int _PointY, int _Width, int _Height, TruckStowageClass _truck);

        public void refreshControl(int _PointX, int _PointY, int _Width, int _Height, TruckStowageClass _truck)
        {
            try
            {

                MyProperty = _truck;
                // ----------------控件大小--------------------
                this.Width = _Width;

                this.Height = _Height;

                // ----------------定位坐标--------------------
                this.Location = new Point(_PointX, _PointY);


                toolTip1.IsBalloon = true;
                toolTip1.ReshowDelay = 0;
                toolTip1.SetToolTip(this, "材料号：" + _truck.CoilNo + "\r"
                                    + "槽号：    " + _truck.GrooveId
                                   );
            }
            catch (Exception er)
            {

                throw;
            }
        }




    }
}
