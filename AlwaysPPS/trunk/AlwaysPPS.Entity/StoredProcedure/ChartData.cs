using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AlwaysPPS.Entity.FormatMODEL;

namespace AlwaysPPS.Entity.StoredProcedure
{
    public class ChartData : BaseProcedure
    {
        public string category { get; set; }
        public decimal value { get; set; }

        public const string NAME = "spGetTimeSheetByClient @clientName";

        public static SqlParameter[] ParametersClient(ChartModel model)
        {
            SqlParameter[] parameters = { new SqlParameter("@clientName",model.clientName)};
            return parameters;
        }
    }
}
