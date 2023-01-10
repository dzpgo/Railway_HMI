using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace _1550PDA
{
    public class CMyLog
    {
        private string m_file;
        private bool m_bLogDaily;
        private string logDirectory;

        private static Object thislock = new Object();

        private CMyLog()
        {
            InitLogDirectory();
        }

        public CMyLog(string file, bool bLogDaily)
        {
            m_file = file;
            m_bLogDaily = bLogDaily;
            InitLogDirectory();
        }

        private void InitLogDirectory()
        {
            // 找到程序运行路径
            string strAssemblyFilePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            // 找到程序集名称
            int indexStart = strAssemblyFilePath.LastIndexOf('\\') + 1;
            int indexEnd = strAssemblyFilePath.LastIndexOf('.');
            strAssemblyFilePath = strAssemblyFilePath.Substring(0, strAssemblyFilePath.LastIndexOf('\\'));
            //logDirectory = String.Format("{0}\\log", strAssemblyFilePath);
            logDirectory = "\\Temp";
            // 创建文件夹
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);
        }

        public void log(string strlog)
        {
            string file;

            if (m_bLogDaily)
            {
                file = string.Format("{0}\\{1}_{2}-{3}-{4}.log",
                    logDirectory,
                    m_file,
                    System.DateTime.Now.Year,
                    System.DateTime.Now.Month,
                    System.DateTime.Now.Day);
            }
            else
            {
                file = string.Format("{0}\\{1}",
                    logDirectory,
                    m_file);
            }

            // 追加文件
            lock (thislock)
            {
                // 写独占保证
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString());
                    sw.WriteLine("  {0}", strlog);
                    sw.Flush();
                }
            }
        }

        #region LoggerOperationsNC_ 成员

        public void error(string msg)
        {
            log("error: " + msg);
        }

        public void print(string msg)
        {
            string s = msg;

            s = s.Replace("\n", "\n\r");

            log(s);
        }

        public void trace(string category, string msg)
        {
            string s = "[ " + category + ": " + msg + " ]";

            s = s.Replace("\n", "\n\r");

            log(s);
        }

        public void warning(string msg)
        {
            log("warning: " + msg);
        }

        public void message(string msg)
        {
            log("message: " + msg);
        }

        #endregion
    }
}