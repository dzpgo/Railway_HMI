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

    public partial class Inventory_Lock : Form
    {
        private string id = "";
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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("PDA");
        private List<string> listStockSubmitted = new List<string>();

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
        public Inventory_Lock(dtPTCommon _people, PTInterfacePrx _Prx, string worktype)
        {
            Prx = _Prx;
            people = _people;
            WorkType = worktype;
            InitializeComponent();
            if (WorkType != "Empty")
            {
                this.Text = "库位禁用";
            }
        }
        #region 表格初始化
        private void Inventory_Check_Lock(object sender, EventArgs e)
        {
           
            InitDataGrid(table);

            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
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

        #region 更新字典
        /// <summary>
        /// 更新字典
        /// </summary>
        private void ScanedEnd(string stock, string matNo)
        {
            try
            {
                if (dicScaned.ContainsKey(stock))
                {
                    if (dicScaned[stock].MatNo == matNo)
                    {
                        txtresult.Text = "该库位已扫描过";
                        txtresult.BackColor = Color.Red;
                    }
                }
                else
                {
                    LocalScanInfo scanInfo = new LocalScanInfo(stock, matNo);
                    dicScaned[stock] = scanInfo;

                    txtresult.Text = stock + "添加成功";
                    txtresult.BackColor = SystemColors.Window;
                    //垛位文本框光标指于最后
                    txtSaddle.Text = "";
                    txtMatNo.Text = "";
                    txtSaddle.Focus();
                    label_RowCnt.Text = dicScaned.Keys.Count.ToString();

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
                YesOrNoForm yesForm = new YesOrNoForm("未提交扫描,均将清空!");
                if (yesForm.ShowDialog() == DialogResult.No)
                    return;

                CurRow = -1;
                table.Clear();
                dicScaned.Clear();
                txtSaddle.Text = "";
                txtresult.Text = "";
                txtresult.BackColor = SystemColors.Window;
                CurScanCol = "";
                id = "";
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

                string tmp = e.Text.Trim().ToUpper();
                string stockno;

                // 首先根据条码长度，估算是否是库位
                if (tmp.Length < 10)
                {
                    if (BarcodeFormater.parseStockBarCode(tmp, out stockno, txtresult))
                    {
                        txtSaddle.Text = tmp;
                        txtMatNo.Focus();
                        return;
                    }
                }

                // 不是库位，再判断是否是钢卷条码
                if (txtMatNo.Focused)
                {
                    if (tmp.Contains("S"))
                    {
                        tmp = tmp.Replace("S", "");
                    }
                    txtMatNo.Text = tmp;
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
                // 获取库图接口
                bool bSumitFailed = false;
               
                CLTS.YardMapFactoryPrx yardMapDefaultPrx = CLTS.YardMapFactoryPrxHelper.uncheckedCast(Program.g_comm.stringToProxy("YardMapFactory@App_YardMap.DefaultAdapter"));
                CLTS.YardMapFactoryPrx yardMapZ51Prx = CLTS.YardMapFactoryPrxHelper.uncheckedCast(Program.g_comm.stringToProxy("YardMapFactory@App_YardMap_Z51.DefaultAdapter"));
                CLTS.YardMapFactoryPrx yardMapZ52Prx = CLTS.YardMapFactoryPrxHelper.uncheckedCast(Program.g_comm.stringToProxy("YardMapFactory@App_YardMap_Z52.DefaultAdapter"));
                CLTS.YardMapFactoryPrx yardMapZ53Prx = CLTS.YardMapFactoryPrxHelper.uncheckedCast(Program.g_comm.stringToProxy("YardMapFactory@App_YardMap_Z53.DefaultAdapter"));
                listStockSubmitted.Clear();
                
                foreach (string stock in dicScaned.Keys)
                {
                    try
                    {
                        CLTS.StockPrx stockPrx = null;
                        string strYardNo = "";

                        // 读取库区代码（库位前3位）
                        if (stock.Length >= 3)
                            strYardNo = stock.Substring(0, 3);

                        if (strYardNo == "Z51")
                            stockPrx = yardMapZ51Prx.getStock(stock);
                        else if (strYardNo == "Z52")
                            stockPrx = yardMapZ52Prx.getStock(stock);
                        else if (strYardNo == "Z53")
                            stockPrx = yardMapZ53Prx.getStock(stock);
                        else
                            stockPrx = yardMapDefaultPrx.getStock(stock);

                        // 库位封锁
                        stockPrx.setChecking();

                        listStockSubmitted.Add(stock);
                    }
                    catch (System.Exception ex)
                    {                        
                        bSumitFailed = true;
                        Program.LogException(ex, true);
                    }
                }

                if (bSumitFailed)
                {
                    txtresult.Text = String.Format("提交成功{0}件, 失败{1}件", listStockSubmitted.Count, dicScaned.Count - listStockSubmitted.Count);
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    txtresult.Text = "提交失败";
                    txtresult.Text = String.Format("提交成功{0}件", dicScaned.Count);
                    txtresult.BackColor = Color.Green;
                }

                // 删除已提交成功的库位
                foreach (string strSubmitStock in listStockSubmitted)
                {
                    dicScaned.Remove(strSubmitStock);
                }
                // 显示尚未提交成功的库位
                ShowData(dicScaned);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "提交失败";
                txtresult.BackColor = Color.Red;
            }
        }

        private void txtMatNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMatNo.Text.Length > 10)
                {
                    string stock;
                    if (BarcodeFormater.parseStockBarCode(txtSaddle.Text.ToUpper(), out stock, txtresult))
                    {
                        ScanedEnd(stock, txtMatNo.Text);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private void btn_EmptyMatNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSaddle.Text.Length > 7)
                {
                    string stock = "";
                    txtMatNo.Text = "";

                    if (BarcodeFormater.parseStockBarCode(txtSaddle.Text.ToUpper(), out stock, txtresult))
                    {
                        ScanedEnd(stock, "");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private void Inventory_Lock_Closed(object sender, EventArgs e)
        {
            ScannerHelper.ScannerDestroy();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dicScaned.Count > 0)
            {
                YesOrNoForm yesForm = new YesOrNoForm("未提交扫描,均将清空!");
                if (yesForm.ShowDialog() == DialogResult.No)
                    return;
            }

            Close();
        }
    }
    
}