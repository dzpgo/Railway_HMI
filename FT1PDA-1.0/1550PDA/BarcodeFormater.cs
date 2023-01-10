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

        public static bool parseStockBarCode(string unitno, out string stock, TextBox txtresult)
        {
            bool bResult = false;
            stock = "";

            try
            {
                stock = JudgeStockFormat1550(unitno);
                //string store = "";
                //string row = "";
                //string col = "";
                //string layer = "1";
                ////根据扫描到的长度补位
                //if (unitno.Length == 8)
                //{
                //    //行列都需要补位
                //    store = unitno.Substring(0, 3);
                //    row = "0" + unitno.Substring(3, 2);
                //    col = "0" + unitno.Substring(5, 2);
                //    stock = store + row + col + layer;
                //}
                //if (unitno.Length == 9)
                //{
                //    //行需要补位
                //    store = unitno.Substring(0, 3);
                //    row = unitno.Substring(3, 3);
                //    col = "0" + unitno.Substring(6, 2);
                //    stock = store + row + col + layer;
                //}
                //if (unitno.Length == 10)
                //{
                //    //不需要补位
                //    store = unitno.Substring(0, 3);
                //    row = unitno.Substring(3, 3);
                //    col = unitno.Substring(6, 3);
                //    stock = store + row + col + layer;
                //}

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
                stock = JudgeStockFormat1550(unitno);
                //string store = "";
                //string row = "";
                //string col = "";
                //string layer = "1";
                ////根据扫描到的长度补位
                //if (unitno.Length == 8)
                //{
                //    bResult = true;

                //    //行列都需要补位
                //    store = unitno.Substring(0, 3);
                //    row = "0" + unitno.Substring(3, 2);
                //    col = "0" + unitno.Substring(5, 2);
                //    stock = store + row + col + layer;
                //}
                //else if (unitno.Length == 9)
                //{
                //    bResult = true;

                //    //行需要补位
                //    store = unitno.Substring(0, 3);
                //    row = unitno.Substring(3, 3);
                //    col = "0" + unitno.Substring(6, 2);
                //    stock = store + row + col + layer;
                //}
                //else if (unitno.Length == 10)
                //{
                //    bResult = true;

                //    //不需要补位
                //    store = unitno.Substring(0, 3);
                //    row = unitno.Substring(3, 3);
                //    col = unitno.Substring(6, 3);
                //    stock = store + row + col + layer;
                //}               
            }
            catch (System.Exception ex)
            {
                Program.LogException(ex, true);
            }

            return bResult;
        }
        /// <summary>
        /// 判断输入库位格式是否合法
        /// </summary>
        /// <param name="strStock"></param>
        public static string JudgeStockFormat1550(string strStock)
        {
            string stock = "";
            string store = "";
            string row = "";
            string col = "";
            string layer = "1";
            //根据扫描到的长度补位
            if (strStock.Length == 8)
            {
                //行列都需要补位
                store = strStock.Substring(0, 3);
                row = "0" + strStock.Substring(3, 2);
                col = "0" + strStock.Substring(5, 2);
                stock = store + row + col + layer;
                return stock;
            }
            else if (strStock.Length == 9)
            {
                //行需要补位
                store = strStock.Substring(0, 3);
                row = strStock.Substring(3, 3);
                col = "0" + strStock.Substring(6, 2);
                stock = store + row + col + layer;
                return stock;
            }
            else if (strStock.Length == 10)
            {
                //不需要补位
                store = strStock.Substring(0, 3);
                row = strStock.Substring(3, 3);
                col = strStock.Substring(6, 3);
                stock = store + row + col + layer;
                return stock;
            }
            return stock;
        }
        public static string JudgeStockFormat1550(string strStock, out string store, out string row, out string col)
        {
            string stock = "";
            //string store = "";
            //string row = "";
            //string col = "";
            string layer = "1";
            //根据扫描到的长度补位
            if (strStock.Length == 8)
            {
                //行列都需要补位
                store = strStock.Substring(0, 3);
                row = "0" + strStock.Substring(3, 2);
                col = "0" + strStock.Substring(5, 2);
                stock = store + row + col + layer;
                return stock;
            }
            else if (strStock.Length == 9)
            {
                //行需要补位
                store = strStock.Substring(0, 3);
                row = strStock.Substring(3, 3);
                col = "0" + strStock.Substring(6, 2);
                stock = store + row + col + layer;
                return stock;
            }
            else if (strStock.Length == 10)
            {
                //不需要补位
                store = strStock.Substring(0, 3);
                row = strStock.Substring(3, 3);
                col = strStock.Substring(6, 3);
                stock = store + row + col + layer;
                return stock;
            }
            store = "";
            row = "";
            col = "";
            return stock;
        }
        /// <summary>
        /// 判断输入库位格式是否合法
        /// </summary>
        /// <param name="strStock"></param>
        public static string JudgeStockFormatFT11(string strStock)
        {
            string stock = "";
            string store = "";
            string row = "";
            string col = "";
            //string layer = "1";
            if (strStock.Contains('-'))
            {
                strStock = strStock.Replace("-", "");
            }
            //根据扫描到的长度补位
            if (strStock.Length == 8)
            {
                store = strStock.Substring(0, 5);  //FT11A
                row = strStock.Substring(5, 1);   //A行
                col = strStock.Substring(6, 2);  //列
                stock = store + row + col;
                return stock;
            }
            //else if (strStock.Length == 9)
            //{
            //    //行需要补位
            //    store = strStock.Substring(0, 3);
            //    row = strStock.Substring(3, 3);
            //    col = "0" + strStock.Substring(6, 2);
            //    stock = store + row + col + layer;
            //    return stock;
            //}
            //else if (strStock.Length == 10)
            //{
            //    //不需要补位
            //    store = strStock.Substring(0, 3);
            //    row = strStock.Substring(3, 3);
            //    col = strStock.Substring(6, 3);
            //    stock = store + row + col + layer;
            //    return stock;
            //}
            return stock;
        }
        public static string JudgeStockFormatFT11(string strStock, out string store, out string row, out string col)
        {
            string stock = "";
            //string layer = "1";
            if (strStock.Contains('-'))
            {
                strStock = strStock.Replace("-", "");
            }
            //根据扫描到的长度补位
            if (strStock.Length == 8)
            {
                store = strStock.Substring(0, 5);  //FT11A -->FT1-1-A
                //store = string.Format("{0}-{1}-{2}", strStock.Substring(0, 3), strStock.Substring(3, 1), strStock.Substring(4, 1));
                row = strStock.Substring(5, 1);   //A区
                col =  strStock.Substring(6, 2);  //
                stock = store + row + col ;
                return stock;
            }
            //else if (strStock.Length == 9)
            //{
            //    //行需要补位
            //    store = strStock.Substring(0, 3);
            //    row = strStock.Substring(3, 3);
            //    col = "0" + strStock.Substring(6, 2);
            //    stock = store + row + col + layer;
            //    return stock;
            //}
            //else if (strStock.Length == 10)
            //{
            //    //不需要补位
            //    store = strStock.Substring(0, 3);
            //    row = strStock.Substring(3, 3);
            //    col = strStock.Substring(6, 3);
            //    stock = store + row + col + layer;
            //    return stock;
            //}
            store = "";
            row = "";
            col = "";
            stock = store + row + col;
            return stock;
        }
    }
}
