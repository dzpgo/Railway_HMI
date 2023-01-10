using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLTS;

namespace MODEL_OF_REPOSITORIES
{
    /// <summary>
    /// 行车状态处理数据类
    /// </summary>
    public class CraneStatusInBay
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
                    // 准备好
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_READY);
                    // 控制模式
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_CONTROL_MODE);
                    // 请求计划
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_ASK_PLAN);
                    // 大车位置
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_XACT);
                    // 小车位置
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_YACT);
                    // 夹钳高度
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_ZACT);
                    // 有卷标志
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_HAS_COIL);
                    // 行车状态
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_CRANE_STATUS);
                    // HEART_BEAT
                    lstAdress.Add(tag_Head + CraneStatusBase.ADRESS_CRANE_PLC_HEART_BEAT);
                }
                arrTagAdress = lstAdress.ToArray<string>();
            }
            catch (Exception ex)
            {
            }
        }


        private Dictionary<string, CraneStatusBase> dicCranePLCStatusBase = new Dictionary<string, CraneStatusBase>();

        public Dictionary<string, CraneStatusBase> DicCranePLCStatusBase
        {
            get { return dicCranePLCStatusBase; }
        }



        //step4
        public void getAllPLCStatusInBay(List<string> listCraneNo)
        {
            try
            {
                readTags();
                foreach (string theCraneNO in lstCraneNO)
                {
                    if (listCraneNo.Contains(theCraneNO))
                    {
                        CraneStatusBase cranePLCStatusBase = getCranePLCStatusFromTags(theCraneNO);
                        dicCranePLCStatusBase[theCraneNO] = cranePLCStatusBase;
                    }
                  
                }

            }
            catch (Exception ex)
            {
            }
        }
        // 替换TAG读取
        public void getAllPLCStatusInBay(string bayNo)
        {
            try
            {
                readMyTags(bayNo);
                foreach (string theCraneNO in lstCraneNO)
                {
                    CraneStatusBase cranePLCStatusBase = getCranePLCStatusFromTags(theCraneNO);
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

        // 替换TAG读取
        private void readMyTags(string bayNo)
        {
            Dictionary<string, string> dictDatas = new Dictionary<string, string>();

            try
            {
                //LogManager.WriteProgramLog("-----------------------------------------------------------------");

                CLTS.MyTagPrx myTagProxy = CLTS.CltsCommunicator.Instance().getMyTagProxy("App_CraneStatusMonitor", bayNo);
                if (myTagProxy != null)
                    myTagProxy.read(arrTagAdress, out dictDatas);

                // 转换成TAG数据
                inDatas.Clear();
                foreach (string TagName in dictDatas.Keys)
                {
                    //LogManager.WriteProgramLog(String.Format("{0} = {1}", TagName, dictDatas[TagName]));
                    inDatas[TagName] = dictDatas[TagName];
                }
            }
            catch (System.Exception ex)
            {
               // LogManager.WriteProgramLog(String.Format("{0} \r\n {1}", ex.StackTrace, ex.Message));
            }
        }

        private CraneStatusBase getCranePLCStatusFromTags(string theCraneNO)
        {
            CraneStatusBase craneBase = new CraneStatusBase();
            try
            {
                craneBase.CraneNO = theCraneNO;
                string tag_Head = craneBase.CraneNO + "_";
                // 准备好
                craneBase.Ready = get_value_x(tag_Head + CraneStatusBase.ADRESS_READY);
                // 控制模式
                craneBase.ControlMode = get_value_x(tag_Head + CraneStatusBase.ADRESS_CONTROL_MODE);
                // 请求计划
                craneBase.AskPlan = get_value_x(tag_Head + CraneStatusBase.ADRESS_ASK_PLAN);
                // 大车位置  铁路库Double  成品库库int 
                craneBase.XAct = get_value_real(tag_Head + CraneStatusBase.ADRESS_XACT);  
                // 小车位置
                craneBase.YAct = get_value_real(tag_Head + CraneStatusBase.ADRESS_YACT);
                // 夹钳高度
                craneBase.ZAct = get_value_real(tag_Head + CraneStatusBase.ADRESS_ZACT);
                // 有卷标志
                craneBase.HasCoil = get_value_x(tag_Head + CraneStatusBase.ADRESS_HAS_COIL);              
                // 行车状态
                craneBase.CraneStatus = get_value_x(tag_Head + CraneStatusBase.ADRESS_CRANE_STATUS);
                // 心跳
                craneBase.ReceiveTime = get_value_string(tag_Head + CraneStatusBase.ADRESS_CRANE_PLC_HEART_BEAT).ToString();
            }
            catch (Exception ex)
            {
            }
            return craneBase;
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
            return theValue; 
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
            return theValue; 
        }

        private string get_value_string(string tagName)
        {
            string theValue = string.Empty;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToString((valueObject));
            }
            catch
            {
                valueObject = null;
            }
            return theValue; 
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
            return theValue; 
        }
    }
}
