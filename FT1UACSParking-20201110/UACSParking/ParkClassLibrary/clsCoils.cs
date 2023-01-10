using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ParkClassLibrary
{
    public class clsCoils
    {
        public string MAT_NO = "";
        public string PLAN_NO = "";
        public string ColumnNO = "";
        public string BigareaNo = "";
        public string weight = "";
        public string width = "";
        public string outDIA = "";
        public override string ToString()
        {
            return MAT_NO + "  " + PLAN_NO + "  " + ColumnNO + "  " + weight + "  " + width + "  " + outDIA;
        }
    }

    public class clsTrainCoils
    {
        public string MAT_NO = ""; 
        public string PLAN_NO = "";
        public string ColumnNO = "";  //库位号
        public string BigareaNo = "";
        public string bracketNO = "";  //支架号
        public int status = 0;
        public Size coilSize = new Size(0, 0);
        public Point coilPoint = new Point(0, 0);
        public clsTrainCoils(clsTrainCoils clsTrainCoil)
        {
            MAT_NO = clsTrainCoil.MAT_NO;
            PLAN_NO = clsTrainCoil.PLAN_NO;
            ColumnNO = clsTrainCoil.ColumnNO;
            BigareaNo = clsTrainCoil.BigareaNo;
            bracketNO = clsTrainCoil.bracketNO;
            status = clsTrainCoil.status;

            coilSize = new Size(clsTrainCoil.coilSize.Width, clsTrainCoil.coilSize.Height);
            coilPoint = new Point(clsTrainCoil.coilPoint.X, clsTrainCoil.coilPoint.Y);
        }
        public clsTrainCoils()
        {

        }
        public override string ToString()
        {
            return MAT_NO + "    " + bracketNO + "      " + ColumnNO + "    " + PLAN_NO;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        } 
    }

    public class clsTrainCaseInfo
    {

        public string caseNO,                           //
            traincaseName,
            trainType,
            stowageName,                                //FA
            treatmentNO,
            stowgeID,
            stowageType;                          //1-0--

        public int railwayStatus,
            length,
            width,
            floorz,
            laserLength,
            laserWidth,
            laserFloorZ,
            laserCount,
            caseStatus;

    }
}
