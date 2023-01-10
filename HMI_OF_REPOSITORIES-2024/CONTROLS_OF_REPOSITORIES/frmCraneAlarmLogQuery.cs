using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;

namespace Crane_Alarm_Log 
{
    public partial class frmCraneAlarmLogQuery  : FormBase
    {
        public frmCraneAlarmLogQuery()
        {
            InitializeComponent();
            this.Load += frmCraneAlarmLogQuery_Load;
        }

        void frmCraneAlarmLogQuery_Load(object sender, EventArgs e)
        {
            //初始时间为前一小时和后一小时
            DateTime dt = DateTime.Now;
            TimeSpan tp = TimeSpan.Parse("00.1:00:00");
            dateTimePicker_Start.Value = dt.Subtract(tp);
            dateTimePicker_End.Value = dt.Add(tp);
        }



        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;

        public static Baosight.iSuperframe.Common.IDBHelper DBHelper
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
                        throw e;
                    }

                }
                return dbHelper;
            }
        }

        string alarmTime_Current = string.Empty;
        string alarmTime_Old = string.Empty;
        bool flagColor = false;
        private void readAlarmLog(string craneNO, DateTime timeStart, DateTime timeEnd)
        {
            try
            {
                string tableName = "UACS_CRANE_ALARM_" + craneNO;

                string strSql = "";
                strSql = "select ";
                strSql += " a.CRANE_NO   CRANE_NO, ";
                strSql += " a.ALARM_CODE   ALARM_CODE, ";
                strSql += " a.ALARM_TIME   ALARM_TIME, ";
                strSql += " a.X_ACT   X_ACT, ";
                strSql += " a.Y_ACT   Y_ACT, ";
                strSql += " a.Z_ACT   Z_ACT, ";
                strSql += " a.HAS_COIL   HAS_COIL, ";
                strSql += " a.CLAMP_WIDTH_ACT   CLAMP_WIDTH_ACT, ";
                strSql += " a.CONTROL_MODE   CONTROL_MODE, ";
                strSql += " a.CRANE_STATUS   CRANE_STATUS, ";
                strSql += " a.ORDER_ID   ORDER_ID, ";
                strSql += " b.ALARM_INFO   ALARM_INFO, ";
                strSql += " b.ALARM_CLASS   ALARM_CLASS ";
                strSql += " from ";
                strSql += tableName+" a "+",";
                strSql += "  UACS_CRANE_ALARM_CODE_DEFINE b  ";
                strSql += " where ";
                strSql += "       a.ALARM_CODE=b.ALARM_CODE ";
                strSql += " and a.CRANE_NO=" + "'" + craneNO + "'";
                strSql += " and a.ALARM_TIME>= " + DateNormal_ToString(timeStart);
                strSql += " and a.ALARM_TIME<= " + DateNormal_ToString(timeEnd);
                strSql += " Order By a.ALARM_TIME " ;

                using (IDataReader rdr = DBHelper.ExecuteReader(strSql))
                {
                    GridAlarmLog.Rows.Clear();
                     while (rdr.Read())
                     {
                         GridAlarmLog.Rows.Add();
                         DataGridViewRow theRow = GridAlarmLog.Rows[GridAlarmLog.Rows.Count - 1];
                         if (rdr["CRANE_NO"] != System.DBNull.Value) 
                         {
                             theRow.Cells["CRANE_NO"].Value = Convert.ToString(rdr["CRANE_NO"]); 
                         }
                         if (rdr["ALARM_CODE"] != System.DBNull.Value)
                         {
                             theRow.Cells["ALARM_CODE"].Value = Convert.ToString(rdr["ALARM_CODE"]);
                         }
                         if (rdr["ALARM_TIME"] != System.DBNull.Value)
                         {
                             alarmTime_Current = Convert.ToString(rdr["ALARM_TIME"]);
                             theRow.Cells["ALARM_TIME"].Value = Convert.ToString(rdr["ALARM_TIME"]);
                         }
                         if (rdr["X_ACT"] != System.DBNull.Value)
                         {
                             theRow.Cells["X_ACT"].Value = Convert.ToString(rdr["X_ACT"]);
                         }
                         if (rdr["Y_ACT"] != System.DBNull.Value)
                         {
                             theRow.Cells["Y_ACT"].Value = Convert.ToString(rdr["Y_ACT"]);
                         }
                         if (rdr["Z_ACT"] != System.DBNull.Value)
                         {
                             theRow.Cells["Z_ACT"].Value = Convert.ToString(rdr["Z_ACT"]);
                         }
                         if (rdr["HAS_COIL"] != System.DBNull.Value)
                         {
                             theRow.Cells["HAS_COIL"].Value = Convert.ToString(rdr["HAS_COIL"]);
                         }
                         //if (rdr["CLAMP_WIDTH_ACT"] != System.DBNull.Value)
                         //{
                         //    theRow.Cells["HAS_COIL"].Value = Convert.ToString(rdr["CLAMP_WIDTH_ACT"]);
                         //}
                         if (rdr["CONTROL_MODE"] != System.DBNull.Value)
                         {
                             theRow.Cells["CONTROL_MODE"].Value = Convert.ToString(rdr["CONTROL_MODE"]);
                         }
                         if (rdr["CRANE_STATUS"] != System.DBNull.Value)
                         {
                             theRow.Cells["CRANE_STATUS"].Value = Convert.ToString(rdr["CRANE_STATUS"]);
                         }
                         if (rdr["ORDER_ID"] != System.DBNull.Value)
                         {
                             theRow.Cells["ORDER_ID"].Value = Convert.ToString(rdr["ORDER_ID"]);
                         }
                         if (rdr["ALARM_CODE"] != System.DBNull.Value)
                         {
                             theRow.Cells["ALARM_CODE"].Value = Convert.ToString(rdr["ALARM_CODE"]);
                         }
                         if (rdr["ALARM_INFO"] != System.DBNull.Value)
                         {
                             theRow.Cells["ALARM_INFO"].Value = Convert.ToString(rdr["ALARM_INFO"]);
                         }
                         if (rdr["ALARM_CLASS"] != System.DBNull.Value)
                         {
                             theRow.Cells["ALARM_CLASS"].Value = Convert.ToString(rdr["ALARM_CLASS"]);
                         }

                         if (alarmTime_Old != alarmTime_Current)
                         {
                             flagColor = !flagColor;
                         }
                         if (flagColor)
                         {
                             theRow.DefaultCellStyle.BackColor = Color.Silver;
                         }
                         else
                         {
                             theRow.DefaultCellStyle.BackColor = Color.DarkGray;
                         }
                         alarmTime_Old = alarmTime_Current;
                     }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public string DateNormal_ToString(DateTime theDateTime)
        {
            string strDateTime = "";
            try
            {
                strDateTime = theDateTime.Year.ToString("0000") + theDateTime.Month.ToString("00") + theDateTime.Day.ToString("00")
                            + theDateTime.Hour.ToString("00") + theDateTime.Minute.ToString("00") + theDateTime.Second.ToString("00");
                strDateTime = "to_date('" + strDateTime + "','YYYYMMDDHH24MISS')";
            }
            catch (Exception ex)
            {
            }
            return strDateTime;
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime timeStart = dateTimePicker_Start.Value;
                DateTime timeEnd = dateTimePicker_End.Value;
                string craneNO = comboBox_ShipLotNo.Text ;
                readAlarmLog(craneNO, timeStart, timeEnd);

                //光标显示到最后一行
                GridAlarmLog.FirstDisplayedScrollingRowIndex = GridAlarmLog.RowCount - 1;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 向上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            //获取当前行的索引
            int index = GridAlarmLog.CurrentRow.Index;
            //找到的报警号
            string currentCode = string.Empty;
            string selectCode = this.txtAlarmCode.Text.Trim();
            if (selectCode == "")
                return;
            for (int i = index -1; i < index; i--)
            {
                if (GridAlarmLog.Rows[i].Cells["ALARM_CODE"].Value != DBNull.Value)
                {
                    currentCode = GridAlarmLog.Rows[i].Cells["ALARM_CODE"].Value.ToString();
                }

                //找到相同钢卷号
                if (selectCode == currentCode)
                {
                    GridAlarmLog.Rows[i].Selected = true;
                    return;
                }
            }

        }

    }
}
