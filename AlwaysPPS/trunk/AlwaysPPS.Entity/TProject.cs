using System;
using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class TProject : EntityBase
    {
        public int ProjectId { get; set; } // ProjectId (Primary key)
        public string ProjectCode { get; set; } // ProjectCode
        public string ProjectName { get; set; } // ProjectName
        public string ProjectDescription { get; set; } // ProjectDescription
        public string ClientName { get; set; } // ClientName
        public int? SystemId { get; set; } // SystemId
        public int? ProjectTypeId { get; set; } // ProjectTypeId
        public int RequestorUid { get; set; } // RequestorUid
        public int? DepartmentId { get; set; } // DepartmentId
        public DateTime? Deadline { get; set; } // Deadline
        public DateTime RequestedDate { get; set; } // RequestedDate
        public int? AssignedToUid { get; set; } // AssignedToUid
        public string Status { get; set; } // Status
        public string State { get; set; } // State
        public int? UpdatedByUid { get; set; } // UpdatedByUid
        public DateTime? UpdatedDate { get; set; } // UpdatedDate
        public DateTime? DateClosed { get; set; } // DateClosed
        public string Reson { get; set; } // Reson
    }
}