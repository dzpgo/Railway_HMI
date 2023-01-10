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
    public partial class PopD202Exit_CoilSelector : Form
    {
        public PopD202Exit_CoilSelector()
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

        private string unitNO = string.Empty;

        public string UnitNO
        {
            get { return unitNO; }
            set { unitNO = value; }
        }


        private string bayNO = string.Empty;

        public string BayNO
        {
            get { return bayNO; }
            set { bayNO = value; }
        }
        


        public void refreshData()
        {
            try
            {
                string strSql = " select * from UACS_LINE_EXIT_L2INFO where UNIT_NO=" + "'" + unitNO + "'"; // + " and HAS_COIL=1 ";
                if (bayNO == "Z33-1")
                {
                    strSql += " and ";
                    strSql += " ( ";
                    strSql += "SADDLE_L2NAME=" + "'" + "0012" + "'" + " or ";
                    strSql += "SADDLE_L2NAME=" + "'" + "0013" + "'" + " or ";
                    strSql += "SADDLE_L2NAME=" + "'" + "0014" + "'" + " or ";
                    strSql += "SADDLE_L2NAME=" + "'" + "0015" + "'" ;
                    strSql += " ) ";
                }
                else if (bayNO == "Z32-1")
                {
                    strSql += " and ";
                    strSql += " ( ";
                    strSql += "SADDLE_L2NAME=" + "'" + "0018" + "'" + " or ";
                    strSql += "SADDLE_L2NAME=" + "'" + "0019" + "'" + " or ";
                    strSql += "SADDLE_L2NAME=" + "'" + "0020" + "'" ;
                    strSql += " ) ";
                }
                else
                {
                    return;
                }

                using (IDataReader rdr = DBHelper.ExecuteReader(strSql))
                {

                    dataGridLineExitInfo.Rows.Clear();
                    int i = 0;
                    while (rdr.Read())
                    {
                        i++;
                        dataGridLineExitInfo.Rows.Add();
                        DataGridViewRow theRow = dataGridLineExitInfo.Rows[dataGridLineExitInfo.Rows.Count - 1];

                        if (rdr["SADDLE_L2NAME"] != System.DBNull.Value) { theRow.Cells["SADDLE_L2NAME"].Value = Convert.ToString(rdr["SADDLE_L2NAME"]); }

                        if (rdr["HAS_COIL"] != System.DBNull.Value) { theRow.Cells["HAS_COIL"].Value = Convert.ToString(rdr["HAS_COIL"]); }

                        if (rdr["COIL_NO"] != System.DBNull.Value) { theRow.Cells["COIL_NO"].Value = Convert.ToString(rdr["COIL_NO"]); }

                        if (rdr["WEIGHT"] != System.DBNull.Value) { theRow.Cells["WEIGHT"].Value = Convert.ToString(rdr["WEIGHT"]); }

                        if (rdr["WIDTH"] != System.DBNull.Value) { theRow.Cells["WIDTH"].Value = Convert.ToString(rdr["WIDTH"]); }

                        if (rdr["IN_DIA"] != System.DBNull.Value) { theRow.Cells["IN_DIA"].Value = Convert.ToString(rdr["IN_DIA"]); }

                        if (rdr["OUT_DIA"] != System.DBNull.Value) { theRow.Cells["OUT_DIA"].Value = Convert.ToString(rdr["OUT_DIA"]); }

                        if (rdr["SLEEVE_WIDTH"] != System.DBNull.Value) { theRow.Cells["SLEEVE_WIDTH"].Value = Convert.ToString(rdr["SLEEVE_WIDTH"]); }

                        theRow.Cells["FlagSelected"].Value = 0;

                    }

                }



            }
            catch (Exception ex)
            {
            }
        }

        private void PopD202Exit_CoilSelector_Load(object sender, EventArgs e)
        {
            try
            {
                refreshData();
            }
            catch (Exception ex)
            {
            }
        }

        private void dataGridLineExitInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                foreach (DataGridViewRow row in dataGridLineExitInfo.Rows)
                {
                    row.Cells["FlagSelected"].Value = 0;
                }
                //首先拿到点击的行
                DataGridViewRow theRow = dataGridLineExitInfo.Rows[e.RowIndex];

                if (Convert.ToInt32(theRow.Cells["FlagSelected"].Value) == 0)
                {
                    theRow.Cells["FlagSelected"].Value = 1;
                }
                else if (Convert.ToInt32(theRow.Cells["FlagSelected"].Value) == 1)
                {
                    theRow.Cells["FlagSelected"].Value = 0;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private long hasCoil = 0;
        public long HasCoil
        {
            get { return hasCoil; }
            set { hasCoil = value; }
        }

        private string coilNO = string.Empty;
        public string CoilNO
        {
            get { return coilNO; }
            set { coilNO = value; }
        }

        private long weight = 0;
        public long Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        private long coilWidth = 0;
        public long CoilWidth
        {
            get { return coilWidth; }
            set { coilWidth = value; }
        }

        private long inDia = 0;
        public long InDia
        {
            get { return inDia; }
            set { inDia = value; }
        }

        private long outDia = 0;
        public long OutDia
        {
            get { return outDia; }
            set { outDia = value; }
        }

        


        private void cmdSelect_Click(object sender, EventArgs e)
        {
            try
            {
                hasCoil=0;
                coilNO = string.Empty;
                weight = 0;
                coilWidth = 0;
                inDia = 0;
                outDia = 0;

                string saddleL2Name=string.Empty ;

                foreach (DataGridViewRow row in dataGridLineExitInfo.Rows)
                {
                    if (Convert.ToInt64(row.Cells["FlagSelected"].Value) == 1)
                    {
                        try
                        {
                            hasCoil = Convert.ToInt64(row.Cells["HAS_COIL"].Value);
                            if (hasCoil == 0) { MessageBox.Show("hasCoil == 0"); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("hasCoil convert error:" + ex.Message);
                        }

                        try
                        {
                            coilNO = Convert.ToString(row.Cells["COIL_NO"].Value);
                            if (coilNO == string.Empty) { MessageBox.Show("coilNO ==string.empty"); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("COIL_NO convert error:" + ex.Message);
                        }
                        
                        try
                        {
                            weight = Convert.ToInt64(row.Cells["WEIGHT"].Value);
                            if (weight == 0) { MessageBox.Show("weight == 0"); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("WEIGHT convert error:" + ex.Message);
                        }

                        try
                        {
                            coilWidth = Convert.ToInt64(row.Cells["WIDTH"].Value);
                            if (coilWidth == 0) { MessageBox.Show("coilWidth == 0"); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("WIDTH convert error:" + ex.Message);
                        }
                        try
                        {
                            inDia = Convert.ToInt64(row.Cells["IN_DIA"].Value);
                            if (inDia == 0) { MessageBox.Show("inDia == 0"); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("IN_DIA convert error:" + ex.Message);
                        }
                        try
                        {
                            outDia = Convert.ToInt64(row.Cells["OUT_DIA"].Value);
                            if (outDia == 0) { MessageBox.Show("outDia == 0"); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("OUT_DIA convert error:" + ex.Message);
                        }

                        saddleL2Name= Convert.ToString(row.Cells["SADDLE_L2NAME"].Value);

                        stockNO = getSotckNOByL2SaddleName(unitNO, 1, saddleL2Name);
                        MessageBox.Show(stockNO);
                    }
                }

                //get the stock name by the saddleL2Name
                getSotckNOByL2SaddleName(unitNO, 1, saddleL2Name);

                if (hasCoil == 1 && coilNO != string.Empty)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                
            }
            catch (Exception ex)
            {
            }
        }

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



        private string stockNO = string.Empty;
        public string StockNO
        {
            get { return stockNO; }
            set { stockNO = value; }
        }

        public string getSotckNOByL2SaddleName(string UnitNO, long flagExit, string L2SaddleName)
        {
            string stockNO = string.Empty;
            try
            {
                string sqlText = "select * from UACS_LINE_SADDLE_DEFINE where UNIT_NO=" + "'" + UnitNO + "'" + " and FLAG_UNIT_EXIT=" + flagExit + " and SADDLE_L2NAME=" + "'" + L2SaddleName + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        if (rdr["STOCK_NO"] != System.DBNull.Value) { stockNO = Convert.ToString(rdr["STOCK_NO"]); }
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Refresh_CranePlan"+ex.Message);
            }

            return stockNO;

        }

    }
}
