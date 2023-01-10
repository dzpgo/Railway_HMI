using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkClassLibrary;

namespace UACSParking
{
    public partial class SubFrmTrainCaseTypeSelect : Form
    {
        public SubFrmTrainCaseTypeSelect()
        {
            InitializeComponent();
            this.Load += SubFrmTrainCaseTypeSelect_Load;
            cmbbStowageType.SelectedIndexChanged += cmbbStowageType_SelectedIndexChanged;
        }

        void cmbbStowageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpecificationNew = cmbbStowageType.SelectedValue.ToString();
            btnConfirm.Text = (specification == SpecificationNew) ? "确定" : "修改";
        }

        void SubFrmTrainCaseTypeSelect_Load(object sender, EventArgs e)
        {
            BindTrainCaseType();
            switch (Specification)
            {
                case ClsParkingManager.TRAIN_SPECIFICATION_C60:
                    cmbbStowageType.Text = "60吨(12.5米)";
                    break;
                //case ClsParkingManager.TRAIN_SPECIFICATION_C61:
                //    cmbbStowageType.Text = "61吨(12.5米)";
                //    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C70:
                    cmbbStowageType.Text = "70吨(13米)";
                    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C71:
                    cmbbStowageType.Text = "71吨(13.5米)";
                    break;
                //睿力新支架
                case ClsParkingManager.TRAIN_SPECIFICATION_C60_1:
                    cmbbStowageType.Text = "睿力60吨(12.5米)";
                    break;
                //case ClsParkingManager.TRAIN_SPECIFICATION_C61_1:
                //    cmbbStowageType.Text = "睿力61吨(12.5米)";
                //    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C70_1:
                    cmbbStowageType.Text = "睿力70吨(13米)";
                    break;
                case ClsParkingManager.TRAIN_SPECIFICATION_C71_1:
                    cmbbStowageType.Text = "睿力71吨(13.5米)";
                    break;
                default:
                    cmbbStowageType.Text = "";
                    break;
            }
            cmbbStowageType_SelectedIndexChanged(null, null);
        }
        private string railwayLineNO; //轨道号

        public string RailwayLineNO
        {
            get { return railwayLineNO; }
            set { railwayLineNO = value; txtRailwayLineNO.Text = railwayLineNO; txtRailwayLineNO.Enabled = false; }
        }
        private string trainCaseNO; //车皮号

        public string TrainCaseNO
        {
            get { return trainCaseNO; }
            set { trainCaseNO = value; txtTrainCaseIndex.Text = trainCaseNO; txtTrainCaseIndex.Enabled = false; }
        }
        private string specification; //当前规格

        public string Specification
        {
            get { return specification; }
            set { specification = value; }
        }
        string specificationNew;  //新选规格

        public string SpecificationNew 
        {
            get { return specificationNew; }
            set { specificationNew = value; }
        }
        string trainCaseName = "";   //车皮牌号

        public string TrainCaseName
        {
            get { return trainCaseName; }
            set { trainCaseName = value; }
        }

        private void BindTrainCaseType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr = dt.NewRow();

            dr = dt.NewRow();
            dr["TypeValue"] = "C60";
            dr["TypeName"] = "60吨(12.5米)";  //12.5米
            dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["TypeValue"] = "C61";
            //dr["TypeName"] = "61吨(12.5米)";  //
            //dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "C70";
            dr["TypeName"] = "70吨(13米)";  //13
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = "C71";
            dr["TypeName"] = "71吨(13.5米)";  //13.5
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = ClsParkingManager.TRAIN_SPECIFICATION_C60_1;
            dr["TypeName"] = "睿力60吨(12.5米)";  //12.5米
            dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["TypeValue"] = "C61_1";
            //dr["TypeName"] = "睿力61吨(12.5米)";  //
            //dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = ClsParkingManager.TRAIN_SPECIFICATION_C70_1;
            dr["TypeName"] = "睿力70吨(13米)";  //13
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TypeValue"] = ClsParkingManager.TRAIN_SPECIFICATION_C71_1;
            dr["TypeName"] = "睿力71吨(13.5米)";  //13.5
            dt.Rows.Add(dr);

            //绑定列表下拉框数据
            this.cmbbStowageType.DataSource = dt;
            this.cmbbStowageType.DisplayMember = "TypeName";
            this.cmbbStowageType.ValueMember = "TypeValue";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (SpecificationNew == specification)
            //{
            //    this.Close();
            //    return;
            //}
            if(SpecificationNew!=null)
            {
                if (TrainCaseName =="")
                {
                    TrainCaseName = TrainCaseNO;
                }
                //string strTemp = "";
                //if (SpecificationNew.Contains('_'))
                //{
                //    strTemp = SpecificationNew.Substring(0, SpecificationNew.IndexOf('_'));  //C60_1
                //}
                //else
                //{
                //    strTemp = SpecificationNew;
                //}
                string tagValue = RailwayLineNO + "|" + TrainCaseNO + "|" + SpecificationNew;
                ///////string tagValue = RailwayLineNO + "|" + TrainCaseNO + "|" + strTemp + "|" + TrainCaseName;
                //DialogResult dr = MessageBox.Show("是否发送tagVaule： " + tagValue, "调试", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                //if (dr != DialogResult.OK)
                //{
                //    return;
                //}
                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_TYPE_MODIFY, tagValue);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpecificationNew = Specification;
            this.Close();

        }

        private void txtTrainCaseNO_TextChanged(object sender, EventArgs e)
        {
            TrainCaseName = txtTrainCaseNO.Text;
        }

    }
}
