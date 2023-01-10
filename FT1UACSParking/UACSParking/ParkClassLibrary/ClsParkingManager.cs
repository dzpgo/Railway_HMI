using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace ParkClassLibrary
{
   public class ClsParkingManager
    {
       //火车装车tag
        public const string TAG_EV_RAILWAY_COACH_ARRIVE = "EV_RAILWAY_COACH_ARRIVE";         //火车到位
        public const string TAG_EV_RAILWAY_COACH_TYPE_MODIFY = "EV_RAILWAY_COACH_TYPE_MODIFY";        //车皮类型修改
        public const string TAG_EV_RAILWAY_COACH_TYPE_MODIFY_FINISHED = "EV_RAILWAY_COACH_TYPE_MODIFY_FINISHED";         //车皮类型修改完成
        public const string TAG_EV_RAILWAY_CARGO_STOWAGE_MODIFY = "EV_RAILWAY_CARGO_STOWAGE_MODIFY";        //配载修改
        public const string TAG_EV_RAILWAY_CARGO_STOWAGE_MODIFY_FINISHED = "EV_RAILWAY_CARGO_STOWAGE_MODIFY_FINISHED";         //  配载修改完成
        public const string TAG_EV_RAILWAY_COACH_COILS_MODIFY = "EV_RAILWAY_COACH_COILS_MODIFY";         //选卷
        public const string TAG_EV_RAILWAY_COACH_COILS_FINISHED = "EV_RAILWAY_COACH_COILS_FINISHED";         //选卷确认
        public const string TAG_EV_RAILWAY_COACH_OPER_PAUSE = "EV_RAILWAY_COACH_OPER_PAUSE";         //  暂停
        public const string TAG_EV_RAILWAY_COACH_OPER_START = "EV_RAILWAY_COACH_OPER_START";         //开始
        public const string TAG_EV_RAILWAY_COACH_XIAO_ZHANG = "EV_XIAOZHANG";         //销账
        public const string TAG_EV_RAILWAY_COACH_LEAVE = "EV_RAILWAY_COACH_LEAVE";         //离开

        public const string TAG_EV_PARKING_LASERSTART_COACH = "EV_PARKING_LASERSTART_COACH";  //激光
        public const string TAG_AUTO_SELECT_COIL = "AUTO_SELECT_COIL";  //自动选卷
        public const string TAG_AUTO_XIOAZHANG = "EV_COACHXIAOZHANG_AUTO";  //自动销账
       //
        public const string TRAIN_RAILWAYLINE_PT55 = "PT55";
        public const string TRAIN_RAILWAYLINE_PT55B = "PT55B";
        public const string TRAIN_RAILWAYLINE_PT57_1 = "PT57A";
        public const string TRAIN_RAILWAYLINE_PT57_2 = "PT57B";

        public const string TRAIN_SPECIFICATION_C60 = "C60";
        public const string TRAIN_SPECIFICATION_C61 = "C61";
        public const string TRAIN_SPECIFICATION_C70 = "C70";
        public const string TRAIN_SPECIFICATION_C71 = "C71";

        public const string TRAIN_SPECIFICATION_C60_1 = "C60_1";
        public const string TRAIN_SPECIFICATION_C61_1 = "C61_1";
        public const string TRAIN_SPECIFICATION_C70_1 = "C70_1";
        public const string TRAIN_SPECIFICATION_C71_1 = "C71_1";
       //画面火车皮显示偏移设定
        public const int HMI_TRAINCASE_OFFSET = 55;

        protected string protectedItem;
        public enum Train
        {
            
        };
        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        public static Baosight.iSuperframe.Common.IDBHelper DBHelper
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

        #region iPlature配置
        private static Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = null;
        public static Baosight.iSuperframe.TagService.Controls.TagDataProvider TagDP
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
        //Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new Baosight.iSuperframe.TagService.DataCollection<object>();
        public ClsParkingManager()
        {

        }
        public ClsParkingManager(Panel pnlControl)
        {
            Point pathwayStart = new Point(0, 0);
            Point pathwayEnd = new Point(0, 0);
          
        }
        #region 火车皮

        //坐标转换

        public void paintRailwayPathWay(Panel pnlControl)
        {
            int wayWidth = pnlControl.Height - 10 -2;
            int wayLength = pnlControl.Width;
            int way_X1 = 0;
            int way_Y1 = 5;
            int way_X2 = 0;
            int way_Y2 = wayWidth + way_Y1;
            //画图对象
            Graphics gr;
            //清空所有绘制的线条
            using (Graphics g = pnlControl.CreateGraphics())
            {
                g.Clear(pnlControl.BackColor);
            }
            gr = pnlControl.CreateGraphics();
            Pen pen1 = new Pen(Color.Black, 2);
            gr.DrawLine(pen1, way_X1, way_Y1, wayLength, way_Y1);  //铁轨1
            gr.DrawLine(pen1, way_X2, way_Y2, wayLength, way_Y2);  //铁轨2

            //铁轨横线
            for (int i = 5; i < wayLength; i+=25)
            {
                Point linePoinSrat = new Point();
                Point linePoinEnd = new Point();
                linePoinSrat.X = i;
                linePoinSrat.Y = way_Y1;
                linePoinEnd.X = i;
                linePoinEnd.Y = way_Y2;
                gr.DrawLine(pen1, linePoinSrat, linePoinEnd);
            }
            gr.DrawString("南", new Font("微软雅黑", 18, FontStyle.Regular), Brushes.Black, new Point(25, pnlControl.Height / 2 - 12));
            gr.DrawString("北", new Font("微软雅黑", 18, FontStyle.Regular), Brushes.Black, new Point(pnlControl.Width - 50, pnlControl.Height / 2 - 12));

        }
        #endregion
       /// <summary>
       /// 获得火车轨道大小
       /// </summary>
       /// <param name="railwayPoint"></param>
       /// <param name="pointEnd"></param>
       public void getRailwaySize(out Point railwayPoint,out Size railwaySize)
       {
            railwayPoint = new Point(0, 0);
            railwaySize = new Size(0, 0);
            try
            {
                //出库激光扫描信息
                string sqlText = @"SELECT  X_START, X_END, Y_START, Y_END, ABS(X_END -X_START) AS SIZE_X ,ABS(Y_START - Y_END)
                AS SIZE_Y FROM UACS_YARDMAP_AREA_DEFINE WHERE AREA_NO = 'FT1-1-RAILWAY' AND BAY_NO ='A-1'";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        railwayPoint.X = ManagerHelper.JudgeIntNull(rdr["X_START"]); 
                        railwayPoint.Y = ManagerHelper.JudgeIntNull(rdr["Y_START"]) ;
                        railwaySize.Width = ManagerHelper.JudgeIntNull(rdr["SIZE_X"]);
                        railwaySize.Height = ManagerHelper.JudgeIntNull(rdr["SIZE_Y"]);

                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

       /// <summary>
       /// 获得全部节火车皮位置
       /// </summary>
       private void getTainsCaseLocation( out List<Point> trainCasePoints)
       {
           trainCasePoints = new List<Point>();
           try
           {
               //出库激光扫描信息
               string sqlText = @"SELECT * FROM UACS_YARDMAP_AREA_DEFINE WHERE AREA_NO = 'FT1-1-RAILWAY' AND BAY_NO ='A-1'";

               using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
               {

               }
           }
           catch (Exception er)
           {
               MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
           }
       }
       /// <summary>
       /// 获得单节火车皮信息
       /// </summary>
       /// <param name="treatmentNO"></param>
       /// <param name="trainCasePoints"></param>
       /// <param name="trainCaseSize"></param>
       /// <returns></returns>
       public bool getTainCaseLaserInfo(string stowageID , out Point trainCasePoints ,out Size trainCaseSize)
       {

           bool ret = false;
           trainCasePoints = new Point();
           trainCaseSize = new Size();
           try
           {
               //出库激光扫描信息
               string sqlText = @" SELECT  CAR_X_BORDER_MAX, CAR_X_BORDER_MIN, CAR_Y_BORDER_MAX, CAR_Y_BORDER_MIN, 
               GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z, GROOVE_WIDTH, CAR_NO, TREATMENT_NO FROM UACSAPP.UACS_LASER_OUT ";
               sqlText += " WHERE STOWAGE_ID = '" + stowageID + "'";
               using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
               {
                   if(rdr.Read())
                   {
                       trainCasePoints.X = ManagerHelper.JudgeIntNull(rdr["CAR_X_BORDER_MIN"]);
                       trainCasePoints.Y = ManagerHelper.JudgeIntNull(rdr["CAR_Y_BORDER_MIN"]);
                       trainCaseSize.Width = ManagerHelper.JudgeIntNull(rdr["CAR_X_BORDER_MAX"])
                           - ManagerHelper.JudgeIntNull(rdr["CAR_X_BORDER_MIN"]);
                       trainCaseSize.Height = ManagerHelper.JudgeIntNull(rdr["CAR_Y_BORDER_MAX"])
                           - ManagerHelper.JudgeIntNull(rdr["CAR_Y_BORDER_MIN"]);
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
        /// <summary>
        /// 生成一节火车
        /// </summary>
        /// <param name="trainCasePoint"></param>
        private void creatTrainCase(Point trainCasePoint)
        {

        }
       /// <summary>
       /// 设置全部火车皮的类型
       /// </summary>
       /// <param name="type"></param>
        public void setAllTrainCaseType(int count, string type)
        {
            for (int i = 1; i <= count; i++)
            {
                string tagValue = TRAIN_RAILWAYLINE_PT55 +"|"+i+"|"+type;
                TagDP.SetData(TAG_EV_RAILWAY_COACH_TYPE_MODIFY, tagValue);
            }
        }

        public void getStowageName(string stowage, out string stowageName)
        {
            stowageName = "";
            try
            {
                string sqlText = " SELECT STOWAGE_NAME FROM UACS_RAILWAY_STOWAGE_ID_DEFINE WHERE STOWAGE_DEFINE ='" + stowage + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {
                        stowageName = ManagerHelper.JudgeStrNull(rdr["STOWAGE_NAME"]);
                    }
                    else
                    {
                        stowageName = "FA1";
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
       //初始化查询车位初始状态
        public bool railwayLoad()
        {
            bool ret = false;

            try
            {

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
            return ret;
        }

        public bool getRaliwayStatus(out int caseCount,string _railwayLineNO = "PT55")
        {
            caseCount = 0;
            bool ret = false;
            try
            {
                string sqlText = " select COUNT (A.STATUS ) AS SUM FROM UACS_RAILWAY_COACH_STATUS A WHERE A.STATUS !=-10 AND RAILWAY_LINE_ID = '" + _railwayLineNO + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {
                        caseCount = ManagerHelper.JudgeIntNull(rdr["SUM"]);
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
       public bool RailwayCaseType()
        {

            bool ret = false;
            try
            {
                string sqlText = " select COUNT (A.STATUS ) AS SUM FROM UACS_RAILWAY_COACH_STATUS A WHERE A.STATUS !=-10";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        //caseCount = ManagerHelper.JudgeIntNull(rdr["SUM"]);
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
       public void getStowageDetile(DataGridView dgv, string stowageID)
       {
           try
           {
               DataTable dt = new DataTable();
               if (stowageID ==null || stowageID == "")
               {
                   dgv.DataSource = dt;
                   return;
               }
               //框架配载图信息
               string sqlText_LoadMap = @"SELECT A.GROOVEID , A.MAT_NO,C.PICK_NO, A.POS_ON_FRAME, A.X_CENTER, A.Y_CENTER, A.Z_CENTER, A.X_RELETIVE,
                A.Y_RELETIVE,E.STOCK_NO, E.LOCK_FLAG, D.WEIGHT, D.OUTDIA ,D.WIDTH ,D.PACK_FLAG, A.STATUS  FROM UACS_TRUCK_STOWAGE_DETAIL A ";
               sqlText_LoadMap += "  LEFT JOIN UACS_TRUCK_STOWAGE B ON A.STOWAGE_ID = B.STOWAGE_ID ";
               sqlText_LoadMap += " LEFT JOIN  UACS_PLAN_L3PICK C ON A.MAT_NO = C.COIL_NO ";
               sqlText_LoadMap += " LEFT JOIN  UACS_YARDMAP_COIL D ON A.MAT_NO = D.COIL_NO ";
               sqlText_LoadMap += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE E ON A.MAT_NO = E.MAT_NO ";
               sqlText_LoadMap += " WHERE 1=1  AND B.STOWAGE_ID = '" + stowageID + "' ORDER BY A.POS_ON_FRAME ";
               using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_LoadMap))
               {
                   dt.Load(rdr);
               }
               dgv.DataSource = dt;
           }
           catch (Exception er)
           {
               MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
           }
       }

       public void getLaserOutInfo(DataGridView dgv, string stowageID)
       {
           try
           {
               DataTable dt = new DataTable();
               //框架配载图信息
               string sqlText_LoadMap = @"SELECT  PARKING_NO, CAR_NO, CAR_X_BORDER_MAX, CAR_X_BORDER_MIN, CAR_Y_BORDER_MAX, CAR_Y_BORDER_MIN, 
               GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z, GROOVE_WIDTH, CAR_NO, GROOVEID, STOWAGE_ID, TIME_CREATED, TREATMENT_NO FROM UACSAPP.UACS_LASER_OUT ";
               sqlText_LoadMap += " WHERE  STOWAGE_ID = '" + stowageID + "' ";
               using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_LoadMap))
               {
                   dt.Load(rdr);
               }
               dgv.DataSource = dt;
           }
           catch (Exception er)
           {
               MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
           }
       }
       /// <summary>
       /// 定位到指定的行
       /// </summary>
       /// <param name="dgv"></param>
       /// <param name="searchString"></param>
       /// <param name="columnName"></param>
       public void SelectDataGridViewRow(DataGridView dgv, string searchString, string columnName)
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
               MessageBox.Show(string.Format("没有找到指定的钢卷：{0}", searchString));
           }

           catch (Exception er)
           {
               MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
           }
       }

       public void setTrainCaseName(string railwayLineNO, string trainCaseIndex ,string trainCaseName)
       {
           try
           {
               string sql = " UPDATE UACS_RAILWAY_COACH_STATUS SET  COACH_NO = '" + trainCaseName + "'  WHERE RAILWAY_LINE_ID = '" + railwayLineNO + "' ";
               sql += " AND COACH_INDEX = '" + trainCaseIndex + "'";
               ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql);
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
           }
       }



       
    }
}
