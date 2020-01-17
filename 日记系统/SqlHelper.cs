using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace 日记系统
{
    static class SqlHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;

        public static int ExecuteNoQuery(string sql, params SqlParameter[] parameters)
        {
            //创建连接对象
            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                //创建命令对象
                using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
                {
                    //判断传入参数是否为空
                    if (parameters != null)
                    {
                        //添加参数
                        sqlComm.Parameters.AddRange(parameters);

                    }
                    //打开数据库
                    sqlConn.Open();
                    //执行sql语句,返回影响行数
                    return sqlComm.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
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
                    return sqlComm.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            SqlConnection sqlConn = new SqlConnection(conStr);

            using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
            {
                if (parameters != null)
                {
                    sqlComm.Parameters.AddRange(parameters);
                }
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

        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                if (parameters != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                }
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
