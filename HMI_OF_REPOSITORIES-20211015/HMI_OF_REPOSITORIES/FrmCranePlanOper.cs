using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.TagService.Controls;
using System.Threading;
using Baosight.iSuperframe.Authorization.Interface;
using System.IO;
using System.Runtime.InteropServices;
using UACSUtility;


namespace FORMS_OF_REPOSITORIES
{
    /// <summary>
    /// 吊运实绩管理
    /// </summary>
    public partial class FrmCranePlanOper : FormBase
    {
        DataTable dt = new DataTable();
        bool hasSetColumn = false;
        DataTable dt_ack = new DataTable();
        bool hasSetColumn_ack = false;
        //static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;

        TagDataProvider tagCraneOper = new TagDataProvider();
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        DataTable dtCmdStatus = new DataTable();
        DataTable dtDelFlag = new DataTable();
        DataTable dtOrderType = new DataTable();
        static string cUserName = string.Empty; // userName


        /// <summary>
        /// RULE_PROPERITY if =1 means ZHK  ,2 means CPK , 3 means admin ,
        /// </summary>
        int RULE_PROPERITY = 0;
        static Baosight.iSuperframe.Common.IDBHelper DBHelper_Auth11 = null;
        Baosight.iSuperframe.Authorization.Interface.IAuthorization auth;

        public FrmCranePlanOper()
        {
            InitializeComponent();

            DBHelper_Auth11 = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("UACSDB0"); // scheme AUTH11 
            //DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");  //平台连接数据库的Text
      

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
        #region rule Methods
        void GetUserGroup()
        {
            try
            {
            
                //distribute rule properity
                foreach (string str in GetRules())
                {
                    if (str == "Administrator")
                    {
                        RULE_PROPERITY = 3;
                        break;
                    }

                    if (str == "CPK")
                    {
                        RULE_PROPERITY = 2;
                        break;
                    }

                    if (str == "ZHK")
                    {
                        RULE_PROPERITY = 1;
                        break;
                    }
                  //  MessageBox.Show(str+" and count= "+ GetRules().Count);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        /// <summary>
        /// get  rule name from database
        /// </summary>
        /// <returns>rules name</returns>
        private List<string> GetRules()
        {
            List<string> rules = new List<string>();
            try
            {
                cUserName = ((IAuthorization)FrameContext.Instance.GetPlugin<IAuthorization>()).GetUserName(); //get current user name 

                //string sql = @"SELECT USERID FROM T_RBAC_USER where USERNAME = '" + cUserName + "' ";
                string sqlRule = string.Format(@"SELECT distinct RULENAME FROM T_RBAC_RULE as rul ,
                                                 T_RBAC_USER as user , T_RBAC_USERINRULE as c
                                                 WHERE c.USERID = user.USERID and user.USERID = c.USERID 
                                                 AND rul.RULEID = c.RULEID AND user.USERNAME='{0}';", cUserName);

                using (IDataReader rdr = DBHelper_Auth11.ExecuteReader(sqlRule))
                {
                   
                    while (rdr.Read())
                    {
                        rules.Add(rdr.GetString(0));
                    }
                }

            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
            }

            return rules;
        }

      /*  static public object GetRuleItem(object ZHK_Item, object CPK_Item, object admin_Item)
        {
            object result = null;
            switch (RULE_PROPERITY)
            {

                case 1:
                    {
                        result = ZHK_Item;
                        break;
                    }
                case 2:
                    {
                        result = CPK_Item;
                        break;
                    }

                case 3:
                    {
                        result = admin_Item;
                        break;
                    }
                default: break;
            }
            return result;
        }*/
        #endregion 

        #region 事件
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CranePlanOper_Load(object sender, EventArgs e)
        {
            try
            {
                auth = FrameContext.Instance.GetPlugin<IAuthorization>() as IAuthorization;

                //获取用户组权限
                GetUserGroup();

                //设置背景色
                this.panel1.BackColor = ColorSln.FormBgColor;
                this.panel2.BackColor = ColorSln.FormBgColor;
                UACSUtility.ViewHelper.DataGridViewInit(dataGridView1);
                //绑定下拉框
                BindCombox();
                
                // 时间宽度调整
                this.dateTimePicker1_recTime.Value = DateTime.Now.AddHours(-1);
                this.dateTimePicker2_recTime.Value = DateTime.Now.AddHours(+3);
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
                //清空子表
                //this.dataGridView2.DataSource = new DataTable();
                GetCraneOrderOperData();
                BindGridView();

                //// 执行率计算
                //string recTime1 = this.dateTimePicker1_recTime.Value.ToString("yyyyMMddHHmmss");
                //string recTime2 = this.dateTimePicker2_recTime.Value.ToString("yyyyMMddHHmmss");
                //string craneNo = this.comboBox_craneNo.SelectedValue.ToString();
                //int nOrderType = 11;
                //int craneMode = 4;
                //string strOrderType = "";
                //CraneOperStatis statisAutoMode = new CraneOperStatis();

                //if (craneNo.IndexOf("4_") != 0)
                //{
                //    txt_OperStatistic.Text = "请选择'4_'开头的行车，进行统计！";
                //    return;
                //}

                //if (craneNo == "4_1" || craneNo == "4_4")
                //{
                //    nOrderType = 11;
                //    strOrderType = "收料";
                //}
                //else
                //{
                //    nOrderType = 21;
                //    strOrderType = "上料";
                //}

                //statisAutoMode = statisCraneOper(craneNo, recTime1, recTime2, nOrderType, craneMode);
                //// 第一行
                //txt_OperStatistic.Text = String.Format("行车{0}，模式{1}, {2}实绩统计（{3} -- {4}）：\r\n", craneNo, craneMode, strOrderType, recTime1, recTime2);
                //// 第二行
                //txt_OperStatistic.Text += String.Format("投用率{0:F0} ({1}卷/{2}卷), ",
                //    statisAutoMode.totalCoils != 0 ? ((float)statisAutoMode.modeTotalCoils / statisAutoMode.totalCoils)*100 : 0f,
                //    statisAutoMode.modeTotalCoils,
                //    statisAutoMode.totalCoils);                
                //txt_OperStatistic.Text += String.Format("成功率{0:F0} ({1}卷/{2}卷)，其中起卷成功率{3:F0}，落关成功率{4:F0}",
                //statisAutoMode.modeTotalCoils != 0 ? ((float)statisAutoMode.modeSuccCoils / statisAutoMode.modeTotalCoils) *100 : 0f,
                //statisAutoMode.modeSuccCoils,
                //statisAutoMode.modeTotalCoils,
                //statisAutoMode.modeTotalCoils != 0 ? ((float)statisAutoMode.modeUpCoils / statisAutoMode.modeTotalCoils) *100 : 0f,
                //statisAutoMode.modeTotalCoils != 0 ? ((float)statisAutoMode.modeDownCoils / statisAutoMode.modeTotalCoils) *100 : 0f);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// When comboBox_craneNo changed ,reflash  OrderOper datagGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_craneNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetCraneOrderOperData();
                BindGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 切换行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count <= 0)
                {
                    return;
                }
                string craneSeq = this.dataGridView1.CurrentRow.Cells["CRANE_SEQ"].Value.ToString();
                string hgNo = this.dataGridView1.CurrentRow.Cells["HG_NO"].Value.ToString();
                string cmdStatus = this.dataGridView1.CurrentRow.Cells["CMD_STATUS"].Value.ToString();
                string matNo = this.dataGridView1.CurrentRow.Cells["MAT_NO"].Value.ToString();
                // 
                string sqlText = @"SELECT MAT_NO,ACK_FLAG,MESSAGE,REC_TIME FROM UACS_PLAN_CRANPLAN_OPERACK ";
                sqlText += "WHERE CRANE_SEQ = {0} and HG_NO = {1} and CMD_STATUS = '{2}' and MAT_NO = '{3}' ORDER BY REC_TIME DESC";
                sqlText = string.Format(sqlText, craneSeq, hgNo, cmdStatus, matNo);
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
                //dataGridView2.DataSource = dt_ack;
                BindL3Ack(dt_ack);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 实绩补发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResend_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    string hasChecked = this.dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value.ToString();

                    if (hasChecked == "1")
                    {
                        string UNIQUE_ID = this.dataGridView1.Rows[i].Cells["UNIQUE_ID"].Value.ToString();

                        //新增吊运实绩
                        string sqlText = "INSERT INTO UACSAPP.UACS_CRANE_ORDER_OPER_Z32_Z33 ";
                        sqlText += "(ORDER_NO, ORDER_GROUP_NO, ORDER_TYPE, CRANE_NO, MAT_NO, STOCK_NO, X, Y, CMD_STATUS, DEL_FLAG, OPER_USERNAME, REC_TIME, OPER_EQUIPIP, PLAN_NO, CRANE_INST_CODE, CRANE_SEQ, HG_NO) ";
                        sqlText += "SELECT ORDER_NO, ORDER_GROUP_NO, ORDER_TYPE, CRANE_NO, MAT_NO, STOCK_NO, X, Y, CMD_STATUS, DEL_FLAG, OPER_USERNAME, REC_TIME, OPER_EQUIPIP, PLAN_NO, CRANE_INST_CODE, CRANE_SEQ, HG_NO FROM UACS_CRANE_ORDER_OPER_Z32_Z33 WHERE UNIQUE_ID = {0}";
                        string sql = string.Format(sqlText, UNIQUE_ID);
                        DBHelper.ExecuteNonQuery(sql);

                        //发送tag点补发吊运实绩
                        //平台配置
                        tagCraneOper.ServiceName = "iplature";
                        tagCraneOper.AutoRegist = true;
                        //添加tag点到数组
                        TagValues.Clear();
                        TagValues.Add("CRANE_OPER", null);
                        tagCraneOper.Attach(TagValues);
                        tagCraneOper.SetData("CRANE_OPER", UNIQUE_ID);
                        txt_L3TelAck.Text +=  "实绩补发成功，实绩流水号：" + UNIQUE_ID + "\r\n" ;
                    }
                }

                GetCraneOrderOperData();
                BindGridView();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 导出实绩到excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

                saveFileDialog1.ShowDialog();

                this.Invoke(new MethodInvoker(delegate ()
                {

                    Export2Excel(dataGridView1, saveFileDialog1.FileName);

                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        #region 处理列表中错误数据（忽略）
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// 切换画面到L3指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnL3OrderTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count <= 0 || dataGridView1.SelectedRows[0].Cells["MAT_NO"].Value == DBNull.Value)
                {
                    auth.OpenForm("01-L3吊运指令");
                }
                else
                {
                    string mat_No = dataGridView1.SelectedRows[0].Cells["MAT_NO"].Value.ToString();
                    auth.OpenForm("01-L3吊运指令", mat_No);
                }
            }
            catch (Exception ex)
            {
                throw;

            }


        }
        /// <summary>
        /// 切换画面到吊运指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrderTransfer_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.Rows.Count <= 0 || dataGridView1.SelectedRows[0].Cells["MAT_NO"].Value == DBNull.Value)
                {
                    auth.OpenForm("02-行车吊运指令");
                }
                else
                {
                    string mat_No = dataGridView1.SelectedRows[0].Cells["MAT_NO"].Value.ToString();
                    auth.OpenForm("02-行车吊运指令", mat_No);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        /// <summary>
        /// select all rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBox_SlctAll_CheckedChanged(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count <= 0)
            {
                chkBox_SlctAll.Checked = false;
                return;
            }

            if (chkBox_SlctAll.Checked)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value = 1;

                }
            }
           else 
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value = 0;

                }
            }


        }
        #endregion

        #region 导出到Excel
        /// <summary>
        /// 初始化一个工作薄
        /// </summary>
        /// <param name="path">工作薄的路径</param>
        /// 
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        public void Export2Excel(DataGridView gridView, string fileName)
        {
            System.Reflection.Missing miss = System.Reflection.Missing.Value; //创建EXCEL对象appExcel,Workbook对象,Worksheet对象,Range对象
            Microsoft.Office.Interop.Excel.Application appExcel;
            appExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbookData;
            Microsoft.Office.Interop.Excel.Worksheet worksheetData;
            Microsoft.Office.Interop.Excel.Range rangedata; //设置对象不可见
            appExcel.Visible = false;
            /* 在调用Excel应用程序，或创建Excel工作簿之前，记着加上下面的两行代码 * 这是因为Excel有一个Bug，如果你的操作系统的环境不是英文的，而Excel就会在执行下面的代码时，报异常。 */
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture; System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            workbookData = appExcel.Workbooks.Add(miss);
            worksheetData = (Microsoft.Office.Interop.Excel.Worksheet)workbookData.Worksheets.Add(miss, miss, miss, miss); //给工作表赋名称
            worksheetData.Name = "UACS"; //清零计数并开始计数

            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                worksheetData.Cells[1, i + 1] = gridView.Columns[i].HeaderText.ToString();
            } //先给Range对象一个范围为A2开始，Range对象可以给一个CELL的范围，也可以给例如A1到H10这样的范围 //因为第一行已经写了表头，所以所有数据都应该从A2开始
            rangedata = worksheetData.get_Range("A2", miss);
            Microsoft.Office.Interop.Excel.Range xlRang = null; //iRowCount为实际行数，最大行
            int iRowCount = gridView.RowCount;
            int iParstedRow = 0,
            iCurrSize = 0; //iEachSize为每次写行的数值，可以自己设置，每次写1000行和每次写2000行大家可以自己测试下效率
            int iEachSize = 1000; //iColumnAccount为实际列数，最大列数
            int iColumnAccount = gridView.ColumnCount; //在内存中声明一个iEachSize×iColumnAccount的数组，iEachSize是每次最大存　　储的行数，iColumnAccount就是存储的实际列数
            object[,] objVal = new object[iEachSize, iColumnAccount];
            try
            {

                iCurrSize = iEachSize;
                while (iParstedRow < iRowCount)
                {
                    if ((iRowCount - iParstedRow) < iEachSize)
                        iCurrSize = iRowCount - iParstedRow; //用FOR循环给数组赋值
                    for (int i = 0; i < iCurrSize; i++)
                    {
                        for (int j = 0; j < iColumnAccount; j++)
                            objVal[i, j] = gridView[j, i + iParstedRow].Value.ToString();

                        System.Windows.Forms.Application.DoEvents();
                    }
                    xlRang = worksheetData.get_Range("A" + ((int)(iParstedRow + 2)).ToString(), ((char)('A' + iColumnAccount - 1)).ToString() + ((int)(iParstedRow + iCurrSize + 1)).ToString()); // 调用Range的Value2属性，把内存中的值赋给Excel
                    xlRang.Value2 = objVal;
                    iParstedRow = iParstedRow + iCurrSize;
                } //保存工作表
                worksheetData.SaveAs(fileName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss); System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRang);
                xlRang = null;
                //关闭EXCEL进程，大家可以试下不用的话如果程序不关闭在进程里一直会有EXCEL.EXE这个进程并锁定你的EXCEL表格

                if (appExcel != null)
                {

                    int lpdwProcessId;
                    GetWindowThreadProcessId(new IntPtr(appExcel.Hwnd), out lpdwProcessId);
                    System.Diagnostics.Process.GetProcessById(lpdwProcessId).Kill();

                }

                MessageBox.Show("数据已经成功导出到：" + fileName, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region 方法
        void BindL3Ack(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count <= 0)
                {
                    return;
                }
                txt_L3TelAck.Text = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string matNO = string.Empty;
                    string ackFlag = string.Empty;
                    string msg = string.Empty;
                    string recTime = string.Empty;
                    DataRow dr = dt.Rows[i];

                    if (dr[0] != DBNull.Value)
                        matNO = dr[0].ToString();
                    if (dr[1] != DBNull.Value)
                        ackFlag = dr[1].ToString();
                    if (dr[2] != DBNull.Value)
                        msg = dr[2].ToString();
                    if (dr[3] != DBNull.Value)
                        recTime = dr[3].ToString();

                    txt_L3TelAck.Text += string.Format(@"-{4}-   {3} 收到钢卷 {0}  的  {1} 应答    详细信息:{2} ", matNO, ackFlag, msg, recTime, i + 1);
                    txt_L3TelAck.Text += "\n";
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void BindCombox()
        {
            CraneOrderImpl craneOrderImpl = new CraneOrderImpl();
            //绑定行车号
            //DataTable dtCraneNo = craneOrderImpl.GetCraneNo(false);
            //bindCombox(this.CRANE_NO, dtCraneNo);
            DataTable dtCraneNo2 = craneOrderImpl.GetCraneNo(true, RULE_PROPERITY);
            bindCombox(this.comboBox_craneNo, dtCraneNo2, true);

            //绑定吊运状态
            dtCmdStatus = craneOrderImpl.GetCodeValueByCodeId("CMD_STATUS", false);
            //bindCombox(this.CMD_STATUS, dtCmdStatus);
            //绑定执行类型
            dtDelFlag = craneOrderImpl.GetCodeValueByCodeId("DEL_FLAG", false);
            //bindCombox(this.DEL_FLAG, dtDelFlag);
            //绑定指令类型
            dtOrderType = craneOrderImpl.GetCodeValueByCodeId("ORDER_TYPE", false);
            //bindCombox(this.ORDER_TYPE, dtOrderType);

        }


        /// <summary>
        /// 查询数据
        /// </summary>
        private void GetCraneOrderOperData()
        {
            string matNo = this.textBox_matNo.Text.Trim();
            string stockNo = this.textBox_stockNo.Text.Trim();
            string recTime1 = this.dateTimePicker1_recTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string recTime2 = this.dateTimePicker2_recTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string craneNo = this.comboBox_craneNo.SelectedValue.ToString();
            string sqlText = string.Empty;

            if (craneNo == "System.Data.DataRowView")
                return;

            if (checkBox_ByRecTime.Checked)
            {
                // 按时间周期进行查询

                // 时间跨度
                sqlText = @"SELECT 0 AS CHECK_COLUMN,UNIQUE_ID,ORDER_NO,CRANE_MODE,ORDER_GROUP_NO, CRANE_NO, MAT_NO, STOCK_NO, X, Y, CMD_STATUS, DEL_FLAG, OPER_USERNAME, REC_TIME, OPER_EQUIPIP, ORDER_TYPE, CRANE_SEQ, HG_NO,SEND_FLAG FROM UACS_CRANE_ORDER_OPER_Z32_Z33 A 
                           WHERE A.REC_TIME > '{0}' and A.REC_TIME < '{1}' ";
                sqlText = string.Format(sqlText, recTime1, recTime2);

                if (matNo != "")
                {
                    sqlText = string.Format("{0} AND A.MAT_NO LIKE '%{1}%'", sqlText, matNo);
                }

                if (stockNo != "")
                {
                    sqlText = string.Format("{0} AND A.STOCK_NO LIKE '%{1}%'", sqlText, stockNo);
                }

                // 材料号和库位号均未指定，方能按行车号进行查询
                if (matNo.Length == 0 && stockNo.Length == 0)
                {
                    if (craneNo == "全部")
                        txt_L3TelAck.Text += "需选定行车号"+"\r\n";
                    else
                        sqlText = string.Format("{0} AND A.CRANE_NO LIKE '%{1}%'", sqlText, craneNo);
                }

                sqlText += " ORDER BY A.UNIQUE_ID ASC";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    dt.Clear();
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
            }
            else if (checkBox_ByUniqueID.Checked)
            {
                if (craneNo == "全部")
                {
                    txt_L3TelAck.Text += "需选定行车号"+"\r\n";
                    return;
                }

                // 查询行车最近N吊
                int nOperCnt = 8;
                sqlText = @"SELECT 0 AS CHECK_COLUMN,UNIQUE_ID,ORDER_NO,CRANE_MODE,ORDER_GROUP_NO, CRANE_NO, MAT_NO, STOCK_NO, X,
                Y, CMD_STATUS, DEL_FLAG, OPER_USERNAME, REC_TIME, OPER_EQUIPIP, ORDER_TYPE, CRANE_SEQ, HG_NO,SEND_FLAG
                    FROM UACS_CRANE_ORDER_OPER_Z32_Z33 A WHERE A.CRANE_NO LIKE '{0}'  ORDER BY A.UNIQUE_ID DESC  FETCH first {1} rows only";
                sqlText = string.Format(sqlText, craneNo, nOperCnt);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    dt.Clear();
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
            }
        }

        // 行车吊运统计的数据结构
        struct CraneOperStatis
        {
            public int nCraneMode;         // 指定模式
            public int totalCoils;         // 总卷数
            public int modeTotalCoils;     // 指定模式的总卷数
            public int modeSuccCoils;      // 指定模式的成功卷数
            public int modeUpCoils;        // 指定模式起卷的卷数
            public int modeDownCoils;      // 指定模式落关的卷数
            public string startTime;       // 统计起始时间
            public string endTime;         // 统计结束时间
        };

        /// <summary>
        /// 查询数据
        /// </summary>
        private CraneOperStatis statisCraneOper(string craneNo, string recTime1, string recTime2, int nOrderType, int nCraneMode)
        {
            CraneOperStatis operStatis = new CraneOperStatis();
            string sqlText = string.Empty;
            Dictionary<string, int> dictLiftUpCoilNo = new Dictionary<string, int>();
            Dictionary<string, int> dictLiftDownCoilNo = new Dictionary<string, int>();

            operStatis.startTime = recTime1;
            operStatis.endTime = recTime2;
            operStatis.nCraneMode = nCraneMode;
            operStatis.totalCoils = 0;
            operStatis.modeTotalCoils = 0;
            operStatis.modeSuccCoils = 0;
            operStatis.modeUpCoils = 0;
            operStatis.modeDownCoils = 0;

            // 吊运实绩的卷号
            sqlText = @"SELECT DISTINCT(MAT_NO) FROM UACS_CRANE_ORDER_OPER_Z32_Z33 
                           WHERE REC_TIME > '{0}' and REC_TIME < '{1}' and CRANE_NO = '{2}' and ORDER_TYPE = {3}";
            sqlText = string.Format(sqlText, recTime1, recTime2, craneNo, nOrderType);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    operStatis.totalCoils++;
                }
            }

            // 吊运实绩的卷号(指定模式)
            sqlText = @"SELECT DISTINCT(MAT_NO) FROM UACS_CRANE_ORDER_OPER_Z32_Z33 
                           WHERE REC_TIME > '{0}' and REC_TIME < '{1}' and CRANE_NO = '{2}' and ORDER_TYPE = {3} and CRANE_MODE = {4}";
            sqlText = string.Format(sqlText, recTime1, recTime2, craneNo, nOrderType, nCraneMode);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    operStatis.modeTotalCoils++;
                }
            }

            // 起卷实绩的卷号（指定模式）
            sqlText = @"SELECT DISTINCT(MAT_NO) FROM UACS_CRANE_ORDER_OPER_Z32_Z33 
                           WHERE REC_TIME > '{0}' and REC_TIME < '{1}' and CRANE_NO = '{2}' and ORDER_TYPE = {3} and CRANE_MODE = {4} and CMD_STATUS = '{5}'";
            sqlText = string.Format(sqlText, recTime1, recTime2, craneNo, nOrderType, nCraneMode, "S");
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    string coilNo = (string)rdr[0];
                    dictLiftUpCoilNo.Add(coilNo, 1);
                }
            }
            operStatis.modeUpCoils = dictLiftUpCoilNo.Count;

            // 落关实绩的卷号（指定模式）
            sqlText = @"SELECT DISTINCT(MAT_NO) FROM UACS_CRANE_ORDER_OPER_Z32_Z33 
                           WHERE REC_TIME > '{0}' and REC_TIME < '{1}' and CRANE_NO = '{2}' and ORDER_TYPE = {3} and CRANE_MODE = {4} and CMD_STATUS = '{5}'";
            sqlText = string.Format(sqlText, recTime1, recTime2, craneNo, nOrderType, nCraneMode, "E");
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    string coilNo = (string)rdr[0];
                    dictLiftDownCoilNo.Add(coilNo, 1);
                }
            }
            operStatis.modeDownCoils = dictLiftDownCoilNo.Count;

            // 查找该模式下成功执行的卷数
            foreach (String coilNo in dictLiftUpCoilNo.Keys)
            {
                if (dictLiftDownCoilNo.ContainsKey(coilNo))
                    operStatis.modeSuccCoils++;
            }

            return operStatis;
        }

        /// <summary>
        /// 绑定gridview数据
        /// </summary>
        private void BindGridView()
        {

            dataGridView1.DataSource = dt;

            //设置背景色
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["SEND_FLAG"].ToString() == "1")
                {
                    dataGridView1.Rows[i].Cells["SEND_FLAG"].Style.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["SEND_FLAG"].Style.BackColor = Color.Yellow;
                }
            }
            dataGridView1.Columns["SEND_FLAG"].DisplayIndex = dataGridView1.Columns.Count - 1;
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



        #endregion

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                return;
            }
            if (e.NewValue > 23)
            {
                chkBox_SlctAll.Visible = false;
            }
            else
                chkBox_SlctAll.Visible = true;
        }

        private void checkBox_ByUniqueID_CheckedChanged(object sender, EventArgs e)
        {
            // 两个查询条件互斥
            checkBox_ByRecTime.Checked = !checkBox_ByUniqueID.Checked;
        }

        private void checkBox_ByRecTime_CheckedChanged(object sender, EventArgs e)
        {
            // 两个查询条件互斥
            checkBox_ByUniqueID.Checked = !checkBox_ByRecTime.Checked;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

    }
}
