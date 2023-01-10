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

namespace _1550PDA
{
    public partial class CreatUserForm : Form
    {
        /// <summary>
        /// 公共ICE接口
        /// </summary>
        private PT.PTInterfacePrx Prx = null;
        /// <summary>
        /// 用户
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        public CreatUserForm(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            InitializeComponent();
            people = _people;
            Prx = _Prx;
        }
    }
}