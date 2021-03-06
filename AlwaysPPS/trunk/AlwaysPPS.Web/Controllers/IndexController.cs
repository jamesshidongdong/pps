﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Always.IAM.AlwaysIAMSvc;
using AlwaysFramework.DAL;
using AlwaysPPS.Library;
using AlwaysPPS.Service;
using Microsoft.Practices.Unity;

namespace AlwaysPPS.Web.Controllers
{
    public class IndexController : BaseController
    {
        //
        // GET: /Index/
        //public void BindViewBag()
        //{
        //    ViewBag.UserName = User.UserName;
        //}

          private readonly IProjectService _projectService;
          private readonly ITResourceTeamService _iTResourceTeamService;
          private readonly IOaEmployeeService _IOaEmployeeService;
          private readonly OaDepartmentService _OaDepartmentService;
          public IndexController([Dependency(UnityIOC.UOF.AlwaysPPS)]IUnitOfWork unitOfWork
              , IProjectService projectService
              , ITResourceTeamService iTResourceTeamService
              , IOaEmployeeService iOaEmployeeService
              , OaDepartmentService oaDepartmentService)
            : base(unitOfWork)
        {
            _projectService = projectService;
              _iTResourceTeamService = iTResourceTeamService;
              _IOaEmployeeService = iOaEmployeeService;
              _OaDepartmentService = oaDepartmentService;
        }

        public ActionResult Index()
        {
            BindViewBagUser();
            var res = GetRole();
            if (res.Contains(1))
            {
                ViewBag.role = "1";
            }
            else if (res.Contains(2))
            {
                ViewBag.role = "2";
            }

            else if (res.Contains(3))
            {
                ViewBag.role = "3";
            }
            else
            {

                
                var oa = _IOaEmployeeService.GetByUid(User.UserId);
                if (oa != null)
                {
                    var result = _OaDepartmentService.GetByDepartmentID(oa.DepartmentId.Value);
                    if (result != null)
                    {
                        //是普通PM
                        if (result.DepartmentHeadUid != User.UserId)
                        {
                            //表示是PM
                            ViewBag.role = "4";
                        }
                        else
                        {
                            //表示是BuHeader
                            ViewBag.role = "5";
                        }
                    }
                }
            }


            return View();
        }
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        private List<int> GetRole()
        {
            List<int> res = new List<int>();
            var resList = _iTResourceTeamService.GetByUid(User.UserId);
            if (resList != null)
            {

                if (resList.Any())
                {
                    return resList.Select(u => u.RoleId).ToList();

                }
            }

            return res;
        }

        #region 待办事宜
        public ActionResult TodoProjects()
        {
            BindViewBagUser();
            return PartialView("TodoProjects");
        }
        public ActionResult GetTodoProjects()
        {
            var model = _projectService.GetToDoProjects(User.UserId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region 我的项目
        public ActionResult MyProject()
        {
            BindViewBagUser();
            return PartialView("MyProject");
        }
        public ActionResult GetMyProject()
        {
            var model = _projectService.GetMyProject(User.UserId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //关闭项目
        [HttpPost]
        public ActionResult CloseProject(int ProjectId)
        {
            bool res = false;
            try
            {
                res = _projectService.CloseProject(ProjectId);
                _unitOfWork.Save();
                if (res)
                {
                    return Json("toastr.success('成功');setTimeout(function() {location.reload();}, 300);");
                }
                else { return Json("toastr.error('失败');"); }

            }
            catch (Exception ex)
            {
                return Json("toastr.error('" + ex.Message + "');");
            }

        }

        //登出
        public ActionResult LogOut()
        {
            User.Logout();
            //kill current app's cookie
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName + "-alwayspps", "");
            faCookie.HttpOnly = true;
            faCookie.Expires = DateTime.Now.AddYears(-1);
            Response.SetCookie(faCookie);

            HttpCookie IamCookie = new HttpCookie(FormsAuthentication.FormsCookieName + "-portal", "");
            IamCookie.HttpOnly = true;
            IamCookie.Expires = DateTime.Now.AddYears(-1);
            Response.SetCookie(IamCookie);
            return Content("Errors - UnAuthorizedFromAttribute");
        }
    }
}
