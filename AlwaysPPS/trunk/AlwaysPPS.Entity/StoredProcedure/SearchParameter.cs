using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Entity.StoredProcedure
{
   public class SearchParameter
    {
       public int userId { get; set; }
       public string ProjectCode { get; set; }
       public string ClientName { get; set; }
       public string Status { get; set; }
       public string State { get; set; }
       public Nullable<int> PageIndex { get; set; }
       public Nullable<int> NumRow { get; set; }
    }
}
