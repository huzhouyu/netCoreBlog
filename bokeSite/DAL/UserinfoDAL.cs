using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using bokeSite.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using bokeSite.tools.MySql;
using bokeSite.Models;
using bokeSite.tools.DataToEnity;

namespace bokeSite.DAL
{
    public class UserinfoDAL
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mySqlParameters"></param>
        /// <returns></returns>
        public DataTable testlogin(string sql,MySqlParameter[] mySqlParameters)
        {
          return MySqlHelpers.ExecuteQuery(sql,mySqlParameters) ;
           
        }
        /// <summary>
        /// 数据插入与修改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mySqlParameters"></param>
        /// <returns></returns>
        public int dataUapdatOrInsert(string sql,MySqlParameter[] mySqlParameters)
        {
            return MySqlHelpers.ExecuteNonQuery(sql, mySqlParameters);
        }
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public userinfo isHaveThisUserName(string UserName)
        {
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@username", UserName)};

            string sql= @"SELECT username,id,nicheng,zhuceshijian,xiugaishijian,touxiangurl FROM boke.userinfo where username=@username and isdel=0";

            DataTable dt=MySqlHelpers.ExecuteQuery(sql,mySqlParameter);
            if (dt.Rows.Count == 1)
            {
                return DataToEnity<userinfo>.DataRowToEntity(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据uif进行用户的注册
        /// </summary>
        /// <param name="uif"></param>
        /// <returns>是否注册成功</returns>
        public int register(userinfo uif)
        {

            if (isHaveThisUserName(uif.username) == null)
            {
                MySqlParameter[] mySqlParameter = { new MySqlParameter("@username", uif.username), new MySqlParameter("@pwd", uif.pwd), new MySqlParameter("@nicheng", uif.nicheng), new MySqlParameter("@touxiangurl", uif.touxiangurl) };
                string sql = @"insert into boke.userinfo values(@username,@pwd,null,@nicheng,now(),now(),@touxiangurl,0)";

                int Count = MySqlHelpers.ExecuteNonQuery(sql, mySqlParameter);
                return Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
