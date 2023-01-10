using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONTROLS_OF_PREMIERE
{
    public partial class PopCraneEvade : Form
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();

        private string[] arrTagAdress;

        private string crane_NO = string.Empty;
        public string Crane_NO
        {
            get
            {
                return crane_NO;
            }

            set
            {
                crane_NO = value;
            }
        }

        private string tagRequestName = string.Empty;
        private string tagCancelName = string.Empty;


        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;

        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ2030");
                    }
                    catch (Exception e)
                    {
                        //throw e;
                    }

                }
                return dbHelper;
            }
        }



        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {
            }
        }

        public PopCraneEvade()
        {
            InitializeComponent();
            this.Load += PopCraneEvadeLoad;
        }

        void PopCraneEvadeLoad(object sender, EventArgs e)
        {
            if (Crane_NO != null)
            {
                txtCraneNO.Text = crane_NO;


                if (crane_NO == "4_4" || crane_NO == "4_5")
                {
                    tagRequestName = "Z33_EVADE_REQUEST";
                    tagCancelName = "Z33_EVADE_CANCEL";
                }
                else if (crane_NO == "4_1" || crane_NO == "4_2" || crane_NO == "4_3")
                {
                    tagRequestName = "Z32_EVADE_REQUEST";
                    tagCancelName = "Z32_EVADE_CANCEL";
                }


                InitTagDataProvide("iplature");


                //刷新显示
                RefreshDiaplay(GetData());



            }

        }


        /// <summary>
        /// 获取 对应 行车 避让 数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetData()
        {

            Dictionary<string, string> data = new Dictionary<string, string>();
            try
            {

                string sql = string.Format("SELECT TARGET_CRANE_NO, SENDER, ORIGINAL_SENDER, EVADE_X_REQUEST, EVADE_X, EVADE_DIRECTION, EVADE_ACTION_TYPE, STATUS  FROM UACS_CRANE_EVADE_REQUEST WHERE TARGET_CRANE_NO='{0}'", crane_NO);

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        string tmp = string.Empty;
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            data.Add(rdr.GetName(i).ToString(), rdr[i].ToString());
                        }
                        return data;
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }


        /// <summary>
        /// 将文本内容保存到数据表
        /// </summary>
        void Update2DB()
        {
            try
            {
                string evadeX;
                if (GetTxt(txtEvadeX) != "")
                    evadeX = GetTxt(txtEvadeX);
                else
                    evadeX = "null";

                string reqEvadeX;
                if (GetTxt(txtReqEvadeX) != "")
                    reqEvadeX = GetTxt(txtReqEvadeX);
                else
                    reqEvadeX = "null";
             
                string sql = string.Empty;

                sql = string.Format("UPDATE UACS_CRANE_EVADE_REQUEST SET SENDER ='{0}',ORIGINAL_SENDER ='{1}', EVADE_X_REQUEST ={2}, EVADE_X ={3}, EVADE_DIRECTION ='{4}', EVADE_ACTION_TYPE ='{5}',STATUS='{6}' WHERE TARGET_CRANE_NO ='{7}'  ",
                                                                     GetTxt(txtSender), GetTxt(txtOriSender), reqEvadeX, evadeX, GetTxt(txtDirection), GetTxt(txtType), txtStatus.Text.Trim(), crane_NO);

                DBHelper.ExecuteNonQuery(sql);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update");
            }
        }
        /// <summary>
        /// 清空数据表记录内容
        /// </summary>
        void Clear2DB()
        {
            try
            {

                //long evadeX = long.Parse(GetTxt(txtEvadeX));
                //long reqEvadeX = long.Parse(txtReqEvadeX.Text.Trim().ToString());

                string sql = string.Empty;

                sql = string.Format("UPDATE UACS_CRANE_EVADE_REQUEST SET SENDER =null,ORIGINAL_SENDER =null, EVADE_X_REQUEST =null, EVADE_X =null, EVADE_DIRECTION =null, EVADE_ACTION_TYPE =null,STATUS='EMPTY' WHERE TARGET_CRANE_NO ='{0}'  ", crane_NO);


                DBHelper.ExecuteNonQuery(sql);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update");
            }
        }

        #region  tag

        public void SetReady(string tagName)
        {
            try
            {
                List<string> lstAdress = new List<string>();
                lstAdress.Add(tagName);
                arrTagAdress = lstAdress.ToArray<string>();
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        /// <summary>
        /// 将数据写入tag
        /// </summary>
        /// <param name="tagName">传入参数tag名</param>
        private void Write2Tag(string tagName)
        {
            try
            {
                string tagValue = string.Empty;
                tagValue = string.Format("{0},{1},{2},{3},{4}", GetTxt(txtCraneNO), GetTxt(txtSender), GetTxt(txtOriSender), GetTxt(txtReqEvadeX), GetTxt(txtDirection));

                tagDataProvider.SetData(tagName, tagValue);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WRITE2TAG");
            }
        }


        /// <summary>
        /// 将数据写入tag
        /// </summary>
        private void Write2Tag(string tagName,string tagValue)
        {
            try
            {

                tagDataProvider.SetData(tagName, tagValue);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WRITE2TAG");
            }
        }
        /// <summary>
        /// 将文本控件内容首尾空白剪切
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        string GetTxt(TextBox txt)
        {
            return txt.Text.Trim();
        }
        /// <summary>
        /// 刷新窗体控件 显示文本
        /// </summary>
        /// <param name="data">数据字典 Dictionary</param>
        void RefreshDiaplay(Dictionary<string, string> data)
        {
            try
            {
                if (data.Count < 7)
                {
                    txtSender.Text = "";
                    txtOriSender.Text = "";
                    txtReqEvadeX.Text = "";
                    txtEvadeX.Text = "";
                    txtDirection.Text = "X_ON_SPOT";
                    txtType.Text = "";
                    txtStatus.Text = "EMPTY";
                    return;
                }

                txtSender.Text = data["SENDER"];
                txtOriSender.Text = data["ORIGINAL_SENDER"];
                txtReqEvadeX.Text = data["EVADE_X_REQUEST"];
                txtEvadeX.Text = data["EVADE_X"];
                txtDirection.Text = data["EVADE_DIRECTION"];
                txtType.Text = data["EVADE_ACTION_TYPE"];
                txtStatus.Text = data["STATUS"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FRESH");
            }

        }

        //private string get_value_string(string tagName)
        //{
        //    string theValue = string.Empty;
        //    object valueObject = null;
        //    try
        //    {
        //        valueObject = inDatas[tagName];
        //        theValue = Convert.ToString((valueObject));
        //    }
        //    catch
        //    {
        //        valueObject = null;
        //    }
        //    return theValue; ;
        //}
        #endregion

        #region  切换按钮事件
        private void chkXinc_CheckedChanged(object sender, EventArgs e)
        {

            if (chkXinc.Checked)
            {
                chkXdec.Checked = (!chkXinc.Checked);
                chkXinc.BackColor = Color.LightGreen;
                txtDirection.Text = "X_INC";
            }
            else
            {
                chkXinc.BackColor = Color.Transparent;
            }


        }

        private void chkXdec_CheckedChanged(object sender, EventArgs e)
        {


            if (chkXdec.Checked)
            {
                chkXinc.Checked = (!chkXdec.Checked);
                chkXdec.BackColor = Color.LightGreen;
                txtDirection.Text = "X_DES";
            }
            else
            {
                chkXdec.BackColor = Color.Transparent;
            }

        }

        private void chkRightNow_CheckedChanged(object sender, EventArgs e)
        {


            if (chkRightNow.Checked)
            {
                chkAfterJob.Checked = (!chkRightNow.Checked);
                chkRightNow.BackColor = Color.LightGreen;
                txtType.Text = "RIGHT_NOW";
            }
            else
            {
                chkRightNow.BackColor = Color.Transparent;
            }
        }

        private void chkAfterJob_CheckedChanged(object sender, EventArgs e)
        {

            if (chkAfterJob.Checked)
            {
                chkRightNow.Checked = (!chkAfterJob.Checked);
                chkAfterJob.BackColor = Color.LightGreen;
                txtType.Text = "AFTER_JOB";
            }
            else
            {
                chkAfterJob.BackColor = Color.Transparent;
            }
        }
        #endregion

        #region  button按钮事件
        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void btnRefresh_Click(object sender, EventArgs e)
        {

            RefreshDiaplay(GetData());

        }



        private void btnSetEvade_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("更新数据到数据表", "Tips", MessageBoxButtons.OKCancel))
                Update2DB();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("清空该行车数据表数据", "Tips", MessageBoxButtons.OKCancel))
            {

                chkAfterJob.Checked = false;
                chkRightNow.Checked = false;
                chkXdec.Checked = false;
                chkXinc.Checked = false;

                Clear2DB();

                RefreshDiaplay(GetData());

            }


        }

        private void btnSend2SVR_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("将避让信息发送到后台？", "Tips", MessageBoxButtons.OKCancel))
                Write2Tag(tagRequestName);
        }

        private void btnCance2SVR_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("取消行车避让信息？", "Tips", MessageBoxButtons.OKCancel))
            { 
                string tagValue = string.Empty;
                tagValue = string.Format("{0},{1}", GetTxt(txtSender), GetTxt(txtDirection));
                Write2Tag(tagCancelName);
            }
              

        }

        private void txtStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtStatus.Text = txtStatus.SelectedText;
        }
        #endregion
    }
}
