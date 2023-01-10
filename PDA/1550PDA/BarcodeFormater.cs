using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _1550PDA
{
    class BarcodeFormater
    {
        public static bool IsStockBarCode(string strBarcode)
        {
            bool bIsStock = false;
            if (strBarcode.ToUpper().IndexOf("Z") == 0)
                bIsStock = true;

            return bIsStock;
        }

        public static bool IsManuPackingStockNo(string stockNo)
        {
            bool bResult = false;
            if (stockNo.Length > 6)
            {
                string strRowNo = stockNo.Substring(3, 3);
                if (strRowNo == "200")
                    bResult = true;
            }

            return bResult;
        }

        public static bool parseMatBarCode(string barcode, out string matNo)
        {
            bool bResult = true;
            matNo = barcode.ToUpper();
            if (matNo.IndexOf("S") == 0)
                matNo = barcode.Substring(1);

            return bResult;
        }

        public static bool parseStockBarCode(string unitno, out string stock, TextBox txtresult)
        {
            bool bResult = false;
            stock = "";

            try
            {
                string store = "";
                string row = "";
                string col = "";
                string layer = "1";
                //根据扫描到的长度补位
                if (unitno.Length == 8)
                {
                    //行列都需要补位
                    store = unitno.Substring(0, 3);
                    row = "0" + unitno.Substring(3, 2);
                    col = "0" + unitno.Substring(5, 2);
                    stock = store + row + col + layer;
                }
                if (unitno.Length == 9)
                {
                    //行需要补位
                    store = unitno.Substring(0, 3);
                    row = unitno.Substring(3, 3);
                    col = "0" + unitno.Substring(6, 2);
                    stock = store + row + col + layer;
                }
                if (unitno.Length == 10)
                {
                    //不需要补位
                    store = unitno.Substring(0, 3);
                    row = unitno.Substring(3, 3);
                    col = unitno.Substring(6, 3);
                    stock = store + row + col + layer;
                }

                //if (!area.Contains(row) || !area.Contains(store))
                //{
                //    txtresult.Text = String.Format("识别库位{0}不属于扫描范围", stock);
                //    txtresult.BackColor = Color.Red;
                //    stock = "";
                //}
                //else
                {
                    bResult = true;
                    txtresult.Text = "识别扫描库位";
                    txtresult.BackColor = Color.Green;
                }
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

            return bResult;
        }

        public static bool parseStockBarCode(string unitno, out string stock)
        {
            bool bResult = false;
            stock = "";

            try
            {
                string store = "";
                string row = "";
                string col = "";
                string layer = "1";
                //根据扫描到的长度补位
                if (unitno.Length == 8)
                {
                    bResult = true;

                    //行列都需要补位
                    store = unitno.Substring(0, 3);
                    row = "0" + unitno.Substring(3, 2);
                    col = "0" + unitno.Substring(5, 2);
                    stock = store + row + col + layer;
                }
                else if (unitno.Length == 9)
                {
                    bResult = true;

                    //行需要补位
                    store = unitno.Substring(0, 3);
                    row = unitno.Substring(3, 3);
                    col = "0" + unitno.Substring(6, 2);
                    stock = store + row + col + layer;
                }
                else if (unitno.Length == 10)
                {
                    bResult = true;

                    //不需要补位
                    store = unitno.Substring(0, 3);
                    row = unitno.Substring(3, 3);
                    col = unitno.Substring(6, 3);
                    stock = store + row + col + layer;
                }               
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

            return bResult;
        }

        
    }
}
