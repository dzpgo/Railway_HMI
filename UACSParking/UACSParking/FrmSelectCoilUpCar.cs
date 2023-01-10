using Baosight.iSuperframe.TagService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParkingControlLibrary
{
    public partial class FrmSelectCoilUpCar : Form
    {
        public class PackingMessage
        {
            /// <summary>
            /// 停车位
            /// </summary>
            public string PackingNo { get; set; }

            /// <summary>
            /// 框架车号
            /// </summary>
            public string CarNo { get; set; }

            /// <summary>
            /// 处理号
            /// </summary>
            public string TREATMENT_NO { get; set; }

            /// <summary>
            /// 配载图id
            /// </summary>
            public string STOWAGE_ID { get; set; }      
        }


        public PackingMessage packing = new PackingMessage();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        private Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();

        // EV_PARKING_MDL_OUT_CAL_START  
        // Z53A2|0502|Z53A2001200|1|1516-27261063901|27261074301|27261071101|27261052901|27261071302|27261071503|27261071103|27261072701 

        public FrmSelectCoilUpCar()
        {
            InitializeComponent();
            this.Load += FrmSelectCoilUpCar_Load;
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
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion

        void FrmSelectCoilUpCar_Load(object sender, EventArgs e)
        {
            txtPackingNo.Text = packing.PackingNo;
            txtCarNo.Text = packing.CarNo;
            txtStowageId.Text = packing.STOWAGE_ID;
            txtNum.Text = packing.TREATMENT_NO;


            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            //框架车出库
            TagValues.Add("EV_PARKING_MDL_OUT_CAL_START", null);
            tagDP.Attach(TagValues);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataTable dt_Laser = new DataTable();
            bool hasSetColumn_Laser = false;
            try
            {
                string sql = @"SELECT STOCK_NO,MAT_NO from UACS_YARDMAP_STOCK_DEFINE ";
                if (cbbAreaNo.Text.Trim() == "A" && txtCoil.Text.Trim() == "")
                {
                    sql += " WHERE STOCK_NO like 'FT11A%' and MAT_NO != ''";
                }
                else if (cbbAreaNo.Text.Trim() == "B" && txtCoil.Text.Trim() == "")
                {
                    sql += " WHERE STOCK_NO like 'FT11B%' and MAT_NO != ''";
                }
                else if (cbbAreaNo.Text.Trim() == "C" && txtCoil.Text.Trim() == "")
                {
                    sql += " WHERE STOCK_NO like 'FT11C%' and MAT_NO != ''";
                }
                else if (cbbAreaNo.Text.Trim() == "D" && txtCoil.Text.Trim() == "")
                {
                    sql += " WHERE STOCK_NO like 'FT11D%' and MAT_NO != ''";
                }
                else if (cbbAreaNo.Text.Trim() == "A" && txtCoil.Text.Trim() != "")
                {
                    sql += " WHERE STOCK_NO like 'FT11A%' and MAT_NO = '"+txtCoil.Text.Trim()+"'";
                }
                else if (cbbAreaNo.Text.Trim() == "B" && txtCoil.Text.Trim() != "")
                {
                    sql += " WHERE STOCK_NO like 'FT11B%' and MAT_NO = '" + txtCoil.Text.Trim() + "'";
                }
                else if (cbbAreaNo.Text.Trim() == "C" && txtCoil.Text.Trim() != "")
                {
                    sql += " WHERE STOCK_NO like 'FT11C%' and MAT_NO = '" + txtCoil.Text.Trim() + "'";
                }
                else if (cbbAreaNo.Text.Trim() == "D" && txtCoil.Text.Trim() != "")
                {
                    sql += " WHERE STOCK_NO like 'FT11D%' and MAT_NO = '" + txtCoil.Text.Trim() + "'";
                }
                else if (cbbAreaNo.Text.Trim() == "全部" && txtCoil.Text.Trim() == "")
                {
                    sql += " WHERE  MAT_NO != ''";
                }
                else if (cbbAreaNo.Text.Trim() == "全部" && txtCoil.Text.Trim() != "")
                {
                    sql += " WHERE  MAT_NO == '" + txtCoil.Text.Trim() + "'";
                }

                dt_Laser.Clear();
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt_Laser.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn_Laser)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt_Laser.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn_Laser = true;
                        dt_Laser.Rows.Add(dr);
                    }
                }
                dataGridView1.DataSource = dt_Laser;
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }

            if (!hasSetColumn_Laser)
            {
               dt_Laser.Columns.Add("STOCK_NO", typeof(String));
               dt_Laser.Columns.Add("MAT_NO", typeof(String));
            }
        }

        private void btnAddlist_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                bool hasChecked = (bool)dataGridView1.Rows[i].Cells["CHECK_COLUMN"].EditedFormattedValue;
                if (hasChecked)
                {
                    string matNo = dataGridView1.Rows[i].Cells["MAT_NO"].Value.ToString();            //材料号

                    if (!this.listBox1.Items.Contains(matNo))
                    {
                        this.listBox1.Items.Add(matNo);
                    }
                    else
                    {
                        MessageBox.Show("该材料已添加,无法重复添加！！！");
                    }
                }
            }

        }

        private void btnRemoveCoil_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                string checkPeople = this.listBox1.SelectedItem.ToString();
                //移除listbox1中
                this.listBox1.Items.Remove(checkPeople);
            }
            else
                MessageBox.Show("请选卷");
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //停车位号|CaoNO|处理号|模型计算次数|配载图ID-卷|卷
            if (listBox1.Items.Count > 0)
            {
                StringBuilder str = new StringBuilder(packing.PackingNo);
                str.Append("|" + packing.CarNo);
                str.Append("|" + packing.TREATMENT_NO);
                str.Append("|1" );
                str.Append("|" + packing.STOWAGE_ID + "-");

                foreach (string itemValue in listBox1.Items)
                {
                    str.Append(itemValue + "|");
                }


                string subStr =  str.ToString().Substring(0,str.ToString().Count() - 1);

                tagDP.SetData("EV_PARKING_MDL_OUT_CAL_START", subStr);

                MessageBox.Show(subStr);
            }
            
           
        }

        
    }
}
