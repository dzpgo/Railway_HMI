using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.TagService.Interface;


namespace FORMS_OF_REPOSITORIES
{
    /// <summary>
    /// L3计划管理
    /// </summary>
    public partial class L3PlanManage : FormBase
    {
        //转库
        DataTable dt_trans = new DataTable();
        bool hasSetColumn_trans = false;
        //发货
        DataTable dt_pick = new DataTable();
        bool hasSetColumn_pick = false;
        //生产
        DataTable dt_prod = new DataTable();
        bool hasSetColumn_prod = false;
        //材料信息
        DataTable dt_mat = new DataTable();
        bool hasSetColumn_mat = false;
        //
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();

        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;

        public L3PlanManage()
        {
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
        }

        #region 事件
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L3Plan_Load(object sender, EventArgs e)
        {
            try
            {
                this.dateTimePicker1_timeLastChange.Value = DateTime.Now.AddDays(-1);
                this.dt1TimeLastChangeTrans.Value = DateTime.Now.AddDays(-1);
                this.dt1TimeLastChangeProd.Value = DateTime.Now.AddDays(-1);
                //
                TagValues.Clear();
                TagValues.Add("L3PICK_REFRESH", null);
                TagValues.Add("L3TRANS_REFRESH", null);
                TagValues.Add("L3PROD_REFRESH", null);
                tagPick.Attach(TagValues);
                tagTrans.Attach(TagValues);
                tagProd.Attach(TagValues);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 发货查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                GetPickData();
                uACS_PLAN_L3PICKDataGridView.DataSource = dt_pick;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 转库查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryTrans_Click(object sender, EventArgs e)
        {
            try
            {
                GetTransData();
                uACS_PLAN_L3TRANSDataGridView.DataSource = dt_trans;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 生成查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryProd_Click(object sender, EventArgs e)
        {
            try
            {
                GetProdData();
                dataGridView2.DataSource = dt_prod;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 发货计划及转库计划列表切换行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string tag = ((DataGridView)sender).Tag.ToString();
                string sqlText = "";
                if (tag == "pick")
                {
                    if (this.uACS_PLAN_L3PICKDataGridView.CurrentRow == null)
                    {
                        return;
                    }
                    string PICK_NO = this.uACS_PLAN_L3PICKDataGridView.CurrentRow.Cells["PICK_NO"].Value.ToString();
                    sqlText = "select A.COIL_NO as COIL_NO2, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.CONTRACT_NO, B.ACT_WEIGHT, B.ACT_WIDTH, C.STOCK_NO ";
                    sqlText += "from UACS_PLAN_L3PICK A ";
                    sqlText += "left join UACS_YARDMAP_COIL B on A.COIL_NO = B.COIL_NO ";
                    sqlText += "left join UACS_YARDMAP_STOCK_DEFINE C on A.COIL_NO = C.MAT_NO AND C.STOCK_STATUS = 2 ";
                    sqlText += "WHERE A.PICK_NO = '" + PICK_NO + "'";
                }
                else if (tag == "trans")
                {
                    if (this.uACS_PLAN_L3TRANSDataGridView.CurrentRow == null)
                    {
                        return;
                    }
                    string PLAN_NO = this.uACS_PLAN_L3TRANSDataGridView.CurrentRow.Cells["PLAN_NO"].Value.ToString();
                    sqlText = "select A.COIL_NO as COIL_NO2, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.CONTRACT_NO, B.ACT_WEIGHT, B.ACT_WIDTH, C.STOCK_NO ";
                    sqlText += "from UACS_PLAN_L3TRANS A ";
                    sqlText += "left join UACS_YARDMAP_COIL B on A.COIL_NO = B.COIL_NO ";
                    sqlText += "left join UACS_YARDMAP_STOCK_DEFINE C on A.COIL_NO = C.MAT_NO AND C.STOCK_STATUS = 2 ";
                    sqlText += "WHERE A.PLAN_NO = '" + PLAN_NO + "'";
                }
                else if (tag == "prod")
                {
                    if (this.dataGridView2.CurrentRow == null)
                    {
                        return;
                    }
                    string PLAN_NO = this.dataGridView2.CurrentRow.Cells["PLAN_NO2"].Value.ToString();
                    sqlText = "select A.COIL_NO as COIL_NO2, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.CONTRACT_NO, B.ACT_WEIGHT, B.ACT_WIDTH, C.STOCK_NO ";
                    sqlText += "from UACS_PLAN_L3PRODPLAN A ";
                    sqlText += "left join UACS_YARDMAP_COIL B on A.COIL_NO = B.COIL_NO ";
                    sqlText += "left join UACS_YARDMAP_STOCK_DEFINE C on A.COIL_NO = C.MAT_NO AND C.STOCK_STATUS = 2 ";
                    sqlText += "WHERE A.PLAN_NO = '" + PLAN_NO + "'";
                }
                dt_mat.Clear();
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        if (!hasSetColumn_mat)
                        {
                            setDataColumn(dt_mat, rdr);
                        }
                        hasSetColumn_mat = true;
                        //
                        DataRow dr = dt_mat.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            dr[i] = rdr[i];
                        }
                        dt_mat.Rows.Add(dr);
                    }
                }
                dataGridView1.DataSource = dt_mat;
                //设置背景色
                for (int i = 0; i < dt_mat.Rows.Count; i++)
                {
                    if (dt_mat.Rows[i]["STOCK_NO"].ToString() != "")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SeaGreen;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 切换tab页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt_mat.Clear();
                dataGridView1.DataSource = dt_mat;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        #region 处理列表中错误数据（忽略）
        private void uACS_PLAN_L3PICKDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void uACS_PLAN_L3TRANSDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// 收到发货计划刷新tag点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tagPick_DataChangedEvent(object sender, DataChangedEventArgs e)
        {
            try
            {
                bool autoReflesh = this.ckBoxAutoReflesh.Checked;
                if (autoReflesh)
                {
                    GetPickData();
                    uACS_PLAN_L3PICKDataGridView.DataSource = dt_pick;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 收到转库计划刷新tag点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tagTrans_DataChangedEvent(object sender, DataChangedEventArgs e)
        {
            try
            {
                bool autoReflesh = this.ckBoxAutoRefleshTrans.Checked;
                if (autoReflesh)
                {
                    GetTransData();
                    uACS_PLAN_L3TRANSDataGridView.DataSource = dt_trans;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 收到生产计划刷新tag点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tagProd_DataChangedEvent(object sender, DataChangedEventArgs e)
        {
            try
            {
                bool autoReflesh = this.ckBoxAutoRefleshProd.Checked;
                if (autoReflesh)
                {
                    GetProdData();
                    dataGridView2.DataSource = dt_prod;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 设置table的列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rdr"></param>
        private void setDataColumn(DataTable dt, IDataReader rdr)
        {
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = rdr.GetName(i);
                dt.Columns.Add(dc);
            }
        }

        /// <summary>
        /// 获取发货计划数据
        /// </summary>
        private void GetPickData()
        {
            string pickNo = this.textBox_pickNo.Text.Trim();
            string timeLastChange1 = this.dateTimePicker1_timeLastChange.Value.ToString("yyyyMMdd000000");
            string timeLastChange2 = this.dateTimePicker2_timeLastChange.Value.ToString("yyyyMMdd235959");

            string sqlText = @"SELECT DISTINCT PICK_NO, LOT_NO, CREATER, CREATE_TIME, RUN_TIME, TRANS_MODE, CARRIER, DESTINATION, SETTLER, CAR_NO, DEL_FLAG, TOTAL_NUM, TOTAL_SUM, TIME_LAST_CHANGE FROM UACS_PLAN_L3PICK ";
            sqlText += "WHERE PICK_NO like '%" + pickNo + "%' and TIME_LAST_CHANGE > '" + timeLastChange1 + "' and TIME_LAST_CHANGE < '" + timeLastChange2 + "' ";
            sqlText += "order by TIME_LAST_CHANGE desc";
            dt_pick.Clear();
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    if (!hasSetColumn_pick)
                    {
                        setDataColumn(dt_pick, rdr);
                    }
                    hasSetColumn_pick = true;
                    DataRow dr = dt_pick.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dr[i] = rdr[i];
                    }
                    dt_pick.Rows.Add(dr);
                }
            }
            foreach (DataRow dr in dt_pick.Rows)
            {
                string status = "执行";
                string sqlText1 = @"SELECT DEL_FLAG FROM UACS_PLAN_L3PICK WHERE PICK_NO = '" + dr["PICK_NO"].ToString() + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText1))
                {
                    while (rdr.Read())
                    {
                        if (rdr[0].ToString() != "3")
                        {
                            status = "未执行";
                            break;
                        }
                    }
                }
                dr["DEL_FLAG"] = status;
            }
        }

        /// <summary>
        /// 获取转库计划数据
        /// </summary>
        private void GetTransData()
        {
            string pickNo = this.tbPlanNoTrans.Text.Trim();
            string timeLastChange1 = this.dt1TimeLastChangeTrans.Value.ToString("yyyyMMdd000000");
            string timeLastChange2 = this.dt2TimeLastChangeTrans.Value.ToString("yyyyMMdd235959");

            string sqlText = @"SELECT DISTINCT PLAN_NO, NEXT_YARD_NO, DEL_FLAG as DEL_FLAG1, SEQ, TIME_LAST_CHANGE as TIME_LAST_CHANGE1 FROM UACS_PLAN_L3TRANS ";
            sqlText += "WHERE PLAN_NO LIKE '%" + pickNo + "%' and TIME_LAST_CHANGE > '" + timeLastChange1 + "' and TIME_LAST_CHANGE < '" + timeLastChange2 + "' ";
            sqlText += "order by TIME_LAST_CHANGE1 desc";
            dt_trans.Clear();
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    if (!hasSetColumn_trans)
                    {
                        setDataColumn(dt_trans, rdr);
                    }
                    hasSetColumn_trans = true;
                    //
                    DataRow dr = dt_trans.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dr[i] = rdr[i];
                    }
                    dt_trans.Rows.Add(dr);
                }
            }
            foreach (DataRow dr in dt_trans.Rows)
            {
                string status = "执行";
                string sqlText1 = @"SELECT DEL_FLAG FROM UACS_PLAN_L3TRANS WHERE PLAN_NO = '" + dr["PLAN_NO"].ToString() + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText1))
                {
                    while (rdr.Read())
                    {
                        if (rdr[0].ToString() != "3")
                        {
                            status = "未执行";
                            break;
                        }
                    }
                }
                dr["DEL_FLAG1"] = status;
            }
        }

        /// <summary>
        /// 获取生产计划数据
        /// </summary>
        private void GetProdData()
        {
            string pickNo = this.tbPlanNoProd.Text.Trim();
            string timeLastChange1 = this.dt1TimeLastChangeProd.Value.ToString("yyyyMMdd000000");
            string timeLastChange2 = this.dt2TimeLastChangeProd.Value.ToString("yyyyMMdd235959");

            //string sqlText = @"SELECT * FROM FV_L3PLAN ";
            string sqlText = @"SELECT DISTINCT PLAN_NO, UNIT_NO, DEL_FLAG, SEQ, TIME_LAST_CHANGE FROM UACS_PLAN_L3PRODPLAN ";
            sqlText += "WHERE PLAN_NO LIKE '%" + pickNo + "%' and TIME_LAST_CHANGE > '" + timeLastChange1 + "' and TIME_LAST_CHANGE < '" + timeLastChange2 + "' ";
            sqlText += "order by TIME_LAST_CHANGE desc";
            dt_prod.Clear();

           // ViewHelper.GenDataGridViewData(DBHelper, dataGridView2, sqlText, false, "PLAN_NO",comboBox1);

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    if (!hasSetColumn_prod)
                    {
                        setDataColumn(dt_prod, rdr);
                    }
                    hasSetColumn_prod = true;
                    //
                    DataRow dr = dt_prod.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dr[i] = rdr[i];
                    }
                    dt_prod.Rows.Add(dr);
                }
            }
            foreach (DataRow dr in dt_prod.Rows)
            {
                string status = "执行";
                string sqlText1 = @"SELECT DEL_FLAG FROM UACS_PLAN_L3PRODPLAN WHERE PLAN_NO = '" + dr["PLAN_NO"].ToString() + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText1))
                {
                    while (rdr.Read())
                    {
                        if (rdr[0].ToString() != "3")
                        {
                            status = "未执行";
                            break;
                        }
                    }
                }
                dr["DEL_FLAG"] = status;
            }

        }
        #endregion
    }
}
