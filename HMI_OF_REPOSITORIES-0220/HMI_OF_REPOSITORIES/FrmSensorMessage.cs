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
    public partial class FrmSensorMessage : Baosight.iSuperframe.Forms.FormBase
    {
        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
        private string[] arrTagAdress;

        //火车装车tag
        public const string TAG_DAOZHA_NORTH_LOWER_LIMIT = "DAOZHA_NORTH_LOWER_LIMIT";         //火车到位
        public const string TAG_EV_RAILWAY_COACH_TYPE_MODIFY = "EV_RAILWAY_COACH_TYPE_MODIFY";        //车皮类型修改
        public const string TAG_EV_RAILWAY_COACH_TYPE_MODIFY_FINISHED = "EV_RAILWAY_COACH_TYPE_MODIFY_FINISHED";         //车皮类型修改完成
        public const string TAG_EV_RAILWAY_CARGO_STOWAGE_MODIFY = "EV_RAILWAY_CARGO_STOWAGE_MODIFY";        //配载修改
        public const string TAG_EV_RAILWAY_CARGO_STOWAGE_MODIFY_FINISHED = "EV_RAILWAY_CARGO_STOWAGE_MODIFY_FINISHED";         //  配载修改完成
        public const string TAG_EV_RAILWAY_COACH_COILS_MODIFY = "EV_RAILWAY_COACH_COILS_MODIFY";         //选卷
        public const string TAG_EV_RAILWAY_COACH_COILS_FINISHED = "EV_RAILWAY_COACH_COILS_FINISHED";         //选卷确认
        public const string TAG_EV_RAILWAY_COACH_OPER_PAUSE = "EV_RAILWAY_COACH_OPER_PAUSE";         //  暂停
        public const string TAG_EV_RAILWAY_COACH_OPER_START = "EV_RAILWAY_COACH_OPER_START";         //开始
        public const string TAG_EV_RAILWAY_COACH_LEAVE = "EV_RAILWAY_COACH_LEAVE";  
        public FrmSensorMessage()
        {
            InitializeComponent();
            this.Load += FrmSensorMessage_Load;
        }

        void FrmSensorMessage_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void getCraneSensorMassage_1()
        {
            HMIDisplay(radioButton3, radioButton4, getTagValue(TAG_DAOZHA_NORTH_LOWER_LIMIT)); //1.tag显示的一个点
        }
        private void getCraneSensorMassage_2()
        {

        }
        private void getCraneSensorMassage_3()
        {

        }
        /// <summary>
        /// 画面显示
        /// </summary>
        /// <param name="radioButtonNO"></param>
        /// <param name="radioButtonOFF"></param>
        /// <param name="status"></param>
        private void HMIDisplay(RadioButton radioButtonNO, RadioButton radioButtonOFF, bool status)
        {
            if (status)
            {
                radioButtonNO.Checked = status;
            }
            else
            {
                radioButtonOFF.Checked = !status;
            }           
        }
        /// <summary>
        /// 初始化Tag数组，并获取变量的值inDatas
        /// </summary>
        private void InitArrTagAdress()
        {
            List<string> lstAdress = new List<string>();

            lstAdress.Add(TAG_DAOZHA_NORTH_LOWER_LIMIT);
            //lstAdress.Add(TagNameClass.tag_DAOZHA_A_NORTH_OPEN);
            //lstAdress.Add(TagNameClass.tag_DAOZHA_A_SOUTH_CLOSE);
            //lstAdress.Add(TagNameClass.tag_DAOZHA_A_SOUTH_OPEN);
            arrTagAdress = lstAdress.ToArray<string>();
            readTags();
        }
        private void readTags()
        {
            try
            {
                inDatas.Clear();
                UACSUtility.ViewHelper.TagDP.GetData(arrTagAdress, out inDatas);
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 获取Tag点值 ,1返回true
        /// </summary>
        /// <param name="TagName"></param>
        /// <returns></returns>
        public bool getTagValue(string TagName)
        {
            bool ret = false;
            string tagName = TagName;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                if (valueObject != null && valueObject.ToString() == "1")
                {
                    ret = true;
                }
            }
            catch (Exception)
            {

            }
            return ret;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                InitArrTagAdress();
                getCraneSensorMassage_1();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message + "\r\n" + EX.StackTrace);
            }
        }
    }
}
