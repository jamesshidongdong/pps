using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity.StoredProcedure
{
    public class BaseProcedure : EntityBase
    {
        protected static SqlParameter ParamVar(string columnName, int? value)
        {
            return value.HasValue
                ? new SqlParameter(columnName, value)
                : new SqlParameter(columnName, DBNull.Value);
        }

        protected static SqlParameter ParamVar(string columnName, string value)
        {
            return value != null
                ? new SqlParameter(columnName, value)
                : new SqlParameter(columnName, DBNull.Value);
        }

        protected static SqlParameter ParamVar(string columnName, DateTime value)
        {
            return value != null
                ? new SqlParameter(columnName, value)
                : new SqlParameter(columnName, DBNull.Value);
        }
    }
}
