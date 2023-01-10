using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PT;

namespace _1550PDA
{
    public partial class subFrmXZ : Form
    {
        string trainLineNO;

        public string TrainLineNO
        {
            get { return trainLineNO; }
        }

        string trainCaseNO;

        public string TrainCaseNO
        {
            get { return trainCaseNO; }
        }

        public subFrmXZ()
        {
            InitializeComponent();
        }
        //public subFrmXZ(dtPTCommon _people, PTInterfacePrx _Prx)
        //{
        //    InitializeComponent();

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbTrainLine.Text.Trim()=="" ||txtTrainCase.Text.Trim() =="")
            {
                MessageBox.Show("请指定车皮信息！"); return;
            }
            trainLineNO = cmbTrainLine.Text;
            trainCaseNO = txtTrainCase.Text;
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            trainLineNO = "";
            trainCaseNO = "";
            this.Close();
        }

        private void txtTrainCase_TextChanged(object sender, EventArgs e)
        {
            if (txtTrainCase.Text.Length== 7)
            {
                txtTrainCase.BackColor = Color.Green;
            }
            else
            {
                txtTrainCase.BackColor = Color.White;
            }
        }
    }
}