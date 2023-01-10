using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;
using Baosight.iSuperframe.Forms;
using CONTROLS_OF_REPOSITORIES;

namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmYardToYardStraegy : FormBase
    {

        //private YardToYardRequest yardToYard = new YardToYardRequest();

        public FrmYardToYardStraegy()
        {
            InitializeComponent();
            this.Load += FrmYardToYardStraegy_Load;
        }

        void FrmYardToYardStraegy_Load(object sender, EventArgs e)
        {
            ShiftCraneByBay();
        }

        private void cbbBayNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShiftCraneByBay();
        }

        private void cbbCraneNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FrmYordToYordConfPassword password = new FrmYordToYordConfPassword();
            //DialogResult ret = password.ShowDialog();
            //if (ret == DialogResult.OK)
            //{
            GetCoilStrategy(cbbCraneNo.Text.Trim(), dgvCoilStrategy);
            GetSaddleStrategy(cbbCraneNo.Text.Trim(), dgvSaddleStrategy);
            // }

        }

        private void ShiftCraneByBay()
        {
            if (cbbBayNo.Text == "FT1A")              
            {

                cbbCraneNo.Items.Clear();
                cbbCraneNo.Items.Add("1");
                cbbCraneNo.Items.Add("2");
                cbbCraneNo.Items.Add("3");
               
            }
            //if (cbbBayNo.Text == "Z32-1")
            //{

            //    cbbCraneNo.Items.Clear();
            //    cbbCraneNo.Items.Add("4_1");
            //    cbbCraneNo.Items.Add("4_2");
            //    cbbCraneNo.Items.Add("4_3");
            //}
            //else if (cbbBayNo.Text == "Z33-1")
            //{
            //    cbbCraneNo.Items.Clear();
            //    cbbCraneNo.Items.Add("4_4");
            //    cbbCraneNo.Items.Add("4_5");
            //}
            //else if (cbbBayNo.Text == "Z51-1")
            //{
            //    cbbCraneNo.Items.Clear();
            //    cbbCraneNo.Items.Add("7_7");
            //    cbbCraneNo.Items.Add("7_8");
            //    cbbCraneNo.Items.Add("7_9");
            //}
            //else if (cbbBayNo.Text == "Z52-1")
            //{
            //    cbbCraneNo.Items.Clear();
            //    cbbCraneNo.Items.Add("7_4");
            //    cbbCraneNo.Items.Add("7_5");
            //    cbbCraneNo.Items.Add("7_6");
            //}
            //else if (cbbBayNo.Text == "Z53-1")
            //{
            //    cbbCraneNo.Items.Clear();
            //    cbbCraneNo.Items.Add("7_0");
            //    cbbCraneNo.Items.Add("7_1");
            //    cbbCraneNo.Items.Add("7_2");
            //    cbbCraneNo.Items.Add("7_3");
            //}
            //else
            //    MessageBox.Show("不符合要求");
        }

        private void dgvCoilStrategy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CoilId;
            int SaddleId;
            if (e.RowIndex >= 0)
            {
                if (dgvCoilStrategy.Rows[e.RowIndex].Cells["CoilId"].Value != DBNull.Value)
                {
                    CoilId = Convert.ToInt32(dgvCoilStrategy.Rows[e.RowIndex].Cells["CoilId"].Value.ToString());

                    for (int i = 0; i < dgvSaddleStrategy.RowCount; i++)
                    {
                        dgvSaddleStrategy.Rows[i].Selected = false;
                        SaddleId = Convert.ToInt32(dgvSaddleStrategy.Rows[i].Cells["SaddleId"].Value.ToString());
                        if (CoilId == SaddleId)
                        {
                            dgvSaddleStrategy.FirstDisplayedScrollingRowIndex = i;
                            dgvSaddleStrategy.Rows[i].Selected = true;
                            dgvSaddleStrategy.CurrentCell = dgvSaddleStrategy.Rows[i].Cells["SaddleId"];


                        }
                    }
                }
            }
        }

        private void dgvSaddleStrategy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CoilId;
            int SaddleId;
            if (e.RowIndex >= 0)
            {
                if (dgvSaddleStrategy.Rows[e.RowIndex].Cells["SaddleId"].Value != DBNull.Value)
                {
                    SaddleId = Convert.ToInt32(dgvSaddleStrategy.Rows[e.RowIndex].Cells["SaddleId"].Value);
                    for (int i = 0; i < dgvCoilStrategy.RowCount; i++)
                    {
                        dgvCoilStrategy.Rows[i].Selected = false;
                        CoilId = Convert.ToInt32(dgvCoilStrategy.Rows[i].Cells["CoilId"].Value);
                        if (SaddleId == CoilId)
                        {
                            dgvCoilStrategy.FirstDisplayedScrollingRowIndex = i;
                            dgvCoilStrategy.Rows[i].Selected = true;
                            dgvCoilStrategy.CurrentCell = dgvCoilStrategy.Rows[i].Cells["CoilId"];
                        }
                    }
                }
            }
        }


        private void CoilReadOnlyByTrue()
        {
            txtCoilFlagByPlan.ReadOnly = true;
            txtCoilMinNullSaddle.ReadOnly = true;
            txtCoilXDir.ReadOnly = true;
            txtCoilXmax.ReadOnly = true;
            txtCoilXmin.ReadOnly = true;
            txtCoilYmax.ReadOnly = true;
            txtCoilYmin.ReadOnly = true;
        }

        private void CoilReadOnlyByFalse()
        {
            txtCoilFlagByPlan.ReadOnly = false;
            txtCoilMinNullSaddle.ReadOnly = false;
            txtCoilXDir.ReadOnly = false;
            txtCoilXmax.ReadOnly = false;
            txtCoilXmin.ReadOnly = false;
            txtCoilYmax.ReadOnly = false;
            txtCoilYmin.ReadOnly = false;
        }

        private void SaddleReadOnlyByTrue()
        {
            txtSaddleFlagByPlan.ReadOnly = true;
            txtSaddleMinNullSaddle.ReadOnly = true;
            txtSaddleXDir.ReadOnly = true;
            txtSaddleXmax.ReadOnly = true;
            txtSaddleXmin.ReadOnly = true;
            txtSaddleYmax.ReadOnly = true;
            txtSaddleYmin.ReadOnly = true;
        }

        private void SaddleReadOnlyByFalse()
        {
            txtSaddleFlagByPlan.ReadOnly = false;
            txtSaddleMinNullSaddle.ReadOnly = false;
            txtSaddleXDir.ReadOnly = false;
            txtSaddleXmax.ReadOnly = false;
            txtSaddleXmin.ReadOnly = false;
            txtSaddleYmax.ReadOnly = false;
            txtSaddleYmin.ReadOnly = false;
        }


        private void ClearCoilText()
        {
            txtCoilId.Text = "";
            txtCoilXmin.Text = "";
            txtCoilXmax.Text = "";
            txtCoilYmin.Text = "";
            txtCoilYmax.Text = "";
            txtCoilXDir.Text = "";
            txtCoilMinNullSaddle.Text = "";
        }

        private void ClearSaddleText()
        {
            txtSaddleId.Text = "";
            txtSaddleXmin.Text = "";
            txtSaddleXmax.Text = "";
            txtSaddleYmin.Text = "";
            txtSaddleYmax.Text = "";
            txtSaddleXDir.Text = "";
            txtSaddleMinNullSaddle.Text = "";
        }

        private void ShiftCoilByText()
        {
            int index = dgvCoilStrategy.CurrentRow.Index;
            txtCoilId.Text = dgvCoilStrategy.Rows[index].Cells["CoilId"].Value.ToString();
            txtCoilXmin.Text = dgvCoilStrategy.Rows[index].Cells["coilXmin"].Value.ToString();
            txtCoilXmax.Text = dgvCoilStrategy.Rows[index].Cells["coilXmax"].Value.ToString();
            txtCoilYmin.Text = dgvCoilStrategy.Rows[index].Cells["coilYmin"].Value.ToString();
            txtCoilYmax.Text = dgvCoilStrategy.Rows[index].Cells["coilYmax"].Value.ToString();
            txtCoilXDir.Text = dgvCoilStrategy.Rows[index].Cells["coilXDir"].Value.ToString();
            txtCoilMinNullSaddle.Text = dgvCoilStrategy.Rows[index].Cells["coilMinEmptySaddle"].Value.ToString();
            txtCoilFlagByPlan.Text = dgvCoilStrategy.Rows[index].Cells["coilFlagPlan"].Value.ToString();
        }

        private void ShiftSaddleByText()
        {
            int index = dgvSaddleStrategy.CurrentRow.Index;
            txtSaddleId.Text = dgvSaddleStrategy.Rows[index].Cells["SaddleId"].Value.ToString();
            txtSaddleXmin.Text = dgvSaddleStrategy.Rows[index].Cells["saddleXmin"].Value.ToString();
            txtSaddleXmax.Text = dgvSaddleStrategy.Rows[index].Cells["saddleXmax"].Value.ToString();
            txtSaddleYmin.Text = dgvSaddleStrategy.Rows[index].Cells["saddleYmin"].Value.ToString();
            txtSaddleYmax.Text = dgvSaddleStrategy.Rows[index].Cells["saddleYmax"].Value.ToString();
            txtSaddleXDir.Text = dgvSaddleStrategy.Rows[index].Cells["saddleXDir"].Value.ToString();
            txtSaddleMinNullSaddle.Text = dgvSaddleStrategy.Rows[index].Cells["saddleMinEmptySaddle"].Value.ToString();
        }

        private void btnCoilConf_Click(object sender, EventArgs e)
        {
            //FrmYordToYordConfPassword password = new FrmYordToYordConfPassword();
            //DialogResult ret = password.ShowDialog();
            //if (ret == DialogResult.OK)
            //{
                CoilReadOnlyByFalse();
                ShiftCoilByText();
            //}

        }

        private void btnSaddleConf_Click(object sender, EventArgs e)
        {
            //FrmYordToYordConfPassword password = new FrmYordToYordConfPassword();
            //DialogResult ret = password.ShowDialog();
            //if (ret == DialogResult.OK)
            //{
                SaddleReadOnlyByFalse();
                ShiftSaddleByText();
           // }

        }

        private void btnUpCoil_Click(object sender, EventArgs e)
        {

            if (txtCoilId.Text.Trim() == "")
            {
                MessageBox.Show("请先点击--更改起吊配置按钮");
                return;
            }


            string XMin = txtCoilXmin.Text.Trim();
            string XMax = txtCoilXmax.Text.Trim();
            string YMin = txtCoilYmin.Text.Trim();
            string YMax = txtCoilYmax.Text.Trim();
            string XDir = txtCoilXDir.Text.Trim();
            int coilId = Convert.ToInt32(txtCoilId.Text.Trim());
            string MinEmptySaddle = txtCoilMinNullSaddle.Text.Trim();

            if (XMin != "" && XMax != "" && YMin != "" && YMax != "" && XDir != "" && MinEmptySaddle != "")
            {
                bool flag = UpCoilStrategy(Convert.ToInt32(XMin), Convert.ToInt32(XMax), Convert.ToInt32(YMin), Convert.ToInt32(YMax), XDir, Convert.ToInt32(MinEmptySaddle), coilId);
                if (flag)
                    MessageBox.Show(coilId + "起吊配置保存成功");
                else
                {
                    MessageBox.Show(coilId + "起吊配置保存失败");
                    return;
                }

            }
            else
            {
                MessageBox.Show("起吊配置输入项不完整！！！");
                return;
            }
            ClearCoilText();
            CoilReadOnlyByTrue();
            GetCoilStrategy(cbbCraneNo.Text.Trim(), dgvCoilStrategy);
        }

        private void btnUpSaddle_Click(object sender, EventArgs e)
        {
            if (txtSaddleId.Text.Trim() == "")
            {
                MessageBox.Show("请先点击--更改落卷配置按钮");
                return;
            }

            string XMin = txtSaddleXmin.Text.Trim();
            string XMax = txtSaddleXmax.Text.Trim();
            string YMin = txtSaddleYmin.Text.Trim();
            string YMax = txtSaddleYmax.Text.Trim();
            string XDir = txtSaddleXDir.Text.Trim();
            string MinEmptySaddle = txtSaddleMinNullSaddle.Text.Trim();
            int saddleId = Convert.ToInt32(txtSaddleId.Text.Trim());
            if (XMin != "" && XMax != "" && YMin != "" && YMax != "" && XDir != "" && MinEmptySaddle != "")
            {
                bool flag = UpSaddleStrategy(Convert.ToInt32(XMin), Convert.ToInt32(XMax), Convert.ToInt32(YMin), Convert.ToInt32(YMax), XDir, Convert.ToInt32(MinEmptySaddle), saddleId);
                if (flag)
                    MessageBox.Show(saddleId + "落卷配置保存成功");
                else
                {
                    MessageBox.Show(saddleId + "落卷配置保存失败");
                    return;
                }
            }
            else
            {
                MessageBox.Show("落卷配置输入项不完整！！！");
                return;
            }
            ClearSaddleText();
            SaddleReadOnlyByTrue();
            GetSaddleStrategy(cbbCraneNo.Text.Trim(), dgvSaddleStrategy);
        }

        public static void GetCoilStrategy(string _CraneNo, DataGridView _dgv)
        {
            // 标记
            bool hasSetColumn = false;
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT a.DESC,b.ID,b.SEQ,a.X_MIN,a.X_MAX,a.Y_MIN,a.Y_MAX,a.X_DIR,a.LIST_UNIT_NO,a.MIN_EMPTY_SADDLES,a.FLAG_FIND_BY_PLAN FROM  
                          YARD_TO_YARD_FIND_COIL_STRATEGY a left join YARD_TO_YARD_CRANE_STRAEGY b on  a.ID = b.COIL_STRATEGY_ID  WHERE a.ID in (";
                sql += " SELECT COIL_STRATEGY_ID FROM YARD_TO_YARD_CRANE_STRAEGY WHERE CRANE_NO  = '" + _CraneNo + "')";
                sql += " ORDER BY b.SEQ";
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (hasSetColumn == false)
            {
                dt.Columns.Add("DESC", typeof(String));
                dt.Columns.Add("ID", typeof(String));
                dt.Columns.Add("SEQ", typeof(String));
                dt.Columns.Add("X_MIN", typeof(String));
                dt.Columns.Add("X_MAX", typeof(String));
                dt.Columns.Add("Y_MIN", typeof(String));
                dt.Columns.Add("Y_MAX", typeof(String));
                dt.Columns.Add("X_DIR", typeof(String));
                dt.Columns.Add("LIST_UNIT_NO", typeof(String));
                dt.Columns.Add("MIN_EMPTY_SADDLES", typeof(String));
                dt.Columns.Add("FLAG_FIND_BY_PLAN", typeof(String));
            }

            _dgv.DataSource = dt;
        }

        public static void GetSaddleStrategy(string _CraneNo, DataGridView _dgv)
        {
            bool hasSetColumn = false;
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT a.DESC,b.ID,b.SEQ,a.X_MIN,a.X_MAX,a.Y_MIN,a.Y_MAX,a.X_DIR,a.MIN_EMPTY_SADDLES,
                                CASE
                                  WHEN b.FLAG_ENABLED = 0 THEN '倒垛方案取消'
                                  WHEN b.FLAG_ENABLED = 1 THEN '倒垛方案执行'
                              END as FLAG_ENABLED FROM  
                              YARD_TO_YARD_FIND_SADDLE_STRATEGY a left join YARD_TO_YARD_CRANE_STRAEGY b on  a.ID = b.SADDLE_STRATEGY_ID  WHERE a.ID in (";
                sql += " SELECT SADDLE_STRATEGY_ID FROM YARD_TO_YARD_CRANE_STRAEGY WHERE CRANE_NO  = '" + _CraneNo + "')";
                sql += " ORDER BY b.SEQ";
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (hasSetColumn == false)
            {
                dt.Columns.Add("DESC", typeof(String));
                dt.Columns.Add("ID", typeof(String));
                dt.Columns.Add("SEQ", typeof(String));
                dt.Columns.Add("X_MIN", typeof(String));
                dt.Columns.Add("X_MAX", typeof(String));
                dt.Columns.Add("Y_MIN", typeof(String));
                dt.Columns.Add("Y_MAX", typeof(String));
                dt.Columns.Add("X_DIR", typeof(String));
                dt.Columns.Add("MIN_EMPTY_SADDLES", typeof(String));
                dt.Columns.Add("FLAG_ENABLED", typeof(String));
            }

            _dgv.DataSource = dt;
        }

        public static bool UpCoilStrategy(int _xMin, int _xMax, int _yMin, int _yMax, string _xDir, int _minEmptySaddle, int _id)
        {
            try
            {
                string sql = @"update YARD_TO_YARD_FIND_COIL_STRATEGY set ";
                sql += " X_MIN =  " + _xMin + ",";
                sql += " X_MAX =  " + _xMax + ",";
                sql += " Y_MIN =  " + _yMin + ",";
                sql += " Y_MAX =  " + _yMax + ",";
                sql += " X_DIR =  '" + _xDir + "',";
                sql += " MIN_EMPTY_SADDLES = " + _minEmptySaddle + " ";
                sql += " where ID = " + _id + " ";
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        public static bool UpSaddleStrategy(int _xMin, int _xMax, int _yMin, int _yMax, string _xDir, int _minEmptySaddle, int _id)
        {
            try
            {
                string sql = @"update YARD_TO_YARD_FIND_SADDLE_STRATEGY set ";
                sql += " X_MIN =  " + _xMin + ",";
                sql += " X_MAX =  " + _xMax + ",";
                sql += " Y_MIN =  " + _yMin + ",";
                sql += " Y_MAX =  " + _yMax + ",";
                sql += " X_DIR =  '" + _xDir + "',";
                sql += " MIN_EMPTY_SADDLES = " + _minEmptySaddle + " ";
                sql += " where ID = " + _id + " ";
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        public bool UpCraneFlagEnabledByStop(int _id, string _craneNo)
        {
            try
            {
                string sql = @"update YARD_TO_YARD_CRANE_STRAEGY set FLAG_ENABLED = 0 where CRANE_NO = '" + _craneNo + "' and ID = " + _id + " ";
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        public bool UpCraneFlagEnabledByOpen(int _id, string _craneNo)
        {
            try
            {
                string sql = @"update YARD_TO_YARD_CRANE_STRAEGY set FLAG_ENABLED = 1 where CRANE_NO = '" + _craneNo + "' and ID = " + _id + " ";
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        private void StopScheme_Click(object sender, EventArgs e)
        {
            if (cbbCraneNo.Text.Trim() != "")
            {
                int index = dgvSaddleStrategy.CurrentRow.Index;
                string id = dgvSaddleStrategy.Rows[index].Cells["SaddleId"].Value.ToString();
                bool flag = UpCraneFlagEnabledByStop(Convert.ToInt32(id), cbbCraneNo.Text.Trim());
                if (flag)
                    MessageBox.Show(id + "配载方案停止成功");
                else
                    MessageBox.Show(id + "配载方案停止失败");

                GetSaddleStrategy(cbbCraneNo.Text.Trim(), dgvSaddleStrategy);
            }

        }

        private void OpenScheme_Click(object sender, EventArgs e)
        {
            if (cbbCraneNo.Text.Trim() != "")
            {
                int index = dgvSaddleStrategy.CurrentRow.Index;
                string id = dgvSaddleStrategy.Rows[index].Cells["SaddleId"].Value.ToString();
                bool flag = UpCraneFlagEnabledByOpen(Convert.ToInt32(id), cbbCraneNo.Text.Trim());
                if (flag)
                    MessageBox.Show(id + "配载方案打开成功");
                else
                    MessageBox.Show(id + "配载方案打开失败");

                GetSaddleStrategy(cbbCraneNo.Text.Trim(), dgvSaddleStrategy);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("X从小到大为-ASC" + "\n" + "X从大到小为-DES");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("X从小到大为-ASC" + "\n" + "X从大到小为-DES");
        }

    }
}
