using System;
using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class OaEmployee : EntityBase
    {
        public string EmployeeId { get; set; } // EmployeeId (Primary key)
        public string EmployeeName { get; set; } // EmployeeName
        public int? UserId { get; set; } // UserId
        public int? DepartmentId { get; set; } // DepartmentId
        public string JobTitle { get; set; } // JobTitle
        public int? JobGradeId { get; set; } // JobGradeId
        public string ManagerEid { get; set; } // ManagerEid
        public int? ManagerUid { get; set; } // ManagerUid
        public DateTime? EmploymentDate { get; set; } // EmploymentDate
        public DateTime? TerminationDate { get; set; } // TerminationDate
        public bool? Deleted { get; set; } // Deleted
        public string Email { get; set; } // Email
    }
}