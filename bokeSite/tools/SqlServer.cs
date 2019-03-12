using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.tools.SqlServer
{
    public class SqlHelper
    {
        /// <summary>
        /// 获取链接字符串
        /// </summary>
        private static readonly string connStr = new ConfigurationBuilder()
                 .AddInMemoryCollection()    //将配置文件的数据加载到内存中
                 .SetBasePath(Directory.GetCurrentDirectory())   //指定配置文件所在的目录
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)  //指定加载的配置文件
                 .Build()["mysql"];    //编译成对象  
                                       // private static readonly string connstr = config["mysql"];  //获取配置中的数据
                                       // config["mysql"] = "test test";   //修改配置对象的数据，配置对象的数据是可以被修改的
                                       // Console.WriteLine(config["test11"]);    //获取配置文件中不存在数据也是不会报错的
                                       //Console.WriteLine(config["theKey:nextKey"]);    //获取：theKey -> nextKey 的值


        /// <summary>
        /// 删掉文件
        /// </summary>
        /// <param name="wenjianwulilujing">物理路径</param>
        /// <param name="fileUrl">相对路径</param>

        public static void DeleteImgFile(string fileUrl)
        {
            fileUrl = AppDomain.CurrentDomain.BaseDirectory + fileUrl;
            string[] allowExtn = { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
            //对上传的文件的类型进行一个个匹对   
            int index = fileUrl.IndexOf('.');
            bool fileOk = false;
            if (index != -1)
            {
                string exName = fileUrl.Substring(index);
                for (int i = 0; i < allowExtn.Length; i++)
                {
                    if (exName == allowExtn[i])
                    {
                        fileOk = true;
                        break;
                    }
                }
            }
            if (System.IO.File.Exists(fileUrl) && fileOk)
            {
                System.IO.File.Delete(fileUrl);
            }
        }




        /// <summary>
        /// 执行查询操作 
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="type">CommandType 命令的类型【text=>sql 脚本,StoredProcedure=>存储过程】</param>
        /// <param name="pars">参数</param>
        /// <returns>返回结果集 dataset</returns>
        public static DataSet GetDataSet(string sql, CommandType type, params SqlParameter[] pars)
        {
            //1.创建链接
            SqlConnection conn = new SqlConnection(connStr);
            //2.打开链接
            conn.Open();
            //3.创建命令对象
            SqlCommand cmd = new SqlCommand(sql, conn);
            //4.创建 适配器
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // 当传入的参数不为空时，直接添加到Cmd 对象的Parameters 属性上
            if (pars != null)
            {
                foreach (var item in pars)
                {
                    item.Value = item.Value == null ? DBNull.Value : item.Value;
                    cmd.Parameters.Add(item);
                }
                //cmd.Parameters.AddRange(pars);
            }
            //根据 使用者 传入的命令类型，给 Cmd 对象的CommandType 属性赋值；
            cmd.CommandType = type;
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch
            {

            }
            //关闭链接
            conn.Close();
            return ds;
        }


        /// <summary>
        /// 执行SQL语句：返回 影响行数
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="type">CommandType 命令的类型【text=>sql 脚本,StoredProcedure=>存储过程】</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        public static int ExecuteNonquery(string sql, CommandType type, params SqlParameter[] pars)
        {
            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        foreach (var item in pars)
                        {
                            item.Value = item.Value == null ? DBNull.Value : item.Value;
                            cmd.Parameters.Add(item);
                        }
                        //cmd.Parameters.AddRange(pars);

                    }
                    cmd.CommandType = type;
                    conn.Open();
                    int cc = 0;
                    try
                    {
                        cc = cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        cc = 0;
                    }
                    return cc;
                }
            }
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        //cmd.Parameters.AddRange(pars);
                        foreach (var item in pars)
                        {
                            item.Value = item.Value == null ? DBNull.Value : item.Value;
                            cmd.Parameters.Add(item);
                        }
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
