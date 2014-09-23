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
    public interface IReportDataByDept
    {
        List<ReportDataByDept> GetData(ReportSearchModel model);
    }
    public class ReportDataByDepts : IReportDataByDept
    {
        private readonly IRepository<ReportDataByDept> _repository;
        public ReportDataByDepts(IRepository<ReportDataByDept> _repository)
        {
            this._repository = _repository;

        }


        public List<ReportDataByDept> GetData(ReportSearchModel model)
        {
            SqlParameter[] parameters = ReportDataByDept.Parameters(model);
            var res = _repository.ExecuteStoredProcedure(ReportDataByDept.NAME, parameters).ToList();
            return res;
        }
    }
}
