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
    public partial class ModifyUserForm : Form
    {
        /// <summary>
        /// 公共ICE接口
        /// </summary>
        private PT.PTInterfacePrx Prx = null;
        /// <summary>
        /// 用户
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        public ModifyUserForm(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            InitializeComponent();
            people = _people;
            Prx = _Prx;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_GotFocus(object sender, EventArgs e)
        {

        }

        private void txtPassword_LostFocus(object sender, EventArgs e)
        {

        }

        private void txtUsername_LostFocus(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {

        }
    }
}