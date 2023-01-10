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

namespace _1550PDA
{
    public partial class ManualScanForm : Form
    {
        private LocalScanInfo localScanInfo = null;
        public LocalScanInfo InputedScanInfo
        {
            get { return localScanInfo; }
        }

        public ManualScanForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 库位不能为空
            if (textBox_StockNo.Text.Trim().Length == 0)
            {
                label_StockNo.ForeColor = Color.Red;
                return;
            }

            localScanInfo = new LocalScanInfo(textBox_StockNo.Text.ToUpper(), textBox_MatNo.Text.ToUpper());
            DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void textBox_StockNo_TextChanged(object sender, EventArgs e)
        {
            if (textBox_StockNo.Text.Length != 0)
                label_StockNo.ForeColor = SystemColors.ControlText;
        }
    }
}