using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.TagService.Interface;
using Baosight.iSuperframe.Authorization.Interface;
using Baosight.iSuperframe.Authorization;
using Baosight.iSuperframe.Common;
using UACSUtility;
using CONTROLS_OF_REPOSITORIES;

namespace FORMS_OF_REPOSITORIES
{

    /// <summary>
    /// 计划指令管理
    /// 查询吊运指令信息
    /// </summary>
    public partial class FrmCranePlanManage : FormBase
    {
        //private static Baosight.iSuperframe.Common.IDBHelper ZJ1550 = null;
        private static Baosight.iSuperframe.Common.IDBHelper ZJ1550 = null;
        private static Baosight.iSuperframe.Common.IDBHelper UACSDB0 = null;
        //DataTable dt = new DataTable();
        DataTable dtOper = new DataTable();
        DataTable dtAck = new DataTable();
        bool hasSetColumn = false;
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        Thread thread;
        int userid = 0;
        string cUserName = null;
        private const string ZHK = "ZHK";
        private const string CPK = "CPK";
        bool threadExecute = false;
        private DataTable dt = new DataTable();
        private IDataReader rdr = null;
        Dictionary<string, string> dicOrderType;
        Dictionary<string, string> dicCmdStatus;
        Dictionary<string, string> dicFlagDel;


        public FrmCranePlanManage()
        {
            InitializeComponent();
            ZJ1550 = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");  //  软件数据库
            UACSDB0 = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("UACSDB0");//  平台数据库
        }

        #region 数据库连接
        //private static Baosight.iSuperframe.Common.IDBHelper zj1550 = null;

        //private static Baosight.iSuperframe.Common.IDBHelper ZJ1550
        //{
        //    get
        //    {
        //        if (zj1550 == null)
        //        {
        //            try
        //            {
        //                zj1550 = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");
        //            }
        //            catch (System.Exception e)
        //            {
        //                //throw e;
        //            }

        //        }
        //        return zj1550;
        //    }
        //}
        #endregion


        #region 事件
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CranePlanManage_Load(object sender, EventArgs e)
        {
            try
            {
                
                //设置背景色
                this.panel1.BackColor = ColorSln.FormBgColor;
                this.panel2.BackColor = ColorSln.FormBgColor;
                Jurisdiction();
                //dataGridView1.DataSource = dt;
                UACSUtility.ViewHelper.DataGridViewInit(dataGridView1);
                //绑定数据
                BindComboxData();

                BindArea();
                //BindArea();

                BindOrderTypes();
                //
                this.dateTimePicker1_recTime.Value = DateTime.Now.AddDays(-1);
                //
                tagDP.ServiceName = "iplature";
                tagDP.AutoRegist = true;
                TagValues.Clear();
                TagValues.Add("EV_ORDER_SET_TO_STOCK", null);
                TagValues.Add("EV_ORDER_DEL", null);
                TagValues.Add("EV_ORDER_FIRSTJOB", null);
                TagValues.Add("EV_ORDER_CHANGE_CRANE", null);
                tagDP.Attach(TagValues);
                //
                timer2.Start();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridView();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 生成吊运指令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMerge_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("确定执行指令删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res != DialogResult.OK)
                {
                    return;
                }
                int count = dataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string hasChecked = this.dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value.ToString();
                    if (hasChecked == "1")
                    {
                        string orderNo = this.dataGridView1.Rows[i].Cells["ORDER_NO"].Value.ToString();
                        //
                        tagDP.SetData("EV_ORDER_DEL", orderNo);
                    }
                }
                MessageBox.Show("删除成功");
                //重新查询并绑定数据
                timer1.Start();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 列表中按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                string orderNo = this.dataGridView1.Rows[e.RowIndex].Cells["ORDER_NO"].Value.ToString();
                string craneNo = this.dataGridView1.Rows[e.RowIndex].Cells["CRANE_NO"].Value.ToString();
                string bayNo = this.dataGridView1.Rows[e.RowIndex].Cells["BAY_NO"].Value.ToString();
                if (dataGridView1.Columns[e.ColumnIndex].Name == "TO_STOCK_NO")
                {
                    string coil_no = this.dataGridView1.Rows[e.RowIndex].Cells["MAT_NO"].Value.ToString();
                    SelectToStock form = new SelectToStock(bayNo);
                    DialogResult res = form.ShowDialog();
                    if (res == DialogResult.OK && form.result_dt.Rows.Count == 1)
                    {
                        DataRow dr = form.result_dt.Rows[0];
                        string stock_no = dr["STOCK_NO"].ToString();
                        DialogResult res2 = MessageBox.Show("确定将指令" + orderNo + "的卸下位置改成" + stock_no + "？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res2 == DialogResult.OK)
                        {
                            string tagValue = orderNo + "|" + stock_no;
                            tagDP.SetData("EV_ORDER_SET_TO_STOCK", tagValue);
                            this.dataGridView1.Rows[e.RowIndex].Cells["TO_STOCK_NO"].Value = stock_no;
                        }
                    }
                    timer1.Start();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "FIRST_JOB")
                {
                    int count999 = 0;
                    //准备数据
                    string sqlText = string.Format("SELECT COUNT(*) FROM UACS_CRANE_ORDER_Z32_Z33 WHERE CRANE_NO = '{0}' and ORDER_PRIORITY = 999", craneNo);
                    using (rdr = ZJ1550.ExecuteReader(sqlText))
                    {
                        if (rdr.Read())
                        {
                            count999 = int.Parse(rdr[0].ToString());
                        }
                    }
                    if (count999 >= 1)
                    {
                        MessageBox.Show(craneNo + "行车已经有一条指令提前了，无法再次执行FIRST JOB");
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("确定将指令" + orderNo + "提前？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                        {
                            tagDP.SetData("EV_ORDER_FIRSTJOB", orderNo);
                        }
                        timer1.Start();
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "CRANE_NO")
                {
                    SelectCraneNo form = new SelectCraneNo();
                    form.craneNo = craneNo;
                    form.bayNo = bayNo;
                    form.orderNo = orderNo;
                    DialogResult res = form.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        string returnCraneNo = form.returnCraneNo;
                        DialogResult res2 = MessageBox.Show("确定将指令" + orderNo + "改为" + returnCraneNo + "行车执行？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res2 == DialogResult.OK)
                        {
                            string tagValue = orderNo + "|" + returnCraneNo;
                            tagDP.SetData("EV_ORDER_CHANGE_CRANE", tagValue);
                            timer1.Start();
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        #region 处理列表中错误数据（忽略）
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// 跨号值切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBoxBayNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //BindArea();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 区域值切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBoxArea_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //BindOrderType();
                //BindArea();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 画面关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CranePlanManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                threadExecute = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改行车号触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                string orderNo = this.dataGridView1.Rows[e.RowIndex].Cells["ORDER_NO"].Value.ToString();
                if (dataGridView1.Columns[e.ColumnIndex].Name == "CRANE_NO")
                {
                    string crane_no = this.dataGridView1.Rows[e.RowIndex].Cells["CRANE_NO"].Value.ToString();

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 等待3秒查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // GetCranePlanData();
            BindGridView();
            timer1.Stop();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void BindComboxData()
        {
            CraneOrderImpl craneOrderImpl = new CraneOrderImpl();
            DataTable dtCraneNo = craneOrderImpl.GetCraneNo(true);
            bindCombox(this.cbBoxCraneNo, dtCraneNo, true);
            ////绑定指令类型
            dicOrderType = craneOrderImpl.GetCodeValueDicByCodeId("ORDER_TYPE", false);
            ////绑定吊运状态
            dicCmdStatus = craneOrderImpl.GetCodeValueDicByCodeId("CMD_STATUS", false);
            DataTable dtCmdStatus2 = craneOrderImpl.GetCodeValueByCodeId("CMD_STATUS", true);
            bindCombox(this.cbBoxCmdStatus, dtCmdStatus2, true);
            ////绑定删除标记
            dicFlagDel = craneOrderImpl.GetCodeValueDicByCodeId("FLAG_DEL", false);
            //绑定跨号
            //DataTable dtBayNo = craneOrderImpl.GetBayNo(true);
            //bindCombox(this.cbBoxBayNo, dtBayNo, true);
        }

        /// <summary>
        /// 绑定吊运事件
        /// </summary>
        private void BindOrderType()
        {
            if (this.cbBoxArea.SelectedValue == null)
            {
                return;
            }
            if (this.cbBoxBayNo.SelectedValue == null)
            {
                return;
            }
            string areaNo = this.cbBoxArea.SelectedValue.ToString();
            string bayNo = this.cbBoxBayNo.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            string sqlText = "";
            if (areaNo == "全部")
            {
                sqlText = "select DISTINCT ORDER_TYPE from UACS_CRANE_ORDER_Z32_Z33 where 1=1";
            }
            else if (areaNo.Contains("D") || areaNo.Contains("PA"))
            {
                //准备数据
                sqlText = "select DISTINCT A.ORDER_TYPE from UACS_CRANE_ORDER_Z32_Z33 A ";
                sqlText += "WHERE A.FROM_STOCK_NO IN (SELECT B.STOCK_NO FROM UACS_LINE_SADDLE_DEFINE B where B.UNIT_NO = '{0}') ";
                sqlText += "or A.TO_STOCK_NO IN (SELECT B.STOCK_NO FROM UACS_LINE_SADDLE_DEFINE B where B.UNIT_NO = '{0}')";
                sqlText = string.Format(sqlText, areaNo);
            }
            else
            {
                sqlText = "select DISTINCT A.ORDER_TYPE from UACS_CRANE_ORDER_Z32_Z33 A ";
                sqlText += "WHERE (substr(A.FROM_STOCK_NO,1,4) IN (SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE VEC_PASSAGE_NO = '{0}') ";
                sqlText += "or substr(A.TO_STOCK_NO,1,4) IN (SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE VEC_PASSAGE_NO = '{0}')) ";
                sqlText = string.Format(sqlText, areaNo);
            }
            if (bayNo != "全部")
            {
                sqlText += " AND BAY_NO = '{0}'";
                sqlText = string.Format(sqlText, bayNo);
            }
            using (rdr = ZJ1550.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeValue"] = rdr["ORDER_TYPE"];
                    //dr["TypeName"] = rdr["ORDER_TYPE"];
                    dr["TypeName"] = GetCodeName(rdr["ORDER_TYPE"].ToString());
                    dt.Rows.Add(dr);
                }
            }

            dt.Rows.Add("全部", "全部");
            //绑定列表下拉框数据

            bindCombox(combox_craneInstCode, dt, true);
        }


        private void BindOrderTypes()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TypeValue");
                dt.Columns.Add("TypeName");

                string sql = @"SELECT CODE_VALUE_ID,CODE_VALUE_NAME FROM UACS_CODE_VALUE WHERE CODE_ID = 'ORDER_TYPE'";
                using (rdr = ZJ1550.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr["TypeValue"] = rdr["CODE_VALUE_ID"];
                        //dr["TypeName"] = rdr["ORDER_TYPE"];
                        dr["TypeName"] = rdr["CODE_VALUE_NAME"];
                        dt.Rows.Add(dr);
                    }
                }

                dt.Rows.Add("全部", "全部");
                //绑定列表下拉框数据

                bindCombox(combox_craneInstCode, dt, true);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 获取指令类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetCodeName(string id)
        {
            string CodeName = null;
            try
            {
                string sql = @"SELECT CODE_VALUE_NAME FROM UACS_CODE_VALUE WHERE CODE_VALUE_ID = '" + id + "' ";
                using (IDataReader rdr = ZJ1550.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        CodeName = rdr["CODE_VALUE_NAME"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return CodeName;
        }

        /// <summary>
        /// 绑定区域
        /// </summary>
        private void BindArea()
        {
            //if (this.cbBoxBayNo.SelectedValue == null)
            //{
            //    return;
            //}
            //string bayNo = this.cbBoxBayNo.SelectedValue.ToString();

            string bayNo = null;

            bool Z32 = this.checkBox_Z32.Checked;
            bool Z33 = this.checkBox_Z33.Checked;
            bool Z51 = this.checkBox_Z51.Checked;
            bool Z52 = this.checkBox_Z52.Checked;
            bool Z53 = this.checkBox_Z53.Checked;

            // 轧后库
            if (Z32 == true && Z33 == false && Z51 == false && Z52 == false && Z53 == false)
            {
                bayNo = "Z32-1";
            }
            if (Z32 == false && Z33 == true && Z51 == false && Z52 == false && Z53 == false)
            {
                bayNo = "Z33-1";
            }
            if (Z32 == true && Z33 == true && Z51 == false && Z52 == false && Z53 == false)
            {
                bayNo = "Z32-1|Z33-1";
            }
            // 成品库
            if (Z32 == false && Z33 == false && Z51 == true && Z52 == true && Z53 == true)
            {
                bayNo = "Z51-1|Z52-2|Z53-3";
            }
            if (Z32 == false && Z33 == false && Z51 == true && Z52 == false && Z53 == false)
            {
                bayNo = "Z51-1";
            }
            if (Z32 == false && Z33 == false && Z51 == false && Z52 == true && Z53 == false)
            {
                bayNo = "Z52-2";
            }
            if (Z32 == false && Z33 == false && Z51 == false && Z52 == false && Z53 == true)
            {
                bayNo = "Z53-3";
            }
            if (Z32 == false && Z33 == false && Z51 == true && Z52 == true && Z53 == false)
            {
                bayNo = "Z51-1|Z52-2";
            }
            if (Z32 == false && Z33 == false && Z51 == true && Z52 == false && Z53 == true)
            {
                bayNo = "Z51-1|Z53-3";
            }
            if (Z32 == false && Z33 == false && Z51 == false && Z52 == true && Z53 == true)
            {
                bayNo = "Z51-2|Z53-3";
            }
            // 全部
            if (Z32 == true && Z33 == true && Z51 == true && Z52 == true && Z53 == true)
            {
                bayNo = "Z32-1|Z33-1|Z51-1|Z52-2|Z53-3";
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //查询所有鞍座的库区号
            string sqlText = string.Format("SELECT YARD_NO as TypeValue,YARD_NO as TypeName FROM UACS_YARDMAP_YARD_DEFINE WHERE YARD_NO like 'D%' OR YARD_NO like 'PA%'");
            using (rdr = ZJ1550.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeValue"] = rdr["TypeValue"];
                    dr["TypeName"] = rdr["TypeName"];
                    dt.Rows.Add(dr);
                }
            }
            if (bayNo != "全部")
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    //根据库区号查跨号
                    string sqlText1 = "select distinct D.BAY_NO from UACS_LINE_SADDLE_DEFINE A, UACS_YARDMAP_SADDLE_DEFINE B, ";
                    sqlText1 += "UACS_YARDMAP_ROWCOL_DEFINE C, UACS_YARDMAP_AREA_DEFINE D ";
                    sqlText1 += "WHERE A.STOCK_NO = B.SADDLE_NO AND B.COL_ROW_NO = C.COL_ROW_NO AND C.AREA_NO = D.AREA_NO ";
                    sqlText1 += "AND A.UNIT_NO = '{0}'";
                    sqlText1 = string.Format(sqlText1, dt.Rows[i]["TypeValue"].ToString());
                    string _bayNo = "";
                    bool isOk = false;
                    using (rdr = ZJ1550.ExecuteReader(sqlText1))
                    {
                        while (rdr.Read())
                        {
                            _bayNo = rdr["BAY_NO"].ToString();
                            if (bayNo.Contains(_bayNo))
                            {
                                isOk = true;
                                break;
                            }
                        }
                    }
                    if (!isOk)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }
            int unitRowCount = dt.Rows.Count;
            //车道
            //准备数据
            sqlText = string.Format("SELECT VEC_PASSAGE_NO as TypeValue,VEC_PASSAGE_NO as TypeName FROM UACS_YARDMAP_VEC_PASSAGE_DEFINE");
            using (rdr = ZJ1550.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeValue"] = rdr["TypeValue"];
                    dr["TypeName"] = rdr["TypeName"];
                    dt.Rows.Add(dr);
                }
            }
            if (bayNo != "全部")
            {
                for (int i = dt.Rows.Count - 1; i >= unitRowCount; i--)
                {
                    string sqlText1 = "select B.BAY_NO from UACS_YARDMAP_VEC_PASSAGE_DEFINE A, UACS_YARDMAP_AREA_DEFINE B ";
                    sqlText1 += "WHERE A.AREA_NO = B.AREA_NO AND A.VEC_PASSAGE_NO = '{0}'";
                    sqlText1 = string.Format(sqlText1, dt.Rows[i]["TypeValue"].ToString());
                    string _bayNo = "";
                    bool isOk = false;
                    using (rdr = ZJ1550.ExecuteReader(sqlText1))
                    {
                        while (rdr.Read())
                        {
                            _bayNo = rdr["BAY_NO"].ToString();
                            if (bayNo.Contains(_bayNo))
                            {
                                isOk = true;
                                break;
                            }
                        }
                    }
                    if (!isOk)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }
            dt.Rows.Add("全部", "全部");
            //绑定列表下拉框数据
            bindCombox(cbBoxArea, dt, true);
        }

        /// <summary>
        /// 获取计划信息
        /// </summary>
        private void GetCranePlanData(bool ShowTime = false)
        {
            string craneInstCode = this.combox_craneInstCode.SelectedValue.ToString();  //指令类型
            //string cmdStatus = this.cbBoxCmdStatus.SelectedValue.ToString();
            string matNo = this.textbox_matNo.Text;    // 材料号
            string recTime1 = this.dateTimePicker1_recTime.Value.ToString("yyyy-MM-dd HH:mm:ss");  // 开始时间
            string recTime2 = this.dateTimePicker2_recTime.Value.ToString("yyyy-MM-dd HH:mm:ss");  // 结束时间
            //string bayNo = this.cbBoxBayNo.SelectedValue.ToString();                        
            string areaNo = this.cbBoxArea.SelectedValue.ToString();     // 区域
            string craneNo = this.cbBoxCraneNo.SelectedValue.ToString(); // 行车号
            bool Z32 = this.checkBox_Z32.Checked;
            bool Z33 = this.checkBox_Z33.Checked;
            bool Z51 = this.checkBox_Z51.Checked;
            bool Z52 = this.checkBox_Z52.Checked;
            bool Z53 = this.checkBox_Z53.Checked;

            string sqlText = @"SELECT 0 as CHECK_COLUMN,'FIRST JOB' AS FIRST_JOB,A.ORDER_NO,A.PLAN_NO,A.ORDER_GROUP_NO,A.CRANE_NO,";
            sqlText += "A.BAY_NO,A.MAT_NO,A.ORDER_TYPE,A.ORDER_PRIORITY,A.FROM_STOCK_NO,A.TO_STOCK_NO,A.CMD_STATUS,A.FLAG_DISPAT,";
            sqlText += "A.REC_TIME,A.UPD_TIME,A.DEL_TIME,A.FLAG_DEL,A.DISPAT_TIME,A.DISPAT_ACK_TIME,";
            sqlText += "B.SEQ AS SEQ1,C.SEQ AS SEQ2,D.SEQ AS SEQ3,E.SEQ AS SEQ4,F.SEQ AS SEQ5  ";
            sqlText += "FROM UACS_CRANE_ORDER_Z32_Z33 A ";
            sqlText += "LEFT JOIN T_MM_DISPAT_BAY_Z32 B ON A.ORDER_NO = B.ORDER_NO ";
            sqlText += "LEFT JOIN T_MM_DISPAT_BAY_Z33 C ON A.ORDER_NO = C.ORDER_NO ";
            sqlText += "LEFT JOIN T_MM_DISPAT_BAY_Z51 D ON A.ORDER_NO = D.ORDER_NO ";
            sqlText += "LEFT JOIN T_MM_DISPAT_BAY_Z52 E ON A.ORDER_NO = E.ORDER_NO ";
            sqlText += "LEFT JOIN T_MM_DISPAT_BAY_Z53 F ON A.ORDER_NO = F.ORDER_NO ";

            //sqlText += "WHERE  A.REC_TIME > '" + recTime1 + "' and A.REC_TIME < '" + recTime2 + "' AND A.FLAG_ENABLE = '1' ";
            //sqlText += "WHERE A.FLAG_ENABLE = '1' ";

            sqlText += " WHERE A.MAT_NO LIKE '%" + matNo + "%' ";

            if (ShowTime != false)
            {
                sqlText += "and A.REC_TIME > '" + recTime1 + "' and A.REC_TIME < '" + recTime2 + "' ";
            }

           
            // 1.行车号
            if (craneNo != "全部")
            {
                sqlText += " and A.CRANE_NO = '" + craneNo + "' ";
            }
            // 2.跨别
            // 轧后库
            if (Z32 == false && Z33 == false && Z51 == false && Z52 == false && Z53 == false)
            {
                return;
            }
            else if (Z32 == true && Z33 == false && Z51 == false && Z52 == false && Z53 == false)
            {
                sqlText += " and A.BAY_NO = 'Z32-1' ";
            }
            else if (Z32 == false && Z33 == true && Z51 == false && Z52 == false && Z53 == false)
            {
                sqlText += " and A.BAY_NO = 'Z33-1' ";
            }
            else if (Z32 == true && Z33 == true && Z51 == false && Z52 == false && Z53 == false)
            {
                sqlText += " and A.BAY_NO in ('Z32-1','Z33-1') ";
            }
            // 成品库
            if (Z32 == false && Z33 == false && Z51 == true && Z52 == true && Z53 == true)
            {
                sqlText += " and A.BAY_NO in ('Z51-1','Z52-2','Z53-3') "; 
            }
            if (Z32 == false && Z33 == false && Z51 == true && Z52 == false && Z53 == false)
            {
                sqlText += " and A.BAY_NO = 'Z51-1' ";
            }
            if (Z32 == false && Z33 == false && Z51 == false && Z52 == true && Z53 == false)
            {
                sqlText += " and A.BAY_NO = 'Z51-2' ";
            }
            if (Z32 == false && Z33 == false && Z51 == false && Z52 == false && Z53 == true)
            {
                sqlText += " and A.BAY_NO = 'Z51-3' ";
            }
            if (Z32 == false && Z33 == false && Z51 == true && Z52 == true && Z53 == false)
            {
                sqlText += " and A.BAY_NO in ('Z51-1','Z52-2') "; 
            }
            if (Z32 == false && Z33 == false && Z51 == true && Z52 == false && Z53 == true)
            {
                sqlText += " and A.BAY_NO in ('Z51-1','Z53-3') "; 
            }
            if (Z32 == false && Z33 == false && Z51 == false && Z52 == true && Z53 == true)
            {
                sqlText += " and A.BAY_NO in ('Z52-2','Z53-3') "; 
            }
            // 全部
            if (Z32 == true && Z33 == true && Z51 == true && Z52 == true && Z53 == true)
            {
                sqlText += " and A.BAY_NO in ('Z32-1','Z33-1','Z51-1','Z52-2','Z53-3') "; 
            }
            #region 旧代码
            //if (cmdStatus != "全部")
            //{
            //    sqlText += " and A.CMD_STATUS = '" + cmdStatus + "' ";
            //}
            //if (bayNo != "全部")
            //{
            //    sqlText += " and A.BAY_NO = '" + bayNo + "' ";
            //} 
            #endregion

            if (areaNo == "全部")
            {
                if (craneInstCode != "全部")
                {
                    sqlText += "and A.ORDER_TYPE = '" + craneInstCode + "' ";
                }
            }
            else if (areaNo.Contains("D") || areaNo.Contains("PA"))
            {
                if (craneInstCode == "全部")
                {
                    sqlText += "AND (A.FROM_STOCK_NO IN (SELECT G.STOCK_NO FROM UACS_LINE_SADDLE_DEFINE G where G.UNIT_NO = '" + areaNo + "') ";
                    sqlText += "or A.TO_STOCK_NO IN (SELECT G.STOCK_NO FROM UACS_LINE_SADDLE_DEFINE G where G.UNIT_NO = '" + areaNo + "')) ";
                }
                else if (craneInstCode == "11" || craneInstCode == "12" || craneInstCode == "14")
                {
                    sqlText += "AND A.FROM_STOCK_NO IN (SELECT G.STOCK_NO FROM UACS_LINE_SADDLE_DEFINE G where G.UNIT_NO = '" + areaNo + "') ";
                    sqlText += "and A.ORDER_TYPE = '" + craneInstCode + "' ";
                }
                else if (craneInstCode == "21" || craneInstCode == "23")
                {
                    sqlText += "AND A.TO_STOCK_NO IN (SELECT G.STOCK_NO FROM UACS_LINE_SADDLE_DEFINE G where G.UNIT_NO = '" + areaNo + "') ";
                    sqlText += "and A.ORDER_TYPE = '" + craneInstCode + "' ";
                }
            }
            else
            {
                if (craneInstCode == "全部")
                {
                    sqlText += "AND (substr(A.FROM_STOCK_NO,1,4) = (SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE VEC_PASSAGE_NO = '" + areaNo + "') ";
                    sqlText += "or substr(A.TO_STOCK_NO,1,4) = (SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE VEC_PASSAGE_NO = '" + areaNo + "') ";
                }
                else if (craneInstCode == "13")
                {
                    sqlText += "AND substr(A.FROM_STOCK_NO,1,4) IN (SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE VEC_PASSAGE_NO = '" + areaNo + "') ";
                    sqlText += "and A.ORDER_TYPE = '" + craneInstCode + "' ";
                }
                else if (craneInstCode == "22" || craneInstCode == "24" || craneInstCode == "25")
                {
                    sqlText += "AND substr(A.TO_STOCK_NO,1,4) IN (SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE VEC_PASSAGE_NO = '" + areaNo + "') ";
                    sqlText += "and A.ORDER_TYPE = '" + craneInstCode + "' ";
                }
            }
            //sqlText += " order by CRANE_NO,SEQ1,SEQ2,SEQ3,SEQ4,SEQ5 ";
            sqlText += " order by A.ORDER_PRIORITY,A.ORDER_TYPE,CRANE_NO,SEQ1,SEQ2,SEQ3,SEQ4,SEQ5 ";
            dt = new DataTable();
            hasSetColumn = false;
            using (rdr = ZJ1550.ExecuteReader(sqlText))
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
                        dr[i] = rdr[i].ToString();
                    }
                    if (!hasSetColumn)
                    {
                        dt.Columns.Add("SEQ");
                    }
                    hasSetColumn = true;
                    dt.Rows.Add(dr);
                }
                rdr.Close();
                //dt.Columns.Add("SEQ");
            }
            foreach (DataRow dr in dt.Rows)
            {
                string status = "未确认";
                //如果分配标记是下发正应答，则表示确认，否则都为未确认
                if (dr["FLAG_DISPAT"].ToString() == "11")
                {
                    status = "确认";
                }
                dr["FLAG_DISPAT"] = status;

                //将5张表里读出来的SEQ汇总到SEQ字段
                if (dr["BAY_NO"].ToString().Contains("Z32"))
                {
                    dr["SEQ"] = dr["SEQ1"];
                }
                else if (dr["BAY_NO"].ToString().Contains("Z33"))
                {
                    dr["SEQ"] = dr["SEQ2"];
                }
                else if (dr["BAY_NO"].ToString().Contains("Z51"))
                {
                    dr["SEQ"] = dr["SEQ3"];
                }
                else if (dr["BAY_NO"].ToString().Contains("Z52"))
                {
                    dr["SEQ"] = dr["SEQ4"];
                }
                else if (dr["BAY_NO"].ToString().Contains("Z53"))
                {
                    dr["SEQ"] = dr["SEQ5"];
                }
                string cmdStatusValue = dr["CMD_STATUS"].ToString();
                if (dicCmdStatus.ContainsKey(cmdStatusValue))
                {
                    dr["CMD_STATUS"] = dicCmdStatus[cmdStatusValue];
                }
                string flagDelValue = dr["FLAG_DEL"].ToString();
                if (dicFlagDel.ContainsKey(flagDelValue))
                {
                    dr["FLAG_DEL"] = dicFlagDel[flagDelValue];
                }
                string orderTypeValue = dr["ORDER_TYPE"].ToString();
                if (dicOrderType.ContainsKey(orderTypeValue))
                {
                    dr["ORDER_TYPE"] = dicOrderType[orderTypeValue];
                }
            }
        }


        /// <summary>
        /// 绑定gridview数据
        /// </summary>
        private void BindGridView(bool band = false)
        {
            int currentRowIndex = 0;
            int currentRowCount = this.dataGridView1.Rows.Count;
            if (currentRowCount > 0)
            {
                for (int i = 0; i < currentRowCount; i++)
                {
                    if (this.dataGridView1.Rows[i].Cells[0].Selected == true)
                    {
                        currentRowIndex = i;
                        break;
                    }
                }
            }
            if (band != false)
            {
                GetCranePlanData(true);
            }
            else
                GetCranePlanData();
            dataGridView1.DataSource = dt;

            //设置背景色
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["FLAG_DISPAT"].ToString() == "未确认")
                {
                    dataGridView1.Rows[i].Cells["FLAG_DISPAT"].Style.BackColor = Color.Yellow;
                }
                else if (dt.Rows[i]["FLAG_DISPAT"].ToString() == "确认")
                {
                    dataGridView1.Rows[i].Cells["FLAG_DISPAT"].Style.BackColor = Color.Green;
                }
                if (dt.Rows[i]["CMD_STATUS"].ToString() == "R")
                {
                    dataGridView1.Rows[i].Cells["CMD_STATUS"].Style.BackColor = Color.LightGreen;
                }
                else if (dt.Rows[i]["CMD_STATUS"].ToString() == "S")
                {
                    dataGridView1.Rows[i].Cells["CMD_STATUS"].Style.BackColor = Color.SkyBlue;
                }


            }

            if (this.dataGridView1.Rows.Count >= currentRowIndex)
            {
                if (this.dataGridView1.Rows.Count > 0)
                {
                    this.dataGridView1.Rows[0].Cells[0].Selected = false;
                    this.dataGridView1.Rows[currentRowIndex].Cells[0].Selected = true;
                }

            }
        }

        public void MonitorCranePlan()
        {
            while (threadExecute)
            {
                try
                {
                    bool autoReflesh = this.ckBoxAutoReflesh.Checked;
                    if (autoReflesh)
                    {
                        System.GC.Collect();
                        //GetCranePlanData();
                        //ShowData(dataGridView1);
                        BindGridView();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="control">下拉框控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="showLastIndex">是否显示最后一条（通常用于查询条件中全部）</param>
        private void bindCombox(ComboBox control, DataTable dt, bool showLastIndex)
        {
            control.DataSource = dt;
            control.DisplayMember = "TypeName";
            control.ValueMember = "TypeValue";
            if (showLastIndex)
            {
                control.SelectedIndex = dt.Rows.Count - 1;
            }
        }

        /// <summary>
        /// 绑定下拉框(列表)
        /// </summary>
        /// <param name="control">下拉框控件</param>
        /// <param name="dt">数据源</param>
        private void bindCombox(DataGridViewComboBoxColumn control, DataTable dt)
        {
            control.DataSource = dt;
            control.DisplayMember = "TypeName";
            control.ValueMember = "TypeValue";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bool autoReflesh = this.ckBoxAutoReflesh.Checked;
            if (autoReflesh)
            {
                System.GC.Collect();

                //ShowData(dataGridView1);
                BindGridView();
            }
        }
        #endregion

        private void combox_craneInstCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            string name = this.combox_craneInstCode.Text.Trim();  //指令类型
            if (name.Contains("机组"))
            {
                cbBoxArea.Enabled = true;
            }
            else
            {
                cbBoxArea.Enabled = false;
            }
        }

        #region 权限管理
        /// <summary>
        /// 权限管理
        /// </summary>
        private void Jurisdiction()
        {
            try
            {
                GetUserID();
                //GetListRuleID(userid);

                foreach (var list in  GetListRuleID(userid))
                {
                    if (list == GetRuleID(ZHK))
                    {
                        //checkBox_Z51.BackColor = Color.Red;
                        //checkBox_Z51.ForeColor = Color.Red;
                        //checkBox_Z52.ForeColor = Color.LightGray;
                        //checkBox_Z53.ForeColor = Color.LightGray;

                        checkBox_Z32.Checked = true;
                        checkBox_Z33.Checked = true;
                        checkBox_Z51.Checked = false;
                        checkBox_Z52.Checked = false;
                        checkBox_Z53.Checked = false;

                        checkBox_Z51.Visible = false;
                        checkBox_Z52.Visible = false;
                        checkBox_Z53.Visible = false;
                        //checkBox_Z51.Enabled = false;   
                        //checkBox_Z52.Enabled = false;                  
                        //checkBox_Z53.Enabled = false;
                        
                    }
                    if (list == GetRuleID(CPK))
                    {
                        //checkBox_Z32.ForeColor = Color.LightGray;
                        //checkBox_Z33.ForeColor = Color.LightGray;

                        checkBox_Z32.Checked = false;
                        checkBox_Z33.Checked = false;
                        checkBox_Z51.Checked = true;
                        checkBox_Z52.Checked = true;
                        checkBox_Z53.Checked = true;

                        checkBox_Z32.Visible = false;
                        checkBox_Z33.Visible = false;
                       
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "权限管理");
            }
        }

        /// <summary>
        /// 获取登录用户名所有的角色
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        private List<int> GetListRuleID(int userid)
        {
            List<int> listRuleId = new List<int>();
            try
            {
                string sql = @"SELECT RULEID FROM T_RBAC_USERINRULE WHERE USERID = '" + userid + "' ";
                using (IDataReader rdr = UACSDB0.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        listRuleId.Add( Convert.ToInt32(rdr["RULEID"]));
                    }
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message + "所有角色");
            }
            return listRuleId;
        }

        /// <summary>
        /// 获取制定角色id
        /// </summary>
        private int GetRuleID(string userName)
        {
            int ruleId = 0;
            try
            {
               
                string sql = @"SELECT RULEID FROM T_RBAC_RULE WHERE RULENAME = '" + userName + "'";
                using (IDataReader rdr = UACSDB0.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        ruleId = Convert.ToInt32(rdr["RULEID"]);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "角色");
            }
            return ruleId;
        }

        /// <summary>
        /// 获取登录用户名id
        /// </summary>
        /// <returns></returns>
        private void GetUserID()
        {
            try
            {
                cUserName = ((IAuthorization)FrameContext.Instance.GetPlugin<IAuthorization>()).GetUserName();      //操作人

                string sql = @"SELECT USERID FROM T_RBAC_USER where USERNAME = '" + cUserName + "' ";
                using (IDataReader rdr = UACSDB0.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        userid = Convert.ToInt32(rdr["USERID"]);
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "用户名");
            }
        }
        #endregion

        private void dateTimePicker1_recTime_ValueChanged(object sender, EventArgs e)
        {
            //System.Timers.Timer t = new System.Timers.Timer(2000);//实例化Timer类，设置时间间隔
            //t.Elapsed += new System.Timers.ElapsedEventHandler(Method2);//到达时间的时候执行事件
            //t.AutoReset = false;//设置是执行一次（false）还是一直执行(true)
            //t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件
            BindGridView(true);
        }

        private void dateTimePicker2_recTime_ValueChanged(object sender, EventArgs e)
        {
            //System.Timers.Timer t = new System.Timers.Timer(2000);//实例化Timer类，设置时间间隔
            //t.Elapsed += new System.Timers.ElapsedEventHandler(Method2);//到达时间的时候执行事件
            //t.AutoReset = false;//设置是执行一次（false）还是一直执行(true)
            //t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件
            BindGridView(true);
        }
        void Method2(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                BindGridView(true);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

    }
}