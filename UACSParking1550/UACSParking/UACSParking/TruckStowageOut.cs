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
using Baosight.iSuperframe.Utility;
using ParkingControlLibrary;
using ParkClassLibrary;

namespace UACSParking
{
    public partial class TruckStowageOut : Baosight.iSuperframe.Forms.FormBase
    {
        IAuthorization auth = Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<Baosight.iSuperframe.Authorization.Interface.IAuthorization>()
        as Baosight.iSuperframe.Authorization.Interface.IAuthorization;
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagProvider_OutStock = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        public TruckStowageOut()
        {
            InitializeComponent();
        }
        public TruckStowageOut(string parkNO)
        {
            InitializeComponent();
            cmbArea.Text = GetOperateArea(parkNO);
            parkingNO = parkNO;
        }
       // bool hasSetColumn_PT = false;
        bool hasSetColumn_Laser = false;
        bool hasSetColumn_LoadMap = false;
        ToolTip toolTip1 = new ToolTip();
        //画面刷新
        bool isStowage = false;
        bool hasCar = true;  //车位无车
        //画面跳转
        string parkingNO = "";

        //手持
        DataTable dt_PT = new DataTable();

        //激光
        DataTable dt_Laser = new DataTable();

        //配载
        DataTable dt_LoadMap = new DataTable();

        //停车位
        DataTable dt_ParkingStatus = new DataTable();

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

        //tag服务
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();


        #region 页面加载
        private void TruckStowageTestOUT2_Load(object sender, EventArgs e)
        {
            try
            {
                //设置背景色
                this.lblTitle.BackColor = Color.FromArgb(242, 246, 252);
                this.panel1.BackColor = Color.FromArgb(242, 246, 252);
                cmbArea.BackColor = Color.FromArgb(242, 246, 252);
                //this.splitContainer1.Panel2.BackColor = Color.FromArgb(242, 246, 252);
                DataGridViewInit(dgvCraneOder);
                DataGridViewInit(dataGridView_LASER);
                DataGridViewInit(dataGridView_LaodMap);

                tagProvider_OutStock.ServiceName = "iplature";
                tagProvider_OutStock.AutoRegist = true;
                TagValues.Clear();
                TagValues.Add("EV_PARKING_HMI_TRUCKSTOWAGEOUT", null);
                tagProvider_OutStock.Attach(TagValues);

                InsertDataSet();
                //GetComboxArea(cmbArea);
                GetComboxOnParking(comb_ParkingNO);
                comb_ParkingNO.Text = "";
                cmbArea.SelectedIndexChanged += cmbArea_SelectedIndexChanged;
                comb_ParkingNO.SelectedIndexChanged += comb_ParkingNO_SelectedIndexChanged;

                timer_RefrehHMI.Enabled = true;
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
                    comb_ParkingNO.Text = parkingNO;
                    comb_ParkingNO_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetComboxOnParking(comb_ParkingNO);
            //comb_ParkingNO.Text = "请选择";
            //comb_ParkingNO_SelectedIndexChanged(null, null);
        }

        void comb_ParkingNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comb_ParkingNO.Text.Contains('Z'))
                return;
            if (JumpToOtherForm(comb_ParkingNO.Text))
            {
                btnRefresh_Click(null, null);
                return;
            }
            isStowage = false;
            hasCar = true;
            try
            {
                RefreshHMI();
                btnOperateStrat.ForeColor = Color.White;
                btnOperatePause.ForeColor = Color.White;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
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
        void parkLaserOut1_LabClick(string matNO)
        {
            SelectDataGridViewRow(dataGridView_LaodMap, matNO, "MAT_NO2");
        }

        public void InsertDataSet()
        {
            //创建虚拟数据表  
            DataTable table_laser = new DataTable();
            DataTable table_loadmap = new DataTable();
            DataTable table_PT = new DataTable();

            //激光静态表
            DataColumnCollection columns_laser = table_laser.Columns;
            columns_laser.Add("LASER_ID", typeof(Int32));
            columns_laser.Add("GROOVE_ACT_X", typeof(Int32));
            columns_laser.Add("GROOVE_ACT_Y", typeof(Int32));
            columns_laser.Add("GROOVE_ACT_Z", typeof(Int32));

            //配载图静态表
            DataColumnCollection columns_loadmap = table_loadmap.Columns;
            columns_loadmap.Add("MAT_NO", typeof(String));
            columns_loadmap.Add("POS_ON_FRAME", typeof(String));
            columns_loadmap.Add("X_CENTER", typeof(Int32));
            columns_loadmap.Add("Y_CENTER", typeof(Int32));
            columns_loadmap.Add("Z_CENTER", typeof(Int32));
            columns_loadmap.Add("X_RELETIVE", typeof(Int32));
            columns_loadmap.Add("Y_RELETIVE", typeof(Int32));

            //手持静态表
            DataColumnCollection columns_PT = table_PT.Columns;
            columns_PT.Add("PORTABLE_ID", typeof(Int32));
            columns_PT.Add("MAT_NO", typeof(String));
        }
        #endregion

        string treatmentNO = string.Empty;
        int ptCount = 0;
        int laserCount = 0;
        int stowageId = 0;
        string headPosition = string.Empty;

        #region 查询


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
        private void RefreshHMI()
        {
            bool stopRefresh = false;
            if (!comb_ParkingNO.Text.Contains('Z'))
            {
                return;
            }
            if (isStowage)
            {
                return;
            }

            //停车位主体信息查询
            Inq_ParkingStatus();
            //查询暂停状态
            GetOperateStatus(comb_ParkingNO.Text.Trim());
            if (!hasCar)
            {
                stopRefresh = txt_TreatmentNO.Text.Contains('Z');
                hasCar = stopRefresh;
                txtDebug.Text = hasCar.ToString();//没车只刷一次
                return;
            }
            //手持扫描信息查询
            //Inq_PT(treatmentNO, ptCount);

            //激光出库扫描信息查询
            Inq_Laser(treatmentNO, laserCount);

            //框架配载图信息查询
            Inq_LoadMap(stowageId);
            //刷新激光扫描图像数据 
            LoadLaserInfo(comb_ParkingNO.Text.Trim(), laserCount, parkLaserOut1);
            //刷新指令表
            RefreshOrderDgv(comb_ParkingNO.Text);
            //刷新车上卷
            reflreshParkingCoilstate(comb_ParkingNO.Text.Trim());

            stopRefresh = txt_TreatmentNO.Text.Contains('Z');
            hasCar = stopRefresh;
            txtDebug.Text = hasCar.ToString();//没车只刷一次
        }

        private void Inq_ParkingStatus()
        {
            try
            {
                string PARKING_NO = comb_ParkingNO.Text.ToString().Trim();     //停车位

                treatmentNO = string.Empty;
                ptCount = 0;
                laserCount = 0;
                stowageId = 0;

                //停车位主体信息
                string sqlText_ParkingStatus = @"SELECT TREATMENT_NO, STOWAGE_ID, CAR_NO, ISLOADED, HEAD_POSTION, PARKING_STATUS, LASER_ACTION_COUNT, PT_ACTION_COUNT FROM UACS_PARKING_STATUS ";
                if (PARKING_NO != "")
                {
                    sqlText_ParkingStatus += " WHERE PARKING_NO = '" + PARKING_NO + "' ";
                }

                //初始化停车位信息
                Clear_ParkingStatus();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_ParkingStatus))
                {
                    while (rdr.Read())
                    {
                        if (rdr["TREATMENT_NO"] != System.DBNull.Value)
                        {
                            txt_TreatmentNO.Text = Convert.ToString(rdr["TREATMENT_NO"]);
                            treatmentNO = Convert.ToString(rdr["TREATMENT_NO"]);
                        }
                        if (rdr["CAR_NO"] != System.DBNull.Value)
                        {
                            txt_CarNO.Text = Convert.ToString(rdr["CAR_NO"]);
                        }
                        if (rdr["STOWAGE_ID"] != System.DBNull.Value)
                        {
                            txt_LoadMapID.Text = Convert.ToString(rdr["STOWAGE_ID"]);
                            stowageId = Convert.ToInt32(rdr["STOWAGE_ID"]);
                        }
                        if (rdr["ISLOADED"] != System.DBNull.Value)
                        {
                            if (Convert.ToString(rdr["ISLOADED"]) == "0")
                            {
                                txt_ISLoaded.Text = "空车";
                            }
                            else if (Convert.ToString(rdr["ISLOADED"]) == "1")
                            {
                                txt_ISLoaded.Text = "重车";
                            }    
                        }
                        if (rdr["HEAD_POSTION"] != System.DBNull.Value)
                        {
                            //txt_HeadPos.Text = Convert.ToString(rdr["HEAD_POSTION"]);
                            switch (Convert.ToString(rdr["HEAD_POSTION"]))
                            {
                                case "E":
                                    txt_HeadPos.Text = "东";
                                    break;
                                case "W":
                                    txt_HeadPos.Text = "西";
                                    break;
                                case "S":
                                    txt_HeadPos.Text = "南";
                                    break;
                                case "N":
                                    txt_HeadPos.Text = "北";
                                    break;
                                default:
                                    txt_HeadPos.Text = "无";
                                    break;
                            }
                            headPosition = Convert.ToString(rdr["HEAD_POSTION"]);
                        }
                        if (rdr["PARKING_STATUS"] != System.DBNull.Value)
                        {
                            switch (Convert.ToString(rdr["PARKING_STATUS"]))
                            {
                                case "5":
                                    txt_ParkingStatus.Text = "无车";
                                    break;
                                case "10":
                                    txt_ParkingStatus.Text = "有车到达";
                                    break;
                                case "110":
                                    txt_ParkingStatus.Text = "激光扫描开始";
                                    break;
                                case "120":
                                    txt_ParkingStatus.Text = "入库激光扫描完成";
                                    break;
                                case "130":
                                    txt_ParkingStatus.Text = "入库手持扫描完成";
                                    break;
                                case "140":
                                    txt_ParkingStatus.Text = "入库计划生成";
                                    break;
                                case "170":
                                    txt_ParkingStatus.Text = "入库暂停";
                                    break;
                                case "210":
                                    txt_ParkingStatus.Text = "出库激光扫描开始";
                                    break;
                                case "220":
                                    txt_ParkingStatus.Text = "出库激光扫描完成";
                                    break;
                                case "240":
                                    txt_ParkingStatus.Text = "出库计划生成";
                                    break;
                                case "270":
                                    txt_ParkingStatus.Text = "出库暂停";
                                    break;
                                default:
                                    break;
                            }
                            if (txt_ParkingStatus.Text.Contains("暂停"))
                            {
                                txt_ParkingStatus.ForeColor = Color.Orange;
                            }
                            else
                            {
                                txt_ParkingStatus.ForeColor = Color.Silver;
                            }
                        }
                        if (rdr["LASER_ACTION_COUNT"] != System.DBNull.Value)
                        {
                            txt_LASER_ACTION_COUNT.Text = Convert.ToString(rdr["LASER_ACTION_COUNT"]);
                            laserCount = Convert.ToInt16(rdr["LASER_ACTION_COUNT"]);
                        }
                        //if (rdr["PT_ACTION_COUNT"] != System.DBNull.Value)
                        //{
                        //    txtGrooveTotal.Text = Convert.ToString(rdr["PT_ACTION_COUNT"]);
                        //    ptCount = Convert.ToInt32(rdr["PT_ACTION_COUNT"]);
                        //}
                    }
                }

                //出库激光车边框信息
                string sqlText_Border = @"SELECT CAR_X_BORDER_MAX, CAR_X_BORDER_MIN, CAR_Y_BORDER_MAX, CAR_Y_BORDER_MIN FROM UACS_LASER_OUT WHERE 1=1 ";

                sqlText_Border += " AND LASER_ACTION_COUNT = '" + laserCount + "' AND TREATMENT_NO = '" + treatmentNO + "' FETCH FIRST 1 ROWS ONLY ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_Border))
                {
                    while (rdr.Read())
                    {
                        if (rdr["CAR_X_BORDER_MAX"] != System.DBNull.Value)
                        {
                            txt_CAR_X_BORDER_MAX.Text = Convert.ToString(rdr["CAR_X_BORDER_MAX"]);
                        }
                        if (rdr["CAR_X_BORDER_MIN"] != System.DBNull.Value)
                        {
                            txt_CAR_X_BORDER_MIN.Text = Convert.ToString(rdr["CAR_X_BORDER_MIN"]);
                        }
                        if (rdr["CAR_Y_BORDER_MAX"] != System.DBNull.Value)
                        {
                            txt_CAR_Y_BORDER_MAX.Text = Convert.ToString(rdr["CAR_Y_BORDER_MAX"]);
                        }
                        if (rdr["CAR_Y_BORDER_MIN"] != System.DBNull.Value)
                        {
                            txt_CAR_Y_BORDER_MIN.Text = Convert.ToString(rdr["CAR_Y_BORDER_MIN"]);
                        }
                    }
                }
                //激光扫描统计
                string sqlTextTotal = @"SELECT COUNT(distinct(LASER_ID)) AS IDTOTAL  FROM UACS_LASER_OUT WHERE 1=1 ";

                sqlTextTotal += " AND LASER_ACTION_COUNT = '" + laserCount + "' AND TREATMENT_NO = '" + treatmentNO + "' FETCH FIRST 1 ROWS ONLY ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlTextTotal))
                {
                    while (rdr.Read())
                    {
                        if (rdr["IDTOTAL"] != System.DBNull.Value)
                        {
                            if (Convert.ToInt16(rdr["IDTOTAL"]) == 0 && txt_CarNO.Text.Equals(""))
                            {
                                txtGrooveTotal.Text="";
                                txtGrooveTotal.BackColor = Color.White;
                            }
                            else
                            {
                                txtGrooveTotal.Text = Convert.ToString(rdr["IDTOTAL"]);
                                if ( txtGrooveTotal.Text !=txtGrooveNum.Text )
                                {
                                    txtGrooveTotal.BackColor = Color.Red;
                                }
                            }
                        }
                    }
                }

                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        private void Inq_PT(string theTreatmentNO, int theCount)
        {
            //try
            //{
            //    //手持扫描信息
            //    string sqlText_PT = @"SELECT PORTABLE_ID, MAT_NO FROM UACS_PDA_SCAN WHERE 1=1 ";
            //    sqlText_PT += " AND PROCESS_NO = '" + theTreatmentNO + "' AND PT_ACTION_COUNT = '" + theCount + "' ";
            //    sqlText_PT += " ORDER BY COIL_POSITION_7 ";

            //    //初始化
            //    //dt_PT.Clear();
            //    dt_PT = new DataTable();

            //    using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_PT))
            //    {
            //        while (rdr.Read())
            //        {
            //            DataRow dr = dt_PT.NewRow();
            //            for (int i = 0; i < rdr.FieldCount; i++)
            //            {
            //                if (!hasSetColumn_PT)
            //                {
            //                    DataColumn dc = new DataColumn();
            //                    dc.ColumnName = rdr.GetName(i);
            //                    dt_PT.Columns.Add(dc);
            //                }
            //                dr[i] = rdr[i];
            //            }
            //            hasSetColumn_PT = true;
            //            dt_PT.Rows.Add(dr);
            //        }
            //    }
            //    hasSetColumn_PT = false;

            //    //初始化grid数据
            //    if (dataGridView_PT.DataSource != null)
            //    {
            //        ((DataTable)dataGridView_PT.DataSource).Rows.Clear();
            //    }
            //    if (dt_PT.Rows.Count == dt_PT.Columns.Count && dt_PT.Rows.Count == 0)
            //    {

            //    }
            //    else
            //    {
            //        dataGridView_PT.DataSource = dt_PT;
            //    }
            //}
            //catch (Exception er)
            //{
            //    MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            //}
        }

        private void Inq_Laser(string theTreatmentNO, int theCount)
        {
            try
            {
                //出库激光扫描信息
                string sqlText_Laser = @"SELECT  LASER_ID, GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z FROM UACS_LASER_OUT WHERE 1=1 ";
                sqlText_Laser += " AND TREATMENT_NO = '" + theTreatmentNO + "' AND LASER_ACTION_COUNT = '" + theCount + "' ";
                sqlText_Laser += " ORDER BY GROOVEID, GROOVE_ACT_Y ";

                //初始化
                //dt_Laser.Clear();
                dt_Laser = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_Laser))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt_Laser.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn_Laser)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt_Laser.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn_Laser = true;
                        dt_Laser.Rows.Add(dr);
                    }
                }
                hasSetColumn_Laser = false;

                //初始化grid
                if (dataGridView_LASER.DataSource != null)
                {
                    ((DataTable)dataGridView_LASER.DataSource).Rows.Clear();
                }
                if (dt_Laser.Rows.Count == dt_Laser.Columns.Count && dt_Laser.Rows.Count == 0)
                {
                }
                else
                {
                    dataGridView_LASER.DataSource = dt_Laser;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        private void Inq_LoadMap(int thestowageId)
        {
            try
            {
                //框架配载图信息
                string sqlText_LoadMap = @"SELECT A.GROOVEID , A.MAT_NO,C.PICK_NO, A.POS_ON_FRAME, A.X_CENTER, A.Y_CENTER, A.Z_CENTER, A.X_RELETIVE, A.Y_RELETIVE,E.STOCK_NO, E.LOCK_FLAG, D.WEIGHT, D.OUTDIA ,D.WIDTH ,D.PACK_FLAG  FROM UACS_TRUCK_STOWAGE_DETAIL A ";
                sqlText_LoadMap += "  LEFT JOIN UACS_TRUCK_STOWAGE B ON A.STOWAGE_ID = B.STOWAGE_ID ";
                sqlText_LoadMap += " LEFT JOIN  UACS_PLAN_L3PICK C ON A.MAT_NO = C.COIL_NO ";
                sqlText_LoadMap += " LEFT JOIN  UACS_YARDMAP_COIL D ON A.MAT_NO = D.COIL_NO ";
                sqlText_LoadMap += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE E ON A.MAT_NO = E.MAT_NO ";
                sqlText_LoadMap += " WHERE 1=1  AND B.STOWAGE_ID = '" + stowageId + "' ORDER BY A.POS_ON_FRAME ";

                //初始化
                //dt_LoadMap.Clear();
                dt_LoadMap = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_LoadMap))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt_LoadMap.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn_LoadMap)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt_LoadMap.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn_LoadMap = true;
                        dt_LoadMap.Rows.Add(dr);
                    }
                }
                hasSetColumn_LoadMap = false;

                //初始化grid数据
                if (dataGridView_LaodMap.DataSource != null)
                {
                    ((DataTable)dataGridView_LaodMap.DataSource).Rows.Clear();
                }
                if (dt_LoadMap.Rows.Count == dt_LoadMap.Columns.Count && dt_LoadMap.Rows.Count == 0)
                {

                }
                else
                {
                    dataGridView_LaodMap.DataSource = dt_LoadMap;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        /// <summary>
        /// 车位绑定激光数据
        /// </summary>
        /// <param name="strParkNo"></param>
        private void LoadLaserInfo(string strParkNo, int laserActionCount, ParkLaserOut park)
        {
            DataTable dtLaserData = new DataTable();
            DataTable dtParksize = new DataTable();
            DataTable dtStowageData = new DataTable();

            try
            {
                if (!strParkNo.Contains('Z'))
                {
                    return;
                }

                dtParksize.Clear();
                dtLaserData.Clear();

                park.ClearbitM();
                string sqlLaser = @"SELECT CAR_X_BORDER_MAX,CAR_X_BORDER_MIN,CAR_Y_BORDER_MAX,CAR_Y_BORDER_MIN,GROOVE_ACT_X,GROOVE_ACT_Y,GROOVE_ACT_Z,GROOVEID FROM UACS_LASER_OUT  ";
                sqlLaser = string.Format("{0}  WHERE TREATMENT_NO  IN (SELECT TREATMENT_NO FROM UACS_PARKING_STATUS WHERE PARKING_NO = '{1}' AND LASER_ACTION_COUNT = '{2}') ORDER BY GROOVEID, GROOVE_ACT_Y", sqlLaser, strParkNo, laserActionCount); //strParkNo:Z53A1
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlLaser))
                {
                    dtLaserData.Load(rdr);
                }
                string sqlPark = string.Format("SELECT * FROM UACS_YARDMAP_PARKINGSITE WHERE NAME ='{0}' AND YARD_NO = '{1}'", strParkNo, strParkNo.Substring(0, 3));
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlPark))
                {
                    dtParksize.Load(rdr);
                }

                string sqlStowage = @" SELECT C.MAT_NO,C.X_CENTER,C.Y_CENTER ,C.GROOVEID, B.OUTDIA ,B.WIDTH, A.STOCK_NO,A.LOCK_FLAG FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                sqlStowage += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
                sqlStowage += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlStowage += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                sqlStowage += " WHERE PARKING_NO ='{0}')  ORDER BY GROOVEID  ";
                sqlStowage = string.Format(sqlStowage, comb_ParkingNO.Text);

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStowage))
                {
                    dtStowageData.Clear();
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
                //park.CreatePassageWayArea(XStart - 500, YEnd + 1500, 5200, 16000);
                park.CreatePassageWayArea(XStart - 500, YEnd + 1800, 5200, 17000);
                park.DrawParksize(XStart, YEnd, XEnd - XStart, YEnd - YStart);
                //生成车位置
                ////获取车位坐标XMin, XMax, YMin, YMax
                int XMin, XMax, YMin, YMax;
                int XVehicleLength, YVehicleLength;
               // int XView, YView;
                XMin = XMax = YMin = YMax = XVehicleLength = YVehicleLength = 0;
                if (dtLaserData.Rows.Count != 0)
                {
                    XMin = JudgeIntNull(dtLaserData.Rows[0]["CAR_X_BORDER_MIN"]);
                    XMax = JudgeIntNull(dtLaserData.Rows[0]["CAR_X_BORDER_MAX"]);
                    YMin = JudgeIntNull(dtLaserData.Rows[0]["CAR_Y_BORDER_MIN"]);
                    YMax = JudgeIntNull(dtLaserData.Rows[0]["CAR_Y_BORDER_MAX"]);
                    XVehicleLength = XMax - XMin;
                    YVehicleLength = YMax - YMin;
                    //画面显示
                    if (txt_HeadPos.Text=="西")
                    {
                        park.CreateCarSize(XMin, YMax, XVehicleLength, YVehicleLength, 1, "W"); //框架车类型不一样1，社会车0
                    }
                    else
                    park.CreateCarSize(XMin, YMax, XVehicleLength, YVehicleLength, 1, "E"); //框架车类型不一样1，社会车0
                }
                else
                {
                    park.ClearbitM();
                    return;
                }
 
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
                        //park.CreateCoilSize(n1, n2, n4, n3, strID, true, strMat, toolTip1);
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

        private bool reflreshParkingCoilstate(string parkNO)
        {
            DataTable dtStowage = new DataTable();
            bool ret = false;
            string matNO;
            string coilStatus;
            string MapID = txt_LoadMapID.Text.Trim();
            if (!parkNO.Contains('Z') || MapID.Trim().Length<2)
            {
                return ret;
            }

            try
            {
                string sqlStowage = @" SELECT C.MAT_NO,C.STATUS FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                sqlStowage += " WHERE C.STOWAGE_ID = " + MapID + " ORDER BY GROOVEID ";
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
                        parkLaserOut1.ChangeCoilState(matNO, coilStatus, "1");
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
        /// 刷新指令表
        /// </summary>
        private void RefreshOrderDgv(string parkNO)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
               // string sql = string.Format("select BAY_NO,MAT_NO,FROM_STOCK_NO,TO_STOCK_NO from UACS_CRANE_ORDER_Z32_Z33 WHERE BAY_NO ='{0}' AND ORDER_TYPE = '23' ", parkNO);  //社会车？？框架车23

                string SQLOder = " SELECT C.GROOVEID, C.MAT_NO,B.BAY_NO,B.FROM_STOCK_NO ,B.TO_STOCK_NO FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                SQLOder += " RIGHT JOIN UACS_CRANE_ORDER_Z32_Z33 B ON C.MAT_NO = B.MAT_NO ";
                SQLOder += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                SQLOder += " WHERE PARKING_NO ='{0}') ORDER BY  C.GROOVEID ";
                SQLOder = string.Format(SQLOder, parkNO);
                using (IDataReader odrIn = DBHelper.ExecuteReader(SQLOder))
                {
                    dt.Load(odrIn);
                }
                dgvCraneOder.DataSource = dt;
                //DataGridViewBindingSource(dgvCraneOder, SQLOder);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }

        }
        /// <summary>
        /// 获得当前车信息
        /// </summary>
        private void GetCurrentCarInfo(string parkNOA)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                string SQLOder = " SELECT A.LENGTH,A.WIDTH,A.HEIGHT,A.LOAD_CAPACITY,A.SADDLE_NUM,A.SADDLE_INTERVAL,A.DISTANCE_HEAD,A.DISTANCE_LEFT,A.DISTANCE_RIGHT";
                SQLOder += " FROM UACS_TRUCK_FRAME_DEFINE A WHERE FRAME_TYPE_NO IN ( SELECT  CAR_NO FROM UACS_PARKING_STATUS B WHERE B.PARKING_NO ='{0}') ";
                SQLOder = string.Format(SQLOder, parkNOA);
                using (IDataReader odrIn = DBHelper.ExecuteReader(SQLOder))
                {
                    dt.Load(odrIn);
                }
                dgvCraneOder.DataSource = dt;
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        txtCarL.Text = JudgeStrNull(item["LENGTH"]);
                        txtCarW.Text = JudgeStrNull(item["WIDTH"]);
                        txtCarH.Text = JudgeStrNull(item["HEIGHT"]);
                        txtGrooveDist.Text = JudgeStrNull(item["SADDLE_INTERVAL"]);
                        txtGrooveNum.Text = JudgeStrNull(item["SADDLE_NUM"]);
                        txtHeadDist.Text = JudgeStrNull(item["DISTANCE_HEAD"]);
                        txtsideDist.Text = JudgeStrNull(item["DISTANCE_LEFT"]);
                    }
                }
                else
                {
                    txtCarL.Text = "";
                    txtCarW.Text = "";
                    txtCarH.Text = "";
                    txtGrooveDist.Text = "";
                    txtGrooveNum.Text = "";
                    txtHeadDist.Text = "";
                    txtsideDist.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        /// <summary>
        /// DataGridView显示指定的数据源
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        private bool DataGridViewBindingSource(DataGridView dataGridView, string sql)
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
        /// <summary>
        /// 用于DataGridView初始化一般属性
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private string DataGridViewInit(DataGridView dataGridView)
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

        /// <summary>
        /// 获取配载信息
        /// </summary>
        /// <param name="stowageID"></param>
        /// <returns></returns>
        private bool GetStowageDetail()
        {
            bool retu = false;
            try
            {
                string sqlStowage = @" SELECT C.MAT_NO FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                sqlStowage += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
                sqlStowage += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                sqlStowage += " WHERE PARKING_NO ='{0}')  ORDER BY C.GROOVEID  "; 
                sqlStowage = string.Format(sqlStowage, comb_ParkingNO.Text.Trim());
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStowage)) 
                {
                    while (rdr.Read())
                    {
                        if (rdr["MAT_NO"] != DBNull.Value)
                        {
                            retu = true;
                            return retu;
                        } 
                    }
                }
                return retu;
            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return retu;
            }
        }

        #endregion

        #region 车到位
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_CarNO.Text.Trim() == "")
                {
                    FrmCarEntry frm = new FrmCarEntry();
                    frm.PackingNo = comb_ParkingNO.Text.Trim();
                    frm.CarType = "框架车";
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("车位已经有车！", "提示");
                }

                //Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();

                ////有车到达  
                //string theOperator = "HMI";
                //string date = "20171128";
                //string shift = "1";
                //string crew = "1";
                //string pullAbility = "1";
                //string equno = "101"; //社会车

                ////跳转画面
                //string HeadPos = txt_HeadPos.Text.Trim();
                //switch (HeadPos)
                //{
                //    case "东":
                //        HeadPos = "E";
                //        break;
                //    case "西":
                //        HeadPos = "W";
                //        break;
                //    case "南":
                //        HeadPos = "S";
                //        break;
                //    case "北":
                //        HeadPos = "N";
                //        break;
                //    default:
                //        break;
                //}

                //string ISLoaded = txt_ISLoaded.Text.Trim();
                //switch (ISLoaded)
                //{
                //    case "空车":
                //        ISLoaded = "0";
                //        break;
                //    case "重车":
                //        ISLoaded = "1";
                //        break;
                //    default:
                //        break;
                //}
                //TagCarArrive form = new TagCarArrive(comb_ParkingNO.Text.Trim(), txt_CarNO.Text.Trim(), HeadPos, ISLoaded);
                //form.StartPosition = FormStartPosition.CenterScreen;
                //form.ShowDialog();
               
                //string parkingNO = form.TAG_PARKING_NO;
                //string carNO = form.TAG_CAR_NO;
                //string isLoaded = form.TAG_ISLOADED;     //1为空，2为满(我们自己0 是空，1是满，要转换)
                //string headPostion = form.TAG_HEAD_POSTION;
                //bool cancelFlag = form.CANCEL_FLAG;
                //string cartype = form.TAG_CAR_TYPE;
                //string parkingype = form.TAG_PARKING_TYPE;

                //if (cancelFlag == false)
                //{
                //    //平台配置
                //    tagProvider_OutStock.ServiceName = "iplature";
                //    tagProvider_OutStock.AutoRegist = true;

                //    //添加tag点到数组
                //    TagValues.Add("EV_NEW_PARKING_CARARRIVE", null);
                //    //tagProvider_CarArrive.Attach(TagValues);
                //    string strDebug = theOperator + "|" + date + "|" + shift + "|" + crew + "|" + parkingNO + "|" + carNO + "|" + isLoaded + "|" + headPostion + "|" + pullAbility + "|" + equno + "|" + cartype + "|" + parkingype;
                //    DialogResult dr = MessageBox.Show(string.Format("发送的Tag的myValue 的值：\n{0}\n", strDebug), "提示", MessageBoxButtons.OK);
                //    if (dr == DialogResult.OK)
                //    {
                //        //this.Close();
                //        //return;
                //    }
                //    else
                //    {
                //        return;
                //    }
                //    tagProvider_OutStock.SetData("EV_NEW_PARKING_CARARRIVE", theOperator + "|" + date + "|" + shift + "|" + crew + "|" + parkingNO + "|" + carNO + "|" + isLoaded + "|" + headPostion + "|" + pullAbility + "|" + equno + "|" + cartype + "|" + parkingype);
                //}
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        #region 车离开
        private void cmd_CarLeave_Click(object sender, EventArgs e)
        {
            try
            {
                if ( !comb_ParkingNO.Text.Contains('Z'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (GetParkStatus(comb_ParkingNO.Text.Trim()) == "5" || txt_CarNO.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不需要车离。");
                    btnRefresh_Click(null, null);
                    return;
                }

                //Baosight.iSuperframe.TagService.DataCollection<object> TagValues1 = new DataCollection<object>();

                ////跳转画面
                //TagCarLeave form = new TagCarLeave(comb_ParkingNO.Text.Trim());
                //form.StartPosition = FormStartPosition.CenterScreen;
                //form.ShowDialog();
                
                //string parkingNO = form.TAG_PARKING_NO;
                //bool cancelFlag = form.CANCEL_FLAG;

                //if (cancelFlag == false)
                //{
                //平台配置
                //tagProvider_OutStock.ServiceName = "iplature";
                //tagProvider_OutStock.AutoRegist = true;

                //添加tag点到数组
                //TagValues.Add("EV_NEW_PARKING_CARLEAVE", null);

                //tagProvider_OutStock.Attach(TagValues);
                
                //tagProvider_OutStock.SetData("EV_PARKING_CARLEAVE", parkingNO);
                //}

                if (comb_ParkingNO.Text.Trim() != "请选择" || comb_ParkingNO.Text.Trim() != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要对" + comb_ParkingNO.Text.Trim() + "跨进行车离位吗？", "操作提示", btn,MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        tagProvider_OutStock.SetData("EV_NEW_PARKING_CARLEAVE", comb_ParkingNO.Text.Trim());
                        //MessageBox.Show("已通知" + comb_ParkingNO.Text.Trim() + "跨车离开");
                        //刷新开启
                        isStowage = false;
                        dt_Laser.Clear();
                        dataGridView_LASER.DataSource = dt_Laser;
                        dt_LoadMap.Clear();
                        dataGridView_LaodMap.DataSource = dt_LoadMap;

                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        #region 初始化方法
        private void Clear_ParkingStatus()
        {
            txt_TreatmentNO.Text = "";
            txt_CarNO.Text = "";
            txt_LoadMapID.Text = "";
            txt_ISLoaded.Text = "";
            txt_HeadPos.Text = "";
            txt_ParkingStatus.Text = "";
            txt_LASER_ACTION_COUNT.Text = "";
            txtGrooveTotal.Text = "";
            txtGrooveTotal.BackColor = Color.White;
            txt_CAR_X_BORDER_MAX.Text = "";
            txt_CAR_X_BORDER_MIN.Text = "";
            txt_CAR_Y_BORDER_MAX.Text = "";
            txt_CAR_Y_BORDER_MIN.Text = "";

        }
        /// <summary>
        /// 绑定作业区域信息
        /// </summary>
        private void GetComboxArea(ComboBox comBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            try
            {
                string sqlText = @"SELECT DISTINCT SUBSTR( ID, 1,4) as  TypeValue ,SUBSTR( NAME, 1,4)  as TypeName FROM UACS_YARDMAP_PARKINGSITE";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr["TypeValue"] = rdr["TypeValue"];
                        dr["TypeName"] = rdr["TypeName"];
                        dt.Rows.Add(dr);
                    }
                }
                //绑定列表下拉框数据
                comBox.DataSource = dt;
                comBox.DisplayMember = "TypeName";
                comBox.ValueMember = "TypeValue";
                comBox.Text = "请选择";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        /// <summary>
        /// 绑定停车位信息
        /// </summary>
        private void GetComboxOnParking(ComboBox comBox)
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
                    str1="Z5";
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
            comBox.DataSource = dt;
            comBox.DisplayMember = "TypeName";
            comBox.ValueMember = "TypeValue";
            comBox.SelectedItem = 0;
            //

        }
        #endregion

        #region tag变化刷新画面查询事件
        private void tagProvider_OutStock_DataChangedEvent(object sender, Baosight.iSuperframe.TagService.Interface.DataChangedEventArgs e)
        {
            try
            {
                if (isStowage == true)
                {
                    if (comb_ParkingNO.Text.Contains('Z'))
                    {
                        reflreshParkingCoilstate(comb_ParkingNO.Text.Trim());
                        RefreshOrderDgv(comb_ParkingNO.Text);
                    }
                }
                //停车位主体信息查询
                Inq_ParkingStatus();

                //手持扫描信息查询
                Inq_PT(treatmentNO, ptCount);

                //激光出库扫描信息查询
                Inq_Laser(treatmentNO, laserCount);

                //框架配载图信息查询
                Inq_LoadMap(stowageId);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        #region 启动激光扫描
        private void cmd_LaserINStart_Click(object sender, EventArgs e)
        {
            try
            {
                Baosight.iSuperframe.TagService.DataCollection<object> TagValuesStart = new DataCollection<object>();

                //跳转画面
                TagLaserInStart form = new TagLaserInStart(comb_ParkingNO.Text.Trim());
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
                
                string parkingNO = form.TAG_PARKING_NO;
                bool cancelFlag = form.CANCEL_FLAG;

                if (cancelFlag == false)
                {
                    //平台配置
                    tagProvider_OutStock.ServiceName = "iplature";
                    tagProvider_OutStock.AutoRegist = true;

                    //添加tag点到数组
                    TagValuesStart.Add("EV_PARKING_LASERSTART", null);
                    tagProvider_OutStock.SetData("EV_PARKING_LASERSTART", parkingNO);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        } 
        #endregion

        #region 删除出库激光数据
        private void cmd_DelOutLaserData_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlText = "";
                int laserID;
                string carNO = txt_CarNO.Text.ToString().Trim();
                if (carNO.Length > 4)
                {
                    for (int i = 0; i < this.dataGridView_LASER.Rows.Count; i++)
                    {
                        int hasChecked = Convert.ToInt32(this.dataGridView_LASER.Rows[i].Cells["SELECT"].Value);  //打钩标记
                        if (hasChecked == 1)
                        {
                            laserID = Convert.ToInt32(this.dataGridView_LASER.Rows[i].Cells["LASER_ID"].Value);

                            //删除选中的出库激光扫描数据
                            sqlText = @"DELETE FROM UACS_LASER_OUT WHERE LASER_ID = {0} ";
                            sqlText = string.Format(sqlText, laserID);
                            DBHelper.ExecuteNonQuery(sqlText);
                        }
                    }
                    //停车位主体信息查询
                    Inq_ParkingStatus();

                    //手持扫描信息查询
                    Inq_PT(treatmentNO, ptCount);

                    //激光出库扫描信息查询
                    Inq_Laser(treatmentNO, laserCount);

                    //框架配载图信息查询
                    Inq_LoadMap(stowageId);
                }
                else
                {
                    MessageBox.Show("只有社会车辆才能操作此按钮！"); 
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        #region 社会车辆出库激光数据确认
        private void cmd_LaserOutEnd_Click(object sender, EventArgs e)
        {
            try
            {
                Baosight.iSuperframe.TagService.DataCollection<object> TagValues2 = new DataCollection<object>();

                //入库激光扫描完成(停车位编号|框架车号|处理号|单车内激光扫描次数)	
                //跳转画面
                TagLaserInEnd form = new TagLaserInEnd(comb_ParkingNO.Text.Trim(), txt_CarNO.Text.Trim(), txt_TreatmentNO.Text.Trim(), txt_LASER_ACTION_COUNT.Text.Trim());
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();

                string PARKING_NO = form.TAG_PARKING_NO;
                string CAR_NO = form.TAG_CAR_NO;
                string TREATMENT_NO = form.TAG_TREATMENT_NO;
                string LASER_ACTION_COUNT = form.TAG_LASER_ACTION_COUNT;
                bool cancelFlag = form.CANCEL_FLAG;

                if (cancelFlag == false)
                {
                    //平台配置
                    tagProvider_OutStock.ServiceName = "iplature";
                    tagProvider_OutStock.AutoRegist = true;

                    //添加tag点到数组
                    TagValues2.Add("EV_PARKING_OUT_LASEREND", null);
                    //Laser.Attach(TagValues);
                    tagProvider_OutStock.SetData("EV_PARKING_OUT_LASEREND", PARKING_NO + "|" + CAR_NO + "|" + TREATMENT_NO + "|" + LASER_ACTION_COUNT);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        private void timer_RefrehHMI_Tick(object sender, EventArgs e)
        {
            if (isStowage == true || GetOperateStatus(comb_ParkingNO.Text.Trim()))
            {
                if (comb_ParkingNO.Text.Contains('Z'))
                {
                    reflreshParkingCoilstate(comb_ParkingNO.Text.Trim());
                    RefreshOrderDgv(comb_ParkingNO.Text);
                }
            }
            //foreach (DataGridViewRow item in dataGridView_LaodMap.Rows)
            //{
            //    if (dataGridView_LaodMap.DataSource!=null && item.Cells["MAT_NO2"].Value!= null
            //        && txt_ParkingStatus.Text == "出库激光扫描完成")
            //    {
            //        if (item.Cells["MAT_NO2"].Value.ToString().Length < 5)
            //        {
            //            break;
            //        }
            //        isStowage = true;
            //        return;
            //    }
            //}
            if (dataGridView_LaodMap.DataSource != null && ((DataTable)dataGridView_LaodMap.DataSource).Rows.Count > 0)
            {
                isStowage = true;
                return;
            }
            isStowage = false;
            RefreshHMI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isStowage)
            {
                MessageBox.Show("车辆已经配载材料，请先做车离。");
                return;
            }
            if (txt_CarNO.Text.Equals(""))
            {
                MessageBox.Show("请先做车入位！");
                return;
            }
            if (comb_ParkingNO.Text.Trim() != "请选择" && comb_ParkingNO.Text.Trim() != "" && comb_ParkingNO.Text.Trim().Contains('Z'))
            {
               string parkNO=comb_ParkingNO.Text;
               string GrooveNum = txtGrooveTotal.Text;
               if (auth.IsOpen("框架车出库材料选择"))
               {
                   auth.CloseForm("框架车出库材料选择");
                   auth.OpenForm("框架车出库材料选择", parkNO, GrooveNum);
               }
               else
                   auth.OpenForm("框架车出库材料选择", parkNO, GrooveNum);
            }
            else
            {
                MessageBox.Show("车位号信息不正确！");
            }
        }

        void selectCoilF_TransferValue(string weight, bool isLoad)
        {
            RefreshHMI();
            isStowage = isLoad;
        }

        private void dataGridView_LaodMap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0)
                && dataGridView_LaodMap.Rows[e.RowIndex].Cells["MAT_NO2"].Value != null
                 && dataGridView_LaodMap.Rows[e.RowIndex].Cells["MAT_NO2"].Value.ToString() != "")
            {
                if (dataGridView_LaodMap.Columns[e.ColumnIndex].Name.Equals("LOCK_FLAG")
                    || dataGridView_LaodMap.Columns[e.ColumnIndex].Name.Equals("STOCK_NO"))
                {
                    if (e.Value == null || e.Value.ToString() == "")
                    {
                        e.Value = "";
                        e.CellStyle.BackColor = Color.Red;
                        return;
                    }
                    //if (e.Value.Equals(0))
                    //    e.Value = "可用";
                    //else if (e.Value.Equals(1))
                    //{
                    //    e.Value = "待判";
                    //    e.CellStyle.BackColor = Color.Yellow;
                    //}
                    //else if (e.Value.Equals(2))
                    //{
                    //    e.Value = "封锁";
                    //    e.CellStyle.BackColor = Color.Red;
                    //}
                    if (e.Value.ToString()=="0")
                    {
                       e.Value = "可用";
                    }
                    else if (e.Value.ToString()=="1")
                    {
                        e.Value = "待判";
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    else if (e.Value.ToString()=="2")
                    {
                        e.Value = "封锁";
                        e.CellStyle.BackColor = Color.Red;
                    }


                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isStowage = false;
            RefreshHMI();
        }

        private void txt_CarNO_TextChanged(object sender, EventArgs e)
        {
            if (comb_ParkingNO.Text.Trim() != "请选择" && comb_ParkingNO.Text.Trim() != "" && comb_ParkingNO.Text.Trim().Contains('Z'))
            GetCurrentCarInfo(comb_ParkingNO.Text);
            else
            {
                txtCarL.Text = "";
                txtCarW.Text = "";
                txtCarH.Text = "";
                txtGrooveDist.Text = "";
                txtGrooveNum.Text = "";
                txtHeadDist.Text = "";
                txtsideDist.Text = "";
            }
        }

        private void btnSeleceByMat_Click(object sender, EventArgs e)
        {
            if (GetStowageDetail())
            {
                MessageBox.Show("车辆已经配载材料，请先做车离。");
                return;
            }
            SelectCoilForm selectCoilF = new SelectCoilForm();
            selectCoilF.CarType = "框架车";
            if (comb_ParkingNO.Text.Trim() != "请选择" && comb_ParkingNO.Text.Trim() != "" && comb_ParkingNO.Text.Trim().Contains('Z'))
            {
                selectCoilF.ParkNO = comb_ParkingNO.Text.Trim();  //Z53A1
                selectCoilF.TransferValue += selectCoilF_TransferValue;

                if (txt_CarNO.Text.Trim().Length > 3)
                    selectCoilF.CarNO = txt_CarNO.Text.Trim();
                else
                {
                    MessageBox.Show("车牌号信息不正确！");
                    return;
                }
                selectCoilF.ShowDialog();
            }
            else
            {
                MessageBox.Show("车位号信息不正确！");
            }
        }
        #region 开始作业
        private void btnOperateStrat_Click(object sender, EventArgs e)
        {
            try
            {
                if (comb_ParkingNO.Text.Trim() == "" || !comb_ParkingNO.Text.Contains('Z'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (txt_CarNO.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不能开始。");
                    return;
                }

                if (comb_ParkingNO.Text.Trim() != "请选择" || comb_ParkingNO.Text.Trim() != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("是否对"+ comb_ParkingNO.Text.Trim() + "作业开始？", "提示", btn,MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        //tagProvider_OutStock.SetData("EV_PARKING_JOB_RESUME", comb_ParkingNO.Text.Trim());EV_NEW_PARKING_Z33_CRANE_ALLOW
                        tagProvider_OutStock.SetData("EV_NEW_PARKING_Z33_CRANE_ALLOW", comb_ParkingNO.Text.Trim());
                        //foreach (DataGridViewRow item in dgvCraneOder.Rows)
                        //{
                        //    if (item.Cells["MAT_NO"].Value==null)
                        //    {
                        //        continue;
                        //    }
                        //    string MatNO = item.Cells["MAT_NO"].Value.ToString();
                        //    if ( MatNO!="")
                        //    {
                        //        SetStowageStatus0(txt_LoadMapID.Text.Trim(), MatNO);
                        //    }                          
                        //}
                        btnOperateStrat.ForeColor = Color.Green;
                        btnOperatePause.ForeColor = Color.White;
                        //

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

        #region 暂停作业
        private void btnOperatePause_Click(object sender, EventArgs e)
        {
            try
            {
                if (comb_ParkingNO.Text.Trim() == "" || !comb_ParkingNO.Text.Contains('Z'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (txt_CarNO.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不能开始。");
                    return;
                }

                if (comb_ParkingNO.Text.Trim() != "请选择" || comb_ParkingNO.Text.Trim() != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show( "是否对"+comb_ParkingNO.Text.Trim() + "作业暂停？", "提示", btn,MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        //tagProvider_OutStock.SetData("EV_PARKING_JOB_PAUSE", comb_ParkingNO.Text.Trim());EV_NEW_PARKING_Z32_CRANE_ALLOW
                        tagProvider_OutStock.SetData("EV_NEW_PARKING_Z32_CRANE_ALLOW", comb_ParkingNO.Text.Trim());
                        //SetStowageStatus100(txt_LoadMapID.Text.Trim());
                        btnOperatePause.ForeColor = Color.Orange;
                        btnOperateStrat.ForeColor = Color.White;
                       
                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
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
        private void SetStowageStatus100(string StowageID)
        {
            try
            {
                if ( txt_LoadMapID.Text.Trim()=="")
                {
                    return;
                }
                string sqlText = @"UPDATE UACS_TRUCK_STOWAGE_DETAIL SET STATUS = '{0}' WHERE STOWAGE_ID = {1} ";
                sqlText = string.Format(sqlText, 100, StowageID);
                DBHelper.ExecuteNonQuery(sqlText);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        private void SetStowageStatus0(string StowageID,string CoilNO)
        {
            try
            {
                if (txt_LoadMapID.Text.Trim() == "" || CoilNO =="" )
                {
                    return;
                }
                string sqlText = @"UPDATE UACS_TRUCK_STOWAGE_DETAIL SET STATUS = '{0}' WHERE STOWAGE_ID = {1} AND MAT_NO = {2} ";
                sqlText = string.Format(sqlText, 0, StowageID,CoilNO);
                DBHelper.ExecuteNonQuery(sqlText);
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
            string strStatus = GetParkStatus(currPark,out carType);
            if (strStatus=="")
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
            else if (strStatus.Substring(0, 1) == "2" && (carType!=100 && carType!=103)) //社车出库
            {
                if (auth.IsOpen("成品库社会车出库"))
                {
                    auth.CloseForm("成品库社会车出库");
                }
                auth.OpenForm("成品库社会车出库", currPark);
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
                sqlText+=" LEFT JOIN UACS_TRUCK_STOWAGE A ON C.STOWAGE_ID = A.STOWAGE_ID ";
                sqlText+=" WHERE PARKING_NO = '" + parkingNO + "'";
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
//private void refresh
    }
}
