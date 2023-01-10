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

namespace FORMS_OF_REPOSITORIES
{
    /// <summary>
    /// 吊运指令管理
    /// 查询已经分配了的吊运指令
    /// </summary>
    public partial class FrmCraneOrderHisyManage : FormBase
    {
        DataTable dt = new DataTable();
        DataTable dt_oper = new DataTable();
        DataTable dt_ack = new DataTable();
        bool hasSetColumn = false;
        bool hasSetColumn_oper = false;
        bool hasSetColumn_ack = false;
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;
        Dictionary<string, string> dicCmdStatus = new Dictionary<string, string>();
        Dictionary<string, string> dicFlagDispat = new Dictionary<string, string>();
        Dictionary<string, string> dicDelFlag = new Dictionary<string, string>();
        Dictionary<string, string> dicOrderType = new Dictionary<string, string>();
        public FrmCraneOrderHisyManage()
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
        private void CraneOrderHisyManage_Load(object sender, EventArgs e)
        {
            try
            {
                //设置背景色
                this.panel1.BackColor = ColorSln.FormBgColor;
                this.panel2.BackColor = ColorSln.FormBgColor;
                //绑定下拉框
                BindCombox();
                //
                this.dateTimePicker1_recTime.Value = DateTime.Now.AddDays(-1);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = this.tabPage1;
                getCraneOrderData();
                dataGridView1.DataSource = dt;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 吊运历史双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count <= 0)
                {
                    return;
                }
                this.tabControl1.SelectedTab = this.tabPage2;
                string orderNo = this.dataGridView1.CurrentRow.Cells["ORDER_NO"].Value.ToString();
                string orderGroupNo = this.dataGridView1.CurrentRow.Cells["ORDER_GROUP_NO"].Value.ToString();
                string sqlText = @"SELECT UNIQUE_ID,ORDER_NO as ORDER_NO2,ORDER_GROUP_NO as ORDER_GROUP_NO2,CRANE_NO as CRANE_NO2,MAT_NO as MAT_NO2, STOCK_NO, X, Y,CMD_STATUS as CMD_STATUS2, DEL_FLAG, OPER_USERNAME, REC_TIME, OPER_EQUIPIP,ORDER_TYPE as ORDER_TYPE2, CRANE_SEQ, HG_NO,SEND_FLAG FROM UACS_CRANE_ORDER_OPER_Z32_Z33 A ";
                sqlText += "WHERE A.ORDER_NO = '{0}' and A.ORDER_GROUP_NO = '{1}'";
                sqlText = string.Format(sqlText, orderNo, orderGroupNo);
                dt_oper = new DataTable();
                hasSetColumn_oper = false;
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt_oper.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn_oper)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt_oper.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn_oper = true;
                        dt_oper.Rows.Add(dr);
                    }
                }
                foreach (DataRow dr in dt_oper.Rows)
                {
                    string cmdStatusValue = dr["CMD_STATUS2"].ToString();
                    if (dicCmdStatus.ContainsKey(cmdStatusValue))
                    {
                        dr["CMD_STATUS2"] = dicCmdStatus[cmdStatusValue];
                    }
                    string flagDispatValue = dr["FLAG_DISPAT"].ToString();
                    if (dicFlagDispat.ContainsKey(flagDispatValue))
                    {
                        dr["FLAG_DISPAT"] = dicFlagDispat[flagDispatValue];
                    }
                    string orderTypeValue = dr["ORDER_TYPE2"].ToString();
                    if (dicOrderType.ContainsKey(orderTypeValue))
                    {
                        dr["ORDER_TYPE2"] = dicOrderType[orderTypeValue];
                    }
                    string delFlagValue = dr["DEL_FLAG"].ToString();
                    if (dicDelFlag.ContainsKey(delFlagValue))
                    {
                        dr["DEL_FLAG"] = dicDelFlag[delFlagValue];
                    }
                }

                dataGridView2.DataSource = dt_oper;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 吊运实绩切换行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView2.Rows.Count <= 0)
                {
                    return;
                }
                string craneSeq = this.dataGridView2.CurrentRow.Cells["CRANE_SEQ"].Value.ToString();
                string hgNo = this.dataGridView2.CurrentRow.Cells["HG_NO"].Value.ToString();
                string cmdStatus = this.dataGridView2.CurrentRow.Cells["CMD_STATUS2"].Value.ToString();
                string matNo = this.dataGridView2.CurrentRow.Cells["MAT_NO2"].Value.ToString();
                string sqlText = @"SELECT ACK_FLAG,MESSAGE,REC_TIME FROM UACS_PLAN_CRANPLAN_OPERACK ";
                sqlText += "WHERE CRANE_SEQ = " + craneSeq + " and HG_NO = " + hgNo + " and CMD_STATUS = '" + cmdStatus + "' and MAT_NO = '" + matNo + "'";
                dt_ack.Clear();
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt_ack.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn_ack)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt_ack.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn_ack = true;
                        dt_ack.Rows.Add(dr);
                    }
                }

                dataGridView3.DataSource = dt_ack;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        #region 处理下拉框处理数据（忽略代码）
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion
        #endregion

        #region 方法
        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void BindCombox()
        {
            CraneOrderImpl craneOrderImpl = new CraneOrderImpl();
            //绑定跨号
            DataTable dtBayNo2 = craneOrderImpl.GetBayNo(true);
            bindCombox(this.comboBox_bayNo, dtBayNo2, true);
            //绑定吊运状态
            dicCmdStatus = craneOrderImpl.GetCodeValueDicByCodeId("CMD_STATUS", false);
            DataTable dtCmdStatus2 = craneOrderImpl.GetCodeValueByCodeId("CMD_STATUS", true);
            bindCombox(this.comboBox_cmdStatus, dtCmdStatus2, true);
            //绑定分配标记
            dicFlagDispat = craneOrderImpl.GetCodeValueDicByCodeId("FLAG_DISPAT", false);
            //绑定执行类型
            dicDelFlag = craneOrderImpl.GetCodeValueDicByCodeId("DEL_FLAG", false);
            //绑定指令类型
            dicOrderType = craneOrderImpl.GetCodeValueDicByCodeId("ORDER_TYPE", false);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void getCraneOrderData()
        {
            string matNo = this.textBox_matNo.Text.Trim();
            string bayNo = this.comboBox_bayNo.SelectedValue.ToString();
            string cmdStatus = this.comboBox_cmdStatus.SelectedValue.ToString();
            string recTime1 = this.dateTimePicker1_recTime.Value.ToString("yyyyMMdd000000");
            string recTime2 = this.dateTimePicker2_recTime.Value.ToString("yyyyMMdd235959");
            string sqlText = @"SELECT BAY_NO,MAT_NO,ORDER_NO,ORDER_GROUP_NO,ORDER_TYPE,ORDER_PRIORITY,FROM_STOCK_NO, TO_STOCK_NO, CMD_STATUS, FLAG_DISPAT, FLAG_ENABLE, CRANE_NO, REC_TIME, UPD_TIME FROM UACS_CRANE_ORDER_HISY_Z32_Z33 ";
            sqlText += "WHERE MAT_NO LIKE '%{0}%' and REC_TIME > '{1}' and REC_TIME < '{2}' ";
            sqlText = string.Format(sqlText, matNo, recTime1, recTime2);
            if (bayNo != "全部")
            {
                sqlText = string.Format("{0} and BAY_NO = '{1}'", sqlText, bayNo);
            }
            if (cmdStatus != "全部")
            {
                sqlText = string.Format("{0} and CMD_STATUS = '{1}'", sqlText, cmdStatus);
            }
            dt = new DataTable();
            hasSetColumn = false;
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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
            foreach (DataRow dr in dt.Rows)
            {
                string cmdStatusValue = dr["CMD_STATUS"].ToString();
                if (dicCmdStatus.ContainsKey(cmdStatusValue))
                {
                    dr["CMD_STATUS"] = dicCmdStatus[cmdStatusValue];
                }
                string flagDispatValue = dr["FLAG_DISPAT"].ToString();
                if (dicFlagDispat.ContainsKey(flagDispatValue))
                {
                    dr["FLAG_DISPAT"] = dicFlagDispat[flagDispatValue];
                }
                string orderTypeValue = dr["ORDER_TYPE"].ToString();
                if (dicOrderType.ContainsKey(orderTypeValue))
                {
                    dr["ORDER_TYPE"] = dicOrderType[orderTypeValue];
                }
            }
        }

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="control">下拉框控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="showLastIndex">是否显示最后一条（通常用于查询条件中全部）</param>
        private void bindCombox(ComboBox control,DataTable dt, bool showLastIndex)
        {
            control.DataSource = dt;
            control.DisplayMember = "TypeName";
            control.ValueMember = "TypeValue";
            if (showLastIndex)
            {
                control.SelectedIndex = dt.Rows.Count - 1;
            }
        }
        #endregion

    }
}
