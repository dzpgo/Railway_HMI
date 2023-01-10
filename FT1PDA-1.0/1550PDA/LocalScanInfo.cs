using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _1550PDA
{
    public class LocalScanInfo
    {
        public string StockNo
        {
            get { return stockNo; }
        }

        public string MatNo
        {
            get { return matNo; }
        }

        public string ScanTime
        {
            get { return scanTime; }
        }

        private string stockNo;
        private string matNo;
        private string scanTime;

        private LocalScanInfo()
        {
        }

        public LocalScanInfo(string stock, string mat)
        {
            stockNo = stock;
            matNo = mat;
            scanTime = String.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
        }
    }
}
