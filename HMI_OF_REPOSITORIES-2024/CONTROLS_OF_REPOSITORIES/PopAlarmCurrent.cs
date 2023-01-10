using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class PopAlarmCurrent : Form
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();

        private string[] arrTagAdress;

        private string[] arrTagAdress2;


        private string crane_No = null;

        private string TagName = null;
        //行车报警Tag点
        private const string TAG_Electric_I_V301_3_CMS = "plc_alarm_1";
        private const string TAG_Electric_I_V301_4_CMS = "plc_alarm_2";
        private const string TAG_Electric_Single_Module_Error_CMS = "plc_alarm_3";

        private const string TAG_AUTO_Coil_Abnormal_CMS = "plc_alarm_4";
        private const string TAG_AUTO_Weight_Error_CMS = "plc_alarm_5";
        private const string TAG_AUTO_Weight_Fulat_CMS = "plc_alarm_6";
        private const string TAG_AUTO_Collision_Fault_CMS = "plc_alarm_7";
        private const string TAG_AUTO_3D_Data_OK_CMS = "plc_alarm_8";
        private const string TAG_AUTO_Hoist_OK_CMS = "plc_alarm_9";
        private const string TAG_AUTO_Trolley_OK_CMS = "plc_alarm_10";
        private const string TAG_AUTO_Gantry_OK_CMS = "plc_alarm_11";

        private const string TAG_AUTO_LIFTER_OK_CMS = "plc_alarm_12";
        private const string TAG_AUTO_PLC_Heart_Jump_Fault_CMS = "plc_alarm_13";
        private const string TAG_AUTO_SP_Bottom_Switch_Error_CMS = "plc_alarm_14";
        private const string TAG_AUTO_SP_Adj_OV_CMS = "plc_alarm_15";
        private const string TAG_AUTO_Width_Error_CMS = "plc_alarm_16";
        private const string TAG_AUTO_CMS_Emg_Stop_CMS = "plc_alarm_17";
        private const string TAG_AU_AW_IN_Emg_Stop_CMS = "plc_alarm_18";
        private const string TAG_AUTO_PLC_Emg_Stop_CMS = "plc_alarm_19";

        Baosight.iSuperframe.TagService.DataCollection<object> inDatas2 = new Baosight.iSuperframe.TagService.DataCollection<object>();

        /// <summary>
        /// 存解析出来的报警代码
        /// </summary>
        private List<int> listAlarm = new List<int>();
        /// <summary>
        /// 行车号
        /// </summary>
        public string Crane_No
        {
            get { return crane_No; }
            set
            {
                crane_No = value;
            }
        }

        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;

        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");
                    }
                    catch (System.Exception e)
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
        
        public PopAlarmCurrent()
        {
            InitializeComponent();
            this.Load += PopAlarmCurrent_Load;
        }

        void PopAlarmCurrent_Load(object sender, EventArgs e)
        {
            if (Crane_No != null)
            {
                tagDataProvider.ServiceName = "iplature";
                TagName = Crane_No + "_fangyao_alarm_list_transformed";
                lblCraneNo.Text = Crane_No + " 报警";
                SetReady(TagName);
                readTags();

                //string value = get_value_string(TagName);



                //GetDgvMessage();
                //getDgvMessageForCrane();
                //string[] sArray = value.Split(',');

                //for (int i = 0; i < sArray.Count(); i++)
                //{
                //    if(sArray[i]=="1")
                //    {
                //        dataGridView_ALARM.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                //    }
                //    else
                //    {
                //        dataGridView_ALARM.Rows[i].DefaultCellStyle.BackColor = Color.White;
                //    }
                //}
                reflashDgvCurAlarm_1();
            }
            
        }
        private void GetDgvMessage()
        {
            try
            {

                string sql = @"SELECT * FROM UACS_CRANE_ALARM_CODE_DEFINE where ALARM_CODE < 100 order by Alarm_Code ";


                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    dataGridView_ALARM.Rows.Clear();
                    while (rdr.Read())
                    {
                        dataGridView_ALARM.Rows.Add();
                        DataGridViewRow theRow = dataGridView_ALARM.Rows[dataGridView_ALARM.Rows.Count - 1];
                        if (rdr["ALARM_CODE"] != System.DBNull.Value)
                        {
                            theRow.Cells["ALARM_CODE"].Value = rdr["ALARM_CODE"].ToString();
                        }
                        if (rdr["ALARM_INFO"] != System.DBNull.Value)
                        {
                            theRow.Cells["ALARM_INFO"].Value = rdr["ALARM_INFO"].ToString();
                        }
                        if (rdr["ALARM_CLASS"] != System.DBNull.Value)
                        {
                            theRow.Cells["ALARM_CLASS"].Value = rdr["ALARM_CLASS"].ToString();
                        }
                    }
                }


            }
            catch (Exception er)
            {

            }
        }

        private void getDgvMessageForCrane()
        {

            try
            {

                string sql = @"SELECT * FROM UACS_CRANE_ALARM_CODE_DEFINE where ALARM_CODE > 100 order by Alarm_Code ";

                //DataTable dt = new DataTable();
                //using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                //{
                //    if (rdr.Read())
                //    {
                //        dt.Load(rdr);
                //    }
                //}
                //dataGridView_ALARM2.DataSource = dt;

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    dataGridView_ALARM2.Rows.Clear();
                    while (rdr.Read())
                    {
                        DataGridViewRow theRow = dataGridView_ALARM2.Rows[dataGridView_ALARM2.Rows.Add()];
                        if (rdr["ALARM_CODE"] != System.DBNull.Value)
                        {
                            theRow.Cells["ALARM_CODE2"].Value = rdr["ALARM_CODE"].ToString();
                        }
                        if (rdr["ALARM_INFO"] != System.DBNull.Value)
                        {
                            theRow.Cells["ALARM_INFO2"].Value = rdr["ALARM_INFO"].ToString();
                        }
                        if (rdr["ALARM_CLASS"] != System.DBNull.Value)
                        {
                            theRow.Cells["ALARM_CLASS2"].Value = rdr["ALARM_CLASS"].ToString();
                        }
                        //dataGridView_ALARM2.Rows.Add(theRow);
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }

        }



        #region read tag

        public void SetReady(string tagName)
        {
            try
            {
                List<string> lstAdress = new List<string>();
                lstAdress.Add(tagName);
                arrTagAdress = lstAdress.ToArray<string>();
                //新增读行车报警点
                List<string> lstAdress2 = new List<string>();
                string tag_Head = Crane_No + "_";
                lstAdress2.Add(tag_Head + TAG_Electric_I_V301_3_CMS);
                lstAdress2.Add(tag_Head + TAG_Electric_I_V301_4_CMS);
                lstAdress2.Add(tag_Head + TAG_Electric_Single_Module_Error_CMS);

                lstAdress2.Add(tag_Head + TAG_AUTO_Coil_Abnormal_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_Weight_Error_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_Weight_Fulat_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_Collision_Fault_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_3D_Data_OK_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_Hoist_OK_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_Trolley_OK_CMS);

                lstAdress2.Add(tag_Head + TAG_AUTO_Gantry_OK_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_LIFTER_OK_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_PLC_Heart_Jump_Fault_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_SP_Bottom_Switch_Error_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_SP_Adj_OV_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_Width_Error_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_CMS_Emg_Stop_CMS);
                lstAdress2.Add(tag_Head + TAG_AU_AW_IN_Emg_Stop_CMS);
                lstAdress2.Add(tag_Head + TAG_AUTO_PLC_Emg_Stop_CMS);
                arrTagAdress2 = lstAdress2.ToArray<string>();
            }
            catch (Exception er)
            {

            }
        }

        private void readTags()
        {
            try
            {
                inDatas.Clear();
                tagDataProvider.GetData(arrTagAdress, out inDatas);
                inDatas2.Clear();
                tagDataProvider.GetData(arrTagAdress2, out inDatas2);
            }
            catch (Exception ex)
            {
            }
        }

        private string get_value_string(string tagName)
        {
            string theValue = string.Empty;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToString((valueObject));
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }

        private string get_value_string2(string tagName)
        {
            string theValue = string.Empty;
            object valueObject = null;
            try
            {
                valueObject = inDatas2[tagName];
                theValue = Convert.ToString((valueObject));
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }
        #endregion
        private void reflashDgvCurAlarm_1()
        {
            try
            {
                string value = get_value_string(TagName);
                GetDgvMessage();
                getDgvMessageForCrane();

                string[] sArray = value.Split(',');

                for (int i = 0; i < sArray.Count(); i++)
                {
                    if (sArray[i] == "1")
                    {
                        dataGridView_ALARM.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView_ALARM.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void reflashDgvCurAlarm_2()
        {
            try
            {
                for (int i = 0; i < arrTagAdress2.Length; i++)
                {
                    if (get_value_string2(arrTagAdress2[i]) == "1")
                    {
                        dataGridView_ALARM2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView_ALARM2.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabCon = (TabControl)sender;
            readTags();
            if (tabCon.SelectedTab.Name == "tabPage2")
            {
                //getDgvMessageForCrane();
                reflashDgvCurAlarm_2();
            }
            else
            {
                reflashDgvCurAlarm_1();
            }
        }
    }
}
