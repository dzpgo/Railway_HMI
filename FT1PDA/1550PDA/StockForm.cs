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
    public partial class StockForm : Form
    {
        private string id = "";
        private string area = "";
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
        /// 材料字典 显示依次字典为准
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
        private string cID;
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();

        #region 构造函数
        public StockForm(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            Prx = _Prx;
            people = _people;
            InitializeComponent();
            this.Activated += new EventHandler(StockForm_Activated);
            this.Closed += new EventHandler(StockForm_Closed);
        }
        #endregion
        #region 初始化表格
        private void StockForm_Load(object sender, EventArgs e)
        {
            InitDataGrid(table);
            //默认先扫描库位
            txtSaddle.Focus();
        }
        #endregion
        #region  表格初始化时 给表格赋值
        /// <summary>
        /// 表格初始化时 给表格赋值
        /// </summary>
        /// <param name="table">表格数据</param>
        private void InitDataGrid(DataTable table)
        {
            table.Columns.Add("库位", typeof(string));
            table.Columns.Add("材料号", typeof(string));

            MappingTheTable();
        }
        #endregion
        #region 数据Table映射
        private void MappingTheTable()
        {
            dg.DataSource = table;

            //dataGridTableStyle1.
            dataGridTableStyle1.MappingName = "table";
            dg.RowHeadersVisible = false;

            DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
            theCol_Stock.HeaderText = "库位";
            theCol_Stock.MappingName = "库位";
            theCol_Stock.Width = 113;

            DataGridTextBoxColumn theCol_MaterialNo = new DataGridTextBoxColumn();
            theCol_MaterialNo.HeaderText = "材料号";
            theCol_MaterialNo.MappingName = "材料号";
            theCol_MaterialNo.Width = 113;

            dataGridTableStyle1.MappingName = "table";
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Stock);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_MaterialNo);

            dg.TableStyles.Add(dataGridTableStyle1);
        }
        #endregion
        private void StockForm_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }
        private void StockForm_Closed(object sender, EventArgs e)
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

                string tmp = e.Text.Trim().ToUpper();
                if (tmp.Contains('-'))
                {
                    tmp = tmp.Replace("-", "");
                }
                string stockno;

                // 首先根据条码长度，估算是否是库位
                if (tmp.Length < 10)
                {
                    if (changestockformat(tmp.ToUpper(), out stockno))
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

        #region 选中材料保持高亮
        private void dg_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                CurRow = dg.CurrentCell.RowNumber;

                SelectCurRow();
            }
        }
        private void SelectCurRow()
        {
            if (CurRow != -1)
            {

                dg.Select(CurRow);

                dg.CurrentCell = new DataGridCell(CurRow, 1);
            }
        }
        #endregion


        #region  插入数据到表格
        private void ShowData(Dictionary<string, LocalScanInfo> dic)
        {
            try
            {
                table.Clear();
                //foreach (string stock in dic.Keys)
                //{
                //    if (stock == CurScanCol)
                //    {
                //        DataRow newRow;
                //        newRow = table.NewRow();
                //        newRow["库位"] = stock;
                //        newRow["材料号"] = dic[stock];
                //        table.Rows.Add(newRow);
                //    }
                //}
                //foreach (string stock in dic.Keys)
                //{
                //    if (stock != CurScanCol)
                //    {
                //        DataRow newRow;
                //        newRow = table.NewRow();
                //        newRow["库位"] = stock;
                //        newRow["材料号"] = dic[stock];
                //        table.Rows.Add(newRow);
                //    }
                //}
                foreach (string stock in dic.Keys)
                {
                    LocalScanInfo scanInfo = dic[stock];
                    DataRow newRow = table.NewRow();

                    newRow["库位"] = stock;
                    newRow["材料号"] = scanInfo.MatNo;
                    table.Rows.Add(newRow);
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion
        #region 盘库开始
        private void btnRet_Click(object sender, EventArgs e)
        {
            try
            {
                btnRedo_Click(null, null);
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
        #endregion
        #region 选中材料删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            try
            {
                YesOrNoForm form = new YesOrNoForm();
                if (form.ShowDialog() != DialogResult.Yes)
                    return;
                if (CurRow != -1)
                {
                    string stock = dg[CurRow, 0].ToString();
                    dicScaned.Remove(stock);
                    ShowData(dicScaned);
                    CurRow = -1;
                    txtMatNum.Text = dicScaned.Keys.Count.ToString();
                    txtSaddle.Focus();

                    //SelectCurRow();
                }
                else
                {
                    txtresult.Text = "请选中材料";
                    txtresult.BackColor = Color.Red;
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion
        #region 提交盘库信息
        /// <summary>
        /// 提交盘库信息 按整列提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                List<MatterCls> list = new List<MatterCls>();
                foreach (string stock in dicScaned.Keys)
                {
                    LocalScanInfo scanInfo = dicScaned[stock];
                    MatterCls mat = new MatterCls();
                    dtUnit u = new dtUnit();
                    u.UnitNo = stock;
                    mat.matno = scanInfo.MatNo;
                    mat.stcUnit = u;
                    mat.sqare2 = scanInfo.ScanTime;
                    list.Add(mat);
                }
                Prx.StockInfSumbit("ALL", people, list.ToArray(), out nResult, Program.ctx);
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

        #region 扫描或输入库位号/材料号
        private void txtMatNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMatNo.Text.Length > 10)
                {
                    string stock;
                    if (changestockformat(txtSaddle.Text.ToUpper(), out stock))
                    {
                        string strMat = txtSaddle.Text.ToUpper();
                        string strSaddle = stock;
                        ScanedEnd(stock, txtMatNo.Text);
                        ////新增 库位直接变黑
                        //string strID = people.Operator;
                        //string strDevice = people.PTID;
                        //int type=0;
                        //bool isSend= MatInOutSendToL3(strMat, strSaddle, type, strID, strDevice);
                        //if (isSend)
                        //{
                        //    //发送成功
                        //    txtresult.Text =string.Format("添加、发送成功");
                        //}
                        //else
                        //{
                        //    //发送失败
                        //    txtresult.Text = string.Format("只添加成功");
                        //    txtresult.BackColor = Color.Orange;
                        //}
                        ////txtSaddle.Focus();
                        ////
                    }
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        /// <summary>
        /// 保证材料号与库位的唯一性
        /// </summary>
        private void ScanedEnd(string stock, string matNo)
        {
            try
            {
                LocalScanInfo scanInfo = new LocalScanInfo(stock, matNo);
                dicScaned[stock] = scanInfo;
                txtresult.Text = "添加成功";
                txtresult.BackColor = Color.Green;
                //垛位文本框光标指于最后
                txtSaddle.Text = "";
                txtMatNo.Text = "";
                txtSaddle.Focus();
                txtMatNum.Text = dicScaned.Keys.Count.ToString();
                ShowData(dicScaned);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        /// <summary>
        /// L2库位即时变黑同时通知L3
        /// </summary>
        /// <param name="strMatNO"></param>
        /// <param name="strStockNO"></param>
        /// <param name="isInOper"></param>
        /// <param name="strID"></param>
        /// <param name="strDevice"></param>
        private bool MatInOutSendToL3(string strMatNO, string strStockNO, int isInOper, string strID, string strDevice)
        {
            bool ret = false;
            try
            {
                strMatNO = strStockNO = string.Empty;
                if (strMatNO.Trim().Length == 0)
                {
                    //strMatNO = strStockNO = string.Empty;
                    return ret;
                }                
                if (strMatNO.Trim().Length < 10)
                {
                    MessageBox.Show("材料号不正确");
                    //strMatNO = strStockNO = string.Empty;
                    return ret;
                }
                else if (isInOper == 0 && strStockNO.Trim().Length < 8 && strStockNO.Trim().Length != 0)
                {
                    MessageBox.Show("入库作业请输入正确库区号");
                    //strMatNO = strStockNO = string.Empty;
                    return ret;
                }
                else if (isInOper == 3 && strStockNO.Trim().Length < 8 && strStockNO.Trim().Length != 0)
                {
                    MessageBox.Show("盘库作业请输入正确库区号");
                    //strMatNO = strStockNO = string.Empty;
                    return ret;
                }
                else
                {
                    string strMAT = strMatNO.Trim().ToUpper();
                    string strStock = strStockNO.Trim().ToUpper();
                    string stock = "";
                    if (strStock.Contains("Z"))
                    {
                        stock = BarcodeFormater.JudgeStockFormat1550(strStock);
                    }
                    else if (strStock.Contains("FT"))
                    {
                        stock = BarcodeFormater.JudgeStockFormatFT11(strStock);
                    }                   
                    if (isInOper == 0 || isInOper == 3)
                    {
                        if (stock.Length == 0)
                        {
                            return ret;
                        }
                    }
                    string tagValue = "";
                    string cRetMessage = "";

                    if (isInOper == 0)
                    {
                        people.sqare1 = stock; //??
                        tagValue = strMAT + "|" + stock + "|" + strDevice + "|" + strID;
                    }
                    else if (isInOper == 2)
                    {
                        tagValue = strMAT + "|" + strDevice + "|" + strID + "|" + "small" + "|" + "coil";
                    }
                    else if (isInOper == 1)
                    {
                        tagValue = strMAT + "|" + strDevice + "|" + strID;
                    }
                    else if (isInOper == 3)
                    {
                        people.sqare1 = stock; //??
                        tagValue = strMAT + "|" + stock + "|" + strDevice + "|" + strID;
                    }
                    Prx.MatInOut(isInOper.ToString(), tagValue, out cRetMessage);
                    if (cRetMessage == "fail")
                    {
                        //txtresult.Text = "发送失败";
                        //txtresult.BackColor = Color.Red;
                    }
                    else
                    {
                        ret=true;
                        //txtresult.Text = "发送成功";
                    }
                    return ret;
                }
            }
            catch (System.Exception ex)
            {
                //strMatNO = strStockNO = string.Empty;
                MessageBox.Show(ex.Message);
                return ret;
            }
            //finally
            //{
            //    //txtMAT.Focus();
            //}
        }
        #endregion

        #region 重置
        private void btnRedo_Click(object sender, EventArgs e)
        {
            YesOrNoForm form = new YesOrNoForm();
            if (form.ShowDialog() != DialogResult.Yes)
                return;
            table.Clear();
            dicScaned.Clear();
            id = "";
            area = "";
            txtSaddle.Text = "";
            txtMatNum.Text = "";
            txtMatNo.Text = "";
            txtresult.Text = "";
            txtresult.BackColor = Color.White;
            txtSaddle.Focus();
            CurRow = -1;
        }
        #endregion

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSaddle.Text.Length > 7)
                {
                    string stock = "";
                    txtMatNo.Text = "";

                    if (changestockformat(txtSaddle.Text.ToUpper(), out stock))
                        ScanedEnd(stock, "");
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            Inventory_Check newform = new Inventory_Check(people, Prx, "CHECK");
            newform.ShowDialog();
        }

        private bool changestockformat(string unitno, out string stock)
        {
            bool bResult = false;
            stock = "";

            try
            {
                string store = "";
                string row = "";
                string col = "";
                //if (unitno.Contains('Z'))
                //{
                //    stock = BarcodeFormater.JudgeStockFormat1550(unitno, out store, out row, out col);
                //}
                //else if (unitno.Contains("FT"))
                //{
                //    stock = BarcodeFormater.JudgeStockFormatFT11(unitno, out store, out row, out col);
                //}

                if (unitno.Contains('Z'))
                {
                    stock = BarcodeFormater.JudgeStockFormat1550(unitno, out store, out row, out col);
                    if (!area.Contains(row) || !area.Contains(stock))
                    {
                        txtresult.Text = String.Format("识别库位{0}不属于扫描范围", stock);
                        txtresult.BackColor = Color.Red;
                    }
                    else
                    {
                        bResult = true;
                        txtresult.Text = "识别扫描库位";
                        txtresult.BackColor = Color.Green;
                    }
                }
                else if (unitno.Contains("FT"))
                {
                    stock = BarcodeFormater.JudgeStockFormatFT11(unitno, out store, out row, out col);
                    string strStore = string.Format("{0}-{1}-{2}", store.Substring(0, 3), store.Substring(3, 1), store.Substring(4, 1));
                    if (!area.Contains(row) || !area.Contains(strStore))
                    {
                        txtresult.Text = String.Format("识别库位{0}不属于扫描范围", strStore);
                        txtresult.BackColor = Color.Red;
                        stock = "";
                    }
                    else
                    {
                        bResult = true;
                        txtresult.Text = "识别扫描库位";
                        txtresult.BackColor = Color.Green;
                    }
                }

            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

            return bResult;
        }
    }
}