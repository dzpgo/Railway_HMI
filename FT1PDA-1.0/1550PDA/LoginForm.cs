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
    public partial class LoginForm : Form
    {
        /// <summary>
        /// 接口各返回值
        /// </summary>
        private string cID;
        private int nRet;
        private int nResult;
        /// <summary>
        /// 密码暗码显示
        /// </summary>
        private string UnSeePassword = "";
        /// <summary>
        /// 密码明码显示
        /// </summary>
        private string Password = "";
        /// <summary>
        /// 公共ICE接口
        /// </summary>
        private PT.PTInterfacePrx Prx = null;
        /// <summary>
        /// 用户
        /// </summary>
        private dtPTCommon people = new dtPTCommon();
        /// <summary>
        /// 通讯实例
        /// </summary>
        Ice.Communicator comm = null;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("PDA");

        public LoginForm()
        {
            InitializeComponent();
        }

        #region ICE初始化 获取手持机IP后三位作为编号
        /// <summary>
        /// ICE初始化 获取手持机IP后三位作为编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                //本机IP号后三位，作为手持机编号
                string hostName = System.Net.Dns.GetHostName();
                System.Net.IPHostEntry localhost = System.Net.Dns.GetHostEntry(hostName);
                System.Net.IPAddress IP = localhost.AddressList[0];
                people.PTID = IP.ToString().Substring(IP.ToString().Length - 3, 3);

                // 载入配置
                Ice.InitializationData initData = new Ice.InitializationData();
                initData.properties = Ice.Util.createProperties();
                initData.properties.load(Program.Location + "\\config.txt");
                comm = Ice.Util.initialize(initData);

                // 本机IP隐式传递
                Program.ctx["IP_ADDR"] = IP.ToString();
                // comm传递
                Program.g_comm = comm;

                // 手持机接口
                Ice.ObjectPrx myprx = comm.propertyToProxy("PDA.Proxy");
                Prx = PT.PTInterfacePrxHelper.uncheckedCast(myprx);
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, false);
                txtresult.Text = "访问超时";
                txtresult.BackColor = Color.Red;
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录 显示登录结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //首先验证输入信息正确性
                if (people.Operator.Length == 0 || people.StoreID == null || Password.Length == 0)
                {
                    txtresult.Text = "用户信息不全";
                    txtresult.BackColor = Color.Red;
                    return;
                }

                // 选择的库区和登录用户，隐式传递
                Program.ctx["USER_ID"] = people.Operator;
                Program.ctx["YARD_NO"] = people.StoreID;

                //用户登录 根据返回结果显示
                Prx.UsrLoginCheck(people, Password, out cID, out nRet, out nResult, Program.ctx);
                if (nResult == -999)
                {
                    txtresult.Text = "登录失败";
                    txtresult.BackColor = Color.Red;
                }
                else
                {
                    if (nRet == 0)
                    {
                        //登录成功 赋用户权限
                        people.Privilege = cID;
                        txtresult.Text = "登录成功";
                        txtresult.BackColor = Color.Green;
                        people.Shift = "A";
                        people.Crew = "D";

                        // 登录成功，获取服务器时间进行同步
                        long secTicks = Prx.getSecTicksSinceUTC1970();
                        DateTime datetime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        datetime = datetime.AddSeconds(secTicks).ToLocalTime();
                        System.Diagnostics.Process.Start("cmd.exe", "/c date " + datetime.ToShortDateString());
                        System.Diagnostics.Process.Start("cmd.exe", "/c time " + datetime.ToShortTimeString());

                        MainForm newform = new MainForm(people, Prx);
                        newform.ShowDialog();

                        txtPassword.Text = "";
                    }
                    if (nRet == -1)
                    {
                        txtresult.Text = "密码错误";
                        txtresult.BackColor = Color.Red;
                    }
                    if (nRet == -2)
                    {
                        txtresult.Text = "用户不存在";
                        txtresult.BackColor = Color.Red;
                    }
                }
            }
            catch (Ice.Exception ex)
            {
                Program.LogException(ex, false);
                txtresult.Text = "访问超时";
                txtresult.BackColor = Color.Red;
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }
        }
        #endregion
        #region 用户名文本框失去焦点，people.Operator赋值
        /// <summary>
        /// 用户名文本框失去焦点，people.Operator赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsername_LostFocus(object sender, EventArgs e)
        {
            people.Operator = txtUsername.Text;
        }
        #endregion

        #region 密码文本框获得焦点，显示密码明码 同时清空自动关闭定时器时间
        /// <summary>
        /// 密码文本框获得焦点，显示密码明码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_GotFocus(object sender, EventArgs e)
        {
            txtPassword.Text = Password;
        }
        #endregion

        #region 密码文本框失去焦点，显示密码暗码
        /// <summary>
        /// 密码文本框失去焦点，显示密码暗码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_LostFocus(object sender, EventArgs e)
        {
            //首先暗码清空
            UnSeePassword = "";
            //根据密码长度写暗码
            if (Password != null)
            {
                for (int i = 0; i < Password.Length; i++)
                {
                    UnSeePassword += "*";
                }
            }
            txtPassword.Text = UnSeePassword;
        }
        #endregion

        #region 密码文本改变，people.password赋值
        /// <summary>
        ///  密码文本改变，people.password赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            //密码显示不为暗码时,更新people.password
            if (txtPassword.Text != UnSeePassword)
            {
                Password = txtPassword.Text;
            }
        }
        #endregion

        #region 退出程序
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            comm.destroy();
            this.Close();
        }
        #endregion

        #region 用户选择库区
        /// <summary>
        /// 用户选择库区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxStoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            people.StoreID = cbxStoreID.Text;
           
        }
        #endregion

        private void btnManagerLogin_Click(object sender, EventArgs e)
        {
            UserManageForm newForm = new UserManageForm();
            newForm.ShowDialog();
        }



    }
}