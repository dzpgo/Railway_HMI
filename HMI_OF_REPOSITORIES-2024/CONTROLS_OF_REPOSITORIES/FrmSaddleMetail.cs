using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;
using UACSUtility;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class FrmSaddleMetail : Form
    {
        private Baosight.iSuperframe.Authorization.Interface.IAuthorization auth;

        private SaddleBase saddleInfo = new SaddleBase();

        public SaddleBase SaddleInfo
        {
            get { return saddleInfo; }
            set { saddleInfo = value; }
        }

        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }
                }
                return dbHelper;
            }
        }
        #endregion

        private const string strPassWord = "123456";

        public FrmSaddleMetail()
        {
            InitializeComponent();
            this.Load += FrmSaddleMetail_Load;
        }
       
        void FrmSaddleMetail_Load(object sender, EventArgs e)
        {
            //auth = FrameContext.Instance.GetPlugin<IAuthorization>() as IAuthorization;
            //this.Deactivate += new EventHandler(frmSaddleDetail_Deactivate);
            txtSaddleNo.Text = saddleInfo.SaddleNo;
            txtSaddleName.Text = saddleInfo.SaddleName;
            txtCoilNo.Text = saddleInfo.Mat_No;
            txtXCenter.Text = saddleInfo.X_Center.ToString();
            txtYCenter.Text = saddleInfo.Y_Center.ToString();
            txtZCenter.Text = saddleInfo.Z_Center.ToString();
            label6.Text = saddleInfo.Row_No.ToString() + "-" + saddleInfo.Col_No.ToString();
            

            #region 转换状态
            switch (saddleInfo.Stock_Status)
            {
                case 0:
                    txtStatus.Text = "无卷";
                    break;
                case 1:
                    txtStatus.Text = "预定";
                    break;
                case 2:
                    txtStatus.Text = "占用";
                    break;
                default:
                    txtStatus.Text = "无";
                    break;
            }
            switch (saddleInfo.Lock_Flag)
            {
                case 0:
                    txtflag.Text = "可用";
                    break;
                case 1:
                    txtflag.Text = "待判";
                    break;
                case 2:
                    txtflag.Text = "封锁";
                    break;
                default:
                    txtflag.Text = "无";
                    break;
            } 
            #endregion

            //AuthorityManagement authority = new AuthorityManagement();
            //if (authority.isUserJudgeEqual("D308", "D202", "scal", "D212"))
            //{
            //    btnCoilMessage.Visible = false;
            //    txtMatNo.Visible = false;
            //    btnUpStockByCoil.Visible = false;
            //    btnByNoCoil.Visible = false;
            //    btnByReserve.Visible = false;
            //    btnByOccupy.Visible = false;
            //    btnNoCoilByUsable.Visible = false;
            //    btnByUsable.Visible = false;
            //    btnByStay.Visible = false;
            //    btnByBlock.Visible = false;
            //    label7.Visible = false;
            //    txtPassWord.Visible = false;
            //    txtPopupMessage.Visible = false;
            //}

        }

        void frmSaddleDetail_Deactivate(object sender, EventArgs e)
        {
            try
            {
                //this.Close();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 更新钢卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpStockByCoil_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string coilNo = txtMatNo.Text.Trim();
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET MAT_NO = '" + coilNo + "',STOCK_STATUS = 2,LOCK_FLAG = 0,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "已添加钢卷" + coilNo;
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
            }
            catch (Exception er)
            {
                txtPopupMessage.Text = er.Message;
            }
        }
        /// <summary>
        /// 库位无卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByNoCoil_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 0,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "状态已无卷";
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
            }
            catch (Exception er)
            {
                txtPopupMessage.Text = er.Message;
            }
        }
        /// <summary>
        /// 库位预定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 1,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "状态已预定";
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
            }
            catch (Exception er)
            {

                txtPopupMessage.Text = er.Message;
            }
        }

        /// <summary>
        /// 库位占用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByOccupy_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 2,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "状态已占用";
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
               
            }
            catch (Exception er)
            {

                txtPopupMessage.Text = er.Message;
            }
        }

        /// <summary>
        /// 库位可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByUsable_Click(object sender, EventArgs e)
        {
            try
            {
                #region 用户信息确认
                //用户信息确认
                UACSUtility.SubFrmUserLogin form = new SubFrmUserLogin();
                form.ShowDialog();
                if (form.DialogResultLogin == DialogResult.Cancel)
                {
                    return;
                }
                if (!form.AllowLogin)
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                } 
                #endregion
                //if (txtPassWord.Text == strPassWord)
                //{
                string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET LOCK_FLAG = 0,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                DBHelper.ExecuteNonQuery(sql);
                txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "标记已可用";
                UACSUtility.HMILogger.WriteLog(btnByUsable.Text, "库位" + saddleInfo.SaddleNo + "标记为可用 ,用户：" + form.UserName, UACSUtility.LogLevel.Info, this.Text);
                //}
                //else
                //    txtPopupMessage.Text = "输入密码错误！！！";
            }
            catch (Exception er)
            {

                txtPopupMessage.Text = er.Message;
            }
        }

        /// <summary>
        /// 库位待判
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByStay_Click(object sender, EventArgs e)
        {
            try
            {
                #region 用户信息确认
                //用户信息确认
                UACSUtility.SubFrmUserLogin form = new SubFrmUserLogin();
                form.ShowDialog();
                if (form.DialogResultLogin == DialogResult.Cancel)
                {
                    return;
                }
                if (!form.AllowLogin)
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                #endregion
                //if (txtPassWord.Text == strPassWord)
                //{
                string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET LOCK_FLAG = 1,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                DBHelper.ExecuteNonQuery(sql);
                txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "标记已待判";
                UACSUtility.HMILogger.WriteLog(btnByStay.Text, "库位" + saddleInfo.SaddleNo + "标记为待判 ,用户：" + form.UserName, UACSUtility.LogLevel.Info, this.Text);
                //}
                //else
                //    txtPopupMessage.Text = "输入密码错误！！！";
                
            }
            catch (Exception er)
            {

                txtPopupMessage.Text = er.Message;
            }
        }
        /// <summary>
        /// 库位封锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByBlock_Click(object sender, EventArgs e)
        {
            try
            {
                #region 用户信息确认
                //用户信息确认
                UACSUtility.SubFrmUserLogin form = new SubFrmUserLogin();
                form.ShowDialog();
                if (form.DialogResultLogin == DialogResult.Cancel)
                {
                    return;
                }
                if (!form.AllowLogin)
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                #endregion
                //if (txtPassWord.Text == strPassWord)
                //{
                string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET LOCK_FLAG = 2,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                DBHelper.ExecuteNonQuery(sql);
                txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "标记已封锁";
                UACSUtility.HMILogger.WriteLog(btnByBlock.Text, "库位" + saddleInfo.SaddleNo + "标记为封锁 ,用户：" + form.UserName, UACSUtility.LogLevel.Info, this.Text);
                //}
                //else
                //    txtPopupMessage.Text = "输入密码错误！！！";
                
            }
            catch (Exception er)
            {
                txtPopupMessage.Text = er.Message;
            }
        }

        private void btnNoCoilByUsable_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string coilNo = txtMatNo.Text.Trim();
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET MAT_NO = NULL,STOCK_STATUS = 0,LOCK_FLAG = 0,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "已无卷可用";
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
               

            }
            catch (Exception er)
            {
                txtPopupMessage.Text = er.Message;
            }
        
        }

        private string strCoil = string.Empty;
        private void btnCoilMessage_Click(object sender, EventArgs e)
        {


            strCoil = txtCoilNo.Text.Trim().ToString();

            if (auth.IsOpen("钢卷信息"))
            {
                auth.CloseForm("钢卷信息");

                if (strCoil.Count() > 0)
                {
                    auth.OpenForm("钢卷信息", strCoil);
                }
                else
                    auth.OpenForm("钢卷信息");
            }
            else
            {
                if (strCoil.Count() > 0)
                {
                    auth.OpenForm("钢卷信息", strCoil);
                }
                else
                    auth.OpenForm("钢卷信息");
            }     
                
        }
    }
}
