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
using MODEL_OF_REPOSITORIES;

namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmL3MsgManage : FormBase
    {
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper2 = null;
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        // 电文解析类对象
        MsgParser parser = new MsgParser("MsgConfig.xml");
        // 电文查询结果
        DataTable queryDataTable;
        // 电文内容解析结果
        DataTable msgDataTable;
        // 选定的电文
        MsgData selectMsgData = null;
        enum QUERY_TYPE
        {
            SEND,
            RECV
        }

        public FrmL3MsgManage()
        {
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("UACSDB0");//平台连接数据库的Text
            DBHelper2 = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
        }

        #region 事件
        private void L3MsgManage_Load(object sender, EventArgs e)
        {
            try
            {
                this.dateTimePicker_RStartDate.Value = DateTime.Now.AddDays(-1);
                this.dateTimePicker_RStartDate_S.Value = DateTime.Now.AddDays(-1);

                tagDP.ServiceName = "iplature";
                tagDP.AutoRegist = true;
                TagValues.Clear();
                TagValues.Add("L3MSG_RESEND", null);
                tagDP.Attach(TagValues);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRecvQuery_Click(object sender, EventArgs e)
        {
            try
            {
                // 准备查询结果表
                MsgQuery2DataGridView(dataGridView1, QUERY_TYPE.RECV);

                // 查询接收表
                string sqlStr = string.Format("SELECT * FROM T_BM_MSG_IN_LOG");
                sqlStr = String.Format("{0} where CLOCK > '{1}{2}' and CLOCK < '{3}{4}' and msgid like 'KDEU%' ",
                    sqlStr,
                    dateTimePicker_RStartDate.Value.ToString("yyyyMMdd"),
                    dateTimePicker_RStartTime.Value.ToString("HHmmss"),
                    dateTimePicker_REndDate.Value.ToString("yyyyMMdd"),
                    dateTimePicker_REndTime.Value.ToString("HHmmss"));
                if (textBox1.Text.Length != 0)
                {
                    sqlStr = String.Format("{0} and msgid = '{1}'",
                        sqlStr,
                        textBox1.Text);
                }
                sqlStr = String.Format("{0} {1}",
                    sqlStr,
                    "ORDER BY CLOCK desc");
                // 筛选字段
                string strFliter = "";
                if (textBox2.Text.Length != 0)
                {
                    strFliter = textBox2.Text;
                }

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStr))
                {
                    while (rdr.Read())
                    {
                        //画面中新增一条记录
                        DataRow row = queryDataTable.NewRow();
                        bool bExcluded = false;

                        row["电文内容"] = rdr["data"];
                        if (strFliter.Length != 0)
                        {
                            if (((String)row["电文内容"]).IndexOf(strFliter) == -1)
                                bExcluded = true;
                        }
                        row["电文号"] = rdr["msgid"];
                        row["序号"] = rdr["id"];
                        row["接收时间"] = rdr["clock"];
                        //row["处理标记"] = rdr["processflag"];
                        //row["处理时间"] = rdr["processlogtime"];
                        //row["处理报错"] = rdr["memo"];
                        if (!bExcluded)
                            queryDataTable.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count <= 0)
                {
                    return;
                }
                string messageid = this.dataGridView1.CurrentRow.Cells["电文号"].Value.ToString();
                string content = this.dataGridView1.CurrentRow.Cells["电文内容"].Value.ToString();

                string[] contentlist = content.Split(',');

                //content = content.Replace(",", "");
                //byte[] bytes = Encoding.Default.GetBytes(content);
                MsgData msgData = parser.Parse(messageid, contentlist);
                MsgData2DataGridView(msgData, dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSndQuery_Click(object sender, EventArgs e)
        {
            try
            {
                // 准备查询结果表
                MsgQuery2DataGridView(dataGridView3, QUERY_TYPE.SEND);

                // 查询接收表
                string sqlStr = string.Format("SELECT * FROM UACS_L3MSG_SEND ");
                sqlStr = String.Format("{0} where rec_time > '{1}{2}' and rec_time < '{3}{4}' ",
                    sqlStr,
                    dateTimePicker_RStartDate_S.Value.ToString("yyyyMMdd"),
                    dateTimePicker_RStartTime_S.Value.ToString("HHmmss"),
                    dateTimePicker_REndDate_S.Value.ToString("yyyyMMdd"),
                    dateTimePicker_REndTime_S.Value.ToString("HHmmss"));
                if (textBox3.Text.Length != 0)
                {
                    sqlStr = String.Format("{0} and msgid = '{1}'",
                        sqlStr,
                        textBox3.Text);
                }
                sqlStr = String.Format("{0} {1}",
                    sqlStr,
                    "ORDER BY send_time desc");
                // 筛选字段
                string strFliter = "";
                if (textBox4.Text.Length != 0)
                {
                    strFliter = textBox4.Text;
                }

                using (IDataReader rdr = DBHelper2.ExecuteReader(sqlStr))
                {
                    while (rdr.Read())
                    {
                        //画面中新增一条记录
                        DataRow row = queryDataTable.NewRow();
                        bool bExcluded = false;

                        row["电文内容"] = rdr["datastr"];
                        if (strFliter.Length != 0)
                        {
                            if (((String)row["电文内容"]).IndexOf(strFliter) == -1)
                                bExcluded = true;
                        }
                        row["电文号"] = rdr["msgid"];
                        row["序号"] = rdr["id"];
                        row["记录时间"] = rdr["rec_time"];
                        row["发送时间"] = rdr["send_time"];
                        row["发送标记"] = rdr["flag"];
                        //row["处理标记"] = rdr["processflag"];
                        //row["处理时间"] = rdr["processlogtime"];
                        //row["处理报错"] = rdr["memo"];
                        if (!bExcluded)
                            queryDataTable.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView3.Rows.Count <= 0)
                {
                    return;
                }
                string messageid = this.dataGridView3.CurrentRow.Cells["电文号"].Value.ToString();
                string content = this.dataGridView3.CurrentRow.Cells["电文内容"].Value.ToString();

                string[] contentlist = content.Split(',');

                //content = content.Replace(",", "");
                //byte[] bytes = Encoding.Default.GetBytes(content);
                MsgData msgData = parser.Parse(messageid, contentlist);
                MsgData2DataGridView(msgData, dataGridView4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 重发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.SelectedRows.Count <1)
                {
                    return;
                }
                int nSelectIndex = dataGridView3.SelectedRows[0].Index;
                if (nSelectIndex >= 0 && nSelectIndex < queryDataTable.Rows.Count)
                {
                    Int32 count = 0;
                    Int32 seq = (Int32)queryDataTable.Rows[nSelectIndex]["序号"];
                    //String sql = String.Format("update sentmessagebufferlog set sendresult=0 where sentmessageid = {0}",
                    //    seq);
                    //db.UpdateOrDeleteDataFromDataBase(sql, ref count);
                    tagDP.SetData("L3MSG_RESEND", seq.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 方法
        private void MsgQuery2DataGridView(DataGridView dataGridView, QUERY_TYPE type)
        {
            queryDataTable = new DataTable();
            queryDataTable.TableName = "电文查询结果";

            DataColumn column = new DataColumn("序号");
            column.DataType = typeof(Int32);
            queryDataTable.Columns.Add(column);

            if (type == QUERY_TYPE.RECV)
            {
                column = new DataColumn("接收时间");
                column.DataType = typeof(String);
                queryDataTable.Columns.Add(column);
            }
            else if (type == QUERY_TYPE.SEND)
            {
                column = new DataColumn("记录时间");
                column.DataType = typeof(String);
                queryDataTable.Columns.Add(column);
            }
            column = new DataColumn("电文号");
            column.DataType = typeof(String);
            queryDataTable.Columns.Add(column);

            column = new DataColumn("电文内容");
            column.DataType = typeof(String);
            queryDataTable.Columns.Add(column);

            if (type == QUERY_TYPE.SEND)
            {
                column = new DataColumn("发送时间");
                column.DataType = typeof(String);
                queryDataTable.Columns.Add(column);

                column = new DataColumn("发送标记");
                column.DataType = typeof(String);
                queryDataTable.Columns.Add(column);
            }

           
            //column = new DataColumn("处理标记");
            //column.DataType = typeof(Int16);
            //queryDataTable.Columns.Add(column);

            //column = new DataColumn("处理时间");
            //column.DataType = typeof(String);
            //queryDataTable.Columns.Add(column);

            //column = new DataColumn("处理报错");
            //column.DataType = typeof(String);
            //queryDataTable.Columns.Add(column);

            dataGridView.DataSource = queryDataTable;
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {
                dataGridView.Columns[item.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void MsgData2DataGridView(MsgData msgData, DataGridView dataGridView)
        {
            // 创建电文结果解析表
            msgDataTable = new DataTable();
            msgDataTable.TableName = "电文解析结果";

            // 设置表内的各字段
            // 值
            DataColumn column = new DataColumn("字段");
            column.DataType = typeof(String);
            msgDataTable.Columns.Add(column);
            // 值
            column = new DataColumn("值");
            column.DataType = typeof(String);
            msgDataTable.Columns.Add(column);
            // 值含义
            column = new DataColumn("含义");
            column.DataType = typeof(String);
            msgDataTable.Columns.Add(column);

            // 向表中添加记录
            bool bRecuMsg = false;
            int nRecuCount = 0;
            // 添加正常字段
            foreach (MsgStandField field in msgData.StandFields)
            {
                DataRow row = msgDataTable.NewRow();
                row["字段"] = field.name.Trim();
                row["值"] = field.value.Trim();
                row["含义"] = field.comment;

                // 循环字段
                if (field.bRecurFlag)
                {
                    bRecuMsg = true;
                    nRecuCount = Convert.ToInt32(field.value);
                }

                msgDataTable.Rows.Add(row);
            }

            // 处理循环字段
            if (msgData.RecuFields.Count !=0)
            {
                for (int nIndex = 0; nIndex < msgData.RecuFields[0].values.Count; nIndex++)
                {
                    // 添加循环数据块字段
                    foreach (MsgRecuField field in msgData.RecuFields)
                    {
                        DataRow row = msgDataTable.NewRow();
                        row["字段"] = field.values[nIndex].Trim();
                        row["值"] = field.values[nIndex].Trim();
                        row["含义"] = String.Format("第{0}个 {1}",
                            nIndex,
                            field.comment);

                        msgDataTable.Rows.Add(row);
                    }
                }
            }

            // 将表绑定到控件
            dataGridView.DataSource = msgDataTable;
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {
                dataGridView.Columns[item.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }




        #endregion

        
    }

}
