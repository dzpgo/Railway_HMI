using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkClassLibrary;

namespace UACSParking
{
    public partial class FrmCarInOutGateHistory : Baosight.iSuperframe.Forms.FormBase
    {
        public FrmCarInOutGateHistory()
        {
            InitializeComponent();
            this.Load += FrmCarInOutGateHistory_Load;
        }

        void FrmCarInOutGateHistory_Load(object sender, EventArgs e)
        {
            this.dateTimeStart.Value = DateTime.Now.Date;
            dateTimeEnd.Text = DateTime.Now.ToString();
            GetCarInOutHistory(dateTimeStart.Value, dateTimeEnd.Value, "", "");
            ManagerHelper.DataGridViewInit(dgv1);
        }


        private void GetCarInOutHistory(DateTime start, DateTime end, string gate, string type)
        {
            string strStart = start.ToString("yyyyMMddHHmmss");
            string strEnd = end.ToString("yyyyMMddHHmmss");
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT ROW_NUMBER() OVER() as ROW_INDEX , CARNO, CAR_NUMBER, IN_OUT , IN_OUT_TIME , GATE_FLAGE FROM UACS_CAR_INOUT_HISTORY WHERE 1=1  ";
                sql += " AND IN_OUT_TIME  > '" + strStart + "' and IN_OUT_TIME <'" + strEnd + "'";

                if (gate != "" && gate != "全部")
                {
                    string temp = gate.Contains("南") ? "S" : "N";
                    sql += " AND GATE_FLAGE = '" + temp + "' ";
                }
                if (type != "" && type != "全部")
                {
                    string kind = type.Contains("入") ? "IN" : "OUT";
                    sql += " AND IN_OUT = '" + kind + "' ";
                }
                if (txtCarNO.Text.Trim()!="")
                {
                   sql += " AND CARNO = '" + txtCarNO.Text.Trim() + "' "; 
                }
                sql += " ORDER BY IN_OUT_TIME DESC";
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = ClsParkingManager.DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                dgv1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void btnFine_Click(object sender, EventArgs e)
        {
            GetCarInOutHistory(dateTimeStart.Value, dateTimeEnd.Value, cmbGate.Text, cmbType.Text);
        }

        private void dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                if (dgv1.Columns[e.ColumnIndex].Name.Equals("GATE_FLAGE") && e.Value !=null)
                {
                    if (e.Value.ToString() == "N")
                    {
                        e.Value = "北";
                    }
                    else if (e.Value.ToString() == "S")
                    {
                        e.Value = "南"; 
                    }
                    else
                    {
                        e.Value = "";
                    }
                }
                if (dgv1.Columns[e.ColumnIndex].Name.Equals("IN_OUT") && e.Value != null)
                {
                    if (e.Value.ToString() == "IN")
                    {
                        e.Value = "入库";
                    }
                    else if (e.Value.ToString() == "OUT")
                    {
                        e.Value = "出库";
                    }
                    else
                    {
                        e.Value = "";
                    }
                }
            }               
        }
    }
}
