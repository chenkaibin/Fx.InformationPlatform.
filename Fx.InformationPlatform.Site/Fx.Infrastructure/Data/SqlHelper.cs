using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Fx.Infrastructure.Data
{
    /// <summary>
    /// Ado.net Sql帮助类
    /// </summary>
    public class SqlHelper
    {
        private string connectString = null;
        /// <summary>
        /// 初始话连接字符串
        /// </summary>
        /// <param name="ConnString">连接字符串</param>
        public SqlHelper(string ConnString)
        {
            this.connectString = ConnString;
        }

        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <param name="strSql">sql</param>
        /// <returns>表信息</returns>
        public DataTable GetDt(string strSql)
        {
            if (ProcessSqlStr(strSql))
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = connectString;
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = strSql;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新 删除
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="isProc">是不是存储过程</param>
        /// <param name="pars">参数</param>
        /// <returns>影响了几行</returns>
        public int Execute(string strSql, bool isProc, SqlParameter[] pars)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connectString;
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = strSql;
            cmd.CommandType = isProc ? CommandType.StoredProcedure : CommandType.Text;
            if (pars != null)
            {
                foreach (SqlParameter p in pars)
                {
                    cmd.Parameters.Add(p);
                }
            }
            cn.Open();
            int rt = cmd.ExecuteNonQuery();
            cn.Close();
            return rt;
        }


        /// <summary>
        /// 处理Sql字符串，检查是否sql注入
        /// </summary>
        /// <param name="strSql">sql</param>
        /// <returns>是否sql注入</returns>
        private bool ProcessSqlStr(string strSql)
        {
            string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((strSql != null) && (strSql != String.Empty))
                {
                    string str_Regex = @"\b(" + SqlStr + @")\b";
                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    if (true == Regex.IsMatch(strSql))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// sql扩展类
    /// </summary>
    public static class Extend
    {
        /// <summary>
        /// 对like语句字符过滤
        /// </summary>
        /// <param name="Keyword">关键字</param>
        /// <returns>过滤后的关键字</returns>
        public static string EncodingKeyword(this string Keyword)
        {
            return Keyword.Replace("_", "[_]").Replace("%", "[%]");
        }

        /// <summary>
        /// 对sql语句进行注释符号过滤
        /// </summary>
        /// <param name="strSql">sql</param>
        /// <returns>过滤后的sql</returns>
        public static string EncodingString(this string strSql)
        {
            return strSql.Replace("'", "''").Replace("--", "");
        }
    }
}
