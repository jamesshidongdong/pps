using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class CtMilestoneConfiguration : EntityTypeConfiguration<CtMilestone>
    {
        public CtMilestoneConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctMilestone");
            HasKey(x => x.MilestoneId);

            Property(x => x.MilestoneId).HasColumnName("MilestoneId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.MilestoneTemplateId).HasColumnName("MilestoneTemplateId").IsOptional();
            Property(x => x.Milestone).HasColumnName("Milestone").IsOptional().HasMaxLength(100);
            Property(x => x.OrderId).HasColumnName("OrderId").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}