using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class CtProjectMileStoneTemplate : EntityBase
    {
        public int Id { get; set; } // Id (Primary key)
        public int? ProjectType { get; set; } // ProjectType
        public string MileStoneName { get; set; } // MileStoneName
    }
}
