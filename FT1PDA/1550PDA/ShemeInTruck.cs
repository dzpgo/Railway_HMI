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

namespace _1550PDA
{
    public partial class ShemeInTruck : Form
    {
        /// <summary>
        /// 车辆信息
        /// </summary>
        private TruckCls Truck = new TruckCls();
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        /// <summary>
        /// ice接口
        /// </summary>
        private PTInterfacePrx Prx = null;
        /// <summary>
        /// 配载图id
        /// </summary>
        private int Process = 0;
        /// <summary>
        /// 接口返回数据
        /// </summary>
        private string cID;
        private int nRet;
        private int nResult;
        private string cartype = "";
        private string direction = "";
        private string parkingType = "";
        #region 构造函数
        /// <summary>
        /// 加入扫描事件
        /// </summary>
        /// <param name="_people"></param>
        /// <param name="_Prx"></param>
        public ShemeInTruck( dtPTCommon _people,PTInterfacePrx _Prx)
        {
            //默认作业类型为入库,存在备用字段
            Truck.sqare2 = "1";
            people = _people;
            Prx = _Prx;
            InitializeComponent();
            parkingType = "0";
            cbxParkingType.Visible = false;
            label6.Visible = false;
        }
        #endregion

        #region 画面激活 启动扫描事件
        /// <summary>
        /// 启动扫描事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShemeInTruck_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }
        #endregion
        #region 画面关闭 关闭扫描事件
        /// <summary>
        /// 画面关闭 关闭扫描事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShemeInTruck_Closed(object sender, EventArgs e)
        {
            ScannerHelper.ScannerDestroy();
        }
        #endregion

        /// <summary>
        /// 扫描事件代理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (tmp.Contains("-"))
                {
                    tmp = tmp.Replace("-", "");
                }

                // 判断扫描的是停车位条码 或 框架槽号条码
                if (tmp.Length == 6 && 
                    (tmp.Contains('W') || tmp.Contains("E") || tmp.Contains("S") || tmp.Contains("N")) )
                {
                    // 停车位条码

                    cbxTruckPostion.Text = tmp.Substring(0, 5);     // 停车位
                    cbxHeadDirection.Text = tmp.Substring(5, 1);    // 框架朝向
                }
                else if (tmp.Length == 7)
                {
                    // 框架槽号条码

                    // 若未选择车位，不判断
                    if (Truck.TruckPosition == null)
                    {
                        txtresult.Text = "请先选择车位号";
                        txtresult.BackColor = Color.Red;
                        return;
                    }
                    //7位为扫描到槽号
                    txtTruckNo.Text = tmp.Substring(0, 4);
                    int groove = Convert.ToInt32(tmp.Substring(5, 1));
                    //根据扫描到的槽号判断车头方向
                    string flag = "";
                    if (groove > 5)
                    {
                        flag = "BIG";
                    }
                    else
                    {
                        flag = "SMALL";
                    }
                    TruckCls _Truck = new TruckCls();
                    //若之前取过车辆类型 保存
                    
                    
                    Truck.sqare1 = flag;
                    Prx.TruckPos(people, Truck, out _Truck, out cID, out nResult, Program.ctx);
                    if (nResult == 100)
                    {

                        int index = 0;
                        for (; index < cbxHeadDirection.Items.Count; index++)
                        {
                            if (cbxHeadDirection.Items[index].ToString() == _Truck.HeadDirection)
                            {
                                cbxHeadDirection.Text = _Truck.HeadDirection;
                                break;
                            }
                        }
                        //cbxHeadDirection.SelectedIndex = index;
                    }
                }
                else
                {
                    //int index = 0;
                    //for (; index < cbxTruckPostion.Items.Count; index++)
                    //{
                    //    if (cbxTruckPostion.Items[index].ToString() == tmp)
                    //    {
                    //        break;
                    //    }
                    //}

                    //cbxTruckPostion.SelectedIndex = index;
                    //Truck.TruckPosition = cbxTruckPostion.Text;
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

        #region 车位赋值
        /// <summary>
        /// 车位赋值 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTruckPostion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Truck.TruckPosition = cbxTruckPostion.Text;
                //查询该车位方向
                cbxHeadDirection.Items.Clear();
                TruckCls _Truck = new TruckCls();
                TruckCls DIR = new TruckCls();

                // 读取停车位方向
                _Truck.sqare1 = "SMALL";
                _Truck.TruckPosition = Truck.TruckPosition;
                Prx.TruckPos(people, _Truck, out DIR, out cID, out nResult, Program.ctx);
                direction = DIR.HeadDirection;
                if (direction.Length != 0)
                {
                    cbxHeadDirection.Items.Clear();
                    if (DIR.HeadDirection == "W" || DIR.HeadDirection == "E")
                    {
                        cbxHeadDirection.Items.Add("W");
                        cbxHeadDirection.Items.Add("E");
                    }
                    if (DIR.HeadDirection == "N" || DIR.HeadDirection == "S")
                    {
                        cbxHeadDirection.Items.Add("N");
                        cbxHeadDirection.Items.Add("S");
                    }
                }
                else
                {
                    MessageBox.Show(String.Format("表UACS_HEAD_POSITION_CONFIG未配置停车位{0}方向的记录！", Truck.TruckPosition));
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

        #region 车头方向赋值
        /// <summary>
        /// 车头方向赋值 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxHeadDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Truck.HeadDirection = cbxHeadDirection.Text;
        }
        #endregion

        #region 车号赋值 同时查询卡车入位信息
        /// <summary>
        /// 车号赋值  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTruckNo_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                //若未选择作业种类，不查询
                if (rbnIn.Checked == false && rbnOut.Checked == false)
                {
                    txtresult.Text = "请选择作业类型";
                    txtresult.BackColor = Color.Red;
                    return;
                }
                if (linkLabel1.Text == "空")
                {
                    linkLabel1.BackColor = Color.Silver;
                    if (txtTruckNo.Text.Trim().Length > 3)
                    {
                        Truck.carNo = txtTruckNo.Text;
                    }

                }
                else
                {
                    linkLabel1.BackColor = Color.Red;
                    if (txtTruckNo.Text.Trim().Length > 3)
                    {
                        Truck.carNo = linkLabel1.Text + txtTruckNo.Text.ToUpper();
                    }

                }
                if (chbChooseCN.Checked)
                {
                    Truck.carNo = Truck.carNo + "挂";
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

        #region 返回上层画面
        /// <summary>
        /// 返回上层画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 根据作业类型进入画面
        /// <summary>
        /// 根据作业类型进入画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Truck.carNo == null || Truck.HeadDirection == null || Truck.TruckPosition == "" || cartype == "" || parkingType=="")
            {
                txtresult.Text = "请录入车辆入位信息";
                txtresult.BackColor = Color.Red;
                return;
            }
            Truck.sqare1 = cartype;
            Truck.TruckPosition = Truck.TruckPosition + "|" + parkingType;
            if (rbnIn.Checked)
            {
                ShemeInForm newform = new ShemeInForm(Truck, Prx, people, Process);
                newform.ShowDialog();
            }
            else
            {
                if (rbnOut.Checked)
                {

                    ShemeOut newform = new ShemeOut(Truck, Prx, people, Process);
                    newform.ShowDialog();
                }
            }
            
        }
        #endregion

        #region 作业类型选择
        /// <summary>
        /// 若选择入库 保证出库为false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnIn.Checked)
            {
                Truck.sqare2 = "1";
                rbnOut.Checked = false;
                txtTruckNo_TextChanged(null, null);
            }
        }

        /// <summary>
        /// 若选择出库 保证入库为false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnOut.Checked)
            {
                rbnIn.Checked = false;
                Truck.sqare2 = "2";
                txtTruckNo_TextChanged(null, null);
            }
        }
        #endregion

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                cityFrm frm = new cityFrm();
                frm.ShowDialog();
                //txtCar_No.Text = frm.city;
                linkLabel1.Text = frm.city;
                

            }
            catch (System.Exception ex)
            {
                //捕获异常,直接显示异常信息
                Program.LogException(ex, true);
            }
        }

        private void linkLabel1_TextChanged(object sender, EventArgs e)
        {
            if (linkLabel1.Text == "空")
            {
                linkLabel1.BackColor = Color.Silver;
                if (txtTruckNo.Text.Trim().Length > 3)
                {
                    Truck.carNo = txtTruckNo.Text;
                }

            }
            else
            {
                linkLabel1.BackColor = Color.Red;
                if (txtTruckNo.Text.Trim().Length > 3)
                {
                    Truck.carNo = linkLabel1.Text + txtTruckNo.Text.ToUpper(); 
                }
                
            }
        }

        private void cbxCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbxHeadDirection.Items.Clear();
            if (cbxCarType.Text == "标准框架")
            {
                cartype = "100";
                cbxParkingType.Visible = false;
                label6.Visible = false;
                parkingType = "0";
            }
            if (cbxCarType.Text == "标准社会车辆")
            {
                cartype = "101";
                cbxParkingType.Visible = false;
                label6.Visible = false;
                parkingType = "0";
            }
            //if (cbxCarType.Text == "大头娃娃车")
            //{
            //    cartype = "102";
            //    cbxParkingType.Visible = true;
            //    cbxParkingType.Text = "小框";
            //    label6.Visible = true;
            //    parkingType = "1";
            //}
            if (cbxCarType.Text == "较低社会车辆")
            {
                cartype = "103";
                cbxParkingType.Visible = false;
                label6.Visible = false;
                parkingType = "0";
            }
            if (cbxCarType.Text == "雨棚车")
            {
                cartype = "104";
                cbxParkingType.Visible = false;
                label6.Visible = false;
                parkingType = "0";
            }
            if (cartype == "100")//框架车
            {
                //铁路库车头可选
                //cbxHeadDirection.Items.Add(direction);
                //cbxHeadDirection.Text = direction;
            }
            //else
            //{
            //    if (direction == "W" || direction == "E")
            //    {
            //        cbxHeadDirection.Items.Add("W");
            //        cbxHeadDirection.Items.Add("E");
            //    }
            //    if (direction == "N" || direction == "S")
            //    {
            //        cbxHeadDirection.Items.Add("N");
            //        cbxHeadDirection.Items.Add("S");
            //    }
            //}
        }

        private void cbxParkingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxParkingType.Text == "大框")
            {
                parkingType = "0";
            }
            else
            {
                parkingType = "1";
            }
        }

        private void chbChooseCN_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbChooseCN.Checked)
                {
                    if (Truck.carNo != null)
                    {
                        if (!Truck.carNo.Contains("挂"))
                        {
                            Truck.carNo = Truck.carNo + "挂";
                        }
                    }
                }
                else
                {
                    if (Truck.carNo != null)
                    {
                        if (Truck.carNo.Contains("挂"))
                        {
                            Truck.carNo = Truck.carNo.Replace("挂", "");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
 
            }
        }
    }
}