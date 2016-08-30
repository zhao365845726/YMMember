using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.CustomerModule.Controllers
{
    /// <summary>
    /// 检查记录控制器
    /// </summary>
    public class InspectionRecordController : PublicController<Base_InspectionRecord>
    {
        //Base_InspectionRecord base_inspectionbll = new Base_InspectionRecord();

        //public ActionResult GridPageListJson(string keywords, string UserId, JqGridParam jqgridparam)
        //{
        //    try
        //    {
        //        Stopwatch watch = CommonHelper.TimerStart();
        //        DataTable ListData = base_inspectionbll.GetPageList(keywords, UserId, ref jqgridparam);
        //        var JsonData = new
        //        {
        //            total = jqgridparam.total,
        //            page = jqgridparam.page,
        //            records = jqgridparam.records,
        //            costtime = CommonHelper.TimerEnd(watch),
        //            rows = ListData,
        //        };
        //        return Json(JsonData, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message + "\r\n条件：" + ParameterJson);
        //        return null;
        //    }
        //}
    }
}