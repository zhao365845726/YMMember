using LeaRun.Business;
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.MobileModule.Controller
{
    public class MemberController : PublicController<Base_Member>
    {
        //
        // GET: /MobileModule/Member/

        public ActionResult Index()
        {
            return View();
        }

    }
}
