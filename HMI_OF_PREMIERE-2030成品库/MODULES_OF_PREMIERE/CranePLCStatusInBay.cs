using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODULES_OF_PREMIERE
{
    public class CranePLCStatusInBay
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        //step1
        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {
            }
        }


        private List<string> lstCraneNO = new List<string>();

        //step2
        public void AddCraneNO(string strCraneNO)
        {
            try
            {
                lstCraneNO.Add(strCraneNO);
            }
            catch (Exception ex)
            {
            }
        }


        private string[] arrTagAdress;

        //step3
        public void SetReady()
        {
            try
            {
                List<string> lstAdress = new List<string>();
                foreach (string theCranNO in lstCraneNO)
                {
                    string tag_Head = theCranNO + "_";
                    //2准备好
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_READY);
                    //3控制模式
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_CONTROL_MODE);
                    //4请求计划
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_ASK_PLAN);
                    //5任务执行中
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_TASK_EXCUTING);
                    //6大车位置
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_XACT);
                    //7小车位置
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_YACT);
                    //8夹钳高度
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_ZACT);
                    //9大车方向实际速度
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_XSPEED);
                    //10小车方向实际速度
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_YSPEED);
                     //11升降实际速度
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_ZSPEED);
                    //12大车正方向
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_XDIR_P);
                    //13大车负方向
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_XDIR_N);
                    //14小车正方向
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_YDIR_P);
                    //15小车负方向
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_YDIR_N);
                    //16升降正方向
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_ZDIR_P);
                    //17升降负方向
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_ZDIR_N);
                    //18有卷标志
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_HAS_COIL);
                    //19称重信号
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_WEIGHT_LOADED);
                    //20夹钳旋转角度
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_ROTATE_ANGLE_ACT);
                    //21夹钳开度
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_CLAMP_WIDTH_ACT);
                    //22急停状态
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_EMG_STOP);
                    //23当前指令号
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_ORDER_ID);
                    //24计划起卷X
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_PLAN_UP_X);
                    //25计划起卷Y
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_PLAN_UP_Y);
                    //26计划起卷Z
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_PLAN_UP_Z);
                    //27计划落卷X
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_PLAN_DOWN_X);
                    //28计划落卷Y
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_PLAN_DOWN_Y);
                    //29计划落卷Z
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_PLAN_DOWN_Z);
                    //30行车状态
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_CRANE_STATUS);
                    //31 HEART_BEAT
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_HEART_BEAT);
                    //32
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_X_EXCUTING);
                    //33
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_Y_EXCUTING);
                    //34
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_Z_EXCUTING);
                    //35
                    lstAdress.Add(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_R_EXCUTING);
                

                }
                arrTagAdress = lstAdress.ToArray<string>();
            }
            catch (Exception ex)
            {
            }
        }


        private Dictionary<string, CranePLCStatusBase> dicCranePLCStatusBase = new Dictionary<string, CranePLCStatusBase>();

        public Dictionary<string, CranePLCStatusBase> DicCranePLCStatusBase
        {
            get { return dicCranePLCStatusBase; }
        }



        //step4
        public void getAllPLCStatusInBay()
        {
            try
            {
                readTags();
                foreach (string theCraneNO in lstCraneNO)
                {
                    CranePLCStatusBase cranePLCStatusBase = getCranePLCStatusFromTags(theCraneNO);
                    dicCranePLCStatusBase[theCraneNO] = cranePLCStatusBase;
                }

            }
            catch (Exception ex)
            {
            }
        }


        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
        private void readTags()
        {
            try
            {
                inDatas.Clear();
                tagDataProvider.GetData(arrTagAdress, out inDatas);
            }
            catch (Exception ex)
            {
            }
        }


        private CranePLCStatusBase getCranePLCStatusFromTags(string theCraneNO)
        {
            CranePLCStatusBase cranePLCBase = new CranePLCStatusBase();
            try
            {
                cranePLCBase.CraneNO = theCraneNO;
                string tag_Head = cranePLCBase.CraneNO + "_";
                //2准备好
                cranePLCBase.Ready = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_READY);
                //3控制模式
                cranePLCBase.ControlMode = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_CONTROL_MODE);
                //4请求计划
                cranePLCBase.AskPlan = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_ASK_PLAN);
                //5任务执行中
                cranePLCBase.TaskExcuting = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_TASK_EXCUTING);
                //6大车位置
                cranePLCBase.XAct = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_XACT);
                //7小车位置
                cranePLCBase.YAct = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_YACT);
                //8夹钳高度
                cranePLCBase.ZAct = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_ZACT);
                //9大车方向实际速度
                cranePLCBase.XSpeed = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_XSPEED);
                //10小车方向实际速度
                cranePLCBase.YSpeed = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_YSPEED);
                //11升降实际速度
                cranePLCBase.ZSpeed = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_ZSPEED);
                //12大车正方向
                cranePLCBase.XDirPositive = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_XDIR_P);
                //13大车负方向
                cranePLCBase.XDirectNegative = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_XDIR_N);
                //14小车正方向
                cranePLCBase.YDirectPositive = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_YDIR_P);
                //15小车负方向
                cranePLCBase.YDirectNegative = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_YDIR_N);
                //16升降正方向
                cranePLCBase.ZDirectPositive = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_ZDIR_P);
                //17升降负方向
                cranePLCBase.ZDirectNegative = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_ZDIR_N);
                //18有卷标志
                cranePLCBase.HasCoil = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_HAS_COIL);
                //19称重信号
                cranePLCBase.WeightLoaded = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_WEIGHT_LOADED);
                //20夹钳旋转角度
                cranePLCBase.RotateAngleAct = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_ROTATE_ANGLE_ACT);
                //21夹钳开度
                cranePLCBase.ClampWidthAct = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_CLAMP_WIDTH_ACT);
                //22急停状态
                cranePLCBase.EmgStop = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_EMG_STOP);
                //23当前指令号
                cranePLCBase.OrderID = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_ORDER_ID);
                //24计划起卷X
                cranePLCBase.PlanUpX = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_PLAN_UP_X);
                //25计划起卷Y
                cranePLCBase.PlanUpY = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_PLAN_UP_Y);
                //26计划起卷Z
                cranePLCBase.PlanUpZ = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_PLAN_UP_Z);
                //27计划落卷X
                cranePLCBase.PlanDownX = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_PLAN_DOWN_X);
                //28计划落卷Y
                cranePLCBase.PlanDownY = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_PLAN_DOWN_Y);
                //29计划落卷Z
                cranePLCBase.PlanDownZ = get_value_real(tag_Head + CranePLCStatusBase.ADRESS_PLAN_DOWN_Z);
                //30行车状态
                cranePLCBase.CraneStatus = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_CRANE_STATUS);
                //31 receiveTime
                cranePLCBase.ReceiveTime = get_value_string(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_HEART_BEAT).ToString();
                //32
                cranePLCBase.XExcuting = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_X_EXCUTING);
                //33
                cranePLCBase.YExcuting = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_Y_EXCUTING);
                //34
                cranePLCBase.ZExcuting = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_Z_EXCUTING);
                //35
                cranePLCBase.RExcuting = get_value_x(tag_Head + CranePLCStatusBase.ADRESS_CRANE_PLC_R_EXCUTING);

            }
            catch (Exception ex)
            {
            }
            return cranePLCBase;
        }


        private long get_value_x(string tagName)
        {
            long theValue = 0;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToInt32(valueObject);
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }

        private long get_value_real(string tagName)
        {
            long theValue = 0;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToInt32(Convert.ToDouble(valueObject));
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }

        private string get_value_string(string tagName)
        {
            string theValue = string.Empty;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToString( (valueObject) );
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }

        private double get_value_Double(string tagName)
        {
            double theValue = 0;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToDouble(valueObject);
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }


    }
}
