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
    public partial class UserManagerForm : Form
    {
        /// <summary>
        /// 公共ICE接口
        /// </summary>
        private PT.PTInterfacePrx Prx = null;
        /// <summary>
        /// 用户
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        public UserManagerForm()
        {
            InitializeComponent();
        }
        public UserManagerForm(dtPTCommon _people, PTInterfacePrx _Prx)
        {
            InitializeComponent();
            people = _people;
            Prx = _Prx;
        }
        private void btnCreatUser_Click(object sender, EventArgs e)
        {
            CreatUserForm newForm = new CreatUserForm(people,Prx);
            newForm.ShowDialog();
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            ModifyUserForm newForm = new ModifyUserForm(people, Prx);
            newForm.ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUserForm newForm = new DeleteUserForm(people, Prx);
            newForm.ShowDialog();
        }
    }
}