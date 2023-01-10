using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CLTS;
using CltsSlice4NetCf;

namespace _1550PDA
{
    class ClsPackingScanSubmit
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("PDA");
        public delegate void DisplaySubmitResult(string msg, bool bResult);
        private string stockNo;
        private string matNo;
        private DisplaySubmitResult callback = null;

        private ClsPackingScanSubmit()
        {
        }

        public ClsPackingScanSubmit(string strStockNo, string strMatNo, DisplaySubmitResult callbackFunc)
        {
            stockNo = strStockNo;
            matNo = strMatNo;
            callback = callbackFunc;
        }

        public void Submit()
        {
            try
            {
                YardMapFactoryPrx yardmapFactoryPrx = null;

                log.Debug("In Submit...1");

                if (stockNo.IndexOf("Z51") == 0)
                    yardmapFactoryPrx = CltsCommunicator.Instance().getYardMapFactory("Z51");
                else if (stockNo.IndexOf("Z52") == 0)
                    yardmapFactoryPrx = CltsCommunicator.Instance().getYardMapFactory("Z52");
                else if (stockNo.IndexOf("Z53") == 0)
                    yardmapFactoryPrx = CltsCommunicator.Instance().getYardMapFactory("Z53");

                log.Debug("In Submit...2");

                // 设置库位状态
                StockPrx stockPrx = yardmapFactoryPrx.getStock(stockNo);
                stockPrx.setOccupied(matNo);
                stockPrx.setConfirmed(matNo, "PDA");

                log.Debug("In Submit...3");

                // 回调通知调用者
                if (callback != null)
                    callback(String.Format("材料{0}提交成功", matNo), true);

                log.Debug("In Submit...4");
            }
            catch (CLTSException ex)
            {
                log.Error(ex.reason);

                if (callback != null)
                    callback(ex.reason, false);      
            }
            catch (System.Exception ex)
            {
                // 取得异常信息
                string errorMessage = ex.Message;
                System.Exception parentException = ex.InnerException;
                while (parentException != null)
                {
                    errorMessage += parentException.Message.ToString() + "\n";
                    parentException = parentException.InnerException;
                }

                log.Error(errorMessage);

                // 回调通知调用者
                if (callback != null)
                    callback(errorMessage, false);                    
            }
        }
    }
}
