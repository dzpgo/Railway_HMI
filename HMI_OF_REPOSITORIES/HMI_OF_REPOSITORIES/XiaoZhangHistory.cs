using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSUtility;
using Baosight.iSuperframe.Forms;

namespace HMI_OF_REPOSITORIES
{
    public partial class XiaoZhangHistory : FormBase
    {
        #region 连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        public static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");
                    }
                    catch (System.Exception e)
                    {
                        throw e;
                    }

                }
                return dbHelper;
            }
        } 
        #endregion
        public XiaoZhangHistory()
        {
            InitializeComponent();
            this.Load += XiaoZhangHistory_Load;
        }
       // String Parking_NO = "";
        void XiaoZhangHistory_Load(object sender, EventArgs e)
        {
            this.dateTimeOutStart.Value = DateTime.Now.Date;
            UACSUtility.ViewHelper.DataGridViewInit(dgvXiaoZhang);
            dgvXiaoZhang.RowHeadersVisible = true;  
            UACSUtility.ViewHelper.DataGridViewInit(dgvStowage);
            dgvXiaoZhang.CellFormatting += dgvXiaoZhang_CellFormatting;
            dgvXiaoZhang.CellMouseDoubleClick += dgvXiaoZhang_CellMouseDoubleClick;
            dgvXiaoZhang.CellContentClick += dgvXiaoZhang_CellContentClick;

           // cmbArea.Text = GetOperateAreaByBay(Parking_NO);
            
        }

        void dgvXiaoZhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow item in dgvXiaoZhang.Rows)
                {
                    if (item.Index == e.RowIndex)
                    {
                        item.Cells[0].Value = true;
                    }
                    else
                    {
                        item.Cells[0].Value = false;
                    }
                }
            }

        }

        void dgvXiaoZhang_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string stowageNO = "";
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvXiaoZhang.Rows[e.RowIndex].Cells["STOWAGE_ID"].Value != null)
                    {
                        stowageNO = dgvXiaoZhang.Rows[e.RowIndex].Cells["STOWAGE_ID"].Value.ToString();
                        if (!searchDetailByStowageNO(stowageNO ))
                        {
                            MessageBox.Show("没有找到指定的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //private void BindBayType(ComboBox cmbBox)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("TypeValue");
        //    dt.Columns.Add("TypeName");

        //    DataRow dr;
        //    dr = dt.NewRow();
        //    dr["TypeValue"] = "A";
        //    dr["TypeName"] = "A跨";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["TypeValue"] = "C";
        //    dr["TypeName"] = "C跨";
        //    dt.Rows.Add(dr);

        //    cmbBox.DisplayMember = "TypeName";
        //    cmbBox.ValueMember = "TypeValue";
        //    cmbBox.DataSource = dt;
        //}

        //private string GetOperateAreaByBay(string parkNO)
        //{
        //    string area = "";
        //    try
        //    {
        //        if (parkNO.Contains("FT1"))
        //        {
        //            area = "A跨";
        //        }
        //        else if (parkNO.Contains("FT3"))
        //        {
        //            area = "C跨";
        //        }
        //        else
        //        {
        //            area = "C跨";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
        //    }
        //    return area;
        //}

        void dgvXiaoZhang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv =(DataGridView)sender;
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {

                if (dgvXiaoZhang.Columns[e.ColumnIndex].Name.Equals("STORE_ID"))
                {
                    if (e.Value == null)
                    {
                        e.Value = "";
                    }
                    else if (e.Value.Equals("IN"))
                        e.Value = "入库";
                    else if (e.Value.Equals("OUT"))
                        e.Value = "出库";
                    else
                        e.Value = "";

                }
                if (dgvXiaoZhang.Columns[e.ColumnIndex].Name.Equals("STATUS"))
                {
                    if (e.Value == null)
                    {
                        e.Value = "";
                    }
                    else if (e.Value.Equals("0"))
                    { e.Value = "待发送"; e.CellStyle.BackColor = Color.Red; e.CellStyle.ForeColor = Color.White; }
                    else if (e.Value.Equals("1") && dgv.Rows[e.RowIndex].Cells["COIL_STATUS"].Value.ToString() == "100")
                    { e.Value = "成功"; e.CellStyle.BackColor = Color.Green; e.CellStyle.ForeColor = Color.White; }
                    else if (e.Value.Equals("2"))
                    { e.Value = "失败" ; e.CellStyle.BackColor = Color.Red; e.CellStyle.ForeColor = Color.White; }
                    else
                    { e.Value = "异常"; e.CellStyle.BackColor = Color.Red; e.CellStyle.ForeColor = Color.White; }

                }

            }

        }
        //查询
        //private void btnSearchOut_Click(object sender, EventArgs e)
        //{
        //    //string TimeInStart = this.dateTimeOutStart.Value.ToString("yyyyMMdd000000");
        //    //string TimeInEnd = this.dateTimeOutEnd.Value.ToString("yyyyMMdd235959");
        //    //GetXiaoZhangHistory(this.dateTimeOutStart.Value, this.dateTimeOutEnd.Value);
        //    GetXiaoZhangHistory(this.dateTimeOutStart.Value, this.dateTimeOutEnd.Value, txtCoilNum.Text, txtCarNO.Text);

        //}
        private void GetXiaoZhangHistory(DateTime start, DateTime end)
        {
            string strStart = start.ToString("yyyyMMdd000000");
            string strEnd = end.ToString("yyyyMMdd000000");
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM UACS_PLAN_BILL_ELIMINATE ";
                sql += " WHERE PTIME  > '" + strStart + "' and PTIME <'" + strEnd + "'";
                sql += " ORDER BY PTIME ";
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                dgvXiaoZhang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private bool  GetXiaoZhangHistory(DateTime start, DateTime end,string matNO,string carNO)
        {
            bool ret = false;
            string strStart = start.ToString("yyyyMMddHHmmss");
            string strEnd = end.ToString("yyyyMMddHHmmss");
            DataTable dt = new DataTable();
            //bool hasSetColumn = false;
            try
            {            //DECODE(C.STATUS,1,'成功',2,'失败',0,'待发送'), ,DECODE (C.STORE_ID,'IN','入库','OUT','出库')
                string sql = @" SELECT C.STOWAGE_ID,C.PARKING_NO,C.CAR_NO,C.PTIME,C.STATUS, D.WEIGHT,
                                A.MAT_NO ,C.STORE_ID ,A.STATUS as COIL_STATUS FROM UACS_TRUCK_STOWAGE_DETAIL A 
                                LEFT JOIN UACS_YARDMAP_COIL D ON A.MAT_NO = D.COIL_NO
                                LEFT JOIN UACS_PLAN_BILL_ELIMINATE C ON C.STOWAGE_ID = A.STOWAGE_ID WHERE 1 = 1  AND A.STATUS != '101' ";
                //sql += " AND C.STATUS != '2' ";


                if (cmbArea.Text == "A跨")
                {
                    sql += "AND C.PARKING_NO LIKE 'FT1%'";
                }
                else if (cmbArea.Text == "C跨")
                {
                    sql += "AND C.PARKING_NO LIKE 'FT3%'";
                }
                else
                {
                    sql += "AND C.PARKING_NO LIKE 'FT%'";
                }
                if (matNO.Trim()!="")
                {
                    sql += " AND A.MAT_NO LIKE '%" + matNO.Trim() + "%'";
                }
                else if (carNO.Trim()!="")
                {
                    sql += " AND C.CAR_NO LIKE '%" + carNO.Trim() + "%'"; 
                }
                if (cmbbType.Text =="入库")
                {
                     sql += " AND C.STORE_ID = 'IN' ";
                }
                else if (cmbbType.Text == "出库")
                {
                    sql += " AND C.STORE_ID = 'OUT' ";
                }
                sql += " AND C.PTIME  > '" + strStart + "' and C.PTIME <'" + strEnd + "'";
                sql += " ORDER BY PTIME DESC";
                dt.Clear();
                dt = new DataTable();
               
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    //int row = 0;
                    //if (!hasSetColumn)
                    //{
                    //    //dt.Columns.Add("Index", typeof(string));
                    //    for (int i = 0; i < rdr.FieldCount; i++)
                    //    {
                    //        DataColumn dc = new DataColumn();
                    //        dc.ColumnName = rdr.GetName(i);
                    //        dt.Columns.Add(dc);
                    //        hasSetColumn = true;
                    //    }
                    //}
                    //while (rdr.Read())
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    //dr["Index"] = row;
                    //    for (int i = 0; i < rdr.FieldCount; i++)
                    //    {
                    //        dr[rdr.GetName(i)] = rdr[rdr.GetName(i)];
                    //    }
                    //    dt.Rows.Add(dr);
                    //    row++;
                    //}

                    dt.Load(rdr);
                }
                if (dt.Rows.Count>0)
                {
                    ret = true;
                }

                //if(cmbArea.Text == "A跨")
                //{
                   
                //    DataRow[] drArr = dt.Select("PARKING_NO LIKE'FT1%'");
                //    DataTable dtNew = dt.Clone();
                //    for (int i = 0; i < drArr.Length; i++)
                //    {
                        
                //        dtNew.ImportRow(drArr[i]);

                //    }
                //    dgvXiaoZhang.DataSource = dtNew;
                //}
                //else if (cmbArea.Text == "C跨")
                //{
                //    DataRow[] drCrr = dt.Select("PARKING_NO LIKE'FT3%'");
                //    DataTable dtNew1 = dt.Clone();
                //    for (int i = 0; i < drCrr.Length; i++)
                //    {
                       
                //        dtNew1.ImportRow(drCrr[i]);

                //    }
                //    dgvXiaoZhang.DataSource = dtNew1;
                //}
                //else
                //{
                //    DataRow[] drBrr = dt.Select("PARKING_NO LIKE'%'");
                //    DataTable dtNew2 = dt.Clone();
                //    for (int i = 0; i < drBrr.Length; i++)
                //    {

                //        dtNew2.ImportRow(drBrr[i]);

                //    }
                //    dgvXiaoZhang.DataSource = dtNew2;
                //}
                                              
                dgvXiaoZhang.DataSource = dt;                          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

            return ret;
        }


        private void getDataCount(DateTime start, DateTime end, string matNO, string carNO)
        {
            DataTable dtCount = new DataTable();
            string strStart = start.ToString("yyyyMMddHHmmss");
            string strEnd = end.ToString("yyyyMMddHHmmss");
            DataTable dt = new DataTable();
            //bool hasSetColumn = false;
            try
            {
                string sql = @"SELECT  COUNT (*) AS TOYALROW ,COUNT(distinct A.STOWAGE_ID) AS TOYALSTOWAGNUM ,SUM(D.WEIGHT) AS SUMWEIGHT FROM UACS_TRUCK_STOWAGE_DETAIL A 
                                LEFT JOIN UACS_YARDMAP_COIL D ON A.MAT_NO = D.COIL_NO
                                LEFT JOIN UACS_PLAN_BILL_ELIMINATE C ON C.STOWAGE_ID = A.STOWAGE_ID WHERE 1 = 1 AND D.WEIGHT > 0  ";
                if(cmbArea.Text == "A跨")
                {
                    sql += "AND C.PARKING_NO LIKE 'FT1%'";
                }
                else if (cmbArea.Text == "C跨")
                {
                    sql += "AND C.PARKING_NO LIKE 'FT3%'";
                }
                else
                {
                    sql += "AND C.PARKING_NO LIKE 'FT%'";
                }
                if (matNO.Trim() != "")
                {
                    sql += " AND A.MAT_NO LIKE '%" + matNO.Trim() + "%'";
                }
                else if (carNO.Trim() != "")
                {
                    sql += " AND C.CAR_NO LIKE '%" + carNO.Trim() + "%'";
                }
                if (cmbbType.Text == "入库")
                {
                    sql += " AND C.STORE_ID = 'IN' ";
                }
                else if (cmbbType.Text == "出库")
                {
                    sql += " AND C.STORE_ID = 'OUT' ";
                }
                sql += " AND C.PTIME  > '" + strStart + "' and C.PTIME <'" + strEnd + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    //if (!hasSetColumn)
                    //{
                    //    //dt.Columns.Add("Index", typeof(string));
                    //    for (int i = 0; i < rdr.FieldCount; i++)
                    //    {
                    //        DataColumn dc = new DataColumn();
                    //        dc.ColumnName = rdr.GetName(i);
                    //        dt.Columns.Add(dc);
                    //        hasSetColumn = true;
                    //    }
                    //}
                    //while (rdr.Read())
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    //dr["Index"] = row;
                    //    for (int i = 0; i < rdr.FieldCount; i++)
                    //    {
                    //        dr[rdr.GetName(i)] = rdr[rdr.GetName(i)];
                    //    }
                    //    dt.Rows.Add(dr);
                    //    //row++;
                    //}
                    dtCount.Load(rdr);
                }
               
                txtCoilCount.Text = dtCount.Rows[0]["TOYALROW"] == DBNull.Value ? "" : dtCount.Rows[0]["TOYALROW"].ToString() + " /件";
                txtCarCount.Text = dtCount.Rows[0]["TOYALSTOWAGNUM"] == DBNull.Value ? "" : dtCount.Rows[0]["TOYALSTOWAGNUM"].ToString() + " /辆";
                txtCoilWeight.Text = dtCount.Rows[0]["SUMWEIGHT"] == DBNull.Value ? "" : dtCount.Rows[0]["SUMWEIGHT"].ToString() + " /公斤";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getDataCount(this.dateTimeOutStart.Value, this.dateTimeOutEnd.Value, txtCoilNum.Text, txtCarNO.Text);
            if (!GetXiaoZhangHistory(this.dateTimeOutStart.Value, this.dateTimeOutEnd.Value, txtCoilNum.Text, txtCarNO.Text))
            {
                MessageBox.Show("没有找到指定的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private bool searchDetailByStowageNO(string stowageNO)
        {
            bool ret = false;
            DataTable dt ;
            try
            {
                string sql = "SELECT MAT_NO,STOWAGE_ID,GROOVEID , STATUS FROM UACS_TRUCK_STOWAGE_DETAIL  ";
                sql += "  WHERE STOWAGE_ID = " + stowageNO + " ORDER BY GROOVEID";
                dt = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                if (dt.Rows.Count > 0)
                {
                    ret = true;
                }
                dgvStowage.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvXiaoZhang.Rows.Count; i++)
            {
                if ((bool)dgvXiaoZhang.Rows[i].Cells[0].EditedFormattedValue == true)
                {
                    string stowageNO = dgvXiaoZhang.Rows[i].Cells["STOWAGE_ID"].Value == null ? dgvXiaoZhang.Rows[i].Cells["STOWAGE_ID"].Value.ToString() : "";
                    DialogResult dr1 =new DialogResult();
                    do
                    {
                        if (!updataXiaoZhangStatus(stowageNO))
                        {
                            dr1 = MessageBox.Show("发送失败！", "提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                        }
                    } while (dr1 == DialogResult.Retry);
                    MessageBox.Show("发送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    UACSUtility.HMILogger.WriteLog(button3.Text, "实绩补发，配载号：" + stowageNO, UACSUtility.LogLevel.Info, this.Text);
                    return;
                }
            }
        }

        private bool updataXiaoZhangStatus(string stowageNO)
        {
            bool ret = false;
            try
            {
                string sql = "UPDATE UACS_PLAN_BILL_ELIMINATE SET STATUS = '0'  WHERE STOWAGE_ID = '" + STOWAGE_ID + "'";
                DBHelper.ExecuteNonQuery(sql);
                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }

        private void dgvXiaoZhang_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvXiaoZhang.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvStowage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStowage.Columns[e.ColumnIndex].Name.Equals("Column6") && e.Value != null)
            {
                if (e.Value.ToString() == "100")
                {
                    e.Value = "自动完成";
                    e.CellStyle.BackColor = Color.White;
                }
                else if (e.Value.ToString() == "101")
                {
                    e.Value = "非自动完成";
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }
    }
}
