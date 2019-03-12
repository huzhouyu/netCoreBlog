using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;

namespace bokeSite.tools
{
    public class FileRW
    {
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="exists"></param>
        /// <returns></returns>
        public static bool CreateHtml(string path,string content,bool exists=true)
        {
            try
            { 
            path = path.Replace("\\", "/");
                content = Html2Text(content);
                if (!File.Exists(path)&&exists)
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, content);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string readHtml(string path)
        {
            var tmppath = ("wwwroot" + path).Replace("\\", "/");

                if (File.Exists(tmppath) )
                return File.ReadAllText(tmppath);

                return null;

        }
        /// <summary>
        /// 过滤JS代码
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public static string Html2Text(string htmlStr)
        {
            if (String.IsNullOrEmpty(htmlStr))

            {
                return "";
            }
            string regEx_script = "<script[^>]*?>[\\s\\S]*?<\\/script>";  //定义script的正则表达式  
            htmlStr = Regex.Replace(htmlStr, regEx_script, "[违规代码]"); //删除js
            return htmlStr.Trim();

        }

    }
}
