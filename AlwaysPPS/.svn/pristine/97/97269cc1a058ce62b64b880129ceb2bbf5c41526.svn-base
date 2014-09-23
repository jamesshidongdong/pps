using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class CtMilestoneTemplateConfiguration : EntityTypeConfiguration<CtMilestoneTemplate>
    {
        public CtMilestoneTemplateConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctMilestoneTemplate");
            HasKey(x => x.MilestoneTemplateId);

            Property(x => x.MilestoneTemplateId).HasColumnName("MilestoneTemplateId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MilestoneTemplateName).HasColumnName("MilestoneTemplateName").IsOptional().HasMaxLength(100);
            Property(x => x.DefaultTemplate).HasColumnName("DefaultTemplate").IsOptional();
            Property(x => x.HidePlanStartDate).HasColumnName("HidePlanStartDate").IsOptional();
            Property(x => x.HidePlanEndDate).HasColumnName("HidePlanEndDate").IsOptional();
            Property(x => x.HideReviseStartDate).HasColumnName("HideReviseStartDate").IsOptional();
            Property(x => x.HideReviseEndDate).HasColumnName("HideReviseEndDate").IsOptional();
            Property(x => x.HideActualStartDate).HasColumnName("HideActualStartDate").IsOptional();
            Property(x => x.HideActualEndDate).HasColumnName("HideActualEndDate").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}