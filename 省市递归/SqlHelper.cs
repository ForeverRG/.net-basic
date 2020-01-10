using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 省市递归
{
    public static class SqlHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;

        /// <summary>
        /// 一般执行增删改
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="parameters">绑定的参数</param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
                {
                    if (parameters != null)
                    {
                        sqlComm.Parameters.AddRange(parameters);
                    }
                    sqlConn.Open();

                    return sqlComm.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 一般执行具有单个返回值的sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回获取的单个结果</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                using (SqlCommand sqlComm = new SqlCommand(sql,sqlConn))
                {
                    if (parameters != null)
                    {
                        sqlComm.Parameters.AddRange(parameters);
                    }
                    sqlConn.Open();

                    return sqlComm.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 一般执行查询结果集语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回reader对象</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            SqlConnection sqlConn = new SqlConnection(conStr);

            using (SqlCommand sqlComm = new SqlCommand(sql,sqlConn))
            {
                if (parameters != null)
                {
                    sqlComm.Parameters.AddRange(parameters);
                }
                //执行查询若出错则关闭连接资源并且抛异常，否则资源一直被占用
                try
                {
                    sqlConn.Open();
                    return sqlComm.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                    throw;
                }
            }
        }
    }
}
