-- MySQL dump 10.13  Distrib 5.7.21, for Win64 (x86_64)
--
-- Host: localhost    Database: boke
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `userinfo`
--

DROP TABLE IF EXISTS `userinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userinfo` (
  `username` varchar(20) DEFAULT NULL,
  `pwd` varchar(20) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nicheng` varchar(30) DEFAULT NULL,
  `zhuceshijian` datetime DEFAULT NULL,
  `xiugaishijian` datetime DEFAULT NULL,
  `touxiangurl` varchar(100) DEFAULT NULL,
  `isdel` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `userinfo_un` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userinfo`
--

LOCK TABLES `userinfo` WRITE;
/*!40000 ALTER TABLE `userinfo` DISABLE KEYS */;
INSERT INTO `userinfo` VALUES ('hufei','12345',0,'欠名',NULL,NULL,NULL,'\0'),('huzhouyu','12345',10,'胡周瑜',NULL,NULL,NULL,'\0'),('huzhouyu1','12345',11,'',NULL,NULL,NULL,'\0');
/*!40000 ALTER TABLE `userinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userwenzhang`
--

DROP TABLE IF EXISTS `userwenzhang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userwenzhang` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `leixing` int(11) DEFAULT NULL,
  `userid` int(11) DEFAULT NULL,
  `content` varchar(20000) DEFAULT NULL,
  `content100` varchar(1000) DEFAULT NULL,
  `zhuceshijian` datetime DEFAULT NULL,
  `xiugaishijian` datetime DEFAULT NULL,
  `dianjiliang` int(11) DEFAULT NULL,
  `wenzhangname` varchar(100) DEFAULT NULL,
  `iskejian` bit(1) DEFAULT NULL COMMENT '是否可见',
  `isdel` bit(1) DEFAULT NULL,
  `wenzhangurl` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=115 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userwenzhang`
--

LOCK TABLES `userwenzhang` WRITE;
/*!40000 ALTER TABLE `userwenzhang` DISABLE KEYS */;
INSERT INTO `userwenzhang` VALUES (111,1,10,'using System.IO;using System.Linq;using System.Threading.Tasks;using System.Text;namespace bokeSite.tools{    public class FileRW    {        /// <summary>        /// 修改测试2        /// </summary>        /// <param name=\"path\"></param>        /// <param name=\"content\"></param>        /// <param name=\"exists\"></param>        /// <returns></returns>        public static bool CreateHtml(string path,string content,bool exists=true)        {            try','using System.IO;using System.Linq;using System.Threading.Tasks;using System.Text;namespace bokeSite.tools{    public class FileRW    {        /// <summary>        /// 修改测试2        /// </summary>        /// <param name=\"path\"></param>        /// <param name=\"content\"></param>        /// <param name=\"exists\"></param>        /// <returns></returns>        public static bool CreateHtml(string path,str','2018-05-28 23:39:30','2018-05-29 01:41:09',0,'C#的爱','','\0','\\upload\\wenzhang\\20180529\\d6589c82-11cd-4269-87c8-55d79d9a52ef.html'),(112,1,10,'using System.IO;using System.Linq;using System.Threading.Tasks;using System.Text;namespace bokeSite.tools{    public class FileRW    {        /// <summary>        /// 写入文件        /// </summary>        /// <param name=\"path\"></param>        /// <param name=\"content\"></param>        /// <param name=\"exists\"></param>        /// <returns></returns>        public static bool CreateHtml(string path,string content,bool exists=true)        {            trytest','using System.IO;using System.Linq;using System.Threading.Tasks;using System.Text;namespace bokeSite.tools{    public class FileRW    {        /// <summary>        /// 写入文件        /// </summary>        /// <param name=\"path\"></param>        /// <param name=\"content\"></param>        /// <param name=\"exists\"></param>        /// <returns></returns>        public static bool CreateHtml(string path,stri','2018-05-28 23:44:26','2018-05-28 23:44:26',0,'wodewenzhang','','','\\upload\\wenzhang\\20180528\\689047c3-2502-47ab-83d5-234b7a940b50.html'),(113,1,10,'本教程教生成实时应用程序使用 ASP.NET Core SignalR 的基础知识。        SignalR在.net core2.1以前是需要下载 Microsoft.AspNetCore.SignalR 包。在.net core 2.1的时候sdk集成了这个包，所以就不要添加包，本文演示的也是基于.net core 2.1的，请确保你的sdk为2.1如果不是请安装.net core 2.1。        官方SDK下载地址为：https://www.microsoft.com/net/download/visual-studio-sdks。        完整程序代码：https://pan.baidu.com/s/1pYp9oxBaRmwoq8AAkpji1A        本教程演示SignalR以下内容：1、在 ASP.NET 核心 web 应用上创建 SignalR。2、创建一个 SignalR 集线器，以将内容推送到客户端。3、修改Startup类并将应用配置。必要条件：1、.NET 核心 2.1.0 预览 2 SDK或更高版本2、Visual Studio 2017 15.7 或使用更高版本ASP.NET 和 web 开发工作负荷或者Visual Studio Code（不推荐，不知道是插件安装不对吗,代码提示不智能）3、npm本文以Visual Studio 2017 开发工具讲解。创建 ASP.NET Core 项目承载 SignalR 客户端和服务器将类添加到项目中，通过选择文件 > 新建 > 文件并选择Visual C# 类。继承自Microsoft.AspNetCore.SignalR.Hub。 Hub类包含属性和管理连接和组，以及发送和接收数据的事件。创建SendMessage将消息发送到所有连接的聊天客户端的方法。 请注意它将返回任务，这是因为 SignalR 是异步的。 更好地缩放异步代码。using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;using Microsoft.AspNetCore.SignalR;namespace SignalRChat.Hubs{    public class ChatHub : Hub    {        /// <summary>        /// 建立连接时触发        /// </summary>        /// <returns></returns>        public override async Task OnConnectedAsync()        {                        await Clients.All.SendAsync(\"ReceiveMessage\", $\"{Context.ConnectionId} joined\");        }        /// <summary>        /// 离开连接时触发        /// </summary>        /// <param name=\"ex\"></param>        /// <returns></returns>        public override async Task OnDisconnectedAsync(Exception ex)        {                        await Clients.All.SendAsync(\"ReceiveMessage\", $\"{Context.ConnectionId} left\");        }        /// <summary>        /// 向所有人推送消息        /// </summary>        /// <param name=\"message\"></param>        /// <returns></returns>        public Task Send(string message)        {            return Clients.All.SendAsync(\"ReceiveMessage\", $\"{Context.ConnectionId}: {message}\");        }        /// <summary>        /// 向指定组推送消息        /// </summary>        /// <param name=\"groupName\"></param>        /// <param name=\"message\"></param>        /// <returns></returns>        public Task SendToGroup(string groupName, string message)        {            return Clients.Group(groupName).SendAsync(\"ReceiveMessage\", $\"{Context.ConnectionId}@{groupName}: {message}\");        }        /// <summary>        /// 加入指定组并向组推送消息        /// </summary>        /// <param name=\"groupName\"></param>        /// <returns></returns>        public async Task JoinGroup(string groupName)        {                        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);            await Clients.Group(groupName).SendAsync(\"ReceiveMessage\", $\"{Context.ConnectionId} joined {groupName}\");        }        /// <summary>        /// 推出指定组并向组推送消息        /// </summary>        /// <param name=\"groupName\"></param>        /// <returns></returns>        public async Task LeaveGroup(string groupName)        {            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);            await Clients.Group(groupName).SendAsync(\"ReceiveMessage\", $\"{Context.ConnectionId} left {groupName}\");        }    /// <summary>    /// 向指定Id推送消息    /// </summary>    /// <param name=\"userid\">要推送消息的对象</param>    /// <param name=\"message\"></param>    /// <returns></returns>        public Task Echo(string userid, string message)        {            return Clients.Client(Context.ConnectionId).SendAsync(\"ReceiveMessage\", $\"{Context.ConnectionId}: {message}\");        }        /// <summary>        /// 向所有人推送消息        /// </summary>        /// <param name=\"user\"></param>        /// <param name=\"message\"></param>        /// <returns></returns>        public async Task SendMessage(string user, string message)        {                       await Clients.All.SendAsync(\"ReceiveMessage\", Context.ConnectionId, message);                   }    }}　　配置项目以使用 SignalR必须配置 SignalR 服务器，这样就知道要传递给 SignalR 的请求。若要配置 SignalR 项目，请修改项目的Startup.ConfigureServices方法。services.AddSignalR 作为的一部分添加 SignalR中间件管道。配置路由到你使用的中心UseSignalR。 using Microsoft.AspNetCore.Builder;using Microsoft.AspNetCore.Hosting;using Microsoft.AspNetCore.Http;using Microsoft.Extensions.Configuration;using Microsoft.Extensions.DependencyInjection;using SignalRChat.Hubs;namespace SignalRChat{    public class Startup    {        public Startup(IConfiguration configuration)        {            Configuration = configuration;        }        public IConfiguration Configuration { get; }        public void ConfigureServices(IServiceCollection services)        {            services.Configure<CookiePolicyOptions>(options =>            {                options.CheckConsentNeeded = context => true;                options.MinimumSameSitePolicy = SameSiteMode.None;            });            services.AddMvc();            services.AddSignalR();        }        public void Configure(IApplicationBuilder app, IHostingEnvironment env)        {            if (env.IsDevelopment())            {                app.UseBrowserLink();                app.UseDeveloperExceptionPage();            }            else            {                app.UseExceptionHandler(\"/Error\");                app.UseHsts();            }            app.UseHttpsRedirection();            app.UseStaticFiles();            app.UseCookiePolicy();            app.UseSignalR(routes =>             {                routes.MapHub<ChatHub>(\"/chathub\");            });            app.UseMvc();                    }    }}创建 SignalR 客户端代码替换中的内容Pages\\Index.cshtml替换为以下代码：@page<div class=\"container\">    <div class=\"row\">&nbsp;</div>    <div class=\"row\">        <div class=\"col-6\">&nbsp;</div>        <div class=\"col-6\">            User..........<input type=\"text\" id=\"userInput\" />            <br />            Message...<input type=\"text\" id=\"messageInput\" />            <input type=\"button\" id=\"sendButton\" value=\"Send Message\" />        </div>    </div>    <div class=\"row\">        <div class=\"col-12\">            <hr />        </div>    </div>    <div class=\"row\">        <div class=\"col-6\">&nbsp;</div>        <div class=\"col-6\">            <ul id=\"messagesList\"></ul>        </div>    </div></div>[违规代码][违规代码] 前面的 HTML 显示名称和消息字段和提交按钮。 请注意在底部的脚本引用： 至于 SignalR在中运行以下命令程序包管理器控制台窗口，npm init -ynpm install @aspnet/signalr 请从项目根：复制signalr.js文件从node_modules\\ @aspnet\\signalr\\dist\\browser* 到lib*项目文件夹中的。运行应用Visual StudioVisual Studio Code选择调试 > 启动而不调试启动浏览器并加载网站本地。 从地址栏复制 URL。打开另一个浏览器实例 （任何浏览器），然后在地址栏中粘贴该 URL。选择任一浏览器，输入名称和消息，然后单击发送按钮。 名称和消息会显示在两个页面上立即。','本教程教生成实时应用程序使用 ASP.NET Core SignalR 的基础知识。        SignalR在.net core2.1以前是需要下载 Microsoft.AspNetCore.SignalR 包。在.net core 2.1的时候sdk集成了这个包，所以就不要添加包，本文演示的也是基于.net core 2.1的，请确保你的sdk为2.1如果不是请安装.net core 2.1。        官方SDK下载地址为：https://www.microsoft.com/net/download/visual-studio-sdks。        完整程序代码：https://pan.baidu.com/s/1pYp9oxBaRmwoq8AAkpji1A        本教程演示SignalR以下内容：1、在 ASP.NET 核心 web 应用上创建 SignalR。2','2018-05-30 19:49:15','2018-06-03 19:38:27',0,'.net core 2.1 以上SignalR实现','','\0','\\upload\\wenzhang\\20180603\\62a38a68-5d46-4ccc-9476-6e54208177d0.html'),(114,0,11,'fdsffdfdfafdfdf','fdsffdfdfafdfdf','2018-06-03 05:10:59','2018-06-03 05:10:59',0,'c#','','\0','\\upload\\wenzhang\\20180603\\5ad23dfb-3985-43e3-b2ee-809a341fe8e7.html');
/*!40000 ALTER TABLE `userwenzhang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userwenzhangleixing`
--

DROP TABLE IF EXISTS `userwenzhangleixing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userwenzhangleixing` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL,
  `leixingming` varchar(20) DEFAULT NULL,
  `zhuceshijian` datetime DEFAULT NULL,
  `xiugaishijian` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userwenzhangleixing`
--

LOCK TABLES `userwenzhangleixing` WRITE;
/*!40000 ALTER TABLE `userwenzhangleixing` DISABLE KEYS */;
INSERT INTO `userwenzhangleixing` VALUES (1,10,'C#',NULL,NULL),(2,10,'java','2018-05-26 17:35:52','2018-05-26 17:35:52'),(3,10,'python','2018-05-26 17:36:02','2018-05-26 17:36:02'),(4,10,'javascript','2018-05-26 17:36:16','2018-05-26 17:36:16'),(5,11,'c#','2018-06-03 05:11:17','2018-06-03 05:11:17');
/*!40000 ALTER TABLE `userwenzhangleixing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wenzhangpinglun`
--

DROP TABLE IF EXISTS `wenzhangpinglun`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wenzhangpinglun` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `wenzhangid` int(11) DEFAULT NULL,
  `pinglunneirong` varchar(4000) DEFAULT NULL,
  `pinglunrenid` int(11) DEFAULT NULL,
  `pinglunshijian` datetime DEFAULT NULL,
  `isdel` bit(1) DEFAULT NULL COMMENT '是否删除',
  `isread` bit(1) DEFAULT NULL COMMENT '是否读取',
  `dianzanshu` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=80 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wenzhangpinglun`
--

LOCK TABLES `wenzhangpinglun` WRITE;
/*!40000 ALTER TABLE `wenzhangpinglun` DISABLE KEYS */;
INSERT INTO `wenzhangpinglun` VALUES (1,111,'来自test',10,'2018-05-30 01:22:41','\0','',1),(2,111,'来自test',10,'2018-05-30 01:23:29','\0','',1),(3,111,'来自test',10,'2018-05-30 01:25:30','\0','',1),(4,111,'来自test',10,'2018-05-30 01:26:42','\0','',1),(5,111,'来自test',10,'2018-05-30 01:27:45','\0','',1),(6,111,'来自test',10,'2018-05-30 01:27:56','\0','',1),(7,111,'来自test',10,'2018-05-30 01:28:24','\0','',1),(8,111,'来自test',10,'2018-05-30 01:35:16','\0','',1),(9,111,'来自TEST',10,'2018-05-30 01:38:39','\0','',1),(10,111,'fdsf',10,'2018-05-30 01:42:20','\0','',1),(11,111,'fdsfdf',10,'2018-05-30 01:45:38','\0','',1),(12,111,'ceshi',10,'2018-05-30 01:47:13','\0','',1),(13,111,'1111111111111111111111111111111',10,'2018-05-30 01:52:55','\0','',1),(14,111,'1111111111111111111111111111111',10,'2018-05-30 01:53:20','\0','',1),(15,111,'1111111111111111111111111111111',10,'2018-05-30 01:56:13','\0','',1),(16,111,'1111111111111111111',10,'2018-05-30 01:56:27','\0','',1),(17,111,'1111111111111',10,'2018-05-30 02:01:13','\0','',1),(18,111,'2222222222',10,'2018-05-30 02:03:58','\0','',1),(19,111,'using System.IO;\r\nusing System.Linq;\r\nusing System.Threading.Tasks;\r\nusing System.Text;\r\nnamespace bokeSite.tools\r\n{\r\n    public class FileRW',10,'2018-05-30 02:05:01','\0','',1),(20,111,'using System.IO;\r\nusing System.Linq;\r\nusing System.Threading.Tasks;\r\nusing System.Text;\r\nnamespace bokeSite.tools\r\n{',10,'2018-05-30 02:07:33','\0','',1),(21,111,'using System.IO;\r\nusing System.Linq;\r\nusing System.Threading.Tasks;\r\nusing System.Text;\r\nnamespace bokeSite.tools\r\n{\r\n    public class FileRW\r\n    {\r\n        /// <summary>\r\n        /// 修改测试2\r\n        /// </summary>\r\n        /// <param name=\"path\"></param>\r\n        /// <param name=\"content\"></param>\r\n        /// <param name=\"exists\"></param>\r\n        /// <returns></returns>\r\n        public static bool CreateHtml(string path,string content,bool exists=true)\r\n        {\r\n            try',10,'2018-05-30 19:18:12','\0','',1),(22,111,'woshuo',10,'2018-05-30 20:22:43','\0','',1),(23,111,'22222222',10,'2018-05-30 20:31:19','\0','',1),(24,111,'11111111',10,'2018-05-30 20:33:25','\0','',1),(25,111,'11111111',10,'2018-05-30 20:38:47','\0','',1),(26,111,'3333333',10,'2018-05-30 20:39:57','\0','',1),(27,111,'22222222222',10,'2018-05-30 20:40:19','\0','',1),(28,111,'11111111111',10,'2018-05-30 20:40:48','\0','',1),(29,111,'22222',10,'2018-05-30 20:41:00','\0','',1),(30,111,'222222',10,'2018-05-30 20:42:27','\0','',1),(31,111,'3333333',10,'2018-05-30 20:46:28','\0','',1),(32,111,'2222222',10,'2018-05-30 20:48:18','\0','',1),(33,111,'2222222222222',10,'2018-05-30 20:49:20','\0','',1),(34,111,'3333333',10,'2018-05-30 20:51:59','\0','',1),(35,113,'你好呀',10,'2018-06-02 15:40:08','','',1),(36,113,'test',10,'2018-06-02 15:41:49','','',1),(37,113,'test',10,'2018-06-02 15:53:55','','',1),(38,113,'test',10,'2018-06-02 15:54:26','','',1),(39,113,'test',10,'2018-06-02 15:55:13','','',1),(40,113,'test',10,'2018-06-02 15:57:45','','',1),(41,113,'test',10,'2018-06-02 15:59:45','','',1),(42,113,'test',10,'2018-06-02 16:12:50','','',1),(43,113,'tswq',10,'2018-06-02 16:25:54','','',1),(44,113,'www',10,'2018-06-02 16:29:14','','',1),(45,113,'test',10,'2018-06-02 16:39:07','','',1),(46,113,'tes',10,'2018-06-02 16:45:29','','',1),(47,113,'test',10,'2018-06-02 16:46:21','','',1),(48,113,'钱钱钱钱钱钱',10,'2018-06-02 21:22:50','','',1),(49,113,'test',10,'2018-06-02 21:36:53','','',1),(50,113,'test',10,'2018-06-02 21:38:27','','',1),(51,113,'test',10,'2018-06-02 22:05:53','','',1),(52,113,'test',10,'2018-06-02 22:13:08','','',1),(53,113,'test',10,'2018-06-02 22:14:59','','',1),(54,113,'1111111',10,'2018-06-02 22:19:07','','',1),(55,113,'test',10,'2018-06-02 22:21:35','','',1),(56,113,'test',10,'2018-06-02 22:25:48','','',1),(57,113,'test',10,'2018-06-02 22:29:17','','',1),(58,113,'test',10,'2018-06-02 22:29:50','','',1),(59,113,'test',10,'2018-06-02 23:18:26','','',1),(60,113,'test',10,'2018-06-02 23:37:45','','',2),(61,113,'test',10,'2018-06-03 00:19:26','','',1),(62,113,'test',10,'2018-06-03 00:22:22','','',1),(63,113,'test',10,'2018-06-03 00:24:31','','',1),(64,113,'test',10,'2018-06-03 00:26:09','','',1),(65,113,'tess',10,'2018-06-03 00:29:01','','',1),(66,113,'test',10,'2018-06-03 00:30:05','','',1),(67,113,'testssst',10,'2018-06-03 00:36:02','','',1),(68,113,'tetst',10,'2018-06-03 00:40:34','','',2),(69,113,'tetst',10,'2018-06-03 01:39:59','','',1),(70,113,'test',10,'2018-06-03 02:27:55','','',1),(71,113,'111111111',10,'2018-06-03 04:54:46','','',1),(72,113,'热热他',10,'2018-06-03 05:01:50','','',2),(73,113,'test',10,'2018-06-03 05:06:32','','',1),(74,111,'terere',10,'2018-06-03 05:09:59','\0','',2),(75,111,'rerer',10,'2018-06-03 05:10:04','\0','',2),(76,114,'teset',11,'2018-06-03 05:11:38','\0','',1),(77,114,'sdfdsfdf',11,'2018-06-03 05:13:08','\0','',1),(78,114,'fdsfd',11,'2018-06-03 05:15:05','\0','',1),(79,113,'wwwww',10,'2018-06-03 23:13:16','\0','',1);
/*!40000 ALTER TABLE `wenzhangpinglun` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wenzhangpinglunson`
--

DROP TABLE IF EXISTS `wenzhangpinglunson`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wenzhangpinglunson` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pinglunid` int(11) DEFAULT NULL,
  `pinglunrenid` int(11) DEFAULT NULL,
  `pinglunneirong` varchar(1000) DEFAULT NULL,
  `isdel` bit(1) DEFAULT NULL,
  `isread` bit(1) DEFAULT NULL,
  `pinglunshijian` datetime DEFAULT NULL,
  `huifurenid` int(11) DEFAULT NULL,
  `dianzanshu` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wenzhangpinglunson`
--

LOCK TABLES `wenzhangpinglunson` WRITE;
/*!40000 ALTER TABLE `wenzhangpinglunson` DISABLE KEYS */;
INSERT INTO `wenzhangpinglunson` VALUES (1,NULL,NULL,NULL,'\0','','2018-06-02 17:03:10',NULL,NULL),(2,50,10,'11111111111','\0','','2018-06-02 21:38:37',10,1),(3,50,10,'222222222222222','\0','','2018-06-02 21:42:55',10,1),(4,51,10,'nihaoya','\0','','2018-06-02 22:06:17',10,1),(5,51,10,'haha','\0','','2018-06-02 22:07:47',10,1),(6,52,10,'test1','\0','','2018-06-02 22:13:14',10,1),(7,52,10,'test2','\0','','2018-06-02 22:13:21',10,1),(8,53,10,'test1','\0','','2018-06-02 22:15:08',10,1),(9,53,10,'test2','\0','','2018-06-02 22:15:13',10,1),(10,55,10,'test1','\0','','2018-06-02 22:21:39',10,1),(11,55,10,'test2','\0','','2018-06-02 22:21:54',10,1),(12,56,10,'test1','\0','','2018-06-02 22:25:54',10,1),(13,58,10,'tests','\0','','2018-06-02 22:29:55',10,1),(14,58,10,'test','\0','','2018-06-02 22:31:45',10,1),(15,59,10,'tea','\0','','2018-06-02 23:18:32',10,1),(16,59,10,'cat','','','2018-06-02 23:18:36',10,1),(17,60,10,'test','\0','','2018-06-02 23:38:15',10,1),(18,61,10,'tests','\0','','2018-06-03 00:19:38',10,1),(19,64,10,'test2','\0','','2018-06-03 00:26:49',10,1),(20,65,10,'tetet','\0','','2018-06-03 00:29:06',10,1),(21,66,10,'test','\0','','2018-06-03 00:30:10',10,1),(22,66,10,'testest','\0','','2018-06-03 00:30:14',10,1),(23,66,10,'11111111','\0','','2018-06-03 00:32:29',10,1),(24,66,10,'44444','\0','','2018-06-03 00:32:49',10,1),(25,66,10,'22222222','\0','','2018-06-03 00:34:28',10,1),(26,67,10,'tetete','\0','','2018-06-03 00:36:06',10,1),(27,67,10,'dfdsfdsf','\0','','2018-06-03 00:36:59',10,1),(28,68,10,'test','\0','','2018-06-03 00:40:38',10,2),(29,69,10,'tetst','\0','','2018-06-03 01:40:03',10,1),(30,69,10,'testet','\0','','2018-06-03 01:40:08',10,1),(31,70,10,'haha','\0','','2018-06-03 02:28:01',10,1),(32,70,10,'haha','\0','','2018-06-03 02:28:07',10,2),(33,71,10,'11111111','\0','','2018-06-03 04:54:56',10,2),(34,72,10,'惹人','','','2018-06-03 05:01:55',10,2),(35,73,10,'testet','','','2018-06-03 05:06:38',10,1),(36,73,10,'terere','\0','','2018-06-03 05:06:45',10,1),(37,74,10,'erer','\0','','2018-06-03 05:10:09',10,2),(38,75,10,'ererer','\0','','2018-06-03 05:10:15',10,2),(39,76,11,'fsdfsdf','\0','','2018-06-03 05:11:55',11,1),(40,76,11,'dfdsf','\0','','2018-06-03 05:12:37',11,1),(41,73,10,'来自胡周瑜的Test','\0','','2018-06-03 16:43:27',10,1),(42,66,10,'测试5','\0','','2018-06-03 17:09:46',10,1),(43,66,10,'测试6','\0','','2018-06-03 17:09:54',10,1),(44,64,10,'1','\0','','2018-06-03 18:23:46',10,1),(45,64,10,'2','\0','','2018-06-03 18:23:49',10,1),(46,64,10,'3','\0','','2018-06-03 18:23:54',10,1),(47,64,10,'4','\0','','2018-06-03 18:23:59',10,1),(48,64,10,'5','\0','','2018-06-03 18:24:05',10,1),(49,64,10,'6','\0','','2018-06-03 18:24:10',10,1),(50,79,10,'hhhhh','\0','','2018-06-03 23:13:25',10,1),(51,79,10,'hhhh','\0','','2018-06-03 23:13:33',10,2);
/*!40000 ALTER TABLE `wenzhangpinglunson` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-06 10:47:59
