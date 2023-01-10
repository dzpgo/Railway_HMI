using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using PT;

namespace _1550PDA
{
    static class Program
    {
        public static Ice.Communicator g_comm = null;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("PDA");

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                // 读取运行程序文件夹
                location = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly()
                   .GetModules()[0].FullyQualifiedName);

                // 载入log配置文件
                string logConfigFile = location + "\\config.log4net";
                if (System.IO.File.Exists(logConfigFile))
                {
                    log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(logConfigFile));
                }

                // 启动登录界面
                Application.Run(new LoginForm());
            }
            catch (System.Exception ex)
            {
                LogException(ex, true);
            }
        }

        public static string Location
        {
            get { return location; }
        }
        private static string location;


        // 上下文显示传递信息
        public static Dictionary<string, string> ctx = new Dictionary<string, string>();

        public static void LogException(System.Exception ex, bool bShow)
        {
            //CMyLog log = new CMyLog("PDA.log", true);

            // 取得异常信息
            string errorMessage = ex.Message;
            System.Exception parentException = ex.InnerException;
            while (parentException != null)
            {
                errorMessage += parentException.Message.ToString() + "\n";
                parentException = parentException.InnerException;
            }
            // 封装成CLTSException异常
            log.Error(String.Format("{0}\r\n{1}\r\n{2}",
                  ex.GetType().Name,
                  errorMessage,
                  ex.StackTrace));

            if (bShow)
                MessageBox.Show(errorMessage + "！（详见日志文件）");
        }

        public static string ToChnDirection(string direction)
        {
            string str ="";

            switch (direction)
            {
                case "0":
                    str = "上开卷";
                    break;
                case "1":
                    str = "下开卷";
                    break;
                case "2c":
                    str = "未知";
                    break;
            }

            return str;
        }

        public static string ToChnSleeveLength(string length)
        {
            string str = "";

            switch (length)
            {
                case "L1":
                    str = "一级套筒";
                    break;
                case "L2":
                    str = "二级套筒";
                    break;
                case "L3":
                    str = "三级套筒";
                    break;
            }

            return str;
        }

        public static string ToChnOutMatStatus(string status)
        {
            string str = "";

            switch (status)
            {
                case "Wrong":
                    str = "错误卷";
                    break;
                case "Scaned":
                    str = "已扫描";
                    break;
                case "UnScan":
                    str = "未扫描";
                    break;
                case "obstacle":
                    str = "障碍钢卷";
                    
                    break;
            }

            return str;
        }

        public static string ToUnitNO(dtUnit unit)
        {
            string lay = "";
            if (unit.layer.ToString().Length == 1)
            {
                lay = "0" + unit.layer.ToString();
            }
            else
            {
                lay = unit.layer.ToString();
            }
            string str = unit.StoreID + unit.UnitNo + lay;
            return str;
        }

    }
}