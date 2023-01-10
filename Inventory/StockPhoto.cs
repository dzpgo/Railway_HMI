using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;

namespace Inventory
{
    public partial class StockPhoto : FormBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id = null;

        /// <summary>
        /// 库位
        /// </summary>
        public string Stock_No = null;

        /// <summary>
        /// 牵连库位
        /// </summary>
        public string Stock_No_Implicate = null;

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

        public StockPhoto()
        {
            InitializeComponent();
            this.Load += StockPhoto_Load;
        }

        void StockPhoto_Load(object sender, EventArgs e)
        {
            try
            {
                dgvStockPhoto.DataSource = BindStockPhoto();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 绑定库位照片
        /// </summary>
        /// <returns></returns>
        private DataTable BindStockPhoto()
        {
            DataTable dt = new DataTable();
            try
            {
                
                bool hasSetColumn = false;
                if (id != null && Stock_No != null )
                {
                    string sql = @"SELECT * FROM UACS_PDA_INVENTORY_PHOTO ";
                    sql += " WHERE ID = '" + id + "' AND STOCK_NO IN ('" + Stock_No + "','" + Stock_No_Implicate + "') ";

                    using (IDataReader rdr = DBHelper.ExecuteReader(sql))
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

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return dt;
        }


    }
}
