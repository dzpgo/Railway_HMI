using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;

namespace HMI_OF_REPOSITORIES
{
    public partial class SubFrmUserLogin : Form
    {
        public SubFrmUserLogin()
        {
            InitializeComponent();
        }
        bool allowLogin = false;

        public bool AllowLogin
        {
            get { return allowLogin; }
            set { allowLogin = value; }
        }
        DialogResult dialogResultLogin;

        public DialogResult DialogResultLogin
        {
            get { return dialogResultLogin; }
            set { dialogResultLogin = value; }
        }
        private string userName ="";

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                userName = txtUserName.Text.Trim();
                string password =txtPassword.Text.Trim();
                string sql = @"SELECT PRIORITY FROM UACS_USER_INF WHERE USERID = '" + userName + "' AND PASSWORD ='" + password + "'";

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        DialogResultLogin = DialogResult.OK;
                        AllowLogin = true; 
                    }
                    else
                    {
                        DialogResultLogin = DialogResult.No;
                        AllowLogin = false;
                    }
                }
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResultLogin = DialogResult.Cancel;
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string UpTem = txtUserName.Text;
            txtUserName.Text = UpTem.ToUpper().Trim();
            txtUserName.SelectionStart = txtUserName.Text.Length;
            txtUserName.SelectionLength = 0;
        }


        private void SubFrmUserLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                btnConfirm_Click(null, null);
            }
        }
    }
}
