using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CONTROLS_OF_REPOSITORIES;

namespace HMI_OF_REPOSITORIES
{
    public partial class FrmStockStrategyManageYard : Baosight.iSuperframe.Forms.FormBase
    {
        string craneNO = "1";
        string coilAreaNO = "";
        string saddleAreaNO = "";
        public FrmStockStrategyManageYard()
        {
            InitializeComponent();
            this.Load += FrmStockStrategyManageYard_Load;
        }

        void FrmStockStrategyManageYard_Load(object sender, EventArgs e)
        {
            UACSUtility.ViewHelper.DataGridViewInit(dgvStrategy);
           // BindCarType(cmbbCarNO);
            UACSUtility.ViewHelper.DataGridViewInit(dgvStrategyDetail);
            UACSUtility.ViewHelper.DataGridViewInit(dgvSaddleDetail);
            dgvStrategy.CellMouseClick += dgvStrategy_CellMouseDoubleClick;
            dgvStrategy.CellContentClick += dgvStrategy_CellContentClick;
            dgvStrategy.CellFormatting += dgvStrategy_CellFormatting;
            dgvStrategyDetail.CellFormatting += dgvStrategyDetail_CellFormatting;
            dgvStrategyDetail.CellMouseClick += dgvStrategyDetail_CellMouseClick;
            dgvSaddleDetail.CellMouseClick += dgvSaddleStrategyDetail_CellMouseClick;
            cmbArea.SelectedIndexChanged += cmbArea_SelectedIndexChanged;

        }
        void dgvStrategyDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //单击显示区域
            if (e.RowIndex >= 0 && senderGrid.Rows[e.RowIndex].Cells["ID2"].Value != null)
            {
                ClsSmallArea smallArea = new ClsSmallArea();
                smallArea.areaName = UACSUtility.ViewHelper.JudgeStrNull(senderGrid.Rows[e.RowIndex].Cells["DESC2"].Value);
                smallArea.areaID = UACSUtility.ViewHelper.JudgeStrNull(senderGrid.Rows[e.RowIndex].Cells["ID2"].Value);
                //smallArea.enable = UACSUtility.ViewHelper.JudgeStrNull(senderGrid.Rows[e.RowIndex].Cells["FLAG_ENABLED2"].Value) == "1" ? true : false;
                smallArea.logisticsFlag = UACSUtility.ViewHelper.JudgeStrNull(senderGrid.Rows[e.RowIndex].Cells["LIST_UNIT_NO"].Value);  //机组字段为流向
                smallArea.point = new Point(UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["X_MIN2"].Value),
                    UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["Y_MIN2"].Value));
                int s_x = UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["X_MAX2"].Value)
                    - UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["X_MIN2"].Value);
                int s_y = UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["Y_MAX2"].Value)
                    - UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["Y_MIN2"].Value);
                smallArea.size = new Size(s_x, s_y);
                displaySmallArea(smallArea);
            }
        }
        void dgvSaddleStrategyDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //单击显示区域
            if (e.RowIndex >= 0 && senderGrid.Rows[e.RowIndex].Cells["ID3"].Value != null)
            {
                ClsSmallArea smallArea = new ClsSmallArea();
                smallArea.areaName = UACSUtility.ViewHelper.JudgeStrNull(senderGrid.Rows[e.RowIndex].Cells["DESC3"].Value);
                smallArea.areaID = UACSUtility.ViewHelper.JudgeStrNull(senderGrid.Rows[e.RowIndex].Cells["ID3"].Value);
               // smallArea.enable = UACSUtility.ViewHelper.JudgeStrNull(senderGrid.Rows[e.RowIndex].Cells["FLAG_ENABLED3"].Value) == "1" ? true : false;
                //smallArea.logisticsFlag = UACSUtility.ViewHelper.JudgeStrNull(senderGrid.Rows[e.RowIndex].Cells["FLOW_TO2"].Value);
                smallArea.point = new Point(UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["X_MIN3"].Value),
                    UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["Y_MIN3"].Value));
                int s_x = UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["X_MAX3"].Value)
                    - UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["X_MIN3"].Value);
                int s_y = UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["Y_MAX3"].Value)
                    - UACSUtility.ViewHelper.JudgeIntNull(senderGrid.Rows[e.RowIndex].Cells["Y_MIN3"].Value);
                smallArea.size = new Size(s_x, s_y);
                displaySmallArea(smallArea);
            }
        }
        void dgvStrategyDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var senderdgv = (DataGridView)sender;
            if (senderdgv.Columns[e.ColumnIndex].Name.Equals("FLAG_ENABLED2") && e.Value != null)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "已开启";
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (e.Value.ToString() == "0")
                {
                    e.Value = "已关闭";
                    e.CellStyle.BackColor = Color.Gray;
                }
            }
            if (senderdgv.Columns[e.ColumnIndex].Name.Equals("LIST_UNIT_NO") && e.Value != null)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "南流向";
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else if (e.Value.ToString() == "2")
                {
                    e.Value = "北流向";
                    e.CellStyle.BackColor = Color.Pink;
                }
                else if (e.Value.ToString() == "3")
                {
                    e.Value = "铁运";
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (e.Value.ToString() == "4")
                { e.Value = "中集商务"; e.CellStyle.BackColor = Color.Peru; }
            }

        }

        void dgvStrategy_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var senderdgv = (DataGridView)sender;
            if (senderdgv.Columns[e.ColumnIndex].Name.Equals("FLAG_ENABLED") && e.Value != null)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "已开启";
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (e.Value.ToString() == "0")
                {
                    e.Value = "已关闭";
                    e.CellStyle.BackColor = Color.Gray;
                }
            }

        }
        void dgvStrategy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string ID = senderGrid.Rows[e.RowIndex].Cells["ID"].Value == null ? "" : senderGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == "启用")
                {
                    DialogResult br = MessageBox.Show("是否将ID：" + ID + " 标记设为启用？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (br == DialogResult.Yes)
                    {
                        updataStrategyFlagCarToYard(ID, 1);
                        queryStrategyInfo(craneNO);
                        UACSUtility.HMILogger.WriteLog(senderGrid.Columns[e.ColumnIndex].HeaderText, "将ID：" + ID + " 标记设为启用", UACSUtility.LogLevel.Info, this.Text);
                    }
                }
                else if (senderGrid.Columns[e.ColumnIndex].HeaderText == "关闭")
                {
                    DialogResult br = MessageBox.Show("是否将ID：" + ID + " 标记设为关闭？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (br == DialogResult.Yes)
                    {
                        updataStrategyFlagCarToYard(ID, 0);
                        queryStrategyInfo(craneNO);
                        UACSUtility.HMILogger.WriteLog(senderGrid.Columns[e.ColumnIndex].HeaderText, "将ID：" + ID + " 标记设为关闭", UACSUtility.LogLevel.Info, this.Text);
                    }
                }
            }
        }
        void dgvStrategy_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvStrategy.Rows[e.RowIndex].Cells["COIL_STRATEGY_ID"].Value != null )
                    {
                        coilAreaNO = dgvStrategy.Rows[e.RowIndex].Cells["COIL_STRATEGY_ID"].Value.ToString();
                        if (!queryCoilStrategyInfoDetail(coilAreaNO))
                        {
                            MessageBox.Show("没有找到指定的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    if (dgvStrategy.Rows[e.RowIndex].Cells["SADDLE_STRATEGY_ID"].Value != null)
                    {
                        saddleAreaNO = dgvStrategy.Rows[e.RowIndex].Cells["SADDLE_STRATEGY_ID"].Value.ToString();
                        if (!querySaaddleStrategyInfoDetail(saddleAreaNO))
                        {
                            MessageBox.Show("没有找到指定的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #region 方法
        //
        private void BindCarType(ComboBox cmbBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr;
            dr = dt.NewRow();
            dr["TypeValue"] = "1";
            dr["TypeName"] = "1#行车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "2";
            dr["TypeName"] = "2#行车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "3";
            dr["TypeName"] = "3#行车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "7";
            dr["TypeName"] = "7#行车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "8";
            dr["TypeName"] = "8#行车";
            dt.Rows.Add(dr);

            //绑定列表下拉框数据
            cmbBox.DisplayMember = "TypeName";
            cmbBox.ValueMember = "TypeValue";
            cmbBox.DataSource = dt;
        }

         private void BindCarType(ComboBox cmbBox,string bayNO)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            DataRow dr;
            
             if(bayNO.Contains("A"))
             {
                 dr = dt.NewRow();
                 dr["TypeValue"] = "1";
                 dr["TypeName"] = "1#行车";
                 dt.Rows.Add(dr);

                 dr = dt.NewRow();
                 dr["TypeValue"] = "2";
                 dr["TypeName"] = "2#行车";
                 dt.Rows.Add(dr);

                 dr = dt.NewRow();
                 dr["TypeValue"] = "3";
                 dr["TypeName"] = "3#行车";
                 dt.Rows.Add(dr);
             }

             if(bayNO.Contains("C"))
             {
                 dr = dt.NewRow();
                 dr["TypeValue"] = "7";
                 dr["TypeName"] = "7#行车";
                 dt.Rows.Add(dr);

                 dr = dt.NewRow();
                 dr["TypeValue"] = "8";
                 dr["TypeName"] = "8#行车";
                 dt.Rows.Add(dr);
             }

             //绑定列表下拉框数据
             cmbBox.DisplayMember = "TypeName";
             cmbBox.ValueMember = "TypeValue";
             cmbBox.DataSource = dt;

        }


        //查询策略数据
        private void queryStrategyInfo(string carneON)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT CRANE_NO, ID, COIL_STRATEGY_ID, SADDLE_STRATEGY_ID, FLAG_ENABLED, SEQ FROM  YARD_TO_YARD_CRANE_STRAEGY  ";
                sql += "  WHERE CRANE_NO = '" + carneON + "' ";

                using (IDataReader rdr = MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                dgvStrategy.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        //查询详细数据
        private bool queryStrategyInfoDetail_(string areaID)
        {
            bool ret = false;
            DataTable dt = new DataTable();

            try
            {
                string sql = " SELECT  A.CRANE_NO, A.ID, A.AREA_ID, A.SADDLE_STRATEGY_ID, A.FLAG_ENABLED, A.SEQ, A.FLOW_TO, ";
                sql += " B.\"DESC\", B.BAY_NO, B.X_MIN, B.X_MAX, B.Y_MIN, B.Y_MAX, B.X_DIR, B.Y_CENTER, B.MIN_EMPTY_SADDLES ";
                sql += " FROM STRATEGY_AREA_TO_YARD A  ";
                sql += " LEFT JOIN YARD_TO_YARD_FIND_SADDLE_STRATEGY B ON A.SADDLE_STRATEGY_ID = B.ID  ";
                sql += " WHERE A.AREA_ID = '" + areaID + "' ";

                using (IDataReader rdr = MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.FieldCount > 0)
                    {
                        dt.Load(rdr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    ret = true;
                }
                dgvStrategyDetail.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }
        private bool queryStrategyInfoDetail(string areaID, string craneNO)
        {
            bool ret = false;
            DataTable dt = new DataTable();

            try
            {
                string sql = " SELECT  A.CRANE_NO, A.ID, A.AREA_ID, A.SADDLE_STRATEGY_ID, A.FLAG_ENABLED, A.SEQ, A.FLOW_TO, ";
                sql += " B.\"DESC\", B.BAY_NO, B.X_MIN, B.X_MAX, B.Y_MIN, B.Y_MAX, B.X_DIR, B.Y_CENTER, B.MIN_EMPTY_SADDLES ";
                sql += " FROM STRATEGY_AREA_TO_YARD A  ";
                sql += " LEFT JOIN YARD_TO_YARD_FIND_SADDLE_STRATEGY B ON A.SADDLE_STRATEGY_ID = B.ID  ";
                sql += " WHERE A.AREA_ID = '" + areaID + "' ";
                sql += " AND A.CRANE_NO = '" + craneNO + "' ";

                using (IDataReader rdr = MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.FieldCount > 0)
                    {
                        dt.Load(rdr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    ret = true;
                }
                dgvStrategyDetail.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }
        private bool queryCoilStrategyInfoDetail(string coilAreaID)
        {
            bool ret = false;
            DataTable dt = new DataTable();

            try
            {
                string sql = " SELECT ID, \"DESC\", BAY_NO, X_MIN, X_MAX, Y_MIN, Y_MAX,  ";
                sql += " X_DIR, Y_CENTER, LIST_UNIT_NO, FLAG_FIND_BY_PLAN, MIN_EMPTY_SADDLES FROM  YARD_TO_YARD_FIND_COIL_STRATEGY ";
                sql += " WHERE ID = '" + coilAreaID + "' ";


                using (IDataReader rdr = MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.FieldCount > 0)
                    {
                        dt.Load(rdr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    ret = true;
                }
                dgvStrategyDetail.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }
        private bool querySaaddleStrategyInfoDetail(string saddleAreaID)
        {
            bool ret = false;
            DataTable dt = new DataTable();

            try
            {
                string sql = " SELECT ID, \"DESC\", BAY_NO, X_MIN, X_MAX, Y_MIN, Y_MAX,  ";
                sql += " X_DIR, Y_CENTER, MIN_EMPTY_SADDLES FROM  YARD_TO_YARD_FIND_SADDLE_STRATEGY ";
                sql += " WHERE ID = '" + saddleAreaID + "' ";


                using (IDataReader rdr = MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.FieldCount > 0)
                    {
                        dt.Load(rdr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    ret = true;
                }
                dgvSaddleDetail.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }
        //更新数据CarToYard
        private void updataStrategyFlagCarToYard(string ID, int flag)
        {
            try
            {
                string sql = "UPDATE YARD_TO_YARD_CRANE_STRAEGY SET ";
                sql += "  FLAG_ENABLED = '" + flag + "' ";
                sql += "  WHERE ID = '" + ID + "' ";
                MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        //更新数据AreaToYard
        private void updataStrategyFlagAreaToYard(string areaID, int flag)
        {
            try
            {
                string sql = "UPDATE STRATEGY_AREA_TO_YARD SET ";
                sql += "  FLAG_ENABLED = '" + flag + "' ";
                sql += "  WHERE ID = '" + areaID + "' ";
                MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        //区域显示
        private void getAreaInfo(string areaName, conStockArea _conStockArea)
        {
            int l_x = 0;
            int l_y = 0;
            int s_x = 0;
            int s_y = 0;
            try
            {
                string sql = "SELECT AREA_NO, AREA_NAME, BAY_NO, X_START, X_END, Y_START, Y_END ,  ";
                sql += " ABS( X_START - X_END) AS X_SIZE ,ABS(Y_START - Y_END) AS Y_SIZE FROM UACS_YARDMAP_AREA_DEFINE ";
                sql += "  WHERE AREA_NO = '" + areaName + "' ";

                using (IDataReader rdr = MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        l_x = UACSUtility.ViewHelper.JudgeIntNull(rdr["X_START"]);
                        l_y = UACSUtility.ViewHelper.JudgeIntNull(rdr["Y_START"]);
                        s_x = UACSUtility.ViewHelper.JudgeIntNull(rdr["X_SIZE"]);
                        s_y = UACSUtility.ViewHelper.JudgeIntNull(rdr["Y_SIZE"]);
                    }
                }
                _conStockArea.createAreaSize(l_x, l_y, s_x, s_y);
                _conStockArea.AreaName = areaName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void displaySmallArea(ClsSmallArea smallArea)
        {
            if (smallArea.areaName.Contains("A")) //A区
            {
                conStockArea_A.addSmallArae(smallArea);
                conStockArea_B.clearStockArea();
                conStockArea_C.clearStockArea();
                conStockArea_D.clearStockArea();
            }
            else if (smallArea.areaName.Contains("B"))
            {
                conStockArea_B.addSmallArae(smallArea);
                conStockArea_A.clearStockArea();
                conStockArea_C.clearStockArea();
                conStockArea_D.clearStockArea();
            }
            else if (smallArea.areaName.Contains("C"))
            {
                conStockArea_C.addSmallArae(smallArea);
                conStockArea_A.clearStockArea();
                conStockArea_B.clearStockArea();
                conStockArea_D.clearStockArea();
            }
            else if (smallArea.areaName.Contains("D"))
            {
                conStockArea_D.addSmallArae(smallArea);
                conStockArea_A.clearStockArea();
                conStockArea_B.clearStockArea();
                conStockArea_C.clearStockArea();
            }
        }
        //获取小区大小
        private void getSmallSizeInfo()
        {
            //DataTable dt = new DataTable();
            //try
            //{
            //    string sql = " select MAX(ID) AS ID, MAX(\"DESC\") AS \"DESC\", MAX(BAY_NO) AS BAY_NO , X_MIN, X_MAX,MAX( Y_MIN) AS Y_MIN , ";
            //    sql += " MAX(Y_MAX) AS Y_MAX , MAX(X_DIR) AS X_DIR, MAX(MIN_EMPTY_SADDLES) AS MIN_EMPTY_SADDLES  FROM YARD_TO_YARD_FIND_SADDLE_STRATEGY  ";
            //    sql += " GROUP BY X_MIN, X_MAX  ";
            //   // sql += " WHERE A.AREA_ID = '" + areaID + "' ";

            //    using (IDataReader rdr = MODEL_OF_REPOSITORIES.DB2Connect.DBHelper.ExecuteReader(sql))
            //    {
            //        dt.Load(rdr);
            //    }
            //    //图像显示
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        ClsSmallArea smallArea = new ClsSmallArea();
            //        smallArea.areaName = UACSUtility.ViewHelper.JudgeStrNull(item["DESC"]);
            //        smallArea.areaID = UACSUtility.ViewHelper.JudgeStrNull(item["ID"]);
            //        smallArea.enable = UACSUtility.ViewHelper.JudgeStrNull(item["FLAG_ENABLED"]) == "1" ? true : false;
            //        smallArea.logisticsFlag = UACSUtility.ViewHelper.JudgeStrNull(item["FLOW_TO"]);
            //        smallArea.point = new Point(UACSUtility.ViewHelper.JudgeIntNull(item["X_MIN"]), UACSUtility.ViewHelper.JudgeIntNull(item["Y_MIN"]));
            //        int s_x = UACSUtility.ViewHelper.JudgeIntNull(item["X_MAX"]) - UACSUtility.ViewHelper.JudgeIntNull(item["X_MIN"]);
            //        int s_y = UACSUtility.ViewHelper.JudgeIntNull(item["Y_MAX"]) - UACSUtility.ViewHelper.JudgeIntNull(item["Y_MIN"]);
            //        smallArea.size = new Size(s_x, s_y);
            //        displaySmallArea(smallArea);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            //}
        }
        #endregion

        private void cmbbCarNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            craneNO = cmbbCarNO.SelectedValue.ToString();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            queryStrategyInfo(craneNO);
            dgvStrategyDetail.DataSource = new DataTable();
            dgvSaddleDetail.DataSource = new DataTable();
           if(cmbArea.Text.Contains("A"))
           {
               getAreaInfo("FT1-1-A", conStockArea_A);
               getAreaInfo("FT1-1-B", conStockArea_B);
               getAreaInfo("FT1-1-C", conStockArea_C);
               getAreaInfo("FT1-1-D", conStockArea_D);
           }
            else
           {
               getAreaInfo("FT3-3-A", conStockArea_A);
               getAreaInfo("FT3-3-B", conStockArea_B);
               getAreaInfo("FT3-3-C", conStockArea_C);
               getAreaInfo("FT3-3-D", conStockArea_D);
           }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            BindCarType(cmbbCarNO, cmb.Text);
        }
    }


}
