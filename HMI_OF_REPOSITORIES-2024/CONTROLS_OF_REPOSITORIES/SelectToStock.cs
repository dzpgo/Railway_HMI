using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class SelectToStock : Form
    {
        private DataTable dt = new DataTable();
        private bool hasSetColumn = false;
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;
        public DataTable result_dt = new DataTable();
        private string bayNo = "";
        public SelectToStock(string _bayNo)
        {
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
            bayNo = _bayNo;
        }

        #region 事件
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectToStock_Load(object sender, EventArgs e)
        {
            try
            {
                //定义返回table的列
                result_dt.Columns.Add("STOCK_NO");
                getMatData();
                dataGridView1.DataSource = dt;
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
                getMatData();
                dataGridView1.DataSource = dt;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取材料数据
        /// </summary>
        private void getMatData()
        {
            string stockNo = this.tbStockNo.Text.ToString().Trim();
            string stockName = this.tbStockName.Text.ToString().Trim();
            string sqlText = "SELECT STOCK_NO,STOCK_NAME FROM UACS_YARDMAP_STOCK_DEFINE  ";
            sqlText += "WHERE STOCK_NO LIKE '%" + stockNo + "%' AND STOCK_NAME like '%" + stockName + "%' ";
            sqlText += "AND STOCK_STATUS <>'2' AND BAY_NO = '" + bayNo + "'";
            dt.Clear();
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
        }

        #endregion
    }
}
