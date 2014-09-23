﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AlwaysFramework.MVC;
using AlwaysFramework.MVC.Extension;
using AlwaysPPS.Business;
using AlwaysPPS.Entity.StoredProcedure;
using AlwaysPPS.Entity.ViewModel;
using AlwaysPPS.Library;
using AlwaysPPS.Library.Constant;
using AlwaysPPS.Service;
using AlwaysPPS.Entity;
using AlwaysFramework.DAL;
using Kendo.Mvc.UI;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using NLog;
using System.Configuration;

namespace AlwaysPPS.Web.Controllers
{
    public class ProjectController : BaseController
    {
        //
        // GET: /Project/
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITResourceTeamService _iTResourceTeamService;        
        private readonly  ICtProjectTypeService _ICtProjectTypeService;
        private readonly IProjectService _IProjectService;
        private readonly IOaEmployeeService _IOaEmployeeService;
        private readonly OaDepartmentService _OaDepartmentService;
        private readonly ITProjectTaskService _ITProjectTaskService;
        private readonly ITProjectMilestoneService _ITProjectMilestoneService;

        private readonly ITTimesheetService _ITTimesheetService;

        private readonly IProjectWorkPlanService _IprojectWorkPalnService;
        private readonly IProjectDocumentService _IprojectDocument;
        private readonly ICtTeamService _ICtTeamService;

        private readonly ICtProjectMileStoneTemplateService _ctProjectMileStoneTemplateService;

        public ProjectController(
            [Dependency(UnityIOC.UOF.AlwaysPPS)]IUnitOfWork unitOfWork
            , ITResourceTeamService iTResourceTeamService
            , ICtProjectTypeService iCtProjectTypeService
            , IProjectService iProjectService
            , IOaEmployeeService iOaEmployeeService
            , OaDepartmentService oaDepartmentService
            , ITProjectTaskService _iTProjectTaskService
            , ITProjectMilestoneService iTProjectMilestoneService
            , IProjectWorkPlanService IprojectWorkPalnService
            , IProjectDocumentService IprojectDocument
            , ITTimesheetService iTTimesheetService
            , ICtTeamService iCtTeamService
            ,ICtProjectMileStoneTemplateService ctProjectMileStoneTemplateService)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _iTResourceTeamService = iTResourceTeamService;
            _ICtProjectTypeService = iCtProjectTypeService;
            _IProjectService = iProjectService;
            _IOaEmployeeService = iOaEmployeeService;
            _OaDepartmentService = oaDepartmentService;
            this._ITProjectMilestoneService = iTProjectMilestoneService;
            this._ITProjectTaskService = _iTProjectTaskService;
            this._ITTimesheetService = iTTimesheetService;
            this._IprojectWorkPalnService = IprojectWorkPalnService;
            this._IprojectDocument = IprojectDocument;
            this._ICtTeamService = iCtTeamService;
            this._ctProjectMileStoneTemplateService = ctProjectMileStoneTemplateService;
        }

        public bool IsCanEdit(int projId)
        {
            
            var res = _IProjectService.GetByID(projId);
            if (res != null)
            {
                if (res.State == DataStatus.ProjectState.closed || res.State == DataStatus.ProjectState.Reject)
                {
                    return false;
                }
            }

      

            return _iTResourceTeamService.IsCanEdit(User.UserId, projId);
        }

        public ActionResult Milestone(int id)
        {
            BindViewBagUser();
            ViewBag.IsCanEdit = IsCanEdit(id);
            string iSrole = "";
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
                        iSrole = "4";
                    }
                    else
                    {
                        //表示是BuHeader
                        iSrole = "5";
                    }
                }
            }
            List<int> roles = GetRole();
            if (roles != null)
            {
                if (roles.Contains(1))
                {
                    ViewBag.role = "1";
                }
                else if (roles.Contains(2))
                {
                    ViewBag.role = "2";
                }
                else
                {
                    ViewBag.role = "3";
                }
            }
            if (iSrole == "4" || iSrole=="5")
            {
                if (ViewBag.role != "1" && ViewBag.role != "2" && ViewBag.role != "3")
                {
                    ViewBag.IsCanEdit = false;
                }
                
            }
            ViewBag.projectID = id;
            return PartialView("Milestone");
        }

        public ActionResult HumanResourcePlanning(int projectId)
        {
            BindViewBagUser();
            ViewBag.IsCanEdit = IsCanEdit(projectId);
            #region 获取权限
            List<int> roles = GetRole();
            if (roles != null)
            {
                if (roles.Contains(1))
                {
                    ViewBag.role = "1";
                }
                else if (roles.Contains(2))
                {
                    ViewBag.role = "2";
                }
                else
                {
                    ViewBag.role = "3";
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
            #endregion

            if (ViewBag.role == "4" || ViewBag.role == "5" || ViewBag.role=="1")
            {
                ViewBag.IsCanEdit = false;
            }
            ViewBag.projectID = projectId;
            return PartialView("HumanResourcePlanning");
        }

        public ActionResult Folder(int projectId)
        {
            BindViewBagUser();
            ViewBag.IsCanEdit = IsCanEdit(projectId);
            ViewBag.projectID = projectId;
            return PartialView("Folder");
        }

       

        //public ActionResult ProjectDetail(int projectId)
        //{
        //    BindViewBagUser();
        //    @ViewBag.IsCanEdit = IsCanEdit(projectId);
        //    var list = _ICtProjectTypeService.GetTypes();
        //    if (list.Any())
        //    {
        //        var selItems = new List<SelectListItem>();
        //        foreach (var items in list)
        //        {
        //            if (items != null)
        //            {
        //                selItems.Add(new SelectListItem() { Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString() });
        //            }
        //        }
        //        ViewBag.ProType = selItems;
        //    }
        //    else
        //    {
        //        SelectListItem sel = new SelectListItem();
        //        ViewBag.ProType = sel;
        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult Add(FormCollection fcCollection)
        {
            string res = fcCollection["models"];
            string pid = fcCollection["projectId"];
            if (string.IsNullOrEmpty(pid) || string.IsNullOrEmpty(res))
            {
                this.ShowNotification(NotificationType.Error, "非法操作,不存在项目");
                return AjaxMsgErr();
            }
            var projectModel = _IProjectService.GetByID(int.Parse(pid));
            if (projectModel == null)
            {
                this.ShowNotification(NotificationType.Error, "项目不存在！");
                return null;
            }
            //if (projectModel.State == DataStatus.ProjectState.pendingByTeamLeader ||
            //    projectModel.State == DataStatus.ProjectState.pendingByTeamLeaderEnd)
            //{
                

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

                List<MileStone> msRes = jsSerializer.Deserialize<List<MileStone>>(res);
                try
                {
                    if (msRes.Any())
                    {
                        foreach (var itemMile in msRes)
                        {
                            TProjectMilestone tm = new TProjectMilestone();
                            if (string.IsNullOrEmpty(itemMile.MilestoneName) || itemMile.ActualEndDate == null)
                            {
                                this.ShowNotification(NotificationType.Error, "不能为空！");
                                return AjaxMsgNoOk();
                            }
                            tm.MilestoneName = itemMile.MilestoneName;
                            tm.ActualEndDate = itemMile.ActualEndDate;
                            tm.ProjectId = int.Parse(pid);
                            //if (_ITProjectMilestoneService.GetMilestone(tm) == null)
                            //{
                                _ITProjectMilestoneService.Add(tm);
                                this.ShowNotification(NotificationType.Success, "新增成功");
                            //}
                            //else
                            //{
                            //    _ITProjectMilestoneService.Update(tm);
                            //    this.ShowNotification(NotificationType.Success, "修改成功");
                            //    //this.ShowNotification(NotificationType.Error, "数据已存在，不允许重复提交！");
                            //    //return null;
                            //}
                           
                        }
                        _unitOfWork.Save();
                      
                        return Json(msRes, JsonRequestBehavior.AllowGet);
                    }
                    return Json(msRes, JsonRequestBehavior.AllowGet);
                }
                catch (Exception err)
                {

                    return AjaxMsgNoOk();
                }
            //}
            //else
            //{
            //    this.ShowNotification(NotificationType.Error, "请先分配团队！");
            //    return null;

            //}
        }

        [HttpGet]
        public ActionResult GetProjectMileByPID(int id)
        {
            var list = _ITProjectMilestoneService.GetListByProjectID(id);
            return Json(list,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Jian(Project project)
        {
            try
            {
                var res = _IProjectService.GetByID(project.projectID);
                res.State = DataStatus.ProjectState.closed;
                res.ProjectName = project.projectName;
                res.ClientName = project.client;
                res.ProjectDescription = project.projectIntroduction;
                _IProjectService.Update(res);
                _unitOfWork.Save();
                this.ShowNotification(NotificationType.Success,"操作成功!");
                return AjaxMsgOk();
            }
            catch (Exception err)
            {
                this.ShowNotification(NotificationType.Error,"操作失败!");
                return AjaxMsgErr();
            }
        }


        /// <summary>
        /// 分配给团队组长
        /// </summary>
        /// <returns></returns>
        public ActionResult ToTeame(Project project)
        {
            //修改主表
            //验证
            if (project.ProjectTeam == 0)
            {
             this.ShowNotification(NotificationType.Warning,"请选择相应的团队");
                return null;
            }

            var proModel = _IProjectService.GetByID(project.projectID);
            if (proModel == null)
            {
                this.ShowNotification(NotificationType.Warning,"项目不存在!");
                return null;
            }
            proModel.State = DataStatus.ProjectState.pendingByTeamLeader;
            //获取团队下的组长
            try
            {
                //获得
                var tra = _iTResourceTeamService.GetLeader(project.ProjectTeam);

                if (tra == null)
                {
                    this.ShowNotification(NotificationType.Warning, "组长不存在！");
                    return null;

                }
                proModel.AssignedToUid = tra.ResourceUid;
                proModel.Status = "A";
                proModel.UpdatedByUid = User.UserId;
                proModel.UpdatedDate = DateTime.Now;
                proModel.ProjectName = project.projectName;
                proModel.ClientName = project.client;
                proModel.ProjectDescription = project.projectIntroduction;
                _IProjectService.Update(proModel);

                //修改tProjectTask 信息
                var taskModel = _ITProjectTaskService.GetTask(project.projectID, User.UserId);
                if (taskModel!=null)
                {
                    taskModel.Status = "C";
                    taskModel.UpdatedByUid = User.UserId;
                    taskModel.UpdatedDate = DateTime.Now;
                    _ITProjectTaskService.Update(taskModel);
                }

                #region 发送邮件
                var oa = _IOaEmployeeService.GetByUid(proModel.AssignedToUid.Value);
                var pt = _ICtProjectTypeService.GetByID(proModel.ProjectTypeId.Value);
                var dept = _OaDepartmentService.GetByDepartmentID(proModel.DepartmentId.Value);
                string url = ConfigurationManager.AppSettings["ppsurl"].ToString();
                if (oa != null && pt != null && dept != null)
                {
                    try
                    {
                        base.SendEmail(oa.Email, "等待您分配团队",
                                        "Dear "
                                        + oa.EmployeeName +
                                        ": <br/> &nbsp;&nbsp;您有一个项目需要去安排人员,请登录项目管理系统查看:<a href='" + url + "'>PPS系统</a> <br/><br/>项目名称:" + proModel.ProjectName
                                        + "<br/> 项目编号:" + proModel.ProjectCode
                                        + "<br/> 客户:" + proModel.ClientName
                                        + "<br/>项目类别:" + pt.ProjectTypeDesc
                                        + "<br/>部门:" + dept.DepartmentName
                                         + "<br/>项目介绍:" + proModel.ProjectDescription +
                                        " <br/><br/><br/> 来自项目管理系统<br/>" + DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    catch (Exception err)
                    {
                        
                       
                    }
                }
                #endregion

                //新增tProjectTask 信息
                TProjectTask newtaskModel = new TProjectTask();
                newtaskModel.ProjectId = project.projectID;
                newtaskModel.AssigneeUid = tra.ResourceUid;
                //Pending Resource Allocation by Team Leader(待组长安排任务)
                newtaskModel.TaskTypeCode = "PendingResourceAllocation";
                newtaskModel.Status = "P";
                newtaskModel.Decision = "A";
                newtaskModel.CreatedByUid = User.UserId;
                newtaskModel.CreatedDate = DateTime.Now;
                _ITProjectTaskService.Add(newtaskModel);


                //更新基础数据


                var res = _ctProjectMileStoneTemplateService.GetByPtype(proModel.ProjectTypeId.Value);
                if (res.Any())
                {
                    var templateMile = _ctProjectMileStoneTemplateService.GetByPtype(proModel.ProjectTypeId.Value);
                    if (templateMile.Any())
                    {
                        foreach (var ctProjectMileStoneTemplate in templateMile)
                        {
                            TProjectMilestone model = new TProjectMilestone() { ProjectId = project.projectID, MilestoneName = ctProjectMileStoneTemplate.MileStoneName, ActualEndDate = DateTime.Now };
                            _ITProjectMilestoneService.Add(model);
                        }
                    }

                }
         

                this.ShowNotification(NotificationType.Success, "操作成功！");
                base._unitOfWork.Save();
                return AjaxMsgOk();
            }
            catch (Exception err)
            {
                
             this.ShowNotification(NotificationType.Error,"服务器内部错误"+err.Message);
                return AjaxMsgErr();
            }
        }

        public ActionResult AddTimeSheet(List<TTimesheet> models)
        {
            try
            {
                foreach (var item in models)
                {
                    if (item.ResourceUid != 0 && item.ProjectId != 0 &&
                        item.Day != Convert.ToDateTime("0001/1/1 0:00:00"))
                    {
                        var timeModel = _ITTimesheetService.GeTimesheet(item);
                        //不存在就新增
                        if (timeModel == null)
                        {
                            item.UpdatedDate = DateTime.Now;
                            item.UpdatedByUid = User.UserId;
                            if (item.NumOfHours !=null)
                            {
                                _ITTimesheetService.Add(item);
                            }
                            
                        }
                            //存在就修改
                        else
                        {
                            timeModel.NumOfHours = item.NumOfHours;
                            timeModel.UpdatedDate = DateTime.Now;
                            timeModel.UpdatedByUid = User.UserId;
                            _ITTimesheetService.Update(timeModel);
                        }
                    }

                }
                base._unitOfWork.Save();
                this.ShowNotification(NotificationType.Success, "操作成功！");
                return AjaxMsgOk();
            }
            catch (Exception err)
            {
                
               this.ShowNotification(NotificationType.Error,"操作失败"+err.Message);
                return AjaxMsgErr();
            }
        }
        
        #region 项目时间表 施冬冬
        [HttpGet]
        public ActionResult GetMilestone(int projectId)
        {
            var res = _ITProjectMilestoneService.GetListByProjectID(projectId);
            return Json(res, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateMilestone(MileStone workPlan)
        {
            string res = Request["models"];
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<MileStone> list = jsSerializer.Deserialize<List<MileStone>>(Request["models"]);
                int projectId = int.Parse(Request["projectId"]);

                #region logic :insert & update

                foreach (var e in list)
                {
                    if (e.ProjectMilestoneId == 0)
                    {
                        //新增
                        TProjectMilestone model = new TProjectMilestone()
                        {
                            ProjectId = projectId,
                            MilestoneName = e.MilestoneName,
                            ActualEndDate = e.ActualEndDate,

                        };
                        _ITProjectMilestoneService.Add(model);
                    }
                    else
                    {
                        //修改
                        TProjectMilestone model = new TProjectMilestone()
                        {
                            ProjectMilestoneId = e.ProjectMilestoneId.Value,
                            ProjectId = e.ProjectId.Value,
                            MilestoneName = e.MilestoneName,
                            ActualEndDate = e.ActualEndDate,

                        };
                        _ITProjectMilestoneService.Update(model);
                    }
                }

                _unitOfWork.Save();
                #endregion

                this.ShowNotification(NotificationType.Success, "修改保存成功");

                return AjaxMsgOk();
            }
            catch (Exception ex)
            {
                this.ShowNotification(NotificationType.Error, ex.Message);
                return AjaxMsgNoOk();
            }

        }

        /// <summary>
        /// 删除项目时间表
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteMilestone()
        {
            try
            {

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<MileStone> list = jsSerializer.Deserialize<List<MileStone>>(Request["models"]);
                int projectId = int.Parse(Request["projectId"]);
                foreach (var e in list)
                {
                    if (e.ProjectMilestoneId != 0)
                    {
                        //修改
                        TProjectMilestone model = new TProjectMilestone();
                        model = _ITProjectMilestoneService.GetByid(e.ProjectMilestoneId.Value);
                        if (model != null)
                        {
                            model.Deleted = true;
                        }
                        _ITProjectMilestoneService.Update(model);
                    }
                }

                _unitOfWork.Save();
                this.ShowNotification(NotificationType.Success, "删除成功");
                return AjaxMsgOk();
            }
            catch (Exception ex)
            {
                this.ShowNotification(NotificationType.Error, ex.Message);
                return AjaxMsgNoOk();
            }
        }


        #endregion

        [HttpGet]
        public ActionResult GetMyProjectDetail(int id)
        {



            BindViewBagUser();
            var ortmp = _IOaEmployeeService.GetByUid(User.UserId);
            if (ortmp != null)
            {
                if(ortmp.DepartmentId==SystemRoles.LoveDesign)
                {
                    ViewBag.isLoveDesing = false;
                }
                var deptModel = _OaDepartmentService.GetByDepartmentID(ortmp.DepartmentId.Value);
                if (deptModel != null)
                {
                    if (deptModel.DepartmentHeadUid == User.UserId)
                    {
                        //表名是组长
                        ViewBag.isBuhead = "1";
                    }
                }
            }
          
            List<int> roles = GetRole();
            if (roles != null)
            {
                if (roles.Contains(1))
                {
                    ViewBag.role = "1";
                }
                else if (roles.Contains(2))
                {
                    ViewBag.role = "2";
                }
                else
                {
                    ViewBag.role = "3";
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
      

            var projectmodel = _IProjectService.GetByID(id);
            if (projectmodel != null)
            {
               
                ViewBag.project = projectmodel;
                ViewBag.RequestTime = projectmodel.RequestedDate.ToString("yyyy-MM-dd");
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
                        if (projectmodel!=null)
                        {
                        if (projectmodel.ProjectTypeId == items.ProjectTypeId)
                        {
                            ViewBag.selectedItems = items.ProjectTypeId.ToString();
                            ViewBag.selectdDeparts = items.DepartmentId.ToString();
                            selItems.Add(new SelectListItem() { Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString(), Selected = true });
                        }
                        else
                        {
                            selItems.Add(new SelectListItem() { Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString() });
                        }
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
            var listTeams = _iTResourceTeamService.GetTrafic(User.UserId);
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
            ViewBag.teams = resTeams;


            var taskModels = _ITProjectTaskService.GTaskHavedTeamLead(id);
            if (taskModels != null)
            {
                //获得组长ID
                int uid = taskModels.AssigneeUid.Value;
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
   



            //var taskModel = _ITProjectTaskService.GTaskHavedTeamLead(id);
            //if (taskModel != null)
            //{
            //    //获得组长ID
            //    int uid = taskModel.AssigneeUid.Value;
            //   var model=  _iTResourceTeamService.GeTeams(uid, 2).FirstOrDefault();
            //    if (model != null)
            //    {
            //        var teamModel = _ICtTeamService.GeTeams(model.TeamId);
            //        if (teamModel != null)
            //        {
            //            ViewBag.teamName = teamModel.TeamName;
            //        }
            //    }
            //}

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
            return View();


            
        }
        
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        public List<int> GetRole()
        {
            var resList = _iTResourceTeamService.GetByUid(User.UserId);
            if (resList.Any())
            {
                return resList.Select(u => u.RoleId).ToList();
            }
            return null;
        }






        #region 工作安排 &  文件上传   -TONG.XU

        #region 资源
        //新增资源规划
        public ActionResult AddHumanPalnning()
        {
             List<WorkPlan> list= new List<WorkPlan>();
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                list = jsSerializer.Deserialize<List<WorkPlan>>(Request["models"]);
                if (Request["projectId"] == null)
                {
                    //this.ShowNotification(NotificationType.Error, "参数错误");
                    return AjaxMsgNoOk("参数错误");
                }
                int projectId = int.Parse(Request["projectId"]);
               
                #region logic :insert & update
                foreach (var e in list)
                {
                    if (e.ProjectWorkPlanId == null)
                    {
                        if (e.PlanStartDate > e.PlanEndDate)
                        {
                            this.ShowNotification(NotificationType.Error, "计划开始时间不能大于计划结束时间");
                            return Json(null, JsonRequestBehavior.AllowGet);
                        }
                        var existing = _IprojectWorkPalnService.IsHumanExistWorkPlan(projectId, e.teamMember.ResourceUid,0);
                        if (!existing)
                        {
                            //新增
                            TProjectWorkPlan model = new TProjectWorkPlan()
                            {
                                ProjectId = projectId,
                                ResourceUid = e.teamMember.ResourceUid,
                                Task = e.Task,
                                PlanStartDate = e.PlanStartDate,
                                PlanEndDate = e.PlanEndDate,
                                PlanEffort = e.PlanEffort
                            };
                        
                            _IprojectWorkPalnService.AddWorkPlan(model);
                        }
                        else
                        {
                            this.ShowNotification(NotificationType.Error, e.teamMember.EmployeeName + "已有工作计划");
                            //return AjaxMsgNoOk(e.teamMember.EmployeeName + "已有工作计划");
                            return Json(null, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                #endregion
                
                var projectE = _IProjectService.GetByID(projectId);
                if (projectE != null)
                {
                    //这里要同步更新tProject表，使数据为 进行中=[待结案]
                    projectE.State = DataStatus.ProjectState.pendingByTeamLeaderEnd;
                    _IProjectService.Update(projectE);

                    //TeamLeader分配人员时，update 自己的待分配数据为完成分配：Completed
                    bool res = _ITProjectTaskService.UpdateCompletedByTeamLeader(projectId, User.UserId);

                    if (res)
                    {
                        //此处批量save
                        _unitOfWork.Save();
                      
                        #region 发送邮件

                        var oa = _IOaEmployeeService.GetByUid(projectE.RequestorUid);
                        var pt = _ICtProjectTypeService.GetByID(projectE.ProjectTypeId.Value);
                        var dept = _OaDepartmentService.GetByDepartmentID(projectE.DepartmentId.Value);


                        //获取traffic id
                        var trafficuid = _ITProjectTaskService.GetTraffice(projectId);

                        var buID = _ITProjectTaskService.GetBuHeader(projectId); 
                        string url = ConfigurationManager.AppSettings["ppsurl"].ToString();
                        if (oa != null && pt != null && dept != null)
                        {
                            try
                            {
                                List<string> emailres=new List<string>();
                                if(trafficuid!=null)
                                {
                                    var tid = _IOaEmployeeService.GetByUid(trafficuid.AssigneeUid.Value);
                                    if(tid!=null)
                                    {
                                        emailres.Add(tid.Email);
                                    }

                                }
                                if (buID!=null)
                                {
                                    var tid = _IOaEmployeeService.GetByUid(buID.AssigneeUid.Value);
                                    if (tid != null)
                                    {
                                        emailres.Add(tid.Email);
                                    }
                                }




                                try
                                {
                                    base.SendEmail(oa.Email, "项目通知",
                                                                          "Dear "
                                                                          + oa.EmployeeName +
                                                                          ": <br/> &nbsp;&nbsp;您创建的项目已经开始分配人员,请登录项目管理系统查看:<a href='" + url + "'>PPS系统</a> <br/><br/>项目名称:" + projectE.ProjectName
                                                                          + "<br/> 项目编号:" + projectE.ProjectCode
                                                                          + "<br/> 客户:" + projectE.ClientName
                                                                          + "<br/>项目类别:" + pt.ProjectTypeDesc
                                                                          + "<br/>部门:" + dept.DepartmentName
                                                                           + "<br/>项目介绍:" + projectE.ProjectDescription +
                                                                          " <br/><br/><br/> 来自项目管理系统<br/>" + DateTime.Now.ToString("yyyy-MM-dd"), emailres);
                                }
                                catch (Exception err)
                                {
                                    
                                    this.ShowNotification(NotificationType.Error,err.Message);
                                }
                            }
                            catch (Exception err)
                            {


                            }
                        }
                        #endregion
                        this.ShowNotification(NotificationType.Success, "新增保存成功");
                        return Json(list, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        this.ShowNotification(NotificationType.Error, "任务更新错误");
                        //return AjaxMsgNoOk("任务更新错误");
                        return Json(null, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    this.ShowNotification(NotificationType.Error, "项目编号错误");
                    //return AjaxMsgNoOk("项目编号错误");
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                this.ShowNotification(NotificationType.Error, ex.Message);
                //return AjaxMsgNoOk(ex.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
           
           
        }



        //获取资源规划
        public ActionResult GetHumanPlanning(int projectId)
        {
            var model = _IprojectWorkPalnService.GetWorkPlanByProjectId(projectId);
            List<WorkPlan> list = new List<WorkPlan>();
            foreach (var e in model)
            {
                list.Add(new WorkPlan()
                {
                    ProjectWorkPlanId = e.ProjectWorkPlanId,
                    ProjectId = e.ProjectId,
                    ResourceUid = e.ResourceUid,
                    Task = e.Task,
                    PlanStartDate = e.PlanStartDate,
                    PlanEndDate = e.PlanEndDate,
                    PlanEffort = e.PlanEffort,
                    EmployeeName = e.EmployeeName,
                    ActualEffort = e.ActualEffort,
                    teamMember = new TeamMember() { ResourceUid = e.ResourceUid, EmployeeName = e.EmployeeName }
                });
            }
            ViewData["EMP"] = GetAllTeamMembers();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //更新资源规划
        public ActionResult UpdateHumanPlanning(WorkPlan workPlan)
        {
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<WorkPlan> list = jsSerializer.Deserialize<List<WorkPlan>>(Request["models"]);
                int projectId = int.Parse(Request["projectId"]);

                #region logic :insert & update

                foreach (var e in list)
                {
                    if (e.ProjectWorkPlanId != null)
                    {
                        if (e.PlanStartDate > e.PlanEndDate)
                        {
                            this.ShowNotification(NotificationType.Error, "计划开始时间不能大于计划结束时间");
                            return Json(null, JsonRequestBehavior.AllowGet);
                        }
                        var existing = _IprojectWorkPalnService.IsHumanExistWorkPlan(projectId, e.teamMember.ResourceUid,e.ProjectWorkPlanId.Value);
                        if (!existing)
                        {
                            //修改
                            TProjectWorkPlan model = new TProjectWorkPlan()
                            {
                                ProjectWorkPlanId = e.ProjectWorkPlanId.Value,
                                ProjectId = e.ProjectId.Value,
                                ResourceUid = e.teamMember.ResourceUid,
                                Task = e.Task,
                                PlanStartDate = e.PlanStartDate,
                                PlanEndDate = e.PlanEndDate,
                                PlanEffort = e.PlanEffort,
                                ActualEffort = e.ActualEffort,
                            };
                            _IprojectWorkPalnService.UpdateWorkPlan(model);
                        }
                        else
                        {
                            this.ShowNotification(NotificationType.Error, e.teamMember.EmployeeName + "已有工作计划");
                            return AjaxMsgNoOk(e.teamMember.EmployeeName + "已有工作计划");
                        }
                    }
                }

                _unitOfWork.Save();
                #endregion

                this.ShowNotification(NotificationType.Success, "修改保存成功");
                return AjaxMsgOk();
            }
            catch (Exception ex)
            {
                this.ShowNotification(NotificationType.Error, ex.Message);
                return AjaxMsgNoOk();
            }

        }
 
        //更新资源规划-删除(批量删除接口ok)
        public ActionResult DeleteHumanPlanning()
        {
            try
            {

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<WorkPlan> list = jsSerializer.Deserialize<List<WorkPlan>>(Request["models"]);
                int projectId = int.Parse(Request["projectId"]);
                foreach (var e in list)
                {
                    if (e.ProjectWorkPlanId != 0)
                    {
                        //修改
                        TProjectWorkPlan model = new TProjectWorkPlan();
                        model = _IprojectWorkPalnService.GetWorkPlan(e.ProjectWorkPlanId.Value);
                        if (model != null)
                        {
                            model.Deleted = true;
                        }
                        _IprojectWorkPalnService.UpdateWorkPlan(model);
                    }
                }

                _unitOfWork.Save();
                this.ShowNotification(NotificationType.Success, "删除成功");
                return AjaxMsgOk();
            }
            catch (Exception ex)
            {
                this.ShowNotification(NotificationType.Error, ex.Message);
                return AjaxMsgNoOk();
            }
        }

        //获取成员-【下拉列表】
        public ActionResult GetAllTeamMembers()
        {
            //int LeadUid = 2;//当前登录人的Id(PS：此功能仅用于teamLeader使用)
            var model = _IprojectWorkPalnService.GeTeamMembers(User.UserId);
            //List<SelectListItem> items = new List<SelectListItem>();
            //foreach (var e in model)
            //{
            //    items.Add(new SelectListItem()
            //    {
            //        Text = e.EmployeeName,
            //        Value = e.ResourceUid.ToString()
            //    });
            //}
            //return Json(items, JsonRequestBehavior.AllowGet);
            List<TeamMember> items = new List<TeamMember>();
            if (model != null)
            {
                foreach (var e in model)
                {
                    items.Add(new TeamMember()
                    {
                        ResourceUid = e.ResourceUid,
                        EmployeeName = e.EmployeeName
                    });

                }
            }
           
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //***********************************************************************************
        #region 文件
        //项目类型
        public ActionResult GetDocType()
        {
            var model = _IprojectDocument.GetAllDocumentType();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var e in model)
            {
                items.Add(new SelectListItem()
                {
                    Text = e.DocumentType,
                    Value = e.DocumentType
                });
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        //上传文件
        [HttpPost]
        public ActionResult SaveFile()
        {
            try
            {
                if (Request.Files[0] != null)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string OriginName = fileName.Substring(0, fileName.LastIndexOf('.'));

                    string StrName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string StrType = fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
                    fileName = StrName + StrType;
                    //创建文件夹
                    string folderName = ConfigurationManager.AppSettings["UploadPath"];
                    CreateFolder(folderName);
                    //save文件
                    Request.Files[0].SaveAs(Server.MapPath(folderName) + fileName);
                    
                    string _Url = folderName.Replace("\\", "/") + fileName;
                    _Url = _Url.Replace("~", "");
                    System.Web.HttpContext.Current.Session.Add("fileUrl", _Url);
                    System.Web.HttpContext.Current.Session.Add("fileName", OriginName);
                }
                this.ShowNotification(NotificationType.Success, "上传成功");
                return AjaxMsgOk();
            }
            catch (Exception ex)
            {
                this.ShowNotification(NotificationType.Error, "上传失败");
                return AjaxMsgNoOk();
            }
        }
        //新增文件-单条
        [HttpPost]
        public ActionResult AddProjectDoc(string docType, string projectId)
        {
            try
            {
                if (Request.Files[0] != null && !string.IsNullOrEmpty(docType) && !string.IsNullOrEmpty(projectId))
                {
                    //----上传
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string OriginName = fileName.Substring(0, fileName.LastIndexOf('.'));

                    string StrName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string StrType = fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
                    fileName = StrName + StrType;
                    //创建文件夹
                    string folderName = ConfigurationManager.AppSettings["UploadPath"];
                    CreateFolder(folderName);
                    //save文件
                    Request.Files[0].SaveAs(Server.MapPath(folderName) + fileName);

                    string _Url = folderName.Replace("\\", "/") + fileName;
                    _Url = _Url.Replace("~", "");
                    System.Web.HttpContext.Current.Session.Add("fileUrl", _Url);
                    System.Web.HttpContext.Current.Session.Add("fileName", OriginName);
                    //------

                    string url = _Url;
                    string name = OriginName;
                    TProjectDocument doc = new TProjectDocument()
                    {
                        ProjectId = !string.IsNullOrEmpty(projectId) ? int.Parse(projectId) : 0,
                        DocumentType = docType,
                        DocumentName = name,
                        DocumentFileName = url,
                        UploadedDate = DateTime.Now,
                        UploadedByUid = User.UserId
                    };
                    _IprojectDocument.AddProjectDocument(doc);
                    _unitOfWork.Save();
                    this.ShowNotification(NotificationType.Success, "文件保存成功");
                    //return AjaxMsgNoOk();
                }
                else
                {
                    this.ShowNotification(NotificationType.Warning, "数据异常");
                    //return AjaxMsgNoOk();
                }
            }
            catch (Exception ex)
            {
                this.ShowNotification(NotificationType.Error, ex.Message);
                //return AjaxMsgNoOk();
            }

            HttpContext.Response.Redirect("/Project/GetMyProjectDetail?id=" + projectId);
            return null;


        }
        //获取本项目文件
        public ActionResult GetProjectDoc(int projectId)
        {
            var model = _IprojectDocument.GetAllDocuments(projectId);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //更新文件 -删除
        public ActionResult DeleteProjectDoc(int projectId)//行内单条删除可行么？---可行
        {
            try
            {
                _IprojectDocument.DeleteProjectDocument(projectId);
                _unitOfWork.Save();
                this.ShowNotification(NotificationType.Success, "删除成功");
                return AjaxMsgOk();
            }
            catch (Exception ex)
            {
                this.ShowNotification(NotificationType.Error, "删除失败");
                return AjaxMsgNoOk();
            }
        }

        //创建文件夹
        private void CreateFolder(string folderName)
        {
            folderName = Server.MapPath(folderName);

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }

        #endregion

        #endregion


        public ActionResult DownloadDocument(int documentId)
        {
            //get data from service
            var res = _IprojectDocument.GetDocumentTypeByID(documentId);
            if (res != null)
            {
              var  fullPath= Server.MapPath(res.DocumentFileName);
              string[] resname=  res.DocumentFileName.Split('/');
                return File(res.DocumentFileName, MimeMapping.GetMimeMapping(fullPath), resname[2]);
            }
            return null;

            //string documentFilePathAndName = "/Upload/20140429141836.xlsx";

            //var fullPath = Server.MapPath(documentFilePathAndName);

            //return File("D:\\11.sql", MimeMapping.GetMimeMapping(fullPath), "11.sql");

        }

        private const string FILE_DOWNLOAD_COOKIE_NAME = "fileDownload";

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            CheckAndHandleFileResult(filterContext);
            base.OnResultExecuting(filterContext);
        }

        /// <summary>
        /// If the current response is a FileResult (an MVC base class for files) then write a
        /// cookie to inform jquery.fileDownload that a successful file download has occured
        /// </summary>
        /// <param name="context"></param>
        private void CheckAndHandleFileResult(ResultExecutingContext context)
        {
            if (context.Result is FileResult)
                //jquery.fileDownload uses this cookie to determine that a file download has completed successfully
                Response.SetCookie(new HttpCookie(FILE_DOWNLOAD_COOKIE_NAME, "true") { Path = "/" });
            else
                //ensure that the cookie is removed in case someone did a file download without using jquery.fileDownload
                if (Request.Cookies[FILE_DOWNLOAD_COOKIE_NAME] != null)
                    Response.Cookies[FILE_DOWNLOAD_COOKIE_NAME].Expires = DateTime.Now.AddYears(-1);
        }



        public ActionResult GetTeamDetail()
        {
            var listTeams = _iTResourceTeamService.GetTrafic(User.UserId);
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
            ViewBag.teams = resTeams;
            return View();
        }

        /// <summary>
        /// 获取所有提交类型
        /// </summary>
        /// <returns></returns>
        public  ActionResult GetSearchTypes()
        {
            List<SelectListItem> resTeams = new List<SelectListItem>();
            SelectListItem utijiao = new SelectListItem() { Text = DataStatus.SearchTypes.utijiao, Value = "1" };
            SelectListItem itemall = new SelectListItem() { Text = DataStatus.SearchTypes.SerAll,Value = "0"};
            SelectListItem Tijiao = new SelectListItem() { Text = DataStatus.SearchTypes.Tijiao, Value = "2" };

            resTeams.Add(utijiao);
            resTeams.Add(itemall);
            resTeams.Add(Tijiao);
            return Json(resTeams, JsonRequestBehavior.AllowGet);
        }

    }
}
