using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 字符串有关的工具类
/// @author 徐长盛  2017-9-7
/// </summary>
/// 
namespace UACSUtility
{
    public class StringUtility
    {
        /// <summary>
        /// 让str的首字母变为大些
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length == 0)//空字符串
                return str;
            else if (str.Length == 1)
                return str.ToUpper();
            else
                return str.Substring(0, 1).ToUpper() + str.Substring(1);

        }

        /// <summary>
        /// 将字符串中的某个子串替换为新值，未找到则不替换
        /// </summary>
        /// <param name="str"></param>
        /// <param name="oldstr"></param>
        /// <param name="newstr"></param>
        /// <returns></returns>
        public static string RelaceString(string str,string oldstr,string newstr)
        {

            return str;

        }
    }

}
