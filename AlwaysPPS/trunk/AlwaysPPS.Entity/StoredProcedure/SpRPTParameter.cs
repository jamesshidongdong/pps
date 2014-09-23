using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Entity.StoredProcedure
{
    public class SpRPTParameter
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public int UserDeptId { get; set; }

        public string  SubTeamId { get; set; }

        public string ProjectRequestorDeptId { get; set; }
    }
}
