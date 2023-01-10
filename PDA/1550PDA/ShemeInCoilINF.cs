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
    public partial class ShemeInCoilINF : Form
    {
        /// <summary>
        /// 材料号
        /// </summary>
        public string MatNo
        {
            get { return matno; }
        }
        private string matno = "";

        /// <summary>
        /// 是否卸下
        /// </summary>
        public bool IsUnload
        {
            get { return isunload; }
        }
        private bool isunload = true;

        /// <summary>
        /// 是否旋转带头
        /// </summary>
        public string FlagRotate
        {
            get { return flagRotate; }
        }
        // 0 不旋转 1 旋转
        private string flagRotate = "0";

        /// <summary>
        /// 槽号
        /// </summary>
        public string Groove
        {
            get { return groove; }
        }
        private string groove = "";

        /// <summary>
        /// 包装状态
        /// </summary>
        public bool Package
        {
            get { return package; }
        }
        private bool package = false;

        /// <summary>
        /// 套筒长度
        /// </summary>
        public string Sleeve
        {
            get { return sleeve; }
        }
        private string sleeve = "";
        /// <summary>
        /// 排
        /// </summary>
        public string Column
        {
            get { return column; }
        }
        private string column = "";
        private bool isMatFocus = false;
        private bool isGrooveFocus = false;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ShemeInCoilINF(string worktype, string theMatNo)
        {
            InitializeComponent();
            this.Activated += new EventHandler(ShemeInCoilINF_Activated);
            this.Closed += new EventHandler(ShemeInCoilINF_Closed);
            txtCoilNo.Text = theMatNo;
            //默认左排
            rbtLeft.Checked = true;
            rbtRight.Checked = false;
            column = "1";
            txtCoilNo.Focus();
            cbxIsUnload.Text = "是";
            isunload = true;
            cbxPackage.Text = "已包装";
            package = true;
            flagRotate="0";
        }
        /// <summary>
        /// 出库构造函数 只显示材料号一项
        /// </summary>
        public ShemeInCoilINF(string worktype)
        {
            InitializeComponent();
            this.Activated += new EventHandler(ShemeInCoilINF_Activated);
            this.Closed += new EventHandler(ShemeInCoilINF_Closed);
            label2.Visible = false;
           
            label4.Visible = false; 
            cbxIsUnload.Visible = false;
            cbxPackage.Visible = false;
            rbtLeft.Checked = true;
            rbtRight.Checked = false;
           
        }
        /// <summary>
        /// 修改材料时构造函数
        /// 出库不允许修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ShemeInCoilINF(MatterCls tmp)
        {
            try
            {
                InitializeComponent();
                //将材料信息显示
                //材料号不许改
                txtCoilNo.Text = tmp.matno;
                txtCoilNo.Enabled = false;
                if (tmp.isUnload)
                {
                    cbxIsUnload.Text = "是";
                }
                else
                {
                    cbxIsUnload.Text = "否";
                }
                
                string tmpgroove= tmp.InGroove;


                //从截取顺序和左右
                if (tmpgroove.Length >6)
                {
                    string SEQ = tmpgroove.Substring(4, 2);
                    txtGroove.Text=SEQ;
                    string tmpcol = tmpgroove.Substring(6, 1);
                    if (tmpcol == "1")
                    {
                        rbtLeft.Checked = true;
                        rbtRight.Checked = false;
                    }
                    else
                    {
                        rbtLeft.Checked = false;
                        rbtRight.Checked = true;
                    }
                }
                if (tmp.PackageState)
                {
                    cbxPackage.Text = "已包装";
                }
                else
                {
                    cbxPackage.Text = "未包装";
                }
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
            if (isMatFocus)
            {
                txtCoilNo.Text = tmp;
            }
            if (isGrooveFocus)
            {
                txtGroove.Text = tmp;
            }
        }
        #endregion

        private void txtCoilNo_GotFocus(object sender, EventArgs e)
        {
            isMatFocus = true;
           
        }

        private void txtGroove_GotFocus(object sender, EventArgs e)
        {
            isGrooveFocus = true;
        }

        private void txtGroove_LostFocus(object sender, EventArgs e)
        {
            isGrooveFocus = false;
        }

        private void txtCoilNo_LostFocus(object sender, EventArgs e)
        {
            isMatFocus = false;
        }

        private void txtCoilNo_TextChanged(object sender, EventArgs e)
        {
            matno = txtCoilNo.Text;
        }

        private void cbxIsUnload_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIsUnload.Text == "是")
            {
                isunload = true;
            }
            else
            {
                isunload = false;
            }
        }

        private void txtGroove_TextChanged(object sender, EventArgs e)
        {
            groove = txtGroove.Text;
        }

        private void cbxPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPackage.Text == "已包装")
            {
                package = true;
            }
            else
            {
                package = false;
            }
        }

     

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void rbtLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtLeft.Checked)
            {
                rbtRight.Checked = false;
                column = "1";
            }
            else
            {
                rbtRight.Checked = true;
                column = "3";
            }
        }

        private void rbtRight_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRight.Checked)
            {
                rbtLeft.Checked = false;
                column = "3";
            }
            else
            {
                rbtLeft.Checked = true;
                column = "1";
            }
        }

        private void checkBox_FlagRotate_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_FlagRotate.Checked)
                flagRotate = "-1";
            else
                flagRotate = "0";
        }
    }
}