using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkClassLibrary;
using UACSParking;
using System.Threading;

namespace UACSParking
{

    public delegate void TrainSelectCoilCommit(ClsTrainCase clsTrainCase);
    public partial class SubFrmTrainSelectCoil : Baosight.iSuperframe.Forms.FormBase
    {
        public enum TrainCoilDefine
        {
            LL = 1,
            LM = 4,
            LR = 7,
            ML = 1,
            MM = 4,
            MR = 7,
            RL = 1,
            RM = 4,
            RR = 7
        };
        private string railwayLineNO = "";

        //public string RailwayLineNO
        //{
        //    get { return railwayLineNO; }
        //    set { railwayLineNO = value;  }
        //}
        DataTable dt = new DataTable();

        string parkNO = "FT1-A-Railway";

        string bayNO = "A-1";

        clsTrainCoils clsCoilSelected = new clsTrainCoils();
        public event TrainSelectCoilCommit TrainSelectCoilCommit;
        public SubFrmTrainSelectCoil()
        {
            InitializeComponent();
           
        }

        public SubFrmTrainSelectCoil(ClsTrainCase clsTrain)
        {
            InitializeComponent();
            railwayLineNO = clsTrain.RailwayLineNO;

            parkNO = railwayLineNO.Contains("PT57") ? "FT3-C-Railway":"FT1-A-Railway"  ;
            bayNO = railwayLineNO.Contains("PT57") ? "C-1" : "A-1";
            trainStowage1.setClsTrainCase ( (ClsTrainCase)clsTrain.Clone());
            trainStowage1.SendLabName += trainStowage1_SendLabName;  //SendLabName : LL0
            trainStowage1.updataStowage();
            this.Load += new System.EventHandler(this.SubFrmTrainSelectCoil_Load);
        }
        //单击事件
        void trainStowage1_SendLabName(string labNane)
        {
            clsCoilSelected = new clsTrainCoils(trainStowage1.ClsTrainStowage.TrainCaseCoils[labNane]);
            //if (trainStowage1.ClsTrainStowage.TrainCaseCoils.ContainsKey(labNane))
            if (trainStowage1.ClsTrainStowage.TrainCaseCoils[labNane].MAT_NO != "")
            {
                //if (trainStowage1.ClsTrainStowage.TrainCaseCoils[labNane].bracketNO == "")
                //{
                //    trainStowage1.ClsTrainStowage.TrainCaseCoils[labNane].bracketNO = labNane;
                //    trainStowage1.ClsTrainStowage.TrainCaseCoils[labNane].MAT_NO = "                    ";
                //}
                //if (trainStowage1.ClsTrainStowage.TrainCaseCoils[labNane].MAT_NO !="")
                {
                    string strMatNO = trainStowage1.ClsTrainStowage.TrainCaseCoils[labNane].MAT_NO.Trim();
                    SelectDataGridViewRow(dataGridView1, strMatNO, "COIL_NO");
                    clsCoilSelected = trainStowage1.ClsTrainStowage.TrainCaseCoils[labNane];
                }
                
            }
            else
            {
                clsCoilSelected.bracketNO = labNane;
            }
            trainStowage1.setLabBackColor(labNane, Color.LightSkyBlue);
            operationGuide();

        }
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

        private void Addtitle()
        {
            // foreach (clsCoils item in listViewCoil.Items)
            {
                if (listBox1.Items.Count > 0)
                {
                    return;
                }
                else
                {
                    clsTrainCoils titleItem = new clsTrainCoils();
                    titleItem.MAT_NO = "  材料号        ";
                    titleItem.bracketNO = "位置";
                    titleItem.ColumnNO = "库位号    ";
                    titleItem.PLAN_NO = "发货单号";
                    listBox1.Items.Add(titleItem);
                }
            }
        }

        private void SubFrmTrainSelectCoil_Load(object sender, EventArgs e)
        {
            Addtitle();
            tsslabGuide.Text = "选卷流程：第一步，单击选择火车位置；第二步，勾选该位置的钢卷";
            ManagerHelper.DataGridViewInit(dataGridView1);
            dataGridView1.ReadOnly = false;
            Thread t = new Thread(new ParameterizedThreadStart(BindMatStock1));
            t.IsBackground = true;
            t.Start("FT1-A-Railway");
            updataListbox();
            btnReelect_Click(null, null);
        }

        /// <summary>
        /// 绑定材料位置信息
        /// </summary>
        private void BindMatStock(string packing, string planNo = "")
        {
            if (!packing.Contains('F') || packing.Trim() == "")
            {
                return;
            }
            dt.Clear();

            long XMax = 400000;
            long XMin = 400000;
            if (packing == "Z53A1" || packing == "Z53A2")
            {
                //max  392292 392271
                //min 250499
                XMax = 439400;
                XMin = 250300;
            }
            if (packing == "Z52A1" || packing == "Z52A2")
            {
                //mini 450295 450292 450280
                //min  308856  250499
                XMax = 450300;
                XMin = 250300;
            }
            if (packing == "Z51A1" || packing == "Z51A2")
            {
                //max   450671 450681 450671
                //min 308785
                XMax = 450800;
                XMin = 308500;
            }
            string sqlText_All = @"  SELECT 0 AS CHECK_COLUMN, C.MAT_NO AS COIL_NO, A.LOT_NO as LOT_NO,  C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,";
            sqlText_All += "    D.X_CENTER, D.Y_CENTER, C.Z_CENTER ,";
            sqlText_All += " B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_YARDMAP_STOCK_DEFINE C ";
            sqlText_All += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
            sqlText_All += " LEFT JOIN  UACS_PLAN_L3PICK A ON C.MAT_NO = A.COIL_NO ";
            sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON C.STOCK_NO = E.STOCK_NO ";
            sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO ";
            //sqlText_All += " WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
            sqlText_All += " WHERE  C.BAY_NO = '" + bayNO + "' ";
            sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL  ";
            if (packing.Contains("Z5"))
            {

                sqlText_All += " AND D.X_CENTER >" + XMin.ToString();
                sqlText_All += " AND D.X_CENTER <" + XMax.ToString();
            }


            if (planNo == "")
            {

            }
            else if (planNo.Trim().Length > 3)
            {
                sqlText_All += " AND A.LOT_NO  like '" + "%" + planNo + "%' ";
            }
            sqlText_All += " order by C.STOCK_NO DESC ";
            using (IDataReader rdr =ClsParkingManager.DBHelper.ExecuteReader(sqlText_All))
            {
                //while (rdr.Read())
                //{
                //    if (!hasSetColumn)
                //    {
                //        setDataColumn(dt, rdr);
                //    }
                //    hasSetColumn = true;
                //    DataRow dr = dt.NewRow();
                //    for (int i = 0; i < rdr.FieldCount; i++)
                //    {
                //        dr[i] = rdr[i];
                //    }
                //    dt.Rows.Add(dr);
                //}
                dt.Load(rdr);
            }
            this.dataGridView1.DataSource = dt;

            dataGridView1.Columns["ACT_WEIGHT"].Visible = false;
            dataGridView1.Columns["ACT_WIDTH"].Visible = false;
        }

        private void BindMatStock1(object packing_)
        {
            try
            {
                DataTable dt1 = new DataTable();
                string packing = (string)packing_;
                string planNo = "";
                if (!packing.Contains('F') || packing.Trim() == "")
                {
                    return;
                }

                long XMax = 400000;
                long XMin = 400000;
                if (packing == "Z53A1" || packing == "Z53A2")
                {
                    //max  392292 392271
                    //min 250499
                    XMax = 439400;
                    XMin = 250300;
                }
                if (packing == "Z52A1" || packing == "Z52A2")
                {
                    //mini 450295 450292 450280
                    //min  308856  250499
                    XMax = 450300;
                    XMin = 250300;
                }
                if (packing == "Z51A1" || packing == "Z51A2")
                {
                    //max   450671 450681 450671
                    //min 308785
                    XMax = 450800;
                    XMin = 308500;
                }
                string sqlText_All = @"  SELECT 0 AS CHECK_COLUMN, C.MAT_NO AS COIL_NO, A.LOT_NO as LOT_NO,  C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,";
                sqlText_All += "    D.X_CENTER, D.Y_CENTER, C.Z_CENTER ,";
                sqlText_All += " B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_YARDMAP_STOCK_DEFINE C ";
                sqlText_All += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
                sqlText_All += " LEFT JOIN  UACS_PLAN_L3PICK A ON C.MAT_NO = A.COIL_NO ";
                sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON C.STOCK_NO = E.STOCK_NO ";
                sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO ";
                //sqlText_All += " WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
                sqlText_All += " WHERE  C.BAY_NO = '" + bayNO + "' ";
                sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL  ";
                if (packing.Contains("Z5"))
                {

                    sqlText_All += " AND D.X_CENTER >" + XMin.ToString();
                    sqlText_All += " AND D.X_CENTER <" + XMax.ToString();
                }


                if (planNo == "")
                {

                }
                else if (planNo.Trim().Length > 3)
                {
                    sqlText_All += " AND A.LOT_NO  like '" + "%" + planNo + "%' ";
                }
                sqlText_All += " order by C.STOCK_NO DESC ";
                using (IDataReader rdr = ClsParkingManager.DBHelper.ExecuteReader(sqlText_All))
                {
                    dt1.Load(rdr);
                }
                LoadDtata(dt1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            
        }
        delegate void LoadDtataDelegate(DataTable dt);
        private void LoadDtata(DataTable dt)
        {
            if (this.dataGridView1.InvokeRequired == true)
            {
                this.dataGridView1.Invoke(new LoadDtataDelegate(LoadDtata), new object[] { dt });
                return;
            }
            this.dataGridView1.DataSource = dt;

            dataGridView1.Columns["ACT_WEIGHT"].Visible = false;
            dataGridView1.Columns["ACT_WIDTH"].Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                    Addtitle();
                    bool hasCheck = (bool)dataGridView1.Rows[e.RowIndex].Cells["CHECK_COLUMN"].EditedFormattedValue;
                    string coilMatNO = "";
                    if (dataGridView1.Rows[e.RowIndex].Cells["COIL_NO"].Value == null)
                    {
                        MessageBox.Show(string.Format("材料号为空"));
                        return;
                    }
                    //if (dataGridView1.Rows[e.RowIndex].Cells["PLAN_NO"].Value == null)
                    //{
                    //    MessageBox.Show(string.Format("提单号为空"));
                    //    return;
                    //}
                    if (dataGridView1.Rows[e.RowIndex].Cells["STOCK_NO"].Value == null)
                    {
                        MessageBox.Show(string.Format("库位号为空"));
                        return;
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["OUTDIA"].Value != null)   //钢卷外径判断
                    {
                        int coilOutDIA = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["OUTDIA"].Value.ToString());
                        if (coilOutDIA >=1700)
                        {
                            DialogResult dr = MessageBox.Show("该钢卷外径大于1.7米，自动吊运可能会触碰车皮。是否继续？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr != System.Windows.Forms.DialogResult.Yes)
                            {
                                return;
                            }
                        }
                    }
                    if (clsCoilSelected.bracketNO == null || clsCoilSelected.bracketNO == "")
                    {
                        MessageBox.Show("请先选择一个钢支架位置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dataGridView1.Rows[e.RowIndex].Cells["CHECK_COLUMN"].Value = false;
                        return;
                    }
                    coilMatNO = dataGridView1.Rows[e.RowIndex].Cells["COIL_NO"].Value.ToString();

                    //没选 添加进去
                    if (hasCheck && clsCoilSelected.bracketNO != null && clsCoilSelected.bracketNO != "")
                    {
                        if (hasCoilMatNO(coilMatNO))
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["CHECK_COLUMN"].Value = true;
                            return;
                        }
                        clsCoilSelected.MAT_NO = dataGridView1.Rows[e.RowIndex].Cells["COIL_NO"].Value.ToString();
                        clsCoilSelected.PLAN_NO = dataGridView1.Rows[e.RowIndex].Cells["PLAN_NO"].Value.ToString();
                        clsCoilSelected.ColumnNO = dataGridView1.Rows[e.RowIndex].Cells["STOCK_NO"].Value.ToString();
                        clsCoilSelected.status = 100;
                        trainStowage1.ClsTrainStowage.TrainCaseCoils[clsCoilSelected.bracketNO] = clsCoilSelected;
                        trainStowage1.refreshTrainStowage();

                        //添加火车类
                       
                        //设置焦点
                        //txtStockIn.Focus();
                        //txtStockIn.SelectAll();
                        updataListbox();  //更新listbox
                        operationGuide();
                        return;
                    }
                    else
                    {
                        foreach (clsTrainCoils item in listBox1.Items)
                        {
                            if (item.MAT_NO == coilMatNO)
                            {
                                delectTrainCaseCoil(coilMatNO);
                                string infodel = "清空该位置的钢卷，当前支架：" + clsCoilSelected.bracketNO + "，已选钢卷：" + clsCoilSelected.MAT_NO;
                                tsslabGuide.Text = infodel;
                                dataGridView1.Rows[e.RowIndex].Cells["CHECK_COLUMN"].Value = false;
                                //txtSelectCoilSNum.Text = (listBox1.Items.Count - 1).ToString();
                                //设置焦点
                                //txtStockIn.Focus();
                                //txtStockIn.SelectAll();
                                updataListbox();  //更新listbox
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
                    /// <summary>
        /// 判断是否已经选择
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        private bool hasCoilMatNO(string mat)
        {
            bool ret = false;
            foreach (KeyValuePair<string ,clsTrainCoils> kvp in trainStowage1.ClsTrainStowage.TrainCaseCoils)
            {
                if (kvp.Value.MAT_NO == mat)
                {
                    MessageBox.Show(string.Format("该材料：{0} 已经选择。", mat));
                    ret = true;
                }
            }
            return ret;
        }
        void updataListbox()
        {
            listBox1.Items.Clear();
            Addtitle();
            foreach (var item in trainStowage1.ClsTrainStowage.TrainCaseCoils)
            {
                listBox1.Items.Add(item.Value);
            }
        }
        void delectTrainCaseCoil(string matNO)
        {
            foreach (var item in trainStowage1.ClsTrainStowage.TrainCaseCoils)
            {
                if (item.Value.MAT_NO == matNO)
                {
                    trainStowage1.ClsTrainStowage.TrainCaseCoils[item.Key] = new clsTrainCoils(); //清空
                    return;
                }
            }
        }
        private void operationGuide(ref int currStatus)
        {
            switch (currStatus)
            {
                case 1:
                    string step1 = "第一步，选中火车皮上的一个位置，当前位置："+clsCoilSelected.bracketNO+"，已选钢卷："+clsCoilSelected.MAT_NO;
                    tsslabGuide.Text = step1;
                    currStatus++;
                    break;
                case 2:
                    string step2 = "第二步，选择该位置对应的钢卷号,"+"，当前位置："+clsCoilSelected.bracketNO+"，已选钢卷："+clsCoilSelected.MAT_NO;
                    tsslabGuide.Text = step2;
                    currStatus++;
                    break;
                //case 3:
                //    string step3 = "第三步，选择该位对应的钢卷号";
                //    tsslabGuide.Text = step3;
                //    break;
                //case 4:
                //    string step4 = "第二步，选择该位对应的钢卷号";
                //    tsslabGuide.Text = step4;
                //    break;
                default:
                    string step0 = "配卷成功"+"，当前位置："+clsCoilSelected.bracketNO+"，已选钢卷："+clsCoilSelected.MAT_NO;
                    tsslabGuide.Text = step0;
                    currStatus = 1;
                    break;
            }
        }
        private void operationGuide( )
        {
            string step1 = "已选位置：" + clsCoilSelected.bracketNO + "，已选钢卷：" + clsCoilSelected.MAT_NO;
            tsslabGuide.Text = step1;
        }
        //提交
        private void btnCommit_Click(object sender, EventArgs e)
        {
            string tagValue;
            tagValue = railwayLineNO + "|" + trainStowage1.ClsTrainStowage.TrainCaseNO + "-";
            string temp =""; 
            foreach (var item in trainStowage1.ClsTrainStowage.TrainCaseCoils)
            {
                if (item.Value.MAT_NO =="")
                {
                    continue;
                }
                temp += item.Value.bracketNO.Replace("-",",") + "," + item.Value.MAT_NO + "|";
            }
            tagValue += temp.Substring(0,temp.LastIndexOf('|'));
            DialogResult dr = MessageBox.Show("是否确定提交？ " , "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr != DialogResult.OK)
            {
                return;
            }
            ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_COILS_MODIFY, tagValue);
            if (TrainSelectCoilCommit==null)
	        {
                TrainSelectCoilCommit(trainStowage1.ClsTrainStowage);
	        }
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //提单
            if (txtGetPlanNo.Text.Trim().Length > 3)
            {            

                string toUpPlanNO = txtGetPlanNo.Text.ToUpper().Trim();
                BindMatStock(parkNO, toUpPlanNO);
                    //
                return;
            }
            else
            {
                txtGetPlanNo.Text = "";
            }
            //库位
            if (!txtBoxStockNO.Text.Contains('-') && txtGetMat.Text.Trim() == "")
            {
                MessageBox.Show(string.Format("输入库位：{0}格式不合法，请重新输入，格式为：排-列。",txtBoxStockNO.Text));
                txtBoxStockNO.Text = "";
                return;
            }
            if (txtBoxStockNO.Text.Trim().Length >= 1 && txtGetMat.Text.Trim() == "")
            {
                string strStockNO = "";
                string str0;
                string str1;
                string str2;
                str0 = string.Format("{0}1", parkNO.Substring(0, 3));
                int index1=txtBoxStockNO.Text.Trim().IndexOf('-');
                str1 = txtBoxStockNO.Text.Trim().Substring(0, index1);

                str2 = txtBoxStockNO.Text.Trim().Substring(index1 + 1);

                strStockNO = string.Format("{0}{1}{2}", str0, str1, str2);
               // SelectDataGridViewRow(dataGridView1, txtBoxStockNO.Text.Trim(), "STOCK_NO");
                foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
                {
                    if (dgvRow.Cells["STOCK_NO"].Value != null)
                    {
                        if (dgvRow.Cells["STOCK_NO"].Value.ToString() == strStockNO)
                        {
                            dataGridView1.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                            dgvRow.Cells["STOCK_NO"].Selected = true;
                            //dgvRow.Cells["CHECK_COLUMN"].Value = true;
                            dataGridView1.CurrentCell = dgvRow.Cells["STOCK_NO"];

                            return;
                        }
                    }
                }
                MessageBox.Show(string.Format("没有找到指定的库位号：{0}", strStockNO));
          }
            //材料
            if (txtGetMat.Text.Trim() == "")
            {
                //cbBoxPickNo_SelectedIndexChanged(null, null);
                return;
            }
            if (txtGetMat.Text.Trim().Length >= 11)
                SelectDataGridViewRow(dataGridView1, txtGetMat.Text.Trim(), "COIL_NO");
            else
            {
                MessageBox.Show(string.Format("没有找到该材料号：{0}", txtGetMat.Text.Trim()));
            }

    }
        //重选
        private void btnReelect_Click(object sender, EventArgs e)
        {
            trainStowage1.resetStowage();
            updataListbox();
        }
        //删除
        private void btndet_Click(object sender, EventArgs e)
        {
            delectTrainCaseCoil(coboxMatNO.Text.Trim());
            trainStowage1.refreshTrainStowage();
            updataListbox();
        }

        private void coboxMatNO_DropDown(object sender, EventArgs e)
        {
            try
            {
                coboxMatNO.Items.Clear();
                foreach (clsTrainCoils theCoil in listBox1.Items)
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

        private string changToTagFormat(string str)
        {
            string strRet = "";
            string coilPosition;
            int coilCount=0;
            coilPosition = str.Substring(0, 1);
            string temp = str.Substring(0, str.IndexOf('-'));

            TrainCoilDefine enunTemp = (TrainCoilDefine)Enum.Parse(typeof(TrainCoilDefine), temp, true);
            coilCount = (int)enunTemp + Convert.ToInt32(str.Substring(str.IndexOf('-') + 1));
            strRet =  coilPosition + "," + coilCount;
            return strRet;
        }

        private void txtBoxStockNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void txtBoxStockNO_TextChanged(object sender, EventArgs e)
        {
            txtGetPlanNo.Text = txtGetPlanNo.Focused ? txtGetPlanNo.Text : "";
            txtGetMat.Text = txtGetMat.Focused ? txtGetMat.Text : "";
            string UpTem = txtBoxStockNO.Text;
            txtBoxStockNO.Text = UpTem.ToUpper().Trim();
            txtBoxStockNO.SelectionStart = txtBoxStockNO.Text.Length;
            txtBoxStockNO.SelectionLength = 0;
        }

        private void txtGetMat_TextChanged(object sender, EventArgs e)
        {
            string UpTem = txtGetMat.Text;
            txtGetMat.Text = UpTem.ToUpper().Trim();
            txtGetMat.SelectionStart = txtGetMat.Text.Length;
            txtGetMat.SelectionLength = 0;
            txtGetPlanNo.Text = txtGetPlanNo.Focused ? txtGetPlanNo.Text : "";
            txtBoxStockNO.Text = txtBoxStockNO.Focused ? txtBoxStockNO.Text : "";
            //if (txtGetMat.Text == "1")
            //{
            //    MessageBox.Show("卷半径干涉关闭。", "警告");
            //}
        }

        private void txtGetPlanNo_TextChanged(object sender, EventArgs e)
        {
            string UpTem = txtGetPlanNo.Text;
            txtGetPlanNo.Text = UpTem.ToUpper().Trim();
            txtGetPlanNo.SelectionStart = txtGetPlanNo.Text.Length;
            txtGetPlanNo.SelectionLength = 0;
            if (txtGetPlanNo.Text.Trim() == "")
            {
                //加载材料信息
                BindMatStock(parkNO);
            }
        }
    }
   
}
