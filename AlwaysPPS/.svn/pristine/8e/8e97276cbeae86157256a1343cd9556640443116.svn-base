using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysPPS.Entity.FormatMODEL;

namespace AlwaysPPS.Entity.StoredProcedure
{
    public class ReportDataByDept : BaseProcedure
    {
        public string DeptName { get; set; }
        public decimal Totalhours { get; set; }

        public const string NAME = "spGetRPGroupByDept @st,@et,@createDeptid,@clientName,@projectName";

        public static SqlParameter[] Parameters(ReportSearchModel pSearchModel)
        {
            SqlParameter[] parameters =
                {
                     ParamVar("@st",pSearchModel.StartData.Value),
                     ParamVar("@et",pSearchModel.EndData.Value),
                     ParamVar("@createDeptid",pSearchModel.createDeptid),
                     ParamVar("@clientName",pSearchModel.clientName),
                     ParamVar("@projectName",pSearchModel.projectName)
                };
            return parameters;
        }

    }
}
