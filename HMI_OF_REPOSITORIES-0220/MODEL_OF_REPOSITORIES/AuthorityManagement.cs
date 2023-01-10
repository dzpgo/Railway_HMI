using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baosight.iSuperframe.Authorization.Interface;
using Baosight.iSuperframe.Authorization;
using System.Windows;
using System.Windows.Forms;
using System.Data;
using Baosight.iSuperframe.Common;

namespace MODEL_OF_REPOSITORIES
{
    /// <summary>
    /// 权限管理
    /// </summary>
    public class AuthorityManagement
    {

        /// <summary>
        /// 判断当前登录用户与需要协调用户是否相同
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool isUserJudgeEqual(params string[] userName)
        {
            List<int> ruleList = new List<int>();
            bool flag = false;
            for (int i = 0; i < userName.Length; i++)
            {
                ruleList.Add(GetRuleID(userName[i]));
            }


            foreach (var item in GetListRuleID())
            {
                flag = ruleList.Contains(item);
                if (flag)
                {
                    return flag;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取登录用户名所有的角色id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        private List<int> GetListRuleID()
        {
            List<int> listRuleId = new List<int>();

         
            try
            {
                string cUserName = ((IAuthorization)FrameContext.Instance.GetPlugin<IAuthorization>()).GetUserName();      //操作人

                string sql = @"SELECT RULEID FROM T_RBAC_USERINRULE WHERE USERID = (SELECT USERID FROM T_RBAC_USER where USERNAME = '" + cUserName + "' ) ";
                using (IDataReader rdr = DB2Connect.DB0Helper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["RULEID"] != DBNull.Value)
                        {
                            listRuleId.Add(Convert.ToInt32(rdr["RULEID"]));
                        }                      
                    }
                }
            }
            catch (Exception er)
            {
               // MessageBox.Show(er.Message + "【所有角色】");
            }
            return listRuleId;
        }

        /// <summary>
        /// 获取特定角色id
        /// </summary>
        private int GetRuleID(string userName)
        {
            int ruleId = 999;
            try
            {
                string sql = @"SELECT RULEID FROM T_RBAC_RULE WHERE RULENAME = '" + userName + "'";
                using (IDataReader rdr = DB2Connect.DB0Helper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["RULEID"] != DBNull.Value)
                        {
                            ruleId = Convert.ToInt32(rdr["RULEID"]);
                        }                     
                    }
                }
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message + "【角色】");
            }
            return ruleId;
        }
    }
}
