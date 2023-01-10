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
using System.Threading;
using UACS;
using CLTS;

namespace Inventory
{
    public partial class InventoryShow : FormBase
    {
        // 复核前是否已确定
        private string isBtnOk = string.Empty;

        string userName = string.Empty;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("INVENTORY");

        private Dictionary<string, List<string>> dictInventId2InventArea = new Dictionary<string, List<string>>();
        private List<int> listSelectedRowNo = new List<int>();

        public InventoryShow()
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

            // 复核清单列表
            BindingAllCheckCtrlForDgv(dgvCheck, checBox_All_Checks);
            dtCheck = InitDataTable(dgvCheck);

            //设置背景色
            this.panel2.BackColor = UACS.ColorSln.FormBgColor;
            this.panel3.BackColor = UACS.ColorSln.FormBgColor;

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            //添加tag点
            TagValues.Clear();
            TagValues.Add("INVENTORY_INIT", null);
            TagValues.Add("INVENTORY", null);
            TagValues.Add("INVENTORY_CHECK", null);
            TagValues.Add("INVENTORY_CONFIRM", null);
            tagDP.Attach(TagValues);

            // TAG变化检测
            string[] tagname = new string[] { "INVENTORY_REFRESH" };
            tagDPrefresh.ServiceName = "iplature";
            tagDPrefresh.RegisterData(new Guid(), tagname);

            IAuthorization iAuth = (IAuthorization)Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<IAuthorization>();
            userName = iAuth.GetUserName();

            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("c:\\iPlature\\SF_HOME\\config\\App4log.config"));
        }

        private DataTable InitDataTable(DataGridView datagridView)
        {
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn dgvColumn in datagridView.Columns)
            {
                DataColumn dtColumn = new DataColumn();
                dtColumn.ColumnName = dgvColumn.DataPropertyName;
                if (!dgvColumn.GetType().Equals(typeof(DataGridViewCheckBoxColumn)))
                {
                    dtColumn.DataType = typeof(String);
                    dataTable.Columns.Add(dtColumn);
                }
            }

            return dataTable;
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

        private void SetDgvRowColor()
        {
            for (int i = 0; i < dgvDetail.RowCount; i++)
            {
                string actMatNo = (string)dgvDetail.Rows[i].Cells["MAT_NO"].FormattedValue;
                string infoMatNo = (string)dgvDetail.Rows[i].Cells["Column5"].FormattedValue;
                string remark = (string)dgvDetail.Rows[i].Cells["REMARK"].FormattedValue;
                string result = (string)dgvDetail.Rows[i].Cells["RESULT"].FormattedValue;
                string inventResult = (string)dgvDetail.Rows[i].Cells["INVENT_RESULT"].FormattedValue;

                if (inventResult == "0")
                {
                    dgvDetail.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (inventResult == "2")
                {
                    dgvDetail.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    dgvDetail.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    if (result.Contains("修改失败"))
                    {
                        dgvDetail.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }

            for (int i = 0; i < dgvCheck.RowCount; i++)
            {
                string actMatNo = (string)dgvCheck.Rows[i].Cells["Coil_no"].FormattedValue;
                string infoMatNo = (string)dgvCheck.Rows[i].Cells["DROP_MAT"].FormattedValue;
                string result = (string)dgvCheck.Rows[i].Cells["CHECK_RESULT"].FormattedValue;
                if (actMatNo == "-999999")
                {
                    dgvCheck.Rows[i].Cells["Coil_no"].Value = "尚未复核";
                    continue;
                }

                if (actMatNo != infoMatNo)
                {
                    dgvCheck.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }

                if (result.Contains("修改失败"))
                {
                    dgvCheck.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
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

                string sql = String.Format("SELECT * FROM UACS_PDA_INVENTORY_DETAIL WHERE ID = '{0}'", id);

                // 选定材料号
                if (Mat_No.Length != 0)
                {
                    sql += String.Format(" AND MAT_NO like '{0}%'", Mat_No);
                }
                if (txtStockNo.Text.Length != 0)
                {
                    sql += String.Format(" AND STOCK_NO like '{0}%'", txtStockNo.Text);
                }

                // 清空表格
                DgvClear();

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
                            string columnName = rdr.GetName(i);
                            if (dtDetail.Columns.Contains(columnName))
                                dr[columnName] = rdr[i].ToString();

                            // 查询在指定区域的盘库记录
                            if (columnName == "STOCK_NO" && listSelectedRowNo.Count != 0)
                            {
                                // 指定材料号和库位号时，不受盘库区域限定
                                string stockNo = rdr[i].ToString();
                                bool bStockInSelectedRow = false;
                                for (int n = 0; n < listSelectedRowNo.Count; n++)
                                {
                                    string areaNo = cbxAreaNo.Text.Replace("-","");
                                    string rowNo = string.Format("{0:X}", listSelectedRowNo[n]);
                                    string temp = areaNo + rowNo;

                                    if (stockNo.Contains(temp))
                                    {
                                        bStockInSelectedRow = true;
                                        break;
                                    }
                                }

                                if (!bStockInSelectedRow)
                                    bRowFiltered = true;
                            }
                        }

                        if (!bRowFiltered)
                        {
                            // 计数列
                            dr["SEQ"] = nRowIndex++;
                            dtDetail.Rows.Add(dr);
                        }
                    }
                    dgvDetail.DataSource = dtDetail;
                }

                //复核单
                //查询全部
                string sqcheckl = String.Format("SELECT * FROM UACS_PDA_INVENTORY_CHECK WHERE ID = '{0}'", id);
                // 选定材料号
                if (Mat_No.Length != 0)
                {
                    sqcheckl += String.Format(" AND MAT_NO like '{0}%'", Mat_No);
                }
                if (txtStockNo.Text.Length != 0)
                {
                    sqcheckl += String.Format(" AND STOCK_NO like '{0}%'", txtStockNo.Text);
                }
                dtCheck.Clear();
                using (IDataReader rdr = DBHelper.ExecuteReader(sqcheckl))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dtCheck.NewRow();
                        bool bRowFiltered = false;

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            string columnName = rdr.GetName(i);
                            if (dtCheck.Columns.Contains(columnName))
                                dr[columnName] = rdr[i].ToString();

                            // 未复核的记录,不显示
                            if (columnName == "MAT_NO")
                            {
                                if (rdr[i].ToString() == "-999999")
                                    bRowFiltered = true;
                            }

                            // 查询在指定区域的盘库记录
                            if (columnName == "STOCK_NO" && listSelectedRowNo.Count != 0)
                            {
                                // 指定材料号和库位号时，不受盘库区域限定
                                string stockNo = rdr[i].ToString();
                                bool bStockInSelectedRow = false;
                                for (int n = 0; n < listSelectedRowNo.Count; n++)
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
                        if (!bRowFiltered)
                            dtCheck.Rows.Add(dr);
                    }

                    dgvCheck.DataSource = dtCheck;
                }

                SetDgvRowColor();
            }
            catch (Exception ex)
            {
                log.Error(String.Format("{0}, {1}", ex.Message, ex.StackTrace));
                MessageBox.Show(String.Format("{0}, {1}", ex.Message, ex.StackTrace));
            }
        }

        private void TrigTag(string tagName, string tagValue)
        {
            try
            {
                if (tagValue.Length != 0 && tagName.Length != 0)
                {
                    tagDP.SetData(tagName, tagValue);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }


        private void btnSeachMat_Click(object sender, EventArgs e)
        {
            // 触发刷新
            if (!refreshDgvTimer.Enabled)
            {
                string inventoryID = this.cbbId.Text.Trim();
                TrigTag("INVENTORY", inventoryID);
            }

            // 3秒后刷新预览结果
            refreshDgvTimer.Enabled = true;
        }
        #endregion

        #region --------------------方法------------------------
       /// <summary>
       /// 盘库明细信息
       /// </summary>
       /// <param name="id"></param>
        private void BindDetailDgv(string id = null)
        {
            try
            {
                dtDetail.Clear();

                //查询全部
                string sql = @"SELECT * FROM UACS_PDA_INVENTORY_DETAIL ";
                if (id != null)
                {
                    sql += " WHERE ID = '" + id + "' ";
                }

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    int nRowIndex = 1;
                    while (rdr.Read())
                    { 
                        DataRow dr = dtDetail.NewRow();
                        dr["SEQ"] = nRowIndex++;
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            string ColumnName = rdr.GetName(i);
                            if (dtDetail.Columns.Contains(ColumnName))
                                dr[ColumnName] = rdr[i].ToString();
                        }

                        dtDetail.Rows.Add(dr);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        /// <summary>
        /// 盘库复核信息
        /// </summary>
        /// <param name="id"></param>
        private void BindCheckDgv(string id = null)
        {
            try
            {
                dtCheck.Clear();
                //查询全部
                string sql = @"SELECT * FROM UACS_PDA_INVENTORY_CHECK ";
                if (id != null)
                {
                    sql += " WHERE ID = '" + id + "' ";
                    sql += " AND MAT_NO != '-999999'";
                }

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dtCheck.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            string ColumnName = rdr.GetName(i);
                            if (dtCheck.Columns.Contains(ColumnName))
                                dr[ColumnName] = rdr[i].ToString();
                        }
                        dtCheck.Rows.Add(dr);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

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

        /// <summary>
        /// 清除dgv所有数据
        /// </summary>
        private void DgvClear()
        {
            int indexCheck = this.dgvCheck.Rows.Count;
            if (dgvCheck.Rows.Count > 0)
            {
                for (int i = indexCheck; i >= 1; i--)
                {
                    this.dgvCheck.Rows.RemoveAt(dgvCheck.Rows[i - 1].Index);
                }
            }

            int indexDetail = this.dgvDetail.Rows.Count;
            if (dgvDetail.Rows.Count > 0)
            {
                for (int i = indexDetail; i >= 1; i--)
                {
                    this.dgvDetail.Rows.RemoveAt(dgvDetail.Rows[i - 1].Index);
                }
            }
        }
        #endregion

        #region --------------------按钮------------------------
        /// <summary>
        /// 盘库清单确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string rowlist = null;

                string tagId = this.cbbId.Text.Trim() ;
                tagId += "|";
                tagId += userName;
                
                for (int i = 0; i < dgvDetail.RowCount; i++)
                {
                    bool isChoosed = (bool)dgvDetail.Rows[i].Cells[0].FormattedValue;
                    string RowNo = dgvDetail.Rows[i].Cells["Stock_No"].Value.ToString().Trim();
                    if (isChoosed)
                    {
                        rowlist += RowNo + "|";
                    }
                }

                if (tagId != "" && rowlist != null)
                {
                    rowlist = tagId + "|" + rowlist;
                    TrigTag("INVENTORY_CONFIRM", rowlist);

                    refreshDgvTimer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请选择流水号和库位号！！！");
                    return;
                }            
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string rowlist = "";

                string tagId = this.cbbId.Text.Trim();
                tagId += "|";
                tagId += userName;

                for (int i = 0; i < dgvCheck.RowCount; i++)
                {
                    bool isChoosed = (bool)dgvCheck.Rows[i].Cells["CHECK_FLAG"].FormattedValue;
                    if (dgvCheck.Rows[i].Cells["Stock_No1"].Value != DBNull.Value)
                    {
                        string RowNo = dgvCheck.Rows[i].Cells["Stock_No1"].Value.ToString().Trim();
                        if (isChoosed)
                        {
                            rowlist += RowNo + "|";
                        }
                    }
                }
                if (rowlist == "")
                {
                    return;
                }
                //处理前再次预览对比
                if (tagId != "")
                {
                    tagId = tagId + "|" + rowlist;
                    TrigTag("INVENTORY_CHECK", tagId);

                    refreshDgvTimer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请选择流水号和库位号！！！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 创建盘库单
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateInventoryListForm newform = new CreateInventoryListForm();
            newform.ShowDialog();
        }
        #endregion

        #region --------------------变量------------------------
        private DataTable dtDetail = new DataTable();
        private DataTable dtCheck = new DataTable();
        public delegate void DgeTable(string id);

        //System.Windows.Forms.CheckBox ckBox1 = new System.Windows.Forms.CheckBox();
        //System.Windows.Forms.CheckBox ckBox2 = new System.Windows.Forms.CheckBox();

        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
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
                //log.Error(er.ToString());
            }
        } 
        #endregion

        #region datagridview全选

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

        private void dgvDetail_Scroll(object sender, ScrollEventArgs e)
        {
            //Chb_dgvDetail();
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                return;
            }
            //if (e.NewValue > dgvDetailCenter)
            //{
            //    ckBox1.Visible = false;
            //}
            //else
            //    ckBox1.Visible = true;
        }

        private void dgvCheck_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                return;
            }
            //if (e.NewValue > dgvCheckCenter)
            //{
            //    ckBox2.Visible = false;
            //}
            //else
            //    ckBox2.Visible = true;
        } 
        #endregion

        private void button_KillStock_Click(object sender, EventArgs e)
        {
            CreateInventoryListForm newform = new CreateInventoryListForm();
            newform.ShowDialog();
        }

        private void moveInveDetail2Hisy(string inventoryId, string stockNo)
        {
            try
            {
                // 盘库扫描记录转入履历
                string sql = String.Format("SELECT * FROM UACS_PDA_INVENTORY_DETAIL WHERE ID = '{0}' and STOCK_NO = '{1}'",
                    inventoryId,
                    stockNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        // 读取的字段值
                        Dictionary<string, string> dicColumnValue = new Dictionary<string, string>();
                        for (int n = 0; n < rdr.FieldCount; n++)
                        {
                            string columnName = rdr.GetName(n).ToUpper();
                            Type columnType = rdr[n].GetType();
                            if (columnType.Equals(typeof(DBNull)))
                                dicColumnValue[columnName] = "null";
                            else if (columnType.Equals(typeof(DateTime)))
                                dicColumnValue[columnName] = "'" + ((DateTime)rdr[n]).ToString("yyyyMMddHHmmss") + "'";
                            else if (columnType.Equals(typeof(Int32)))
                                dicColumnValue[columnName] = rdr[n].ToString();
                            else
                                dicColumnValue[columnName] = "'" + rdr[n].ToString() + "'";
                        }

                        string strSql = "INSERT INTO UACS_PDA_INVENTORY_HIS (ID, STOCK_NO, MAT_NO, DROP_MAT, ACTION, RESULT, REMARK,";
                        strSql += " STOCK_NO_IMPLICATE, ACTION_IMPLICATE, RESULT_IMPLICATE,";
                        strSql += " USER, PTID, SCAN_TIME, REC_TIME, CONFIRMER, SURE_TIME, BATCH_ID,";
                        strSql += " INVENT_TYPE, INVENT_RESULT, DEL_FLAG) ";
                        strSql += " VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6},";
                        strSql += " {7}, {8}, {9},";
                        strSql += " {10}, {11}, {12}, {13}, {14}, {15}, {16},";
                        strSql += " {17}, {18}, {19})";
                        // 组织写入SQL
                        string insertSql = String.Format(strSql,
                            dicColumnValue["ID"], dicColumnValue["STOCK_NO"], dicColumnValue["MAT_NO"], dicColumnValue["DROP_MAT"], dicColumnValue["ACTION"], dicColumnValue["RESULT"], dicColumnValue["REMARK"],
                            dicColumnValue["STOCK_NO_IMPLICATE"], dicColumnValue["ACTION_IMPLICATE"], dicColumnValue["RESULT_IMPLICATE"],
                            dicColumnValue["USER"], dicColumnValue["PTID"], dicColumnValue["SCAN_TIME"], dicColumnValue["REC_TIME"], dicColumnValue["CONFIRMER"], dicColumnValue["SURE_TIME"], dicColumnValue["BATCH_ID"],
                            dicColumnValue["INVENT_TYPE"], dicColumnValue["INVENT_RESULT"], 1);

                        //log.Debug(insertSql);
                        //MessageBox.Show(insertSql);

                        // 执行sql语句
                        DBHelper.ExecuteNonQuery(insertSql);
                    }
                }
                string deleSql = String.Format("DELETE FROM UACS_PDA_INVENTORY_DETAIL WHERE ID = '{0}' and STOCK_NO = '{1}'",
                    inventoryId,
                    stockNo);
                DBHelper.ExecuteNonQuery(deleSql);

                // 复核记录进历史表
                sql = String.Format("SELECT * FROM UACS_PDA_INVENTORY_CHECK WHERE ID = '{0}' and STOCK_NO = '{1}'",
                                    inventoryId,
                                    stockNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        // 尚未复核的，不需要存入履历
                        if (rdr["MAT_NO"].ToString() == "-999999")
                            continue;

                        // 读取的字段值
                        Dictionary<string, string> dicColumnValue = new Dictionary<string, string>();
                        for (int n = 0; n < rdr.FieldCount; n++)
                        {
                            string columnName = rdr.GetName(n).ToUpper();
                            Type columnType = rdr[n].GetType();
                            if (columnType.Equals(typeof(DBNull)))
                                dicColumnValue[columnName] = "null";
                            else if (columnType.Equals(typeof(DateTime)))
                                dicColumnValue[columnName] = "'" + ((DateTime)rdr[n]).ToString("yyyyMMddHHmmss") + "'";
                            else if (columnType.Equals(typeof(Int32)))
                                dicColumnValue[columnName] = rdr[n].ToString();
                            else
                                dicColumnValue[columnName] = "'" + rdr[n].ToString() + "'";
                        }

                        string strSql = "INSERT INTO UACS_PDA_INVENTORY_HIS (ID, STOCK_NO, MAT_NO, DROP_MAT, ACTION, RESULT, REMARK,";
                        strSql += " STOCK_NO_IMPLICATE, ACTION_IMPLICATE, RESULT_IMPLICATE,";
                        strSql += " USER, PTID, SCAN_TIME, REC_TIME, CONFIRMER, SURE_TIME, BATCH_ID,";
                        strSql += " INVENT_TYPE, INVENT_RESULT, DEL_FLAG) ";
                        strSql += " VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6},";
                        strSql += " {7}, {8}, {9},";
                        strSql += " {10}, {11}, {12}, {13}, {14}, {15}, {16},";
                        strSql += " {17}, {18}, {19})";
                        // 组织写入SQL
                        string insertSql = String.Format(strSql,
                            dicColumnValue["ID"], dicColumnValue["STOCK_NO"], dicColumnValue["MAT_NO"], dicColumnValue["DROP_MAT"], dicColumnValue["ACTION"], dicColumnValue["RESULT"], dicColumnValue["REMARK"],
                            dicColumnValue["STOCK_NO_IMPLICATE"], dicColumnValue["ACTION_IMPLICATE"], dicColumnValue["RESULT_IMPLICATE"],
                            dicColumnValue["USER"], dicColumnValue["PTID"], dicColumnValue["SCAN_TIME"], dicColumnValue["REC_TIME"], dicColumnValue["CONFIRMER"], dicColumnValue["SURE_TIME"], dicColumnValue["BATCH_ID"],
                            dicColumnValue["INVENT_TYPE"], dicColumnValue["INVENT_RESULT"], 1);

                        //log.Debug(insertSql);
                        //MessageBox.Show(insertSql);

                        // 执行sql语句
                        DBHelper.ExecuteNonQuery(insertSql);
                    }
                    deleSql = String.Format("DELETE FROM UACS_PDA_INVENTORY_CHECK WHERE ID = '{0}' and STOCK_NO = '{1}'",
                                        inventoryId,
                                        stockNo);
                    DBHelper.ExecuteNonQuery(deleSql);
                }
            }
            catch (System.Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button_DelRecord_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvDetail.RowCount; i++)
                {
                    bool isChoosed = (bool)dgvDetail.Rows[i].Cells[0].FormattedValue;
                    string Stock_No = dgvDetail.Rows[i].Cells["Stock_No"].Value.ToString().Trim();
                    string InventoryId = dgvDetail.Rows[i].Cells["ID"].Value.ToString().Trim();
                    if (isChoosed)
                    {
                        moveInveDetail2Hisy(InventoryId, Stock_No);
                    }
                }

                for (int i = 0; i < dgvCheck.RowCount; i++)
                {
                    bool isChoosed = (bool)dgvCheck.Rows[i].Cells[0].FormattedValue;
                    string Stock_No = dgvCheck.Rows[i].Cells["Stock_No1"].Value.ToString().Trim();
                    string InventoryId = dgvCheck.Rows[i].Cells["Column10"].Value.ToString().Trim();
                    if (isChoosed)
                    {
                        moveInveDetail2Hisy(InventoryId, Stock_No);
                    }
                }

                // 刷新
                QueryInventDB();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                //dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
                if (dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "False")
                    dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                else
                    dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                dgvDetail.EndEdit();
            }
        }

        private void checBox_All_Details_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                dgvDetail.Rows[i].Cells[0].Value = checBox_All_Details.Checked;
            }
        }

        private void checBox_All_Checks_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvCheck.Rows.Count; i++)
            {
                if (dgvCheck.Rows[i].Cells["Coil_no"].Value != DBNull.Value)
                {
                    if (dgvCheck.Rows[i].Cells["Coil_no"].Value.ToString() == "-999999")
                    {
                        continue;
                    }
                }
                dgvCheck.Rows[i].Cells["CHECK_FLAG"].Value = checBox_All_Checks.Checked;
            }
        }

        private void refreshDgvTimer_Tick(object sender, EventArgs e)
        {
            refreshDgvTimer.Enabled = false;
            QueryInventDB();
        }

        private void btn_ForceConfirm_Click(object sender, EventArgs e)
        {
            // 强制复核
            try
            {
                //if (dgvCheck.SelectedRows.Count <= 0 )
                //    throw new ArgumentException("未选定记录，进行强制复核");
                //else if (dgvCheck.SelectedRows.Count > 1)
                //    throw new ArgumentException("只允许单条记录，进行强制复核");

                if (dgvCheck.SelectedRows.Count != 1 )
                {
                    throw new ArgumentException("只允许单条记录，进行强制复核");
                    return;
                }

                // 后台
                //CLTS.YardMapFactoryPrx  yardMapFactoryPrx = CLTS.CltsCommunicator.Instance().getYardMapFactory(cbbId.Text.Substring(0, 3));
                CLTS.YardMapFactoryPrx yardMapFactoryPrx;
                if (cbbId.Text.Substring(0, 1) == "A" || cbbId.Text.Substring(0, 1) == "B")
                    yardMapFactoryPrx = CLTS.CltsCommunicator.Instance().getYardMapFactory();
                else
                    yardMapFactoryPrx = CLTS.CltsCommunicator.Instance().getYardMapFactory(cbbId.Text.Substring(0, 3));

                for (int i = 0; i < dgvCheck.SelectedRows.Count; i++)
                {
                    int rowIndex = dgvCheck.SelectedRows[i].Index;
                    bool isChoosed = (bool)dgvCheck.Rows[rowIndex].Cells["CHECK_FLAG"].FormattedValue;
                    if (dgvCheck.Rows[rowIndex].Cells["Stock_No1"].Value != DBNull.Value)
                    {
                        string matNo = dgvCheck.Rows[rowIndex].Cells["Coil_no"].Value.ToString().Trim();
                        string stockNo = dgvCheck.Rows[rowIndex].Cells["Stock_No1"].Value.ToString().Trim();
                        string action = dgvCheck.Rows[rowIndex].Cells["CHECK_RESULT"].Value.ToString().Trim();

                        if (isChoosed)
                        {
                            if (action != "修改失败")
                            {
                                // 复核失败的，才能够进行复核
                                MessageBox.Show("'复核确认'修改失败，才能够进行强制复核!");
                                continue;
                            }

                            // 列表显示最近一次吊运实绩
                            string strStockNo = dgvCheck.Rows[rowIndex].Cells["Stock_No1"].Value.ToString();
                            string strScanTime = dgvCheck.Rows[rowIndex].Cells["CHECK_SCAN_TIME"].Value.ToString();
                            ShowList4StockCraneOper(strStockNo, strScanTime);

                            //// 强制复核前必须输入密码，并且严格提示
                            //MyMessageboxForm form = new MyMessageboxForm();
                            //form.StockNo = strStockNo;
                            //if (form.ShowDialog() == DialogResult.Yes)
                            //{
                            //    // 查询库位最近1次的吊运实绩                           
                            //    CLTS.StockPrx stockPrx = yardMapFactoryPrx.getStock(stockNo);
                            //    stockPrx.forceConfirmed(matNo, userName);
                            //}

                            #region 用户信息确认
                            UACSUtility.SubFrmUserLogin frm = new UACSUtility.SubFrmUserLogin();
                            DialogResult dRet = frm.ShowDialog();
                            //用户信息确认
                            if (frm.DialogResultLogin == DialogResult.Cancel)
                            {
                                return;
                            }
                            if (!frm.AllowLogin)
                            {
                                MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                            #endregion
                            // 查询库位最近1次的吊运实绩                           
                            CLTS.StockPrx stockPrx = yardMapFactoryPrx.getStock(stockNo);
                            stockPrx.forceConfirmed(matNo, frm.UserName);
                            UACSUtility.HMILogger.WriteLog("强制复核", "强制复核,库位号：" + stockNo + ",材料号：" + matNo + ",用户：" + frm.UserName, UACSUtility.LogLevel.Warn, this.Text);

                        }
                    }
                }

                // 刷新画面
                btnSeachMat.PerformClick();
            }
            catch (CLTS.CLTSException ex)
            {
                MessageBox.Show(ex.reason);
            }
            catch (Exception ex)
            {
                // 取得异常信息
                string errorMessage = ex.Message;
                System.Exception parentException = ex.InnerException;
                while (parentException != null)
                {
                    errorMessage += parentException.Message.ToString() + "\n";
                    parentException = parentException.InnerException;
                }
                MessageBox.Show(errorMessage);
            }
        }

        private void dgvCheck_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCheck.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "False")
                dgvCheck.Rows[e.RowIndex].Cells[1].Value = true;
            else
                dgvCheck.Rows[e.RowIndex].Cells[1].Value = false;

            // 从盘库清单中找到盘库记录
        }

        private void InventoryShow_Activated(object sender, EventArgs e)
        {
            Thread threadInitCltsCommunicator = new Thread(new ThreadStart(InitCLTSCommunication));
            threadInitCltsCommunicator.IsBackground = true;
            threadInitCltsCommunicator.Start();
        }

        private void InitCLTSCommunication()
        {
            try
            {
                log.Debug("Begin InitCLTSCommunication");
                DateTime dateTimeStart = DateTime.Now;
                CltsCommunicator.Instance();
                DateTime dateTimeEnd = DateTime.Now;
                log.Debug(String.Format("End InitCLTSCommunication. {Eclpased {0} ms}", (dateTimeEnd - dateTimeStart).TotalMilliseconds));
            }
            catch (CLTS.CLTSException ex)
            {
                log.Error(ex.reason);
            }
            catch (System.Exception ex)
            {
                log.Error(ex.Message);
            }
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

        private void dgvCheck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                if (dgvCheck.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ||
                    (bool)dgvCheck.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == false)
                {
                    dgvCheck.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
                else
                {
                    dgvCheck.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }

                dgvCheck.EndEdit();
            }
        }

        private void ShowList4StockCraneOper(string strStockNo, string scanTime)
        {
            try
            {
                listBox1.Items.Clear();

                if (strStockNo.Length == 0)
                    return;

                listBox1.Items.Add("库位吊运实绩（最近）");
                listBox1.Items.Add(String.Format("库位：{0}", strStockNo));

                // 查询最近一次吊运实绩ID
                int nMaxUniqueID = -1;
                string strSql1 = String.Format("SELECT MAX(UNIQUE_ID) FROM UACS_CRANE_ORDER_OPER_Z32_Z33 WHERE STOCK_NO = '{0}'", strStockNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(strSql1))
                {
                    while (rdr.Read())
                    {
                        nMaxUniqueID = (int)rdr[0];
                    }
                }
   
                if (nMaxUniqueID == -1)
                    return;

                // 查询最近一次吊运实绩内容
                strSql1 = String.Format("SELECT * FROM UACS_CRANE_ORDER_OPER_Z32_Z33 WHERE UNIQUE_ID = {0}", nMaxUniqueID);
                using (IDataReader rdr = DBHelper.ExecuteReader(strSql1))
                {
                    while (rdr.Read())
                    {
                        // 时间
                        DateTime craneOperTime = (DateTime)rdr["REC_TIME"];
                        listBox1.Items.Add("时间：" + rdr["REC_TIME"].ToString());
                        // 起落卷动作
                        string cmdStatus = rdr["CMD_STATUS"].ToString();                        
                        if (cmdStatus == "S")
                        {
                            listBox1.Items.Add("实绩：起卷");
                        }
                        else if (cmdStatus == "E")
                        {
                            listBox1.Items.Add("实绩：落卷");
                        }
                        // 模式
                        string craneMode = rdr["CRANE_MODE"].ToString();
                        if (craneMode == "2")
                        {
                            listBox1.Items.Add("模式：人工");
                        }
                        else if (craneMode == "1")
                        {
                            listBox1.Items.Add("模式：遥控");
                        }
                        else if (craneMode == "4")
                        {
                            listBox1.Items.Add("模式：自动");
                        }
                        // 行车
                        listBox1.Items.Add("行车：" + rdr["CRANE_NO"].ToString());
                        // 盘库时间
                        DateTime dateCheckScan = DateTime.Now;
                        DateTime dateCraneOper = DateTime.Now;
                        DateTime.TryParse(scanTime, out dateCheckScan);
                        DateTime.TryParse(scanTime, out dateCraneOper);
                        if (dateCheckScan < dateCraneOper)
                        {
                            listBox1.Items.Add("备注：盘库后，又落过卷");
                            listBox1.BackColor = Color.Red;
                            listBox1.ForeColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
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
    }
}
 