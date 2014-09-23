using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class CtMilestone : EntityBase
    {
        public int MilestoneId { get; set; } // MilestoneId (Primary key)
        public int? MilestoneTemplateId { get; set; } // MilestoneTemplateId
        public string Milestone { get; set; } // Milestone
        public int? OrderId { get; set; } // OrderId
    }
}