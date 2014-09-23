using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Always.IAM.MVC.Controllers;

namespace AlwaysPPS.Web.Controllers
{
    public class ErrorsController : Controller, IErrorsController
    {
        public ActionResult NotFound()
        {
            //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Error Page Not Found"));
            //todo: add view
            //return View();
            return Content("Errors - Page Not Found");
        }

        public ActionResult Error500()
        {
            //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Error 500"));
            //todo: add view
            //return View();
            return Content("Errors - Error 500");
        }

        public ActionResult UnAuthorized()
        {
            //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Error UnAuthorized"));
            //todo: add view
            //return View();
            return Content("Errors - UnAuthorized");
            //return RedirectToAction("Index", "Home");
        }

        public ActionResult UnAuthorizedFromAttribute()
        {
            //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Error UnAuthorizedFromAttribute"));
            //todo: add view
            //return View();
            return Content("Errors - UnAuthorizedFromAttribute");
            //return RedirectToAction("Index", "Home");
        }
    }
}
