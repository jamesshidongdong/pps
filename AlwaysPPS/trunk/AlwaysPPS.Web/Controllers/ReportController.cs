﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AlwaysFramework.DAL;
using AlwaysFramework.MVC;
using AlwaysFramework.MVC.Extension;
using AlwaysPPS.Entity;
using AlwaysPPS.Entity.Common;
using AlwaysPPS.Entity.FormatMODEL;
using AlwaysPPS.Entity.StoredProcedure;
using AlwaysPPS.Library;
using AlwaysPPS.Library.Constant;
using AlwaysPPS.Service;
using AlwaysPPS.Entity.ViewModel;
using Elmah.ContentSyndication;
using Kendo.Mvc.Extensions;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;

namespace AlwaysPPS.Web.Controllers
{
    public class ReportController : BaseController
    {
        //
        // GET: /Report/
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITResourceTeamService _iTResourceTeamService;
        private readonly ICtProjectTypeService _ICtProjectTypeService;
        private readonly IProjectService _IProjectService;
        private readonly IOaEmployeeService _IOaEmployeeService;
        private readonly OaDepartmentService _OaDepartmentService;
        private readonly ITProjectTaskService _ITProjectTaskService;
        private readonly ICtTeamService _ICtTeamService;
        private readonly ITTimesheetService _ITTimesheetService;
        private readonly IProjectWorkPlanService _IProjectWorkPlanService;

        public ReportController(
            [Dependency(UnityIOC.UOF.AlwaysPPS)] IUnitOfWork unitOfWork
            , ITResourceTeamService iTResourceTeamService
            , ICtProjectTypeService iCtProjectTypeService
            , IProjectService iProjectService
            , IOaEmployeeService iOaEmployeeService
            , OaDepartmentService oaDepartmentService
            , ITProjectTaskService _iTProjectTaskService
            , ICtTeamService iCtTeamService
            , ITTimesheetService iTTimesheetService
            , IProjectWorkPlanService iProjectWorkPlanService)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _iTResourceTeamService = iTResourceTeamService;

            _ICtProjectTypeService = iCtProjectTypeService;
            _IProjectService = iProjectService;
            _IOaEmployeeService = iOaEmployeeService;
            _OaDepartmentService = oaDepartmentService;
            this._ITProjectTaskService = _iTProjectTaskService;
            _ICtTeamService = iCtTeamService;
            _ITTimesheetService = iTTimesheetService;
            this._IProjectWorkPlanService = iProjectWorkPlanService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public bool IsCanEdit(int projId)
        {
            var res = _IProjectService.GetByID(projId);
            if (res != null)
            {
                if (res.State == DataStatus.ProjectState.closed)
                {
                    return false;
                }
            }
            return _iTResourceTeamService.IsCanEdit(GetCureentID(), projId);
        }



        /// <summary>
        ///  get currentuserid if buheader get treaffic id  else cureent id
        /// </summary>
        /// <returns></returns>
        private int GetCureentID()
        {
            int userids = -1;
            var ints = CurrentUserDepartmentTrafficeLeaderId();
            if (ints == -1)
            {
                userids = User.UserId;
            }
            else
            {
                userids = ints;
            }
            return userids;

        }


        #region 1.0 根据权限生成 不同的菜单 + ActionResult GetMenu()

        /// <summary>
        /// 根据权限生成 不同的菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMenu()
        {
            StringBuilder sbMuen = new StringBuilder(1000);
            var oa = _IOaEmployeeService.GetByUid(GetCureentID());
            if (GetRole().Any() == false)
            {

            
                if (oa != null)
                {
                    var res = _OaDepartmentService.GetByDepartmentID(oa.DepartmentId.Value);
                    if (res != null)
                    {
                        //是普通PM
                        if (res.DepartmentHeadUid != User.UserId)
                        {
                            sbMuen.Append(
                                "<li class='openable'><a href='/Index/Index'><span class='icons-home iconL'></span><span class='text'>首页</span></a></li><li class='openable'><a href='/Report/AddNewItem'>");
                            sbMuen.Append(
                                "<span class='icons-addNewItem iconL'></span><span class='text'>新增项目</span></a></li>");

                        }
                        else
                        {
                            sbMuen.Append(
                                "<li class='openable'><a href='/Index/Index'><span class='icons-home iconL'></span><span class='text'>首页</span></a></li><li class='openable'><a href='/Report/AddNewItem'>");
                            sbMuen.Append(
                                "<span class='icons-addNewItem iconL'></span><span class='text'>新增项目</span></a></li><li class='openable'><a href='/Search/SearchProjects'><span class='icons-searchableItems iconL'></span><span class='text'>项目列表</span></a></li>");
                         

                           
                         

                        }
                    }
                }
            }
            else
            {
                sbMuen.Append(
                    "<li class='openable'><a href='/Index/Index'><span class='icons-home iconL'></span><span class='text'>首页</span></a></li><li class='openable'><a href='/Report/AddNewItem'>");
               
                //不是teamLeader就会把新增项目都显示
                if (!GetRole().Contains(2))
                {
                    sbMuen.Append(
                    "<span class='icons-addNewItem iconL'></span><span class='text'>新增项目</span></a></li><li class='openable'><a href='/Search/SearchProjects'><span class='icons-searchableItems iconL'></span><span class='text'>项目列表</span></a></li>");

                }
                else
                {
                    int id = -1;
                    var oaEmp = _IOaEmployeeService.GetByUid(User.UserId);
                    if (oaEmp != null)
                    {
                        id = oaEmp.DepartmentId.Value;
                    }
                    //如果是teamLeader 并且不是LoveDesign 就会显示
                    if (SystemRoles.LoveDesign != id)
                    {
                        sbMuen.Append(
                       "<span class='icons-addNewItem iconL'></span><span class='text'>新增项目</span></a></li><li class='openable'><a href='/Search/SearchProjects'><span class='icons-searchableItems iconL'></span><span class='text'>项目列表</span></a></li>");

                    }
                }
          


                if (GetRole().Contains(1) || GetRole().Contains(2))
                {
                    sbMuen.Append(
                        "<li class='openable'><a class='openable-toggle' data-toggle='dropdown' href='javascript:void(0)' onclick='meuns(this)'><span class='icons-schedule iconL'></span><span class='text'>时间表</span><span class='icons-up iconR'></span></a>");
                    if (GetRole().Contains(1))
                    {
                        sbMuen.Append(
                      "<ul class='subNav'><li><a href='/Report/ProjectTimeByPro'><span class='icons-left'></span>依项目</a></li><li><a href='/Report/GetProjectByUser'><span class='icons-left'></span>依人员</a></li><li><a href='/Report/GetTeamDetail'><span class='icons-left'></span>依团队</a></li></ul></li>");
                  
                    }
                    else if (GetRole().Contains(2))
                    {
                        sbMuen.Append(
                   "<ul class='subNav'><li><a href='/Report/ProjectTimeByPro'><span class='icons-left'></span>依项目</a></li><li><a href='/Report/GetProjectByUser'><span class='icons-left'></span>依人员</a></li></ul></li>");
                  
                    }
                  
                    //
                      if (GetRole().Contains(1))
                    {
                        sbMuen.Append(
                     "<li class='openable'><a class='openable-toggle' data-toggle='dropdown' href='javascript:void(0)' onclick='meuns(this)'><span class='icons-diagram iconL'></span><span class='text'>报表</span><span class='icons-up iconR'></span></a>");
                 
                        sbMuen.Append(
                            "<ul class='subNav'><li><a href='/ReportForm/HumanResource'><span class='icons-left'></span>人力资源概括</a></li><li><a href='/ReportForm/team'><span class='icons-left'></span>依团队</a></li><li><a href='/ReportForm/assign'><span class='icons-left'></span>项目分配</a></li><li><a href='/ReportForm/GetReportAll'><span class='icons-left'></span>工时汇总</a></li></ul></li>");
                   //
                    }
                    // delete team/
                    //else if (GetRole().Contains(2))
                    //{
                    //    sbMuen.Append(
                    //        "<ul class='subNav'><li><a href='/ReportForm/HumanResource'><span class='icons-left'></span>人力资源概括</a></li></ul></li>");
                    //}


                }

            }


            return AjaxMsg(AjaxMsgStatu.Ok, "", "", sbMuen.ToString());


        }

        #endregion



        #region 2.0 新增操作 + ActionResult Add(Project project)

        /// <summary>
        /// 新增操作
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Project project)
        {
            //测试

            //获取当前用户
            var cutUser = _IOaEmployeeService.GetByUid(User.UserId);
            var isTraffice = _iTResourceTeamService.GeTeamsByUid(GetCureentID());
            OaDepartment cutUsrDepart = null;
            if (cutUser != null)
            {
                cutUsrDepart = _OaDepartmentService.GetByDepartmentID(Convert.ToInt32(cutUser.DepartmentId.Value));
            }
            if (string.IsNullOrEmpty(project.projectName) || string.IsNullOrEmpty(project.client))
            {
                return null;
            }



            TProject model = new TProject();
            model.ProjectName = project.projectName;
            model.ClientName = project.client;
            model.ProjectTypeId = project.projectType;
            model.DepartmentId = project.department;
            model.Deadline = project.deadline;
            model.ProjectDescription = project.projectIntroduction.Replace("\n","");

            var newmodel = _IProjectService.GetLastModel();

            string sernos = "";
            if (newmodel != null)
            {

                string year = newmodel.ProjectCode.Substring(0, 4);
                string month = newmodel.ProjectCode.Substring(4, 2);
                string no = newmodel.ProjectCode.Substring(6, newmodel.ProjectCode.Length - 6);
                string tmpNewMoth = "";
                if (year == DateTime.Now.Year.ToString())
                {
                    int tmpMoth = DateTime.Now.Month;

                    if (tmpMoth < 10)
                    {
                        tmpNewMoth = "0" + tmpMoth.ToString();
                    }
                    else
                    {
                        tmpNewMoth = tmpMoth.ToString();
                    }
                    //如果是当月
                    if (tmpNewMoth == month)
                    {

                        int tmpNo = Convert.ToInt32(no);
                        if (tmpNo < 10)
                        {
                            sernos = year + month + "0" + (tmpNo + 1).ToString();
                        }
                        else
                        {
                            sernos = year + month + Convert.ToString(Convert.ToInt32(no) + 1);
                        }

                    }
                    else
                    {
                        sernos = year + tmpNewMoth + "01";

                    }
                }
                else
                {
                    sernos = DateTime.Now.Year.ToString() + "01" + "01";
                }

            }
            else
            {
                string res = "";
                string year = DateTime.Now.Year.ToString();
                string resMonth = "";
                int moth = DateTime.Now.Month;
                if (moth < 10)
                {
                    resMonth = "0" + moth.ToString();
                }
                res = year + resMonth + "01";
                sernos = res;
            }
            //项目号
            try
            {
                model.ProjectCode = sernos;
                model.RequestedDate = DateTime.Now;
                model.RequestorUid = User.UserId;
                model.Status = "A";
                //如果是FBI 或者是life  或者是builderheader
                if (cutUsrDepart != null)
                //1.0 如果是builderheader
                {
                    //如果是buhead申请  
                    if (User.UserId == cutUsrDepart.DepartmentHeadUid || cutUsrDepart.DepartmentName == SystemRoles.DeptName ||
                        cutUsrDepart.DepartmentName == SystemRoles.LoveDesignName)
                    {


                        var typeTmp = _ICtProjectTypeService.GetByID(model.ProjectTypeId.Value);
                        if (typeTmp != null)
                        {
                            if (typeTmp.DepartmentId != cutUser.DepartmentId.Value)
                            {
                                model.State = DataStatus.ProjectState.pendingByBuHead;
                                model.AssignedToUid = cutUsrDepart.DepartmentHeadUid;
                                //分配给当前的buhead 部门领导

                                #region 发送邮件

                                var oa = _IOaEmployeeService.GetByUid(model.AssignedToUid.Value);

                                var pt = _ICtProjectTypeService.GetByID(model.ProjectTypeId.Value);
                                var dept = _OaDepartmentService.GetByDepartmentID(model.DepartmentId.Value);
                                string url = ConfigurationManager.AppSettings["ppsurl"].ToString();
                                if (oa != null && pt != null && dept != null)
                                {
                                    try
                                    {
                                        base.SendEmail(oa.Email, "等待您分配团队",
                                                       "Dear "
                                                       + oa.EmployeeName +
                                                       ": <br/> &nbsp;&nbsp;您有一个项目需要去审批,请登录项目管理系统查看:<a href='" + url +
                                                       "'>PPS系统</a> <br/><br/>项目名称:" + model.ProjectName
                                                       + "<br/> 项目编号:" + model.ProjectCode
                                                       + "<br/> 客户:" + model.ClientName
                                                       + "<br/>项目类别:" + pt.ProjectTypeDesc
                                                       + "<br/>部门:" + dept.DepartmentName
                                                       + "<br/>项目介绍:" + model.ProjectDescription +
                                                       " <br/><br/><br/> 来自项目管理系统<br/>" +
                                                       DateTime.Now.ToString("yyyy-MM-dd"));
                                    }
                                    catch (Exception err)
                                    {


                                    }
                                }

                                #endregion
                            }
                            else
                            {

                                //to  if role is pm need to buheader to approve 
                             
                                model.State = DataStatus.ProjectState.pendingByTrafficLeader;
                                //按照所选的部门 找到对应的team 再得到对应的 Traffic Leader
                                int projectType = project.projectType;
                                var projectModel = _ICtProjectTypeService.GetByID(projectType);
                                if (projectModel != null)
                                {
                                    var trsModel = _iTResourceTeamService.GetByTid(projectModel.TeamId.Value);
                                    if (trsModel != null)
                                    {

                                        model.AssignedToUid = trsModel.ResourceUid;
                                    }
                                }

                                #region 发送邮件

                                if (model.AssignedToUid != null)
                                {
                                    var oa = _IOaEmployeeService.GetByUid(model.AssignedToUid.Value);

                                    var pt = _ICtProjectTypeService.GetByID(model.ProjectTypeId.Value);
                                    var dept = _OaDepartmentService.GetByDepartmentID(model.DepartmentId.Value);
                                    string url = ConfigurationManager.AppSettings["ppsurl"].ToString();
                                    if (oa != null && pt != null && dept != null)
                                    {
                                        try
                                        {
                                            base.SendEmail(oa.Email, "等待您分配团队",
                                                           "Dear "
                                                           + oa.EmployeeName +
                                                           ": <br/> &nbsp;&nbsp;您有一个项目需要去分配团队,请登录项目管理系统查看:<a href='" +
                                                           url +
                                                           "'>PPS系统</a> <br/><br/>项目名称:" + model.ProjectName
                                                           + "<br/> 项目编号:" + model.ProjectCode
                                                           + "<br/> 客户:" + model.ClientName
                                                           + "<br/>项目类别:" + pt.ProjectTypeDesc
                                                           + "<br/>部门:" + dept.DepartmentName
                                                           + "<br/>项目介绍:" + model.ProjectDescription +
                                                           " <br/><br/><br/> 来自项目管理系统<br/>" +
                                                           DateTime.Now.ToString("yyyy-MM-dd"));
                                        }
                                        catch (Exception err)
                                        {


                                        }
                                    }
                                }

                                #endregion
                            }
                        }
                    }
                    else
                    {


                        model.State = DataStatus.ProjectState.pendingByBuHead;
                        //分配给当前的buhead 部门领导
                        model.AssignedToUid = cutUsrDepart.DepartmentHeadUid;

                        #region 发送邮件

                        var oa = _IOaEmployeeService.GetByUid(model.AssignedToUid.Value);

                        var pt = _ICtProjectTypeService.GetByID(model.ProjectTypeId.Value);
                        var dept = _OaDepartmentService.GetByDepartmentID(model.DepartmentId.Value);
                        string url = ConfigurationManager.AppSettings["ppsurl"].ToString();
                        if (oa != null && pt != null && dept != null)
                        {
                            try
                            {
                                base.SendEmail(oa.Email, "等待您分配团队",
                                               "Dear "
                                               + oa.EmployeeName +
                                               ": <br/> &nbsp;&nbsp;您有一个项目需要去审批,请登录项目管理系统查看:<a href='" + url +
                                               "'>PPS系统</a> <br/><br/>项目名称:" + model.ProjectName
                                               + "<br/> 项目编号:" + model.ProjectCode
                                               + "<br/> 客户:" + model.ClientName
                                               + "<br/>项目类别:" + pt.ProjectTypeDesc
                                               + "<br/>部门:" + dept.DepartmentName
                                               + "<br/>项目介绍:" + model.ProjectDescription +
                                               " <br/><br/><br/> 来自项目管理系统<br/>" + DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                            catch (Exception err)
                            {


                            }
                        }

                        #endregion
                    }
                    _IProjectService.Add(model);

                    _unitOfWork.Save();
                    //string sno=DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+
                    if (model.State == DataStatus.ProjectState.pendingByBuHead)
                    {
                        TProjectTask tpTask = new TProjectTask();
                        tpTask.ProjectId = model.ProjectId;
                        tpTask.AssigneeUid = model.AssignedToUid;
                        //Pending Approval by BU Head(待上级审核)
                        tpTask.TaskTypeCode = "PendingApproval";
                        tpTask.Status = "P";

                        tpTask.CreatedDate = DateTime.Now;
                        tpTask.CreatedByUid = User.UserId;
                        _ITProjectTaskService.Add(tpTask);
                    }
                    if (model.State == DataStatus.ProjectState.pendingByTrafficLeader)
                    {
                        TProjectTask tpTask = new TProjectTask();
                        tpTask.ProjectId = model.ProjectId;
                        tpTask.AssigneeUid = model.AssignedToUid;
                        //Pending Team Lead Assignment by Traffic Leader(待交通员分配给团队)
                        tpTask.TaskTypeCode = "PendingTeamLeadAssignment";
                        tpTask.Status = "P";
                        tpTask.Decision = "A";
                        tpTask.CreatedDate = DateTime.Now;
                        tpTask.CreatedByUid = User.UserId;
                        _ITProjectTaskService.Add(tpTask);

                    }
                    _unitOfWork.Save();
                    var lastModel = _IProjectService.GetLastModel();
                    int pid = 0;
                    if (lastModel != null)
                    {
                        pid = lastModel.ProjectId;
                    }
                    this.ShowNotification(NotificationType.Success, "新增成功！");
                    return AjaxMsgOk("", "", pid);

                }
            }
            catch (Exception err)
            {
                this.ShowNotification(NotificationType.Error, "邮寄发送失败！");

                return AjaxMsgErr("内部异常，请联系FBI人员:_" + err.Message);
            }


            return AjaxMsgOk("新增成功!");
        }

        #endregion

        /// <summary>
        /// Get Current User's department Traffic Leader ID
        /// </summary>
        /// <returns>-1: Traffic Leader Id not found, else: returns Traffic Leader Id</returns>
        private int CurrentUserDepartmentTrafficeLeaderId()
        {
            var userID = -1;

            var oa = _IOaEmployeeService.GetByUid(User.UserId);
            if (oa != null)
            {
                var res = _OaDepartmentService.GetByDepartmentID(oa.DepartmentId.Value);
                if (res != null)
                {
                    //是Buheader
                    if (res.DepartmentHeadUid == User.UserId)
                    {

                        var team = _ICtProjectTypeService.GetByDept(res.DepartmentId);
                        if (team != null)
                        {
                            var resteam = _iTResourceTeamService.GetTraffice(team.TeamId.Value);
                            if (resteam != null)
                            {
                                userID = resteam.ResourceUid; //traffic leader's ID
                            }
                        }

                    }
                }
            }
            return userID;
        }


        #region 3.0 获得所有项目类别 + ActionResult ProjectType()

        /// <summary>
        /// 获得所有项目类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProjectType()
        {
            var selItems = new List<SelectListItem>();

            var taskList = _ITProjectTaskService.GetMyTasks(GetCureentID()).Distinct().ToList();
            if (taskList.Any())
            {
                foreach (var itemTask in taskList)
                {
                    if (itemTask != null)
                    {
                        var proModel = _IProjectService.GetByID(itemTask.ProjectId.Value);
                        if (proModel != null && proModel.State != DataStatus.ProjectState.closed)
                        {
                            selItems.Add(new SelectListItem()
                                {Text = proModel.ProjectName, Value = proModel.ProjectId.ToString()});
                        }
                    }

                }

            }
            return Json(selItems, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region 4.0 根据输入获得客户 + ActionResult GetClient(string name)

        /// <summary>
        /// 根据输入获得客户
        /// </summary>
        /// <returns></returns>
        public ActionResult GetClient(string name)
        {
            string nametmp = Request.Params["client"];
            List<SelectListItem> list = new List<SelectListItem>();
            var res = _IProjectService.GetClients(nametmp).Distinct().ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 5.0 根据项目类别 + ActionResult GetDepart(int projectTypeID)

        /// <summary>
        /// 根据项目类别
        /// </summary>
        /// <param name="projectTypeID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetDepart(int projectTypeID)
        {
            //TODO 根据用户ID 从AlwaysHR数据库获得用户所对应的部门ID
            OaEmployee oaEmployee = _IOaEmployeeService.GetByUid(GetCureentID());

            var model = _ICtProjectTypeService.GetByID(projectTypeID);
            if (model != null)
            {
                if (oaEmployee != null)
                {
                    //如果用户所对应的部门ID与当前项目类别的部门ID是一样，那么就会把所有的部门给返回回去
                    if (oaEmployee.DepartmentId == model.DepartmentId)
                    {
                        var departmodellist = _OaDepartmentService.GetList();
                        if (departmodellist != null)
                        {
                            if (departmodellist.Any())
                            {
                                var itemsDeparts = new List<SelectListItem>();
                                foreach (var newitem in departmodellist)
                                {
                                    if (newitem.DepartmentId == projectTypeID)
                                    {
                                        itemsDeparts.Add(new SelectListItem()
                                            {
                                                Text = newitem.DepartmentName,
                                                Value = newitem.DepartmentId.ToString(),
                                                Selected = true
                                            });
                                    }
                                    else
                                    {
                                        itemsDeparts.Add(new SelectListItem()
                                            {Text = newitem.DepartmentName, Value = newitem.DepartmentId.ToString()});
                                    }


                                }
                                return Json(itemsDeparts, JsonRequestBehavior.AllowGet);

                            }

                        }
                    }
                    else
                    {
                        var modeldepart =
                            _OaDepartmentService.GetByDepartmentID(Convert.ToInt32(oaEmployee.DepartmentId));
                        if (modeldepart != null)
                        {
                            var itemsDeparts = new List<SelectListItem>();
                            SelectListItem list = new SelectListItem()
                                {Text = modeldepart.DepartmentName, Value = modeldepart.DepartmentId.ToString()};
                            itemsDeparts.Add(list);
                            return Json(itemsDeparts, JsonRequestBehavior.AllowGet);
                        }
                    }
                    //如果用户所对应的部门ID与当前项目类别的部门ID是不一样，那么就不要选择部门。默认会给当前uid对应部门Id发送邮件
                }

            }
            return AjaxMsgOk();

        }

        #endregion

        #region 6.0 审批或者拒绝 + ActionResult ApproveOrReject(Project project)

        /// <summary>
        /// 审批或者拒绝
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ApproveOrReject(Project project)
        {
            var oldProject = _IProjectService.GetByID(project.projectID);


            try
            {
                if (project.types == "A")
                {
                    oldProject.ProjectName = project.projectName;
                    oldProject.ClientName = project.client;
                    oldProject.ProjectTypeId = project.projectType;
                    oldProject.DepartmentId = project.department;
                    oldProject.Deadline = project.deadline;
                    oldProject.ProjectDescription = project.projectIntroduction;
                    int projectType = project.projectType;
                    var projectModel = _ICtProjectTypeService.GetByID(projectType);
                    if (projectModel != null)
                    {
                        var trsModel = _iTResourceTeamService.GetByTid(projectModel.TeamId.Value);
                        if (trsModel != null)
                        {

                            oldProject.AssignedToUid = trsModel.ResourceUid;
                        }
                        else
                        {
                            this.ShowNotification(NotificationType.Error, "项目团队不存在！");
                            return null;
                        }
                    }
                    oldProject.State = DataStatus.ProjectState.pendingByTrafficLeader;

                    #region 发送邮件

                    var oa = _IOaEmployeeService.GetByUid(oldProject.AssignedToUid.Value);
                    var pt = _ICtProjectTypeService.GetByID(oldProject.ProjectTypeId.Value);
                    var dept = _OaDepartmentService.GetByDepartmentID(oldProject.DepartmentId.Value);
                    string url = ConfigurationManager.AppSettings["ppsurl"].ToString();
                    if (oa != null && pt != null && dept != null)
                    {
                        try
                        {
                            base.SendEmail(oa.Email, "等待您分配团队",
                                           "Dear "
                                           + oa.EmployeeName +
                                           ": <br/> &nbsp;&nbsp;您有一个项目需要去分配团队,请登录项目管理系统查看:<a href='" + url +
                                           "'>PPS系统</a> <br/><br/>项目名称:" + oldProject.ProjectName
                                           + "<br/> 项目编号:" + oldProject.ProjectCode
                                           + "<br/> 客户:" + oldProject.ClientName
                                           + "<br/>项目类别:" + pt.ProjectTypeDesc
                                           + "<br/>部门:" + dept.DepartmentName
                                           + "<br/>项目介绍:" + oldProject.ProjectDescription +
                                           " <br/><br/><br/> 来自项目管理系统<br/>" + DateTime.Now.ToString("yyyy-MM-dd"));
                        }
                        catch (Exception err)
                        {


                        }
                    }

                    #endregion

                    _IProjectService.Update(oldProject);

                    //将原先的状态修改
                    var pteams = _ITProjectTaskService.GetTask(project.projectID, User.UserId);
                    if (pteams != null)
                    {

                        pteams.Status = "C";
                        pteams.Decision = "A";
                        pteams.UpdatedByUid = User.UserId;
                        pteams.UpdatedDate = DateTime.Now;
                        _ITProjectTaskService.Update(pteams);

                    }





                    //获取对应的



                    TProjectTask tpTask = new TProjectTask();
                    tpTask.ProjectId = oldProject.ProjectId;
                    //审批 完成 就将AssigneeUid 设为 traffic
                    var projectTypeModel = _ICtProjectTypeService.GetByID(project.projectType);
                    if (projectTypeModel != null)
                    {
                        var trafficModel = _iTResourceTeamService.GetTraffice(projectTypeModel.TeamId.Value);
                        if (trafficModel != null)
                        {
                            tpTask.AssigneeUid = trafficModel.ResourceUid;
                        }
                    }

                    //Pending Team Lead Assignment by Traffic Leader(待交通员分配给团队)
                    tpTask.TaskTypeCode = "PendingTeamLeadAssignment";
                    tpTask.Status = "P";
                    tpTask.Decision = "A";
                    tpTask.CreatedDate = DateTime.Now;
                    tpTask.CreatedByUid = User.UserId;
                    _ITProjectTaskService.Add(tpTask);


                    //发送邮件 TODO
                    //SendEmail();

                }
                if (project.types == "R")
                {
                    oldProject.ProjectName = project.projectName;
                    oldProject.ClientName = project.client;
                    oldProject.ProjectTypeId = project.projectType;
                    oldProject.DepartmentId = project.department;
                    oldProject.Deadline = project.deadline;
                    oldProject.ProjectDescription = project.projectIntroduction;
                    oldProject.State = DataStatus.ProjectState.Reject;
                    oldProject.Reson = project.Reason;
                    //修改状态
                    //将原先的状态修改  修改为拒绝状态 
                    var pteams = _ITProjectTaskService.GetTask(project.projectID, User.UserId);
                    if (pteams != null)
                    {
                        pteams.Status = "C";
                        pteams.Decision = "R";
                        pteams.UpdatedByUid = User.UserId;
                        pteams.UpdatedDate = DateTime.Now;
                        _ITProjectTaskService.Update(pteams);
                    }

                    //TProjectTask tpTask = new TProjectTask();
                    //tpTask.ProjectId = oldProject.ProjectTypeId;
                    //tpTask.AssigneeUid = oldProject.AssignedToUid;
                    ////Pending Team Lead Assignment by Traffic Leader(待交通员分配给团队)
                    //tpTask.TaskTypeCode = "PendingTeamLeadAssignment";
                    //tpTask.Status = "P";
                    ////拒绝
                    //tpTask.Decision = "R";
                    //tpTask.CreatedDate = DateTime.Now;
                    //tpTask.CreatedByUid = User.UserId;

                    _IProjectService.Update(oldProject);
                    //_ITProjectTaskService.Add(tpTask);

                }
                _unitOfWork.Save();
                this.ShowNotification(NotificationType.Success, "操作成功!");
                return AjaxMsgOk();
            }
            catch (Exception err)
            {

                this.ShowNotification(NotificationType.Error, "操作失败！");
                return AjaxMsgErr();
            }
            return AjaxMsgOk();
        }

        #endregion

        [HttpGet]
        public ActionResult ApproveOrReject(int id)
        {
            var projectmodel = _IProjectService.GetByID(id);
            if (projectmodel != null)
            {
                ViewBag.project = projectmodel;
                var oaModel = _IOaEmployeeService.GetByUid(projectmodel.RequestorUid);
                if (oaModel != null)
                {

                    ViewBag.RequestName = oaModel.EmployeeName;
                }
                var ptotypeModel = _ICtProjectTypeService.GetByID(projectmodel.ProjectTypeId.Value);
                if (ptotypeModel != null)
                {

                    ViewBag.projectTypeName = ptotypeModel.ProjectTypeDesc;

                }
                var deptModel = _OaDepartmentService.GetByDepartmentID(projectmodel.DepartmentId.Value);
                if (deptModel != null)
                {

                    ViewBag.deptName = deptModel.DepartmentName;
                }
            }







            BindViewBagUser();
            return View();
        }

        public ActionResult AddNewItem()
        {

            List<int> roles = GetRole();
            if (roles != null && roles.Any())
            {
                if (roles.Contains(1))
                {
                    ViewBag.role = SystemRoles.TraiiceLeader;
                }
                else if (roles.Contains(2))
                {
                    ViewBag.role = SystemRoles.TeamLeader;
                }
                else
                {
                    ViewBag.role = SystemRoles.TeamMember;
                }
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
                            ViewBag.role = SystemRoles.PM;
                        }
                        else
                        {
                            //表示是BuHeader
                            ViewBag.role = SystemRoles.Buhead;
                        }
                        ViewBag.deptNames = result.DepartmentName;
                        ViewBag.deptID = result.DepartmentId;
                    }
                }
            }


            var list = _ICtProjectTypeService.GetTypes();
            if (list.Any())
            {
                var selItems = new List<SelectListItem>();
                foreach (var items in list)
                {
                    if (items != null)
                    {

                        selItems.Add(new SelectListItem()
                            {Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString()});
                    }
                }
                ViewBag.ProType = selItems;
            }
            else
            {
                SelectListItem sel = new SelectListItem();
                ViewBag.ProType = sel;
            }

            BindViewBagUser();
            return View();

        }


        public ActionResult AddProject(int id)
        {
            var projectmodel = _IProjectService.GetByID(id);
            if (projectmodel != null)
            {
                ViewBag.newproject = projectmodel;
                var dept = _OaDepartmentService.GetByDepartmentID(projectmodel.DepartmentId.Value);
                if (dept != null)
                {
                    ViewBag.deptNames = dept.DepartmentName;

                }
            }

            var list = _ICtProjectTypeService.GetTypes();
            if (list.Any())
            {
                var selItems = new List<SelectListItem>();
                foreach (var items in list)
                {
                    if (items != null)
                    {

                        selItems.Add(new SelectListItem()
                            {Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString()});
                    }
                }
                ViewBag.ProType = selItems;
            }
            else
            {
                SelectListItem sel = new SelectListItem();
                ViewBag.ProType = sel;
            }

            BindViewBagUser();
            return View();
        }


        [HttpGet]
        public ActionResult ProjectDetail(int id)
        {
            @ViewBag.IsCanEdit = IsCanEdit(id);

            var CurrentUserIDDept = _IOaEmployeeService.GetByUid(User.UserId).DepartmentId;
            if(CurrentUserIDDept==null)
            {
                return null;
            }
            if(CurrentUserIDDept==SystemRoles.LoveDesign)
            {
                ViewBag.isLoveDesing = false;
            }

            //获得角色
            List<int> roles = GetRole();
            if (roles.Contains(1))
            {
                ViewBag.role = SystemRoles.TraiiceLeader;
            }
            else if (roles.Contains(2))
            {
                ViewBag.role = SystemRoles.TeamLeader;
            }
            else
            {
                ViewBag.role = SystemRoles.TeamMember;
            }


            var projectmodel = _IProjectService.GetByID(id);
            if (projectmodel != null)
            {
                ViewBag.project = projectmodel;
                var oaModel = _IOaEmployeeService.GetByUid(projectmodel.RequestorUid);
                if (oaModel != null)
                {
                    ViewBag.RequestName = oaModel.EmployeeName;

                    var ptotypeModel = _ICtProjectTypeService.GetByID(projectmodel.ProjectTypeId.Value);
                    if (ptotypeModel != null)
                    {
                        ViewBag.projectTypeName = ptotypeModel.ProjectTypeDesc;

                    }
                    var deptModel = _OaDepartmentService.GetByDepartmentID(projectmodel.DepartmentId.Value);
                    if (deptModel != null)
                    {
                        ViewBag.deptName = deptModel.DepartmentName;
                    }

                }
            }
            var list = _ICtProjectTypeService.GetTypes();
            if (list.Any())
            {
                var selItems = new List<SelectListItem>();
                foreach (var items in list)
                {
                    if (items != null)
                    {
                        if (projectmodel.ProjectTypeId == items.ProjectTypeId)
                        {
                            ViewBag.selectedItems = items.ProjectTypeId.ToString();
                            ViewBag.selectdDeparts = "18";
                            selItems.Add(new SelectListItem()
                                {Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString(), Selected = true});
                        }
                        else
                        {
                            selItems.Add(new SelectListItem()
                                {Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString()});
                        }

                    }
                }
                ViewBag.ProType = selItems;
            }
            else
            {
                SelectListItem sel = new SelectListItem();
                ViewBag.ProType = sel;
            }

            //获取项目团队
            //测试
            //获取traffice 所在的部门
            var listTeams = _iTResourceTeamService.GetTrafic(GetCureentID());
            List<SelectListItem> resTeams = new List<SelectListItem>();
            if (listTeams != null)
            {
                var res = _ICtTeamService.GetList(listTeams.TeamId);
                if (res.Any())
                {
                    foreach (var item in res)
                    {
                        resTeams.Add(new SelectListItem() {Text = item.TeamName, Value = Convert.ToString(item.TeamId)});
                    }
                }
            }
            ViewBag.teams = resTeams;


            var taskModel = _ITProjectTaskService.GTaskHavedTeamLead(id);
            if (taskModel != null)
            {
                //获得组长ID
                int uid = taskModel.AssigneeUid.Value;
                var model = _iTResourceTeamService.GetTeamLeader(uid);
                if (model != null)
                {
                    var teamModel = _ICtTeamService.GeTeams(model.SubTeamId.Value);
                    if (teamModel != null)
                    {
                        ViewBag.teamName = teamModel.TeamName;
                    }
                }
            }


            BindViewBagUser();
            ViewBag.mileClass = "";
            ViewBag.fileClass = "";
            if (Request["divId"] != null)
            {
                ViewBag.fileClass = "k-state-active";
            }
            else
            {
                ViewBag.mileClass = "k-state-active";
            }
            return View();
        }

        /// <summary>
        /// 分配执行团队 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddDetail(Project project)
        {
            try
            {
                var oldProject = _IProjectService.GetByID(project.projectID);
                oldProject.ProjectName = project.projectName;
                oldProject.ClientName = project.client;
                oldProject.ProjectTypeId = project.projectType;
                oldProject.DepartmentId = project.department;
                oldProject.Deadline = project.deadline;
                oldProject.ProjectDescription = project.projectIntroduction;
                oldProject.State = DataStatus.ProjectState.pendingByTeamLeader;
                oldProject.UpdatedByUid = User.UserId;
                oldProject.UpdatedDate = DateTime.Now;
                _IProjectService.Update(oldProject);
                //修改 之前状态
                var model = _ITProjectTaskService.GetTask(project.projectID, User.UserId);
                if (model != null)
                {
                    model.Status = "C";
                    model.UpdatedByUid = User.UserId;
                    model.UpdatedDate = DateTime.Now;
                    _ITProjectTaskService.Update(model);
                }



                //新增
                TProjectTask tpTask = new TProjectTask();
                tpTask.ProjectId = oldProject.ProjectTypeId;
                tpTask.AssigneeUid = oldProject.AssignedToUid;
                //Pending Resource Allocation by Team Leader(待组长安排任务)
                tpTask.TaskTypeCode = "PendingResourceAllocation";
                tpTask.Status = "P";
                tpTask.Decision = "A";
                tpTask.CreatedDate = DateTime.Now;
                tpTask.CreatedByUid = User.UserId;
                //获取teamLeader
                var teamLeaderModel = _iTResourceTeamService.GetTeamLeader(project.ProjectTeam, GetCureentID());
                if (teamLeaderModel != null)
                {
                    tpTask.AssigneeUid = teamLeaderModel.ResourceUid;
                }
                _ITProjectTaskService.Add(tpTask);
                base._unitOfWork.Save();
                string email = _IOaEmployeeService.GetByUid(tpTask.AssigneeUid.Value).Email;
                //TODO 发送邮件
                //SendEmail(email,"");   
                this.ShowNotification(NotificationType.Success, "分配成功！");
                return AjaxMsgOk();
            }
            catch (Exception err)
            {

                return AjaxMsgErr();
            }
        }


        public ActionResult ProjectToTeam(int id)
        {
            BindViewBagUser();
            return View();
        }

        public ActionResult ProjectTimeByPro()
        {
            BindViewBagUser();
            return View();
        }



        public List<int> GetUsers()
        {
            List<int> users = new List<int>();

            //获取所在的团队



            var traffic = _iTResourceTeamService.GetTraffice(GetCureentID());
            //获得Traffice Lead 
            if (traffic != null)
            {
                //获得下面所有的TeamLeader
                var listTeam = _iTResourceTeamService.GetTeamsList(traffic.ResourceUid);
                if (listTeam.Any())
                {
                    foreach (var itemMember in listTeam)
                    {
                        if (itemMember != null)
                        {
                            //添加TeamLeader
                            users.Add(itemMember.ResourceUid);
                            var member = _iTResourceTeamService.GetTeamsList(itemMember.ResourceUid);
                            //添加member
                            foreach (var me in member)
                            {
                                if (me != null)
                                {
                                    users.Add(me.ResourceUid);
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                var list = _iTResourceTeamService.GetByUid(GetCureentID());
                foreach (var item in list)
                {
                    if (item.RoleId == 2)
                    {
                        //将本人TeamLeader 添加进来
                        users.Add(item.ResourceUid);
                        var member = _iTResourceTeamService.GetTeamsList(item.ResourceUid);
                        if (member.Any())
                        {
                            foreach (var me in member)
                            {
                                if (me != null)
                                {
                                    //将本人TeamMember 添加进来
                                    users.Add(me.ResourceUid);
                                }
                            }
                        }

                        //添加member
                        return users;
                    }
                }
            }
            return users;
        }


        public ActionResult GetProjectHtml(SearchModel serModel)
        {
            if (serModel.endingDate == Convert.ToDateTime("0001/1/1 0:00:00") ||
                serModel.startDate == Convert.ToDateTime("0001/1/1 0:00:00"))
            {
                this.ShowNotification(NotificationType.Error, "请选择开始时间和结束时间");
                return null;


            }
            int proID = serModel.project;
            TimeSpan ts = serModel.endingDate - serModel.startDate;

            if (ts.TotalSeconds < 0)
            {
                this.ShowNotification(NotificationType.Error, "结束时间必须大于开始时间");
                return null;
            }
            //
            StringBuilder sbHtml = new StringBuilder(500);
            sbHtml.Append("<table class='table table-bordered form-inline' id='tbList'>");
            var projectModel = _IProjectService.GetProjectByAnPai(serModel.project);
            if (projectModel == null)
            {
                this.ShowNotification(NotificationType.Error, "项目不存在!");
                return null;
            }
            //根据项目获得teamleader
            List<int> resUIDS = new List<int>();
            var teamLeader = _iTResourceTeamService.GetTeamLeader(projectModel.AssignedToUid.Value);
            if (teamLeader != null)
            {
                resUIDS.Add(teamLeader.ResourceUid);
                // 获取组长下面的所有成员 
                var res = _iTResourceTeamService.GeetMembers(teamLeader.ResourceId, teamLeader.SubTeamId.Value);
                if (res.Any())
                {
                    foreach (var item in res)
                    {
                        var uids =
                            _IProjectWorkPlanService.GetWorkPlanByProjectId(proID).Select(u => u.ResourceUid).ToList();
                        if (uids.Contains(item.ResourceUid))
                        {
                            resUIDS.Add(item.ResourceUid);
                        }

                    }

                }
            }

            //List<int> userInts=  _iTResourceTeamService.GetCurrentUInts(User.UserId);

            int colNumbers = 0;
            if (resUIDS.Any())
            {
                sbHtml.Append("<tr><th>日期</th>");
                foreach (var itemUser in resUIDS)
                {
                    //如果角色是traffic 那就人员显示就要在项目中 在timesheet中设置的
                    bool isCS = false;
                    sbHtml.Append("<th>");
                    var oaModel = _IOaEmployeeService.GetByUid(itemUser);
                    double planTime = 0.00;
                    if (oaModel != null)
                    {
                     var plantime=   _IProjectWorkPlanService.GetTime(proID, itemUser);
                        if(plantime!=null)
                        {
                            if(plantime.PlanEffort!=null)
                            {
                                planTime =  Convert.ToDouble(plantime.PlanEffort) + Convert.ToDouble(plantime.PlanEffort)*0.25;
                            }
                        }
                        var time = _ITTimesheetService.GetTime(proID, itemUser);
                        if(time!=null)
                        {
                            var atime = Convert.ToDouble(time);
                            if(atime>planTime)
                            {
                                isCS = true;
                            }
                        }
                        colNumbers = colNumbers + 1;
                        if (isCS)
                        {
                            sbHtml.Append(oaModel.EmployeeName + "<font color='red'>(*)</font>");
                        }
                        else
                        {
                            sbHtml.Append(oaModel.EmployeeName);
                        }
                       
                    }
                    sbHtml.Append("</th>");


                }
                sbHtml.Append("</tr>");
            }

            int countCol = Convert.ToInt32(ts.Days) + 1;
            for (int i = 0; i < countCol; i++)
            {
                string dt = serModel.startDate.AddDays(i).ToString("yyyy-MM-dd");
                sbHtml.Append("<tr>");
                sbHtml.Append("<td>");
                sbHtml.Append(dt + "(" + serModel.startDate.AddDays(i) .ToString("dddd")+ ")");
                sbHtml.Append("</td>");
                foreach (var itemUser in resUIDS)
                {
                    if (itemUser != null)
                    {
                        int userid = itemUser;
                        TTimesheet timesheet = new TTimesheet()
                            {
                                ProjectId = proID,
                                Day = Convert.ToDateTime(dt),
                                ResourceUid = userid
                            };
                        var timesheetModel = _ITTimesheetService.GeTimesheet(timesheet);
                        if (timesheetModel == null)
                        {

                            if (GetRole().Contains(1))
                            {
                                sbHtml.Append("<td>");
                                sbHtml.Append(
                                    "<input class='form-control' readonly='readonly' style='width:100%' data-proId='" +
                                    proID + "' data-userid='" +
                                    userid + "' data-time='" + dt + "' />");
                                sbHtml.Append("</td>");
                            }
                            else if (GetRole().Contains(2))
                            {
                                if (projectModel.State == DataStatus.ProjectState.pendingByTeamLeaderEnd)
                                {
                                    sbHtml.Append("<td>");
                                    sbHtml.Append(
                                        "<input class='form-control'  style='width:100%' data-proId='" +
                                        proID + "' data-userid='" +
                                        userid + "' data-time='" + dt + "' />");
                                    sbHtml.Append("</td>");
                                }
                                else if (projectModel.State == DataStatus.ProjectState.closed)
                                {
                                    sbHtml.Append("<td>");
                                    sbHtml.Append(
                                        "<input readonly='readonly' class='form-control'  style='width:100%' data-proId='" +
                                        proID + "' data-userid='" +
                                        userid + "' data-time='" + dt + "' />");
                                    sbHtml.Append("</td>");
                                }

                            }

                        }
                        else
                        {
                            sbHtml.Append("<td>");
                            if (GetRole().Contains(1))
                            {
                                sbHtml.Append(
                                    "<input class='form-control' readonly='readonly' style='width:100%' data-proId='" +
                                    proID + "' data-userid='" +
                                    userid + "' data-time='" + dt + "' value='" + timesheetModel.NumOfHours +
                                    "'/>");
                            }
                            else if (GetRole().Contains(2))
                            {
                                if (projectModel.State == DataStatus.ProjectState.pendingByTeamLeaderEnd)
                                {
                                    sbHtml.Append("<input class='form-control' style='width:100%' data-proId='" +
                                                  proID + "' data-userid='" +
                                                  userid + "' data-time='" + dt + "' value='" +
                                                  timesheetModel.NumOfHours +
                                                  "'/>");
                                }
                                else if (projectModel.State == DataStatus.ProjectState.closed)
                                {
                                    sbHtml.Append(
                                        "<input readonly='readonly' class='form-control' style='width:100%' data-proId='" +
                                        proID + "' data-userid='" +
                                        userid + "' data-time='" + dt + "' value='" +
                                        timesheetModel.NumOfHours +
                                        "'/>");
                                }
                            }

                            sbHtml.Append("</td>");
                        }

                    }
                }
                sbHtml.Append("</tr>");
            }

            //}
            sbHtml.Append("</table>");
            if (GetRole().Contains(2) || GetRole().Contains(3))
            {
                sbHtml.Append("<input type='button' class='btn btn-blueBlack fr' value='提交' onclick='add()'>");
            }

            return AjaxMsgOk("", "", sbHtml.ToString());
        }



        public ActionResult GetProjectByUser()
        {

            BindViewBagUser();
            return View();
        }



        public ActionResult GetMyProjectUser()
        {
            List<int> resRole = GetRole();
            if (resRole != null)
            {
                foreach (var item in resRole)
                {
                    if (item == 2)
                    {
                        return PartialView("GetProject");
                        //return Redirect("/report/GetProjectByUser");
                    }
                    if (item == 3)
                    {
                        ViewBag.IsMy = "1";
                        ViewBag.uid = User.UserId;
                        return PartialView("GetProjectByMyUser");
                        //return Redirect("/report/GetProjectByMyUser");
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 获得我的时间表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProjectByMyUser()
        {
            BindViewBagUser();

            ViewBag.IsMy = "1";
            ViewBag.uid = User.UserId;
            return View();
        }



        public ActionResult GetProjectHtmlByUser(SerchUserModel model)
        {
            if (model.uid == 0)
            {
                this.ShowNotification(NotificationType.Error, "请选择人员！");
                return null;
            }
            if (model.dtTime == Convert.ToDateTime("0001/1/1 0:00:00"))
            {
                this.ShowNotification(NotificationType.Success, "请选择日期");
                return null;
            }




            DateTime dtst = DataHelper.CalculateFirstDateOfWeek(model.dtTime);
            DateTime dtet = DataHelper.CalculateLastDateOfWeek(model.dtTime);
            StringBuilder sbhtml = new StringBuilder(500);
            sbhtml.Append("<table class='table table-bordered timetable' id='tbList' style='width: 100%'>");
            sbhtml.Append("<tr>");
            sbhtml.Append("<th style='width:20%'>");
            sbhtml.Append("项目");
            sbhtml.Append("</th>");
            for (int i = 0; i < 7; i++)
            {
                sbhtml.Append("<th>");
                sbhtml.Append(dtst.AddDays(i).ToString("yyyy-MM-dd") + "(" + dtst.AddDays(i) .ToString("dddd")+ ")");
                sbhtml.Append("</th>");
            }
            //获取项目

            //List<TProjectWorkPlan> 
            List<TProject> tpList = new List<TProject>();

            List<TProjectTask> work = new List<TProjectTask>();
            if (GetRole().Contains(3))
            {
                //获取组长
                //可能是多个组  当是成员的时候
                if (GetRole().Contains(3))
                {
                    var resList = _iTResourceTeamService.GeTeams(GetCureentID(), 3);
                    if (resList.Any())
                    {
                        foreach (var dataItem in resList)
                        {
                            if (dataItem != null)
                            {

                                var res = _iTResourceTeamService.GEtLeader(dataItem.ManagerUid.Value);
                                if (res != null)
                                {
                                    var rr = _ITProjectTaskService.GetMyTasks(res.ResourceUid);
                                    if (rr.Any())
                                    {
                                        foreach (var rrr in rr)
                                        {
                                            if (rrr != null)
                                            {
                                                work.Add(rrr);
                                            }

                                        }
                                    }
                                }

                            }


                        }
                    }
                }
                //当时组长的时候
                if (GetRole().Contains(2))
                {
                    var res = _ITProjectTaskService.GetMyTasks(GetCureentID());
                    if (res.Any())
                    {
                        foreach (var rr in res)
                        {
                            if (rr != null)
                            {
                                work.Add(rr);
                            }
                        }
                    }
                }


            }
            else
            {
                var res = _ITProjectTaskService.GetMyTasks(GetCureentID());
                if (res.Any())
                {
                    foreach (var rr in res)
                    {
                        if (rr != null)
                        {
                            work.Add(rr);
                        }
                    }
                }
            }

            //var workPlanList = _IProjectWorkPlanService.GetWorkPlansByUsers(model.uid);
            if (work.Any())
            {

                foreach (var itemWork in work)
                {
                    var promodel = _IProjectService.GetByID(itemWork.ProjectId.Value);
                    if (promodel != null && promodel.State != DataStatus.ProjectState.closed)
                    {
                        var resuid =
                            _IProjectWorkPlanService.GetWorkPlanByProjectId(promodel.ProjectId).Select(
                                u => u.ResourceUid)
                                .ToList();

                        if (resuid.Contains(model.uid))
                        {
                            tpList.Add(promodel);
                        }


                    }
                }
            }

            var resTypes = tpList.Distinct().ToList();
            if (resTypes.Any())
            {
                for (int i = 0; i < resTypes.Count; i++)
                {
                    //
                    bool isCS = false;
                    double planTime = 0.00;
                    var plantime = _IProjectWorkPlanService.GetTime(resTypes[i].ProjectId, model.uid);
                    if (plantime != null)
                    {
                        if (plantime.PlanEffort != null)
                        {
                            planTime = Convert.ToDouble(plantime.PlanEffort) + Convert.ToDouble(plantime.PlanEffort) * 0.25;
                        }
                    }
                    var time = _ITTimesheetService.GetTime(resTypes[i].ProjectId, model.uid);
                    if (time != null)
                    {
                        var atime = Convert.ToDouble(time);
                        if (atime > planTime)
                        {
                            isCS = true;
                        }
                    }
                    sbhtml.Append("<tr>");
                    sbhtml.Append("<td>");
                    if (isCS)
                    {
                        sbhtml.Append(resTypes[i].ProjectName + "<font color='red'>(*)</font>");
                    }
                    else
                    {
                        sbhtml.Append(resTypes[i].ProjectName);
                    }
                  
                    sbhtml.Append("</td>");
                    for (int j = 0; j < 7; j++)
                    {
                        TTimesheet timesheet = new TTimesheet()
                            {
                                Day = Convert.ToDateTime(dtst.AddDays(j).ToString("yy-MM-dd")),
                                ResourceUid = model.uid,
                                ProjectId = resTypes[i].ProjectId
                            };

                        var timeSheetModel = _ITTimesheetService.GeTimesheet(timesheet);
                        if (timeSheetModel == null)
                        {
                            if (GetRole().Contains(1))
                            {
                                sbhtml.Append("<td>");
                                sbhtml.Append(
                                    "<input readonly='readonly'  class='form-control'  style='width: 80%' data-proId='" +
                                    timesheet.ProjectId +
                                    "' data-userid='" + model.uid + "' data-time='" +
                                    dtst.AddDays(j).ToString("yy-MM-dd") + "' />");
                                sbhtml.Append("</td>");
                            }
                            else if (GetRole().Contains(2) || GetRole().Contains(3))
                            {
                                if (resTypes[i].State == DataStatus.ProjectState.pendingByTeamLeaderEnd)
                                {
                                    sbhtml.Append("<td>");
                                    sbhtml.Append("<input   class='form-control'  style='width: 80%' data-proId='" +
                                                  timesheet.ProjectId +
                                                  "' data-userid='" + model.uid + "' data-time='" +
                                                  dtst.AddDays(j).ToString("yy-MM-dd") + "' />");
                                    sbhtml.Append("</td>");
                                }
                                else if (resTypes[i].State == DataStatus.ProjectState.closed)
                                {
                                    sbhtml.Append("<td>");
                                    sbhtml.Append(
                                        "<input readonly='readonly'   class='form-control'  style='width: 80%' data-proId='" +
                                        timesheet.ProjectId +
                                        "' data-userid='" + model.uid + "' data-time='" +
                                        dtst.AddDays(j).ToString("yy-MM-dd") + "' />");
                                    sbhtml.Append("</td>");
                                }

                            }

                        }
                        else
                        {
                            if (GetRole().Contains(1))
                            {
                                sbhtml.Append("<td>");
                                sbhtml.Append("<input readonly='readonly' value='" + timeSheetModel.NumOfHours +
                                              "'   class='form-control' style='width: 80%' data-proId='" +
                                              timesheet.ProjectId +
                                              "' data-userid='" + model.uid + "' data-time='" +
                                              dtst.AddDays(j).ToString("yy-MM-dd") + "'  value='" +
                                              timeSheetModel.NumOfHours +
                                              "'/>");
                                sbhtml.Append("</td>");
                            }
                            else if (GetRole().Contains(2) || GetRole().Contains(3))
                            {
                                if (resTypes[i].State == DataStatus.ProjectState.pendingByTeamLeaderEnd)
                                {
                                    sbhtml.Append("<td>");
                                    sbhtml.Append("<input value='" + timeSheetModel.NumOfHours +
                                                  "'   class='form-control' style='width: 80%' data-proId='" +
                                                  timesheet.ProjectId +
                                                  "' data-userid='" + model.uid + "' data-time='" +
                                                  dtst.AddDays(j).ToString("yy-MM-dd") + "'  value='" +
                                                  timeSheetModel.NumOfHours +
                                                  "'/>");
                                    sbhtml.Append("</td>");
                                }
                                else if (resTypes[i].State == DataStatus.ProjectState.closed)
                                {
                                    sbhtml.Append("<td>");
                                    sbhtml.Append("<input readonly='readonly' value='" + timeSheetModel.NumOfHours +
                                                  "'   class='form-control' style='width: 80%' data-proId='" +
                                                  timesheet.ProjectId +
                                                  "' data-userid='" + model.uid + "' data-time='" +
                                                  dtst.AddDays(j).ToString("yy-MM-dd") + "'  value='" +
                                                  timeSheetModel.NumOfHours +
                                                  "'/>");
                                    sbhtml.Append("</td>");
                                }
                            }
                        }

                    }
                    sbhtml.Append("</tr>");
                }
            }
            else
            {
                this.ShowNotification(NotificationType.Information,"项目不存在！");
                return null;
            }
            sbhtml.Append(
                "<tr><td colspan='8' class='clearfix'><input type='button' class='fl btn btn-blueBlack' value='上周' onclick='preWeek()'>&nbsp;&nbsp;<input type='button' class='fr btn btn-blueBlack' value='下周' onclick='nextWeek()'/></td></tr>");
            sbhtml.Append("</table>");
            if (GetRole().Contains(2) || GetRole().Contains(3))
            {
                sbhtml.Append("<input type='button' class='btn btn-blueBlack fr' value='提交' onclick='add()'>");
            }
            HtmlData data = new HtmlData()
                {
                    sbHtml = sbhtml.ToString(),
                    STime = model.dtTime.AddDays(-7).ToString("yyyy-MM-dd"),
                    ETime = model.dtTime.AddDays(7).ToString("yyyy-MM-dd"),
                    uid = model.uid
                };
            return AjaxMsgOk("", "", data);

        }



        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        public List<int> GetRole()
        {
            List<int> res = new List<int>();
            int userids = -1;
            var ints = CurrentUserDepartmentTrafficeLeaderId();
            if (ints == -1)
            {
                userids = User.UserId;
            }
            else
            {
                userids = ints;
            }

            var resList = _iTResourceTeamService.GetByUid(userids);
            if (resList != null)
            {

                if (resList.Any())
                {
                    return resList.Select(u => u.RoleId).ToList();

                }
            }

            return res;
        }


        #region 获取人员 + ActionResult GetPeoples()

        /// <summary>
        /// 获取人员 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPeoples()
        {
            List<OaEmployee> oaEmployees = new List<OaEmployee>();


            if (GetRole().Contains(1))
            {
                var result = _iTResourceTeamService.GetTrafic(GetCureentID());
                if (result != null)
                {
                    var data = _iTResourceTeamService.GetMembers(result.TeamId);
                    if (data.Any())
                    {
                        foreach (var item in data)
                        {
                            var dataRes = _IOaEmployeeService.GetByUid(item.ResourceUid);
                            if (dataRes != null)
                            {
                                oaEmployees.Add(dataRes);
                            }
                        }
                    }
                }
            }
            else if (GetRole().Contains(2))
            {
                var teamLeader = _iTResourceTeamService.GetTeamLeader(GetCureentID());
                if (teamLeader != null)
                {
                    var resOA = _IOaEmployeeService.GetByUid(teamLeader.ResourceUid);
                    if (resOA != null)
                    {
                        oaEmployees.Add(resOA);
                    }
                    var resList = _iTResourceTeamService.GetTeamsList(teamLeader.ResourceId);
                    if (resList.Any())
                    {
                        foreach (var item in resList)
                        {
                            var oa = _IOaEmployeeService.GetByUid(item.ResourceUid);
                            if (oa != null)
                            {
                                oaEmployees.Add(oa);
                            }
                        }

                    }
                }
            }

            List<SelectListItem> sel = new List<SelectListItem>();
            if (oaEmployees.Any())
            {

                foreach (var item in oaEmployees.Distinct().ToList())
                {
                    if (item != null)
                    {
                        SelectListItem selectListItem = new SelectListItem()
                            {Text = item.EmployeeName, Value = item.UserId.ToString()};
                        sel.Add(selectListItem);
                    }
                }
            }
            return Json(sel, JsonRequestBehavior.AllowGet);
        }

        #endregion




        /// <summary>
        /// 获取人员 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPeoplesByCondition()
        {

            string searchType = Request.Params["searchType"];



            List<OaEmployee> oaEmployees = new List<OaEmployee>();


            if (GetRole().Contains(1))
            {

                int userids = -1;
                var ints = CurrentUserDepartmentTrafficeLeaderId();
                if (ints == -1)
                {
                    userids = User.UserId;
                }
                else
                {
                    userids = ints;
                }

                var result = _iTResourceTeamService.GetTrafic(userids);
                if (result != null)
                {
                    var data = _iTResourceTeamService.GetMembers(result.TeamId);
                    if (data.Any())
                    {
                        foreach (var item in data)
                        {
                            var dataRes = _IOaEmployeeService.GetByUid(item.ResourceUid);
                            if (dataRes != null)
                            {
                                oaEmployees.Add(dataRes);
                            }
                        }
                    }
                }
            }
            else if (GetRole().Contains(2))
            {
                var teamLeader = _iTResourceTeamService.GetTeamLeader(GetCureentID());
                if (teamLeader != null)
                {
                    var resOA = _IOaEmployeeService.GetByUid(teamLeader.ResourceUid);
                    if (resOA != null)
                    {
                        oaEmployees.Add(resOA);
                    }
                    var resList = _iTResourceTeamService.GetTeamsList(teamLeader.ResourceId);
                    if (resList.Any())
                    {
                        foreach (var item in resList)
                        {
                            var oa = _IOaEmployeeService.GetByUid(item.ResourceUid);
                            if (oa != null)
                            {
                                oaEmployees.Add(oa);
                            }
                        }

                    }
                }
            }

            //}
          


            List<SelectListItem> sel = new List<SelectListItem>();
            if (oaEmployees.Any())
            {

                foreach (var item in oaEmployees.Distinct().ToList())
                {
                    if (item != null)
                    {
                        if(searchType==DataStatus.SearchMeum.UT)
                        {


                            var resnew = _ITTimesheetService.GetByPid(item.UserId.Value);
                            if (resnew.Any()==false)
                            {


                                SelectListItem selectListItem = new SelectListItem()
                                    {Text = item.EmployeeName, Value = item.UserId.ToString()};
                                sel.Add(selectListItem);
                            }
                        }
                        else if(searchType==DataStatus.SearchMeum.YT)
                        {
                            var resnew = _ITTimesheetService.GetByPid(item.UserId.Value);
                            if (resnew.Any())
                            {


                                SelectListItem selectListItem = new SelectListItem() { Text = item.EmployeeName, Value = item.UserId.ToString() };
                                sel.Add(selectListItem);
                            }
                        }
                        else
                        {
                            SelectListItem selectListItem = new SelectListItem() { Text = item.EmployeeName, Value = item.UserId.ToString() };
                            sel.Add(selectListItem);
                        }
                    }
                }
            }
            return Json(sel, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 获得所有工作人员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPeople()
        {
            List<OaEmployee> oaEmployees = new List<OaEmployee>();

            List<int> res = GetRole();
            if (res.Any())
            {
                foreach (var item in res)
                {
                    #region 1.0 Traffic Leader 下面所有的人员

                    //if (item == 1)
                    //{
                    //  _iTResourceTeamService.GeTeams(User.UserId,item)
                    //}



                    if (item == 1 || item == 2)
                    {
                        var list = _iTResourceTeamService.GetByUid(GetCureentID());
                        if (list.Any())
                        {
                            List<int> teaInts = list.Select(u => u.TeamId).ToList();
                            if (teaInts.Any())
                            {
                                foreach (var itemTeamis in teaInts)
                                {
                                    var listMembers = _iTResourceTeamService.GetMembers(itemTeamis);
                                    if (listMembers.Any())
                                    {
                                        //获得所有员工
                                        var listUsers = listMembers.Select(u => u.ResourceUid).ToList();
                                        if (listUsers.Any())
                                        {
                                            foreach (var userItem in listUsers)
                                            {
                                                var oaModel = _IOaEmployeeService.GetByUid(userItem);
                                                if (oaModel != null)
                                                {
                                                    oaEmployees.Add(oaModel);
                                                }
                                            }
                                        }

                                    }
                                }

                            }

                        }
                    }

                    #endregion


                }

            }
            List<SelectListItem> sel = new List<SelectListItem>();
            if (oaEmployees.Any())
            {

                foreach (var item in oaEmployees.Distinct().ToList())
                {
                    if (item != null)
                    {
                        SelectListItem selectListItem = new SelectListItem()
                            {Text = item.EmployeeName, Value = item.EmployeeId.ToString()};
                        sel.Add(selectListItem);
                    }
                }
            }
            return Json(sel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTeamDetail()
        {
            return View();

        }

        [HttpPost]
        public ActionResult GetDataByTeam(PlanTimeParameter parameters)
        {
           if(parameters.teamID==0)
           {
               this.ShowNotification(NotificationType.Warning,"请选择团队！");
               return null;
           }

           PlanTimeParameter parameter = new PlanTimeParameter() { teamID = parameters.teamID, startDate = Convert.ToDateTime(parameters.startDate.ToString("yyyy-MM-dd")), endingDate = Convert.ToDateTime(parameters.endingDate.ToString("yyyy-MM-dd")) };

            List<FullCalendarModel> res=new List<FullCalendarModel>();
            List<SpGetPlanTime> newres=new List<SpGetPlanTime>();
          var reslist=  _IProjectWorkPlanService.GetPlanTimes(parameter);
         
            foreach (var spGetPlanTime in reslist)
            {
                var result =
                    newres.Where(
                        u => u.endtime == spGetPlanTime.starttime.AddDays(-1) && u.ProjectId == spGetPlanTime.ProjectId).FirstOrDefault();
                if (result!=null)
                {
                    SpGetPlanTime ap=new SpGetPlanTime();
                    ap.starttime = result.starttime;
                   
                    newres.Remove(result);
                    ap.ProjectId = spGetPlanTime.ProjectId;
                    ap.endtime = spGetPlanTime.endtime;

                    newres.Add(ap);

                }
                else
                {
                    newres.Add(spGetPlanTime);
                }
               
            }

            if (newres.Any())
            {
                foreach (var spGetPlanTime in newres)
                {
                    if(spGetPlanTime!=null)
                    {
                        var project = _IProjectService.GetByID(spGetPlanTime.ProjectId);
                        if(project!=null)
                        {
                             FullCalendarModel item=new FullCalendarModel();
                            item.title = project.ProjectName;
                            item.start = spGetPlanTime.starttime.ToString("yyyy-MM-dd");
                            item.end = spGetPlanTime.endtime.ToString("yyyy-MM-dd");
                            res.Add(item);
                        }
                       
                    }
                   
                }
            }

            //FullCalendarModel model1 = new FullCalendarModel();
            //model1.title = "123";
            //model1.start = "2014-06-04";
            //model1.end = "2014-06-07";
            //List<FullCalendarModel> res = new List<FullCalendarModel>();
            //res.Add(model1);
            return AjaxMsgOk("", "", res);


        }

        public ActionResult GetTeams()
        {
            var listTeams = _iTResourceTeamService.GetTrafic(GetCureentID());
            List<SelectListItem> resTeams = new List<SelectListItem>();
            if (listTeams != null)
            {
                var res = _ICtTeamService.GetList(listTeams.TeamId);
                if (res.Any())
                {
                    foreach (var item in res)
                    {
                        resTeams.Add(new SelectListItem() { Text = item.TeamName, Value = Convert.ToString(item.TeamId) });
                    }
                }
            }
            return Json(resTeams, JsonRequestBehavior.AllowGet);
        }
    }
}
