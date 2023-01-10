using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PT;
using PsionTeklogix.Keyboard;
using PsionTeklogix;
using PsionTeklogix.Barcode;
using System.Threading;

namespace _1550PDA
{
    public partial class ShemeOutSearch : Form
    {
        /// <summary>
        /// table相关
        /// </summary>
        /// <param name="_Truck"></param>
        private DataTable table_pick = new DataTable("table_pick");
        private DataTable table_l3pro = new DataTable("table_l3pro");
        private DataTable table_l2pro = new DataTable("table_l2pro");
        private DataTable table_tran = new DataTable("table_tran");
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle_pick = new DataGridTableStyle();
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle_l3pro = new DataGridTableStyle();
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle_l2pro = new DataGridTableStyle();
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle_tran = new DataGridTableStyle();
        /// <summary>
        /// 出库材料
        /// </summary>
        /// <param name="_Truck"></param>
        private Dictionary<string, dtOutPlan> dicMat = new Dictionary<string, dtOutPlan>();
        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="_Truck"></param>
        public PT.PTInterfacePrx Prx = null;
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        /// <summary>
        /// 接口返回值
        /// </summary>
        /// <param name="_Truck"></param>
        private int nResult = 0;

        public ShemeOutSearch(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            Prx = _Prx;
            people = _people;
            InitializeComponent();
        }
        #region 返回上层画面
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region  4表格初始化
        private void ShemeOutSearch_Load(object sender, EventArgs e)
        {
            try
            {
                InitDataGrid(table_pick);
                InitDataGrid(table_l3pro);
                InitDataGrid(table_l2pro);
                InitDataGrid(table_tran);
                //默认选中发货 查询所有发货计划
                dtOutPlan[] matlist = null;
                Prx.OutSearch("PICK", out matlist, out nResult, Program.ctx);
                for (int index = 0; index < matlist.Length; index++)
                {
                    dicMat.Add(matlist[index].matterNo, matlist[index]);
                    //提单号下拉菜单
                    if (!cbxPlanNo.Items.Contains(matlist[index].PlanNO))
                    {
                        cbxPlanNo.Items.Add(matlist[index].PlanNO);
                    }
                }
                ShowData(dicMat);
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, false);
                

            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
            
        }
        #endregion
        #region  表格初始化时 给表格赋值
        /// <summary>
        /// 表格初始化时 给表格赋值
        /// </summary>
        /// <param name="table">表格数据</param>
        private void InitDataGrid(DataTable table)
        {
            if (table.TableName == "table_pick")
            {
                table.Columns.Add("提单号", typeof(string));
                table.Columns.Add("材料号", typeof(string));
                table.Columns.Add("垛位", typeof(string));
                table.Columns.Add("目的地", typeof(string));
                table.Columns.Add("车", typeof(string));
                MappingTheTable(table);
            }
            if (table.TableName == "table_l3pro")
            {
                table.Columns.Add("计划号", typeof(string));
                table.Columns.Add("材料号", typeof(string));
                table.Columns.Add("垛位", typeof(string));
                table.Columns.Add("机组号", typeof(string));
                MappingTheTable(table);
            }
            if (table.TableName == "table_l2pro")
            {
                table.Columns.Add("计划号", typeof(string));
                table.Columns.Add("材料号", typeof(string));
                table.Columns.Add("垛位", typeof(string));
                table.Columns.Add("机组号", typeof(string));
                MappingTheTable(table);
            }
            if (table.TableName == "table_tran")
            {
                table.Columns.Add("计划号", typeof(string));
                table.Columns.Add("材料号", typeof(string));
                table.Columns.Add("垛位", typeof(string));
                table.Columns.Add("下道库区号", typeof(string));
                MappingTheTable(table);
            }
        }
        #endregion
        #region 数据Table映射
        private void MappingTheTable(DataTable table)
        {
            #region 提单表
            if (table.TableName == "table_pick")
            {
                dg_pick.DataSource = table;

                //dataGridTableStyle1.
                dataGridTableStyle_pick.MappingName = "table_pick";
                dg_pick.RowHeadersVisible = false;

                DataGridTextBoxColumn theCol_Plan = new DataGridTextBoxColumn();
                theCol_Plan.HeaderText = "提单号";
                theCol_Plan.MappingName = "提单号";
                theCol_Plan.Width = 155;

                DataGridTextBoxColumn theCol_MaterialNo = new DataGridTextBoxColumn();
                theCol_MaterialNo.HeaderText = "材料号";
                theCol_MaterialNo.MappingName = "材料号";
                theCol_MaterialNo.Width = 95;

                DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
                theCol_Stock.HeaderText = "垛位";
                theCol_Stock.MappingName = "垛位";
                theCol_Stock.Width = 85;

                DataGridTextBoxColumn theCol_Car = new DataGridTextBoxColumn();
                theCol_Car.HeaderText = "车";
                theCol_Car.MappingName = "车";
                theCol_Car.Width = 85;

                DataGridTextBoxColumn theCol_DES = new DataGridTextBoxColumn();
                theCol_DES.HeaderText = "目的地";
                theCol_DES.MappingName = "目的地";
                theCol_DES.Width = 95;

                dataGridTableStyle_pick.MappingName = "table_pick";
                
                dataGridTableStyle_pick.GridColumnStyles.Add(theCol_Plan);
                dataGridTableStyle_pick.GridColumnStyles.Add(theCol_MaterialNo);
                dataGridTableStyle_pick.GridColumnStyles.Add(theCol_Stock);
                dataGridTableStyle_pick.GridColumnStyles.Add(theCol_Car);
                dataGridTableStyle_pick.GridColumnStyles.Add(theCol_DES);

                dg_pick.TableStyles.Add(dataGridTableStyle_pick);
            }
            #endregion 提单表
            #region l3生产表
            if (table.TableName == "table_l3pro")
            {
                dgL3Pro.DataSource = table;
                
                //dataGridTableStyle1.
                dataGridTableStyle_l3pro.MappingName = "table_l3pro";
                dgL3Pro.RowHeadersVisible = false;

                DataGridTextBoxColumn theCol_Plan = new DataGridTextBoxColumn();
                theCol_Plan.HeaderText = "计划号";
                theCol_Plan.MappingName = "计划号";
                theCol_Plan.Width = 155;

                DataGridTextBoxColumn theCol_MaterialNo = new DataGridTextBoxColumn();
                theCol_MaterialNo.HeaderText = "材料号";
                theCol_MaterialNo.MappingName = "材料号";
                theCol_MaterialNo.Width = 95;

                DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
                theCol_Stock.HeaderText = "垛位";
                theCol_Stock.MappingName = "垛位";
                theCol_Stock.Width = 85;

                DataGridTextBoxColumn theCol_DES = new DataGridTextBoxColumn();
                theCol_DES.HeaderText = "机组号";
                theCol_DES.MappingName = "机组号";
                theCol_DES.Width = 95;

                dataGridTableStyle_l3pro.MappingName = "table_l3pro";
                dataGridTableStyle_l3pro.GridColumnStyles.Add(theCol_Plan);
                dataGridTableStyle_l3pro.GridColumnStyles.Add(theCol_MaterialNo);
                dataGridTableStyle_l3pro.GridColumnStyles.Add(theCol_Stock);
                dataGridTableStyle_l3pro.GridColumnStyles.Add(theCol_DES);

                dgL3Pro.TableStyles.Add(dataGridTableStyle_l3pro);
            }
            #endregion
            #region l2生产表
            if (table.TableName == "table_l2pro")
            {
                dg_l2pro.DataSource = table;
                
                //dataGridTableStyle1.
                dataGridTableStyle_l2pro.MappingName = "table_l2pro";
                dgL3Pro.RowHeadersVisible = false;

                DataGridTextBoxColumn theCol_Plan = new DataGridTextBoxColumn();
                theCol_Plan.HeaderText = "计划号";
                theCol_Plan.MappingName = "计划号";
                theCol_Plan.Width = 155;

                DataGridTextBoxColumn theCol_MaterialNo = new DataGridTextBoxColumn();
                theCol_MaterialNo.HeaderText = "材料号";
                theCol_MaterialNo.MappingName = "材料号";
                theCol_MaterialNo.Width = 95;

                DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
                theCol_Stock.HeaderText = "垛位";
                theCol_Stock.MappingName = "垛位";
                theCol_Stock.Width = 85;

                DataGridTextBoxColumn theCol_DES = new DataGridTextBoxColumn();
                theCol_DES.HeaderText = "机组号";
                theCol_DES.MappingName = "机组号";
                theCol_DES.Width = 95;

                dataGridTableStyle_l2pro.MappingName = "table_l2pro";
                dataGridTableStyle_l2pro.GridColumnStyles.Add(theCol_Plan);
                dataGridTableStyle_l2pro.GridColumnStyles.Add(theCol_MaterialNo);
                dataGridTableStyle_l2pro.GridColumnStyles.Add(theCol_Stock);
                dataGridTableStyle_l2pro.GridColumnStyles.Add(theCol_DES);

                dg_l2pro.TableStyles.Add(dataGridTableStyle_l2pro);
            }
            #endregion
            #region 转库
            if (table.TableName == "table_tran")
            {
                dg_tran.DataSource = table;
                
                //dataGridTableStyle1.
                dataGridTableStyle_tran.MappingName = "table_tran";
                dg_tran.RowHeadersVisible = false;

                DataGridTextBoxColumn theCol_Plan = new DataGridTextBoxColumn();
                theCol_Plan.HeaderText = "计划号";
                theCol_Plan.MappingName = "计划号";
                theCol_Plan.Width = 155;

                DataGridTextBoxColumn theCol_MaterialNo = new DataGridTextBoxColumn();
                theCol_MaterialNo.HeaderText = "材料号";
                theCol_MaterialNo.MappingName = "材料号";
                theCol_MaterialNo.Width = 95;

                DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
                theCol_Stock.HeaderText = "垛位";
                theCol_Stock.MappingName = "垛位";
                theCol_Stock.Width = 85;

                DataGridTextBoxColumn theCol_DES = new DataGridTextBoxColumn();
                theCol_DES.HeaderText = "目的地";
                theCol_DES.MappingName = "目的地";
                theCol_DES.Width = 95;

                dataGridTableStyle_tran.MappingName = "table_tran";
                dataGridTableStyle_tran.GridColumnStyles.Add(theCol_Plan);
                dataGridTableStyle_tran.GridColumnStyles.Add(theCol_MaterialNo);
                dataGridTableStyle_tran.GridColumnStyles.Add(theCol_Stock);
                dataGridTableStyle_tran.GridColumnStyles.Add(theCol_DES);

                dg_tran.TableStyles.Add(dataGridTableStyle_tran);
            }
            #endregion
        }
        #endregion
        #region  插入数据到表格
        private void ShowData(Dictionary<string, dtOutPlan> dic)
        {
            try
            {
                #region 发货
                if (tctdg.SelectedIndex == 0)
                {
                    table_pick.Clear();
                    foreach (dtOutPlan mat in dic.Values)
                    {
                        DataRow newRow;
                        newRow = table_pick.NewRow();
                        newRow["提单号"] = mat.PlanNO;
                        newRow["材料号"] = mat.matterNo;
                        newRow["垛位"] = mat.stcUnit.UnitNo;
                        newRow["车"] = mat.ShipCNAME;
                        newRow["目的地"] = mat.HAVEN;

                        table_pick.Rows.Add(newRow);
                    }
                }
                #endregion
                #region 转库
                if (tctdg.SelectedIndex == 1)
                {
                    table_tran.Clear();
                    foreach (dtOutPlan mat in dic.Values)
                    {
                        DataRow newRow;
                        newRow = table_tran.NewRow();
                        newRow["计划号"] = mat.PlanNO;
                        newRow["材料号"] = mat.matterNo;
                        newRow["垛位"] = mat.stcUnit.UnitNo;
                        newRow["下道库区号"] = mat.HAVEN;

                        table_tran.Rows.Add(newRow);
                    }
                }
                #endregion
                #region L3生产计划
                if (tctdg.SelectedIndex == 2)
                {
                    table_l3pro.Clear();
                    foreach (dtOutPlan mat in dic.Values)
                    {
                        DataRow newRow;
                        newRow = table_l3pro.NewRow();
                        newRow["计划号"] = mat.PlanNO;
                        newRow["材料号"] = mat.matterNo;
                        newRow["垛位"] = mat.stcUnit.UnitNo;
                        newRow["机组号"] = mat.HAVEN;

                        table_l3pro.Rows.Add(newRow);
                    }
                }
                #endregion
                #region L2生产计划
                if (tctdg.SelectedIndex == 3)
                {
                    table_l2pro.Clear();
                    foreach (dtOutPlan mat in dic.Values)
                    {
                        DataRow newRow;
                        newRow = table_l2pro.NewRow();
                        newRow["计划号"] = mat.PlanNO;
                        newRow["材料号"] = mat.matterNo;
                        newRow["垛位"] = mat.stcUnit.UnitNo;
                        newRow["机组号"] = mat.HAVEN;

                        table_l2pro.Rows.Add(newRow);
                    }
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

        }
        #endregion

        #region 查询具体计划号信息
        private void cbxPlanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string planno = cbxPlanNo.Text;
                Dictionary<string,dtOutPlan> tmpdic=new Dictionary<string,dtOutPlan>();
                foreach (dtOutPlan mat in dicMat.Values)
                {
                    if (mat.PlanNO == planno)
                    {
                        tmpdic.Add(mat.matterNo, mat);
                    }
                }
                ShowData(tmpdic);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

        }
        #endregion

        #region 跳转tab页 查询
        private void tctdg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbxPlanNo.Items.Clear();
                txtPlan.Text = "";
                string type = "";
                switch (tctdg.SelectedIndex)
                {
                    case 0:
                        type = "PICK";
                        break;
                    case 1:
                        type = "TRAN";
                        break;
                    case 2:
                        type = "L3PRO";
                        break;
                    case 3:
                        type = "L2PRO";
                        break;
                }
                dicMat.Clear();
                dtOutPlan[] matlist=null;
                Prx.OutSearch(type, out matlist, out nResult, Program.ctx);
                for (int index = 0; index < matlist.Length; index++)
                {
                    dicMat[matlist[index].matterNo] = matlist[index];
                    //提单号下拉菜单
                    if (!cbxPlanNo.Items.Contains(matlist[index].PlanNO))
                    {
                        cbxPlanNo.Items.Add(matlist[index].PlanNO);
                    }
                }
                ShowData(dicMat);
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, false);

            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion
        #region 输入部分提单号 查询计划
        private void txtPlan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPlan.Text.Trim().Length > 5)
                {
                    string planno = txtPlan.Text.Trim();
                    Dictionary<string, dtOutPlan> tmpdic = new Dictionary<string, dtOutPlan>();
                    foreach (dtOutPlan mat in dicMat.Values)
                    {
                        if (mat.PlanNO.Contains(planno))
                        {
                            tmpdic.Add(mat.matterNo, mat);
                        }
                    }
                    ShowData(tmpdic);
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion

    }
}