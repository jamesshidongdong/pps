using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Always.IAM.MVC.Controllers;

namespace AlwaysPPS.Web.Controllers
{
    public class SessionController : BaseSessionController
    {
        public override string AuthCookiePostFix
        {
            get { return "-alwayspps"; }
        }

        public override int SessionTimeoutDuration
        {
            get { return 30; }
        }

        public override ActionResult LoginSuccess()
        {
            return RedirectToAction("Index", "Index");
        }

    }
}
