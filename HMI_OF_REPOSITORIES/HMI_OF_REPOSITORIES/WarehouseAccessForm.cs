using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.Common;
using UACSUtility;
using MODEL_OF_REPOSITORIES;

namespace FORMS_OF_REPOSITORIES
{
    public partial class WarehouseAccessForm : FormBase
    {

        #region //连接数据库
        //private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //public static Baosight.iSuperframe.Common.IDBHelper DBHelper
        //{
        //    get
        //    {
        //        if (dbHelper == null)
        //        {
        //            try
        //            {
        //                dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");
        //            }
        //            catch (System.Exception e)
        //            {
        //                throw e;
        //            }

        //        }
        //        return dbHelper;
        //    }
        //}
        #endregion

        private void GetWareAccessData(DateTime start, DateTime end, string gateNO ,string type)
        {
            string strStart = start.ToString("yyyyMMddHHmmss");
            string strEnd = end.ToString("yyyyMMddHHmmss");
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT ROW_NUMBER() OVER() as INDEX , AREA_NAME,GATE_ID,KIND,ACTION_TIME FROM UACS_GATE_ACCESS   WHERE 1 = 1  ";
                sql += " AND ACTION_TIME  > '" + strStart + "' and ACTION_TIME <'" + strEnd + "'";

                if (gateNO != "" && gateNO != "全部")
                {
                    sql += " AND GATE_ID = '" + gateNO + "' ";
                }
                if (type != "" && type != "全部")
                {
                    int kind = type.Contains("进") ? 1 : 2;
                    sql += " AND KIND = " + kind + " ";
                }
                sql += " ORDER BY ACTION_TIME ";
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DB2Connect. DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                dgvWareAccess.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void TimeCompare(DateTime start, DateTime end)
        {
            if (DateTime.Compare(start, end) > 0)
            {
                MessageBox.Show("查询起始时间不能大于终止时间，起始时间:" + start.ToString() + " 终止时间：" + end.ToString() + "！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private int GetSeqno(string MAT_NO, DataGridView dgv)
        {
            int index = -1;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (Convert.ToString(dgv.Rows[i].Cells["GATE"].Value) == MAT_NO)
                {
                    index = i + 1;
                    break;
                }
            }
            return index;
        }
        void dgvXiaoZhang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            

        }
        private void Search(DataGridView dgv, int Index)
        {
            if (Index >= dgv.Rows.Count)
            {
                dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
                dgv.Rows[dgv.Rows.Count - 1].Selected = true;
            }
            else if (Index <= 0)
            {
                dgv.FirstDisplayedScrollingRowIndex = 0;
                dgv.Rows[0].Selected = true;
            }
            else
            {
                dgv.FirstDisplayedScrollingRowIndex = Index - 1;
                dgv.Rows[Index - 1].Selected = true;
            }
        }

        public WarehouseAccessForm()
        {
            InitializeComponent();
            
        }

        private void WarehouseAccessForm_Load(object sender, EventArgs e)
        {
            //dateTimeStart.Value = DateTime.Now.AddDays(-3);    //前10天
            this.dateTimeStart.Value = DateTime.Now.Date;
            dateTimeEnd.Text = DateTime.Now.ToString();
            GetWareAccessData(dateTimeStart.Value, dateTimeEnd.Value, "","");
            dgvWareAccess.CellFormatting += dgvWareAccess_CellFormatting;
        }

        void dgvWareAccess_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {

                if (dgvWareAccess.Columns[e.ColumnIndex].Name.Equals("KIND"))
                {
                    if (e.Value == null)
                    {
                        e.Value = "";
                    }
                    else if (e.Value.Equals(1))
                        e.Value = "入库";
                    else if (e.Value.Equals(2))
                        e.Value = "出库";
                    else
                        e.Value = "";

                }

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            GetWareAccessData(dateTimeStart.Value, dateTimeEnd.Value, cbxDoorNo.Text.Trim(),cmbbtype.Text.Trim());
        }

        private void cbxDoorNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetWareAccessData(dateTimeStart.Value, dateTimeEnd.Value, cbxDoorNo.Text.Trim(), cmbbtype.Text.Trim());
        }

       
    }
}
