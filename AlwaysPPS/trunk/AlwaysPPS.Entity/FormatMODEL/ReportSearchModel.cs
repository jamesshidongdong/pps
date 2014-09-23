using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Entity.FormatMODEL
{
    public class ReportSearchModel
    {
        public DateTime? StartData { get; set; }
        public DateTime? EndData { get; set; }
        public string createDeptid { get; set; }
        public string clientName { get; set; }
        public string projectName { get; set; }
        public int? page { get; set; }
        public int? pageSize { get; set; }
    }
}
