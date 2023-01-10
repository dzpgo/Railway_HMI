using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONTROLS_OF_PREMIERE
{
    public partial class FrmPassword : Form
    {
        const string passWord = "321";
        public bool isAllow = false;
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text .Length != passWord.Length)
            {
                return;
            }
            if (txtPassword.Text == passWord)
            {
                isAllow = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }
    }
}
