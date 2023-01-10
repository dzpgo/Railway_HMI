using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    /// <summary>
    /// 平台数据连接
    /// </summary>
    public class DB2Connect
    {
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        public static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }
                }
                return dbHelper;
            }
        }


        private static Baosight.iSuperframe.Common.IDBHelper db0Helper = null;
        //连接数据库
        public static Baosight.iSuperframe.Common.IDBHelper DB0Helper
        {
            get
            {
                if (db0Helper == null)
                {
                    try
                    {
                        db0Helper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("UACSDB0");//平台连接数据库的Text
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }
                }
                return db0Helper;
            }
        }

    }
}
