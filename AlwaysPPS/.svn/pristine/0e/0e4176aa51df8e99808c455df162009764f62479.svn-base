using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    using System.Data.SqlClient;
    public interface ITTimesheetService
    {
        void Add(TTimesheet model);
        TTimesheet GeTimesheet(TTimesheet model);
        void Update(TTimesheet model);

        /// <summary>
        /// 判断当前人员是否在项目中
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        bool IsContainsUID(int uid);


        List<TTimesheet> GetByPid(int uid);
        double GetTime(int pid, int uid);
    }

    public  class TTimesheetService:ITTimesheetService
    {
        private readonly IRepository<TTimesheet> _TTimesheet;
        public TTimesheetService(IRepository<TTimesheet> iTimesheet)
        {
            this._TTimesheet = iTimesheet;
        }

        public void Add(TTimesheet model)
        {
            _TTimesheet.Insert(model);
        }

        public TTimesheet GeTimesheet(TTimesheet model)
        {
         return    _TTimesheet.Query()
                .Filter(x => x.Day == model.Day && x.ResourceUid == model.ResourceUid && x.ProjectId == model.ProjectId)
                .Get().OrderByDescending(u=>u.UpdatedDate)
                .FirstOrDefault();
        }

        public void Update(TTimesheet model)
        {
            _TTimesheet.Update(model);
        }


        public bool IsContainsUID(int uid)
        {
          var res=  _TTimesheet.Query().Filter(u => u.ResourceUid == uid).Get().ToList();
            if (res.Any())
            {
                return true;
            }
            return false;
        }

        public List<TTimesheet> GetByPid(int uid)
        {
            DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            return _TTimesheet.Query().Filter(u => u.ResourceUid == uid && u.Day >= dt).Get().ToList();
        }

        public double GetTime(int pid,int uid)
        {
            double time = 0.00;
           var res= _TTimesheet.Query().Filter(u => u.ProjectId == pid && u.ResourceUid == uid).Get().ToList();
           if(res.Any())
           {
               foreach (var timesheet in res)
               {
                   if(timesheet!=null)
                   {
                       time = time + Convert.ToDouble(timesheet.NumOfHours);
                   }
                 
               }
           }
            return time;
        }
    }
}
