using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService;
using ParkClassLibrary;
using UACSParking;

namespace UACSParking
{
    public partial class SubFrmCarToTrain : Form
    {
        public SubFrmCarToTrain()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStowageID.Text.Trim() == null  || txtStowageID.Text.Trim() == "" )
                {
                    MessageBox.Show("请输入配载号！");
                    return;
                }
                else    
                {
                    string sqlText = @"SELECT STATUS FROM UACS_TRUCK_STOWAGE_DETAIL WHERE  STOWAGE_ID = '" + txtStowageID.Text.Trim() + "'";
                    IDataReader myRead = ClsParkingManager.DBHelper.ExecuteReader(sqlText);
                    if (myRead.Read())
                    {
                        string sqlText1 = @" UPDATE UACS_TRUCK_STOWAGE_DETAIL SET STATUS = '101' WHERE  STOWAGE_ID = '" + txtStowageID.Text.Trim() + "'";
                        IDataReader rdr = ClsParkingManager.DBHelper.ExecuteReader(sqlText1);
                       // string sqlText2 = @" SELECT  STATUS FROM UACS_TRUCK_STOWAGE_DETAIL WHERE MAT_NO = '" + txtCoilNo.Text.Trim() + "' AND STOWAGE_ID = '" + txtStowageID.Text.Trim() + "'";
                        //using (IDataReader rdr1 = ClsParkingManager.DBHelper.ExecuteReader(sqlText2))
                        //{
                        //    while (rdr1.Read())
                        //    {
                        //        string STATUS = ManagerHelper.JudgeStrNull(rdr1["STATUS"]);
                        //        if (STATUS == "101")
                        //        {
                                    MessageBox.Show("整车卷改为直装！");
                        //        }
                        //    }
                        //}

                    }
                    else
                    {
                        myRead.Close();
                        MessageBox.Show("不存在，请检查配载号！");
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }             

       
        
    }
}
