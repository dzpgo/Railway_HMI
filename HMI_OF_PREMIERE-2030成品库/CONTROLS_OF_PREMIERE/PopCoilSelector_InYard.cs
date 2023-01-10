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
    public partial class PopCoilSelector_InYard : Form
    {
        public PopCoilSelector_InYard()
        {
            InitializeComponent();
        }


        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;

        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ2030");
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }

                }
                return dbHelper;
            }
        }

        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        //step1
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


        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();


        //UnitNO
        private string unitNO = string.Empty;

        public string UnitNO
        {
            get { return unitNO; }
            set { unitNO = value; }
        }

        //NextCoil
        private string nextCoil = string.Empty;

        public string NextCoil
        {
            get { return nextCoil; }
            set { nextCoil = value; }
        }

        //BayNO
        private string bayNO = string.Empty;

        public string BayNO
        {
            get { return bayNO; }
            set { bayNO = value; }
        }

        //coilNO
        private string coilNO = string.Empty;

        public string CoilNO
        {
            get { return coilNO; }
            set { coilNO = value; }
        }




        //read the next coil for d118
        private void cmdD118NextCoil_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstAdress = new List<string>();
                lstAdress.Add("D118_NEXT_COIL");
                string[] arrTagAdress;
                arrTagAdress = lstAdress.ToArray<string>();



                inDatas.Clear();
                tagDataProvider.GetData(arrTagAdress, out inDatas);

                nextCoil = string.Empty;
                nextCoil=get_value_string("D118_NEXT_COIL");
                txt_NextCoil.Text = nextCoil;

                unitNO = string.Empty;
                unitNO = "D118";
                txt_UnitNO.Text = unitNO;

                bayNO = string.Empty;
                bayNO = "Z33-1";
                txt_BayNO.Text = bayNO;

                coilNO = string.Empty;
                coilNO = nextCoil;
                txt_CoilNO.Text = coilNO;



            }
            catch (Exception ex)
            {
            }
        }

        //read the next coil for d218
        private void cmdD218NextCoil_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstAdress = new List<string>();
                lstAdress.Add("D218_NEXT_COIL");
                string[] arrTagAdress;
                arrTagAdress = lstAdress.ToArray<string>();



                inDatas.Clear();
                tagDataProvider.GetData(arrTagAdress, out inDatas);

                nextCoil = string.Empty;
                nextCoil = get_value_string("D218_NEXT_COIL");
                txt_NextCoil.Text = nextCoil;

                unitNO = string.Empty;
                unitNO = "D218";
                txt_UnitNO.Text = unitNO;

                bayNO = string.Empty;
                bayNO = "Z33-1";
                txt_BayNO.Text = bayNO;

                coilNO = string.Empty;
                coilNO = nextCoil;
                txt_CoilNO.Text = coilNO;
            }
            catch (Exception ex)
            {
            }
        }


        private string get_value_string(string tagName)
        {
            string theValue = string.Empty;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToString((valueObject));
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }



        //query coil info and stock info
        private void cmdQueryCoilInfoAndStock_Click(object sender, EventArgs e)
        {
            try
            {
                coilNO = string.Empty;
                coilNO = txt_CoilNO.Text .Trim();
                txt_CoilNO.Text = coilNO;

                QueryColiInfo(coilNO);

                QueryStockInfo(bayNO, coilNO);
            }
            catch (Exception ex)
            {
            }
        }

        //Weight
        private long weight = 999999;

        public long Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        //CoilWidth
        private long coilWidth = 999999;

        public long CoilWidth
        {
            get { return coilWidth; }
            set { coilWidth = value; }
        }

        //OutDia
        private long outDia = 999999;

        public long OutDia
        {
            get { return outDia; }
            set { outDia = value; }
        }

        //InDia
        private long inDia = 999999;

        public long InDia
        {
            get { return inDia; }
            set { inDia = value; }
        }

        //StockNO
        private string stockNO = string.Empty;

        public string StockNO
        {
            get { return stockNO; }
            set { stockNO = value; }
        }

        //StockType
        long stockType = 999999;

        public long StockType
        {
            get { return stockType; }
            set { stockType = value; }
        }

        //STOCK_STATUS
        long stockStatus = 999999;

        public long StockStatus
        {
            get { return stockStatus; }
            set { stockStatus = value; }
        }

        //LOCK_FLAG
        long stockLockFlag = 999999;

        public long StockLockFlag
        {
            get { return stockLockFlag; }
            set { stockLockFlag = value; }
        }


        private void QueryStockInfo(string bayNO,string coilNO)
        {
            try
            {


                string sqlText = "SELECT * FROM UACS_YARDMAP_STOCK_DEFINE WHERE MAT_NO=" + "'" + coilNO + "'" + " and BAY_NO=" + "'" + bayNO + "'";

                stockNO = string.Empty;
                stockType = 999999;
                stockStatus = 999999;
                stockLockFlag = 999999;

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {

                        if (rdr["STOCK_NO"] != System.DBNull.Value) { stockNO = Convert.ToString(rdr["STOCK_NO"]); }
                        if (rdr["STOCK_TYPE"] != System.DBNull.Value) { stockType = Convert.ToInt64(rdr["STOCK_TYPE"]); }
                        if (rdr["STOCK_STATUS"] != System.DBNull.Value) { stockStatus = Convert.ToInt64(rdr["STOCK_STATUS"]); }
                        if (rdr["LOCK_FLAG"] != System.DBNull.Value) { stockLockFlag = Convert.ToInt64(rdr["LOCK_FLAG"]); }
                    }

                }

                txt_StockNO.Text = stockNO;
                txt_StockType.Text = stockType.ToString();
                txt_StockStatus.Text = stockStatus.ToString();
                txt_Stock_LockFlag.Text = stockLockFlag.ToString();


            }
            catch (Exception ex)
            {
            }
        }


        private void QueryColiInfo(string coilNO)
        {
            try
            {


                string sqlText = "SELECT * FROM UACS_YARDMAP_COIL WHERE COIL_NO=" + "'" + coilNO + "'";

                weight = 999999;
                coilWidth = 999999;
                outDia = 999999;
                InDia = 999999;

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {

                        if (rdr["WEIGHT"] != System.DBNull.Value) { weight = Convert.ToInt32(rdr["WEIGHT"]); }
                        if (rdr["WIDTH"] != System.DBNull.Value) { coilWidth = Convert.ToInt32(rdr["WIDTH"]); }
                        if (rdr["OUTDIA"] != System.DBNull.Value) { outDia = Convert.ToInt32(rdr["OUTDIA"]); }
                        if (rdr["INDIA"] != System.DBNull.Value) { inDia = Convert.ToInt32(rdr["INDIA"]); }

                    }

                }

                txt_Weight.Text = weight.ToString();
                txt_Width.Text = coilWidth.ToString();
                txt_OutDia.Text = outDia.ToString();
                txt_InDia.Text = InDia.ToString();

            }
            catch (Exception ex)
            {
            }
        }
        //select command
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
            }
        }

        //cancel command
        private void cmdCanel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
            }
        }




    }
}
