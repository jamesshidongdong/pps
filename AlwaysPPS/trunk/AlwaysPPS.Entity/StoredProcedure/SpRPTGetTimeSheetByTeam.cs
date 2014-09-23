using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AlwaysPPS.Entity.StoredProcedure
{

   
    public  class SpRPTGetTimeSheetByTeam:BaseProcedure
    {
        public string proName { get; set; }
        public string pTime { get; set; }
        public string fTime { get; set; }

        public const string NAME = "spRPTGetTimeSheetByTeam @beginTime,@endTime,@department";

        public static SqlParameter[] Parameters(GetTimeSheetParameter parameter)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@beginTime",parameter.BeginTime),
                    new SqlParameter("@endTime",parameter.EndTime),
                    new SqlParameter("@department",parameter.Dpartment), 

                };
            return parameters;
        }
    }
}
