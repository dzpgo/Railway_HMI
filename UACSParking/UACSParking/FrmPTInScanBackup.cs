using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ParkingControlLibrary
{
    public partial class FrmPTInScanBackup : Form
    {

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
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion
        /// <summary>
        /// 停车位
        /// </summary>
        public string ParkingNo { get; set; }

        public FrmPTInScanBackup()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    MessageBox.Show("手持机添加数据成功");
                    Thread.Sleep(1000);
                    this.Close();
                }   
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }



        List<ptDataBase> lstPTDataBase = new List<ptDataBase>();
        private bool SaveData()
        {
            try
            {
                lstPTDataBase.Clear();
                getPTData(txt_MatNO1.Text, text_Pos1.Text);
                getPTData(txt_MatNO2.Text, text_Pos2.Text);
                getPTData(txt_MatNO3.Text, text_Pos3.Text);
                getPTData(txt_MatNO4.Text, text_Pos4.Text);
                getPTData(txt_MatNO5.Text, text_Pos5.Text);
                getPTData(txt_MatNO6.Text, text_Pos6.Text);
                getPTData(txt_MatNO7.Text, text_Pos7.Text);
                getPTData(txt_MatNO8.Text, text_Pos8.Text);
                getPTData(txt_MatNO9.Text, text_Pos9.Text);
                getPTData(txt_MatNO10.Text, text_Pos10.Text);
                if (lstPTDataBase.Count == 0)
                    return false;
                //TODO:删除PDA_SCAN中次数为1的纪录
                if( !DelPTData())
                    return false;
               

                //TODO:查询STOWAGE_ID(配载图id)
                int theStowage = GetSTOWAGE_ID();

                //TODO:查询TREATMENT_NO(处理号)
                string theTreatment = GetTREATMENT_NO();

                //TODO:添加人工数据到UACS_PDA_SCAN
                foreach (ptDataBase ptData in lstPTDataBase)
                {
                    //long thePortableID = getSeqPortableId();
                    SaveAPtData(ptData.MatNO, theStowage, 1, theTreatment, 1, ptData.Pos, ParkingNo);
                }

                //TODO:更新UACS_PARKING_STATUS的PT_ACTION_COUNT为1
                UpdateParkingStatus();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }


        private  void UpdateParkingStatus()
        {
            try
            {

                string sqlText = "Update UACS_PARKING_STATUS set PT_ACTION_Count= " + 1 + " where PARKING_NO= '" + ParkingNo + "'";
                DBHelper.ExecuteNonQuery(sqlText);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private bool DelPTData()
        {
            try
            {
                string sql = @"DELETE FROM UACS_PDA_SCAN where PACKING_SPACE = '" + ParkingNo + "' and PT_ACTION_COUNT = 1";
                DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                return false;
            }
            return true;
        }


        private int GetSTOWAGE_ID()
        {
            int stowage = 0;
            try
            {
                string sql = @"SELECT STOWAGE_ID FROM UACS_PARKING_STATUS where PARKING_NO = '" + ParkingNo + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["STOWAGE_ID"] != DBNull.Value)
                            stowage = Convert.ToInt32( rdr["STOWAGE_ID"]);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return stowage;
        }

        private string GetTREATMENT_NO()
        {
            string stowage = string.Empty;
            try
            {
                string sql = @"SELECT TREATMENT_NO FROM UACS_PARKING_STATUS where PARKING_NO = '" + ParkingNo + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["TREATMENT_NO"] != DBNull.Value)
                            stowage = rdr["TREATMENT_NO"].ToString();
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return stowage;
        }

        private void getPTData(string theMatNO, string thePos7)
        {
            ptDataBase thePTData = null;
            try
            {
                if (theMatNO != null && thePos7 != null && theMatNO.Trim() != string.Empty && thePos7.Trim() != string.Empty)
                {
                    if (thePos7.Length == 7)
                    {
                        thePTData = new ptDataBase(theMatNO, thePos7);
                        lstPTDataBase.Add(thePTData);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private int getSeqPortableId()
        {
            Int32 theSeqPortableId = 0;
            try
            {

                string sqlText = "select nextval for seq_Portable_Id  nextval from sysibm.sysdummy1";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        if (rdr["nextval"] != System.DBNull.Value)
                        {
                            theSeqPortableId = Convert.ToInt32(rdr["nextval"]);
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return theSeqPortableId;
        }

        private void SaveAPtData(string theMatNo,
                                 int theStowageId,
                                 int theScanType,
                                 string theProcessNo,
                                 int thePTActionCount,
                                 string thePOS7,
                                 string thePackingSpace)
        {
            try
            {
                string sqlText = "INSERT INTO UACS_PDA_SCAN ";
                sqlText += " (";
                sqlText += " MAT_NO,";
                sqlText += " STOWAGE_ID,";
                sqlText += " SCAN_TYPE,";
                sqlText += " PROCESS_NO,";
                sqlText += " PT_ACTION_COUNT,";
                sqlText += " COIL_POSITION_7,";
                sqlText += " PACKING_SPACE,";
                sqlText += " EQU_NO,";
                sqlText += " USERNAME";
                sqlText += " )";
                sqlText += " Values";
                sqlText += " (";
                sqlText += "'" + theMatNo + "' ,";
                sqlText += "" + theStowageId + " ,";
                sqlText += "" + theScanType + " ,";
                sqlText += "'" + theProcessNo + "',";
                sqlText += "" + thePTActionCount + ", ";
                sqlText += "'" + thePOS7 + "' ,";
                sqlText += "'" + thePackingSpace + "',";
                sqlText += "'26',";
                sqlText += "'1'";
                sqlText += " )";
                DBHelper.ExecuteNonQuery(sqlText);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }



    public class ptDataBase
    {
        private string matNO = string.Empty;

        public string MatNO
        {
            get { return matNO; }
            set { matNO = value; }
        }
        private string pos = string.Empty;

        public string Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public ptDataBase(string theMatNO, string thePos)
        {
            matNO = theMatNO;
            pos = thePos;
        }

    }
}
