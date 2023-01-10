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
    public partial class Inventory_Diff : Form
    {
        /// <summary>
        /// 当前选中材料
        /// </summary>
        private int CurRow = -1;
        /// <summary>
        /// table相关
        /// </summary>
        /// <param name="_Truck"></param>
        private DataTable table = new DataTable("table");
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();
        /// <summary>
        /// 材料字典 显示依此字典为准 索引为库位号
        /// </summary>
        /// <param name="_Truck"></param>
        private Dictionary<string, MatterCls> dicMat = new Dictionary<string, MatterCls>();
        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="_Truck"></param>
        public PT.PTInterfacePrx Prx = null;
        /// <summary>
        /// 接口返回值
        /// </summary>
        /// <param name="_Truck"></param>
        private int nResult = 0;
       
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
  
        public Inventory_Diff(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            Prx = _Prx;
            people = _people;
            InitializeComponent();
            this.Activated += new EventHandler(Inventory_Diff_Activated);
            this.Closed += new EventHandler(Inventory_Diff_Closed);
           
        }
        private void Inventory_Diff_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }
        private void Inventory_Diff_Closed(object sender, EventArgs e)
        {
            ScannerHelper.ScannerDestroy();
        }
        private delegate void OnScanCompleteDelegate(object sender, ScanCompleteEventArgs e);

        #region   void ScannerHelper_ScanCompleteEvent(object sender, ScanCompleteEventArgs e)  扫描完成事件
        /// <summary>
        /// 扫描完成事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        void ScannerHelper_ScanCompleteEvent(object Sender, PsionTeklogix.Barcode.ScanCompleteEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {

                    BeginInvoke(new OnScanCompleteDelegate(ScannerHelper_ScanCompleteEvent),
                        new object[] { Sender, e });
                    return;
                }

                string tmp = e.Text.Trim();

                if (txtSaddle.Focused)
                {
                    if (tmp.Length == 10)
                    {

                     
                        txtSaddle.Text = tmp;
                        txtresult.Text = "扫描成功";
                        txtresult.BackColor = Color.Green;
                    

                    }
                    else
                    {
                        txtresult.Text = "扫描数据错误";
                        txtresult.BackColor = Color.Red;
                    }

                }
                if (txtMatNo.Focused)
                {
                    if (txtMatNo.Text.Length < 10)
                    {
                        txtresult.Text = "扫描数据错误";
                        txtresult.BackColor = Color.Red;
                    }
                    else
                    {
                        txtMatNo.Text = tmp;
                    }
                }
            }

            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "材料扫描失败";
                txtresult.BackColor = Color.Green;
            }

        }
        #endregion

        private void btnRet_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 查询所有差异信息
        /// <summary>
        /// 查询所有差异信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            { 
                MatterCls[] matlist=null;
                Prx.StockDiffSearch(out matlist, out nResult, Program.ctx);
                if (matlist.Length != 0)
                {
                    for (int i = 0; i < matlist.Length; i++)
                    {
                        //收集材料信息
                        matlist[i].status = "UnScan";
                        //不会出现同一垛位多个材料 故不需要判断contains
                        dicMat[matlist[i].stcUnit.UnitNo] = matlist[i];
                       
                    }
                    ShowData(dicMat);
                }
                else
                {
                    txtresult.Text = "无差异垛位";
                    txtresult.BackColor = Color.Red;
                }
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, false);
                txtresult.Text = "访问超时";
                txtresult.BackColor = Color.Red;

            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion

        #region 表格初始化
        private void Inventory_Diff_Load(object sender, EventArgs e)
        {
            InitDataGrid(table);
        }
        #endregion
        #region  表格初始化时 给表格赋值
        /// <summary>
        /// 表格初始化时 给表格赋值
        /// </summary>
        /// <param name="table">表格数据</param>
        private void InitDataGrid(DataTable table)
        {
            table.Columns.Add("状态", typeof(string));
            table.Columns.Add("库位", typeof(string));
            table.Columns.Add("实际材料", typeof(string));
            table.Columns.Add("系统材料", typeof(string));
           
            MappingTheTable();
        }
        #endregion
        #region 数据Table映射
        private void MappingTheTable()
        {
            dataGrid1.DataSource = table;

            //dataGridTableStyle1.
            dataGridTableStyle1.MappingName = "table";
            dataGrid1.RowHeadersVisible = false;

            DataGridTextBoxColumn theCol_STATUS = new DataGridTextBoxColumn();
            theCol_STATUS.HeaderText = "状态";
            theCol_STATUS.MappingName = "状态";
            theCol_STATUS.Width = 55;

            DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
            theCol_Stock.HeaderText = "库位";
            theCol_Stock.MappingName = "库位";
            theCol_Stock.Width = 85;

            DataGridTextBoxColumn theCol_REAL_MaterialNo = new DataGridTextBoxColumn();
            theCol_REAL_MaterialNo.HeaderText = "实际材料";
            theCol_REAL_MaterialNo.MappingName = "实际材料";
            theCol_REAL_MaterialNo.Width = 95;

            DataGridTextBoxColumn theCol_SYS_MaterialNo = new DataGridTextBoxColumn();
            theCol_SYS_MaterialNo.HeaderText = "系统材料";
            theCol_SYS_MaterialNo.MappingName = "系统材料";
            theCol_SYS_MaterialNo.Width = 95;

           

            dataGridTableStyle1.MappingName = "table";

            dataGridTableStyle1.GridColumnStyles.Add(theCol_STATUS);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Stock);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_REAL_MaterialNo);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_SYS_MaterialNo);
            

            dataGrid1.TableStyles.Add(dataGridTableStyle1);
        }
        #endregion
        #region  插入数据到表格
        private void ShowData(Dictionary<string, MatterCls> dic)
        {
            try
            {
                table.Clear();
                foreach (MatterCls mat in dic.Values)
                {
                    DataRow newRow;
                    newRow = table.NewRow();
                    newRow["状态"] = Program.ToChnOutMatStatus(mat.status);
                    newRow["库位"] = mat.stcUnit.UnitNo;
                    newRow["实际材料"] = mat.matno;
                    newRow["系统材料"] = mat.sqare1;
                   
                    table.Rows.Add(newRow);
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

        }
        #endregion

        #region 扫描或输入库位号/材料号
        /// <summary>
        /// 扫描或输入库位号/材料号 扫描完成两文本框循环获得焦点
        /// 考虑手输，仍判断数据正确性
        /// 材料号与库位号同时输入完成后 添加或更新材料
        /// 添加结束后 库位获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSaddle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSaddle.Text.Length == 10)
                {
                    txtSaddle.Text = txtSaddle.Text.ToUpper();

               
                    if (txtMatNo.Text.Length > 10)
                    {
                        ScanedEnd();
                    }
                    else
                    {
                        txtMatNo.Focus();
                    }
                   
                    

                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        private void txtMatNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMatNo.Text.Length > 10)
                {
                    if (txtSaddle.Text.Length == 10)
                    {
                        ScanedEnd();
                    }
                    else
                    {
                        txtSaddle.Focus();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        /// <summary>
        /// 更新字典
        /// 保持实际材料唯一性
        /// </summary>
        private void ScanedEnd()
        {
            try
            {
                //首先查询该材料是否在差异表中 若不在 查询该垛位系统材料
                //若材料号长度为0 说明该垛位无材料 不需寻找重复材料
                //若材料号长度不为0 要先查询该材料是否为其他垛位的实际材料，若是 需将其清除
                if (txtMatNo.Text.Trim().Length != 0)
                {
                    //首先寻找在差异表中 是否已有该材料 若有将实际材料清空
                    string[] list = dicMat.Keys.ToArray();
                    for (int i = 0; i < list.Length; i++)
                    {
                        MatterCls tmp = dicMat[list[i]];
                        if (tmp.matno == txtMatNo.Text)
                        {
                            tmp.matno = "";
                            dicMat[list[i]] = tmp;
                            break;
                        }
                    }
                }
                if (dicMat.Keys.Contains(txtSaddle.Text))
                {
                    //更新垛位信息
                    MatterCls tmpMat = dicMat[txtSaddle.Text];
                    tmpMat.status = "Scaned";
                    tmpMat.matno = txtMatNo.Text.Trim();
                    dicMat[txtSaddle.Text.Trim()] = tmpMat;
                }
                else
                {
                    MatterCls[] matlist = null;
                    MatterCls tmpMat = new MatterCls();
                    tmpMat.matno=txtMatNo.Text;
                    dtUnit unit=new dtUnit();
                    unit.UnitNo=txtSaddle.Text.Trim();
                    tmpMat.stcUnit=unit;
                    Prx.StockInfSearch(people, txtSaddle.Text.Trim(), out matlist, out nResult, Program.ctx);
                    if (matlist.Length != 0)
                    {
                        tmpMat.sqare1 = matlist[0].matno;
                    }
                    else
                    {
                        tmpMat.sqare1 = "";
                    }
                    dicMat[txtSaddle.Text.Trim()] = tmpMat;
                }
                ShowData(dicMat);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion

        #region 若垛位上无材料 点击该按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSaddle.Text.Trim().Length == 10)
                {
                    if (txtMatNo.Text.Trim().Length == 0 || txtMatNo.Text.Trim().Length > 10)
                    {
                        ScanedEnd();
                    }
                    else
                    {
                        txtresult.Text = "材料号错误";
                        txtresult.BackColor = Color.Red;
                    }
                }
                else
                {
                    txtresult.Text = "垛位号错误";
                    txtresult.BackColor = Color.Red;
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion
        #region 清空显示
        private void btnRedo_Click(object sender, EventArgs e)
        {
            try
            {
                CurRow = -1;
                table.Clear();
                dicMat.Clear();
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

        }
        #endregion

        #region 选中材料保持高亮
        private void dataGrid1_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                CurRow = dataGrid1.CurrentCell.RowNumber;

                SelectCurRow();
            }
        }
        private void SelectCurRow()
        {
            if (CurRow != -1)
            {

                dataGrid1.Select(CurRow);

                dataGrid1.CurrentCell = new DataGridCell(CurRow, 1);
            }
        }
        #endregion 
        #region 提交 
        /// <summary>
        /// 只提交扫描过的垛位 盘库方式DIFF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                List<MatterCls> sendlist = new List<MatterCls>();
                foreach (MatterCls mat in dicMat.Values)
                {
                    if (mat.status == "Scaned")
                    {
                        sendlist.Add(mat);
                    }
                }
                Prx.StockInfSumbit("DIFF", people, sendlist.ToArray(), out nResult, Program.ctx);
                if (nResult != -999)
                {
                    txtresult.Text = "提交成功";
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    txtresult.Text = "提交失败";
                    txtresult.BackColor = Color.Red;
                }
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, false);
                txtresult.Text = "访问超时";
                txtresult.BackColor = Color.Red;

            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion
        #region 删除选中库位
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurRow != -1)
                {
                    string stock = dataGrid1[CurRow, 1].ToString();
                    dicMat.Remove(stock);
                    ShowData(dicMat);
                    CurRow = -1;
                    SelectCurRow();
                    txtresult.Text = "删除成功";
                    txtresult.BackColor = Color.Green;
                }
                else
                {
                    txtresult.Text = "请选择库位";
                    txtresult.BackColor = Color.Red;
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