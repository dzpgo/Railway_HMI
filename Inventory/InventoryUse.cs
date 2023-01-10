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

namespace Inventory
{
    public partial class InventoryUse : FormBase
    {
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        List<string> area = new List<string>();
        public InventoryUse()
        {
            InitializeComponent();
            this.Load += InventoryUse_Load;
        }
        
        void InventoryUse_Load(object sender, EventArgs e)
        {
            //设置背景色
            this.panel1.BackColor = UACS.ColorSln.FormBgColor;
            this.groupBox1.BackColor = UACS.ColorSln.FormBgColor;

            //tag控件配置
            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            //添加tag点
            TagValues.Clear();
            TagValues.Add("INVENTORY_INIT", null);
            tagDP.Attach(TagValues);
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

        private void cbbStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                area.Clear();
               
                string StockNo = this.cbbStock.Text.Trim();
                dataGridView1.Rows.Clear();
                string id = MainId(StockNo);
                txtId.Text = id;
                area = InitArea(id);
                string sqlGetRowNo = @"SELECT COL_ROW_NO FROM UACS_YARDMAP_ROWCOL_DEFINE WHERE COL_ROW_NO LIKE '%";
                sqlGetRowNo += StockNo;
                sqlGetRowNo += "%'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlGetRowNo))
                {
                    while (rdr.Read())
                    {
                        dataGridView1.Rows.Add(1);
                        int count = dataGridView1.Rows.Count - 1;
                        string RowColNo = rdr["COL_ROW_NO"].ToString();

                        dataGridView1.Rows[count].Cells[1].Value = RowColNo;
                        //该行未封锁的空库位个数
                        int AvailableEmpty = AvailableEmptyStockNum(RowColNo);
                        //空库位个数
                        int Empty = EmptyStockNum(RowColNo);
                        //判断行是否在本次区域内 已封锁，且已添加的不允许选择
                        string isadd = "";
                        if (area.Contains(RowColNo))
                        {
                            isadd = "，   已添加";
                        }
                        else
                        {
                            isadd = "，   未添加";
                        }
                        //情况1：无空库位
                        //情况2：有空库位,且存在空库位未封锁
                        //情况3：有空库位,且每个空库位都被封锁
                        if (Empty == 0)
                        {
                            dataGridView1.Rows[count].Cells[2].Value = "无空库位" + isadd;
                            dataGridView1.Rows[count].DefaultCellStyle.BackColor = Color.Wheat;
                            
                        }
                        else
                        {
                            if (AvailableEmpty == 0)
                            {
                                dataGridView1.Rows[count].Cells[2].Value = "已封锁" + isadd;
                                dataGridView1.Rows[count].DefaultCellStyle.BackColor = Color.Red;
                            }
                            else
                            {
                                dataGridView1.Rows[count].Cells[2].Value = "未封锁" + isadd;
                                dataGridView1.Rows[count].DefaultCellStyle.BackColor = Color.White;
                            }
                        }
                        
                    }
                }
               

                //dataGridView1.ReadOnly = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 查询行列库位的数量
        /// </summary>
        /// <param name="rowcol"></param>
        /// <returns></returns>
        private int AvailableEmptyStockNum(string rowcol)
        {
            int num = 0;
            try
            {
                string sqlStockNo = @"SELECT COUNT(*) AS NUM FROM UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NAME like '" + rowcol + "%' AND STOCK_STATUS = 0 AND LOCK_FLAG !=1";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStockNo))
                {
                    if (rdr.Read())
                    {
                        num = Convert.ToInt32(rdr["NUM"].ToString());
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return num;
        }
        /// <summary>
        /// 空库位个数
        /// </summary>
        /// <param name="rowcol"></param>
        /// <returns></returns>
        private int EmptyStockNum(string rowcol)
        {
            int num = 0;
            try
            {
                string sqlStockNo = @"SELECT COUNT(*) AS NUM FROM UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NAME like '" + rowcol + "%' AND STOCK_STATUS = 0";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStockNo))
                {
                    if (rdr.Read())
                    {
                        num = Convert.ToInt32(rdr["NUM"].ToString());
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return num;
        }
        /// <summary>
        /// 初始化库位区域
        /// </summary>
        /// <param name="rowcol"></param>
        /// <returns></returns>
        private List<string> InitArea(string id)
        {
            List<string> list = new List<string>();
            int num = 0;
            try
            {
                string sqlStockNo = @"SELECT ROW_NO FROM UACS_PDA_INVENTORY_AREA WHERE ID = '" + id + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStockNo))
                {
                    while (rdr.Read())
                    {
                        string row= rdr["ROW_NO"].ToString();
                        list.Add(row);
                    }
                }
               

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return list;
        }
        /// <summary>
        /// 判断有多少库位是封锁
        /// </summary>
        /// <returns></returns>
        private int StockStatus(string rowcol)
        {
            int num = 0;
            try
            {
                string sqlStockNo = @"SELECT COUNT(*) AS NUM FROM UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NAME like '" + rowcol + "%' AND LOCK_FLAG =1";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStockNo))
                {
                    if (rdr.Read())
                    {
                        num = Convert.ToInt32(rdr["NUM"].ToString());
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return num;
        }


        private string MainId(string rowcol)
        {
            string id = null;
            try
            {
                string sql = @"SELECT ID FROM UACS_PDA_INVENTORY_MAIN WHERE BAY_NO = '" + rowcol + "' AND EFFECT_FLAG = 'Y' ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        id = rdr["ID"].ToString();
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return id;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateInventoryListForm newform = new CreateInventoryListForm();
            newform.ShowDialog();
            cbbStock.Text = newform.bayno;
            txtId.Text = newform.inventoryid;
            cbbStock_SelectedIndexChanged(null, null);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string tagRow = txtId.Text + "|";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string isChoosed = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
                    string RowNo = dataGridView1[1, i].Value.ToString();
                    if (isChoosed == "True")
                    {
                        tagRow += RowNo + "|";
                    }
                
                }

                tagDP.SetData("INVENTORY_INIT", tagRow);
                MessageBox.Show("TAGVALUE:"+tagRow);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            btnRefesh_Click(null, null);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text.Trim();
                if (id != "")
                {
                    string sql = @"UPDATE UACS_PDA_INVENTORY_MAIN SET EFFECT_FLAG = 'N' WHERE ID = '" + id + "'";
                    DBHelper.ExecuteNonQuery(sql);
                    txtResult.Text = "已关闭";
                }
                else
                    txtResult.Text = "盘库单号不能为空"; 
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            cbbStock_SelectedIndexChanged(null, null);
        }
    }
}
