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
    public partial class MatInf : Form
    {
        /// <summary>
        /// ice接口
        /// </summary>
        private PTInterfacePrx Prx = null;
        /// <summary>
        /// 接口返回数据
        /// </summary>
        private string cID;
        private int nRet;
        private int nResult;
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        public MatInf(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            people = _people;
            Prx = _Prx;
            InitializeComponent();
            this.Activated += new EventHandler(MatInf_Activated);
            this.Closed += new EventHandler(MatInf_Closed);
        }
        #region 画面激活 启动扫描事件
        /// <summary>
        /// 启动扫描事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MatInf_Activated(object sender, EventArgs e)
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
        private void MatInf_Closed(object sender, EventArgs e)
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
                txtMatNo.Text = tmp;
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

        #region 清空显示
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMatNo.Text = "";
            txtSaddleNo.Text = "";
            txtStoreId.Text = "";
            txtLayerNo.Text = "";
            txtInDia.Text = "";
            txtOutDia.Text = "";
            txtWeight.Text = "";
            txtwidth.Text = "";
            txtSleeve.Text = "";
            txtNextUnitNo.Text = "";
            txtContract.Text = "";
            txtCoilType.Text = "";
            rbnDown.Checked = false;
            rbnNo.Checked = false;
            rbnUp.Checked = false;
            rbnYes.Checked = false;
            rbnUnkwon.Checked = false;
            txtresult.Text = "";
            txtresult.BackColor = Color.White;

        }
        #endregion
        #region 返回
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region 若材料号位数不正确 不查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtMatNo.Text.Trim().Length > 10 || txtSaddleNo.Text.Trim().Length > 9)
                {
                    string searchstr = "";
                    //若材料号和垛位号都查询 以材料号为查询条件
                    if (txtMatNo.Text.Trim().Length != 0)
                    {
                        searchstr = txtMatNo.Text.Trim();
                    }
                    else if (txtSaddleNo.Text.Trim().Length != 0)
                    {
                        searchstr = txtSaddleNo.Text.Trim();
                    }
                    MatterCls mat = new MatterCls();
                    Prx.MatInfSearch(people, searchstr, out mat, out nResult, Program.ctx);
                    if (mat.matno != "-999999")
                    {
                        txtMatNo.Text = mat.matno;
                        txtSaddleNo.Text = mat.stcUnit.UnitNo;
                        txtStoreId.Text = mat.stcUnit.StoreID;
                        txtLayerNo.Text = mat.stcUnit.layer.ToString();
                        txtInDia.Text = mat.insideDia.ToString();
                        txtOutDia.Text = mat.outsideDia.ToString();
                        //重量以吨显示
                        txtWeight.Text = (mat.weight / 1000).ToString();
                        txtwidth.Text = mat.width.ToString();
                        txtSleeve.Text = mat.sleeve;
                        txtNextUnitNo.Text = mat.NextUnitno;
                        txtContract.Text = mat.ContractNo;
                        if (mat.direction == "0")
                        {
                            //上开卷

                            rbnDown.Checked = false;
                            rbnUp.Checked = true;
                            rbnUnkwon.Checked = false;

                        }
                        if (mat.direction == "1")
                        {
                            //下开卷
                            rbnDown.Checked = true;
                            rbnUp.Checked = false;
                            rbnUnkwon.Checked = false;
                        }
                        if (mat.direction == "2")
                        {
                            //未知
                            rbnDown.Checked = false;
                            rbnUp.Checked = false;
                            rbnUnkwon.Checked = true;
                        }
                        if (mat.PackageState)
                        {
                            rbnNo.Checked = false;
                            rbnYes.Checked = true;
                        }
                        else
                        {
                            rbnNo.Checked = true;
                            rbnYes.Checked = false;
                        }
                        txtCoilType.Text = mat.MatName;
                        txtresult.Text = "查询材料信息成功";
                        txtresult.BackColor = Color.Green;
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        txtresult.Text = "无材料信息";
                        txtresult.BackColor = Color.Red;
                        if (searchstr.Length > 10)
                        {
                            txtMatNo.Text = searchstr;
                        }
                        else
                        {
                            txtSaddleNo.Text = searchstr;
                        }

                    }

                }
                else
                {
                    txtresult.Text = "查询条件错误";
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

        private void txtSaddleNo_LostFocus(object sender, EventArgs e)
        {
            txtSaddleNo.Text = txtSaddleNo.Text.ToUpper();
        }

        #region
        /// <summary>
        /// 申请成功后 启用定时器 3秒查询材料新信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string matno=txtMatNo.Text.Trim();
                if(matno.Length>10)
                {
                    Prx.MatInfQuery(matno, out nResult, Program.ctx);
                    if (nResult == 100)
                    {
                        //开启定时器
                        timer1.Enabled = true;
                    }
                    else
                    {
                        txtresult.Text = "申请失败";
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
            timer1.Enabled = false;
        }


    }
}