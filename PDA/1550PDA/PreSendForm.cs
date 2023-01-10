using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PsionTeklogix.Barcode;
using System.Collections;
using System.Runtime;
using System.Runtime.InteropServices;

using System.Threading;
using System.IO;
using System.Reflection;
using Ice;
using PsionTeklogix.Keyboard;
using PsionTeklogix;
using PT;

namespace _1550PDA
{
    public partial class PreSendForm : Form
    {
        //扫描顺序为钢卷号->准发标签->麦头号
        PTInterfacePrx _Prx = null;
        public dtPTCommon _people;
        private string cID;
        private int nResult;
        private string cRetMessage;
        /// <summary>
        /// 麦头号 数据库该列不可为空
        /// 默认为1
        /// </summary>
        /// <param name="people"></param>
        /// <param name="Prx"></param>
        #region 构造函数
        public PreSendForm(dtPTCommon people,PTInterfacePrx Prx)
        {
            InitializeComponent();

            _Prx = Prx;
            _people = people;

        }
        #endregion

        #region 页面加载
        private void PreSendForm_Load(object sender, EventArgs e)
        {
            txtMatno.Focus();
        }
        #endregion

        #region 确定
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            try
            {
                string GjNo = txtMatno.Text.Trim();    //钢卷号
                string ZfNo = txtPresendno.Text.Trim();    //准发号
                string MT = txtMT.Text.Trim();
                //if (GjNo.Length!=11 || ZfNo.Length!=11||MT.Length!=11)
                if (GjNo.Length != 11 || ZfNo.Length != 11 )
                {
                    txtresult.Text = "扫描信息错误！";
                    txtresult.BackColor = Color.Red;
                    return;
                }
                _Prx.PreSend2L3(_people, GjNo, MT, ZfNo, out cID, out nResult);
                nResult = 100;
                if (nResult == -999)
                {
                    txtresult.Text = "电文发送失败！";
                    txtresult.BackColor = Color.Red;
                    return;
                }
                else
                {
                    txtresult.Text = "电文已成功发送！";
                    txtresult.BackColor = Color.Green;
                }

                Thread.Sleep(4000);

                //查询接口
                _Prx.CheckPreSend(_people, GjNo, out cRetMessage, out nResult);
                if (nResult == -999 || cRetMessage.Length == 0)
                {
                    txtresult.Text = "无数据记录";
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    if (nResult == 0)
                    {
                        txtresult.BackColor = Color.Green;
                        txtresult.Text = cRetMessage;
                    }
                    else
                    {
                        txtresult.BackColor = Color.Red;
                        txtresult.Text = cRetMessage;
                        MessageBox.Show(cRetMessage);
                    }
                }
            }
            catch (Ice.Exception ex)
            {
                ////player.PlaySync();

                txtresult.Text = "访问超时";
                txtresult.BackColor = Color.Red;
                Program.LogException(ex, false);
                return;
            }
            finally
            {
                txtMatno.Focus();
            }
        }
        #endregion

        #region 返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void txtPresendno_TextChanged(object sender, EventArgs e)
        {

            if (txtMatno.Text.Trim().Length == 11 && txtPresendno.Text.Trim().Length == 11)
            {
                btnConfirm_Click(null, null);
                txtMatno.Focus();
                //txtMT.Focus();
            }
               
        }

        private void txtMatno_TextChanged(object sender, EventArgs e)
        {
            if (txtMatno.Text.Trim().Length == 11)
            {
                txtPresendno.Focus();
            }
        }

        string cScanValue = string.Empty;
        private delegate void OnScanCompleteDelegate(object sender, PsionTeklogix.Barcode.ScanCompleteEventArgs e);

        private void PreSendForm_Activated(object sender, EventArgs e)
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
            if (txtMatno.Focused)
            {
                if (txtMatno.Text.ToUpper() != "S")
                {
                    txtMatno.Text = txtresult.Text = txtPresendno.Text = txtMT.Text = string.Empty;
                    txtresult.BackColor = Color.White;
                }
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

            //根据文本框选中状态判定扫描的是哪一个标签
            if (txtMatno.Focused)
            {
                if (tmp.Contains("S"))
                {
                    tmp = tmp.Replace("S", "");
                    txtMatno.Text = tmp;
                }
                else
                {
                    // 也可手工补一个S进去
                    if (txtMatno.Text.Contains("S") || txtMatno.Text.Contains("s"))
                    {
                        txtMatno.Text = tmp;
                    }
                }
            }
            else if (txtPresendno.Focused)
            {
                txtPresendno.Text = tmp;
            }
            else if (txtMT.Focused)
            {
                if (tmp.Contains("L"))
                {
                    tmp = tmp.Replace("L", "");
                    txtMT.Text = tmp;
                }
            }
        }
        #endregion

        #region 改变麦头号
        private void txtMT_TextChanged(object sender, EventArgs e)
        {
            //if (txtMatno.Text.Trim().Length ==11 && txtPresendno.Text.Trim().Length ==11&&txtMT.Text.Trim().Length==11)
            if (txtMatno.Text.Trim().Length == 11 && txtPresendno.Text.Trim().Length == 11 )
            {
                
                txtMatno.Focus();
            }
        }
        #endregion
    }
}