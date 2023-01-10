using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UACSUtility
{
    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Error = 3,
        Fatal = 4
    }


    public class HMILogger
    {
        private static LogLevel currentLevel = LogLevel.Info;
        private static string hostname = System.Net.Dns.GetHostName();
        private DataBaseHelper m_dbHelper = null;
        System.Net.IPAddress[] _IPList = System.Net.Dns.GetHostAddresses(hostname);

        #region 连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;

        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");
                    }
                    catch (System.Exception e)
                    {

                    }
                }
                return dbHelper;
            }
        }
        #endregion

        // 缓存日志信息 ，批量插入数据库
        private static IList<string> messages = new List<string>();

        //达到count就写入数据库一次
        private static int COUNT = 10;
        public HMILogger()
        {
            for (int i = 0; i != _IPList.Length; i++)
            {
                if (_IPList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    strIPList += _IPList[i].ToString();
                    strIPList += "  ";
                }
            }
        }
        public static void SetLogLevel(LogLevel level)
        {
            currentLevel = level;
        }

        public static void SetDBHelper(LogLevel level)
        {
            currentLevel = level;
        }
        static string strIPList = "";

        public static string StrIPList
        {
            get {
                if (strIPList == "")
                {
                    strIPList = getIPList(hostname);
                }
                return strIPList; }
            //set { strIPList = value; }
        }
        public static string WriteLog(string key1, string message, LogLevel level = 0, string module = "UACS_HMI", string userid = "")
        {
            return GenSQL(key1, "", message, level, module, userid);
        }

        public static string WriteLog(string key1, string key2, string message, LogLevel level = 0, string module = "UACS_HMI", string userid = "")
        {
            return GenSQL(key1, key2, message, level, module, userid);
        }


        private static string GenSQL(string key1, string key2, string info, LogLevel level, string module, string userid)
        {
            ////获得主机名
            //string HostName = Dns.GetHostName();
            //Console.WriteLine("主机名是：" + HostName);

            ////遍历地址列表，如果电脑有多网卡只能这样遍历显示
            //IPAddress[] iplist = Dns.GetHostAddresses(HostName);
            //for (int i = 0; i < iplist.Length; i++)
            //{
            //    Console.WriteLine("IP地址：" + iplist[i]);
            //}
            //string _ComputName = System.Net.Dns.GetHostName();

            string g = strIPList;
            userid = string.Format("{0}-{1}", hostname, StrIPList);
            string sql = "insert into  UACS_HMI_LOG(key1,key2,level,info,module,userid) values (@key1,@key2,@level,@info,@module,@userid)";
            if (string.IsNullOrEmpty(key1))
                sql = sql.Replace("@key1", "NULL");
            else
                sql = sql.Replace("@key1", "'" + key1 + "'");

            if (string.IsNullOrEmpty(key2))
                sql = sql.Replace("@key2", "NULL");
            else
                sql = sql.Replace("@key2", "'" + key2 + "'");

            if (string.IsNullOrEmpty(module))
                sql = sql.Replace("@module", "NULL");
            else
                sql = sql.Replace("@module", "'" + module + "'");

            if (string.IsNullOrEmpty(userid))
                sql = sql.Replace("@userid", "NULL");
            else
                sql = sql.Replace("@userid", "'" + userid + "'");

            if (string.IsNullOrEmpty(info))
                sql = sql.Replace("@info", "NULL");
            else
                sql = sql.Replace("@info", "'" + info + "'");

            sql = sql.Replace("@level", ((int)level).ToString());

            DBHelper.ExecuteNonQuery(sql);

            return sql;
        }
        private static string getIPList(string computerName)
        {
            string IPList;
            System.Net.IPAddress[] _IPList = System.Net.Dns.GetHostAddresses(computerName);
            string strIPList = "";
            for (int i = 0; i != _IPList.Length; i++)
            {
                if (_IPList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    strIPList += _IPList[i].ToString();
                    strIPList += "  ";
                }
            }
            IPList = strIPList;
            return IPList;
        }
    }
}
