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
    public partial class ShemeInForm : Form
    {
        /// <summary>
        /// 当前选中材料
        /// </summary>
        private int CurRow = -1;
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        /// <summary>
        /// 车辆信息
        /// </summary>
        private TruckCls Truck = new TruckCls();
        /// <summary>
        /// table相关
        /// </summary>
        /// <param name="_Truck"></param>
        private DataTable table = new DataTable("table");
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();
        /// <summary>
        /// 材料字典
        /// </summary>
        /// <param name="_Truck"></param>
        private Dictionary<string, MatterCls> dicMat = new Dictionary<string, MatterCls>();
        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="_Truck"></param>
        public PT.PTInterfacePrx Prx = null;
        /// <summary>
        /// 批处理号
        /// </summary>
        /// <param name="_Truck"></param>
        private int ProcessNo = 0;
        /// <summary>
        /// 接口返回值
        /// </summary>
        /// <param name="_Truck"></param>
        private int nResult = 0;
        private string cID;
        private int nRet;
        /// <summary>
        /// 当前扫描的材料号
        /// </summary>
        /// <param name="_Truck"></param>
        private string scanMat = "";
        public ShemeInForm(TruckCls _Truck, PTInterfacePrx _Prx,dtPTCommon _people,int _process)
        {
            try
            {
                ProcessNo = _process;
                Prx = _Prx;
                people = _people;
                Truck = _Truck;
                InitializeComponent();
                InitDataGrid(table);
                this.Activated += new EventHandler(ShemeInCoilINF_Activated);
                this.Closed += new EventHandler(ShemeInCoilINF_Closed);
                

            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        private void ShemeInCoilINF_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }
        private void ShemeInCoilINF_Closed(object sender, EventArgs e)
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

            if (InvokeRequired)
            {

                BeginInvoke(new OnScanCompleteDelegate(ScannerHelper_ScanCompleteEvent),
                    new object[] { Sender, e });
                return;
            }

            string tmp = e.Text.Trim();
            if (tmp.Contains("-"))
            {
                tmp = tmp.Replace("-", "");
            }
            if (tmp.Contains("S"))
            {
                tmp = tmp.Replace("S", "");
            }
            //根据扫描到的字符串长度判断是车号还是槽号
            if (dicMat.Keys.Contains(tmp))
            {
                txtresult.Text = "材料已添加";
                txtresult.BackColor = Color.Red;
            }
            else
            {
                scanMat = tmp;
                btnAdd_Click(null, null);

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
            table.Columns.Add("卸下", typeof(string));
            table.Columns.Add("材料号", typeof(string));
            table.Columns.Add("槽号", typeof(string));
            table.Columns.Add("包装状态", typeof(string));
            table.Columns.Add("开卷方向", typeof(string));

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

            DataGridTextBoxColumn theCol_Unload = new DataGridTextBoxColumn();
            theCol_Unload.HeaderText = "卸下";
            theCol_Unload.MappingName = "卸下";
            theCol_Unload.Width = 68;

            DataGridTextBoxColumn theCol_MaterialNo = new DataGridTextBoxColumn();
            theCol_MaterialNo.HeaderText = "材料号";
            theCol_MaterialNo.MappingName = "材料号";
            theCol_MaterialNo.Width = 110;


            DataGridTextBoxColumn theCol_Groove = new DataGridTextBoxColumn();
            theCol_Groove.HeaderText = "槽号";
            theCol_Groove.MappingName = "槽号";
            theCol_Groove.Width = 80;

           

            DataGridTextBoxColumn theCol_Package = new DataGridTextBoxColumn();
            theCol_Package.HeaderText = "包装状态";
            theCol_Package.MappingName = "包装状态";
            theCol_Package.Width = 68;

            DataGridTextBoxColumn theCol_DIR = new DataGridTextBoxColumn();
            theCol_DIR.HeaderText = "开卷方向";
            theCol_DIR.MappingName = "开卷方向";
            theCol_DIR.Width = 68;

           
            

            dataGridTableStyle1.MappingName = "table";
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Unload);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_MaterialNo);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Groove);
          
          
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Package);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_DIR);

            dataGrid1.TableStyles.Add(dataGridTableStyle1);
        }
        #endregion

        #region 添加材料 若材料添加过 更新材料
        /// <summary>
        /// 添加材料 若材料添加过 更新材料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                ShemeInCoilINF newform = new ShemeInCoilINF("ShemeIn", scanMat);
                if (newform.ShowDialog() != DialogResult.OK)
                    return;
                //社会车辆拼7位码 前补4个0
                //框架车以框架号补前4位
                string Joint0to7 = "";
                string groove = "";
                if (Truck.carNo.Length == 4)
                {
                    Joint0to7 = Truck.carNo;
                }
                else
                {
                    Joint0to7 = "0000";
                }
                if (newform.Groove.Length == 1)
                {
                    groove = "0" + newform.Groove;
                   
                }
                Joint0to7 = Joint0to7 + groove + newform.Column;

                if (dicMat.ContainsKey(newform.MatNo))
                {
                    //材料已添加过 更新
                    MatterCls tmp = dicMat[newform.MatNo];
                    tmp.isUnload = newform.IsUnload;
                    tmp.direction = newform.FlagRotate;
                    tmp.InGroove = Joint0to7;
                    tmp.PackageState = newform.Package;
                    tmp.sleeve = newform.Sleeve;
                    tmp.l3lack = "";
                    dicMat[newform.MatNo] = tmp;
                    txtresult.Text = "材料信息更新成功";
                    txtresult.BackColor = Color.Green;
                }
                else
                {
                    //添加若材料信息不完整 不允许添加 弹框提示
                    if (newform.MatNo == "" || newform.Groove == ""  )
                    {
                        MessageBox.Show("材料信息不完整");
                        return;
                    }
                    MatterCls tmp = new MatterCls();
                    tmp.matno = newform.MatNo;
                    tmp.isUnload = newform.IsUnload;
                    tmp.direction = newform.FlagRotate;
                    tmp.InGroove = Joint0to7;
                    tmp.PackageState = newform.Package;
                    tmp.sleeve = newform.Sleeve;
                    tmp.l3lack = "";
                    dicMat[newform.MatNo] = tmp;
                    txtresult.Text = "材料信息添加成功";
                    txtresult.BackColor = Color.Green;
                }
                ShowData(dicMat);
                CurRow = table.Rows.Count-1;
                SelectCurRow();
                scanMat = "";
    
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, true);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
           
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
                    string unload = "否";
                    if (mat.isUnload)
                    {
                        unload = "是";
                    }
                    newRow["卸下"] = unload;
                    newRow["材料号"] = mat.matno;
                    //截取顺序 左右
                    if (mat.InGroove != null)
                    {
                        if (mat.InGroove.Length > 6)
                        {
                            string seq = mat.InGroove.Substring(4, 2);
                            string col = mat.InGroove.Substring(6, 1);
                            string str = seq + "排";
                            if (col == "1")
                            {
                                str += "左列";
                            }
                            else
                            {
                                str += "右列";
                            }
                            newRow["槽号"] = str;
                        }
                    }
                    else
                    {
                        newRow["槽号"] = "";
                    }
                    string package = "未包装";
                    if (mat.PackageState)
                    {
                        package = "已包装";
                    }
                    newRow["包装状态"] = package;
                    if (mat.direction == "0")
                    {
                        newRow["开卷方向"] = "上开卷";
                    }
                    if (mat.direction == "1")
                    {
                        newRow["开卷方向"] = "下开卷";
                    }
                    if (mat.direction == "2")
                    {
                        newRow["开卷方向"] = "未知";
                    }
                    table.Rows.Add(newRow);
                    
                }
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

        #region 删除材料 正应答的材料不允许删除
        /// <summary>
        /// 删除材料 正应答的材料不允许删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (CurRow == -1)
                {
                    return;
                }
                YesOrNoForm form = new YesOrNoForm();
                if (form.ShowDialog() != DialogResult.Yes)
                    return;
                //首先找到该材料
                string matno = dataGrid1[CurRow, 1].ToString();
                MatterCls tmpmat = dicMat[matno];
                //判断材料是否正应答
                if (tmpmat.l3lack == "正应答")
                {
                    txtresult.Text = "正应答的材料不允许删除";
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    //Prx.DeleteWrongMat(Truck,matno, ProcessNo, out nResult);
                    nResult = 100;
                    if (nResult != -999)
                    {
                        dicMat.Remove(matno);
                        txtresult.Text = "删除成功";
                        txtresult.BackColor = Color.Green; 
                        ShowData(dicMat);
                        //当前选中行被删除
                        CurRow = -1;
                        SelectCurRow();
                    }
                    else
                    {
                        txtresult.Text = "删除失败";
                        txtresult.BackColor = Color.Red; 
                    }
                }
              
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, true);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

        }
        #endregion

        #region 返回
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 若SRS系统含有车辆材料信息 先确认车辆到达，同时查询
        /// <summary>
        /// 若SRS系统含有车辆材料信息 先确认车辆到达，同时查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShemeInForm_Load(object sender, EventArgs e)
        {
            try
            {
                dicMat.Clear();
                MatterCls[] matlist=null;
                //确认卡车入位信息 触发tag点 并等3秒 装卸车后台反映
                Prx.TruckInInf(people, Truck, ProcessNo, out cID, out nResult, Program.ctx);
                //等待3s 查询应答
                Thread.Sleep(3000);
                ////nResult返回配载图ID
                //ProcessNo = nResult;
                //后台根据停车位查询当前配载图ID和处理号，查询配载信息
                Truck.TruckPosition = Truck.TruckPosition.Substring(0, Truck.TruckPosition.Length - 2);
                Prx.SearchMatInf(people, Truck, ProcessNo, out matlist, out cID, out nResult, Program.ctx);
                //若含有材料信息，添加至字典
                if (matlist.Length != 0)
                {
                    for (int index = 0; index < matlist.Length; index++)
                    {
                        MatterCls tmp = matlist[index];
                        dicMat.Add(tmp.matno, tmp);
                    }
                    txtresult.Text = "材料信息查询成功";
                    txtresult.BackColor = Color.Green;
                }
                else
                {
                    txtresult.Text = "无材料信息";
                    txtresult.BackColor = Color.Green;
                }
                ShowData(dicMat);
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, true);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

        }
        #endregion

        #region 修改材料 正应答的材料不允许修改
        /// <summary>
        /// 修改材料 正应答的材料不允许修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            try 
            {
                if (CurRow == -1)
                {
                    return;
                }
                //首先找到该材料
                string matno = dataGrid1[CurRow, 1].ToString();
                MatterCls tmpmat = dicMat[matno];
               
                //进入材料修改画面
                ShemeInCoilINF newform = new ShemeInCoilINF(tmpmat);
                if (newform.ShowDialog() != DialogResult.OK)
                    return;
                string Joint0to7 = "";
                string groove = "";
                if (Truck.carNo.Length == 4)
                {
                    Joint0to7 = Truck.carNo;
                }
                else
                {
                    Joint0to7 = "0000";
                }
                if (newform.Groove.Length == 1)
                {
                    groove = "0" + newform.Groove;

                }
                Joint0to7 = Joint0to7 + groove + newform.Column;
                tmpmat.isUnload = newform.IsUnload;
                tmpmat.direction = newform.FlagRotate;
                tmpmat.InGroove = Joint0to7;
                tmpmat.PackageState = newform.Package;
                tmpmat.sleeve = newform.Sleeve;
                tmpmat.l3lack = "";
                dicMat[matno] = tmpmat;
                txtresult.Text = "材料信息更新成功";
                //修改后Currow不变
                ShowData(dicMat);
                SelectCurRow();

               
                
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion

        #region 提交材料 只提交状态为卸下的材料 等待3S查询应答信息
        /// <summary>
        /// 提交材料 只提交状态为卸下的材料 等待3S查询应答信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSummit_Click(object sender, EventArgs e)
        {
            try
            { 
                List<MatterCls> matlist= new List<MatterCls>();
                //将需卸下的材料提交
                foreach (MatterCls mat in dicMat.Values)
                {
                    //if (mat.isUnload)
                    //{
                    //    matlist.Add(mat);
                    //}
                    matlist.Add(mat);
                }
                if (matlist.Count == 0)
                {
                    txtresult.Text = "无卸下材料";
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    Prx.SubmitTruckInf(people, Truck, 1, matlist.ToArray(), out nResult, Program.ctx);
                    if (nResult == -999)
                    {
                        txtresult.Text = "信息提交失败";
                        txtresult.BackColor = Color.Red;
                        return;
                    }
                    else
                    {
                        txtresult.Text = "信息提交成功";
                        txtresult.BackColor = Color.Green;
                        return;
                    }
                    ////等待3s 查询应答
                    //Thread.Sleep(3000);
                    //MatterCls[] acklst = null;
                    //Prx.TruckInOutAck(people, ProcessNo, out nResult, out acklst, Program.ctx);
                    //if (nResult == -999)
                    //{
                    //    txtresult.Text = "查询应答失败";
                    //    txtresult.BackColor = Color.Red;
                    //}
                    //if (nResult == -888)
                    //{
                    //    txtresult.Text = "未找到对应库区";
                    //    txtresult.BackColor = Color.Red;
                    //}
                    //if (nResult == 100)
                    //{
                    //    //更新材料显示信息
                    //    for (int index = 0; index < acklst.Length; index++)
                    //    {
                    //        MatterCls tmp = dicMat[acklst[index].matno];
                    //        tmp.l3lack = acklst[index].l3lack;
                    //        dicMat[tmp.matno] = tmp;
                    //    }
                    //    ShowData(dicMat);
                    //    txtresult.Text = "查询应答成功";
                    //    txtresult.BackColor = Color.Green;
                    //}

                }

            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, true);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

        }
        #endregion

        #region 查询应答
        /// <summary>
        /// 查询应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnACK_Click(object sender, EventArgs e)
        {
            try
            {
           
                MatterCls[] acklst = null;
                Prx.TruckInOutAck(people, ProcessNo, out nResult, out acklst, Program.ctx);
                if (nResult == -999)
                {
                    txtresult.Text = "查询应答失败";
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    //更新材料显示信息
                    for (int index = 0; index < acklst.Length; index++)
                    {
                        MatterCls tmp = dicMat[acklst[index].matno];
                        tmp.l3lack = acklst[index].l3lack;
                        dicMat[tmp.matno] = tmp;
                    }
                    ShowData(dicMat);
                    txtresult.Text = "查询应答成功";
                    txtresult.BackColor = Color.Red;
                }

            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, true);
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

        }
        #endregion

        
    }
}