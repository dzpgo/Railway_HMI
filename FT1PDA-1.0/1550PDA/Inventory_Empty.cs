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

    public partial class Inventory_Empty : Form
    {
        private string id = "";
        private string area = "";
        /// <summary>
        /// 当前扫描的行
        /// </summary>
        private string CurScanCol = "";
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
        private Dictionary<string, LocalScanInfo> dicScaned = new Dictionary<string, LocalScanInfo>();
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
        /// <summary>
        /// 作业类型
        /// </summary>
        /// <param name="_people"></param>
        /// <param name="_Prx"></param>
        /// <param name="worktype"></param>
        private string WorkType = "";
        public Inventory_Empty(dtPTCommon _people, PTInterfacePrx _Prx,string worktype)
        {
            Prx = _Prx;
            people = _people;
            WorkType = worktype;
            InitializeComponent();
            if (WorkType != "Empty")
            {
                this.Text = "库位禁用";
            }
            this.Activated += new EventHandler(Inventory_Empty_Activated);
            this.Closed += new EventHandler(Inventory_Empty_Closed);
        }
        #region 表格初始化
        private void Inventory_Empty_Load(object sender, EventArgs e)
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
            table.Columns.Add("序号", typeof(string));
            table.Columns.Add("库位", typeof(string));

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

            DataGridTextBoxColumn theCol_ID = new DataGridTextBoxColumn();
            theCol_ID.HeaderText = "序号";
            theCol_ID.MappingName = "序号";
            theCol_ID.Width = 20;

            DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
            theCol_Stock.HeaderText = "库位";
            theCol_Stock.MappingName = "库位";
            theCol_Stock.Width = 205;

            dataGridTableStyle1.MappingName = "table";

            dataGridTableStyle1.GridColumnStyles.Add(theCol_ID);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Stock);

            dataGrid1.TableStyles.Add(dataGridTableStyle1);
        }
        #endregion

        #region 扫描或输入库位
        /// <summary>
        /// 扫描或输入库位号扫描完成两文本框循环获得焦点
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
                if (txtSaddle.Text.Length > 7)
                {
                    ScanedEnd();
                    txtSaddle.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion

        #region 更新字典
        /// <summary>
        /// 更新字典
        /// </summary>
        private void ScanedEnd()
        {
            try
            {
                string unitno = txtSaddle.Text.Trim().ToUpper();
                if (unitno.Length < 8 && unitno.Length!=0)
                {
                    txtresult.Text = "扫描数据错误";
                    txtresult.BackColor = Color.Red;
                    return;
                }
                string stock="";
                string store= "";
                string row = "";
                string col = "";
                //string layer = "1";
                if (unitno.Contains('Z'))
                {
                    stock = BarcodeFormater.JudgeStockFormat1550(unitno, out store, out row, out col);
                }
                else if (unitno.Contains("FT"))
                {
                    stock = BarcodeFormater.JudgeStockFormatFT11(unitno, out store, out row, out col);
                }

                ////根据扫描到的长度补位
                //if (unitno.Length == 8)
                //{
                //    //行列都需要补位
                //    store = unitno.Substring(0, 3);
                //    row = "0" + unitno.Substring(3, 2);
                //    col = "0" + unitno.Substring(5, 2);
                //    stock = store + row + col + layer;
                //}
                //if (unitno.Length == 9)
                //{
                //    //行需要补位
                //    store = unitno.Substring(0, 3);
                //    row = unitno.Substring(3, 3);
                //    col = "0" + unitno.Substring(6, 2);
                //    stock = store + row + col + layer;
                //}
                //if (unitno.Length == 10)
                //{
                //    //不需要补位
                //    store = unitno.Substring(0, 3);
                //    row = unitno.Substring(3, 3);
                //    col = unitno.Substring(6, 3);
                //    stock = store + row + col + layer;
                //}
                if (stock == "")
                {
                    return;
                }
                if (unitno.Contains('Z'))
                {
                    if (!area.Contains(row) || !area.Contains(stock))
                    {
                        txtresult.Text = String.Format("识别库位{0}不属于扫描范围", stock);
                        txtresult.BackColor = Color.Red;
                        return;
                    } 
                }
                else if (unitno.Contains("FT"))
                {
                    string strStore = string.Format("{0}-{1}-{2}", store.Substring(0, 3), store.Substring(3, 1), store.Substring(4, 1));
                    if (!area.Contains(row) || !area.Contains(strStore))
                    {
                        txtresult.Text = String.Format("识别库位{0}不属于扫描范围", strStore);
                        txtresult.BackColor = Color.Red;
                        return;
                    }   
                }

                if (dicScaned.ContainsKey(stock))
                {
                    txtresult.Text = "该垛位已扫描过";
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    LocalScanInfo scanInfo = new LocalScanInfo(stock, "");
                    dicScaned.Add(stock, scanInfo);
                    ShowData(dicScaned);
                }
               
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion
        #region  插入数据到表格
        private void ShowData(Dictionary<string, LocalScanInfo> dic)
        {
            try
            {
                table.Clear();
                int index = 0;
                foreach (String stockNo in dic.Keys)
                {
                    DataRow newRow;
                    index++;
                    newRow = table.NewRow();
                    newRow["序号"] = index.ToString();
                    newRow["库位"] = stockNo;
                    table.Rows.Add(newRow);
                }

                // 显示行计数
                label_RowCnt.Text = table.Rows.Count + "件";
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSaddle.Text.Length == 0)
                {
                    txtresult.Text = "请输入库位号";
                    return;
                }
                ScanedEnd();
                txtSaddle.Text = "";
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurRow != -1)
                {
                    string stock = dataGrid1[CurRow, 1].ToString();
                    dicScaned.Remove(stock);
                    ShowData(dicScaned);
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

        private void btnRedo_Click(object sender, EventArgs e)
        {
            try
            {
                CurRow = -1;
                table.Clear();
                dicScaned.Clear();
                txtSaddle.Text = "";
                txtresult.Text = "";
                txtresult.BackColor=Color.White;
                CurScanCol = "";
                id = "";
                area = "";
                label_RowCnt.Text = "0 件";
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Inventory_Empty_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }
        private void Inventory_Empty_Closed(object sender, EventArgs e)
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
                if (tmp.Contains('-'))
                {
                    tmp = tmp.Replace("-","");
                }
                if (tmp.Length == 8 || tmp.Length == 9)
                {
                    txtSaddle.Text = tmp;
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

        private void btnSummit_Click(object sender, EventArgs e)
        {
            try
            {
                List<MatterCls> sendlist = new List<MatterCls>();
                foreach (string stock in dicScaned.Keys)
                {
                    LocalScanInfo scanInfo = dicScaned[stock];
                    MatterCls newmat = new MatterCls();
                    dtUnit u = new dtUnit();
                    u.UnitNo = stock;
                    newmat.stcUnit = u;
                    newmat.sqare2 = scanInfo.ScanTime; // 扫描时间
                    sendlist.Add(newmat);
                }

                Prx.StockInfSumbit(WorkType, people, sendlist.ToArray(), out nResult, Program.ctx);
                if (nResult == 100)
                {
                    txtresult.Text = "提交成功";
                    txtresult.BackColor = Color.Green;
                }
                else
                {
                    if (nResult == -999999)
                    {
                        txtresult.Text = "盘库单已关闭";
                        txtresult.BackColor = Color.Red;
                    }
                    else
                    {
                        txtresult.Text = "提交失败";
                        txtresult.BackColor = Color.Red;
                    }
                }
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "访问超时";
                txtresult.BackColor = Color.Green;
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = ex.Message;
                txtresult.BackColor = Color.Green;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try 
            {
                btnRedo_Click(null,null);
                Prx.OutInventoryInfo(people.StoreID, out id, out area, Program.ctx);
                txtresult.Text = "盘库区域：" + area;
                people.sqare1 = id;
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "访问超时";
                txtresult.BackColor = Color.Green;
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = ex.Message;
                txtresult.BackColor = Color.Green;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Inventory_Check newform = new Inventory_Check(people, Prx, "CHECK");
            newform.ShowDialog();
        }
    }
    
}