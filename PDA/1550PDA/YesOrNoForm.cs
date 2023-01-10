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
    public partial class YesOrNoForm : Form
    {        
        public YesOrNoForm()
        {
            InitializeComponent();
            label_Title.Text = "";
        }

        public YesOrNoForm(string msg)
        {
            InitializeComponent();
            label_Title.Text = msg;
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}