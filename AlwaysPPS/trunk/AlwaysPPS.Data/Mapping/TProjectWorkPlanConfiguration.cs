using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class TProjectWorkPlanConfiguration : EntityTypeConfiguration<TProjectWorkPlan>
    {
        public TProjectWorkPlanConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tProjectWorkPlan");
            HasKey(x => x.ProjectWorkPlanId);

            Property(x => x.ProjectWorkPlanId).HasColumnName("ProjectWorkPlanId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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
            InitializePartial();
        }
        partial void InitializePartial();
    }
}