using Baosight.iSuperframe.TagService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSParking
{
    public partial class FrmCarEntry : Form
    {
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        public FrmCarEntry()
        {
            InitializeComponent();
            this.Load += FrmCarEntry_Load;
        }
        /// <summary>
        /// 停车位
        /// </summary>
        public string PackingNo { get; set; }
        private string carType = "";
        string carFlag="1";
        string carDirection="";

        public string CarType
        {
            get { return carType; }
            set { carType = value; }
        }
        void FrmCarEntry_Load(object sender, EventArgs e)
        {


            txtPacking.Text = PackingNo;

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add("EV_NEW_PARKING_CARARRIVE", null);
            tagDP.Attach(TagValues);

            this.Text = string.Format("{0}到位", carType);
            if (carType== "框架车")
            {
                txtDirection.Enabled = false;
                txtDirection.Text = "东";
                txtDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;  
            }
            else if (carType == "社会车")
            {
                txtDirection.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtPacking.Text.ToString().Contains('Z') || txtPacking.Text.ToString().Trim()=="请选择")
            {
                MessageBox.Show("请先选择停车位！！", "提示");
                this.Close();
                return;
            }
            //框架车
            if (carType == "框架车")
            {
                txtDirection.Text = "东";
               // txtDirection.Enabled = false ;
                txtDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                //txtDirection
                if ( txtDirection.Text.Trim()=="东")
                {
                    carDirection = "E";
                }
                else if (txtDirection.Text.Trim() == "西")
                {
                    carDirection = "W";
                }
                if (txtCarNo.Text.Trim() != "" || txtDirection.Text.Trim() != "" || txtFlag.Text.Trim() != "" || txtPacking.Text.Trim() != "")
                {
                    //操作人|日期|班次|班组|停车位|车号|空满标记|车头方向|载重能力|设备号
                    //车头位置(东：E 西：W 南：S 北：N)
                    StringBuilder sb = new StringBuilder("HMI");
                    sb.Append("|");
                    sb.Append(DateTime.Now.ToString("yyyyMMdd"));
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append(txtPacking.Text.Trim());
                    sb.Append("|");
                    sb.Append(txtCarNo.Text.ToUpper().Trim());
                    sb.Append("|");
                    sb.Append(carFlag.Trim());
                    sb.Append("|");
                    sb.Append(carDirection.Trim());
                    sb.Append("|");
                    sb.Append("90");
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append("100"); //100
                    sb.Append("|");
                    sb.Append("0");

                    tagDP.SetData("EV_NEW_PARKING_CARARRIVE", sb.ToString());
                    //richTextBox1.Text += string.Format("tag值：{0}", sb.ToString());
                   // MessageBox.Show("已通知到达");
                    DialogResult dr = MessageBox.Show("框架车车到位成功，激光扫描开始，请保证车位上方没有行车经过。", "提示", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("请填写完整");
            }
            else if (carType == "社会车")
            {
                if (txtDirection.Text.Trim() == "东")
                {
                    carDirection = "E";
                }
                else if (txtDirection.Text.Trim() == "西")
                {
                    carDirection = "W";
                }
                if (txtCarNo.Text.Trim() != "" || txtDirection.Text.Trim() != "" || txtFlag.Text.Trim() != "" || txtPacking.Text.Trim() != "")
                {
                    //操作人|日期|班次|班组|停车位|车号|空满标记|车头方向|载重能力|设备号
                    //车头位置(东：E 西：W 南：S 北：N)
                    StringBuilder sb = new StringBuilder("HMI");
                    sb.Append("|");
                    sb.Append(DateTime.Now.ToString("yyyyMMdd"));
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append(txtPacking.Text.Trim());
                    sb.Append("|");
                    sb.Append(txtCarNo.Text.ToUpper().Trim());
                    sb.Append("|");
                    sb.Append(carFlag.Trim());
                    sb.Append("|");
                    sb.Append(carDirection.Trim());
                    sb.Append("|");
                    sb.Append("90");
                    sb.Append("|");
                    sb.Append("1");
                    sb.Append("|");
                    sb.Append("101");
                    sb.Append("|");
                    sb.Append("0");

                    tagDP.SetData("EV_NEW_PARKING_CARARRIVE", sb.ToString());
                    //richTextBox1.Text += string.Format("tag值：{0}", sb.ToString());
                    //MessageBox.Show("已通知到达");
                    DialogResult dr = MessageBox.Show("社会车车到位成功，激光扫描开始，请保证车位上方没有行车经过。", "提示", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("请填写完整");
            }

            else
                MessageBox.Show("不存在该出库类型！");
        }

        private void FrmCarEntry_Activated(object sender, EventArgs e)
        {
            txtCarNo.Focus();
        }

        private void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            string UpTem = txtCarNo.Text;
            txtCarNo.Text = UpTem.ToUpper().Trim();
            txtCarNo.SelectionStart = txtCarNo.Text.Length;
            txtCarNo.SelectionLength = 0;
        }
    }
}
