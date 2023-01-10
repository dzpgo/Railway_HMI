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
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        IAuthorization auth = Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<Baosight.iSuperframe.Authorization.Interface.IAuthorization>()
        as Baosight.iSuperframe.Authorization.Interface.IAuthorization;
        //
        DataTable dtPlanOut = new DataTable();
        string parkBayNO = "";
        string carNO = "";
        bool openFlag = false;  //画面跳转标记
        bool isStowage = false;
        int selectCoilNum = 8;
        public kuajiacheForm()
        {
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();

            //框架车出库
            TagValues.Add("EV_PARKING_MDL_OUT_CAL_START", null);
            tagDP.Attach(TagValues);

            dgvPlanOut.CellFormatting += dgvPlanOut_CellFormatting;
            
        }
        public kuajiacheForm(string parkingNO)
        {
            //清空数据
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();

            //框架车出库
            TagValues.Add("EV_PARKING_MDL_OUT_CAL_START", null);
            tagDP.Attach(TagValues);
            //画面跳转
            ClearHMIData();
            openFlag = true;
            isStowage = false;
            //comboBoxParkNO.Enabled = false;
            GetComboxOnParking();
            comboBoxParkNO.Text = parkingNO;
            comboBoxParkNO_SelectedIndexChanged(null, null);  //初始化画面的参数，必须初始化
            dgvPlanOut.CellFormatting += dgvPlanOut_CellFormatting;
        }
        public kuajiacheForm(string parkingNO,string GrNUm)
        {
            //清空数据
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();

            //框架车出库
            TagValues.Add("EV_PARKING_MDL_OUT_CAL_START", null);
            tagDP.Attach(TagValues);
            //画面跳转
            ClearHMIData();
            openFlag = true;
            isStowage = false;
            //comboBoxParkNO.Enabled = false;
            GetComboxOnParking();
            comboBoxParkNO.Text = parkingNO;
            txtGrooveNum.Text = GrNUm;
            comboBoxParkNO_SelectedIndexChanged(null, null);  //初始化画面的参数，必须初始化
            dgvPlanOut.CellFormatting += dgvPlanOut_CellFormatting;
        }

        void dgvPlanOut_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
                {
                    if (dgvPlanOut.Columns[e.ColumnIndex].Name.Equals("BAY_NO")
                        || dgvPlanOut.Columns[e.ColumnIndex].Name.Equals("STOCK_NO"))
                    {
                        if (e.Value == null || e.Value.ToString() == "")
                        {                           
                           // e.Value = "";
                            e.CellStyle.BackColor = Color.Gray;
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
        /// 绑定船名
        /// </summary>
        private void GetComboxShipName()
        {
            //准备数据
            try
            {
               // string time = DateTime.Now.ToString("yyyyMMdd");
                comBoxShipName.Items.Clear();
                if (checkBoxAllShip.Checked==true)
                {
                    string sqlText = @"SELECT distinct SHIP_NAME  FROM UACS_PLAN_OUT order by SHIP_NAME";
                    using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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
                    string sqlText = @"SELECT distinct B.SHIP_NAME SHIP_NAME  FROM UACS_PLAN_OUT_DETAIL  C ";
                    //sqlText += "RIGHT outer JOIN UACS_YARDMAP_STOCK_DEFINE A ON  C.MAT_NO = A.MAT_NO ,";
                    //sqlText += "RIGHT  JOIN UACS_YARDMAP_STOCK_DEFINE A ON  C.MAT_NO = A.MAT_NO ";
                    //sqlText += " UACS_PLAN_OUT B   where  B.PLAN_NO = C.PLAN_NO AND ";
                    sqlText += " RIGHT  JOIN UACS_PLAN_OUT B   ON  B.PLAN_NO = C.PLAN_NO WHERE  ";
                    sqlText += "B.SHIP_NAME IS NOT NULL AND C.STATUS='0'";
                    sqlText += " ORDER BY B.SHIP_NAME";
                    using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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
        private void GetComboxhipSEQNO(string shipNO)
        {
            //准备数据
            try
            {
                comboBoxShipSEQNO.Items.Clear();
                string sqlText = @"SELECT DISTINCT SHIP_SEQ_NO  FROM UACS_PLAN_OUT WHERE SHIP_NAME ='{0}'  ";
                sqlText = string.Format(sqlText, shipNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        if (rdr["SHIP_SEQ_NO"] != DBNull.Value)
                        {
                            comboBoxShipSEQNO.Items.Add(rdr["SHIP_SEQ_NO"].ToString());
                        }
                    }
                }
               // comboBoxShipSEQNO.Text = "";

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
                sqlText += "D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_L3PICK G ON C.MAT_NO = G.COIL_NO ";
                sqlText += "WHERE F.SHIP_SEQ_NO ='{0}' order by F.PLAN_NO ";
                sqlText = string.Format(sqlText, shipSEQNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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
                string sqlText = @"SELECT DISTINCT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_PARKINGSITE ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();

                        if (rdr["TypeValue"].ToString().Contains("Z5"))
                        {
                            dr["TypeValue"] = rdr["TypeValue"];
                            dr["TypeName"] = rdr["TypeName"];
                            dt.Rows.Add(dr);
                        }
                    }
                }
                //绑定列表下拉框数据
                this.comboBoxParkNO.DataSource = dt;
                this.comboBoxParkNO.DisplayMember = "TypeName";
                this.comboBoxParkNO.ValueMember = "TypeValue";
                if (!openFlag)
                {
                    comboBoxParkNO.Text = "请选择";           //
                }
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
                GetComboxOnParking();
            }
            CreakConlumcheckBox();
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
            GetComboxhipSEQNO(comBoxShipName.Text.Trim());
            if (comboBoxShipSEQNO.Items.Count>0)
            {
                comboBoxShipSEQNO.SelectedIndex=0;
                //查询记录
                comboBoxShipSEQNO.Text = comboBoxShipSEQNO.Items[comboBoxShipSEQNO.SelectedIndex].ToString();
                comboBoxShipSEQNO_SelectedIndexChanged(null, null);
            }
            //清空数据
            if (!openFlag)
            {
                comboBoxParkNO.Text = "";
            }
            //dtPlanOut.Clear();
            //dgvPlanOut.DataSource = dtPlanOut;
            listViewCoil.Items.Clear();
            //txtPlanCount.Text = "";
            //txtPlanStockCoil.Text = "";
            btnSelectByXMin.BackColor = Color.FromArgb(92, 137, 241);
            btnSelectByXMax.BackColor = Color.FromArgb(92, 137, 241);
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
            btnSelectByXMin.BackColor = Color.FromArgb(92, 137, 241);
            btnSelectByXMax.BackColor = Color.FromArgb(92, 137, 241);
        }
        private void checkBoxAllShip_CheckedChanged(object sender, EventArgs e)
        {            
            GetComboxShipName();
        }

        private void comboBoxShipSEQNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShipSEQNO.Text =="" || comboBoxShipSEQNO.Text=="请选择")
            {
                return;
            }
            //查询记录
            GetPlanOutInfo(comboBoxShipSEQNO.Text.Trim());
            //统计计划数目
            CountBayCoils();

        }
        /// <summary>
        /// 分跨统计钢卷
        /// </summary>
        private void CountBayCoils()
        {
            try
            {       
                int dgvRowsCount = dgvPlanOut.Rows.Count;
                if (dgvRowsCount > 0)
                {
                    txtPlanCount.Text = string.Format("{0} 个", dgvRowsCount.ToString());
                }
                int i = 0;
                int Z53Count, Z52Count, Z51Count;
                Z53Count = Z52Count = Z51Count = 0;
                foreach (DataGridViewRow item in dgvPlanOut.Rows)
                {
                    //if (!item.IsNull("BA.Y_NO") && !item.IsNull("STOCK_NO"))
                    if (!item.Cells["BAY_NO"].Value.Equals(null) || item.Cells["STOCK_NO"].Value.Equals(null))
                    {
                        if (item.Cells["BAY_NO"].Value.ToString().Trim() != "" && item.Cells["STOCK_NO"].Value.ToString().Trim() != "")
                        {
                            i++;
                            //53
                            if (item.Cells["BAY_NO"].Value.ToString().Contains("Z53"))
                            {
                                Z53Count++;
                            }
                            else if (item.Cells["BAY_NO"].Value.ToString().Contains("Z52"))
                            {
                                Z52Count++;
                            }
                            else if (item.Cells["BAY_NO"].Value.ToString().Contains("Z51"))
                            {
                                Z51Count++;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    txtPlanStockCoil.Text = string.Format("总 {0} 个，51跨 {1} 个，52跨 {2} 个，53跨 {3} 个", i.ToString(), Z51Count, Z52Count, Z53Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
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
            if (comboBoxParkNO.Text.Trim() == "" || !comboBoxParkNO.Text .Contains('Z'))
            {
                return;
            }
            //刷新钢卷信息表
            comboBoxShipSEQNO_SelectedIndexChanged(null, null);
            //btnFine_Click(null, null);
            parkBayNO = comboBoxParkNO.Text.Trim().Substring(0, 3);
            parkBayNO = string.Format("{0}-1", parkBayNO);
            carNO=  GetTextOnCar(comboBoxParkNO.Text.Trim());
            listViewCoil.Items.Clear();
            coboxPickNO.Text = "";
            coboxWeight.Text = "";
            txtStockIn.Text = "";
            txtPlanNO.Text = "";
            btnSelectByXMin.BackColor = Color.FromArgb(92, 137, 241);
            btnSelectByXMax.BackColor = Color.FromArgb(92, 137, 241);
            isStowage = false;

        }



        private void btnSelectCoilXMax_Click(object sender, EventArgs e)
        {
            int coilCount=0;
            long XMax = 400000;
            long XMin=400000;

            string parkingNO=comboBoxParkNO.Text.Trim();
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
                listViewCoil.Items.Clear();
                string sqlText = @"SELECT 0 AS CHECK_COLUMN,F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , C.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,  ";
                sqlText += "D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO  ";
                sqlText += "WHERE F.SHIP_SEQ_NO ='{0}'  ";
                sqlText += " AND A.BAY_NO = '{1}' ";
                sqlText += " AND D.X_CENTER>" + XMin.ToString();
                sqlText += " AND D.X_CENTER<" + XMax.ToString();
                sqlText+=" order by D.X_CENTER DESC ";


                sqlText = string.Format(sqlText, comboBoxShipSEQNO.Text.Trim(),parkBayNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read() && coilCount<8)// && i < 50)
                    {
                        coilCount++;
                        clsCoils theCoil_Ship = new clsCoils();

                        //先接收内厂材料号
                        theCoil_Ship.MAT_NO = Convert.ToString(rdr["MAT_NO"]);

                        theCoil_Ship.PLAN_NO = Convert.ToString(rdr["PLAN_NO"]);

                        theCoil_Ship.ColumnNO = Convert.ToString(rdr["STOCK_NO"]);
                        listViewCoil.Items.Add(theCoil_Ship);
                        txtSelectCoilSNum.Text = listViewCoil.Items.Count.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        private void btnSelectCoilXMin_Click(object sender, EventArgs e)
        {

            long XMax = 400000;
            long XMin = 400000;

            string parkingNO = comboBoxParkNO.Text.Trim();
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
                listViewCoil.Items.Clear();
                string sqlText = @"SELECT 0 AS CHECK_COLUMN,F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , C.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,  ";
                sqlText += "D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO  ";
                sqlText += " WHERE F.SHIP_SEQ_NO ='{0}'  ";
                sqlText += " AND A.BAY_NO = '{1}' ";
                sqlText += " AND D.X_CENTER>" + XMin.ToString();
                sqlText += " AND D.X_CENTER<" + XMax.ToString();
                sqlText += " order by D.X_CENTER  ";

                sqlText = string.Format(sqlText, comboBoxShipSEQNO.Text.Trim(), parkBayNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    int coilCount = 0;
                    while (rdr.Read() && coilCount < 8)// && i < 50)
                    {
                        coilCount++;
                        clsCoils theCoil_Ship = new clsCoils();

                        //先接收内厂材料号
                        theCoil_Ship.MAT_NO = Convert.ToString(rdr["MAT_NO"]);

                        theCoil_Ship.PLAN_NO = Convert.ToString(rdr["PLAN_NO"]);

                        theCoil_Ship.ColumnNO = Convert.ToString(rdr["STOCK_NO"]);

                        listViewCoil.Items.Add(theCoil_Ship);
                        txtSelectCoilSNum.Text = listViewCoil.Items.Count.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        private void SelectCoilByDrection(string dret)
        {
            int coilCount = 0;


            listViewCoil.Items.Clear();           
            Addtitle();
            string parkingNO = comboBoxParkNO.Text.Trim();

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

                string sqlText = @"SELECT 0 AS CHECK_COLUMN,F.PLAN_NO,F.SHIP_SEQ_NO, A.BAY_NO , C.MAT_NO,A.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,  ";
                sqlText += " D.X_CENTER, D.Y_CENTER, A.Z_CENTER,F.PLAN_TIME,F.SHIP_NAME FROM UACS_PLAN_OUT_DETAIL C  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON A.STOCK_NO = E.STOCK_NO  ";
                sqlText += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO  ";
                sqlText += " LEFT JOIN  UACS_PLAN_OUT F ON C.PLAN_NO = F.PLAN_NO  ";
                sqlText += " WHERE F.SHIP_SEQ_NO ='{0}'  ";
                sqlText += " AND A.BAY_NO = '{1}' ";
                sqlText += " AND D.X_CENTER>" + XMin.ToString();
                sqlText += " AND D.X_CENTER<" + XMax.ToString();
                if (dret == "从X大方向")
                {
                    sqlText += " order by D.X_CENTER DESC ";
                }
                else if (dret == "从X小方向")
                {
                    sqlText += " order by D.X_CENTER  ASC";
                }
                sqlText = string.Format(sqlText, comboBoxShipSEQNO.Text.Trim(), parkBayNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read() && coilCount < selectCoilNum)// && i < 50)
                    {
                        coilCount++;
                        clsCoils theCoil_Ship = new clsCoils();

                        //先接收内厂材料号
                        theCoil_Ship.MAT_NO = Convert.ToString(rdr["MAT_NO"]);

                        theCoil_Ship.PLAN_NO = Convert.ToString(rdr["PLAN_NO"]);

                        theCoil_Ship.ColumnNO = Convert.ToString(rdr["STOCK_NO"]);
                        listViewCoil.Items.Add(theCoil_Ship);

                    }
                }
                if (listViewCoil.Items.Count==0)
                {
                    MessageBox.Show("没找到指定类型的钢卷");
                }
                txtSelectCoilSNum.Text = (listViewCoil.Items.Count-1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
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
                if (parkNOA == "" || !parkNOA.Contains('Z'))
                {
                    return "";
                }
                string sql = string.Format("select CAR_NO,HEAD_POSTION ,TREATMENT_NO ,LASER_ACTION_COUNT from UACS_PARKING_STATUS where PARKING_NO = '{0}' ", parkNOA);

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
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
                    if (theCoil.ColumnNO.Contains('Z')) //标题不要
                    {
                        myValue += theCoil.MAT_NO;
                        myValue += "|";
                        countCoul++;
                    }

                }
               // //debug
               //// richTextBoxDebug.Text += string.Format("发送的Tag的myValue 的值：\n{0}\n", myValue);
               // DialogResult dr = MessageBox.Show(string.Format("发送的Tag的myValue 的值：\n{0}\n", myValue), "提示", MessageBoxButtons.YesNo);
               // if (dr == DialogResult.Yes)
               // {
               //     //this.Close();
               //     //return;
               // }
               // else if (dr == DialogResult.No)
               // {
               //     return;
               // }
               // //debug

                sqlText = @"UPDATE UACS_TRUCK_STOWAGE SET MD_COIL_READY = '{0}' WHERE STOWAGE_ID = {1} ";
                sqlText = string.Format(sqlText, myValue, stowageNo);
                DBHelper.ExecuteNonQuery(sqlText);

                //发送tag
                myValue = myValue.Substring(0, myValue.Length - 1);


                    tagDP.SetData("EV_PARKING_MDL_OUT_CAL_START", myValue);


                //更新模型计算次数
                sqlText = @"UPDATE UACS_PARKING_STATUS SET MDL_CAL_ID = {0} where PARKING_NO = '{1}'";
                sqlText = string.Format(sqlText, mdlCalId, parkingNo);
                DBHelper.ExecuteNonQuery(sqlText);
                isStowage = true;
                MessageBox.Show("框架车选择材料成功，行车准备自动运行，请注意安全！");
                auth.OpenForm("成品库框架车出库");
               // this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                MessageBox.Show("框架车选择材料失败！");
            }

        }

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (selectCoilNum==8)
        //    {
        //        selectCoilNum = 30;
        //    }
        //    else
        //    {
        //        selectCoilNum = 8;
        //    }
        //}

        private void btnSelectByXMax_Click(object sender, EventArgs e)
        {
            string SelectDret = "从X大方向";
            SelectCoilByDrection(SelectDret);
            btnSelectByXMax.BackColor = Color.Green;
            btnSelectByXMin.BackColor = Color.FromArgb(92, 137, 241);	
        }

        private void btnSelectByXMin_Click(object sender, EventArgs e)
        {
            string SelectDret = "从X小方向";
            SelectCoilByDrection(SelectDret);
            btnSelectByXMin.BackColor = Color.Green;
            btnSelectByXMax.BackColor = Color.FromArgb(92, 137, 241);		
        }

        private void btnFine_Click(object sender, EventArgs e)
        {
            string shipSEQNO=comboBoxShipSEQNO.Text.Trim();
            string maxWeight=coboxWeight.Text.Trim();
            string pickNO = coboxPickNO.Text.Trim();
            string parkingNO=comboBoxParkNO.Text.Trim();
            string planNO = txtPlanNO.Text.Trim();
            if (txtStockIn.Text.Trim().Contains('-'))
            {
                FindByStock(txtStockIn.Text.Trim(), parkingNO);
                return;
            }
            txtStockIn.Text = "";
           // GetPlanOutInfo(shipSEQNO, parkingNO, pickNO, maxWeight);
            GetPlanOutInfo(shipSEQNO, parkingNO,planNO, pickNO, maxWeight);
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
           // foreach (clsCoils item in listViewCoil.Items)
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
                    listViewCoil.Items.Add(titleItem);
                }
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

        private void coboxPickNO_TextChanged(object sender, EventArgs e)
        {
            string UpTem = coboxPickNO.Text;
            coboxPickNO.Text = UpTem.ToUpper().Trim();
            coboxPickNO.SelectionStart = coboxPickNO.Text.Length;
            coboxPickNO.SelectionLength = 0;
            txtStockIn.Text = "";
        }

        private void ckBoxAllCoil_CheckedChanged(object sender, EventArgs e)
        {
            //if (selectCoilNum == 8)
            //{
            //    selectCoilNum = 30;
            //}
            //else
            //{
            //    selectCoilNum = 8;
            //}

            string shipSEQNO = comboBoxShipSEQNO.Text.Trim();
            string maxWeight = coboxWeight.Text.Trim();
            string pickNO = coboxPickNO.Text.Trim();
            string parkingNO = comboBoxParkNO.Text.Trim();
            GetPlanOutInfo(shipSEQNO, parkingNO, pickNO, maxWeight);
            CountBayCoils();
        }

        private void listViewCoil_DrawItem(object sender, DrawItemEventArgs e)
        {
            MessageBox.Show(string.Format("listViewCoil_DrawItem"));
        }
        /// <summary>
        /// 
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
            if ( parkNO.Length<3 ||!parkNO.Contains('Z') )
            {
                 MessageBox.Show(string.Format("输入车位：{0}格式不合法，请重新输入。", parkNO));
                 parkNO = "";
                 return;
            }
            if (stockIn.Trim().Length >= 1 )
            {
                string strStockNO = "";
                string str0;
                string str1;
                string str2;
                str0 = parkNO.Substring(0, 3);
                int index1 = stockIn.Trim().IndexOf('-');
                str1 = stockIn.Trim().Substring(0, index1);
                if (str1.Length == 1)
                {
                    str1 = string.Format("00{0}", str1);
                }
                else if (str1.Length > 1)
                    str1 = string.Format("0{0}", str1);

                str2 = stockIn.Trim().Substring(index1 + 1);
                for (int i = str2.Length; i < 3; i++)
                {
                    str2 = string.Format("0{0}", str2);

                }
                strStockNO = string.Format("{0}{1}{2}1", str0, str1, str2);
                // SelectDataGridViewRow(dataGridView1, stockIn.Trim(), "STOCK_NO");
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

        private void txtStockIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFine_Click(null, null);
            }
        }

        private void coboxPickNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFine_Click(null, null);
            }
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

        private void txtPlanNO_Click(object sender, EventArgs e)
        {
            txtPlanNO.SelectAll();
        }

        private void txtPlanNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFine_Click(null, null);
            }
        }

        private void kuajiacheForm_Shown(object sender, EventArgs e)
        {
            if (comBoxShipName.Items.Count > 3)
                return;
            GetComboxShipName();
        }


    }
}
