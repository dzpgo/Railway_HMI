using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;

namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmPlanInMessage : FormBase
    {
        public FrmPlanInMessage()
        {
            InitializeComponent();
            this.Load += FrmPlanInMessage_Load;
        }

        void FrmPlanInMessage_Load(object sender, EventArgs e)
        {
            this.dateTimeInStart.Value = DateTime.Now.Date.AddDays(-1);
        }

        //初始化绑定默认关键词（此数据源可以从数据库取）
        List<string> listOnit = new List<string>();
        //输入key之后，返回的关键词
        List<string> listNew = new List<string>();

        //当前输入框内的信息变量(只有在输入框里输入信息是此变量才会有值,其他时候为默认空值)
        string CbxNowStr = "";
        //输入框内的前一个历史信息变量
        string CbxOldStr = "";

        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        public static Baosight.iSuperframe.Common.IDBHelper DBHelper
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
                        throw e;
                    }

                }
                return dbHelper;
            }
        }

        private void cbxPlanNoIn_DropDown(object sender, EventArgs e)
        {
            try
            {
                //检测默认数组内是否有值
                if (listOnit.Count > 0)
                {
                    //清空默认数组
                    listOnit.Clear();
                }
                listOnit.Add("全部");

                string sql = @"SELECT distinct PLAN_NO FROM UACS_PLAN_IN";
                if (!checkBox2.Checked)
                {
                    string timeStart = (DateTime.Now.Date.AddDays(-1)).ToString("yyyyMMddHHmmss");
                    sql += " WHERE PLAN_TIME  > '" + timeStart + "'";
                }
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["PLAN_NO"] != DBNull.Value)
                        {
                            listOnit.Add(rdr["PLAN_NO"].ToString());
                        }
                    }
                }

                BindComboBox();


                if (CbxNowStr == "")//确定是否鼠标点击时调用的下拉事件
                {
                    if (this.cbxPlanNoIn.Items.Count > 0)
                    {
                        this.cbxPlanNoIn.Items.Clear();
                    }
                    if (this.listNew.Count > 0)
                    {
                        this.listNew.Clear();
                    }
                    BindComboBox();
                }
                //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
                Cursor = Cursors.Default;
                //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
                this.cbxPlanNoIn.SelectionStart = this.cbxPlanNoIn.Text.Length;
            }
            catch (Exception er)
            {

                throw;
            }
        }

        private void BindComboBox()
        {
            //检测临时数组是否有值.初始化时临时数组为空
            if (listNew.Count > 0)
            {
                //清空COMBOBOX里的下拉框数据
                if (this.cbxPlanNoIn.Items.Count > 0)
                {
                    this.cbxPlanNoIn.Items.Clear();
                }
                //重新绑定新数据
                this.cbxPlanNoIn.Items.AddRange(listNew.ToArray());//绑定数据
                //指定下拉框显示项长度
                this.cbxPlanNoIn.MaxDropDownItems = 8;
                //清空临时数组
                this.listNew.Clear();
            }
            //默认数组内有值且当前输入框内容为空
            else if (listOnit.Count > 0 && CbxNowStr == "")
            {
                //清空COMBOBOX里的下拉框数据
                if (this.cbxPlanNoIn.Items.Count > 0)
                {
                    this.cbxPlanNoIn.Items.Clear();
                }
                //绑定默认数组数据给下拉框
                this.cbxPlanNoIn.Items.AddRange(listOnit.ToArray());//绑定数据
                //指定下拉框显示项长度
                this.cbxPlanNoIn.MaxDropDownItems = 8;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchOut_Click(object sender, EventArgs e)
        {
            string TimeInStart = this.dateTimeInStart.Value.ToString("yyyyMMdd000000");
            string TimeInEnd = this.dateTimeInEnd.Value.ToString("yyyyMMdd235959");
            string planNo = cbxPlanNoIn.Text.Trim().ToString();
            DbPlanInMessage(planNo, TimeInStart, TimeInEnd);
        }







        private void DbPlanInMessage(string _PlanNo, string _TimeStart, string _TimeEnd)
        {
            // 标记
            bool hasSetColumn = false;
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT ROW_NUMBER() OVER() as ROW_NO, 
                               A.OUTSTORE_ID,
                               A.INSTORE_ID,
                               A.ZZ_FLAG,
                               A.SHIP_SEQ_NO,
                               A.SHIP_NAME,
                               A.PLAN_NO,
                               A.HAVEN_ID,
                               A.TOTAL_NUM,
                               (A.TOTAL_GROSS_WEIGHT / 1000) AS TOTAL_GROSS_WEIGHT,
                               (A.TOTAL_NET_WEIGHT / 1000) AS TOTAL_NET_WEIGHT,
                               A.PLAN_STATUS,
                               A.PLAN_TIME,
                               A.CREATE_TIME ,
                               A.CREATER 
                               FROM  
                               UACS_PLAN_IN A ";
                if (checkBox1.Checked || _PlanNo == "全部")
                {
                    //if (_PlanNo == "全部" || _PlanNo == "")
                    {
                        sql += " WHERE A.PLAN_TIME  > '" + _TimeStart + "' and A.PLAN_TIME <'" + _TimeEnd + "'";
                    }
                    //else
                    //{
                    //    sql += " WHERE A.PLAN_NO = '" + _PlanNo + "' AND A.PLAN_TIME  > '" + _TimeStart + "' and  A.PLAN_TIME <'" + _TimeEnd + "'";
                    //}
                }
                else
                {
                    sql += " WHERE A.PLAN_NO = '" + _PlanNo + "' ";
                }

                sql += " ORDER BY A.PLAN_TIME DESC";

                dt.Clear();
                dt = new DataTable();

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
            catch (Exception er)
            {

                throw;
            }

            if (hasSetColumn == false)
            {
                dt.Columns.Add("ROW_NO", typeof(String));
                dt.Columns.Add("OUTSTORE_ID", typeof(String));
                dt.Columns.Add("INSTORE_ID", typeof(String));
                dt.Columns.Add("ZZ_FLAG", typeof(String));
                dt.Columns.Add("SHIP_SEQ_NO", typeof(String));
                dt.Columns.Add("SHIP_NAME", typeof(String));
                dt.Columns.Add("PLAN_NO", typeof(String));
                dt.Columns.Add("HAVEN_ID", typeof(String));
                dt.Columns.Add("TOTAL_NUM", typeof(String));
                dt.Columns.Add("TOTAL_GROSS_WEIGHT", typeof(String));
                dt.Columns.Add("TOTAL_NET_WEIGHT", typeof(String));
                dt.Columns.Add("PLAN_STATUS", typeof(String));
                dt.Columns.Add("PLAN_TIME", typeof(String));
                dt.Columns.Add("CREATE_TIME", typeof(String));
                dt.Columns.Add("CREATER", typeof(String));
            }

            dgvPlanIn.DataSource = dt;
        }


        private void DbPlanInDetail(string _PlanNo)
        {
            // 标记
            bool hasSetColumn = false;
            DataTable dt = new DataTable();
            try
            {
                string sql = @"select ROW_NUMBER() OVER() as ROW_NO, 
                              A.MAT_NO,
                              A.PLAN_NO,
                              A.CONFIRM_NO,
                              A.GOODS_CODE,
                              A.GOODS_NAME,
                              A.CONTRACT_ID,
                              A.STATUS,
                              A.RESERVE_TREATMENT_NO,
                              A.OUT_TIME,
                              A.OUT_MAT_NO,
                              B.WEIGHT,
                              B.WIDTH,
                              B.INDIA,
                              B.OUTDIA,
                              B.REC_TIME from UACS_PLAN_IN_DETAIL A left join 
                              UACS_YARDMAP_COIL B on A.MAT_NO = B.COIL_NO ";
                sql += " where A.PLAN_NO = '" + _PlanNo + "'";

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
            catch (Exception)
            {

                throw;
            }


            if (hasSetColumn == false)
            {
                dt.Columns.Add("ROW_NO", typeof(String));
                dt.Columns.Add("MAT_NO", typeof(String));
                dt.Columns.Add("PLAN_NO", typeof(String));
                dt.Columns.Add("CONFIRM_NO", typeof(String));
                dt.Columns.Add("GOODS_CODE", typeof(String));
                dt.Columns.Add("GOODS_NAME", typeof(String));
                dt.Columns.Add("CONTRACT_ID", typeof(String));
                dt.Columns.Add("STATUS", typeof(String));
                dt.Columns.Add("RESERVE_TREATMENT_NO", typeof(String));
                dt.Columns.Add("OUT_TIME", typeof(String));
                dt.Columns.Add("OUT_MAT_NO", typeof(String));
                dt.Columns.Add("WEIGHT", typeof(String));
                dt.Columns.Add("WIDTH", typeof(String));
                dt.Columns.Add("INDIA", typeof(String));
                dt.Columns.Add("OUTDIA", typeof(String));
                dt.Columns.Add("REC_TIME", typeof(String));
            }

            dgvPlanInDetail.DataSource = dt;

        }


        private void dgvPlanIn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string planNo = "";
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvPlanIn.Rows[e.RowIndex].Cells["PLAN_NO_IN"].Value != DBNull.Value)
                    {
                        planNo = dgvPlanIn.Rows[e.RowIndex].Cells["PLAN_NO_IN"].Value.ToString();
                        DbPlanInDetail(planNo);
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void cbxPlanNoIn_DropDownClosed(object sender, EventArgs e)
        {
            this.cbxPlanNoIn.Text = CbxOldStr;

            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;

            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            this.cbxPlanNoIn.SelectionStart = this.cbxPlanNoIn.Text.Length;
        }

        private void cbxPlanNoIn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cbxPlanNoIn.SelectedItem != null)
            {
                CbxOldStr = this.cbxPlanNoIn.SelectedItem.ToString();
            }
        }

        private void cbxPlanNoIn_TextUpdate(object sender, EventArgs e)
        {
            //暂时保存当前输入框的值
            CbxNowStr = this.cbxPlanNoIn.Text;
            CbxOldStr = CbxNowStr;//CbxNowStr在此方法结束时会被清空,因此需要此变量用作记录数据
            //关闭下拉框一次,下面会重新打开
            this.cbxPlanNoIn.DroppedDown = false;
            //清空COMBOBOX下拉框
            if (this.cbxPlanNoIn.Items.Count > 0)
            {
                //清空combobox
                this.cbxPlanNoIn.Items.Clear();
            }
            //清空临时数组数据
            if (listNew.Count > 0)
            {
                //清空listNew
                listNew.Clear();
            }
            //遍历全部备查数据向临时数组加入符合条件的数据
            foreach (var item in listOnit)
            {
                if (item.Contains(this.cbxPlanNoIn.Text.Trim()))
                {
                    //符合，插入ListNew
                    listNew.Add(item);
                }
            }
            //将临时数组内容绑定到控件,临时数组有值则加临时数组的数据,临时数组无值则不会添加任何数据
            BindComboBox();
            //确定要弹出下拉框的条件:输入框必须有值
            if (this.cbxPlanNoIn.Text.Trim() != "")
            {
                //确定要弹出下拉框的条件:下拉框列表必须有数据
                if (this.cbxPlanNoIn.Items.Count > 0)
                {
                    //确定要弹出下拉框的条件:下拉框首行数据与输入框内数据并不完全一致
                    if (this.cbxPlanNoIn.Text.Trim() != this.cbxPlanNoIn.Items[0].ToString().Trim())
                    {
                        //自动弹出下拉框
                        this.cbxPlanNoIn.DroppedDown = true;
                    }
                }
            }
            //将原先保存的输入框值重新给回输入框,因调用弹开下拉框列表时输入框值会被自动填充
            this.cbxPlanNoIn.Text = CbxNowStr;
            //清空CbxNowStr
            CbxNowStr = "";
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            this.cbxPlanNoIn.SelectionStart = this.cbxPlanNoIn.Text.Length;
        }

        private void cbxPlanNoIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearchOut_Click(null, null);
        }


    }
}
