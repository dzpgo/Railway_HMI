using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HMI_OF_REPOSITORIES
{
    public partial class SubFrmLetOutWater : Form
    {
        #region iPlature配置
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = null;
        public Baosight.iSuperframe.TagService.Controls.TagDataProvider TagDP
        {
            get
            {
                if (tagDP == null)
                {
                    try
                    {
                        tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
                        tagDP.ServiceName = "iplature";
                        tagDP.AutoRegist = true;
                    }
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return tagDP;
            }
            //set { tagDP = value; }
        }
        #endregion

        string tagNameStart;
        //string tagNamePause;
        bool craneDrainWater = false;

        public bool CraneDrainWater
        {
            get { return craneDrainWater; }
            set { craneDrainWater = value; }
        }


        public SubFrmLetOutWater()
        {
            InitializeComponent();
        }
        public SubFrmLetOutWater(string name)
        {
            InitializeComponent();
            CraneName = name;
            InitTagname(name);
        }
        private void InitTagname(string name)
        {
            switch (name)
            {
                case "1":
                    tagNameStart = "1_DownLoadWater";
                    break;
                case "2":
                    tagNameStart = "2_DownLoadWater";
                    break;
                case "3":
                    tagNameStart = "3_DownLoadWater";
                    break;
                case "7":
                    tagNameStart = "7_DownLoadWater";
                    break;
                case "8":
                    tagNameStart = "8_DownLoadWater";
                    break;
                default:
                    break;
            }
        
        }
        string craneName;
        public string CraneName
        {
            get { return craneName; }
            set { craneName = value; }
        }
        //开始
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要对" + craneName + "#行车进行排水？", "提示", btn,MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                TagDP.SetData(tagNameStart, "1");
                UACSUtility.HMILogger.WriteLog(button1.Text, "行车进行排水：" + tagNameStart, UACSUtility.LogLevel.Info, this.Text);

            }
            else
            {

            }
            this.Close();
        }
        //暂停
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要对" + craneName + "#行车暂停排水？", "提示", btn, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                TagDP.SetData(tagNameStart, "0");
                UACSUtility.HMILogger.WriteLog(button1.Text, "行车进行排水：" + tagNameStart, UACSUtility.LogLevel.Info, this.Text);
            }
            else
            {

            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
