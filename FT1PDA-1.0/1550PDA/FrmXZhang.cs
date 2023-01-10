using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PsionTeklogix.Keyboard;
using PsionTeklogix;
using PT;


namespace _1550PDA
{
    public partial class FrmXZhang : Form
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="_Truck"></param>
        public PT.PTInterfacePrx Prx = null;

        ZJ.structMat[] lstMat = null;
        //ZJ.FTInterfaceFatoryPrx ftPtx =null;

        /// <summary>
        /// 材料字典 显示依次字典为准
        /// </summary>
        /// <param name="_Truck"></param>
        private Dictionary<string, LocalScanInfo> dicScaned = new Dictionary<string, LocalScanInfo>();

        /// <summary>
        /// table相关
        /// </summary>
        /// <param name="_Truck"></param>
        private DataTable table = new DataTable("table");
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();

        private string trainLineNO = "";

        public string TrainLineNO
        {
            get { return trainLineNO; }
            set { trainLineNO = value; }
        }

        private string trianCaseNO = "";

        public string TrianCaseNO
        {
            get { return trianCaseNO; }
            set { trianCaseNO = value; }
        }
        /// <summary>
        /// 当前选中材料
        /// </summary>
        private int CurRow = -1;
        public FrmXZhang()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmXZhang_Load);
        }
        public FrmXZhang(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmXZhang_Load);

            Prx = _Prx;
            people = _people;
        }

        void FrmXZhang_Load(object sender, EventArgs e)
        {           
            this.Closed += new EventHandler(FrmXZhang_Closed);
            InitDataGrid(table);
            txtMatNo.Focus();
        }

        void FrmXZhang_Closed(object sender, EventArgs e)
        {
            ScannerHelper.ScannerDestroy(); ;
        }

        private void FrmXZhang_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }
        /// <summary>
        /// 表格初始化时 给表格赋值
        /// </summary>
        /// <param name="table">表格数据</param>
        private void InitDataGrid(DataTable table)
        {
            table.Columns.Add("序号", typeof(int));
            table.Columns.Add("材料号", typeof(string));
            //table.Columns.Add("材料位置", typeof(string));
            MappingTheTable();
        }
        #region 数据Table映射
        private void MappingTheTable()
        {
            dg.DataSource = table;

            //dataGridTableStyle1.
            dataGridTableStyle1.MappingName = "table";

            DataGridTextBoxColumn theCol_Index = new DataGridTextBoxColumn();
            theCol_Index.HeaderText = "序号";
            theCol_Index.MappingName = "序号";
            theCol_Index.Width = 40;

            DataGridTextBoxColumn theCol_MaterialNo = new DataGridTextBoxColumn();
            theCol_MaterialNo.HeaderText = "材料号";
            theCol_MaterialNo.MappingName = "材料号";
            theCol_MaterialNo.Width = 130;

            //DataGridTextBoxColumn theCol_Stock = new DataGridTextBoxColumn();
            //theCol_Stock.HeaderText = "材料位置";
            //theCol_Stock.MappingName = "材料位置";
            //theCol_Stock.Width = 100;



            //dataGridTableStyle1.MappingName = "table";
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Index);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_MaterialNo);
            //dataGridTableStyle1.GridColumnStyles.Add(theCol_Stock);

            dg.TableStyles.Add(dataGridTableStyle1);
            dg.RowHeadersVisible = false;
        }
        #endregion
        private delegate void OnScanCompleteDelegate(object sender, PsionTeklogix.Barcode.ScanCompleteEventArgs e);

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

                //钢卷条码
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
            }
        }
        #endregion

        #region 接口封装
        ZJ.FTInterfaceFatoryPrx ftPrx = null;

        public ZJ.FTInterfaceFatoryPrx FtPrx
        {
            get {  
                if (ftPrx ==null)
                { ftPrx = ClsZJFTPtrNet.ZJPtrCommunicator.Instance("PT").geFTInterfaceFatory(); txtresult.Text = "\r\n接口初始化成功"; }
            return ftPrx; 
            }
        }
        #endregion

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (trainLineNO == "" || trianCaseNO == "")
                {
                    txtresult.Text = "请单击开始再提交！";
                    txtresult.BackColor =Color.Red; 
                    return;
                }
                ZJ.dtPTCommon PTcom = new ZJ.dtPTCommon(people.StoreID, people.PTID, people.Shift, people.Crew, people.Operator, people.TimeOper
                    , people.Privilege, people.sqare1, people.sqare2);
                
                //FtPrx.getCurrentOutMats("FT1", out lstMat);
                //if (lstMat !=null)
                //{
                //    for (int i=0;i<lstMat.Length ;i++)
                //    {
                //       txtresult.Text+="材料号："+ lstMat[i].matNO;
                //       txtresult.Text += "位置：" + lstMat[i].position;
                //       txtresult.Text += "\r\n";
                //    }
                //}

                List<ZJ.structMat> lstScanMats = new List<ZJ.structMat>();
                foreach (string stock in dicScaned.Keys)
                {
                    ZJ.structMat mat = new ZJ.structMat(dicScaned[stock].MatNo, stock, "", "");
                    lstScanMats.Add(mat);
                }

                int ret = FtPrx.commitMats(PTcom, new ZJ.structXZhang(trainLineNO, lstScanMats.ToArray(), TrianCaseNO, "", ""));
                if (ret == -1)
                {
                    txtresult.Text = "提交失败！";
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    txtresult.Text = "提交成功！";
                    txtresult.BackColor = Color.Green;
                }
            }
            catch (CLTS.CLTSException ex)
            {
                MessageBox.Show(ex.reason);
            }
            catch (Exception ex)
            {
                // 取得异常信息
                string errorMessage = ex.Message;
                System.Exception parentException = ex.InnerException;
                while (parentException != null)
                {
                    errorMessage += parentException.Message.ToString() + "\n";
                    parentException = parentException.InnerException;
                }
                MessageBox.Show(errorMessage);
            }
        }

        #region  插入数据到表格
        private void ShowData(Dictionary<string, LocalScanInfo> dic)
        {
            try
            {
                table.Clear();  
                int index =1;
                foreach (string stock in dic.Keys)
                {
                    LocalScanInfo scanInfo = dic[stock];
                    DataRow newRow = table.NewRow();
                    newRow["序号"] = index.ToString();
                    newRow["材料号"] = scanInfo.MatNo;
                    //newRow["材料位置"] = stock;

                    table.Rows.Add(newRow);
                    index++;
                }

            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion

        private void txtMatNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(dicScaned.Keys.Count>0)
                {
                    foreach (var item in dicScaned)
                    {
                        if (item.Value.MatNo == txtMatNo.Text)
                        {
                            txtMatNo.Text = "";
                            txtresult.Text = "钢卷已添加：" + item.Value.MatNo;
                            txtresult.BackColor = Color.Red;
                            return;
                        }
                    }
                }
                if (txtMatNo.Text.Length > 10)
                {
                    int temp = dicScaned.Keys.Count;
                    ScanedEnd(temp.ToString(), txtMatNo.Text);
                    txtresult.Text = "新增：" + txtMatNo.Text;
                    txtresult.BackColor = Color.Green;

                    txtMatNo.Text = "";
                }
                else
                {
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private void ScanedEnd(string stock, string matNo)
        {
            try
            {
                LocalScanInfo scanInfo = new LocalScanInfo(stock, matNo);
                dicScaned[stock] = scanInfo;

                ShowData(dicScaned);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            subFrmXZ frm = new subFrmXZ();
            frm.ShowDialog();
            if ( frm.TrainLineNO!="" && frm.TrainCaseNO !="")
            {
                if ( TrianCaseNO !="")
                {
                    YesOrNoForm form = new YesOrNoForm("清空扫描钢卷");
                    if (form.ShowDialog() == DialogResult.Yes)
                    {
                        table.Clear();
                        dicScaned.Clear();
                        txtMatNo.Text = "";
                        txtMatNo.Focus();
                    }
                }

                TrainLineNO = frm.TrainLineNO;
                TrianCaseNO = frm.TrainCaseNO;
                txtresult.Text = "请开始扫描钢卷,当前车号: " + TrianCaseNO;
                txtresult.BackColor = Color.Green;

                
            }
            else
            {
                txtresult.Text = "开始取消！";
                txtresult.BackColor = Color.White;
            }
            this.Text = TrianCaseNO == "" ? "装车销账" : "装车销账-" + TrianCaseNO;

        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            //DateTime current = DateTime.Now;
            try
            {
                YesOrNoForm form = new YesOrNoForm();
                if (form.ShowDialog() != DialogResult.Yes)
                    return;
                if (CurRow != -1)
                {
                    string matNO = dg[CurRow, 1].ToString();   //注意键值
                    foreach (var item in dicScaned)
                    {
                        if (item.Value.MatNo == matNO)
                        {
                            dicScaned.Remove(item.Key); break;
                        }
                    }
                    ShowData(dicScaned);
                    txtresult.Text = "移除：" + matNO;
                    txtresult.BackColor =Color.White;
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

        private void btnRedo_Click(object sender, EventArgs e)
        {
            YesOrNoForm form = new YesOrNoForm();
            if (form.ShowDialog() != DialogResult.Yes)
                return;
            table.Clear();
            dicScaned.Clear();
            txtMatNo.Text = "";
            txtMatNo.Focus();
            CurRow = -1;
            txtresult.Text = "重置";
            txtresult.BackColor = Color.White;
        }


    }
}