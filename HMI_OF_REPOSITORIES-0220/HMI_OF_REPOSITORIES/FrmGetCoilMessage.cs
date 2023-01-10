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

namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmGetCoilMessage : FormBase
    {
        public FrmGetCoilMessage()
        {
            InitializeComponent();
        }

        public FrmGetCoilMessage(string coil)
        {
            InitializeComponent();
            txtCoilNo.Text = coil;
            CoilMessage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoilMessage();
        }

        private void CoilMessage()
        {
            CoilMessage coilMessage = new CoilMessage();
            //coilMessage.GetCoilMessageByCoil(dgvCoilMessage, txtCoilNo.Text.Trim());

            if (txtCoilNo.Text.Trim() == "" || txtCoilNo.Text.Trim().Length<4)
            {
                MessageBox.Show("请至少输入4位钢卷号！","提示" ,MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            coilMessage.GetCoilMessageByCoil(dgvCoilMessage, txtCoilNo.Text.Trim(), cmbPlantype.Text.Trim());
            if (dgvCoilMessage.Rows.Count==0)
            {
                MessageBox.Show(string .Format("没有找到指定钢卷号：{0}",txtCoilNo.Text.Trim()),"提示" ,MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FrmGetCoilMessage_Load(object sender, EventArgs e)
        {
            UACSUtility.ViewHelper.DataGridViewInit(dgvCoilMessage);
            dgvCoilMessage.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void txtCoilNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void dgvCoilMessage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var senderdgv = (DataGridView)sender;

            if (senderdgv.Columns[e.ColumnIndex].Name.Equals("LOGISTICS_FLAG") && e.Value != null)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "南流向";
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else if (e.Value.ToString() == "2")
                {
                    e.Value = "北流向";
                    e.CellStyle.BackColor = Color.Pink;
                }
                else if (e.Value.ToString() == "3")
                {
                    e.Value = "铁运";
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (e.Value.ToString() == "4")
                {
                    e.Value = "中集商务";
                    e.CellStyle.BackColor = Color.Peru;
                }
                else
                {
                    //e.Value = "";
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }
        
    }
}
