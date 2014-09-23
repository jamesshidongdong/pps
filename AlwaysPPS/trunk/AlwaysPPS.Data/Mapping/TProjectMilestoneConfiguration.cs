using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class TProjectMilestoneConfiguration : EntityTypeConfiguration<TProjectMilestone>
    {
        public TProjectMilestoneConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tProjectMilestone");
            HasKey(x => x.ProjectMilestoneId);

            Property(x => x.ProjectMilestoneId).HasColumnName("ProjectMilestoneId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
            Property(x => x.MilestoneName).HasColumnName("MilestoneName").IsOptional().HasMaxLength(100);
            Property(x => x.PlanStartDate).HasColumnName("PlanStartDate").IsOptional();
            Property(x => x.PlanEndDate).HasColumnName("PlanEndDate").IsOptional();
            Property(x => x.ReviseStartDate).HasColumnName("ReviseStartDate").IsOptional();
            Property(x => x.ReviseEndDate).HasColumnName("ReviseEndDate").IsOptional();
            Property(x => x.ActualStartDate).HasColumnName("ActualStartDate").IsOptional();
            Property(x => x.ActualEndDate).HasColumnName("ActualEndDate").IsOptional();
            Property(x => x.Remarks).HasColumnName("Remarks").IsOptional();
            Property(x => x.Deleted).HasColumnName("Deleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}