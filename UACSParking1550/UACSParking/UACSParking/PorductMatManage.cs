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
using Baosight.iSuperframe.Authorization.Interface;
using Baosight.iSuperframe.Common;


using ParkingControlLibrary;
using ParkClassLibrary;

namespace UACSParking
{
    public partial class PorductMatManage : FormBase
    {
       // private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;
        IAuthorization auth = Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<Baosight.iSuperframe.Authorization.Interface.IAuthorization>()
        as Baosight.iSuperframe.Authorization.Interface.IAuthorization;
        
        //datagridview1
        DataTable dt = new DataTable();
        DataTable dt_selected = new DataTable();
        DataTable dt_Laser = new DataTable();
        DataTable dtNull = new DataTable();
        ToolTip toolTip1 = new ToolTip();
        string carHearDrection = "";
        
        //
        bool hasSetColumn = false;
        bool hasParkSize = false;
        bool isStowage = false;
        bool hasCar = true;  //车位无车

        int coilsWeight = 0;   //添加材料重量
        //当前停车位，画面跳转
        string parkingNO = "";
        //
        string[] dgvColumnsName = { "GROOVEID", "MAT_NO", "FROM_STOCK_NO", "TO_STOCK_NO", "BAY_NO" };
        string[] dgvHeaderText = { "槽号", "材料号", "起卷库位", "落卷库位", "跨别" };

        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        public PorductMatManage()
        {
            InitializeComponent();
            this.Load += PorductMatManage_Load;
        }
        public PorductMatManage(string parkNO)
        {
            InitializeComponent();
            this.Load += PorductMatManage_Load;
            cmbArea.Text = GetOperateArea(parkNO);
            parkingNO = parkNO;
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
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion
        
        void PorductMatManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
        //tag点事件处理
        void tagDP_DataChangedEvent(object sender, Baosight.iSuperframe.TagService.Interface.DataChangedEventArgs e)
        {
            if (isStowage == true)
            {
                if (cbbPacking.Text.Contains('Z'))
                {
                    reflreshParkingCoilstate(cbbPacking.Text.Trim());
                    RefreshOrderDgv(cbbPacking.Text.Trim());
                    return;
                }
            }
            RefreshHMI();
        }

        void PorductMatManage_Load(object sender, EventArgs e)
        {
            //DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");
            this.FormClosed += PorductMatManage_FormClosed;
            dataGridView2.CellFormatting += dataGridView2_CellFormatting;
            tagDP.DataChangedEvent += tagDP_DataChangedEvent;

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dt_selected.Columns.Add(dataGridView2.Columns[i].Name);
            }
             tagDP.ServiceName = "iplature";
             tagDP.AutoRegist = true;
             TagValues.Clear();
             TagValues.Add("EV_NEW_PARKING_CARLEAVE", null);
             TagValues.Add("EV_NEW_PARKING_MDL_OUT_CAL_JUDGE",null);
             tagDP.Attach(TagValues);

            //初始化dataGridview属性
             DataGridViewInit(dataGridView2);
             DataGridViewInit(dataGridView_LASER);

             DataGridViewInit(dgvOrder);
             CreatDgvHeader(dgvOrder, dgvColumnsName, dgvHeaderText);
             dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

             GetComboxOnParking();
             cbbPacking.Text = "";
             cbbPacking.SelectedIndexChanged += cbbPacking_SelectedIndexChanged;
            //开启定时器、
             timer1.Enabled = true;
             #region  tooltipshow
             // Create the ToolTip and associate with the Form container.

             // Set up the delays for the ToolTip.
             toolTip1.AutoPopDelay = 10000;
             toolTip1.InitialDelay = 1000;
             toolTip1.ReshowDelay = 500;
             // Force the ToolTip text to be displayed whether or not the form is active.
             toolTip1.ShowAlways = true;
             #endregion

             parkLaserOut1.LabClick += parkLaserOut1_LabClick;
             if (parkingNO!="")//画面跳转
             {
                 cbbPacking.Text = parkingNO;
             }
        }


        void cbbPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JumpToOtherForm(cbbPacking.Text))
            {
                btnRefresh_Click(null, null);
                return;
            }
            if (cbbPacking.Text.Trim() != "请选择" && cbbPacking.Text.Trim() != "" && cbbPacking.Text.Trim().Contains('Z'))
            {
                isStowage = false;
                hasCar = true;
                hasParkSize = false;
                RefreshHMI();
                btnOperateStrat.ForeColor = Color.White;
                btnOperatePause.ForeColor = Color.White;
            }
        }

        private string GetOperateArea(string parkNO)
        {
            string area = "";
            try
            {
                if (parkNO.Contains("Z5") && parkNO.Contains("A"))
                {
                    area = "成品7-1通道";
                }
                else if (parkNO.Contains("Z5") && parkNO.Contains("B"))
                {
                    area = "成品7-2通道";
                }
                else if (parkNO.Contains("Z5") && parkNO.Contains("C"))
                {
                    area = "成品7-3通道";
                }
                else
                {
                    area = "轧后库";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return area;
        }


        #region -----------------------------调用方法-------------------------------------
        /// <summary>
        /// 绑定停车位信息
        /// </summary>
        private void GetComboxOnParking()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            try
            {
                string str1 = "";
                string str2 = "";
                if (cmbArea.Text.Contains("7-1"))
                {
                    str1 = "Z5";
                    str2 = "A";
                }
                else if (cmbArea.Text.Contains("7-2"))
                {
                    str1 = "Z5";
                    str2 = "B";
                }
                else if (cmbArea.Text.Contains("7-3"))
                {
                    str1 = "Z5";
                    str2 = "C";
                }
                else
                {
                    str1 = "Z3";
                    str2 = "";
                }
                string sqlText = @"SELECT DISTINCT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_PARKINGSITE ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();

                        if (rdr["TypeName"].ToString().Contains(str1) && rdr["TypeName"].ToString().Contains(str2) || cmbArea.Text.Trim() == "")
                        {
                            dr["TypeValue"] = rdr["TypeValue"];
                            dr["TypeName"] = rdr["TypeName"];
                            dt.Rows.Add(dr);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            //绑定列表下拉框数据
            this.cbbPacking.DataSource = dt;
            this.cbbPacking.DisplayMember = "TypeName";
            this.cbbPacking.ValueMember = "TypeValue";
            cbbPacking.SelectedItem = 0;
            //cbbPacking.Text = "请选择";           //
        }

        /// <summary>
        /// 查询车号
        /// </summary>
        /// <param name="parking">停车位</param>
        private string GetTextOnCar(string parking)
        {
            try
            {
                string str = "";
                //txtCarNo.Text = "";
                string sql = string.Format("select CAR_NO,HEAD_POSTION ,TREATMENT_NO,STOWAGE_ID ,LASER_ACTION_COUNT from UACS_PARKING_STATUS where PARKING_NO = '{0}' ", parking);

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        txtTeratmentNO.Text = JudgeStrNull(rdr["TREATMENT_NO"]);
                        txtLaserCount.Text = JudgeStrNull(rdr["LASER_ACTION_COUNT"]);
                        txtStowageID.Text = JudgeStrNull(rdr["STOWAGE_ID"]);
                        if (rdr["CAR_NO"] != DBNull.Value)
                        {
                            str  = rdr["CAR_NO"].ToString();
                        }
                        else
                        {
                            str = "";
                        }

                        if (rdr["HEAD_POSTION"] != DBNull.Value)
                        {
                            if (rdr["HEAD_POSTION"].ToString() =="E")
                            {
                                 txtCarHeadToward.Text = "东";
                            }
                            else if (rdr["HEAD_POSTION"].ToString() == "W")
                            {
                                txtCarHeadToward.Text = "西";
                            }
                            else if (rdr["HEAD_POSTION"].ToString() == "S")
                            {
                                txtCarHeadToward.Text = "南";
                            }
                            else if (rdr["HEAD_POSTION"].ToString() == "N")
                            {
                                txtCarHeadToward.Text = "北";
                            }
                            carHearDrection = rdr["HEAD_POSTION"].ToString();
                        }
                        else
                        {
                            txtCarHeadToward.Text = "";
                            carHearDrection = "";
                        }
                    }
                    txtCarNo.Text = str;
                    return str;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return "";
            }
        }

        /// <summary>
        /// 获得配载ID
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        private string GetStowageID(string parking,string carNo)
        {
            try
            {
                string  str = "";
               // string sql = string.Format("select STOWAGE_ID from UACS_TRUCK_STOWAGE where FRAME_LOCATION = '{0}' order by STOWAGE_ID desc LIMIT 1 ", parking);
                string sql = string.Format(" select STOWAGE_ID from UACS_TRUCK_STOWAGE where rownum<=1 And FRAME_LOCATION='{0}' AND FRAME_NO = '{1}' order by STOWAGE_ID desc", parking, carNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["STOWAGE_ID"] != DBNull.Value)
                        {
                            str = rdr["STOWAGE_ID"].ToString();
                        }
                    }
                }
                return str ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return "";
            }
        }
        /// <summary>
        /// 获取配载信息
        /// </summary>
        /// <param name="stowageID"></param>
        /// <returns></returns>
        private bool  GetStowageDetail()
        {
            bool retu = false;
            try
            {            
                //查询是车位状态
                string carNo = GetTextOnCar(cbbPacking.Text.Trim());
                if (carNo != "" && cbbPacking.Text.Contains('Z') && cbbPacking.Text.Trim() != "请选择")
                {
                    string strStowageID = GetStowageID(cbbPacking.Text.Trim(), carNo); //"1451";// 
                    if (strStowageID != "")
                    {
                        string sql = @"select C.GROOVEID,C.MAT_NO as COIL_NO2,A.LOT_NO as LOT_NO,C.X_CENTER as GROOVE_ACT_X ,C.Y_CENTER AS GROOVE_ACT_Y,C.Z_CENTER AS GROOVE_ACT_Z, B.WEIGHT, B.OUTDIA ,D.STOCK_NO, D.LOCK_FLAG,B.PACK_FLAG  from UACS_TRUCK_STOWAGE_DETAIL C ";
                        sql += " LEFT JOIN  UACS_PLAN_L3PICK A ON C.MAT_NO = A.COIL_NO ";
                        sql += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
                        sql += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE D ON C.MAT_NO = D.MAT_NO ";
                        sql += string.Format(" where STOWAGE_ID = '{0}' order by C.GROOVEID", strStowageID);
                        DataGridViewBindingSource(dataGridView2, sql);
                        //没找到数据，返回
                        if (((DataTable)dataGridView2.DataSource).Rows.Count==0)
                        {
                            return retu;
                        }
                        retu = true;
                        return retu;
                    }
                }
                dtNull.Clear();
                dataGridView2.DataSource = dtNull;
                //isStowage = true;
                return retu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return retu;
            }
        }

        /// <summary>
        /// 绑定材料位置信息
        /// </summary>
        private void BindMatStock(string packing, string planNo = null)
        {
            if (!packing.Contains('Z') || packing.Trim() =="")
            {
                return;                
            }
            dt.Clear();

            //if (this.cbbPacking.SelectedValue == null)
            //{
            //    return;
            //}


            //string pickNo = this.cbbPacking.SelectedValue.ToString();

            //发货(根据库位状态和封锁标记只查出可吊的钢卷)
            //string sqlText = @"SELECT 0 AS CHECK_COLUMN, A.COIL_NO, A.PICK_NO as PLAN_NO,A.DESTINATION, G.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, ";
            //sqlText += "B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.STEEL_GRANDID, J.X_CENTER, J.Y_CENTER, J.Z_CENTER ,";
            //sqlText += "B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_PLAN_L3PICK A ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_COIL B ON A.COIL_NO = B.COIL_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON C.MAT_NO = A.COIL_NO AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_STOCK I ON I.STOCK_NO = C.STOCK_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_DEFINE J ON J.SADDLE_NO = I.SADDLE_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_STOCK D ON C.STOCK_NO = D.STOCK_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_DEFINE E ON D.SADDLE_NO = E.SADDLE_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE F ON E.COL_ROW_NO = F.COL_ROW_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_AREA_DEFINE G ON F.AREA_NO = G.AREA_NO ";

            //string sqlText = @"SELECT 0 AS CHECK_COLUMN, C.MAT_NO AS COIL_NO, A.PICK_NO as PLAN_NO, A.DESTINATION, C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, ";
            //sqlText += "B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.STEEL_GRANDID, C.X_CENTER, C.Y_CENTER, C.Z_CENTER ,";
            //sqlText += "B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_YARDMAP_STOCK_DEFINE C ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
            //sqlText += "LEFT JOIN  UACS_PLAN_L3PICK A ON C.MAT_NO = A.COIL_NO ";
            //sqlText += "WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
            //sqlText += "AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL";
            //sqlText += " order by C.STOCK_NO DESC";

            //dataGridView1.Columns["PACK_FLAG"].Visible = false; xx
            //dataGridView1.Columns["SLEEVE_WIDTH"].Visible = false; xxx
            //dataGridView1.Columns["COIL_OPEN_DIRECTION"].Visible = false; xxx
            //dataGridView1.Columns["NEXT_UNIT_NO"].Visible = false; xxx
            //dataGridView1.Columns["STEEL_GRANDID"].Visible = false;   xx
            //dataGridView1.Columns["ACT_WEIGHT"].Visible = false;
            //dataGridView1.Columns["ACT_WIDTH"].Visible = false;
            //dataGridView1.Columns["DESTINATION"].Visible = false; xx

            string sqlText_All = @"  SELECT 0 AS CHECK_COLUMN, C.MAT_NO AS COIL_NO, A.PICK_NO as PLAN_NO,  C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,";
            sqlText_All += "    D.X_CENTER, D.Y_CENTER, C.Z_CENTER ,";
            sqlText_All += " B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_YARDMAP_STOCK_DEFINE C ";
            sqlText_All += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
            sqlText_All += " LEFT JOIN  UACS_PLAN_L3PICK A ON C.MAT_NO = A.COIL_NO ";
            sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON C.STOCK_NO = E.STOCK_NO ";
            sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO ";

            if (planNo == null)
            {
                sqlText_All += " WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
                sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL  ";
                sqlText_All += " order by C.STOCK_NO DESC ";
            }
            else if (planNo.Trim().Length > 4)
            {
                sqlText_All += " WHERE  C.BAY_NO  like '" +packing.Substring(0, 3) + "%' ";
                sqlText_All += " AND A.PICK_NO  like '" + "%" + planNo + "%' ";
                sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL  ";
                sqlText_All += " order by C.STOCK_NO DESC ";
            }
            else
            {
                sqlText_All += " WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
                sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL  ";
                sqlText_All += " order by C.STOCK_NO DESC ";
            }

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_All))
            {
                while (rdr.Read())
                {
                    if (!hasSetColumn)
                    {
                        setDataColumn(dt, rdr);
                    }
                    hasSetColumn = true;
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dr[i] = rdr[i];
                    }
                    dt.Rows.Add(dr);
                }
            }

            #region 转库计划
            //转库(根据库位状态和封锁标记只查出可吊的钢卷)
            //sqlText = @"SELECT 0 AS CHECK_COLUMN, A.COIL_NO,A.PLAN_NO, G.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, ";
            //sqlText += "B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.STEEL_GRANDID, ";
            //sqlText += "B.ACT_WEIGHT, B.ACT_WIDTH, C.X_CENTER, C.Y_CENTER, C.Z_CENTER FROM UACS_PLAN_L3TRANS A ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_COIL B ON A.COIL_NO = B.COIL_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON C.MAT_NO = A.COIL_NO AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_STOCK D ON C.STOCK_NO = D.STOCK_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_DEFINE E ON D.SADDLE_NO = E.SADDLE_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE F ON E.COL_ROW_NO = F.COL_ROW_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_AREA_DEFINE G ON F.AREA_NO = G.AREA_NO ";
            //sqlText += "WHERE A.PLAN_NO = '{0}' ";
            //sqlText = string.Format(sqlText, pickNo);
            //using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            //{
            //    while (rdr.Read())
            //    {
            //        if (!hasSetColumn)
            //        {
            //            setDataColumn(dt, rdr);
            //        }
            //        hasSetColumn = true;
            //        DataRow dr = dt.NewRow();
            //        for (int i = 0; i < rdr.FieldCount; i++)
            //        {
            //            dr[i] = rdr[i];
            //        }
            //        dt.Rows.Add(dr);
            //    }
            // } 
            #endregion

            //this.dataGridView1.DataSource = dt;
            //隐藏列
            //dataGridView1.Columns["PACK_FLAG"].Visible = false;
            //dataGridView1.Columns["SLEEVE_WIDTH"].Visible = false;
            //dataGridView1.Columns["COIL_OPEN_DIRECTION"].Visible = false;
            //dataGridView1.Columns["NEXT_UNIT_NO"].Visible = false;
            //dataGridView1.Columns["STEEL_GRANDID"].Visible = false;
            //dataGridView1.Columns["ACT_WEIGHT"].Visible = false;
            //dataGridView1.Columns["ACT_WIDTH"].Visible = false;
            //dataGridView1.Columns["DESTINATION"].Visible = false; 
        }
        /// <summary>
        /// 设置table的列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rdr"></param>
        private void setDataColumn(DataTable dt, IDataReader rdr)
        {
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = rdr.GetName(i);
                dt.Columns.Add(dc);
            }
            //

        }

        /// <summary>
        /// 激光扫描数据
        /// </summary>
        /// <returns></returns>
        private bool RefreshHMILaserOutData()
        {
            bool bResut = false;
            try
            {
                string parkingNo = "";
                string TREATMENT_NO = "";
                long LASER_ACTION_COUNT = 0;

                // 读取车牌数据
                string truckNo = txtCarNo.Text.Trim();      //车号
                if (truckNo == "")
                {
                    return bResut;
                }

                // 车号对应的停车位数据
                string sqlText = @"SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE CAR_NO = '{0}'";
                sqlText = string.Format(sqlText, truckNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {
                        parkingNo = rdr["PARKING_NO"].ToString();
                    }
                }
                // this.lbParkingNo.Text = parkingNo;

                //先获取车头方向配置表里的车长方向坐标轴和趋势
                string AXES_CAR_LENGTH = "";
                string TREND_TO_TAIL = "";
                string sqlText_head = @"SELECT AXES_CAR_LENGTH, TREND_TO_TAIL FROM UACS_HEAD_POSITION_CONFIG WHERE HEAD_POSTION IN ";
                sqlText_head += "(SELECT HEAD_POSTION FROM UACS_PARKING_STATUS WHERE PARKING_NO = '{0}') AND PARKING_NO = '{0}'";
                sqlText_head = string.Format(sqlText_head, parkingNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_head))
                {
                    if (rdr.Read())
                    {
                        AXES_CAR_LENGTH = rdr["AXES_CAR_LENGTH"].ToString();
                        TREND_TO_TAIL = rdr["TREND_TO_TAIL"].ToString();
                    }
                }

                string sqlorder = "";
                if (AXES_CAR_LENGTH == "X" && TREND_TO_TAIL == "INC")
                {
                    sqlorder = "ORDER BY GROOVE_ACT_X ";
                }
                else if (AXES_CAR_LENGTH == "X" && TREND_TO_TAIL == "DES")
                {
                    sqlorder = "ORDER BY GROOVE_ACT_X DESC";
                }
                else if (AXES_CAR_LENGTH == "Y" && TREND_TO_TAIL == "INC")
                {
                    sqlorder = "ORDER BY GROOVE_ACT_Y ";
                }
                else if (AXES_CAR_LENGTH == "Y" && TREND_TO_TAIL == "DES")
                {
                    sqlorder = "ORDER BY GROOVE_ACT_Y DESC";
                }

                //从停车位表里取出处理号和激光扫描次数
                sqlText = @"SELECT TREATMENT_NO, LASER_ACTION_COUNT FROM UACS_PARKING_STATUS WHERE PARKING_NO='{0}' ";
                sqlText = string.Format(sqlText, parkingNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        TREATMENT_NO = rdr["TREATMENT_NO"].ToString();
                        LASER_ACTION_COUNT = Convert.ToInt64(rdr["LASER_ACTION_COUNT"].ToString());
                    }
                }

                //string GROOVE_ACT_X = "";
                //string GROOVE_ACT_Y = "";
                //string GROOVE_ACT_Z = "";
                //string GROOVEID = "";
                dt_selected.Clear();

                //从出库激光表里取出激光扫描数据
                sqlText = @"SELECT GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z, GROOVEID FROM UACS_LASER_OUT ";
                sqlText += "WHERE TREATMENT_NO = '{0}' AND LASER_ACTION_COUNT = '{1}' ";
                sqlText += sqlorder;
                sqlText = string.Format(sqlText, TREATMENT_NO, LASER_ACTION_COUNT);

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    //while (rdr.Read())
                    //{
                    //    GROOVE_ACT_X = rdr["GROOVE_ACT_X"].ToString();
                    //    GROOVE_ACT_Y = rdr["GROOVE_ACT_Y"].ToString();
                    //    GROOVE_ACT_Z = rdr["GROOVE_ACT_Z"].ToString();
                    //    GROOVEID = rdr["GROOVEID"].ToString();
                    //    dt_selected.Rows.Add(GROOVEID, "", "", "", "", GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z);
                    //}
                    dt_selected.Load(rdr);
                }
                this.dataGridView2.DataSource = dt_selected;

                bResut = true;
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }

            return bResut;
        }

        /// <summary>
        /// 与配载信息匹配
        /// </summary>
        /// <param name="treatmentNo"></param>
        /// <param name="LASER_ACTION_COUNT"></param>
        /// <returns></returns>
        private bool CheckWithLaserOutData(string treatmentNo, long LASER_ACTION_COUNT)
        {
            bool bResult = false;
            string sqlText;

            try
            {
                // 获取最新激光扫描数据（从出库激光表里取出激光扫描数据）
                Dictionary<string, LASER_OUT_DATA> dictGrooveIDLaserOut = new Dictionary<string, LASER_OUT_DATA>();
                sqlText = @"SELECT GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z, GROOVEID FROM UACS_LASER_OUT ";
                sqlText += "WHERE TREATMENT_NO = '{0}' AND LASER_ACTION_COUNT = '{1}' ";
                sqlText = string.Format(sqlText, treatmentNo, LASER_ACTION_COUNT);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        LASER_OUT_DATA laseroutData;
                        laseroutData.GROOVE_ACT_X = rdr["GROOVE_ACT_X"].ToString();
                        laseroutData.GROOVE_ACT_Y = rdr["GROOVE_ACT_Y"].ToString();
                        laseroutData.GROOVE_ACT_Z = rdr["GROOVE_ACT_Z"].ToString();
                        laseroutData.GROOVEID = rdr["GROOVEID"].ToString();

                        dictGrooveIDLaserOut[laseroutData.GROOVEID] = laseroutData;
                    }
                }

                // 与画面选定的配载信息比对
                int nCountCoil = 0;
                int nCountChecked = 0;
                for (int i = 0; i < dt_selected.Rows.Count; i++)
                {
                    if (i < 30)
                    {
                        string coilNO = dt_selected.Rows[i]["COIL_NO2"].ToString().Trim();
                        if (coilNO.Length != 0)
                        {
                            nCountCoil++;

                            // 配过卷的
                            string GROOVEID = dt_selected.Rows[i]["GROOVEID"].ToString();
                            string GROOVE_X = dt_selected.Rows[i]["GROOVE_ACT_X"].ToString();
                            string GROOVE_Y = dt_selected.Rows[i]["GROOVE_ACT_Y"].ToString();
                            string GROOVE_Z = dt_selected.Rows[i]["GROOVE_ACT_Z"].ToString();

                            if (dictGrooveIDLaserOut.ContainsKey(GROOVEID))
                            {
                                LASER_OUT_DATA laserout = dictGrooveIDLaserOut[GROOVEID];

                                // 画面数据与选择数据匹配
                                if (laserout.GROOVE_ACT_X == GROOVE_X &&
                                    laserout.GROOVE_ACT_Y == GROOVE_Y &&
                                    laserout.GROOVE_ACT_Z == GROOVE_Z)
                                {
                                    nCountChecked++;
                                }
                            }
                        }
                    }
                }
                // 数据与后台均匹配
                if (nCountChecked == nCountCoil && nCountCoil != 0)
                    bResult = true;
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }

            return bResult;
        }
        #endregion



        #region -----------------------------控件事件-------------------------------------




        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isStowage = false;
            hasCar = true;
            hasParkSize = false;
            RefreshHMI();
        }
        /// <summary>
        /// 刷新画面
        /// </summary>
        private void RefreshHMI()
        {
            bool stopRefresh = false;
            if (isStowage)
            {
                return;
            }
            if (cbbPacking.Text.Trim().Contains('Z'))
            {
                //刷新车位信息
                GetTextOnCar(cbbPacking.Text.Trim());
                //查询车位状态
                GetOperateStatus(cbbPacking.Text.Trim());
                string strPacking = cbbPacking.Text.Trim().Substring(0, 3);
                StringBuilder sbb = new StringBuilder(strPacking);
                sbb.Append("-1");
                BindMatStock(sbb.ToString());

                //刷新车位
                GetParkInfo();
                if (!hasCar)
                {
                    stopRefresh = txtTeratmentNO.Text.Contains('Z');
                    hasCar = stopRefresh;
                    return;
                }
                //刷新指令表
                RefreshOrderDgv(cbbPacking.Text.Trim());
                //刷新激光图像配载数据
                LoadLaserInfo(cbbPacking.Text.Trim(), parkLaserOut1);
                //刷新激光数据
                Inq_Laser(txtTeratmentNO.Text, txtLaserCount.Text);

                //获得配载数据
                GetStowageDetail();
                //if (!GetStowageDetail())
                //{
                //    //dt_selected.Clear();
                //    this.dataGridView2.DataSource = dtNull;
                //    RefreshHMILaserOutData();
                //}
                //计算重量
                CalculteWeight();
                //刷新车上卷状态
                reflreshParkingCoilstate(cbbPacking.Text.Trim());

                stopRefresh = txtTeratmentNO.Text.Contains('Z');
                hasCar = stopRefresh;
                //txtDebug.Text = hasCar.ToString();//没车只刷一次
            }
        }
        private void CalculteWeight()
        {
            txtCoilsWeight.Text = "";
            if (txtCoilsWeight.Text=="" && dataGridView2.Rows.Count!=0)
            {
                int n1 = 0;
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if (item.Cells["WEIGHT2"].Value!= null)
                    {
                        n1 += JudgeIntNull(item.Cells["WEIGHT2"].Value);
                    }
                }
                txtCoilsWeight.Text = string.Format("{0} /公斤", n1.ToString());
                if (n1 > 500000)
                    txtCoilsWeight.BackColor = Color.Red;
                else
                    txtCoilsWeight.BackColor = Color.White;
            }
        }
        
        /// <summary>
        /// 定位到指定的行
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="searchString"></param>
        /// <param name="columnName"></param>
        private void SelectDataGridViewRow(DataGridView dgv, string searchString, string columnName)
        {
            try
            {
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (dgvRow.Cells[columnName].Value != null)
                    {
                        if (dgvRow.Cells[columnName].Value.ToString() == searchString)
                        {
                            dgv.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                            dgvRow.Cells[columnName].Selected = true;
                            dgv.CurrentCell = dgvRow.Cells[columnName];
                            return;
                        }
                    }
                }
                MessageBox.Show(string.Format("没有找到指定的钢卷：{0}", searchString));
            }

            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }


        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string matNo = "";  //材料号
            //    string pickNo = ""; //提单号
            //    string coilweight = "";
            //    string coilOutdia = "";
            //    int x_distence = 0;  //钢卷半径距离


            //    //检测所选材料是否为单选
            //    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            //    {
            //        //string  hasChecked = this.dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value.ToString();  //打钩标记
            //        bool hasChecked = (bool)dataGridView1.Rows[i].Cells["CHECK_COLUMN"].EditedFormattedValue;
            //        if (hasChecked )
            //        {
            //            matNo = dataGridView1.Rows[i].Cells["COIL_NO"].Value.ToString();            //材料号
            //            pickNo = dataGridView1.Rows[i].Cells["PLAN_NO"].Value.ToString();            //计划号
            //            coilweight = dataGridView1.Rows[i].Cells["WEIGHT"].Value.ToString();            //重量
            //            coilOutdia = dataGridView1.Rows[i].Cells["OUTDIA"].Value.ToString();            //外径

            //            count++;
            //            //消除打钩
            //            this.dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value = 0;
            //            break;
            //        }
            //    }
            //    if (count > 1)
            //    {
            //        //初始化
            //        count = 0;
            //        MessageBox.Show("提单中的材料选择信息只能单选！");
            //        return;
            //    }
            //    //初始化
            //    //count = 0;
            //    //检测配载材料是否为单选
            //    //for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            //    //{
            //    //    string hasChecked = this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value.ToString();  //打钩标记
            //    //    if (hasChecked == "1")
            //    //    {
            //    //        count++;
            //    //    }
            //    //}
            //    //if (count > 1)
            //    //{
            //    //    //初始化
            //    //    count = 0;
            //    //    MessageBox.Show("社会车辆配载材料信息选择只能单选！");
            //    //    return;
            //    //}

            //    //判断材料号是否相同
            //    foreach (DataGridViewRow item in dataGridView2.Rows)
            //    {
            //        if (item.Cells["COIL_NO2"].Value.ToString() != "")
            //        {
            //            if (item.Cells["COIL_NO2"].Value.ToString() == matNo)
            //            {                            
            //                MessageBox.Show(string.Format("该材料:{0}已经选择，请重新选择材料号！", matNo));
            //                count = 0;
            //                return;
            //            }
            //        }
            //    }

            //    //初始化
            //    count = 0;
            //    int distenceTem = 0;
            //    for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            //    {
            //        //string hasChecked2 = this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value.ToString();  //打钩标记
            //        bool  hasChecked2= (bool)dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].EditedFormattedValue;
            //        if (hasChecked2)
            //        {
                        
            //            //先判断重量、半径
            //            //显示钢卷中重量
            //            //coilsWeight += GetCoilWeight(matNo);
            //            if (coilweight!="")
            //            coilsWeight +=Convert.ToInt32( coilweight);
            //            if (coilsWeight >= 50000)//大于50吨报警
            //            {
            //                txtCoilsWeight.BackColor = Color.Red;
            //                //return;                               
            //            }
            //            else if (0 < coilsWeight && coilsWeight<50000)
            //            {
            //                txtCoilsWeight.BackColor = Color.White;
            //            }
            //            //显示钢卷中心距离
            //            //if (x_coil1 == 0 && x_coil2 == 0)
            //            //{
            //            //   x_coil1= GetCoilRadius(matNo);
            //            //}
            //            //else if (x_coil1 > 0 && x_coil2 == 0)
            //            //{
            //            //    x_coil2 = GetCoilRadius(matNo);
            //            //}
            //            //if (x_coil1!=0 && x_coil2!=0)
            //            //{
            //            //    distenceTem = GetgrooveDistence() - x_coil1 - x_coil2;
            //            //    if (distenceTem < 10 )
            //            //    {
            //            //        coilDistance.Text = distenceTem.ToString();
            //            //        coilDistance.BackColor = Color.Red;
            //            //        MessageBox.Show(string.Format("钢卷中心距离为:{0},小于安全距离10mm,请重新选择。", distenceTem));
            //            //        return;
            //            //    }
            //            //    else if (distenceTem > 10)
            //            //    {
            //            //        coilDistance.Text = distenceTem.ToString();
            //            //        coilDistance.BackColor = Color.White;
            //            //    }
            //            //}
  

            //            this.dataGridView2.Rows[i].Cells["COIL_NO2"].Value = matNo;
            //            this.dataGridView2.Rows[i].Cells["PICK_NO"].Value = pickNo;
            //            this.dataGridView2.Rows[i].Cells["WEIGHT2"].Value = coilweight;
            //            this.dataGridView2.Rows[i].Cells["OUTDIA2"].Value = coilOutdia;


            //            //消除打钩
            //            this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value = 0;



            //        }

            //    }
            //   // this.dataGridView2.DataSource = dt_selected;
            //    //MessageBox.Show(dt_selected.Rows.Count.ToString());


            //    txtCoilsWeight.Text = string.Format("{0} /公斤", coilsWeight);

            //}
            //catch (Exception er)
            //{
            //    MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            //}
        }
        

        /// <summary>
        /// 停车位变化刷新激光数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            //改在车位刷新
            if (txtCarNo.Text.Trim().Length > 2)
            {
                //判断是否已经配载
                if (cbbPacking.Text.Trim().Contains('Z'))
                {
                    if (!GetStowageDetail())
                    {
                        //RefreshHMILaserOutData();
                    }
                }
            }

        }     

        #region 车到达
        /// <summary>
        /// 车到达
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCarEnter_Click(object sender, EventArgs e)
        {
            if (GetTextOnCar(cbbPacking.Text.Trim()) == "")
            {
                FrmCarEntry frm = new FrmCarEntry();
                frm.PackingNo = cbbPacking.Text.Trim();
                frm.CarType = "社会车";
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("车位已经有车！", "提示");
            }
        } 
        #endregion

        #region 车离

        /// <summary>
        /// 车离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCarFrom_Click(object sender, EventArgs e)
        {
            if (!cbbPacking.Text.Contains('Z'))
            {
                MessageBox.Show("请选择停车位。");
                return;
            }
            if (GetParkStatus(cbbPacking.Text.Trim()) == "5")
            {
                MessageBox.Show("车位无车，不需要车离。");
                btnRefresh_Click(null, null);
                return;
            }
            if (cbbPacking.Text.Contains('Z'))
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要对" + cbbPacking.Text.Trim() + "跨进行车离位吗？", "操作提示", btn, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.OK)
                {
                    tagDP.SetData("EV_NEW_PARKING_CARLEAVE", cbbPacking.Text.Trim());
                    MessageBox.Show("已通知" + cbbPacking.Text.Trim() + "跨车离开");
                    //画面清空
                    dt_selected.Clear();
                    dataGridView2.DataSource = dt_selected;
                    //重量清空
                    coilsWeight = 0;
                    txtCoilsWeight.Text = string.Format("{0}/吨", coilsWeight);
                    txtCoilsWeight.BackColor = Color.White;
                    //钢卷半径距离清空
                    //txtCarHeadToward.Text = "";
                    //txtCarNo.Text = "";
                    txtSelectGoove.Text = "";
                }
                isStowage = false;
                hasParkSize = false;
            }

        }
        private string GetParkStatus(string parkingNO)
        {
            string ret = "";
            if (!parkingNO.Contains('Z'))
            {
                return ret;
            }
            try
            {
                string sqlText = @"SELECT PARKING_STATUS FROM UACS_PARKING_STATUS WHERE PARKING_NO = '" + parkingNO + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        ret = ParkClassLibrary.ManagerHelper.JudgeStrNull(rdr["PARKING_STATUS"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return ret;
        } 
        #endregion
      #endregion



        #region 车位状态显示

        /// <summary>
        /// 读取停车位状态
        /// </summary>
        private bool GetParkInfo()
        {
            try
            {
                string sql = "select PARKING_NO,ISLOADED,PARKING_STATUS,CAR_NO from UACS_PARKING_STATUS";
                bool ret = true;
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        //Z3
                        if (cbbPacking.Text.Contains("Z3"))
                        {
                            if (rdr["PARKING_NO"].ToString().Trim() == "Z32A1")
                            {
                                parkZ53A1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z33A1")
                            {
                                parkZ53A2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                        }
                        else if (cbbPacking.Text.Contains("Z5") && cmbArea.Text.Trim().Contains("7-1"))
                        {
                            //Z5 7-1
                            if (rdr["PARKING_NO"].ToString().Trim() == "Z51A1")
                            {
                                parkZ51A1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));

                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z51A2")
                            {
                                parkZ51A2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z52A1")
                            {
                                parkZ52A1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z52A2")
                            {
                                parkZ52A2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z53A1")
                            {
                                parkZ53A1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z53A2")
                            {
                                parkZ53A2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                        }

                        else if (cbbPacking.Text.Contains("Z5") && cmbArea.Text.Trim().Contains("7-2"))
                        {
                            //Z5 7-2
                            if (rdr["PARKING_NO"].ToString().Trim() == "Z51B1")
                            {
                                parkZ51A1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));

                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z51B2")
                            {
                                parkZ51A2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z52B1")
                            {
                                parkZ52A1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z52B2")
                            {
                                parkZ52A2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z53B1")
                            {
                                parkZ53A1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z53B2")
                            {
                                parkZ53A2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]));
                            }
                        }


                        // if (rdr["CAR_NO"] != DBNull.Value)

                    }

                }

                string treatmentNO = txtTeratmentNO.Text;
                string laserCount = txtLaserCount.Text;
                string sqlTextTotal = @"SELECT COUNT(distinct(LASER_ID)) AS IDTOTAL  FROM UACS_LASER_OUT WHERE 1=1 ";
                sqlTextTotal += " AND LASER_ACTION_COUNT = '" + laserCount + "' AND TREATMENT_NO = '" + treatmentNO + "' FETCH FIRST 1 ROWS ONLY ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlTextTotal))
                {
                    while (rdr.Read())
                    {
                        if (rdr["IDTOTAL"] != System.DBNull.Value)
                        {
                            txtSelectGoove.Text = Convert.ToString(rdr["IDTOTAL"]);
                        }
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return false;
            }
        } 
        #endregion

        #region 方法
        private string JudgeStrNull(object item)
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
        private int JudgeIntNull(object item)
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
        /// <summary>
        /// 用于DataGridView初始化一般属性
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static string DataGridViewInit(DataGridView dataGridView)
        {
            dataGridView.ReadOnly = true;
            //foreach (DataGridViewColumn c in dataGridView.Columns)
            //    if (c.Index != 0) c.ReadOnly = true;
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
        public static bool DataGridViewBindingSource(DataGridView dataGridView, string sql)
        {
            DataTable dt = new DataTable();
            using (IDataReader odrIn = DBHelper.ExecuteReader(sql))
            {
                try
                {
                    dt.Load(odrIn);
                    dataGridView.DataSource = dt;
                    foreach (DataGridViewColumn item in dataGridView.Columns)
                    {
                        if (item.Name == "Index")
                        {
                            for (int y = 0; y < dataGridView.Rows.Count - 1; y++)
                            {
                                dataGridView.Rows[y].Cells["Index"].Value = y;
                            }
                            break;
                        }
                    }

                }
                catch (Exception meg)
                {
                    MessageBox.Show(string.Format("调用函数DataGridViewBindingSource出错：{0}", meg));
                }
                odrIn.Close();
                return true;
            }
        }
        private bool CreatDgvHeader(DataGridView dataGridView, string[] columnsName, string[] headerText)
        {
            bool isFirst = false;
            if (!isFirst)
            {
                //dataGridView.Columns.Add("Index", "序号");
                //DataGridViewColumn columnIndex = new DataGridViewTextBoxColumn();
                //columnIndex.Width = 50;
                //columnIndex.DataPropertyName = "Index";
                //columnIndex.Name = "Index";
                //columnIndex.HeaderText = "序号";
                //dataGridView.Columns.Add(columnIndex);
                for (int i = 0; i < headerText.Count(); i++)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.DataPropertyName = columnsName[i];
                    column.Name = columnsName[i];
                    column.HeaderText = headerText[i];
                    if (i > 0)
                    {
                        column.Width = 150;
                    }

                    int index = dataGridView.Columns.Add(column);
                    dataGridView.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                isFirst = true;
                return isFirst;
            }
            else
                return isFirst;
        }
        void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0)
                                && dataGridView2.Rows[e.RowIndex].Cells["COIL_NO2"].Value != null
                                 && dataGridView2.Rows[e.RowIndex].Cells["COIL_NO2"].Value.ToString() != "")
                {
                    if (dataGridView2.Columns[e.ColumnIndex].Name.Equals("LOCK_FLAG")
                        || dataGridView2.Columns[e.ColumnIndex].Name.Equals("STOCK_NO"))
                    {
                        if (e.Value == null || e.Value.ToString() == "")
                        {
                            e.Value = "";
                            e.CellStyle.BackColor = Color.Red;
                            return;
                        }
                        if (e.Value.Equals(0))
                            e.Value = "可用";
                        else if (e.Value.Equals(1))
                        {
                            e.Value = "待判";
                            e.CellStyle.BackColor = Color.Yellow;
                        }
                        else if (e.Value.Equals(2))
                        {
                            e.Value = "封锁";
                            e.CellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        #endregion
        #region 指令信息显示

        /// <summary>
        /// 刷新指令表
        /// </summary>
        private void RefreshOrderDgv(string parkNO)
        {
            DataTable dtOrder = new DataTable();
            dtOrder.Clear();
            try
            {
                //string sql = string.Format("select BAY_NO,MAT_NO,FROM_STOCK_NO,TO_STOCK_NO from UACS_CRANE_ORDER_Z32_Z33 WHERE BAY_NO ='{0}' AND ORDER_TYPE = '12' ", parkNO);  //社会车？？框架车23
                string SQLOder = " SELECT C.GROOVEID, C.MAT_NO,B.BAY_NO,B.FROM_STOCK_NO ,B.TO_STOCK_NO FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                SQLOder += " RIGHT JOIN UACS_CRANE_ORDER_Z32_Z33 B ON C.MAT_NO = B.MAT_NO ";
                SQLOder += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                SQLOder += " WHERE PARKING_NO ='{0}') ORDER BY C.GROOVEID ";
                SQLOder = string.Format(SQLOder, parkNO);
                using (IDataReader odrIn = DBHelper.ExecuteReader(SQLOder))
                {
                    dtOrder.Load(odrIn);
                }
                dgvOrder.DataSource = dtOrder;

                //DataGridViewBindingSource(dgvOrder, SQLOder);



            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }

        } 
        #endregion

        private void CreatCarSize(string strParkNo, ParkLaserOut park)
        {
            DataTable dtLaserData = new DataTable();
            dtLaserData.Clear();
            try
            {
                string sqlLaser = @"SELECT CAR_X_BORDER_MAX,CAR_X_BORDER_MIN,CAR_Y_BORDER_MAX,CAR_Y_BORDER_MIN,GROOVE_ACT_X,GROOVE_ACT_Y,GROOVE_ACT_Z,GROOVEID FROM UACS_LASER_OUT  ";
                sqlLaser = string.Format("{0}  WHERE TREATMENT_NO  IN (SELECT TREATMENT_NO FROM UACS_PARKING_STATUS WHERE PARKING_NO = '{1}')", sqlLaser, strParkNo); //strParkNo:Z53A1
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlLaser))
                {
                    dtLaserData.Load(rdr);
                }
                //生成车位置
                ////获取车位坐标XMin, XMax, YMin, YMax
                int XMin, XMax, YMin, YMax;
                int XVehicleLength, YVehicleLength;
                XMin = XMax = YMin = YMax = XVehicleLength = YVehicleLength = 0;
                //SELECT CAR_X_BORDER_MAX,CAR_X_BORDER_MIN,CAR_Y_BORDER_MAX,CAR_Y_BORDER_MIN,GROOVE_ACT_X,GROOVE_ACT_Y,GROOVE_ACT_Z,GROOVEID FROM UACS_LASER_OUT 
                if (dtLaserData.Rows.Count != 0)
                {
                    XMin = Convert.ToInt32(dtLaserData.Rows[0]["CAR_X_BORDER_MIN"]);
                    XMax = Convert.ToInt32(dtLaserData.Rows[0]["CAR_X_BORDER_MAX"]);
                    YMin = Convert.ToInt32(dtLaserData.Rows[0]["CAR_Y_BORDER_MIN"]);
                    YMax = Convert.ToInt32(dtLaserData.Rows[0]["CAR_Y_BORDER_MAX"]);
                    XVehicleLength = XMax - XMin;
                    YVehicleLength = YMax - YMin;
                    //画面显示
                    park.CreateCarSize(XMin, YMax, XVehicleLength, YVehicleLength, 0, "E");
                }
                //生成钢卷位置
                foreach (DataRow item in dtLaserData.Rows)
                {
                    int n1 = JudgeIntNull(item["GROOVE_ACT_X"]);
                    int n2 = JudgeIntNull(item["GROOVE_ACT_Y"]);
                    string strID = JudgeStrNull(item["GROOVEID"]);
                    if (n1 != 0 && n2 != 0)
                    {
                        park.CreateCoilSize(n1, n2, 1200, 1200, strID, false);
                    }
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }

        }
        #region 配载图显示
        /// <summary>
        /// 车位绑定激光数据
        /// </summary>
        /// <param name="strParkNo"></param>
        private void LoadLaserInfo(string strParkNo, ParkLaserOut park)
        {
            if (!strParkNo.Contains('Z'))
            {
                return;
            }
            DataTable dtLaserData = new DataTable();
            DataTable dtParksize = new DataTable();
            DataTable dtStowageData = new DataTable();
            dtParksize.Clear();
            dtLaserData.Clear();
            dtStowageData.Clear();
            park.ClearbitM();
            try
            {
                string sqlLaser = @"SELECT CAR_X_BORDER_MAX,CAR_X_BORDER_MIN,CAR_Y_BORDER_MAX,CAR_Y_BORDER_MIN,GROOVE_ACT_X,GROOVE_ACT_Y,GROOVE_ACT_Z,GROOVEID FROM UACS_LASER_OUT  ";
                sqlLaser = string.Format("{0}  WHERE TREATMENT_NO  IN (SELECT TREATMENT_NO FROM UACS_PARKING_STATUS WHERE PARKING_NO = '{1}')", sqlLaser, strParkNo); //strParkNo:Z53A1
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlLaser))
                {
                    dtLaserData.Load(rdr);
                }
                string sqlPark = string.Format("SELECT * FROM UACS_YARDMAP_PARKINGSITE WHERE NAME ='{0}' AND YARD_NO = '{1}'", strParkNo, strParkNo.Substring(0, 3));
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlPark))
                {
                    dtParksize.Load(rdr);
                }
                string sqlStowage = @" SELECT C.MAT_NO,C.X_CENTER,C.Y_CENTER ,C.GROOVEID, B.OUTDIA ,B.WIDTH ,A.STOCK_NO,A.LOCK_FLAG  FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                sqlStowage += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
                sqlStowage += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlStowage += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                sqlStowage += " WHERE PARKING_NO ='{0}')  ORDER BY GROOVEID  ";
                sqlStowage = string.Format(sqlStowage, cbbPacking.Text.Trim());
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStowage))
                {
                    dtStowageData.Load(rdr);
                }
                //初始化停车位信息
                int XStart, XEnd, YStart, YEnd, XLength, YLength;
                XStart = JudgeIntNull(dtParksize.Rows[0]["X_START"]);
                XEnd = JudgeIntNull(dtParksize.Rows[0]["X_END"]);
                YStart = JudgeIntNull(dtParksize.Rows[0]["Y_START"]);
                YEnd = JudgeIntNull(dtParksize.Rows[0]["Y_END"]);
                XLength = JudgeIntNull(dtParksize.Rows[0]["X_LENGTH"]);
                YLength = JudgeIntNull(dtParksize.Rows[0]["Y_LENGTH"]);
                //画面显示
                park.InitializeXY(park.Size.Width - 10, park.Size.Height - 10);

                //生成车位
                //宽增加0.5m、长度增加1.5m
                park.CreatePassageWayArea(XStart - 500, YEnd + 1800, 5200, 17000);
                if (!hasParkSize)
                {
                    //park.DrawParksize(XStart, YEnd, XEnd - XStart, YEnd - YStart);
                    park.DrawParksize(XStart, YEnd, XEnd - XStart, YEnd - YStart, carHearDrection);
                    if (carHearDrection != "")
                    {
                        hasParkSize = true;
                    }
                }
                park.HasCarSize = false;
                //生成钢卷位置
                foreach (DataRow item in dtStowageData.Rows)
                {
                    int n1 = JudgeIntNull(item["X_CENTER"]);
                    int n2 = JudgeIntNull(item["Y_CENTER"]);
                    int n3 = JudgeIntNull(item["OUTDIA"]);  //外径
                    int n4 = JudgeIntNull(item["WIDTH"]);  //宽度
                    string strID = JudgeStrNull(item["GROOVEID"]);
                    string strMat = JudgeStrNull(item["MAT_NO"]);
                    int flag1 = 3;  //封锁标记(0:可用 1:待判 2:封锁)
                    if (item["LOCK_FLAG"] == DBNull.Value)
                    {
                        flag1 = 3;
                    }
                    else
                    {
                        flag1 = Convert.ToInt32(item["LOCK_FLAG"]);
                    }
                    if (n1 != 0 && n2 != 0)
                    {
                        //park.CreateCoilSize(n1, n2, n4, n3, strID, true);
                        //park.CreateCoilSize(n1, n2, n4, n3, strID, true,strMat, toolTip1 );
                        park.CreateCoilSize(n1, n2, n4, n3, strID, false, strMat, toolTip1, flag1);
                        //park.CreateLaserLocation(n1, n2, 4000, 120);
                    }
                }
                //生成激光位置
                foreach (DataRow item in dtLaserData.Rows)
                {
                    int n1 = JudgeIntNull(item["GROOVE_ACT_X"]);
                    int n2 = JudgeIntNull(item["GROOVE_ACT_Y"]);
                    string strID = JudgeStrNull(item["GROOVEID"]);
                    if (n1 != 0 && n2 != 0)
                    {
                        //park.CreateCoilSize(n1, n2, 4000, 120,strID,false);
                        park.CreateLaserLocation(n1, n2, 4000, 120);
                        //有卷测试
                        //park.CreateCoilSize(n1, n2, 1200, 1200, strID, true);
                    }
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }



        }
        void parkLaserOut1_LabClick(string matNO)
        {
            SelectDataGridViewRow(dataGridView2, matNO, "COIL_NO2");
        }
        private bool reflreshParkingCoilstate(string parkNO)
        {
            DataTable dtStowage = new DataTable();
            bool ret = false;
            string matNO;
            string coilStatus;
            string stowageID = txtStowageID.Text.Trim();
            if (!parkNO.Contains('Z')||stowageID.Length<2)
            {
                return ret ;
            }
            try
            {
                string sqlStowage = @" SELECT C.MAT_NO,C.STATUS FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                sqlStowage += " WHERE C.STOWAGE_ID = " + stowageID + " ORDER BY GROOVEID ";
                //sqlStowage += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                //sqlStowage += " WHERE  CAR_NO IN ( SELECT CAR_NO FROM UACS_PARKING_STATUS WHERE PARKING_NO ='{0}')) ORDER BY GROOVEID ";
                //sqlStowage = string.Format(sqlStowage, parkNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStowage))
                {
                    dtStowage.Load(rdr);
                }
                if (dtStowage.Rows.Count>0)
                {
                    foreach (DataRow item in dtStowage.Rows)
                    {
                        matNO = JudgeStrNull(item["MAT_NO"]);
                        coilStatus = JudgeStrNull(item["STATUS"]);
                        parkLaserOut1.ChangeCoilState(matNO, coilStatus, "0");
                    }
                }

                return ret;    
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                return ret; 
            }
 
        }
        #endregion

        #region 激光数据显示
        private void Inq_Laser(string theTreatmentNO, string theCount)
        {
            try
            {
                if (theTreatmentNO == "" || theCount == "")
                {
                    dt_Laser.Clear();
                    dataGridView_LASER.DataSource = dt_Laser;
                    return;
                }
                //出库激光扫描信息
                string sqlText_Laser = @"SELECT  GROOVEID, GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z FROM UACS_LASER_OUT WHERE 1=1 ";
                sqlText_Laser += " AND TREATMENT_NO = '" + theTreatmentNO + "' AND LASER_ACTION_COUNT = '" + theCount + "' ";
                sqlText_Laser += " ORDER BY GROOVEID, GROOVE_ACT_Y ";


                //初始化grid
                if (dataGridView_LASER.DataSource != null)
                {
                    dt_Laser.Clear();
                }
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_Laser))
                {
                    dt_Laser.Load(rdr);
                }
                dataGridView_LASER.DataSource = dt_Laser;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        } 
        #endregion
        /// <summary>
        /// 每10秒刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isStowage==true)
            {
                if (cbbPacking.Text.Contains('Z'))
                {
                    reflreshParkingCoilstate(cbbPacking.Text.Trim());
                    RefreshOrderDgv(cbbPacking.Text.Trim());
                }                   
            }
            //foreach (DataGridViewRow item in dataGridView2.Rows)
            //{           

            //    if (dataGridView2.DataSource !=null && item.Cells["COIL_NO2"].Value != null)
            //    {
            //        if (item.Cells["COIL_NO2"].Value.ToString().Length<5)
            //        {
            //            break;
            //        }
            //        isStowage = true;
            //        return;
            //    }
            //}
            if (dataGridView2.DataSource != null && ((DataTable)dataGridView2.DataSource).Rows.Count > 0)
            {
                isStowage = true;
                return;
            }
            isStowage = false;
            if (!cbbPacking.Text.Contains('Z'))
            {
                GetParkInfo();
                return;
            }
            RefreshHMI();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GetStowageDetail())
            {
                MessageBox.Show("车辆已经配载材料，请先做车离。");
                return;
            } 
            SelectCoilForm selectCoilF = new SelectCoilForm();
            selectCoilF.TransferValue += selectCoilF_TransferValue;
            selectCoilF.CarType = "社会车";
            if (cbbPacking.Text.Trim() != "请选择" && cbbPacking.Text.Trim() != "" && cbbPacking.Text.Trim().Contains('Z'))
            {
                //string strPacking = cbbPacking.Text.Trim().Substring(0, 3);
                //StringBuilder sbb = new StringBuilder(strPacking);
                //sbb.Append("-1");
                selectCoilF.ParkNO = cbbPacking.Text.Trim();
                if (txtCarNo.Text.Trim().Length > 3)
                    selectCoilF.CarNO = txtCarNo.Text.Trim();
                else
                {
                    MessageBox.Show("车牌号信息不正确！");
                    return;
                } 
                selectCoilF.ShowDialog();
            }
            else
            {
                MessageBox.Show("车位信息不正确！");
            }
            
        }

        void selectCoilF_TransferValue(string weight , bool isLoad)
        {
            if (weight!="")
            {
                if (Convert.ToInt32(weight) > 50000)
                    txtCoilsWeight.BackColor = Color.Red;
                else
                    txtCoilsWeight.BackColor = Color.White;
            }
            RefreshHMI();
            txtCoilsWeight.Text = string.Format("{0} /公斤", weight);
            isStowage = isLoad;
        }

        #region 作业开始
        private void btnOperateStrat_Click(object sender, EventArgs e)
        {
            string parkNO = cbbPacking.Text.Trim();
            try
            {
                if (parkNO == "" || !parkNO.Contains('Z'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (txtCarNo.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不能开始。");
                    return;
                }

                if (parkNO != "请选择" || parkNO != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("是否对" + parkNO + "作业开始？", "提示", btn, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        //tagDP.SetData("EV_PARKING_JOB_RESUME", parkNO);
                        tagDP.SetData("EV_NEW_PARKING_Z33_CRANE_ALLOW", parkNO);
                        btnOperateStrat.ForeColor = Color.Green;
                        btnOperatePause.ForeColor = Color.White;
                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        } 
        
        /// <summary>
        /// 获取车位是否是暂停状态
        /// </summary>
        /// <param name="parkNO"></param>
        /// <returns></returns>
        private bool GetOperateStatus(string parkNO)
        {
            bool ret = false;
            try
            {
                string SQLOder = "  SELECT PARKING_STATUS FROM UACS_PARKING_STATUS WHERE PARKING_NO ='{0}' ";
                SQLOder = string.Format(SQLOder, parkNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(SQLOder))
                {
                    while (rdr.Read())
                    {
                        int status = 0;
                        status = JudgeIntNull(rdr["PARKING_STATUS"]);
                        if (status == 270) //暂停
                        {
                            ret = true;
                            break;
                        }
                    }
                }
                if (ret) //开始
                {
                    btnOperateStrat.ForeColor = Color.White;
                    btnOperatePause.ForeColor = Color.Orange;
                }
                else
                {
                    btnOperatePause.ForeColor = Color.White;
                    btnOperateStrat.ForeColor = Color.White;
                }
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return ret;
            }
            //
        }
        #endregion

        #region 作业暂停

        private void btnOperatePause_Click(object sender, EventArgs e)
        {
            string parkNO = cbbPacking.Text.Trim();
            try
            {
                if (parkNO == "" || !parkNO.Contains('Z'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (txtCarNo.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不能开始。");
                    return;
                }

                if (parkNO != "请选择" || parkNO != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("是否对" + parkNO + "作业暂停？", "提示", btn, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        //tagDP.SetData("EV_PARKING_JOB_PAUSE", parkNO);EV_PARKING_Z33_CRANE_ALLOW
                        tagDP.SetData("EV_NEW_PARKING_Z32_CRANE_ALLOW", parkNO);
                        btnOperateStrat.ForeColor = Color.White;
                        btnOperatePause.ForeColor = Color.Orange;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        } 
        #endregion



        #region 画面跳转
        private bool JumpToOtherForm(string currPark)
        {
            bool ret = false;
            Int16 carType = -1;
            string strStatus = GetParkStatus(currPark, out carType);
            if (strStatus == "")
            {
                return ret;
            }
            if (strStatus.Substring(0, 1) == "1" && strStatus.Length == 3) //入库
            {
                if (auth.IsOpen("成品库车辆入库"))
                {
                    auth.CloseForm("成品库车辆入库");
                }
                auth.OpenForm("成品库车辆入库", currPark);
                ret = true;
            }
            else if (strStatus.Substring(0, 1) == "2" && (carType != 101 && carType != 102)) //框架出库
            {
                if (auth.IsOpen("成品库框架车出库"))
                {
                    auth.CloseForm("成品库框架车出库");
                }
                auth.OpenForm("成品库框架车出库", currPark);
                ret = true;
            }
            return ret;
        }
        /// <summary>
        /// 返回车位状态
        /// </summary>
        /// <param name="parkingNO"></param>
        /// <returns></returns>
        private string GetParkStatus(string parkingNO, out Int16 carType)
        {
            string ret = "";
            carType = -1;
            if (!parkingNO.Contains('Z'))
            {
                return ret;
            }
            try
            {
                string sqlText = " SELECT C.PARKING_STATUS,A.CAR_TYPE FROM UACS_PARKING_STATUS  C ";
                sqlText += " LEFT JOIN UACS_TRUCK_STOWAGE A ON C.STOWAGE_ID = A.STOWAGE_ID ";
                sqlText += " WHERE PARKING_NO = '" + parkingNO + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        ret = ManagerHelper.JudgeStrNull(rdr["PARKING_STATUS"]);
                        carType = (Int16)ManagerHelper.JudgeIntNull(rdr["CAR_TYPE"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return ret;
        }
        #endregion
        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetComboxOnParking();
        }
    }

}
