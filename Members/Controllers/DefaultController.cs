using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using YMDLL.Class;

namespace Members.Controllers
{
    public class DefaultController : Controller
    {
        YM_SQLServer _sqlserver = new YM_SQLServer();
        // GET: Default
        public ActionResult Index()
        {
            RouteValueDictionary get_route = new RouteValueDictionary(RouteData.Values);
            string strID = Convert.ToString(get_route["ID"]);
            _sqlserver.dbInitialization(ReadAppSetting("DBServer"), ReadAppSetting("DBName"), ReadAppSetting("DBUsername"), ReadAppSetting("DBPassword"));
            string strSQL = "select * from Base_Member where ID = '" + strID + "'";
            DataSet ds = _sqlserver.dbReadData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    TempData["Name"] = row["Name"];
                    if(row["Sex"].ToString() == "0")
                    {
                        TempData["Sex"] = "女";
                    }
                    else if(row["Sex"].ToString() == "1")
                    {
                        TempData["Sex"] = "男";
                    }
                    TempData["Age"] = row["Age"];
                    TempData["Disease"] = row["Disease"];
                    TempData["SubHealth"] = row["SubHealth"];
                    TempData["GroupNumber"] = row["GroupNumber"];
                }
            }

            TempData["ID"] = strID;
            return View();
        }

        /// <summary>
        /// 完善信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            RouteValueDictionary get_route = new RouteValueDictionary(RouteData.Values);
            string strID = Convert.ToString(get_route["ID"]);

            TempData["ID"] = strID;
            return View();
        }

        /// <summary>
        /// 诊断记录
        /// </summary>
        /// <returns></returns>
        public ActionResult InspectionList()
        {
            RouteValueDictionary get_route = new RouteValueDictionary(RouteData.Values);
            string strID = Convert.ToString(get_route["ID"]);
            //_sqlserver.dbInitialization(ReadAppSetting("DBServer"), ReadAppSetting("DBName"), ReadAppSetting("DBUsername"), ReadAppSetting("DBPassword"));
            //string strSQL = "select ID,BloodPressure,BloodSugar,BloodFat,RoutineBloodTest,UrineRoutine,BloodType,LiverFunction,RenalFunction,AbdomenUltrasonography,Electrocardiogram,TraceElement,Enclosure,CreateTime from Base_InspectionRecord where ID = '" + strID + "' order by CreateTime DESC";
            //DataSet ds = _sqlserver.dbReadData(strSQL);

            TempData["ID"] = strID;
            //Json(ds, JsonRequestBehavior.AllowGet);
            return View();
        }

        /// <summary>
        /// 诊断结果
        /// </summary>
        /// <returns></returns>
        public JsonResult InspectionResult()
        {
            RouteValueDictionary get_route = new RouteValueDictionary(RouteData.Values);
            string strID = Convert.ToString(get_route["ID"]);
            _sqlserver.dbInitialization(ReadAppSetting("DBServer"), ReadAppSetting("DBName"), ReadAppSetting("DBUsername"), ReadAppSetting("DBPassword"));
            string strSQL = "select ID,BloodPressure,BloodSugar,BloodFat,RoutineBloodTest,UrineRoutine,BloodType,LiverFunction,RenalFunction,AbdomenUltrasonography,Electrocardiogram,TraceElement,Enclosure,CreateTime from Base_InspectionRecord where ID = '" + strID + "' order by CreateTime DESC";
            DataSet ds = _sqlserver.dbReadData(strSQL);
            return Json(ds,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 诊断详情
        /// </summary>
        /// <returns></returns>
        public ActionResult InspectionDetail()
        {
            return View();
        }

        /// <summary>
        /// 调理记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ConditionList()
        {
            RouteValueDictionary get_route = new RouteValueDictionary(RouteData.Values);
            string strID = Convert.ToString(get_route["ID"]);

            TempData["ID"] = strID;
            return View();
        }

        /// <summary>
        /// 调理详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ConditionDetail()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Login(FormCollection form)
        {
            string strTel = form["InputTel"];
            string strPwd = form["InputPassword"];
            _sqlserver.dbInitialization(ReadAppSetting("DBServer"), ReadAppSetting("DBName"), ReadAppSetting("DBUsername"), ReadAppSetting("DBPassword"));
            string strSQL = "select ID from Base_Member where Tel = '" + strTel + "' and Password = '" + strPwd + "'";
            DataSet ds = _sqlserver.dbReadData(strSQL);
            if(ds.Tables[0].Rows.Count > 0)
            {
                TempData["msg"] = "获取参数成功：\n" + strTel + "\n" + strPwd + "\n" + ds.Tables[0].Rows[0]["ID"].ToString();
                return RedirectToAction("Index", "Default",new {ID = ds.Tables[0].Rows[0]["ID"].ToString() });
            }
            else
            {
                return RedirectToAction("Login", "Default");
            }
        }

        /// <summary>
        /// 登陆页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPwd()
        {
            RouteValueDictionary get_route = new RouteValueDictionary(RouteData.Values);
            string strID = Convert.ToString(get_route["ID"]);
            TempData["ResetID"] = strID;
            return View();
        }

        /// <summary>
        /// 重置密码提交表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public RedirectToRouteResult ResetPwd(FormCollection form)
        {
            string strNewPwd = form["NewPassword"];
            string strID = form["ResetId"];
            _sqlserver.dbInitialization(ReadAppSetting("DBServer"), ReadAppSetting("DBName"), ReadAppSetting("DBUsername"), ReadAppSetting("DBPassword"));
            string strSQL = "Update Base_Member SET Password = '" + strNewPwd + "' where ID = '" + strID + "'";
            bool isExec = _sqlserver.dbExec(strSQL);
            if (isExec)
            {
                TempData["ResetMsg"] = "密码修改成功";
            }
            else
            {
                TempData["ResetMsg"] = "密码修改失败";
            }

            return RedirectToAction("ResetPwd", "Default");
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