using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Always.IAM.MVC;
using AlwaysFramework.MVC.Filter;
using AlwaysPPS.Web.App_Start;
using System.Configuration;
using AlwaysPPS.Web.Controllers;

namespace AlwaysPPS.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : BaseGlobalApplication
    {
        public override string AuthCookiePostFix
        {
            get { return "-alwayspps"; }
        }

        public override int SessionTimeoutDuration
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeoutDuration"]); }
        }

        public override IController ApplicationErrorController
        {
            get { return new ErrorsController(); }
        }
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Clears all previously registered view engines.
            ViewEngines.Engines.Clear();
            // Registers our Razor C# specific view engine.
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        protected void Application_PreSendRequestHeaders()
        {
            /*Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
            Response.Headers.Remove("X-Powered-By");*/

            Response.AddHeader("X-UA-Compatible", "IE=edge");
        }
    }
}