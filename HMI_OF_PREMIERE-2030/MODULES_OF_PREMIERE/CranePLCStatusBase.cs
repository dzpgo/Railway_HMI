using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODULES_OF_PREMIERE
{
    public class CranePLCStatusBase : ICloneable
    {
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public CranePLCStatusBase Clone()
        {
            return (CranePLCStatusBase)this.MemberwiseClone();
        }

        //1 CRANE_NO 字1
        private string craneNO = string.Empty;

        public string CraneNO
        {
            get { return craneNO; }
            set { craneNO = value; }
        }

        //2 READY       灯1
        private long ready = 0;

        public long Ready
        {
            get { return ready; }
            set { ready = value; }
        }

        //3 CONTROL_MODE  字2
        private long controlMode = 0;

        public long ControlMode
        {
            get { return controlMode; }
            set { controlMode = value; }
        }

        //4 ASK_PLAN 灯2
        private long askPlan = 0;

        public long AskPlan
        {
            get { return askPlan; }
            set { askPlan = value; }
        }

        //5 TASK_EXCUTING 灯3
        private long taskExcuting = 0;

        public long TaskExcuting
        {
            get { return taskExcuting; }
            set { taskExcuting = value; }
        }

        //6 XACT 字3
        private long xAct = 0;

        public long XAct
        {
            get { return xAct; }
            set { xAct = value; }
        }

        //7 YACT 字4
        private long yAct = 0;

        public long YAct
        {
            get { return yAct; }
            set { yAct = value; }
        }

        //8 ZACT 字5
        private long zAct = 0;

        public long ZAct
        {
            get { return zAct; }
            set { zAct = value; }
        }

        //9 XSPEED 字6
        private long xSpeed = 0;

        public long XSpeed
        {
            get { return xSpeed; }
            set { xSpeed = value; }
        }

        //10 YSPEED 字7
        private long ySpeed = 0;

        public long YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }

        //11 ZSPEED 字8
        private long zSpeed = 0;

        public long ZSpeed
        {
            get { return zSpeed; }
            set { zSpeed = value; }
        }

        //12 XDIR_P 灯4
        private long xDirPositive = 0;

        public long XDirPositive
        {
            get { return xDirPositive; }
            set { xDirPositive = value; }
        }

        //13 XDIR_N 灯5
        private long xDirectNegative = 0;

        public long XDirectNegative
        {
            get { return xDirectNegative; }
            set { xDirectNegative = value; }
        }

        //14 YDIR_P 灯6
        private long yDirectPositive = 0;

        public long YDirectPositive
        {
            get { return yDirectPositive; }
            set { yDirectPositive = value; }
        }

        //15 YDIR_N 灯7
        private long yDirectNegative = 0;

        public long YDirectNegative
        {
            get { return yDirectNegative; }
            set { yDirectNegative = value; }
        }

        //16 ZDIR_P 灯8
        private long zDirectPositive = 0;

        public long ZDirectPositive
        {
            get { return zDirectPositive; }
            set { zDirectPositive = value; }
        }

        //17 ZDIR_N 灯9
        private long zDirectNegative = 0;

        public long ZDirectNegative
        {
            get { return zDirectNegative; }
            set { zDirectNegative = value; }
        }

        //18 HAS_COIL 灯10
        private long hasCoil = 0;

        public long HasCoil
        {
            get { return hasCoil; }
            set { hasCoil = value; }
        }

        //19 WEIGHT_LOADED 字9
        private long weightLoaded = 0;

        public long WeightLoaded
        {
            get { return weightLoaded; }
            set { weightLoaded = value; }
        }

        //20 ROTATE_ANGLE_ACT 字10
        private long rotateAngleAct = 0;

        public long RotateAngleAct
        {
            get { return rotateAngleAct; }
            set { rotateAngleAct = value; }
        }

        //21 CLAMP_WIDTH_ACT 字11
        private long clampWidthAct = 0;

        public long ClampWidthAct
        {
            get { return clampWidthAct; }
            set { clampWidthAct = value; }
        }

        //22 EMG_STOP 灯11
        private long emgStop = 0;

        public long EmgStop
        {
            get { return emgStop; }
            set { emgStop = value; }
        }

        //23 ORDER_ID 字12
        private long orderID = 0;

        public long OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        //24 PLAN_UP_X 字13
        private long planUpX = 0;

        public long PlanUpX
        {
            get { return planUpX; }
            set { planUpX = value; }
        }

        //25 PLAN_UP_Y 字14
        private long planUpY = 0;

        public long PlanUpY
        {
            get { return planUpY; }
            set { planUpY = value; }
        }

        //26 PLAN_UP_Z 字15
        private long planUpZ = 0;

        public long PlanUpZ
        {
            get { return planUpZ; }
            set { planUpZ = value; }
        }

        //27 PLAN_DOWN_X 字16
        private long planDownX = 0;

        public long PlanDownX
        {
            get { return planDownX; }
            set { planDownX = value; }
        }

        //28 PLAN_DOWN_Y 字17
        private long planDownY = 0;

        public long PlanDownY
        {
            get { return planDownY; }
            set { planDownY = value; }
        }

        //29 PLAN_DOWN_Z 字18
        private long planDownZ = 0;

        public long PlanDownZ
        {
            get { return planDownZ; }
            set { planDownZ = value; }
        }

        //30 CRANE_STATUS 字19
        private long craneStatus = 0;

        public long CraneStatus
        {
            get { return craneStatus; }
            set { craneStatus = value; }
        }

        //31 receiveTime
        private string receiveTime = string.Empty;

        public string ReceiveTime
        {
            get { return receiveTime; }
            set { receiveTime = value; }
        }

        //32 x_excuting 灯
        private long xExcuting = 0;

        public long XExcuting
        {
            get { return xExcuting; }
            set { xExcuting = value; }
        }

        //33 y_excuting 灯
        private long yExcuting = 0;

        public long YExcuting
        {
            get { return yExcuting; }
            set { yExcuting = value; }
        }

        //34 z_excuting 灯
        private long zExcuting = 0;

        public long ZExcuting
        {
            get { return zExcuting; }
            set { zExcuting = value; }
        }

        //35 R_excuting 灯
        private long rExcuting = 0;

        public long RExcuting
        {
            get { return rExcuting; }
            set { rExcuting = value; }
        }

        public string CraneStatusDesc()
        {
            //空钩起升过程= 000;
            if (craneStatus == STATUS_NEED_TO_READY)
            {
                return STATUS_NEED_TO_READY_Desc;
            }
             //空钩等待状态= 010
            else if (craneStatus == STATUS_WAITING_ORDER_WITH_OUT_COIL)
            {
                return STATUS_WAITING_ORDER_WITH_OUT_COIL_Desc;
            }
             //空钩走行状态= 020
            else if (craneStatus == STATUS_MOVING_WITH_OUT_COIL)
            {
                return STATUS_MOVING_WITH_OUT_COIL_Desc;
            }
            //空钩走行到位状态= 030
            else if (craneStatus == STATUS_ARRIVED_POS_WITH_OUT_COIL)
            {
                return STATUS_ARRIVED_POS_WITH_OUT_COIL_Desc;
            }
            //空钩下降去取卷= 040
            else if (craneStatus == STATUS_LIFT_COIL_DOWN_PHASE)
            {
                return STATUS_LIFT_COIL_DOWN_PHASE_Desc;
            }
            //钢卷起吊= 050
            else if (craneStatus == STATUS_COIL_LIFTED)
            {
                return STATUS_COIL_LIFTED_Desc;
            }
            //重钩起升过程= 060
            else if (craneStatus == STATUS_LIFT_COIL_UP_PHASE)
            {
                return STATUS_LIFT_COIL_UP_PHASE_Desc;
            }
            //重钩等待状态= 070
            else if (craneStatus == STATUS_WAITING_ORDER_WITH_COIL)
            {
                return STATUS_WAITING_ORDER_WITH_COIL_Desc;
            }
            //重钩走行状态= 080
            else if (craneStatus == STATUS_MOVING_WITH_COIL)
            {
                return STATUS_MOVING_WITH_COIL_Desc;
            }
            //重钩走行到位= 090
            else if (craneStatus == STATUS_ARRIVED_POS_WITH_COIL)
            {
                return STATUS_ARRIVED_POS_WITH_COIL_Desc;
            }
            //重钩下降去落卷= 100
            else if (craneStatus == STATUS_DOWN_COIL_DOWN_PHASE)
            {
                return STATUS_DOWN_COIL_DOWN_PHASE_Desc;
            }
            //钢卷落关= 110
            else if (craneStatus == STATUS_COIL_DOWN)
            {
                return STATUS_COIL_DOWN_Desc;
            }
            else
            {
                return string.Empty;
            }
        }

        	//--------------------------------------------------行车设备状态定义----------------------------------------------------------------
			 //空钩起升过程= 000;
			 public const   long STATUS_NEED_TO_READY=0;
			 //空钩等待状态= 010
			 public const   long STATUS_WAITING_ORDER_WITH_OUT_COIL=10;
			 //空钩走行状态= 020
			 public const   long STATUS_MOVING_WITH_OUT_COIL=20;
			 //空钩走行到位状态= 030
			 public const   long STATUS_ARRIVED_POS_WITH_OUT_COIL=30;
			 //空钩下降去取卷= 040
			 public const   long STATUS_LIFT_COIL_DOWN_PHASE=40;
			 //钢卷起吊= 050
			 public const   long STATUS_COIL_LIFTED=50;
			 //重钩起升过程= 060
			 public const   long STATUS_LIFT_COIL_UP_PHASE=60;
			 //重钩等待状态= 070
			 public const   long STATUS_WAITING_ORDER_WITH_COIL=70;
			 //重钩走行状态= 080
			 public const   long STATUS_MOVING_WITH_COIL=80;
			 //重钩走行到位= 090
			 public const   long STATUS_ARRIVED_POS_WITH_COIL=90;
			 //重钩下降去落卷= 100
			 public const   long STATUS_DOWN_COIL_DOWN_PHASE=100;
			 //钢卷落关= 110
             public const long STATUS_COIL_DOWN = 110;


             //空钩起升过程= 000;
             public const string STATUS_NEED_TO_READY_Desc = "空钩起升";
             //空钩等待状态= 010
             public const string STATUS_WAITING_ORDER_WITH_OUT_COIL_Desc = "空钩等待";
             //空钩走行状态= 020
             public const string STATUS_MOVING_WITH_OUT_COIL_Desc = "空钩走行";
             //空钩走行到位状态= 030
             public const string STATUS_ARRIVED_POS_WITH_OUT_COIL_Desc = "空钩到位";
             //空钩下降去取卷= 040
             public const string STATUS_LIFT_COIL_DOWN_PHASE_Desc = "起卷下降";
             //钢卷起吊= 050
             public const string STATUS_COIL_LIFTED_Desc = "钢卷起吊";
             //重钩起升过程= 060
             public const string STATUS_LIFT_COIL_UP_PHASE_Desc = "起卷上升";
             //重钩等待状态= 070
             public const string STATUS_WAITING_ORDER_WITH_COIL_Desc = "重钩等待";
             //重钩走行状态= 080
             public const string STATUS_MOVING_WITH_COIL_Desc = "重钩走行";
             //重钩走行到位= 090
             public const string STATUS_ARRIVED_POS_WITH_COIL_Desc = "重钩到位";
             //重钩下降去落卷= 100
             public const string STATUS_DOWN_COIL_DOWN_PHASE_Desc = "落卷下降";
             //钢卷落关= 110
             public const string STATUS_COIL_DOWN_Desc = "钢卷落关";


		//--------------------------------------------------行车状态信号对应的系统内部tag点定义-------------------------------------
			//--------------------------------------------------系统内部tag点主要供给画面使用，行车后台程序不使用------------
			 //2准备好
			 public const string ADRESS_READY="ready";
			 //3控制模式
			 public const  string  ADRESS_CONTROL_MODE="autoMode";
			 //4请求计划
			 public const  string ADRESS_ASK_PLAN="askPlan";
			 //5任务执行中
			 public const  string ADRESS_TASK_EXCUTING="taskExcuting";
			 //6大车位置
			 public const  string ADRESS_XACT="xAct";
			 //7小车位置
			 public const  string ADRESS_YACT="yAct";
			 //8夹钳高度
			 public const  string ADRESS_ZACT="zAct";
			 //9大车方向实际速度
			 public const  string ADRESS_XSPEED="xSpeed";
			 //10小车方向实际速度
			 public const  string ADRESS_YSPEED="ySpeed";
			 //11升降实际速度
			 public const  string ADRESS_ZSPEED="zSpeed";
			 //12大车正方向
			 public const  string ADRESS_XDIR_P="xDir_P";
			 //13大车负方向
			 public const  string ADRESS_XDIR_N="xDir_N";
			 //14小车正方向
			 public const  string ADRESS_YDIR_P="yDir_P";
			 //15小车负方向
			 public const  string ADRESS_YDIR_N="yDir_N";
			 //16升降正方向
			 public const  string ADRESS_ZDIR_P="zDir_P";
			 //17升降负方向
			 public const  string ADRESS_ZDIR_N="zDir_N";
			 //18有卷标志
			 public const  string ADRESS_HAS_COIL="hasCoil";
			 //19称重信号
			 public const  string ADRESS_WEIGHT_LOADED="weightLoaded";
			 //20夹钳旋转角度
			 public const  string ADRESS_ROTATE_ANGLE_ACT="rotateAngleAct";
			 //21夹钳开度
			 public const  string ADRESS_CLAMP_WIDTH_ACT="pawActWidth";
			 //22急停状态
			 public const  string ADRESS_EMG_STOP="emergencyStop";
			 //23当前指令号
			 public const  string ADRESS_ORDER_ID="craneOrderNo";
			 //24计划起卷X
			 public const  string ADRESS_PLAN_UP_X="planUpX";
			 //25计划起卷Y
			 public const  string ADRESS_PLAN_UP_Y="planUpY";
			 //26计划起卷Z
			 public const  string ADRESS_PLAN_UP_Z="planUpZ";
			 //27计划落卷X
			 public const  string ADRESS_PLAN_DOWN_X="planDownX";
			 //28计划落卷Y
			 public const  string ADRESS_PLAN_DOWN_Y="planDownY";
			 //29计划落卷Z
			 public const  string ADRESS_PLAN_DOWN_Z="planDownZ";
			 //30行车状态
			 public const  string ADRESS_CRANE_STATUS="status";
            //31 HEART_BEAT
             public const string ADRESS_CRANE_PLC_HEART_BEAT = "heartBeat";
             //32 x_excuting
             public const string ADRESS_CRANE_PLC_X_EXCUTING = "x_excuting";
             //33 y_excuting
             public const string ADRESS_CRANE_PLC_Y_EXCUTING = "y_excuting";
             //34 y_excuting
             public const string ADRESS_CRANE_PLC_Z_EXCUTING = "z_excuting";
             //35 r_excuting
             public const string ADRESS_CRANE_PLC_R_EXCUTING = "r_excuting";
		

			 //---------------------------------------------------------------------------------------------------------------------------------------------------









    }
}
