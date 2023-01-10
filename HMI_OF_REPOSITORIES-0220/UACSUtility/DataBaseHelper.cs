using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using IBM.Data.DB2;


/// <summary>
/// 数据库工具类
/// @author 徐长盛  2017-9-7。
/// 对原来的DataBaseHelper进行了精简
/// </summary>
namespace UACSUtility
{


    /// <summary>
    /// 数据库访问类
    /// </summary>
    public class DataBaseHelper
    {

        private static DB2Connection db2Conn = null;
        private bool isOpened = false;

        //数据库连接字符串
        private string connectstr = "";


        public string Connectstr
        {
            get
            {
                return connectstr;
            }

            set
            {
                connectstr = value;
            }
        }


        public bool IsOpend()
        {
            return isOpened;
        }

        /// <summary>
        /// 根据外界提供的连接字符串直接打开数据库
        /// </summary>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public string OpenDB(string strConn)
        {
            if (isOpened || db2Conn != null)
                return "";

            connectstr = strConn;
            try
            {
                db2Conn = new IBM.Data.DB2.DB2Connection(connectstr);
                db2Conn.Open();
                isOpened = true;
            }
            catch (Exception ex)
            {
                //记录到画面的日志中去
                return ex.Message;
            }
            return "";
        }

        /// <summary>
        /// 打开DB2数据库
        /// </summary>
        /// <param name="server"></param>
        /// <param name="dsn_dbname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>数据库打开成功返回空，否则返回异常字符串</returns>
        public string OpenDB(string server, string database, string username, string password)
        {
            if (isOpened)
                return "";

            connectstr = string.Format("Server={0};DataBase={1};UID={2};PWD={3}", server, database, username, password);

            return OpenDB(connectstr);

        }


        /// <summary>
        /// 执行非查询，对于Update、Insert和Delete语句，返回值为该命令所影响的行数。
        /// 对于所有其他类型的语句，返回值为-1。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecNonQuery(string sql)
        {
            int recordsAffected = -1;
            try
            {
                IBM.Data.DB2.DB2Command command = new IBM.Data.DB2.DB2Command(sql, db2Conn);
                recordsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //使用日志，记录
                return recordsAffected;
            }
            return recordsAffected;
        }

        /// <summary>
        /// 2017-9-6 新增加读数据库，返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="errorinfo"></param>
        /// <returns></returns>
        public DataTable ReadData(string sql, out string errorinfo)
        {
            DataTable dt = null;
            try
            {
                IBM.Data.DB2.DB2Command command = new IBM.Data.DB2.DB2Command(sql, db2Conn);
                IBM.Data.DB2.DB2DataAdapter adapter = new IBM.Data.DB2.DB2DataAdapter(command);

                dt = new DataTable();

                //Fill函数种类很多，dataset，开始的记录数，结束的记录数
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                errorinfo = ex.Message;
                return null;
            }
            errorinfo = "";
            return dt;
        }


        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <returns></returns>
        public string CloseDB()
        {
            if (db2Conn != null)
            {
                try
                {
                    db2Conn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

    }

}
