using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSUtility;

namespace HMI_OF_REPOSITORIES
{
    public partial class FrmCarHearInf : Baosight.iSuperframe.Forms.FormBase
    {
        public FrmCarHearInf()
        {
            InitializeComponent();
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
                    catch (System.Exception e)
                    {
                        //throw e;
                    }
                }
                return dbHelper;
            }
        }
        #endregion
        #region 画面导入
        private void FrmCarHear_Load(object sender, EventArgs e)
        {
            UACSUtility.ViewHelper.DataGridViewInit(dgvCarHead);
            GetCarHeadInf();
        } 
        #endregion

        #region 方法
        private void GetCarHeadInf()
        {
            DataTable dtcarH=new DataTable();
           try 
	        {	        
		        string  sqlText = @"SELECT * FROM UACS_CAR_HEAD_DEFINE WHERE 1 = 1 ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    dtcarH.Load(rdr);
                }
                dgvCarHead.DataSource=dtcarH;
	        }
	        catch (Exception er)
	        {
                MessageBox.Show(er.Message);
	        }
        }
        /// <summary>
        /// 定位到指定的行
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="searchString"></param>
        /// <param name="columnName"></param>
        private void SelectDataGridViewRow(DataGridView dgv, string searchString, string columnName)
        {
            try
            {
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (dgvRow.Cells[columnName].Value != null)
                    {
                        if (dgvRow.Cells[columnName].Value.ToString() == searchString)
                        {
                            dgv.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                            dgvRow.Cells[columnName].Selected = true;
                            dgv.CurrentCell = dgvRow.Cells[columnName];
                            return;
                        }
                    }
                }
                MessageBox.Show(string.Format("没有找到指定的信息：{0}", searchString));
            }

            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        /// <summary>
        /// text文本输入转大写
        /// </summary>
        /// <param name="txt"></param>
        private void TxtStrTOUpper(TextBox txt)
        {
            string UpTem = txt.Text;
            txt.Text = UpTem.ToUpper().Trim();
            txt.SelectionStart = txt.Text.Length;
            txt.SelectionLength = 0;
        }
        #endregion

        #region 查询
        private void btnSerch_Click(object sender, EventArgs e)
        {
            if ( txtCarNum.Text.Trim()!="")
            {
                string carNO = dgvCarHead.Columns[0].Name;
                SelectDataGridViewRow(dgvCarHead, txtCarNum.Text.Trim(), carNO);
            }
            else if (txtLicenceNO.Text.Trim()!="")
            {
                string carLicenNO = dgvCarHead.Columns[1].Name;
                SelectDataGridViewRow(dgvCarHead, txtLicenceNO.Text.Trim(), carLicenNO);
            }


        } 
        #endregion

        private void txtLicenceNO_TextChanged(object sender, EventArgs e)
        {
            if (!txtCarNum.Focused)
            {
                txtCarNum.Text = "";
            }
            TxtStrTOUpper(txtLicenceNO);
        }

        private void txtCarNum_TextChanged(object sender, EventArgs e)
        {
            if (!txtLicenceNO.Focused)
            {
                txtLicenceNO.Text = "";
            }
            TxtStrTOUpper(txtCarNum);
        }



    }
}
