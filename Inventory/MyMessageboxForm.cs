using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    public partial class MyMessageboxForm : Form
    {
        private const string password = "123abc";

        public MyMessageboxForm()
        {
            InitializeComponent();
        }

        public string StockNo
        {
            set
            {
                label_StockNo.Text = value;
            }
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if (textBox_Password.Text != password)
            {
                MessageBox.Show("密码不正确!");
                return;
            }

            DialogResult = DialogResult.Yes;
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
