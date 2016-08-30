using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.MobileModule
{
    public class MobileModuleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MobileModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                this.AreaName + "_Default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { area = this.AreaName, controller = "Member", action = "Index", id = UrlParameter.Optional },
                new string[] { "LeaRun.WebApp.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}