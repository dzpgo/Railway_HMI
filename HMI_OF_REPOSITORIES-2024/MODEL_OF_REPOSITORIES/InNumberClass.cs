using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MODEL_OF_REPOSITORIES
{
    public class InNumberClass
    {
        /// <summary>
        /// 通过小区，查找和计算对应数据，返回一个实体类
        /// </summary>
        /// <param name="areaNO">小区</param>
        /// <returns></returns>
        public NumberBese GetNumberClass(string areaNO)
        {
            NumberBese numberBase = new NumberBese();

            try
            {
                string sql = @"select max(X_CENTER) as X_MAX,min(X_CENTER) as X_MIN,max(Y_CENTER) as Y_MAX from UACS_YARDMAP_SADDLE_DEFINE where SADDLE_NAME like '" + areaNO + "%' and X_CENTER != 999999";

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["X_MAX"] != System.DBNull.Value)
                        {
                            numberBase.X_Max = Convert.ToInt32(rdr["X_MAX"]);
                        }
                        if (rdr["X_MAX"] != System.DBNull.Value)
                        {
                            numberBase.X_Min = Convert.ToInt32(rdr["X_MIN"]);
                        }
                        if (rdr["X_MAX"] != System.DBNull.Value)
                        {
                            numberBase.Y_Max = Convert.ToInt32(rdr["Y_MAX"]);
                        }

                        numberBase.X_Width = numberBase.X_Max - numberBase.X_Min;

                        numberBase.X_Center = numberBase.X_Width / 2 + numberBase.X_Min;

                        numberBase.Y_Center = numberBase.Y_Max + 1700 ;

                        numberBase.Y_Height = 1400;

                    }
                }
            }
            catch (Exception er)
            {

                //throw;
            }

            return numberBase;

        }
        /// <summary>
        /// 通过小区号，获取行列编号，返回一个list
        /// </summary>
        /// <param name="areaNO">小区</param>
        /// <returns></returns>
        public List<int> GetAreaNoRow(string areaNO)
        {
            List<int> rowList = new List<int>{};
            string strRow;
            int intRow;
            try
            {
                string sql = string.Format("select COL_ROW_NO from UACS_YARDMAP_ROWCOL_DEFINE where AREA_NO like '{0}%'", areaNO);
                //string sql = @"select COL_ROW_NO from UACS_YARDMAP_ROWCOL_DEFINE where AREA_NO like '"+areaNO+"%' ";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["COL_ROW_NO"] != System.DBNull.Value)
                        {
                            strRow = rdr["COL_ROW_NO"].ToString();

                            intRow = Convert.ToInt32( strRow.Substring(8,3));

                            rowList.Add(intRow);
                        }
                        
                    }
                }
            }
            catch (Exception er)
            {
                
                throw;
            }
            return rowList;
        }

        /// <summary>
        /// 通过库位行号和编号，返回一个显示string
        /// </summary>
        /// <param name="list">int类型List</param>
        /// <param name="AreaNo">小区</param>
        /// <returns></returns>
        public string InListByLabel(List<int> list,string AreaNo)
        {
            StringBuilder stringBuilder = new StringBuilder(AreaNo);
            stringBuilder.Append("区  ");
            string strLabel = string.Empty;
            if (list.Count > 0)
            {
                ArrayList lists = new ArrayList(list);
                lists.Sort();
                int min = Convert.ToInt32(lists[0]);
                int max = Convert.ToInt32(lists[lists.Count - 1]);

                stringBuilder.Append(max);
                stringBuilder.Append("-");
                stringBuilder.Append(min);
                //strLabel = AreaNo+ "区   " + min + "-" + max;
                
            }
            strLabel = stringBuilder.ToString();

            return strLabel;
        }


        /// <summary>
        /// 通过跨号获取库区名称,返回list
        /// </summary>
        /// <param name="bayNO"></param>
        /// <returns></returns>
        public List<string> GetDataByList(string bayNO)
        {
            List<string> areaNoList = new List<string>();

            try
            {
                string sql = string.Format("select AREA_NO from UACS_YARDMAP_AREA_DEFINE where BAY_NO = '{0}' and AREA_TYPE = 0", bayNO);
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["AREA_NO"] != System.DBNull.Value)
                        {
                            areaNoList.Add(rdr["AREA_NO"].ToString());
                        }
                    }
                }
            }
            catch (Exception er)
            {
                
                throw ;
            }
            return areaNoList;
            
        }
      
    }
}
