using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _1550PDA
{
    public partial class cityFrm : Form
    {
        public string city = "";
        public cityFrm()
        {
            InitializeComponent();
        }
        private void btnCity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            city = btn.Text;
            this.Close();
        }
    }
}