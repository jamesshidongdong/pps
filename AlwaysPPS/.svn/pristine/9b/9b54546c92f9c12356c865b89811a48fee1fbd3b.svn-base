using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Entity.StoredProcedure
{

    using  System.Data.SqlClient;
    public class SpRPTTeamTimeSheet : BaseProcedure
    {
        public decimal totalHours { get; set; }

        public int uid { get; set; }

        public string content { get; set; }

        public string dep { get; set; }

        public string status { get; set; }

        public DateTime dates { get; set; }


        public const string NAME = "spRPTTeamTimeSheet @FromDate,@ToDate,@UserDeptId,@SubTeamId,@ProjectRequestorDeptId";

        public  static SqlParameter[] Parameters(SpRPTParameter parameter)
        {
            SqlParameter[] parameters =
                {
                      ParamVar("@FromDate",parameter.FromDate),
                ParamVar("@ToDate", parameter.ToDate),
             
                ParamVar("@UserDeptId", parameter.UserDeptId),
                ParamVar("@SubTeamId", parameter.SubTeamId),
                ParamVar("@ProjectRequestorDeptId", parameter.ProjectRequestorDeptId),
            
                };
            return parameters;
        }

    }
}
