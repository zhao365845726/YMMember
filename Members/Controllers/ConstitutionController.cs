using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMDLL.Class;

namespace Members.Controllers
{
    public class ConstitutionController : Controller
    {
        YM_SQLServer _sqlserver = new YM_SQLServer();

        // GET: Constitution
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 调理请求的页面
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public RedirectToRouteResult Index(FormCollection form)
        {
            string strId = Guid.NewGuid().ToString();
            string strUserName = form["txtUserName"];
            string strTel = form["txtTel"];
            
            string strCreateTime = DateTime.Now.ToString();
            string strUpdateTime = DateTime.Now.ToString();
            string strResult = form["txtResult"];

            _sqlserver.dbInitialization(ReadAppSetting("DBServer"), ReadAppSetting("DBName"),ReadAppSetting("DBUsername"),ReadAppSetting("DBPassword"));
            string strSQL = "INSERT INTO Base_Physique(id,name,tel,result,createtime,updatetime) VALUES('" +
                    strId + "','" + strUserName + "','" + strTel + "','" + strResult + "','" +
                    strCreateTime + "','" + strUpdateTime + "')";

            bool isExec = _sqlserver.dbExec(strSQL);

            if (isExec)
            {
                TempData["msg"] = "数据写入成功:\n" + strUserName + "\n" + strTel + "\n" + strSQL + "\n" + isExec.ToString();
                return RedirectToAction("Result","Constitution");
            }
            else
            {
                TempData["msg"] = "数据写入失败" + strUserName + "\n" + strTel + "\n" + strSQL + "\n" + isExec.ToString();
                return RedirectToAction("Index", "Constitution");
            }
        }

        /// <summary>
        /// 显示检测的结果
        /// </summary>
        /// <returns></returns>
        public ActionResult Result()
        {
            //TempData["result"] = "还不赖";
            return View();
        }

        /// <summary>
        /// 读取设置
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string ReadAppSetting(string strKey)
        {
            return ConfigurationManager.AppSettings[strKey].ToString(); 
        }
    }
}