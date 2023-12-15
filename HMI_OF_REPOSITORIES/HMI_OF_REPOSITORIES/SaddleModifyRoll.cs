using Baosight.iSuperframe.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UACSUtility;

namespace HMI_OF_REPOSITORIES
{
    public partial class SaddleModifyRoll : Form
    {
        private static IDBHelper DBHelper = null;
        private DataTable Initial_DGV_A = null;
        private DataTable Initial_DGV_C = null;
        public SaddleModifyRoll()
        {
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");

            // A跨，加载数据
            RefreshDataA();
            // C跨，加载数据
            RefreshDataC();
        }
        #region 点击事件
        /// <summary>
        /// A跨，加载数据
        /// </summary>
        /// <returns></returns>
        private void RefreshDataA()
        {
            try
            {
                if (Initial_DGV_A != null && Initial_DGV_A.Rows.Count > 0)
                    Initial_DGV_A.Clear();
                DataTable dt = new DataTable();
                DataTable DGV_A_Source = new DataTable(); //InitDataTable(DGV_A);
                DGV_A_Source.Columns.Add("STOCK_NO");
                DGV_A_Source.Columns.Add("STOCK_NAME");
                DGV_A_Source.Columns.Add("STOCK_STATUS");
                DGV_A_Source.Columns.Add("MAT_NO");
                DGV_A_Source.Columns.Add("BAY_NO");
                DGV_A_Source.Columns.Add("STATUS");
                Initial_DGV_A = DGV_A_Source.Clone();

                var sqlText = @"SELECT DISTINCT A.STOCK_NO, A.STOCK_NAME, A.STOCK_STATUS, A.MAT_NO, A.BAY_NO, B.STATUS 
                                    FROM UACSAPP.UACS_YARDMAP_STOCK_DEFINE A 
                                    LEFT JOIN UACS_PLAN_OUT_DETAIL B ON A.MAT_NO = B.MAT_NO 
                                    WHERE BAY_NO = 'A-1' AND A.STOCK_NO IN ('FT11A001','FT11A003','FT11A005','FT11A007','FT11A009','FT11A011','FT11A013','FT11A015','FT11A017'
                                    ,'FT11A019','FT11A021','FT11A023','FT11A025','FT11A027','FT11A029','FT11A031','FT11A033','FT11A035','FT11A037','FT11A039','FT11A041','FT11A043'
                                    ,'FT11A045','FT11A047','FT11A049','FT11A051','FT11A053','FT11A055','FT11A057','FT11A059');";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    dt.Load(rdr);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["BAY_NO"].ToString()))
                        {
                            if (row["BAY_NO"].ToString().Equals("A-1"))
                            {
                                // 为 DGV_A_Source 创建新的 DataRow
                                DataRow newRow = DGV_A_Source.NewRow();
                                // 将原始 DataRow 的值复制到新的 DataRow
                                newRow.ItemArray = row.ItemArray;
                                // 将新的 DataRow 添加到 DGV_A_Source
                                DGV_A_Source.Rows.Add(newRow);

                                DataRow InitialNewRow = Initial_DGV_A.NewRow();
                                InitialNewRow.ItemArray = row.ItemArray;
                                Initial_DGV_A.Rows.Add(InitialNewRow);
                            }
                        }
                    }
                    DGV_A.DataSource = DGV_A_Source;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// C跨，加载数据
        /// </summary>
        /// <returns></returns>
        private void RefreshDataC()
        {
            try
            {
                if (Initial_DGV_C != null && Initial_DGV_C.Rows.Count > 0)
                    Initial_DGV_C.Clear();
                DataTable dt = new DataTable();
                DataTable DGV_C_Source = new DataTable(); //InitDataTable(DGV_C);
                DGV_C_Source.Columns.Add("STOCK_NO");
                DGV_C_Source.Columns.Add("STOCK_NAME");
                DGV_C_Source.Columns.Add("STOCK_STATUS");
                DGV_C_Source.Columns.Add("MAT_NO");
                DGV_C_Source.Columns.Add("BAY_NO");
                DGV_C_Source.Columns.Add("STATUS");
                Initial_DGV_C = DGV_C_Source.Clone();

                var sqlText = @"SELECT DISTINCT A.STOCK_NO, A.STOCK_NAME, A.STOCK_STATUS, A.MAT_NO, A.BAY_NO, B.STATUS 
                                    FROM UACSAPP.UACS_YARDMAP_STOCK_DEFINE A 
                                    LEFT JOIN UACS_PLAN_OUT_DETAIL B ON A.MAT_NO = B.MAT_NO 
                                    WHERE BAY_NO = 'C-1' AND A.STOCK_NO IN ('FT33A001','FT33A003','FT33A005','FT33A007','FT33A009'
                                    ,'FT33A011','FT33A013','FT33A015','FT33A017','FT33A019','FT33A021','FT33A023','FT33A025','FT33A027','FT33A029','FT33A031','FT33A033','FT33A035'
                                    ,'FT33A037','FT33A039','FT33A041','FT33A043','FT33A045','FT33A047','FT33A049','FT33A051','FT33A053','FT33A055','FT33A057','FT33A059');";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    dt.Load(rdr);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["BAY_NO"].ToString()))
                        {
                            if (row["BAY_NO"].ToString().Equals("C-1"))
                            {
                                // 为 DGV_C_Source 创建新的 DataRow
                                DataRow newRow = DGV_C_Source.NewRow();
                                // 将原始 DataRow 的值复制到新的 DataRow
                                newRow.ItemArray = row.ItemArray;
                                // 将新的 DataRow 添加到 DGV_C_Source
                                DGV_C_Source.Rows.Add(newRow);

                                DataRow InitialNewRow = Initial_DGV_C.NewRow();
                                InitialNewRow.ItemArray = row.ItemArray;
                                Initial_DGV_C.Rows.Add(InitialNewRow);
                            }
                        }
                    }
                    DGV_C.DataSource = DGV_C_Source;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// A跨，保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Save_A_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_A.DataSource != null && Initial_DGV_A != null && DGV_A.Rows.Count > 0 && Initial_DGV_A.Rows.Count > 0)
                {
                    //确认提示
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult drmsg = MessageBox.Show("确认是否修改数据？", "提示", btn, MessageBoxIcon.Asterisk);
                    if (drmsg == DialogResult.OK)
                    {
                        Dictionary<string, string> UpdateDictionary = new Dictionary<string, string>();
                        foreach (DataGridViewRow dgv in DGV_A.Rows)
                        {
                            foreach (DataRow dr in Initial_DGV_A.Rows)
                            {
                                var dgvStockNo = dgv.Cells["STOCK_NO_A"].Value.ToString();
                                var drtockNo = dr["STOCK_NO"].ToString();
                                if (!string.IsNullOrEmpty(dgv.Cells["STOCK_NO_A"].Value.ToString()) && !string.IsNullOrEmpty(dr["STOCK_NO"].ToString()) && dgv.Cells["STOCK_NO_A"].Value.ToString().Equals(dr["STOCK_NO"].ToString()))
                                {
                                    //判断物料是否更改
                                    if (!dgv.Cells["MAT_NO_A"].Value.ToString().Equals(dr["MAT_NO"].ToString()))
                                    {
                                        UpdateDictionary.Add(dgv.Cells["STOCK_NO_A"].Value.ToString(), dgv.Cells["MAT_NO_A"].Value.ToString());
                                    }
                                }
                            }
                        }
                        var SqlText = "";
                        foreach (KeyValuePair<string, string> kvp in UpdateDictionary)
                        {
                            var stockNo = kvp.Key;
                            var matNo = kvp.Value;
                            var stockStatus = string.Empty;
                            if (!string.IsNullOrEmpty(matNo))
                            {
                                stockStatus = "2";
                                SqlText += " UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = '" + stockStatus + "' ,MAT_NO = '" + matNo + "' WHERE STOCK_NO = '" + stockNo + "'; ";
                            }
                            else
                            {
                                stockStatus = "0";
                                SqlText += " UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = '" + stockStatus + "' ,MAT_NO = '" + matNo + "' WHERE STOCK_NO = '" + stockNo + "'; ";
                            }
                        }

                        if (UpdateDictionary.Count > 0)
                        {
                            var commandtext = SqlText;
                            var rowsAffected = DBHelper.ExecuteNonQuery(commandtext);
                            if (rowsAffected > 0)
                            {
                                if (UpdateDictionary.Count == rowsAffected)
                                {
                                    MessageBoxButtons btnok = MessageBoxButtons.OK;
                                    DialogResult drokmsg = MessageBox.Show("保存成功，已修改 " + rowsAffected + " / " + UpdateDictionary.Count + " 条！", "提示", btnok, MessageBoxIcon.Asterisk);
                                    HMILogger.WriteLog(tb_Save_A.Text, "保存成功，已修改 " + rowsAffected + " / " + UpdateDictionary.Count + " 条！", UACSUtility.LogLevel.Info, this.Text);
                                }
                                else
                                {
                                    MessageBoxButtons btnok = MessageBoxButtons.OK;
                                    DialogResult drokmsg = MessageBox.Show("保存成功，已修改 " + rowsAffected + " / " + UpdateDictionary.Count + " 条！", "提示", btnok, MessageBoxIcon.Warning);
                                    HMILogger.WriteLog(tb_Save_A.Text, "保存成功，已修改 " + rowsAffected + " / " + UpdateDictionary.Count + " 条！", UACSUtility.LogLevel.Warn, this.Text);
                                }
                            }
                            else
                            {
                                MessageBoxButtons btnok = MessageBoxButtons.OK;
                                DialogResult drokmsg = MessageBox.Show("保存失败，无数据更改！", "提示", btnok, MessageBoxIcon.Error);
                                HMILogger.WriteLog(tb_Save_A.Text, "保存失败，无数据更改！", UACSUtility.LogLevel.Error, this.Text);
                            }
                        }
                        else
                        {
                            MessageBoxButtons btnok = MessageBoxButtons.OK;
                            DialogResult drokmsg = MessageBox.Show("保存失败，无数据更改！", "提示", btnok, MessageBoxIcon.Error);
                            HMILogger.WriteLog(tb_Save_A.Text, "保存失败，无数据更改！", UACSUtility.LogLevel.Error, this.Text);

                        }
                        // 刷新数据
                        RefreshDataA();
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxButtons btn = MessageBoxButtons.OK;
                DialogResult drmsg = MessageBox.Show("保存失败，无数据更改！", "提示", btn, MessageBoxIcon.Error);
                HMILogger.WriteLog(tb_Save_A.Text, "保存失败，无数据更改！", UACSUtility.LogLevel.Error, this.Text);
            }
        }
        /// <summary>
        /// C跨，保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Save_C_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_C.DataSource != null && Initial_DGV_C != null && DGV_C.Rows.Count > 0 && Initial_DGV_C.Rows.Count > 0)
                {
                    //确认提示
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult drmsg = MessageBox.Show("确认是否修改数据？", "提示", btn, MessageBoxIcon.Asterisk);
                    if (drmsg == DialogResult.OK)
                    {
                        Dictionary<string, string> UpdateDictionary = new Dictionary<string, string>();
                        foreach (DataGridViewRow dgv in DGV_C.Rows)
                        {
                            foreach (DataRow dr in Initial_DGV_C.Rows)
                            {
                                var dgvStockNo = dgv.Cells["STOCK_NO_C"].Value.ToString();
                                var drtockNo = dr["STOCK_NO"].ToString();
                                if (!string.IsNullOrEmpty(dgv.Cells["STOCK_NO_C"].Value.ToString()) && !string.IsNullOrEmpty(dr["STOCK_NO"].ToString()) && dgv.Cells["STOCK_NO_C"].Value.ToString().Equals(dr["STOCK_NO"].ToString()))
                                {
                                    //判断物料是否更改
                                    if (!dgv.Cells["MAT_NO_C"].Value.ToString().Equals(dr["MAT_NO"].ToString()))
                                    {
                                        UpdateDictionary.Add(dgv.Cells["STOCK_NO_C"].Value.ToString(), dgv.Cells["MAT_NO_C"].Value.ToString());
                                    }
                                }
                            }
                        }
                        var SqlText = "";
                        foreach (KeyValuePair<string, string> kvp in UpdateDictionary)
                        {
                            var stockNo = kvp.Key;
                            var matNo = kvp.Value;
                            var stockStatus = string.Empty;
                            if (!string.IsNullOrEmpty(matNo))
                            {
                                stockStatus = "2";
                                SqlText += " UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = '" + stockStatus + "' ,MAT_NO = '" + matNo + "' WHERE STOCK_NO = '" + stockNo + "'; ";
                            }
                            else
                            {
                                stockStatus = "0";
                                SqlText += " UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = '" + stockStatus + "' ,MAT_NO = '" + matNo + "' WHERE STOCK_NO = '" + stockNo + "'; ";
                            }
                        }

                        if (UpdateDictionary.Count > 0)
                        {
                            var commandtext = SqlText;
                            var rowsAffected = DBHelper.ExecuteNonQuery(commandtext);
                            if (rowsAffected > 0)
                            {
                                if (UpdateDictionary.Count == rowsAffected)
                                {
                                    MessageBoxButtons btnok = MessageBoxButtons.OK;
                                    DialogResult drokmsg = MessageBox.Show("保存成功，已修改 " + rowsAffected + " / " + UpdateDictionary.Count + " 条！", "提示", btnok, MessageBoxIcon.Asterisk);
                                    HMILogger.WriteLog(tb_Save_C.Text, "保存成功，已修改 " + rowsAffected + " / " + UpdateDictionary.Count + " 条！", UACSUtility.LogLevel.Info, this.Text);
                                }
                                else
                                {
                                    MessageBoxButtons btnok = MessageBoxButtons.OK;
                                    DialogResult drokmsg = MessageBox.Show("保存成功，已修改 " + rowsAffected + " / " + UpdateDictionary.Count + " 条！", "提示", btnok, MessageBoxIcon.Warning);
                                    HMILogger.WriteLog(tb_Save_C.Text, "保存成功，已修改 " + rowsAffected + " / " + UpdateDictionary.Count + " 条！", UACSUtility.LogLevel.Warn, this.Text);
                                }
                            }
                            else
                            {
                                MessageBoxButtons btnok = MessageBoxButtons.OK;
                                DialogResult drokmsg = MessageBox.Show("保存失败，无数据更改！", "提示", btnok, MessageBoxIcon.Error);
                                HMILogger.WriteLog(tb_Save_C.Text, "保存失败，无数据更改！", UACSUtility.LogLevel.Error, this.Text);
                            }
                        }
                        else
                        {
                            MessageBoxButtons btnok = MessageBoxButtons.OK;
                            DialogResult drokmsg = MessageBox.Show("保存失败，无数据更改！", "提示", btnok, MessageBoxIcon.Error);
                            HMILogger.WriteLog(tb_Save_C.Text, "保存失败，无数据更改！", UACSUtility.LogLevel.Error, this.Text);
                        }
                        // 刷新数据
                        RefreshDataC();
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxButtons btn = MessageBoxButtons.OK;
                DialogResult drmsg = MessageBox.Show("保存失败，无数据更改！", "提示", btn, MessageBoxIcon.Error);
                HMILogger.WriteLog(tb_Save_C.Text, "保存失败，无数据更改！", UACSUtility.LogLevel.Error, this.Text);
            }
        }
        /// <summary>
        /// A跨，刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Refresh_A_Click(object sender, EventArgs e)
        {
            RefreshDataA();
        }
        /// <summary>
        /// C跨，刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Refresh_C_Click(object sender, EventArgs e)
        {
            RefreshDataC();
        }
        #endregion

        #region 触发事件
        /// <summary>
        /// A跨，状态等于1时，行设置红色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_A_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 判断是否是目标列，例如第二列（索引为1）
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var STATUS = DGV_A.Rows[e.RowIndex].Cells[5].Value;
                // 将单元格的值转换为整数

                // 如果值为1，设置背景颜色为红色
                if (!string.IsNullOrEmpty(STATUS.ToString()) && STATUS.ToString().Equals("1"))
                {
                    e.CellStyle.BackColor = Color.Tomato;
                }
                else
                {
                    // 根据行索引设置隔行背景颜色
                    if (e.RowIndex % 2 == 0)
                    {
                        // 偶数行，设置背景颜色为灰色或其他颜色
                        e.CellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        // 奇数行，设置背景颜色为默认颜色
                        e.CellStyle.BackColor = SystemColors.Control;
                    }
                }
            }
        }
        /// <summary>
        /// C跨，状态等于1时，行设置红色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_C_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 判断是否是目标列，例如第二列（索引为1）
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var STATUS = DGV_C.Rows[e.RowIndex].Cells[5].Value;
                // 将单元格的值转换为整数

                // 如果值为1，设置背景颜色为红色
                if (!string.IsNullOrEmpty(STATUS.ToString()) && STATUS.ToString().Equals("1"))
                {
                    e.CellStyle.BackColor = Color.Tomato;
                }
                else
                {
                    // 根据行索引设置隔行背景颜色
                    if (e.RowIndex % 2 == 0)
                    {
                        // 偶数行，设置背景颜色为灰色或其他颜色
                        e.CellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        // 奇数行，设置背景颜色为默认颜色
                        e.CellStyle.BackColor = SystemColors.Control;
                    }
                }
            }
        }
        /// <summary>
        /// A跨，限制输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_A_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // 判断是否是你要限制的列
            if (DGV_A.CurrentCell.ColumnIndex == 3) // 假设是第一列
            {
                TextBox textBox = e.Control as TextBox;

                if (textBox != null)
                {
                    // 移除 KeyPress 事件处理程序，以免触发默认的文本输入
                    textBox.KeyPress -= TextBox_KeyPress;

                    // 添加自定义的 KeyPress 事件处理程序
                    textBox.KeyPress += TextBox_KeyPress;
                }
            }
        }
        /// <summary>
        /// C跨，限制输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_C_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // 判断是否是你要限制的列
            if (DGV_C.CurrentCell.ColumnIndex == 3) // 假设是第一列
            {
                TextBox textBox = e.Control as TextBox;

                if (textBox != null)
                {
                    // 移除 KeyPress 事件处理程序，以免触发默认的文本输入
                    textBox.KeyPress -= TextBox_KeyPress;

                    // 添加自定义的 KeyPress 事件处理程序
                    textBox.KeyPress += TextBox_KeyPress;
                }
            }
        }
        /// <summary>
        /// 限制数字按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 允许数字和控制键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
