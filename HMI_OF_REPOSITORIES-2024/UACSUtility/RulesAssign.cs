using Baosight.iSuperframe.Authorization.Interface;
using Baosight.iSuperframe.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UACSUtility
{
    public class RulesAssign
    {
        static private int RULE_PROPERITY;

        static Baosight.iSuperframe.Common.IDBHelper DBHelper_Auth11 = null;

        static RulesAssign mpRulesAssign = null;
        static public RulesAssign GetInstance()
        {

            if (mpRulesAssign == null)
                mpRulesAssign = new RulesAssign();

            return mpRulesAssign;

        }

        RulesAssign()
        {
            DBHelper_Auth11 = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("UACSDB0"); // scheme AUTH11 
            GetUserGroup();
        }
        void GetUserGroup()
        {
            try
            {

                //distribute rule properity
                foreach (string str in GetRules())
                {
                    if (str == "Administrator")
                    {
                        RULE_PROPERITY = 3;
                        break;
                    }

                    if (str == "CPK")
                    {
                        RULE_PROPERITY = 2;
                        break;
                    }

                    if (str == "ZHK")
                    {
                        RULE_PROPERITY = 1;
                        break;
                    }
                    //  MessageBox.Show(str+" and count= "+ GetRules().Count);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        /// <summary>
        /// get  rule name from database
        /// </summary>
        /// <returns>rules name</returns>
        private List<string> GetRules()
        {
            List<string> rules = new List<string>();
            try
            {
                string userName = string.Empty;
                userName = ((IAuthorization)FrameContext.Instance.GetPlugin<IAuthorization>()).GetUserName(); //get current login user name 

                //string sql = @"SELECT USERID FROM T_RBAC_USER where USERNAME = '" + cUserName + "' ";
                string sqlRule = string.Format(@"SELECT distinct RULENAME FROM T_RBAC_RULE as rul ,
                                                 T_RBAC_USER as user , T_RBAC_USERINRULE as c
                                                 WHERE c.USERID = user.USERID and user.USERID = c.USERID 
                                                 AND rul.RULEID = c.RULEID AND user.USERNAME='{0}';", userName);

                using (IDataReader rdr = DBHelper_Auth11.ExecuteReader(sqlRule))
                {

                    while (rdr.Read())
                    {
                        rules.Add(rdr.GetString(0));
                    }
                }

            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
            }

            return rules;
        }

        /// <summary>
        /// 返回对应用户的item
        /// </summary>
        /// <param name="ZHK_Item">轧后库数据项</param>
        /// <param name="CPK_Item">成品库数据项</param>
        /// <param name="admin_Item">管理员数据项</param>
        /// <returns>返回对应权限的数据项，</returns>
        public object GetRuleItem(object ZHK_Item, object CPK_Item, object admin_Item)
        {
            try
            {
                if (ZHK_Item.GetType() != CPK_Item.GetType() || ZHK_Item.GetType() != admin_Item.GetType())
                    return "ERROR";

                object result = null;

                switch (RULE_PROPERITY)
                {

                    case 1:
                        {
                            result = ZHK_Item;
                            break;
                        }
                    case 2:
                        {
                            result = CPK_Item;
                            break;
                        }

                    case 3:
                        {
                            result = admin_Item;
                            break;
                        }
                    default: break;
                }

                return result;

            }
            catch (Exception ex)
            {
                return "ERROR";
                throw;
            }

        }


    }
}
