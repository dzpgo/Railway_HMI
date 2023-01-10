using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSParking
{
    public partial class FrmDaoZhaManage : Baosight.iSuperframe.Forms.FormBase
    {
        public FrmDaoZhaManage()
        {
            InitializeComponent();
            this.Load+=FrmDaoZhaManage_Load;
        }
        string[] PARK_FT_A = new string[] { "FT101", "FT102", "FT103", "FT104", "FT105", "FT106", "FT107", "FT108", "FT109" };
        string[] ParksArray = null;
        const string TAG_DAOZHA_A_NORTH_CLOSE = "DAOZHA_A_NORTH_CLOSE";
        string dgvCellSelect = "";
        void FrmDaoZhaManage_Load(object sender, EventArgs e)
        {
            getCurrMode();
            getCurrrRecommendParks();
            bindComboxOnFrameHeadNO(cmbbFrameName);
            GetComboxOnParking(cmbbRecommendPark);
            getHMIType(cmbbModeType);
            BindModeLock(cmbbModeLock);
            ParkClassLibrary.ManagerHelper.DataGridViewInit(dgvParkToAreaInfo);
            ParkClassLibrary.ManagerHelper.DataGridViewInit(dgvHMIInfo);
            getHMIInfo();
            cmbbRecommendPark.Text = "";

        }
        

        private void getCurrMode()
        {
            try
            {
                string sql = @"SELECT RECOMMEND_MODE FROM UACS_DAOZHA_RECOMMEND_CONFIG WHERE MODE_LOCK = 1  ORDER BY MODE_LEVEL ASC ";
                string mode1 ="";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager. DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {                        
                        mode1 += rdr["RECOMMEND_MODE"].ToString()  ;
                        mode1 += "  ";
                    }
                }
                mode1 = mode1.Replace("AUTO", "自动");
                mode1 = mode1.Replace("HMI", "人工");
                labCurrMode.Text ="当前模式：" + mode1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void getCurrrRecommendParks()
        {
            try
            {
                string sql = @"SELECT RECOMMEND_MODE ,RECOMMEND_PARKS FROM UACS_DAOZHA_RECOMMEND_CONFIG
                                WHERE MODE_LOCK = 1 AND RECOMMEND_MODE LIKE 'HMI%' ";
                string temp = "";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        temp = rdr["RECOMMEND_PARKS"].ToString();
                    }
                }
                labCurrHMISequence.Text = "当前优先顺序：" + temp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void setRecommendParks(string parks)
        {
            try
            {
                string sql = " UPDATE UACS_DAOZHA_RECOMMEND_CONFIG SET ";
                sql += " RECOMMEND_PARKS = "+"'" +parks +"'";
                sql += " ,SET_TIME = " + "'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'";
                sql += " WHERE RECOMMEND_MODE = 'HMI' ";
                sql += " AND MODE_TYPE = '1' ";
                ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {

            try
            {
                string[] parks = txtParksSequence.Text.Split('#');
                List<string> strList = new List<string>();
                foreach (string item in parks)
                {
                    if (PARK_FT_A.Contains(item))
                    {
                        string temp = item.Trim();
                        strList.Add(item);
                    }
                    else
                    {
                        MessageBox.Show("输入的车位格式不正确：" + item, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    ParksArray = strList.ToArray();
                }
                DialogResult dResult = MessageBox.Show("是否将人工模式推荐顺序修改为：\r\n " + string.Join(",", ParksArray), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dResult == DialogResult.Yes)
                {
                    setRecommendParks(string.Join(",", ParksArray));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            FrmDaoZhaManage_Load(null, null);
        }

        private void btnChangeMode_Click(object sender, EventArgs e)
        {
            if (dgvCellSelect == "")
            {
                MessageBox.Show("请一个模式类型！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk); return;
            }
            DialogResult dResult = MessageBox.Show("是否启动模式："+ dgvCellSelect + " ？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dResult == DialogResult.Yes)
            {
                try
                {
                    string sql = " UPDATE UACS_DAOZHA_RECOMMEND_CONFIG SET ";
                    sql += " MODE_LOCK = " + 1;
                    sql += " ,SET_TIME = " + "'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'";
                    sql += " WHERE RECOMMEND_MODE = 'HMI' ";
                    sql += " AND MODE_TYPE = '" + dgvCellSelect + "' ";
                    ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            FrmDaoZhaManage_Load(null, null);
        }

        private void btnCloseHMIMode_Click(object sender, EventArgs e)
        {
            if (dgvCellSelect == "")
            {
                MessageBox.Show("请一个模式类型！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk); return;
            }
            DialogResult dResult = MessageBox.Show("是否关闭模式：" + dgvCellSelect + " ？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dResult == DialogResult.Yes)
            {
                try
                {
                    string sql = " UPDATE UACS_DAOZHA_RECOMMEND_CONFIG SET ";
                    sql += " MODE_LOCK = " + 0;
                    sql += " ,SET_TIME = " + "'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'";
                    sql += " WHERE RECOMMEND_MODE = 'HMI' ";
                    sql += " AND MODE_TYPE = '" + dgvCellSelect + "' ";
                    ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            FrmDaoZhaManage_Load(null, null);
        }

        private void txtParksSequence_TextChanged(object sender, EventArgs e)
        {
            string UpTem = txtParksSequence.Text;
            txtParksSequence.Text = UpTem.ToUpper().Trim();
            txtParksSequence.SelectionStart = txtParksSequence.Text.Length;
            txtParksSequence.SelectionLength = 0;
        }

        private void btnFine_Click(object sender, EventArgs e)
        {
            string frameNO;
            frameNO = cmbbFrameName.Text.Trim();
            getRecommendPark(frameNO);
        }


        private void getRecommendPark(string frameID)
        {
            string frameNO = "";
            string logisticsFlag = "";
            string havenName = "";
            string recommendPark= "";
            DataTable dt =new DataTable();
            try
            {   // 框架号
                string sql = @"SELECT  A.FRAME_NO, A.STATUS, A.LOAD_POINT, A.UNLOAD_POINT, A.USESTATUS  FROM UACS_FRAME_IN_STORAGE A 
					WHERE A.TRUCK_NO ='{0}' AND A.USESTATUS = 0  ORDER BY A.REC_TIME DESC ";
                sql = string.Format(sql, frameID);


                  using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql))
                  {
                      if (rdr.Read())
                      {
                          frameNO = ParkClassLibrary.ManagerHelper.JudgeStrNull( rdr["FRAME_NO"]);
                      }

                  }
                  if (frameNO == "")
                  {
                      MessageBox.Show("没找到指定的车头号: " + frameID + "相关的框架号！");
                      return;

                  }

                //流向标记
                string sqlText = @"  SELECT A.MAT_NO ,B.HAVEN_CNAME , C.LOGISTICS_FLAG ,A.STOWAGE_ID,A.GROOVEID FROM UACS_TRUCK_STOWAGE_DETAIL A 
                LEFT JOIN UACS_PLAN_IN_DETAIL B ON A.MAT_NO = B.MAT_NO 
                LEFT JOIN UACS_LOGISTICS_CONFIG C ON B.HAVEN_CNAME = C.HAVEN_CNAME  
                WHERE A.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_TRUCK_STOWAGE B WHERE B.FRAME_NO  = '";
                sqlText += frameNO;
                sqlText += @"' ORDER BY B.REC_TIME DESC  fetch first 1 rows only) 
                ORDER BY A.GROOVEID
                fetch first 1 rows only
                ";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        
                        logisticsFlag = ParkClassLibrary.ManagerHelper.JudgeStrNull( rdr["LOGISTICS_FLAG"]);
                        havenName = ParkClassLibrary.ManagerHelper.JudgeStrNull(rdr["HAVEN_CNAME"]);

                    }
                }
                if (logisticsFlag =="")
                {
                    MessageBox.Show("没找到指定的车号: " + frameNO + "相应的信息！");
                    return;
                }
                //区域距离
                sqlText = "";
                sqlText = " SELECT ROW_NUMBER() OVER() as ROW_NO,min(A.\"DESC\") AS \"DESC\", A.X_MIN, A.X_MAX,ABS( C.X_CENTER - ((A.X_MAX - A.X_MIN)/2 +A.X_MIN) ) AS X_SUB , C.NAME, ";
                sqlText += @" MIN(D.PARKING_STATUS) AS PARKING_STATUS, MIN(E.HAVEN_CNAME) AS HAVEN_CNAME   FROM YARD_TO_YARD_FIND_SADDLE_STRATEGY A 
			    LEFT JOIN STRATEGY_AREA_TO_YARD B ON A.ID = B.SADDLE_STRATEGY_ID  
			    LEFT JOIN UACS_YARDMAP_PARKINGSITE C ON 1 = 1  
                LEFT JOIN UACS_PARKING_STATUS D ON C.ID = D.PARKING_NO
                LEFT JOIN UACS_LOGISTICS_CONFIG E ON B.FLOW_TO = E.LOGISTICS_FLAG
			    where  A.BAY_NO = 'A-1' AND C.YARD_NO = 'A' AND B.FLOW_TO ={0} AND B.FLAG_ENABLED = 1  AND C.X_CENTER > 1  AND C.NAME LIKE 'FT10%' 
			    GROUP BY A.X_MIN, A.X_MAX,C.X_CENTER ,C.NAME  ORDER BY X_SUB   ";
                sqlText = string.Format(sqlText, logisticsFlag);
                using(IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sqlText))
                {
                    dt.Load(rdr);
                    dgvParkToAreaInfo.DataSource = dt;
                }
                //
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       if(ParkClassLibrary.ManagerHelper.JudgeIntNull( dt.Rows[i]["PARKING_STATUS"]) ==5 )
                       {
                           recommendPark = ParkClassLibrary.ManagerHelper.JudgeStrNull(dt.Rows[i]["NAME"]);
                           break;
                       }
                    }
                }
                cmbbRecommendPark.Text = recommendPark;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        private void GetComboxOnParking(ComboBox comBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            try
            {
                string sqlText = @"SELECT DISTINCT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_PARKINGSITE WHERE NAME LIKE 'FT10%' ";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        //if (rdr["TypeValue"].ToString().Contains("Z5"))  //debug all
                        {
                            dr["TypeValue"] = rdr["TypeValue"];
                            dr["TypeName"] = rdr["TypeName"];
                            dt.Rows.Add(dr);
                        }
                    }
                }
                //绑定列表下拉框数据
                comBox.DataSource = dt;
                comBox.DisplayMember = "TypeName";
                comBox.ValueMember = "TypeValue";
                comBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comBox"></param>
        private void bindComboxOnFrameHeadNO(ComboBox comBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            try
            {
                string sqlText = @"SELECT DISTINCT   TRUCK_NO AS TypeName,TRUCK_NO AS TypeValue  FROM UACS_FRAME_IN_STORAGE
                                   WHERE USESTATUS = 0 ORDER BY TRUCK_NO ";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        //if (rdr["TypeValue"].ToString().Contains("Z5"))  //debug all
                        {
                            dr["TypeValue"] = rdr["TypeValue"];
                            dr["TypeName"] = rdr["TypeName"];
                            dt.Rows.Add(dr);
                        }
                    }
                }
                //绑定列表下拉框数据
                comBox.DataSource = dt;
                comBox.DisplayMember = "TypeName";
                comBox.ValueMember = "TypeValue";
                comBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        private void dgvParkToAreaInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                if (dgvParkToAreaInfo.Columns[e.ColumnIndex].Name.Equals("PARKING_STATUS")
                    && dgvParkToAreaInfo.Rows[e.RowIndex].Cells["PARKING_STATUS"].Value != null
                     )
                {
                    if (e.Value.ToString() == "5")
                    {
                        e.Value = "无车";
                        //e.CellStyle.BackColor = Color.LightGray;
                    }
                    else 
                    {
                        e.Value = "有车";
                    }

                }

            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                string modeType = cmbbFrameName.Text.Trim();
                if (modeType=="")
                {
                    modeType = cmbbModeType.Text.ToString();
                }
                if (cmbbModeLock.Text == "")
                {
                    MessageBox.Show("请指定模式状态。");
                    return;
                }
                string park = cmbbRecommendPark.Text.ToString();
                string modeLock = cmbbModeLock.SelectedValue.ToString();
                if (modeType=="" || park=="" ||modeLock=="")
                {
                    MessageBox.Show("修改失败，请输入完整的信息！");
                    return;
                }
                delectHMIMode(modeType);
                insertHMIMode(modeType, park, modeLock);
                MessageBox.Show("修改成功！");
                getHMIInfo();
            }
            catch (Exception)
            {
                
                
            }

        }
        private void insertHMIMode(string modeType,string park , string modeLock )
        {
            try
            {
                string sql = @"INSERT INTO UACS_DAOZHA_RECOMMEND_CONFIG (
                RECOMMEND_MODE
                ,MODE_TYPE
                ,MODE_LOCK
                ,MODE_LEVEL
                ,RECOMMEND_PARKS
                ,SET_TIME
                ,LOGISTICS_FLAG
                ,FRAME_HEAD_NO
                ,FRAME_NO
            ) VALUES (";

                sql += "'HMI'";
                sql += " ,'" + modeType+"'";
                sql += " ,'" + modeLock + "'";
                sql += " ,1 " ;
                sql += " ,'" + park + "'";
                sql += " ,'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'";
                sql += ",NULL";
                sql += ",NULL";
                sql += " ,'" + modeType + "'";
                sql += " )";
                ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void delectHMIMode(string modeType)
        {
            try
            {
                string sql = " DELETE FROM UACS_DAOZHA_RECOMMEND_CONFIG WHERE MODE_TYPE ='" + modeType + "' ";

                ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void getHMIInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @" SELECT RECOMMEND_MODE , MODE_TYPE, MODE_LOCK, RECOMMEND_PARKS, SET_TIME , FRAME_HEAD_NO, FRAME_NO 
                FROM UACS_DAOZHA_RECOMMEND_CONFIG WHERE RECOMMEND_MODE ='HMI'";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                dgvHMIInfo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FrmDaoZhaManage_Load(null, null);
            getHMIInfo();
        }

        private void getHMIType(ComboBox comBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            try
            {
                string sqlText = @"SELECT  DISTINCT MODE_TYPE as TypeValue, MODE_TYPE as TypeName 
                FROM UACS_DAOZHA_RECOMMEND_CONFIG WHERE RECOMMEND_MODE LIKE 'HMI%' AND MODE_TYPE != '1' ";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sqlText))
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
                comBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        private void BindModeLock(ComboBox comBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr ;

            dr = dt.NewRow();
            dr["TypeValue"] = "0";
            dr["TypeName"] = "关闭";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "1";
            dr["TypeName"] = "启用";
            dt.Rows.Add(dr);


            //绑定列表下拉框数据
            comBox.DataSource = dt;
            comBox.DisplayMember = "TypeName";
            comBox.ValueMember = "TypeValue";
            comBox.Text="";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string modeType = cmbbModeType.Text.ToString().Trim();

            if (modeType == "")
            {
                MessageBox.Show("模式没指定。");
                return;
            }
            DialogResult dResult = MessageBox.Show("是否删除模式：" + modeType + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dResult == DialogResult.Yes)
            {
                delectHMIMode(modeType);
            }
        }

        private string  gedeleteByModeLock( string modeType)
        {
            string modeLock = "";
            try
            {
                string sql = " SELECT   MODE_LOCK FROM UACS_DAOZHA_RECOMMEND_CONFIG WHERE MODE_TYPE ='" + modeType + "' ";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        modeLock = ParkClassLibrary.ManagerHelper.JudgeStrNull(rdr["MODE_LOCK"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return modeLock;
        }

        private void cmbbModeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbFrameName.Text="";
            string modeType = cmbbModeType.SelectedValue.ToString();
            cmbbRecommendPark.Text= getRecommendParks(modeType);
            cmbbModeLock.Text = gedeleteByModeLock(cmbbModeType.SelectedValue.ToString()) == "1" ? "启用" : "关闭";
        }
        private string getRecommendParks(string modeType)
        {
            string RecommendParks = "";
            try
            {
                string sql = " SELECT   RECOMMEND_PARKS FROM UACS_DAOZHA_RECOMMEND_CONFIG WHERE MODE_TYPE ='" + modeType + "' ";
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        RecommendParks = ParkClassLibrary.ManagerHelper.JudgeStrNull(rdr["RECOMMEND_PARKS"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return RecommendParks;
        }

        private void cmbbModeLock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbbFrameName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb =(ComboBox)sender;
            cmbbModeType.Text = cmb.Text;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string tagValue ="";
            string carNO = cmbNO.Text.Trim() ;
            string carStatus = cmbStatus.Text.Contains("1") ? "1" : "0";
            tagValue = "0|" + carNO + "|" + carStatus;
            DialogResult dResult = MessageBox.Show("是否将车: "+carNO + "状态更改为："+carStatus + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dResult == DialogResult.Yes)
            {
                ParkClassLibrary.ClsParkingManager.TagDP.SetData(TAG_DAOZHA_A_NORTH_CLOSE, tagValue);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            string tagValue = "0|ALL|0";
            DialogResult dResult = MessageBox.Show("是否将全部车状态都置为0？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dResult == DialogResult .Yes)
            {
                ParkClassLibrary.ClsParkingManager.TagDP.SetData(TAG_DAOZHA_A_NORTH_CLOSE, tagValue);
            }
            System.Threading.Thread.Sleep(2000);
            ParkClassLibrary.ClsParkingManager.TagDP.SetData(TAG_DAOZHA_A_NORTH_CLOSE, "0");
        }


        private void dgvHMIInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (!dgv.Rows[e.RowIndex].Cells["MODE_TYPE"].Value.Equals(null))
                {
                    dgvCellSelect = dgv.Rows[e.RowIndex].Cells["MODE_TYPE"].Value.ToString();
                }
            }
        }
    }
}
