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
using ParkClassLibrary;
using Baosight.iSuperframe.Authorization.Interface;

namespace UACSParking
{
    public partial class kuajiacheForm : FormBase
    {
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        IAuthorization auth = Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<Baosight.iSuperframe.Authorization.Interface.IAuthorization>()
        as Baosight.iSuperframe.Authorization.Interface.IAuthorization;
        //
        DataTable dtPlanOut = new DataTable();
        string parkBayNO = "";
        string carNO = "";
        bool openFlag = false;  //画面跳转标记
        bool isStowage = false;
        int selectCoilNum = 8;

        //下拉框加载
        //初始化绑定默认关键词（此数据源可以从数据库取）
        List<string> listOnit = new List<string>();
        //输入key之后，返回的关键词
        List<string> listNew = new List<string>();

        //当前输入框内的信息变量(只有在输入框里输入信息是此变量才会有值,其他时候为默认空值)
        string CbxNowStr = "";
        //输入框内的前一个历史信息变量
        string CbxOldStr = "";

        //三种规格查询
        List<string> lstMatsWeight = new List<string>();
        List<string> lstMatsWidth = new List<string>();
        List<string> lstMatsOutDIA = new List<string>();
        //满足三种条件的卷
        List<string> lstAllowCoils = new List<string>();
        //其他框架上的卷
        List<string> lstOtherParkingCoils = new List<string>();

        public kuajiacheForm()
        {
            InitializeComponent();

            TagValues.Clear();


            
        }
        public kuajiacheForm(string parkingNO)
        {
            //清空数据
            InitializeComponent();


            TagValues.Clear();
            cmbArea.Text = GetOperateAreaByBay(parkingNO);


            //画面跳转
            ClearHMIData();
            openFlag = true;
            isStowage = false;
            comboBoxParkNO.Text = parkingNO;
            comboBoxParkNO_SelectedIndexChanged(null, null);  //初始化画面的参数，必须初始化
        }
        public kuajiacheForm(string parkingNO,string GrNUm)
        {
            //清空数据
            InitializeComponent();


            TagValues.Clear();
            cmbArea.Text = GetOperateAreaByBay(parkingNO);

            //画面跳转
            ClearHMIData();
            openFlag = true;
            isStowage = false;
            //comboBoxParkNO.Enabled = false;
            //GetComboxOnParking();
            comboBoxParkNO.Text = parkingNO;
            txtGrooveNum.Text = GrNUm;
            comboBoxParkNO_SelectedIndexChanged(null, null);  //初始化画面的参数，必须初始化
        }
        private string GetOperateAreaByBay(string parkNO)
        {
            string area = "";
            try
            {
                if (parkNO.Contains("Z53"))
                {
                    area = "成品-Z53跨";
                }
                else if (parkNO.Contains("Z52"))
                {
                    area = "成品-Z51跨";
                }
                else if (parkNO.Contains("Z51"))
                {
                    area = "成品-Z51跨";
                }
                else if (parkNO.Contains("FT1"))
                {
                    area = "产成品A-1";
                }
                else if (parkNO.Contains("FT3"))
                {
                    area = "产成品C-1";
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
        void dgvPlanOut_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                if (e.RowIndex < 0 || (e.ColumnIndex < 0))
                {
                    return;
                }
                if (!dgv.Columns[e.ColumnIndex].Name.Equals("MAT_NO"))
                {
                    return;
                }
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            } 
        }

        /// <summary>
        /// 绑定船名
        /// </summary>
        private void GetComboxShipName()
        {
            //准备数据
            try
            {
                comBoxShipName.Items.Clear();
                comBoxShipName.Items.Add("全部");
                if (checkBoxAllShip.Checked==true)
                {
                    string sqlText = @"SELECT distinct SHIP_NAME  FROM UACS_PLAN_OUT order by SHIP_NAME";
                    using (IDataReader rdr = ClsParkingManager.DBHelper.ExecuteReader(sqlText)) 
                    {
                        while (rdr.Read())
                        {
                            if (rdr["SHIP_NAME"] != DBNull.Value)
                            {
                                comBoxShipName.Items.Add(rdr["SHIP_NAME"]);
                            }
                        }
                    }
                    comBoxShipName.Text = "请选择";
                }
                else
                {
                    string sqlText = @" SELECT  A.SHIP_NAME FROM UACS_PLAN_OUT A
                    LEFT JOIN  UACS_PLAN_OUT_DETAIL  B ON A.PLAN_NO = B.PLAN_NO
                    RIGHT JOIN UACS_YARDMAP_STOCK_DEFINE C ON B.MAT_NO = C.MAT_NO
                    WHERE A.SHIP_NAME IS NOT NULL AND  B.STATUS= 0
                    GROUP BY A.SHIP_NAME ";

                    using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                    {
                        while (rdr.Read())
                        {
                            if (rdr["SHIP_NAME"] != DBNull.Value)
                            {
                                comBoxShipName.Items.Add(rdr["SHIP_NAME"]);
                            }
                        }
                    }
                    comBoxShipName.Text = "请选择";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
 
            //

        }

        /// <summary>
        /// 获取船批号
        /// </summary>
        /// <param name="shipNO"></param>
        private void GetComboxhipSEQNO(string shipNO)
        {
            //准备数据
            try
            {
                comboBoxShipSEQNO.Items.Clear();
                comboBoxShipSEQNO.Items.Add("全部");
                string sqlText = @"SELECT DISTINCT SHIP_SEQ_NO  FROM UACS_PLAN_OUT WHERE SHIP_NAME ='{0}'  ";
                sqlText = string.Format(sqlText, shipNO);
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        if (rdr["SHIP_SEQ_NO"] != DBNull.Value)
                        {
                            comboBoxShipSEQNO.Items.Add(rdr["SHIP_SEQ_NO"].ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        /// <summary>
        /// 根据根据船批号查询
        /// </summary>
        /// <param name="shipSEQNO"></param>
        private void GetPlanOutInfo(string shipSEQNO)
        {
            //准备数据
            dtPlanOut.Clear();
            try
            {
                string sqlText = @"SELECT 0 AS CHECK_COLUMN,G.PICK_NO as PICK_NO, F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , C.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,  ";
                sqlText += " D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_L3PICK G ON C.MAT_NO = G.COIL_NO ";
                sqlText += "WHERE F.SHIP_SEQ_NO ='{0}' order by F.PLAN_NO ";
                sqlText = string.Format(sqlText, shipSEQNO);
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    dtPlanOut.Load(rdr);
                }
                dgvPlanOut.DataSource = dtPlanOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        private void GetPlanOutInfo(string shipSEQNO,string parkingNO ="", string pickNO="", string weight = "")
        {
            //准备数据
            dtPlanOut.Clear();
            long XMax = 400000;
            long XMin = 400000;
            if (parkingNO == "Z53A1" || parkingNO == "Z53A2" || parkingNO == "Z53B1" || parkingNO == "Z53B2")
            {
                //max  392292 392271
                //min 250499
                XMax = 394000;
                XMin = 250000;
            }
            if (parkingNO == "Z52A1" || parkingNO == "Z52A2" || parkingNO == "Z52B1" || parkingNO == "Z52B2")
            {
                //XMax 450818 450778
                //min  308901 308901
                XMax = 451000;
                XMin = 308500;
            }
            if (parkingNO == "Z51A1" || parkingNO == "Z51A2" || parkingNO == "Z51B1" || parkingNO == "Z51B2")
            {
                //max    451376 451404
                //min 309490
                XMax = 451600;
                XMin = 309000;
            }
            try
            {
                string sqlText = @"SELECT 0 AS CHECK_COLUMN,G.PICK_NO as PICK_NO, F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , C.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,  ";
                sqlText += "D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_L3PICK G ON C.MAT_NO = G.COIL_NO ";
                sqlText += " WHERE F.SHIP_SEQ_NO ='{0}'";
                if (!ckBoxAllCoil.Checked)
                {
                    sqlText += " AND D.X_CENTER>" + XMin.ToString();
                    sqlText += " AND D.X_CENTER<" + XMax.ToString();
                }
                if (parkingNO != "" && parkingNO != null)
                {
                    parkBayNO = parkingNO.Substring(0, 3);
                    parkBayNO = string.Format("{0}-1", parkBayNO);
                    sqlText += " AND A.BAY_NO = '" + parkBayNO + "' ";
                }
                if (pickNO != "" && pickNO!= null)
                {
                    sqlText += " AND G.PICK_NO like '%" + pickNO + "%' "; ;
                }

                if (weight != "" && weight != null)
                {
                    sqlText += " AND B.WEIGHT < "+weight+" ";
                }
                sqlText += " order by G.PICK_NO ";
                sqlText = string.Format(sqlText, shipSEQNO);
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    dtPlanOut.Load(rdr);
                }
                dgvPlanOut.DataSource = dtPlanOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        private void GetPlanOutInfo(string shipSEQNO, string parkingNO = "",string PlanNO="", string pickNO = "", string weight = "")
        {
            //准备数据
            dtPlanOut.Clear();
            long XMax = 400000;
            long XMin = 400000;
            if (parkingNO == "Z53A1" || parkingNO == "Z53A2" || parkingNO == "Z53B1" || parkingNO == "Z53B2")
            {
                //max  392292 392271
                //min 250499
                XMax = 394000;
                XMin = 250000;
            }
            if (parkingNO == "Z52A1" || parkingNO == "Z52A2" || parkingNO == "Z52B1" || parkingNO == "Z52B2")
            {
                //XMax 450818 450778
                //min  308901 308901
                XMax = 451000;
                XMin = 308500;
            }
            if (parkingNO == "Z51A1" || parkingNO == "Z51A2" || parkingNO == "Z51B1" || parkingNO == "Z51B2")
            {
                //max    451376 451404
                //min 309490
                XMax = 451600;
                XMin = 309000;
            }
            try
            {
                string sqlText = @"SELECT 0 AS CHECK_COLUMN,G.PICK_NO as PICK_NO, F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , C.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,  ";
                sqlText += "D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_L3PICK G ON C.MAT_NO = G.COIL_NO ";
                sqlText += " WHERE F.SHIP_SEQ_NO ='{0}'";
                if (!ckBoxAllCoil.Checked)
                {
                    sqlText += " AND D.X_CENTER>" + XMin.ToString();
                    sqlText += " AND D.X_CENTER<" + XMax.ToString();
                }
                if (parkingNO != "" && parkingNO != null)
                {
                    parkBayNO = parkingNO.Substring(0, 3);
                    parkBayNO = string.Format("{0}-1", parkBayNO);
                    sqlText += " AND A.BAY_NO = '" + parkBayNO + "' ";
                }
                if (PlanNO != "" && PlanNO != null)
                {
                    sqlText += " AND F.PLAN_NO like '%" + PlanNO + "%' "; ;
                }
                if (pickNO != "" && pickNO != null)
                {
                    sqlText += " AND G.PICK_NO like '%" + pickNO + "%' "; ;
                }

                if (weight != "" && weight != null)
                {
                    sqlText += " AND B.WEIGHT < " + weight + " ";
                }
                sqlText += " order by G.PICK_NO ";
                sqlText = string.Format(sqlText, shipSEQNO);
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    dtPlanOut.Load(rdr);
                }
                dgvPlanOut.DataSource = dtPlanOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

       

        private void kuajiacheForm_Load(object sender, EventArgs e)
        {
            //GetComboxShipName();

            DataGridViewInit(dgvPlanOut);
            if (!openFlag)
            {
                //GetComboxOnParking();
            }
            CreakConlumcheckBox();
            bindCbbEvent(cbbPlantNO);
            dgvPlanOut.CellFormatting += dgvPlanOut_CellFormatting;
            this.Show();
        }
        private void CreakConlumcheckBox()
        {
            var cell = this.dgvPlanOut.GetCellDisplayRectangle(0, -1, true);
            //var checkbox = new CheckBox { Left = cell.Size.Width - 20, Top = cell.Top + 10, Width = 16, Height = 16 };
            var checkbox = new CheckBox { Left = cell.Size.Width - 20, Top = cell.Size.Height/2-8, Width = 16, Height = 16 };
            checkbox.CheckedChanged += checkbox_CheckedChanged;
            this.dgvPlanOut.Controls.Add(checkbox);
        }

        void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            CheckBox cb = (CheckBox)sender;
            Addtitle();
            if (cb.Checked)
            {
                foreach (DataGridViewRow item in dgvPlanOut.Rows)
                {
                    if (i == 8)
                    {
                        break;
                    }
                    clsCoils coil = new clsCoils();
                    coil.MAT_NO = item.Cells["MAT_NO"].Value.ToString();
                    coil.PLAN_NO = item.Cells["PLAN_NO"].Value.ToString();
                    coil.ColumnNO = item.Cells["STOCK_NO"].Value.ToString();
                    listViewCoil.Items.Add(coil);
                    item.Cells["CHECK_COLUMN"].Value = true;
                    txtSelectCoilSNum.Text = (listViewCoil.Items.Count - 1).ToString();
                    i++;
                }
            }
            else if (!cb.Checked)
            {
                int k = 0;
                foreach (DataGridViewRow item in dgvPlanOut.Rows)
                {
                    foreach (clsCoils item1 in listViewCoil.Items)
                    {
                        if (item1.MAT_NO==item.Cells["MAT_NO"].Value.ToString())
                        {
                            listViewCoil.Items.Remove(item1);
                            item.Cells["CHECK_COLUMN"].Value = false;                           
                            k++;
                            break;
                        }
                    }
                    if (k>8)
                    {
                        break;
                    }
                }
                txtSelectCoilSNum.Text = (listViewCoil.Items.Count - 1).ToString();
            }

        }

        private void comBoxShipName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbb = (ComboBox)sender;

            listViewCoil.Items.Clear();
            btnSelectByXMin.ForeColor = Color.White;
            btnSelectByXMax.ForeColor = Color.White;

            if (cbb.Text =="全部") //获得库区所有卷
            {
                if (comboBoxParkNO.Text =="")
                {
                    MessageBox.Show("请选择一个停车位！");
                }
                GetPlanOutInfoByPicknON(comBoxShipName.Text.Trim(), "", "");
                return;
            }
            GetComboxhipSEQNO(comBoxShipName.Text.Trim());
            if (comboBoxShipSEQNO.Items.Count>0)
            {
                comboBoxShipSEQNO.SelectedIndex=0;
                //查询记录
                comboBoxShipSEQNO.Text = comboBoxShipSEQNO.Items[comboBoxShipSEQNO.SelectedIndex].ToString();
                comboBoxShipSEQNO_SelectedIndexChanged(null, null);
            }



        }

        private void ClearHMIData()
        {
            //清空数据
            comboBoxParkNO.Text = "";

            dtPlanOut.Clear();
            dgvPlanOut.DataSource = dtPlanOut;
            listViewCoil.Items.Clear();
            txtPlanCount.Text = "";
            txtPlanStockCoil.Text = "";

            txtMaxOutDIA.Text = "";
            txtMaxWeight.Text = "";
            txtMaxWidth.Text = "";
            txtMinWeight.Text = "";
            //清空
            lstMatsOutDIA.Clear();
            lstMatsWeight.Clear();
            lstMatsWidth.Clear();
            lstAllowCoils.Clear();
            lstOtherParkingCoils.Clear();

            btnSelectByXMin.ForeColor = Color.White;
            btnSelectByXMax.ForeColor = Color.White;
        }
        private void checkBoxAllShip_CheckedChanged(object sender, EventArgs e)
        {            
            GetComboxShipName();
        }
        /// <summary>
        /// 船批号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxShipSEQNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShipSEQNO.Text =="" || comboBoxShipSEQNO.Text=="请选择")
            {
                return;
            }

            try
            {
                //获取计划号
                getPlantNOListByShipSEQNO(comboBoxShipSEQNO.Text, cbbPlantNO);
                //清空表格
                dgvPlanOut.DataSource = new DataTable();
                //查询记录
                // GetPlanOutInfo(comboBoxShipSEQNO.Text.Trim());
                //统计计划数目
               // CountBayCoils();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);

            } 


        }
        /// <summary>
        /// 获取提单号
        /// </summary>
        /// <param name="shipSEQNO"></param>
        /// <param name="cbb"></param>
        private void getPlantNOListByShipSEQNO(string shipSEQNO,ComboBox cbb)
        {
            try
            {
                if (listOnit.Count > 0)
                {
                    //清空默认数组
                    listOnit.Clear();
                }
                cbb.Text = "";
                string sqlText = "";
                if (shipSEQNO =="全部")
                {
                    if (comBoxShipName.Text != "")
                    {
                        sqlText = @"  SELECT  A.LOT_NO  FROM UACS_PLAN_OUT A 
                           WHERE  A.SHIP_NAME ='{0}'  GROUP BY A.LOT_NO ORDER BY A.LOT_NO";
                        sqlText = string.Format(sqlText, comBoxShipName.Text.Trim());
                    }
                }
                else
                {
                    sqlText = @" SELECT A.LOT_NO  FROM UACS_PLAN_OUT A 
                            WHERE A.SHIP_SEQ_NO ='{0}'  GROUP BY A.LOT_NO ORDER BY A.LOT_NO";
                    sqlText = string.Format(sqlText, shipSEQNO);
                }

                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    listOnit.Add("全部");
                    while (rdr.Read())
                    {
                        if (rdr["LOT_NO"] != DBNull.Value)
                        {
                            //cbb.Items.Add(rdr["PLAN_NO"]);
                            listOnit.Add(rdr["LOT_NO"].ToString());
                        }
                    }
                }
                BindComboBox(cbb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        #region 计划钢卷统计
        /// <summary>
        /// 分跨统计钢卷
        /// </summary>
        private void CountBayCoils()
        {
            try
            {

                getPlantCoilsCount(comBoxShipName.Text, comboBoxShipSEQNO.Text, cbbPlantNO.Text);
                int i = 0;
                int FT11ACount, FT11BCount, FT11CCount,FT11DCount;
                FT11ACount = FT11BCount = FT11CCount = FT11DCount = 0;
                foreach (DataGridViewRow item in dgvPlanOut.Rows)
                {
                    if (!item.Cells["BAY_NO"].Value.Equals(null) || item.Cells["STOCK_NO"].Value.Equals(null))
                    {
                        if (item.Cells["BAY_NO"].Value.ToString().Trim() != "" && item.Cells["STOCK_NO"].Value.ToString().Trim() != "")
                        {
                            i++;
                            //53
                            if (item.Cells["STOCK_NO"].Value.ToString().Contains("FT11A"))
                            {
                                FT11ACount++;
                            }
                            else if (item.Cells["STOCK_NO"].Value.ToString().Contains("FT11B"))
                            {
                                FT11BCount++;
                            }
                            else if (item.Cells["STOCK_NO"].Value.ToString().Contains("FT11C"))
                            {
                                FT11CCount++;
                            }
                            else if (item.Cells["STOCK_NO"].Value.ToString().Contains("FT11D"))
                            {
                                FT11CCount++;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    txtPlanStockCoil.Text = string.Format("总 {0}个，A区 {1}个，B区 {2}个，C区 {3}个，D区 {4}个", i.ToString(), FT11CCount, FT11BCount, FT11ACount,FT11DCount);
                }
                else
                {
                    txtPlanStockCoil.Text = string.Format("总 {0}个，A区 {1}个，B区 {2}个，C区 {3}个，D区 {4}个", 0, 0, 0, 0,0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }

        }

        private void getPlantCoilsCount(string shipName, string shipSeqNO, string lotNO)
        {
            try
            {

                string sqlText = @" SELECT COUNT(C.MAT_NO) COILSCOUNT FROM UACS_PLAN_OUT_DETAIL C  
                 LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO WHERE 1=1
                 AND C.MAT_NO IS NOT NULL ";
                    if (lotNO != "全部")
                    {
                        sqlText += " AND F.LOT_NO ='{0}' ";
                        sqlText = string.Format(sqlText, lotNO);
                    }
                    else if (shipSeqNO != "全部")
                    {
                        sqlText += " AND F.SHIP_SEQ_NO ='{0}' ";
                        sqlText = string.Format(sqlText, shipSeqNO);
                    }
                    else
                    {
                        sqlText += " AND F.SHIP_NAME ='{0}'";
                        sqlText = string.Format(sqlText, shipName);
                    }
                string coilsCount ="";
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {
                        if (rdr["COILSCOUNT"] != DBNull.Value)
                        {
                           coilsCount = rdr["COILSCOUNT"].ToString();
                        }
                    }
                }
                txtPlanCount.Text = coilsCount + "个";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        #endregion



        /// <summary>
        /// 用于DataGridView初始化一般属性
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private  string DataGridViewInit(DataGridView dataGridView)
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
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.RowHeadersVisible = false;  //隐藏行标题
            //禁止用户改变DataGridView1所有行的行高  
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowTemplate.Height = 30;

            dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            return "";
        }
        /// <summary>
        /// 就近选卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void comboBoxParkNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxParkNO.Text.Trim() == "" || !comboBoxParkNO.Text .Contains('F'))
            {
                return;
            }
            //刷新钢卷信息表
            //comboBoxShipSEQNO_SelectedIndexChanged(null, null);
            parkBayNO = string.Format("{0}-1", "A");
            carNO=  GetTextOnCar(comboBoxParkNO.Text.Trim());
            listViewCoil.Items.Clear();
            txtMaxWeight.Text = "";
            txtStockIn.Text = "";
            btnSelectByXMin.ForeColor = Color.White;
            btnSelectByXMax.ForeColor = Color.White;
            isStowage = false;

        }


    

        private void SelectCoilByDrection(string dret, string shipName, string shipSeqNO, string lotNO)
        {
            int coilCount = 0;
            listViewCoil.Items.Clear();
            //获取当前车位的所有卷
            getCurParkingcoils();
            if (txtSelectCount.Text !="")
            {
                selectCoilNum = Convert.ToInt32(txtSelectCount.Text);
            }
            if (selectCoilNum > 50)
            {
                selectCoilNum = 50;
                txtSelectCount.Text = "50";
            }
            Addtitle();
            string parkingNO = comboBoxParkNO.Text.Trim();

            //long XMax = 400000;
            //long XMin = 400000;
            //if (parkingNO == "Z53A1" || parkingNO == "Z53A2" || parkingNO == "Z53B1" || parkingNO == "Z53B2")
            //{
            //    XMax = 394000;
            //    XMin = 250000;
            //}
            //if (parkingNO == "Z52A1" || parkingNO == "Z52A2" || parkingNO == "Z52B1" || parkingNO == "Z52B2")
            //{
            //    XMax = 451000;
            //    XMin = 308500;
            //}
            //if (parkingNO == "Z51A1" || parkingNO == "Z51A2" || parkingNO == "Z51B1" || parkingNO == "Z51B2")
            //{
            //    XMax = 451600;
            //    XMin = 309000;
            //}
            try
            {

                string sqlText = @" SELECT 0 AS CHECK_COLUMN,F.LOT_NO as PICK_NO, F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , C.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, 
                             D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  
                             LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO 
                             LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  
                             LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO 
                             LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  
                             LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO WHERE 1=1
                             AND A.STOCK_NO IS NOT NULL ";
                //sqlText += " AND D.X_CENTER>" + XMin.ToString();
                //sqlText += " AND D.X_CENTER<" + XMax.ToString();
                if (parkBayNO!="")
                {
                    sqlText += "  AND A.BAY_NO ='" + parkBayNO + "'";
                }
                if (lotNO != "全部")
                {
                    sqlText += " AND F.LOT_NO ='{0}'  ";
                    sqlText = string.Format(sqlText, lotNO);
                }
                else if (shipSeqNO != "全部")
                {
                    sqlText += " AND F.SHIP_SEQ_NO ='{0}' ";
                    sqlText = string.Format(sqlText, shipSeqNO);
                }
                else
                {
                    sqlText += " AND F.SHIP_NAME ='{0}'  ";
                    sqlText = string.Format(sqlText, shipName);
                }
                if (dret == "从X大方向")
                {
                    sqlText += " order by D.X_CENTER DESC ";
                }
                else if (dret == "从X小方向")
                {
                    sqlText += " order by D.X_CENTER  ASC";
                }
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read() && coilCount < selectCoilNum)// && i < 50)
                    {
                        if (lstAllowCoils.Count>0)  //判断是否在规格list里面
                        {
                            if (!lstAllowCoils.Contains(ManagerHelper.JudgeStrNull(rdr["MAT_NO"])))
                            {
                                continue;
                            }
                        }
                        if (lstOtherParkingCoils.Count>0)  //判断是否已被选择
                        {
                            if (lstOtherParkingCoils.Contains(ManagerHelper.JudgeStrNull(rdr["MAT_NO"])))
                            {
                                continue;
                            }
                        }
                        coilCount++;
                        clsCoils theCoil_Ship = new clsCoils();

                        //先接收内厂材料号
                        theCoil_Ship.MAT_NO = ManagerHelper.JudgeStrNull(rdr["MAT_NO"]);

                        theCoil_Ship.PLAN_NO = ManagerHelper.JudgeStrNull(rdr["PLAN_NO"]);

                        theCoil_Ship.ColumnNO = ManagerHelper.JudgeStrNull(rdr["STOCK_NO"]);

                        theCoil_Ship.weight = ManagerHelper.JudgeStrNull(rdr["WEIGHT"]);
                        theCoil_Ship.width = ManagerHelper.JudgeStrNull(rdr["WIDTH"]);
                        theCoil_Ship.outDIA = ManagerHelper.JudgeStrNull(rdr["OUTDIA"]);

                        listViewCoil.Items.Add(theCoil_Ship);

                    }
                }
                if (listViewCoil.Items.Count == 0)
                {
                    MessageBox.Show("没找到指定类型的钢卷");
                }
                txtSelectCoilSNum.Text = (listViewCoil.Items.Count - 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        private void btndet_Click(object sender, EventArgs e)
        {
            //按计划删
            if (comboBox_ShipCoils_PlanNO.Text.Trim() != "")
            {
                List<clsCoils> lst_Coils_To_BeDeleted = new List<clsCoils>();

                string strPlanNo = comboBox_ShipCoils_PlanNO.Text;
                foreach (clsCoils theCoil in listViewCoil.Items)
                {
                    if (theCoil.PLAN_NO == strPlanNo)
                    {
                        lst_Coils_To_BeDeleted.Add(theCoil);
                    }
                }

                foreach (clsCoils CoilsToDelete in lst_Coils_To_BeDeleted)
                {
                    listViewCoil.Items.Remove(CoilsToDelete);
                }
                comboBox_ShipCoils_PlanNO.Text = "";
                txtSelectCoilSNum.Text = (listViewCoil.Items.Count-1).ToString();
                return;
            }
            //按材料删
            else if (coboxMatNO.Text!="")
            {
                string strMatNO = coboxMatNO.Text;
                foreach (clsCoils item in listViewCoil.Items)
                {
                    if (item.MAT_NO==strMatNO)
                    {
                        listViewCoil.Items.Remove(item);
                        coboxMatNO.Text = "";
                        txtSelectCoilSNum.Text = (listViewCoil.Items.Count-1).ToString();
                        return;
                    }                    
                }
            }
        }

        private void comboBox_ShipCoils_PlanNO_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBox_ShipCoils_PlanNO.Items.Clear();    
                foreach (clsCoils theCoil in listViewCoil.Items)
                {
                    if (!theCoil.MAT_NO.Contains("号"))
                    {
                        string strPlanNO_ToAdd = theCoil.PLAN_NO;
                        bool founded = false;
                        foreach (string strPlanNO in comboBox_ShipCoils_PlanNO.Items)
                        {
                            if (strPlanNO == strPlanNO_ToAdd)
                            {
                                founded = true;
                            }
                        }
                        if (founded == false)
                        {
                            comboBox_ShipCoils_PlanNO.Items.Add(strPlanNO_ToAdd);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        /// <summary>
        /// 查询车号
        /// </summary>
        /// <param name="parking">停车位</param>
        private string GetTextOnCar(string parkNOA)
        {
            string str = "";
            try
            {
                if (parkNOA == "" || !parkNOA.Contains('F'))
                {
                    return "";
                }
                string sql = string.Format("select CAR_NO,HEAD_POSTION ,TREATMENT_NO ,LASER_ACTION_COUNT from UACS_PARKING_STATUS where PARKING_NO = '{0}' ", parkNOA);

                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {

                        if (rdr["CAR_NO"] != DBNull.Value)
                        {
                            str = rdr["CAR_NO"].ToString();
                        }
                        else
                        {
                            str = "";
                        }
                    }
                    return str;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return "";
            }
        }
        private void btnCarEnter_Click(object sender, EventArgs e)
        {
            string truckNo = carNO;
            string parkingNo = comboBoxParkNO.Text.Trim();

            if (isStowage)
            {
                MessageBox.Show("材料已经配载,重新选择停车位刷新。");
                return;
            }
            try
            {
                //框架车号不能为空
                if (truckNo == "")
                {
                    MessageBox.Show("框架车号不能为空,请先做车到位。");
                    return;
                }
                //车位号不能为空
                if (parkingNo == "" || parkingNo == "请选择")
                {
                    MessageBox.Show("该框架车找不到对应的停车位号");
                    return;
                }
                #region 钢卷多库位判断
                string temp;
                if (checkMatNOCount(out temp))
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
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {
                        treatmentNo = ManagerHelper.JudgeStrNull(rdr["TREATMENT_NO"]);
                        LASER_ACTION_COUNT = ManagerHelper.JudgeIntNull(rdr["LASER_ACTION_COUNT"]);

                        stowageNo = ManagerHelper.JudgeStrNull(rdr["STOWAGE_ID"]);
                        currengMdlCalId = ManagerHelper.JudgeIntNull(rdr["MDL_CAL_ID"]);
                    }
                }

                //模型计算次数
                int mdlCalId = currengMdlCalId + 1;
                myValue = string.Format("{0}|{1}|{2}|{3}|{4}-", parkingNo, truckNo, treatmentNo, mdlCalId, stowageNo);

                int countCoul = 0;  //只选八个卷
                foreach (clsCoils theCoil in listViewCoil.Items)
                {
                    if (countCoul>=9)
                    {
                        break;
                    }
                    if (theCoil.ColumnNO.Contains('F')) //标题不要
                    {
                        myValue += theCoil.MAT_NO;
                        myValue += "|";
                        countCoul++;
                    }

                }
                //debug
                DialogResult dr1 = MessageBox.Show(string.Format("发送的Tag的myValue 的值：\n{0}\n", myValue), "提示", MessageBoxButtons.YesNo);
                if (dr1 != DialogResult.Yes)
                {
                    return;
                }

                //debug

                sqlText = @"UPDATE UACS_TRUCK_STOWAGE SET MD_COIL_READY = '{0}' WHERE STOWAGE_ID = {1} ";
                sqlText = string.Format(sqlText, myValue, stowageNo);
                ClsParkingManager. DBHelper.ExecuteNonQuery(sqlText);

                //发送tag
                myValue = myValue.Substring(0, myValue.Length - 1);
                ClsParkingManager.TagDP.SetData("EV_PARKING_MDL_OUT_CAL_START", myValue);
                //更新模型计算次数
                sqlText = @"UPDATE UACS_PARKING_STATUS SET MDL_CAL_ID = {0} where PARKING_NO = '{1}'";
                sqlText = string.Format(sqlText, mdlCalId, parkingNo);
                ClsParkingManager.DBHelper.ExecuteNonQuery(sqlText);
                isStowage = true;
                MessageBox.Show("框架车选择材料成功，行车准备自动运行，请注意安全！");
                auth.OpenForm("成品库框架车出库");
               // this.Close();
                //清空
                lstMatsOutDIA.Clear();
                lstMatsWeight.Clear();
                lstMatsWidth.Clear();
                lstAllowCoils.Clear();
                lstOtherParkingCoils.Clear();
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                MessageBox.Show("框架车选择材料失败！");
            }

        }


        private void btnSelectByXMax_Click(object sender, EventArgs e)
        {
            string SelectDret = "从X大方向";
            //SelectCoilByDrection(SelectDret);
            SelectCoilByDrection(SelectDret, comBoxShipName.Text.Trim(), comboBoxShipSEQNO.Text.Trim(), cbbPlantNO.Text.Trim());
            btnSelectByXMax.ForeColor = Color.Green;
            btnSelectByXMin.ForeColor = Color.White;	
        }

        private void btnSelectByXMin_Click(object sender, EventArgs e)
        {
            string SelectDret = "从X小方向";
            //SelectCoilByDrection(SelectDret);
            SelectCoilByDrection(SelectDret, comBoxShipName.Text.Trim(), comboBoxShipSEQNO.Text.Trim(), cbbPlantNO.Text.Trim());
            btnSelectByXMin.ForeColor = Color.Green;
            btnSelectByXMax.ForeColor = Color.White;		
        }

        private void btnFine_Click(object sender, EventArgs e)
        {
            string minWeight = txtMinWeight.Text.Trim();
            string maxWeight = txtMaxWeight.Text.Trim();
            string maxWidth =txtMaxWidth.Text.Trim();
            string maxOutDIA =txtMaxOutDIA.Text.Trim();
            lstMatsOutDIA.Clear();
            lstMatsWeight.Clear();
            lstMatsWidth.Clear();
            lstAllowCoils.Clear();
            //设置筛选
            setMyDatagridViewRows(maxWeight, minWeight, maxWidth, maxOutDIA);
            string parkingNO = comboBoxParkNO.Text.Trim();
            if (txtStockIn.Text.Trim().Contains('-'))
            {
                FindByStock(txtStockIn.Text.Trim(), parkingNO);
                return;
            }
            txtStockIn.Text = "";
            if (txtMatNO.Text !="")
            {
                SelectDataGridViewRow(dgvPlanOut, txtMatNO.Text.Trim(), "MAT_NO");
            }
           // GetPlanOutInfo(shipSEQNO, parkingNO, pickNO, maxWeight);
            //GetPlanOutInfo(shipSEQNO, parkingNO,planNO, pickNO, maxWeight);
            CountBayCoils();
        }

        private void coboxMatNO_DropDown(object sender, EventArgs e)
        {
            try
            {
                coboxMatNO.Items.Clear();
                foreach (clsCoils theCoil in listViewCoil.Items)
                {
                    if (!theCoil.MAT_NO.Contains("号"))
                    {
                        string strPlanNO_ToAdd = theCoil.MAT_NO;
                        bool founded = false;
                        foreach (string strPlanNO in coboxMatNO.Items)
                        {
                            if (strPlanNO == strPlanNO_ToAdd)
                            {
                                founded = true;
                            }
                        }
                        if (founded == false)
                        {
                            coboxMatNO.Items.Add(strPlanNO_ToAdd);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        private void dgvPlanOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex!=-1)
                {
                    Addtitle();
                    bool hasCheck = (bool)dgvPlanOut.Rows[e.RowIndex].Cells["CHECK_COLUMN"].EditedFormattedValue;
                    string coilMatNO = "";
                    if (dgvPlanOut.Rows[e.RowIndex].Cells["MAT_NO"].Value == null)
                    {
                        MessageBox.Show(string.Format("材料号为空"));
                        return;
                    }
                    if (dgvPlanOut.Rows[e.RowIndex].Cells["PLAN_NO"].Value == null)
                    {
                        MessageBox.Show(string.Format("提单号为空"));
                        return;
                    }
                    if (dgvPlanOut.Rows[e.RowIndex].Cells["STOCK_NO"].Value == null)
                    {
                        MessageBox.Show(string.Format("库位号为空"));
                        return;
                    }
                    coilMatNO = dgvPlanOut.Rows[e.RowIndex].Cells["MAT_NO"].Value.ToString();
                    //没选 添加进去
                    if (hasCheck)
                    {                      
                        if (hasCoilMatNO(coilMatNO))
                        {
                            clsCoils coil = new clsCoils();
                            coil.MAT_NO = dgvPlanOut.Rows[e.RowIndex].Cells["MAT_NO"].Value.ToString();
                            coil.PLAN_NO = dgvPlanOut.Rows[e.RowIndex].Cells["PLAN_NO"].Value.ToString();
                            coil.ColumnNO = dgvPlanOut.Rows[e.RowIndex].Cells["STOCK_NO"].Value.ToString();

                            coil.outDIA = dgvPlanOut.Rows[e.RowIndex].Cells["OUTDIA"].Value.ToString();
                            coil.width = dgvPlanOut.Rows[e.RowIndex].Cells["WIDTH"].Value.ToString();
                            coil.weight = dgvPlanOut.Rows[e.RowIndex].Cells["WEIGHT"].Value.ToString();

                            listViewCoil.Items.Add(coil);
                            dgvPlanOut.Rows[e.RowIndex].Cells["CHECK_COLUMN"].Value = true;
                            txtSelectCoilSNum.Text = (listViewCoil.Items.Count-1).ToString();
                        }
                        //设置焦点
                        txtStockIn.Focus();
                        txtStockIn.SelectAll();
                        return;
                    }
                    else
                    {
                        foreach (clsCoils item in listViewCoil.Items)
                        {
                            if (item.MAT_NO == coilMatNO)
                            {
                                listViewCoil.Items.Remove(item);
                                dgvPlanOut.Rows[e.RowIndex].Cells["CHECK_COLUMN"].Value = false;
                                txtSelectCoilSNum.Text = (listViewCoil.Items.Count -1).ToString();
                                //设置焦点
                                txtStockIn.Focus();
                                txtStockIn.SelectAll();
                                return;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            
        }

        private void Addtitle()
        {
                if (listViewCoil.Items.Count>0)
                {
                    return;
                }
                else
                {
                    clsCoils titleItem = new clsCoils();
                    titleItem.MAT_NO =    "  材料号   ";
                    titleItem.PLAN_NO =   " 发货单号 ";
                    titleItem.ColumnNO =  "  库位号 ";
                    titleItem.weight = "  重量 ";
                    titleItem.width = "  宽度 ";
                    titleItem.outDIA = "  外径 ";
                    listViewCoil.Items.Add(titleItem);
                }
        }
        /// <summary>
        /// 判断是否已经选择
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        private bool hasCoilMatNO(string mat)
        {
            foreach (clsCoils item in listViewCoil.Items)
            {
                if (item.MAT_NO==mat)
                {
                    MessageBox.Show(string.Format("该材料：{0} 已经选择。", mat));
                    return false;
                }
            }
            return true;
        }


        private void ckBoxAllCoil_CheckedChanged(object sender, EventArgs e)
        {
            if (comBoxShipName.Text.Trim() =="")
            {
                return;
            }
            GetPlanOutInfoByPicknON(comBoxShipName.Text.Trim(), comboBoxShipSEQNO.Text.Trim(), cbbPlantNO.Text.Trim());
            //统计在库数量
            CountBayCoils();
        }

        private void listViewCoil_DrawItem(object sender, DrawItemEventArgs e)
        {
            MessageBox.Show(string.Format("listViewCoil_DrawItem"));
        }

        /// <summary>
        /// 查找指定库位
        /// </summary>
        /// <param name="stockIn"></param>
        /// <param name="parkNO">Z52</param>
        private void FindByStock(string stockIn,string parkNO)
        {
            //库位
            if (!stockIn.Contains('-') )
            {
                MessageBox.Show(string.Format("输入库位：{0}格式不合法，请重新输入，格式为：排-列。", stockIn));
                stockIn = "";
                return;
            }
            if ( parkNO.Length<3 ||!parkNO.Contains('F') )
            {
                 MessageBox.Show(string.Format("输入车位：{0}格式不合法，请重新输入。", parkNO));
                 parkNO = "";
                 return;
            }
            if (stockIn.Trim().Length >= 1 )
            {
                string strStockNO = "";
                //string str0;
                string str1;
                string str2;
                //str0 = parkNO.Substring(0, 3);
                int index1 = stockIn.Trim().IndexOf('-');
                str1 = stockIn.Trim().Substring(0, index1);
                str2 = stockIn.Trim().Substring(index1 + 1);
                strStockNO = string.Format("FT11{0}{1}", str1, str2);
                foreach (DataGridViewRow dgvRow in dgvPlanOut.Rows)
                {
                    if (dgvRow.Cells["STOCK_NO"].Value != null)
                    {
                        if (dgvRow.Cells["STOCK_NO"].Value.ToString() == strStockNO)
                        {
                            dgvPlanOut.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                            dgvRow.Cells["STOCK_NO"].Selected = true;
                            dgvPlanOut.CurrentCell = dgvRow.Cells["STOCK_NO"];
                            return;
                        }
                    }
                }
                MessageBox.Show(string.Format("没有找到指定的库位号：{0}", strStockNO));

            }
        }
        /// <summary>
        /// 网格指定查询
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
        #region 材料筛选
        private void setMyDatagridViewRows(string MaxWeight, string MinWeight, string MaxWidth, string MaxOutDIA)
        {
            //状态清空
            foreach (DataGridViewRow dgvRow in dgvPlanOut.Rows)
            {
                dgvRow.DefaultCellStyle.BackColor = Color.White;
            }
            dgvPlanOut.DefaultCellStyle.BackColor = Color.White;

            if (MaxWeight == "" && MinWeight == "" && MaxWidth == "" && MaxOutDIA == "")
            {
                return;
            }
            if (MaxWeight != "" || MinWeight != "")   //重量筛选
            {
                setMyDatagridViewRows_Weight(MaxWeight, MinWeight);
            }
            if (MaxWidth != "")
            {
                setMyDatagridViewRows_Width(MaxWidth);
            }
            if (MaxOutDIA != "")
            {
                setMyDatagridViewRows_OutDIA(MaxOutDIA);
            }
            //
            string matNO ="";
            foreach(DataGridViewRow dgvRow in dgvPlanOut.Rows)
            {
                if (dgvRow.Cells["MAT_NO"].Value != null)
                {
                    matNO = dgvRow.Cells["MAT_NO"].Value.ToString();
                }
                //重量
                if (lstMatsWeight.Count > 0)
                {
                    if (lstMatsWeight.Contains(matNO))
                    {
                        dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dgvRow.DefaultCellStyle.BackColor = Color.White;
                    }
                    //宽度
                    if (lstMatsWidth.Count > 0)
                    {
                        if (dgvRow.DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            if (lstMatsWidth.Contains(matNO))
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.White;
                            }
                        }
                    }
                    //外径
                    if (lstMatsOutDIA.Count > 0)
                    {
                        if (dgvRow.DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            if (lstMatsOutDIA.Contains(matNO))
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.White;
                            }
                        }
                    }
                }

                else if (lstMatsWidth.Count > 0)
                {
                    if (lstMatsWidth.Contains(matNO))
                    {
                        dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dgvRow.DefaultCellStyle.BackColor = Color.White;
                    }

                    //外径
                    if (lstMatsOutDIA.Count > 0)
                    {
                        if (dgvRow.DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            if (lstMatsOutDIA.Contains(matNO))
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.White;
                            }
                        }
                    }
                }
                else if (lstMatsOutDIA.Count > 0)
                {
                    if (lstMatsOutDIA.Contains(matNO))
                    {
                        dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dgvRow.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            //满足条件添加进list
            foreach (DataGridViewRow dgvRow in dgvPlanOut.Rows)
            {
                if (dgvRow.DefaultCellStyle.BackColor == Color.Yellow)
                {
                    string matNO2 = "";
                    if (dgvRow.Cells["MAT_NO"].Value != null)
                    {
                        matNO2 = dgvRow.Cells["MAT_NO"].Value.ToString();
                    }
                    lstAllowCoils.Add(matNO2);
                }
            }
        }

        private void setMyDatagridViewRows_Weight(string MaxWeight, string MinWeight)
        {
            int min = MinWeight =="" ? 0 : int.Parse(MinWeight);
            int max = MaxWeight =="" ? 99999 :int.Parse(MaxWeight);
            lstMatsWeight.Clear();
            foreach (DataGridViewRow dgvRow in dgvPlanOut.Rows)
            {
                if (dgvRow.Cells["WEIGHT"].Value != null && dgvRow.Cells["MAT_NO"].Value != null)
                {
                    int matWeight = int.Parse(dgvRow.Cells["WEIGHT"].Value.ToString());
                    string matNO = dgvRow.Cells["MAT_NO"].Value.ToString();
                    if (min <= matWeight && matWeight <= max)
                    {
                        lstMatsWeight.Add(matNO);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void setMyDatagridViewRows_Width(string MaxWidth)
        {
            int max = MaxWidth == "" ? 99999 : int.Parse(MaxWidth);
            lstMatsWidth.Clear();
            foreach (DataGridViewRow dgvRow in dgvPlanOut.Rows)
            {
                if (dgvRow.Cells["WIDTH"].Value != null && dgvRow.Cells["MAT_NO"].Value != null)
                {
                    int matWidth = int.Parse(dgvRow.Cells["WIDTH"].Value.ToString());
                    string matNO = dgvRow.Cells["MAT_NO"].Value.ToString();
                    if (matWidth <= max)
                    {
                        //dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                        lstMatsWidth.Add(matNO);
                    }
                    else
                    {
                       // dgvRow.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
        private void setMyDatagridViewRows_OutDIA(string MaxOutDIA)
        {
            int max = MaxOutDIA == "" ? 99999 : int.Parse(MaxOutDIA);
            lstMatsOutDIA.Clear();
            foreach (DataGridViewRow dgvRow in dgvPlanOut.Rows)
            {
                if (dgvRow.Cells["OUTDIA"].Value != null && dgvRow.Cells["MAT_NO"].Value != null)
                {
                    int matOutDIA = int.Parse(dgvRow.Cells["OUTDIA"].Value.ToString());
                    string matNO = dgvRow.Cells["MAT_NO"].Value.ToString();
                    if (matOutDIA <= max)
                    {
                        //dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                        lstMatsOutDIA.Add(matNO);
                    }
                    else
                    {
                        //.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }


        #endregion


        #region textBox事件
        private void txtStockIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFine_Click(null, null);
            }
        }

        private void txtStockIn_TextChanged(object sender, EventArgs e)
        {
            ManagerHelper.TextBoxToUp((TextBox)sender);
        }

        private void coboxWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFine_Click(null, null);
            }
        }

        private void comBoxShipName_DropDown(object sender, EventArgs e)
        {
            if (comBoxShipName.Items.Count > 3)
                return;
            GetComboxShipName();
        }

        private void btnReelect_Click(object sender, EventArgs e)
        {
            listViewCoil.Items.Clear();
            Addtitle();
        }

        private void txtStockIn_Click(object sender, EventArgs e)
        {
            txtStockIn.SelectAll();
        }


        private void kuajiacheForm_Shown(object sender, EventArgs e)
        {
            if (comBoxShipName.Items.Count > 3)
                return;
            GetComboxShipName();
        } 
        #endregion

        #region 多库位判断

        private bool checkMatNOCount(out string repeatedMats)
        {
            bool ret = false;
            repeatedMats = "";
            foreach (clsCoils item in listViewCoil.Items)
            {
                if (item.MAT_NO != null && item.MAT_NO != "" && item.MAT_NO.Length > 10)
                {

                    string matNO = item.MAT_NO;
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
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sql))
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
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sql))
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
                        retInfo += "没有钢卷信息 ;";
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

        #region cbb动态筛选item
        private void bindCbbEvent(ComboBox cbb)
        {
            cbb.TextUpdate += comboBox1_TextUpdate;
            cbb.DropDown += comboBox1_DropDown;
            cbb.DropDownClosed += comboBox1_DropDownClosed;
            cbb.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
        }
        /// <summary>
        /// 动态绑定ComboBox数据的方法
        /// </summary>
        private void BindComboBox(ComboBox cbb)
        {

            //检测临时数组是否有值.初始化时临时数组为空
            if (listNew.Count > 0)
            {
                //清空COMBOBOX里的下拉框数据
                if (cbb.Items.Count > 0) 
                {
                   cbb.Items.Clear();
                }
                //重新绑定新数据
               cbb.Items.AddRange(listNew.ToArray());//绑定数据
                //指定下拉框显示项长度
               if (listNew.Count>10)
               {
                   cbb.MaxDropDownItems = 10;
               }
               else
                    cbb.MaxDropDownItems = listNew.Count;
                //清空临时数组
                this.listNew.Clear();
            }
            //默认数组内有值且当前输入框内容为空
            else if (listOnit.Count > 0 && CbxNowStr == "")
            {
                //清空COMBOBOX里的下拉框数据
                if (cbb.Items.Count > 0)
                {
                   cbb.Items.Clear();
                }
                //绑定默认数组数据给下拉框
               cbb.Items.AddRange(listOnit.ToArray());//绑定数据
                //指定下拉框显示项长度
               if (listOnit.Count > 10)
               {
                   cbb.MaxDropDownItems = 10;// listOnit.Count;

               }
               else
               {
                   cbb.MaxDropDownItems = listOnit.Count;
               }
            }
        }
        //此方法内会用到DroppedDown方法所以必须使用TextUpdate事件,如果用TextChanged事件则会和DroppedDown冲突
        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            ComboBox cbb = (ComboBox)sender;
            //暂时保存当前输入框的值
            CbxNowStr = cbb.Text;
            CbxOldStr = CbxNowStr;//CbxNowStr在此方法结束时会被清空,因此需要此变量用作记录数据
            //关闭下拉框一次,下面会重新打开
            cbb.DroppedDown = false;
            //清空COMBOBOX下拉框
            if (cbb.Items.Count > 0)
            {
                //清空combobox
                cbb.Items.Clear();
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
                if (item.Contains(cbb.Text.Trim()))
                {
                    //符合，插入ListNew
                    listNew.Add(item);
                }
            }
            //将临时数组内容绑定到控件,临时数组有值则加临时数组的数据,临时数组无值则不会添加任何数据
            BindComboBox(cbb);
            //确定要弹出下拉框的条件:输入框必须有值
            if (cbb.Text.Trim() != "")
            {
                //确定要弹出下拉框的条件:下拉框列表必须有数据
                if (cbb.Items.Count > 0)
                {
                    //确定要弹出下拉框的条件:下拉框首行数据与输入框内数据并不完全一致
                    if (cbb.Text.Trim() != cbb.Items[0].ToString().Trim())
                    {
                        //自动弹出下拉框
                        cbb.DroppedDown = true;
                    }
                }
            }
            //将原先保存的输入框值重新给回输入框,因调用弹开下拉框列表时输入框值会被自动填充
            cbb.Text = CbxNowStr;
            //清空CbxNowStr
            CbxNowStr = "";
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            cbb.SelectionStart = cbb.Text.Length;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            ComboBox cbb = (ComboBox)sender;
            if (CbxNowStr == "")//确定是否鼠标点击时调用的下拉事件
            {
                if (cbb.Items.Count > 0)
                {
                    cbb.Items.Clear();
                }
                if (this.listNew.Count > 0)
                {
                    this.listNew.Clear();
                }
                BindComboBox(cbb);
            }
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            cbb.SelectionStart = cbb.Text.Length;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox cbb = (ComboBox)sender;
            cbb.Text = CbxOldStr;

            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;

            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            cbb.SelectionStart = cbb.Text.Length;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cbb = (ComboBox)sender;
            if (cbb.SelectedItem != null)
            {
                CbxOldStr = cbb.SelectedItem.ToString();
            }
        }
        #endregion
        private void cbbPlantNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = (ComboBox)sender;

            if (cbb.Text !="")
            {
                //查询库内材料
                GetPlanOutInfoByPicknON(comBoxShipName.Text.Trim(),comboBoxShipSEQNO.Text.Trim(), cbb.Text.Trim());
                //统计在库数量
                CountBayCoils();
            }

        }

        /// <summary>
        /// 根据根据船批号查询
        /// </summary>
        /// <param name="shipSEQNO"></param>
        private void GetPlanOutInfoByPicknON(string shipName,string shipSeqNO, string lotNO)
        {
            //准备数据
            dtPlanOut.Clear();
            try
            {
                string sqlText = @" SELECT 0 AS CHECK_COLUMN,F.LOT_NO as PICK_NO, F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , C.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, 
                             D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  
                             LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO 
                             LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  
                             LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO 
                             LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  
                             LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO WHERE 1=1 " ;

                if (!ckBoxAllCoil.Checked)
                {
                    sqlText += " AND A.STOCK_NO IS NOT NULL ";  
                }
                if (lotNO != "全部")
                {
                    sqlText += " AND F.LOT_NO ='{0}' order by C.PLAN_NO ";
                    sqlText = string.Format(sqlText, lotNO);
                }
                else if (shipSeqNO != "全部")
                {
                    sqlText += " AND F.SHIP_SEQ_NO ='{0}' order by C.PLAN_NO ";
                    sqlText = string.Format(sqlText, shipSeqNO);
                }
                else
                {
                    sqlText += " AND F.SHIP_NAME ='{0}' order by C.PLAN_NO ";
                    sqlText = string.Format(sqlText, shipName);
                }
                if (shipName == "全部")
                {
                    comboBoxShipSEQNO.Text = "";
                    cbbPlantNO.Text = "";
                    sqlText = @" SELECT 0 AS CHECK_COLUMN,F.LOT_NO as PICK_NO, F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , A.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, 
                             D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_YARDMAP_STOCK_DEFINE A  
                             LEFT JOIN  UACS_PLAN_OUT_DETAIL C ON C.MAT_NO = A.MAT_NO 
                             LEFT JOIN  UACS_YARDMAP_COIL B ON A.MAT_NO = B.COIL_NO  
                             LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO 
                             LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  
                             LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO WHERE 1=1
                             AND A.MAT_NO IS NOT NULL ";
                    string bayNO = "";
                    string parkNO =comboBoxParkNO.Text.Trim();
                    if (parkNO.Contains("Z51"))
                    {
                        bayNO = "Z51-1";
                    }
                    else if(parkNO.Contains("Z52"))
                    {
                        bayNO = "Z52-1";
                    }
                    else if (parkNO.Contains("Z53"))
                    {
                        bayNO = "Z53-1";
                    }
                    else if (parkNO.Contains("FT"))
                    {
                        bayNO = "A-1";
                    }
                    if (bayNO =="")
                    {
                        return;
                    }
                    sqlText += " AND A.BAY_NO = '"+ bayNO + "' ";
                    sqlText += " AND A.STOCK_NO LIKE '" + parkNO.Substring(0, 2) + "%' ";  //FT
                    sqlText += " ORDER BY A.STOCK_NO";
                }
                using (IDataReader rdr = ClsParkingManager.DBHelper.ExecuteReader(sqlText))
                {
                    dtPlanOut.Load(rdr);
                }
                dgvPlanOut.DataSource = dtPlanOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        private void cbbPlantNO_TextChanged(object sender, EventArgs e)
        {
            ComboBox cbb = (ComboBox)sender;
            string UpTem = cbb.Text;
            cbb.Text = UpTem.ToUpper().Trim();
            cbb.SelectionStart = cbb.Text.Length;
            cbb.SelectionLength = 0;
        }

        #region 按跨别选卷

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetComboxOnParkingByBay();
        }

        private void GetComboxOnParkingByBay()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            try
            {
                //string str1 = "";
                //string str2 = "";
                //if (cmbArea.Text.Contains("A"))
                //{

                //}

                string sqlText = @"SELECT DISTINCT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_PARKINGSITE 
                WHERE YARD_NO ='A' AND NAME LIKE 'FT10%' ";
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr["TypeValue"] = rdr["TypeValue"];
                        dr["TypeName"] = rdr["TypeName"];
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            //绑定列表下拉框数据
            this.comboBoxParkNO.DataSource = dt;
            this.comboBoxParkNO.DisplayMember = "TypeName";
            this.comboBoxParkNO.ValueMember = "TypeValue";
            comboBoxParkNO.SelectedItem = 0;
        } 
        #endregion

        #region 去除其他车位已选钢卷
        /// <summary>
        /// 获取当前车位上的所有卷
        /// </summary>
        private void getCurParkingcoils()
        {
            try
            {
                lstOtherParkingCoils.Clear();
                string sqlText = @" SELECT A.MAT_NO  FROM UACS_TRUCK_STOWAGE_DETAIL A WHERE  A.STOWAGE_ID IN
                            (SELECT B.STOWAGE_ID FROM UACS_PARKING_STATUS B) ORDER BY A.MAT_NO";
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        lstOtherParkingCoils.Add(ManagerHelper.JudgeStrNull(rdr["MAT_NO"]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        } 
        #endregion

        private void txtMatNO_TextChanged(object sender, EventArgs e)
        {
            txtStockIn.Text = "";
        }



        #region 获取L3配载
        private void btnAutoStowage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("该功能尚未开放！");
                return;
            if (carNO == "")
            {
                MessageBox.Show("该车位无车！");
                return;
            }
            getL3StowageDetail(carNO);
            txtSelectCoilSNum.Text = (listViewCoil.Items.Count - 1).ToString();
        }
        private void getL3StowageDetail(string carNum)
        {
            listViewCoil.Items.Clear();
            Addtitle();
            string sqlstr = @"SELECT A.MAT_NO, C.STOCK_NO , D.PLAN_NO, B.WEIGHT,B.WIDTH,B.OUTDIA FROM UACS_TRUCK_STOWAGE_L3 A
            LEFT JOIN  UACS_YARDMAP_COIL B ON A.MAT_NO = B.COIL_NO
            LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON A.MAT_NO = C.MAT_NO
            LEFT JOIN UACS_PLAN_OUT_DETAIL D ON A.MAT_NO = D.MAT_NO  WHERE  1=1 ";
            sqlstr += " AND A.TRUCK_NO = '"+carNum+"' ";
            sqlstr += " AND C.BAY_NO = '"+parkBayNO + "' ";
            try
            {
                using (IDataReader rdr = ClsParkingManager.DBHelper.ExecuteReader(sqlstr))
                {
                    while (rdr.Read())
                    {
                        clsCoils coil =new clsCoils();
                        coil.MAT_NO = ManagerHelper.JudgeStrNull(rdr["MAT_NO"]);
                        coil.PLAN_NO = ManagerHelper.JudgeStrNull(rdr["PLAN_NO"]);
                        coil.outDIA = ManagerHelper.JudgeStrNull(rdr["OUTDIA"]);
                        coil.weight = ManagerHelper.JudgeStrNull(rdr["WEIGHT"]);
                        coil.width = ManagerHelper.JudgeStrNull(rdr["WIDTH"]);
                        coil.ColumnNO = ManagerHelper.JudgeStrNull(rdr["STOCK_NO"]);
                        listViewCoil.Items.Add(coil);
                    }
                }
                if (listViewCoil.Items.Count <= 1)
                {
                    MessageBox.Show(string.Format("没有找到该车辆:{0}配载!",carNO));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        #endregion


    }
}
