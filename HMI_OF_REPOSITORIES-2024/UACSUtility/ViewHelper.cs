using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.TagService;

namespace UACSUtility
{

    /// <summary>
    /// 跟画面有关的一些工具方法。
    /// 2017年9月8日开发
    /// </summary>
    public class ViewHelper
    {
        #region iPlature配置
        private static Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = null;
        public static Baosight.iSuperframe.TagService.Controls.TagDataProvider TagDP
        {
            get
            {
                if (tagDP == null)
                {
                    try
                    {
                        tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
                        tagDP.ServiceName = "iplature";
                        tagDP.AutoRegist = true;
                    }
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return tagDP;
            }
            //set { tagDP = value; }
        }
        #endregion
        /// <summary>
        /// 使用sql语句查询出数据库表，然后与DataGridView逐行绑定
        /// 使用方法：
        /// string sql = "select * from LV_CRANE_PLAN";
        /// ViewHelper.GenDataGridViewData(Helper, dataGridView1, sql, isFalseIn);
        /// 其中Helper是：IDBHelper helper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("APP");的属性返回
        /// </summary>
        /// <param name="Helper">数据库访问对象，iPlature提供，</param>
        /// <param name="dataGridView1">需要绑定数据的DataGridView</param>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="isFalse">是否第一次调用，需要返回新值，需要加 ref </param>
        public static string GenDataGridViewData(IDBHelper Helper, DataGridView dataGridView1, string sql, bool isFalse)
        {
            if (Helper == null)
            {
                return "Helper未初始化";
            }

            DataTable datatable = new DataTable();

            using (IDataReader odrIn = Helper.ExecuteReader(sql))
            {
                while (odrIn.Read())
                {
                    //如果是第一次调用，需要为DataTable建立Column。
                    if (!isFalse)
                    {
                        for (int i = 0; i < odrIn.FieldCount; i++)
                        {
                            DataColumn dc = new DataColumn();
                            dc.ColumnName = odrIn.GetName(i);
                            datatable.Columns.Add(dc);
                        }
                        isFalse = true;
                    }


                    //逐列赋值
                    DataRow dr = datatable.NewRow();
                    for (int i = 0; i < odrIn.FieldCount; i++)
                    {
                        dr[i] = odrIn[i];
                    }
                    datatable.Rows.Add(dr);
                }//while结束

                //为datagridview赋值
                string str = SetDataGridViewData(dataGridView1, datatable);

                //if (datatable.Rows.Count > 0)
                //{
                //    for (int i = 0; i < datatable.Rows.Count; i++)
                //    {
                //        dataGridView1.Rows.Add();
                //        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                //        for (int j = 0; j < datatable.Columns.Count; j++)
                //        {
                //            dataGridView1.Rows[i].Cells[j + 1].Value = datatable.Rows[i][j].ToString();
                //        }
                //    }
                //}

                return str;

            }
        }

        /// <summary>
        /// 给dataGridView1用datatable逐行赋值
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="datatable"></param>
        public static string SetDataGridViewData(DataGridView dataGridView1,DataTable datatable)
        {
            if(datatable.Rows.Count==0)
            {
                return "datatable为NULL";
            }

            try
            {
                if (datatable.Rows.Count > 0)
                {
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                        for (int j = 0; j < datatable.Columns.Count; j++)
                        {
                            dataGridView1.Rows[i].Cells[j + 1].Value = datatable.Rows[i][j].ToString();
                        }
                    }
                }
            }
            catch (Exception er)
            {
                
                throw;
            }

           

            return "";
        }



        /// <summary>
        /// 给dataGridView1用datatable逐行赋值
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="datatable"></param>
        public static string SetDataGridViewData(DataGridView dataGridView1, DataTable datatable, bool isNeedSeq)
        {
            if (datatable == null)
            {
                return "datatable为NULL";
            }

            if (datatable.Rows.Count > 0)
            {
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    if (isNeedSeq)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                        for (int j = 0; j < datatable.Columns.Count; j++)
                        {
                            dataGridView1.Rows[i].Cells[j + 1].Value = datatable.Rows[i][j].ToString();
                        }
                    }
                    else
                    {
                        for (int j = 0; j < datatable.Columns.Count; j++)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = datatable.Rows[i][j].ToString();
                        }
                    }

                }
            }

            return "";
        }





        private static string SetComboBoxData(ComboBox comBox, string columnName, DataTable datatable)
        {
            if (datatable == null)
            {
                return "datatable为NULL";
            }

            columnName = columnName.ToUpper().Trim();
            bool columnExist = false;
            List<string> items = new List<string>();
            //查找datatable中是否存在名字为columnName的列
            for (int k = 0; k < datatable.Columns.Count; k++)
            {
                if(datatable.Columns[k].ColumnName.ToUpper().Trim()== columnName)
                {
                    columnExist = true;
                    break;
                }
            }
            if(!columnExist)
            {
                return "datatable中不存在列名："+ columnName;
            }
           
            //comBox.DataSource = null;
            //comBox.Items.Clear();          
            for (int i = 0; i < datatable.Rows.Count;i++)
            {
                items.Add(datatable.Rows[i][columnName].ToString());
               // comBox.Items.Add(datatable.Rows[i][columnName].ToString());
            }
          //  List<string> nonDuplicateitems = items.Where((x, i) => items.FindIndex(z => z == x) == i).ToList();
         //   comBox.DataSource = nonDuplicateitems;
           //comBox.Text = "";
            return "";
        }
        /// <summary>
        /// 使用sql语句查询出数据库表，然后与DataGridView逐行绑定，同时还将其中的一列数据绑定到combox用于下拉框
        /// </summary>
        /// <param name="Helper"></param>
        /// <param name="dataGridView1"></param>
        /// <param name="sql"></param>
        /// <param name="isFalse"></param>
        /// <param name="combox1"></param>
        /// <returns></returns>
        public static string GenDataGridViewData(IDBHelper Helper, DataGridView dataGridView1, string sql, bool isFalse, string columnName, ComboBox combox)
        {
            if (Helper == null)
            {
                return "Helper未初始化";
            }

            DataTable datatable = new DataTable();
            using (IDataReader odrIn = Helper.ExecuteReader(sql))
            {
                while (odrIn.Read())
                {
                    //如果是第一次调用，需要为DataTable建立Column。
                    if (!isFalse)
                    {
                        for (int i = 0; i < odrIn.FieldCount; i++)
                        {
                            DataColumn dc = new DataColumn();
                            dc.ColumnName = odrIn.GetName(i);
                            datatable.Columns.Add(dc);
                        }
                    }
                    isFalse = true;

                    //逐列赋值
                    DataRow dr = datatable.NewRow();
                    for (int i = 0; i < odrIn.FieldCount; i++)
                    {
                        dr[i] = odrIn[i];
                    }
                    datatable.Rows.Add(dr);
                }//while结束

                //为datagridview赋值
                string str = SetDataGridViewData(dataGridView1, datatable);
                str = SetComboBoxData(combox, columnName, datatable);
                return str;
            }

        }
      
        

        /// <summary>
        /// DataGridView显示指定的数据源，load直接绑定
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="columnsName">DataGridView的列名绑定数据的集合</param>
        /// <param name="headerText">DataGridView的列名的集合</param>
        /// <param name="Helper"></param>
        /// <param name="sql"></param>
        /// <param name="isFist"></param>
        /// <returns></returns>
        public static bool DataGridViewBindingSource(DataGridView dataGridView, string[] columnsName,string[] headerText, IDBHelper Helper, string sql, bool isFist)
        {
            DataTable dt = new DataTable();
            using (IDataReader odrIn = Helper.ExecuteReader(sql))
            {
                //while (odrIn.Read())
                //{
                    try
                    {
                        if (!isFist)
                        {
                            dataGridView.Columns.Add("Index", "序号");
                            for (int i = 0; i < headerText.Length; i++)
                            {
                                //dataGridView.Columns.Add(odrIn.GetName(i), columnsName[i]);
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.DataPropertyName = columnsName[i];
                                column.Name = columnsName[i];
                                column.HeaderText = headerText[i];
                                int index= dataGridView.Columns.Add(column);
                                dataGridView.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                            }
                            isFist = true;
                        }
                      //  int index = dataGridView.Rows.Add();
                      
                      //  dataGridView.Rows[index].Cells[0].Value = index;
                        //for (int y = 0; y < odrIn.FieldCount; y++)
                        //{
                        //    dataGridView.Rows[index].Cells[y + 1].Value = odrIn[y];
                        //}
                        dt.Load(odrIn);
                        //dt.Rows.Add(odrIn);
                        dataGridView.DataSource = dt;

                        for(int y =0 ;y<dataGridView.Rows.Count-1;y++)
                        {
                            dataGridView.Rows[y].Cells["Index"].Value = y;
                        }
                    }
                    catch (Exception meg)
                    {
                        MessageBox.Show(string.Format("调用函数DataGridViewBindingSource出错：{0}", meg));
                    }
                //}
  
                odrIn.Close();

                return isFist;
            }
        }
     
        /// <summary>
        /// 将读取的数据导入DataGridView，并添加一列序号数据。需要先配置DataGridView的列名
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="Helper"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool DataGridViewBindingSource(DataGridView dataGridView,  IDBHelper Helper, string sql)
        {
            DataTable dt = new DataTable();
            using (IDataReader odrIn = Helper.ExecuteReader(sql))
            {
                while (odrIn.Read())
                {
                    try
                    {
                        int index = dataGridView.Rows.Add();
                        dataGridView.Rows[index].Cells[0].Value = index;
                        for (int y = 0; y < odrIn.FieldCount; y++)
                        {
                            dataGridView.Rows[index].Cells[y + 1].Value = odrIn[y];
                        }
                    }
                    catch (Exception meg)
                    {
                        MessageBox.Show(string.Format("调用函数DataGridViewBindingSource出错：{0}", meg));
                    }
                }
                odrIn.Close();
            }
            return true;

        }

        /// <summary>
        /// 将combobox的数据源与DataGridView指定的列名关联
        /// </summary>
        /// <param name="comBox"></param>
        /// <param name="columnName"></param>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static string SetComboBoxData(ComboBox comBox, string columnName, DataGridView dataGridView)
        {

            return "找不到指定的列名";
        }

        ///生成SQL的Where时间功能，开始与结束之间的
        public static string GenTimeSpanSQL(DateTime start, DateTime end, string fieldName)
        {
            string sql = fieldName + ">'" + start.ToString("yyyyMMdd") + "000000'";
            sql = sql + "and " + fieldName + "<'" + end.ToString("yyyyMMdd") + "235959'";

            return sql;

        }
        ///生成SQL的Where时间功能，某一天
        public static string GenTimeSpanSQL(DateTime start,string fieldName)
        {
            string sql = fieldName + ">'" + start.ToString("yyyyMMdd") + "000000'";
            sql = sql + "and " + fieldName + "<'" + start.ToString("yyyyMMdd") + "235959'";

            return sql;

        }

        /// <summary>
        /// 生成SQL的Where时间功能，根据班组和日期返回
        /// </summary>
        /// <param name="shift"></param>
        /// <param name="dt"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GenTimeSpanSQL(string shift, DateTime dt, string fieldName)
        {
            string sql = fieldName + ">='" + dt.ToString("yyyyMMdd");


            if (shift == "全部")
            {
                sql = sql + "000000" + "'";
            }
            else if (shift == "早班")
            {
                sql = sql + "080000' and " + fieldName + "<'" + dt.ToString("yyyyMMdd") + "200000'";
            }
            else if (shift == "晚班")
            {
                DateTime dt2 = dt.AddDays(1);
                sql = fieldName + ">='" + dt.ToString("yyyyMMdd") + "200000' and " + fieldName + "<'" + dt2.ToString("yyyyMMdd") + "080000'";
            }
            else
            {
                return "无效的班组信息";
            }

            return sql;
        }


        /// <summary>
        /// 用于DataGridView初始化一般属性
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static string DataGridViewInit(DataGridView dataGridView)
        {
            //dataGridView.ReadOnly = true;
            //列标题属性
            dataGridView.AutoGenerateColumns = false;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;//标题背景颜色
            //设置列高
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; 
            dataGridView.ColumnHeadersHeight = 35;
            //设置标题内容居中显示;  
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            dataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //设置行属性
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.RowHeadersVisible = false;  //隐藏行标题
            //禁止用户改变DataGridView1所有行的行高  
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowTemplate.Height = 30;

            dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            return "";
        }
        public static int JudgeIntNull(object item)
        {
            int ret = 0;
            if (item == DBNull.Value)
            {
                return ret;
            }
            else
            {
                ret = Convert.ToInt32(item);
            }
            return ret;
        }
        public static string JudgeStrNull(object item)
        {
            string str = "";
            if (item == DBNull.Value)
            {
                return str;
            }
            else
            {
                str = item.ToString();
            }
            return str;
        }
        public static string changTextDrection(string str)
        {
            string retStr = "";
            str = str.Trim();
            for (int i = 0; i < str.Length; i++)
            {
                retStr += str[i] + "\r\n";
            }
            return retStr;
        }
    }
}
