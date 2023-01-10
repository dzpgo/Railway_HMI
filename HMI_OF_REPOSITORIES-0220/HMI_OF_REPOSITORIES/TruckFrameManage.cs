using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Authorization.Interface;
using Baosight.iSuperframe.Authorization;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.TagService.Controls;
using UACSUtility;

namespace FORMS_OF_REPOSITORIES
{
    public partial class TruckFrameManage : Baosight.iSuperframe.Forms.FormBase
    {
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();

        DataTable dt = new DataTable();

        DataTable dt1 = new DataTable();

        DataTable dt2 = new DataTable();

        bool hasSetColumn = false;

        //非空标志
        int flag = 0;

        //选择标志
        int flag1 = 0;

        public TruckFrameManage()
        {
            InitializeComponent();
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

        #region 页面加载
        private void TruckFrameManage_Load(object sender, EventArgs e)
        {
            try
            {
                //设置背景色
                this.panel1.BackColor = Color.FromArgb(242, 246, 252);
                this.splitContainer3.Panel2.BackColor = Color.FromArgb(242, 246, 252);
                this.splitContainer4.Panel2.BackColor = Color.FromArgb(242, 246, 252);
                UACSUtility.ViewHelper.DataGridViewInit(dataGridView1);
                UACSUtility.ViewHelper.DataGridViewInit(dataGridView2);
                //车辆类型下拉绑定
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("TypeValue");
                dt1.Columns.Add("TypeName");
                dt1.Rows.Add("", "全部");
                dt1.Rows.Add("01", "平型框架");
                dt1.Rows.Add("02", "冷卷框架");
                dt1.Rows.Add("03", "热卷框架");
                dt1.Rows.Add("04", "厚板框架");
                dt1.Rows.Add("05", "隔热框架");
                dt1.Rows.Add("06", "雨棚框架");

                //绑定查询条件下拉框数据
                this.comboBox1.DataSource = dt1;
                this.comboBox1.DisplayMember = "TypeName";
                this.comboBox1.ValueMember = "TypeValue";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 查询
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Inq();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void Inq()
        {
            try
            {
                string FRAME_TYPE_NAME = "";

                if(this.comboBox1.SelectedValue != null)
                {
                    FRAME_TYPE_NAME = this.comboBox1.SelectedValue.ToString().Trim();      //车辆类型
                }
 
                string sqlText = "";

                //根据车辆类型、挂车标识查出对应框架类型信息的数据
                sqlText = @"SELECT * FROM UACS_TRUCK_FRAME_DEFINE WHERE 1 = 1 ";

                if (FRAME_TYPE_NAME != "")
                {
                    sqlText += "AND FRAME_TYPE_NAME = '" + FRAME_TYPE_NAME + "' ";
                }

                //初始化
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        flag = 1;

                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (dt.Columns.Contains(rdr.GetName(i)) == true)
                            {
                                if (i == 0)
                                {
                                    dr[0] = false;
                                }
                                dr[i + 1] = rdr[i];
                            }
                            else
                            {
                                DataColumn dc = new DataColumn();

                                if (i == 0)
                                {
                                    DataColumn dc1 = new DataColumn();
                                    dc1.ColumnName = "SELECT";
                                    dt.Columns.Add(dc1);
                                    dr[0] = false;
                                }

                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);

                                dr[i + 1] = rdr[i];
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                    if (flag == 0)
                    {
                        this.textBox1.Text = "未查询到信息！";
                        return;
                    }
                    flag = 0;
                }

                //初始化各grid数据
                if (dataGridView1.DataSource != null)
                {
                    ((DataTable)dataGridView1.DataSource).Rows.Clear();
                }

                //赋值给datagridview
                dataGridView1.DataSource = dt;
                //dataGridView1.Columns[1].ReadOnly = true;

                this.textBox1.Text = "查询成功！";


                #region 超限提示
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells["Column5"].Value != null)
                    {
                        string length = dataGridView1.Rows[i].Cells["Column5"].Value.ToString();
                        length = length.Replace(" ", "");
                        int LenCount = length.Count();
                        if (LenCount > 12)
                        {
                            dataGridView1.Rows[i].Cells["Column5"].Style.BackColor = Color.Red;
                        }
                    }

                    if (dataGridView1.Rows[i].Cells["Column6"].Value != null)
                    {
                        string width = dataGridView1.Rows[i].Cells["Column6"].Value.ToString();
                        width = width.Replace(" ", "");
                        int WidCount = width.Count();
                        if (WidCount > 12)
                        {
                            dataGridView1.Rows[i].Cells["Column6"].Style.BackColor = Color.Red;
                        }
                    }
                   
                } 
                #endregion
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 申请
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string FRAME_TYPE_NO = textBox2.Text.Trim();  //框架/车辆类型编号

                if (FRAME_TYPE_NO == "")
                {
                    MessageBox.Show("请输入框架/车号！");
                    return;
                }
                else
                {
                    //发送tag点发车辆信息请求电文给l3
                    //平台配置
                    TruckFrameMsg.ServiceName = "iplature";
                    TruckFrameMsg.AutoRegist = true;

                    //添加tag点到数组
                    TagValues.Add("TRUCK_FRAME_MSG", null);
                    TruckFrameMsg.Attach(TagValues);
                    TruckFrameMsg.SetData("TRUCK_FRAME_MSG", FRAME_TYPE_NO);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 新增
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int count = dataGridView1.Rows.Count;    //所有行数
                string sqlSHUYU = "";

                for (int i = 0; i < count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")  //布尔型单元格是否被勾上
                    {
                        dataGridView1.Rows[i].Selected = true; //根据行号选中一整行

                        string FRAME_TYPE_NO = this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();                    //框架/车辆类型编号
                        string FRAME_TYPE_NAME = this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();                  //框架/车辆类型代码
                        string TRAILER_NO = this.dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();                       //挂车标识

                        int LENGTH = 0;
                        if (this.dataGridView1.Rows[i].Cells[4].Value.ToString().Trim() != "")
                        {
                            LENGTH = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[4].Value.ToString().Trim());             //长度(CM)
                        }
                        int WIDTH = 0;
                        if (this.dataGridView1.Rows[i].Cells[5].Value.ToString().Trim() != "")
                        {
                            WIDTH = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[5].Value.ToString().Trim());              //宽度(CM)
                        }
                        int HEIGHT = 0;
                        if (this.dataGridView1.Rows[i].Cells[6].Value.ToString().Trim() != "")
                        {
                            HEIGHT = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[6].Value.ToString().Trim());             //高度(CM)
                        }
                        int LOAD_CAPACITY = 0;
                        if (this.dataGridView1.Rows[i].Cells[7].Value.ToString().Trim() != "")
                        {
                            LOAD_CAPACITY = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[7].Value.ToString().Trim());      //载重(KG)
                        }
                        int SADDLE_NUM = 0;
                        if (this.dataGridView1.Rows[i].Cells[8].Value.ToString().Trim() != "")
                        {
                            SADDLE_NUM = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[8].Value.ToString().Trim());         //鞍座数
                        }
                        int SADDLE_INTERVAL = 0;
                        if (this.dataGridView1.Rows[i].Cells[9].Value.ToString().Trim() != "")
                        {
                            SADDLE_INTERVAL = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[9].Value.ToString().Trim());    //鞍座档距(CM)
                        }
                        int DISTANCE_HEAD = 0;
                        if (this.dataGridView1.Rows[i].Cells[10].Value.ToString().Trim() != "")
                        {
                            DISTANCE_HEAD = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[10].Value.ToString().Trim());     //鞍座距车头距离
                        }
                        int DISTANCE_LEFT = 0;
                        if (this.dataGridView1.Rows[i].Cells[11].Value.ToString().Trim() != "")
                        {
                            DISTANCE_LEFT = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[11].Value.ToString().Trim());     //鞍座距车左距离
                        }
                        int DISTANCE_RIGHT = 0;
                        if (this.dataGridView1.Rows[i].Cells[12].Value.ToString().Trim() != "")
                        {
                            DISTANCE_RIGHT = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[12].Value.ToString().Trim());    //鞍座距车右距离
                        }
                        int DISTANCE_1_2 = 0;
                        if (this.dataGridView1.Rows[i].Cells[13].Value.ToString().Trim() != "")
                        {
                            DISTANCE_1_2 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[13].Value.ToString().Trim());      //鞍座1/2之间距离
                        }
                        int DISTANCE_2_3 = 0;
                        if (this.dataGridView1.Rows[i].Cells[14].Value.ToString().Trim() != "")
                        {
                            DISTANCE_2_3 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[14].Value.ToString().Trim());      //鞍座2/3之间距离
                        }
                        int DISTANCE_3_4 = 0;
                        if (this.dataGridView1.Rows[i].Cells[15].Value.ToString().Trim() != "")
                        {
                            DISTANCE_3_4 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[15].Value.ToString().Trim());      //鞍座3/4之间距离
                        }
                        int DISTANCE_4_5 = 0;
                        if (this.dataGridView1.Rows[i].Cells[16].Value.ToString().Trim() != "")
                        {
                            DISTANCE_4_5 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[16].Value.ToString().Trim());      //鞍座4/5之间距离
                        }
                        int DISTANCE_5_6 = 0;
                        if (this.dataGridView1.Rows[i].Cells[17].Value.ToString().Trim() != "")
                        {
                            DISTANCE_5_6 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[17].Value.ToString().Trim());      //鞍座5/6之间距离
                        }
                        int DISTANCE_6_7 = 0;
                        if (this.dataGridView1.Rows[i].Cells[18].Value.ToString().Trim() != "")
                        {
                            DISTANCE_6_7 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[18].Value.ToString().Trim());      //鞍座6/7之间距离
                        }
                        int DISTANCE_7_8 = 0;
                        if (this.dataGridView1.Rows[i].Cells[19].Value.ToString().Trim() != "")
                        {
                            DISTANCE_7_8 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[19].Value.ToString().Trim());      //鞍座7/8之间距离
                        }
                        int DISTANCE_8_9 = 0;
                        if (this.dataGridView1.Rows[i].Cells[20].Value.ToString().Trim() != "")
                        {
                            DISTANCE_8_9 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[20].Value.ToString().Trim());      //偏移重量
                        }
                        int DISTANCE_9_10 = 0;
                        if (this.dataGridView1.Rows[i].Cells[21].Value.ToString().Trim() != "")
                        {
                            DISTANCE_9_10 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[21].Value.ToString().Trim());     //偏移重量
                        }
                        int DISTANCE_10_END = 0;
                        if (this.dataGridView1.Rows[i].Cells[22].Value.ToString().Trim() != "")
                        {
                            DISTANCE_10_END = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[22].Value.ToString().Trim());   //偏移重量
                        }
                        string FORBIDEN_FLAG = this.dataGridView1.Rows[i].Cells[23].Value.ToString().Trim();                   //封锁标记

                        //根据车号查找表里是否有重复的纪录
                        string sqlText = @"SELECT COUNT(*) AS NUM FROM UACS_TRUCK_FRAME_DEFINE WHERE FRAME_TYPE_NO = '" + FRAME_TYPE_NO + "' ";

                        //初始化
                        dt1.Clear();
                        dt1 = new DataTable();

                        using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                        {
                            while (rdr.Read())
                            {
                                DataRow dr = dt1.NewRow();
                                for (int j = 0; j < rdr.FieldCount; j++)
                                {
                                    if (!hasSetColumn)
                                    {
                                        DataColumn dc = new DataColumn();
                                        dc.ColumnName = rdr.GetName(j);
                                        dt1.Columns.Add(dc);
                                    }
                                    dr[j] = rdr[j];
                                }
                                hasSetColumn = true;
                                dt1.Rows.Add(dr);
                            }
                        }
                        hasSetColumn = false;

                        if (Convert.ToInt32(dt1.Rows[0]["NUM"].ToString().Trim()) > 0)
                        {
                            this.textBox1.Text = "输入的车号已存在，请重新输入！";
                            return;
                        }

                        //新增框架类型信息表的数据
                        sqlSHUYU = @"INSERT INTO UACS_TRUCK_FRAME_DEFINE (FRAME_TYPE_NO, FRAME_TYPE_NAME, TRAILER_NO, LENGTH, WIDTH, HEIGHT, LOAD_CAPACITY, SADDLE_NUM, ";
                        sqlSHUYU += "SADDLE_INTERVAL, DISTANCE_HEAD, DISTANCE_LEFT, DISTANCE_RIGHT, DISTANCE_1_2, DISTANCE_2_3, DISTANCE_3_4, DISTANCE_4_5, DISTANCE_5_6, ";
                        sqlSHUYU += "DISTANCE_6_7, DISTANCE_7_8, DISTANCE_8_9, DISTANCE_9_10, DISTANCE_10_END, FORBIDEN_FLAG) ";
                        sqlSHUYU += "VALUES ('" + FRAME_TYPE_NO + "', '" + FRAME_TYPE_NAME + "', '" + TRAILER_NO + "', '" + LENGTH + "', '" + WIDTH + "', '" + HEIGHT + "', ";
                        sqlSHUYU += " '" + LOAD_CAPACITY + "', '" + SADDLE_NUM + "', '" + SADDLE_INTERVAL + "', '" + DISTANCE_HEAD + "', '" + DISTANCE_LEFT + "', ";
                        sqlSHUYU += " '" + DISTANCE_RIGHT + "', '" + DISTANCE_1_2 + "', '" + DISTANCE_2_3 + "', '" + DISTANCE_3_4 + "', '" + DISTANCE_4_5 + "', ";
                        sqlSHUYU += " '" + DISTANCE_5_6 + "', '" + DISTANCE_6_7 + "', '" + DISTANCE_7_8 + "', '" + DISTANCE_8_9 + "', '" + DISTANCE_9_10 + "', ";
                        sqlSHUYU += " '" + DISTANCE_10_END + "', '" + FORBIDEN_FLAG + "') ";

                        DBHelper.ExecuteNonQuery(sqlSHUYU);

                        flag1 = flag1 + 1;
                    }
                }

                if (flag1 > 0)
                {
                    //刷新查询
                    Inq();

                    this.textBox1.Text = "新增框架类型信息成功！";

                    flag1 = 0;
                }
                else
                {
                    this.textBox1.Text = "请勾选需要操作的数据！";
                    return;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 修改
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int count = dataGridView1.Rows.Count;    //所有行数
                string sqlSHUYU = "";

                //检测所勾选grid的数据是否符合规范
                for (int i = 0; i < count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")  //布尔型单元格是否被勾上
                    {
                        flag = flag + 1;
                        break;
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")  //布尔型单元格是否被勾上
                    {
                        dataGridView1.Rows[i].Selected = true; //根据行号选中一整行

                        string FRAME_TYPE_NO = this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();                    //框架/车辆类型编号
                        string FRAME_TYPE_NAME = this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();                  //框架/车辆类型代码
                        string TRAILER_NO = this.dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();                       //挂车标识

                        int LENGTH = 0;
                        if (this.dataGridView1.Rows[i].Cells[4].Value.ToString().Trim() != "")
                        {
                            LENGTH = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[4].Value.ToString().Trim());             //长度(CM)
                        }
                        int WIDTH = 0;
                        if (this.dataGridView1.Rows[i].Cells[5].Value.ToString().Trim() != "")
                        {
                            WIDTH = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[5].Value.ToString().Trim());              //宽度(CM)
                        }
                        int HEIGHT = 0;
                        if (this.dataGridView1.Rows[i].Cells[6].Value.ToString().Trim() != "")
                        {
                            HEIGHT = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[6].Value.ToString().Trim());             //高度(CM)
                        }
                        int LOAD_CAPACITY = 0;
                        if (this.dataGridView1.Rows[i].Cells[7].Value.ToString().Trim() != "")
                        {
                            LOAD_CAPACITY = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[7].Value.ToString().Trim());      //载重(KG)
                        }
                        int SADDLE_NUM = 0;
                        if (this.dataGridView1.Rows[i].Cells[8].Value.ToString().Trim() != "")
                        {
                            SADDLE_NUM = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[8].Value.ToString().Trim());         //鞍座数
                        }
                        int SADDLE_INTERVAL = 0;
                        if (this.dataGridView1.Rows[i].Cells[9].Value.ToString().Trim() != "")
                        {
                            SADDLE_INTERVAL = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[9].Value.ToString().Trim());    //鞍座档距(CM)
                        }
                        int DISTANCE_HEAD = 0;
                        if (this.dataGridView1.Rows[i].Cells[10].Value.ToString().Trim() != "")
                        {
                            DISTANCE_HEAD = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[10].Value.ToString().Trim());     //鞍座距车头距离
                        }
                        int DISTANCE_LEFT = 0;
                        if (this.dataGridView1.Rows[i].Cells[11].Value.ToString().Trim() != "")
                        {
                            DISTANCE_LEFT = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[11].Value.ToString().Trim());     //鞍座距车左距离
                        }
                        int DISTANCE_RIGHT = 0;
                        if (this.dataGridView1.Rows[i].Cells[12].Value.ToString().Trim() != "")
                        {
                            DISTANCE_RIGHT = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[12].Value.ToString().Trim());    //鞍座距车右距离
                        }
                        int DISTANCE_1_2 = 0;
                        if (this.dataGridView1.Rows[i].Cells[13].Value.ToString().Trim() != "")
                        {
                            DISTANCE_1_2 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[13].Value.ToString().Trim());      //鞍座1/2之间距离
                        }
                        int DISTANCE_2_3 = 0;
                        if (this.dataGridView1.Rows[i].Cells[14].Value.ToString().Trim() != "")
                        {
                            DISTANCE_2_3 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[14].Value.ToString().Trim());      //鞍座2/3之间距离
                        }
                        int DISTANCE_3_4 = 0;
                        if (this.dataGridView1.Rows[i].Cells[15].Value.ToString().Trim() != "")
                        {
                            DISTANCE_3_4 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[15].Value.ToString().Trim());      //鞍座3/4之间距离
                        }
                        int DISTANCE_4_5 = 0;
                        if (this.dataGridView1.Rows[i].Cells[16].Value.ToString().Trim() != "")
                        {
                            DISTANCE_4_5 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[16].Value.ToString().Trim());      //鞍座4/5之间距离
                        }
                        int DISTANCE_5_6 = 0;
                        if (this.dataGridView1.Rows[i].Cells[17].Value.ToString().Trim() != "")
                        {
                            DISTANCE_5_6 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[17].Value.ToString().Trim());      //鞍座5/6之间距离
                        }
                        int DISTANCE_6_7 = 0;
                        if (this.dataGridView1.Rows[i].Cells[18].Value.ToString().Trim() != "")
                        {
                            DISTANCE_6_7 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[18].Value.ToString().Trim());      //鞍座6/7之间距离
                        }
                        int DISTANCE_7_8 = 0;
                        if (this.dataGridView1.Rows[i].Cells[19].Value.ToString().Trim() != "")
                        {
                            DISTANCE_7_8 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[19].Value.ToString().Trim());      //鞍座7/8之间距离
                        }
                        int DISTANCE_8_9 = 0;
                        if (this.dataGridView1.Rows[i].Cells[20].Value.ToString().Trim() != "")
                        {
                            DISTANCE_8_9 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[20].Value.ToString().Trim());      //偏移重量
                        }
                        int DISTANCE_9_10 = 0;
                        if (this.dataGridView1.Rows[i].Cells[21].Value.ToString().Trim() != "")
                        {
                            DISTANCE_9_10 = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[21].Value.ToString().Trim());     //偏移重量
                        }
                        int DISTANCE_10_END = 0;
                        if (this.dataGridView1.Rows[i].Cells[22].Value.ToString().Trim() != "")
                        {
                            DISTANCE_10_END = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[22].Value.ToString().Trim());   //偏移重量
                        }
                        string FORBIDEN_FLAG = this.dataGridView1.Rows[i].Cells[23].Value.ToString().Trim();                   //封锁标记

                        //更新框架类型信息表的数据
                        sqlSHUYU = @"UPDATE UACS_TRUCK_FRAME_DEFINE SET FRAME_TYPE_NAME = '" + FRAME_TYPE_NAME + "', TRAILER_NO = '" + TRAILER_NO + "', ";
                        sqlSHUYU += "LENGTH = '" + LENGTH + "', WIDTH =  '" + WIDTH + "', HEIGHT = '" + HEIGHT + "', LOAD_CAPACITY = '" + LOAD_CAPACITY + "', ";
                        sqlSHUYU += "SADDLE_NUM = '" + SADDLE_NUM + "', SADDLE_INTERVAL = '" + SADDLE_INTERVAL + "', DISTANCE_HEAD = '" + DISTANCE_HEAD + "', ";
                        sqlSHUYU += "DISTANCE_LEFT = '" + DISTANCE_LEFT + "', DISTANCE_RIGHT = '" + DISTANCE_RIGHT + "', DISTANCE_1_2 = '" + DISTANCE_1_2 + "', ";
                        sqlSHUYU += "DISTANCE_2_3 = '" + DISTANCE_2_3 + "', DISTANCE_3_4 = '" + DISTANCE_3_4 + "', DISTANCE_4_5 = '" + DISTANCE_4_5 + "', ";
                        sqlSHUYU += "DISTANCE_5_6 = '" + DISTANCE_5_6 + "', DISTANCE_6_7 = '" + DISTANCE_6_7 + "', DISTANCE_7_8 = '" + DISTANCE_7_8 + "', ";
                        sqlSHUYU += "DISTANCE_8_9 = '" + DISTANCE_8_9 + "', DISTANCE_9_10 = '" + DISTANCE_9_10 + "', DISTANCE_10_END = '" + DISTANCE_10_END + "', ";
                        sqlSHUYU += "FORBIDEN_FLAG = '" + FORBIDEN_FLAG + "' WHERE FRAME_TYPE_NO = '" + FRAME_TYPE_NO + "'";

                        DBHelper.ExecuteNonQuery(sqlSHUYU);

                        flag1 = flag1 + 1;
                    }
                }

                if (flag1 > 0)
                {
                    //刷新查询
                    Inq();

                    this.textBox1.Text = "修改框架类型信息成功！";

                    flag1 = 0;
                }
                else
                {
                    this.textBox1.Text = "请勾选需要操作的数据！";
                    return;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 删除
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int count = dataGridView1.Rows.Count;    //所有行数
                string sqlSHUYU = "";

                for (int i = 0; i < count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")  //布尔型单元格是否被勾上
                    {
                        dataGridView1.Rows[i].Selected = true; //根据行号选中一整行

                        string FRAME_TYPE_NO = this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();                    //框架/车辆类型编号

                        //根据框架/车辆类型编号删除框架类型信息表的数据
                        sqlSHUYU = @"DELETE FROM UACS_TRUCK_FRAME_DEFINE WHERE FRAME_TYPE_NO = '" + FRAME_TYPE_NO + "' ";

                        DBHelper.ExecuteNonQuery(sqlSHUYU);

                        flag1 = flag1 + 1;
                    }
                }

                if (flag1 > 0)
                {
                    //刷新查询
                    Inq();

                    this.textBox1.Text = "删除框架类型信息成功！";

                    flag1 = 0;
                }
                else
                {
                    this.textBox1.Text = "请勾选需要操作的数据！";
                    return;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        #region 确认覆盖
        private void button5_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 自动打钩事件

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0 && (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11 || e.ColumnIndex == 12 || e.ColumnIndex == 13 || e.ColumnIndex == 14 || e.ColumnIndex == 15 || e.ColumnIndex == 16 || e.ColumnIndex == 17 || e.ColumnIndex == 18 || e.ColumnIndex == 19 || e.ColumnIndex == 20 || e.ColumnIndex == 21 || e.ColumnIndex == 22 || e.ColumnIndex == 23))
            {
                dataGridView1.Rows[row].Cells[0].Value = true;
            }
        }
        #endregion

        #region 关联查询
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //UnionInq();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UnionInq();
        }
        private void UnionInq()
        {
            int count = 0;
            if (dataGridView1.CurrentRow != null)
            {
                count = dataGridView1.CurrentRow.Index;    //获取当前焦点行的行号
            }
            if (count > 0)
            {
                string FRAME_TYPE_NO = "";
                if (this.dataGridView1.Rows[count].Cells[1].Value != null)
                {
                    FRAME_TYPE_NO = this.dataGridView1.Rows[count].Cells[1].Value.ToString().Trim();   //框架/车辆类型编号
                }

                //根据车道编号查出对应停车点信息的数据
                string sqlText = @"SELECT * FROM UACS_TRUCK_FRAME_DEFINE_L3 WHERE FRAME_TYPE_NO = '" + FRAME_TYPE_NO + "' ";

                //初始化
                dt2.Clear();
                dt2 = new DataTable();
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt2.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (dt2.Columns.Contains(rdr.GetName(i)) == true)
                            {
                                if (i == 0)
                                {
                                    dr[0] = false;
                                }
                                dr[i + 1] = rdr[i];
                            }
                            else
                            {
                                DataColumn dc = new DataColumn();

                                if (i == 0)
                                {
                                    DataColumn dc1 = new DataColumn();
                                    dc1.ColumnName = "SELECT";
                                    dt2.Columns.Add(dc1);
                                    dr[0] = false;
                                }

                                dc.ColumnName = rdr.GetName(i);
                                dt2.Columns.Add(dc);

                                dr[i + 1] = rdr[i];
                            }
                        }
                        dt2.Rows.Add(dr);

                        //初始化各grid数据
                        if (dataGridView2.DataSource != null)
                        {
                            ((DataTable)dataGridView2.DataSource).Rows.Clear();
                        }

                        dataGridView2.DataSource = dt2;

                        dataGridView2.Columns[0].ReadOnly = false;
                        dataGridView2.Columns[1].ReadOnly = true;
                        dataGridView2.Columns[2].ReadOnly = true;
                        dataGridView2.Columns[3].ReadOnly = true;
                        dataGridView2.Columns[4].ReadOnly = true;
                        dataGridView2.Columns[5].ReadOnly = true;
                        dataGridView2.Columns[6].ReadOnly = true;
                        dataGridView2.Columns[7].ReadOnly = true;
                        dataGridView2.Columns[8].ReadOnly = true;
                        dataGridView2.Columns[9].ReadOnly = true;
                        dataGridView2.Columns[10].ReadOnly = true;
                        dataGridView2.Columns[11].ReadOnly = true;
                        dataGridView2.Columns[12].ReadOnly = true;
                        dataGridView2.Columns[13].ReadOnly = true;
                        dataGridView2.Columns[14].ReadOnly = true;
                        dataGridView2.Columns[15].ReadOnly = true;
                        dataGridView2.Columns[16].ReadOnly = true;
                        dataGridView2.Columns[17].ReadOnly = true;
                        dataGridView2.Columns[18].ReadOnly = true;
                        dataGridView2.Columns[19].ReadOnly = true;
                        dataGridView2.Columns[20].ReadOnly = true;
                        dataGridView2.Columns[21].ReadOnly = true;
                        dataGridView2.Columns[22].ReadOnly = true;
                        dataGridView2.Columns[23].ReadOnly = true;
                    }
                }
            }
        }
        #endregion

    }
}
