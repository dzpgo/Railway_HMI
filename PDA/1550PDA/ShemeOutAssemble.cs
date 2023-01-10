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
    public partial class ShemeOutAssemble : Form
    {

        /// <summary>
        /// 卡车入位标志
        /// </summary>
        private bool IsTruckIn = false;
        /// <summary>
        /// 车辆信息
        /// </summary>
        private TruckCls Truck = new TruckCls();
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
        /// 障碍字典 
        /// </summary>
        /// <param name="_Truck"></param>
        private Dictionary<string, MatterCls> dicMat_obs = new Dictionary<string, MatterCls>();
        /// <summary>
        /// 材料字典 显示依次字典为准
        /// </summary>
        /// <param name="_Truck"></param>
        private Dictionary<string, MatterCls> dicMat = new Dictionary<string, MatterCls>();
        /// <summary>
        /// 原始字典 防止删除材料后再扫描该材料 出现不允许出库现象
        /// </summary>
        private Dictionary<string, MatterCls> dicMatOri = new Dictionary<string, MatterCls>();
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
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        public ShemeOutAssemble(TruckCls _Truck, PTInterfacePrx _Prx, dtPTCommon _people, int _process)
        {
            ProcessNo = _process;
            Prx = _Prx;
            people = _people;
            Truck = _Truck;
            InitializeComponent();
            InitDataGrid(table);
        }
    
        #region  表格初始化时 给表格赋值
        /// <summary>
        /// 表格初始化时 给表格赋值
        /// </summary>
        /// <param name="table">表格数据</param>
        private void InitDataGrid(DataTable table)
        {
            table.Columns.Add("状态", typeof(string));
            table.Columns.Add("材料号", typeof(string));
            table.Columns.Add("应答", typeof(string));

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

            DataGridFormattableTextBoxColumn theCol_Status = new DataGridFormattableTextBoxColumn();
            theCol_Status.HeaderText = "状态";
            theCol_Status.MappingName = "状态";
            theCol_Status.Width = 68;

            DataGridTextBoxColumn theCol_MaterialNo = new DataGridTextBoxColumn();
            theCol_MaterialNo.HeaderText = "材料号";
            theCol_MaterialNo.MappingName = "材料号";
            theCol_MaterialNo.Width = 110;

            DataGridTextBoxColumn theCol_OutGroove = new DataGridTextBoxColumn();
            theCol_OutGroove.HeaderText = "槽号";
            theCol_OutGroove.MappingName = "槽号";
            theCol_OutGroove.Width = 60;

            DataGridTextBoxColumn theCol_Ack = new DataGridTextBoxColumn();
            theCol_Ack.HeaderText = "应答";
            theCol_Ack.MappingName = "应答";
            theCol_Ack.Width = 150;


            dataGridTableStyle1.MappingName = "table";
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Status);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_MaterialNo);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_OutGroove);
            dataGridTableStyle1.GridColumnStyles.Add(theCol_Ack);

            dataGrid1.TableStyles.Add(dataGridTableStyle1);
            theCol_Status.SetCellFormat += new DataGridFormattableTextBoxColumn.FormatCellEventHandler(theCol_Status_SetCellFormat);
        }
        #endregion
        #region 根据指令状态更新显示颜色
        /// <summary>
        /// 根据指令状态更新显示颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void theCol_Status_SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                DataRow theRow = table.Rows[e.Row];
                string matno = theRow["材料号"].ToString();

                if (matno != "")
                {

                    MatterCls tmp = dicMat[matno];
                    //选中状态为“不允许出库”或负应答的材料 红色显示
                    if ((tmp.l3lack != "" && tmp.l3lack != "成功") || tmp.status == "Wrong")
                    {
                        SolidBrush theSolidBrush = new System.Drawing.SolidBrush(Color.Red);
                        e.BackBrush = theSolidBrush;
                    }
                }
            }

            catch (System.Exception ex)
            {
                Program.LogException(ex, false);

            }
        }
        #endregion
        #region  插入数据到表格
        /// <summary>
        /// 对于障碍钢卷 槽号写入入库槽号
        /// </summary>
        /// <param name="dic"></param>
        private void ShowData()
        {
            try
            {
                table.Clear();
                #region 显示出库钢卷 
                
                foreach (MatterCls mat in dicMat.Values)
                {
                    DataRow newRow;
                    newRow = table.NewRow();
                    newRow["状态"] = Program.ToChnOutMatStatus(mat.status);
                    newRow["材料号"] = mat.matno;
                    newRow["槽号"] = mat.OutGroove;
                    newRow["应答"] = mat.l3lack;
                    table.Rows.Add(newRow);

                }
                #endregion
                #region 显示障碍钢卷

                foreach (MatterCls mat in dicMat_obs.Values)
                {
                    DataRow newRow;
                    newRow = table.NewRow();
                    newRow["状态"] = Program.ToChnOutMatStatus(mat.status);
                    newRow["材料号"] = mat.matno;
                    newRow["槽号"] = mat.OutGroove;
                    newRow["应答"] = mat.l3lack;
                    table.Rows.Add(newRow);

                }
                #endregion
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

        #region 扫描不到材料号时 手动添加材料号
        /// <summary>
        /// 根据作业状态 加入障碍字典或扫描字典
        /// 扫描不到材料号时 手动添加材料号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManual_Click(object sender, EventArgs e)
        {
            try
            {
                ShemeInCoilINF newform = new ShemeInCoilINF("Out");
                if (newform.ShowDialog() != DialogResult.OK)
                    return;
                
                //已入位 出库流程
                if (IsTruckIn)
                {
                    //若添加的材料号在出库队列里，将其状态改为已扫描
                    if (dicMatOri.Keys.Contains(newform.MatNo))
                    {

                        MatterCls tmp = dicMatOri[newform.MatNo];
                        tmp.OutGroove = newform.Groove;
                        tmp.status = "Scaned";
                        dicMat[newform.MatNo] = tmp;
                    }

                    //若无 将其状态改为不允许出库
                    else
                    {
                        MatterCls tmp = new MatterCls();
                        tmp.OutGroove = newform.Groove;
                        tmp.matno = newform.MatNo;
                        tmp.status = "Wrong";
                        tmp.l3lack = "";
                        dicMat[newform.MatNo] = tmp;
                    }
                }
                //未入位 添加障碍
                else
                {
                    //若之前填加过 更新
                    if (dicMat_obs.ContainsKey(newform.MatNo))
                    {
                        MatterCls tmp = dicMat_obs[newform.MatNo];
                        tmp.status = "obstacle";
                        tmp.l3lack = "";
                        tmp.OutGroove = newform.Groove;
                        dicMat_obs[newform.MatNo] = tmp;
                    }
                    else
                    {
                        MatterCls tmp = new MatterCls();
                        tmp.OutGroove = newform.Groove;
                        tmp.matno = newform.MatNo;
                        tmp.status = "obstacle";
                        tmp.l3lack = "";
                        dicMat_obs[newform.MatNo] = tmp;
                    }

                }
                ShowData();
                //寻找材料所在行作为当前行
                for (int index = 0; index < table.Rows.Count; index++)
                {
                    string CurMat = table.Rows[index][1].ToString();
                    if (CurMat == newform.MatNo)
                    {
                        CurRow = index;
                        break;
                    }
                }
                SelectCurRow();
                txtresult.Text = "材料添加成功";
                txtresult.BackColor = Color.Green;
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "材料添加失败";
                txtresult.BackColor = Color.Red;
            }
        }
        #endregion

        #region 提交扫描信息
        /// <summary>
        /// 提交 仅提交状态为已扫描的材料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                List<MatterCls> matlist = new List<MatterCls>();
                //将需卸下的材料提交
                foreach (MatterCls mat in dicMat.Values)
                {
                    if (mat.status != "obstacle")
                    {
                        matlist.Add(mat);
                    }
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
                    //等待3s 查询应答
                    Thread.Sleep(3000);
                    MatterCls[] acklst = null;
                    Prx.TruckInOutAck(people, ProcessNo, out nResult, out acklst);
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
                        ShowData();
                        txtresult.Text = "查询应答成功";
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 删除材料
        /// <summary>
        /// 删除障碍钢卷时 在后台也删除
        /// 删除材料 只能删除不允许出库的材料
        /// 只在显示字典中删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurRow == -1)
                    return;
                //找到该材料
                string matno = dataGrid1[CurRow, 1].ToString();
                // 判断该材料是否是障碍钢卷
                if (dicMat_obs.Keys.Contains(matno))
                {
                    MatterCls tmp = dicMat_obs[matno];
                    Prx.DeleteWrongMat(Truck, matno, ProcessNo, out nResult, Program.ctx);
                    if (nResult != -999)
                    {
                        dicMat_obs.Remove(matno);
                        txtresult.Text = "删除成功";
                        txtresult.BackColor = Color.Green;
                        ShowData();
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
                else
                {
                    MatterCls tmp = dicMat[matno];
                    //扫描成功和正应答材料不允许删除
                    if (tmp.status != "Wrong")
                    {
                        txtresult.Text = "该材料不允许删除";
                        txtresult.BackColor = Color.Red;
                    }
                    else
                    {
                        dicMat.Remove(matno);
                        CurRow = -1;
                        ShowData();
                        SelectCurRow();
                        txtresult.Text = "材料删除成功";
                        txtresult.BackColor = Color.Green;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
                txtresult.Text = "材料删除失败";
                txtresult.BackColor = Color.Red;
            }
        }
        #endregion

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
                    ShowData();
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
        #region 查询随车信息
        /// <summary>
        /// 查询随车信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsTruckIn)
                {
                    dicMat.Clear();
                    dicMatOri.Clear();
                    MatterCls[] matlist = null;
                    Prx.SearchMatInf(people, Truck, ProcessNo, out matlist, out cID, out nResult, Program.ctx);
                    //nResult返回配载图ID
                    ProcessNo = nResult;
                    //若含有材料信息，添加至字典
                    if (matlist.Length != 0)
                    {
                        for (int index = 0; index < matlist.Length; index++)
                        {
                            MatterCls tmp = matlist[index];
                            dicMat.Add(tmp.matno, tmp);
                            dicMatOri.Add(tmp.matno, tmp);
                        }
                        txtresult.Text = "材料信息查询成功";
                        txtresult.BackColor = Color.Green;
                    }
                    else
                    {
                        txtresult.Text = "无材料信息";
                        txtresult.BackColor = Color.Green;
                    }
                    ShowData();
                }
                else
                {
                    txtresult.Text = "请先完成车辆入位";
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

        #region 扫描完障碍钢卷 车辆完成入位
        private void btnCarIn_Click(object sender, EventArgs e)
        {
            try
            {
                Prx.TruckInInf(people, Truck, ProcessNo, out cID, out nResult, Program.ctx);
                //nResult返回配载图ID
                ProcessNo = nResult;
                //将障碍钢卷提交
                List<MatterCls> matlist = new List<MatterCls>();
                foreach (MatterCls mat in dicMat_obs.Values)
                {
                    matlist.Add(mat);
                }
                Prx.SubmitTruckInf(people, Truck, 4, matlist.ToArray(), out nResult, Program.ctx);
                //改变作业模式
                IsTruckIn = true;

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