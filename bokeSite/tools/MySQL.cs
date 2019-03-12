using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.tools.MySql
{
    class MySqlHelpers
    {
        //从配置文件读取连接字符串

        private static readonly string connstr = new ConfigurationBuilder()
                   .AddInMemoryCollection()    //将配置文件的数据加载到内存中
                   .SetBasePath(Directory.GetCurrentDirectory())   //指定配置文件所在的目录
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)  //指定加载的配置文件
                   .Build()["mysql"];    //编译成对象  
                                         // private static readonly string connstr = config["mysql"];  //获取配置中的数据
                                         // config["mysql"] = "test test";   //修改配置对象的数据，配置对象的数据是可以被修改的
                                         // Console.WriteLine(config["test11"]);    //获取配置文件中不存在数据也是不会报错的
                                         //Console.WriteLine(config["theKey:nextKey"]);    //获取：theKey -> nextKey 的值

        //创建连接
        public static MySqlConnection CreateConnection()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(MySqlConnection conn, string sql, params MySqlParameter[] parameters)
        {
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 数据的插入与修改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = CreateConnection())
            {
                return ExecuteNonQuery(conn, sql, parameters);
            }
        }

        public static object ExecuteScalar(MySqlConnection conn, string sql, params MySqlParameter[] parameters)
        {
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = CreateConnection())
            {
                return ExecuteScalar(conn, sql, parameters);
            }
        }

        public static DataTable ExecuteQuery(MySqlConnection conn, string sql, MySqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                
                cmd.Parameters.AddRange(parameters);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        public static DataTable ExecuteQuery(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = CreateConnection())
            {
                return ExecuteQuery(conn, sql, parameters);
            }
        }
    }
}
