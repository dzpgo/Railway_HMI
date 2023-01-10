using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.TagService.Controls;
using Baosight.iSuperframe.Forms;

namespace ParkingControlLibrary
{
    public partial class BillMatManage : FormBase
    {
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;
        DataTable dt = new DataTable();
        bool hasSetColumn = false;
        DataTable dt_selected = new DataTable();
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        int count = 0;

        #region 数据库连接
        public BillMatManage()
        {
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
        }
        #endregion

        #region 页面加载
        private void BillMatManage_Load(object sender, EventArgs e)
        {
            try
            {
                //设置背景色
                this.panel1.BackColor = Color.FromArgb(242, 246, 252);
                this.panel2.BackColor = Color.FromArgb(242, 246, 252);
                
                //绑定提单号
                BindPickNo();
                
                //社会车辆配载材料grid列
                dt_selected.Columns.Add("CHECK_COLUMN2");
                dt_selected.Columns.Add("GROOVE_ACT_X");
                dt_selected.Columns.Add("GROOVE_ACT_Y");
                dt_selected.Columns.Add("COIL_NO2");
                dt_selected.Columns.Add("PICK_NO");
                dt_selected.Columns.Add("GROOVE_ACT_Z");
                dt_selected.Columns.Add("GROOVEID");

                tagDP.ServiceName = "iplature";
                tagDP.AutoRegist = true;
                TagValues.Clear();
                TagValues.Add("EV_PARKING_MDL_OUT_CAL_JUDGE", null);
                tagDP.Attach(TagValues);
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        #endregion

        #region 提单号选择切换事件
        private void cbBoxPickNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //绑定计划详细信息
                BindPlanDetail();

                //绑定材料位置信息
                BindMatStock();
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        #endregion

        #region +按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string matNo = "";
                //检测所选材料是否为单选
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    string hasChecked = this.dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value.ToString();  //打钩标记
                    if (hasChecked == "1")
                    {
                        matNo = this.dataGridView1.Rows[i].Cells["COIL_NO"].Value.ToString();            //材料号
                        count++;

                        //消除打钩
                        this.dataGridView1.Rows[i].Cells["CHECK_COLUMN"].Value = 0;
                    }
                }
                if (count > 1)
                {
                    //初始化
                    count = 0;
                    MessageBox.Show("提单中的材料选择信息只能单选！");
                    return;
                }
                //初始化
                count = 0;

                for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                {
                    string hasChecked = this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value.ToString();  //打钩标记
                    if (hasChecked == "1")
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    //初始化
                    count = 0;
                    MessageBox.Show("社会车辆配载材料信息选择只能单选！");
                    return;
                }
                //初始化
                count = 0;

                //提单号下拉不能为空
                if (this.cbBoxPickNo.SelectedValue == null)
                {
                    MessageBox.Show("提单号不能为空！");
                    return;
                }

                string pickNo = this.cbBoxPickNo.SelectedValue.ToString();                  //提单号

                for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                {
                    string hasChecked = this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value.ToString();  //打钩标记
                    if (hasChecked == "1")
                    {
                        this.dataGridView2.Rows[i].Cells["COIL_NO2"].Value = matNo;
                        this.dataGridView2.Rows[i].Cells["PICK_NO"].Value = pickNo;
                        //消除打钩
                        this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value = 0;
                    }
                }
                this.dataGridView2.DataSource = dt_selected;
            }
            catch (Exception er)
            {
                //MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        #endregion

        #region -按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = this.dataGridView2.Rows.Count - 1; i >= 0; i--)
                {
                    string hasChecked = this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value.ToString();
                    string coilNo = this.dataGridView2.Rows[i].Cells["COIL_NO2"].Value.ToString();
                    if (hasChecked == "1")
                    {
                        this.dataGridView2.Rows[i].Cells["COIL_NO2"].Value = "";
                        this.dataGridView2.Rows[i].Cells["PICK_NO"].Value = "";
                        //消除打钩
                        this.dataGridView2.Rows[i].Cells["CHECK_COLUMN2"].Value = 0;
                    }
                }
                this.dataGridView2.DataSource = dt_selected;
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        #endregion

        #region 确认按钮事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string truckNo = GetCarNo();
                string parkingNo = this.lbParkingNo.Text.Trim();
                //框架车号不能为空
                if (truckNo == "")
                {
                    MessageBox.Show("框架车号不能为空");
                    return;
                }
                //车位号不能为空
                if (parkingNo == "")
                {
                    MessageBox.Show("该框架车找不到对应的停车位号");
                    return;
                }

                //检查社会车辆两个可见光落点间距是否大于彼此材料半径加上安全距离（防止碰撞）
                //先获取车头方向配置表里的车长方向坐标轴
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

                int GROOVE_ACT_X1 = 0;
                int GROOVE_ACT_Y1 = 0;
                int GROOVE_ACT_X2 = 0;
                int GROOVE_ACT_Y2 = 0;
                string MAT_NO1 = "";
                string MAT_NO2 = "";
                int OUTDIA1 = 0;
                int OUTDIA2 = 0;
                string sqlText_outdia = "";

                //卷径干涉判断
                for (int j = 0; j < this.dataGridView2.Rows.Count; j++)
                {
                    if (j < this.dataGridView2.Rows.Count - 1)
                    {
                        GROOVE_ACT_X1 = Convert.ToInt32(this.dataGridView2.Rows[j].Cells["GROOVE_ACT_X"].Value.ToString());  //槽中心点X1
                        GROOVE_ACT_Y1 = Convert.ToInt32(this.dataGridView2.Rows[j].Cells["GROOVE_ACT_Y"].Value.ToString());  //槽中心点Y1
                        MAT_NO1 = this.dataGridView2.Rows[j].Cells["COIL_NO2"].Value.ToString();                             //材料号1

                        GROOVE_ACT_X2 = Convert.ToInt32(this.dataGridView2.Rows[j + 1].Cells["GROOVE_ACT_X"].Value.ToString());  //槽中心点X2
                        GROOVE_ACT_Y2 = Convert.ToInt32(this.dataGridView2.Rows[j + 1].Cells["GROOVE_ACT_Y"].Value.ToString());  //槽中心点Y2
                        MAT_NO2 = this.dataGridView2.Rows[j + 1].Cells["COIL_NO2"].Value.ToString();                             //材料号2

                        //获取材料号1的外径
                        sqlText_outdia = @"SELECT OUTDIA FROM UACS_YARDMAP_COIL WHERE COIL_NO = '{0}'";
                        sqlText_outdia = string.Format(sqlText_outdia, MAT_NO1);
                        using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_outdia))
                        {
                            if (rdr.Read())
                            {
                                OUTDIA1 = (int)rdr["OUTDIA"];
                                OUTDIA1 = OUTDIA1 / 2;
                            }
                        }

                        //获取材料号2的外径
                        sqlText_outdia = @"SELECT OUTDIA FROM UACS_YARDMAP_COIL WHERE COIL_NO = '{0}'";
                        sqlText_outdia = string.Format(sqlText_outdia, MAT_NO2);
                        using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_outdia))
                        {
                            if (rdr.Read())
                            {
                                OUTDIA2 = (int)rdr["OUTDIA"];
                                OUTDIA2 = OUTDIA2 / 2;
                            }
                        }

                        if (AXES_CAR_LENGTH == "X" && TREND_TO_TAIL == "INC")
                        {
                            //目前暂定安全距离10，后续待调整改为可配置
                            if (GROOVE_ACT_X2 - GROOVE_ACT_X1 - OUTDIA1 - OUTDIA2 <= 10)
                            {
                                MessageBox.Show("落点钢卷之间距离小于安全距离，请重新选择配载材料！");
                                return;
                            }
                        }
                        else if (AXES_CAR_LENGTH == "X" && TREND_TO_TAIL == "DES")
                        {
                            //目前暂定安全距离10，后续待调整改为可配置
                            if (GROOVE_ACT_X1 - GROOVE_ACT_X2 - OUTDIA1 - OUTDIA2 <= 10)
                            {
                                MessageBox.Show("落点钢卷之间距离小于安全距离，请重新选择配载材料！");
                                return;
                            }
                        }
                        else if (AXES_CAR_LENGTH == "Y" && TREND_TO_TAIL == "INC")
                        {
                            if (GROOVE_ACT_Y2 - GROOVE_ACT_Y1 - OUTDIA1 - OUTDIA2 <= 10)
                            {
                                MessageBox.Show("落点钢卷之间距离小于安全距离，请重新选择配载材料！");
                                return;
                            }
                        }
                        else if (AXES_CAR_LENGTH == "Y" && TREND_TO_TAIL == "DES")
                        {
                            if (GROOVE_ACT_Y1 - GROOVE_ACT_Y2 - OUTDIA1 - OUTDIA2 <= 10)
                            {
                                MessageBox.Show("落点钢卷之间距离小于安全距离，请重新选择配载材料！");
                                return;
                            }
                        }
                    }
                }

                ////判断该材料是否已被其他车选走
                //string matNo = "";
                //string sqlText_order = "";
                //int NUM = 0;
                //for (int k = 0; k < this.dataGridView2.Rows.Count; k++)
                //{
                //    matNo = this.dataGridView2.Rows[k].Cells["COIL_NO2"].Value.ToString();                             //材料号

                //    //根据材料号去吊运指令表找寻是否有生成的指令信息
                //    sqlText_order = @"SELECT COUNT(*) AS NUM FROM UACS_CRANE_ORDER_Z32_Z33 WHERE MAT_NO = '{0}'";
                //    sqlText_order = string.Format(sqlText_order, matNo);
                //    using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_order))
                //    {
                //        if (rdr.Read())
                //        {
                //            NUM = (int)rdr["NUM"];
                //        }
                //    }
                //    if (NUM > 0)
                //    {
                //        MessageBox.Show("选中的配载材料中有已经生成吊运指令的材料存在，请重新选择配载材料！");
                //        return;
                //    }
                //}

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

                // 检查画面选定数据与后台当前数据是否一致
                if (!CheckWithLaserOutData(treatmentNo, LASER_ACTION_COUNT))
                {
                    RefreshHMILaserOutData();
                    MessageBox.Show("数据已发生修改，画面刷新！请重新选择材料");
                    return;
                }

                //模型计算次数
                int mdlCalId = currengMdlCalId + 1;
                myValue = string.Format("{0}|{1}|{2}|{3}|{4}-", parkingNo, truckNo, treatmentNo, mdlCalId, stowageNo);
                for (int i = 0; i < dt_selected.Rows.Count; i++)
                {
                    if (i < 30)
                    {
                        myValue += dt_selected.Rows[i]["COIL_NO2"].ToString();
                        myValue += "|";
                    }
                }

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
                            shehuicheValue += dt_selected.Rows[i]["GROOVEID"].ToString();
                            shehuicheValue += "-";
                        }
                    }
                }

                sqlText = @"UPDATE UACS_TRUCK_STOWAGE SET MD_COIL_READY = '{0}' WHERE STOWAGE_ID = {1} ";
                sqlText = string.Format(sqlText, shehuicheValue, stowageNo);
                DBHelper.ExecuteNonQuery(sqlText);

                //发送tag
                myValue = myValue.Substring(0, myValue.Length - 1);
                tagDP.SetData("EV_PARKING_MDL_OUT_CAL_JUDGE", myValue);

                //更新模型计算次数
                sqlText = @"UPDATE UACS_PARKING_STATUS SET MDL_CAL_ID = {0} where PARKING_NO = '{1}'";
                sqlText = string.Format(sqlText, mdlCalId, parkingNo);
                DBHelper.ExecuteNonQuery(sqlText);

                MessageBox.Show("社会车辆选择材料成功！");
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 绑定计划号
        /// </summary>
        private void BindPickNo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            //车号
            string truckNo = GetCarNo();

            //车号不能为空
            if (truckNo == "")
            {
                return;
            }

            //准备数据（从装卸车作业绑定表里读取之前已经绑定的最新一批提单号）
            string sqlText = @"SELECT PICK_NO AS TypeValue FROM UACS_TRUCK_PICK_BIND WHERE CAR_NO = '{0}' AND SEQ IN (SELECT MAX(SEQ) AS SEQ FROM UACS_TRUCK_PICK_BIND WHERE CAR_NO = '{0}') ";
            sqlText = string.Format(sqlText, truckNo);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeValue"] = rdr["TypeValue"];
                    dt.Rows.Add(dr);
                }
            }

            //绑定列表下拉框数据
            this.cbBoxPickNo.DataSource = dt;
            this.cbBoxPickNo.DisplayMember = "TypeValue";
            this.cbBoxPickNo.ValueMember = "TypeValue";
        }

        /// <summary>
        /// 绑定计划详细信息
        /// </summary>
        private void BindPlanDetail()
        {
            this.lbLotNo.Text = "";
            this.lbTransMode.Text = "";
            this.lbDestination.Text = "";
            this.lbCarrier.Text = "";
            this.lbSettler.Text = "";

            //提单号下拉不能为空
            if (this.cbBoxPickNo.SelectedValue == null)
            {
                return;
            }
            //提单号
            string pickNo = this.cbBoxPickNo.SelectedValue.ToString();

            //准备数据
            string sqlText = @"SELECT * FROM UACS_PLAN_L3PICK WHERE PICK_NO='{0}'";
            sqlText = string.Format(sqlText, pickNo);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    this.lbLotNo.Text = rdr["LOT_NO"].ToString();
                    this.lbTransMode.Text = rdr["TRANS_MODE"].ToString();
                    this.lbDestination.Text = rdr["DESTINATION"].ToString();
                    this.lbCarrier.Text = rdr["CARRIER"].ToString();
                    this.lbSettler.Text = rdr["SETTLER"].ToString();
                }
            }

            //准备数据
            string sqlText1 = @"SELECT * FROM UACS_PLAN_L3TRANS where PLAN_NO='{0}'";
            sqlText = string.Format(sqlText1, pickNo);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText1))
            {
                while (rdr.Read())
                {
                    this.lbLotNo.Text = rdr["LOT_NO"].ToString();
                    this.lbTransMode.Text = rdr["TRANS_MODE"].ToString();
                    this.lbDestination.Text = rdr["DESTINATION"].ToString();
                    this.lbCarrier.Text = rdr["CARRIER"].ToString();
                    this.lbSettler.Text = rdr["SETTLER"].ToString();
                }
            }
        }

        /// <summary>
        /// 绑定材料位置信息
        /// </summary>
        private void BindMatStock()
        {
            dt.Clear();

            //提单号不为空
            if (this.cbBoxPickNo.SelectedValue == null)
            {
                return;
            }
            
            //提单号
            string pickNo = this.cbBoxPickNo.SelectedValue.ToString();

            //发货(根据库位状态和封锁标记只查出可吊的钢卷)
            string sqlText = @"SELECT 0 AS CHECK_COLUMN, A.COIL_NO, G.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, ";
            sqlText += "B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.STEEL_GRANDID, ";
            sqlText += "B.ACT_WEIGHT, B.ACT_WIDTH, C.X_CENTER, C.Y_CENTER, C.Z_CENTER FROM UACS_PLAN_L3PICK A ";
            sqlText += "LEFT JOIN UACS_YARDMAP_COIL B ON A.COIL_NO = B.COIL_NO ";
            sqlText += "LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON C.MAT_NO = A.COIL_NO AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 ";
            sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_STOCK D ON C.STOCK_NO = D.STOCK_NO ";
            sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_DEFINE E ON D.SADDLE_NO = E.SADDLE_NO ";
            sqlText += "LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE F ON E.COL_ROW_NO = F.COL_ROW_NO ";
            sqlText += "LEFT JOIN UACS_YARDMAP_AREA_DEFINE G ON F.AREA_NO = G.AREA_NO ";
            sqlText += "WHERE A.PICK_NO = '{0}' ";
            sqlText = string.Format(sqlText, pickNo);

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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

            //转库(根据库位状态和封锁标记只查出可吊的钢卷)
            sqlText = @"SELECT 0 AS CHECK_COLUMN, A.COIL_NO, G.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, ";
            sqlText += "B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.STEEL_GRANDID, ";
            sqlText += "B.ACT_WEIGHT, B.ACT_WIDTH, C.X_CENTER, C.Y_CENTER, C.Z_CENTER FROM UACS_PLAN_L3TRANS A ";
            sqlText += "LEFT JOIN UACS_YARDMAP_COIL B ON A.COIL_NO = B.COIL_NO ";
            sqlText += "LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON C.MAT_NO = A.COIL_NO AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 ";
            sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_STOCK D ON C.STOCK_NO = D.STOCK_NO ";
            sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_DEFINE E ON D.SADDLE_NO = E.SADDLE_NO ";
            sqlText += "LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE F ON E.COL_ROW_NO = F.COL_ROW_NO ";
            sqlText += "LEFT JOIN UACS_YARDMAP_AREA_DEFINE G ON F.AREA_NO = G.AREA_NO ";
            sqlText += "WHERE A.PLAN_NO = '{0}' ";
            sqlText = string.Format(sqlText, pickNo);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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
            this.dataGridView1.DataSource = dt;
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
        #endregion

        private string GetCarNo()
        {
            string carNo = this.txtBoxTruckNo.Text.ToUpper().Trim();

            if (carNo.Length == 0)
                return carNo;

            if (this.btnArea.Text.Trim() != "空")
            {
                carNo = this.btnArea.Text.ToUpper().Trim() + carNo;
            }
            if (checkBox_gua.Checked == true)
            {
                carNo = carNo + "挂";
            }

            return carNo;
        }

        #region 车号事件
        private void txtBoxTruckNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //绑定提单号
                BindPickNo();

                // 刷新激光数据
                RefreshHMILaserOutData();
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        #endregion

        #region 社会车辆车号前汉字
        private void btnArea_Click(object sender, EventArgs e)
        {
            try
            {
                CarNo form = new CarNo();
                form.ShowDialog();
                form.StartPosition = FormStartPosition.CenterScreen;
                this.btnArea.Text = form.Area;

                //绑定提单号
                BindPickNo();

                // 刷新激光扫描数据
                RefreshHMILaserOutData();
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        #endregion

        #region 挂事件
        private void checkBox_gua_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //绑定提单号
                BindPickNo();

                // 刷新激光扫描数据
                RefreshHMILaserOutData();
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        #endregion

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

                        //MessageBox.Show(String.Format("x={0}, y={1}, z={2}", laseroutData.GROOVE_ACT_X, laseroutData.GROOVE_ACT_Y, laseroutData.GROOVE_ACT_Z));
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
                //MessageBox.Show(String.Format("nCountCoil={0}, nCountChecked={1}", nCountCoil, nCountChecked));


                // 数据与后台均匹配
                if (nCountChecked == nCountCoil && nCountCoil != 0)
                    bResult = true;

                //MessageBox.Show(String.Format("bResult={0}", bResult));
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }

            return bResult;
        }

        private bool RefreshHMILaserOutData()
        {
            bool bResut = false;
            try
            {
                string parkingNo = "";
                string TREATMENT_NO = "";
                long LASER_ACTION_COUNT = 0;

                // 读取车牌数据
                string truckNo = GetCarNo();      //车号
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
                this.lbParkingNo.Text = parkingNo;

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
                        dt_selected.Rows.Add("0", GROOVE_ACT_X, GROOVE_ACT_Y, "", "", GROOVE_ACT_Z, GROOVEID);
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
    }
}
