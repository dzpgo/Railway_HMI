using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PT;
using System.Threading;
using System.IO;
using System.Reflection;

namespace _1550PDA
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 公共ICE接口
        /// </summary>
        private PT.PTInterfacePrx Prx = null;
        /// <summary>
        /// 用户
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        public MainForm(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            InitializeComponent();
            people = _people;
            Prx = _Prx;
        }

        private void btnShemeIn_Click(object sender, EventArgs e)
        {
            ShemeInTruck newform = new ShemeInTruck(people, Prx);
            newform.ShowDialog();
        }

        private void btnPreSearch_Click(object sender, EventArgs e)
        {
            PreSendForm newform=new PreSendForm(people ,Prx);
            newform.ShowDialog();
        }

        private void btnCoilINFSearch_Click(object sender, EventArgs e)
        {
            MatInf newform = new MatInf(people, Prx);
            newform.ShowDialog();
        }

        private void btnStockINF_Click(object sender, EventArgs e)
        {
            StockForm newform = new StockForm(people, Prx);
            newform.ShowDialog();
          
        }

        private void btnInventorysingle_Click(object sender, EventArgs e)
        {

            Inventory_Single newform = new Inventory_Single(Prx,people);
            newform.ShowDialog();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlanSearch_Click(object sender, EventArgs e)
        {
            ShemeOutSearch newform = new ShemeOutSearch(people, Prx);
            newform.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm newform = new InventoryForm(people, Prx);
            newform.ShowDialog();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            xiaozhang form = new xiaozhang(Prx, people);
            form.ShowDialog();
        }

        private void button_PackingScan_Click(object sender, EventArgs e)
        {
            PackingScanForm form = new PackingScanForm();
            form.ShowDialog();
        }
    }
}
