using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace Inventory
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 载入log配置文件
            string logConfigFile = System.Environment.GetEnvironmentVariable("IPLATURE") + "\\SF_HOME\\config\\log4net.config";
            if (System.IO.File.Exists(logConfigFile))
            {
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(logConfigFile));
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InventoryShow());

            // 关闭log4net
            log4net.LogManager.Shutdown();
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
    }
}
