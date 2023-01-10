/*
 * Copyright (c) 2002-2011 by Psion Inc.
 * All rights reserved.
 *
 * This material is proprietary to Psion Inc. and,
 * in addition to the above mentioned Copyright, may be
 * subject to protection under other intellectual property
 * regimes, including patents, trade secrets, designs and/or
 * trademarks.
 *
 * This code and all related information is provided 揂s Is?
 * and without warranty of any kind, either express or
 * implied including, but not limited to, warranties of
 * merchantability and/or fitness for any particular
 * purpose.
 *
 */

using System;
using System.Collections.Generic;
using System.Text;

using PsionTeklogix.Barcode;
using PsionTeklogix.Barcode.ScannerServices;

namespace _1550PDA
{
    
    static class ScannerHelper
    {
        //扫描设备
        private static Scanner scanner;
        private static ScannerServicesDriver scannerServicesDriver;

        // 扫描事件
        private static ScanCompleteEventHandler scanCompleteEvent;

        public static bool IsScannerPresent()
        {
            return ScannerServicesDriver.IsScannerPresent;
        }

        /// <summary>
        /// 扫描初始化方法
        /// </summary>
        private static void ScannerInit()
        {
            if (scanner != null) //Scanner already initialized
                return;

            scanner = new Scanner();
            scannerServicesDriver = new ScannerServicesDriver();
            scanner.Driver = scannerServicesDriver;
        }

        /// <summary>
        /// 扫描注册
        /// </summary>
        public static void RegisterWithScanner(ScanCompleteEventHandler handler)
        {
            if (scanner == null)
                ScannerInit();

            if (scanCompleteEvent != null)
                DeregisterWithScanner();

            scanner.ScanCompleteEvent += handler;
            scanCompleteEvent = handler;
        }

        /// <summary>
        /// 扫描解注册
        /// </summary>
        private static void DeregisterWithScanner()
        {
            try
            {
                if (scanner == null)
                    return;

                if (scanCompleteEvent != null)
                    scanner.ScanCompleteEvent -= scanCompleteEvent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 扫描结束 释放资源
        /// </summary>
        public static void ScannerDestroy()
        {
            if (scanner != null)
            {
                DeregisterWithScanner();
                scanner.Dispose();
                scanner = null;
            }

            if (scannerServicesDriver != null)
            {
                scannerServicesDriver.Dispose();
                scannerServicesDriver = null;
            }
        }
    }
}
