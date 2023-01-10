using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    public class SaddleStrategyData
    {
        private Dictionary<string, SaddleStrategyType> dicSaddleType = new Dictionary<string, SaddleStrategyType>();
        public Dictionary<string, SaddleStrategyType> DicSaddleType
        {
            get { return dicSaddleType; }
            set { dicSaddleType = value; }
        }


        private List<SaddleStrategyType> listSaddleType = new List<SaddleStrategyType>();
        public List<SaddleStrategyType> ListSaddleType
        {
            get { return listSaddleType; }
            set { listSaddleType = value; }
        }


        private string bayNo;

        public string BayNo
        {
            get { return bayNo; }
            set { bayNo = value; }
        }
        

        public void GetSaddleStrategMessage()
        {
            string SQL = "select MAX(ID) AS ID, MAX(\"DESC\") AS \"DESC\", MAX(BAY_NO) AS BAY_NO , X_MIN, X_MAX,MAX( Y_MIN) AS Y_MIN ,min(Y_CENTER)Y_CENTER, ";
            SQL += " MAX(Y_MAX) AS Y_MAX , MAX(X_DIR) AS X_DIR, MAX(MIN_EMPTY_SADDLES) AS MIN_EMPTY_SADDLES  FROM YARD_TO_YARD_FIND_SADDLE_STRATEGY   ";
            SQL += " WHERE BAY_NO = '"  + BayNo  + "'  GROUP BY X_MIN, X_MAX  ";
            //string sql = string.Format("SELECT * FROM YARD_TO_YARD_FIND_SADDLE_STRATEGY where BAY_NO = '{0}' order by ID ", bayNo);
            try
            {
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(SQL))
                {
                    while (rdr.Read())
                    {
                        SaddleStrategyType theSaddleType= new SaddleStrategyType();
                        if (rdr["ID"] != DBNull.Value)
                            theSaddleType.Id = Convert.ToInt32(rdr["ID"]);
                        if (rdr["DESC"] != DBNull.Value)
                            theSaddleType.Desc = rdr["DESC"].ToString();
                        if (rdr["BAY_NO"] != DBNull.Value)
                            theSaddleType.BayNo = rdr["BAY_NO"].ToString();
                        if (rdr["X_MIN"] != DBNull.Value)
                            theSaddleType.XMin = Convert.ToInt32(rdr["X_MIN"]);
                        if (rdr["X_MAX"] != DBNull.Value)
                            theSaddleType.XMax = Convert.ToInt32(rdr["X_MAX"]);
                        if (rdr["Y_MIN"] != DBNull.Value)
                            theSaddleType.YMin = Convert.ToInt32(rdr["Y_MIN"]);
                        if (rdr["Y_MAX"] != DBNull.Value)
                            theSaddleType.YMax = Convert.ToInt32(rdr["Y_MAX"]);
                        if (rdr["X_DIR"] != DBNull.Value)
                            theSaddleType.XDir = rdr["X_DIR"].ToString();
                        if (rdr["Y_CENTER"] != DBNull.Value)
                            theSaddleType.YCenter = Convert.ToInt32(rdr["Y_CENTER"]);
                        if (rdr["MIN_EMPTY_SADDLES"] != DBNull.Value)
                            theSaddleType.MinEmptySaddle = Convert.ToInt32(rdr["MIN_EMPTY_SADDLES"]);
                        listSaddleType.Add(theSaddleType);
                    }
                }
            }
            catch (Exception er)
            {
                
            }
        }




    }
}
