using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class VProjectWorkPlanConfiguration : EntityTypeConfiguration<VProjectWorkPlan>
    {
        public VProjectWorkPlanConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".V_ProjectWorkPlan");
            HasKey(x => new { x.ProjectWorkPlanId, x.ProjectId, x.ResourceUid });

            Property(x => x.ProjectWorkPlanId).HasColumnName("ProjectWorkPlanId").IsRequired();
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
            Property(x => x.ResourceUid).HasColumnName("ResourceUid").IsRequired();
            Property(x => x.Task).HasColumnName("Task").IsOptional().HasMaxLength(1000);
            Property(x => x.PlanStartDate).HasColumnName("PlanStartDate").IsOptional();
            Property(x => x.PlanEndDate).HasColumnName("PlanEndDate").IsOptional();
            Property(x => x.ActualStartDate).HasColumnName("ActualStartDate").IsOptional();
            Property(x => x.ActualEndDate).HasColumnName("ActualEndDate").IsOptional();
            Property(x => x.PlanEffort).HasColumnName("PlanEffort").IsOptional().HasPrecision(18, 2);
            Property(x => x.ActualEffort).HasColumnName("ActualEffort").IsOptional().HasPrecision(18, 2);
            Property(x => x.Remarks).HasColumnName("Remarks").IsOptional();
            Property(x => x.Deleted).HasColumnName("Deleted").IsOptional();
            Property(x => x.EmployeeName).HasColumnName("EmployeeName").IsOptional().HasMaxLength(100);
            Property(x => x.ProjectName).HasColumnName("ProjectName").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}