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
using Baosight.iSuperframe.Utility;
using ParkClassLibrary;
using UACSParking;

namespace UACSParking
{
    public partial class FrmRailwayParkingOut : Baosight.iSuperframe.Forms.FormBase
    {
        Baosight.iSuperframe.Authorization.Interface.IAuthorization auth = Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<Baosight.iSuperframe.Authorization.Interface.IAuthorization>()
        as Baosight.iSuperframe.Authorization.Interface.IAuthorization;

        ClsParkingManager parkingManager = new ClsParkingManager();
        string preTrainNum = "";
        int trainCaseCount;
        /// <summary>
        /// 当前选中火车皮 中间类，用于数据交换
        /// </summary>
        ClsTrainCase mClsTrainCase = null;

        string[] curOrderMatNO = { };

        //标记位
        bool isReflaseHMILocation = false;
        
        //轨道号
        string railwayLineNO = "";
        public FrmRailwayParkingOut()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            cmbTrainLine.Text = "A跨 PT55";
            railwayLineNO = cmbTrainLine.Text.Contains("PT55") ?
                ClsParkingManager.TRAIN_RAILWAYLINE_PT55 : cmbTrainLine.Text.Contains("PT57A") ?
                ClsParkingManager.TRAIN_RAILWAYLINE_PT57_1 : cmbTrainLine.Text.Contains("PT57B") ?
                ClsParkingManager.TRAIN_RAILWAYLINE_PT57_2 : "";
        }

        private void FrmRailwayParkingOut_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(242, 246, 252);
            pnlRailwayArea.Paint += pnlRailwayArea_Paint;
            foreach (TabPage item in tabControl1.TabPages)
            {
                item.BackColor = Color.FromArgb(242, 246, 252);
            }
            ManagerHelper.DataGridViewInit(dataGridView_LaodMap);
            ManagerHelper.DataGridViewInit(dgvCraneOder);
            ManagerHelper.DataGridViewInit(dgvLaser);
            trainStowage1.SendLabName += trainStowage1_SendLabName;
            //step1 生成火车皮
            if (parkingManager.getRaliwayStatus(out trainCaseCount, railwayLineNO))
            {
                //if (trainCaseCount > 0)
                {
                    createTrainCase(railwayLineNO, trainCaseCount);
                    timerRefresh.Enabled = true;
                }
            }
            else
            {
                return;
            }
            //step2 初始化大小
            initializeRailwaySize();

            cmbTrainLine.SelectedIndexChanged += cmbTrainLine_SelectedIndexChanged;
        }

        void cmbTrainLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            railwayLineNO = cmbTrainLine.Text.Contains("PT55") ?
            ClsParkingManager.TRAIN_RAILWAYLINE_PT55 : cmbTrainLine.Text.Contains("PT57A") ?
            ClsParkingManager.TRAIN_RAILWAYLINE_PT57_1 : cmbTrainLine.Text.Contains("PT57B") ?
            ClsParkingManager.TRAIN_RAILWAYLINE_PT57_2 : "";
                    
                btnTrainCaseTypeCommit.Enabled = true;
                btnTrainCaseSelect.Enabled = true;

                btnSelectStowage.Enabled = true;
                btnStowageCommit.Enabled = true;
                                               
            btnReflesh_Click(null, null);
        }

        void trainStowage1_SendLabName(string labNane)
        {
            parkingManager.SelectDataGridViewRow(dataGridView_LaodMap, labNane, "MAT_NO2");
        }

        //火车皮单击触发事件
        void trainCase_SendTrainCls(ClsTrainCase clsTrain)
        {
            foreach (railwayCarriage item in pnlRailwayArea.Controls)
            {
                if (item.ClsTrainCase.TrainCaseNO == preTrainNum)
                {
                    item.setBackColor(Color.Silver);  //恢复
                }
                if (item.ClsTrainCase.TrainCaseNO == clsTrain.TrainCaseNO)
                {
                    item.setBackColor(Color.LightSkyBlue); //选中
                    mClsTrainCase = (ClsTrainCase)clsTrain.Clone();
                }  
            }
            preTrainNum = clsTrain.TrainCaseNO;
          

            //刷新配载图
            if (clsTrain.StowageID != null && clsTrain.StowageID != "")
	        {
                Point trainP;Size trainS;
                if (parkingManager.getTainCaseLaserInfo(clsTrain.StowageID,out trainP, out trainS))
                {
                    //初始化控件
                    trainStowage1.initializeControlToActual(trainP.X, trainP.Y, trainS.Width, trainS.Height);
                    parkingManager.getLaserOutInfo(dgvLaser, clsTrain.StowageID);                    
                }
                else
                {
                    dgvLaser.DataSource = new DataTable();
                }
                getStowageDitail(clsTrain.StowageID);//获取配载信息，绑定钢卷字典数据                                                 
	        }
            trainStowage1.setClsTrainCase( (ClsTrainCase)clsTrain.Clone());  //是最新的类吗？
            trainStowage1.updataStowage();
            //返回新的类覆盖
            cloneToCurrTrainCase(trainStowage1.ClsTrainStowage);
            refreshHMI();
        }
        //画铁轨
        void pnlRailwayArea_Paint(object sender, PaintEventArgs e)
        {
            parkingManager.paintRailwayPathWay(pnlRailwayArea);
        }
        //车到达
        private void cmd_CarArrive_Click(object sender, EventArgs e)
        {
            if(judgeTrainHas())
            {
                MessageBox.Show("车位已有车！");
                //cmd_CarArrive.Enabled = false; 
                return;
            }
            FrmTrainArrive form = new FrmTrainArrive(railwayLineNO);
            form.sendTrainsCount += form_sendTrainsCount;
            form.Show();
            //form.ShowDialog();
            //trainCaseCount = form.TrainCaseCount;
            //string railwayLineNO = form.RailWayLineNO;
            //if (trainCaseCount>0)
            //{
            //    createTrainCase(railwayLineNO,trainCaseCount);
            //}
            //车皮默认配置(有可能时间反应不过来)
            //parkingManager.setAllTrainCaseType(trainCaseCount, ClsParkingManager.TRAIN_SPECIFICATION_C60);
        }

        void form_sendTrainsCount(string railwayLineNO, int count)
        {
            if (count > 0)
            {
                trainCaseCount = count;
                createTrainCase(railwayLineNO, trainCaseCount);
            }
        }

        //激光
        private void cmd_LaserINStart_Click(object sender, EventArgs e)
        {
            string tagValue = "PT55|-9";
            DialogResult dr = MessageBox.Show("是否发送tagVaule： " + tagValue, "调试", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr != DialogResult.OK)
            {
                return;
            }
            ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_PARKING_LASERSTART_COACH, tagValue);
        }

         private void createTrainCase(string lineNO,int count)
        {
            pnlRailwayArea.Controls.Clear();
            
            mClsTrainCase = null;
            //信息显示
            trainCaseInfo1.setClsTrainInfo ( new ClsTrainCase());
            trainCaseInfo1.updataTrainInfo();
            trainStowage1.setClsTrainCase(  new ClsTrainCase());
            trainStowage1.updataStowage();
            dataGridView_LaodMap.DataSource = new DataTable();
            if (count<=0)
            {
                parkingManager = new ClsParkingManager();
                btnTrainCaseSelect.Enabled = true;
                btnTrainCaseTypeCommit.Enabled = true;
                btnSelectStowage.Enabled = true;
                btnStowageCommit.Enabled = true;
                timerRefresh.Enabled = false;

                return;
            }

            List<Point> listPoints = new List<Point>();
            for (int i = 0; i < count; i++)
            {
                Point point1 = new Point(0, 5);
                point1.X = i * 140 + 5;  //120
                listPoints.Add(point1);
            }
            int TrainNum = count;
            foreach (Point item in listPoints)
            {

                railwayCarriage trainCase = new railwayCarriage(new Size(130, 115));   //120, 85
                trainCase.Location = item;
                trainCase.ClsTrainCase.RailwayLineNO = lineNO;
                trainCase.ClsTrainCase.TrainCaseNO = TrainNum.ToString();
                trainCase.ClsTrainCase.Specification = ClsParkingManager.TRAIN_SPECIFICATION_C60;
                TrainNum--;
                trainCase.SendTrainCls += trainCase_SendTrainCls;
                pnlRailwayArea.Controls.Add(trainCase);
                trainCase.updataTrain();
            }
        }
        //选择配载方案
        private void btnSelectStowage_Click(object sender, EventArgs e)
        {
            if (mClsTrainCase != null)
            {
                if (mClsTrainCase.IsConfirmStowageType)
                {
                    MessageBox.Show("配载已确认！");
                    btnSelectStowage.Enabled = false;
                    btnStowageCommit.Enabled = false;
                    return;
                }
                else
                {
                    btnSelectStowage.Enabled = true;
                    btnStowageCommit.Enabled = true;
                }
            }
            SubFrmSelectStowageType form = new SubFrmSelectStowageType();
            if (mClsTrainCase!=null)
            {
                form.RailwayLineNO = mClsTrainCase.RailwayLineNO;
                form.Specification = mClsTrainCase.Specification;
                form.TrainCaseNO = mClsTrainCase.TrainCaseNO;
                form.StowageName = mClsTrainCase.StowageName;
                form.ShowDialog();
            }
            if (mClsTrainCase!=null && form.SelectedStowage!="")
            {
                mClsTrainCase.StowageType = form.SelectedStowage;
                mClsTrainCase.StowageName = form.StowageName;               
                cloneToCurrTrainCase(mClsTrainCase);
                trainCase_SendTrainCls(mClsTrainCase);
                timerRefresh.Enabled = true;
            }

        }
        //配卷
        private void btnSelectCoil_Click(object sender, EventArgs e)
        {
            if (mClsTrainCase!=null)
            {
                if (mClsTrainCase.TrainCaseStatus>10)
                {
                    DialogResult dr =  MessageBox.Show("是否重新选卷？","",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                    if (dr !=DialogResult.Yes)
                    {
                        return;
                    }
                }
                SubFrmTrainSelectCoil form = new SubFrmTrainSelectCoil(mClsTrainCase);

                form.TrainSelectCoilCommit += form_TrainSelectCoilCommit;
                form.ShowDialog(); 
                //if (auth.IsOpen("02-火车配卷"))
                //{
                //    auth.CloseForm("02-火车配卷");
                //    auth.OpenForm("02-火车配卷", mClsTrainCase);
                //}
                //else
                //    auth.OpenForm("02-火车配卷", mClsTrainCase);


            }

        }
        //选卷确认
        void form_TrainSelectCoilCommit(ClsTrainCase clsTrainCase)
        {
            mClsTrainCase = new ClsTrainCase();
            mClsTrainCase = (ClsTrainCase)clsTrainCase.Clone();
            cloneToCurrTrainCase(mClsTrainCase);
        }
        //修改车皮类型
        private void btnTrainCaseSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (mClsTrainCase != null)
                {
                    if (mClsTrainCase.IsConfirmTrainCaseType)
                    {
                        MessageBox.Show("车皮已确认！");
                        btnTrainCaseSelect.Enabled = false;
                        btnTrainCaseTypeCommit.Enabled = false;
                        return;
                    }
                    else
                    {
                        btnTrainCaseTypeCommit.Enabled = true;
                        btnTrainCaseSelect.Enabled = true;
                    }
                    SubFrmTrainCaseTypeSelect form = new SubFrmTrainCaseTypeSelect();
                    form.RailwayLineNO = mClsTrainCase.RailwayLineNO;
                    form.TrainCaseNO = mClsTrainCase.TrainCaseNO;
                    form.Specification = mClsTrainCase.Specification;
                    form.TrainCaseName = mClsTrainCase.TrainCaseName;
                    form.ShowDialog();
                    mClsTrainCase.Specification = form.SpecificationNew != mClsTrainCase.Specification ? form.SpecificationNew : mClsTrainCase.Specification;
                    mClsTrainCase.TrainCaseName = form.TrainCaseName;

                    cloneToCurrTrainCase(mClsTrainCase);
                    parkingManager.setTrainCaseName(railwayLineNO,  mClsTrainCase.TrainCaseNO, mClsTrainCase.TrainCaseName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

        }

        private bool getCurrTrainCase(string TrainNO)
        {
            bool ret = false;
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage &&  ((railwayCarriage)item).ClsTrainCase.TrainCaseNO==TrainNO)
                {
                    ret = true;
                }
            }
            return ret;
        }
        private bool cloneToCurrTrainCase(ClsTrainCase mClsTrainCase)
        {
            bool ret = false;
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage && ((railwayCarriage)item).ClsTrainCase.TrainCaseNO == mClsTrainCase.TrainCaseNO)
                {
                    //((railwayCarriage)item).ClsTrainCase = (ClsTrainCase)mClsTrainCase.Clone();
                    ((railwayCarriage)item).setClsTrainCase((ClsTrainCase)mClsTrainCase.Clone());
                    ret = true;
                }
                //((railwayCarriage)item).updataTrain(); 
            }
            return ret;
        }
        //车皮确认
        private void btnTrainCaseTypeCommit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("车皮类型确认后将不能修改，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr !=DialogResult.Yes)
                {
                    return;
                }
               if(mClsTrainCase!=null)
               {
                   if (mClsTrainCase.IsConfirmTrainCaseType)
                   {
                       MessageBox.Show("车皮已确认！");
                       btnTrainCaseSelect.Enabled = false;
                       btnTrainCaseTypeCommit.Enabled = false;
                       return;
                   }
               }
               else
               {
                   btnTrainCaseTypeCommit.Enabled = true;
                   btnTrainCaseSelect.Enabled = true;
               }
                //确认前修改
                foreach (var item in pnlRailwayArea.Controls)
                {
                    if (item is railwayCarriage)
                    {
                        string tagVaule = railwayLineNO + "|" + ((railwayCarriage)item).ClsTrainCase.TrainCaseNO + "|" + ((railwayCarriage)item).ClsTrainCase.Specification;
                        ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_TYPE_MODIFY, tagVaule);
                    }
                }
                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_TYPE_MODIFY_FINISHED, mClsTrainCase.RailwayLineNO + "|" + trainCaseCount);
                btnTrainCaseSelect.Enabled = false;
                btnTrainCaseTypeCommit.Enabled = false;
                if (mClsTrainCase!=null)
                {
                    mClsTrainCase.IsConfirmTrainCaseType = true;
                }
                foreach (var item in pnlRailwayArea.Controls)
                {
                    if (item is railwayCarriage)
                    {
                        ((railwayCarriage)item).ClsTrainCase.IsConfirmTrainCaseType = true;
                        ((railwayCarriage)item).updataTrain();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        //配载确认
        private void btnStowageCommit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("配载类型确认后将不能修改，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
                if (mClsTrainCase != null)
                {
                    if (mClsTrainCase.IsConfirmStowageType)
                    {
                        MessageBox.Show("配载已确认！");
                        btnSelectStowage.Enabled = false;
                        btnStowageCommit.Enabled = false;
                        return;
                    }
                    else
                    {
                        btnSelectStowage.Enabled = true;
                        btnStowageCommit.Enabled = true;
                    }
                }
                string tagValue = "";
                tagValue += railwayLineNO + "-";
                foreach (var item in pnlRailwayArea.Controls)
                {
                    if (item is railwayCarriage)
                    {
                        if (((railwayCarriage)item).ClsTrainCase.StowageName!=null && ((railwayCarriage)item).ClsTrainCase.StowageName!="")
                        {                           
                            tagValue += ((railwayCarriage)item).ClsTrainCase.TrainCaseNO;
                            tagValue += "|";
                        }  
                    }
                }
                if (tagValue.Contains('|'))
                {
                    tagValue = tagValue.Substring(0, tagValue.LastIndexOf('|'));
                }
                //DialogResult dr = MessageBox.Show("是否发送tagVaule： " + tagValue, "调试", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                //if (dr != DialogResult.OK)
                //{
                //    return;
                //}
                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_CARGO_STOWAGE_MODIFY_FINISHED, tagValue);
                btnSelectStowage.Enabled = false;
                btnStowageCommit.Enabled = false;
                if (mClsTrainCase!=null)
                {
                    mClsTrainCase.IsConfirmStowageType = true;
                }
                foreach (var item in pnlRailwayArea.Controls)
                {
                    if (item is railwayCarriage)
                    {
                        ((railwayCarriage)item).ClsTrainCase.IsConfirmStowageType = true;
                        ((railwayCarriage)item).updataTrain();
                    }
                }
                //开启刷新
                timerRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void btnTrainLeave_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("是否做火车离开?", "提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk);
            //if (dr != DialogResult.OK)
            //{
            //    //this.Close();
            //    return;
            //}
            DialogResult dr = MessageBox.Show("火车车离？ " + railwayLineNO, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr != DialogResult.OK)
            {
                return;
            }
            #region 自动销账
            //自动销账
            string tagValueXZ = "";
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage)
                {
                    railwayCarriage mCase = (railwayCarriage)item;
                    string mStowageID = mCase.ClsTrainCase.StowageID;
                    tagValueXZ += mStowageID;
                    tagValueXZ += "|";
                }
            }
            if (tagValueXZ.Contains('|'))
            {
                tagValueXZ = tagValueXZ.Substring(0, tagValueXZ.LastIndexOf('|'));
            }
            if (tagValueXZ.Trim() != "")
            {
                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_AUTO_XIOAZHANG, tagValueXZ);
            } 
            #endregion

            //ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_LEAVE, ClsParkingManager.TRAIN_RAILWAYLINE);
            ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_LEAVE, railwayLineNO);
            UACSUtility.HMILogger.WriteLog(btnTrainLeave.Text, "火车离：" + railwayLineNO, UACSUtility.LogLevel.Info, this.Text);
           

            pnlRailwayArea.Controls.Clear();
            mClsTrainCase = new ClsTrainCase();
            clearHMI();

        }
        private void clearHMI()
        {
            trainCaseInfo1.setClsTrainInfo( new ClsTrainCase());
            trainCaseInfo1.updataTrainInfo();
            //配载图
            trainStowage1.setClsTrainCase( new ClsTrainCase());
            trainStowage1.updataStowage();
            btnTrainCaseSelect.Enabled = true;
            btnTrainCaseTypeCommit.Enabled = true;
            btnSelectStowage.Enabled = true;
            btnStowageCommit.Enabled = true;
            timerRefresh.Enabled = false;
            dataGridView_LaodMap.DataSource = new DataTable();
            dgvLaser.DataSource = new DataTable();
        }
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (parkingManager.getRaliwayStatus(out trainCaseCount, railwayLineNO))
            {
                getCurCranesOrder(); //获取当前行车指令材料
                refreshHMI();
            }
            else
            {
                clearHMI();
            }

        }
        //刷新
        private void refreshHMI()
        {
            try
            {
                //获取火车线、车皮状态的信息
                getTrainCaseCurStatus();
                //根据激光数据显示火车皮位置
                foreach (var item in pnlRailwayArea.Controls)
                {
                    if (item is railwayCarriage)
                    {
                        var trainCaseItem = (railwayCarriage)item;
                        if (trainCaseItem.ClsTrainCase.StowageID != null && trainCaseItem.ClsTrainCase.StowageID != "")     //刷新配载图
                        {
                            Point trainP; Size trainS;
                            string stowageNO = trainCaseItem.ClsTrainCase.StowageID;
                            if (parkingManager.getTainCaseLaserInfo(stowageNO, out trainP, out trainS))
                            {
                                trainP = converHMIPoint(trainP);
                                trainS = converToHMISize(trainS);
                                setTrainCasePoint(stowageNO, trainP, Convert.ToInt32(trainCaseItem.ClsTrainCase.TrainCaseNO));  //显示激光数据坐标
                            }
                        }
                        trainCaseItem.updataTrain();
                    }
                }
                if (mClsTrainCase != null)
                {
                    getStowageDitail(mClsTrainCase.StowageID);//获取配载信息，绑定钢卷字典数据 
                    //信息显示
                    trainCaseInfo1.setClsTrainInfo (gettrainCase(mClsTrainCase.TrainCaseNO));
                    trainCaseInfo1.updataTrainInfo();
                    trainStowage1.setClsTrainCase ( gettrainCase(mClsTrainCase.TrainCaseNO)); 
                    trainStowage1.refreshTrainStowage();
                    parkingManager.getStowageDetile(dataGridView_LaodMap, mClsTrainCase.StowageID);      //配载详细表格显示
                    RefreshOrderDgv(mClsTrainCase.StowageID); //获取指令
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        //配载表
        private void getTrainCaseCurStatus()
        {
            try
            {
                string sqlText = @"  SELECT  A.RAILWAY_LINE_ID, A.COACH_INDEX, A.COACH_NO, A.COACH_NO, A.COACH_TYPE_ID, A.CARGO_STOWAGE_ID, A.STOWAGE_ID,D.LENGTH, D.WIDTH, D.FLOORZ,
                A.STATUS AS CASE_STATUS,B.STATUS AS LINE_STATUS, B.TREATMENT_NO,C.STOWAGE_DEFINE,B.LASER_ACTION_COUNT, E.GROOVE_ACT_Z, 
                ABS(E.CAR_X_BORDER_MAX -E.CAR_X_BORDER_MIN) AS CAR_X_BORDER_LENGTH,ABS(E.CAR_Y_BORDER_MAX -E.CAR_Y_BORDER_MIN) AS CAR_Y_BORDER_LENGTH
                FROM UACS_RAILWAY_COACH_STATUS A
                LEFT JOIN UACS_RAILWAY_LINE_STATUS B ON A.RAILWAY_LINE_ID = B.RAILWAY_LINE_ID 
                LEFT JOIN UACS_RAILWAY_STOWAGE_ID_DEFINE C ON (A.CARGO_STOWAGE_ID = C.STOWAGE_NAME AND A.COACH_TYPE_ID = C.STOWAGE_TYPE )
                LEFT JOIN UACS_RAILWAY_COACH_DEFINE D ON A.COACH_TYPE_ID = D.COACH_TYPE_ID
                LEFT JOIN UACS_LASER_OUT E ON E.STOWAGE_ID =A.STOWAGE_ID
                WHERE A.STATUS != '-10' AND A.RAILWAY_LINE_ID = '" + railwayLineNO + "'";
                using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText))
                {
                    clsTrainCaseInfo trainCaseInfo = new clsTrainCaseInfo(); 
                    while (rdr.Read())
                    {
                        trainCaseInfo.caseNO = ManagerHelper.JudgeStrNull(rdr["COACH_INDEX"]);
                        trainCaseInfo.traincaseName = ManagerHelper.JudgeStrNull(rdr["COACH_NO"]);
                        trainCaseInfo.trainType = ManagerHelper.JudgeStrNull(rdr["COACH_TYPE_ID"]);
                        trainCaseInfo.stowageName = ManagerHelper.JudgeStrNull(rdr["CARGO_STOWAGE_ID"]);
                        trainCaseInfo.treatmentNO = ManagerHelper.JudgeStrNull(rdr["TREATMENT_NO"]);
                        trainCaseInfo.stowgeID = ManagerHelper.JudgeStrNull(rdr["STOWAGE_ID"]);
                        trainCaseInfo.railwayStatus = ManagerHelper.JudgeIntNull(rdr["LINE_STATUS"]);
                        trainCaseInfo.stowageType = ManagerHelper.JudgeStrNull(rdr["STOWAGE_DEFINE"]);
                        trainCaseInfo.caseStatus = ManagerHelper.JudgeIntNull (rdr["CASE_STATUS"]);
                        trainCaseInfo.length = ManagerHelper.JudgeIntNull(rdr["LENGTH"]);
                        trainCaseInfo.width = ManagerHelper.JudgeIntNull(rdr["WIDTH"]);
                        trainCaseInfo.floorz = ManagerHelper.JudgeIntNull(rdr["FLOORZ"]);
                        trainCaseInfo.laserLength = ManagerHelper.JudgeIntNull(rdr["CAR_X_BORDER_LENGTH"]);
                        trainCaseInfo.laserWidth = ManagerHelper.JudgeIntNull(rdr["CAR_Y_BORDER_LENGTH"]);
                        trainCaseInfo.laserFloorZ = ManagerHelper.JudgeIntNull(rdr["GROOVE_ACT_Z"]);
                        trainCaseInfo.laserCount = ManagerHelper.JudgeIntNull(rdr["LASER_ACTION_COUNT"]);

                        settrainCaseType(trainCaseInfo);

                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }

        }
        //更新状态
        private void settrainCaseType(string caseNO ,string trainCaseType, string treatmentNO, string stowgeType,string sowageID,int status ,string stowageDefine)
        {
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage)
                {
                    if (((railwayCarriage)item).ClsTrainCase.TrainCaseNO == caseNO)
                    {
                        ((railwayCarriage)item).ClsTrainCase.Specification = trainCaseType;
                        ((railwayCarriage)item).ClsTrainCase.StowageName = stowgeType;
                        ((railwayCarriage)item).ClsTrainCase.TreatmentNO = treatmentNO;
                        ((railwayCarriage)item).ClsTrainCase.StowageID = sowageID;
                        ((railwayCarriage)item).ClsTrainCase.RailwayStatus = status;
                        ((railwayCarriage)item).ClsTrainCase.StowageType = stowageDefine;
                    }
                }
            }

        }
        private void settrainCaseType(clsTrainCaseInfo trainCaseInfo)
        {
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage)
                {
                    var varTrainCase = ((railwayCarriage)item).ClsTrainCase;
                    if (varTrainCase.TrainCaseNO == trainCaseInfo.caseNO)
                    {
                        varTrainCase.TrainCaseName = trainCaseInfo.traincaseName;
                        varTrainCase.Specification = trainCaseInfo.trainType;
                        varTrainCase.StowageName = trainCaseInfo.stowageName;
                        varTrainCase.TreatmentNO = trainCaseInfo.treatmentNO;
                        varTrainCase.StowageID = trainCaseInfo.stowgeID;
                        varTrainCase.RailwayStatus = trainCaseInfo.railwayStatus;
                        varTrainCase.StowageType = trainCaseInfo.stowageType;
                        varTrainCase.TrainCaseStatus = trainCaseInfo.caseStatus;
                        varTrainCase.TrainCaseSize = new System.Drawing.Size(trainCaseInfo.length, trainCaseInfo.width);
                        varTrainCase.TrainHeight = trainCaseInfo.floorz;
                        varTrainCase.LaserTrainCaseSize = new Size(trainCaseInfo.laserLength, trainCaseInfo.laserWidth);
                        varTrainCase.LaserFloorZ = trainCaseInfo.laserFloorZ;
                    }
                    if (mClsTrainCase != null && varTrainCase.TrainCaseNO == mClsTrainCase.TrainCaseNO)
                    {
                        mClsTrainCase = varTrainCase;
                    }
                }
            }

        }
        /// <summary>
        /// 根据车号获取车皮
        /// </summary>
        /// <param name="caseNO"></param>
        /// <returns></returns>
        private ClsTrainCase gettrainCase(string caseNO)
        {
            ClsTrainCase ret_ClsTrainCase = new ClsTrainCase();
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage)
                {
                    var varTrainCase = ((railwayCarriage)item).ClsTrainCase;
                    if (varTrainCase.TrainCaseNO == caseNO)
                    {
                        ret_ClsTrainCase = varTrainCase;
                        return ret_ClsTrainCase;
                    }
                }
            }
            return ret_ClsTrainCase;
        }
        //获得钢卷,并赋给车皮
        private void getStowageDitail(string stowageID)
        {
            try
            {
                if (stowageID ==null || stowageID == "")
                {
                    return;
                }
                Dictionary<string, clsTrainCoils> trainCaseCoils = new Dictionary<string, clsTrainCoils>(getClsTrainCoilsOldDtat(stowageID));
                string sqlText = @" SELECT A.GROOVEID , A.MAT_NO, A.POS_ON_FRAME,A.POS_IN_GROOVE, A.X_CENTER, A.Y_CENTER, A.Z_CENTER, D.WEIGHT, D.OUTDIA ,D.WIDTH , A.STATUS  FROM UACS_TRUCK_STOWAGE_DETAIL A 
                 LEFT JOIN UACS_TRUCK_STOWAGE B ON A.STOWAGE_ID = B.STOWAGE_ID
                 LEFT JOIN  UACS_YARDMAP_COIL D ON A.MAT_NO = D.COIL_NO ";
                sqlText += "  WHERE A.STOWAGE_ID = '" + stowageID + "'" + " ORDER BY A.POS_ON_FRAME ";
                using (IDataReader rdr = ClsParkingManager.DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        string matNO = ManagerHelper.JudgeStrNull(rdr["MAT_NO"]);
                        string grooveID = ManagerHelper.JudgeStrNull(rdr["GROOVEID"]);
                        string POS_IN_GROOVE = ManagerHelper.JudgeStrNull(rdr["POS_IN_GROOVE"]);
                        string temp = string.Format("{0}-{1}", grooveID, POS_IN_GROOVE);
                        int status = ManagerHelper.JudgeIntNull(rdr["STATUS"]);
                        clsTrainCoils clsTrainCoilsTemp = trainCaseCoils.ContainsKey(temp) ? new clsTrainCoils(trainCaseCoils[temp]) : new clsTrainCoils();  
                        clsTrainCoilsTemp.bracketNO = temp;
                        clsTrainCoilsTemp.MAT_NO = matNO;
                        clsTrainCoilsTemp.status = status;
                        clsTrainCoilsTemp.coilPoint.X = ManagerHelper.JudgeIntNull(rdr["X_CENTER"]);
                        clsTrainCoilsTemp.coilPoint.Y = ManagerHelper.JudgeIntNull(rdr["Y_CENTER"]);
                        clsTrainCoilsTemp.coilSize.Height = ManagerHelper.JudgeIntNull(rdr["WIDTH"]);
                        clsTrainCoilsTemp.coilSize.Width = ManagerHelper.JudgeIntNull(rdr["OUTDIA"]);
                        settrainCaseCoils(stowageID, temp, clsTrainCoilsTemp);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        //获取旧的字典数据，更新数据时应获取旧的，再设置新的数据
        private Dictionary<string, clsTrainCoils> getClsTrainCoilsOldDtat(string stowageID)
        {
            Dictionary<string, clsTrainCoils> dictCoils = new Dictionary<string, clsTrainCoils>();
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage)
                {
                    if (((railwayCarriage)item).ClsTrainCase.StowageID == stowageID)
                    {
                        dictCoils = new Dictionary<string, clsTrainCoils>(((railwayCarriage)item).ClsTrainCase.TrainCaseCoils);
                        break;
                    }
                }
            }
            return dictCoils;
        }
        private void RefreshOrderDgv(string stowageID)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            if (stowageID ==null || stowageID =="")
            {
                dgvCraneOder.DataSource = dt;
                return;
            }
            try
            {
                string SQLOder = " SELECT C.GROOVEID, C.MAT_NO,B.BAY_NO,B.FROM_STOCK_NO ,B.TO_STOCK_NO FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                SQLOder += " RIGHT JOIN UACS_CRANE_ORDER_Z32_Z33 B ON C.MAT_NO = B.MAT_NO ";
                SQLOder += " WHERE  C.STOWAGE_ID  = '" + stowageID + "'";
                using (IDataReader odrIn = ClsParkingManager.DBHelper.ExecuteReader(SQLOder))
                {
                    dt.Load(odrIn);
                }
                dgvCraneOder.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        private void btnReflesh_Click(object sender, EventArgs e)
        {
            //step1 生成火车皮
            if (parkingManager.getRaliwayStatus(out trainCaseCount, railwayLineNO))
            {
                //if (trainCaseCount > 0)
                {
                    createTrainCase(railwayLineNO, trainCaseCount);
                    timerRefresh.Enabled = true;
                }
            }
            else
            {
                clearHMI();
                return;
            }
            refreshHMI();
            if (trainCaseCount > 0)
                selectTrainCase("1");
        }
        private void settrainCaseCoils( string stowageID , string key, clsTrainCoils clscoil)
        {
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage)
                {
                    railwayCarriage railwayCarriageItem = (railwayCarriage)item;
                    if (railwayCarriageItem.ClsTrainCase.StowageID == stowageID &&
                        railwayCarriageItem.ClsTrainCase.TrainCaseStatus>10)
                    {
                        railwayCarriageItem.ClsTrainCase.TrainCaseCoils[key] = clscoil;
                        return;
                    }
                }
            }
        }
      private bool getTrainCaseSize( )
       {
           bool ret = false;
           try
           {
               int lenght, width;
               string sqlText_LoadMap = @"SELECT  LENGTH, WIDTH FROM UACS_RAILWAY_COACH_DEFINE WHERE COACH_TYPE_ID ='C60' ";
               using (IDataReader rdr = ClsParkingManager. DBHelper.ExecuteReader(sqlText_LoadMap))
               {
                   if (rdr.Read())
                   {
                       lenght = ManagerHelper.JudgeIntNull( rdr["LENGTH"]);
                       width = ManagerHelper.JudgeIntNull(rdr["WIDTH"]);
                       ret = true;
                   }
               }
           }
           catch (Exception er)
           {
               MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
           }
           return ret;
       }

      private void initializeTrainSize()
      {
          if (getTrainCaseSize())
          {
              
          }
      }
        #region 画面切换
        private void FrmRailwayParkingOut_TabActivated(object sender, EventArgs e)
        {
            timerRefresh.Enabled = true;
        }

        private void FrmRailwayParkingOut_TabDeactivated(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
        }

        private void FrmRailwayParkingOut_Resize(object sender, EventArgs e)
        {
            if (this.Height == 0)
            { timerRefresh.Enabled = false; }
            else
            { timerRefresh.Enabled = true; }
        } 
        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (mClsTrainCase == null)
            {
                MessageBox.Show("请先选择一个车皮。");
            }
            string tagValue = railwayLineNO;
            tagValue += "|" + mClsTrainCase.TrainCaseNO;
            DialogResult dr = MessageBox.Show("是否作业开始？车皮号： " + mClsTrainCase.TrainCaseNO, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_OPER_START, tagValue);
                UACSUtility.HMILogger.WriteLog(btnStart.Text, "作业开始：" + tagValue, UACSUtility.LogLevel.Info, this.Text);

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (mClsTrainCase == null)
            {
                MessageBox.Show("请先选择一个车皮。");
            }
            string tagValue = railwayLineNO;
            tagValue += "|" + mClsTrainCase.TrainCaseNO;
            DialogResult dr = MessageBox.Show("是否作业暂停？车皮号：  " + mClsTrainCase.TrainCaseNO, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_OPER_PAUSE, tagValue);
                UACSUtility.HMILogger.WriteLog(btnPause.Text, "作业暂停：" + tagValue, UACSUtility.LogLevel.Info, this.Text);

            }
        }

        decimal XRatio, YRatio;
        int XOffset, YOffset;
        #region 坐标转换
        public void initializeControlToActual(int location_X, int location_Y, int size_X, int size_Y)
        {
            //int X_bloeUp, Y_blowUp;
            //X_bloeUp = 500;
            //Y_blowUp = 500;//放大偏移量
            //XRatio = getRatio(this.pnlTrainCase.Size.Width, size_X + X_bloeUp); 
            //YRatio = getRatio(this.pnlTrainCase.Size.Height, size_Y + Y_blowUp);
            initializeRatio(size_X, size_Y);
            InitializeOffsetXY(location_X, location_Y);
        }
        private void InitializeOffsetXY(int actualLocation_X, int actualLocation_Y)
        {
            //实际*比率+偏移量 = 画面参数
            //坐标转换  (x,y) --> (5,5)
            Point initPoint = new Point(5, 5);   //画面转换基点
            XOffset = Convert.ToInt32(initPoint.X - actualLocation_X * XRatio);
            YOffset = Convert.ToInt32(initPoint.Y - actualLocation_Y * YRatio);

        }
        private decimal getRatio(int HMIValue, int actualValue)
        {
            decimal ret = 1;
            ret = Math.Round((decimal)HMIValue / actualValue, 5); ;
            return ret;
        }
        private void initializeRatio(int size_X, int size_Y)
        {
            int X_bloeUp, Y_blowUp;
            X_bloeUp = 500;  //
            Y_blowUp = 500;//坐标密度系数
            XRatio = getRatio(this.pnlRailwayArea.Size.Width, size_X + X_bloeUp);
            YRatio = getRatio(this.pnlRailwayArea.Size.Height, size_Y + Y_blowUp);
        }
        private int converToHMISize_X(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(XRatio * actualValue);
            return HMIValue;
        }
        private int converToHMISize_Y(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(YRatio * actualValue);
            return HMIValue;
        }
        private Size converToHMISize(Size actualSize)
        {
            Size hmiSize = new Size();
            hmiSize.Width = converToHMISize_X(actualSize.Width);
            hmiSize.Height = converToHMISize_Y(actualSize.Height);
            return hmiSize;
        }
        private int converToHMILocation_X(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(Math.Abs(XRatio * actualValue + XOffset));
            return HMIValue;
        }
        private int converToHMILocation_Y(int actualValue)
        {
            int HMIValue = 0;
            HMIValue = Convert.ToInt32(Math.Abs(YRatio * actualValue + YOffset));
            return HMIValue;
        }
        private Point converHMIPoint(Point actualPoint)
        {
            Point hmiPoint = new Point();
            hmiPoint.X = converToHMILocation_X(actualPoint.X) +500; //车皮大小没有按照实际尺寸转换,加偏移量
            hmiPoint.Y = converToHMILocation_X(actualPoint.Y);
            // 数量产出画面长度，向下排列  vella add
            //if (hmiPoint.X + 200 > pnlRailwayArea.Size.Width) 
            //{
            //    hmiPoint.X = hmiPoint.X - pnlRailwayArea.Size.Width + 200;
            //    int multiple = hmiPoint.X / pnlRailwayArea.Size.Width;
            //    hmiPoint.Y = hmiPoint.Y + 100 * (1 + multiple) ;
            //}

            return hmiPoint;
        }
        #endregion
        private void initializeRailwaySize()
        {
            Point p =new Point();
            Size s =new System.Drawing.Size();
            parkingManager.getRailwaySize(out p, out s);
            initializeControlToActual(p.X, p.Y, s.Width + 800, s.Height);
        }
        private void setTrainCasePoint(string stowageID ,Point newPoint ,int index)
        {
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage)
                {
                    var trainCase = (railwayCarriage)item;
                    if (trainCase.ClsTrainCase.StowageID == stowageID)
                    {
                        trainCase.Location = new Point(newPoint.X - ClsParkingManager.HMI_TRAINCASE_OFFSET * (index-1), newPoint.Y);   //50
                        return;
                    }
                }
            }
        }

        private bool judgeTrainHas()
        {
            bool ret = false;
            if (mClsTrainCase!=null &&(mClsTrainCase.IsConfirmStowageType || mClsTrainCase.IsConfirmTrainCaseType))
            {
                ret = true;
            }
            return ret;
        }
        /// <summary>
        /// 选中指定的火车皮
        /// </summary>
        /// <param name="trainCaseNO">火车皮号</param>
        private void selectTrainCase(string  trainCaseNO)
        {
            foreach (var item in pnlRailwayArea.Controls)
            {
                if (item is railwayCarriage)
                {
                    railwayCarriage railwayCarriageItem = (railwayCarriage)item;
                    if (railwayCarriageItem.ClsTrainCase.TrainCaseNO == trainCaseNO)
                    {
                        trainCase_SendTrainCls(railwayCarriageItem.ClsTrainCase);
                        return;
                    }
                }
            }
        }

        private void dataGridView_LaodMap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if ( e.RowIndex==-1 || e.ColumnIndex ==-1)
            {
                return;
            }
            if (dgv.Columns[e.ColumnIndex].Name.Equals("LOCK_FLAG"))
            {
                if (e.Value == null || e.Value.ToString() == "")
                {
                    e.Value = "";
                    e.CellStyle.BackColor = Color.White;
                    return;
                }
                if (e.Value.ToString() == "0")
                {
                    e.Value = "可用";
                }
                else if (e.Value.ToString() == "1")
                {
                    e.Value = "待判";
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (e.Value.ToString() == "2")
                {
                    e.Value = "封锁";
                    e.CellStyle.BackColor = Color.Red;
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name.Equals("STATUS") && dataGridView_LaodMap.Rows[e.RowIndex].Cells["MAT_NO2"].Value!=null)
            {
                string matNO = dataGridView_LaodMap.Rows[e.RowIndex].Cells["MAT_NO2"].Value.ToString();

                if (curOrderMatNO.Contains(matNO))
                {
                    e.Value = "吊出中";
                    e.CellStyle.BackColor = Color.Yellow;
                }
                if (e.Value.ToString() == "0")
                {
                    e.Value = "待吊出";
                    e.CellStyle.BackColor = Color.White;
                }
                else if (e.Value.ToString() == "100")
                {
                    e.Value = "已吊出";
                    e.CellStyle.BackColor = Color.LightGray;
                }
                else if (e.Value.ToString() == "101")
                {
                    e.Value = "人工吊出";
                    e.CellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private bool getCurCranesOrder()
        {
            bool ret = false;
            List<string> lstTemp = new List<string>();
            try
            {
                string sqlText = @" SELECT MAT_NO FROM UACS_CRANE_ORDER_CURRENT WHERE CRANE_NO  IN('1','2','3','7','8') ";
                using (IDataReader rdr =ClsParkingManager.DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        lstTemp.Add(ParkClassLibrary.ManagerHelper.JudgeStrNull(rdr["MAT_NO"]));
                        ret = true;
                    }
                }
                curOrderMatNO = lstTemp.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return ret;
        }

        private void btnXiaoZhao_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("功能暂未开放！");
            //return;
            if (mClsTrainCase==null)
            {
                MessageBox.Show("请选择一节车皮！");
                return;
            }
            if (mClsTrainCase.StowageID ==null || mClsTrainCase.StowageID =="")
            {
                MessageBox.Show("该节车皮没有配载ID，不能销账！");
                return;
            }
            string tagValue = "";
            tagValue = mClsTrainCase.StowageID + "|" + railwayLineNO + "|" + mClsTrainCase.TrainCaseNO + "-" + mClsTrainCase.TrainCaseName + "|" + "OUT";
            DialogResult dr = MessageBox.Show("是否发送tagVaule： " + tagValue, "调试", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_COACH_XIAO_ZHANG, tagValue);
                UACSUtility.HMILogger.WriteLog(btnTrainLeave.Text, "火车销账：" + tagValue, UACSUtility.LogLevel.Info, this.Text);
            }
        }

        private void btnAutoSelectColi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能暂未开放！");
            return;
            if (mClsTrainCase == null)
            {
                MessageBox.Show("请选择一节车皮！");
                return;
            }
            string tagValue = "";
            tagValue = railwayLineNO + "|" + mClsTrainCase.TrainCaseNO + "-" + mClsTrainCase.TrainCaseName;
            DialogResult dr = MessageBox.Show("是否发送tagVaule： " + tagValue, "调试", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_AUTO_SELECT_COIL, tagValue);
                UACSUtility.HMILogger.WriteLog(btnTrainLeave.Text, "自动选卷：" + tagValue, UACSUtility.LogLevel.Info, this.Text);
            }
        }

        private void btnXiaoZhaoCancel_Click(object sender, EventArgs e)
        {
            SubFrmXiaoZhaoCancel form = new SubFrmXiaoZhaoCancel();
            form.ShowDialog();
        }

        private void btnXiaoZhaoRecover_Click(object sender, EventArgs e)
        {
            SubFrmXiaoZhaoRecover form = new SubFrmXiaoZhaoRecover();
            form.ShowDialog();
        }

        

       
    }
}
