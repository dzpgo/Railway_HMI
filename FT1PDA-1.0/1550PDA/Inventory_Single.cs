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
    public partial class Inventory_Single : Form
    {
        bool isInOper = false;
        public PTInterfacePrx Prx = null;
        public dtPTCommon _people;

        public Inventory_Single()
        {
            InitializeComponent();
        }

        public Inventory_Single(PTInterfacePrx _Prx, dtPTCommon people)
        {
            InitializeComponent();
            txtID.Text = people.Operator;
            txtDevice.Text = people.PTID;
            Prx = _Prx;
            _people = people;
            this.Load += new EventHandler(Inventory_Single_Load);
            btnExit.Click+=new EventHandler(btnExit_Click);
            txtMAT.TextChanged+=new EventHandler(txtMAT_TextChanged);
            txtSite.TextChanged+=new EventHandler(txtSite_TextChanged);
            this.Activated+=new EventHandler(Inventory_Single_Activated);
            this.Closed += new EventHandler(Inventory_Single_Closed);
        }

        private void Inventory_Single_Load(object sender, EventArgs e)
        {
            txtMAT.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private delegate void OnScanCompleteDelegate(object sender, PsionTeklogix.Barcode.ScanCompleteEventArgs e);

        private void Inventory_Single_Activated(object sender, EventArgs e)
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
                txtMAT.Text = txtresult.Text = txtSite.Text = string.Empty;
                txtresult.BackColor = Color.White;
            }
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
            if(txtMAT.Text.Trim().Length>10)
                txtSite.Focus();
        }

        private void txtSite_TextChanged(object sender, EventArgs e)
        {
            
            if (txtSite.Text.Length > 9)
            {
                SendInfo();
            }
        }

        private void SendInfo()
        {
            try
            {
                if (txtSite.Text.Trim().Length == 0 || txtMAT.Text.Trim().Length == 0)
                    return;
                if (txtMAT.Text.Trim().Length < 11)
                {
                    MessageBox.Show("材料号不正确");
                    txtMAT.Text = txtSite.Text = string.Empty;
                    return;
                }
                else if (txtSite.Text.Trim().Length < 10 && txtSite.Text.Trim().Length != 0)
                {
                    MessageBox.Show("输入正确库区号");
                    txtMAT.Text = txtSite.Text = string.Empty;

                    return;
                }
                else
                {
                    string strMAT = txtMAT.Text.Trim();
                    string strSite = txtSite.Text.Trim().ToUpper();
                    //if (strSite.Length == 8)
                    //{
                    //    strSite = strSite.Substring(0, 3) + "0" + strSite.Substring(3, 2) + "0" + strSite.Substring(5, 3);
                    //}
                    string strID = txtID.Text.Trim().ToUpper();
                    string strDevice = txtDevice.Text.Trim().ToUpper();
                    int nResult = 0;
                    List<MatterCls> sendlist=new List<MatterCls>();
                    MatterCls tmp=new MatterCls();
                    tmp.matno=strMAT;
                    dtUnit unit=new dtUnit();
                    unit.UnitNo=strSite;
                    tmp.stcUnit=unit;
                    sendlist.Add(tmp);
                    Prx.StockInfSumbit("ALL", _people, sendlist.ToArray(), out nResult, Program.ctx);

                    if (nResult == -999)
                    {
                        txtresult.Text = "发送失败";
                    }
                    else
                    {
                        txtresult.Text = "发送成功";
                    }
                   
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            finally
            {
                txtMAT.Focus();
            }

            //System.Threading.Thread.Sleep(5000);
            //txtMAT.Text = txtSite.Text = txtresult.Text = string.Empty;
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SendInfo();
        }

        private void Inventory_Single_Closed(object sender, EventArgs e)
        {
            ScannerHelper.ScannerDestroy();
        }


    }
}