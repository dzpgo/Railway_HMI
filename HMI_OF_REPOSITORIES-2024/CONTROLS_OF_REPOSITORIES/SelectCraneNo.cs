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
    public partial class SelectCraneNo : Form
    {
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = null;
        public string bayNo = String.Empty;
        public  string craneNo = String.Empty;
        public string orderNo = String.Empty;
        public string returnCraneNo = String.Empty;
        private bool firstItem = true;

        public SelectCraneNo()
        {
            InitializeComponent();
            DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
        }

        private void SelectCraneNo_Load(object sender, EventArgs e)
        {
            try
            {
                if (craneNo.Trim() != String.Empty)
                {
                    this.label1.Text = string.Format("指令{0}原指定{1}行车执行，现修改为：", orderNo, craneNo);
                }
                else
                {
                    this.label1.Text = string.Format("指令{0}原未指定行车执行，现修改为：", orderNo, craneNo);
                }
                DataTable dt = GetCraneNoData();
                ShowControl(dt);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private DataTable GetCraneNoData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");
            string sqlText = @"SELECT ID,NAME FROM UACS_YARDMAP_CRANE WHERE BAY_NO = '{0}'";
            sqlText = string.Format(sqlText, bayNo);
            dt.Clear();
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dr[i] = rdr[i];
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private void ShowControl(DataTable dt)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ID"].ToString() == craneNo)
                {
                    continue;
                }
                if (50 + (x + 1) * 110 > this.Width)
                {
                    x = 0;
                    y++;
                }
                int locationX = 50 + x * 110;
                int locationY = 50 + y * 40;
                System.Windows.Forms.RadioButton radioButton = new System.Windows.Forms.RadioButton();
                radioButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                radioButton.Location = new System.Drawing.Point(locationX, locationY);
                radioButton.Name = "r" + i;

                radioButton.Size = new System.Drawing.Size(100, 30);
                radioButton.TabIndex = 0;
                radioButton.Tag = dt.Rows[i]["ID"].ToString();
                radioButton.Text = dt.Rows[i]["ID"].ToString();
                radioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
                radioButton.UseVisualStyleBackColor = true;
                this.Controls.Add(radioButton);
                if (firstItem)
                {
                    radioButton.Checked = true;
                    firstItem = false;
                }
                x++;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                returnCraneNo = ((RadioButton)sender).Tag.ToString();
            }
        }
    }
}
