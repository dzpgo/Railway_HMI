using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using MODEL_OF_REPOSITORIES;
using CONTROLS_OF_REPOSITORIES;

namespace FORMS_OF_REPOSITORIES
{
    public partial class StowageMessage : FormBase
    {
        public StowageMessage()
        {
            InitializeComponent();
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

        enum CarType
        {
            All,           //全部
            FrameCar,      //框架车
            SocietyCar,    //社会车辆
            ChildCar,      //大头娃娃车
            Society17mCar  //框架车
        }   

        List<TruckStowageClass> listTruck = new List<TruckStowageClass>();

        private void GetStowage(string _TimeStart, string _TimeEnd,CarType _carType)
        {
            // 标记
            bool hasSetColumn = false;
            DataTable dt = new DataTable();

            try
            {
                string sql = @"SELECT STOWAGE_ID,FRAME_NO,LOAD_FLAG,CONFIRM_FLAG,FRAME_DIRECTION,SCAN_FLAG,WORK_DIV,CAR_TYPE,REC_TIME FROM UACS_TRUCK_STOWAGE ";

                sql += "  WHERE REC_TIME  > '" + _TimeStart + "' and REC_TIME <'" + _TimeEnd + "' ";
                if (_carType == CarType.FrameCar)
                {
                    sql += "  and CAR_TYPE = 100 ";
                }
                else if (_carType == CarType.SocietyCar)
                {
                    sql += "  and CAR_TYPE = 101 ";
                }
                else if (_carType == CarType.Society17mCar)
                {
                    sql += "  and CAR_TYPE = 103 ";
                }
                else if (_carType == CarType.ChildCar)
                {
                    sql += "  and CAR_TYPE = 102 ";
                }

                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            if (hasSetColumn == false)
            {
                dt.Columns.Add("STOWAGE_ID", typeof(String));
                dt.Columns.Add("FRAME_NO", typeof(String));
                dt.Columns.Add("LOAD_FLAG", typeof(String));
                dt.Columns.Add("CONFIRM_FLAG", typeof(String));
                dt.Columns.Add("FRAME_DIRECTION", typeof(String));
                dt.Columns.Add("SCAN_FLAG", typeof(String));
                dt.Columns.Add("WORK_DIV", typeof(String));
                dt.Columns.Add("CAR_TYPE", typeof(String));
                dt.Columns.Add("REC_TIME", typeof(String));
            }

            dgvStowage.DataSource = dt;
        }

        private void GetStowageDetail(int _STOWAGE_ID)
        {
            listTruck.Clear();
            bool hasSetColumn = false;
            DataTable dt = new DataTable();
            try
            {
                 string sql = @"SELECT MAT_NO,STOWAGE_ID,X_CENTER,Y_CENTER,Z_CENTER,CONFIRM_TIME,STATUS,GROOVEID FROM UACS_TRUCK_STOWAGE_DETAIL ";
                sql += "  WHERE STOWAGE_ID = "+_STOWAGE_ID+"";
                sql += " order by  GROOVEID";
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {

                        TruckStowageClass truck = new TruckStowageClass();
                        if (rdr["MAT_NO"] != DBNull.Value)
	                    {
                            truck.CoilNo = rdr["MAT_NO"].ToString();
	                    }
                        if (rdr["STOWAGE_ID"] != DBNull.Value)
                        {
                            truck.StowageId = Convert.ToInt32( rdr["STOWAGE_ID"].ToString());
                        }
                        if (rdr["X_CENTER"] != DBNull.Value)
                        {
                            truck.XCenter = Convert.ToInt32(rdr["X_CENTER"].ToString());
                        }
                        if (rdr["Y_CENTER"] != DBNull.Value)
                        {
                            truck.YCenter = Convert.ToInt32(rdr["Y_CENTER"].ToString());
                        }
                        if (rdr["Z_CENTER"] != DBNull.Value)
                        {
                            truck.ZCenter = Convert.ToInt32(rdr["Z_CENTER"].ToString());
                        }
                        if (rdr["GROOVEID"] != DBNull.Value)
                        {
                            truck.GrooveId = Convert.ToInt32(rdr["GROOVEID"].ToString());
                        }
                        listTruck.Add(truck);

                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            if (hasSetColumn == false)
            {
                dt.Columns.Add("MAT_NO", typeof(String));
                dt.Columns.Add("STOWAGE_ID", typeof(String));
                dt.Columns.Add("X_CENTER", typeof(String));
                dt.Columns.Add("Y_CENTER", typeof(String));
                dt.Columns.Add("Z_CENTER", typeof(String));
                dt.Columns.Add("CONFIRM_TIME", typeof(String));
                dt.Columns.Add("STATUS", typeof(String));
                dt.Columns.Add("GROOVEID", typeof(String));
            }

            dgvStowageDetail.DataSource = dt;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string TimeInStart = this.dateTimeOutStart.Value.ToString("yyyyMMdd000000");
            string TimeInEnd = this.dateTimeOutEnd.Value.ToString("yyyyMMdd235959");

            if (radioButton1.Checked)
                GetStowage(TimeInStart, TimeInEnd,CarType.All);
            if (radioButton2.Checked)
                GetStowage(TimeInStart, TimeInEnd, CarType.FrameCar);
            if (radioButton3.Checked)
                GetStowage(TimeInStart, TimeInEnd, CarType.SocietyCar);
            if (radioButton4.Checked)
                GetStowage(TimeInStart, TimeInEnd, CarType.ChildCar);
            if (radioButton5.Checked)
                GetStowage(TimeInStart, TimeInEnd, CarType.Society17mCar);
        }

        private void dgvStowage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int planNo;
            string carDir;
            int carType;
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvStowage.Rows[e.RowIndex].Cells["Column1"].Value != DBNull.Value)
                    {
                        //配载图ID
                        planNo = Convert.ToInt32( dgvStowage.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
                        GetStowageDetail(planNo);
                        carDir = dgvStowage.Rows[e.RowIndex].Cells["Column10"].Value.ToString();
                        carType =  Convert.ToInt32( dgvStowage.Rows[e.RowIndex].Cells["Column7"].Value.ToString());
                        conTruckStowage1.DrawTruckStowage(carDir, carType, listTruck);
                        conTruckStowage1.Refresh();
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void conTruckStowage1_UserControlBtnClicked(object sender, EventArgs e)
        {
            conCarSaddle con = sender as conCarSaddle;
           // MessageBox.Show(con.MyProperty.CoilNo);
            string CoilId = con.MyProperty.CoilNo;
            int index = dgvStowageDetail.CurrentRow.Index;
            for (int i = 0; i < dgvStowageDetail.RowCount; i++)
            {
                //dgvStowageDetail.Rows[i].Selected = false;
                string SaddleId = dgvStowageDetail.Rows[i].Cells["Column12"].Value.ToString();
                if (CoilId == SaddleId)
                {
                    dgvStowageDetail.FirstDisplayedScrollingRowIndex = i;
                    dgvStowageDetail.Rows[i].Selected = true;
                    dgvStowageDetail.CurrentCell = dgvStowageDetail.Rows[i].Cells["Column12"];
                }
            }

        }

    }
}
