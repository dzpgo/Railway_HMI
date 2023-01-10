using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    public class LogManager
    {
        static object locker = new object();
        /// <summary>
        /// 重要信息写入日志
        /// </summary>
        /// <param name="logs">日志列表，每条日志占一行</param>
        public static void WriteProgramLog(params string[] logs)
        {
            lock (locker)
            {
                string LogAddress = Environment.CurrentDirectory + "\\Log";
                if (!Directory.Exists(LogAddress + "\\PRG"))
                {
                    Directory.CreateDirectory(LogAddress + "\\PRG");
                }
                LogAddress = string.Concat(LogAddress, "\\PRG\\",
                 DateTime.Now.Year, '-', DateTime.Now.Month, '-',
                 DateTime.Now.Day, "_program.log");
                StreamWriter sw = new StreamWriter(LogAddress, true);
                foreach (string log in logs)
                {
                    sw.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), log));
                }
                sw.Close();
            }
        }
    }
}
