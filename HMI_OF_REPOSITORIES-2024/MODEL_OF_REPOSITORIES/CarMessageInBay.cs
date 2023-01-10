using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace MODEL_OF_REPOSITORIES
{
   
    public class CarMessageInBay
    {
        private  int SaddleNum;
        private Dictionary<int, int> dicCenter = new Dictionary<int, int>();
        public CarMessageBase GetCarMessage(string bay)
        {
            CarMessageBase carMessage = null;
            isCarSaddle(bay,out SaddleNum);
            if (SaddleNum > 0 && SaddleNum < 9)  
            {
                List<int> list = GetXCenter(bay) as List<int>;
                if (list.Count > 0)
                {
                    carMessage = new CarMessageBase();
                    ArrayList lists = new ArrayList(list);
                    lists.Sort();
                    int y_min = Convert.ToInt32(lists[0]);
                    int y_max = Convert.ToInt32(lists[lists.Count - 1]);
                    carMessage.CarLength = y_max - y_min + 2000;
                    carMessage.CarWidth = 3000;
                    carMessage.Y_Center = (y_min - 1000) + (carMessage.CarLength / 2);
                    carMessage.X_Center = dicCenter[y_min];
                   
                }
            }
            return carMessage;
        }




        private void isCarSaddle(string bay, out int saddleNum)
        {

            int num = 0;
            try
            {
                string sql = "select count(*) as num from UACS_YARDMAP_SADDLE_DEFINE where SADDLE_NO  like  '"+bay+"A%' and X_CENTER > 0 ";

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                        {
                            num = Convert.ToInt32(rdr["num"]);
                        }
                       
                    }
                }
       
            }
            catch (Exception er)
            {
                saddleNum = 0;
            }
            saddleNum = num;
        }


        /// <summary>
        /// 查询Y中心点
        /// </summary>
        /// <param name="bay"></param>
        /// <returns></returns>
        private List<int> GetXCenter(string bay)
        {
            List<int> list = new List<int>();
            try
            {
                string sql = "select Y_CENTER,X_CENTER from UACS_YARDMAP_SADDLE_DEFINE where SADDLE_NO  like  '" + bay + "A%' and X_CENTER > 0 ";

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["Y_CENTER"] != DBNull.Value)
                        {
                            list.Add(Convert.ToInt32( rdr["Y_CENTER"]));
                            dicCenter.Add(Convert.ToInt32(rdr["Y_CENTER"]), Convert.ToInt32(rdr["X_CENTER"]));
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return list;
        }
    }
}
