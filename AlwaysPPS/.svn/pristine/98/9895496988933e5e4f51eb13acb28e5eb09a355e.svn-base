using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AlwaysPPS.Entity.FormatMODEL;

namespace AlwaysPPS.Entity.StoredProcedure
{
    /// <summary>
    /// 报表数据
    /// </summary>
    public class ReportCharData : BaseProcedure
    {
       public string ClientName { get; set; }
       public string DepartmentName { get; set; }
       public string ProjectName { get; set; }
       public decimal Totalhours { get; set; }
       public int TotalCount { get; set; }

        public const string NAME = "spGetRD @st,@et,@createDeptid,@clientName,@projectName,@PageIndex,@NumRow";

        public static SqlParameter[] Parameters(ReportSearchModel pSearchModel)
        {
            SqlParameter[] parameters =
                {
                     ParamVar("@st",pSearchModel.StartData.Value),
                     ParamVar("@et",pSearchModel.EndData.Value),
                     ParamVar("@createDeptid",pSearchModel.createDeptid),
                     ParamVar("@clientName",pSearchModel.clientName),
                     ParamVar("@projectName",pSearchModel.projectName),
                     ParamVar("@PageIndex",pSearchModel.page),
                     ParamVar("@NumRow",pSearchModel.pageSize),
                };
            return parameters;
        }
    }
}
