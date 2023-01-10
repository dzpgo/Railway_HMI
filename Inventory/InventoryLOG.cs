using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;

namespace Inventory
{
    public partial class InventoryLOG : FormBase
    {
        public InventoryLOG()
        {
            InitializeComponent();
            BtnTime.Click += BtnTime_Click;
            BtnOk.Click += BtnOk_Click;
        }

        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }
                }
                return dbHelper;
            }
        }
        #endregion  

        void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string stockno = this.txtStockNo.Text.Trim();
                string coilno = this.txtCoilNo.Text.Trim();

                if (stockno != "" && coilno =="")
                {
                    DgvDetail(null,stockno);
                    DgvCheck(null,stockno);
                }
                else if (stockno == "" && coilno != "")
                {
                    DgvDetail(null, null,coilno);
                    DgvCheck(null, null, coilno);
                }
                else if (stockno != "" && coilno != "")
                {
                    DgvDetail(null, stockno,coilno);
                    DgvCheck(null, stockno, coilno);
                }
            }
            catch (Exception er)
            {
                
            }
        }

        void BtnTime_Click(object sender, EventArgs e)
        {
            try
            {

                int row = 0;

                List<string> listTime = new List<string>();
                // 获取指定的时间
                string recTime1 = this.dateTimePicker1_recTime.Value.ToString();
                string recTime2 = this.dateTimePicker2_recTime.Value.ToString();

                string sqlTime = @"select distinct ID  from UACS_PDA_INVENTORY_HIS WHERE ID BETWEEN '" + recTime1 + "' AND '" + recTime2 + "'";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlTime))
                {
                    while (rdr.Read())
                    {
                        listTime.Add(rdr["ID"].ToString());
                    }
                }
                dataGridView1.Rows.Clear();
                foreach (var time in listTime)
                {
                    string sqlArea = @"SELECT ID,ROW_NO FROM UACS_PDA_INVENTORY_AREA WHERE ID = '" + time + "'";
                    using (IDataReader rdr = DBHelper.ExecuteReader(sqlArea))
                    {
                        while (rdr.Read())
                        {
                            dataGridView1.Rows.Add(1);
                            dataGridView1.Rows[row].Cells[0].Value = rdr["ID"].ToString();
                            dataGridView1.Rows[row].Cells[1].Value = rdr["ROW_NO"].ToString();
                            row++;
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != DBNull.Value  && dataGridView1.Rows[e.RowIndex].Cells[1].Value != DBNull.Value)
                    {
                        string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                        string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

                        DgvDetail(id);
                        DgvCheck(id);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 盘库明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stockno"></param>
        /// <param name="coilno"></param>
        private void DgvDetail(string id = null,string stockno = null,string coilno = null)
        {
            try
            {
                bool hasSetColumn = false;

                DataTable dt = new DataTable();

                string sql = @"SELECT * FROM UACS_PDA_INVENTORY_HIS ";
                if (id != null && stockno == null && coilno == null)
                {
                    sql += " WHERE ID = '" + id + "' AND TYPE = 'DETAIL'";
                }
                else if (id == null && stockno != null && coilno == null)
                {
                    sql += " WHERE STOCK_NO LIKE '%" + stockno + "%' AND TYPE = 'DETAIL'";
                }
                else if (id == null && stockno == null && coilno != null)
                {
                    sql += " WHERE MAT_NO LIKE '%" + coilno + "%' AND TYPE = 'DETAIL' ";
                }
                else if (id == null && stockno != null && coilno != null)
                {
                    sql += " WHERE STOCK_NO LIKE '%" + stockno + "%' AND MAT_NO LIKE '%" + coilno + "%' AND TYPE = 'DETAIL'";
                }

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }

                            dr[i] = rdr[i];
                        }

                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
                if (hasSetColumn == false)
                {
                    dt.Columns.Add("ID", typeof(String));
                    dt.Columns.Add("STOCK_NO", typeof(String));
                    dt.Columns.Add("MAT_NO", typeof(String));
                    dt.Columns.Add("RESULT", typeof(String));
                    dt.Columns.Add("DROP_MAT", typeof(String));
                    dt.Columns.Add("STOCK_NO_IMPLICATE", typeof(String));
                    dt.Columns.Add("RESULT_IMPLICATE", typeof(String));
                    dt.Columns.Add("ACTION", typeof(String));
                    dt.Columns.Add("ACTION_IMPLICATE", typeof(String));
                    dt.Columns.Add("REMARK", typeof(String));
                    dt.Columns.Add("USER", typeof(String));
                    dt.Columns.Add("BATCH_ID", typeof(String));
                    dt.Columns.Add("TYPE", typeof(String));
                }
                dataGridView2.DataSource = dt;
            }
            catch (Exception er)
            {
                
            }
        }

        /// <summary>
        /// 盘库复核明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stockno"></param>
        /// <param name="coilno"></param>
        private void DgvCheck(string id = null, string stockno = null, string coilno = null)
        {
            try
            {
                bool hasSetColumn = false;

                DataTable dt = new DataTable();

                string sql = @"SELECT * FROM UACS_PDA_INVENTORY_HIS ";
                if (id != null)
                {
                    sql += " WHERE ID = '" + id + "' AND TYPE = 'CHECK'";
                }
                else if (id == null && stockno != null && coilno == null)
                {
                    sql += " WHERE STOCK_NO LIKE '%" + stockno + "%' AND TYPE = 'CHECK'";
                }
                else if (id == null && stockno == null && coilno != null)
                {
                    sql += " WHERE MAT_NO LIKE '%" + coilno + "%' AND TYPE = 'CHECK' ";
                }
                else if (id == null && stockno != null && coilno != null)
                {
                    sql += " WHERE STOCK_NO LIKE '%" + stockno + "%' AND MAT_NO LIKE '%" + coilno + "%' AND TYPE = 'CHECK'";
                }

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }

                            dr[i] = rdr[i];
                        }

                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
                if (hasSetColumn == false)
                {
                    dt.Columns.Add("ID", typeof(String));
                    dt.Columns.Add("STOCK_NO", typeof(String));
                    dt.Columns.Add("MAT_NO", typeof(String));
                    dt.Columns.Add("RESULT", typeof(String));
                    dt.Columns.Add("DROP_MAT", typeof(String));
                    dt.Columns.Add("STOCK_NO_IMPLICATE", typeof(String));
                    dt.Columns.Add("RESULT_IMPLICATE", typeof(String));
                    dt.Columns.Add("ACTION", typeof(String));
                    dt.Columns.Add("ACTION_IMPLICATE", typeof(String));
                    dt.Columns.Add("REMARK", typeof(String));
                    dt.Columns.Add("USER", typeof(String));
                    dt.Columns.Add("BATCH_ID", typeof(String));
                    dt.Columns.Add("TYPE", typeof(String));
                }
                dataGridView3.DataSource = dt;
            }
            catch (Exception er)
            {

            }
        }

    }
}
