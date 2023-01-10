using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSParking
{
    public partial class FrmRailwayLogisticsManage :   Baosight.iSuperframe.Forms.FormBase
    {
        public FrmRailwayLogisticsManage()
        {
            InitializeComponent();
            this.Load += FrmRailwayLogisticsManage_Load;
        }
        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        public static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
                    }
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion
        DataTable dt;
        void FrmRailwayLogisticsManage_Load(object sender, EventArgs e)
        {
           try
            {
                ParkClassLibrary.ManagerHelper.DataGridViewInit(dgvInfo);
                dgvInfo.ReadOnly = false;
                bindDgvCombb(dsCmbb.Tables["dataTable1"]);
                LoadInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
           
        }

        private void LoadInfo()
        {
            dt = new DataTable();
            try
            {
                //string sql = "select ROW_NUMBER() OVER() as ROW_NUMBER, HAVEN_CNAME, 1 as TRANSPORTTYPE from UACS_PLAN_IN_DETAIL where HAVEN_CNAME is not null group by HAVEN_CNAME ";
                string sql = @"select  ROW_NUMBER() OVER() as ROW_NUMBER, A.HAVEN_CNAME, B.LOGISTICS_FLAG as TRANSPORTTYPE from UACS_PLAN_IN_DETAIL A
                                LEFT join UACS_LOGISTICS_CONFIG B  on B.HAVEN_CNAME = A.HAVEN_CNAME
                                where A.HAVEN_CNAME is not null group by ( A.HAVEN_CNAME, B.LOGISTICS_FLAG) ";
                dt = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                dgvInfo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void bindDgvCombb(DataTable dt)
        {

            DataRow dr = dt.NewRow();
            dr["TypeValue"] = "1";
            dr["TypeName"] = "外贸";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["TypeValue"] = "2";
            dr["TypeName"] = "内贸";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["TypeValue"] = "3";
            dr["TypeName"] = "铁路北";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["TypeValue"] = "4";
            dr["TypeName"] = "铁路南";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["TypeValue"] = "0";
            dr["TypeName"] = "无";
            dt.Rows.Add(dr);  
        }

        private void btnCarEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string havenCname = "";
                int transporTypeNew = 0;
                DialogResult dResult = MessageBox.Show("是否修改当前配置？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dResult == DialogResult.Yes)
                {
                    //删除数据
                    delectLogistics();
                    foreach (DataGridViewRow row in this.dgvInfo.Rows)
                    {
                        havenCname = row.Cells["HAVEN_CNAME"].Value == null ? "" : row.Cells["HAVEN_CNAME"].Value.ToString();
                        if (row.Cells["Column3"].Value == null)
                        {
                            transporTypeNew = row.Cells["TRANSPORTTYPE"].Value.Equals(DBNull.Value) ? 0 : Convert.ToInt32(row.Cells["TRANSPORTTYPE"].Value);
                        }
                        else
                        {
                            transporTypeNew = row.Cells["Column3"].Value == null ? 0 : Convert.ToInt32(row.Cells["Column3"].Value);
                        }
                        updataLogistics(havenCname, transporTypeNew);

                    }
                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

        }
        private void updataLogistics(string name,int type)
        {
            try
            {
                string sqlText = "INSERT INTO UACS_LOGISTICS_CONFIG(HAVEN_CNAME,LOGISTICS_FLAG,CHANGE_TIME) VALUES('{0}',{1},'{2}') ";
                sqlText = string.Format(sqlText, name, type, DateTime.Now.ToString("yyyyMMddHHmmss"));
                DBHelper.ExecuteNonQuery(sqlText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

        }
        private void delectLogistics()
        {
            try
            {
                string sqlText = "DELETE  FROM UACS_LOGISTICS_CONFIG  ";
                DBHelper.ExecuteNonQuery(sqlText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void dgvInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
                {
                    if (dgvInfo.Columns[e.ColumnIndex].Name.Equals("TRANSPORTTYPE"))
                    {
                        if (e.Value == null)
                        {
                            e.Value = "";
                        }
                        else if (e.Value.Equals(0))
                            e.Value = "无";
                        else if (e.Value.Equals(1))
                        { e.Value = "外贸"; e.CellStyle.BackColor = Color.MediumSpringGreen; }
                        else if (e.Value.Equals(2))
                        { e.Value = "内贸"; e.CellStyle.BackColor = Color.MistyRose; }
                        else if (e.Value.Equals(3))
                        { e.Value = "铁路北"; e.CellStyle.BackColor = Color.Orange; }
                        else if (e.Value.Equals(4))
                        { e.Value = "铁路南"; e.CellStyle.BackColor = Color.Peru ; }
                        else
                        { e.Value = ""; e.CellStyle.BackColor = Color.LightGray; }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }


        private void dgvInfo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (this.dgvInfo.CurrentCell != null && this.dgvInfo.CurrentCell.OwningColumn.Name == "Column3")
                {
                    ComboBox combo = e.Control as ComboBox;
                    if (combo != null)
                    {
                        combo.SelectedIndexChanged -=
                        new EventHandler(ComboBox_SelectedIndexChanged);

                        combo.SelectedIndexChanged +=
                        new EventHandler(ComboBox_SelectedIndexChanged);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (sender is ComboBox)
            {
                ComboBox combo = sender as ComboBox;
                combo.BackColor = Color.Red;

               // MessageBox.Show(combo.Text);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void dgvInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex>0 &&e.RowIndex>0 && e.ColumnIndex!=3)
            //{
            //    foreach (DataGridViewRow item in dgvInfo.Rows)
            //    {
            //        if (item.Cells["Column3"].Value != null && item.Cells["Column3"].FormattedValue.ToString() != "")
            //        {
            //            if (item.Cells["TRANSPORTTYPE"].Value != item.Cells["Column3"].Value)
            //            {
            //                item.DefaultCellStyle.BackColor = Color.Red;
            //            }
            //            else
            //            {
            //                item.DefaultCellStyle.BackColor = Color.White;
            //            }
            //        }
            //    }
            //}
        }

        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex > 0 && e.ColumnIndex != 3)
            {
                foreach (DataGridViewRow item in dgvInfo.Rows)
                {
                    if (item.Cells["Column3"].Value != null && item.Cells["Column3"].FormattedValue.ToString() != "")
                    {
                        if (item.Cells["TRANSPORTTYPE"].Value.ToString() != item.Cells["Column3"].Value.ToString())
                        {
                            item.DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            item.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
        }
    }
}
