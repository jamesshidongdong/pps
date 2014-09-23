using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Entity.StoredProcedure
{
    using  System.Data.SqlClient;
    public  class SpGetPlanTime:BaseProcedure
    {
        public int ProjectId { get; set;}
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }

        public const string NAME = "uspGetPlantime @TeamID,@startDate,@endingDate ";
        
        public  static SqlParameter[] Parameters(PlanTimeParameter parameter)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@TeamID", parameter.teamID),
                    new SqlParameter("@startDate", parameter.startDate),
                    new SqlParameter("@endingDate", parameter.endingDate),
                };
            return parameters;
        }
    }
}
