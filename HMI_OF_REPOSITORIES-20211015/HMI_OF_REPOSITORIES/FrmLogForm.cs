using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Baosight.ColdRolling.Utility;
//using Baosight.ColdRolling.LogicLayer;
//using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.Common;
using UACSUtility;
using Baosight.iSuperframe.Authorization.Interface;
using Baosight.iSuperframe.Authorization;

namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmLogForm : Baosight.iSuperframe.Forms.FormBase
    {
       // private static Baosight.iSuperframe.Common.IDBHelper dBHelper = null;
        bool isFalse = false;

        public FrmLogForm()
        {
            InitializeComponent();
            //dBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");
        }

        private void MLogForm_Load(object sender, EventArgs e)
        {
            //dataGridView1.ColumnHeadersHeight = 35;
            //dataGridView1.RowTemplate.Height = 35;
            //dataGridView1.AllowUserToResizeRows = false;          //禁止用户改变DataGridView1所有行的行高
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   //居中
            //dataGridView1.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10, FontStyle.Regular);
            //GetFormLogData();
            UACSUtility.ViewHelper.DataGridViewInit(dataGridView1);
            this.dateTimeStart.Value = DateTime.Now.Date;
            dateTimeEnd.Text = DateTime.Now.Date.AddDays(1).ToString(); 
            GetoLogsData(dateTimeStart.Value, dateTimeEnd.Value, "","");
        }
        private void GetFormLogData()
        {
            //try
            //{
            //    string sql = "select * from LV_LOG_LOGINFO order by TOC desc";
            //    ViewHelper.GenDataGridViewData(dBHelper, dataGridView1, sql, isFalse, "KEY1", cbxKey1);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //GetFormLogData();
            GetoLogsData(dateTimeStart.Value, dateTimeEnd.Value, cbxKey1.Text.Trim(), txtInfo.Text.Trim());
        }
        private void GetoLogsData(DateTime start, DateTime end, string key1, string info)
        {            
            string strStart = start.ToString("yyyyMMddHHmmss");
            string strEnd = end.ToString("yyyyMMddHHmmss");
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT ROW_NUMBER() OVER() as ROW_INDEX , SEQNO, KEY1, KEY2, \"LEVEL\", INFO, MODULE, USERID, TOC, USERNAME FROM UACS_HMI_LOG   WHERE 1 = 1  ";
                sql += " AND TOC  > '" + strStart + "' and TOC <'" + strEnd + "'";

                if (key1 != "" && key1 != "全部")
                {
                    sql += " AND KEY1 = '" + key1 + "' ";
                }
                if (info != "" && info != "全部")
                {
                    sql += " AND INFO LIKE  '%" + info + "%' ";
                }
                if (cmbLevelId.Text.Contains("出错信息"))
                {
                    sql += " AND LEVEL = '" + 3 + "' ";
                }
                 else if (cmbLevelId.Text.Contains("普通警告"))
                {
                    sql += " AND LEVEL = '" + 2 + "' ";
                }
                else if (cmbLevelId.Text.Contains("普通信息"))
                {
                    sql += " AND LEVEL = '" + 1 + "' ";
                }
                sql += " ORDER BY TOC DESC ";
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                dataGridView1.DataSource = dt;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
    }
}
