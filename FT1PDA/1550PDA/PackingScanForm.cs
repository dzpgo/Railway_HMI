using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using PsionTeklogix.Keyboard;
using PsionTeklogix;
using PsionTeklogix.Barcode;
using CLTS;
using System.Threading;

namespace _1550PDA
{
    public partial class PackingScanForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("PDA");

        public PackingScanForm()
        {
            InitializeComponent();
            label_SubmitResult.Text = "";
        }

        private void PackingScanForm_Load(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            ScanedEnd(textBox_StockNo.Text, textBox_MatNo.Text);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PackingScanForm_Closed(object sender, EventArgs e)
        {
            ScannerHelper.ScannerDestroy();
        }

        #region void ScannerHelper_ScanCompleteEvent(object sender, ScanCompleteEventArgs e)  扫描完成事件

        // 委托
        private delegate void OnScanCompleteDelegate(object sender, ScanCompleteEventArgs e);

        /// <summary>
        /// 扫描完成事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        /// 
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
                log.Debug(String.Format("扫描条码{0}", tmp));

                if (BarcodeFormater.IsStockBarCode(tmp))
                {
                    // 扫描到库位号
                    string stockNo;

                    // 库位号清空
                    label_StockNo.ForeColor = SystemColors.WindowText;
                    textBox_StockNo.Text = "";

                    // 材料号清空
                    label_MatNo.ForeColor = SystemColors.WindowText;
                    textBox_MatNo.Text = "";

                    // 提示信息清空
                    label_SubmitResult.Text = "";
                    label_SubmitResult.ForeColor = SystemColors.WindowText;

                    log.Debug("2");

                    if (BarcodeFormater.parseStockBarCode(tmp, out stockNo))
                    {

                        log.Debug("3");

                        // 扫描到库位号显示
                        textBox_StockNo.Text = stockNo;

                        // 等待扫描材料号
                        textBox_MatNo.Focus();
                    }
                    else
                    {
                        label_SubmitResult.Text = String.Format("{0} 库位条码{1}, 格式非法", DateTime.Now.ToShortTimeString(), tmp);
                        label_SubmitResult.ForeColor = Color.Red;

                        // 库位号颜色突出显示
                        label_StockNo.ForeColor = Color.Red;

                        // 等待扫描库位号
                        textBox_StockNo.Focus();
                    }
                }
                else
                {
                    // 扫描到材料号

                    // 材料号清空
                    label_MatNo.ForeColor = SystemColors.WindowText;
                    textBox_MatNo.Text = "";

                    // 提示信息清空
                    label_SubmitResult.Text = "";
                    label_SubmitResult.ForeColor = SystemColors.WindowText;

                    if (textBox_StockNo.Text.Length == 0)
                    {
                        textBox_StockNo.Focus();

                        label_SubmitResult.Text = String.Format("{0} 请先扫描库位条码", DateTime.Now.ToShortTimeString());
                        label_SubmitResult.ForeColor = Color.Red;
                        return;
                    }
                    else
                    {
                        // 扫描到材料号显示
                        textBox_MatNo.Text = tmp;

                        // 提交扫描结果
                        ScanedEnd(textBox_StockNo.Text, textBox_MatNo.Text);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, false);

                // 显示报错
                label_SubmitResult.Text = String.Format("{0} {1}", DateTime.Now.ToShortTimeString(), ex.Message);
                label_SubmitResult.ForeColor = Color.Red;
            }
        }
        #endregion

        private void ScanedEnd(string stockNo, string matNo)
        {
            stockNo = stockNo.Trim();
            matNo = matNo.Trim();

            if (stockNo.Length == 0)
            {
                DisplaySubmitResult("扫描库位为空", false);
                label_StockNo.ForeColor = Color.Red;
            }
            else if (BarcodeFormater.IsManuPackingStockNo(stockNo))
            {
                DisplaySubmitResult("库位不是离线包装", false);
                label_StockNo.ForeColor = Color.Red;
            }
            else if (matNo.Length == 0)
            {
                DisplaySubmitResult("材料号为空", false);
                label_StockNo.ForeColor = Color.Red;
            }
            else
            {
                SetControlTextWithColor(label_SubmitResult, "正在提交扫描记录......", true);

                ClsPackingScanSubmit clsPackingScanSubmit = new ClsPackingScanSubmit(stockNo, matNo, DisplaySubmitResult);
                Thread threadSubmit = new Thread(new ThreadStart(clsPackingScanSubmit.Submit));
                threadSubmit.IsBackground = true;
                threadSubmit.Start();
            }
        }

        private void DisplaySubmitResult(string message, bool bResult)
        {
            if (bResult)
            {
                // 提交成功,清空原提交数据

                // 库位号清空
                label_StockNo.ForeColor = SystemColors.WindowText;
                textBox_StockNo.Text = "";

                // 材料号清空
                label_MatNo.ForeColor = SystemColors.WindowText;
                textBox_MatNo.Text = "";
            }
            SetControlTextWithColor(label_SubmitResult, message, bResult);
        }

        private delegate void DelgSetControlTextWithColor(Control control, string text, bool bRedText);
        private void SetControlTextWithColor(Control control, string text, bool bRedText)
        {
            if (control.InvokeRequired)
            {
                BeginInvoke(new DelgSetControlTextWithColor(SetControlTextWithColor),new object[] { control, text, bRedText });
                return;
            }

            // 提示文字
            control.Text = String.Format("{0} {1}", DateTime.Now.ToShortTimeString(), text);

            // 提示颜色
            if (!bRedText)
                control.ForeColor = Color.Red;
            else
                control.ForeColor = SystemColors.WindowText;
        }
    }
}