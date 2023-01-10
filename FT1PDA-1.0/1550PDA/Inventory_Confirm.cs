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
    public partial class Inventory_Confirm : Form
    {
        /// <summary>
        /// 当前选中行
        /// </summary>
        private DataTable table = new DataTable("table");
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();

        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="_Truck"></param>
        public PT.PTInterfacePrx Prx = null;


        /// <summary>
        /// 作业类型
        /// </summary>
        /// <param name="_people"></param>
        /// <param name="_Prx"></param>
        /// <param name="worktype"></param>
        private string id = "";
        private Dictionary<string, inventoryStock> list = new Dictionary<string, inventoryStock>();
        private Dictionary<string, LocalScanInfo> dicScanInfo = new Dictionary<string,LocalScanInfo>();

        public Inventory_Confirm(dtPTCommon _people, PTInterfacePrx _Prx, string worktype)
        {
            Prx = _Prx;
            people = _people;
            WorkType = worktype;
            InitializeComponent();
            this.Activated += new EventHandler(Inventory_Check_Activated);
            this.Closed += new EventHandler(Inventory_Check_Closed);
        }

        private void Inventory_Check_Load(object sender, EventArgs e)
        {
            InitDataGrid(table);
            btnSearch_Click(null,null);
            txtMatNo.Focus();
            
        }
        #region  表格初始化时 给表格赋值
        /// <summary>
        /// 表格初始化时 给表格赋值
        /// </summary>
        /// <param name="table">表格数据</param>
        private void InitDataGrid(DataTable table)
        {
            table.Columns.Add("选择", typeof(string));
            table.Columns.Add("库位", typeof(string));
            table.Columns.Add("材料", typeof(string));
            table.Columns.Add("初次材料", typeof(string));

            MappingTheTable();
        }
        #endregion
        #region 数据Table映射
        private void MappingTheTable()
        {
            dataGrid_notScan.DataSource = table;

            //dataGridTableStyle1.
            dataGridTableStyle1.MappingName = "table";
            dataGrid_notScan.RowHeadersVisible = false;

            DataGridTextBoxColumn theCol_Select = new DataGridTextBoxColumn();
            theCol_Select.HeaderText = "已核";
            theCol_Select.MappingName = "选择";
            theCol_Select.Width = 40;

            DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
            theCol_Stock.HeaderText = "库位";
            theCol_Stock.MappingName = "库位";
            theCol_Stock.Width = 65;

            DataGridTextBoxColumn theCol_Mat = new DataGridTextBoxColumn();
            theCol_Mat.HeaderText = "材料";
            theCol_Mat.MappingName = "材料";
            theCol_Mat.Width = 85;

            DataGridTextBoxColumn theCol_Mat_fir = new DataGridTextBoxColumn();
            theCol_Mat_fir.HeaderText = "初次材料";
            theCol_Mat_fir.MappingName = "初次材料";
            theCol_Mat_fir.Width = 85;

            dataGridTableStyle1.MappingName = "table";

            dataGridTableStyle1.GridColumnStyles.Add(theCol_Select);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Stock);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Mat);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Mat_fir);
            dataGrid_notScan.TableStyles.Add(dataGridTableStyle1);
        }
        #endregion

        private void ShowData()
        {
            try
            {
                table.Clear();
                Dictionary<string, inventoryStock> partdic = new Dictionary<string, inventoryStock>();
                string row = cbxRowNo.Text;

                // 刷新下拉列表
                RefreshComboxItems(checkList);

                // 显示选定下拉范围内的记录
                if (row=="全部"||row=="")
                {
                    for (int index = 0; index < checkList.Length; index++)
                    {
                        inventoryStock tmp = checkList[index];
                        partdic[tmp.unitno] = tmp;
                    }
                }
                else
                {
                    string selectrow = row.Substring(0, 6);
                    for (int index = 0; index < checkList.Length; index++)
                    {
                        inventoryStock tmp = checkList[index];
                        if (tmp.unitno.Contains(selectrow))
                        {
                            partdic[tmp.unitno] = tmp;
                        }
                    }
                }
                
                //首先显示当前库位
                foreach (inventoryStock tmp in partdic.Values)
                {
                    if (tmp.unitno == txtMatNo.Text)
                    {
                        DataRow newRow;
                        newRow = table.NewRow();
                        if (tmp.select == "select")
                        {
                            newRow["选择"] = "是";
                        }
                        else
                        {
                            newRow["选择"] = "否";
                        }
                        newRow["库位"] = tmp.unitno;
                        newRow["材料"] = tmp.MATNO;
                        newRow["初次材料"] = tmp.MATNOFIRST;
                        table.Rows.Add(newRow);
                    }
                }
                foreach (inventoryStock tmp in partdic.Values)
                {
                    if (tmp.unitno != txtMatNo.Text)
                    {
                        DataRow newRow;
                        newRow = table.NewRow();
                        if (tmp.select == "select")
                        {
                            newRow["选择"] = "是";
                        }
                        else
                        {
                            newRow["选择"] = "否";
                        }
                        newRow["库位"] = tmp.unitno;
                        newRow["材料"] = tmp.MATNO;
                        newRow["初次材料"] = tmp.MATNOFIRST;
                        table.Rows.Add(newRow);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private void RefreshComboxItems(inventoryStock[] checklist)
        {
            Dictionary<string, int> dictCheckedByRow = new Dictionary<string, int>();
            Dictionary<string, int> dictAllByRow = new Dictionary<string, int>();

            if (checklist == null)
                return;

            if (checklist.Length != 0)
            {
                for (int index = 0; index < checklist.Length; index++)
                {
                    inventoryStock tmp = checklist[index];
                    string row = tmp.unitno.Substring(0, 6);
                    int nCount = 0;

                    // 统计行内的复核总数
                    if (dictAllByRow.ContainsKey(row))
                        nCount = dictAllByRow[row];
                    nCount++;
                    dictAllByRow[row] = nCount;

                    // 确认库位是否已复核
                    if (list.ContainsKey(tmp.unitno))
                    {
                        tmp.select = list[tmp.unitno].select;
                        int nChecked = 0;

                        // 统计行内的已复核数
                        if (dictCheckedByRow.ContainsKey(row))
                            nChecked = dictCheckedByRow[row];
                        nChecked++;
                        dictCheckedByRow[row] = nChecked;
                    }
                }

                foreach (string rowNo in dictAllByRow.Keys)
                {
                    bool bAdded = false;
                    int nCheckdCnt = 0;

                    // 已核对总数
                    if (dictCheckedByRow.ContainsKey(rowNo))
                        nCheckdCnt = dictCheckedByRow[rowNo];

                    // 该行统计列表是否已添加
                    for (int index = 0; index < cbxRowNo.Items.Count; index++)
                    {
                        string itemText = cbxRowNo.Items[index].ToString();
                        if (itemText.Contains(rowNo))
                        {
                            // 已添加，更新文字
                            bAdded = true;
                            cbxRowNo.Items[index] = String.Format("{0} - 已核{1}/共{2}", rowNo, nCheckdCnt, dictAllByRow[rowNo]);
                        }
                    }

                    if (!bAdded)
                    {
                        // 未添加，新增下拉统计项
                        string tmp = String.Format("{0} - 已核{1}/共{2}", rowNo, nCheckdCnt, dictAllByRow[rowNo]);
                        cbxRowNo.Items.Add(tmp);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //cbxRowNo.Items.Clear();
                //cbxRowNo.Items.Add("全部");
                //table.Clear();
                //Prx.RecheckLIST(people.StoreID, out id, out checkList, Program.ctx);
                //if (checkList.Length != 0)
                //{
                //    txtresult.Text = "复核信息查询成功";
                //    txtresult.BackColor = Color.Green;
                //}
                //else
                {
                    txtresult.Text = "当前无复核信息";
                    txtresult.BackColor = Color.Green;
                }
                ShowData();
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
                txtresult.BackColor = Color.Red;
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            YesOrNoForm form = new YesOrNoForm();
            if (form.ShowDialog() != DialogResult.Yes)
                return;
            id = "";
            table.Clear();
            txtMatNo.Text = "";
            txtresult.BackColor = Color.White;
            txtresult.Text = "";
            list.Clear();

            dicScanInfo.Clear();
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (table.Rows.Count > 0)
                {
                    int CurRow = dataGrid_notScan.CurrentCell.RowNumber;
                    int CurCol = dataGrid_notScan.CurrentCell.ColumnNumber;

                    if (CurCol == 1)
                    {
                        txtMatNo.Text = dataGrid_notScan[CurRow, 1].ToString();
                        txtresult.Text = "库位:" + txtMatNo.Text + "选定成功";
                        txtresult.BackColor = Color.Green;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = ex.Message;
                txtresult.BackColor = Color.Red ;
            }
        }

        private void dataGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string stockNo = "";
                if (table.Rows.Count > 0)
                {
                    int CurRow = dataGrid_notScan.CurrentCell.RowNumber;
                    stockNo = dataGrid_notScan[CurRow, 1].ToString();
                }

                list.Remove(stockNo);
                dicScanInfo.Remove(stockNo);

                ShowData();
            }
            catch(System.Exception ex)
            {
                txtresult.Text = ex.Message;
                txtresult.BackColor = Color.Red;
            }
        }
        private void Inventory_Check_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }
        private void Inventory_Check_Closed(object sender, EventArgs e)
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
                if (tmp.Contains("Z"))
                {
                    //扫描到库位号
                    string unitno = tmp;
                    string stock = "";
                    string store = "";
                    string row = "";
                    string col = "";
                    string layer = "1";
                    //根据扫描到的长度补位
                    if (unitno.Length == 8)
                    {
                        //行列都需要补位
                        store = unitno.Substring(0, 3);
                        row = "0" + unitno.Substring(3, 2);
                        col = "0" + unitno.Substring(5, 2);
                        stock = store + row + col + layer;
                    }
                    if (unitno.Length == 9)
                    {
                        //行需要补位
                        store = unitno.Substring(0, 3);
                        row = unitno.Substring(3, 3);
                        col = "0" + unitno.Substring(6, 2);
                        stock = store + row + col + layer;
                    }
                    if (unitno.Length == 10)
                    {
                        //不需要补位
                        store = unitno.Substring(0, 3);
                        row = unitno.Substring(3, 3);
                        col = unitno.Substring(6, 3);
                        stock = store + row + col + layer;
                    }

                    // 扫描库位检查是否在复核清单中
                    inventoryStock tmpInvent = new inventoryStock();
                    if (!bStockInCheckList(stock, ref tmpInvent))
                    {
                        txtresult.Text = String.Format("扫描库位{0}, 不在复核清单内", stock);
                        txtresult.BackColor = Color.Red;
                        txtMatNo.Text = "";
                    }
                    else
                    {
                        txtMatNo.Text = stock;
                        txtresult.Text = "库位:" + stock + "扫描成功, 等待扫描材料号";
                        txtresult.BackColor = Color.Green;

                        ShowData();
                    }
                }
                else
                {
                    //扫描到材料号
                    if (txtMatNo.Text == "")
                    {
                        txtresult.Text = "请先扫描库位";
                        txtresult.BackColor = Color.Red;
                        return;
                    }
                    // 材料条码除多余字
                    if (tmp.Contains("S"))
                    {
                        tmp = tmp.Replace("S", "");
                    }
                    string matNo = tmp;

                    ScanedEnd(txtMatNo.Text, tmp);
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "材料扫描失败";
                txtresult.BackColor = Color.Red;
            }
        }
        #endregion

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                List<MatterCls> sendlist = new List<MatterCls>();
                foreach (inventoryStock tmp in list.Values)
                {
                    if (tmp.select == "select")
                    {
                        MatterCls newmat = new MatterCls();
                        newmat.matno = tmp.MATNO;
                        dtUnit u = new dtUnit();
                        u.UnitNo = tmp.unitno;
                        newmat.stcUnit = u;
                        sendlist.Add(newmat);
                    }
                }
                people.sqare1 = id;
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

        private void btnManu_Click(object sender, EventArgs e)
        {
            try
            {
                ScanedEnd(txtMatNo.Text, "");
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "材料号添加失败";
                txtresult.BackColor = Color.Red;
            }
        }

        private void cbxRowNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ShowData();
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private bool bStockInCheckList(string stock, ref inventoryStock check)
        {
            bool bResult = false;

            if (checkList == null)
                return bResult;

            // 检查扫描库位是否有效
            for (int index = 0; index < checkList.Length; index++)
            {
                if (checkList[index].unitno == stock)
                {
                    bResult = true;
                    check = checkList[index];

                    break;
                }
            }

            return bResult;
        }

        private void ScanedEnd(string stockNo, string matNo)
        {
            try
            {
                inventoryStock tmpstock = new inventoryStock();
                LocalScanInfo scanInfo = new LocalScanInfo(stockNo, matNo);

                if (!bStockInCheckList(stockNo, ref tmpstock))
                {
                    txtresult.Text = String.Format("扫描库位{0}, 不在复核清单内", stockNo);
                    txtresult.BackColor = Color.Red;
                    return;
                }

                txtresult.Text = String.Format("复核记录添加成功", stockNo);
                txtresult.BackColor = Color.Green;

                // 已核清单增加记录
                tmpstock.MATNO = matNo;
                tmpstock.select = "select";
                list[stockNo] = tmpstock;

                // 已核扫描记录
                dicScanInfo[stockNo] = scanInfo;

                // 刷新列表
                ShowData();

                txtMatNo.Text = "";
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "材料号添加失败";
                txtresult.BackColor = Color.Red;
            }
        }        
    }
}