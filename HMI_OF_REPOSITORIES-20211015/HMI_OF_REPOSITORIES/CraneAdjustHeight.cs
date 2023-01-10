using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;

namespace HMI_OF_REPOSITORIES
{

    public partial class CraneAdjustHeight : FormBase
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
        public CraneAdjustHeight()
        {
            InitializeComponent();
            this.Load += CraneAdjustHeight_Load;
            txtHeight.KeyPress += txtHeight_KeyPress;
        }

        void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtHeight.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtHeight.Text, out oldf);
                    b2 = float.TryParse(txtHeight.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        void CraneAdjustHeight_Load(object sender, EventArgs e)
        {
            BindCarType(cmbCrane);
           this.BackColor= Color.FromArgb(242, 246, 252);
        }

        private void BindCarType(ComboBox cmbBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr;
            dr = dt.NewRow();
            dr["TypeValue"] = "1";
            dr["TypeName"] = "1#行车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "2";
            dr["TypeName"] = "2#行车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "3";
            dr["TypeName"] = "3#行车";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "7";
            dr["TypeName"] = "7#行车";
            dt.Rows.Add(dr);


            dr = dt.NewRow();
            dr["TypeValue"] = "8";
            dr["TypeName"] = "8#行车";
            dt.Rows.Add(dr);
            //绑定列表下拉框数据
            cmbBox.DataSource = dt;
            cmbBox.DisplayMember = "TypeName";
            cmbBox.ValueMember = "TypeValue";
        }
        
        private void btnCommit_Click(object sender, EventArgs e)
        {
            string tagName = cmbCrane.SelectedValue.ToString().Trim();
            tagName += "_DownLoadOrder_Z";
            StringBuilder sb = new StringBuilder("");
            sb.Append(cmbCrane.SelectedValue.ToString().Trim());
            sb.Append("|");
            sb.Append(txtHeight.Text.Trim());
            //DialogResult dResult = MessageBox.Show(sb.ToString(), "调试", MessageBoxButtons.YesNo);
            //if (dResult == DialogResult.No)
            //{
            //    return;
            //}
            if (txtPassWord.Text=="123456")
            {
                DialogResult br = MessageBox.Show(string.Format("确定要对行车：{0}#  进行重新标定？", cmbCrane.SelectedValue.ToString().Trim()), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (br == DialogResult.Yes)
                {
                    TagDP.SetData(tagName, sb.ToString());
                    MessageBox.Show(string.Format("行车：{0}#  码值提交成功", cmbCrane.SelectedValue.ToString().Trim()), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    UACSUtility.HMILogger.WriteLog(btnCommit.Text, "码值提交成功,行车：" + cmbCrane.SelectedValue.ToString().Trim(), UACSUtility.LogLevel.Info, this.Text);
                }
            }
            else
                MessageBox.Show(string.Format("密码不正确！"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtHeight.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
