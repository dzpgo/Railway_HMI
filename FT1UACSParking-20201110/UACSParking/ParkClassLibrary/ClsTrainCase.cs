using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using System.Data;
using System.Drawing;
using ParkClassLibrary;

namespace ParkClassLibrary
{
    public class ClsTrainCase : ICloneable  
    {
        private string railwayLineNO; //轨道号

        public string RailwayLineNO
        {
            get { return railwayLineNO; }
            set { railwayLineNO = value; }
        }
        private string trainCaseNO; //车皮号

        public string TrainCaseNO
        {
            get { return trainCaseNO; }
            set { trainCaseNO = value; }
        }

        private string trainCaseName;  //车皮名称

        public string TrainCaseName
        {
            get { return trainCaseName; }
            set { trainCaseName = value; }
        }
        //int trainCaseCount;  //车皮总数

        //public int TrainCaseCount
        //{
        //    get { return trainCaseCount; }
        //    set { trainCaseCount = value; }
        //}
        private string specification; //规格(车皮类型)

        public string Specification
        {
            get { return specification; }
            set { specification = value; }
        }
        bool isConfirmTrainCaseType;   //车皮确认

        public bool IsConfirmTrainCaseType
        {
            get { return isConfirmTrainCaseType; }
            set { isConfirmTrainCaseType = value; }
        }
        string treatmentNO;   //处理号

        public string TreatmentNO
        {
            get { return treatmentNO; }
            set { treatmentNO = value; }
        }
        private string stowageID;   //配载ID

        public string StowageID
        {
            get { return stowageID; }
            set { stowageID = value; }
        }

        private string stowageType; //配载类型1-1--1--1-1

        public string StowageType
        {
            get { return stowageType; }
            set { stowageType = value; }
        }
        private string stowageName;  //配载名称FA1

        public string StowageName
        {
            get { return stowageName; }
            set { stowageName = value; }
        }

        bool isConfirmStowageType;   //配载确认

        public bool IsConfirmStowageType
        {
            get { return isConfirmStowageType; }
            set { isConfirmStowageType = value; }
        }
      
        private int railwayStatus;   //火车当前状态

        public int RailwayStatus
        {
            get { return railwayStatus; }
            set { railwayStatus = value;
            isConfirmTrainCaseType = railwayStatus > 10 ? true : false;
            IsConfirmStowageType = railwayStatus > 20 ? true : false;
            }
        }

        private int trainCaseStatus;  //火车皮状态

        public int TrainCaseStatus
        {
            get { return trainCaseStatus; }
            set { trainCaseStatus = value; 

            }
        }
        Dictionary<string, clsTrainCoils> trainCaseCoils = new Dictionary<string, clsTrainCoils>();  //车皮上的钢卷
        public Dictionary<string, clsTrainCoils> TrainCaseCoils
        {
            get { return trainCaseCoils; }
            //set { trainCaseCoils = value == null ? new Dictionary<string, clsTrainCoils>() : new Dictionary<string, clsTrainCoils>(value); }
        }
        public void setTrainCaseCoils(Dictionary<string, clsTrainCoils> valueTrainCaseCoils)
        {
            trainCaseCoils = valueTrainCaseCoils == null ? new Dictionary<string, clsTrainCoils>() : new Dictionary<string, clsTrainCoils>(valueTrainCaseCoils); 
        }
        private Point startPoint; //开始坐标

        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        private Point endPoint;  //结束坐标

        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }
        private Size trainCaseSize;   //大小

        public Size TrainCaseSize
        {
            get { return trainCaseSize; }
            set { trainCaseSize = value; }
        }
        private int trainHeight = 0; //高度

        public int TrainHeight
        {
            get { return trainHeight; }
            set { trainHeight = value; }
        }
        private Size laserTrainCaseSize;   //激光数据

        public Size LaserTrainCaseSize  
        {
            get { return laserTrainCaseSize; }
            set { laserTrainCaseSize = value; }
        }

        private int laserFloorZ = 0;  //激光高度

        public int LaserFloorZ
        {
            get { return laserFloorZ; }
            set { laserFloorZ = value; }
        }
        private int laserCount = 0;   //激光统计

        public int LaserCount
        {
            get { return laserCount; }
            set { laserCount = value; }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        } 


    }

}
