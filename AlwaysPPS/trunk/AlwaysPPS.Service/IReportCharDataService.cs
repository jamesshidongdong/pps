﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity.FormatMODEL;
using AlwaysPPS.Entity.StoredProcedure;

namespace AlwaysPPS.Service
{
    public interface IReportCharDataService
    {
        List<ReportCharData> GetData(ReportSearchModel model);
    }

    public class ReportCharDataService : IReportCharDataService
    {
        private readonly IRepository<ReportCharData> _repository;
        public ReportCharDataService(IRepository<ReportCharData> _repository)
        {
            this._repository = _repository;

        }
    
        public List<ReportCharData> GetData(ReportSearchModel model)
        {
          SqlParameter[] parameters = ReportCharData.Parameters(model);
          var res=  _repository.ExecuteStoredProcedure(ReportCharData.NAME,parameters).ToList();
         
          return res;

        }
    }
}
