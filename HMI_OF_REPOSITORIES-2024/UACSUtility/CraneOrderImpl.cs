using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UACSUtility
{
    public class CraneOrderImpl
    {
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text


        /// <summary>
        /// 根据代码ID得到代码值
        /// </summary>
        /// <param name="codeId">代码ID</param>
        /// <param name="showAll">代码值中加“全部”</param>
        /// <returns>代码值</returns>
        public DataTable GetCodeValueByCodeId(string codeId,bool showAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            string sqlText = string.Format("SELECT CODE_VALUE_ID as TypeValue,CODE_VALUE_NAME as TypeName FROM UACS_CODE_VALUE WHERE CODE_ID = '{0}' ", codeId);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeValue"] = rdr["TypeValue"];
                    dr["TypeName"] = rdr["TypeName"];
                    dt.Rows.Add(dr);
                }
            }
            if (showAll)
            {
                dt.Rows.Add("全部","全部");
            }
            return dt;
        }

        /// <summary>
        /// 获取跨号
        /// </summary>
        /// <param name="showAll">代码值中加“全部”</param>
        /// <returns>代码值</returns>
        public DataTable GetBayNo(bool showAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            string sqlText = @"SELECT BAY_NO as TypeValue,BAY_NO as TypeName FROM UACS_YARDMAP_BAY_DEFINE ";
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeValue"] = rdr["TypeValue"];
                    dr["TypeName"] = rdr["TypeName"];
                    dt.Rows.Add(dr);
                }
            }
            if (showAll)
            {
                dt.Rows.Add("全部", "全部");
            }
            return dt;
        }

        /// <summary>
        /// 获取行车号
        /// </summary>
        /// <param name="showAll">代码值中加“全部”</param>
        /// <returns>代码值</returns>
        /// 
        public DataTable GetCraneNo(bool showAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据

            // string sqlText = @"SELECT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_CRANE  ";

            string sqlText =  @"SELECT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_CRANE  ";
         

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                   
                    if (rdr["TypeValue"].ToString().Count() == 1 )
                    {
                        DataRow dr = dt.NewRow();
                        dr["TypeValue"] = rdr["TypeValue"];
                        dr["TypeName"] = rdr["TypeName"];
                        dt.Rows.Add(dr);
                    }
                   
                }
            }
            if (showAll)
            {
                dt.Rows.Add("全部", "全部");
            }
            return dt;
        }
        public DataTable GetCraneNo(bool showAll ,int rule)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据

            // string sqlText = @"SELECT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_CRANE  ";
            string sqlText = string.Empty;

            //switch (rule)
            //{

            //    case 1:
            //        {
            //            sqlText = @" SELECT ID AS TypeValue, NAME AS TypeName FROM UACS_YARDMAP_CRANE 
            //                      WHERE YARD_NO = 'Z33' or YARD_NO = 'Z32' ";
            //            break;
            //        }
            //    case 2:
            //        {
            //            sqlText = @" SELECT ID AS TypeValue , NAME AS TypeName FROM UACS_YARDMAP_CRANE 
            //                         WHERE  YARD_NO='Z52' or  YARD_NO='Z53' or YARD_NO='Z54' ";
            //            break;
            //        }

            //    case 3:
            //        {
            //            sqlText = @"SELECT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_CRANE  ";
            //            break;
            //        }
            //    default: break;
            //}

            string sqlText1 = @" SELECT ID AS TypeValue, NAME AS TypeName FROM UACS_YARDMAP_CRANE 
                               WHERE YARD_NO = 'Z33' or YARD_NO = 'Z32' ";
            string sqlText2 = @" SELECT ID AS TypeValue , NAME AS TypeName FROM UACS_YARDMAP_CRANE 
                                    WHERE  YARD_NO='Z52' or  YARD_NO='Z53' or YARD_NO='Z54' ";
            string sqlText3 = @"SELECT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_CRANE  ";

            if ((string)RulesAssign.GetInstance().GetRuleItem(sqlText1, sqlText2, sqlText3) != "ERROR")
                sqlText = (string)RulesAssign.GetInstance().GetRuleItem(sqlText1, sqlText2, sqlText3);

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeValue"] = rdr["TypeValue"];
                    dr["TypeName"] = rdr["TypeName"];
                    dt.Rows.Add(dr);
                }
            }
            if (showAll)
            {
                dt.Rows.Add("全部", "全部");
            }
            return dt;
        }

        /// <summary>
        /// 根据代码ID得到代码值
        /// </summary>
        /// <param name="codeId">代码ID</param>
        /// <param name="showAll">代码值中加“全部”</param>
        /// <returns>代码值</returns>
        public Dictionary<string,string> GetCodeValueDicByCodeId(string codeId, bool showAll)
        {
            Dictionary<string, string> CodeValue = new Dictionary<string, string>();
            //准备数据
            string sqlText = string.Format("SELECT CODE_VALUE_ID as TypeValue,CODE_VALUE_NAME as TypeName FROM UACS_CODE_VALUE WHERE CODE_ID = '{0}' ", codeId);
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                while (rdr.Read())
                {
                    string value = rdr["TypeValue"].ToString();
                    string name = rdr["TypeName"].ToString();
                    CodeValue[value] = name;
                }
            }
            if (showAll)
            {
                CodeValue["全部"] = "全部";
            }
            return CodeValue;
        }
    }
}
