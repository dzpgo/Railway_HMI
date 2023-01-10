using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Authorization.Interface;

namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmParkSafeGateView : Baosight.iSuperframe.Forms.FormBase
    {

        public FrmParkSafeGateView()
        {
            InitializeComponent();
        }

        IAuthorization auth = Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<Baosight.iSuperframe.Authorization.Interface.IAuthorization>()
       as Baosight.iSuperframe.Authorization.Interface.IAuthorization;


        #region    按钮功能
        private void button1_Click(object sender, EventArgs e)
        {
            DaoZhaForm form = new DaoZhaForm();
            form.ShowDialog(this);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CarForm form = new CarForm();
            form.ShowDialog(this);
        }


        private void btnToStock_Click_1(object sender, EventArgs e)
        {
            auth.OpenForm("4.1库位实时状态");
        }

        private void btnToStat_Click(object sender, EventArgs e)
        {
            auth.OpenForm("4.3库位统计分析");
        }

        private void btnToSafe_Click(object sender, EventArgs e)
        {
            auth.OpenForm("2.2出入库记录");
        }
        #endregion
        private void ParkSafeGateView_Load(object sender, EventArgs e)
        {
            //库区信息显示
         }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //从数据库刷新库位状态
        }

    }
}
