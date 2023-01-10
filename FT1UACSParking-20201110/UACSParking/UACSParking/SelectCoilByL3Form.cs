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

//using ParkingControlLibrary;
using ParkClassLibrary;

namespace UACSParking
{
    public partial class SelectCoilByL3Form : Form
    {
        public event TransferValue TransferValue;
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;
        DataTable dt_selected = new DataTable();
        CheckBox checkbox ;
        string parkNO;
        string carNO;
        //添加材料个数
        //int count = 0;
        int coilsWeight = 0;   //添加材料重量
        //int coilsDistance = 0;  //半径距离
        //int x_coil1 = 0;
        //int x_coil2 = 0;
        string carType;

        public string CarType
        {
            get { return carType; }
            set
            {
                carType = value;
                this.Text = string.Format("{0}材料选择", carType);
            }
        }

        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        public string CarNO
        {
            get { return carNO; }
            set { carNO = value; }
        }

        public string ParkNO
        {
            get { return parkNO; }
            set { parkNO = value; }
        }

        public SelectCoilByL3Form()
        {
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            //TagValues.Add("EV_NEW_PARKING_CARLEAVE", null);
            //社会车出库
            TagValues.Add("EV_NEW_PARKING_MDL_OUT_CAL_JUDGE", null);
            //框架车出库
            TagValues.Add("EV_PARKING_MDL_OUT_CAL_START", null);
            tagDP.Attach(TagValues);

            //初始化dataGridview属性
            DataGridViewInit(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;
            DataGridViewInit(dataGridView2);
            //dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.RowTemplate.Height = 40;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.Text = string.Format("{0}材料选择", carType);
        }

        private void SelectCoilForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(242, 246, 252);
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dt_selected.Columns.Add(dataGridView2.Columns[i].Name);
            }
            //添加全选
            CreakConlumcheckBox();
            //加载扫描数据
            RefreshHMILaserOutData();

            //加载L3装车要求
            InitialL3StowagePlan(carNO);
        }
        #region 添加全选
        private void CreakConlumcheckBox()
        {
            var cell = this.dataGridView1.GetCellDisplayRectangle(0, -1, true);
            //var checkbox = new CheckBox { Left = cell.Size.Width - 20, Top = cell.Top + 10, Width = 16, Height = 16 };
            checkbox = new CheckBox { Left = cell.Size.Width - 20, Top = cell.Size.Height / 2 - 8, Width = 16, Height = 16 };
            checkbox.CheckedChanged += checkbox_CheckedChanged;
            this.dataGridView1.Controls.Add(checkbox);
        }

        void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                CheckBox cb = (CheckBox)sender;
                if (cb.Checked)
                {
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        item.Cells["CHECK_COLUMN"].Value = true;
                        i++;
                    }
                }
                else if (!cb.Checked)
                {
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        item.Cells["CHECK_COLUMN"].Value = false;

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message +"\r\n"+ ex.StackTrace); 
            }

        } 
        #endregion
        private void InitialL3StowagePlan(string strTruckNo)
        {
            // 查询L3装车要求
            string strL3PlanNo = "";
            string strL3TaskNo = "";
            if (QueryL3StowagePlan(strTruckNo, out strL3PlanNo, out strL3TaskNo))
            {
                textBox_L3_TRUCK_NO.Text = strTruckNo;
                textBox_L3_PLAN_NO.Text = strL3PlanNo;
                textBox_L3_TASK_NO.Text = strL3TaskNo;

                // 根据L3配载计划，查询装车材料信息
                DataTable dataTable = BindMatStockByL3Stowage(strTruckNo, strL3PlanNo, strL3TaskNo);
                this.dataGridView1.DataSource = dataTable;
            }
            else
            {
                textBox_L3_TRUCK_NO.Text = "无";
                textBox_L3_PLAN_NO.Text = "无";
                textBox_L3_TASK_NO.Text = "无";
            }
        }

        // 
        private bool QueryL3StowagePlan(string strTruckNo, out string strL3PlanNo, out string strL3TaskNo)
        {
            bool bFounded = false;

            strL3PlanNo = "";
            strL3TaskNo = "";

            // 查询车号对应的L3装车要求号
            string sqlText = @"SELECT * FROM UACS_TRUCK_STOWAGE_L3 where TRUCK_NO like '{0}'";
            sqlText = string.Format(sqlText, strTruckNo);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                if (rdr.Read())
                {
                    strL3PlanNo = rdr["L3_PLAN_NO"].ToString();
                    strL3TaskNo = rdr["L3_TASK_NO"].ToString();

                    bFounded = true;
                }
            }

            return bFounded;
        }

        private DataTable InitDataTable(DataGridView datagridView)
        {
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn dgvColumn in datagridView.Columns)
            {
                DataColumn dtColumn = new DataColumn();
                if (!dgvColumn.GetType().Equals(typeof(DataGridViewCheckBoxColumn)))
                {
                    dtColumn.ColumnName = dgvColumn.Name.ToUpper();
                    dtColumn.DataType = typeof(String);
                    dataTable.Columns.Add(dtColumn);
                }
                else
                {
                    dtColumn.ColumnName = dgvColumn.Name.ToUpper();
                    //dtColumn.DataType = typeof(bool);
                    dataTable.Columns.Add(dtColumn);
                }
            }

            return dataTable;
        }


        /// <summary>
        /// 绑定材料位置信息
        /// </summary>
        private DataTable BindMatStock(string strPlanNo, string strLotNo, string strMatNo, string strStockNo)
        {
            DataTable dtResult = InitDataTable(dataGridView1);

            if (strPlanNo.Length == 0 && strMatNo.Length == 0 && strStockNo.Length == 0 && strLotNo.Length == 0)
                return dtResult;

            // 查询语句
            string sqlText_All = @"  SELECT 0 AS CHECK_COLUMN, C.MAT_NO AS COIL_NO, A.PLAN_NO as PLAN_NO,  C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,";
            sqlText_All += "    D.X_CENTER, D.Y_CENTER, C.Z_CENTER ,";
            sqlText_All += " B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_YARDMAP_STOCK_DEFINE C ";
            sqlText_All += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
            sqlText_All += " LEFT JOIN  UACS_PLAN_OUT_DETAIL A ON C.MAT_NO = A.MAT_NO ";
            sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON C.STOCK_NO = E.STOCK_NO ";
            sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO ";
            sqlText_All += " WHERE  C.BAY_NO  like '" + parkNO.Substring(0, 3) + "%' ";
            sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0";

            bool bAddedCondition = false;
            string subSql = "";
            // 查询条件：指定发货单号
            if (strPlanNo.Length != 0)
            {
                subSql = string.Format("C.MAT_NO IN (SELECT MAT_NO FROM UACS_PLAN_OUT_DETAIL WHERE PLAN_NO like '%{0}%')", strPlanNo);
                bAddedCondition = true;
            }
            // 查询条件: 指定提单号
            if (strLotNo.Length != 0)
            {
                string strTmpSql = string.Format("C.MAT_NO IN (SELECT A.MAT_NO FROM UACS_PLAN_OUT_DETAIL A, UACS_PLAN_OUT B WHERE A.PLAN_NO = B.PLAN_NO and B.LOT_NO like '%{0}%')", strLotNo);
                if (bAddedCondition)
                {
                    subSql += " OR (" + strTmpSql + ")";
                }
                else
                {
                    subSql = strTmpSql;
                    bAddedCondition = true;
                }
            }
            // 查询条件：指定材料号
            if (strMatNo.Length != 0)
            {
                string strTmpSql = string.Format("C.MAT_NO like '%{0}%'", strMatNo);
                if (bAddedCondition)
                {
                    subSql += " OR (" + strTmpSql + ")";
                }
                else
                {
                    subSql = strTmpSql;
                    bAddedCondition = true;
                }
            }
            // 查询条件：指定库位号
            if (strStockNo.Length != 0)
            {
                string strTmpSql = string.Format("C.STOCK_NO like '%{0}%'", strStockNo);
                if (bAddedCondition)
                {
                    subSql += " OR (" + strTmpSql + ")";
                }
                else
                {
                    subSql = strTmpSql;
                    bAddedCondition = true;
                }
            }

            // 补充查询条件
            sqlText_All += " AND ( " + subSql + " )";

            // 排序
            sqlText_All += " order by C.STOCK_NO DESC ";
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_All))
            {
                while (rdr.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        string columnName = rdr.GetName(i);
                        dr[columnName] = rdr[i];
                    }
                    dtResult.Rows.Add(dr);
                }
            }

            // 查询材料对应的发货信息
            DataTable dtPick = new DataTable();
            subSql = "SELECT PLAN_NO FROM UACS_PLAN_OUT_DETAIL";
            if (strStockNo.Length != 0)
            {
                string strTmpSql = String.Format("MAT_NO IN ( SELECT MAT_NO FROM UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NO like '%{0}%' )", strStockNo);
                subSql = string.Format("{0} WHERE {1}", subSql, strTmpSql);
            }
            if (strMatNo.Length != 0)
            {
                string strTmpSql = String.Format("MAT_NO like '%{0}%'", strMatNo);
                if (subSql.IndexOf("WHERE") != -1)
                    subSql = string.Format("{0} OR ({1})", subSql, strTmpSql);
                else
                    subSql = string.Format("{0} WHERE {1}", subSql, strTmpSql);
            }

            sqlText_All = string.Format("SELECT * FROM UACS_PLAN_OUT");
            if (strPlanNo.Length != 0)
            {
                string strTmpSql = String.Format("PLAN_NO like '%{0}%'", strPlanNo);
                sqlText_All = string.Format("{0} WHERE {1}", sqlText_All, strTmpSql);
            }
            if (strLotNo.Length != 0)
            {
                string strTmpSql = String.Format("LOT_NO like '%{0}%'", strLotNo);
                if (sqlText_All.IndexOf("WHERE") == -1)
                {
                    sqlText_All = string.Format("{0} WHERE {1}", sqlText_All, strTmpSql);
                }
                else
                {
                    sqlText_All = string.Format("{0} OR {1}", sqlText_All, strTmpSql);
                }
            }
            if (subSql.IndexOf("WHERE") != -1)
            {
                if (sqlText_All.IndexOf("WHERE") == -1)
                    sqlText_All = string.Format("{0} WHERE PLAN_NO IN ({1})", sqlText_All, subSql);
                else
                    sqlText_All = string.Format("{0} OR PLAN_NO IN ({1})", sqlText_All, subSql);
            }
            
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_All))
            {
                bool hasSetColumn = false;
                while (rdr.Read())
                {
                    if (!hasSetColumn)
                    {
                        setDataColumn(dtPick, rdr);
                    }
                    hasSetColumn = true;
                    DataRow dr = dtPick.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dr[i] = rdr[i];
                    }
                    dtPick.Rows.Add(dr);
                }
            }

            // 库存数据中补充发货信息
            if (dtPick.Rows.Count != 0)
            {
                foreach (DataRow row in dtResult.Rows)
                {
                    if (row["PLAN_NO"] != null)
                    {
                        string planNo = row["PLAN_NO"].ToString();
                        DataRow[] foundRows = dtPick.Select(string.Format("PLAN_NO = '{0}'", planNo));
                        if (foundRows.Length > 0)
                        {
                            row["LOT_NO"] = foundRows[0]["LOT_NO"];
                            row["SHIP_NAME"] = foundRows[0]["SHIP_NAME"];
                        }
                    }
                }
            }

            return dtResult;
        }

        /// <summary>
        /// 绑定材料位置信息
        /// </summary>
        private DataTable BindMatStockByL3Stowage(string strL3TruckNo, string strL3PlanNo, string strL3TaskNo)
        {
            DataTable dtResult = InitDataTable(dataGridView1);
            bool bAddedWhere = false;
            string subSql = "SELECT MAT_NO FROM UACS_TRUCK_STOWAGE_L3";

            // 转换
            if (strL3PlanNo == "无")
                strL3PlanNo = "";
            if (strL3TaskNo == "无")
                strL3TaskNo = "";
            if (strL3TruckNo == "无")
                strL3TruckNo = "";

            if (strL3TruckNo.Length == 0 && strL3PlanNo.Length == 0  && strL3TaskNo.Length == 0)
                return dtResult;

            #region MyRegion
            //// L3装车要求
            //// 查询条件：指定配载车号
            //if (strL3TruckNo.Length != 0)
            //{
            //    subSql = string.Format("{0} WHERE TRUCK_NO like '%{1}%'", subSql, strL3TruckNo);
            //    bAddedWhere = true;
            //}
            //// 查询条件：指定配载计划号
            //if (strL3PlanNo.Length != 0)
            //{
            //    if (bAddedWhere)
            //    {
            //        subSql = string.Format("{0} AND L3_PLAN_NO like '%{1}%'", subSql, strL3PlanNo);
            //    }
            //    else
            //    {
            //        subSql = string.Format("{0} WHERE L3_PLAN_NO like '%{1}%'", subSql, strL3PlanNo);
            //        bAddedWhere = true;
            //    }
            //}
            //// 查询条件：指定配载任务号
            //if (strL3TaskNo.Length != 0)
            //{
            //    if (bAddedWhere)
            //    {
            //        subSql = string.Format("{0} AND L3_TASK_NO like '%{1}%'", subSql, strL3TaskNo);
            //    }
            //    else
            //    {
            //        subSql = string.Format("{0} WHERE L3_TASK_NO like '%{1}%'", subSql, strL3TaskNo);
            //        bAddedWhere = true;
            //    }
            //}

            //// 查询语句
            //string sqlText_All = @"  SELECT 0 AS CHECK_COLUMN, C.MAT_NO AS COIL_NO, A.PLAN_NO as PLAN_NO,  C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,";
            //sqlText_All += "    D.X_CENTER, D.Y_CENTER, C.Z_CENTER ,";
            //sqlText_All += " B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_YARDMAP_STOCK_DEFINE C ";
            //sqlText_All += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
            //sqlText_All += " LEFT JOIN  UACS_PLAN_OUT_DETAIL A ON C.MAT_NO = A.MAT_NO ";
            //sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON C.STOCK_NO = E.STOCK_NO ";
            //sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO ";
            //sqlText_All += " WHERE  C.BAY_NO  like '" + parkNO.Substring(0, 3) + "%' ";
            //sqlText_All += " AND C.MAT_NO IN (" + subSql + ")";
            ////sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0";

            //// 排序
            //sqlText_All += " order by C.STOCK_NO DESC "; 
            #endregion

            string sqlText_All = @" SELECT 0 AS CHECK_COLUMN, F.MAT_NO  AS COIL_NO, A.PLAN_NO as PLAN_NO,  C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,
             D.X_CENTER, D.Y_CENTER, C.Z_CENTER ,
             B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_TRUCK_STOWAGE_L3 F  
             LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON F.MAT_NO = C.MAT_NO
             LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO 
             LEFT JOIN  UACS_PLAN_OUT_DETAIL A ON C.MAT_NO = A.MAT_NO 
             LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON C.STOCK_NO = E.STOCK_NO 
             LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO 
             WHERE  F.MAT_NO IS NOT NULL ";
            sqlText_All += "AND F.TRUCK_NO ='" + strL3TruckNo + "'";
            // 执行
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_All))
            {
                while (rdr.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        string columnName = rdr.GetName(i);
                        dr[columnName] = rdr[i];
                    }
                    dtResult.Rows.Add(dr);
                }
            }

            // 查询材料对应的发货信息
            DataTable dtPick = new DataTable();
            subSql = string.Format("SELECT PLAN_NO FROM UACS_PLAN_OUT_DETAIL WHERE MAT_NO IN ({0})", subSql);
            sqlText_All = string.Format("SELECT * FROM UACS_PLAN_OUT WHERE PLAN_NO IN ({0})", subSql);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_All))
            {
                bool hasSetColumn = false;
                while (rdr.Read())
                {
                    if (!hasSetColumn)
                    {
                        setDataColumn(dtPick, rdr);
                    }
                    hasSetColumn = true;
                    DataRow dr = dtPick.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dr[i] = rdr[i];
                    }
                    dtPick.Rows.Add(dr);
                }
            }

            // 发货信息不为空
            if (dtPick.Rows.Count != 0)
            {
                // 库存数据中补充发货信息
                foreach (DataRow row in dtResult.Rows)
                {
                    if (row["PLAN_NO"] != null)
                    {
                        string planNo = row["PLAN_NO"].ToString();
                        DataRow[] foundRows = dtPick.Select(string.Format("PLAN_NO = '{0}'", planNo));
                        if (foundRows.Length > 0)
                        {
                            row["LOT_NO"] = foundRows[0]["LOT_NO"];
                            row["SHIP_NAME"] = foundRows[0]["SHIP_NAME"];
                        }
                    }
                }
            }

            return dtResult;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string truckNo = carNO;
            string parkingNo = parkNO;
            try
            {
                //框架车号不能为空
                if (truckNo == "")
                {
                    MessageBox.Show("车号不能为空");
                    return;
                }
                //车位号不能为空
                if (parkingNo == "" || parkingNo == "请选择")
                {
                    MessageBox.Show("该车找不到对应的停车位号");
                    return;
                }
                if (((DataTable)dataGridView2.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("扫描数据为空！程序退出。");
                    return;
                }
                #region    社会车卷径干涉判断  材料号输入0不判断
                if (carType == "社会车" && txtGetMat.Text.Trim()!="0")                    //开关
                {
                    //检查社会车辆两个可见光落点间距是否大于彼此材料半径加上安全距离（防止碰撞）
                    ////先获取车头方向配置表里的车长方向坐标轴
                    //string AXES_CAR_LENGTH = "";
                    //string TREND_TO_TAIL = "";
                    //string sqlText_head = @"SELECT AXES_CAR_LENGTH, TREND_TO_TAIL FROM UACS_HEAD_POSITION_CONFIG WHERE HEAD_POSTION IN ";
                    //sqlText_head += "(SELECT HEAD_POSTION FROM UACS_PARKING_STATUS WHERE PARKING_NO = '{0}') AND PARKING_NO = '{0}'";
                    //sqlText_head = string.Format(sqlText_head, parkingNo);
                    //using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_head))
                    //{
                    //    if (rdr.Read())
                    //    {
                    //        AXES_CAR_LENGTH = rdr["AXES_CAR_LENGTH"].ToString();
                    //        TREND_TO_TAIL = rdr["TREND_TO_TAIL"].ToString();
                    //    }
                    //}

                    int GROOVE_ACT_X1 = 0;
                    int GROOVE_ACT_Y1 = 0;
                    int GROOVE_ACT_X2 = 0;
                    int GROOVE_ACT_Y2 = 0;
                    string MAT_NO1 = "";
                    string MAT_NO2 = "";
                    int OUTDIA1 = 0;
                    int OUTDIA2 = 0;
                    //string sqlText_outdia = "";
                    const int safeDistance = 100;  //安全距离100mm
                    //卷径干涉判断  社会车

                    for (int j = 0; j < this.dataGridView2.Rows.Count-1; j++)
                    {
                        GROOVE_ACT_X1 = Convert.ToInt32(this.dataGridView2.Rows[j].Cells["GROOVE_ACT_X"].Value.ToString());  //槽中心点X1
                        GROOVE_ACT_Y1 = Convert.ToInt32(this.dataGridView2.Rows[j].Cells["GROOVE_ACT_Y"].Value.ToString());  //槽中心点Y1
                        MAT_NO1 = this.dataGridView2.Rows[j].Cells["COIL_NO2"].Value.ToString();                             //材料号1
                        if (MAT_NO1.Length>8)
                        {
                            OUTDIA1 = Convert.ToInt32(this.dataGridView2.Rows[j].Cells["OUTDIA2"].Value.ToString()) / 2;  //钢卷半径
                        }
                        else
                        {
                            OUTDIA1 = 0;
                        }
                        GROOVE_ACT_X2 = Convert.ToInt32(this.dataGridView2.Rows[j + 1].Cells["GROOVE_ACT_X"].Value.ToString());  //槽中心点X2
                        GROOVE_ACT_Y2 = Convert.ToInt32(this.dataGridView2.Rows[j + 1].Cells["GROOVE_ACT_Y"].Value.ToString());  //槽中心点Y2
                        MAT_NO2 = this.dataGridView2.Rows[j + 1].Cells["COIL_NO2"].Value.ToString();                             //材料号2
                        if (MAT_NO2.Length > 8)
                        {
                            OUTDIA2 = Convert.ToInt32(this.dataGridView2.Rows[j + 1].Cells["OUTDIA2"].Value.ToString()) / 2;  //钢卷半径
                        }
                        else
                        {
                            OUTDIA2 = 0;
                        }
                       
                        if (parkingNo.Contains("FT"))  //成品库库位类型
                        {
                            //int dist = GROOVE_ACT_Y2 - GROOVE_ACT_Y1 - OUTDIA1 - OUTDIA2;
                            int dist = System.Math.Abs(GROOVE_ACT_Y1 - GROOVE_ACT_Y2) - (OUTDIA1 + OUTDIA2);
                            if (dist <= safeDistance)
                            {
                                DialogResult dr = MessageBox.Show(string.Format("{0}槽与{1}槽的钢卷距离: {2}mm小于安全距离:{3}mm，继续可能存在危险！", j, j + 1, dist, safeDistance), "警告", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                                if (dr != DialogResult.Yes)
                                {
                                    return;
                                }
                            }
                        }
                        //else if (AXES_CAR_LENGTH == "Y" && TREND_TO_TAIL == "DES")
                        //{
                        //    int  dist = GROOVE_ACT_Y1 - GROOVE_ACT_Y2 - OUTDIA1 - OUTDIA2;
                        //    if (dist <= safeDistance)
                        //    {
                        //        //MessageBox.Show("落点钢卷之间距离小于安全距离，请重新选择配载材料！");
                        //        DialogResult dr = MessageBox.Show(string.Format("{0}槽与{1}钢卷之间距离: {2}mm小于安全距离:{3}mm，继续可能存在危险！", j, j + 1, dist, safeDistance), "警告", MessageBoxButtons.YesNo);
                        //        if (dr == DialogResult.Yes)
                        //        {

                        //        }
                        //        else if (dr == DialogResult.No)
                        //        {
                        //            return;
                        //        }
                        //    }
                        //}
                    }
                }
                #endregion

                #region 钢卷多库位判断
                string temp;
                if(checkMatNOCount(out temp))
                {
                    DialogResult dr = MessageBox.Show(string.Format("所选钢卷存在多库位或者卷信息有误：\r\n{0}！继续请先确认钢卷信息。", temp), "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }


                #endregion

                string myValue = "";
                //停车位号|CaoNO|处理号|模型计算次数|配载图ID-卷|卷
                string treatmentNo = "";
                string stowageNo = "";
                int currengMdlCalId = 0;
                long LASER_ACTION_COUNT = 0;
                string sqlText = @"SELECT TREATMENT_NO, STOWAGE_ID, MDL_CAL_ID, LASER_ACTION_COUNT FROM UACS_PARKING_STATUS where PARKING_NO = '{0}'";
                sqlText = string.Format(sqlText, parkingNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {
                        treatmentNo = rdr["TREATMENT_NO"].ToString();
                        LASER_ACTION_COUNT = Convert.ToInt64(rdr["LASER_ACTION_COUNT"].ToString());

                        stowageNo = rdr["STOWAGE_ID"].ToString();
                        if (rdr["MDL_CAL_ID"] != DBNull.Value)
                        {
                            currengMdlCalId = (int)rdr["MDL_CAL_ID"];
                        }
                    }
                }
                if (carType == "社会车")
                {

                    // 检查画面选定数据与后台当前数据是否一致
                    if (!dataGridView2.Rows[0].Cells["GROOVEID"].Value.ToString().Equals(""))
                    {
                        if (!CheckWithLaserOutData(treatmentNo, LASER_ACTION_COUNT))
                        {
                            RefreshHMILaserOutData();
                            MessageBox.Show("数据已发生修改，画面刷新！请重新选择材料");
                            txtCoilsWeight.Text = "";
                            txtCoilsWeight.BackColor = Color.White;
                            return;
                        }
                    }

                }
                else if (carType == "框架车")
                {

                }

                //模型计算次数
                int mdlCalId = currengMdlCalId + 1;
                myValue = string.Format("{0}|{1}|{2}|{3}|{4}-", parkingNo, truckNo, treatmentNo, mdlCalId, stowageNo);
                //MessageBox.Show(dt_selected.Rows.Count.ToString());
                for (int i = 0; i < dt_selected.Rows.Count; i++)
                {
                    if (i < 30)
                    {
                        myValue += dt_selected.Rows[i]["COIL_NO2"].ToString();
                        myValue += "|";
                    }
                }
                //debug
                //richTextBoxDebug.Text += string.Format("发送的Tag的myValue 的值：\n{0}\n", myValue);
                //DialogResult dr = MessageBox.Show(string.Format("发送的Tag的myValue 的值：\n{0}\n", myValue), "提示", MessageBoxButtons.YesNo);
                //if (dr == DialogResult.Yes)
                //{
                //    //this.Close();
                //    //return;
                //}
                //else if (dr == DialogResult.No)
                //{
                //    return;
                //}
                //debug
                //更新社会车辆中间选卷数据到配载图的选卷完成中间数据里
                string shehuicheValue = "";
                for (int i = 0; i < dt_selected.Rows.Count; i++)
                {
                    if (i < 30)
                    {
                        string coilNO = dt_selected.Rows[i]["COIL_NO2"].ToString().Trim();
                        if (coilNO.Length != 0)
                        {
                            shehuicheValue += dt_selected.Rows[i]["GROOVE_ACT_X"].ToString();
                            shehuicheValue += "|";
                            shehuicheValue += dt_selected.Rows[i]["GROOVE_ACT_Y"].ToString();
                            shehuicheValue += "|";
                            shehuicheValue += dt_selected.Rows[i]["COIL_NO2"].ToString();
                            shehuicheValue += "|";
                            shehuicheValue += dt_selected.Rows[i]["GROOVE_ACT_Z"].ToString();
                            shehuicheValue += "|";
                            if (dt_selected.Rows[i]["GROOVEID"].ToString()=="")
                            {
                                shehuicheValue += i+1;
                            }
                            else
                            {
                                shehuicheValue += dt_selected.Rows[i]["GROOVEID"].ToString();
                            }
                            shehuicheValue += "-";
                        }
                    }
                }

                sqlText = @"UPDATE UACS_TRUCK_STOWAGE SET MD_COIL_READY = '{0}' WHERE STOWAGE_ID = {1} ";
                sqlText = string.Format(sqlText, shehuicheValue, stowageNo);
                DBHelper.ExecuteNonQuery(sqlText);

                //发送tag
                myValue = myValue.Substring(0, myValue.Length - 1);

                if (carType == "社会车")
                {
                    tagDP.SetData("EV_NEW_PARKING_MDL_OUT_CAL_JUDGE", myValue);

                }
                else if (carType == "框架车")
                {
                    tagDP.SetData("EV_PARKING_MDL_OUT_CAL_START", myValue);
                }

                //更新模型计算次数
                sqlText = @"UPDATE UACS_PARKING_STATUS SET MDL_CAL_ID = {0} where PARKING_NO = '{1}'";
                sqlText = string.Format(sqlText, mdlCalId, parkingNo);
                DBHelper.ExecuteNonQuery(sqlText);
                if (carType == "社会车")
                {
                    TransferValue(coilsWeight.ToString(), true);
                }

                MessageBox.Show("材料选择成功，自动行车准备作业，请注意安全！");
                this.Close();
            }
            catch (Exception er)
            {
                TransferValue(coilsWeight.ToString(), false);
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                MessageBox.Show("车辆选择材料失败！");
            }


        }
        private string GetParkType(string stowageID )
        {
            string ret = "";
            
            try
            {
                string sql = "select CAR_TYPE from UACS_TRUCK_STOWAGE where STOWAGE_ID= '" + stowageID + "' ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        ret = rdr["STOWAGE_ID"].ToString();
                       
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
        }

        /// <summary>
        /// 用于DataGridView初始化一般属性
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static string DataGridViewInit(DataGridView dataGridView)
        {
            // dataGridView.ReadOnly = true;
            foreach (DataGridViewColumn c in dataGridView.Columns)
                if (c.Index != 0) c.ReadOnly = true;
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
            //dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.RowHeadersVisible = false;  //隐藏行标题
            //禁止用户改变DataGridView1所有行的行高  
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowTemplate.Height = 30;

            dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            return "";
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
                string truckNo = carNO;      //车号
                if (truckNo == "")
                {
                    return bResut;
                }

                // 车号对应的停车位数据
                //string sqlText = @"SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE CAR_NO = '{0}'";
                //sqlText = string.Format(sqlText, truckNo);
                //using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                //{
                //    if (rdr.Read())
                //    {
                //        parkingNo = rdr["PARKING_NO"].ToString();
                //    }
                //}
                // this.lbParkingNo.Text = parkingNo;
                parkingNo = parkNO;
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
               string sqlText = @"SELECT TREATMENT_NO, LASER_ACTION_COUNT FROM UACS_PARKING_STATUS WHERE PARKING_NO='{0}' ";
                sqlText = string.Format(sqlText, parkingNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        TREATMENT_NO = rdr["TREATMENT_NO"].ToString();
                        LASER_ACTION_COUNT = Convert.ToInt64(rdr["LASER_ACTION_COUNT"].ToString());
                    }
                }

                string GROOVE_ACT_X = "";
                string GROOVE_ACT_Y = "";
                string GROOVE_ACT_Z = "";
                string GROOVEID = "";
                dt_selected.Clear();

                //从出库激光表里取出激光扫描数据
                sqlText = @"SELECT GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z, GROOVEID FROM UACS_LASER_OUT ";
                sqlText += "WHERE TREATMENT_NO = '{0}' AND LASER_ACTION_COUNT = '{1}' ";
                sqlText += sqlorder;
                sqlText = string.Format(sqlText, TREATMENT_NO, LASER_ACTION_COUNT);

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        GROOVE_ACT_X = rdr["GROOVE_ACT_X"].ToString();
                        GROOVE_ACT_Y = rdr["GROOVE_ACT_Y"].ToString();
                        GROOVE_ACT_Z = rdr["GROOVE_ACT_Z"].ToString();
                        GROOVEID = rdr["GROOVEID"].ToString();
                        dt_selected.Rows.Add("0", GROOVEID, "", "", "", "", GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z);
                    }
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
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 查询条件：发货单号
            string queryPlanNo = "";
            if (txtGetPlanNo.Text.Trim().Length > 4)
            {
                queryPlanNo = txtGetPlanNo.Text.ToUpper().Trim();
            }
            else
            {
                txtGetPlanNo.Text = "";
            }

            // 查询条件：提单号
            string queryLotNo = "";
            if (textBox_LotNo.Text.Trim().Length > 4)
            {
                queryLotNo = textBox_LotNo.Text.ToUpper().Trim();
            }
            else
            {
                textBox_LotNo.Text = "";
            }

            // 查询条件：材料号
            string queryMatNo = "";
            if (txtGetMat.Text.Trim().Length > 5)
            {
                queryMatNo = txtGetMat.Text.Trim();
            }
            else
            {
                txtGetMat.Text = "";
            }

            // 查询条件：库位号
            string queryStockNo = "";
            if (!txtBoxStockNO.Text.Contains('-'))
            {
                txtBoxStockNO.Text = "";
            }
            else
            {
                // 解析录入的库位                
                int index = txtBoxStockNO.Text.IndexOf("-");
                if (index != -1 && txtBoxStockNO.Text != "行-列")
                {
                    queryStockNo = txtBoxStockNO.Text;
                    queryStockNo = String.Format("{0}{1}{2}", parkNO.Substring(0, 3), queryStockNo.Substring(0, index).PadLeft(3, '0'), queryStockNo.Substring(index + 1).PadLeft(3, '0'));
                }
            }

            // 按指定条件，查询的库存
            DataTable dataTable1 = BindMatStock(queryPlanNo, queryLotNo, queryMatNo, queryStockNo);
            if (dataTable1.Rows.Count==0)
            {
                MessageBox.Show("指定查询信息为空！");
            }
            // 按L3配载计划，查询的库存
            DataTable dataTable2 = BindMatStockByL3Stowage(textBox_L3_TRUCK_NO.Text, textBox_L3_PLAN_NO.Text, textBox_L3_TASK_NO.Text);

            // 查询结果合并
            dataTable1.Merge(dataTable2);

            // 绑定到表格
            this.dataGridView1.DataSource = dataTable1;

            // 转到特定查询条件的行
            if (queryPlanNo.Length != 0)
                SelectDataGridViewRow(dataGridView1, queryPlanNo, "PLAN_NO");
            if (queryMatNo.Length != 0)
                SelectDataGridViewRow(dataGridView1, queryMatNo, "COIL_NO");
            if (queryStockNo.Length != 0)
                SelectDataGridViewRow(dataGridView1, queryStockNo, "STOCK_NO");

            //// 选中行
            //if (txtBoxStockNO.Text.Trim().Length >= 1 && txtGetMat.Text.Trim() == "")
            //{
            //    foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            //    {
            //        if (dgvRow.Cells["STOCK_NO"].Value != null)
            //        {
            //            if (dgvRow.Cells["STOCK_NO"].Value.ToString() == queryStockNo)
            //            {
            //                dataGridView1.FirstDisplayedScrollingRowIndex = dgvRow.Index;
            //                dgvRow.Cells["STOCK_NO"].Selected = true;
            //                dgvRow.Cells["CHECK_COLUMN"].Value = true;
            //                dataGridView1.CurrentCell = dgvRow.Cells["STOCK_NO"];
            //                if (((DataTable)dataGridView2.DataSource).Rows.Count > 0)
            //                {
            //                    foreach (DataGridViewRow item2 in dataGridView2.Rows)
            //                    {
            //                        if (item2.Cells["COIL_NO2"].Value.ToString() == "")
            //                        {
            //                            item2.Cells[0].Value = true;
            //                            return;
            //                        }
            //                        else
            //                        {
            //                            item2.Cells[0].Value = false;
            //                        }
            //                    }
            //                }
            //                return;
            //            }
            //        }
            //    }
            //    MessageBox.Show(string.Format("没有找到指定的库位号：{0}", queryStockNo));
            //}
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
                        if (dgvRow.Cells[columnName].Value.ToString().Contains(searchString))
                        {
                            dgv.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                            dgvRow.Cells[columnName].Selected = true;
                            dgv.CurrentCell = dgvRow.Cells[columnName];
                            break;
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if (item.Index == e.RowIndex)
                    {
                        item.Cells[0].Value = true;
                    }
                    else
                    {
                        item.Cells[0].Value = false;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string matNo = "";  //材料号
                string pickNo = ""; //提单号
                string coilweight = "";
                string coilOutdia = "";
                //全选
                if (selectAllCoils())
                {
                    txtCoilsWeight.Text = string.Format("{0} /公斤", coilsWeight);
                    return;
                }
                //检测所选材料是否为单选
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    //string  hasChecked = this.dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value.ToString();  //打钩标记
                    bool hasChecked = (bool)dataGridView1.Rows[i].Cells["CHECK_COLUMN"].EditedFormattedValue;
                    if (hasChecked)
                    {
                        matNo = dataGridView1.Rows[i].Cells["COIL_NO"].Value.ToString();            //材料号
                        pickNo = dataGridView1.Rows[i].Cells["PLAN_NO"].Value.ToString();           //计划号
                        coilweight = dataGridView1.Rows[i].Cells["WEIGHT"].Value.ToString();        //重量
                        coilOutdia = dataGridView1.Rows[i].Cells["OUTDIA"].Value.ToString();        //外径

                        //count++;
                        //消除打钩
                        this.dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value = 0;
                        break;
                    }
                }

                //判断材料号是否相同
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if (item.Cells["COIL_NO2"].Value.ToString() != "")
                    {
                        if (item.Cells["COIL_NO2"].Value.ToString() == matNo)
                        {
                            MessageBox.Show(string.Format("该材料:{0}已经选择，请重新选择材料号！", matNo));
                            return;
                        }
                    }
                }
                if (((DataTable)dataGridView2.DataSource).Rows.Count==0)
                {
                    MessageBox.Show("扫描槽号结果为空。");
                    return;
                }
                for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                {
                    bool hasChecked2 = (bool)dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].EditedFormattedValue;
                    if (hasChecked2)
                    {
                        //显示钢卷中重量
                        //coilsWeight += GetCoilWeight(matNo);
                        if (coilweight != "")
                            coilsWeight += Convert.ToInt32(coilweight);
                        if (coilsWeight >= 50000)//大于50吨报警
                        {
                            txtCoilsWeight.BackColor = Color.Red;
                            //return;                               
                        }
                        else if (0 < coilsWeight && coilsWeight < 50000)
                        {
                            txtCoilsWeight.BackColor = Color.White;
                        }
                        this.dataGridView2.Rows[i].Cells["COIL_NO2"].Value = matNo;
                        this.dataGridView2.Rows[i].Cells["PICK_NO"].Value = pickNo;
                        this.dataGridView2.Rows[i].Cells["WEIGHT2"].Value = coilweight;
                        this.dataGridView2.Rows[i].Cells["OUTDIA2"].Value = coilOutdia;
                        //消除打钩
                        this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value = 0;
                        break;
                    }
                }
                txtCoilsWeight.Text = string.Format("{0} /公斤", coilsWeight);
                txtBoxStockNO.Focus();
                txtBoxStockNO.SelectAll();
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} \r\n{1}", er.Message, er.StackTrace));
            }
        }
        /// <summary>
        /// 全选
        /// </summary>
        private bool selectAllCoils()
        {
            bool ret = false;
            try
            {
                if (!checkbox.Checked)
                {
                    return ret;
                }
                ret = true;
                string matNo = "";  //材料号
                string pickNo = ""; //提单号
                string coilweight = "";
                string coilOutdia = "";


                //检测所选材料是否为单选
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    bool hasChecked = (bool)dataGridView1.Rows[i].Cells["CHECK_COLUMN"].EditedFormattedValue;
                    if (hasChecked)
                    {
                        matNo = dataGridView1.Rows[i].Cells["COIL_NO"].Value.ToString();            //材料号
                        pickNo = dataGridView1.Rows[i].Cells["PLAN_NO"].Value.ToString();           //计划号
                        coilweight = dataGridView1.Rows[i].Cells["WEIGHT"].Value.ToString();        //重量
                        coilOutdia = dataGridView1.Rows[i].Cells["OUTDIA"].Value.ToString();        //外径

                        //判断材料号是否相同
                        bool hasCoil = false;
                        foreach (DataGridViewRow item in dataGridView2.Rows)
                        {
                            if (item.Cells["COIL_NO2"].Value.ToString() != "")
                            {
                                if (item.Cells["COIL_NO2"].Value.ToString() == matNo)
                                {
                                    hasCoil = true;
                                    break;
                                }
                            }
                        }
                        if (hasCoil)
                        {
                            continue;
                        }
                        //添加进去
                        for (int k = 0; k < this.dataGridView2.Rows.Count; k++)
                        {
                            if(this.dataGridView2.Rows[k].Cells["COIL_NO2"].Value.ToString().Length>9 )
                            {
                                dataGridView2.Rows[k].Cells["CHECK_COLUMN2"].Value = false;
                                continue;
                            }

                            bool hasChecked2 = true;// (bool)dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].EditedFormattedValue;
                            if (hasChecked2)
                            {
                                //显示钢卷中重量
                                //coilsWeight += GetCoilWeight(matNo);
                                if (coilweight != "")
                                    coilsWeight += Convert.ToInt32(coilweight);
                                if (coilsWeight >= 50000)//大于50吨报警
                                {
                                    txtCoilsWeight.BackColor = Color.Red;
                                    //return;                               
                                }
                                else if (0 < coilsWeight && coilsWeight < 50000)
                                {
                                    txtCoilsWeight.BackColor = Color.White;
                                }
                                this.dataGridView2.Rows[k].Cells["COIL_NO2"].Value = matNo;
                                this.dataGridView2.Rows[k].Cells["PICK_NO"].Value = pickNo;
                                this.dataGridView2.Rows[k].Cells["WEIGHT2"].Value = coilweight;
                                this.dataGridView2.Rows[k].Cells["OUTDIA2"].Value = coilOutdia;
                                //消除打钩
                                this.dataGridView2.Rows[k].Cells["CHECK_COLUMN2"].Value = 0;
                                break;
                            }
                        }
                     //
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex ==-1 || e.ColumnIndex !=0)
                {
                    return; 
                }
                if (e.ColumnIndex == 0 )
                {
                    //checkbox.Checked = false;
                    ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value = !(bool)dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue; ;
                }
                if (((DataTable)dataGridView2.DataSource).Rows.Count > 0)
                {
                    foreach (DataGridViewRow item2 in dataGridView2.Rows)
                    {
                        if (item2.Cells["COIL_NO2"].Value.ToString() == "")
                        {
                            item2.Cells[0].Value = true;
                            return;
                        }
                        else
                        {
                            item2.Cells[0].Value = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                throw;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = this.dataGridView2.Rows.Count - 1; i >= 0; i--)
                {
                    //string  hasChecked = this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value.ToString();
                    //string coilNo = this.dataGridView2.Rows[i].Cells["COIL_NO2"].Value.ToString();
                    bool hasChecked = (bool)this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].EditedFormattedValue;
                    if (hasChecked)
                    {
                        coilsWeight -= Convert.ToInt32(dataGridView2.Rows[i].Cells["WEIGHT2"].Value);
                        this.dataGridView2.Rows[i].Cells["COIL_NO2"].Value = "";
                        this.dataGridView2.Rows[i].Cells["PICK_NO"].Value = "";
                        dataGridView2.Rows[i].Cells["WEIGHT2"].Value = "";         //重量
                        dataGridView2.Rows[i].Cells["OUTDIA2"].Value = "";        //外径

                        //消除打钩

                        this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value = 0;
                        break;
                    }
                }
                // this.dataGridView2.DataSource = dt_selected;
                txtCoilsWeight.Text = string.Format("{0} /公斤", coilsWeight);
                txtCoilsWeight.BackColor = Color.White;
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }

        private void txtBoxStockNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnQuery.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransferValue("", false);
            this.Close();
        }

        private void txtGetMat_TextChanged(object sender, EventArgs e)
        {
            string UpTem = txtGetMat.Text;
            txtGetMat.Text = UpTem.ToUpper().Trim();
            txtGetMat.SelectionStart = txtGetMat.Text.Length;
            txtGetMat.SelectionLength = 0;
            txtGetPlanNo.Text = "";
            txtBoxStockNO.Text = "";
            if (txtGetMat.Text=="1")
            {
                MessageBox.Show("卷半径干涉关闭。", "警告");
            }
        }

        private void txtGetPlanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnQuery.PerformClick();
            }
        }

        private void txtGetMat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnQuery.PerformClick();
            }
        }

        private void txtBoxStockNO_Click(object sender, EventArgs e)
        {
            txtBoxStockNO.SelectAll();
        }

        private void txtGetPlanNo_Click(object sender, EventArgs e)
        {
            txtGetPlanNo.SelectAll();
        }

        private void txtGetMat_Click(object sender, EventArgs e)
        {
            txtGetMat.SelectAll();
        }
        #region 多库位、卷信息有误判断

        private bool checkMatNOCount(out string repeatedMats)
        {
            bool ret = false;
            repeatedMats = "";
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                if (item.Cells["COIL_NO2"].Value != null && item.Cells["COIL_NO2"].Value.ToString() != "")
                {
                    string matNO = item.Cells["COIL_NO2"].Value.ToString();
                    int matNOcount = getMatCount(matNO);
                    if (matNOcount > 1)
                    {
                        repeatedMats += " 多库位钢卷：";
                        repeatedMats += matNO + "  ";
                        ret = true;                      
                        //return ret;
                    }
                    else if (matNOcount == 0)
                    {
                        repeatedMats += " 无库位钢卷: " + matNO + " ";
                        ret = true;
                    }
                    if (judgetCoilInfo(matNO, ref repeatedMats))
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }
        private int getMatCount(string matNO)
        {
            int count = 0;
            try
            {
                string sql = " SELECT COUNT (MAT_NO) AS MAT_NO_COUNT FROM UACS_YARDMAP_STOCK_DEFINE WHERE MAT_NO ='" + matNO + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        count = ManagerHelper.JudgeIntNull(rdr["MAT_NO_COUNT"]);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return count;
        }
        private bool judgetCoilInfo(string coilNO, ref string retInfo)
        {
            bool ret = false;          
            try
            {
                string sql = " SELECT  WEIGHT, WIDTH, INDIA, OUTDIA FROM UACS_YARDMAP_COIL WHERE COIL_NO ='" + coilNO + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        int weight = ManagerHelper.JudgeIntNull(rdr["WEIGHT"]);
                        int width = ManagerHelper.JudgeIntNull(rdr["WIDTH"]);
                        int inDIA = ManagerHelper.JudgeIntNull(rdr["INDIA"]);
                        int outDIA = ManagerHelper.JudgeIntNull(rdr["OUTDIA"]);
                        if (weight < 10)
                        {
                            retInfo += "\r\n";
                            retInfo += " 钢卷信息有误：" + coilNO + " , ";
                            retInfo += " 重量小于10 ; ";
                            ret = true;
                        }
                        if (width < 100)
                        {
                            retInfo += "\r\n";
                            retInfo += " 钢卷信息有误：" + coilNO + " , ";
                            retInfo += " 宽度小于100 ; ";
                            ret = true;
                        }
                        if (inDIA < 10)
                        {
                            retInfo += "\r\n";
                            retInfo += " 钢卷信息有误：" + coilNO + " , ";
                            retInfo += " 内径小于10 ; ";
                            ret = true;
                        }
                        if (outDIA < 10)
                        {
                            retInfo += "\r\n";
                            retInfo += " 钢卷信息有误：" + coilNO + " , ";
                            retInfo += " 外径小于10 ; ";
                            ret = true;
                        }
                    }
                    else
                    {
                        retInfo += "\r\n";
                        retInfo += "没有钢卷信息 ：" + coilNO + ";";
                        ret = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }

        #endregion

        private void textBox_L3_TRUCK_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_L3_TRUCK_NO.Text = "";
            textBox_L3_PLAN_NO.Text = "";
            textBox_L3_TASK_NO.Text = "";

            dataGridView1.DataSource = null;
        }

        private void textBox_L3_PLAN_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_L3_TRUCK_NO.Text = "";
            textBox_L3_PLAN_NO.Text = "";
            textBox_L3_TASK_NO.Text = "";

            dataGridView1.DataSource = null;
        }

        private void textBox_L3_TASK_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_L3_TRUCK_NO.Text = "";
            textBox_L3_PLAN_NO.Text = "";
            textBox_L3_TASK_NO.Text = "";

            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            string bayNO ="";
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            if (dgv.Columns[e.ColumnIndex].Name.Equals("STOCK_NO"))
            {
                if (e.Value==null || e.Value.ToString()=="")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.Value = "无库位";
                }
                else if((e.Value.ToString().Contains('-')))
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.Value = "已装车";
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Name.Equals("BAY_NO"))
            {
                if (e.Value == null &&  e.Value.ToString() == "")
                {
                    bayNO =e.Value.ToString(); 
                    
                }
                if(!bayNO.Contains(parkNO.Substring(0, 3)))
                {
                    dgv.Rows[e.RowIndex].Cells["STOCK_NO"].Style.BackColor = Color.Red;
                }

            }


        }
    }
}
