using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace MODEL_OF_REPOSITORIES
{
    /// <summary>
    /// 钢卷信息类
    /// </summary>
    public  class CoilMessage
    {
        /// <summary>
        /// 钢卷信息显示
        /// </summary>
        /// <param name="dgv">要显示的DataGridView</param>
        /// <param name="coilNo">钢卷号</param>
        public void GetCoilMessageByCoil(DataGridView dgv,string coilNo)
        {
            DataTable coilDt = new DataTable();
            bool hasSetColumn = false;
            try
            {
                string sql = @"SELECT  COIL_NO,WEIGHT,WIDTH,INDIA,OUTDIA,PACK_FLAG,SLEEVE_WIDTH,COIL_OPEN_DIRECTION,NEXT_UNIT_NO,STEEL_GRANDID,ACT_WEIGHT,ACT_WIDTH FROM UACS_YARDMAP_COIL  ";
                sql += " WHERE COIL_NO LIKE '" + coilNo + "%' ";

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = coilDt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                coilDt.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        coilDt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                //throw;
            }
            finally
            {
                if (!hasSetColumn)
                {
                     coilDt.Columns.Add("PLAN_TYPE", typeof(String));
                     coilDt.Columns.Add("PLAN_NO", typeof(String));
                     coilDt.Columns.Add("COIL_NO", typeof(String));
                     coilDt.Columns.Add("WEIGHT", typeof(String));
                     coilDt.Columns.Add("WIDTH", typeof(String));
                     coilDt.Columns.Add("INDIA", typeof(String));
                     coilDt.Columns.Add("OUTDIA", typeof(String));
                     coilDt.Columns.Add("PACK_FLAG", typeof(String));
                     coilDt.Columns.Add("SLEEVE_WIDTH", typeof(String));
                     coilDt.Columns.Add("COIL_OPEN_DIRECTION", typeof(String));
                     coilDt.Columns.Add("NEXT_UNIT_NO", typeof(String));
                     coilDt.Columns.Add("STEEL_GRANDID", typeof(String));
                     coilDt.Columns.Add("ACT_WEIGHT", typeof(String));
                     coilDt.Columns.Add("ACT_WIDTH", typeof(String));
                }


                dgv.DataSource = coilDt;
            }
        }
        public void GetCoilMessageByCoil(DataGridView dgv, string coilNo,string plantType)
        {
            DataTable coilDt = new DataTable();
            bool hasSetColumn = false;
            try
            {
                //string sql = @"SELECT  COIL_NO,WEIGHT,WIDTH,INDIA,OUTDIA,PACK_FLAG,SLEEVE_WIDTH,COIL_OPEN_DIRECTION,NEXT_UNIT_NO,STEEL_GRANDID,ACT_WEIGHT,ACT_WIDTH FROM UACS_YARDMAP_COIL  ";
                //sql += " WHERE COIL_NO LIKE '" + coilNo + "%' ";
                string sql = "";
                if (plantType=="入库") //入库
                {
                    sql = @"SELECT DECODE(B.PLAN_TYPE ,0,'出库',1,'入库') AS PLAN_TYPE1 ,A.REC_TIME AS REC_TIME1, '' AS PLAN_TYPE2, '' AS REC_TIME2,B.PLAN_NO, D.STOCK_NO, C.COIL_NO ,C.WEIGHT,C.WIDTH,C.INDIA,C.OUTDIA, C.PACK_FLAG, C.SLEEVE_WIDTH, ";
                    sql += " C.COIL_OPEN_DIRECTION, C.NEXT_UNIT_NO,STEEL_GRANDID, C.ACT_WEIGHT, C.ACT_WIDTH,G.LOGISTICS_FLAG FROM UACS_YARDMAP_COIL C ";
                    sql += " RIGHT JOIN UACS_PLAN_IN_DETAIL A ON A.MAT_NO = C.COIL_NO";
                    sql += " RIGHT JOIN UACS_PLAN_IN B ON B.PLAN_NO = A.PLAN_NO";
                    sql += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE D ON D.MAT_NO = C.COIL_NO ";
                    sql += "  LEFT JOIN UACS_LOGISTICS_CONFIG G ON A.HAVEN_CNAME = G.HAVEN_CNAME ";
                    sql += "  WHERE COIL_NO LIKE '%" + coilNo + "%' ";
                }
                else if(plantType=="出库")
                {
                    sql = @"SELECT DECODE(B.PLAN_TYPE ,0,'出库',1,'入库') AS PLAN_TYPE2 ,A.REC_TIME AS REC_TIME2,'' AS PLAN_TYPE1, '' AS REC_TIME1, B.PLAN_NO, C.COIL_NO ,D.STOCK_NO, C.WEIGHT,C.WIDTH,C.INDIA,C.OUTDIA, C.PACK_FLAG, C.SLEEVE_WIDTH, ";
                    sql += " C.COIL_OPEN_DIRECTION, C.NEXT_UNIT_NO,STEEL_GRANDID, C.ACT_WEIGHT, C.ACT_WIDTH,G.LOGISTICS_FLAG FROM UACS_YARDMAP_COIL C ";
                    sql += " RIGHT JOIN UACS_PLAN_OUT_DETAIL A ON A.MAT_NO = C.COIL_NO";
                    sql += " RIGHT JOIN UACS_PLAN_OUT B ON B.PLAN_NO = A.PLAN_NO";
                    sql += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE D ON D.MAT_NO = C.COIL_NO ";
                    sql += "  LEFT JOIN UACS_LOGISTICS_CONFIG G ON A.HAVEN_CNAME = G.HAVEN_CNAME";
                    sql += "  WHERE COIL_NO LIKE '%" + coilNo + "%' ";
                }
                else
                {
                    sql = @"SELECT DECODE(B.PLAN_TYPE ,0,'出库',1,'入库') AS PLAN_TYPE1 ,A.REC_TIME AS REC_TIME1, DECODE(E.PLAN_TYPE ,0,'出库',1,'入库') AS PLAN_TYPE2 ,D.REC_TIME AS REC_TIME2, B.PLAN_NO, C.COIL_NO, F.STOCK_NO, C.WEIGHT,C.WIDTH,C.INDIA,C.OUTDIA, C.PACK_FLAG, C.SLEEVE_WIDTH,  ";
                    sql += " C.COIL_OPEN_DIRECTION, C.NEXT_UNIT_NO,STEEL_GRANDID, C.ACT_WEIGHT, C.ACT_WIDTH,G.LOGISTICS_FLAG FROM UACS_YARDMAP_COIL C ";
                    sql += " LEFT JOIN UACS_PLAN_IN_DETAIL A ON A.MAT_NO = C.COIL_NO ";
                    sql += " LEFT JOIN UACS_PLAN_IN B ON B.PLAN_NO = A.PLAN_NO ";
                    sql += " LEFT JOIN UACS_PLAN_OUT_DETAIL D ON D.MAT_NO = C.COIL_NO ";
                    sql += " LEFT JOIN UACS_PLAN_OUT E ON E.PLAN_NO = D.PLAN_NO ";
                    sql += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE F ON F.MAT_NO = C.COIL_NO ";
                    sql += "  LEFT JOIN UACS_LOGISTICS_CONFIG G ON A.HAVEN_CNAME = G.HAVEN_CNAME";
                    sql += " WHERE COIL_NO LIKE'%" + coilNo + "%' ";
                }

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = coilDt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                coilDt.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        coilDt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                //throw;
            }
            finally
            {
                if (!hasSetColumn)
                {
                    coilDt.Columns.Add("COIL_NO", typeof(String));
                    coilDt.Columns.Add("WEIGHT", typeof(String));
                    coilDt.Columns.Add("WIDTH", typeof(String));
                    coilDt.Columns.Add("INDIA", typeof(String));
                    coilDt.Columns.Add("OUTDIA", typeof(String));
                    coilDt.Columns.Add("PACK_FLAG", typeof(String));
                    coilDt.Columns.Add("SLEEVE_WIDTH", typeof(String));
                    coilDt.Columns.Add("COIL_OPEN_DIRECTION", typeof(String));
                    coilDt.Columns.Add("NEXT_UNIT_NO", typeof(String));
                    coilDt.Columns.Add("STEEL_GRANDID", typeof(String));
                    coilDt.Columns.Add("ACT_WEIGHT", typeof(String));
                    coilDt.Columns.Add("ACT_WIDTH", typeof(String));
                }


                dgv.DataSource = coilDt;
            }
        }

        /// <summary>
        /// 根据钢卷号显示到Label
        /// </summary>
        /// <param name="label">显示的Label</param>
        /// <param name="coilNo">钢卷号</param>
        public void GetLabeTxtByCoil(Label label,string coilNo)
        {
            string stockNo = "";
            if (coilNo.Trim().Count() == 11)
            {
                try
                {
                    string sql = string.Format("SELECT STOCK_NO FROM UACS_YARDMAP_STOCK_DEFINE WHERE  MAT_NO = '{0}'",coilNo);
                    using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                    {
                        while (rdr.Read())
                        {
                            if (stockNo.Trim().Count() >= 10)
                            {
                                stockNo += "," + rdr["STOCK_NO"].ToString();
                            }
                            else
                            {
                                stockNo = rdr["STOCK_NO"].ToString();
                            }
                            
                        }
                    }


                    if (stockNo == "")
                    {
                        label.Text = coilNo + "没有库位";
                    }
                    else if (stockNo.Count() > 10)
                    {
                        label.Text = "警告！" + coilNo + "出现多库位" + stockNo;
                    }
                    else
                    {
                        label.Text = "库位号:："+stockNo;
                    }
                }
                catch (Exception er)
                {
                    label.Text = er.Message;
                }
            }
            else
                label.Text = "钢卷号不符合钢卷规则";
        }
    }
}
