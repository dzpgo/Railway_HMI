using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class FrmModeSwitchover : Form
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        /// <summary>
        /// 行车号
        /// </summary>
        public string Crane_No { get; set; }

        /// <summary>
        /// tag
        /// </summary>
        public string TagServiceName { get; set; }
        public FrmModeSwitchover()
        {
            InitializeComponent();
            this.Load += FrmModeSwitchover_Load;
        }

        void FrmModeSwitchover_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            tagDataProvider.ServiceName = TagServiceName;
            label1.Text = Crane_No + "模式切换";
        }



        /// <summary>
        /// 手动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
           SendShortCmd(Crane_No, CraneStatusBase.SHORT_CMD_CANCEL_COMPUTER_AUTO);
           UACSUtility.HMILogger.WriteLog(button1.Text, "手动,行车：" + Crane_No, UACSUtility.LogLevel.Info, this.Text);
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SendShortCmd(Crane_No, CraneStatusBase.SHORT_CMD_RESET);
            UACSUtility.HMILogger.WriteLog(button2.Text, "复位,行车：" + Crane_No, UACSUtility.LogLevel.Info, this.Text);
        }
        /// <summary>
        /// 自动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("注意,行车切自动", "警告", MessageBoxButtons.OK))
            {
                SendShortCmd(Crane_No, CraneStatusBase.SHORT_CMD_ASK_COMPUTER_AUTO);
                UACSUtility.HMILogger.WriteLog(button3.Text, "自动,行车：" + Crane_No, UACSUtility.LogLevel.Info, this.Text);
            }
           
        }
        /// <summary>
        /// 请求停车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
           // SendShortCmd(Crane_No, CraneStatusBase.SHORT_CMD_NORMAL_STOP);
        }


        /// <summary>
        /// 模式切换
        /// </summary>
        /// <param name="theCraneNO">行车号</param>
        /// <param name="cmdFlag">对应模式切换数值</param>
        private void SendShortCmd(string theCraneNO, long cmdFlag)
        {
            try
            {
                string messageBuffer = string.Empty;

                messageBuffer = theCraneNO + "," + cmdFlag.ToString();
                //DownLoadShortCommand
                Baosight.iSuperframe.TagService.DataCollection<object> wirteDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                wirteDatas[theCraneNO + "_" + TagNameClass.tag_CraneMode] = messageBuffer;
                tagDataProvider.SetData(theCraneNO + "_" + TagNameClass.tag_CraneMode, messageBuffer);

            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 取消窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
