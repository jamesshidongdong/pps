using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;
using AlwaysPPS.Entity.FormatMODEL;
using AlwaysPPS.Library;
using AlwaysPPS.Service;
using Microsoft.Practices.Unity;

namespace AlwaysPPS.Web.Controllers
{
    public class HtmlController : BaseController
    {
#if DEBUG
            //
        // GET: /Report/
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITResourceTeamService _iTResourceTeamService;
        private readonly ICtProjectTypeService _ICtProjectTypeService;
        private readonly IProjectService _IProjectService;
        private readonly IOaEmployeeService _IOaEmployeeService;
        private readonly OaDepartmentService _OaDepartmentService;
        private readonly ITProjectTaskService _ITProjectTaskService;

        public HtmlController(
            [Dependency(UnityIOC.UOF.AlwaysPPS)]IUnitOfWork unitOfWork
            , ITResourceTeamService iTResourceTeamService
            , ICtProjectTypeService iCtProjectTypeService
            , IProjectService iProjectService
            , IOaEmployeeService iOaEmployeeService
            , OaDepartmentService oaDepartmentService
            , ITProjectTaskService _iTProjectTaskService)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _iTResourceTeamService = iTResourceTeamService;
            
            _ICtProjectTypeService = iCtProjectTypeService;
            _IProjectService = iProjectService;
            _IOaEmployeeService = iOaEmployeeService;
            _OaDepartmentService = oaDepartmentService;
        }


        // GET: /Html/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewItem()
        {
            var list = _ICtProjectTypeService.GetTypes();
            if (list.Any())
            {
                var selItems = new List<SelectListItem>();
                foreach (var items in list)
                {
                    if (items != null)
                    {
                        selItems.Add(new SelectListItem() { Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString() });
                    }
                }
                ViewBag.ProType = selItems;
            }
            else
            {
                SelectListItem sel = new SelectListItem();
                ViewBag.ProType = sel;
            }

            return View();
        }

        public ActionResult Milestone()
        {
            return View();
        }

        public ActionResult HumanResourcePlanning()
        {
            return View();
        }

        public ActionResult Folder()
        {
            return View();
        }

        public ActionResult ProjectDetail()
        {



            var list = _ICtProjectTypeService.GetTypes();
            if (list.Any())
            {
                var selItems = new List<SelectListItem>();
                foreach (var items in list)
                {
                    if (items != null)
                    {
                        selItems.Add(new SelectListItem() { Text = items.ProjectTypeDesc, Value = items.ProjectTypeId.ToString() });
                    }
                }
                ViewBag.ProType = selItems;
            }
            else
            {
                SelectListItem sel = new SelectListItem();
                ViewBag.ProType = sel;
            }
            return View();
        }

        //搜索
        public ActionResult  SearchableItems()
        {
            return View();
        }

        public ActionResult ReportOne()
        {
            return View();
        }

        public ActionResult ChartReport()
        {
            return View();
        }

        public  ActionResult GetFullCalendar()
        {
            return View();
        }

        public ActionResult GetFullData()
        {
            //List<FullCalendarModel> res = new List<FullCalendarModel>();
            //FullCalendarModel model = new FullCalendarModel();
            //model.start = Convert.ToDateTime("2014-06-03");
            //model.end = Convert.ToDateTime("2014-06-04");
            //model.title = "今天来打酱油";
            //res.Add(model);
            //ViewBag.Data = res;
            //ViewBag.id = "22";

            //FullCalendarModel model2 = new FullCalendarModel();
            //model2.start = Convert.ToDateTime("2014-06-03");
            //model2.end = Convert.ToDateTime("2014-06-04");
            //model2.title = "今天来打酱油";
            //res.Add(model2);
            //ViewBag.Data = res;
            //ViewBag.id = "22";
            return View();
        }


        public ActionResult GetData()
        {
            //List<FullCalendarModel> res=new List<FullCalendarModel>();
            //FullCalendarModel model=new FullCalendarModel();
            //model.start = DateTime.Now;
            //model.end = DateTime.Now.AddDays(1);
            //model.title = "今天来打酱油";
            //res.Add(model);
            //return Json(res, JsonRequestBehavior.AllowGet);
            return null;
        }
        public ActionResult HourExplain()
        {
            return View();
        }
#endif 
    }
}
