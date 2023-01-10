using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using UACSUtility;

namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmStatForm : FormBase
    {
        private DataBaseHelper m_dbHelper;

        #region 连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;

        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
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

                    }
                }
                return dbHelper;
            }
        }
        #endregion

        public FrmStatForm()
        {
            InitializeComponent();
            this.Load += StatForm_Load;
        }

        void StatForm_Load(object sender, EventArgs e)
        {
            m_dbHelper = new DataBaseHelper();
            m_dbHelper.OpenDB(DBHelper.ConnectionString);
            UACSUtility.ViewHelper.DataGridViewInit(dataGridView1);
            UACSUtility.ViewHelper.DataGridViewInit(dataGridView2);
            UACSUtility.ViewHelper.DataGridViewInit(dataGridView3);
        }
       
       

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_dbHelper == null)
                return;

           // HMILogger.WriteLog("k1","k2","message");


            //选择班组
            string strshift = cmbShift.Text;
            
            //选择哪一跨的
            string strWare = cmbWare.Text.Trim();
            DateTime dt = dateTimePicker1.Value; ;
            string timespan1 = ViewHelper.GenTimeSpanSQL(strshift.Trim(), dt, "REC_TIME");

            DateTime dt2 = dateTimePicker2.Value;
            string timespan2 = ViewHelper.GenTimeSpanSQL(dt, dt2, "REC_TIME");

            //查询作业总数
            string sql0 = @"select crane_no,count(*) /2 as num from  UACS_CRANE_ORDER_OPER_Z32_Z33 where " + timespan1;

            //查询出3列
            string sql1 = @"select crane_no,CASE
          WHEN crane_mode = 1 THEN '遥控'
          WHEN crane_mode = 2 THEN '手动'
          WHEN crane_mode = 4 THEN '自动'
      END as mode ,count(*)/2 as num from  UACS_CRANE_ORDER_OPER_Z32_Z33 where " + timespan1;

            //增加作业类型，共4列
            string sql2 = @"select CASE
          WHEN order_type = 11 THEN '入库(出口收料)'
          WHEN order_type = 12 THEN '入库(台车收料)'
          WHEN order_type = 13 THEN '入库(车辆卸载)'       
          WHEN order_type = 14 THEN '入库(入口退料)'
          WHEN order_type = 21 THEN '出库(入口上料)'
          WHEN order_type = 22 THEN '出库(台车上料)'
          WHEN order_type = 23 THEN '出库(车辆装载)'
          WHEN order_type = 24 THEN '出库(称重标定)'
          WHEN order_type = 31 THEN '倒垛(库内倒垛)'
          ELSE '其他'
       END as ordertype, crane_no,CASE
          WHEN crane_mode = 1 THEN '遥控'
          WHEN crane_mode = 2 THEN '手动'
          WHEN crane_mode = 4 THEN '自动'
      END as mode ,count(*)/2 as num from  UACS_CRANE_ORDER_OPER_Z32_Z33 where " + timespan1;

            string sql3 = @"SELECT 
                      CASE
                          WHEN STOCK_NO like 'D308%' THEN 'D308'
                          WHEN STOCK_NO like 'D212VR1A%' THEN 'D212-01'
                          WHEN STOCK_NO like 'D212VR2A%' THEN 'D212-02'
                       END as stock_no ,
                count(*) as num,
                CASE
                          WHEN order_type = 11 THEN '机组产出'
                          WHEN order_type = 12 THEN '机组回退'
                          WHEN order_type = 13 THEN '框架入库'       
                          WHEN order_type = 14 THEN '包装入库'
                          WHEN order_type = 21 THEN '机组上料' 
                          WHEN order_type = 22 THEN '废品出库'
                          WHEN order_type = 23 THEN '包装出库'
                          WHEN order_type = 24 THEN '转库出库'
                          WHEN order_type = 25 THEN '发货出库'
                          WHEN order_type = 31 THEN '倒剁'
                          ELSE '其他'
                       END as ordertype,
                       crane_no
                       ,CASE
                          WHEN crane_mode = 1 THEN '遥控'
                          WHEN crane_mode = 2 THEN '手动'
                          WHEN crane_mode = 4 THEN '自动'
                      END as mode
                 FROM UACS_CRANE_ORDER_OPER_Z32_Z33
                 WHERE " + timespan1 ;

            sql3 += " and (STOCK_NO like 'D308%' or STOCK_NO like 'D212%') ";

            sql3 += " and ( crane_no='4_1' or crane_no='4_2' or crane_no='4_3') ";


            if (strWare == "轧后库")
            {
                sql0 += " and ( crane_no='4_1' or crane_no='4_2' or crane_no='4_3' or crane_no='4_4' or crane_no='4_5')";
                sql1 += " and ( crane_no='4_1' or crane_no='4_2' or crane_no='4_3' or crane_no='4_4' or crane_no='4_5')";
                sql2 += " and ( crane_no='4_1' or crane_no='4_2' or crane_no='4_3' or crane_no='4_4' or crane_no='4_5')";
            }
            else if (strWare == "成品库")
            {
                sql0 += " and  crane_no in ('7_0','7_1','7_2','7_3','7_4','7_5','7_6','7_7','7_8','7_9')";
                sql1 += " and  crane_no in ('7_0','7_1','7_2','7_3','7_4','7_5','7_6','7_7','7_8','7_9')";
                sql2 += " and  crane_no in ('7_0','7_1','7_2','7_3','7_4','7_5','7_6','7_7','7_8','7_9')";

            }
            else if (strWare == "A跨")
            {
                sql0 += " and  crane_no in ('1','2','3')";
                sql1 += " and  crane_no in ('1','2','3')";
                sql2 += " and  crane_no in ('1','2','3')"; 
            }
            else if (strWare == "C跨")
            {
                sql0 += " and  crane_no in ('7','8')";
                sql1 += " and  crane_no in ('7','8')";
                sql2 += " and  crane_no in ('7','8')";
            }
            sql0 += " group by crane_no";
            sql1 += " group by crane_no,crane_mode";
            sql2 += " group by order_type,crane_no,crane_mode";
            sql3 += " group by stock_no,crane_mode,crane_no,order_type";

            //查询吊运总数
            DataTable data0 = null;
            string error = "";
            // DBHelper.ReadTable
            data0 = m_dbHelper.ReadData(sql0, out error);

            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            //计算百分比
            if (data0 != null)
            {
                foreach (DataRow dr in data0.Rows)
                {
                    myDictionary.Add((string)dr[0], (int)dr[1]);
                }
            }
            DataTable data1 = null;
            data1 = m_dbHelper.ReadData(sql1, out error);

                 

            //计算百分比
            if (data1 != null)
            {
                data1.Columns.Add("PERCENT", Type.GetType("System.Single"));
                dataGridView1.Rows.Clear();   

                foreach(DataRow dr in data1.Rows)
                {
                    string str = (string)dr[0];
                    int count = myDictionary[str];
                    if (count!=0)
                    {
                        float temp = (int)dr[2] * 100 / (float)count;
                        dr[3] = float.Parse(temp.ToString("#0.00"));
                    }
                     else
                        dr[3] = 0.0;
                    // myDictionary[str];
                }
            }

            ViewHelper.SetDataGridViewData(dataGridView1, data1, true);

            DataTable data2 = null;

            data2 = m_dbHelper.ReadData(sql2, out error);

            dataGridView2.Rows.Clear();
            ViewHelper.SetDataGridViewData(dataGridView2, data2, true);

            GetDatagridview(timespan1);
            VisibleColumn(dataGridView3);
            //DataTable data3 = null;

            //data3 = m_dbHelper.ReadData(sql3, out error);




            //dataGridView3.Rows.Clear();
            //ViewHelper.SetDataGridViewData(dataGridView3, data3, true);


            dataGridViewColor(); 
        }

        private void StatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_dbHelper.CloseDB();
        }

        

        private void dataGridViewColor()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               // CraneMode1
                if (dataGridView1.Rows[i].Cells["CraneMode1"].Value != System.DBNull.Value)
                {
                    if (dataGridView1.Rows[i].Cells["CraneMode1"].Value.ToString().Trim() == "自动")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["CraneMode2"].Value != System.DBNull.Value)
                {
                    if (dataGridView2.Rows[i].Cells["CraneMode2"].Value.ToString().Trim() == "自动")
                    {
                        //dataGridView2.Rows[i].Cells["CraneMode2"].Style.BackColor = Color.Blue;
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }


            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Cells["CraneMode3"].Value != System.DBNull.Value)
                {
                    if (dataGridView3.Rows[i].Cells["CraneMode3"].Value.ToString().Trim() == "自动")
                    {
                        dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }



        private void GetDatagridview(string time)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Rows.Add(12);
            dataGridView3.Rows[0].Cells[0].Value = "D212";
            dataGridView3.Rows[0].Cells[1].Value = GetNUM(time, 21, "D212", 4);  //自动上料D212
            dataGridView3.Rows[0].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[0].Cells[3].Value = "自动";

            dataGridView3.Rows[1].Cells[0].Value = "D212";
            dataGridView3.Rows[1].Cells[1].Value = GetNUM(time, 21, "D212", 2);  //手动上料D212
            dataGridView3.Rows[1].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[1].Cells[3].Value = "手动";

            dataGridView3.Rows[2].Cells[0].Value = "D212";
            dataGridView3.Rows[2].Cells[1].Value = GetNUM(time, 14, "D212", 4);  //自动退料D212
            dataGridView3.Rows[2].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[2].Cells[3].Value = "自动";

            dataGridView3.Rows[3].Cells[0].Value = "D212";
            dataGridView3.Rows[3].Cells[1].Value = GetNUM(time, 14, "D212", 2);  //手动退料D212
            dataGridView3.Rows[3].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[3].Cells[3].Value = "手动";

            dataGridView3.Rows[4].Cells[0].Value = "D212";
            dataGridView3.Rows[4].Cells[1].Value = GetNUM(time, 21, "D212", 1);  //遥控上料D212
            dataGridView3.Rows[4].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[4].Cells[3].Value = "遥控";

            dataGridView3.Rows[5].Cells[0].Value = "D212";
            dataGridView3.Rows[5].Cells[1].Value = GetNUM(time, 14, "D212", 1);  //遥控退料D212
            dataGridView3.Rows[5].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[5].Cells[3].Value = "遥控";

            dataGridView3.Rows[6].Cells[0].Value = "D308";
            dataGridView3.Rows[6].Cells[1].Value = GetNUM(time, 21, "D308", 4);  //自动上料D308
            dataGridView3.Rows[6].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[6].Cells[3].Value = "自动";

            dataGridView3.Rows[7].Cells[0].Value = "D308";
            dataGridView3.Rows[7].Cells[1].Value = GetNUM(time, 21, "D308", 2);  //手动上料D308
            dataGridView3.Rows[7].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[7].Cells[3].Value = "手动";

            dataGridView3.Rows[8].Cells[0].Value = "D308";
            dataGridView3.Rows[8].Cells[1].Value = GetNUM(time, 14, "D308", 4);  //自动退料D308
            dataGridView3.Rows[8].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[8].Cells[3].Value = "自动";

            dataGridView3.Rows[9].Cells[0].Value = "D308";
            dataGridView3.Rows[9].Cells[1].Value = GetNUM(time, 14, "D308", 2);  //手动退料D308
            dataGridView3.Rows[9].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[9].Cells[3].Value = "手动";


            dataGridView3.Rows[10].Cells[0].Value = "D308";
            dataGridView3.Rows[10].Cells[1].Value = GetNUM(time, 21, "D308", 1);  //遥控上料D308
            dataGridView3.Rows[10].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[10].Cells[3].Value = "遥控";

            dataGridView3.Rows[11].Cells[0].Value = "D308";
            dataGridView3.Rows[11].Cells[1].Value = GetNUM(time, 14, "D308", 1);  //遥控退料D308
            dataGridView3.Rows[11].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[11].Cells[3].Value = "遥控";

        }
        /// <summary>
        /// 获取具体数量
        /// orderType 分为
        /// 机组回退（14）
        /// 机组上料（21）
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="orderType">类别</param>
        /// <param name="stockNo">机组号</param>
        /// <param name="mode">行车模式</param>
        /// <returns></returns>
        private string GetNUM(string time,int orderType,string unitNo,int mode)
        {
            string num = "0";
            try
            {
                string sql = @" SELECT  count(*) as num  FROM UACS_CRANE_ORDER_OPER_Z32_Z33 ";
                sql += " WHERE " + time;
                sql += " and (crane_no='4_3' or crane_no = '4_2')  and ORDER_TYPE = " + orderType + " ";
                sql += " and STOCK_NO like '" + unitNo + "%' ";
                sql += " and crane_mode = " + mode + " ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                        {
                            num =rdr["num"].ToString();
                        }
                        else
                        {
                            num = "0";
                        }
                       
                    }
                }

                return num;
 
            }
            catch (Exception er)
            {
                return "0";
            }
        }


        private void VisibleColumn(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["num"].Value != System.DBNull.Value)
                {
                    if (dgv.Rows[i].Cells["num"].Value.ToString().Trim() == "0")
                    {
                        dgv.Rows[i].Visible = false;
                    }
                }
            }
        }


    }
}
