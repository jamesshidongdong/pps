using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Entity.StoredProcedure
{
    using  System.Data.SqlClient;
   public  class SpRPTByTeamTimeSheet : BaseProcedure
    {
        public string name { get; set; }
        public string proName { get; set; }

        public string lead { get; set; }

       public const string NAME = "spRPTByTeamTimeSheet @FromDate,@ToDate,@UserDeptId";

       public static SqlParameter[] Parameters(SpRPTByTeamParameter parameter)
       {
           SqlParameter[] parameters =
               {
                     ParamVar("@FromDate",parameter.FromDate),
                ParamVar("@ToDate", parameter.ToDate),
             
                ParamVar("@UserDeptId", parameter.UserDeptId),
               };
           return parameters;
       }
    }
}
