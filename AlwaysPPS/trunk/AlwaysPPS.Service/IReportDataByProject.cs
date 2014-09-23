using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity.FormatMODEL;
using AlwaysPPS.Entity.StoredProcedure;

namespace AlwaysPPS.Service
{
    public interface IReportDataByProject
    {
        List<ReportDateByProject> GetData(ReportSearchModel model);
    }
    public class ReportDataByProjects : IReportDataByProject
    {
        private readonly IRepository<ReportDateByProject> _repository;
        public ReportDataByProjects(IRepository<ReportDateByProject> _repository)
        {
            this._repository = _repository;

        }


        public List<ReportDateByProject> GetData(ReportSearchModel model)
        {
            SqlParameter[] parameters = ReportDateByProject.Parameters(model);
            var res = _repository.ExecuteStoredProcedure(ReportDateByProject.NAME, parameters).ToList();
            return res;
        }
    }
}
