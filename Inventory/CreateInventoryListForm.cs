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

namespace Inventory
{
    public partial class CreateInventoryListForm : Form
    {
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();

        List<string> areaList = new List<string>();
        /// <summary>
        /// 当前选中行
        /// </summary>
        int CurRow = -1;
        public CreateInventoryListForm()
        {
            InitializeComponent();
            //默认选中普通
            rdbNor.Checked = true;           
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

        #region 选择库区 表格显示库区内每一列中红库位个数
        /// <summary>
        /// 选择库区 表格显示库区内每一列中红库位个数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string bayno = cbxStore.Text.Trim();
                InitCbxAreaValue(bayno);
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }
        #endregion

        #region 选择区域完毕  创建盘库单号，将区域写进数据库
        /// <summary>
        /// 选择区域完毕  创建盘库单号，将区域写进数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string isChoosed = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
                    string RowNo = dataGridView1[1, i].Value.ToString();
                    if (isChoosed == "True")
                    {
                        areaList.Add(RowNo);
                    }
                    else
                    {
                        areaList.Remove(RowNo);
                    }
                }

                //如果是初始化，需要人工确认，否则将所选区域全杀红
                if (rdbInit.Checked)
                {
                    //IsComfirmForm newform = new IsComfirmForm();
                    //if (newform.ShowDialog() != DialogResult.OK)
                    //{
                    //    txtResult.Text = "用户取消";
                    //    return;
                    //}
                }
                //判断数据完整性
                if (cbxStore.Text == "" || areaList.Count == 0)
                {
                    txtResult.Text = "请选择区域";
                    return;
                }

                //单号：库区+创建时间+类型（普通盘库/初始化）
                //只允许存在一张开放的单子
                string time = DateTime.Now.ToString();
                string store = cbxStore.Text;
                string sqlIfExist = @"SELECT * FROM UACS_PDA_INVENTORY_MAIN WHERE BAY_NO = '";
                sqlIfExist += store;
                sqlIfExist += "' AND EFFECT_FLAG = 'Y'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlIfExist))
                {
                    if (rdr.Read())
                    {
                        string Inventory_ID = rdr[0].ToString();
                        //找到记录，说明上一张单子有效 不允许再次添加
                        txtResult.Text = "单号:" + Inventory_ID;
                        labListNo.Text = Inventory_ID;

                        //组织初始化tag值
                        string tmplist = Inventory_ID + "|";
                        for (int i = 0; i < areaList.Count; i++)
                        {
                            //若为初始化，tag点通知后台 将区域内白库位杀红
                            tmplist += areaList[i] + "|";
                        }

                        if (tmplist != "")
                        {
                            tagDP.SetData("INVENTORY_INIT", tmplist);
                        }

                        areaList.Clear();
                    }
                    else
                    {
                        txtResult.Text = "未找到盘库单";
                        return;
                    }
                }

                WinClose();
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }
        //private void btnOK_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        for (int i = 0; i < dataGridView1.RowCount; i++)
        //        {
        //            string isChoosed = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
        //            string RowNo = dataGridView1[1, i].Value.ToString();
        //            if (isChoosed == "True")
        //            {
        //                areaList.Add(RowNo);
        //            }
        //            else
        //            {
        //                areaList.Remove(RowNo);
        //            }
        //        }


        //        //如果是初始化，需要人工确认，否则将所选区域全杀红
        //        if (rdbInit.Checked)
        //        {
        //            IsComfirmForm newform = new IsComfirmForm();
        //            if (newform.ShowDialog() != DialogResult.OK)
        //            {
        //                txtResult.Text = "用户取消";
        //                return;
        //            }
        //        }
        //        //判断数据完整性
        //        if (cbxStore.Text == ""||areaList.Count==0)
        //        {
        //            txtResult.Text = "请选择区域";
        //            return;
        //        }
        //        //单号：库区+创建时间+类型（普通盘库/初始化）
        //        //只允许存在一张开放的单子
        //        string time = DateTime.Now.ToString();
        //        string store = cbxStore.Text;
        //        string type = "";
        //        if (rdbNor.Checked)
        //        {
        //            type = "Nor";
        //        }
        //        else
        //        {
        //            type = "Init";
        //        }
        //        if (Inventory_ID == "")
        //        {
        //           Inventory_ID = time + store + type;
        //        }

        //        //同一时间 一跨只能存在一张开放的单子 先查询是否存在
        //        string sqlIfExist = @"SELECT * FROM UACS_PDA_INVENTORY_MAIN WHERE BAY_NO = '";
        //        sqlIfExist += store;
        //        sqlIfExist += "' AND EFFECT_FLAG = 'Y'";
        //        using (IDataReader rdr = DBHelper.ExecuteReader(sqlIfExist))
        //        {
        //            if (rdr.Read())
        //            {
        //                string listno = rdr[0].ToString();
        //                //找到记录，说明上一张单子有效 不允许再次添加
        //                txtResult.Text = "本跨仍有未关闭的盘库单，单号:" + listno;
        //            }
        //            else
        //            {
        //                labListNo.Text = Inventory_ID;
        //                //首先写盘库主表
        //                string sqlCreateList = @"INSERT INTO UACS_PDA_INVENTORY_MAIN (ID,EFFECT_FLAG,TYPE,BAY_NO) VALUES ('";
        //                sqlCreateList += Inventory_ID + "', 'Y' , '";
        //                if(type == "Nor")
        //                {
        //                    sqlCreateList+="1' , '";
        //                }
        //                else
        //                {
        //                    sqlCreateList+="0' , '";
        //                }
        //                sqlCreateList += store + "')";
        //                DBHelper.ExecuteReader(sqlCreateList);
        //                //根据单号写入盘库区域表
        //                string sqlInsArea= @"INSERT INTO UACS_PDA_INVENTORY_AREA (ID,ROW_NO) VALUES ('";
        //                sqlInsArea += Inventory_ID + "' ,'";
        //                string tmplist = Inventory_ID + "|";
        //                for (int i = 0; i < areaList.Count; i++)
        //                {
        //                    //若为初始化，tag点通知后台 将区域内白库位杀红
        //                    tmplist += areaList[i] + "|";
        //                    string tmp = sqlInsArea + areaList[i] + "')";
        //                    DBHelper.ExecuteReader(tmp);
        //                }
        //                labListNo.Text = Inventory_ID;
        //                txtResult.Text = "盘库单生成成功，单号：" + Inventory_ID;
        //                //若位初始化 通知后台杀库位
        //                if (type == "Init")
        //                {
        //                    if (tmplist != "")
        //                    {
        //                        tagDP.SetData("INVENTORY_INIT", tmplist);
        //                        MessageBox.Show("INVENTORY_INIT:" + tmplist);
        //                    }
        //                }
        //            }
        //            areaList.Clear();
        //        }

        //        WinClose();
        //    }
        //    catch (Exception ex)
        //    {
        //        txtResult.Text = ex.Message;
        //    }
        //}
        #endregion

        #region 保证类型有且单选
        /// <summary>
        /// 保证类型单选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbNor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNor.Checked)
            {
                rdbInit.Checked = false;
            }
            else
            {
                rdbInit.Checked = true;
            }
        }
        private void rdbInit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbInit.Checked)
            {
                rdbNor.Checked = false;
            }
            else
            {
                rdbNor.Checked = true;
            }
        }
        #endregion

        #region  单击 若选中 该区域加入list 反之从list从移除
        /// <summary>
        /// 单击 若选中 该区域加入list 反之从list从移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        int row=dataGridView1.CurrentCell.RowIndex;
        //        string isChoosed = dataGridView1.CurrentCell.FormattedValue.ToString();
        //        string RowNo = dataGridView1[1, row].Value.ToString();
        //        if (isChoosed == "True")
        //        {
        //            areaList.Add(RowNo);
        //        }
        //        else
        //        {
        //            areaList.Remove(RowNo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        txtResult.Text = ex.Message;
        //    }
        //}
        #endregion

        #region   画面初始化，配置TAG
        /// <summary>
        /// 画面初始化，配置TAG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInventoryListForm_Load(object sender, EventArgs e)
        {
            //设置背景色
            this.panel1.BackColor = UACS.ColorSln.FormBgColor;
            this.panel2.BackColor = UACS.ColorSln.FormBgColor;
            //tag控件配置
            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            //添加tag点
            TagValues.Clear();
            TagValues.Add("INVENTORY_INIT", null);
            tagDP.Attach(TagValues);

            // 初始化
            InitCbxStoreValue();
        }
        #endregion

        private void InitCbxStoreValue()
        {
            try
            {
                cbxStore.Items.Clear();

                // 查找所有可盘库跨
                string sql = @"SELECT Distinct(BAY_NO) FROM UACS_PDA_INVENTORY_MAIN";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        string bayNo = rdr[0].ToString();

                        if (!cbxStore.Items.Contains(bayNo))
                            cbxStore.Items.Add(bayNo);
                    }
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }

        private void InitCbxAreaValue(string bayNo)
        {
            try
            {
                cbxAreaName.Items.Clear();
                cbxAreaName.Items.Add("全部");

                // 查找所有可盘库跨
                string sql = String.Format("SELECT Distinct(AREA_NO) FROM UACS_YARDMAP_AREA_DEFINE WHERE AREA_NO LIKE '{0}%' AND AREA_TYPE = 0", 
                    bayNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        string areaNo = rdr[0].ToString();

                        if (!cbxAreaName.Items.Contains(areaNo))
                            cbxAreaName.Items.Add(areaNo);
                    }
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }

        /// <summary>
        /// 库区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAreaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 dataGridView1.Rows.Clear();
                ////首先从行列定义表中找到所有行
                 string bayno = cbxStore.Text.Trim();
                 string areaNo = cbxAreaName.Text.Trim();
                 string sqlGetRowNo = @"SELECT DISTINCT(COL_ROW_NO) FROM UACS_YARDMAP_ROWCOL_DEFINE ";
                 if (areaNo == "全部")
                 {
                    sqlGetRowNo += "WHERE";
                    for (int index = 0; index < cbxAreaName.Items.Count; index  ++)
                    {
                        string text = cbxAreaName.Items[index].ToString();
                        if (text == "全部")
                            continue;

                        sqlGetRowNo += String.Format(" AREA_NO = '{0}' ", text);

                        if (index != cbxAreaName.Items.Count -1)
                        {
                            sqlGetRowNo += "OR";
                        }
                    }
                 }
                 else
                 {
                     sqlGetRowNo += String.Format(" WHERE AREA_NO = '{0}' ", areaNo);
                 }
                
                 using (IDataReader rdr = DBHelper.ExecuteReader(sqlGetRowNo))
                 {
                     while (rdr.Read())
                     {
                        //寻找改行红库位个数
                        string COL_ROW_NO = rdr[0].ToString();
                        dataGridView1.Rows.Add(1);
                        int datacount = dataGridView1.Rows.Count - 1;
                        dataGridView1[1, datacount].Value = COL_ROW_NO;
                        dataGridView1[2, datacount].Value = "--";
                    }
                }
                 dataGridView1.ReadOnly = false;
            }
            catch (Exception ex)
            {
               txtResult.Text = ex.Message;
            }
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = checkBox1.Checked;
            }
        }

        /// <summary>
        /// 两秒后自动关闭
        /// </summary>
        private void WinClose()
        {
            System.Timers.Timer t = new System.Timers.Timer(2000);//实例化Timer类，设置时间间隔
            t.Elapsed += t_Elapsed;
            t.AutoReset = false;//设置是执行一次（false）还是一直执行(true)
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Close();
        }
       
    }
}
