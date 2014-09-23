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
   public interface IReportDataByClient
    {
       List<ReportDataByClient> GetData(ReportSearchModel model);
    }

    public class ReportDataByClients : IReportDataByClient
    {
        private readonly IRepository<ReportDataByClient> _repository;
        public ReportDataByClients(IRepository<ReportDataByClient> _repository)
        {
            this._repository = _repository;

        }
        public List<ReportDataByClient> GetData(ReportSearchModel model)
        {
            SqlParameter[] parameters = ReportDataByClient.Parameters(model);
            var res = _repository.ExecuteStoredProcedure(ReportDataByClient.NAME, parameters).ToList();
            return res;
        }
    }
}
