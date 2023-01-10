using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.TagService.Interface;
using Baosight.iSuperframe.Authorization.Interface;
using UACS;

namespace Inventory
{
    public partial class InventoryShowHis : FormBase
    {
        // 复核前是否已确定
        private string isBtnOk = string.Empty;

        string userName = string.Empty;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(InventoryShow));

        private Dictionary<string, List<string>> dictInventId2InventArea = new Dictionary<string, List<string>>();
        private List<int> listSelectedRowNo = new List<int>();

        public InventoryShowHis()
        {
            InitializeComponent();
            this.Load += InventoryShow_Load;
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

        #region --------------------事件------------------------
        void InventoryShow_Load(object sender, EventArgs e)
        {
            // 盘库清单列表
            BindingAllCheckCtrlForDgv(dgvDetail, checBox_All_Details);
            dtDetail = InitDataTable(dgvDetail);

            // 盘库周期当前时间前后5小时
            dateTimePicker1.Value = DateTime.Now.AddHours(-8);
            dateTimePicker2.Value = DateTime.Now.AddHours(1);
        }

        private DataTable InitDataTable(DataGridView datagridView)
        {
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn dgvColumn in datagridView.Columns)
            {
                DataColumn dtColumn = new DataColumn();
                if (!dgvColumn.GetType().Equals(typeof(DataGridViewCheckBoxColumn)))
                {
                    dtColumn.ColumnName = dgvColumn.Name.ToUpper();
                    dtColumn.DataType = typeof(String);
                    dataTable.Columns.Add(dtColumn);
                }
            }

            return dataTable;
        }

        private void cbbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbxAreaNo.Items.Clear();
                
                string inventoryID = cbbId.Text;
                if (dictInventId2InventArea.ContainsKey(inventoryID))
                {
                    //盘库范围条件，默认为全部
                    cbxAreaNo.Items.Add("全部");
                    cbxAreaNo.SelectedIndex = 0;

                    // 盘库范围条件，增加选定盘库单下所有的区域
                    List<string> listAreaNo = dictInventId2InventArea[inventoryID];
                    foreach (string areaNo in listAreaNo)
                    {
                        cbxAreaNo.Items.Add(areaNo);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void cbxAreaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxAreaNo.Text != "全部" && cbxAreaNo.Text != "")
                {
                    string areaNo = cbxAreaNo.Text;
                    listSelectedRowNo = GetRowNo(areaNo);
                }
                else
                {
                    listSelectedRowNo.Clear();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void cbbId_Click(object sender, EventArgs e)
        {
            try
            {
                BindCbb();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void txtMatNo_TextChanged(object sender, EventArgs e)
        {
            if (txtMatNo.Text.Length != 0 &&
                cbxAreaNo.Items.Count > 0)
            {
                // 盘库查询条件，设定为按材料查询

                //重置盘库范围的查询条件
                cbxAreaNo.SelectedIndex = 0;
                //重置盘库材料的查询条件
                txtStockNo.Text = ""; 
            }
        }

        private void txtStockNo_TextChanged(object sender, EventArgs e)
        {
            if (txtStockNo.Text.Length != 0 &&
                cbxAreaNo.Items.Count > 0)
            {
                // 盘库查询条件，设定为按库位查询

                //重置盘库范围的查询条件
                cbxAreaNo.SelectedIndex = 0;
                //重置盘库材料的查询条件
                txtMatNo.Text = "";
            }
        }

        private void SetDgvRowColor()
        {
            for (int i = 0; i < dgvDetail.RowCount; i++)
            {
                string actMatNo = (string)dgvDetail.Rows[i].Cells["MAT_NO"].FormattedValue;
                string infoMatNo = (string)dgvDetail.Rows[i].Cells["DROP_MAT"].FormattedValue;
                string remark = (string)dgvDetail.Rows[i].Cells["REMARK"].FormattedValue;
                string result = (string)dgvDetail.Rows[i].Cells["RESULT"].FormattedValue;
                string inventResult = (string)dgvDetail.Rows[i].Cells["INVENT_RESULT"].FormattedValue;

                // 实物与信息有差异，特殊显示
                if (inventResult == "0")
                {
                    dgvDetail.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (inventResult == "2")
                {
                    // 盘出会砸卷库位, 红底白字
                    dgvDetail.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    dgvDetail.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }

                // 强制或错误盘库记录，特殊显示
                if (result.Contains("修改失败"))
                {
                    dgvDetail.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                if (remark.Contains("强制复核成功"))
                {
                    // 强制复核，红底白字
                    dgvDetail.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dgvDetail.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private string trans2ColumnValue(string columnName, object obj)
        {
            string columnValue = obj.ToString();

            if (columnName == "INVENT_TYPE")
            {
                switch ((int)obj)
                {
                    case 0:
                        columnValue = "投用盘库";
                        break;
                    case 1:
                        columnValue = "普通盘库";
                        break;
                    case 2:
                        columnValue = "复核盘库";
                        break;
                }
            }

            return columnValue;
        }

        private void QueryInventDB()
        {
            try
            {
                string id = cbbId.Text;
                string Mat_No = txtMatNo.Text.Trim();

                if (id.Length == 0)
                {
                    MessageBox.Show("尚未选择盘库流水号");
                    return;
                }

                string sql = String.Format("SELECT * FROM UACS_PDA_INVENTORY_HIS WHERE REC_TIME > '{0}' AND REC_TIME < '{1}' AND ID = '{2}'",
                    dateTimePicker1.Value.ToString("yyyyMMddHHmmss"),
                    dateTimePicker2.Value.ToString("yyyyMMddHHmmss"),
                    id);

                // 按盘库结果查询
                if ((checkBox1.Checked && checkBox2.Checked) == false)
                {
                    if (checkBox1.Checked)
                        sql += String.Format(" AND INVENT_RESULT = 1");
                    else
                        sql += String.Format(" AND INVENT_RESULT != 1");
                }

                // 按盘库（材料、库位）查询
                if (txtStockNo.Text.Length != 0)
                {
                    sql += String.Format(" AND STOCK_NO LIKE '{0}%'",
                        txtStockNo.Text);
                }
                else if (txtMatNo.Text.Length != 0)
                {
                    sql += String.Format(" AND MAT_NO LIKE '{0}%'",
                        txtMatNo.Text);
                }

                sql +=" ORDER BY SEQ DESC";

                // 重新绑定数据
                dtDetail.Clear();
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    int nRowIndex = 1;
                    while (rdr.Read())
                    {
                        DataRow dr = dtDetail.NewRow();
                        bool bRowFiltered = false;
                        // 其他列
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            string columnName = rdr.GetName(i).ToUpper();
                            if (dtDetail.Columns.Contains(columnName))
                            {
                                if (rdr[i].GetType().Equals(typeof(DBNull)))
                                    dr[columnName] = "";
                                else
                                    dr[columnName] = trans2ColumnValue(columnName, rdr[i]);

                                // 查询在指定区域的盘库记录
                                if (columnName == "STOCK_NO" && listSelectedRowNo.Count != 0)
                                {
                                    // 指定材料号和库位号时，不受盘库区域限定
                                    string stockNo = rdr[i].ToString();
                                    bool bStockInSelectedRow = false;
                                    for (int n = 0; n < listSelectedRowNo.Count; n ++)
                                    {
                                        string areaNo = cbxAreaNo.Text.Substring(0, 3);
                                        string rowNo = string.Format("{0:d3}", listSelectedRowNo[n]);

                                        if (stockNo.Contains(areaNo + rowNo))
                                        {
                                            bStockInSelectedRow = true;
                                            break;
                                        }
                                    }

                                    if (!bStockInSelectedRow)
                                        bRowFiltered = true;
                                }
                            }
                        }

                        if (!bRowFiltered)
                            dtDetail.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeachMat_Click(object sender, EventArgs e)
        {
            // 触发刷新
            if (!refreshDgvTimer.Enabled)
            {
                refreshDgvTimer.Enabled = true;
            }
        }
        #endregion

        #region --------------------方法------------------------
        /// <summary>
        /// 绑定流水号
        /// </summary>
        private void BindCbb()
        {
            try
            {
                cbbId.Items.Clear();
                cbxAreaNo.Items.Clear();
                dictInventId2InventArea.Clear();

                string sqlGetId = @"SELECT DISTINCT(ID) FROM UACS_PDA_INVENTORY_MAIN";
                string sqlId2Area = "";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlGetId))
                {
                    while (rdr.Read())
                    {
                        string strInventoryID = rdr[0].ToString();
                        List<string> listInventoryArea = GetInventoryArea(strInventoryID);
                        dictInventId2InventArea[strInventoryID] = listInventoryArea;

                        cbbId.Items.Add(strInventoryID);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private List<string> GetInventoryArea(string inventoryID)
        {
            List<string> listAreaNo = new List<string>();

            try
            {

                string strSql1 = String.Format("SELECT DISTINCT(ROW_NO) FROM UACS_PDA_INVENTORY_AREA WHERE ID = '{0}'", inventoryID);
                string strSql2 = String.Format("SELECT DISTINCT(AREA_NO) FROM UACS_YARDMAP_ROWCOL_DEFINE WHERE COL_ROW_NO IN ({0})", strSql1);
                using (IDataReader rdr = DBHelper.ExecuteReader(strSql2))
                {
                    while (rdr.Read())
                    {
                        string strAreaNo = rdr[0].ToString();
                        listAreaNo.Add(strAreaNo);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            return listAreaNo;
        }

        private List<int> GetRowNo(string areaNo)
        {
            List<int> listRowNo = new List<int>();

            try
            {
                string strSql1 = String.Format("SELECT COL_ROW_SEQ FROM UACS_YARDMAP_ROWCOL_DEFINE WHERE AREA_NO = '{0}'", areaNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(strSql1))
                {
                    while (rdr.Read())
                    {
                        int nRowNo = (int)rdr[0];
                        listRowNo.Add(nRowNo);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            return listRowNo;
        }

        /// <summary>
        /// 清除dgv所有数据
        /// </summary>
        private void RefreshDataGridView(DataGridView dgv, DataTable dataTable)
        {
            // DataGridView绑定数据
            dgv.DataSource = dataTable;

            // 突出显示
            SetDgvRowColor();
        }
        #endregion

        #region --------------------按钮------------------------
 

        #endregion

        #region --------------------变量------------------------
        private DataTable dtDetail = new DataTable();
        #endregion

        #region tag事件刷新

        private void tagDPrefresh_DataChangedEvent(object sender, DataChangedEventArgs e)
        {
            try
            {
                if (e.DataCollection.Keys.Contains("INVENTORY_REFRESH"))
                {
                    string id = e.DataCollection["INVENTORY_REFRESH"].ToString();
                    // ...
                }
            }
            catch (Exception er)
            {
                log.Error(er.ToString());
            }
        } 
        #endregion

        /// <summary>
        /// 添加dgvDetail的checkbox
        /// </summary>
        private void BindingAllCheckCtrlForDgv(DataGridView dgv, CheckBox allCheckBox)
        {
            allCheckBox.Text = "全选";
            allCheckBox.Checked = false;
            allCheckBox.Size = new System.Drawing.Size(14, 14);
            int x = dgv.Columns[0].Width / 2 - (14 / 2);
            int y = dgv.ColumnHeadersHeight / 2 - (14 / 2);
            allCheckBox.Location = new Point(x, y);
            allCheckBox.BackColor = dgv.BackgroundColor;
            dgv.Controls.Add(allCheckBox);
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                if (dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "False")
                    dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                else
                    dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
            }
        }

        private void checBox_All_Details_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                dgvDetail.Rows[i].Cells[0].Value = checBox_All_Details.Checked;
            }
        }

        private void refreshDgvTimer_Tick(object sender, EventArgs e)
        {
            refreshDgvTimer.Enabled = false;
            QueryInventDB();
            RefreshDataGridView(dgvDetail, dtDetail);
        }

        private void dgvDetail_Sorted(object sender, EventArgs e)
        {
            RefreshDataGridView(dgvDetail, dtDetail);
        }


    }
}
 