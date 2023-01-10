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
using System.Threading;
namespace _1550PDA
{
    public partial class InventoryForm : Form
    {
        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="_Truck"></param>
        public PT.PTInterfacePrx Prx = null;

        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        public InventoryForm(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            people = _people;
            Prx = _Prx;
            InitializeComponent();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            Inventory_Empty newform = new Inventory_Empty(people, Prx,"Empty");
            newform.ShowDialog();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Inventory_Check newform = new Inventory_Check(people, Prx, "CHECK");
            newform.ShowDialog();
        }

        private void btnCommon_Click(object sender, EventArgs e)
        {
            StockForm newform = new StockForm(people, Prx);
            newform.ShowDialog();
        }

        private void button_StockLock_Click(object sender, EventArgs e)
        {
            Inventory_Lock form = new Inventory_Lock(people, Prx, "Empty");
            form.ShowDialog();
        }
    }
}