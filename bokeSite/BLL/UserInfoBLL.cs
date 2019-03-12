using bokeSite.DAL;
using bokeSite.Models;
using bokeSite.tools.DataToEnity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.BLL
{
    public class UserInfoBLL
    {
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="UserName">要判断是否存在的用户名</param>
        /// <returns></returns>
        public bool isHaveThisUserName(string UserName)
        {
            UserinfoDAL BLL = new UserinfoDAL();
            userinfo uif=BLL.isHaveThisUserName(UserName);
            if (uif == null)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 根据用户名获取指定用户信息
        /// </summary>
        /// <param name="UserName">要判断是否存在的用户名</param>
        /// <returns></returns>
        public userinfo GetThisUserNameInfo(string UserName)
        {
            UserinfoDAL BLL = new UserinfoDAL();
            return BLL.isHaveThisUserName(UserName);
        }

        /// <summary>
        /// 通过用户id获得用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>

        public userinfo Getuserinfo(int userid)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@userid", userid) };

            var data = ud.testlogin(@"SELECT  username, id, nicheng FROM boke.userinfo where id=@userid and isdel=0", mySqlParameter);
            if (data.Rows.Count == 1)
            {
                return DataToEnity<userinfo>.DataRowToEntity(data.Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// 根据uif进行用户的注册
        /// </summary>
        /// <param name="uif"></param>
        /// <returns>是否注册成功</returns>
        public bool register(userinfo uif)
        {
            return new UserinfoDAL().register(uif) == 1;
        }


    }
}
