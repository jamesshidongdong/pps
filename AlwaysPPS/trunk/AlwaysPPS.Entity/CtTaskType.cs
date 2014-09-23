using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class CtTaskType : EntityBase
    {
        public string TaskTypeCode { get; set; } // TaskTypeCode (Primary key)
        public string TaskTypeDescription { get; set; } // TaskTypeDescription
    }
}