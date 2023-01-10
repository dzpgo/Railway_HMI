using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PsionTeklogix.Barcode;
using Ice;
using PsionTeklogix.Keyboard;
using PsionTeklogix;
using PT;


namespace _1550PDA
{
    public partial class xiaozhang : Form
    {
        private int isInOper = 1;
        private string matNoForL3Acking = "";
        public PTInterfacePrx _Prx = null;
        public dtPTCommon _people;

        public xiaozhang()
        {
            InitializeComponent();
        }

        public xiaozhang(PTInterfacePrx Prx, dtPTCommon people)
        {
            InitializeComponent();
            txtID.Text = people.Operator;
            txtDevice.Text = people.PTID;
            _Prx = Prx;
            _people = people;
            this.Load+=new EventHandler(xiaozhang_Load);
            this.Closed += new EventHandler(xiaozhang_Closed);
        }

        private void xiaozhang_Load(object sender, EventArgs e)
        {
            txtMAT.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIn.Checked == true)
            {
                isInOper = 0;
            }
            else if (rbtnOut.Checked == true)
            {
                isInOper = 1;
            }
            else if (rbtnSmall.Checked == true)
            {
                isInOper = 2;
            }
            else if (rbtnInvent.Checked == true)
            {
                isInOper = 3;
            }
            txtMAT.Text = txtSite.Text = string.Empty;
            txtMAT.Focus();
        }

        private void rbtnIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIn.Checked == true)
            {
                isInOper = 0;
            }
            else if (rbtnOut.Checked == true)
            {
                isInOper = 1;
            }
            else if (rbtnSmall.Checked == true)
            {
                isInOper = 2;
            }
            else if (rbtnInvent.Checked == true)
            {
                isInOper = 3;
            }
            txtMAT.Text = txtSite.Text = string.Empty;
            txtMAT.Focus();
        }

        private void rbtnSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIn.Checked == true)
            {
                isInOper = 0;
            }
            else if (rbtnOut.Checked == true)
            {
                isInOper = 1;
            }
            else if (rbtnSmall.Checked == true)
            {
                isInOper = 2;
            }
            else if (rbtnInvent.Checked == true)
            {
                isInOper = 3;
            }
            txtMAT.Text = txtSite.Text = string.Empty;
            txtMAT.Focus();
        }

        private void radioInvent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIn.Checked == true)
            {
                isInOper = 0;
            }
            else if (rbtnOut.Checked == true)
            {
                isInOper = 1;
            }
            else if (rbtnSmall.Checked == true)
            {
                isInOper = 2;
            }
            else if (rbtnInvent.Checked == true)
            {
                isInOper = 3;
            }
            txtMAT.Text = txtSite.Text = string.Empty;
            txtMAT.Focus();
        }

        private delegate void OnScanCompleteDelegate(object sender, PsionTeklogix.Barcode.ScanCompleteEventArgs e);


        private void xiaozhang_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }

        #region   void ScannerHelper_ScanCompleteEvent(object sender, ScanCompleteEventArgs e)  扫描完成事件
        /// <summary>
        /// 扫描完成事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        void ScannerHelper_ScanCompleteEvent(object Sender, ScanCompleteEventArgs e)
        {
            if (txtMAT.Focused)
            {
                //txtMAT.TextChanged-=new EventHandler(txtMAT_TextChanged);
                //txtSite.TextChanged-=new EventHandler(txtSite_TextChanged);

                txtMAT.Text = txtresult.Text = txtSite.Text = string.Empty;
                txtresult.BackColor = Color.White;

                //txtMAT.TextChanged+=new EventHandler(txtMAT_TextChanged);
                //txtSite.TextChanged+=new EventHandler(txtSite_TextChanged);
            }
            //if (InvokeRequired)
            //{
            //    BeginInvoke(new OnScanCompleteDelegate(ScannerHelper_ScanCompleteEvent),
            //        new object[] { Sender, e });
            //    return;
            //}

            string tmp = e.Text.Trim();
            if (tmp.Contains("S"))
            {
                tmp = tmp.Replace("S", "");
            }
            if (tmp.Contains("-"))
            {
                tmp = tmp.Replace("-", "");
            }
            if (tmp.Length>12)
            {
                tmp = tmp.Substring(0, 12);
            }
            if (txtMAT.Focused)
                txtMAT.Text = tmp;
            else if (txtSite.Focused)
                txtSite.Text = tmp;
        }
        #endregion

        private void txtMAT_TextChanged(object sender, EventArgs e)
        {
            if (txtMAT.Text.Trim().Length > 10)
            {
                if (isInOper == 0 || isInOper == 3)
                {
                    txtSite.Focus();
                }
                else
                {
                    SendInfo();
                }
            }
        }

        private void txtSite_TextChanged(object sender, EventArgs e)
        {
            if (txtSite.Text.Trim().Length>=8)
            {
                SendInfo();
            }
        }

        private void SendInfo()
        {
            try
            {
                if (txtMAT.Text.Trim().Length == 0)
                    return;

                if (txtMAT.Text.Trim().Length < 10)
                {
                    MessageBox.Show("材料号不正确");
                    txtMAT.Text = txtSite.Text = string.Empty;

                    return;
                }
                else if (isInOper==0 && txtSite.Text.Trim().Length < 8 && txtSite.Text.Trim().Length !=0)
                {
                    MessageBox.Show("入库作业请输入正确库区号");
                    txtMAT.Text = txtSite.Text = string.Empty;

                    return;
                }
                else if (isInOper == 3 && txtSite.Text.Trim().Length < 8 && txtSite.Text.Trim().Length != 0)
                {
                    MessageBox.Show("盘库作业请输入正确库区号");
                    txtMAT.Text = txtSite.Text = string.Empty;

                    return;
                }
                else
                {
                    string strMAT = txtMAT.Text.Trim();
                    string strStock = txtSite.Text.Trim().ToUpper();
                    string stock = "";
                    if (strStock.Contains("Z"))
                    {
                        stock = BarcodeFormater.JudgeStockFormat1550(strStock);
                    }
                    else if (strStock.Contains("FT"))
                    {
                        stock = BarcodeFormater.JudgeStockFormatFT11(strStock);
                    }
                    //string unitno = txtSite.Text.Trim().ToUpper();
                    //string store = "";
                    //string row = "";
                    //string col = "";
                    //string layer = "1";
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
                    if (isInOper == 0 || isInOper == 3)
                    {
                        if (stock.Length == 0)
                        {
                            return;
                        }
                    }
                    string strID = txtID.Text.Trim().ToUpper();
                    string strDevice = txtDevice.Text.Trim().ToUpper();

                    string tagValue = "";
                    string cRetMessage = "";

                    if (isInOper == 0)
                    {
                        _people.sqare1 = stock;
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
                        _people.sqare1 = stock;
                        tagValue = strMAT + "|" + stock + "|" + strDevice + "|" + strID;
                    }
                    _Prx.MatInOut(isInOper.ToString(), tagValue, out cRetMessage);
                    if (cRetMessage == "fail")
                    {
                        txtresult.Text = "发送失败";
                        txtresult.BackColor = Color.Red;
                    }
                    else
                    {
                        txtresult.Text = "发送成功";
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtMAT.Focus();
            }

            // 等待定时器开启刷新
            matNoForL3Acking = txtMAT.Text;
            timer_RefreshL3Ack.Enabled = true;
        }

        private void txtMAT_Validated(object sender, EventArgs e)
        {
        }

        private void xiaozhang_Closed(object sender, EventArgs e)
        {
            ScannerHelper.ScannerDestroy();
        }

        private void timer_RefreshL3Ack_Tick(object sender, EventArgs e)
        {
            string cRetMessage = "";
            
            // 读取结果
            int nResult = _Prx.MatInOutAckSearch(_people, matNoForL3Acking, isInOper.ToString(), out cRetMessage);
            if (nResult == 0)
            {
                // 只刷新1次
                timer_RefreshL3Ack.Enabled = false;

                txtresult.BackColor = Color.Green;
                if (isInOper == 0)
                {
                    txtresult.Text = "入库扫描成功";
                }
                else if (isInOper == 1 || isInOper == 2)
                {
                    txtresult.Text = "出库扫描成功";
                }
                else if (isInOper == 3)
                {
                    txtresult.Text = "盘库扫描成功";
                }
            }
            else if (nResult == -1)
            {
                //txtresult.BackColor = Color.Red;
                //txtresult.Text = cRetMessage;
            }
            else
            {
                // 只刷新1次
                timer_RefreshL3Ack.Enabled = false;
                
                // 
                txtresult.BackColor = Color.Red;
                // 分行显示
                //int nLineTextLength = 15;
                //if (cRetMessage.Length > nLineTextLength)
                //{
                //    txtresult.Text = cRetMessage.Substring(0, nLineTextLength);
                //    txtresult.Text += "\r\n";
                //    txtresult.Text += cRetMessage.Substring(nLineTextLength);
                //}
                //else
                {
                    txtresult.Text = cRetMessage;
                }
            }
        }

    }
}